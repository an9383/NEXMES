using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;

namespace WIZ.WM
{
    public partial class WM0200 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        //선택수량 관리용 변수
        Hashtable hash = new Hashtable();
        #endregion

        #region<CONSTRUCTOR>
        public WM0200()
        {
            InitializeComponent();
        }
        #endregion

        #region<WM0200_Load>
        private void WM0200_Load(object sender, EventArgs e)
        {
            #region 그리드
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);
            // InitColumnUltraGrid
            // 0. gird 명, 1 칼럼명, 2.aption  3. colNotNullable, 4.colDataType
            // 5.columnWidth, 6.maxLength, 7. HAlign, 8. visible, 9. editable, 10. formatString, 
            // 11. editMask, 12. maxValue, 13. minValue, 14. regexPattern

            _GridUtil.InitColumnUltraGrid(grid1, "INDATE", "입고일자", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "Lot No", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TOPLANTCODE", "현사업장", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TOWH", "현창고", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "TOWHNAME", "현창고명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FROMPLANTCODE", "이전 사업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FROMWH", "이전창고", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FROMWHNAME", "이전창고명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "INQTY", "입고수량", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);


            _GridUtil.SetInitUltraGridBind(grid1);

            //     ///row number
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            //MERGE
            grid1.Columns["INDATE"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["INDATE"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["INDATE"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["LOTNO"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["LOTNO"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["LOTNO"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["ITEMCODE"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["ITEMCODE"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["ITEMCODE"].MergedCellStyle = MergedCellStyle.Always;

            uccRecDateStart.Value = DateTime.Now;
            uccRecDateEnd.Value = DateTime.Now;

            #endregion

            #region 콤보박스

            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //공장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "FROMPLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "TOPLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");


            #endregion

            #region 팝업 설정
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtWHCode, txtWHName, "TBM0800", new object[] { cboPlantCode, "", "", "", "" });
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode, "" });
            #endregion
        }
        #endregion

        #region <TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                base.DoInquire();
                grid1.DataSource = helper.FillTable("USP_WM0200_S1N", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("pPlantCode", Convert.ToString(cboPlantCode.Value), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("pWHCode", Convert.ToString(txtWHCode.Text), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("pWHName", Convert.ToString(txtWHName.Text), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("pItemCode", Convert.ToString(txtItemCode.Text), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("pItemName", Convert.ToString(txtItemName.Text), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("pStartLot", Convert.ToString(txtStartLot.Text), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("pEndLot", Convert.ToString(txtEndLot.Text), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("pType", Convert.ToString(ultraOptionSet1.CheckedItem.Tag), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("pStartDate", Convert.ToDateTime(uccRecDateStart.Value).ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("pEndDate", Convert.ToDateTime(uccRecDateEnd.Value).ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input));
                grid1.DataBinds();
                hash.Clear();

                switch (Convert.ToString(ultraOptionSet1.CheckedItem.Tag))
                {
                    case "L":
                        grid1.Columns["LOTNO"].Hidden = false;
                        grid1.Columns["ITEMCODE"].Hidden = true;

                        break;
                    case "I":
                        grid1.Columns["LOTNO"].Hidden = true;
                        grid1.Columns["ITEMCODE"].Hidden = false;

                        break;
                    case "G":
                        grid1.Columns["LOTNO"].Hidden = false;
                        grid1.Columns["ITEMCODE"].Hidden = true;

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
                IsShowDialog = false;
            }
        }
        #endregion

        #region<METHOD AREA>
        private void ultraOptionSet1_ValueChanged(object sender, EventArgs e)
        {
            DoInquire();

            this.ClosePrgFormNew();
        }
        #endregion
    }
}

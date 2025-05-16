using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;

namespace WIZ.QM
{
    public partial class QM1500 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        #endregion

        #region<CONSTRUCTOR>
        public QM1500()
        {
            InitializeComponent();
        }
        #endregion

        #region<QM1500_Load>
        private void QM1500_Load(object sender, EventArgs e)
        {
            #region 하단 그리드
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkDate", "발생일", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "workcentercode", "작업장", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "workcentername", "작업장명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "완성품목", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Itemname", "완성품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Step", "단계", false, GridColDataType_emu.VarChar, 60, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DSeq", "자품목순서", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Default, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Component", "자품목", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Componentname", "자품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemType", "제품군", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CustCode", "업체코드", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Custname", "업체명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ComponentQty", "U/S", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "QTY", "수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorClass", "불량유형", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ErrorCode", "불량명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProdFlag", "1차판정(생산)", false, GridColDataType_emu.VarChar, 110, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OutFlag", "판정", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Remark", "비고", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "작성일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "작성자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "승인일", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "승인자", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProcFlag", "처리구분", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, false, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            //     ///row number
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #region Grid MERGE
            grid1.Columns["PlantCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["PlantCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["PlantCode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["WorkDate"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["WorkDate"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["WorkDate"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["workcentercode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["workcentercode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["workcentercode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["workcentername"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["workcentername"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["workcentername"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["ItemCode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["ItemCode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["ItemCode"].MergedCellStyle = MergedCellStyle.Always;

            grid1.Columns["Itemname"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["Itemname"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["Itemname"].MergedCellStyle = MergedCellStyle.Always;
            #endregion Grid MERGE

            #endregion

            #region 상단 그리드
            _GridUtil.InitializeGrid(this.grid2, true, false, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid2, "PlantCode", "사업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WorkDate", "생산일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "DayNight", "주야구분", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WorkCenterCode", "작업장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "WorkCenterName", "작업장명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ItemCode", "완성품목", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ItemName", "완성품명", true, GridColDataType_emu.VarChar, 160, 100, Infragistics.Win.HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "QTY", "수량", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "BadType", "불량", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "ProdFlag", "판정", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "OutFlag", "판정", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid2);

            //     ///row number
            grid2.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid2.DisplayLayout.Override.RowSelectorWidth = 40;
            grid2.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid2.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            #endregion

            #region 콤보 박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("INSPKIND");   // 사내/외주
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ProdFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "OutFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("ErrorClass");  // 유형
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ErrorClass", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("ItemType");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ItemType", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DAYNIGHT");
            WIZ.Common.FillComboboxMaster(this.cboDayNight_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "DayNight", rtnDtTemp, "CODE_ID", "CODE_NAME");
            #endregion

            BizTextBoxManager tBizManager = new BizTextBoxManager();
            tBizManager.PopUpAdd(txtItemCode_H, txtItemName_H, "TBM0100", new object[] { cboPlantCode_H, "" });
            tBizManager.PopUpAdd(txtWorkCenterCode_H, txtWorkCenterName_H, "TBM0600", new object[] { cboPlantCode_H, "", txtItemCode_H, txtItemName_H });

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

                string sPlantCode = DBHelper.nvlString(cboPlantCode_H.Value);  // 공장코드
                string sWorkCenterCode = txtWorkCenterCode_H.Text;
                string sWorkCenterName = txtWorkCenterName_H.Text;
                string sItemCode = txtItemCode_H.Text;
                string sItemName = txtItemName_H.Text;
                string sStartDate = Convert.ToDateTime(CboStartDate_H.Value).ToString("yyyy-MM-dd");
                string sEndDate = Convert.ToDateTime(CboEndDate_H.Value).ToString("yyyy-MM-dd");
                string sDayNight = DBHelper.nvlString(cboDayNight_H.Value);

                grid2.DataSource = helper.FillTable("USP_QM1500_S2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("pPlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pWorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pWorkCenterName", sWorkCenterName, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pItemName", sItemName, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pDayNight", sDayNight, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pStartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                                   , helper.CreateParameter("pEndDate", sEndDate, DbType.String, ParameterDirection.Input));
                grid2.DataBinds();


                DataTable DtTemp = new DataTable();
                DtTemp = (DataTable)grid1.DataSource;
                DtTemp.Rows.Clear();
                grid1.DataSource = DtTemp;
                grid1.DataBinds();

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


        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {

        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {

        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {

        }
        #endregion

        #region 버튼 이벤트
        private void grid2_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {

            DBHelper helper = new DBHelper(false);

            try
            {

                string sPlantCode = grid2.ActiveRow.Cells["PlantCode"].Value.ToString();  // 공장코드
                string sworkcentercode = grid2.ActiveRow.Cells["workcentercode"].Value.ToString();
                string sItemCode = grid2.ActiveRow.Cells["ItemCode"].Value.ToString();
                string sWorkDate = grid2.ActiveRow.Cells["WorkDate"].Value.ToString();

                grid1.DataSource = helper.FillTable("USP_QM1500_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("workcentercode", sworkcentercode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("ItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("RecDate", sWorkDate, DbType.String, ParameterDirection.Input));

                grid1.DataBinds();



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
    }
}

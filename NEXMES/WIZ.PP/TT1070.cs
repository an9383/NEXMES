#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : TT1070
//   Form Name    : 3차원 측정값 조회
//   Name Space   : WIZ.PP.DLL
//   Created Date : 2012-12-20
//   Made By      : WIZCORE - 동상현 
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>

using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;


#endregion
namespace WIZ.PP
{
    public partial class TT1070 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        int iColCount;
        Common _Common = new Common();
        BizTextBoxManager btbManager;
        //임시로 사용할 데이터테이블 생성
        DataTable _DtTemp = new DataTable();
        #endregion

        #region<CONSTRUCTOR>

        public TT1070()
        {
            InitializeComponent();
            btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtInspCode, txtInspName, "TBM1500", new object[] { "", "", "" });
            btbManager.PopUpAdd(txtItemCode, txtItemName, "TBM0100", new object[] { cboPlantCode_H, "" });
        }
        #endregion

        #region<TT1070_Load>
        private void TT1070_Load(object sender, EventArgs e)
        {
            #region Grid 셋팅
            //그리드 객체 생성
            UltraGridUtil _GridUtil = new UltraGridUtil();
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PlantCode", "공장", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemCode", "품목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ItemName", "품목명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspCode", "검사항목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspName", "검사항목명", false, GridColDataType_emu.VarChar, 170, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspDate", "측정일", false, GridColDataType_emu.DateTime, 120, 100, Infragistics.Win.HAlign.Center, true, false, "yyyy-MM-dd", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "InspDN", "주야", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Seq", "NO", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "LotNo", "측정LOT", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "RstValue", "측정값", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProcFlag", "처리구분", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OKNG", "판정", false, GridColDataType_emu.VarChar, 70, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProcInspDate", "검사일", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ProcInspDN", "검사주/야", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OrgInspDate", "수집일시", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false, "yyyy-MM-dd HH:mm:ss", null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수집자", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false, null, null, null, null, null);

            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Bands[0].RowLayoutStyle = RowLayoutStyle.GroupLayout;
            //Enbale Column/Group moving

            iColCount = grid1.Columns.Count;
            //     ///row number
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 40;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;


            #region Grid MERGE
            grid1.Columns["plantcode"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
            grid1.Columns["plantcode"].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
            grid1.Columns["plantcode"].MergedCellStyle = MergedCellStyle.Always;

            #endregion Grid MERGE


            #endregion



            #region 콤보박스
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PlantCode", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DAYNIGHT");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "InspDN", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.Common.FillComboboxMaster(this.cboDayNight, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

            rtnDtTemp = _Common.GET_BM0000_CODE("PROCFLAG");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ProcFlag", rtnDtTemp, "CODE_ID", "CODE_NAME");
            //WIZ.Common.FillComboboxMaster(this.cboDayNight2, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
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

                string sPlantCode = cboPlantCode_H.Value.ToString() == "ALL" ? "" : cboPlantCode_H.Value.ToString();
                string sItemCode = txtItemCode.Text.Trim();
                string sItemName = txtItemName.Text.Trim();
                string sInspCode = txtInspCode.Text.Trim();
                string sInspName = txtInspName.Text.Trim();
                string sWorkDN = Convert.ToString(cboDayNight.Value);
                string sOKNG = txtOKNG.Text.Trim();
                string sStartDate = string.Format("{0:yyyy-MM-dd 00:00:00}", CboStartdate_H.Value);
                string sEndDate = string.Format("{0:yyyy-MM-dd 23:59:59}", CboEnddate_H.Value);

                grid1.DataSource = helper.FillTable("USP_TT1070_S1", CommandType.StoredProcedure
                                                            , helper.CreateParameter("@pPlantCode", sPlantCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@pStartDate", sStartDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@pEndDate", sEndDate, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@pItemCode", sItemCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@pItemName", sItemName, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@pDayNightIn", sWorkDN, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@pInspCode", sInspCode, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@pInspName", sInspName, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@pDayNightPIn", sWorkDN, DbType.String, ParameterDirection.Input)
                                                            , helper.CreateParameter("@OKNG", sOKNG, DbType.String, ParameterDirection.Input));

                DataTable dt = new DataTable();
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
    }
}

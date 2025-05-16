#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM0122
//   Form Name    : BOM 조회
//   Name Space   : WIZ.BM
//   Created Date : 2020-09-23
//   Made By      : inho.hwang
//   Edited Date  : 
//   Edit By      :
//   Description  : BOM 조회
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Windows.Forms;
using WIZ.PopUp;
#endregion

namespace WIZ.BM
{
    public partial class BM0122 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성
        Common _Common = new Common();
        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성


        string sUserID = WIZ.LoginInfo.UserID;       // Defalue 사용자
        #endregion

        #region < CONSTRUCTOR >
        public BM0122()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void BM0122_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //grid1 품목 (grid1는 좌측 상단 두번쨰 GRID, GRID를 추가시 좌측상단부터 GRID 채번) (GRID EDITABLE 은 FALSE)
                _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 140, 150, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.SetInitUltraGridBind(grid1);

                _GridUtil.InitializeGrid(this.grid2, true, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 120, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 90, 120, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 140, 150, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "COMPONENT", "투입품목", true, GridColDataType_emu.VarChar, 140, 150, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "COMP_NAME", "투입품명", true, GridColDataType_emu.VarChar, 140, 150, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMTYPE", "품목유형", true, GridColDataType_emu.VarChar, 90, 120, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMGROUP", "품목종류", true, GridColDataType_emu.VarChar, 140, 150, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "OPCODE", "공정코드", true, GridColDataType_emu.VarChar, 140, 150, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "OPNAME", "공정명", true, GridColDataType_emu.VarChar, 140, 150, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "PHANTOM", "가상코드여부", false, GridColDataType_emu.VarChar, 50, 150, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SEQ", "순번", false, GridColDataType_emu.VarChar, 50, 150, Infragistics.Win.HAlign.Left, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "UNIT", "단위", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "QTY", "소요량", true, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "CAL_QTY", "계산 소요량", true, GridColDataType_emu.Double, 90, 100, Infragistics.Win.HAlign.Center, false, false);
                _GridUtil.InitColumnUltraGrid(grid2, "LVL", "단계", true, GridColDataType_emu.Integer, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "SORTCOL", "숨김항목", false, GridColDataType_emu.VarChar, 50, 150, Infragistics.Win.HAlign.Left, false, false);

                _GridUtil.SetInitUltraGridBind(grid2);

                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;


                rtnDtTemp = _Common.GET_BM0000_CODE("ITEMTYPE"); //품목유형
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "ITEMTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                rtnDtTemp = _Common.GET_BM0000_CODE("ITEMGROUP"); //품목종류
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "ITEMGROUP", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0130_CODE("Y"); //단위               
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "UNIT", rtnDtTemp, "CODE_ID", "CODE_NAME");

                #endregion

                #region POPUP SETTING

                //품목
                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });

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
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화

            base.DoInquire();

            DBHelper helper = new DBHelper(false);
            string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
            string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());
            string sSubItemCode = DBHelper.nvlString(txt_SubItemCode.Text.Trim());
            string sSubItemName = DBHelper.nvlString(txt_SubItemName.Text.Trim());

            //grid1 품목 조회
            try
            {

                if (sItemCode == "")
                {
                    ClosePrgFormNew();
                    this.ShowDialog(Common.getLangText("품목을  입력 후 조회하세요.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                rtnDtTemp = helper.FillTable("USP_BM0122_S2", CommandType.StoredProcedure
                                        , helper.CreateParameter("AS_PCODE", "S1", DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_SUBITEMCODE", sSubItemCode, DbType.String, ParameterDirection.Input)
                                        , helper.CreateParameter("AS_SUBITEMNAME", sSubItemName, DbType.String, ParameterDirection.Input)
                                        );

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
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

        private void DoInquire2()
        {
            _GridUtil.Grid_Clear(grid2); // 조회전 그리드 초기화
            DBHelper helper = new DBHelper(false);

            string sItemCode = grid1.ActiveRow.Cells["ITEMCODE"].Text;
            string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
            string sSubItemCode = DBHelper.nvlString(txt_SubItemCode.Text.Trim());
            string sSubItemName = DBHelper.nvlString(txt_SubItemName.Text.Trim());

            rtnDtTemp = helper.FillTable("USP_BM0122_S2", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PCODE", "S2", DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_SUBITEMCODE", sSubItemCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_SUBITEMNAME", sSubItemName, DbType.String, ParameterDirection.Input)
                                    );

            grid2.DataSource = rtnDtTemp;
            grid2.DataBinds();
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        /// <summary>

        ///
        /// ToolBar의 저장 버튼 Click
        /// </summary>

        /// <summary>
        /// ToolBar의 엑셀업로드 버튼 Click
        /// </summary>

        public override void DoImportExcel()
        {
            base.DoImportExcel();

            BM0120_EXCEL BM0120_excel = new BM0120_EXCEL();
            BM0120_excel.ShowDialog();

            base.DoInquire();
        }
        #endregion

        #region < EVENT AREA >

        #endregion

        private void grid1_ClickCell(object sender, ClickCellEventArgs e)
        {
            DoInquire2();
        }

        private void grid1_KeyUp(object sender, KeyEventArgs e)
        {
            DoInquire2();
        }
    }
}
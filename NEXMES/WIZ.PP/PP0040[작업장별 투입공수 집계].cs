#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP0040
//   Form Name    : 작업장별 투입공수 집계
//   Name Space   : WIZ.PP
//   Created Date : 2018-01-17
//   Made By      : WIZCORE
//   Edited Date  : 
//   Edit By      :
//   Description  : 작업장별 투입공수 집계 관리
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using WIZ.PopUp;
#endregion

namespace WIZ.PP
{
    public partial class PP0040 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataSet rtnDsTemp = new DataSet();      // return DataSet 공통
        DataTable rtnDtTemp = new DataTable();  // return DataTable 공통
        DataTable _DtTemp = new DataTable();    //임시로 사용할 데이터테이블 생성

        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        Common _Common = new Common();

        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        string SelBanCode = string.Empty;
        #endregion

        #region < CONSTRUCTOR >
        public PP0040()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void PP0040_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1
                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "GNAME", "항 목", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "TOT", "합계(시간)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "M01", "1월(시간)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "M02", "2월(시간)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "M03", "3월(시간)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "M04", "4월(시간)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "M05", "5월(시간)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "M06", "6월(시간)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "M07", "7월(시간)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "M08", "8월(시간)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "M09", "9월(시간)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "M10", "10월(시간)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "M11", "11월(시간)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "M12", "12월(시간)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);

                _GridUtil.SetInitUltraGridBind(grid1);

                #endregion

                //사용자 입력이 필요하지 않은 부분은 행 추가시 수정이 안되도록 조치
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;

                grid1.DisplayLayout.Override.MergedCellAppearance.TextVAlign = Infragistics.Win.VAlign.Top;
                grid1.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;

                grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.None;

                grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                rtnDtTemp = _Common.GET_BM0060_CODE(""); //작업장             
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WORKCENTERCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                cbo_YEAR_H.Value = DateTime.Now;
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
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);                    //공장
                string sYear = Convert.ToDateTime(this.cbo_YEAR_H.Value).ToString("yyyy");   //조회년도
                string sWorkcenterCode = DBHelper.nvlString(txt_WORKCENTERCODE_H.Text.Trim());         //작업장코드                
                string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());               //품목

                rtnDtTemp = helper.FillTable("USP_PP0040_S1", CommandType.StoredProcedure
                                                         , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("AS_YEAR", sYear, DbType.String, ParameterDirection.Input)
                                                         , helper.CreateParameter("AS_WORKCENTERCODE", sWorkcenterCode, DbType.String, ParameterDirection.Input));

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

        private void grid1_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            if (Convert.ToString(e.Row.Cells["GNAME"].Value) == "총가동공수")
                e.Row.Appearance.BackColor = Color.FromArgb(254, 252, 177);
            else if (Convert.ToString(e.Row.Cells["GNAME"].Value) == "총부하공수")
                e.Row.Appearance.BackColor = Color.FromArgb(227, 243, 251);
            else if (Convert.ToString(e.Row.Cells["GNAME"].Value) == "시간가동율")
                e.Row.Appearance.BackColor = Color.FromArgb(243, 254, 227);
            else
                e.Row.Appearance.BackColor = Color.White;

            e.Row.Cells["GNAME"].Appearance.FontData.Bold = DefaultableBoolean.True;
        }
        #endregion
    }
}
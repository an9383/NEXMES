#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0040
//   Form Name    : 작업장별 작업지시현황
//   Name Space   : WIZ.AP
//   Created Date : 2018-01-16
//   Made By      : WIZ
//   Edited Date  : 
//   Edit By      :
//   Description  : 
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

namespace WIZ.AP
{
    public partial class AP0040 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        DataSet rtnDsTemp = new DataSet();              //return DataSet 공통
        DataTable rtnDtTemp = new DataTable();          //return DataTable 공통
        DataTable _DtTemp = new DataTable();            //임시로 사용할 데이터테이블

        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        Common _Common = new Common();                  //COMMON 객체 생성

        BizTextBoxManager btbManager = new BizTextBoxManager(); //팝업 매니저      
        BizGridManager gridManager;

        private string plantCode = string.Empty; //plantcode default 설정

        #endregion

        #region < CONSTRUCTOR >

        public AP0040()
        {
            InitializeComponent();
        }

        #endregion

        #region < FORM LOAD >
        private void AP0040_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1
                _GridUtil.InitializeGrid(this.grid1, true, false, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERDATE", "지시일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "CONTRACTNO", "수주번호", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANNO", "생산계획번호", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "작업지시번호", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY", "지시수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "생산수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", false, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
                //_GridUtil.InitColumnUltraGrid(grid1, "ORDERFIX",       "확정여부",      false, GridColDataType_emu.VarChar,  80, 100, Infragistics.Win.HAlign.Center, true, false, null,    null, null, null, null);   
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERTYPE", "지시구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERSTATUS", "진행상태", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "LASTDATE", "최종변경일시", false, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Center, true, false);

                grid1.Columns["ORDERQTY"].Format = "#,##0";
                grid1.Columns["PRODQTY"].Format = "#,##0";

                _GridUtil.SetInitUltraGridBind(grid1);

                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "전체", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
                cbo_ENDDATE_H.Value = DateTime.Now;
                #endregion

                #region POPUP SETTING

                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });
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
            _GridUtil.Grid_Clear(grid1);

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);                //공장                                
                string sWcCode = DBHelper.nvlString(txt_WORKCENTERCODE_H.Text.Trim());     //작업장
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);   //조회 시작일자
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);     //조회 종료일자
                string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());           //품목
                string sOrderNo = DBHelper.nvlString(txt_ORDERNO_H.Text.Trim());            //계획일자                

                if (DateCheck.CheckDate(sStartDate, sEndDate) == false)
                {
                    this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    return;
                }

                rtnDtTemp = helper.FillTable("USP_AP0040_S1", CommandType.StoredProcedure
                                , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_WORKCENTERCODE", sWcCode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                , helper.CreateParameter("AS_ORDERNO", sOrderNo, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = UltraGridUtil.SetSubTotalUltraGrid(grid1, rtnDtTemp, "WORKCENTERCODE", Common.getLangText("[ 작업장별 합계 ]", "TEXT"), "WORKCENTERNAME", "ORDERQTY,PRODQTY", "SUM,SUM");
                    grid1.DataBinds();

                    grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;
                    grid1.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always;

                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        grid1.DisplayLayout.Rows[i].Appearance.BorderColor = Color.Black;
                    }

                    for (int i = 0; i < grid1.DisplayLayout.Bands[0].Columns.Count; i++)
                    {
                        grid1.DisplayLayout.Bands[0].Columns[i].CellAppearance.BorderColor = Color.Black;
                    }

                    grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                    grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.Default;

                    grid1.DisplayLayout.Override.MergedCellAppearance.TextVAlign = VAlign.Top;
                    grid1.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;

                    grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    this.ShowDialog(Common.getLangText("조회 할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);    //조회할 데이터가 없습니다.
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

        /// <summary>
        /// Grid1 BackColor White
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*private void grid1_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            try
            {
                e.Row.Appearance.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }*/

        /// <summary>
        /// 작업지시 변경 이력 팝업창 오픈 처리.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            try
            {
                string sOrderNo = grid1.ActiveRow.Cells["ORDERNO"].Value.ToString();
                string sOrderType = grid1.ActiveRow.Cells["ORDERTYPE"].Value.ToString();

            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        #endregion
    }
}

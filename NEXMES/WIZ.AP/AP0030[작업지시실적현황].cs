#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : AP0030
//   Form Name    : 작업지시 실적현황
//   Name Space   : WIZ.AP
//   Created Date : 2018-01-15
//   Made By      : WIZCORE 남부사무소 사원 윤근욱
//   Edited Date  : 
//   Edit By      :
//   Description  : 작업지시 별 지시수량 대비 실적 관리
// *---------------------------------------------------------------------------------------------*                                                                                                   
#endregion

#region < USING AREA >
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using WIZ.PopUp;
#endregion

namespace WIZ.AP
{
    public partial class AP0030 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >

        //그리드 객체 생성
        UltraGridUtil _GridUtil = new UltraGridUtil();
        BizTextBoxManager btbManager = new BizTextBoxManager();
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        Common _Common = new Common();

        private string plantCode = string.Empty; //plantcode default 설정

        string sUseFlag = string.Empty;
        string sLineCode = string.Empty;
        string sOPCode = string.Empty;

        #endregion

        #region < CONSTRUCTOR >

        public AP0030()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void AP0030_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명", false, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "지시번호", false, GridColDataType_emu.VarChar, 130, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERDATE", "지시일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERTYPE", "지시구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY", "지시수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,###", "nnn,nnn,nnn", null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "PRODDATE", "생산일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "생산수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,###", "nnn,nnn,nnn", null, null, null);
                _GridUtil.InitColumnUltraGrid(grid1, "QTYPERCENT", "달성율(%)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);


                _GridUtil.SetInitUltraGridBind(grid1);


                _GridUtil.InitializeGrid(this.grid2, true, true, false, "", false);

                _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 200, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ORDERDATE", "지시일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ORDERTYPE", "지시구분", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "ORDERQTY", "지시수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,###", "nnn,nnn,nnn", null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "PRODDATE", "생산일자", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid2, "PRODQTY", "생산수량", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false, "#,###", "nnn,nnn,nnn", null, null, null);
                _GridUtil.InitColumnUltraGrid(grid2, "QTYPERCENT", "달성율(%)", false, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Right, true, false);

                _GridUtil.SetInitUltraGridBind(grid2);
                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");


                rtnDtTemp = _Common.GET_BM0000_CODE("ORDERTYPE"); //작업지시구분
                WIZ.Common.FillComboboxMaster(this.cbo_ORDERTYPE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ORDERTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid2, "ORDERTYPE", rtnDtTemp, "CODE_ID", "CODE_NAME");

                cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
                cbo_ENDDATE_H.Value = DateTime.Now;

                plantCode = CModule.GetAppSetting("Site", "10");
                cbo_PLANTCODE_H.Text = plantCode;
                #endregion

                #region POPUP SETTING

                btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" }); //품목            
                btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" }); //작업장
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
            _GridUtil.Grid_Clear(grid2);

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);                //사업장
                string sStartDate = string.Format("{0:yyyy-MM-dd}", cbo_STARTDATE_H.Value);   //실적일자(시작)
                string sEndDate = string.Format("{0:yyyy-MM-dd}", cbo_ENDDATE_H.Value);     //실적일자(종료)
                string sWcCode = DBHelper.nvlString(txt_WORKCENTERCODE_H.Text.Trim());     //작업장
                string sOrderNo = DBHelper.nvlString(txt_ORDERNO_H.Text.Trim());            //작업지시번호
                string sItemCode = DBHelper.nvlString(txt_ITEMCODE_H.Text.Trim());           //품목
                string sOrderType = DBHelper.nvlString(cbo_ORDERTYPE_H.Value);                //작업지시구분

                if (DateCheck.CheckDate(sStartDate, sEndDate) == false)
                {
                    this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); //시작일자를 종료일자보다 이전으로 선택해주십시오.
                    return;
                }
                if (tabControl1.SelectedTab.Index == 0)
                {
                    // 계획대비 실적현황(계획별)
                    rtnDtTemp = helper.FillTable("USP_AP0030_S1", CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_FLAG", "TAB1", DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_WCCODE", sWcCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_SDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_EDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ORDERNO", sOrderNo, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ORDERTYPE", sOrderType, DbType.String, ParameterDirection.Input));

                    this.ClosePrgFormNew();
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        DataTable DtGrid = rtnDtTemp.Clone();

                        grid1.DataSource = UltraGridUtil.SetSubTotalUltraGrid(grid1, rtnDtTemp, "WORKCENTERCODE", Common.getLangText("[ 작업장별 합계 ]", "TEXT"), "WORKCENTERNAME", "ORDERQTY,PRODQTY,QTYPERCENT", "SUM,SUM,AVG"); ;
                        grid1.DataBinds();

                        grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
                        grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;
                        grid1.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always;
                        grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
                        grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellStyle = MergedCellStyle.Always;

                        grid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                        grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;

                        grid1.DisplayLayout.Override.MergedCellAppearance.TextVAlign = Infragistics.Win.VAlign.Top;
                        grid1.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;
                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid1);
                        this.ShowDialog(Common.getLangText("조회 할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);
                    }
                    //그리드 가로 세로 Line 설정
                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        grid1.DisplayLayout.Rows[i].Appearance.BorderColor = Color.Black;
                    }
                }
                else if (tabControl1.SelectedTab.Index == 1)
                {
                    // 계획대비 실적현황(품목별) 
                    rtnDtTemp = helper.FillTable("USP_AP0030_S1", CommandType.StoredProcedure
                                            , helper.CreateParameter("AS_FLAG", "TAB2", DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_WCCODE", sWcCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_SDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_EDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ORDERNO", sOrderNo, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                            , helper.CreateParameter("AS_ORDERTYPE", sOrderType, DbType.String, ParameterDirection.Input));

                    this.ClosePrgFormNew();
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        DataTable DtGrid = rtnDtTemp.Clone();

                        grid2.DataSource = UltraGridUtil.SetSubTotalUltraGrid(grid1, rtnDtTemp, "ITEMCODE", Common.getLangText("[ 품목별 합계 ]", "TEXT"), "ITEMNAME", "ORDERQTY,PRODQTY,QTYPERCENT", "SUM,SUM,AVG");
                        grid2.DataBinds();

                        grid2.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
                        grid2.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle = MergedCellStyle.Always;
                        grid2.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellStyle = MergedCellStyle.Always;

                        grid2.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                        grid2.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;

                        grid2.DisplayLayout.Override.MergedCellAppearance.TextVAlign = Infragistics.Win.VAlign.Top;
                        grid2.DisplayLayout.Override.MergedCellContentArea = MergedCellContentArea.VisibleRect;
                    }
                    else
                    {
                        _GridUtil.Grid_Clear(grid2);
                        this.ShowDialog(Common.getLangText("조회 할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK);    //조회할 데이터가 없습니다.
                    }

                }

                //그리드 가로 세로 Line 설정
                for (int i = 0; i < grid2.Rows.Count; i++)
                {
                    grid2.DisplayLayout.Rows[i].Appearance.BorderColor = Color.Black;
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

        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            try
            {
                base.DoNew();
            }
            catch (Exception ex)
            {
                this.ShowDialog(ex.Message, Forms.DialogForm.DialogType.OK);
            }
        }

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();

            this.grid1.DeleteRow();
        }

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            base.DoSave();
        }
    }
}

public class DateCheck
{
    public static bool CheckDate(string sDate, string eDate)
    {
        int Start = int.Parse(string.Format("{0:yyyyMMdd}", sDate.Replace("-", "")));
        int End = int.Parse(string.Format("{0:yyyyMMdd}", eDate.Replace("-", "")));

        if (Start > End)
            return false;
        else
            return true;
    }
}
#endregion

#region < EVNET AREA >

#endregion
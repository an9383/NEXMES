#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : DG0420
//   Form Name    : 작업장별 가동현황
//   Name Space   : WIZ.PP
//   Created Date : 2018-01-17
//   Made By      : WIZCORE 남부사무소 사원 최수정
//   Edited Date  : 
//   Edit By      :
//   Description  : 작업장별 가동현황
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using WIZ.PopUp;
#endregion

namespace WIZ.MT
{
    using Infragistics.Win.UltraWinGrid;

    public partial class DG0420 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataSet rtnDsTemp = new DataSet();    //return DataSet 공통
        DataTable rtnDtTemp = new DataTable();  //return DataTable 공통
        DataTable _DtTemp = new DataTable();    //임시로 사용할 데이터테이블 생성

        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        Common _Common = new Common();

        BizTextBoxManager btbManager = new BizTextBoxManager(); //콤보박스 객체 생성

        #endregion

        #region < CONSTRUCTOR >
        public DG0420()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void DG0420_Load(object sender, EventArgs e)
        {
            try
            {
                #region GRID SETTING

                //GRID1
                _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, 100, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "EQPID", "설비코드", false, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "JOBID", "LOTNO", false, GridColDataType_emu.Float, 150, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ALPOSX", "도면 X좌표", false, GridColDataType_emu.Float, 150, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ALPOSY", "도면 Y좌표", false, GridColDataType_emu.Float, 150, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ALTPX", "PA X데이터", false, GridColDataType_emu.Float, 150, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ALTPY", "PA Y데이터", false, GridColDataType_emu.Float, 150, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "DIA", "지름", false, GridColDataType_emu.Float, 150, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "ROUND", "진원도", false, GridColDataType_emu.Float, 150, 100, Infragistics.Win.HAlign.Center, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "DATETIME", "발생시각", false, GridColDataType_emu.DateTime, 180, 100, Infragistics.Win.HAlign.Center, true, false);

                //_GridUtil.InitColumnUltraGrid(grid1, "STATUS",         "상태",         false, GridColDataType_emu.VarChar,   90, 100, Infragistics.Win.HAlign.Left,   true,   false);
                //_GridUtil.InitColumnUltraGrid(grid1, "STOPCODE",       "비가동코드",   false, GridColDataType_emu.VarChar,   90, 100, Infragistics.Win.HAlign.Center, true,   false);
                //_GridUtil.InitColumnUltraGrid(grid1, "STOPDESC",       "비가동명",     false, GridColDataType_emu.VarChar,  150, 100, Infragistics.Win.HAlign.Left,   true,   false);
                //_GridUtil.InitColumnUltraGrid(grid1, "STATUSTIME",     "작업시간(분)", false, GridColDataType_emu.VarChar,  100, 100, Infragistics.Win.HAlign.Right,  true,   false);
                //_GridUtil.InitColumnUltraGrid(grid1, "WORKERCNT",      "작업자수",     false, GridColDataType_emu.VarChar,  100, 100, Infragistics.Win.HAlign.Right,  true,   false);
                //_GridUtil.InitColumnUltraGrid(grid1, "ORDERNO",        "계획번호",     false, GridColDataType_emu.VarChar,  130, 100, Infragistics.Win.HAlign.Center, true,   false);
                //_GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",       "생산품목",     false, GridColDataType_emu.VarChar,  120, 100, Infragistics.Win.HAlign.Left,   true,   false);
                //_GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",       "생산품명",     false, GridColDataType_emu.VarChar,  200, 100, Infragistics.Win.HAlign.Left,   true,   false);
                //_GridUtil.InitColumnUltraGrid(grid1, "PRODQTY",        "생산수량",     false, GridColDataType_emu.VarChar,  100, 100, Infragistics.Win.HAlign.Right,  true,   false);
                //_GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE",       "결품업체",     false, GridColDataType_emu.VarChar,  180, 100, Infragistics.Win.HAlign.Left,   true,   false);
                //_GridUtil.InitColumnUltraGrid(grid1, "NOWLS",          "종료여부",     false, GridColDataType_emu.VarChar,   90, 100, Infragistics.Win.HAlign.Left,   true,   false);   

                //grid1.Columns["STATUSTIME"].Format = "#,##0.00";
                //grid1.Columns["PRODQTY"].Format = "#,##0";

                _GridUtil.SetInitUltraGridBind(grid1);

                #endregion

                #region COMBOBOX SETTING

                rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
                WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
                cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

                //rtnDtTemp = _Common.GET_BM0000_CODE("YESNO");
                //WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "NOWLS", rtnDtTemp, "CODE_ID", "CODE_NAME");

                rtnDtTemp = _Common.GET_BM0000_CODE("HIMSEQUIP"); //설비코드
                WIZ.Common.FillComboboxMaster(this.cbo_HIMSEQUIP_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");

                cbo_STARTDATE_H.Value = DateTime.Now.AddHours(-6);
                cbo_ENDDATE_H.Value = DateTime.Now.AddDays(1);
                #endregion

                #region POPUP SETTING
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
        /// /// ToolBar의 조회 버튼 클릭
        /// /// </summary>
        public override void DoInquire()
        {
            _GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);                            //공장
                string sEquipCode = DBHelper.nvlString(cbo_HIMSEQUIP_H.Value);                            //설비
                string sStartDate = DBHelper.nvlDateTime(cbo_STARTDATE_H.Value).ToString("yyyy-MM-dd");   //시작일자
                string sEndDate = DBHelper.nvlDateTime(cbo_ENDDATE_H.Value).ToString("yyyy-MM-dd");     //완료일자

                //if (Common.DateCheck.CheckDate(sStartDate, sEndDate) == false)
                //{
                //    this.ShowDialog(Common.getLangText("시작일자를 종료일자보다 이전으로 선택해주십시오.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); 
                //    return;
                //}
                rtnDtTemp = helper.FillTable("USP_DG0420_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_EQUIPCODE", sEquipCode, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input));

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
        #endregion 

        #region < EVENT AREA >
        private void grid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //CustomMergedCellEvalutor CM1 = new CustomMergedCellEvalutor("WORKCENTERCODE", "WORKCENTERNAME");
            //e.Layout.Bands[0].Columns["PLANTCODE"].MergedCellEvaluator = CM1;
            //e.Layout.Bands[0].Columns["RECDATE"].MergedCellEvaluator = CM1;
            //e.Layout.Bands[0].Columns["DAYNIGHT"].MergedCellEvaluator = CM1;
        }

        /*        private void grid1_InitializeRow(object sender, InitializeRowEventArgs e)
                {
                    if (Convert.ToString(e.Row.Cells["NOWLS"].Value) == "N")
                        e.Row.Appearance.BackColor = Color.FromArgb(254, 252, 177);
                    else
                        e.Row.Appearance.BackColor = Color.White;
                }*/

        #endregion

    }
}

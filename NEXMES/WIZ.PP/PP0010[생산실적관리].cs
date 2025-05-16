#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP0010
//   Form Name    : 생산실적관리
//   Name Space   : WIZ.PP
//   Created Date : 2018-01-17
//   Made By      : WIZCORE
//   Edited Date  : 
//   Edit By      :
//   Description  : 생산실적관리
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
    public partial class PP0010 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil();
        BizTextBoxManager btbManager = new BizTextBoxManager();

        Common _Common = new Common();
        DataTable rtnDtTemp = new DataTable();
        #endregion

        #region < CONSTRUCTOR >
        public PP0010()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void PP0010_Load(object sender, EventArgs e)
        {
            #region GRID SETTING
            //그리드 객체 생성
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장", true, GridColDataType_emu.VarChar, 180, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STARTDATE", "생산시작시간", true, GridColDataType_emu.DateTime, 180, 130, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUS", "현상태", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRESTATUS", "이전상태", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ENDDATE", "종료시간", true, GridColDataType_emu.DateTime, 180, 130, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPCODE", "비가동사유", true, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUSTIME", "소요시간(s)", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERCNT", "작업자수", true, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "작업LOTNO", true, GridColDataType_emu.VarChar, 150, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO", "지시번호", true, GridColDataType_emu.VarChar, 130, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERSEQNO", "지시SEQ 번호", true, GridColDataType_emu.VarChar, 80, 130, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 230, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY", "생산량", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "ERRORQTY", "불량량", true, GridColDataType_emu.VarChar, 100, 130, Infragistics.Win.HAlign.Right, true, true, "#,###,###");
            _GridUtil.InitColumnUltraGrid(grid1, "LOTQTY", "LOT실적량", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Right, true, false, "#,###,###");
            _GridUtil.InitColumnUltraGrid(grid1, "LABELQTY", "라벨발행량", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RECDATE", "수불일자", true, GridColDataType_emu.VarChar, 100, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DAYNIGHT", "주야", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ERRORMACHCODE", "고장설비", true, GridColDataType_emu.VarChar, 180, 130, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 90, 90, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일시", true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);

            /*
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",       "사업장",          true, GridColDataType_emu.VarChar,  140, 130, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OPCODE",          "공정",            true, GridColDataType_emu.VarChar,   90,  90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OPNAME",          "공정명",          true, GridColDataType_emu.VarChar,  150,  90, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LINECODE",        "라인",            true, GridColDataType_emu.VarChar,   90,  90, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LINENAME",        "라인명",          true, GridColDataType_emu.VarChar,  150,  90, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE",  "작업장",          true, GridColDataType_emu.VarChar,   90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME",  "작업장명",        true, GridColDataType_emu.VarChar,  150, 130, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",        "품목",            true, GridColDataType_emu.VarChar,  120,  90, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",        "품명",            true, GridColDataType_emu.VarChar,  200,  90, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RECDATE",         "수불일자 ",       true, GridColDataType_emu.VarChar,  180, 130, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "DAYNIGHT",        "주야구분",        true, GridColDataType_emu.VarChar,   90,  90, Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "GapQty",          "차이수량",        true, GridColDataType_emu.Double,    90, 130, Infragistics.Win.HAlign.Right,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY",         "설비카운트",      true, GridColDataType_emu.Double,    90, 130, Infragistics.Win.HAlign.Right,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ERRORQTY",        "불량수량",        true, GridColDataType_emu.Double,    90, 130, Infragistics.Win.HAlign.Right,  true, false);
            */

            _GridUtil.SetInitUltraGridBind(grid1);

            grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid1.DisplayLayout.Override.RowSelectorWidth = 50;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            #endregion

            #region COMBOBOX SETTING
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

            rtnDtTemp = _Common.GET_BM0000_CODE("RUNSTOP"); //현상태
            WIZ.Common.FillComboboxMaster(this.cbo_STATUS_B, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PRESTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0010_CODE(""); //품목
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0060_CODE("");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WORKCENTERCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.GET_BM0000_CODE("DAYNIGHT"); //주야구분
                                                             //  WIZ.Common.FillComboboxMaster(this.cbo_DAYNIGHT_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DAYNIGHT", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            #region POPUP SETTING

            //  btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });
            btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" });
            //   btbManager.PopUpAdd(txt_OPCODE_H, txt_OPNAME_H, "BM0040", new object[] { cbo_PLANTCODE_H, "", "" });

            #endregion

            try
            {
                this.grid1.DisplayLayout.Bands[0].SummaryFooterCaption = Common.getLangText("합계", "TEXT");
                this.grid1.DisplayLayout.Bands[0].Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;

                this.grid1.DisplayLayout.Bands[0].Summaries.Add("SUM([PRODQTY])", SummaryPosition.UseSummaryPositionColumn, this.grid1.DisplayLayout.Bands[0].Columns["PRODQTY"]);
                this.grid1.DisplayLayout.Bands[0].Summaries[0].DisplayFormat = "{0:#,###}";
                this.grid1.DisplayLayout.Bands[0].Summaries[0].SourceColumn = this.grid1.DisplayLayout.Bands[0].Columns["PRODQTY"];
                this.grid1.DisplayLayout.Bands[0].Summaries[0].Key = "PRODQTY";
                this.grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.TextHAlign = HAlign.Right;
                this.grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.BackColor = Color.DimGray;
                this.grid1.DisplayLayout.Bands[0].Summaries[0].Appearance.ForeColor = Color.White;
                this.grid1.DisplayLayout.Bands[0].Summaries[0].SourceColumn.Format = "#,###";
                this.grid1.DisplayLayout.Bands[0].Summaries[0].SummaryPositionColumn.Format = "#,###";
                this.grid1.DisplayLayout.Bands[0].Summaries[0].SummaryDisplayArea = SummaryDisplayAreas.Top;
                this.grid1.DisplayLayout.Bands[0].Summaries[0].SummaryType = SummaryType.Sum;

                this.grid1.DisplayLayout.Bands[0].Summaries.Add("AVG([RESULTQTY])", SummaryPosition.UseSummaryPositionColumn, this.grid1.DisplayLayout.Bands[0].Columns["RESULTQTY"]);
                this.grid1.DisplayLayout.Bands[0].Summaries[1].DisplayFormat = "{0:#,###.###}";
                this.grid1.DisplayLayout.Bands[0].Summaries[1].SourceColumn = this.grid1.DisplayLayout.Bands[0].Columns["RESULTQTY"];
                this.grid1.DisplayLayout.Bands[0].Summaries[1].Key = "RESULTQTY";
                this.grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.TextHAlign = HAlign.Right;
                this.grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.BackColor = Color.DimGray;
                this.grid1.DisplayLayout.Bands[0].Summaries[1].Appearance.ForeColor = Color.White;
                this.grid1.DisplayLayout.Bands[0].Summaries[1].SourceColumn.Format = "#,###.###";
                this.grid1.DisplayLayout.Bands[0].Summaries[1].SummaryPositionColumn.Format = "#,###.###";
                this.grid1.DisplayLayout.Bands[0].Summaries[1].SummaryDisplayArea = SummaryDisplayAreas.Top;
                this.grid1.DisplayLayout.Bands[0].Summaries[1].SummaryType = SummaryType.Average;
            }
            catch (Exception ex)
            {
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
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);                            // 사업장(공장)
                string sStartDate = DBHelper.nvlDateTime(cbo_STARTDATE_H.Value).ToString("yyyy-MM-dd");   // 생산시작일자
                string sEndDate = DBHelper.nvlDateTime(cbo_ENDDATE_H.Value).ToString("yyyy-MM-dd");     // 생산  끝일자
                string sWorkCenterCode = this.txt_WORKCENTERCODE_H.Text.Trim();                                // 작업장 코드
                string sStatus = DBHelper.nvlString(cbo_STATUS_B.Value);                               // 현상태
                string sItemCode = txt_ITEMCODE_H.Text.Trim();                                           // 품목

                //       string sOPCode         = this.txt_OPCODE_H.Text.Trim();                                        // 공정 코드
                //       string sDayNight       = DBHelper.nvlString(cbo_DAYNIGHT_H.Value);                             // 주야 구분


                rtnDtTemp = helper.FillTable("USP_PP0010_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_STATUS", sStatus, DbType.String, ParameterDirection.Input));

                //    , helper.CreateParameter("AS_ITEMCODE",       sItemCode,       DbType.String, ParameterDirection.Input));
                //    , helper.CreateParameter("AS_OPCODE", sOPCode, DbType.String, ParameterDirection.Input)
                //    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                //     , helper.CreateParameter("AS_DAYNIGHT", sDayNight, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    for (int i = 0; i < grid1.Rows.Count; i++)
                    {
                        // 합격결과에 따라서 글자 색 변경
                        if (grid1.Rows[i].Cells["GAPQTY"].Value.ToString() == "0") grid1.Rows[i].Cells["GAPQTY"].Appearance.ForeColor = Color.Blue;
                        else grid1.Rows[i].Cells["GAPQTY"].Appearance.ForeColor = Color.Red;
                    }

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

        #region < DOBASESUM >
        public override void DoBaseSum()
        {
            base.DoBaseSum();

            UltraGridRow ugr = grid1.DoSummaries(new string[] { "PRODQTY", "ERRORQTY", "LOTQTY", "LABELQTY", "RESULTQTY" });
            // UltraGridRow ugr = grid1.DoSummaries(new string[] { "PRODQTY", "RESULTQTY", "GAPQTY", "ERRORQTY" });
        }
        #endregion
    }
}
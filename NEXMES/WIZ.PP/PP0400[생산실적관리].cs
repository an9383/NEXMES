#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP0400
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
using Infragistics.UltraChart.Resources.Appearance;
using System;
using System.Data;
using WIZ.PopUp;


#endregion

namespace WIZ.PP
{
    public partial class PP0400 : WIZ.Forms.BaseMDIChildForm
    {
        #region<MEMBER AREA>
        UltraGridUtil _GridUtil = new UltraGridUtil();
        BizTextBoxManager btbManager = new BizTextBoxManager();

        Common _Common = new Common();
        DataTable rtnDtTemp = new DataTable();
        DataSet rtnDsTemp = new DataSet();
        #endregion

        #region<CONSTRUCTOR>
        public PP0400()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void PP0400_Load(object sender, EventArgs e)
        {
            #region GRID SETTING
            //그리드 객체 생성
            //_GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);

            //_GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",       "사업장",        true, GridColDataType_emu.VarChar,  140, 130, Infragistics.Win.HAlign.Left,   true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE",  "작업장",        true, GridColDataType_emu.VarChar,  180,  90, Infragistics.Win.HAlign.Left,   true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "STARTDATE",       "생산시작시간",  true, GridColDataType_emu.DateTime, 180, 130, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "STATUS",          "현상태",        true, GridColDataType_emu.VarChar,   90,  90, Infragistics.Win.HAlign.Left,   true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "PRESTATUS",       "이전상태",      true, GridColDataType_emu.VarChar,   90,  90, Infragistics.Win.HAlign.Left,   true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "ENDDATE",         "종료시간",      true, GridColDataType_emu.DateTime, 180, 130, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "STOPCODE",        "비가동사유",    true, GridColDataType_emu.VarChar,  150,  90, Infragistics.Win.HAlign.Left,   true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "STATUSTIME",      "소요시간(s)",   true, GridColDataType_emu.VarChar,  100,  90, Infragistics.Win.HAlign.Right,  true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "WORKERCNT",       "작업자수",      true, GridColDataType_emu.VarChar,  100, 130, Infragistics.Win.HAlign.Right,  true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "LOTNO",           "작업LOTNO",     true, GridColDataType_emu.VarChar,  150,  90, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "ORDERNO",         "지시번호",      true, GridColDataType_emu.VarChar,  130,  90, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "ORDERSEQNO",      "지시SEQ 번호",  true, GridColDataType_emu.VarChar,   80, 130, Infragistics.Win.HAlign.Right,  true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",        "품목",          true, GridColDataType_emu.VarChar,  230,  90, Infragistics.Win.HAlign.Left,   true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "PRODQTY",         "생산량",        true, GridColDataType_emu.VarChar,  100,  90, Infragistics.Win.HAlign.Right,  true, true);
            //_GridUtil.InitColumnUltraGrid(grid1, "ERRORQTY",        "불량량",        true, GridColDataType_emu.VarChar,  100, 130, Infragistics.Win.HAlign.Right,  true, true);
            //_GridUtil.InitColumnUltraGrid(grid1, "LOTQTY",          "LOT실적량",     true, GridColDataType_emu.VarChar,  100,  90, Infragistics.Win.HAlign.Right,  true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "LABELQTY",        "라벨발행량",    true, GridColDataType_emu.VarChar,  100,  90, Infragistics.Win.HAlign.Right,  true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "RECDATE",         "수불일자",      true, GridColDataType_emu.VarChar,  100,  90, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "DAYNIGHT",        "주야",          true, GridColDataType_emu.VarChar,   90,  90, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "ERRORMACHCODE",   "고장설비",      true, GridColDataType_emu.VarChar,  180, 130, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "MAKER",           "등록자",        true, GridColDataType_emu.VarChar,   90,  90, Infragistics.Win.HAlign.Left,   true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",        "등록일시",      true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "EDITOR",          "수정자",        true, GridColDataType_emu.VarChar,   90,  90, Infragistics.Win.HAlign.Left,   true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "EDITDATE",        "수정일시",      true, GridColDataType_emu.DateTime, 180, 140, Infragistics.Win.HAlign.Center, true, false);

            ///*
            //_GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",       "사업장",          true, GridColDataType_emu.VarChar,  140, 130, Infragistics.Win.HAlign.Left,   true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "OPCODE",          "공정",            true, GridColDataType_emu.VarChar,   90,  90, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "OPNAME",          "공정명",          true, GridColDataType_emu.VarChar,  150,  90, Infragistics.Win.HAlign.Left,   true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "LINECODE",        "라인",            true, GridColDataType_emu.VarChar,   90,  90, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "LINENAME",        "라인명",          true, GridColDataType_emu.VarChar,  150,  90, Infragistics.Win.HAlign.Left,   true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE",  "작업장",          true, GridColDataType_emu.VarChar,   90, 100, Infragistics.Win.HAlign.Center, true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME",  "작업장명",        true, GridColDataType_emu.VarChar,  150, 130, Infragistics.Win.HAlign.Left,   true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",        "품목",            true, GridColDataType_emu.VarChar,  120,  90, Infragistics.Win.HAlign.Left,   true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",        "품명",            true, GridColDataType_emu.VarChar,  200,  90, Infragistics.Win.HAlign.Left,   true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "RECDATE",         "수불일자 ",       true, GridColDataType_emu.VarChar,  180, 130, Infragistics.Win.HAlign.Left,   true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "DAYNIGHT",        "주야구분",        true, GridColDataType_emu.VarChar,   90,  90, Infragistics.Win.HAlign.Left,   true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "GapQty",          "차이수량",        true, GridColDataType_emu.Double,    90, 130, Infragistics.Win.HAlign.Right,  true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "PRODQTY",         "설비카운트",      true, GridColDataType_emu.Double,    90, 130, Infragistics.Win.HAlign.Right,  true, false);
            //_GridUtil.InitColumnUltraGrid(grid1, "ERRORQTY",        "불량수량",        true, GridColDataType_emu.Double,    90, 130, Infragistics.Win.HAlign.Right,  true, false);
            //*/

            //_GridUtil.SetInitUltraGridBind(grid1);

            //grid1.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            //grid1.DisplayLayout.Override.RowSelectorWidth = 50;
            //grid1.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //grid1.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            //cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            #endregion

            #region COMBOBOX SETTING
            //  rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE"); //사업장
            //  WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            //  WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            //  cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;

            //  rtnDtTemp = _Common.GET_BM0000_CODE("RUNSTOP"); //현상태
            //  WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "STATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");
            //  WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PRESTATUS", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //  rtnDtTemp = _Common.GET_BM0010_CODE(""); //품목
            //  WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //  rtnDtTemp = _Common.GET_BM0060_CODE(""); 
            //  WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "WORKCENTERCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            //  rtnDtTemp = _Common.GET_BM0000_CODE("DAYNIGHT"); //주야구분
            ////  WIZ.Common.FillComboboxMaster(this.cbo_DAYNIGHT_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            //  WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "DAYNIGHT", rtnDtTemp, "CODE_ID", "CODE_NAME");

            #endregion

            #region POPUP SETTING

            //  btbManager.PopUpAdd(txt_ITEMCODE_H, txt_ITEMNAME_H, "BM0010", new object[] { cbo_PLANTCODE_H, "", "" });
            btbManager.PopUpAdd(txt_WORKCENTERCODE_H, txt_WORKCENTERNAME_H, "BM0060", new object[] { cbo_PLANTCODE_H, "", "", "" });
            //   btbManager.PopUpAdd(txt_OPCODE_H, txt_OPNAME_H, "BM0040", new object[] { cbo_PLANTCODE_H, "", "" });

            #endregion
        }
        #endregion

        #region < TOOL BAR AREA >
        /// <summary>
        /// ToolBar의 조회 버튼 클릭
        /// </summary>
        public override void DoInquire()
        {
            //_GridUtil.Grid_Clear(grid1); // 조회전 그리드 초기화

            base.DoInquire();

            DBHelper helper = new DBHelper(false);

            try
            {
                string sPlantCode = string.Empty;
                string sStartDate = string.Empty;
                string sEndDate = string.Empty;
                string sWorkCenterCode = string.Empty;
                //string sPlantCode      = DBHelper.nvlString(cbo_PLANTCODE_H.Value);                          
                //string sStartDate      = DBHelper.nvlDateTime(cbo_STARTDATE_H.Value).ToString("yyyy-MM-dd"); 
                //string sEndDate        = DBHelper.nvlDateTime(cbo_ENDDATE_H.Value).ToString("yyyy-MM-dd");   
                //string sWorkCenterCode = this.txt_WORKCENTERCODE_H.Text.Trim();                              


                rtnDtTemp = helper.FillTable("USP_PP0400_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_WORKCENTERCODE", sWorkCenterCode, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    ultraChart1.Series.Clear();

                    ultraChart1.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.StackBarChart;
                    //ultraChart1.DataSource = rtnDtTemp;

                    NumericSeries RSeries = new NumericSeries();
                    RSeries.Data.DataSource = rtnDtTemp;
                    RSeries.Data.LabelColumn = "WORKCENTERNAME";
                    RSeries.Data.ValueColumn = "STATUSTIME";


                    ultraChart1.Series.Add(RSeries);



                    //ultraChart1.
                    //chart1.Series.Clear();

                    //chart1.DataSource = rtnDtTemp;
                    //chart1.Series.Add("R");
                    //chart1.Series.Add("S");

                    //chart1.Series["R"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
                    //chart1.Series["S"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;

                    //string [] arrWcCode = new string[rtnDtTemp.Rows.Count];
                    //double [] arrStTime = new double[rtnDtTemp.Rows.Count];

                    //for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                    //{
                    //    arrWcCode[i] = Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERCODE"]);
                    //    arrStTime[i] = Convert.ToDouble(rtnDtTemp.Rows[i]["STATUSTIME"]);
                    //}

                    //chart1.Series["R"].Points.AddXY(10, 3);
                    //chart1.Series["S"].Points.AddXY(10, 3);
                    //chart1.Series["R"].Points.AddXY(10, 2);

                    ////chart1.Series["R"].Points.DataBindXY(arrWcCode, arrStTime);
                    ////chart1.Series["S"].Points.DataBindXY(arrWcCode, arrStTime);

                    ////for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                    ////{
                    ////    if (Convert.ToString(rtnDtTemp.Rows[i]["STATUS"]) == "R")
                    ////        //chart1.Series["R"].Points.AddY(Convert.ToDouble(rtnDtTemp.Rows[i]["STATUSTIME"]));
                    ////        chart1.Series["R"].Points.DataBindXY(rtnDtTemp.Rows[i]["WORKCENTERCODE"], rtnDtTemp.Rows[i]["STATUSTIME"])
                    ////    else
                    ////        //chart1.Series["S"].Points.AddY(Convert.ToDouble(rtnDtTemp.Rows[i]["STATUSTIME"]));
                    ////}

                    ////chart1.Series[0].XValueMember = "STATUSTIME";
                    ////chart1.Series[0].YValueMembers = "WORKCENTERCODE";
                    //chart1.DataBind();


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

        private DataTable SetUpChartData()
        {
            DataSet _dsTemp = new DataSet();

            for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
            {
                if (i != 0)
                {
                    string sWcCode = Convert.ToString(rtnDtTemp.Rows[0]["WORKCENTERCODE"]);
                }

            }

            DataTable mydata = new DataTable();

            mydata.Columns.Add("Series Labels", typeof(string));
            mydata.Columns.Add("Column A", typeof(int));
            mydata.Columns.Add("Column B", typeof(int));
            mydata.Columns.Add("Column C", typeof(int));
            mydata.Columns.Add("Column D", typeof(int));

            mydata.Rows.Add(new Object[] { "Week 1", 6, 4, 10, 7 });
            mydata.Rows.Add(new Object[] { "Week 2", 4, 8, 5, 3 });
            mydata.Rows.Add(new Object[] { "Week 3", 5, 8, 6, 4 });
            mydata.Rows.Add(new Object[] { "Week 4", 7, 10, 7, 2 });

            return mydata;
        }
        #endregion

        #region<DoBaseSum>
        public override void DoBaseSum()
        {
            base.DoBaseSum();

            //UltraGridRow ugr = grid1.DoSummaries(new string[] { "PRODQTY", "ERRORQTY", "LOTQTY", "LABELQTY", "RESULTQTY" });
            // UltraGridRow ugr = grid1.DoSummaries(new string[] { "PRODQTY", "RESULTQTY", "GAPQTY", "ERRORQTY" });
        }
        #endregion
    }
}
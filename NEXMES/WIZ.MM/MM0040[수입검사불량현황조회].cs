#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM0040
//   Form Name    : 수입검사대기현황조회
//   Name Space   : WIZ.MM
//   Created Date : 2018-03-21
//   Made By      : WIZCORE 남부사무소 사원 최수정
//   Edited Date  : 
//   Edit By      :
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using Infragistics.UltraChart.Core.Primitives;
using Infragistics.UltraChart.Resources.Appearance;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
#endregion

namespace WIZ.MM
{
    public partial class MM0040 : WIZ.Forms.BaseMDIChildForm
    {
        #region < MEMBER AREA > 
        UltraGridUtil _GridUtil = new UltraGridUtil();

        Common _Common = new Common();
        DataTable rtnDtTemp = new DataTable();
        DataSet rtnDsTemp = new DataSet();
        #endregion

        #region < CONSTRUCTOR >
        public MM0040()
        {
            InitializeComponent();
        }
        #endregion

        #region < FORM LOAD >
        private void MM0040_Load(object sender, EventArgs e)
        {
            #region GRID SETTING
            //그리드 객체 생성
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", true, GridColDataType_emu.VarChar, 140, 130, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPDATE", "검사일자", true, GridColDataType_emu.VarChar, 100, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 120, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", true, GridColDataType_emu.VarChar, 180, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SEQNO", "차수", true, GridColDataType_emu.VarChar, 50, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPCODE", "검사항목", true, GridColDataType_emu.VarChar, 90, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPNAME", "검사항목명", true, GridColDataType_emu.VarChar, 150, 100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPRESULT", "검사결과", true, GridColDataType_emu.VarChar, 80, 100, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPVALUE", "검사값", true, GridColDataType_emu.VarChar, 90, 130, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECLSL", "하한값", true, GridColDataType_emu.VarChar, 90, 130, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECUSL", "상한값", true, GridColDataType_emu.VarChar, 90, 130, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "검사자", true, GridColDataType_emu.VarChar, 90, 130, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "검사일시", true, GridColDataType_emu.DateTime, 180, 130, Infragistics.Win.HAlign.Center, true, false);


            _GridUtil.SetInitUltraGridBind(grid1);

            #endregion

            #region COMBOBOX SETTING
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");  //사업장
            WIZ.Common.FillComboboxMaster(this.cbo_PLANTCODE_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
            WIZ.UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            cbo_PLANTCODE_H.Value = WIZ.LoginInfo.PlantCode;
            cbo_STARTDATE_H.Value = DateTime.Now.AddDays(-7);
            #endregion

            #region POPUP SETTING

            #endregion

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

            ultraChart1.Series.Clear();
            ultraChart2.Series.Clear();
            ultraChart3.Series.Clear();

            try
            {
                string sPlantCode = DBHelper.nvlString(cbo_PLANTCODE_H.Value);
                string sStartDate = DBHelper.nvlDateTime(cbo_STARTDATE_H.Value).ToString("yyyy-MM-dd");
                string sEndDate = DBHelper.nvlDateTime(cbo_ENDDATE_H.Value).ToString("yyyy-MM-dd");
                string sItemCode = txt_ITEMCODE_H.Text.Trim();
                string sLotNo = DBHelper.nvlString(txt_LOTNO_H.Text.Trim());

                rtnDsTemp = helper.FillDataSet("USP_MM0040_S1", CommandType.StoredProcedure
                                                                    , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                                    , helper.CreateParameter("AS_LOTNO", sLotNo, DbType.String, ParameterDirection.Input));

                this.ClosePrgFormNew();

                if (rtnDsTemp.Tables[0].Rows.Count > 0)
                {
                    grid1.DataSource = rtnDsTemp.Tables[0];
                    grid1.DataBinds(rtnDsTemp.Tables[0]);

                    NumericSeries series1 = new NumericSeries();
                    if (rtnDsTemp.Tables[1].Rows.Count > 0)
                    {
                        series1.Data.DataSource = rtnDsTemp.Tables[1];
                        series1.Data.LabelColumn = "INSPDATE";
                        series1.Data.ValueColumn = "ERRCNT";
                        series1.DataBind(rtnDsTemp.Tables[1], "ERRCNT");

                        ultraChart1.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.ColumnChart;
                        ultraChart1.Axis.Y.RangeType = Infragistics.UltraChart.Shared.Styles.AxisRangeType.Custom;
                        ultraChart1.Axis.Y.RangeMin = 0;
                        ultraChart1.Axis.Y.RangeMax = 25;
                        ultraChart1.Axis.Y.Labels.ItemFormatString = "<DATA_VALUE:0>";
                        ultraChart1.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
                        ultraChart1.Tooltips.FormatString = "<DATA_VALUE:0>";
                        ultraChart1.ColorModel.CustomPalette = new Color[] { Color.Gainsboro };
                        ultraChart1.Axis.X.Extent = 20;
                        ultraChart1.Axis.Y.Extent = 10;
                        ultraChart1.Axis.X.Labels.Font = new Font("맑은 고딕", 12);
                        ultraChart1.Axis.X.Labels.FontColor = Color.Black;

                        ultraChart1.Series.Add(series1);
                        ultraChart1.DataBind();
                    }

                    NumericSeries series2 = new NumericSeries();
                    if (rtnDsTemp.Tables[2].Rows.Count > 0)
                    {
                        series2.Data.DataSource = rtnDsTemp.Tables[2];
                        series2.Data.LabelColumn = "ITEMNAME";
                        series2.Data.ValueColumn = "ERRCNT";
                        series2.DataBind(rtnDsTemp.Tables[2], "ERRCNT");

                        ultraChart2.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.ColumnChart;
                        ultraChart2.Axis.Y.RangeType = Infragistics.UltraChart.Shared.Styles.AxisRangeType.Custom;
                        ultraChart2.Axis.Y.RangeMin = 0;
                        ultraChart2.Axis.Y.RangeMax = 25;
                        ultraChart2.Axis.Y.Labels.ItemFormatString = "<DATA_VALUE:0>";
                        ultraChart2.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
                        ultraChart2.Tooltips.FormatString = "<DATA_VALUE:0>";
                        ultraChart2.ColorModel.CustomPalette = new Color[] { Color.Gainsboro };
                        ultraChart2.Axis.X.Extent = 20;
                        ultraChart2.Axis.Y.Extent = 10;
                        ultraChart2.Axis.X.Labels.Font = new Font("맑은 고딕", 12);
                        ultraChart2.Axis.X.Labels.FontColor = Color.Black;

                        ultraChart2.Series.Add(series2);
                        ultraChart2.DataBind();
                    }

                    NumericSeries series3 = new NumericSeries();
                    if (rtnDsTemp.Tables[3].Rows.Count > 0)
                    {
                        series3.Data.DataSource = rtnDsTemp.Tables[3];
                        series3.Data.LabelColumn = "INSPNAME";
                        series3.Data.ValueColumn = "ERRCNT";
                        series3.DataBind(rtnDsTemp.Tables[3], "ERRCNT");

                        ultraChart3.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.ColumnChart;
                        ultraChart3.Axis.Y.RangeType = Infragistics.UltraChart.Shared.Styles.AxisRangeType.Custom;
                        ultraChart3.Axis.Y.RangeMin = 0;
                        ultraChart3.Axis.Y.RangeMax = 25;
                        ultraChart3.Axis.Y.Labels.ItemFormatString = "<DATA_VALUE:0>";
                        ultraChart3.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
                        ultraChart3.Tooltips.FormatString = "<DATA_VALUE:0>";
                        ultraChart3.ColorModel.CustomPalette = new Color[] { Color.Gainsboro };
                        ultraChart3.Axis.X.Extent = 20;
                        ultraChart3.Axis.Y.Extent = 10;
                        ultraChart3.Axis.X.Labels.Font = new Font("맑은 고딕", 12);
                        ultraChart3.Axis.X.Labels.FontColor = Color.Black;

                        ultraChart3.Series.Add(series3);
                        ultraChart3.DataBind();
                    }
                }
                else
                {
                    this.ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), WIZ.Forms.DialogForm.DialogType.OK); //조회할 데이터가 없습니다.
                    return;
                }


                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                grid1.DisplayLayout.Bands[0].Columns["LOTNO"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["LOTNO"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

                grid1.DisplayLayout.Bands[0].Columns["INSPDATE"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["INSPDATE"].MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (grid1.Rows[i].Cells["INSPRESULT"].Value.ToString() == "NG")
                    {
                        grid1.Rows[i].Cells["INSPRESULT"].Appearance.BackColor = Color.LightPink;
                    }
                    else
                    {
                        grid1.Rows[i].Cells["INSPRESULT"].Appearance.BackColor = Color.DarkCyan;
                        grid1.Rows[i].Cells["INSPRESULT"].Appearance.ForeColor = Color.White;
                    }
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

        private void ultraChart1_ChartDrawItem(object sender, Infragistics.UltraChart.Shared.Events.ChartDrawItemEventArgs e)
        {
            Box box = e.Primitive as Box;

            if (box == null)
                return;

            if (box.DataPoint == null)
                return;

            box.PE.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.SolidFill; // 바(bar)색 단색으로 채우기, 그라데이션 제거

            int dWidth = box.rect.Width - 100;

            if (dWidth <= 0)
                return;
            else
            {
                box.rect.Width = 100;
                box.rect.X += dWidth / 2; // 바(bar) width 설정
            }

        }

        #endregion
    }
}
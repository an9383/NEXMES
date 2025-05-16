using Infragistics.UltraChart.Resources.Appearance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WIZ.MT
{
    public partial class UC_SPC : UserControl
    {
        #region< MEMBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil();

        SingleSampleSPC spc = new SingleSampleSPC();
        private List<double> DataList = new List<double>();

        DataTable rtnDtTemp = new DataTable();

        DataTable dtData = new DataTable();
        DataTable DtXBar = new DataTable();
        DataTable DtR = new DataTable();

        bool bFirst = true;

        public DataTable DtData
        {
            get
            {
                return dtData;
            }
            set
            {
                dtData = value;

                this.DataBinding();
            }
        }
        #endregion

        #region< CONSTRUCTOR >
        public UC_SPC()
        {
            InitializeComponent();

            WIZ.Forms.FormInfor frm = new Forms.FormInfor("", "", "");
            //frm.SetControl(this, Common.Lang);
        }
        #endregion

        #region < EVENT AREA >
        private void UC_SPC_Load(object sender, EventArgs e)
        {
            DtXBar.Columns.Add("DataRowNum");
            DtXBar.Columns.Add("UCLx");
            DtXBar.Columns.Add("X_Bar");
            DtXBar.Columns.Add("Actual");
            DtXBar.Columns.Add("LCLx");

            DtR.Columns.Add("DataRowNum");
            DtR.Columns.Add("UCLmR");
            DtR.Columns.Add("AVGmR");
            DtR.Columns.Add("mR");
            DtR.Columns.Add("LCLmR");

            lbl_INSPINFO_H.Text = dtData.Rows[0]["ITEMNAME"] + " - " + dtData.Rows[0]["INSPNAME"];

            FontInit();

            bFirst = false;

            this.DataBinding();
        }

        public static string SetPointFormat(double value, int point)
        {
            if (!(value == double.NaN))
            {
                //Dim formatStr As String = "0." & "0".PadLeft(point, "#")
                //Return Format(Math.Round(value, point), formatStr)
                //string formatStr = "0." + "0".PadLeft(point, '#');
                string formatStr = "{0:0." + "0".PadLeft(point, '0') + "}";
                //return string.Format(Convert.ToString(Math.Round(value, point)), formatStr);
                return String.Format(formatStr, Math.Round(value, point));
            }
            else
            {
                return "-";
            }
        }

        private void DataBinding()
        {
            int pointPosition = 0;

            //SPC차트 그리기
            if (dtData.Rows.Count > 0)
            {
                pointPosition = 6;

                LbNomin.Text = SetPointFormat(double.Parse(dtData.Rows[0]["SPECNOL"].ToString()), pointPosition);
                LbUTol.Text = SetPointFormat(double.Parse(dtData.Rows[0]["SPECUSL"].ToString()) - Convert.ToDouble(LbNomin.Text), pointPosition);
                LbLTol.Text = SetPointFormat(double.Parse(dtData.Rows[0]["SPECLSL"].ToString()) - Convert.ToDouble(LbNomin.Text), pointPosition);

                DataList.Clear();
                foreach (DataRow row in dtData.Rows)
                {
                    DataList.Add(row.IsNull("INSPVALUE") ? 0.0 : Convert.ToDouble(row["INSPVALUE"]));
                }

                spc.Nominal = double.Parse(dtData.Rows[0]["SPECNOL"].ToString());
                spc.UpperTolOffset = (double.Parse(dtData.Rows[0]["SPECUSL"].ToString()) - spc.Nominal);
                spc.LowerTolOffset = (double.Parse(dtData.Rows[0]["SPECLSL"].ToString()) - spc.Nominal);
                spc.Actual = DataList;

                // 최대값
                LbMax.Text = SetPointFormat(dtData.Rows.Cast<DataRow>().Max(row => Convert.ToDouble(row["INSPVALUE"])), pointPosition);

                // 최소값
                LbMin.Text = SetPointFormat(dtData.Rows.Cast<DataRow>().Min(row => Convert.ToDouble(row["INSPVALUE"])), pointPosition);

                // 평균
                LbAvg.Text = SetPointFormat(dtData.Rows.Cast<DataRow>().Average(row => Convert.ToDouble(row["INSPVALUE"])), pointPosition);

                // 표준편차
                LbSigma.Text = SetPointFormat(spc.Sigma == null ? double.NaN : (double)spc.Sigma, pointPosition);
                LbCp.Text = SetPointFormat(spc.Cp == null ? double.NaN : (double)spc.Cp, pointPosition);
                LbCpk.Text = SetPointFormat(spc.Cpk == null ? double.NaN : (double)spc.Cpk, pointPosition);

                //공정능력 판정
                if (spc.Cpk == null)
                {
                    lblProcessJudge.Text = Common.getLangText("공정능력판정 : N/A");
                    gbxHeader.Appearance.BackColor = Color.Azure;
                }
                else if ((double)spc.Cpk > 1.67)
                {
                    lblProcessJudge.Text = Common.getLangText("공정능력판정 : 매우안정");
                    gbxHeader.Appearance.BackColor = Color.Azure;
                }
                else if ((double)spc.Cpk > 1.33 && (double)spc.Cpk <= 1.67)
                {
                    lblProcessJudge.Text = Common.getLangText("공정능력판정 : 안정");
                    gbxHeader.Appearance.BackColor = Color.Azure;
                }
                else if ((double)spc.Cpk > 1.00 && (double)spc.Cpk <= 1.33)
                {
                    lblProcessJudge.Text = Common.getLangText("공정능력판정 : 보통");
                    gbxHeader.Appearance.BackColor = Color.Azure;
                }
                else if ((double)spc.Cpk > 0.67 && (double)spc.Cpk <= 1.00)
                {
                    lblProcessJudge.Text = Common.getLangText("공정능력판정 : 불안정");
                    gbxHeader.Appearance.BackColor = Color.LightPink;
                }
                else if ((double)spc.Cpk <= 0.67)
                {
                    lblProcessJudge.Text = Common.getLangText("공정능력판정 : 매우불안정");
                    gbxHeader.Appearance.BackColor = Color.LightPink;
                }
                else
                {
                    lblProcessJudge.Text = Common.getLangText("공정능력판정 : N/A");
                    gbxHeader.Appearance.BackColor = Color.Azure;
                }

                //X_Bar Chart
                ultraChartXBar.Series.Clear();
                DtXBar.Clear();

                if (bFirst == true)
                {
                    return;
                }

                if (spc.Actual.Count > 0)
                {
                    for (int i = 0; i < spc.Actual.Count - 1; i++)
                    {
                        DataRow drRow = DtXBar.NewRow();

                        drRow["DataRowNum"] = i;
                        drRow["UCLx"] = spc.UCLx;
                        drRow["X_Bar"] = spc.X_Bar;
                        drRow["Actual"] = spc.Actual[i];
                        drRow["LCLx"] = spc.LCLx;

                        DtXBar.Rows.Add(drRow);
                    }

                    NumericSeries UCLx = new NumericSeries();
                    NumericSeries X_Bar = new NumericSeries();
                    NumericSeries Actual = new NumericSeries();
                    NumericSeries LCLx = new NumericSeries();

                    UCLx.Label = "UCLx";
                    X_Bar.Label = "X_Bar";
                    Actual.Label = "Actual";
                    LCLx.Label = "LCLx";

                    foreach (DataRow currentRow in DtXBar.Rows)
                    {
                        UCLx.Points.Add(new NumericDataPoint(Convert.ToDouble(currentRow["UCLx"]), currentRow["DataRowNum"].ToString(), false));
                        X_Bar.Points.Add(new NumericDataPoint(Convert.ToDouble(currentRow["X_Bar"]), currentRow["DataRowNum"].ToString(), false));
                        Actual.Points.Add(new NumericDataPoint(Convert.ToDouble(currentRow["Actual"]), currentRow["DataRowNum"].ToString(), false));
                        LCLx.Points.Add(new NumericDataPoint(Convert.ToDouble(currentRow["LCLx"]), currentRow["DataRowNum"].ToString(), false));
                    }

                    ultraChartXBar.Series.Add(UCLx);
                    ultraChartXBar.Series.Add(X_Bar);
                    ultraChartXBar.Series.Add(Actual);
                    ultraChartXBar.Series.Add(LCLx);
                }

                //R Chart
                ultraChartRChart.Series.Clear();
                DtR.Clear();
                if (spc.mR.Count > 0)
                {
                    for (int i = 0; i < spc.mR.Count - 1; i++)
                    {
                        DataRow drRow = DtR.NewRow();

                        drRow["DataRowNum"] = i;
                        drRow["UCLmR"] = spc.UCLmR;
                        drRow["AVGmR"] = spc.mR_Bar;
                        drRow["mR"] = spc.mR[i];
                        drRow["LCLmR"] = spc.LCLmR;

                        DtR.Rows.Add(drRow);
                    }

                    NumericSeries UCLmR = new NumericSeries();
                    NumericSeries AVGmR = new NumericSeries();
                    NumericSeries mR = new NumericSeries();
                    NumericSeries LCLmR = new NumericSeries();

                    UCLmR.Label = "UCLmR";
                    AVGmR.Label = "AVGmR";
                    mR.Label = "mR";
                    LCLmR.Label = "LCLmR";

                    foreach (DataRow currentRow in DtR.Rows)
                    {
                        UCLmR.Points.Add(new NumericDataPoint(Convert.ToDouble(currentRow["UCLmR"]), currentRow["DataRowNum"].ToString(), false));
                        AVGmR.Points.Add(new NumericDataPoint(Convert.ToDouble(currentRow["AVGmR"]), currentRow["DataRowNum"].ToString(), false));
                        mR.Points.Add(new NumericDataPoint(Convert.ToDouble(currentRow["mR"]), currentRow["DataRowNum"].ToString(), false));
                        LCLmR.Points.Add(new NumericDataPoint(Convert.ToDouble(currentRow["LCLmR"]), currentRow["DataRowNum"].ToString(), false));
                    }

                    ultraChartRChart.Series.Add(UCLmR);
                    ultraChartRChart.Series.Add(AVGmR);
                    ultraChartRChart.Series.Add(mR);
                    ultraChartRChart.Series.Add(LCLmR);
                }
                //// X-Bar Chart
                //ChartXBar.Series[0].Points.Clear();
                //// UCLx
                //ChartXBar.Series[1].Points.Clear();
                //// Avg X-Bar
                //ChartXBar.Series[2].Points.Clear();
                //// X-Bar
                //ChartXBar.Series[3].Points.Clear();
                //// LCLx
                //ChartXBar.Series[4].Points.Clear();
                //// 경계상한
                //ChartXBar.Series[5].Points.Clear();
                //// 경계하한
                //ChartXBar.Series[6].Points.Clear();
                //// 이상상한
                //ChartXBar.Series[7].Points.Clear();
                //// 이상하한
                //for (int i = 0; i <= spc.Actual.Count - 1; i++)
                //{
                //    ChartXBar.Series[0].Points.Add(spc.UCLx);
                //    ChartXBar.Series[1].Points.Add(spc.X_Bar);
                //    ChartXBar.Series[2].Points.Add(spc.Actual[i]);
                //    ChartXBar.Series[3].Points.Add(spc.LCLx);
                //}

                //// R Chart
                //ChartR.Series[0].Points.Clear();
                //// UCLmR
                //ChartR.Series[1].Points.Clear();
                //// Avg mR
                //ChartR.Series[2].Points.Clear();
                //// mR
                //ChartR.Series[3].Points.Clear();
                //// LCLmR
                //for (int i = 0; i <= spc.mR.Count - 1; i++)
                //{
                //    ChartR.Series[0].Points.Add(spc.UCLmR);
                //    ChartR.Series[1].Points.Add(spc.mR_Bar);
                //    ChartR.Series[2].Points.Add(spc.mR[i]);
                //    ChartR.Series[3].Points.Add(spc.LCLmR);
                //}

                // 그래프 갱신
                Chart1.Series[0].Points.Clear();
                for (int i = 0; i < spc.DIstribution.Count - 1; i++)
                {
                    Chart1.Series[0].Points.Add(new DataPoint(spc.NormalDistribution[i].X, spc.Frequency[i]));
                    // X값, Y값
                }

                // 표준 정규분포
                Chart1.Series[1].Points.Clear();
                for (int i = 0; i < spc.NormalDistribution.Count - 1; i++)
                {
                    Chart1.Series[1].Points.Add(new DataPoint(spc.NormalDistribution[i].X, spc.NormalDistribution[i].Y));
                }

                double maxY = 0.0;
                for (int i = 0; i < spc.NormalDistribution.Count - 1; i++)
                {
                    if (maxY < spc.NormalDistribution[i].Y)
                    {
                        maxY = spc.NormalDistribution[i].Y;
                    }
                }

                // 기준치
                Chart1.Series[2].Points.Clear();
                Chart1.Series[2].Points.Add(new DataPoint(spc.Nominal, 0));
                Chart1.Series[2].Points.Add(new DataPoint(spc.Nominal, maxY));

                // USL
                Chart1.Series[3].Points.Clear();
                Chart1.Series[3].Points.Add(new DataPoint(spc.UpperTol, 0));
                Chart1.Series[3].Points.Add(new DataPoint(spc.UpperTol, maxY));

                // LSL
                Chart1.Series[4].Points.Clear();
                Chart1.Series[4].Points.Add(new DataPoint(spc.LowerTol, 0));
                Chart1.Series[4].Points.Add(new DataPoint(spc.LowerTol, maxY));

                if (spc.Sigma != null)
                {
                    // -3 시그마
                    Chart1.Series[5].Points.Clear();
                    Chart1.Series[5].Points.Add(new DataPoint(Convert.ToDouble(spc.X_Bar + (3 * spc.Sigma)), 0));
                    Chart1.Series[5].Points.Add(new DataPoint(Convert.ToDouble(spc.X_Bar + (3 * spc.Sigma)), maxY));

                    // +3 시그마
                    Chart1.Series[6].Points.Clear();
                    Chart1.Series[6].Points.Add(new DataPoint(Convert.ToDouble(spc.X_Bar - (3 * spc.Sigma)), 0));
                    Chart1.Series[6].Points.Add(new DataPoint(Convert.ToDouble(spc.X_Bar - (3 * spc.Sigma)), maxY));
                }

                // Median
                Chart1.Series[7].Points.Clear();
                Chart1.Series[7].Points.Add(new DataPoint(spc.X_Bar, 0));
                Chart1.Series[7].Points.Add(new DataPoint(spc.X_Bar, maxY));
            }
            else
            {
                ultraChartXBar.Series.Clear();
                ultraChartRChart.Series.Clear();

                // 그래프 갱신
                Chart1.Series[0].Points.Clear();
                // 표준 정규분포
                Chart1.Series[1].Points.Clear();
                // 기준치
                Chart1.Series[2].Points.Clear();
                // USL
                Chart1.Series[3].Points.Clear();
                // LSL
                Chart1.Series[4].Points.Clear();
                // -3 시그마
                Chart1.Series[5].Points.Clear();
                // +3 시그마
                Chart1.Series[6].Points.Clear();
                // Median
                Chart1.Series[7].Points.Clear();
                //// X-Bar Chart
                //ChartXBar.Series[0].Points.Clear();
                //// UCLx
                //ChartXBar.Series[1].Points.Clear();
                //// Avg X-Bar
                //ChartXBar.Series[2].Points.Clear();
                //// X-Bar
                //ChartXBar.Series[3].Points.Clear();
                //// LCLx
                //ChartXBar.Series[4].Points.Clear();
                //// 경계상한
                //ChartXBar.Series[5].Points.Clear();
                //// 경계하한
                //ChartXBar.Series[6].Points.Clear();
                //// 이상상한
                //ChartXBar.Series[7].Points.Clear();
                //// R Chart
                //ChartR.Series[0].Points.Clear();
                //// UCLmR
                //ChartR.Series[1].Points.Clear();
                //// Avg mR
                //ChartR.Series[2].Points.Clear();
                //// mR
                //ChartR.Series[3].Points.Clear();

                LbNomin.Text = "";
                LbMax.Text = "";
                LbMin.Text = "";
                LbAvg.Text = "";
                LbSigma.Text = "";
                LbUTol.Text = "";
                LbLTol.Text = "";
                LbCp.Text = "";
                LbCpk.Text = "";
            }
        }
        #endregion

        private void FontInit()
        {
            Chart1.Titles[0].Text = Common.getLangText("정규분포 히스토그램");
            //ChartXBar.Titles[0].Text = "X-Bar Chart";
            //ChartR.Titles[0].Text    = "R Chart";

            Chart1.Series[0].Name = Common.getLangText("도수");
            Chart1.Series[1].Name = Common.getLangText("정규분포");

            //ChartXBar.Series[4].Name = Common.getLangText("경계상한");
            //ChartXBar.Series[5].Name = Common.getLangText("경계하한");
            //ChartXBar.Series[6].Name = Common.getLangText("이상상한");
            //ChartXBar.Series[7].Name = Common.getLangText("이상하한");

            Chart1.Titles[0].Font = new System.Drawing.Font(Common.FontName, 12F, FontStyle.Bold);
            //ChartXBar.Titles[0].Font = new System.Drawing.Font(Common.FontName, 12F, FontStyle.Bold);
            //ChartR.Titles[0].Font    = new System.Drawing.Font(Common.FontName, 12F, FontStyle.Bold);

            Chart1.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font(Common.FontName, 8F);
            Chart1.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font(Common.FontName, 8F);

            //ChartXBar.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font(Common.FontName, 8F);
            //ChartXBar.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font(Common.FontName, 8F);

            //ChartR.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font(Common.FontName, 8F);
            //ChartR.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font(Common.FontName, 8F);

            Chart1.Series[0].Font = new Font(Common.FontName, 8F);
            Chart1.Series[1].Font = new Font(Common.FontName, 8F);
            Chart1.Series[2].Font = new Font(Common.FontName, 8F);
            Chart1.Series[3].Font = new Font(Common.FontName, 8F);
            Chart1.Series[4].Font = new Font(Common.FontName, 8F);
            Chart1.Series[5].Font = new Font(Common.FontName, 8F);
            Chart1.Series[6].Font = new Font(Common.FontName, 8F);
            Chart1.Series[7].Font = new Font(Common.FontName, 8F);

            //ChartXBar.Series[0].Font = new Font(Common.FontName, 8F);
            //ChartXBar.Series[1].Font = new Font(Common.FontName, 8F);
            //ChartXBar.Series[2].Font = new Font(Common.FontName, 8F);
            //ChartXBar.Series[3].Font = new Font(Common.FontName, 8F);
            //ChartXBar.Series[4].Font = new Font(Common.FontName, 8F);
            //ChartXBar.Series[5].Font = new Font(Common.FontName, 8F);
            //ChartXBar.Series[6].Font = new Font(Common.FontName, 8F);
            //ChartXBar.Series[7].Font = new Font(Common.FontName, 8F);

            //ChartR.Series[0].Font = new Font(Common.FontName, 8F);
            //ChartR.Series[1].Font = new Font(Common.FontName, 8F);
            //ChartR.Series[2].Font = new Font(Common.FontName, 8F);
            //ChartR.Series[3].Font = new Font(Common.FontName, 8F);

            Chart1.Legends[0].Font = new Font(Common.FontName, 8F);
            //ChartXBar.Legends[0].Font = new Font(Common.FontName, 8F);
            //ChartR.Legends[0].Font    = new Font(Common.FontName, 8F);
        }
    }
}

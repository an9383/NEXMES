using Infragistics.UltraChart.Resources.Appearance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WIZ.QM
{
    public partial class UC_SPC : UserControl
    {
        #region< MEMBER AREA >
        UltraGridUtil _GridUtil = new UltraGridUtil();

        SingleSampleSPC spc = new SingleSampleSPC();
        private List<double> DataList = new List<double>();

        DataTable rtnDtTemp = new DataTable();

        DataTable DtXBar = new DataTable();
        DataTable DtR = new DataTable();

        string sPlantCode = "";
        string sItemCode = "";
        string sItemName = "";
        string sInspCode = "";
        string sInspName = "";
        string sInspType = "";
        string sStartDate = "";
        string sEndDate = "";

        public string PlantCode
        {
            get
            {
                return sPlantCode;
            }
            set
            {
                sPlantCode = value;
            }
        }

        public string ItemCode
        {
            get
            {
                return sItemCode;
            }
            set
            {
                sItemCode = value;
            }
        }

        public string ItemName
        {
            get
            {
                return sItemName;
            }
            set
            {
                sItemName = value;
            }
        }

        public string InspCode
        {
            get
            {
                return sInspCode;
            }
            set
            {
                sInspCode = value;
            }
        }

        public string InspName
        {
            get
            {
                return sInspName;
            }
            set
            {
                sInspName = value;
            }
        }

        public string InspType
        {
            set
            {
                sInspType = value;
            }
        }

        public string StartDate
        {
            set
            {
                sStartDate = value;
            }
        }

        public string EndDate
        {
            set
            {
                sEndDate = value;
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
            #region GRID
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "사업장", false, GridColDataType_emu.VarChar, 140, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품명", false, GridColDataType_emu.VarChar, 120, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPCODE", "검사항목", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPNAME", "검사항목명", false, GridColDataType_emu.VarChar, 100, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPDATE", "검사일시", false, GridColDataType_emu.DateTime, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECNOL", "기준값", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECLSL", "하한값", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SPECUSL", "상한값", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPVALUE", "검사값", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INSPRESULT", "검사결과", false, GridColDataType_emu.VarChar, 80, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);

            _GridUtil.SetColumnTextHAlign(grid1, "ITEMNAME", Infragistics.Win.HAlign.Center);
            _GridUtil.SetColumnTextHAlign(grid1, "INSPNAME", Infragistics.Win.HAlign.Center);
            _GridUtil.SetColumnTextHAlign(grid1, "INSPVALUE", Infragistics.Win.HAlign.Center);
            _GridUtil.SetColumnTextHAlign(grid1, "SPECNOL", Infragistics.Win.HAlign.Center);
            _GridUtil.SetColumnTextHAlign(grid1, "SPECUSL", Infragistics.Win.HAlign.Center);
            _GridUtil.SetColumnTextHAlign(grid1, "SPECLSL", Infragistics.Win.HAlign.Center);
            #endregion

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

            if (sInspType == "자주검사")
            {
                lbl_INSPINFO_H.Text = sItemName + " - " + sInspName;
            }
            else
            {
                lbl_INSPINFO_H.Text = sItemName + " - " + sInspCode;
            }

            btn_SELECT_H.PerformClick();

            FontInit();
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

        private void btnMesrCnt_Click(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);

            _GridUtil.SetInitUltraGridBind(grid1);
            _GridUtil.Grid_Clear(grid1);

            try
            {
                rtnDtTemp = helper.FillTable("USP_UCSPC_S1"
                                                   , CommandType.StoredProcedure
                                                   , helper.CreateParameter("AS_PLANTCODE", sPlantCode, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_ITEMCODE", sItemCode, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_INSPCODE", sInspCode, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_INSPTYPE", sInspType, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AI_INSPCNT", Convert.ToInt32(txt_INSPCNT_H.Text), DbType.Int32, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_STARTDATE", sStartDate, DbType.String, ParameterDirection.Input)
                                                   , helper.CreateParameter("AS_ENDDATE", sEndDate, DbType.String, ParameterDirection.Input));

                if (helper.RSCODE == "S")
                {
                    if (rtnDtTemp.Rows.Count > 0)
                    {
                        grid1.DataSource = rtnDtTemp;
                        grid1.DataBind();

                        for (int i = 0; i < grid1.Rows.Count; i++)
                        {
                            if (Convert.ToString(grid1.Rows[i].Cells["INSPRESULT"].Value) != "OK")
                            {
                                grid1.Rows[i].Cells["INSPRESULT"].Appearance.BackColor = Color.LightPink;
                                grid1.Rows[i].Cells["INSPRESULT"].Appearance.ForeColor = Color.Black;
                            }
                            else
                            {
                                grid1.Rows[i].Cells["INSPRESULT"].Appearance.BackColor = Color.LightBlue;
                                grid1.Rows[i].Cells["INSPRESULT"].Appearance.ForeColor = Color.Black;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(helper.RSMSG);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }

            int pointPosition = 0;
            //SPC차트 그리기
            if (rtnDtTemp.Rows.Count > 0)
            {
                pointPosition = 6;

                LbNomin.Text = SetPointFormat(double.Parse(rtnDtTemp.Rows[0]["SPECNOL"].ToString()), pointPosition);
                LbUTol.Text = SetPointFormat(double.Parse(rtnDtTemp.Rows[0]["SPECUSL"].ToString()) - Convert.ToDouble(LbNomin.Text), pointPosition);
                LbLTol.Text = SetPointFormat(double.Parse(rtnDtTemp.Rows[0]["SPECLSL"].ToString()) - Convert.ToDouble(LbNomin.Text), pointPosition);

                DataList.Clear();
                foreach (DataRow row in rtnDtTemp.Rows)
                {
                    DataList.Add(row.IsNull("INSPVALUE") ? 0.0 : Convert.ToDouble(row["INSPVALUE"]));
                }

                spc.Nominal = double.Parse(rtnDtTemp.Rows[0]["SPECNOL"].ToString());
                spc.UpperTolOffset = (double.Parse(rtnDtTemp.Rows[0]["SPECUSL"].ToString()) - spc.Nominal);
                spc.LowerTolOffset = (double.Parse(rtnDtTemp.Rows[0]["SPECLSL"].ToString()) - spc.Nominal);
                spc.Actual = DataList;

                // 최대값
                LbMax.Text = SetPointFormat(rtnDtTemp.Rows.Cast<DataRow>().Max(row => Convert.ToDouble(row["INSPVALUE"])), pointPosition);
                // 최소값
                LbMin.Text = SetPointFormat(rtnDtTemp.Rows.Cast<DataRow>().Min(row => Convert.ToDouble(row["INSPVALUE"])), pointPosition);
                // 평균
                LbAvg.Text = SetPointFormat(rtnDtTemp.Rows.Cast<DataRow>().Average(row => Convert.ToDouble(row["INSPVALUE"])), pointPosition);
                // 표준편차
                LbSigma.Text = SetPointFormat(spc.Sigma == null ? double.NaN : (double)spc.Sigma, pointPosition);
                LbCp.Text = SetPointFormat(spc.Cp == null ? double.NaN : (double)spc.Cp, pointPosition);
                LbCpk.Text = SetPointFormat(spc.Cpk == null ? double.NaN : (double)spc.Cpk, pointPosition);
                LbPp.Text = SetPointFormat(spc.Pp == null ? double.NaN : (double)spc.Pp, pointPosition);
                LbPpk.Text = SetPointFormat(spc.Ppk == null ? double.NaN : (double)spc.Ppk, pointPosition);


                //공정능력 판정
                if (spc.Cpk == null)
                {
                    lbl_Judge_H.Text = "공정능력판정 : N/A";
                    groupBox1.BackColor = Color.Azure;
                }
                else if ((double)spc.Cpk > 1.67)
                {
                    lbl_Judge_H.Text = "공정능력판정 : 매우안정";
                    groupBox1.BackColor = Color.Azure;
                }
                else if ((double)spc.Cpk > 1.33 && (double)spc.Cpk <= 1.67)
                {
                    lbl_Judge_H.Text = "공정능력판정 : 안정";
                    groupBox1.BackColor = Color.Azure;
                }
                else if ((double)spc.Cpk > 1.00 && (double)spc.Cpk <= 1.33)
                {
                    lbl_Judge_H.Text = "공정능력판정 : 보통";
                    groupBox1.BackColor = Color.Azure;
                }
                else if ((double)spc.Cpk > 0.67 && (double)spc.Cpk <= 1.00)
                {
                    lbl_Judge_H.Text = "공정능력판정 : 불안정";
                    groupBox1.BackColor = Color.LightPink;
                }
                else if ((double)spc.Cpk <= 0.67)
                {
                    lbl_Judge_H.Text = "공정능력판정 : 매우불안정";
                    groupBox1.BackColor = Color.LightPink;
                }
                else
                {
                    lbl_Judge_H.Text = "공정능력판정 : N/A";
                    groupBox1.BackColor = Color.Azure;
                }

                //X_Bar Chart
                ultraChartXBar.Series.Clear();
                DtXBar.Clear();

                if (spc.Actual.Count > 0)
                {
                    for (int i = 0; i <= spc.Actual.Count - 1; i++)
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
                    for (int i = 0; i <= spc.mR.Count - 1; i++)
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

                // 그래프 갱신
                Chart1.Series[0].Points.Clear();
                for (int i = 0; i <= spc.DIstribution.Count - 1; i++)
                {
                    Chart1.Series[0].Points.Add(new DataPoint(spc.NormalDistribution[i].X, spc.Frequency[i]));
                    // X값, Y값
                }

                // 표준 정규분포
                Chart1.Series[1].Points.Clear();
                for (int i = 0; i <= spc.NormalDistribution.Count - 1; i++)
                {
                    Chart1.Series[1].Points.Add(new DataPoint(spc.NormalDistribution[i].X, spc.NormalDistribution[i].Y));
                }

                double maxY = 0.0;
                for (int i = 0; i <= spc.NormalDistribution.Count - 1; i++)
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

                LbNomin.Text = "";
                LbMax.Text = "";
                LbMin.Text = "";
                LbAvg.Text = "";
                LbSigma.Text = "";
                LbUTol.Text = "";
                LbLTol.Text = "";
                LbCp.Text = "";
                LbCpk.Text = "";
                LbPp.Text = "";
                LbPpk.Text = "";
            }
        }

        public void PerformAction_btnMesrCnt()
        {
            btn_SELECT_H.PerformClick();
        }
        #endregion

        private void FontInit()
        {
            Chart1.Titles[0].Text = Common.getLangText("정규분포 히스토그램");

            Chart1.Series[0].Name = Common.getLangText("도수");
            Chart1.Series[1].Name = Common.getLangText("정규분포");

            Chart1.Titles[0].Font = new System.Drawing.Font(Common.FontName, 12F, FontStyle.Bold);

            Chart1.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font(Common.FontName, 8F);
            Chart1.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font(Common.FontName, 8F);

            Chart1.Series[0].Font = new Font(Common.FontName, 8F);
            Chart1.Series[1].Font = new Font(Common.FontName, 8F);
            Chart1.Series[2].Font = new Font(Common.FontName, 8F);
            Chart1.Series[3].Font = new Font(Common.FontName, 8F);
            Chart1.Series[4].Font = new Font(Common.FontName, 8F);
            Chart1.Series[5].Font = new Font(Common.FontName, 8F);
            Chart1.Series[6].Font = new Font(Common.FontName, 8F);
            Chart1.Series[7].Font = new Font(Common.FontName, 8F);

            Chart1.Legends[0].Font = new Font(Common.FontName, 8F);
        }
    }
}

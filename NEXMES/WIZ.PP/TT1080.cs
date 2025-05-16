#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : TT1080
//   Form Name    : 브레이징 온도 모니터링
//   Name Space   : WIZ.PP
//   Created Date : 
//   Made By      : WIZCORE
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using Infragistics.UltraGauge.Resources;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGauge;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
#endregion

namespace WIZ.PP
{
    public partial class TT1080 : WIZ.Forms.BaseMDIChildForm
    {
        #region <MEMBER AREA>
        delegate void EventHandlerAddCtrl();
        event EventHandlerAddCtrl OnAddCtrl;
        Hashtable hash = new Hashtable();
        #endregion

        #region <CUSTOM CLASS AREA>
        public class ClassGauge
        {
            public string PlcAddr;
            public UltraGauge Gauge;
            public UltraLabel Label;

            public double Min;
            public double Max;
            public double TickInterval;
            public double Target;
            public string Value;
            public ClassGauge(string name, double dMin, double dMax, double dTickMarkInterval, string dValue, double dTarget = 0)
            {
                PlcAddr = name;
                string a = (dValue.Substring(8, 4)).Trim();
                Gauge = new UltraGauge();
                Gauge.Dock = DockStyle.Fill;
                Gauge.BackColor = Color.Bisque;

                Label = new UltraLabel();
                Label.Dock = DockStyle.Fill;
                Label.Appearance.TextHAlign = HAlign.Center;
                Label.Appearance.TextVAlign = VAlign.Middle;
                Label.Appearance.BackColor = Color.Azure;
                Label.Font = new System.Drawing.Font
                                              ("맑은고딕", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Label.AutoSize = true;
                if (Convert.ToInt32(dValue.Substring(8, 4).Trim()) > dMax)
                {
                    Label.Appearance.BackColor = Color.Red;
                }
                else if (Convert.ToInt32(dValue.Substring(8, 4).Trim()) < dMin)
                {
                    Label.Appearance.BackColor = Color.PowderBlue;
                }
                Min = dMin;
                Max = dMax;
                Value = dValue;
                Target = dTarget;
                TickInterval = dTickMarkInterval;
            }

            public void SetValue()
            {
                if (Label != null)
                    Label.Text = DBHelper.nvlString(Value);
            }
        }

        #endregion

        #region <CONSTRUCTOR>
        public TT1080()
        {
            InitializeComponent();
            splitContainer1.SplitterDistance = this.Width / 2;
            //th = new Thread(new ThreadStart(FunctionForThread));
            //th.Start();
        }
        #endregion

        #region <EVENT AREA>
        private void TT1080_Load(object sender, EventArgs e)
        {
            Common _Common = new Common();
            DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
            MakeGauge();
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            WIZ.Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);

            ultraGroupBox1.Appearance.ForeColor = Color.Black;

            trmReload.Enabled = true;
            FunctionForThread();
        }

        private void TT1080_FormClosed(object sender, FormClosedEventArgs e)
        {
            trmReload.Stop();
            trmReload.Enabled = false;
            //if (th != null)
            //{
            //    th.Abort();
            //    th = null;
            //}
        }

        private void TT1080_Enter(object sender, EventArgs e)
        {
            trmReload.Start();
            //if (th == null)
            //{
            //    th = new Thread(new ThreadStart(FunctionForThread));
            //    th.Start();
            //}
            //else
            //{
            //    //th.Start();
            //}
        }
        #endregion

        #region <TOOL BAR AREA >
        public override void DoInquire()
        {

            //try
            //{
            //    //base.DoInquire();
            //}
            //catch (Exception ex)
            //{
            //    this.ShowDialog(ex.ToString());
            //}
            //finally
            //{
            //    helper.Close();
            //}
        }
        #endregion

        #region <METHOD AREA>
        private void FunctionForThread()
        {
            try
            {
                CheckForIllegalCrossThreadCalls = false;
                sTime.Text = string.Format("{0:MM/dd}", DateTime.Now).Replace("-", "/") + "\n" +
                             string.Format("{0:HH:mm}", DateTime.Now);
                //if (th != null)
                //{
                //    while (true)
                //    {
                //        Thread.Sleep(3 * 1000);
                SetStatusMessage(string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now) + " 에 온도 데이터가 갱신 되었습니다.");
                DoGauge();

                //    }
                //}

            }
            catch (Exception ex)
            {

            }
        }

        private void MakeGauge()
        {
            try
            {
                DataTable table = new DataTable();
                DBHelper helper = new DBHelper(false);

                System.Data.Common.DbParameter[] param = new System.Data.Common.DbParameter[1];

                try
                {
                    param[0] = helper.CreateParameter("@pPlantCode", DbType.String, "821");
                    table = helper.FillTable("USP_TT1080_S1", CommandType.StoredProcedure, param);
                    if (table.Rows.Count == 0)
                    {
                        return;
                    }
                    int ix = 0, iy = 0;
                    TableLayoutPanel tlp = layout1;

                    foreach (DataRow dr in table.Rows)
                    {
                        string name = DBHelper.nvlString(dr["PLCADDR"]);
                        double dMin = DBHelper.nvlDouble(dr["RelCode1"]);
                        double dMax = DBHelper.nvlDouble(dr["RelCode2"]);
                        double dInterval = Math.Round((dMax - dMin) / 5, 2);
                        string dValue = DBHelper.nvlString(dr["Value"]);
                        double dTarget = DBHelper.nvlDouble(dr["RelCode3"]);

                        ClassGauge cg = new ClassGauge(name, dMin, dMax, dInterval, dValue, dTarget);

                        hash.Add(name, cg);

                        if (ix == 3)
                        {
                            iy++;

                            if (iy == 3 && ix == 3)
                            {
                                if (tlp.Equals(layout2)) break;

                                tlp = layout2;

                                iy = 0;
                                ix = 0;
                            }

                            ix = 0;
                        }

                        tlp.Controls.Add(cg.Gauge, ix, iy * 2);
                        tlp.Controls.Add(cg.Label, ix, (iy * 2) + 1);

                        DoGauge(cg);
                        ix++;
                    }
                }
                catch (Exception e)
                {
                    this.ShowDialog(e.ToString());
                }
                finally
                {
                    helper.Close();
                    if (param != null) { param = null; }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void DoGauge()
        {
            try
            {
                DataTable table = new DataTable();
                DBHelper helper = new DBHelper(false);

                try
                {
                    Configuration appConfig1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    SqlCommand oCmd = new SqlCommand();
                    oCmd.Connection = new SqlConnection();
                    oCmd.Connection.ConnectionString = appConfig1.ConnectionStrings.ConnectionStrings["ConnectionString"].ConnectionString;
                    oCmd.CommandText = "USP_TT1080_S1A";
                    oCmd.CommandType = CommandType.StoredProcedure;
                    oCmd.Parameters.Add(helper.CreateParameter("@pPlantCode", DbType.String, "821"));

                    SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);

                    oAdap.Fill(table);

                    foreach (DataRow dr in table.Rows)
                    {
                        string name = DBHelper.nvlString(dr["PLCADDR"]);
                        string dValue = DBHelper.nvlString(dr["Value"]);

                        ClassGauge cg = (ClassGauge)hash[name];
                        cg.Value = dValue;

                        DoGauge(cg);
                    }
                }
                catch (Exception e)
                {
                    throw (e);
                }
            }
            catch (Exception ex)
            {
                //this.ShowDialog(ex.ToString());
            }
        }

        private void DoGauge(ClassGauge cg)
        {
            try
            {
                UltraGauge ug = cg.Gauge;
                LinearGauge gauge1 = ug.Gauges.AddLinearGauge();
                gauge1.Orientation = LinearOrientation.Vertical;
                LinearGaugeScale fahrenheitScale = new LinearGaugeScale();
                gauge1.Scales.Add(fahrenheitScale);
                fahrenheitScale.StartExtent = 20.0;
                fahrenheitScale.EndExtent = 80.0;
                fahrenheitScale.Axis = new NumericAxis(cg.Min, cg.Max, cg.TickInterval);
                fahrenheitScale.Labels.Extent = 21.0;
                fahrenheitScale.Labels.BrushElement = new SolidFillBrushElement(Color.Black);
                fahrenheitScale.Labels.ZPosition = LinearTickmarkZPosition.BelowMarkers;
                fahrenheitScale.Labels.Font = new System.Drawing.Font
                                              ("맑은고딕", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                fahrenheitScale.MajorTickmarks.StrokeElement.Color = Color.Black;
                fahrenheitScale.MajorTickmarks.StartExtent = 30.0;
                fahrenheitScale.MajorTickmarks.EndExtent = 40.0;
                LinearGaugeBarMarker barMarker = fahrenheitScale.Markers.AddBarMarker();
                barMarker.BrushElement = new SolidFillBrushElement(Color.Red);
                barMarker.BulbSpan = 20.0;
                if (Convert.ToInt32((cg.Value).Substring(8, 4).Trim()) > cg.Max) barMarker.Value = cg.Max;
                else barMarker.Value = Convert.ToInt32((cg.Value).Substring(8, 4).Trim());
                barMarker.Background.BrushElement = new SolidFillBrushElement(Color.White);
                barMarker.StrokeElement.Color = Color.Black;
                barMarker.Background.StrokeElement.Color = Color.Black;
                BoxAnnotation fahrenheitAnnotation = new BoxAnnotation();
                fahrenheitAnnotation.BoundsMeasure = Measure.Percent;
                fahrenheitAnnotation.Bounds = new Rectangle(0, 0, 40, 20);
                fahrenheitAnnotation.Label.BrushElement = new SolidFillBrushElement(Color.Black);
                fahrenheitAnnotation.Label.FormatString = "섭씨(℃)";
                ug.Annotations.Add(fahrenheitAnnotation);

                BoxAnnotation fahrenheitAnnotation2 = new BoxAnnotation();
                fahrenheitAnnotation2.BoundsMeasure = Measure.Percent;
                fahrenheitAnnotation2.Bounds = new Rectangle(60, 55, 40, 30);
                fahrenheitAnnotation2.Label.BrushElement = new SolidFillBrushElement(Color.Black);
                StringBuilder sTmp = new StringBuilder();
                sTmp.AppendLine("USL : " + cg.Max.ToString());
                sTmp.AppendLine("  CL : " + cg.Target.ToString());
                sTmp.AppendLine("LSL : " + cg.Min.ToString());
                fahrenheitAnnotation2.Label.FormatString = sTmp.ToString();
                ug.Annotations.Add(fahrenheitAnnotation2);

                cg.SetValue();
            }
            catch (Exception ex)
            {

                throw (ex);
            }

        }
        private void TT1080_Deactivate(object sender, EventArgs e)
        {
            //if (th != null)
            //{
            //    th.Abort();
            //    th = null;
            //}
            trmReload.Stop();
        }

        private void trmReload_Tick(object sender, EventArgs e)
        {
            FunctionForThread();
        }
        #endregion

    }
}

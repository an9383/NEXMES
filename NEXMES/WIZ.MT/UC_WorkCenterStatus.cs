#region [ USING AREA ]
using Infragistics.UltraChart.Resources.Appearance;
using Infragistics.UltraChart.Shared.Styles;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace WIZ.MT
{
    public partial class UC_WorkCenterStatus : UserControl
    {
        private DataTable dtChart = new DataTable();

        private DataRow drWorkCenter;

        private Hashtable hashX = new Hashtable();
        private Hashtable hashY = new Hashtable();
        private Hashtable hashD = new Hashtable();

        Color[] _selColor = new Color[] { Color.Red };

        public UC_WorkCenterStatus()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);

            InitChart();
        }

        public DataRow WCData
        {
            get
            {
                return drWorkCenter;
            }
            set
            {
                drWorkCenter = value;

                crtStatus.Series.Clear();
                dtChart.Rows.Clear();

                dtChart.Rows.Add(drWorkCenter["WORKCENTERCODE"], drWorkCenter["WORKPERCENT"]);

                NumericSeries _srs = new NumericSeries();
                _srs.DataBind(dtChart, "VALUE", "TARGET");
                crtStatus.Series.Add(_srs);

                lblItemCode.Text = Convert.ToString(drWorkCenter["ITEMCODE"]);
                lblItemName.Text = Convert.ToString(drWorkCenter["ITEMNAME"]);
                lblWorkCenterCode.Text = "[" + Convert.ToString(drWorkCenter["WORKCENTERCODE"]) + "] " + Convert.ToString(drWorkCenter["WORKCENTERNAME"]);
                lblOrdQty.Text = Convert.ToString(drWorkCenter["ORDERQTY"]);
                lblProdQty.Text = Convert.ToString(drWorkCenter["PRODQTY"]);
                lblLineStatus.Text = Convert.ToString(drWorkCenter["WORKCENTERSTATUS"]);
                lblLastLineTime.Text = Convert.ToString(drWorkCenter["LASTDATE"]);

                switch (Convert.ToString(drWorkCenter["WORKCENTERSTATUS"]))
                {
                    case "R":
                        this.SetColor(Color.FromArgb(45, 134, 186), Color.Black, Color.White);
                        break;
                    case "S":
                        switch (Convert.ToString(drWorkCenter["STOPTYPE"]))
                        {
                            case "AA": // 계획정지
                                this.SetColor(Color.FromArgb(191, 61, 39), Color.Black, Color.White);
                                break;
                            case "BB": // 장비/설비
                                this.SetColor(Color.FromArgb(215, 126, 71), Color.Black, Color.White);
                                break;
                            case "CC": // 품질정지
                                this.SetColor(Color.FromArgb(172, 126, 184), Color.Black, Color.White);
                                break;
                            case "DD": // 제품/부품
                                this.SetColor(Color.FromArgb(239, 200, 73), Color.Black, Color.White);
                                break;
                            case "EE": // 인적요인
                                this.SetColor(Color.FromArgb(106, 138, 75), Color.Black, Color.White);
                                break;
                        }
                        break;
                    default:
                        this.SetColor(Color.White, Color.Black, Color.FromArgb(64, 64, 64));
                        break;
                }
            }
        }

        private void SetColor(Color bClr, Color fClr, Color fClr2)
        {
            this.BackColor = bClr;
            pnlHeader.BackColor = bClr;

            this.lblWorkCenterCode.ForeColor = fClr2;
            this.lblItemCode.ForeColor = fClr;
            this.lblItemName.ForeColor = fClr;
            this.lblOrdQty.ForeColor = fClr;
            this.lblLineStatus.ForeColor = fClr;
            this.lblLastLineTime.ForeColor = fClr;
        }

        private void InitChart()
        {
            dtChart.Columns.Add(new DataColumn("TARGET", typeof(string)));
            dtChart.Columns.Add(new DataColumn("VALUE", typeof(double)));

            crtStatus.ChartType = ChartType.BarChart;
            crtStatus.Data.ZeroAligned = true;
            crtStatus.Axis.X.RangeType = AxisRangeType.Custom;
            crtStatus.Axis.X.RangeMin = 0;
            crtStatus.Axis.X.RangeMax = 100;
            crtStatus.ColorModel.CustomPalette = _selColor;
            crtStatus.Axis.X.Labels.Visible = false;
            crtStatus.Axis.Y.Labels.Visible = false;
            crtStatus.Axis.Z.Labels.Visible = false;
            crtStatus.Axis.X2.Labels.Visible = false;
            crtStatus.Axis.Y2.Labels.Visible = false;
            crtStatus.Axis.Z2.Labels.Visible = false;
            crtStatus.Axis.X.Visible = false;
            crtStatus.Axis.Y.Visible = false;
            crtStatus.Axis.Z.Visible = false;
            crtStatus.Axis.X2.Visible = false;
            crtStatus.Axis.Y2.Visible = false;
            crtStatus.Axis.Z2.Visible = false;
        }
    }
}

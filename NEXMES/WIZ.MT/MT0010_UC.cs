using Infragistics.UltraGauge.Resources;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace WIZ.MT
{
    public partial class MT0010_UC : UserControl
    {
        public MT0010_UC()
        {
            InitializeComponent();

        }

        private DataRow DrWorkCenter;
        public DataRow WCData
        {
            get { return DrWorkCenter; }
            set
            {
                DrWorkCenter = value;

                string sTest = Convert.ToString(DrWorkCenter["WORKCENTERCODE"]);
                //lblWorkCenterCode.Text = Convert.ToString(DrWorkCenter["WORKCENTERCODE"]);
                lblWorkCenterName.Text = Convert.ToString(DrWorkCenter["WORKCENTERNAME"]);
                //lblItemCode.Text = Convert.ToString(DrWorkCenter["ITEMCODE"]);
                lblItemName.Text = Convert.ToString(DrWorkCenter["ITEMNAME"]);
                lblProdQty.Text = Convert.ToString(DrWorkCenter["PRODQTY"]);
                lblLineStatus.Text = Convert.ToString(DrWorkCenter["LASTWORKCENTERSTATUS"]);
                lblLastLineTime.Text = Convert.ToString(DrWorkCenter["LASTWORKCENTERTIME"]);
                lblWorkCenterName.AutoSize = true;

                if (lblWorkCenterName.Text != string.Empty)
                    picWcName.Image = Properties.Resources.settings;

                if (lblItemName.Text != string.Empty)
                    picItemName.Image = Properties.Resources.Item;

                if (lblLineStatus.Text != string.Empty)
                    lblLineStatus.Appearance.BackColor = Color.White;

                SettingGauge(Convert.ToString(DrWorkCenter["PRODQTY2"]), Convert.ToString(DrWorkCenter["ORDERQTY"]));
                SetSize();

                switch (Convert.ToString(DrWorkCenter["WORKCENTERSTATUS"]))
                {
                    case "R":
                        SetColor(Color.FromArgb(76, 175, 80), Color.White);
                        break;
                    case "S":
                        switch (Convert.ToString(DrWorkCenter["STOPTYPE"]))
                        {
                            case "AA":
                                SetColor(Color.FromArgb(2, 136, 209), Color.White);
                                break;
                            case "BB":
                                SetColor(Color.FromArgb(229, 57, 53), Color.White);
                                break;
                            case "CC":
                                SetColor(Color.FromArgb(245, 127, 23), Color.White);
                                break;
                            case "DD":
                                SetColor(Color.FromArgb(245, 127, 23), Color.White);
                                break;
                            case "EE":
                                SetColor(Color.FromArgb(245, 127, 23), Color.White);
                                break;
                            default:
                                SetColor(Color.FromArgb(220, 219, 214), Color.White);
                                ultraGauge1.Visible = false;
                                break;
                        }
                        break;
                    default:
                        this.SetColor(Color.FromArgb(220, 219, 214), Color.White);
                        break;
                }
            }
        }

        private void SettingGauge(string sProdQty, string sOrderQty)
        {
            if (sProdQty == string.Empty || sOrderQty == string.Empty)
            {
                ultraGauge1.Visible = false;
                return;
            }

            int iProdQty = Convert.ToInt32(sProdQty);
            int iOrderQty = Convert.ToInt32(sOrderQty);
            double dValue = 0;

            if (iProdQty != 0 && iOrderQty != 0)
                dValue = Math.Round((double)iProdQty * 100 / iOrderQty, 0);
            int iAnnoYAxis = 0;

            LinearGauge gauge = (LinearGauge)ultraGauge1.Gauges[0];
            LinearGaugeMarker marker = gauge.Scales[0].Markers[0];

            if (dValue > 100)
                dValue = 100;

            SolidFillBrushElement brush1 = new SolidFillBrushElement();
            //brush1.Color = Color.White;
            brush1.Color = Color.FromArgb(253, 248, 145); // Yellow

            marker.Value = dValue;
            marker.BrushElement = brush1;

            SolidFillBrushElement brush2 = new SolidFillBrushElement();
            brush2.Color = Color.Black;

            SolidFillBrushElement brush3 = new SolidFillBrushElement();
            brush3.Color = Color.White;

            BoxAnnotation boxAnnotation1 = new BoxAnnotation();
            boxAnnotation1.BrushElement = brush2;
            boxAnnotation1.Label.BrushElement = brush3;
            boxAnnotation1.StrokeElement.Color = Color.Black;

            if (dValue <= 10)
                iAnnoYAxis = 90;
            else
                iAnnoYAxis = 100 - Convert.ToInt32(dValue);

            boxAnnotation1.Bounds = new Rectangle(8, iAnnoYAxis, 90, 10);
            boxAnnotation1.BoundsMeasure = Measure.Percent;
            boxAnnotation1.Label.Font = new Font("맑은 고딕", 9, FontStyle.Bold);
            boxAnnotation1.Label.FormatString = Convert.ToString(dValue) + "%";
            ultraGauge1.Annotations.Add(boxAnnotation1);
        }

        private void SetSize()
        {
            int iWidth = Screen.PrimaryScreen.Bounds.Width;
            int iHeight = Screen.PrimaryScreen.Bounds.Height;

            double dUCRate = Math.Round((double)iWidth * 100 / 1920, 2);

            this.Width = (int)(this.Width * ((double)dUCRate / 100));
            this.Height = (int)(this.Height * ((double)dUCRate / 100));
        }

        // Event 연결
        private void lbl_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }

        private void SetColor(Color bClr, Color fClr)
        {
            BackColor = bClr;

            //lblWorkCenterCode.ForeColor = fClr;
            lblWorkCenterName.ForeColor = fClr;
            //lblItemCode.ForeColor = fClr;
            lblItemName.ForeColor = fClr;
            lblProdQty.ForeColor = fClr;
            lblLineStatus.ForeColor = bClr;
            lblLastLineTime.ForeColor = fClr;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN
                return parms;
            }
        }
    }
}

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WIZ.MT
{
    public partial class UC_WorkCenter : UserControl
    {
        public UC_WorkCenter()
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

                lblWorkCenterCode.Text = Convert.ToString(DrWorkCenter["WORKCENTERCODE"]);
                lblWorkCenterName.Text = Convert.ToString(DrWorkCenter["WORKCENTERNAME"]);
                lblItemCode.Text = Convert.ToString(DrWorkCenter["ITEMCODE"]);
                lblItemName.Text = Convert.ToString(DrWorkCenter["ITEMNAME"]);
                lblProdQty.Text = Convert.ToString(DrWorkCenter["PRODQTY"]);
                lblLineStatus.Text = Convert.ToString(DrWorkCenter["LASTWORKCENTERSTATUS"]);
                lblLastLineTime.Text = Convert.ToString(DrWorkCenter["LASTWORKCENTERTIME"]);

                switch (Convert.ToString(DrWorkCenter["WORKCENTERSTATUS"]))
                {
                    case "R":
                        this.BackColor = Color.White;
                        break;
                    case "S":
                        switch (Convert.ToString(DrWorkCenter["STOPTYPE"]))
                        {
                            case "A":
                                this.SetColor(Color.Blue, Color.White);
                                break;
                            case "B":
                                this.SetColor(Color.Orange, Color.Black);
                                break;
                            case "C":
                                this.SetColor(Color.Red, Color.White);
                                break;
                            case "D":
                                this.SetColor(Color.Yellow, Color.Black);
                                break;
                        }
                        break;
                    default:
                        this.SetColor(Color.White, Color.Black);
                        break;
                }
            }
        }

        // Event 연결
        private void lbl_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }

        private void SetColor(Color bClr, Color fClr)
        {
            this.BackColor = bClr;

            this.lblWorkCenterCode.ForeColor = fClr;
            this.lblWorkCenterName.ForeColor = fClr;
            this.lblItemCode.ForeColor = fClr;
            this.lblItemName.ForeColor = fClr;
            this.lblProdQty.ForeColor = fClr;
            this.lblLineStatus.ForeColor = fClr;
            this.lblLastLineTime.ForeColor = fClr;
        }
    }
}

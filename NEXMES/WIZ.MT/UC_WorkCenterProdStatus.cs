using System;
using System.Data;
using System.Windows.Forms;

namespace WIZ.MT
{
    public partial class UC_WorkCenterProdStatus : UserControl
    {
        public UC_WorkCenterProdStatus()
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

                if (DrWorkCenter == null)
                {
                    return;
                }


                lblWorkCenterName.Text = Convert.ToString(DrWorkCenter["WORKCENTERNAME"]);
                lblProdRate1.Text = "진행율:" + Convert.ToString(DrWorkCenter["PRODRATE1"]);
                lblProdRate2.Text = "달성율:" + Convert.ToString(DrWorkCenter["PRODRATE2"]);
            }
        }

        // Event 연결
        private void lbl_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }
    }
}

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WIZ.MT
{
    public partial class UC_WorkCenterCheck : UserControl
    {
        private DataRow drWorkCenter;

        public UC_WorkCenterCheck()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);

            pnlStatus01.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("NG_FC");
            pnlStatus02.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("NG_FC");
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

                lblWorkCenterCode.Text = "[" + Convert.ToString(drWorkCenter["WORKCENTERCODE"]) + "] " + Convert.ToString(drWorkCenter["WORKCENTERNAME"]);
                lblDayCnt.Text = Convert.ToString(drWorkCenter["DAYCNT"]);
                lblMonthCnt.Text = Convert.ToString(drWorkCenter["MONTHCNT"]);

                if (Convert.ToString(drWorkCenter["DAILYCHECK"]) == "N")
                {
                    pnlStatus01.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("NG_FC");
                }
                else if (Convert.ToString(drWorkCenter["DAILYCHECK"]) == "I")
                {
                    pnlStatus01.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Wait_FC");
                }
                else if (Convert.ToString(drWorkCenter["DAILYCHECK"]) == "Y")
                {
                    pnlStatus01.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("OK_FC");
                }
                else
                {
                    pnlStatus01.BackgroundImage = null;
                }

                if (Convert.ToString(drWorkCenter["MONTHCHECK"]) == "N")
                {
                    pnlStatus02.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("NG_FC");
                }
                else if (Convert.ToString(drWorkCenter["MONTHCHECK"]) == "I")
                {
                    pnlStatus02.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Wait_FC");
                }
                else if (Convert.ToString(drWorkCenter["MONTHCHECK"]) == "Y")
                {
                    pnlStatus02.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("OK_FC");
                }
                else
                {
                    pnlStatus02.BackgroundImage = null;
                }
            }
        }
    }
}

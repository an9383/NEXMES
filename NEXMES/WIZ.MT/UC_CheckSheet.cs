using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WIZ.MT
{
    public partial class UC_CheckSheet : UserControl
    {
        private DataRow drWorkCenter;

        public UC_CheckSheet()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);

            pnlDay01.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("NG_INSP");
            pnlDay02.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("NG_INSP");
            pnlDay03.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("NG_INSP");
            pnlNight01.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("NG_INSP");
            pnlNight02.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("NG_INSP");
            pnlNight03.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("NG_INSP");
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

                if (Convert.ToString(drWorkCenter["INSP01D"]) == "N")
                {
                    pnlDay01.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("NG_INSP");
                }
                else if (Convert.ToString(drWorkCenter["INSP01D"]) == "I")
                {
                    pnlDay01.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Wait_INSP");
                }
                else if (Convert.ToString(drWorkCenter["INSP01D"]) == "Y")
                {
                    pnlDay01.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("OK_INSP");
                }
                else
                {
                    pnlDay01.BackgroundImage = null;
                }

                if (Convert.ToString(drWorkCenter["INSP02D"]) == "N")
                {
                    pnlDay02.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("NG_INSP");
                }
                else if (Convert.ToString(drWorkCenter["INSP02D"]) == "I")
                {
                    pnlDay02.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Wait_INSP");
                }
                else if (Convert.ToString(drWorkCenter["INSP02D"]) == "Y")
                {
                    pnlDay02.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("OK_INSP");
                }
                else
                {
                    pnlDay02.BackgroundImage = null;
                }

                if (Convert.ToString(drWorkCenter["INSP03D"]) == "N")
                {
                    pnlDay03.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("NG_INSP");
                }
                else if (Convert.ToString(drWorkCenter["INSP03D"]) == "I")
                {
                    pnlDay03.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Wait_INSP");
                }
                else if (Convert.ToString(drWorkCenter["INSP03D"]) == "Y")
                {
                    pnlDay03.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("OK_INSP");
                }
                else
                {
                    pnlDay03.BackgroundImage = null;
                }

                if (Convert.ToString(drWorkCenter["INSP01N"]) == "N")
                {
                    pnlNight01.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("NG_INSP");
                }
                else if (Convert.ToString(drWorkCenter["INSP01N"]) == "I")
                {
                    pnlNight01.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Wait_INSP");
                }
                else if (Convert.ToString(drWorkCenter["INSP01N"]) == "Y")
                {
                    pnlNight01.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("OK_INSP");
                }
                else
                {
                    pnlNight01.BackgroundImage = null;
                }

                if (Convert.ToString(drWorkCenter["INSP02N"]) == "N")
                {
                    pnlNight02.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("NG_INSP");
                }
                else if (Convert.ToString(drWorkCenter["INSP02N"]) == "I")
                {
                    pnlNight02.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Wait_INSP");
                }
                else if (Convert.ToString(drWorkCenter["INSP02N"]) == "Y")
                {
                    pnlNight02.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("OK_INSP");
                }
                else
                {
                    pnlNight02.BackgroundImage = null;
                }

                if (Convert.ToString(drWorkCenter["INSP03N"]) == "N")
                {
                    pnlNight03.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("NG_INSP");
                }
                else if (Convert.ToString(drWorkCenter["INSP03N"]) == "I")
                {
                    pnlNight03.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("Wait_INSP");
                }
                else if (Convert.ToString(drWorkCenter["INSP03N"]) == "Y")
                {
                    pnlNight03.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("OK_INSP");
                }
                else
                {
                    pnlNight03.BackgroundImage = null;
                }
            }
        }
    }
}

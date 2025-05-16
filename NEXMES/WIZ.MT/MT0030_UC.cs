#region [ USING AREA ]
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace WIZ.MT
{
    public partial class MT0030_UC : UserControl
    {
        #region [ MEMBER AREA ]
        private string sWorkCenter = string.Empty;
        private string sStatus = string.Empty;
        private string sStopType = string.Empty;
        private string sQty = string.Empty;

        private int iMoveX, iMoveY;

        private bool bDrag = false;

        private DataRow drWC;
        #endregion

        #region [ CONSTRUCTOR ]
        public MT0030_UC()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            this.BackgroundImageLayout = ImageLayout.Stretch;
            picIcon.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        protected override void OnNotifyMessage(Message m)
        {
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
        #endregion

        #region [ EVENT AREA ]
        private void picIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bDrag = true;

                iMoveX = e.X;
                iMoveY = e.Y;
            }
        }

        private void picIcon_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && bDrag)
            {
                Point curLoc = this.Location;

                curLoc.X += e.X - iMoveY;
                curLoc.Y += e.Y - iMoveY;

                this.Location = curLoc;
            }
        }

        private void picIcon_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DBHelper helper = new DBHelper(true);

                try
                {
                    helper.ExecuteNoneQuery("USP_MT0030_U1", CommandType.StoredProcedure
                    , helper.CreateParameter("AS_PLANTCODE", DbType.String, LoginInfo.PlantCode)
                    , helper.CreateParameter("AS_WORKCENTERCODE", DbType.String, sWorkCenter)
                    , helper.CreateParameter("AI_XAXIS", DbType.Int32, this.Left)
                    , helper.CreateParameter("AI_YAXIS", DbType.Int32, this.Top));

                    if (helper.RSCODE == "S")
                    {
                        helper.Commit();
                    }
                    else
                    {
                        throw new Exception(helper.RSMSG);
                    }
                }
                catch (Exception ex)
                {
                    helper.Rollback();
                }
                finally
                {
                    helper.Close();

                    bDrag = false;
                }
            }
        }
        #endregion

        #region [ METHOD AREA ]
        public DataRow WCData
        {
            get
            {
                return drWC;
            }
            set
            {
                drWC = value;

                sWorkCenter = Convert.ToString(drWC["WORKCENTERCODE"]);
                sStatus = Convert.ToString(drWC["WORKCENTERSTATUS"]);
                sStopType = Convert.ToString(drWC["STOPTYPE"]);

                lblQty.Text = Convert.ToString(drWC["PRODQTY"]);
                lblWorkcenter.Text = Convert.ToString(drWC["WORKCENTERNAME"]);

                switch (sStatus)
                {
                    case "R":
                        this.BackgroundImage = Properties.Resources.MT0030_001;
                        break;
                    default:
                        this.BackgroundImage = Properties.Resources.MT0030_002;
                        break;
                }

                switch (sStopType)
                {
                    case "AA":
                        picIcon.Image = Properties.Resources.MT0030_004;
                        break;
                    case "BB":
                        picIcon.Image = Properties.Resources.MT0030_005;
                        break;
                    case "CC":
                        picIcon.Image = Properties.Resources.MT0030_006;
                        break;
                    default:
                        picIcon.Image = Properties.Resources.MT0030_003;
                        break;
                }
            }
        }
        #endregion
    }
}

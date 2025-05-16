using Infragistics.Win.Misc;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WIZ.Control;

namespace WIZ.Forms
{
    public class BaseProgressForm : Form
    {
        private IContainer components = null;

        private UltraPanel pnlBody;

        public CircularProgressControl indProgress;

        public BaseProgressForm()
        {
            InitializeComponent();
        }

        public BaseProgressForm(Point locpoint, int width, int height)
        {
            InitializeComponent();
            base.Location = new Point(locpoint.X + (width - base.Width) / 2, locpoint.Y + (height - base.Height) / 2);
        }

        private void BaseProgressForm_Load(object sender, EventArgs e)
        {
            indProgress.Start();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            pnlBody = new Infragistics.Win.Misc.UltraPanel();
            indProgress = new WIZ.Control.CircularProgressControl();
            pnlBody.ClientArea.SuspendLayout();
            pnlBody.SuspendLayout();
            SuspendLayout();
            appearance.BorderColor = System.Drawing.Color.Gray;
            pnlBody.Appearance = appearance;
            pnlBody.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            pnlBody.ClientArea.Controls.Add(indProgress);
            pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlBody.Location = new System.Drawing.Point(0, 0);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new System.Drawing.Size(306, 93);
            pnlBody.TabIndex = 4;
            indProgress.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            indProgress.BackColor = System.Drawing.Color.Black;
            indProgress.CenterMessage = "0%";
            indProgress.Font = new System.Drawing.Font("맑은 고딕", 13f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            indProgress.ForeColor = System.Drawing.Color.Lime;
            indProgress.InnerRadiousFactor = 0.6f;
            indProgress.Interval = 60;
            indProgress.IsShowMessage = true;
            indProgress.Location = new System.Drawing.Point(2, 2);
            indProgress.Message = "조회중...";
            indProgress.MessagePosition = WIZ.Control.CircularProgressControl.MessagePositionType.Right;
            indProgress.MinimumSize = new System.Drawing.Size(28, 28);
            indProgress.Name = "indProgress";
            indProgress.OuterRadiousFactor = 0.7f;
            indProgress.Percent = 0.0;
            indProgress.Rotation = WIZ.Control.CircularProgressControl.Direction.CLOCKWISE;
            indProgress.ShowTime = true;
            indProgress.Size = new System.Drawing.Size(300, 87);
            indProgress.SpokesCount = 50;
            indProgress.SpokeThick = 2;
            indProgress.StartAngle = 270f;
            indProgress.TabIndex = 0;
            indProgress.TickColor = System.Drawing.Color.Lime;
            indProgress.Type = WIZ.Control.CircularProgressControl.ControlType.PROGRESS;
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.White;
            //base.ClientSize = new System.Drawing.Size(306, 93);
            base.ClientSize = new System.Drawing.Size(306, 73);
            base.Controls.Add(pnlBody);
            DoubleBuffered = true;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.Name = "BaseProgressForm";
            base.ShowInTaskbar = false;
            base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "BaseProgressForm";
            base.Load += new System.EventHandler(BaseProgressForm_Load);
            pnlBody.ClientArea.ResumeLayout(false);
            pnlBody.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}

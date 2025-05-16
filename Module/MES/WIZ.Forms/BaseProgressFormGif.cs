using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WIZ.Forms
{
    public class BaseProgressFormGif : Form
    {
        private IContainer components = null;

        private PictureBox pictureBox1;

        public BaseProgressFormGif()
        {
            InitializeComponent();
        }

        public BaseProgressFormGif(Point locpoint, int width, int height)
        {
            InitializeComponent();
            base.Location = new Point(locpoint.X + (width - base.Width) / 2, locpoint.Y + (height - base.Height) / 3);
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
            pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBox1.Image = WIZ.Forms.Properties.Resources.Loading;
            pictureBox1.Location = new System.Drawing.Point(0, 0);
            pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            pictureBox1.Name = "pictureBox1";
            //pictureBox1.Size = new System.Drawing.Size(200, 200);
            pictureBox1.Size = new System.Drawing.Size(200, 150);
            //pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.White;
            //base.ClientSize = new System.Drawing.Size(200, 200);
            base.ClientSize = new System.Drawing.Size(200, 150);
            base.Controls.Add(pictureBox1);
            DoubleBuffered = true;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.Name = "BaseProgressFormGif";
            base.ShowInTaskbar = false;
            base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "BaseProgressFormGif";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }
    }
}

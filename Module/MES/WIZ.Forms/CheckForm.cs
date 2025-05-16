using Infragistics.Win;
using Infragistics.Win.Misc;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WIZ.Forms
{
    public class CheckForm : Form
    {
        public string result;

        private IContainer components = null;

        public UltraLabel lblMessage;

        private UltraButton btnOK;

        public CheckForm()
        {
            InitializeComponent();
        }

        public CheckForm(string messageid)
        {
            InitializeComponent();
            DoSetColor();
            DBHelper dBHelper = new DBHelper(completedClose: false);
            DataTable dataTable = new DataTable();
            lblMessage.Text = messageid;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DoSetColor()
        {
            try
            {
                string uIStyle = Common.UIStyle;
                if (!(uIStyle == "DarkGray"))
                {
                    if (!(uIStyle == "LightBlue"))
                    {
                        if (uIStyle == "LightGreen")
                        {
                            lblMessage.Appearance.BackColor = Color.FromArgb(242, 255, 181);
                            lblMessage.Appearance.BackColor2 = Color.FromArgb(155, 186, 0);
                            lblMessage.Appearance.BackGradientStyle = GradientStyle.Vertical;
                            lblMessage.Appearance.ForeColor = Color.Black;
                        }
                    }
                    else
                    {
                        lblMessage.Appearance.BackColor = Color.Azure;
                        lblMessage.Appearance.BackColor2 = Color.FromArgb(213, 228, 242);
                        lblMessage.Appearance.BackGradientStyle = GradientStyle.Vertical;
                        lblMessage.Appearance.ForeColor = Color.Black;
                    }
                }
            }
            catch
            {
            }
        }

        private void CheckForm_Load(object sender, EventArgs e)
        {
            lblMessage.Appearance.FontData.Name = Common.FontName;
            btnOK.Appearance.FontData.Name = Common.FontName;
            Font = new Font(Common.FontName, 9f, FontStyle.Regular, GraphicsUnit.Point, 129);
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WIZ.Forms.CheckForm));
            lblMessage = new Infragistics.Win.Misc.UltraLabel();
            btnOK = new Infragistics.Win.Misc.UltraButton();
            SuspendLayout();
            appearance.BackColor = System.Drawing.Color.FromArgb(117, 117, 117);
            appearance.BackColor2 = System.Drawing.Color.FromArgb(79, 79, 79);
            appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance.FontData.Name = "맑은 고딕";
            appearance.FontData.SizeInPoints = 12f;
            appearance.ForeColor = System.Drawing.Color.Yellow;
            appearance.TextVAlignAsString = "Middle";
            lblMessage.Appearance = appearance;
            lblMessage.Dock = System.Windows.Forms.DockStyle.Top;
            lblMessage.Font = new System.Drawing.Font("맑은 고딕", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            lblMessage.Location = new System.Drawing.Point(0, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Padding = new System.Drawing.Size(10, 10);
            lblMessage.Size = new System.Drawing.Size(442, 112);
            lblMessage.TabIndex = 0;
            lblMessage.UseAppStyling = false;
            lblMessage.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            appearance2.FontData.BoldAsString = "True";
            appearance2.FontData.Name = "맑은 고딕";
            appearance2.FontData.SizeInPoints = 12f;
            btnOK.Appearance = appearance2;
            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOK.Font = new System.Drawing.Font("맑은 고딕", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            btnOK.Location = new System.Drawing.Point(320, 118);
            btnOK.Name = "btnOK";
            btnOK.ShowFocusRect = false;
            btnOK.Size = new System.Drawing.Size(119, 58);
            btnOK.TabIndex = 2;
            btnOK.Text = "확 인";
            btnOK.Click += new System.EventHandler(btnOK_Click);
            base.AcceptButton = btnOK;
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            base.ClientSize = new System.Drawing.Size(442, 178);
            base.Controls.Add(btnOK);
            base.Controls.Add(lblMessage);
            Font = new System.Drawing.Font("Yu Gothic UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            ForeColor = System.Drawing.Color.White;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.Name = "CheckForm";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "알 림";
            base.Load += new System.EventHandler(CheckForm_Load);
            ResumeLayout(false);
        }
    }
}

using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WIZ.Forms
{
    public class MessageForm : Form
    {
        private IContainer components = null;

        public UltraLabel lblMessage;

        private UltraGroupBox ultraGroupBox1;

        private UltraButton btnConfirm;

        private UltraCheckEditor cheSystem;

        public UltraTextEditor txtSysMessage;

        public MessageForm()
        {
            InitializeComponent();
        }

        public MessageForm(string text)
        {
            InitializeComponent();
            lblMessage.Text = text;
        }

        public MessageForm(SException ex)
        {
            InitializeComponent();
            lblMessage.Text = Common.getLangText("오류가 발생했습니다. 시스템메세지를 확인하세요.", "MSG");
        }

        public MessageForm(Exception ex)
        {
            InitializeComponent();
            DoSetColor();
            lblMessage.Text = Common.getLangText("오류가 발생했습니다. 시스템메세지를 확인하세요.", "MSG");
            txtSysMessage.Text = ex.ToString();
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

        private void cheSystem_CheckedChanged(object sender, EventArgs e)
        {
            if (cheSystem.Checked)
            {
                base.Height = 600;
            }
            else
            {
                base.Height = 200;
            }
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            lblMessage.Appearance.FontData.Name = Common.FontName;
            btnConfirm.Appearance.FontData.Name = Common.FontName;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WIZ.Forms.MessageForm));
            lblMessage = new Infragistics.Win.Misc.UltraLabel();
            ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            txtSysMessage = new WIZ.Control.STextBox();
            btnConfirm = new Infragistics.Win.Misc.UltraButton();
            cheSystem = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            ((System.ComponentModel.ISupportInitialize)ultraGroupBox1).BeginInit();
            ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtSysMessage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cheSystem).BeginInit();
            SuspendLayout();
            appearance.BackColor = System.Drawing.Color.FromArgb(117, 117, 117);
            appearance.BackColor2 = System.Drawing.Color.FromArgb(79, 79, 79);
            appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance.FontData.BoldAsString = "True";
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
            ultraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            ultraGroupBox1.Controls.Add(txtSysMessage);
            ultraGroupBox1.Location = new System.Drawing.Point(0, 178);
            ultraGroupBox1.Name = "ultraGroupBox1";
            ultraGroupBox1.Size = new System.Drawing.Size(442, 393);
            ultraGroupBox1.TabIndex = 1;
            ultraGroupBox1.Text = "SYSTEM MESSAGE";
            txtSysMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            txtSysMessage.Location = new System.Drawing.Point(2, 16);
            txtSysMessage.Multiline = true;
            txtSysMessage.Name = "txtSysMessage";
            txtSysMessage.ReadOnly = true;
            txtSysMessage.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            txtSysMessage.Size = new System.Drawing.Size(438, 375);
            txtSysMessage.TabIndex = 0;
            appearance2.FontData.BoldAsString = "True";
            appearance2.FontData.SizeInPoints = 12f;
            btnConfirm.Appearance = appearance2;
            btnConfirm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnConfirm.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            btnConfirm.Location = new System.Drawing.Point(326, 115);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.ShowFocusRect = false;
            btnConfirm.Size = new System.Drawing.Size(114, 54);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "확 인";
            cheSystem.Location = new System.Drawing.Point(1, 155);
            cheSystem.Name = "cheSystem";
            cheSystem.Size = new System.Drawing.Size(15, 14);
            cheSystem.TabIndex = 3;
            cheSystem.CheckedChanged += new System.EventHandler(cheSystem_CheckedChanged);
            base.AcceptButton = btnConfirm;
            base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.CancelButton = btnConfirm;
            base.ClientSize = new System.Drawing.Size(442, 171);
            base.Controls.Add(cheSystem);
            base.Controls.Add(btnConfirm);
            base.Controls.Add(ultraGroupBox1);
            base.Controls.Add(lblMessage);
            ForeColor = System.Drawing.Color.White;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.Name = "MessageForm";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "MessageForm";
            base.Load += new System.EventHandler(MessageForm_Load);
            ((System.ComponentModel.ISupportInitialize)ultraGroupBox1).EndInit();
            ultraGroupBox1.ResumeLayout(false);
            ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtSysMessage).EndInit();
            ((System.ComponentModel.ISupportInitialize)cheSystem).EndInit();
            ResumeLayout(false);
        }
    }
}

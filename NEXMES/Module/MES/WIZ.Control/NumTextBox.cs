using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WIZ.Control
{
    public class NumTextBox : UltraTextEditor
    {
        private string cformat = "N0";

        private IContainer components = null;

        public string Format
        {
            get
            {
                return cformat;
            }
            set
            {
                cformat = value;
            }
        }

        public new string Text
        {
            get
            {
                return base.Text.Replace(",", "");
            }
            set
            {
                try
                {
                    base.Text = string.Format("{0:" + cformat + "}", Convert.ToDouble(value.Replace(",", "")));
                }
                catch
                {
                }
            }
        }

        public NumTextBox()
        {
            InitializeComponent();
            base.Appearance.TextHAlign = HAlign.Right;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if ((e.KeyValue == 8 || e.KeyValue == 45 || e.KeyValue == 46 || (e.KeyValue >= 48 && e.KeyValue <= 57) || (e.KeyValue >= 96 && e.KeyValue <= 105)) && cformat != "")
            {
                try
                {
                    int selectionStart = base.SelectionStart;
                    int length = base.Text.Length;
                    int num = base.Text.IndexOf(".");
                    Text = string.Format("{0:" + cformat + "}", Convert.ToDouble(base.Text.Replace(",", "")));
                    int num2 = base.Text.IndexOf(".");
                    if (num != num2)
                    {
                        base.SelectionStart = num2;
                    }
                    else if (num2 != -1 && selectionStart > num2)
                    {
                        base.SelectionStart = selectionStart;
                    }
                    else
                    {
                        base.SelectionStart = selectionStart + (base.Text.Length - length);
                    }
                }
                catch
                {
                }
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && e.KeyChar != '-' && e.KeyChar != '.' && (e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar < '`' || e.KeyChar > 'i'))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '-' && (Text.IndexOf(".") != -1 || base.SelectionStart != 0))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.' && Text.IndexOf(".") != -1)
            {
                e.Handled = true;
            }
            else
            {
                base.OnKeyPress(e);
            }
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
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            base.Size = new System.Drawing.Size(100, 26);
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }
    }
}

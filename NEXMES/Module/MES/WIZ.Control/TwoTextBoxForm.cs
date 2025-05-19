using Infragistics.Win.Misc;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WIZ.Control
{
    public class TwoTextBoxForm : Form
    {
        public enum DialogType
        {
            YESNO,
            OK,
            YESNOCANCEL
        }

        public string result;

        private IContainer components = null;

        private Label lblNoticeBG;

        private UltraButton BtnYes;

        private UltraButton btnOK;

        private UltraButton BtnNo;

        private UltraButton BtnCancel2;

        private UltraButton btnCancel;

        private UltraButton btnConfirm;
        public Control.STextBox txtBox1;
        public Control.STextBox txtBox2;
        public Control.SLabel lblTitle1;
        public Control.SLabel lblTitle2;
        public UltraLabel lblNotice;

        public TwoTextBoxForm()
        {
            InitializeComponent();
        }

        public TwoTextBoxForm(string labelTitle, DialogType type = DialogType.YESNO)
        {
            InitializeComponent();
            DoSetColor();
            DBHelper dBHelper = new DBHelper(completedClose: false);
            string empty = string.Empty;
            lblNotice.Text = labelTitle;
            try
            {
                string sTag = "YESNO";
                switch (type)
                {
                    case DialogType.OK:
                        sTag = "OK";
                        break;
                    case DialogType.YESNO:
                        sTag = "YESNO";
                        break;
                    case DialogType.YESNOCANCEL:
                        sTag = "YESNOCANCEL";
                        break;
                }
                InitControl(this, sTag);
            }
            catch (Exception)
            {
            }
        }

        private void InitControl(System.Windows.Forms.Control con, string sTag)
        {
            if (con != null)
            {
                foreach (System.Windows.Forms.Control control in con.Controls)
                {
                    InitControl(control, sTag);
                    if (control.GetType().Name == "UltraButton")
                    {
                        UltraButton ultraButton = (UltraButton)control;
                        ultraButton.Visible = (ultraButton.Tag.ToString() == sTag);
                    }
                }
            }
        }

        private void DoSetColor()
        {
            try
            {
            }
            catch
            {
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            result = "OK";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            result = "OK";
        }

        private void TwoTextBoxForm_Load(object sender, EventArgs e)
        {
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TwoTextBoxForm));
            this.lblNoticeBG = new System.Windows.Forms.Label();
            this.BtnYes = new Infragistics.Win.Misc.UltraButton();
            this.btnOK = new Infragistics.Win.Misc.UltraButton();
            this.BtnNo = new Infragistics.Win.Misc.UltraButton();
            this.BtnCancel2 = new Infragistics.Win.Misc.UltraButton();
            this.btnCancel = new Infragistics.Win.Misc.UltraButton();
            this.btnConfirm = new Infragistics.Win.Misc.UltraButton();
            this.lblNotice = new Infragistics.Win.Misc.UltraLabel();
            this.lblTitle2 = new WIZ.Control.SLabel();
            this.lblTitle1 = new WIZ.Control.SLabel();
            this.txtBox2 = new WIZ.Control.STextBox(this.components);
            this.txtBox1 = new WIZ.Control.STextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNoticeBG
            // 
            this.lblNoticeBG.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNoticeBG.Font = new System.Drawing.Font("맑은 고딕", 20F);
            this.lblNoticeBG.Location = new System.Drawing.Point(0, 0);
            this.lblNoticeBG.Name = "lblNoticeBG";
            this.lblNoticeBG.Size = new System.Drawing.Size(600, 50);
            this.lblNoticeBG.TabIndex = 11;
            this.lblNoticeBG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnYes
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.FontData.BoldAsString = "True";
            appearance2.FontData.Name = "맑은 고딕";
            appearance2.FontData.SizeInPoints = 15F;
            appearance2.ForeColor = System.Drawing.Color.DimGray;
            this.BtnYes.Appearance = appearance2;
            this.BtnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.BtnYes.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.BtnYes.Location = new System.Drawing.Point(351, 256);
            this.BtnYes.Margin = new System.Windows.Forms.Padding(0);
            this.BtnYes.Name = "BtnYes";
            this.BtnYes.ShowFocusRect = false;
            this.BtnYes.Size = new System.Drawing.Size(120, 60);
            this.BtnYes.TabIndex = 11;
            this.BtnYes.Tag = "YESNOCANCEL";
            this.BtnYes.Text = "예";
            // 
            // btnOK
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.FontData.BoldAsString = "True";
            appearance3.FontData.Name = "맑은 고딕";
            appearance3.FontData.SizeInPoints = 15F;
            appearance3.ForeColor = System.Drawing.Color.DimGray;
            this.btnOK.Appearance = appearance3;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.btnOK.Location = new System.Drawing.Point(351, 256);
            this.btnOK.Margin = new System.Windows.Forms.Padding(0);
            this.btnOK.Name = "btnOK";
            this.btnOK.ShowFocusRect = false;
            this.btnOK.Size = new System.Drawing.Size(120, 60);
            this.btnOK.TabIndex = 8;
            this.btnOK.Tag = "YESNO";
            this.btnOK.Text = "예";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // BtnNo
            // 
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.FontData.BoldAsString = "True";
            appearance4.FontData.Name = "맑은 고딕";
            appearance4.FontData.SizeInPoints = 15F;
            appearance4.ForeColor = System.Drawing.Color.DimGray;
            this.BtnNo.Appearance = appearance4;
            this.BtnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.BtnNo.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.BtnNo.Location = new System.Drawing.Point(475, 256);
            this.BtnNo.Margin = new System.Windows.Forms.Padding(0);
            this.BtnNo.Name = "BtnNo";
            this.BtnNo.ShowFocusRect = false;
            this.BtnNo.Size = new System.Drawing.Size(120, 60);
            this.BtnNo.TabIndex = 12;
            this.BtnNo.Tag = "YESNOCANCEL";
            this.BtnNo.Text = "아니오";
            // 
            // BtnCancel2
            // 
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.FontData.BoldAsString = "True";
            appearance5.FontData.Name = "맑은 고딕";
            appearance5.FontData.SizeInPoints = 15F;
            appearance5.ForeColor = System.Drawing.Color.DimGray;
            this.BtnCancel2.Appearance = appearance5;
            this.BtnCancel2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel2.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.BtnCancel2.Location = new System.Drawing.Point(475, 256);
            this.BtnCancel2.Margin = new System.Windows.Forms.Padding(0);
            this.BtnCancel2.Name = "BtnCancel2";
            this.BtnCancel2.ShowFocusRect = false;
            this.BtnCancel2.Size = new System.Drawing.Size(120, 60);
            this.BtnCancel2.TabIndex = 13;
            this.BtnCancel2.Tag = "YESNOCANCEL";
            this.BtnCancel2.Text = "취소";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.BackColor = System.Drawing.Color.White;
            appearance6.FontData.BoldAsString = "True";
            appearance6.FontData.Name = "맑은 고딕";
            appearance6.FontData.SizeInPoints = 15F;
            appearance6.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancel.Appearance = appearance6;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(475, 178);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShowFocusRect = false;
            this.btnCancel.Size = new System.Drawing.Size(120, 60);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Tag = "YESNO";
            this.btnCancel.Text = "아니요";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance7.BackColor = System.Drawing.Color.White;
            appearance7.FontData.BoldAsString = "True";
            appearance7.FontData.Name = "맑은 고딕";
            appearance7.FontData.SizeInPoints = 15F;
            appearance7.ForeColor = System.Drawing.Color.DimGray;
            this.btnConfirm.Appearance = appearance7;
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirm.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.Location = new System.Drawing.Point(351, 178);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.ShowFocusRect = false;
            this.btnConfirm.Size = new System.Drawing.Size(120, 60);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Tag = "YESNO";
            this.btnConfirm.Text = "변경";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblNotice
            // 
            appearance8.FontData.BoldAsString = "True";
            appearance8.FontData.Name = "맑은 고딕";
            appearance8.FontData.SizeInPoints = 18F;
            appearance8.ForeColor = System.Drawing.Color.White;
            appearance8.TextVAlignAsString = "Middle";
            this.lblNotice.Appearance = appearance8;
            this.lblNotice.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblNotice.Location = new System.Drawing.Point(44, 0);
            this.lblNotice.Margin = new System.Windows.Forms.Padding(0);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Padding = new System.Drawing.Size(10, 10);
            this.lblNotice.Size = new System.Drawing.Size(547, 50);
            this.lblNotice.TabIndex = 15;
            this.lblNotice.Text = "알람";
            this.lblNotice.UseAppStyling = false;
            this.lblNotice.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // lblTitle2
            // 
            appearance1.FontData.BoldAsString = "True";
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.lblTitle2.Appearance = appearance1;
            this.lblTitle2.DbField = null;
            this.lblTitle2.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle2.Location = new System.Drawing.Point(12, 132);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.Default;
            this.lblTitle2.Size = new System.Drawing.Size(102, 21);
            this.lblTitle2.TabIndex = 19;
            this.lblTitle2.Text = "이름1";
            // 
            // lblTitle1
            // 
            appearance9.FontData.BoldAsString = "True";
            appearance9.FontData.UnderlineAsString = "False";
            appearance9.ForeColor = System.Drawing.Color.White;
            appearance9.TextHAlignAsString = "Right";
            appearance9.TextVAlignAsString = "Middle";
            this.lblTitle1.Appearance = appearance9;
            this.lblTitle1.DbField = null;
            this.lblTitle1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle1.Location = new System.Drawing.Point(12, 69);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.Default;
            this.lblTitle1.Size = new System.Drawing.Size(102, 21);
            this.lblTitle1.TabIndex = 18;
            this.lblTitle1.Text = "이름1";
            // 
            // txtBox2
            // 
            appearance11.FontData.BoldAsString = "False";
            appearance11.FontData.UnderlineAsString = "False";
            appearance11.ForeColor = System.Drawing.Color.Black;
            this.txtBox2.Appearance = appearance11;
            this.txtBox2.Font = new System.Drawing.Font("굴림", 12F);
            this.txtBox2.Location = new System.Drawing.Point(149, 128);
            this.txtBox2.Name = "txtBox2";
            this.txtBox2.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtBox2.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtBox2.Size = new System.Drawing.Size(387, 25);
            this.txtBox2.TabIndex = 17;
            // 
            // txtBox1
            // 
            appearance10.FontData.BoldAsString = "False";
            appearance10.FontData.UnderlineAsString = "False";
            appearance10.ForeColor = System.Drawing.Color.Black;
            this.txtBox1.Appearance = appearance10;
            this.txtBox1.Font = new System.Drawing.Font("굴림", 12F);
            this.txtBox1.Location = new System.Drawing.Point(149, 69);
            this.txtBox1.Name = "txtBox1";
            this.txtBox1.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtBox1.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtBox1.Size = new System.Drawing.Size(387, 25);
            this.txtBox1.TabIndex = 16;
            // 
            // TwoTextBoxForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(600, 242);
            this.Controls.Add(this.lblTitle2);
            this.Controls.Add(this.lblTitle1);
            this.Controls.Add(this.txtBox2);
            this.Controls.Add(this.txtBox1);
            this.Controls.Add(this.lblNotice);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.BtnCancel2);
            this.Controls.Add(this.BtnNo);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.BtnYes);
            this.Controls.Add(this.lblNoticeBG);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TwoTextBoxForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "알 림";
            this.Load += new System.EventHandler(this.TwoTextBoxForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

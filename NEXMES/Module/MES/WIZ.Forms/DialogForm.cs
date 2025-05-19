using Infragistics.Win;
using Infragistics.Win.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WIZ.Forms
{
    public class DialogForm : Form
    {
        public enum DialogType
        {
            /// <summary>
            /// 버튼 두개 처리 - 1) result : "OK" , DialogResult.OK, 2) result : "NO", DialogResult.No
            /// </summary>
			YESNO,
            /// <summary>
            /// 버튼 한개 처리 - 1) result : "OK", DialogResult.OK
            /// </summary>
			OK,

            /// <summary>
            /// 버튼 한개 처리 - 1) reult : "YES", DialogResult.Yes, 2) result : "NO", DialogResult.No, 3) result : "CANCEL", DialogResult.Cancel
            /// </summary>
			YESNOCANCEL
        }

        public string result;

        public FormInfor FormInformation;

        private IContainer components = null;

        private Label lblNoticeBG;

        public UltraLabel lblMessage;

        private UltraButton btnTwo;

        private UltraButton btnThree;

        private UltraButton btnOne;

        public UltraLabel lblNotice;

        public DialogForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageid">표시할 텍스트</param>
        /// <param name="type">버튼 종류, DialogType 참고</param>
        /// <param name="sButtonText">표시할 버튼 텍스트</param>
		public DialogForm(string messageid, DialogType type = DialogType.YESNO, string[] sButtonText = null)
        {
            InitializeComponent();
            DoSetColor();
            DBHelper dBHelper = new DBHelper(completedClose: false);
            string empty = string.Empty;
            try
            {
                lblMessage.Text = messageid;
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
                InitControl(sTag, sButtonText);
                FormInformation = new FormInfor(LoginInfo.UserID, base.Name, Common.Lang);
                FormInformation.ManageForm(this);
            }
            catch (Exception)
            {
                lblMessage.Text = ((empty == "") ? ("(" + messageid + ") 를 등록하세요.") : empty);
            }
        }

        private void InitControl(string sTag, string[] sButtonText)
        {
            btnOne.Visible = false;
            btnTwo.Visible = false;
            btnThree.Visible = false;

            List<string> listText = new List<string>();

            if (sButtonText != null)
            {
                listText.AddRange(sButtonText);
            }

            switch (sTag)
            {
                case "OK":
                    btnThree.Visible = true;
                    btnThree.Tag = "OK";

                    btnThree.DialogResult = DialogResult.OK;

                    if (listText.Count >= 1) { btnThree.Text = listText[0]; } else { btnThree.Text = "OK"; }
                    break;
                case "YESNO":
                    btnTwo.Visible = true;
                    btnThree.Visible = true;

                    btnTwo.DialogResult = DialogResult.OK;
                    btnThree.DialogResult = DialogResult.Cancel;

                    btnTwo.Tag = "OK";
                    btnThree.Tag = "NO";

                    if (listText.Count >= 1) { btnTwo.Text = listText[0]; } else { btnTwo.Text = "예"; }
                    if (listText.Count >= 2) { btnThree.Text = listText[1]; } else { btnThree.Text = "아니오"; }
                    break;
                case "YESNOCANCEL":
                    btnOne.Visible = true;
                    btnTwo.Visible = true;
                    btnThree.Visible = true;

                    btnOne.DialogResult = DialogResult.Yes;
                    btnTwo.DialogResult = DialogResult.No;
                    btnThree.DialogResult = DialogResult.Cancel;

                    btnOne.Tag = "YES";
                    btnTwo.Tag = "NO";
                    btnThree.Tag = "CANCEL";

                    if (listText.Count >= 1) { btnOne.Text = listText[0]; } else { btnOne.Text = "예"; }
                    if (listText.Count >= 2) { btnTwo.Text = listText[1]; } else { btnTwo.Text = "아니오"; }
                    if (listText.Count >= 3) { btnThree.Text = listText[2]; } else { btnThree.Text = "취소"; }
                    break;
            }
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

        private void btn_Click(object sender, EventArgs e)
        {
            UltraButton u = sender as UltraButton;

            if (u != null)
            {
                string sTag = CModule.ToString(u.Tag);

                result = sTag;
            }
        }

        private void DialogForm_Load(object sender, EventArgs e)
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
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogForm));
            this.lblNoticeBG = new System.Windows.Forms.Label();
            this.lblMessage = new Infragistics.Win.Misc.UltraLabel();
            this.btnTwo = new Infragistics.Win.Misc.UltraButton();
            this.btnThree = new Infragistics.Win.Misc.UltraButton();
            this.btnOne = new Infragistics.Win.Misc.UltraButton();
            this.lblNotice = new Infragistics.Win.Misc.UltraLabel();
            this.SuspendLayout();
            // 
            // lblNoticeBG
            // 
            this.lblNoticeBG.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNoticeBG.Font = new System.Drawing.Font("맑은 고딕", 20F);
            this.lblNoticeBG.Image = global::WIZ.Forms.Properties.Resources.Notice_T;
            this.lblNoticeBG.Location = new System.Drawing.Point(0, 0);
            this.lblNoticeBG.Name = "lblNoticeBG";
            this.lblNoticeBG.Size = new System.Drawing.Size(600, 50);
            this.lblNoticeBG.TabIndex = 11;
            this.lblNoticeBG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMessage
            // 
            appearance.BackColor = System.Drawing.Color.White;
            appearance.FontData.BoldAsString = "False";
            appearance.FontData.Name = "맑은 고딕";
            appearance.FontData.SizeInPoints = 15F;
            appearance.ForeColor = System.Drawing.Color.DimGray;
            appearance.TextVAlignAsString = "Middle";
            this.lblMessage.Appearance = appearance;
            this.lblMessage.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.lblMessage.Location = new System.Drawing.Point(5, 50);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(590, 199);
            this.lblMessage.TabIndex = 14;
            this.lblMessage.UseAppStyling = false;
            this.lblMessage.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // btnTwo
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.FontData.BoldAsString = "True";
            appearance2.FontData.Name = "맑은 고딕";
            appearance2.FontData.SizeInPoints = 15F;
            appearance2.ForeColor = System.Drawing.Color.DimGray;
            this.btnTwo.Appearance = appearance2;
            this.btnTwo.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnTwo.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.btnTwo.Location = new System.Drawing.Point(355, 256);
            this.btnTwo.Margin = new System.Windows.Forms.Padding(0);
            this.btnTwo.Name = "btnTwo";
            this.btnTwo.ShowFocusRect = false;
            this.btnTwo.Size = new System.Drawing.Size(120, 60);
            this.btnTwo.TabIndex = 11;
            this.btnTwo.Tag = "YESNOCANCEL";
            this.btnTwo.Text = "2";
            this.btnTwo.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnThree
            // 
            appearance6.BackColor = System.Drawing.Color.White;
            appearance6.FontData.BoldAsString = "True";
            appearance6.FontData.Name = "맑은 고딕";
            appearance6.FontData.SizeInPoints = 15F;
            appearance6.ForeColor = System.Drawing.Color.DimGray;
            this.btnThree.Appearance = appearance6;
            this.btnThree.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThree.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.btnThree.Location = new System.Drawing.Point(475, 256);
            this.btnThree.Margin = new System.Windows.Forms.Padding(0);
            this.btnThree.Name = "btnThree";
            this.btnThree.ShowFocusRect = false;
            this.btnThree.Size = new System.Drawing.Size(120, 60);
            this.btnThree.TabIndex = 9;
            this.btnThree.Tag = "YESNO";
            this.btnThree.Text = "3";
            this.btnThree.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnOne
            // 
            appearance7.BackColor = System.Drawing.Color.White;
            appearance7.FontData.BoldAsString = "True";
            appearance7.FontData.Name = "맑은 고딕";
            appearance7.FontData.SizeInPoints = 15F;
            appearance7.ForeColor = System.Drawing.Color.DimGray;
            this.btnOne.Appearance = appearance7;
            this.btnOne.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOne.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.btnOne.Location = new System.Drawing.Point(235, 256);
            this.btnOne.Margin = new System.Windows.Forms.Padding(0);
            this.btnOne.Name = "btnOne";
            this.btnOne.ShowFocusRect = false;
            this.btnOne.Size = new System.Drawing.Size(120, 60);
            this.btnOne.TabIndex = 10;
            this.btnOne.Tag = "OK";
            this.btnOne.Text = "1";
            this.btnOne.Click += new System.EventHandler(this.btn_Click);
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
            // DialogForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(174)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(600, 320);
            this.Controls.Add(this.lblNotice);
            this.Controls.Add(this.btnOne);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnThree);
            this.Controls.Add(this.btnTwo);
            this.Controls.Add(this.lblNoticeBG);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DialogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "알 림";
            this.Load += new System.EventHandler(this.DialogForm_Load);
            this.ResumeLayout(false);

        }
    }
}

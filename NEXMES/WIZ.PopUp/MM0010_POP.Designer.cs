namespace WIZ.PopUp
{
    partial class MM0010_POP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MM0010_POP));
            this.btn_CLOSE_H = new Infragistics.Win.Misc.UltraButton();
            this.txt_REMARK_H = new WIZ.Control.STextBox();
            this.lbl_REMARK_H = new Infragistics.Win.Misc.UltraLabel();
            this.btn_SAVE_H = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_REMARK_H)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_CLOSE_H
            // 
            this.btn_CLOSE_H.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_CLOSE_H.Location = new System.Drawing.Point(818, 17);
            this.btn_CLOSE_H.Margin = new System.Windows.Forms.Padding(0);
            this.btn_CLOSE_H.Name = "btn_CLOSE_H";
            this.btn_CLOSE_H.Size = new System.Drawing.Size(91, 48);
            this.btn_CLOSE_H.TabIndex = 693;
            this.btn_CLOSE_H.Text = "닫기";
            this.btn_CLOSE_H.Click += new System.EventHandler(this.btn_CLOSE_H_Click);
            // 
            // txt_REMARK_H
            // 
            this.txt_REMARK_H.AutoSize = false;
            this.txt_REMARK_H.Location = new System.Drawing.Point(23, 37);
            this.txt_REMARK_H.Name = "txt_REMARK_H";
            this.txt_REMARK_H.Size = new System.Drawing.Size(681, 27);
            this.txt_REMARK_H.TabIndex = 679;
            // 
            // lbl_REMARK_H
            // 
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.lbl_REMARK_H.Appearance = appearance1;
            this.lbl_REMARK_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_REMARK_H.Location = new System.Drawing.Point(23, 13);
            this.lbl_REMARK_H.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbl_REMARK_H.Name = "lbl_REMARK_H";
            this.lbl_REMARK_H.Size = new System.Drawing.Size(144, 26);
            this.lbl_REMARK_H.TabIndex = 700;
            this.lbl_REMARK_H.Text = "재발행 사유";
            // 
            // btn_SAVE_H
            // 
            this.btn_SAVE_H.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_SAVE_H.Location = new System.Drawing.Point(715, 17);
            this.btn_SAVE_H.Margin = new System.Windows.Forms.Padding(0);
            this.btn_SAVE_H.Name = "btn_SAVE_H";
            this.btn_SAVE_H.Size = new System.Drawing.Size(91, 48);
            this.btn_SAVE_H.TabIndex = 701;
            this.btn_SAVE_H.Text = "저장";
            this.btn_SAVE_H.Click += new System.EventHandler(this.btn_SAVE_H_Click);
            // 
            // MM0010_POP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 80);
            this.Controls.Add(this.btn_SAVE_H);
            this.Controls.Add(this.btn_CLOSE_H);
            this.Controls.Add(this.txt_REMARK_H);
            this.Controls.Add(this.lbl_REMARK_H);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MM0010_POP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "식별표 재발행 사유 입력 POP-UP";
            ((System.ComponentModel.ISupportInitialize)(this.txt_REMARK_H)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private WIZ.Control.STextBox txt_REMARK_H;
        private Infragistics.Win.Misc.UltraButton btn_CLOSE_H;
        private Infragistics.Win.Misc.UltraLabel lbl_REMARK_H;
        private Infragistics.Win.Misc.UltraButton btn_SAVE_H;
    }
}
namespace WIZ.PopUp
{
    partial class WM0000_POP
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WM0000_POP));
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.txt_LOTCNT = new WIZ.Control.STextBox();
            this.lbl_LOTCNT = new Infragistics.Win.Misc.UltraLabel();
            this.txt_TOTQTY = new WIZ.Control.STextBox();
            this.lbl_TOTCNT = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.rb_ZBPRINT_B = new System.Windows.Forms.RadioButton();
            this.rb_NMPRINT_B = new System.Windows.Forms.RadioButton();
            this.txt_BOXQTY = new WIZ.Control.STextBox();
            this.lbl_BOXQTY = new Infragistics.Win.Misc.UltraLabel();
            this.txt_ITEMNAME = new WIZ.Control.STextBox();
            this.txt_ITEMCODE = new WIZ.Control.STextBox();
            this.lbl_ITEMCODE = new Infragistics.Win.Misc.UltraLabel();
            this.ultraPanel2 = new Infragistics.Win.Misc.UltraPanel();
            this.btnPrint = new Infragistics.Win.Misc.UltraButton();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.cbo_LOCCODE = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cbo_WHCODE = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lbl_WHCODE = new Infragistics.Win.Misc.UltraLabel();
            this.lbl_LOCCODE = new Infragistics.Win.Misc.UltraLabel();
            this.ultraPanel1.ClientArea.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LOTCNT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TOTQTY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BOXQTY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMNAME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMCODE)).BeginInit();
            this.ultraPanel2.ClientArea.SuspendLayout();
            this.ultraPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_LOCCODE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_WHCODE)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraPanel1
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ultraPanel1.Appearance = appearance1;
            // 
            // ultraPanel1.ClientArea
            // 
            this.ultraPanel1.ClientArea.Controls.Add(this.lbl_LOCCODE);
            this.ultraPanel1.ClientArea.Controls.Add(this.lbl_WHCODE);
            this.ultraPanel1.ClientArea.Controls.Add(this.cbo_LOCCODE);
            this.ultraPanel1.ClientArea.Controls.Add(this.cbo_WHCODE);
            this.ultraPanel1.ClientArea.Controls.Add(this.txt_LOTCNT);
            this.ultraPanel1.ClientArea.Controls.Add(this.lbl_LOTCNT);
            this.ultraPanel1.ClientArea.Controls.Add(this.txt_TOTQTY);
            this.ultraPanel1.ClientArea.Controls.Add(this.lbl_TOTCNT);
            this.ultraPanel1.ClientArea.Controls.Add(this.ultraGroupBox1);
            this.ultraPanel1.ClientArea.Controls.Add(this.txt_BOXQTY);
            this.ultraPanel1.ClientArea.Controls.Add(this.lbl_BOXQTY);
            this.ultraPanel1.ClientArea.Controls.Add(this.txt_ITEMNAME);
            this.ultraPanel1.ClientArea.Controls.Add(this.txt_ITEMCODE);
            this.ultraPanel1.ClientArea.Controls.Add(this.lbl_ITEMCODE);
            this.ultraPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(660, 183);
            this.ultraPanel1.TabIndex = 3;
            // 
            // txt_LOTCNT
            // 
            appearance42.BackColor = System.Drawing.SystemColors.Control;
            appearance42.FontData.SizeInPoints = 10F;
            this.txt_LOTCNT.Appearance = appearance42;
            this.txt_LOTCNT.AutoSize = false;
            this.txt_LOTCNT.BackColor = System.Drawing.SystemColors.Control;
            this.txt_LOTCNT.Location = new System.Drawing.Point(155, 91);
            this.txt_LOTCNT.Name = "txt_LOTCNT";
            this.txt_LOTCNT.ReadOnly = true;
            this.txt_LOTCNT.Size = new System.Drawing.Size(110, 25);
            this.txt_LOTCNT.TabIndex = 587;
            this.txt_LOTCNT.UseAppStyling = false;
            // 
            // lbl_LOTCNT
            // 
            appearance16.FontData.SizeInPoints = 10F;
            appearance16.TextHAlignAsString = "Left";
            appearance16.TextVAlignAsString = "Middle";
            this.lbl_LOTCNT.Appearance = appearance16;
            this.lbl_LOTCNT.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_LOTCNT.Location = new System.Drawing.Point(154, 66);
            this.lbl_LOTCNT.Name = "lbl_LOTCNT";
            this.lbl_LOTCNT.Size = new System.Drawing.Size(112, 25);
            this.lbl_LOTCNT.TabIndex = 586;
            this.lbl_LOTCNT.Text = "LOT 수량";
            // 
            // txt_TOTQTY
            // 
            appearance2.BackColor = System.Drawing.SystemColors.Control;
            appearance2.FontData.SizeInPoints = 10F;
            this.txt_TOTQTY.Appearance = appearance2;
            this.txt_TOTQTY.AutoSize = false;
            this.txt_TOTQTY.BackColor = System.Drawing.SystemColors.Control;
            this.txt_TOTQTY.Location = new System.Drawing.Point(283, 91);
            this.txt_TOTQTY.Name = "txt_TOTQTY";
            this.txt_TOTQTY.ReadOnly = true;
            this.txt_TOTQTY.Size = new System.Drawing.Size(110, 25);
            this.txt_TOTQTY.TabIndex = 585;
            this.txt_TOTQTY.UseAppStyling = false;
            // 
            // lbl_TOTCNT
            // 
            appearance5.FontData.SizeInPoints = 10F;
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Middle";
            this.lbl_TOTCNT.Appearance = appearance5;
            this.lbl_TOTCNT.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_TOTCNT.Location = new System.Drawing.Point(281, 66);
            this.lbl_TOTCNT.Name = "lbl_TOTCNT";
            this.lbl_TOTCNT.Size = new System.Drawing.Size(112, 25);
            this.lbl_TOTCNT.TabIndex = 584;
            this.lbl_TOTCNT.Text = "총 수량";
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.rb_ZBPRINT_B);
            this.ultraGroupBox1.Controls.Add(this.rb_NMPRINT_B);
            this.ultraGroupBox1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ultraGroupBox1.Location = new System.Drawing.Point(409, 61);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(224, 60);
            this.ultraGroupBox1.TabIndex = 583;
            this.ultraGroupBox1.Text = "프린터 유형";
            // 
            // rb_ZBPRINT_B
            // 
            this.rb_ZBPRINT_B.AutoSize = true;
            this.rb_ZBPRINT_B.Checked = true;
            this.rb_ZBPRINT_B.Location = new System.Drawing.Point(125, 30);
            this.rb_ZBPRINT_B.Name = "rb_ZBPRINT_B";
            this.rb_ZBPRINT_B.Size = new System.Drawing.Size(94, 19);
            this.rb_ZBPRINT_B.TabIndex = 579;
            this.rb_ZBPRINT_B.TabStop = true;
            this.rb_ZBPRINT_B.Text = "Zebra Printer";
            this.rb_ZBPRINT_B.UseVisualStyleBackColor = true;
            // 
            // rb_NMPRINT_B
            // 
            this.rb_NMPRINT_B.AutoSize = true;
            this.rb_NMPRINT_B.Location = new System.Drawing.Point(12, 30);
            this.rb_NMPRINT_B.Name = "rb_NMPRINT_B";
            this.rb_NMPRINT_B.Size = new System.Drawing.Size(100, 19);
            this.rb_NMPRINT_B.TabIndex = 580;
            this.rb_NMPRINT_B.Text = "Nomal Printer";
            this.rb_NMPRINT_B.UseVisualStyleBackColor = true;
            // 
            // txt_BOXQTY
            // 
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.FontData.SizeInPoints = 10F;
            this.txt_BOXQTY.Appearance = appearance6;
            this.txt_BOXQTY.AutoSize = false;
            this.txt_BOXQTY.BackColor = System.Drawing.SystemColors.Control;
            this.txt_BOXQTY.Location = new System.Drawing.Point(26, 91);
            this.txt_BOXQTY.Name = "txt_BOXQTY";
            this.txt_BOXQTY.ReadOnly = true;
            this.txt_BOXQTY.Size = new System.Drawing.Size(110, 25);
            this.txt_BOXQTY.TabIndex = 294;
            this.txt_BOXQTY.UseAppStyling = false;
            // 
            // lbl_BOXQTY
            // 
            appearance10.FontData.SizeInPoints = 10F;
            appearance10.TextHAlignAsString = "Left";
            appearance10.TextVAlignAsString = "Middle";
            this.lbl_BOXQTY.Appearance = appearance10;
            this.lbl_BOXQTY.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_BOXQTY.Location = new System.Drawing.Point(24, 66);
            this.lbl_BOXQTY.Name = "lbl_BOXQTY";
            this.lbl_BOXQTY.Size = new System.Drawing.Size(112, 25);
            this.lbl_BOXQTY.TabIndex = 293;
            this.lbl_BOXQTY.Text = "납품 박스당 수량";
            // 
            // txt_ITEMNAME
            // 
            appearance22.BackColor = System.Drawing.SystemColors.Control;
            appearance22.FontData.SizeInPoints = 10F;
            this.txt_ITEMNAME.Appearance = appearance22;
            this.txt_ITEMNAME.AutoSize = false;
            this.txt_ITEMNAME.BackColor = System.Drawing.SystemColors.Control;
            this.txt_ITEMNAME.Location = new System.Drawing.Point(206, 30);
            this.txt_ITEMNAME.Name = "txt_ITEMNAME";
            this.txt_ITEMNAME.ReadOnly = true;
            this.txt_ITEMNAME.Size = new System.Drawing.Size(333, 25);
            this.txt_ITEMNAME.TabIndex = 292;
            this.txt_ITEMNAME.UseAppStyling = false;
            // 
            // txt_ITEMCODE
            // 
            appearance3.BackColor = System.Drawing.SystemColors.Control;
            appearance3.FontData.SizeInPoints = 10F;
            this.txt_ITEMCODE.Appearance = appearance3;
            this.txt_ITEMCODE.AutoSize = false;
            this.txt_ITEMCODE.BackColor = System.Drawing.SystemColors.Control;
            this.txt_ITEMCODE.Location = new System.Drawing.Point(26, 30);
            this.txt_ITEMCODE.Name = "txt_ITEMCODE";
            this.txt_ITEMCODE.ReadOnly = true;
            this.txt_ITEMCODE.Size = new System.Drawing.Size(181, 25);
            this.txt_ITEMCODE.TabIndex = 291;
            this.txt_ITEMCODE.UseAppStyling = false;
            // 
            // lbl_ITEMCODE
            // 
            appearance4.FontData.SizeInPoints = 10F;
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.lbl_ITEMCODE.Appearance = appearance4;
            this.lbl_ITEMCODE.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_ITEMCODE.Location = new System.Drawing.Point(24, 5);
            this.lbl_ITEMCODE.Name = "lbl_ITEMCODE";
            this.lbl_ITEMCODE.Size = new System.Drawing.Size(244, 25);
            this.lbl_ITEMCODE.TabIndex = 290;
            this.lbl_ITEMCODE.Text = "품목";
            // 
            // ultraPanel2
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ultraPanel2.Appearance = appearance8;
            // 
            // ultraPanel2.ClientArea
            // 
            this.ultraPanel2.ClientArea.Controls.Add(this.btnPrint);
            this.ultraPanel2.ClientArea.Controls.Add(this.btnClose);
            this.ultraPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ultraPanel2.Location = new System.Drawing.Point(0, 183);
            this.ultraPanel2.Name = "ultraPanel2";
            this.ultraPanel2.Size = new System.Drawing.Size(660, 67);
            this.ultraPanel2.TabIndex = 4;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrint.Location = new System.Drawing.Point(373, 10);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(137, 49);
            this.btnPrint.TabIndex = 82;
            this.btnPrint.Text = "식별표 발행";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Location = new System.Drawing.Point(516, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(137, 49);
            this.btnClose.TabIndex = 80;
            this.btnClose.Text = "닫기";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbo_LOCCODE
            // 
            this.cbo_LOCCODE.AutoSize = false;
            this.cbo_LOCCODE.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cbo_LOCCODE.Location = new System.Drawing.Point(222, 147);
            this.cbo_LOCCODE.Name = "cbo_LOCCODE";
            this.cbo_LOCCODE.Size = new System.Drawing.Size(171, 28);
            this.cbo_LOCCODE.TabIndex = 590;
            // 
            // cbo_WHCODE
            // 
            this.cbo_WHCODE.AutoSize = false;
            this.cbo_WHCODE.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cbo_WHCODE.Location = new System.Drawing.Point(26, 147);
            this.cbo_WHCODE.Name = "cbo_WHCODE";
            this.cbo_WHCODE.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbo_WHCODE.Size = new System.Drawing.Size(171, 28);
            this.cbo_WHCODE.TabIndex = 589;
            this.cbo_WHCODE.ValueChanged += new System.EventHandler(this.cbo_WHCODE_ValueChanged);
            // 
            // lbl_WHCODE
            // 
            appearance9.FontData.SizeInPoints = 10F;
            appearance9.TextHAlignAsString = "Left";
            appearance9.TextVAlignAsString = "Middle";
            this.lbl_WHCODE.Appearance = appearance9;
            this.lbl_WHCODE.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_WHCODE.Location = new System.Drawing.Point(24, 122);
            this.lbl_WHCODE.Name = "lbl_WHCODE";
            this.lbl_WHCODE.Size = new System.Drawing.Size(112, 25);
            this.lbl_WHCODE.TabIndex = 591;
            this.lbl_WHCODE.Text = "입고 창고";
            // 
            // lbl_LOCCODE
            // 
            appearance7.FontData.SizeInPoints = 10F;
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Middle";
            this.lbl_LOCCODE.Appearance = appearance7;
            this.lbl_LOCCODE.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_LOCCODE.Location = new System.Drawing.Point(222, 122);
            this.lbl_LOCCODE.Name = "lbl_LOCCODE";
            this.lbl_LOCCODE.Size = new System.Drawing.Size(112, 25);
            this.lbl_LOCCODE.TabIndex = 592;
            this.lbl_LOCCODE.Text = "입고 위치";
            // 
            // WM0000_POP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 250);
            this.Controls.Add(this.ultraPanel1);
            this.Controls.Add(this.ultraPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WM0000_POP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "완제품 식별표 발행";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WM0000_POP_FormClosing);
            this.ultraPanel1.ClientArea.ResumeLayout(false);
            this.ultraPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_LOTCNT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_TOTQTY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_BOXQTY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMNAME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ITEMCODE)).EndInit();
            this.ultraPanel2.ClientArea.ResumeLayout(false);
            this.ultraPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbo_LOCCODE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_WHCODE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
        private Infragistics.Win.Misc.UltraPanel ultraPanel2;
        private Infragistics.Win.Misc.UltraButton btnClose;
        private Infragistics.Win.Misc.UltraButton btnPrint;
        private WIZ.Control.STextBox txt_ITEMNAME;
        private WIZ.Control.STextBox txt_ITEMCODE;
        private Infragistics.Win.Misc.UltraLabel lbl_ITEMCODE;
        private Infragistics.Win.Misc.UltraLabel lbl_BOXQTY;
        private WIZ.Control.STextBox txt_BOXQTY;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private System.Windows.Forms.RadioButton rb_ZBPRINT_B;
        private System.Windows.Forms.RadioButton rb_NMPRINT_B;
        private WIZ.Control.STextBox txt_LOTCNT;
        private Infragistics.Win.Misc.UltraLabel lbl_LOTCNT;
        private WIZ.Control.STextBox txt_TOTQTY;
        private Infragistics.Win.Misc.UltraLabel lbl_TOTCNT;
        private System.IO.Ports.SerialPort serialPort1;
        private Infragistics.Win.Misc.UltraLabel lbl_LOCCODE;
        private Infragistics.Win.Misc.UltraLabel lbl_WHCODE;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbo_LOCCODE;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbo_WHCODE;
    }
}
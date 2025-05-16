namespace WIZ.PopUp
{
    partial class POP_MM0300X
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
            Telerik.Reporting.TypeReportSource typeReportSource1 = new Telerik.Reporting.TypeReportSource();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POP_MM0300X));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ReportViewer = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtTraType = new System.Windows.Forms.TextBox();
            this.lblTraType = new WIZ.Control.SLabel();
            this.txtPrintingCount = new System.Windows.Forms.TextBox();
            this.lblPrintingCount = new WIZ.Control.SLabel();
            this.txtTraNo = new System.Windows.Forms.TextBox();
            this.lblTroNa = new WIZ.Control.SLabel();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(877, 686);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ReportViewer);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 80);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(877, 606);
            this.panel4.TabIndex = 1;
            // 
            // ReportViewer
            // 
            this.ReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewer.Location = new System.Drawing.Point(0, 0);
            this.ReportViewer.Name = "ReportViewer";
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("TraNo", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("PrintDate", null));
            typeReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("FaxNo", null));
            typeReportSource1.TypeName = "P4017.MM2300X_R, P4017, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            this.ReportViewer.ReportSource = typeReportSource1;
            this.ReportViewer.Size = new System.Drawing.Size(877, 606);
            this.ReportViewer.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(877, 80);
            this.panel3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.txtTraType);
            this.groupBox1.Controls.Add(this.lblTraType);
            this.groupBox1.Controls.Add(this.txtPrintingCount);
            this.groupBox1.Controls.Add(this.lblPrintingCount);
            this.groupBox1.Controls.Add(this.txtTraNo);
            this.groupBox1.Controls.Add(this.lblTroNa);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(877, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "반출증 출력";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("맑은 고딕", 16F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Location = new System.Drawing.Point(526, 23);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(215, 46);
            this.btnPrint.TabIndex = 560;
            this.btnPrint.TabStop = false;
            this.btnPrint.Text = "반출증 발행";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 16F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(754, 22);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 46);
            this.btnClose.TabIndex = 559;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtTraType
            // 
            this.txtTraType.BackColor = System.Drawing.SystemColors.Control;
            this.txtTraType.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtTraType.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtTraType.Location = new System.Drawing.Point(231, 45);
            this.txtTraType.MaxLength = 2;
            this.txtTraType.Name = "txtTraType";
            this.txtTraType.ReadOnly = true;
            this.txtTraType.Size = new System.Drawing.Size(138, 25);
            this.txtTraType.TabIndex = 553;
            // 
            // lblTraType
            // 
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.SizeInPoints = 9.75F;
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.lblTraType.Appearance = appearance3;
            this.lblTraType.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblTraType.DbField = null;
            this.lblTraType.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTraType.Location = new System.Drawing.Point(231, 20);
            this.lblTraType.Name = "lblTraType";
            this.lblTraType.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblTraType.Size = new System.Drawing.Size(138, 25);
            this.lblTraType.TabIndex = 552;
            this.lblTraType.Text = "반출구분";
            // 
            // txtPrintingCount
            // 
            this.txtPrintingCount.BackColor = System.Drawing.SystemColors.Control;
            this.txtPrintingCount.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtPrintingCount.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPrintingCount.Location = new System.Drawing.Point(407, 45);
            this.txtPrintingCount.MaxLength = 2;
            this.txtPrintingCount.Name = "txtPrintingCount";
            this.txtPrintingCount.ReadOnly = true;
            this.txtPrintingCount.Size = new System.Drawing.Size(48, 25);
            this.txtPrintingCount.TabIndex = 551;
            // 
            // lblPrintingCount
            // 
            appearance4.FontData.BoldAsString = "False";
            appearance4.FontData.SizeInPoints = 9.75F;
            appearance4.FontData.UnderlineAsString = "False";
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.lblPrintingCount.Appearance = appearance4;
            this.lblPrintingCount.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblPrintingCount.DbField = null;
            this.lblPrintingCount.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPrintingCount.Location = new System.Drawing.Point(407, 20);
            this.lblPrintingCount.Name = "lblPrintingCount";
            this.lblPrintingCount.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPrintingCount.Size = new System.Drawing.Size(100, 25);
            this.lblPrintingCount.TabIndex = 550;
            this.lblPrintingCount.Text = "출력 매수";
            // 
            // txtTraNo
            // 
            this.txtTraNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtTraNo.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtTraNo.Location = new System.Drawing.Point(39, 45);
            this.txtTraNo.Name = "txtTraNo";
            this.txtTraNo.ReadOnly = true;
            this.txtTraNo.Size = new System.Drawing.Size(160, 25);
            this.txtTraNo.TabIndex = 549;
            // 
            // lblTroNa
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.SizeInPoints = 9.75F;
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.lblTroNa.Appearance = appearance2;
            this.lblTroNa.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblTroNa.DbField = null;
            this.lblTroNa.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTroNa.Location = new System.Drawing.Point(39, 20);
            this.lblTroNa.Name = "lblTroNa";
            this.lblTroNa.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblTroNa.Size = new System.Drawing.Size(160, 25);
            this.lblTroNa.TabIndex = 548;
            this.lblTroNa.Text = "반출증 번호";
            // 
            // POP_MM0300X
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 686);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "POP_MM0300X";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "반출증 발행";
            this.Load += new System.EventHandler(this.POP_MM0300X_Load);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.ReportViewer.WinForms.ReportViewer ReportViewer;
        private System.Windows.Forms.TextBox txtTraType;
        private Control.SLabel lblTraType;
        private System.Windows.Forms.TextBox txtPrintingCount;
        private Control.SLabel lblPrintingCount;
        private System.Windows.Forms.TextBox txtTraNo;
        private Control.SLabel lblTroNa;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
    }
}
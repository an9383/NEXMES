namespace WIZ.MM
{
    partial class PD2020
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD2020));
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtInputBarCode = new WIZ.Control.STextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtBarCode = new WIZ.Control.STextBox();
            this.txtMakeDate = new WIZ.Control.STextBox();
            this.txtMaker = new WIZ.Control.STextBox();
            this.txtUnitCode = new WIZ.Control.STextBox();
            this.txtQty = new WIZ.Control.STextBox();
            this.txtItemName = new WIZ.Control.STextBox();
            this.txtItemCode = new WIZ.Control.STextBox();
            this.txtCustName = new WIZ.Control.STextBox();
            this.txtPoNo = new WIZ.Control.STextBox();
            this.btnMakedate = new System.Windows.Forms.Button();
            this.btnMaker = new System.Windows.Forms.Button();
            this.btnQty = new System.Windows.Forms.Button();
            this.btnItemCode = new System.Windows.Forms.Button();
            this.btnCustName = new System.Windows.Forms.Button();
            this.btnPoNo = new System.Windows.Forms.Button();
            this.btnBarCode = new System.Windows.Forms.Button();
            this.lblFormName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInputBarCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMakeDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPoNo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Size = new System.Drawing.Size(646, 69);
            this.gbxHeader.Visible = false;
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.lblFormName);
            this.gbxBody.Controls.Add(this.panel1);
            this.gbxBody.Location = new System.Drawing.Point(0, 69);
            this.gbxBody.Size = new System.Drawing.Size(646, 600);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.txtInputBarCode);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.txtBarCode);
            this.panel1.Controls.Add(this.txtMakeDate);
            this.panel1.Controls.Add(this.txtMaker);
            this.panel1.Controls.Add(this.txtUnitCode);
            this.panel1.Controls.Add(this.txtQty);
            this.panel1.Controls.Add(this.txtItemName);
            this.panel1.Controls.Add(this.txtItemCode);
            this.panel1.Controls.Add(this.txtCustName);
            this.panel1.Controls.Add(this.txtPoNo);
            this.panel1.Controls.Add(this.btnMakedate);
            this.panel1.Controls.Add(this.btnMaker);
            this.panel1.Controls.Add(this.btnQty);
            this.panel1.Controls.Add(this.btnItemCode);
            this.panel1.Controls.Add(this.btnCustName);
            this.panel1.Controls.Add(this.btnPoNo);
            this.panel1.Controls.Add(this.btnBarCode);
            this.panel1.Location = new System.Drawing.Point(4, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 541);
            this.panel1.TabIndex = 2;
            // 
            // txtInputBarCode
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(92)))), ((int)(((byte)(118)))));
            appearance14.FontData.BoldAsString = "True";
            appearance14.FontData.SizeInPoints = 12F;
            appearance14.ForeColor = System.Drawing.Color.Gold;
            this.txtInputBarCode.Appearance = appearance14;
            this.txtInputBarCode.AutoSize = false;
            this.txtInputBarCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(92)))), ((int)(((byte)(118)))));
            this.txtInputBarCode.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtInputBarCode.Location = new System.Drawing.Point(128, 42);
            this.txtInputBarCode.Name = "txtInputBarCode";
            this.txtInputBarCode.Size = new System.Drawing.Size(161, 27);
            this.txtInputBarCode.TabIndex = 286;
            this.txtInputBarCode.UseAppStyling = false;
            this.txtInputBarCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarCode_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(128, 346);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(161, 35);
            this.btnSave.TabIndex = 285;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClear.Location = new System.Drawing.Point(37, 346);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 35);
            this.btnClear.TabIndex = 284;
            this.btnClear.Text = "초기화";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtBarCode
            // 
            this.txtBarCode.AutoSize = false;
            this.txtBarCode.Location = new System.Drawing.Point(38, 72);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.ReadOnly = true;
            this.txtBarCode.Size = new System.Drawing.Size(251, 28);
            this.txtBarCode.TabIndex = 94;
            // 
            // txtMakeDate
            // 
            this.txtMakeDate.AutoSize = false;
            this.txtMakeDate.Location = new System.Drawing.Point(128, 281);
            this.txtMakeDate.Name = "txtMakeDate";
            this.txtMakeDate.ReadOnly = true;
            this.txtMakeDate.Size = new System.Drawing.Size(161, 28);
            this.txtMakeDate.TabIndex = 93;
            // 
            // txtMaker
            // 
            this.txtMaker.AutoSize = false;
            this.txtMaker.Location = new System.Drawing.Point(128, 251);
            this.txtMaker.Name = "txtMaker";
            this.txtMaker.ReadOnly = true;
            this.txtMaker.Size = new System.Drawing.Size(161, 28);
            this.txtMaker.TabIndex = 92;
            // 
            // txtUnitCode
            // 
            this.txtUnitCode.AutoSize = false;
            this.txtUnitCode.Location = new System.Drawing.Point(247, 221);
            this.txtUnitCode.Name = "txtUnitCode";
            this.txtUnitCode.ReadOnly = true;
            this.txtUnitCode.Size = new System.Drawing.Size(42, 28);
            this.txtUnitCode.TabIndex = 91;
            // 
            // txtQty
            // 
            this.txtQty.AutoSize = false;
            this.txtQty.Location = new System.Drawing.Point(128, 221);
            this.txtQty.Name = "txtQty";
            this.txtQty.ReadOnly = true;
            this.txtQty.Size = new System.Drawing.Size(117, 28);
            this.txtQty.TabIndex = 90;
            // 
            // txtItemName
            // 
            this.txtItemName.AutoSize = false;
            this.txtItemName.Location = new System.Drawing.Point(38, 192);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(251, 27);
            this.txtItemName.TabIndex = 89;
            // 
            // txtItemCode
            // 
            this.txtItemCode.AutoSize = false;
            this.txtItemCode.Location = new System.Drawing.Point(128, 162);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.ReadOnly = true;
            this.txtItemCode.Size = new System.Drawing.Size(161, 28);
            this.txtItemCode.TabIndex = 88;
            // 
            // txtCustName
            // 
            this.txtCustName.AutoSize = false;
            this.txtCustName.Location = new System.Drawing.Point(128, 132);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.ReadOnly = true;
            this.txtCustName.Size = new System.Drawing.Size(161, 28);
            this.txtCustName.TabIndex = 86;
            // 
            // txtPoNo
            // 
            this.txtPoNo.AutoSize = false;
            this.txtPoNo.Location = new System.Drawing.Point(128, 102);
            this.txtPoNo.Name = "txtPoNo";
            this.txtPoNo.ReadOnly = true;
            this.txtPoNo.Size = new System.Drawing.Size(161, 28);
            this.txtPoNo.TabIndex = 85;
            // 
            // btnMakedate
            // 
            this.btnMakedate.Location = new System.Drawing.Point(37, 280);
            this.btnMakedate.Name = "btnMakedate";
            this.btnMakedate.Size = new System.Drawing.Size(88, 30);
            this.btnMakedate.TabIndex = 65;
            this.btnMakedate.Text = "발행일자";
            // 
            // btnMaker
            // 
            this.btnMaker.Location = new System.Drawing.Point(37, 250);
            this.btnMaker.Name = "btnMaker";
            this.btnMaker.Size = new System.Drawing.Size(88, 30);
            this.btnMaker.TabIndex = 63;
            this.btnMaker.Text = "발행자";
            // 
            // btnQty
            // 
            this.btnQty.Location = new System.Drawing.Point(37, 220);
            this.btnQty.Name = "btnQty";
            this.btnQty.Size = new System.Drawing.Size(88, 30);
            this.btnQty.TabIndex = 60;
            this.btnQty.Text = "수량";
            // 
            // btnItemCode
            // 
            this.btnItemCode.Location = new System.Drawing.Point(37, 161);
            this.btnItemCode.Name = "btnItemCode";
            this.btnItemCode.Size = new System.Drawing.Size(88, 30);
            this.btnItemCode.TabIndex = 57;
            this.btnItemCode.Text = "품목";
            // 
            // btnCustName
            // 
            this.btnCustName.Location = new System.Drawing.Point(37, 131);
            this.btnCustName.Name = "btnCustName";
            this.btnCustName.Size = new System.Drawing.Size(88, 30);
            this.btnCustName.TabIndex = 54;
            this.btnCustName.Text = "거래처";
            // 
            // btnPoNo
            // 
            this.btnPoNo.Location = new System.Drawing.Point(37, 101);
            this.btnPoNo.Name = "btnPoNo";
            this.btnPoNo.Size = new System.Drawing.Size(88, 30);
            this.btnPoNo.TabIndex = 52;
            this.btnPoNo.Text = "발주번호";
            // 
            // btnBarCode
            // 
            this.btnBarCode.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnBarCode.Location = new System.Drawing.Point(37, 41);
            this.btnBarCode.Name = "btnBarCode";
            this.btnBarCode.Size = new System.Drawing.Size(88, 30);
            this.btnBarCode.TabIndex = 47;
            this.btnBarCode.Text = "바코드";
            this.btnBarCode.UseVisualStyleBackColor = false;
            this.btnBarCode.Click += new System.EventHandler(this.btnBarCode_Click);
            // 
            // lblFormName
            // 
            this.lblFormName.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblFormName.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFormName.ForeColor = System.Drawing.Color.White;
            this.lblFormName.Location = new System.Drawing.Point(4, 4);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(328, 17);
            this.lblFormName.TabIndex = 75;
            this.lblFormName.Text = "수입검사 대기취소";
            // 
            // PD2020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 669);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PD2020";
            this.Text = "수입검사 대기취소";
            this.Load += new System.EventHandler(this.PD2020_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtInputBarCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMakeDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPoNo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMakedate;
        private System.Windows.Forms.Button btnMaker;
        private System.Windows.Forms.Button btnQty;
        private System.Windows.Forms.Button btnItemCode;
        private System.Windows.Forms.Button btnCustName;
        private System.Windows.Forms.Button btnPoNo;
        private System.Windows.Forms.Button btnBarCode;
        private WIZ.Control.STextBox txtUnitCode;
        private WIZ.Control.STextBox txtQty;
        private WIZ.Control.STextBox txtItemName;
        private WIZ.Control.STextBox txtItemCode;
        private WIZ.Control.STextBox txtCustName;
        private WIZ.Control.STextBox txtPoNo;
        private WIZ.Control.STextBox txtMakeDate;
        private WIZ.Control.STextBox txtMaker;
        private System.Windows.Forms.Label lblFormName;
        private WIZ.Control.STextBox txtBarCode;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private WIZ.Control.STextBox txtInputBarCode;
    }
}
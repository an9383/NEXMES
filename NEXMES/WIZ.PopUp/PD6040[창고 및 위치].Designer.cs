namespace WIZ.PopUp
{
    partial class PD6040
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD6040));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStorage = new System.Windows.Forms.Button();
            this.lblFormName = new Infragistics.Win.Misc.UltraLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClear = new Infragistics.Win.Misc.UltraButton();
            this.btnSelect = new Infragistics.Win.Misc.UltraButton();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.txtStorageName = new WIZ.Control.STextBox(this.components);
            this.txtStorageCode = new WIZ.Control.STextBox(this.components);
            this.txtStorageBARCODE = new WIZ.Control.STextBox(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStorageName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStorageCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStorageBARCODE)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtStorageName);
            this.panel1.Controls.Add(this.txtStorageCode);
            this.panel1.Controls.Add(this.txtStorageBARCODE);
            this.panel1.Controls.Add(this.btnStorage);
            this.panel1.Controls.Add(this.lblFormName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 163);
            this.panel1.TabIndex = 1;
            // 
            // btnStorage
            // 
            this.btnStorage.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnStorage.Location = new System.Drawing.Point(0, 33);
            this.btnStorage.Name = "btnStorage";
            this.btnStorage.Size = new System.Drawing.Size(66, 30);
            this.btnStorage.TabIndex = 291;
            this.btnStorage.Text = "입고위치";
            this.btnStorage.UseVisualStyleBackColor = false;
            // 
            // lblFormName
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            appearance4.FontData.BoldAsString = "True";
            appearance4.FontData.SizeInPoints = 10F;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextVAlignAsString = "Middle";
            this.lblFormName.Appearance = appearance4;
            this.lblFormName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFormName.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblFormName.Location = new System.Drawing.Point(0, 0);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(242, 27);
            this.lblFormName.TabIndex = 78;
            this.lblFormName.Text = "창고 및 위치 선택";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnSelect);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 163);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(244, 201);
            this.panel2.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            appearance2.BackColor = System.Drawing.Color.SkyBlue;
            this.btnClear.HotTrackAppearance = appearance2;
            this.btnClear.Location = new System.Drawing.Point(7, 141);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(72, 45);
            this.btnClear.TabIndex = 83;
            this.btnClear.Text = "초기화";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSelect.Location = new System.Drawing.Point(87, 141);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(72, 45);
            this.btnSelect.TabIndex = 82;
            this.btnSelect.Text = "선택";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Location = new System.Drawing.Point(167, 141);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 45);
            this.btnClose.TabIndex = 81;
            this.btnClose.Text = "닫기";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtStorageName
            // 
            appearance1.BackColor2 = System.Drawing.Color.White;
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.txtStorageName.Appearance = appearance1;
            this.txtStorageName.AutoSize = false;
            this.txtStorageName.Location = new System.Drawing.Point(63, 62);
            this.txtStorageName.Name = "txtStorageName";
            this.txtStorageName.ReadOnly = true;
            this.txtStorageName.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtStorageName.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtStorageName.Size = new System.Drawing.Size(176, 28);
            this.txtStorageName.TabIndex = 294;
            // 
            // txtStorageCode
            // 
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            this.txtStorageCode.Appearance = appearance3;
            this.txtStorageCode.AutoSize = false;
            this.txtStorageCode.Location = new System.Drawing.Point(1, 62);
            this.txtStorageCode.Name = "txtStorageCode";
            this.txtStorageCode.ReadOnly = true;
            this.txtStorageCode.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtStorageCode.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtStorageCode.Size = new System.Drawing.Size(63, 28);
            this.txtStorageCode.TabIndex = 293;
            // 
            // txtStorageBARCODE
            // 
            appearance14.FontData.BoldAsString = "False";
            appearance14.FontData.SizeInPoints = 12F;
            appearance14.FontData.UnderlineAsString = "False";
            appearance14.ForeColor = System.Drawing.Color.Black;
            this.txtStorageBARCODE.Appearance = appearance14;
            this.txtStorageBARCODE.AutoSize = false;
            this.txtStorageBARCODE.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtStorageBARCODE.Location = new System.Drawing.Point(63, 35);
            this.txtStorageBARCODE.Name = "txtStorageBARCODE";
            this.txtStorageBARCODE.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtStorageBARCODE.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtStorageBARCODE.Size = new System.Drawing.Size(176, 27);
            this.txtStorageBARCODE.TabIndex = 292;
            this.txtStorageBARCODE.Tag = "";
            this.txtStorageBARCODE.UseAppStyling = false;
            this.txtStorageBARCODE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStorageBARCODE_KeyPress);
            // 
            // PD6040
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 364);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PD6040";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "창고 및 위치";
            this.Load += new System.EventHandler(this.PD6040_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtStorageName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStorageCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStorageBARCODE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Infragistics.Win.Misc.UltraLabel lblFormName;
        private System.Windows.Forms.Panel panel2;
        private Infragistics.Win.Misc.UltraButton btnSelect;
        private Infragistics.Win.Misc.UltraButton btnClose;
        private Infragistics.Win.Misc.UltraButton btnClear;
        private Control.STextBox txtStorageName;
        private Control.STextBox txtStorageCode;
        private Control.STextBox txtStorageBARCODE;
        private System.Windows.Forms.Button btnStorage;
    }
}
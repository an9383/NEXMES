namespace WIZ.WM
{
    partial class PD4110
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD4110));
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtInputBarCode = new WIZ.Control.STextBox(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.txtBarCode = new WIZ.Control.STextBox(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBarCode = new System.Windows.Forms.Button();
            this.lblFormName = new System.Windows.Forms.Label();
            this.lblITEM = new System.Windows.Forms.Label();
            this.grid1 = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQ = new System.Windows.Forms.TextBox();
            this.txtW = new System.Windows.Forms.TextBox();
            this.txtSUMQ = new System.Windows.Forms.TextBox();
            this.txtSUMW = new System.Windows.Forms.TextBox();
            this.BtnDot = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInputBarCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarCode)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Size = new System.Drawing.Size(628, 69);
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
            this.gbxBody.Size = new System.Drawing.Size(628, 559);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.BtnDot);
            this.panel1.Controls.Add(this.txtSUMQ);
            this.panel1.Controls.Add(this.txtSUMW);
            this.panel1.Controls.Add(this.txtW);
            this.panel1.Controls.Add(this.txtQ);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.grid1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblITEM);
            this.panel1.Controls.Add(this.txtInputBarCode);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtBarCode);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnBarCode);
            this.panel1.Location = new System.Drawing.Point(4, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 541);
            this.panel1.TabIndex = 3;
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
            this.txtInputBarCode.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtInputBarCode.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtInputBarCode.Size = new System.Drawing.Size(163, 27);
            this.txtInputBarCode.TabIndex = 292;
            this.txtInputBarCode.UseAppStyling = false;
            this.txtInputBarCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarCode_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(131, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 35);
            this.btnSave.TabIndex = 287;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtBarCode
            // 
            this.txtBarCode.AutoSize = false;
            this.txtBarCode.Location = new System.Drawing.Point(38, 72);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.ReadOnly = true;
            this.txtBarCode.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtBarCode.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtBarCode.Size = new System.Drawing.Size(253, 28);
            this.txtBarCode.TabIndex = 275;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClear.Location = new System.Drawing.Point(37, 415);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 35);
            this.btnClear.TabIndex = 67;
            this.btnClear.Text = "초기화";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBarCode
            // 
            this.btnBarCode.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnBarCode.Location = new System.Drawing.Point(37, 41);
            this.btnBarCode.Name = "btnBarCode";
            this.btnBarCode.Size = new System.Drawing.Size(88, 30);
            this.btnBarCode.TabIndex = 87;
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
            this.lblFormName.TabIndex = 106;
            this.lblFormName.Text = "외주 발송";
            // 
            // lblITEM
            // 
            this.lblITEM.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblITEM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblITEM.Location = new System.Drawing.Point(35, 103);
            this.lblITEM.Name = "lblITEM";
            this.lblITEM.Size = new System.Drawing.Size(256, 21);
            this.lblITEM.TabIndex = 294;
            this.lblITEM.Text = "품목 / 품명";
            // 
            // grid1
            // 
            this.grid1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.grid1.CheckBoxes = true;
            this.grid1.FullRowSelect = true;
            this.grid1.HideSelection = false;
            this.grid1.Location = new System.Drawing.Point(37, 127);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(254, 170);
            this.grid1.TabIndex = 345;
            this.grid1.UseCompatibleStateImageBehavior = false;
            this.grid1.View = System.Windows.Forms.View.List;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(178, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 19);
            this.label2.TabIndex = 109;
            this.label2.Text = "중량(KG)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(49, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 19);
            this.label1.TabIndex = 110;
            this.label1.Text = "수량 (EA)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtQ
            // 
            this.txtQ.BackColor = System.Drawing.SystemColors.Window;
            this.txtQ.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.txtQ.Location = new System.Drawing.Point(41, 322);
            this.txtQ.Name = "txtQ";
            this.txtQ.ReadOnly = true;
            this.txtQ.Size = new System.Drawing.Size(95, 23);
            this.txtQ.TabIndex = 344;
            // 
            // txtW
            // 
            this.txtW.BackColor = System.Drawing.SystemColors.Window;
            this.txtW.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.txtW.Location = new System.Drawing.Point(170, 322);
            this.txtW.Name = "txtW";
            this.txtW.ReadOnly = true;
            this.txtW.Size = new System.Drawing.Size(95, 23);
            this.txtW.TabIndex = 346;
            // 
            // txtSUMQ
            // 
            this.txtSUMQ.BackColor = System.Drawing.SystemColors.Window;
            this.txtSUMQ.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.txtSUMQ.Location = new System.Drawing.Point(41, 373);
            this.txtSUMQ.Name = "txtSUMQ";
            this.txtSUMQ.ReadOnly = true;
            this.txtSUMQ.Size = new System.Drawing.Size(94, 23);
            this.txtSUMQ.TabIndex = 344;
            this.txtSUMQ.Visible = false;
            // 
            // txtSUMW
            // 
            this.txtSUMW.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.txtSUMW.Location = new System.Drawing.Point(170, 373);
            this.txtSUMW.Name = "txtSUMW";
            this.txtSUMW.Size = new System.Drawing.Size(95, 23);
            this.txtSUMW.TabIndex = 343;
            this.txtSUMW.Visible = false;
            // 
            // BtnDot
            // 
            this.BtnDot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnDot.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnDot.Location = new System.Drawing.Point(272, 373);
            this.BtnDot.Name = "BtnDot";
            this.BtnDot.Size = new System.Drawing.Size(20, 25);
            this.BtnDot.TabIndex = 350;
            this.BtnDot.Text = ".";
            this.BtnDot.UseVisualStyleBackColor = false;
            this.BtnDot.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Black;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(230, 415);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(61, 35);
            this.btnClose.TabIndex = 351;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // PD4110
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 628);
            this.Name = "PD4110";
            this.Text = "외주 발송";
            this.Load += new System.EventHandler(this.PD4110_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInputBarCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBarCode;
        private System.Windows.Forms.Label lblFormName;
        private WIZ.Control.STextBox txtBarCode;
        private System.Windows.Forms.Button btnSave;
        private WIZ.Control.STextBox txtInputBarCode;
        private System.Windows.Forms.Button BtnDot;
        private System.Windows.Forms.TextBox txtSUMQ;
        private System.Windows.Forms.TextBox txtSUMW;
        private System.Windows.Forms.TextBox txtW;
        private System.Windows.Forms.TextBox txtQ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView grid1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblITEM;
        private System.Windows.Forms.Button btnClose;
    }
}
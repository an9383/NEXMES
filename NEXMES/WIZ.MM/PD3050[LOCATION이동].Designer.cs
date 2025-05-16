namespace WIZ.MM
{
    partial class PD3050
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PD3050));
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            this.lblFormName = new System.Windows.Forms.Label();
            this.lblFormName2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grid2 = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose2 = new System.Windows.Forms.Button();
            this.btnDEL2 = new System.Windows.Forms.Button();
            this.btnPrePage = new System.Windows.Forms.Button();
            this.btnClear2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnDEL1 = new System.Windows.Forms.Button();
            this.grid1 = new System.Windows.Forms.ListView();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.txtInputBarCode = new WIZ.Control.STextBox(this.components);
            this.txtStorageName = new WIZ.Control.STextBox(this.components);
            this.btnStorageLocCode = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtBarCode = new WIZ.Control.STextBox(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBarCode = new System.Windows.Forms.Button();
            this.txtStorageCode = new WIZ.Control.STextBox(this.components);
            this.txtLimit = new WIZ.Control.STextBox(this.components);
            this.lblLimit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInputBarCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStorageName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStorageCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Size = new System.Drawing.Size(1124, 69);
            this.gbxHeader.Visible = false;
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.lblFormName2);
            this.gbxBody.Controls.Add(this.panel2);
            this.gbxBody.Controls.Add(this.lblFormName);
            this.gbxBody.Controls.Add(this.panel1);
            this.gbxBody.Location = new System.Drawing.Point(0, 69);
            this.gbxBody.Size = new System.Drawing.Size(1124, 559);
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
            this.lblFormName.Text = "로케이션 이동";
            // 
            // lblFormName2
            // 
            this.lblFormName2.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblFormName2.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFormName2.ForeColor = System.Drawing.Color.White;
            this.lblFormName2.Location = new System.Drawing.Point(375, 4);
            this.lblFormName2.Name = "lblFormName2";
            this.lblFormName2.Size = new System.Drawing.Size(328, 17);
            this.lblFormName2.TabIndex = 298;
            this.lblFormName2.Text = "로케이션 이동";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.grid2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnClose2);
            this.panel2.Controls.Add(this.btnDEL2);
            this.panel2.Controls.Add(this.btnPrePage);
            this.panel2.Controls.Add(this.btnClear2);
            this.panel2.Location = new System.Drawing.Point(375, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 541);
            this.panel2.TabIndex = 297;
            // 
            // grid2
            // 
            this.grid2.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.grid2.CheckBoxes = true;
            this.grid2.FullRowSelect = true;
            this.grid2.HideSelection = false;
            this.grid2.Location = new System.Drawing.Point(38, 72);
            this.grid2.Name = "grid2";
            this.grid2.Size = new System.Drawing.Size(251, 347);
            this.grid2.TabIndex = 304;
            this.grid2.UseCompatibleStateImageBehavior = false;
            this.grid2.View = System.Windows.Forms.View.List;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DodgerBlue;
            this.label2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(35, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 41);
            this.label2.TabIndex = 299;
            this.label2.Text = "상세 정보";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose2
            // 
            this.btnClose2.BackColor = System.Drawing.Color.Black;
            this.btnClose2.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose2.ForeColor = System.Drawing.Color.White;
            this.btnClose2.Location = new System.Drawing.Point(243, 425);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(50, 35);
            this.btnClose2.TabIndex = 304;
            this.btnClose2.Text = "닫기";
            this.btnClose2.UseVisualStyleBackColor = false;
            // 
            // btnDEL2
            // 
            this.btnDEL2.BackColor = System.Drawing.Color.Crimson;
            this.btnDEL2.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDEL2.ForeColor = System.Drawing.Color.White;
            this.btnDEL2.Location = new System.Drawing.Point(192, 425);
            this.btnDEL2.Name = "btnDEL2";
            this.btnDEL2.Size = new System.Drawing.Size(47, 35);
            this.btnDEL2.TabIndex = 302;
            this.btnDEL2.Text = "삭제";
            this.btnDEL2.UseVisualStyleBackColor = false;
            this.btnDEL2.Click += new System.EventHandler(this.btnDEL2_Click);
            // 
            // btnPrePage
            // 
            this.btnPrePage.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPrePage.Location = new System.Drawing.Point(38, 425);
            this.btnPrePage.Name = "btnPrePage";
            this.btnPrePage.Size = new System.Drawing.Size(58, 35);
            this.btnPrePage.TabIndex = 298;
            this.btnPrePage.Text = "◀";
            this.btnPrePage.UseVisualStyleBackColor = false;
            this.btnPrePage.Click += new System.EventHandler(this.btnPrePage_Click);
            // 
            // btnClear2
            // 
            this.btnClear2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClear2.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClear2.Location = new System.Drawing.Point(99, 425);
            this.btnClear2.Name = "btnClear2";
            this.btnClear2.Size = new System.Drawing.Size(88, 35);
            this.btnClear2.TabIndex = 67;
            this.btnClear2.Text = "초기화";
            this.btnClear2.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lblLimit);
            this.panel1.Controls.Add(this.txtLimit);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.btnDEL1);
            this.panel1.Controls.Add(this.grid1);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.btnNextPage);
            this.panel1.Controls.Add(this.txtInputBarCode);
            this.panel1.Controls.Add(this.txtStorageName);
            this.panel1.Controls.Add(this.btnStorageLocCode);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtBarCode);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnBarCode);
            this.panel1.Controls.Add(this.txtStorageCode);
            this.panel1.Location = new System.Drawing.Point(4, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 541);
            this.panel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 9.25F);
            this.button1.Location = new System.Drawing.Point(37, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 30);
            this.button1.TabIndex = 304;
            this.button1.Text = "바코드 타입";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Black;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(203, 425);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 35);
            this.btnClose.TabIndex = 303;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.Green;
            this.btnSelect.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSelect.ForeColor = System.Drawing.Color.White;
            this.btnSelect.Location = new System.Drawing.Point(236, 384);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(52, 35);
            this.btnSelect.TabIndex = 302;
            this.btnSelect.Text = "조회";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnDEL1
            // 
            this.btnDEL1.BackColor = System.Drawing.Color.Crimson;
            this.btnDEL1.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDEL1.ForeColor = System.Drawing.Color.White;
            this.btnDEL1.Location = new System.Drawing.Point(180, 384);
            this.btnDEL1.Name = "btnDEL1";
            this.btnDEL1.Size = new System.Drawing.Size(47, 35);
            this.btnDEL1.TabIndex = 301;
            this.btnDEL1.Text = "삭제";
            this.btnDEL1.UseVisualStyleBackColor = false;
            this.btnDEL1.Click += new System.EventHandler(this.btnDEL1_Click);
            // 
            // grid1
            // 
            this.grid1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.grid1.CheckBoxes = true;
            this.grid1.FullRowSelect = true;
            this.grid1.HideSelection = false;
            this.grid1.Location = new System.Drawing.Point(37, 206);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(254, 172);
            this.grid1.TabIndex = 300;
            this.grid1.UseCompatibleStateImageBehavior = false;
            this.grid1.View = System.Windows.Forms.View.List;
            this.grid1.SelectedIndexChanged += new System.EventHandler(this.grid1_SelectedIndexChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(216, 173);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(57, 24);
            this.radioButton2.TabIndex = 299;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "들기";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(145, 173);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(57, 24);
            this.radioButton1.TabIndex = 298;
            this.radioButton1.Text = "놓기";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // btnNextPage
            // 
            this.btnNextPage.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnNextPage.Location = new System.Drawing.Point(38, 384);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(58, 35);
            this.btnNextPage.TabIndex = 297;
            this.btnNextPage.Text = "▶";
            this.btnNextPage.UseVisualStyleBackColor = false;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // txtInputBarCode
            // 
            appearance13.FontData.BoldAsString = "False";
            appearance13.FontData.SizeInPoints = 12F;
            appearance13.FontData.UnderlineAsString = "False";
            appearance13.ForeColor = System.Drawing.Color.Black;
            this.txtInputBarCode.Appearance = appearance13;
            this.txtInputBarCode.AutoSize = false;
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
            // txtStorageName
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.txtStorageName.Appearance = appearance1;
            this.txtStorageName.AutoSize = false;
            this.txtStorageName.Location = new System.Drawing.Point(125, 136);
            this.txtStorageName.Name = "txtStorageName";
            this.txtStorageName.ReadOnly = true;
            this.txtStorageName.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtStorageName.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtStorageName.Size = new System.Drawing.Size(166, 28);
            this.txtStorageName.TabIndex = 289;
            // 
            // btnStorageLocCode
            // 
            this.btnStorageLocCode.Location = new System.Drawing.Point(37, 106);
            this.btnStorageLocCode.Name = "btnStorageLocCode";
            this.btnStorageLocCode.Size = new System.Drawing.Size(88, 30);
            this.btnStorageLocCode.TabIndex = 288;
            this.btnStorageLocCode.Text = "위치";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(102, 425);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 35);
            this.btnSave.TabIndex = 287;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtBarCode
            // 
            appearance16.FontData.BoldAsString = "False";
            appearance16.FontData.UnderlineAsString = "False";
            appearance16.ForeColor = System.Drawing.Color.Black;
            this.txtBarCode.Appearance = appearance16;
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
            this.btnClear.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClear.Location = new System.Drawing.Point(102, 384);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(72, 35);
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
            // txtStorageCode
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.txtStorageCode.Appearance = appearance2;
            this.txtStorageCode.AutoSize = false;
            this.txtStorageCode.Location = new System.Drawing.Point(38, 136);
            this.txtStorageCode.Name = "txtStorageCode";
            this.txtStorageCode.ReadOnly = true;
            this.txtStorageCode.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtStorageCode.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtStorageCode.Size = new System.Drawing.Size(87, 28);
            this.txtStorageCode.TabIndex = 294;
            // 
            // txtLimit
            // 
            appearance23.FontData.BoldAsString = "False";
            appearance23.FontData.UnderlineAsString = "False";
            appearance23.ForeColor = System.Drawing.Color.Black;
            this.txtLimit.Appearance = appearance23;
            this.txtLimit.AutoSize = false;
            this.txtLimit.Location = new System.Drawing.Point(203, 108);
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.ReadOnly = true;
            this.txtLimit.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtLimit.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtLimit.Size = new System.Drawing.Size(88, 28);
            this.txtLimit.TabIndex = 305;
            // 
            // lblLimit
            // 
            this.lblLimit.AutoSize = true;
            this.lblLimit.Location = new System.Drawing.Point(131, 111);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(69, 20);
            this.lblLimit.TabIndex = 306;
            this.lblLimit.Text = "한도수량";
            // 
            // PD3050
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 628);
            this.Name = "PD3050";
            this.Text = "로케이션 이동";
            this.Load += new System.EventHandler(this.PD3050_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInputBarCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStorageName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStorageCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLimit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBarCode;
        private System.Windows.Forms.Label lblFormName;
        private System.Windows.Forms.Button btnSave;
        private WIZ.Control.STextBox txtStorageName;
        private System.Windows.Forms.Button btnStorageLocCode;
        private WIZ.Control.STextBox txtInputBarCode;
        private WIZ.Control.STextBox txtStorageCode;
        private System.Windows.Forms.Label lblFormName2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClear2;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPrePage;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnDEL1;
        private System.Windows.Forms.ListView grid1;
        private System.Windows.Forms.Button btnClose2;
        private System.Windows.Forms.Button btnDEL2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView grid2;
        private System.Windows.Forms.Button button1;
        private Control.STextBox txtBarCode;
        private System.Windows.Forms.Label lblLimit;
        private Control.STextBox txtLimit;
    }
}
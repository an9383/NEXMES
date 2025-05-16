namespace WIZ.PP
{
    partial class TT1080
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.layout1 = new System.Windows.Forms.TableLayoutPanel();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.layout2 = new System.Windows.Forms.TableLayoutPanel();
            this.ultraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.cboPlantCode_H = new System.Windows.Forms.ComboBox();
            this.lblPlantCode = new WIZ.Control.SLabel();
            this.trmReload = new System.Windows.Forms.Timer(this.components);
            this.sTime = new Infragistics.Win.Misc.UltraLabel();
            this.ultraComboEditor1 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.layout1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraComboEditor1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.sTime);
            this.gbxHeader.Controls.Add(this.cboPlantCode_H);
            this.gbxHeader.Controls.Add(this.lblPlantCode);
            this.gbxHeader.Controls.Add(this.ultraLabel21);
            this.gbxHeader.Size = new System.Drawing.Size(1136, 114);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.splitContainer1);
            this.gbxBody.Location = new System.Drawing.Point(0, 114);
            this.gbxBody.Size = new System.Drawing.Size(1136, 711);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(6, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ultraGroupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ultraGroupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1124, 699);
            this.splitContainer1.SplitterDistance = 561;
            this.splitContainer1.TabIndex = 1;
            // 
            // ultraGroupBox1
            // 
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.Controls.Add(this.layout1);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(561, 699);
            this.ultraGroupBox1.TabIndex = 2;
            this.ultraGroupBox1.Text = "1호기";
            // 
            // layout1
            // 
            this.layout1.ColumnCount = 3;
            this.layout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layout1.Controls.Add(this.ultraComboEditor1, 0, 0);
            this.layout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout1.Location = new System.Drawing.Point(3, 37);
            this.layout1.Name = "layout1";
            this.layout1.RowCount = 6;
            this.layout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.77778F));
            this.layout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.layout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.77778F));
            this.layout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.layout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.77778F));
            this.layout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.layout1.Size = new System.Drawing.Size(555, 659);
            this.layout1.TabIndex = 1;
            // 
            // ultraGroupBox2
            // 
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.ultraGroupBox2.Appearance = appearance2;
            this.ultraGroupBox2.Controls.Add(this.layout2);
            this.ultraGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox2.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ultraGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(559, 699);
            this.ultraGroupBox2.TabIndex = 2;
            this.ultraGroupBox2.Text = "2호기";
            // 
            // layout2
            // 
            this.layout2.ColumnCount = 3;
            this.layout2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layout2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layout2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layout2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout2.Location = new System.Drawing.Point(3, 37);
            this.layout2.Name = "layout2";
            this.layout2.RowCount = 6;
            this.layout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.77778F));
            this.layout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.layout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.77778F));
            this.layout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.layout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.77778F));
            this.layout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.layout2.Size = new System.Drawing.Size(553, 659);
            this.layout2.TabIndex = 2;
            // 
            // ultraLabel21
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(66)))));
            appearance5.ForeColor = System.Drawing.Color.White;
            appearance5.TextHAlignAsString = "Center";
            appearance5.TextVAlignAsString = "Middle";
            this.ultraLabel21.Appearance = appearance5;
            this.ultraLabel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraLabel21.Font = new System.Drawing.Font("HY헤드라인M", 36F, System.Drawing.FontStyle.Bold);
            this.ultraLabel21.Location = new System.Drawing.Point(4, 4);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(1128, 106);
            this.ultraLabel21.TabIndex = 3;
            this.ultraLabel21.Text = "브레이징로 온도 모니터링";
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.FormattingEnabled = true;
            this.cboPlantCode_H.Location = new System.Drawing.Point(198, 61);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(120, 28);
            this.cboPlantCode_H.TabIndex = 234;
            this.cboPlantCode_H.Visible = false;
            // 
            // lblPlantCode
            // 
            appearance85.TextHAlignAsString = "Center";
            appearance85.TextVAlignAsString = "Middle";
            this.lblPlantCode.Appearance = appearance85;
            this.lblPlantCode.DbField = null;
            this.lblPlantCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlantCode.Location = new System.Drawing.Point(199, 29);
            this.lblPlantCode.Name = "lblPlantCode";
            this.lblPlantCode.Size = new System.Drawing.Size(119, 27);
            this.lblPlantCode.TabIndex = 233;
            this.lblPlantCode.Text = "사업장";
            this.lblPlantCode.Visible = false;
            // 
            // trmReload
            // 
            this.trmReload.Interval = 30000;
            this.trmReload.Tick += new System.EventHandler(this.trmReload_Tick);
            // 
            // sTime
            // 
            appearance52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(66)))));
            appearance52.ForeColor = System.Drawing.Color.White;
            appearance52.TextHAlignAsString = "Center";
            appearance52.TextVAlignAsString = "Middle";
            this.sTime.Appearance = appearance52;
            this.sTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.sTime.Font = new System.Drawing.Font("HY헤드라인M", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sTime.Location = new System.Drawing.Point(4, 4);
            this.sTime.Name = "sTime";
            this.sTime.Size = new System.Drawing.Size(227, 106);
            this.sTime.TabIndex = 235;
            this.sTime.Text = "12:00";
            // 
            // ultraComboEditor1
            // 
            this.ultraComboEditor1.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.ultraComboEditor1.Location = new System.Drawing.Point(3, 3);
            this.ultraComboEditor1.Name = "ultraComboEditor1";
            this.ultraComboEditor1.Size = new System.Drawing.Size(144, 27);
            this.ultraComboEditor1.TabIndex = 199;
            // 
            // TT1080
            // 
            this.ClientSize = new System.Drawing.Size(1136, 825);
            this.Name = "TT1080";
            this.Text = "브레이징로 온도 모니터링";
            this.Deactivate += new System.EventHandler(this.TT1080_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TT1080_FormClosed);
            this.Load += new System.EventHandler(this.TT1080_Load);
            this.Enter += new System.EventHandler(this.TT1080_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.layout1.ResumeLayout(false);
            this.layout1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraComboEditor1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel21;
        private System.Windows.Forms.ComboBox cboPlantCode_H;
        private Control.SLabel lblPlantCode;
        private System.Windows.Forms.Timer trmReload;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private System.Windows.Forms.TableLayoutPanel layout1;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private System.Windows.Forms.TableLayoutPanel layout2;
        private Infragistics.Win.Misc.UltraLabel sTime;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor ultraComboEditor1;
    }
}

namespace WIZ.MT
{
    partial class UC_WorkCenterProdStatus
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblProdRate1 = new System.Windows.Forms.Label();
            this.lblWorkCenterName = new System.Windows.Forms.Label();
            this.lblProdRate2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblProdRate2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblWorkCenterName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblProdRate1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(127, 72);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblProdRate1
            // 
            this.lblProdRate1.BackColor = System.Drawing.Color.Transparent;
            this.lblProdRate1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProdRate1.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProdRate1.ForeColor = System.Drawing.Color.White;
            this.lblProdRate1.Location = new System.Drawing.Point(5, 25);
            this.lblProdRate1.Name = "lblProdRate1";
            this.lblProdRate1.Size = new System.Drawing.Size(117, 21);
            this.lblProdRate1.TabIndex = 0;
            this.lblProdRate1.Text = "0%";
            this.lblProdRate1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProdRate1.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // lblWorkCenterName
            // 
            this.lblWorkCenterName.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkCenterName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorkCenterName.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWorkCenterName.ForeColor = System.Drawing.Color.White;
            this.lblWorkCenterName.Location = new System.Drawing.Point(5, 2);
            this.lblWorkCenterName.Name = "lblWorkCenterName";
            this.lblWorkCenterName.Size = new System.Drawing.Size(117, 21);
            this.lblWorkCenterName.TabIndex = 0;
            this.lblWorkCenterName.Text = "작업장명";
            this.lblWorkCenterName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWorkCenterName.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // lblProdRate2
            // 
            this.lblProdRate2.BackColor = System.Drawing.Color.Transparent;
            this.lblProdRate2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProdRate2.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProdRate2.ForeColor = System.Drawing.Color.White;
            this.lblProdRate2.Location = new System.Drawing.Point(5, 48);
            this.lblProdRate2.Name = "lblProdRate2";
            this.lblProdRate2.Size = new System.Drawing.Size(117, 22);
            this.lblProdRate2.TabIndex = 1;
            this.lblProdRate2.Text = "0%";
            this.lblProdRate2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UC_WorkCenter3
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_WorkCenter3";
            this.Size = new System.Drawing.Size(127, 72);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblProdRate1;
        private System.Windows.Forms.Label lblProdRate2;
        private System.Windows.Forms.Label lblWorkCenterName;
    }
}

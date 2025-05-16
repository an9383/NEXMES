namespace WIZ.MT
{
    partial class UC_WorkCenter
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
            this.lblWorkCenterCode = new System.Windows.Forms.Label();
            this.lblWorkCenterName = new System.Windows.Forms.Label();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblProdQty = new System.Windows.Forms.Label();
            this.lblLineStatus = new System.Windows.Forms.Label();
            this.lblLastLineTime = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblWorkCenterCode, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblWorkCenterName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblItemCode, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblItemName, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblProdQty, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblLineStatus, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblLastLineTime, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(198, 148);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblWorkCenterCode
            // 
            this.lblWorkCenterCode.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkCenterCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorkCenterCode.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWorkCenterCode.Location = new System.Drawing.Point(3, 0);
            this.lblWorkCenterCode.Name = "lblWorkCenterCode";
            this.lblWorkCenterCode.Size = new System.Drawing.Size(192, 19);
            this.lblWorkCenterCode.TabIndex = 0;
            this.lblWorkCenterCode.Text = "333106";
            this.lblWorkCenterCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWorkCenterCode.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // lblWorkCenterName
            // 
            this.lblWorkCenterName.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkCenterName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorkCenterName.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWorkCenterName.Location = new System.Drawing.Point(3, 19);
            this.lblWorkCenterName.Name = "lblWorkCenterName";
            this.lblWorkCenterName.Size = new System.Drawing.Size(192, 19);
            this.lblWorkCenterName.TabIndex = 0;
            this.lblWorkCenterName.Text = "포밍 18";
            this.lblWorkCenterName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWorkCenterName.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // lblItemCode
            // 
            this.lblItemCode.BackColor = System.Drawing.Color.Transparent;
            this.lblItemCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItemCode.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemCode.Location = new System.Drawing.Point(3, 38);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(192, 19);
            this.lblItemCode.TabIndex = 0;
            this.lblItemCode.Text = "45558-23050F0";
            this.lblItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblItemCode.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // lblItemName
            // 
            this.lblItemName.BackColor = System.Drawing.Color.Transparent;
            this.lblItemName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItemName.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemName.Location = new System.Drawing.Point(3, 57);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(192, 19);
            this.lblItemName.TabIndex = 0;
            this.lblItemName.Text = "HUB-O/D CLUTCH";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblItemName.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // lblProdQty
            // 
            this.lblProdQty.BackColor = System.Drawing.Color.Transparent;
            this.lblProdQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProdQty.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProdQty.Location = new System.Drawing.Point(3, 76);
            this.lblProdQty.Name = "lblProdQty";
            this.lblProdQty.Size = new System.Drawing.Size(192, 19);
            this.lblProdQty.TabIndex = 0;
            this.lblProdQty.Text = "1072/1000";
            this.lblProdQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProdQty.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // lblLineStatus
            // 
            this.lblLineStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblLineStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLineStatus.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLineStatus.Location = new System.Drawing.Point(3, 95);
            this.lblLineStatus.Name = "lblLineStatus";
            this.lblLineStatus.Size = new System.Drawing.Size(192, 29);
            this.lblLineStatus.TabIndex = 0;
            this.lblLineStatus.Text = "가동";
            this.lblLineStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLineStatus.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // lblLastLineTime
            // 
            this.lblLastLineTime.BackColor = System.Drawing.Color.Transparent;
            this.lblLastLineTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastLineTime.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLastLineTime.Location = new System.Drawing.Point(3, 124);
            this.lblLastLineTime.Name = "lblLastLineTime";
            this.lblLastLineTime.Size = new System.Drawing.Size(192, 24);
            this.lblLastLineTime.TabIndex = 0;
            this.lblLastLineTime.Text = "2014-08-29 08:24:00";
            this.lblLastLineTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLastLineTime.DoubleClick += new System.EventHandler(this.lbl_DoubleClick);
            // 
            // UC_WorkCenter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_WorkCenter";
            this.Size = new System.Drawing.Size(198, 148);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblWorkCenterCode;
        private System.Windows.Forms.Label lblWorkCenterName;
        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblProdQty;
        private System.Windows.Forms.Label lblLineStatus;
        private System.Windows.Forms.Label lblLastLineTime;
    }
}

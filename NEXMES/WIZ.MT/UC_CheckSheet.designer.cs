namespace WIZ.MT
{
    partial class UC_CheckSheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_CheckSheet));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tlpDetail = new System.Windows.Forms.TableLayoutPanel();
            this.pnlNight03 = new System.Windows.Forms.Panel();
            this.pnlNight02 = new System.Windows.Forms.Panel();
            this.pnlNight01 = new System.Windows.Forms.Panel();
            this.pnlDay03 = new System.Windows.Forms.Panel();
            this.pnlDay02 = new System.Windows.Forms.Panel();
            this.pnlNight_H = new System.Windows.Forms.Panel();
            this.pnlDay_H = new System.Windows.Forms.Panel();
            this.pnlDay01 = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblWorkCenterCode = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.tlpDetail.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.tlpDetail);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(265, 129);
            this.pnlMain.TabIndex = 2;
            // 
            // tlpDetail
            // 
            this.tlpDetail.AutoSize = true;
            this.tlpDetail.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpDetail.ColumnCount = 4;
            this.tlpDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tlpDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tlpDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tlpDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tlpDetail.Controls.Add(this.pnlNight03, 3, 1);
            this.tlpDetail.Controls.Add(this.pnlNight02, 2, 1);
            this.tlpDetail.Controls.Add(this.pnlNight01, 1, 1);
            this.tlpDetail.Controls.Add(this.pnlDay03, 3, 0);
            this.tlpDetail.Controls.Add(this.pnlDay02, 2, 0);
            this.tlpDetail.Controls.Add(this.pnlNight_H, 0, 1);
            this.tlpDetail.Controls.Add(this.pnlDay_H, 0, 0);
            this.tlpDetail.Controls.Add(this.pnlDay01, 1, 0);
            this.tlpDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDetail.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tlpDetail.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlpDetail.Location = new System.Drawing.Point(0, 30);
            this.tlpDetail.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDetail.Name = "tlpDetail";
            this.tlpDetail.RowCount = 2;
            this.tlpDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDetail.Size = new System.Drawing.Size(265, 99);
            this.tlpDetail.TabIndex = 10;
            // 
            // pnlNight03
            // 
            this.pnlNight03.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlNight03.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlNight03.BackgroundImage")));
            this.pnlNight03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlNight03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNight03.Location = new System.Drawing.Point(193, 50);
            this.pnlNight03.Margin = new System.Windows.Forms.Padding(0);
            this.pnlNight03.Name = "pnlNight03";
            this.pnlNight03.Size = new System.Drawing.Size(71, 48);
            this.pnlNight03.TabIndex = 28;
            // 
            // pnlNight02
            // 
            this.pnlNight02.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlNight02.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlNight02.BackgroundImage")));
            this.pnlNight02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlNight02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNight02.Location = new System.Drawing.Point(122, 50);
            this.pnlNight02.Margin = new System.Windows.Forms.Padding(0);
            this.pnlNight02.Name = "pnlNight02";
            this.pnlNight02.Size = new System.Drawing.Size(70, 48);
            this.pnlNight02.TabIndex = 27;
            // 
            // pnlNight01
            // 
            this.pnlNight01.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlNight01.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlNight01.BackgroundImage")));
            this.pnlNight01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlNight01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNight01.Location = new System.Drawing.Point(51, 50);
            this.pnlNight01.Margin = new System.Windows.Forms.Padding(0);
            this.pnlNight01.Name = "pnlNight01";
            this.pnlNight01.Size = new System.Drawing.Size(70, 48);
            this.pnlNight01.TabIndex = 26;
            // 
            // pnlDay03
            // 
            this.pnlDay03.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlDay03.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlDay03.BackgroundImage")));
            this.pnlDay03.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlDay03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDay03.Location = new System.Drawing.Point(193, 1);
            this.pnlDay03.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDay03.Name = "pnlDay03";
            this.pnlDay03.Size = new System.Drawing.Size(71, 48);
            this.pnlDay03.TabIndex = 25;
            // 
            // pnlDay02
            // 
            this.pnlDay02.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlDay02.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlDay02.BackgroundImage")));
            this.pnlDay02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlDay02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDay02.Location = new System.Drawing.Point(122, 1);
            this.pnlDay02.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDay02.Name = "pnlDay02";
            this.pnlDay02.Size = new System.Drawing.Size(70, 48);
            this.pnlDay02.TabIndex = 24;
            // 
            // pnlNight_H
            // 
            this.pnlNight_H.BackColor = System.Drawing.Color.White;
            this.pnlNight_H.BackgroundImage = global::WIZ.MT.Properties.Resources.Night;
            this.pnlNight_H.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlNight_H.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNight_H.Location = new System.Drawing.Point(1, 50);
            this.pnlNight_H.Margin = new System.Windows.Forms.Padding(0);
            this.pnlNight_H.Name = "pnlNight_H";
            this.pnlNight_H.Size = new System.Drawing.Size(49, 48);
            this.pnlNight_H.TabIndex = 22;
            // 
            // pnlDay_H
            // 
            this.pnlDay_H.BackColor = System.Drawing.Color.White;
            this.pnlDay_H.BackgroundImage = global::WIZ.MT.Properties.Resources.Day;
            this.pnlDay_H.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlDay_H.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDay_H.Location = new System.Drawing.Point(1, 1);
            this.pnlDay_H.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDay_H.Name = "pnlDay_H";
            this.pnlDay_H.Size = new System.Drawing.Size(49, 48);
            this.pnlDay_H.TabIndex = 21;
            // 
            // pnlDay01
            // 
            this.pnlDay01.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlDay01.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlDay01.BackgroundImage")));
            this.pnlDay01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlDay01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDay01.Location = new System.Drawing.Point(51, 1);
            this.pnlDay01.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDay01.Name = "pnlDay01";
            this.pnlDay01.Size = new System.Drawing.Size(70, 48);
            this.pnlDay01.TabIndex = 23;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Silver;
            this.pnlHeader.Controls.Add(this.lblWorkCenterCode);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.ForeColor = System.Drawing.Color.Black;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(265, 30);
            this.pnlHeader.TabIndex = 9;
            // 
            // lblWorkCenterCode
            // 
            this.lblWorkCenterCode.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkCenterCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorkCenterCode.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblWorkCenterCode.ForeColor = System.Drawing.Color.Black;
            this.lblWorkCenterCode.Location = new System.Drawing.Point(0, 0);
            this.lblWorkCenterCode.Margin = new System.Windows.Forms.Padding(0);
            this.lblWorkCenterCode.Name = "lblWorkCenterCode";
            this.lblWorkCenterCode.Size = new System.Drawing.Size(265, 30);
            this.lblWorkCenterCode.TabIndex = 13;
            this.lblWorkCenterCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UC_CheckSheet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UC_CheckSheet";
            this.Size = new System.Drawing.Size(265, 129);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.tlpDetail.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TableLayoutPanel tlpDetail;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblWorkCenterCode;
        private System.Windows.Forms.Panel pnlNight_H;
        private System.Windows.Forms.Panel pnlDay_H;
        private System.Windows.Forms.Panel pnlNight03;
        private System.Windows.Forms.Panel pnlNight02;
        private System.Windows.Forms.Panel pnlNight01;
        private System.Windows.Forms.Panel pnlDay03;
        private System.Windows.Forms.Panel pnlDay02;
        private System.Windows.Forms.Panel pnlDay01;
    }
}

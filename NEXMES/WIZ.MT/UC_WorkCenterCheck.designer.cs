namespace WIZ.MT
{
    partial class UC_WorkCenterCheck
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tlpDetail = new System.Windows.Forms.TableLayoutPanel();
            this.pnlStatus02 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlStatus01 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlStatus_H = new System.Windows.Forms.Panel();
            this.pnlDate_H = new System.Windows.Forms.Panel();
            this.pnlInsp_H = new System.Windows.Forms.Panel();
            this.lblDateM = new System.Windows.Forms.Label();
            this.lblDateD = new System.Windows.Forms.Label();
            this.lblMonthCnt = new System.Windows.Forms.Label();
            this.lblDayCnt = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblWorkCenterCode = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.tlpDetail.SuspendLayout();
            this.pnlStatus02.SuspendLayout();
            this.pnlStatus01.SuspendLayout();
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
            this.pnlMain.Size = new System.Drawing.Size(250, 130);
            this.pnlMain.TabIndex = 1;
            // 
            // tlpDetail
            // 
            this.tlpDetail.AutoSize = true;
            this.tlpDetail.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpDetail.ColumnCount = 3;
            this.tlpDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpDetail.Controls.Add(this.pnlStatus02, 2, 2);
            this.tlpDetail.Controls.Add(this.pnlStatus01, 1, 2);
            this.tlpDetail.Controls.Add(this.pnlStatus_H, 0, 2);
            this.tlpDetail.Controls.Add(this.pnlDate_H, 0, 1);
            this.tlpDetail.Controls.Add(this.pnlInsp_H, 0, 0);
            this.tlpDetail.Controls.Add(this.lblDateM, 2, 1);
            this.tlpDetail.Controls.Add(this.lblDateD, 1, 1);
            this.tlpDetail.Controls.Add(this.lblMonthCnt, 2, 0);
            this.tlpDetail.Controls.Add(this.lblDayCnt, 1, 0);
            this.tlpDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDetail.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tlpDetail.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlpDetail.Location = new System.Drawing.Point(0, 30);
            this.tlpDetail.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDetail.Name = "tlpDetail";
            this.tlpDetail.RowCount = 3;
            this.tlpDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpDetail.Size = new System.Drawing.Size(250, 100);
            this.tlpDetail.TabIndex = 10;
            // 
            // pnlStatus02
            // 
            this.pnlStatus02.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlStatus02.BackgroundImage = global::WIZ.MT.Properties.Resources.NG_FC;
            this.pnlStatus02.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlStatus02.Controls.Add(this.label2);
            this.pnlStatus02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatus02.Location = new System.Drawing.Point(150, 67);
            this.pnlStatus02.Margin = new System.Windows.Forms.Padding(0);
            this.pnlStatus02.Name = "pnlStatus02";
            this.pnlStatus02.Size = new System.Drawing.Size(99, 32);
            this.pnlStatus02.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(39, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(60, 32);
            this.label2.TabIndex = 19;
            this.label2.Text = "정기점검";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlStatus01
            // 
            this.pnlStatus01.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlStatus01.BackgroundImage = global::WIZ.MT.Properties.Resources.NG_FC;
            this.pnlStatus01.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlStatus01.Controls.Add(this.label1);
            this.pnlStatus01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatus01.Location = new System.Drawing.Point(51, 67);
            this.pnlStatus01.Margin = new System.Windows.Forms.Padding(0);
            this.pnlStatus01.Name = "pnlStatus01";
            this.pnlStatus01.Size = new System.Drawing.Size(98, 32);
            this.pnlStatus01.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(38, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(60, 32);
            this.label1.TabIndex = 18;
            this.label1.Text = "일상점검";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlStatus_H
            // 
            this.pnlStatus_H.BackColor = System.Drawing.Color.White;
            this.pnlStatus_H.BackgroundImage = global::WIZ.MT.Properties.Resources.Check;
            this.pnlStatus_H.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlStatus_H.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatus_H.Location = new System.Drawing.Point(1, 67);
            this.pnlStatus_H.Margin = new System.Windows.Forms.Padding(0);
            this.pnlStatus_H.Name = "pnlStatus_H";
            this.pnlStatus_H.Size = new System.Drawing.Size(49, 32);
            this.pnlStatus_H.TabIndex = 24;
            // 
            // pnlDate_H
            // 
            this.pnlDate_H.BackColor = System.Drawing.Color.White;
            this.pnlDate_H.BackgroundImage = global::WIZ.MT.Properties.Resources.Calendar;
            this.pnlDate_H.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlDate_H.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDate_H.Location = new System.Drawing.Point(1, 34);
            this.pnlDate_H.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDate_H.Name = "pnlDate_H";
            this.pnlDate_H.Size = new System.Drawing.Size(49, 32);
            this.pnlDate_H.TabIndex = 23;
            // 
            // pnlInsp_H
            // 
            this.pnlInsp_H.BackColor = System.Drawing.Color.White;
            this.pnlInsp_H.BackgroundImage = global::WIZ.MT.Properties.Resources.InspList;
            this.pnlInsp_H.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlInsp_H.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInsp_H.Location = new System.Drawing.Point(1, 1);
            this.pnlInsp_H.Margin = new System.Windows.Forms.Padding(0);
            this.pnlInsp_H.Name = "pnlInsp_H";
            this.pnlInsp_H.Size = new System.Drawing.Size(49, 32);
            this.pnlInsp_H.TabIndex = 22;
            // 
            // lblDateM
            // 
            this.lblDateM.BackColor = System.Drawing.Color.Gainsboro;
            this.lblDateM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDateM.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDateM.ForeColor = System.Drawing.Color.Black;
            this.lblDateM.Location = new System.Drawing.Point(150, 34);
            this.lblDateM.Margin = new System.Windows.Forms.Padding(0);
            this.lblDateM.Name = "lblDateM";
            this.lblDateM.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDateM.Size = new System.Drawing.Size(99, 32);
            this.lblDateM.TabIndex = 18;
            this.lblDateM.Text = "매월 1일";
            this.lblDateM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDateD
            // 
            this.lblDateD.BackColor = System.Drawing.Color.Gainsboro;
            this.lblDateD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDateD.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDateD.ForeColor = System.Drawing.Color.Black;
            this.lblDateD.Location = new System.Drawing.Point(51, 34);
            this.lblDateD.Margin = new System.Windows.Forms.Padding(0);
            this.lblDateD.Name = "lblDateD";
            this.lblDateD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDateD.Size = new System.Drawing.Size(98, 32);
            this.lblDateD.TabIndex = 17;
            this.lblDateD.Text = "매일 시업 전";
            this.lblDateD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonthCnt
            // 
            this.lblMonthCnt.BackColor = System.Drawing.Color.Gainsboro;
            this.lblMonthCnt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMonthCnt.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.lblMonthCnt.ForeColor = System.Drawing.Color.Black;
            this.lblMonthCnt.Location = new System.Drawing.Point(150, 1);
            this.lblMonthCnt.Margin = new System.Windows.Forms.Padding(0);
            this.lblMonthCnt.Name = "lblMonthCnt";
            this.lblMonthCnt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMonthCnt.Size = new System.Drawing.Size(99, 32);
            this.lblMonthCnt.TabIndex = 15;
            this.lblMonthCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDayCnt
            // 
            this.lblDayCnt.BackColor = System.Drawing.Color.Gainsboro;
            this.lblDayCnt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDayCnt.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.lblDayCnt.ForeColor = System.Drawing.Color.Black;
            this.lblDayCnt.Location = new System.Drawing.Point(51, 1);
            this.lblDayCnt.Margin = new System.Windows.Forms.Padding(0);
            this.lblDayCnt.Name = "lblDayCnt";
            this.lblDayCnt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDayCnt.Size = new System.Drawing.Size(98, 32);
            this.lblDayCnt.TabIndex = 14;
            this.lblDayCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.pnlHeader.Size = new System.Drawing.Size(250, 30);
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
            this.lblWorkCenterCode.Size = new System.Drawing.Size(250, 30);
            this.lblWorkCenterCode.TabIndex = 13;
            this.lblWorkCenterCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UC_WorkCenterCheck
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UC_WorkCenterCheck";
            this.Size = new System.Drawing.Size(250, 130);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.tlpDetail.ResumeLayout(false);
            this.pnlStatus02.ResumeLayout(false);
            this.pnlStatus01.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TableLayoutPanel tlpDetail;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblWorkCenterCode;
        private System.Windows.Forms.Label lblDateM;
        private System.Windows.Forms.Label lblDateD;
        private System.Windows.Forms.Label lblMonthCnt;
        private System.Windows.Forms.Label lblDayCnt;
        private System.Windows.Forms.Panel pnlStatus_H;
        private System.Windows.Forms.Panel pnlDate_H;
        private System.Windows.Forms.Panel pnlInsp_H;
        private System.Windows.Forms.Panel pnlStatus02;
        private System.Windows.Forms.Panel pnlStatus01;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

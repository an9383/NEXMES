using Infragistics.Win;
using Infragistics.Win.UltraWinSchedule;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using WIZ.Control;
using WIZ.Forms;
using WIZ.PopManager;

namespace WIZ.SY
{
    public class SY0040 : BaseMDIChildForm
    {
        private UltraGridUtil _GridUtil = new UltraGridUtil();

        private Common _Com = new Common();

        private new IContainer components = null;

        private WIZ.Control.Grid grid1;

        private SLabel lbl;

        private UltraCalendarCombo cboPlanStartDT_H;

        private SLabel lblPlanDT;

        private UltraCalendarCombo cboPlanEndDT_H;

        private SLabel lblWorkerID;

        private SBtnTextEditor txtMaker;

        private WIZ.Control.STextBox txtWorkerName;

        public SY0040()
        {
            InitializeComponent();
        }

        private void SY0040_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERID", "사용자ID", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME", "사용자명", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Left);
            _GridUtil.InitColumnUltraGrid(grid1, "SSTAMP", "시작일자", false, GridColDataType_emu.VarChar, 150, 100, HAlign.Center);
            _GridUtil.InitColumnUltraGrid(grid1, "ESTAMP", "종료일자", false, GridColDataType_emu.VarChar, 150, 100, HAlign.Center);
            _GridUtil.InitColumnUltraGrid(grid1, "STATE", "상태", false, GridColDataType_emu.VarChar, 80, 100, HAlign.Center);
            _GridUtil.InitColumnUltraGrid(grid1, "PROGID", "화면ID", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center);
            _GridUtil.InitColumnUltraGrid(grid1, "RUNSTR", "실행시간", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Right);
            _GridUtil.InitColumnUltraGrid(grid1, "RUNTIME", "실행시간(초)", false, GridColDataType_emu.Integer, 100, 100, HAlign.Right, true, false, "#,##0");
            _GridUtil.InitColumnUltraGrid(grid1, "IPADDRESS", "접속자IP", false, GridColDataType_emu.VarChar, 120, 100, HAlign.Center);
            _GridUtil.InitColumnUltraGrid(grid1, "COMNAME", "컴퓨터이름", false, GridColDataType_emu.VarChar, 180, 100, HAlign.Left);
            _GridUtil.SetInitUltraGridBind(grid1);
            txtMaker.ControlAdded += tCodeControlAdd;
            txtWorkerName.ControlAdded += tNameControlAdd;
            cboPlanStartDT_H.Value = DateTime.Now;
            cboPlanEndDT_H.Value = DateTime.Now;
        }

        public override void DoInquire()
        {
            base.DoInquire();
            DateTime planstartdt = DBHelper.nvlDateTime(cboPlanStartDT_H.Text + " 00:00:00");
            DateTime planenddt = DBHelper.nvlDateTime(cboPlanEndDT_H.Text + " 23:59:59.99");
            string text = txtMaker.Text;
            _GridUtil.Grid_Clear(grid1);
            DataTable dataTable = USP_SY0040_S1(planstartdt, planenddt, text);
            if (dataTable != null)
            {
                grid1.DataSource = dataTable;
                grid1.DataBinds();
            }
        }

        private void txtMaker_ButtonClick(object sender, EventArgs e)
        {
            PopManagerBase popManagerBase = new PopManagerBase();
            DataTable dataTable = popManagerBase.OpenPopupShow("WIZ.SY", "POP_TSY0030", "사용자 검색", new string[7]
            {
                "",
                "",
                "",
                "",
                "",
                "",
                "Y"
            });
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                txtMaker.Text = Convert.ToString(dataTable.Rows[0]["WorkerID"]);
                txtWorkerName.Text = Convert.ToString(dataTable.Rows[0]["WorkerName"]);
            }
        }

        private void tCodeControlAdd(object sender, ControlEventArgs e)
        {
            e.Control.DoubleClick += tCodeBox_DoubleClick;
        }

        private void tCodeBox_DoubleClick(object sender, EventArgs e)
        {
            txtMaker_ButtonClick(null, null);
        }

        private void tNameControlAdd(object sender, ControlEventArgs e)
        {
            e.Control.DoubleClick += tNameBox_DoubleClick;
        }

        private void tNameBox_DoubleClick(object sender, EventArgs e)
        {
            txtMaker_ButtonClick(null, null);
        }

        private DataTable USP_SY0040_S1(DateTime planstartdt, DateTime planenddt, string maker)
        {
            DBHelper dBHelper = new DBHelper(completedClose: false);
            try
            {
                return dBHelper.FillTable("USP_SY0040_S1", CommandType.StoredProcedure, dBHelper.CreateParameter("SDATE", planstartdt, DbType.DateTime, ParameterDirection.Input), dBHelper.CreateParameter("SDATE1", planenddt, DbType.DateTime, ParameterDirection.Input), dBHelper.CreateParameter("WorkerID", maker, DbType.String, ParameterDirection.Input));
            }
            catch (Exception ex)
            {
                CheckForm checkForm = new CheckForm(ex.ToString());
                checkForm.ShowDialog();
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private new void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            lbl = new WIZ.Control.SLabel();
            lblPlanDT = new WIZ.Control.SLabel();
            cboPlanEndDT_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            cboPlanStartDT_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            grid1 = new WIZ.Control.Grid(components);
            lblWorkerID = new WIZ.Control.SLabel();
            txtMaker = new WIZ.Control.SBtnTextEditor();
            txtWorkerName = new WIZ.Control.STextBox(components);
            ((System.ComponentModel.ISupportInitialize)gbxHeader).BeginInit();
            gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gbxBody).BeginInit();
            gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cboPlanEndDT_H).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboPlanStartDT_H).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grid1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtMaker).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtWorkerName).BeginInit();
            SuspendLayout();
            gbxHeader.ContentPadding.Bottom = 2;
            gbxHeader.ContentPadding.Left = 2;
            gbxHeader.ContentPadding.Right = 2;
            gbxHeader.ContentPadding.Top = 4;
            gbxHeader.Controls.Add(txtWorkerName);
            gbxHeader.Controls.Add(txtMaker);
            gbxHeader.Controls.Add(lblWorkerID);
            gbxHeader.Controls.Add(lbl);
            gbxHeader.Controls.Add(cboPlanStartDT_H);
            gbxHeader.Controls.Add(lblPlanDT);
            gbxHeader.Controls.Add(cboPlanEndDT_H);
            gbxHeader.Controls.SetChildIndex(cboPlanEndDT_H, 0);
            gbxHeader.Controls.SetChildIndex(lblPlanDT, 0);
            gbxHeader.Controls.SetChildIndex(cboPlanStartDT_H, 0);
            gbxHeader.Controls.SetChildIndex(lbl, 0);
            gbxHeader.Controls.SetChildIndex(lblWorkerID, 0);
            gbxHeader.Controls.SetChildIndex(txtMaker, 0);
            gbxHeader.Controls.SetChildIndex(txtWorkerName, 0);
            gbxBody.ContentPadding.Bottom = 4;
            gbxBody.ContentPadding.Left = 4;
            gbxBody.ContentPadding.Right = 4;
            gbxBody.ContentPadding.Top = 6;
            gbxBody.Controls.Add(grid1);
            appearance.FontData.BoldAsString = "False";
            appearance.FontData.UnderlineAsString = "False";
            appearance.ForeColor = System.Drawing.Color.Black;
            appearance.TextHAlignAsString = "Center";
            appearance.TextVAlignAsString = "Middle";
            lbl.Appearance = appearance;
            lbl.DbField = null;
            lbl.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lbl.Location = new System.Drawing.Point(230, 35);
            lbl.Name = "lbl";
            lbl.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lbl.Size = new System.Drawing.Size(20, 26);
            lbl.TabIndex = 17;
            lbl.Text = "~";
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            lblPlanDT.Appearance = appearance2;
            lblPlanDT.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            lblPlanDT.DbField = null;
            lblPlanDT.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblPlanDT.Location = new System.Drawing.Point(110, 10);
            lblPlanDT.Name = "lblPlanDT";
            lblPlanDT.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblPlanDT.Size = new System.Drawing.Size(145, 25);
            lblPlanDT.TabIndex = 16;
            lblPlanDT.Text = "조회기간";
            appearance3.FontData.Name = "맑은 고딕";
            appearance3.FontData.SizeInPoints = 10f;
            cboPlanEndDT_H.Appearance = appearance3;
            cboPlanEndDT_H.AutoSize = false;
            cboPlanEndDT_H.DateButtons.Add(dateButton);
            cboPlanEndDT_H.Location = new System.Drawing.Point(250, 35);
            cboPlanEndDT_H.Name = "cboPlanEndDT_H";
            cboPlanEndDT_H.NonAutoSizeHeight = 26;
            cboPlanEndDT_H.Size = new System.Drawing.Size(120, 26);
            cboPlanEndDT_H.TabIndex = 15;
            appearance4.FontData.Name = "맑은 고딕";
            appearance4.FontData.SizeInPoints = 10f;
            cboPlanStartDT_H.Appearance = appearance4;
            cboPlanStartDT_H.AutoSize = false;
            cboPlanStartDT_H.DateButtons.Add(dateButton2);
            cboPlanStartDT_H.Location = new System.Drawing.Point(110, 35);
            cboPlanStartDT_H.Name = "cboPlanStartDT_H";
            cboPlanStartDT_H.NonAutoSizeHeight = 26;
            cboPlanStartDT_H.Size = new System.Drawing.Size(120, 26);
            cboPlanStartDT_H.TabIndex = 14;
            grid1.AutoResizeColumn = true;
            grid1.AutoUserColumn = true;
            grid1.ContextMenuCopyEnabled = true;
            grid1.ContextMenuDeleteEnabled = false;
            grid1.ContextMenuExcelEnabled = true;
            grid1.ContextMenuInsertEnabled = false;
            grid1.ContextMenuPasteEnabled = true;
            grid1.DeleteButtonEnable = true;
            appearance5.BorderColor = System.Drawing.Color.FromArgb(224, 224, 224);
            grid1.DisplayLayout.Appearance = appearance5;
            grid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance6.BackColor = System.Drawing.Color.Gray;
            grid1.DisplayLayout.CaptionAppearance = appearance6;
            grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.RoyalBlue;
            grid1.DisplayLayout.GroupByBox.Hidden = true;
            grid1.DisplayLayout.InterBandSpacing = 2;
            grid1.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance7.BackColor = System.Drawing.Color.RoyalBlue;
            appearance7.FontData.BoldAsString = "True";
            appearance7.ForeColor = System.Drawing.Color.White;
            grid1.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.All;
            grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010ScrollbarButton;
            appearance8.BackColor = System.Drawing.Color.DimGray;
            appearance8.BackColor2 = System.Drawing.Color.Silver;
            appearance8.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.BorderColor = System.Drawing.Color.White;
            appearance8.FontData.BoldAsString = "True";
            appearance8.ForeColor = System.Drawing.Color.White;
            grid1.DisplayLayout.Override.HeaderAppearance = appearance8;
            grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance9.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            appearance9.BackColor2 = System.Drawing.Color.Gray;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            grid1.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance9;
            grid1.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
            grid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.RowConnectorColor = System.Drawing.Color.Silver;
            grid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            grid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            grid1.EnterNextRowEnable = true;
            grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75f);
            grid1.Location = new System.Drawing.Point(6, 6);
            grid1.Name = "grid1";
            grid1.Size = new System.Drawing.Size(1124, 743);
            grid1.TabIndex = 3;
            grid1.Text = "DE";
            grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            appearance10.BorderColor = System.Drawing.Color.FromArgb(224, 224, 224);
            appearance10.FontData.BoldAsString = "False";
            appearance10.FontData.UnderlineAsString = "False";
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.TextHAlignAsString = "Left";
            appearance10.TextVAlignAsString = "Middle";
            lblWorkerID.Appearance = appearance10;
            lblWorkerID.DbField = null;
            lblWorkerID.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblWorkerID.Location = new System.Drawing.Point(416, 9);
            lblWorkerID.Name = "lblWorkerID";
            lblWorkerID.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblWorkerID.Size = new System.Drawing.Size(145, 25);
            lblWorkerID.TabIndex = 29;
            lblWorkerID.Text = "사용자";
            appearance11.FontData.BoldAsString = "False";
            appearance11.FontData.UnderlineAsString = "False";
            appearance11.ForeColor = System.Drawing.Color.Black;
            txtMaker.Appearance = appearance11;
            txtMaker.AutoSize = false;
            txtMaker.btnImgType = WIZ.Control.SBtnTextEditor.ButtonImgTypeEnum.Type1;
            txtMaker.btnWidth = 26;
            txtMaker.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtMaker.Location = new System.Drawing.Point(416, 35);
            txtMaker.Name = "txtMaker";
            txtMaker.RequireFlag = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            txtMaker.RequirePop = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            txtMaker.Size = new System.Drawing.Size(150, 26);
            txtMaker.TabIndex = 32;
            txtMaker.ButtonClick += new System.EventHandler(txtMaker_ButtonClick);
            appearance12.FontData.BoldAsString = "False";
            appearance12.FontData.UnderlineAsString = "False";
            appearance12.ForeColor = System.Drawing.Color.Black;
            txtWorkerName.Appearance = appearance12;
            txtWorkerName.AutoSize = false;
            txtWorkerName.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtWorkerName.Location = new System.Drawing.Point(568, 35);
            txtWorkerName.Name = "txtWorkerName";
            txtWorkerName.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtWorkerName.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtWorkerName.Size = new System.Drawing.Size(200, 26);
            txtWorkerName.TabIndex = 243;
            base.ClientSize = new System.Drawing.Size(1136, 825);
            base.Name = "SY0040";
            base.Load += new System.EventHandler(SY0040_Load);
            ((System.ComponentModel.ISupportInitialize)gbxHeader).EndInit();
            gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gbxBody).EndInit();
            gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cboPlanEndDT_H).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboPlanStartDT_H).EndInit();
            ((System.ComponentModel.ISupportInitialize)grid1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtMaker).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtWorkerName).EndInit();
            ResumeLayout(false);
        }
    }
}

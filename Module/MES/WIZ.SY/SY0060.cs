using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinSchedule;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using WIZ.Control;
using WIZ.Forms;

namespace WIZ.SY
{
    public class SY0060 : BaseMDIChildForm
    {
        private UltraGridUtil _GridUtil = new UltraGridUtil();

        private Common _Com = new Common();

        private DataSet rtnDsTemp = new DataSet();

        private DataTable rtnDtTemp = new DataTable();

        private new IContainer components = null;

        private SLabel lbl;

        private UltraCalendarCombo dtStart_H;

        private SLabel lblPlanDT;

        private UltraCalendarCombo dtEnd_H;

        private WIZ.Control.Grid grid1;

        public SY0060()
        {
            InitializeComponent();
        }

        private void SY0060_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(grid1, true, true, true, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "DATE", "발생일자", false, GridColDataType_emu.DateTime, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "NAME", "ERROR PROCEDURE", false, GridColDataType_emu.VarChar, 180, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ERROR", "ERROR NO", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ELINE", "ERROR LINE", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MESSAGE", "ERROR MESSAGE", false, GridColDataType_emu.VarChar, 700, true, false);
            _GridUtil.SetColumnTextHAlign(grid1, "MESSAGE", HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "NAME", HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "ERROR", HAlign.Right);
            _GridUtil.SetColumnTextHAlign(grid1, "ELINE", HAlign.Right);
            _GridUtil.SetInitUltraGridBind(grid1);
            grid1.DisplayLayout.Override.RowSizing = RowSizing.AutoFree;
            grid1.DisplayLayout.Bands[0].Columns["MESSAGE"].CellMultiLine = DefaultableBoolean.True;
            rtnDtTemp = (DataTable)grid1.DataSource;
        }

        public override void DoInquire()
        {
            DBHelper dBHelper = new DBHelper(completedClose: false);
            try
            {
                _GridUtil.Grid_Clear(grid1);
                base.DoInquire();
                string value = $"{dtStart_H.Value:yyyy-MM-dd}";
                string value2 = $"{dtEnd_H.Value:yyyy-MM-dd}";
                rtnDtTemp = dBHelper.FillTable("USP_SY0060_S1", CommandType.StoredProcedure, dBHelper.CreateParameter("AS_SDATE", value, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_EDATE", value2, DbType.String, ParameterDirection.Input));
                grid1.DataSource = rtnDtTemp;
                grid1.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            lbl = new WIZ.Control.SLabel();
            dtStart_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            lblPlanDT = new WIZ.Control.SLabel();
            dtEnd_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            grid1 = new WIZ.Control.Grid(components);
            ((System.ComponentModel.ISupportInitialize)gbxHeader).BeginInit();
            gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gbxBody).BeginInit();
            gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtStart_H).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtEnd_H).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grid1).BeginInit();
            SuspendLayout();
            gbxHeader.ContentPadding.Bottom = 2;
            gbxHeader.ContentPadding.Left = 2;
            gbxHeader.ContentPadding.Right = 2;
            gbxHeader.ContentPadding.Top = 4;
            gbxHeader.Controls.Add(lbl);
            gbxHeader.Controls.Add(dtStart_H);
            gbxHeader.Controls.Add(lblPlanDT);
            gbxHeader.Controls.Add(dtEnd_H);
            gbxHeader.Size = new System.Drawing.Size(1035, 70);
            gbxHeader.Controls.SetChildIndex(dtEnd_H, 0);
            gbxHeader.Controls.SetChildIndex(lblPlanDT, 0);
            gbxHeader.Controls.SetChildIndex(dtStart_H, 0);
            gbxHeader.Controls.SetChildIndex(lbl, 0);
            gbxBody.ContentPadding.Bottom = 4;
            gbxBody.ContentPadding.Left = 4;
            gbxBody.ContentPadding.Right = 4;
            gbxBody.ContentPadding.Top = 6;
            gbxBody.Controls.Add(grid1);
            gbxBody.Size = new System.Drawing.Size(1035, 407);
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
            lbl.TabIndex = 21;
            lbl.Text = "~";
            appearance2.FontData.Name = "맑은 고딕";
            appearance2.FontData.SizeInPoints = 10f;
            dtStart_H.Appearance = appearance2;
            dtStart_H.AutoSize = false;
            dtStart_H.DateButtons.Add(dateButton);
            dtStart_H.Location = new System.Drawing.Point(110, 35);
            dtStart_H.Name = "dtStart_H";
            dtStart_H.NonAutoSizeHeight = 26;
            dtStart_H.Size = new System.Drawing.Size(120, 26);
            dtStart_H.TabIndex = 18;
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            lblPlanDT.Appearance = appearance3;
            lblPlanDT.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            lblPlanDT.DbField = null;
            lblPlanDT.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblPlanDT.Location = new System.Drawing.Point(110, 10);
            lblPlanDT.Name = "lblPlanDT";
            lblPlanDT.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblPlanDT.Size = new System.Drawing.Size(145, 25);
            lblPlanDT.TabIndex = 20;
            lblPlanDT.Text = "오류 발생 일자";
            appearance4.FontData.Name = "맑은 고딕";
            appearance4.FontData.SizeInPoints = 10f;
            dtEnd_H.Appearance = appearance4;
            dtEnd_H.AutoSize = false;
            dtEnd_H.DateButtons.Add(dateButton2);
            dtEnd_H.Location = new System.Drawing.Point(250, 35);
            dtEnd_H.Name = "dtEnd_H";
            dtEnd_H.NonAutoSizeHeight = 26;
            dtEnd_H.Size = new System.Drawing.Size(120, 26);
            dtEnd_H.TabIndex = 19;
            grid1.AutoResizeColumn = true;
            grid1.AutoUserColumn = true;
            grid1.ContextMenuCopyEnabled = true;
            grid1.ContextMenuDeleteEnabled = true;
            grid1.ContextMenuExcelEnabled = true;
            grid1.ContextMenuInsertEnabled = true;
            grid1.ContextMenuPasteEnabled = true;
            grid1.DeleteButtonEnable = true;
            grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            grid1.DisplayLayout.GroupByBox.Hidden = true;
            grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.All;
            grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            grid1.EnterNextRowEnable = true;
            grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75f);
            grid1.Location = new System.Drawing.Point(6, 6);
            grid1.Name = "grid1";
            grid1.Size = new System.Drawing.Size(1023, 395);
            grid1.TabIndex = 32;
            grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus;
            grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(1035, 477);
            base.Name = "SY0060";
            Text = "DB오류정보";
            base.Load += new System.EventHandler(SY0060_Load);
            ((System.ComponentModel.ISupportInitialize)gbxHeader).EndInit();
            gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gbxBody).EndInit();
            gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtStart_H).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtEnd_H).EndInit();
            ((System.ComponentModel.ISupportInitialize)grid1).EndInit();
            ResumeLayout(false);
        }
    }
}

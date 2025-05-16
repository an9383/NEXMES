using Infragistics.Win;
using Infragistics.Win.Misc;
using System;
using System.ComponentModel;
using System.Data;
using WIZ.Forms;

namespace WIZ.SY
{
    public class POP_SY1600 : BasePopupForm
    {
        private UltraGridUtil _GridUtil = new UltraGridUtil();

        private Common _Com = new Common();

        private DataTable _dtControl = new DataTable();

        private IContainer components = null;

        private UltraGroupBox gbxHeader;

        private UltraButton btnClose;

        private UltraButton btnSave;

        private UltraGroupBox ultraGroupBox2;

        private WIZ.Control.Grid grid1;

        private UltraButton btnDelete;

        public POP_SY1600(DataTable dControl)
        {
            InitializeComponent();
            _dtControl = dControl;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count != 0)
            {
                grid1.DeleteRow();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dataTable = grid1.chkChange();
            if (dataTable != null)
            {
                DBHelper dBHelper = new DBHelper("", bTrans: true);
                try
                {
                    Focus();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        switch (row.RowState)
                        {
                            case DataRowState.Added:
                                dBHelper.ExecuteNoneQuery("USP_ZZ9100_I1", CommandType.StoredProcedure, false, false, dBHelper.CreateParameter("Lang", "KO", DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("wKey", Convert.ToString(row["wKey"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("OpKey", Convert.ToString(row["OpKey"]), DbType.String, ParameterDirection.Input));
                                break;
                            case DataRowState.Modified:
                                dBHelper.ExecuteNoneQuery("USP_ZZ9100_I1", CommandType.StoredProcedure, false, false, dBHelper.CreateParameter("Lang", "KO", DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("wKey", Convert.ToString(row["wKey"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("OpKey", Convert.ToString(row["OpKey"]), DbType.String, ParameterDirection.Input));
                                break;
                        }
                        grid1.SetRowError(row, dBHelper.RSMSG, dBHelper.RSCODE);
                    }
                    grid1.SetAcceptChanges();
                    dBHelper.Commit();
                }
                catch (Exception)
                {
                    base.CancelProcess = true;
                    dBHelper.Rollback();
                }
                finally
                {
                    dBHelper.Close();
                    Close();
                }
            }
        }

        private void POP_SY1600_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "wKey", "Key문장", false, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "OpKey", "구분", false, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ControlID", "컨트롤ID", false, GridColDataType_emu.VarChar, 120, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ControlName", "컨트롤명", false, GridColDataType_emu.VarChar, 250, 1000, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
            grid1.DataSource = _dtControl;
            grid1.DataBind();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            gbxHeader = new Infragistics.Win.Misc.UltraGroupBox();
            btnClose = new Infragistics.Win.Misc.UltraButton();
            btnDelete = new Infragistics.Win.Misc.UltraButton();
            btnSave = new Infragistics.Win.Misc.UltraButton();
            ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            grid1 = new WIZ.Control.Grid(components);
            ((System.ComponentModel.ISupportInitialize)gbxHeader).BeginInit();
            gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ultraGroupBox2).BeginInit();
            ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid1).BeginInit();
            SuspendLayout();
            gbxHeader.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            gbxHeader.Controls.Add(btnClose);
            gbxHeader.Controls.Add(btnDelete);
            gbxHeader.Controls.Add(btnSave);
            gbxHeader.Dock = System.Windows.Forms.DockStyle.Top;
            gbxHeader.Location = new System.Drawing.Point(0, 0);
            gbxHeader.Margin = new System.Windows.Forms.Padding(0);
            gbxHeader.Name = "gbxHeader";
            gbxHeader.Size = new System.Drawing.Size(743, 68);
            gbxHeader.TabIndex = 0;
            btnClose.Location = new System.Drawing.Point(656, 5);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(75, 54);
            btnClose.TabIndex = 5;
            btnClose.Text = "취 소";
            btnClose.Click += new System.EventHandler(btnClose_Click);
            btnDelete.Location = new System.Drawing.Point(474, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(75, 54);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "선택 삭제";
            btnDelete.Click += new System.EventHandler(btnDelete_Click);
            btnSave.Location = new System.Drawing.Point(575, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(75, 54);
            btnSave.TabIndex = 4;
            btnSave.Text = "저 장";
            btnSave.Click += new System.EventHandler(btnSave_Click);
            ultraGroupBox2.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            ultraGroupBox2.Controls.Add(grid1);
            ultraGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            ultraGroupBox2.Location = new System.Drawing.Point(0, 68);
            ultraGroupBox2.Margin = new System.Windows.Forms.Padding(0);
            ultraGroupBox2.Name = "ultraGroupBox2";
            ultraGroupBox2.Size = new System.Drawing.Size(743, 415);
            ultraGroupBox2.TabIndex = 1;
            grid1.AutoResizeColumn = true;
            grid1.AutoUserColumn = true;
            grid1.ContextMenuCopyEnabled = true;
            grid1.ContextMenuDeleteEnabled = true;
            grid1.ContextMenuExcelEnabled = true;
            grid1.ContextMenuInsertEnabled = true;
            grid1.ContextMenuPasteEnabled = true;
            grid1.DeleteButtonEnable = true;
            appearance.BorderColor = System.Drawing.Color.FromArgb(224, 224, 224);
            grid1.DisplayLayout.Appearance = appearance;
            grid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance2.BackColor = System.Drawing.Color.Gray;
            grid1.DisplayLayout.CaptionAppearance = appearance2;
            grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.RoyalBlue;
            grid1.DisplayLayout.GroupByBox.Hidden = true;
            grid1.DisplayLayout.InterBandSpacing = 2;
            grid1.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance3.BackColor = System.Drawing.Color.RoyalBlue;
            appearance3.FontData.BoldAsString = "True";
            appearance3.ForeColor = System.Drawing.Color.White;
            grid1.DisplayLayout.Override.ActiveRowAppearance = appearance3;
            grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.All;
            grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010ScrollbarButton;
            appearance4.BackColor = System.Drawing.Color.DimGray;
            appearance4.BackColor2 = System.Drawing.Color.Silver;
            appearance4.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.BorderColor = System.Drawing.Color.White;
            appearance4.FontData.BoldAsString = "True";
            appearance4.ForeColor = System.Drawing.Color.White;
            grid1.DisplayLayout.Override.HeaderAppearance = appearance4;
            grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance5.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            appearance5.BackColor2 = System.Drawing.Color.Gray;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            grid1.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance5;
            grid1.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
            grid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.RowConnectorColor = System.Drawing.Color.Silver;
            grid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            grid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            grid1.EnterNextRowEnable = true;
            grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75f);
            grid1.Location = new System.Drawing.Point(2, 0);
            grid1.Name = "grid1";
            grid1.Size = new System.Drawing.Size(739, 413);
            grid1.TabIndex = 0;
            grid1.Text = "grid1";
            grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 12f);
            base.ClientSize = new System.Drawing.Size(743, 483);
            base.Controls.Add(ultraGroupBox2);
            base.Controls.Add(gbxHeader);
            base.Name = "POP_SY1600";
            Text = "다국어 처리";
            base.Load += new System.EventHandler(POP_SY1600_Load);
            ((System.ComponentModel.ISupportInitialize)gbxHeader).EndInit();
            gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ultraGroupBox2).EndInit();
            ultraGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grid1).EndInit();
            ResumeLayout(false);
        }
    }
}

using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using WIZ.Control;
using WIZ.Forms;

namespace WIZ.SY
{
    public class POP_TSY0031 : BasePopupForm
    {
        private UltraGridUtil _GridUtil = new UltraGridUtil();

        private Common _Common = new Common();

        private DataTable _DtTemp = new DataTable();

        private IContainer components = null;

        private Panel panel1;

        private Panel panel2;

        private WIZ.Control.Grid Grid1;

        private SLabel lblGRPName;

        private SLabel lblGRPID;

        private UltraButton btnFind;

        private UltraButton btnClose;

        private WIZ.Control.STextBox txtGRPID;

        private WIZ.Control.STextBox txtGRPName;

        public POP_TSY0031(string[] param)
        {
            InitializeComponent();
            txtGRPID.Text = param[4];
            txtGRPName.Text = param[5];
        }

        private void POP_TSY0031_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(Grid1);
            _GridUtil.InitColumnUltraGrid(Grid1, "GRPID", "그룹ID", false, GridColDataType_emu.VarChar, 150, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(Grid1, "GRPNAME", "그룹명", false, GridColDataType_emu.VarChar, 250, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(Grid1);
            search();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            string sGRPID = txtGRPID.Text.Trim();
            string sGRPNAME = txtGRPName.Text.Trim();
            DataTable dataSource = SEL_TSY0080(sGRPID, sGRPNAME);
            Grid1.DataSource = dataSource;
            Grid1.DataBind();
        }

        private void Grid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("GRPID", typeof(string));
            dataTable.Columns.Add("GRPNAME", typeof(string));
            if (Grid1.Selected.Rows.Count == 0)
            {
                dataTable.Rows.Add(e.Row.Cells["GRPID"].Value, e.Row.Cells["GRPNAME"].Value);
            }
            else
            {
                foreach (UltraGridRow row in Grid1.Selected.Rows)
                {
                    dataTable.Rows.Add(row.Cells["GRPID"].Value, row.Cells["GRPNAME"].Value);
                }
            }
            base.Tag = dataTable;
            Close();
        }

        private void txtWorkerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                search();
            }
        }

        private void txtWorkerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                search();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private DataTable SEL_TSY0080(string sGRPID, string sGRPNAME)
        {
            DBHelper dBHelper = new DBHelper(completedClose: false);
            try
            {
                return dBHelper.FillTable("USP_SY0080_S1", CommandType.StoredProcedure, dBHelper.CreateParameter("GRPID", sGRPID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("GRPName", sGRPNAME, DbType.String, ParameterDirection.Input));
            }
            catch (Exception)
            {
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

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WIZ.SY.POP_TSY0031));
            panel1 = new System.Windows.Forms.Panel();
            lblGRPName = new WIZ.Control.SLabel();
            btnFind = new Infragistics.Win.Misc.UltraButton();
            btnClose = new Infragistics.Win.Misc.UltraButton();
            lblGRPID = new WIZ.Control.SLabel();
            panel2 = new System.Windows.Forms.Panel();
            Grid1 = new WIZ.Control.Grid(components);
            txtGRPID = new WIZ.Control.STextBox(components);
            txtGRPName = new WIZ.Control.STextBox(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Grid1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtGRPID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtGRPName).BeginInit();
            SuspendLayout();
            panel1.Controls.Add(txtGRPName);
            panel1.Controls.Add(txtGRPID);
            panel1.Controls.Add(lblGRPName);
            panel1.Controls.Add(btnFind);
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(lblGRPID);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(675, 73);
            panel1.TabIndex = 0;
            appearance.FontData.BoldAsString = "False";
            appearance.FontData.SizeInPoints = 9.75f;
            appearance.FontData.UnderlineAsString = "False";
            appearance.ForeColor = System.Drawing.Color.Black;
            appearance.TextHAlignAsString = "Left";
            appearance.TextVAlignAsString = "Middle";
            lblGRPName.Appearance = appearance;
            lblGRPName.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            lblGRPName.DbField = null;
            lblGRPName.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblGRPName.Location = new System.Drawing.Point(173, 12);
            lblGRPName.Name = "lblGRPName";
            lblGRPName.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblGRPName.Size = new System.Drawing.Size(154, 25);
            lblGRPName.TabIndex = 0;
            lblGRPName.Text = "그룹명";
            btnFind.Font = new System.Drawing.Font("맑은 고딕", 16f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            btnFind.Location = new System.Drawing.Point(437, 8);
            btnFind.Name = "btnFind";
            btnFind.Size = new System.Drawing.Size(100, 54);
            btnFind.TabIndex = 6;
            btnFind.Text = "조회";
            btnFind.Click += new System.EventHandler(btnFind_Click);
            btnClose.Font = new System.Drawing.Font("맑은 고딕", 16f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            btnClose.Location = new System.Drawing.Point(543, 8);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(100, 54);
            btnClose.TabIndex = 6;
            btnClose.Text = "닫기";
            btnClose.Visible = false;
            btnClose.Click += new System.EventHandler(btnClose_Click);
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.SizeInPoints = 9.75f;
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            lblGRPID.Appearance = appearance2;
            lblGRPID.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            lblGRPID.DbField = null;
            lblGRPID.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblGRPID.Location = new System.Drawing.Point(34, 12);
            lblGRPID.Name = "lblGRPID";
            lblGRPID.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblGRPID.Size = new System.Drawing.Size(100, 25);
            lblGRPID.TabIndex = 0;
            lblGRPID.Text = "그룹ID";
            panel2.Controls.Add(Grid1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 73);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(675, 437);
            panel2.TabIndex = 1;
            Grid1.AutoResizeColumn = true;
            Grid1.AutoUserColumn = true;
            Grid1.ContextMenuCopyEnabled = true;
            Grid1.ContextMenuDeleteEnabled = true;
            Grid1.ContextMenuExcelEnabled = true;
            Grid1.ContextMenuInsertEnabled = true;
            Grid1.ContextMenuPasteEnabled = true;
            Grid1.DeleteButtonEnable = true;
            appearance3.BackColor = System.Drawing.SystemColors.Window;
            appearance3.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            Grid1.DisplayLayout.Appearance = appearance3;
            Grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            Grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            Grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.BorderColor = System.Drawing.SystemColors.Window;
            Grid1.DisplayLayout.GroupByBox.Appearance = appearance4;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            Grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance5;
            Grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            Grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance6.BackColor2 = System.Drawing.SystemColors.Control;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            Grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance6;
            Grid1.DisplayLayout.MaxColScrollRegions = 1;
            Grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            appearance7.ForeColor = System.Drawing.SystemColors.ControlText;
            Grid1.DisplayLayout.Override.ActiveCellAppearance = appearance7;
            appearance8.BackColor = System.Drawing.SystemColors.Highlight;
            appearance8.ForeColor = System.Drawing.SystemColors.HighlightText;
            Grid1.DisplayLayout.Override.ActiveRowAppearance = appearance8;
            Grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            Grid1.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.All;
            Grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            Grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            Grid1.DisplayLayout.Override.CardAreaAppearance = appearance9;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            Grid1.DisplayLayout.Override.CellAppearance = appearance10;
            Grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            Grid1.DisplayLayout.Override.CellPadding = 0;
            appearance11.BackColor = System.Drawing.SystemColors.Control;
            appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance11.BorderColor = System.Drawing.SystemColors.Window;
            Grid1.DisplayLayout.Override.GroupByRowAppearance = appearance11;
            appearance12.TextHAlignAsString = "Left";
            Grid1.DisplayLayout.Override.HeaderAppearance = appearance12;
            Grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            Grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            Grid1.DisplayLayout.Override.RowAppearance = appearance13;
            Grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance14.BackColor = System.Drawing.SystemColors.ControlLight;
            Grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance14;
            Grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            Grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            Grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            Grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            Grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            Grid1.EnterNextRowEnable = true;
            Grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            Grid1.Location = new System.Drawing.Point(0, 0);
            Grid1.Name = "Grid1";
            Grid1.Size = new System.Drawing.Size(675, 437);
            Grid1.TabIndex = 0;
            Grid1.Text = "grid1";
            Grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            Grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            Grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            Grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            Grid1.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(Grid1_DoubleClickRow);
            appearance15.FontData.BoldAsString = "False";
            appearance15.FontData.UnderlineAsString = "False";
            appearance15.ForeColor = System.Drawing.Color.Black;
            txtGRPID.Appearance = appearance15;
            txtGRPID.AutoSize = false;
            txtGRPID.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtGRPID.Location = new System.Drawing.Point(34, 37);
            txtGRPID.Name = "txtGRPID";
            txtGRPID.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtGRPID.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtGRPID.Size = new System.Drawing.Size(100, 25);
            txtGRPID.TabIndex = 248;
            appearance16.FontData.BoldAsString = "False";
            appearance16.FontData.UnderlineAsString = "False";
            appearance16.ForeColor = System.Drawing.Color.Black;
            txtGRPName.Appearance = appearance16;
            txtGRPName.AutoSize = false;
            txtGRPName.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtGRPName.Location = new System.Drawing.Point(173, 37);
            txtGRPName.Name = "txtGRPName";
            txtGRPName.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtGRPName.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtGRPName.Size = new System.Drawing.Size(154, 25);
            txtGRPName.TabIndex = 249;
            base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(675, 510);
            base.Controls.Add(panel2);
            base.Controls.Add(panel1);
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.Name = "POP_TSY0031";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "사용자그룹 정보";
            base.Load += new System.EventHandler(POP_TSY0031_Load);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Grid1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtGRPID).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtGRPName).EndInit();
            ResumeLayout(false);
        }
    }
}

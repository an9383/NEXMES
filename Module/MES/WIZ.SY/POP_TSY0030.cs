using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using WIZ.Control;
using WIZ.Forms;

namespace WIZ.SY
{
    public class POP_TSY0030 : BasePopupForm
    {
        private UltraGridUtil _GridUtil = new UltraGridUtil();

        private DataTable _DtTemp = new DataTable();

        private IContainer components = null;

        private Panel panel1;

        private Panel panel2;

        private WIZ.Control.Grid Grid1;

        private SLabel lblOpName;

        private SLabel lblOpCode;

        private SLabel lblUseFlag;

        private UltraComboEditor cboUseFlag_H;

        private UltraButton btnFind;

        private UltraButton btnSel;

        private WIZ.Control.STextBox txtWorkerID;

        private WIZ.Control.STextBox txtWorkerName;

        public POP_TSY0030(string[] param)
        {
            InitializeComponent();
            Common common = new Common();
            txtWorkerID.Text = param[4];
            txtWorkerName.Text = param[5];
            cboUseFlag_H.Text = ((param[6] == "") ? "ALL" : param[6]);
            DataTable dataTable = common.GET_BM0000_CODE("USEFLAG");
            Common.FillComboboxMaster(cboUseFlag_H, dataTable, dataTable.Columns["CODE_ID"].ColumnName, dataTable.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(Grid1, "UseFlag", dataTable, "CODE_ID", "CODE_NAME");
        }

        private void POP_TSY0030_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(Grid1);
            _GridUtil.InitColumnUltraGrid(Grid1, "WorkerID", "사용자ID", false, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(Grid1, "WorkerName", "사용자명", false, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, true, false, null, null, null, null, null);
            try
            {
                _GridUtil.SetInitUltraGridBind(Grid1);
            }
            catch (Exception)
            {
            }
            search();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            string empty = string.Empty;
            string empty2 = string.Empty;
            string sOPCode = "";
            string sLineCode = "";
            string sWorkCenterCode = "";
            string sWorkerID = txtWorkerID.Text.Trim();
            string sWorkerName = txtWorkerName.Text.Trim();
            string sUseFlag = Convert.ToString(cboUseFlag_H.Value);
            string sPlantCode = "";
            DataTable dataTable = new DataTable();
            _DtTemp = SEL_TSY0030(sPlantCode, sOPCode, sLineCode, sWorkCenterCode, sWorkerID, sWorkerName, sUseFlag);
            Grid1.DataSource = _DtTemp;
            Grid1.DataBind();
        }

        private void Grid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("WorkerID", typeof(string));
            dataTable.Columns.Add("WorkerName", typeof(string));
            if (Grid1.Selected.Rows.Count == 0)
            {
                dataTable.Rows.Add(e.Row.Cells["WorkerID"].Value, e.Row.Cells["WorkerName"].Value);
            }
            else
            {
                foreach (UltraGridRow row in Grid1.Selected.Rows)
                {
                    dataTable.Rows.Add(row.Cells["WorkerID"].Value, row.Cells["WorkerName"].Value);
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

        private void btnSel_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("WorkerID", typeof(string));
            dataTable.Columns.Add("WorkerName", typeof(string));
            if (Grid1.Selected.Rows.Count == 0)
            {
                dataTable.Rows.Add(Grid1.ActiveRow.Cells["WorkerID"].Value, Grid1.ActiveRow.Cells["WorkerName"].Value);
            }
            else
            {
                foreach (UltraGridRow row in Grid1.Selected.Rows)
                {
                    dataTable.Rows.Add(row.Cells["WorkerID"].Value, row.Cells["WorkerName"].Value);
                }
            }
            base.Tag = dataTable;
            Close();
        }

        private DataTable SEL_TSY0030(string sPlantCode, string sOPCode, string sLineCode, string sWorkCenterCode, string sWorkerID, string sWorkerName, string sUseFlag)
        {
            DBHelper dBHelper = new DBHelper(completedClose: false);
            try
            {
                return dBHelper.FillTable("USP_SY0030_POP", CommandType.StoredProcedure, dBHelper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("LineCode", sLineCode, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("WorkerID", sWorkerID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("WorkerName", sWorkerName, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));
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
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WIZ.SY.POP_TSY0030));
            panel1 = new System.Windows.Forms.Panel();
            cboUseFlag_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            btnFind = new Infragistics.Win.Misc.UltraButton();
            lblUseFlag = new WIZ.Control.SLabel();
            lblOpName = new WIZ.Control.SLabel();
            btnSel = new Infragistics.Win.Misc.UltraButton();
            lblOpCode = new WIZ.Control.SLabel();
            panel2 = new System.Windows.Forms.Panel();
            Grid1 = new WIZ.Control.Grid(components);
            txtWorkerID = new WIZ.Control.STextBox(components);
            txtWorkerName = new WIZ.Control.STextBox(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cboUseFlag_H).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Grid1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtWorkerID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtWorkerName).BeginInit();
            SuspendLayout();
            panel1.Controls.Add(txtWorkerName);
            panel1.Controls.Add(txtWorkerID);
            panel1.Controls.Add(cboUseFlag_H);
            panel1.Controls.Add(btnFind);
            panel1.Controls.Add(lblUseFlag);
            panel1.Controls.Add(lblOpName);
            panel1.Controls.Add(btnSel);
            panel1.Controls.Add(lblOpCode);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(675, 90);
            panel1.TabIndex = 0;
            cboUseFlag_H.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            cboUseFlag_H.Location = new System.Drawing.Point(371, 45);
            cboUseFlag_H.Name = "cboUseFlag_H";
            cboUseFlag_H.Size = new System.Drawing.Size(154, 26);
            cboUseFlag_H.TabIndex = 3;
            btnFind.Font = new System.Drawing.Font("맑은 고딕", 16f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            btnFind.Location = new System.Drawing.Point(537, 9);
            btnFind.Name = "btnFind";
            btnFind.Size = new System.Drawing.Size(117, 33);
            btnFind.TabIndex = 6;
            btnFind.Text = "조회";
            btnFind.Click += new System.EventHandler(btnFind_Click);
            appearance.FontData.BoldAsString = "False";
            appearance.FontData.SizeInPoints = 9.75f;
            appearance.FontData.UnderlineAsString = "False";
            appearance.ForeColor = System.Drawing.Color.Black;
            appearance.TextHAlignAsString = "Left";
            appearance.TextVAlignAsString = "Middle";
            lblUseFlag.Appearance = appearance;
            lblUseFlag.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            lblUseFlag.DbField = null;
            lblUseFlag.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblUseFlag.Location = new System.Drawing.Point(371, 21);
            lblUseFlag.Name = "lblUseFlag";
            lblUseFlag.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblUseFlag.Size = new System.Drawing.Size(154, 25);
            lblUseFlag.TabIndex = 0;
            lblUseFlag.Text = "사용유무";
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.SizeInPoints = 9.75f;
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            lblOpName.Appearance = appearance2;
            lblOpName.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            lblOpName.DbField = null;
            lblOpName.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblOpName.Location = new System.Drawing.Point(194, 21);
            lblOpName.Name = "lblOpName";
            lblOpName.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblOpName.Size = new System.Drawing.Size(154, 25);
            lblOpName.TabIndex = 0;
            lblOpName.Text = "사용자명";
            btnSel.Font = new System.Drawing.Font("맑은 고딕", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            btnSel.Location = new System.Drawing.Point(537, 48);
            btnSel.Name = "btnSel";
            btnSel.Size = new System.Drawing.Size(117, 33);
            btnSel.TabIndex = 6;
            btnSel.Text = "선택";
            btnSel.Visible = false;
            btnSel.Click += new System.EventHandler(btnSel_Click);
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.SizeInPoints = 9.75f;
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            lblOpCode.Appearance = appearance3;
            lblOpCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            lblOpCode.DbField = null;
            lblOpCode.Font = new System.Drawing.Font("맑은 고딕", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblOpCode.Location = new System.Drawing.Point(19, 21);
            lblOpCode.Name = "lblOpCode";
            lblOpCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblOpCode.Size = new System.Drawing.Size(154, 25);
            lblOpCode.TabIndex = 0;
            lblOpCode.Text = "사용자ID";
            panel2.Controls.Add(Grid1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 90);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(675, 420);
            panel2.TabIndex = 1;
            Grid1.AutoResizeColumn = true;
            Grid1.AutoUserColumn = true;
            Grid1.ContextMenuCopyEnabled = true;
            Grid1.ContextMenuDeleteEnabled = true;
            Grid1.ContextMenuExcelEnabled = true;
            Grid1.ContextMenuInsertEnabled = true;
            Grid1.ContextMenuPasteEnabled = true;
            Grid1.DeleteButtonEnable = true;
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            Grid1.DisplayLayout.Appearance = appearance4;
            Grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            Grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            Grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.BorderColor = System.Drawing.SystemColors.Window;
            Grid1.DisplayLayout.GroupByBox.Appearance = appearance5;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            Grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance6;
            Grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            Grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance7.BackColor2 = System.Drawing.SystemColors.Control;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
            Grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance7;
            Grid1.DisplayLayout.MaxColScrollRegions = 1;
            Grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            appearance8.ForeColor = System.Drawing.SystemColors.ControlText;
            Grid1.DisplayLayout.Override.ActiveCellAppearance = appearance8;
            appearance9.BackColor = System.Drawing.SystemColors.Highlight;
            appearance9.ForeColor = System.Drawing.SystemColors.HighlightText;
            Grid1.DisplayLayout.Override.ActiveRowAppearance = appearance9;
            Grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            Grid1.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.All;
            Grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            Grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            Grid1.DisplayLayout.Override.CardAreaAppearance = appearance10;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            Grid1.DisplayLayout.Override.CellAppearance = appearance11;
            Grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            Grid1.DisplayLayout.Override.CellPadding = 0;
            appearance12.BackColor = System.Drawing.SystemColors.Control;
            appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance12.BorderColor = System.Drawing.SystemColors.Window;
            Grid1.DisplayLayout.Override.GroupByRowAppearance = appearance12;
            appearance13.TextHAlignAsString = "Left";
            Grid1.DisplayLayout.Override.HeaderAppearance = appearance13;
            Grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            Grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance14.BackColor = System.Drawing.SystemColors.Window;
            appearance14.BorderColor = System.Drawing.Color.Silver;
            Grid1.DisplayLayout.Override.RowAppearance = appearance14;
            Grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance15.BackColor = System.Drawing.SystemColors.ControlLight;
            Grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance15;
            Grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            Grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            Grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            Grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            Grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            Grid1.EnterNextRowEnable = true;
            Grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            Grid1.Location = new System.Drawing.Point(0, 0);
            Grid1.Name = "Grid1";
            Grid1.Size = new System.Drawing.Size(675, 420);
            Grid1.TabIndex = 0;
            Grid1.Text = "grid1";
            Grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            Grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            Grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            Grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            Grid1.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(Grid1_DoubleClickRow);
            appearance16.FontData.BoldAsString = "False";
            appearance16.FontData.UnderlineAsString = "False";
            appearance16.ForeColor = System.Drawing.Color.Black;
            txtWorkerID.Appearance = appearance16;
            txtWorkerID.AutoSize = false;
            txtWorkerID.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtWorkerID.Location = new System.Drawing.Point(19, 46);
            txtWorkerID.Name = "txtWorkerID";
            txtWorkerID.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtWorkerID.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtWorkerID.Size = new System.Drawing.Size(154, 25);
            txtWorkerID.TabIndex = 247;
            appearance17.FontData.BoldAsString = "False";
            appearance17.FontData.UnderlineAsString = "False";
            appearance17.ForeColor = System.Drawing.Color.Black;
            txtWorkerName.Appearance = appearance17;
            txtWorkerName.AutoSize = false;
            txtWorkerName.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtWorkerName.Location = new System.Drawing.Point(194, 46);
            txtWorkerName.Name = "txtWorkerName";
            txtWorkerName.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtWorkerName.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtWorkerName.Size = new System.Drawing.Size(154, 25);
            txtWorkerName.TabIndex = 248;
            base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(675, 510);
            base.Controls.Add(panel2);
            base.Controls.Add(panel1);
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.Name = "POP_TSY0030";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "사용자정보";
            base.Load += new System.EventHandler(POP_TSY0030_Load);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cboUseFlag_H).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Grid1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtWorkerID).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtWorkerName).EndInit();
            ResumeLayout(false);
        }
    }
}

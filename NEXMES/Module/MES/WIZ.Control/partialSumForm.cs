using Infragistics.Win;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace WIZ.Control
{
    public class partialSumForm : Form
    {
        private UltraGridUtil _GridUtil = new UltraGridUtil();

        private IContainer components = null;

        private Panel panel1;

        private Label lbMsg;

        private DataGridView dataGridView1;

        private DataGridViewTextBoxColumn colName;

        private DataGridViewTextBoxColumn Sum;

        private DataGridViewTextBoxColumn Ave;

        private DataGridViewTextBoxColumn isum;

        private Grid grid1;

        public DataTable dataSource
        {
            set
            {
                grid1.DataSource = value;
                grid1.DataBind();
            }
        }

        public string Msg
        {
            set
            {
                lbMsg.Text = value;
            }
        }

        public partialSumForm()
        {
            InitializeComponent();
            Text = Common.getLangText("부분합계");
            _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "COLNAME", "컬럼명", false, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SUM", "합계", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "AVE", "평균", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "COL", "", false, GridColDataType_emu.VarChar, 1, 100, HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "ISUM", "", false, GridColDataType_emu.VarChar, 1, 100, HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
            grid1.DisplayLayout.Override.RowSelectorWidth = 10;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            panel1 = new System.Windows.Forms.Panel();
            lbMsg = new System.Windows.Forms.Label();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Ave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            isum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            grid1 = new WIZ.Control.Grid(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grid1).BeginInit();
            SuspendLayout();
            panel1.Controls.Add(lbMsg);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(416, 41);
            panel1.TabIndex = 0;
            lbMsg.AutoSize = true;
            lbMsg.Location = new System.Drawing.Point(55, 13);
            lbMsg.Name = "lbMsg";
            lbMsg.Size = new System.Drawing.Size(0, 12);
            lbMsg.TabIndex = 0;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            dataGridViewCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(colName, Sum, Ave, isum);
            dataGridView1.GridColor = System.Drawing.Color.White;
            dataGridView1.Location = new System.Drawing.Point(0, 343);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 10;
            dataGridView1.RowTemplate.Height = 23;
            dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new System.Drawing.Size(384, 81);
            dataGridView1.TabIndex = 1;
            colName.DataPropertyName = "colName";
            colName.HeaderText = "컬럼명";
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 200;
            Sum.DataPropertyName = "Sum";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            Sum.DefaultCellStyle = dataGridViewCellStyle2;
            Sum.HeaderText = "합계";
            Sum.Name = "Sum";
            Sum.ReadOnly = true;
            Ave.DataPropertyName = "Ave";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            Ave.DefaultCellStyle = dataGridViewCellStyle3;
            Ave.HeaderText = "평균";
            Ave.Name = "Ave";
            Ave.ReadOnly = true;
            isum.DataPropertyName = "isum";
            isum.HeaderText = "Column1";
            isum.Name = "isum";
            isum.ReadOnly = true;
            isum.Visible = false;
            grid1.AutoResizeColumn = true;
            grid1.AutoUserColumn = true;
            grid1.ContextMenuCopyEnabled = true;
            grid1.ContextMenuDeleteEnabled = true;
            grid1.ContextMenuExcelEnabled = true;
            grid1.ContextMenuInsertEnabled = true;
            grid1.ContextMenuPasteEnabled = true;
            grid1.DeleteButtonEnable = true;
            appearance.BackColor = System.Drawing.SystemColors.Window;
            appearance.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            grid1.DisplayLayout.Appearance = appearance;
            grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            grid1.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            grid1.DisplayLayout.MaxColScrollRegions = 1;
            grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            grid1.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            grid1.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Override.AllowMultiCellOperations = (Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste);
            grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            grid1.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            grid1.DisplayLayout.Override.CellAppearance = appearance8;
            grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            grid1.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            grid1.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            grid1.DisplayLayout.Override.HeaderAppearance = appearance10;
            grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            grid1.DisplayLayout.Override.RowAppearance = appearance11;
            grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            grid1.EnterNextRowEnable = true;
            grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            grid1.Location = new System.Drawing.Point(0, 41);
            grid1.Name = "grid1";
            grid1.Size = new System.Drawing.Size(416, 233);
            grid1.TabIndex = 2;
            grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(416, 274);
            base.Controls.Add(grid1);
            base.Controls.Add(dataGridView1);
            base.Controls.Add(panel1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            base.Name = "partialSumForm";
            Text = "부분합계";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)grid1).EndInit();
            ResumeLayout(false);
        }
    }
}

using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using WIZ.Control;
using WIZ.Forms;
using WIZ.PopManager;

namespace WIZ.SY
{
    public class SY0201Y : BasePopupForm
    {
        private string[] argument;

        private UltraGridUtil _GridUtil = new UltraGridUtil();

        private DataTable _DtTemp = new DataTable();

        private string SystemID = "";

        private string sType = string.Empty;

        private IContainer components = null;

        private Panel panel1;

        private Button bntDel;

        private Button bntAdd;

        private TextBox txtWorkerID;

        private TextBox txtWorkerName;

        private SLabel lblWorker;

        private Button btnSave;

        private Button btnClose;

        private WIZ.Control.Grid grid1;

        private UltraCheckEditor chkSystem;

        public SY0201Y()
        {
            InitializeComponent();
        }

        public SY0201Y(string[] param)
        {
            InitializeComponent();
            argument = new string[param.Length];
            for (int i = 0; i < param.Length; i++)
            {
                argument[i] = param[i];
                switch (i)
                {
                    case 0:
                        txtWorkerID.Text = argument[0];
                        break;
                    case 1:
                        txtWorkerName.Text = argument[1];
                        break;
                    case 3:
                        SystemID = argument[3];
                        break;
                    case 4:
                        sType = argument[4];
                        break;
                }
            }
        }

        private void SY0201_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(grid1);
            string caption = "사용자ID";
            string caption2 = "사용자명";
            if (sType.Equals("G"))
            {
                caption = "그룹ID";
                caption2 = "그룹명";
            }
            _GridUtil.InitColumnUltraGrid(grid1, "WorkerID", caption, false, GridColDataType_emu.VarChar, 100, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkerName", caption2, false, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkSystem_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSystem.Checked)
            {
                txtWorkerID.Text = "SYSTEM";
                txtWorkerName.Text = "SYSTEM";
            }
            else
            {
                txtWorkerID.Text = argument[0];
                txtWorkerName.Text = argument[1];
            }
        }

        private void bntAdd_Click(object sender, EventArgs e)
        {
            PopManagerBase popManagerBase = new PopManagerBase();
            DataTable dataTable = popManagerBase.OpenPopupShow("WIZ.PopUp", "POP_TSY0200", "사용자 검색", new string[7]
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
                _DtTemp = (DataTable)grid1.DataSource;
                int pos = 0;
                if (grid1.ActiveRow != null)
                {
                    pos = grid1.ActiveRow.Index + 1;
                }
                foreach (DataRow row in dataTable.Rows)
                {
                    DataRow dataRow2 = _DtTemp.NewRow();
                    dataRow2["WorkerID"] = row["WorkerID"];
                    dataRow2["WorkerName"] = row["WorkerName"];
                    _DtTemp.Rows.InsertAt(dataRow2, pos);
                }
            }
        }

        private void bntDel_Click(object sender, EventArgs e)
        {
            int num = (grid1.ActiveRow != null) ? grid1.ActiveRow.Index : 0;
            if (num >= 0)
            {
                UltraGridUtil.GridRowDelete(grid1, num);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogForm dialogForm = new DialogForm(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG"));
            dialogForm.ShowDialog();
            if (dialogForm.DialogResult == DialogResult.OK)
            {
                insert();
                Close();
            }
        }

        private void grid1_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            grid_POP_UP();
        }

        private void grid1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                grid_POP_UP();
            }
        }

        private void grid_POP_UP()
        {
            int index = grid1.ActiveRow.Index;
            string sUseFlag = "Y";
            string sWorkerID = grid1.Rows[index].Cells["WorkerID"].Text.Trim();
            string sWorkerName = grid1.Rows[index].Cells["WorkerName"].Text.Trim();
            if (grid1.ActiveCell.Column.ToString().ToUpper() == "WORKERID" || grid1.ActiveCell.Column.ToString().ToUpper() == "WORKERNAME")
            {
                TSY0200_POP_Grid("", "", "", "", sWorkerID, sWorkerName, sUseFlag, grid1, "WorkerID", "WorkerName");
            }
        }

        public void TSY0200_POP_Grid(string sPlantCode, string sOPCode, string sLineCode, string sWorkCenterCode, string sWorkerID, string sWorkerName, string sUseFlag, UltraGrid Grid, string Column1, string Column2)
        {
            try
            {
                DBHelper dBHelper = new DBHelper(completedClose: true);
                DataTable dataTable = dBHelper.FillTable("USP_SY0200_POP", CommandType.StoredProcedure, dBHelper.CreateParameter("PlantCode", sPlantCode, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("OPCode", sOPCode, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("LineCode", sLineCode, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("WorkCenterCode", sWorkCenterCode, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("WorkerID", sWorkerID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("WorkerName", sWorkerName, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("UseFlag", sUseFlag, DbType.String, ParameterDirection.Input));
                if (dataTable.Rows.Count == 1)
                {
                    Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(dataTable.Rows[0]["WorkerID"]);
                    Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(dataTable.Rows[0]["WorkerName"]);
                }
                else
                {
                    Grid.ActiveRow.Cells[Column1].Value = string.Empty;
                    Grid.ActiveRow.Cells[Column2].Value = string.Empty;
                    PopManagerBase popManagerBase = new PopManagerBase();
                    dataTable = popManagerBase.OpenPopupShow("WIZ.PopUp", "POP_TSY0200", Common.getLangText("사용자 검색"), new string[7]
                    {
                        sPlantCode,
                        sOPCode,
                        sLineCode,
                        sWorkCenterCode,
                        sWorkerID,
                        sWorkerName,
                        sUseFlag
                    });
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        Grid.ActiveRow.Cells[Column1].Value = Convert.ToString(dataTable.Rows[0]["WorkerID"]);
                        Grid.ActiveRow.Cells[Column2].Value = Convert.ToString(dataTable.Rows[0]["WorkerName"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageForm messageForm = new MessageForm(ex);
                messageForm.ShowDialog();
            }
        }

        private void insert()
        {
            try
            {
                int count = grid1.Rows.Count;
                string code = string.Empty;
                string mesg = string.Empty;
                for (int i = 0; i < count; i++)
                {
                    string i_WorkerID = grid1.Rows[i].Cells["WorkerID"].Value.ToString();
                    INS_TSY0201(i_WorkerID, ref code, ref mesg);
                }
                if (code == "S")
                {
                    DialogForm dialogForm = new DialogForm("C:R00005", DialogForm.DialogType.OK);
                    dialogForm.ShowDialog();
                }
            }
            catch (Exception)
            {
            }
        }

        public void INS_TSY0201(string I_WorkerID, ref string code, ref string mesg)
        {
            DBHelper dBHelper = new DBHelper(completedClose: false);
            try
            {
                if (argument[2] == "AUTH")
                {
                    dBHelper.ExecuteNoneQuery("USP_SY0200_P2", CommandType.StoredProcedure, dBHelper.CreateParameter("FromWorkerID", txtWorkerID.Text, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("ToWorkerID", I_WorkerID, DbType.String, ParameterDirection.Input));
                }
                else
                {
                    dBHelper.ExecuteNoneQuery("USP_SY0200_P1", CommandType.StoredProcedure, dBHelper.CreateParameter("FromWorkerID", txtWorkerID.Text, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("ToWorkerID", I_WorkerID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("SYSTEMID", SystemID, DbType.String, ParameterDirection.Input));
                }
                if (dBHelper.RSCODE == "S")
                {
                    dBHelper.Commit();
                }
                else
                {
                    DialogForm dialogForm = new DialogForm(dBHelper.RSMSG, DialogForm.DialogType.OK);
                    dialogForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                dBHelper.Rollback();
                MessageForm messageForm = new MessageForm(ex);
                messageForm.ShowDialog();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WIZ.SY.SY0201Y));
            panel1 = new System.Windows.Forms.Panel();
            chkSystem = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            bntDel = new System.Windows.Forms.Button();
            bntAdd = new System.Windows.Forms.Button();
            txtWorkerID = new System.Windows.Forms.TextBox();
            txtWorkerName = new System.Windows.Forms.TextBox();
            lblWorker = new WIZ.Control.SLabel();
            btnSave = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            grid1 = new WIZ.Control.Grid(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chkSystem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grid1).BeginInit();
            SuspendLayout();
            panel1.Controls.Add(chkSystem);
            panel1.Controls.Add(bntDel);
            panel1.Controls.Add(bntAdd);
            panel1.Controls.Add(txtWorkerID);
            panel1.Controls.Add(txtWorkerName);
            panel1.Controls.Add(lblWorker);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnClose);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(810, 63);
            panel1.TabIndex = 2;
            chkSystem.Location = new System.Drawing.Point(120, 39);
            chkSystem.Name = "chkSystem";
            chkSystem.Size = new System.Drawing.Size(257, 19);
            chkSystem.TabIndex = 73;
            chkSystem.Text = "시스템권한";
            chkSystem.CheckedChanged += new System.EventHandler(chkSystem_CheckedChanged);
            bntDel.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            bntDel.ForeColor = System.Drawing.Color.Red;
            bntDel.Location = new System.Drawing.Point(500, 8);
            bntDel.Name = "bntDel";
            bntDel.Size = new System.Drawing.Size(98, 31);
            bntDel.TabIndex = 72;
            bntDel.Text = "행삭제";
            bntDel.UseVisualStyleBackColor = true;
            bntDel.Click += new System.EventHandler(bntDel_Click);
            bntAdd.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            bntAdd.ForeColor = System.Drawing.Color.Blue;
            bntAdd.Location = new System.Drawing.Point(402, 8);
            bntAdd.Name = "bntAdd";
            bntAdd.Size = new System.Drawing.Size(98, 31);
            bntAdd.TabIndex = 71;
            bntAdd.Text = "추가";
            bntAdd.UseVisualStyleBackColor = true;
            bntAdd.Click += new System.EventHandler(bntAdd_Click);
            txtWorkerID.Enabled = false;
            txtWorkerID.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtWorkerID.Location = new System.Drawing.Point(120, 12);
            txtWorkerID.Name = "txtWorkerID";
            txtWorkerID.Size = new System.Drawing.Size(118, 25);
            txtWorkerID.TabIndex = 66;
            txtWorkerName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            txtWorkerName.Enabled = false;
            txtWorkerName.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtWorkerName.Location = new System.Drawing.Point(244, 12);
            txtWorkerName.Name = "txtWorkerName";
            txtWorkerName.Size = new System.Drawing.Size(137, 25);
            txtWorkerName.TabIndex = 68;
            appearance.FontData.BoldAsString = "False";
            appearance.FontData.UnderlineAsString = "False";
            appearance.ForeColor = System.Drawing.Color.Black;
            appearance.TextHAlignAsString = "Right";
            appearance.TextVAlignAsString = "Middle";
            lblWorker.Appearance = appearance;
            lblWorker.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            lblWorker.DbField = null;
            lblWorker.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblWorker.Location = new System.Drawing.Point(18, 12);
            lblWorker.Name = "lblWorker";
            lblWorker.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblWorker.Size = new System.Drawing.Size(96, 25);
            lblWorker.TabIndex = 67;
            lblWorker.Text = "ID";
            btnSave.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            btnSave.Location = new System.Drawing.Point(598, 8);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(98, 31);
            btnSave.TabIndex = 37;
            btnSave.Text = "등록";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += new System.EventHandler(btnSave_Click);
            btnClose.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            btnClose.Location = new System.Drawing.Point(696, 8);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(98, 31);
            btnClose.TabIndex = 36;
            btnClose.Text = "닫기";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += new System.EventHandler(btnClose_Click);
            grid1.AutoResizeColumn = true;
            grid1.AutoUserColumn = true;
            grid1.ContextMenuCopyEnabled = true;
            grid1.ContextMenuDeleteEnabled = true;
            grid1.ContextMenuExcelEnabled = true;
            grid1.ContextMenuInsertEnabled = true;
            grid1.ContextMenuPasteEnabled = true;
            grid1.DeleteButtonEnable = true;
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            grid1.DisplayLayout.Appearance = appearance2;
            grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            grid1.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            grid1.DisplayLayout.MaxColScrollRegions = 1;
            grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            grid1.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            grid1.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.All;
            grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            grid1.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            grid1.DisplayLayout.Override.CellAppearance = appearance9;
            grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            grid1.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            grid1.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.TextHAlignAsString = "Left";
            grid1.DisplayLayout.Override.HeaderAppearance = appearance11;
            grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            grid1.DisplayLayout.Override.RowAppearance = appearance12;
            grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            grid1.EnterNextRowEnable = false;
            grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            grid1.Location = new System.Drawing.Point(0, 63);
            grid1.Name = "grid1";
            grid1.Size = new System.Drawing.Size(810, 423);
            grid1.TabIndex = 4;
            grid1.Text = "grid2";
            grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            grid1.DoubleClickCell += new Infragistics.Win.UltraWinGrid.DoubleClickCellEventHandler(grid1_DoubleClickCell);
            grid1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(grid1_KeyPress);
            base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(810, 486);
            base.Controls.Add(grid1);
            base.Controls.Add(panel1);
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.Name = "SY0201Y";
            Text = "권한관리";
            base.Load += new System.EventHandler(SY0201_Load);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chkSystem).EndInit();
            ((System.ComponentModel.ISupportInitialize)grid1).EndInit();
            ResumeLayout(false);
        }
    }
}

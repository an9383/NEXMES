namespace WIZ.PopUp
{
    partial class BM0060_POP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BM0060_POP));
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_OPCODE_H = new WIZ.Control.STextBox(this.components);
            this.btn_SEARCH_H = new Infragistics.Win.Misc.UltraButton();
            this.txt_LINECODE_H = new WIZ.Control.STextBox(this.components);
            this.cbo_USEFLAG_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.txt_WORKCENTERNAME_H = new WIZ.Control.STextBox(this.components);
            this.txt_WORKCENTERCODE_H = new WIZ.Control.STextBox(this.components);
            this.cbo_PLANTCODE_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lbl_PLANTCODE_H = new Infragistics.Win.Misc.UltraLabel();
            this.lbl_USEFLAG_H = new Infragistics.Win.Misc.UltraLabel();
            this.lbl_LINECODE_H = new Infragistics.Win.Misc.UltraLabel();
            this.lbl_OPCODE_H = new Infragistics.Win.Misc.UltraLabel();
            this.lbl_WORKCENTERCODE_H = new Infragistics.Win.Misc.UltraLabel();
            this.lbl_WORKCENTERNAME_H = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_OPCODE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LINECODE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_USEFLAG_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WORKCENTERNAME_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WORKCENTERCODE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_PLANTCODE_H)).BeginInit();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.AutoResizeColumn = true;
            this.grid1.AutoUserColumn = true;
            this.grid1.ContextMenuCopyEnabled = true;
            this.grid1.ContextMenuDeleteEnabled = true;
            this.grid1.ContextMenuExcelEnabled = true;
            this.grid1.ContextMenuInsertEnabled = true;
            this.grid1.ContextMenuPasteEnabled = true;
            this.grid1.DeleteButtonEnable = true;
            appearance14.BackColor = System.Drawing.SystemColors.Window;
            appearance14.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance14;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance5.BackColor = System.Drawing.SystemColors.Highlight;
            appearance5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            this.grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.DisplayLayout.Override.AllowMultiCellOperations = ((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)((((((((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Delete) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Undo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Redo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Reserved)));
            this.grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance12;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance8;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance7.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance10;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance11;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(0, 146);
            this.grid1.Margin = new System.Windows.Forms.Padding(0);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(814, 745);
            this.grid1.TabIndex = 1;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.grid1_DoubleClickRow);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_OPCODE_H);
            this.groupBox1.Controls.Add(this.btn_SEARCH_H);
            this.groupBox1.Controls.Add(this.txt_LINECODE_H);
            this.groupBox1.Controls.Add(this.cbo_USEFLAG_H);
            this.groupBox1.Controls.Add(this.txt_WORKCENTERNAME_H);
            this.groupBox1.Controls.Add(this.txt_WORKCENTERCODE_H);
            this.groupBox1.Controls.Add(this.cbo_PLANTCODE_H);
            this.groupBox1.Controls.Add(this.lbl_PLANTCODE_H);
            this.groupBox1.Controls.Add(this.lbl_USEFLAG_H);
            this.groupBox1.Controls.Add(this.lbl_LINECODE_H);
            this.groupBox1.Controls.Add(this.lbl_OPCODE_H);
            this.groupBox1.Controls.Add(this.lbl_WORKCENTERCODE_H);
            this.groupBox1.Controls.Add(this.lbl_WORKCENTERNAME_H);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(814, 146);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ 조회항목 ]";
            // 
            // txt_OPCODE_H
            // 
            this.txt_OPCODE_H.AutoSize = false;
            this.txt_OPCODE_H.Location = new System.Drawing.Point(220, 102);
            this.txt_OPCODE_H.Name = "txt_OPCODE_H";
            this.txt_OPCODE_H.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_OPCODE_H.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_OPCODE_H.Size = new System.Drawing.Size(160, 27);
            this.txt_OPCODE_H.TabIndex = 694;
            this.txt_OPCODE_H.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_OPCODE_H_KeyPress);
            // 
            // btn_SEARCH_H
            // 
            this.btn_SEARCH_H.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_SEARCH_H.Location = new System.Drawing.Point(595, 21);
            this.btn_SEARCH_H.Margin = new System.Windows.Forms.Padding(0);
            this.btn_SEARCH_H.Name = "btn_SEARCH_H";
            this.btn_SEARCH_H.Size = new System.Drawing.Size(110, 110);
            this.btn_SEARCH_H.TabIndex = 717;
            this.btn_SEARCH_H.Text = "조회";
            this.btn_SEARCH_H.Click += new System.EventHandler(this.btn_SEARCH_H_Click);
            // 
            // txt_LINECODE_H
            // 
            this.txt_LINECODE_H.AutoSize = false;
            this.txt_LINECODE_H.Location = new System.Drawing.Point(20, 102);
            this.txt_LINECODE_H.Name = "txt_LINECODE_H";
            this.txt_LINECODE_H.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_LINECODE_H.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_LINECODE_H.Size = new System.Drawing.Size(160, 27);
            this.txt_LINECODE_H.TabIndex = 693;
            this.txt_LINECODE_H.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_LINECODE_H_KeyPress);
            // 
            // cbo_USEFLAG_H
            // 
            this.cbo_USEFLAG_H.AutoSize = false;
            this.cbo_USEFLAG_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbo_USEFLAG_H.Location = new System.Drawing.Point(420, 102);
            this.cbo_USEFLAG_H.Name = "cbo_USEFLAG_H";
            this.cbo_USEFLAG_H.Size = new System.Drawing.Size(160, 27);
            this.cbo_USEFLAG_H.TabIndex = 691;
            // 
            // txt_WORKCENTERNAME_H
            // 
            this.txt_WORKCENTERNAME_H.AutoSize = false;
            this.txt_WORKCENTERNAME_H.Location = new System.Drawing.Point(420, 42);
            this.txt_WORKCENTERNAME_H.Name = "txt_WORKCENTERNAME_H";
            this.txt_WORKCENTERNAME_H.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_WORKCENTERNAME_H.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_WORKCENTERNAME_H.Size = new System.Drawing.Size(160, 27);
            this.txt_WORKCENTERNAME_H.TabIndex = 689;
            this.txt_WORKCENTERNAME_H.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_WORKCENTERNAME_H_KeyPress);
            // 
            // txt_WORKCENTERCODE_H
            // 
            this.txt_WORKCENTERCODE_H.AutoSize = false;
            this.txt_WORKCENTERCODE_H.Location = new System.Drawing.Point(220, 42);
            this.txt_WORKCENTERCODE_H.Name = "txt_WORKCENTERCODE_H";
            this.txt_WORKCENTERCODE_H.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_WORKCENTERCODE_H.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txt_WORKCENTERCODE_H.Size = new System.Drawing.Size(160, 27);
            this.txt_WORKCENTERCODE_H.TabIndex = 688;
            this.txt_WORKCENTERCODE_H.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_WORKCENTERCODE_H_KeyPress);
            // 
            // cbo_PLANTCODE_H
            // 
            this.cbo_PLANTCODE_H.AutoSize = false;
            this.cbo_PLANTCODE_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbo_PLANTCODE_H.Location = new System.Drawing.Point(20, 42);
            this.cbo_PLANTCODE_H.Name = "cbo_PLANTCODE_H";
            this.cbo_PLANTCODE_H.Size = new System.Drawing.Size(160, 27);
            this.cbo_PLANTCODE_H.TabIndex = 686;
            // 
            // lbl_PLANTCODE_H
            // 
            this.lbl_PLANTCODE_H.Location = new System.Drawing.Point(20, 20);
            this.lbl_PLANTCODE_H.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbl_PLANTCODE_H.Name = "lbl_PLANTCODE_H";
            this.lbl_PLANTCODE_H.Size = new System.Drawing.Size(144, 26);
            this.lbl_PLANTCODE_H.TabIndex = 711;
            this.lbl_PLANTCODE_H.Text = "사업장";
            // 
            // lbl_USEFLAG_H
            // 
            this.lbl_USEFLAG_H.Location = new System.Drawing.Point(420, 80);
            this.lbl_USEFLAG_H.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbl_USEFLAG_H.Name = "lbl_USEFLAG_H";
            this.lbl_USEFLAG_H.Size = new System.Drawing.Size(144, 26);
            this.lbl_USEFLAG_H.TabIndex = 710;
            this.lbl_USEFLAG_H.Text = "사용여부";
            // 
            // lbl_LINECODE_H
            // 
            this.lbl_LINECODE_H.Location = new System.Drawing.Point(20, 80);
            this.lbl_LINECODE_H.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbl_LINECODE_H.Name = "lbl_LINECODE_H";
            this.lbl_LINECODE_H.Size = new System.Drawing.Size(144, 26);
            this.lbl_LINECODE_H.TabIndex = 713;
            this.lbl_LINECODE_H.Text = "라인코드";
            // 
            // lbl_OPCODE_H
            // 
            this.lbl_OPCODE_H.Location = new System.Drawing.Point(220, 80);
            this.lbl_OPCODE_H.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbl_OPCODE_H.Name = "lbl_OPCODE_H";
            this.lbl_OPCODE_H.Size = new System.Drawing.Size(144, 26);
            this.lbl_OPCODE_H.TabIndex = 714;
            this.lbl_OPCODE_H.Text = "공정코드";
            // 
            // lbl_WORKCENTERCODE_H
            // 
            this.lbl_WORKCENTERCODE_H.Location = new System.Drawing.Point(220, 20);
            this.lbl_WORKCENTERCODE_H.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbl_WORKCENTERCODE_H.Name = "lbl_WORKCENTERCODE_H";
            this.lbl_WORKCENTERCODE_H.Size = new System.Drawing.Size(144, 26);
            this.lbl_WORKCENTERCODE_H.TabIndex = 715;
            this.lbl_WORKCENTERCODE_H.Text = "작업장코드";
            // 
            // lbl_WORKCENTERNAME_H
            // 
            this.lbl_WORKCENTERNAME_H.Location = new System.Drawing.Point(420, 20);
            this.lbl_WORKCENTERNAME_H.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbl_WORKCENTERNAME_H.Name = "lbl_WORKCENTERNAME_H";
            this.lbl_WORKCENTERNAME_H.Size = new System.Drawing.Size(144, 26);
            this.lbl_WORKCENTERNAME_H.TabIndex = 716;
            this.lbl_WORKCENTERNAME_H.Text = "작업장명";
            // 
            // BM0060_POP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 891);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BM0060_POP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "작업장마스터 POP-UP";
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_OPCODE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LINECODE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_USEFLAG_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WORKCENTERNAME_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WORKCENTERCODE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_PLANTCODE_H)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Control.Grid grid1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbo_USEFLAG_H;
        private WIZ.Control.STextBox txt_WORKCENTERNAME_H;
        private WIZ.Control.STextBox txt_WORKCENTERCODE_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbo_PLANTCODE_H;
        private WIZ.Control.STextBox txt_OPCODE_H;
        private WIZ.Control.STextBox txt_LINECODE_H;
        private Infragistics.Win.Misc.UltraLabel lbl_PLANTCODE_H;
        private Infragistics.Win.Misc.UltraLabel lbl_USEFLAG_H;
        private Infragistics.Win.Misc.UltraLabel lbl_LINECODE_H;
        private Infragistics.Win.Misc.UltraLabel lbl_OPCODE_H;
        private Infragistics.Win.Misc.UltraLabel lbl_WORKCENTERCODE_H;
        private Infragistics.Win.Misc.UltraLabel lbl_WORKCENTERNAME_H;
        private Infragistics.Win.Misc.UltraButton btn_SEARCH_H;
    }
}
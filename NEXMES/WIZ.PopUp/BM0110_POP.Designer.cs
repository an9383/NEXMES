namespace WIZ.PopUp
{
    partial class BM0110_POP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BM0110_POP));
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo_USEFLAG_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.txt_STOPDESC_H = new WIZ.Control.STextBox();
            this.txt_STOPCODE_H = new WIZ.Control.STextBox();
            this.cbo_STOPTYPE_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cbo_PLANTCODE_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.btn_SEARCH_H = new Infragistics.Win.Misc.UltraButton();
            this.lbl_USEFLAG_H = new Infragistics.Win.Misc.UltraLabel();
            this.lbl_PLANTCODE_H = new Infragistics.Win.Misc.UltraLabel();
            this.lbl_STOPCODE_H = new Infragistics.Win.Misc.UltraLabel();
            this.lbl_STOPDESC_H = new Infragistics.Win.Misc.UltraLabel();
            this.lbl_STOPTYPE_H = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_USEFLAG_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_STOPDESC_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_STOPCODE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_STOPTYPE_H)).BeginInit();
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
            this.grid1.Location = new System.Drawing.Point(0, 182);
            this.grid1.Margin = new System.Windows.Forms.Padding(0);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(816, 444);
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
            this.groupBox1.Controls.Add(this.btn_SEARCH_H);
            this.groupBox1.Controls.Add(this.cbo_USEFLAG_H);
            this.groupBox1.Controls.Add(this.txt_STOPDESC_H);
            this.groupBox1.Controls.Add(this.txt_STOPCODE_H);
            this.groupBox1.Controls.Add(this.cbo_STOPTYPE_H);
            this.groupBox1.Controls.Add(this.cbo_PLANTCODE_H);
            this.groupBox1.Controls.Add(this.lbl_USEFLAG_H);
            this.groupBox1.Controls.Add(this.lbl_PLANTCODE_H);
            this.groupBox1.Controls.Add(this.lbl_STOPCODE_H);
            this.groupBox1.Controls.Add(this.lbl_STOPDESC_H);
            this.groupBox1.Controls.Add(this.lbl_STOPTYPE_H);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(816, 182);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ 조회항목 ]";
            // 
            // cbo_USEFLAG_H
            // 
            this.cbo_USEFLAG_H.AutoSize = false;
            this.cbo_USEFLAG_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbo_USEFLAG_H.Location = new System.Drawing.Point(251, 128);
            this.cbo_USEFLAG_H.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbo_USEFLAG_H.Name = "cbo_USEFLAG_H";
            this.cbo_USEFLAG_H.Size = new System.Drawing.Size(183, 34);
            this.cbo_USEFLAG_H.TabIndex = 691;
            // 
            // txt_STOPDESC_H
            // 
            this.txt_STOPDESC_H.AutoSize = false;
            this.txt_STOPDESC_H.Location = new System.Drawing.Point(480, 52);
            this.txt_STOPDESC_H.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_STOPDESC_H.Name = "txt_STOPDESC_H";
            this.txt_STOPDESC_H.Size = new System.Drawing.Size(183, 34);
            this.txt_STOPDESC_H.TabIndex = 689;
            this.txt_STOPDESC_H.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_STOPDESC_H_KeyPress);
            // 
            // txt_STOPCODE_H
            // 
            this.txt_STOPCODE_H.AutoSize = false;
            this.txt_STOPCODE_H.Location = new System.Drawing.Point(251, 52);
            this.txt_STOPCODE_H.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_STOPCODE_H.Name = "txt_STOPCODE_H";
            this.txt_STOPCODE_H.Size = new System.Drawing.Size(183, 34);
            this.txt_STOPCODE_H.TabIndex = 688;
            this.txt_STOPCODE_H.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_STOPCODE_H_KeyPress);
            // 
            // cbo_STOPTYPE_H
            // 
            this.cbo_STOPTYPE_H.AutoSize = false;
            this.cbo_STOPTYPE_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbo_STOPTYPE_H.Location = new System.Drawing.Point(23, 128);
            this.cbo_STOPTYPE_H.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbo_STOPTYPE_H.Name = "cbo_STOPTYPE_H";
            this.cbo_STOPTYPE_H.Size = new System.Drawing.Size(183, 34);
            this.cbo_STOPTYPE_H.TabIndex = 687;
            // 
            // cbo_PLANTCODE_H
            // 
            this.cbo_PLANTCODE_H.AutoSize = false;
            this.cbo_PLANTCODE_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbo_PLANTCODE_H.Location = new System.Drawing.Point(23, 52);
            this.cbo_PLANTCODE_H.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbo_PLANTCODE_H.Name = "cbo_PLANTCODE_H";
            this.cbo_PLANTCODE_H.Size = new System.Drawing.Size(183, 34);
            this.cbo_PLANTCODE_H.TabIndex = 686;
            // 
            // btn_SEARCH_H
            // 
            this.btn_SEARCH_H.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_SEARCH_H.Location = new System.Drawing.Point(674, 23);
            this.btn_SEARCH_H.Margin = new System.Windows.Forms.Padding(0);
            this.btn_SEARCH_H.Name = "btn_SEARCH_H";
            this.btn_SEARCH_H.Size = new System.Drawing.Size(126, 138);
            this.btn_SEARCH_H.TabIndex = 723;
            this.btn_SEARCH_H.Text = "조회";
            // 
            // lbl_USEFLAG_H
            // 
            this.lbl_USEFLAG_H.Location = new System.Drawing.Point(251, 100);
            this.lbl_USEFLAG_H.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbl_USEFLAG_H.Name = "lbl_USEFLAG_H";
            this.lbl_USEFLAG_H.Size = new System.Drawing.Size(165, 32);
            this.lbl_USEFLAG_H.TabIndex = 721;
            this.lbl_USEFLAG_H.Text = "사용여부";
            // 
            // lbl_PLANTCODE_H
            // 
            this.lbl_PLANTCODE_H.Location = new System.Drawing.Point(23, 25);
            this.lbl_PLANTCODE_H.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbl_PLANTCODE_H.Name = "lbl_PLANTCODE_H";
            this.lbl_PLANTCODE_H.Size = new System.Drawing.Size(165, 32);
            this.lbl_PLANTCODE_H.TabIndex = 722;
            this.lbl_PLANTCODE_H.Text = "사업장";
            // 
            // lbl_STOPCODE_H
            // 
            this.lbl_STOPCODE_H.Location = new System.Drawing.Point(251, 25);
            this.lbl_STOPCODE_H.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbl_STOPCODE_H.Name = "lbl_STOPCODE_H";
            this.lbl_STOPCODE_H.Size = new System.Drawing.Size(165, 32);
            this.lbl_STOPCODE_H.TabIndex = 724;
            this.lbl_STOPCODE_H.Text = "비가동코드";
            // 
            // lbl_STOPDESC_H
            // 
            this.lbl_STOPDESC_H.Location = new System.Drawing.Point(480, 25);
            this.lbl_STOPDESC_H.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbl_STOPDESC_H.Name = "lbl_STOPDESC_H";
            this.lbl_STOPDESC_H.Size = new System.Drawing.Size(165, 32);
            this.lbl_STOPDESC_H.TabIndex = 725;
            this.lbl_STOPDESC_H.Text = "비가동명";
            // 
            // lbl_STOPTYPE_H
            // 
            this.lbl_STOPTYPE_H.Location = new System.Drawing.Point(23, 100);
            this.lbl_STOPTYPE_H.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbl_STOPTYPE_H.Name = "lbl_STOPTYPE_H";
            this.lbl_STOPTYPE_H.Size = new System.Drawing.Size(165, 32);
            this.lbl_STOPTYPE_H.TabIndex = 726;
            this.lbl_STOPTYPE_H.Text = "비가동구분";
            // 
            // BM0110_POP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 626);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BM0110_POP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "비가동마스터 POP-UP";
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbo_USEFLAG_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_STOPDESC_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_STOPCODE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_STOPTYPE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_PLANTCODE_H)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Control.Grid grid1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbo_USEFLAG_H;
        private WIZ.Control.STextBox txt_STOPDESC_H;
        private WIZ.Control.STextBox txt_STOPCODE_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbo_STOPTYPE_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbo_PLANTCODE_H;
        private Infragistics.Win.Misc.UltraButton btn_SEARCH_H;
        private Infragistics.Win.Misc.UltraLabel lbl_USEFLAG_H;
        private Infragistics.Win.Misc.UltraLabel lbl_PLANTCODE_H;
        private Infragistics.Win.Misc.UltraLabel lbl_STOPCODE_H;
        private Infragistics.Win.Misc.UltraLabel lbl_STOPDESC_H;
        private Infragistics.Win.Misc.UltraLabel lbl_STOPTYPE_H;
    }
}
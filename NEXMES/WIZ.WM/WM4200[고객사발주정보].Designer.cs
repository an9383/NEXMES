namespace WIZ.WM
{
    partial class WM4200
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
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.sLabel1 = new WIZ.Control.SLabel();
            this.cboSOEDDT = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.txtCustCode = new System.Windows.Forms.TextBox();
            this.lblItemCode = new WIZ.Control.SLabel();
            this.cboSOSTDT = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lblSODT = new WIZ.Control.SLabel();
            this.btnPlanInput = new Infragistics.Win.Misc.UltraButton();
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.sLabel3 = new WIZ.Control.SLabel();
            this.sLabel2 = new WIZ.Control.SLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSOEDDT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSOSTDT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.txtItemName);
            this.gbxHeader.Controls.Add(this.txtItemCode);
            this.gbxHeader.Controls.Add(this.sLabel1);
            this.gbxHeader.Controls.Add(this.cboSOEDDT);
            this.gbxHeader.Controls.Add(this.txtCustName);
            this.gbxHeader.Controls.Add(this.txtCustCode);
            this.gbxHeader.Controls.Add(this.lblItemCode);
            this.gbxHeader.Controls.Add(this.cboSOSTDT);
            this.gbxHeader.Controls.Add(this.lblSODT);
            this.gbxHeader.Controls.Add(this.btnPlanInput);
            this.gbxHeader.Controls.Add(this.cboPlantCode_H);
            this.gbxHeader.Controls.Add(this.sLabel3);
            this.gbxHeader.Controls.Add(this.sLabel2);
            this.gbxHeader.Size = new System.Drawing.Size(1130, 82);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel2, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel3, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantCode_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.btnPlanInput, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblSODT, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboSOSTDT, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblItemCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtCustCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtCustName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboSOEDDT, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel1, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtItemCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtItemName, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(0, 82);
            this.gbxBody.Size = new System.Drawing.Size(1130, 657);
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
            appearance76.BackColor = System.Drawing.SystemColors.Window;
            appearance76.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance76;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance1.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance1.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance1;
            appearance79.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance79;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance78.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance78.BackColor2 = System.Drawing.SystemColors.Control;
            appearance78.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance78.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance78;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance101.BackColor = System.Drawing.SystemColors.Window;
            appearance101.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance101;
            appearance2.BackColor = System.Drawing.SystemColors.Highlight;
            appearance2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance2;
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
            appearance104.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance104;
            appearance100.BorderColor = System.Drawing.Color.Silver;
            appearance100.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance100;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance81.BackColor = System.Drawing.SystemColors.Control;
            appearance81.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance81.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance81.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance81.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance81;
            appearance99.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance99;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance102.BackColor = System.Drawing.SystemColors.Window;
            appearance102.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance102;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance103.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance103;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(6, 6);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1118, 645);
            this.grid1.TabIndex = 3;
            this.grid1.Text = "grid2";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.ClickCell += new Infragistics.Win.UltraWinGrid.ClickCellEventHandler(this.grid1_ClickCell);
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtItemName.Location = new System.Drawing.Point(720, 43);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(248, 27);
            this.txtItemName.TabIndex = 241;
            // 
            // txtItemCode
            // 
            this.txtItemCode.Location = new System.Drawing.Point(579, 43);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(135, 27);
            this.txtItemCode.TabIndex = 240;
            // 
            // sLabel1
            // 
            appearance25.FontData.BoldAsString = "False";
            appearance25.FontData.UnderlineAsString = "False";
            appearance25.ForeColor = System.Drawing.Color.Black;
            appearance25.TextHAlignAsString = "Right";
            appearance25.TextVAlignAsString = "Middle";
            this.sLabel1.Appearance = appearance25;
            this.sLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel1.DbField = null;
            this.sLabel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel1.Location = new System.Drawing.Point(493, 44);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(80, 24);
            this.sLabel1.TabIndex = 247;
            this.sLabel1.Text = "품목";
            // 
            // cboSOEDDT
            // 
            this.cboSOEDDT.DateButtons.Add(dateButton1);
            this.cboSOEDDT.Location = new System.Drawing.Point(498, 12);
            this.cboSOEDDT.Name = "cboSOEDDT";
            this.cboSOEDDT.NonAutoSizeHeight = 26;
            this.cboSOEDDT.Size = new System.Drawing.Size(135, 26);
            this.cboSOEDDT.TabIndex = 237;
            // 
            // txtCustName
            // 
            this.txtCustName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtCustName.Location = new System.Drawing.Point(235, 44);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(248, 27);
            this.txtCustName.TabIndex = 239;
            // 
            // txtCustCode
            // 
            this.txtCustCode.Location = new System.Drawing.Point(98, 44);
            this.txtCustCode.Name = "txtCustCode";
            this.txtCustCode.Size = new System.Drawing.Size(135, 27);
            this.txtCustCode.TabIndex = 238;
            // 
            // lblItemCode
            // 
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.lblItemCode.Appearance = appearance3;
            this.lblItemCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblItemCode.DbField = null;
            this.lblItemCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemCode.Location = new System.Drawing.Point(12, 45);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblItemCode.Size = new System.Drawing.Size(80, 24);
            this.lblItemCode.TabIndex = 245;
            this.lblItemCode.Text = "거래처";
            // 
            // cboSOSTDT
            // 
            this.cboSOSTDT.DateButtons.Add(dateButton2);
            this.cboSOSTDT.Location = new System.Drawing.Point(346, 12);
            this.cboSOSTDT.Name = "cboSOSTDT";
            this.cboSOSTDT.NonAutoSizeHeight = 26;
            this.cboSOSTDT.Size = new System.Drawing.Size(135, 26);
            this.cboSOSTDT.TabIndex = 236;
            // 
            // lblSODT
            // 
            appearance82.FontData.BoldAsString = "False";
            appearance82.FontData.UnderlineAsString = "False";
            appearance82.ForeColor = System.Drawing.Color.Black;
            appearance82.TextHAlignAsString = "Right";
            appearance82.TextVAlignAsString = "Middle";
            this.lblSODT.Appearance = appearance82;
            this.lblSODT.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblSODT.DbField = null;
            this.lblSODT.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSODT.Location = new System.Drawing.Point(250, 13);
            this.lblSODT.Name = "lblSODT";
            this.lblSODT.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblSODT.Size = new System.Drawing.Size(88, 25);
            this.lblSODT.TabIndex = 244;
            this.lblSODT.Text = "발주일자";
            // 
            // btnPlanInput
            // 
            this.btnPlanInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlanInput.Font = new System.Drawing.Font("맑은 고딕", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPlanInput.Location = new System.Drawing.Point(999, 8);
            this.btnPlanInput.Name = "btnPlanInput";
            this.btnPlanInput.Size = new System.Drawing.Size(119, 68);
            this.btnPlanInput.TabIndex = 242;
            this.btnPlanInput.Text = "EXCEL\r\nUPLOAD";
            this.btnPlanInput.Click += new System.EventHandler(this.ExcelUPbtn_Click);
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboPlantCode_H.Location = new System.Drawing.Point(98, 12);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(135, 27);
            this.cboPlantCode_H.TabIndex = 235;
            this.cboPlantCode_H.Text = "cboPlantCode_H";
            // 
            // sLabel3
            // 
            appearance32.FontData.BoldAsString = "False";
            appearance32.FontData.UnderlineAsString = "False";
            appearance32.ForeColor = System.Drawing.Color.Black;
            appearance32.TextHAlignAsString = "Right";
            appearance32.TextVAlignAsString = "Middle";
            this.sLabel3.Appearance = appearance32;
            this.sLabel3.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel3.DbField = null;
            this.sLabel3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel3.Location = new System.Drawing.Point(12, 14);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel3.Size = new System.Drawing.Size(80, 25);
            this.sLabel3.TabIndex = 243;
            this.sLabel3.Text = "사업장";
            // 
            // sLabel2
            // 
            appearance14.FontData.BoldAsString = "False";
            appearance14.FontData.UnderlineAsString = "False";
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.TextHAlignAsString = "Center";
            appearance14.TextVAlignAsString = "Middle";
            this.sLabel2.Appearance = appearance14;
            this.sLabel2.DbField = null;
            this.sLabel2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel2.Location = new System.Drawing.Point(462, 13);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel2.Size = new System.Drawing.Size(52, 25);
            this.sLabel2.TabIndex = 246;
            this.sLabel2.Text = "~";
            // 
            // WM4200
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 739);
            this.Name = "WM4200";
            this.Text = "고객사 발주정보 등록";
            this.Load += new System.EventHandler(this.WM4200_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSOEDDT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSOSTDT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtItemCode;
        private Control.SLabel sLabel1;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cboSOEDDT;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.TextBox txtCustCode;
        private Control.SLabel lblItemCode;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cboSOSTDT;
        private Control.SLabel lblSODT;
        private Infragistics.Win.Misc.UltraButton btnPlanInput;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
        private Control.SLabel sLabel3;
        private Control.SLabel sLabel2;
        private Control.Grid grid1;
    }
}
namespace WIZ.MM
{
    partial class MM9910
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            this.cboEndDate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.cboStartDate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.sLabel2 = new WIZ.Control.SLabel();
            this.lblInDate = new WIZ.Control.SLabel();
            this.txtCoilNo_H = new System.Windows.Forms.TextBox();
            this.lblCoilNo = new WIZ.Control.SLabel();
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.txtPoNo_H = new System.Windows.Forms.TextBox();
            this.lblPoNo = new WIZ.Control.SLabel();
            this.sLabel3 = new WIZ.Control.SLabel();
            this.txtItemCode_H = new System.Windows.Forms.TextBox();
            this.txtItemName_H = new System.Windows.Forms.TextBox();
            this.lblItemName = new WIZ.Control.SLabel();
            this.grid1 = new WIZ.Control.Grid(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboEndDate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStartDate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.cboEndDate_H);
            this.gbxHeader.Controls.Add(this.cboStartDate_H);
            this.gbxHeader.Controls.Add(this.sLabel2);
            this.gbxHeader.Controls.Add(this.lblInDate);
            this.gbxHeader.Controls.Add(this.txtCoilNo_H);
            this.gbxHeader.Controls.Add(this.lblCoilNo);
            this.gbxHeader.Controls.Add(this.cboPlantCode_H);
            this.gbxHeader.Controls.Add(this.txtPoNo_H);
            this.gbxHeader.Controls.Add(this.lblPoNo);
            this.gbxHeader.Controls.Add(this.sLabel3);
            this.gbxHeader.Controls.Add(this.txtItemCode_H);
            this.gbxHeader.Controls.Add(this.txtItemName_H);
            this.gbxHeader.Controls.Add(this.lblItemName);
            this.gbxHeader.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.gbxHeader.Location = new System.Drawing.Point(3, 3);
            this.gbxHeader.Size = new System.Drawing.Size(1130, 120);
            this.gbxHeader.TabIndex = 0;
            this.gbxHeader.Controls.SetChildIndex(this.lblItemName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtItemName_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtItemCode_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel3, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblPoNo, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtPoNo_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantCode_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblCoilNo, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtCoilNo_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblInDate, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel2, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboStartDate_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboEndDate_H, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(3, 123);
            this.gbxBody.Size = new System.Drawing.Size(1130, 699);
            // 
            // cboEndDate_H
            // 
            this.cboEndDate_H.DateButtons.Add(dateButton1);
            this.cboEndDate_H.Location = new System.Drawing.Point(896, 13);
            this.cboEndDate_H.Name = "cboEndDate_H";
            this.cboEndDate_H.NonAutoSizeHeight = 26;
            this.cboEndDate_H.Size = new System.Drawing.Size(145, 24);
            this.cboEndDate_H.TabIndex = 128;
            // 
            // cboStartDate_H
            // 
            this.cboStartDate_H.DateButtons.Add(dateButton2);
            this.cboStartDate_H.Location = new System.Drawing.Point(690, 12);
            this.cboStartDate_H.Name = "cboStartDate_H";
            this.cboStartDate_H.NonAutoSizeHeight = 26;
            this.cboStartDate_H.Size = new System.Drawing.Size(145, 24);
            this.cboStartDate_H.TabIndex = 127;
            // 
            // sLabel2
            // 
            appearance24.FontData.BoldAsString = "False";
            appearance24.FontData.UnderlineAsString = "False";
            appearance24.ForeColor = System.Drawing.Color.Black;
            appearance24.TextHAlignAsString = "Center";
            appearance24.TextVAlignAsString = "Middle";
            this.sLabel2.Appearance = appearance24;
            this.sLabel2.DbField = null;
            this.sLabel2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel2.Location = new System.Drawing.Point(856, 11);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel2.Size = new System.Drawing.Size(20, 25);
            this.sLabel2.TabIndex = 130;
            this.sLabel2.Text = "~";
            // 
            // lblInDate
            // 
            appearance39.FontData.BoldAsString = "False";
            appearance39.FontData.UnderlineAsString = "False";
            appearance39.ForeColor = System.Drawing.Color.Black;
            appearance39.TextHAlignAsString = "Right";
            appearance39.TextVAlignAsString = "Middle";
            this.lblInDate.Appearance = appearance39;
            this.lblInDate.DbField = "cboUseFlag";
            this.lblInDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInDate.Location = new System.Drawing.Point(595, 12);
            this.lblInDate.Name = "lblInDate";
            this.lblInDate.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblInDate.Size = new System.Drawing.Size(90, 25);
            this.lblInDate.TabIndex = 129;
            this.lblInDate.Text = "라벨발행일";
            // 
            // txtCoilNo_H
            // 
            this.txtCoilNo_H.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCoilNo_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtCoilNo_H.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtCoilNo_H.Location = new System.Drawing.Point(690, 48);
            this.txtCoilNo_H.Name = "txtCoilNo_H";
            this.txtCoilNo_H.Size = new System.Drawing.Size(351, 25);
            this.txtCoilNo_H.TabIndex = 125;
            // 
            // lblCoilNo
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.lblCoilNo.Appearance = appearance1;
            this.lblCoilNo.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblCoilNo.DbField = null;
            this.lblCoilNo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCoilNo.Location = new System.Drawing.Point(595, 48);
            this.lblCoilNo.Name = "lblCoilNo";
            this.lblCoilNo.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblCoilNo.Size = new System.Drawing.Size(90, 25);
            this.lblCoilNo.TabIndex = 126;
            this.lblCoilNo.Text = "자재번호";
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Location = new System.Drawing.Point(146, 11);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(145, 27);
            this.cboPlantCode_H.TabIndex = 118;
            // 
            // txtPoNo_H
            // 
            this.txtPoNo_H.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPoNo_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtPoNo_H.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPoNo_H.Location = new System.Drawing.Point(146, 48);
            this.txtPoNo_H.Name = "txtPoNo_H";
            this.txtPoNo_H.Size = new System.Drawing.Size(351, 25);
            this.txtPoNo_H.TabIndex = 119;
            // 
            // lblPoNo
            // 
            appearance16.FontData.BoldAsString = "False";
            appearance16.FontData.UnderlineAsString = "False";
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.lblPoNo.Appearance = appearance16;
            this.lblPoNo.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblPoNo.DbField = null;
            this.lblPoNo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPoNo.Location = new System.Drawing.Point(51, 48);
            this.lblPoNo.Name = "lblPoNo";
            this.lblPoNo.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPoNo.Size = new System.Drawing.Size(90, 25);
            this.lblPoNo.TabIndex = 124;
            this.lblPoNo.Text = "발주번호";
            // 
            // sLabel3
            // 
            appearance40.FontData.BoldAsString = "False";
            appearance40.FontData.UnderlineAsString = "False";
            appearance40.ForeColor = System.Drawing.Color.Black;
            appearance40.TextHAlignAsString = "Right";
            appearance40.TextVAlignAsString = "Middle";
            this.sLabel3.Appearance = appearance40;
            this.sLabel3.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel3.DbField = null;
            this.sLabel3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel3.Location = new System.Drawing.Point(51, 12);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel3.Size = new System.Drawing.Size(90, 25);
            this.sLabel3.TabIndex = 123;
            this.sLabel3.Text = "사업장";
            // 
            // txtItemCode_H
            // 
            this.txtItemCode_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtItemCode_H.Location = new System.Drawing.Point(146, 84);
            this.txtItemCode_H.Name = "txtItemCode_H";
            this.txtItemCode_H.Size = new System.Drawing.Size(145, 25);
            this.txtItemCode_H.TabIndex = 120;
            // 
            // txtItemName_H
            // 
            this.txtItemName_H.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtItemName_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtItemName_H.Location = new System.Drawing.Point(291, 84);
            this.txtItemName_H.Name = "txtItemName_H";
            this.txtItemName_H.ReadOnly = true;
            this.txtItemName_H.Size = new System.Drawing.Size(200, 25);
            this.txtItemName_H.TabIndex = 121;
            // 
            // lblItemName
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.lblItemName.Appearance = appearance2;
            this.lblItemName.DbField = "cboUseFlag";
            this.lblItemName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItemName.Location = new System.Drawing.Point(51, 84);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblItemName.Size = new System.Drawing.Size(90, 25);
            this.lblItemName.TabIndex = 122;
            this.lblItemName.Text = "품목";
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
            appearance78.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance78.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance78.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance78.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance78;
            appearance79.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance79;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance80.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance80.BackColor2 = System.Drawing.SystemColors.Control;
            appearance80.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance80.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance80;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance81.BackColor = System.Drawing.SystemColors.Window;
            appearance81.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance81;
            appearance82.BackColor = System.Drawing.SystemColors.Highlight;
            appearance82.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance82;
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
            appearance83.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance83;
            appearance84.BorderColor = System.Drawing.Color.Silver;
            appearance84.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance84;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance85.BackColor = System.Drawing.SystemColors.Control;
            appearance85.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance85.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance85.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance85.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance85;
            appearance86.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance86;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance87.BackColor = System.Drawing.SystemColors.Window;
            appearance87.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance87;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance92.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance92;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(6, 6);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1118, 687);
            this.grid1.TabIndex = 0;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.ClickCell += new Infragistics.Win.UltraWinGrid.ClickCellEventHandler(this.grid1_ClickCell);
            // 
            // MM9910
            // 
            this.ClientSize = new System.Drawing.Size(1136, 825);
            this.Name = "MM9910";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "자재LOT(발행) 정보 관리";
            this.Load += new System.EventHandler(this.MM9910_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboEndDate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStartDate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cboEndDate_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cboStartDate_H;
        private Control.SLabel sLabel2;
        private Control.SLabel lblInDate;
        private System.Windows.Forms.TextBox txtCoilNo_H;
        private Control.SLabel lblCoilNo;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
        private System.Windows.Forms.TextBox txtPoNo_H;
        private Control.SLabel lblPoNo;
        private Control.SLabel sLabel3;
        private System.Windows.Forms.TextBox txtItemCode_H;
        private System.Windows.Forms.TextBox txtItemName_H;
        private Control.SLabel lblItemName;
        private Control.Grid grid1;
    }
}

namespace WIZ.PP
{
    partial class PP4100
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
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.txtOPCode = new System.Windows.Forms.TextBox();
            this.txtOPName = new System.Windows.Forms.TextBox();
            this.txtWorkCenterCode = new System.Windows.Forms.TextBox();
            this.txtWorkCenterName = new System.Windows.Forms.TextBox();
            this.lblPlantCode = new WIZ.Control.SLabel();
            this.CboStartdate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.CboEnddate_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.lblOPCode = new WIZ.Control.SLabel();
            this.lblWorkCenterCode = new WIZ.Control.SLabel();
            this.lblDate = new WIZ.Control.SLabel();
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboStartdate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboEnddate_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.cboPlantCode_H);
            this.gbxHeader.Controls.Add(this.txtOPCode);
            this.gbxHeader.Controls.Add(this.txtOPName);
            this.gbxHeader.Controls.Add(this.txtWorkCenterCode);
            this.gbxHeader.Controls.Add(this.txtWorkCenterName);
            this.gbxHeader.Controls.Add(this.lblPlantCode);
            this.gbxHeader.Controls.Add(this.CboStartdate_H);
            this.gbxHeader.Controls.Add(this.CboEnddate_H);
            this.gbxHeader.Controls.Add(this.ultraLabel4);
            this.gbxHeader.Controls.Add(this.lblOPCode);
            this.gbxHeader.Controls.Add(this.lblWorkCenterCode);
            this.gbxHeader.Controls.Add(this.lblDate);
            this.gbxHeader.Size = new System.Drawing.Size(1136, 90);
            this.gbxHeader.Controls.SetChildIndex(this.lblDate, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblWorkCenterCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblOPCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.ultraLabel4, 0);
            this.gbxHeader.Controls.SetChildIndex(this.CboEnddate_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.CboStartdate_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lblPlantCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtWorkCenterName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtWorkCenterCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtOPName, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtOPCode, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboPlantCode_H, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(0, 90);
            this.gbxBody.Size = new System.Drawing.Size(1136, 735);
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
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance5;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance6;
            appearance8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance8;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance7.BackColor2 = System.Drawing.SystemColors.Control;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance7;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance13;
            appearance9.BackColor = System.Drawing.SystemColors.Highlight;
            appearance9.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance9;
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
            appearance16.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance16;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance12;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance14.BackColor = System.Drawing.SystemColors.Window;
            appearance14.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance14;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance15.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance15;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(6, 6);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1124, 723);
            this.grid1.TabIndex = 0;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtOPCode
            // 
            this.txtOPCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtOPCode.Location = new System.Drawing.Point(146, 51);
            this.txtOPCode.Name = "txtOPCode";
            this.txtOPCode.Size = new System.Drawing.Size(119, 25);
            this.txtOPCode.TabIndex = 3;
            this.txtOPCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOPCode_KeyDown);
            this.txtOPCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOPCode_KeyPress);
            this.txtOPCode.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtWorkCenterCode_MouseDoubleClick);
            // 
            // txtOPName
            // 
            this.txtOPName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtOPName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtOPName.Location = new System.Drawing.Point(265, 51);
            this.txtOPName.MaxLength = 30;
            this.txtOPName.Name = "txtOPName";
            this.txtOPName.Size = new System.Drawing.Size(199, 25);
            this.txtOPName.TabIndex = 4;
            this.txtOPName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOPName_KeyDown);
            this.txtOPName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOPName_KeyPress);
            this.txtOPName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtWorkCenterName_MouseDoubleClick);
            // 
            // txtWorkCenterCode
            // 
            this.txtWorkCenterCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtWorkCenterCode.Location = new System.Drawing.Point(653, 51);
            this.txtWorkCenterCode.Name = "txtWorkCenterCode";
            this.txtWorkCenterCode.Size = new System.Drawing.Size(119, 25);
            this.txtWorkCenterCode.TabIndex = 5;
            this.txtWorkCenterCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWorkCenterCode_KeyDown);
            this.txtWorkCenterCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWorkCenterCode_KeyPress);
            this.txtWorkCenterCode.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtOPCode_MouseDoubleClick);
            // 
            // txtWorkCenterName
            // 
            this.txtWorkCenterName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtWorkCenterName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.txtWorkCenterName.Location = new System.Drawing.Point(772, 51);
            this.txtWorkCenterName.MaxLength = 30;
            this.txtWorkCenterName.Name = "txtWorkCenterName";
            this.txtWorkCenterName.Size = new System.Drawing.Size(199, 25);
            this.txtWorkCenterName.TabIndex = 6;
            this.txtWorkCenterName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWorkCenterName_KeyDown);
            this.txtWorkCenterName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWorkCenterName_KeyPress);
            this.txtWorkCenterName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtOPName_MouseDoubleClick);
            // 
            // lblPlantCode
            // 
            appearance58.FontData.BoldAsString = "False";
            appearance58.FontData.Name = "맑은 고딕";
            appearance58.FontData.SizeInPoints = 9F;
            appearance58.FontData.UnderlineAsString = "False";
            appearance58.ForeColor = System.Drawing.Color.Black;
            appearance58.TextHAlignAsString = "Right";
            appearance58.TextVAlignAsString = "Middle";
            this.lblPlantCode.Appearance = appearance58;
            this.lblPlantCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblPlantCode.DbField = null;
            this.lblPlantCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlantCode.Location = new System.Drawing.Point(51, 15);
            this.lblPlantCode.Name = "lblPlantCode";
            this.lblPlantCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblPlantCode.Size = new System.Drawing.Size(90, 25);
            this.lblPlantCode.TabIndex = 300;
            this.lblPlantCode.Text = "사업장";
            // 
            // CboStartdate_H
            // 
            appearance70.FontData.Name = "맑은 고딕";
            appearance70.FontData.SizeInPoints = 9F;
            this.CboStartdate_H.Appearance = appearance70;
            this.CboStartdate_H.AutoSize = false;
            this.CboStartdate_H.DateButtons.Add(dateButton1);
            this.CboStartdate_H.Location = new System.Drawing.Point(652, 14);
            this.CboStartdate_H.Name = "CboStartdate_H";
            this.CboStartdate_H.NonAutoSizeHeight = 26;
            this.CboStartdate_H.Size = new System.Drawing.Size(119, 26);
            this.CboStartdate_H.TabIndex = 1;
            // 
            // CboEnddate_H
            // 
            appearance77.FontData.Name = "맑은 고딕";
            appearance77.FontData.SizeInPoints = 9F;
            this.CboEnddate_H.Appearance = appearance77;
            this.CboEnddate_H.AutoSize = false;
            this.CboEnddate_H.DateButtons.Add(dateButton2);
            this.CboEnddate_H.Location = new System.Drawing.Point(853, 15);
            this.CboEnddate_H.Name = "CboEnddate_H";
            this.CboEnddate_H.NonAutoSizeHeight = 26;
            this.CboEnddate_H.Size = new System.Drawing.Size(119, 26);
            this.CboEnddate_H.TabIndex = 2;
            // 
            // ultraLabel4
            // 
            appearance78.TextHAlignAsString = "Center";
            appearance78.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance78;
            this.ultraLabel4.AutoSize = true;
            this.ultraLabel4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ultraLabel4.Location = new System.Drawing.Point(808, 18);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(13, 18);
            this.ultraLabel4.TabIndex = 297;
            this.ultraLabel4.Text = "~";
            // 
            // lblOPCode
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.Name = "맑은 고딕";
            appearance1.FontData.SizeInPoints = 9F;
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.lblOPCode.Appearance = appearance1;
            this.lblOPCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblOPCode.DbField = null;
            this.lblOPCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOPCode.Location = new System.Drawing.Point(51, 51);
            this.lblOPCode.Name = "lblOPCode";
            this.lblOPCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblOPCode.Size = new System.Drawing.Size(90, 25);
            this.lblOPCode.TabIndex = 296;
            this.lblOPCode.Text = "공정";
            // 
            // lblWorkCenterCode
            // 
            appearance69.FontData.BoldAsString = "False";
            appearance69.FontData.Name = "맑은 고딕";
            appearance69.FontData.SizeInPoints = 9F;
            appearance69.FontData.UnderlineAsString = "False";
            appearance69.ForeColor = System.Drawing.Color.Black;
            appearance69.TextHAlignAsString = "Right";
            appearance69.TextVAlignAsString = "Middle";
            this.lblWorkCenterCode.Appearance = appearance69;
            this.lblWorkCenterCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblWorkCenterCode.DbField = null;
            this.lblWorkCenterCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWorkCenterCode.Location = new System.Drawing.Point(558, 51);
            this.lblWorkCenterCode.Name = "lblWorkCenterCode";
            this.lblWorkCenterCode.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblWorkCenterCode.Size = new System.Drawing.Size(90, 25);
            this.lblWorkCenterCode.TabIndex = 295;
            this.lblWorkCenterCode.Text = "작업장";
            // 
            // lblDate
            // 
            appearance63.FontData.BoldAsString = "False";
            appearance63.FontData.Name = "맑은 고딕";
            appearance63.FontData.UnderlineAsString = "False";
            appearance63.ForeColor = System.Drawing.Color.Black;
            appearance63.TextHAlignAsString = "Right";
            appearance63.TextVAlignAsString = "Middle";
            this.lblDate.Appearance = appearance63;
            this.lblDate.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblDate.DbField = null;
            this.lblDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDate.Location = new System.Drawing.Point(557, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblDate.Size = new System.Drawing.Size(90, 25);
            this.lblDate.TabIndex = 294;
            this.lblDate.Text = "일자";
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboPlantCode_H.Location = new System.Drawing.Point(146, 14);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(119, 27);
            this.cboPlantCode_H.TabIndex = 0;
            // 
            // PP4100
            // 
            this.ClientSize = new System.Drawing.Size(1136, 825);
            this.Name = "PP4100";
            this.Text = "일별 작업장 설비 효율관리";
            this.Load += new System.EventHandler(this.PP4100_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboStartdate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboEnddate_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.Grid grid1;
        private System.Windows.Forms.TextBox txtOPCode;
        private System.Windows.Forms.TextBox txtOPName;
        private System.Windows.Forms.TextBox txtWorkCenterCode;
        private System.Windows.Forms.TextBox txtWorkCenterName;
        private Control.SLabel lblPlantCode;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo CboStartdate_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo CboEnddate_H;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Control.SLabel lblOPCode;
        private Control.SLabel lblWorkCenterCode;
        private Control.SLabel lblDate;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
    }
}

namespace WIZ.PP
{
    partial class PP0240
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            this.lbl_PLANTCODE_H = new WIZ.Control.SLabel();
            this.cbo_PLANTCODE_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lbl_WORKCENTERCODE_H = new WIZ.Control.SLabel();
            this.txt_WORKCENTERCODE_H = new WIZ.Control.SBtnTextEditor();
            this.cbo_ENDDATE_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.cbo_STARTDATE_H = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lbl_DATE_H = new Infragistics.Win.Misc.UltraLabel();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.txt_WORKCENTERNAME_H = new WIZ.Control.STextBox();
            this.sLabel4 = new WIZ.Control.SLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_PLANTCODE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WORKCENTERCODE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_ENDDATE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_STARTDATE_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WORKCENTERNAME_H)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.txt_WORKCENTERNAME_H);
            this.gbxHeader.Controls.Add(this.txt_WORKCENTERCODE_H);
            this.gbxHeader.Controls.Add(this.cbo_ENDDATE_H);
            this.gbxHeader.Controls.Add(this.cbo_PLANTCODE_H);
            this.gbxHeader.Controls.Add(this.cbo_STARTDATE_H);
            this.gbxHeader.Controls.Add(this.lbl_WORKCENTERCODE_H);
            this.gbxHeader.Controls.Add(this.lbl_PLANTCODE_H);
            this.gbxHeader.Controls.Add(this.lbl_DATE_H);
            this.gbxHeader.Controls.Add(this.sLabel4);
            this.gbxHeader.Size = new System.Drawing.Size(1637, 73);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel4, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_DATE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_PLANTCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.lbl_WORKCENTERCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_STARTDATE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_PLANTCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cbo_ENDDATE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txt_WORKCENTERCODE_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txt_WORKCENTERNAME_H, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 2;
            this.gbxBody.ContentPadding.Left = 2;
            this.gbxBody.ContentPadding.Right = 2;
            this.gbxBody.ContentPadding.Top = 4;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.gbxBody.Location = new System.Drawing.Point(0, 73);
            this.gbxBody.Size = new System.Drawing.Size(1637, 789);
            // 
            // lbl_PLANTCODE_H
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.Name = "맑은 고딕";
            appearance2.FontData.SizeInPoints = 9.75F;
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.lbl_PLANTCODE_H.Appearance = appearance2;
            this.lbl_PLANTCODE_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_PLANTCODE_H.DbField = null;
            this.lbl_PLANTCODE_H.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_PLANTCODE_H.Location = new System.Drawing.Point(110, 10);
            this.lbl_PLANTCODE_H.Name = "lbl_PLANTCODE_H";
            this.lbl_PLANTCODE_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_PLANTCODE_H.Size = new System.Drawing.Size(145, 25);
            this.lbl_PLANTCODE_H.TabIndex = 221;
            this.lbl_PLANTCODE_H.Text = "사업장";
            // 
            // cbo_PLANTCODE_H
            // 
            this.cbo_PLANTCODE_H.AutoSize = false;
            this.cbo_PLANTCODE_H.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cbo_PLANTCODE_H.Location = new System.Drawing.Point(110, 32);
            this.cbo_PLANTCODE_H.Name = "cbo_PLANTCODE_H";
            this.cbo_PLANTCODE_H.Size = new System.Drawing.Size(160, 27);
            this.cbo_PLANTCODE_H.TabIndex = 0;
            // 
            // lbl_WORKCENTERCODE_H
            // 
            appearance6.FontData.BoldAsString = "False";
            appearance6.FontData.SizeInPoints = 9.75F;
            appearance6.FontData.UnderlineAsString = "False";
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Middle";
            this.lbl_WORKCENTERCODE_H.Appearance = appearance6;
            this.lbl_WORKCENTERCODE_H.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lbl_WORKCENTERCODE_H.DbField = "";
            this.lbl_WORKCENTERCODE_H.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_WORKCENTERCODE_H.Location = new System.Drawing.Point(726, 10);
            this.lbl_WORKCENTERCODE_H.Name = "lbl_WORKCENTERCODE_H";
            this.lbl_WORKCENTERCODE_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lbl_WORKCENTERCODE_H.Size = new System.Drawing.Size(145, 25);
            this.lbl_WORKCENTERCODE_H.TabIndex = 241;
            this.lbl_WORKCENTERCODE_H.Text = "작업장";
            // 
            // txt_WORKCENTERCODE_H
            // 
            appearance49.FontData.BoldAsString = "False";
            appearance49.FontData.Name = "맑은 고딕";
            appearance49.FontData.SizeInPoints = 10F;
            appearance49.FontData.UnderlineAsString = "False";
            appearance49.ForeColor = System.Drawing.Color.Black;
            this.txt_WORKCENTERCODE_H.Appearance = appearance49;
            this.txt_WORKCENTERCODE_H.AutoSize = false;
            this.txt_WORKCENTERCODE_H.btnImgType = WIZ.Control.SBtnTextEditor.ButtonImgTypeEnum.Type1;
            this.txt_WORKCENTERCODE_H.btnWidth = 26;
            this.txt_WORKCENTERCODE_H.Location = new System.Drawing.Point(726, 32);
            this.txt_WORKCENTERCODE_H.Name = "txt_WORKCENTERCODE_H";
            this.txt_WORKCENTERCODE_H.RequireFlag = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txt_WORKCENTERCODE_H.RequirePop = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            this.txt_WORKCENTERCODE_H.Size = new System.Drawing.Size(145, 27);
            this.txt_WORKCENTERCODE_H.TabIndex = 247;
            // 
            // cbo_ENDDATE_H
            // 
            this.cbo_ENDDATE_H.AutoSize = false;
            this.cbo_ENDDATE_H.DateButtons.Add(dateButton1);
            this.cbo_ENDDATE_H.Location = new System.Drawing.Point(516, 32);
            this.cbo_ENDDATE_H.Name = "cbo_ENDDATE_H";
            this.cbo_ENDDATE_H.NonAutoSizeHeight = 26;
            this.cbo_ENDDATE_H.Size = new System.Drawing.Size(160, 27);
            this.cbo_ENDDATE_H.TabIndex = 249;
            // 
            // cbo_STARTDATE_H
            // 
            this.cbo_STARTDATE_H.AutoSize = false;
            this.cbo_STARTDATE_H.DateButtons.Add(dateButton2);
            this.cbo_STARTDATE_H.Location = new System.Drawing.Point(320, 32);
            this.cbo_STARTDATE_H.Name = "cbo_STARTDATE_H";
            this.cbo_STARTDATE_H.NonAutoSizeHeight = 26;
            this.cbo_STARTDATE_H.Size = new System.Drawing.Size(160, 27);
            this.cbo_STARTDATE_H.TabIndex = 248;
            // 
            // lbl_DATE_H
            // 
            appearance4.FontData.SizeInPoints = 9.75F;
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.lbl_DATE_H.Appearance = appearance4;
            this.lbl_DATE_H.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_DATE_H.Location = new System.Drawing.Point(320, 10);
            this.lbl_DATE_H.Name = "lbl_DATE_H";
            this.lbl_DATE_H.Size = new System.Drawing.Size(145, 25);
            this.lbl_DATE_H.TabIndex = 250;
            this.lbl_DATE_H.Text = "설비점검일자";
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
            appearance46.BackColor = System.Drawing.SystemColors.Window;
            appearance46.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance46;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance47.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance47.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance47.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance47.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance47;
            appearance48.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance48;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance50.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance50.BackColor2 = System.Drawing.SystemColors.Control;
            appearance50.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance50.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance50;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance53.BackColor = System.Drawing.SystemColors.Window;
            appearance53.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance53;
            appearance54.BackColor = System.Drawing.SystemColors.Highlight;
            appearance54.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance54;
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
            appearance55.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance55;
            appearance56.BorderColor = System.Drawing.Color.Silver;
            appearance56.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance56;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance57.BackColor = System.Drawing.SystemColors.Control;
            appearance57.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance57.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance57.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance57.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance57;
            appearance58.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance58;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance59.BackColor = System.Drawing.SystemColors.Window;
            appearance59.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance59;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance60.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance60;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(4, 4);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1629, 781);
            this.grid1.TabIndex = 698;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txt_WORKCENTERNAME_H
            // 
            this.txt_WORKCENTERNAME_H.AutoSize = false;
            this.txt_WORKCENTERNAME_H.Location = new System.Drawing.Point(870, 32);
            this.txt_WORKCENTERNAME_H.Name = "txt_WORKCENTERNAME_H";
            this.txt_WORKCENTERNAME_H.Size = new System.Drawing.Size(200, 27);
            this.txt_WORKCENTERNAME_H.TabIndex = 243;
            // 
            // sLabel4
            // 
            appearance17.FontData.BoldAsString = "False";
            appearance17.FontData.UnderlineAsString = "False";
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.TextHAlignAsString = "Center";
            appearance17.TextVAlignAsString = "Middle";
            this.sLabel4.Appearance = appearance17;
            this.sLabel4.DbField = null;
            this.sLabel4.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.sLabel4.Location = new System.Drawing.Point(480, 32);
            this.sLabel4.Name = "sLabel4";
            this.sLabel4.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel4.Size = new System.Drawing.Size(36, 27);
            this.sLabel4.TabIndex = 680;
            this.sLabel4.Text = "~";
            // 
            // PP0240
            // 
            this.ClientSize = new System.Drawing.Size(1637, 862);
            this.Name = "PP0240";
            this.Text = "작업장 별 설비점검 이력";
            this.Load += new System.EventHandler(this.PP0240_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbo_PLANTCODE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WORKCENTERCODE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_ENDDATE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_STARTDATE_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_WORKCENTERNAME_H)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.SLabel lbl_PLANTCODE_H;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbo_PLANTCODE_H;
        private Control.SLabel lbl_WORKCENTERCODE_H;
        private Control.SBtnTextEditor txt_WORKCENTERCODE_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cbo_ENDDATE_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo cbo_STARTDATE_H;
        private Infragistics.Win.Misc.UltraLabel lbl_DATE_H;
        private Control.Grid grid1;
        private WIZ.Control.STextBox txt_WORKCENTERNAME_H;
        private Control.SLabel sLabel4;
    }
}

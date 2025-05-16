namespace WIZ.BM
{
    partial class BM7100
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
            Infragistics.Win.Appearance appearance370 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance371 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance372 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance373 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance374 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance375 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance376 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance377 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance378 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance379 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance380 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance381 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance382 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance383 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            this.cboPlantCode_G = new WIZ.Control.SCodeNMComboBox();
            this.btnSample = new Infragistics.Win.Misc.UltraButton();
            this.grid1 = new WIZ.Control.Grid(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Size = new System.Drawing.Size(1136, 0);
            this.gbxHeader.TabIndex = 0;
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Controls.Add(this.btnSample);
            this.gbxBody.Controls.Add(this.cboPlantCode_G);
            this.gbxBody.Location = new System.Drawing.Point(0, 0);
            this.gbxBody.Size = new System.Drawing.Size(1136, 774);
            this.gbxBody.TabIndex = 1;
            // 
            // cboPlantCode_G
            // 
            this.cboPlantCode_G.AutoSize = false;
            this.cboPlantCode_G.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cboPlantCode_G.ComboDataType = WIZ.Control.ComboDataType.CodeOnly;
            this.cboPlantCode_G.DbConfig = null;
            this.cboPlantCode_G.DefaultValue = "";
            appearance370.BackColor = System.Drawing.SystemColors.Window;
            appearance370.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboPlantCode_G.DisplayLayout.Appearance = appearance370;
            this.cboPlantCode_G.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.cboPlantCode_G.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cboPlantCode_G.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance371.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance371.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance371.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance371.BorderColor = System.Drawing.SystemColors.Window;
            this.cboPlantCode_G.DisplayLayout.GroupByBox.Appearance = appearance371;
            appearance372.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cboPlantCode_G.DisplayLayout.GroupByBox.BandLabelAppearance = appearance372;
            this.cboPlantCode_G.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance373.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance373.BackColor2 = System.Drawing.SystemColors.Control;
            appearance373.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance373.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cboPlantCode_G.DisplayLayout.GroupByBox.PromptAppearance = appearance373;
            this.cboPlantCode_G.DisplayLayout.MaxColScrollRegions = 1;
            this.cboPlantCode_G.DisplayLayout.MaxRowScrollRegions = 1;
            appearance374.BackColor = System.Drawing.SystemColors.Window;
            appearance374.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboPlantCode_G.DisplayLayout.Override.ActiveCellAppearance = appearance374;
            appearance375.BackColor = System.Drawing.SystemColors.Highlight;
            appearance375.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cboPlantCode_G.DisplayLayout.Override.ActiveRowAppearance = appearance375;
            appearance376.FontData.BoldAsString = "True";
            this.cboPlantCode_G.DisplayLayout.Override.ActiveRowCellAppearance = appearance376;
            this.cboPlantCode_G.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cboPlantCode_G.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cboPlantCode_G.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.None;
            appearance377.BackColor = System.Drawing.SystemColors.Window;
            this.cboPlantCode_G.DisplayLayout.Override.CardAreaAppearance = appearance377;
            appearance378.BorderColor = System.Drawing.Color.Silver;
            appearance378.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cboPlantCode_G.DisplayLayout.Override.CellAppearance = appearance378;
            this.cboPlantCode_G.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cboPlantCode_G.DisplayLayout.Override.CellPadding = 0;
            appearance379.BackColor = System.Drawing.SystemColors.Control;
            appearance379.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance379.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance379.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance379.BorderColor = System.Drawing.SystemColors.Window;
            this.cboPlantCode_G.DisplayLayout.Override.GroupByRowAppearance = appearance379;
            appearance380.TextHAlignAsString = "Left";
            this.cboPlantCode_G.DisplayLayout.Override.HeaderAppearance = appearance380;
            this.cboPlantCode_G.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cboPlantCode_G.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance381.BackColor = System.Drawing.SystemColors.Window;
            appearance381.BorderColor = System.Drawing.Color.Silver;
            this.cboPlantCode_G.DisplayLayout.Override.RowAppearance = appearance381;
            this.cboPlantCode_G.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance382.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(133)))), ((int)(((byte)(188)))));
            appearance382.FontData.BoldAsString = "True";
            this.cboPlantCode_G.DisplayLayout.Override.SelectedRowAppearance = appearance382;
            appearance383.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cboPlantCode_G.DisplayLayout.Override.TemplateAddRowAppearance = appearance383;
            this.cboPlantCode_G.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cboPlantCode_G.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cboPlantCode_G.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.cboPlantCode_G.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cboPlantCode_G.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cboPlantCode_G.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboPlantCode_G.Location = new System.Drawing.Point(174, 153);
            this.cboPlantCode_G.MajorCode = "PLANTCODE";
            this.cboPlantCode_G.Name = "cboPlantCode_G";
            this.cboPlantCode_G.SelectedValue = null;
            this.cboPlantCode_G.ShowDefaultValue = true;
            this.cboPlantCode_G.Size = new System.Drawing.Size(125, 25);
            this.cboPlantCode_G.TabIndex = 51;
            // 
            // btnSample
            // 
            this.btnSample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance1.FontData.BoldAsString = "True";
            appearance1.FontData.Name = "SimSun";
            appearance1.FontData.SizeInPoints = 50F;
            this.btnSample.Appearance = appearance1;
            this.btnSample.Location = new System.Drawing.Point(13, 675);
            this.btnSample.Name = "btnSample";
            this.btnSample.Size = new System.Drawing.Size(428, 87);
            this.btnSample.TabIndex = 52;
            this.btnSample.Text = "SAMPLE";
            this.btnSample.Click += new System.EventHandler(this.btnSample_Click);
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
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance4;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance5;
            appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance7;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance6.BackColor2 = System.Drawing.SystemColors.Control;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance6;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance12;
            appearance8.BackColor = System.Drawing.SystemColors.Highlight;
            appearance8.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance8;
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
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance15;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance11;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Center";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance13;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance14.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance14;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.grid1.Location = new System.Drawing.Point(6, 6);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1124, 762);
            this.grid1.TabIndex = 53;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid1_KeyDown);
            // 
            // BM7100
            // 
            this.ClientSize = new System.Drawing.Size(1136, 774);
            this.Name = "BM7100";
            this.Load += new System.EventHandler(this.BM1000_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.SCodeNMComboBox cboPlantCode_G;
        private Infragistics.Win.Misc.UltraButton btnSample;
        private Control.Grid grid1;
    }
}

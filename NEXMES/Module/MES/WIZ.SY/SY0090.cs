using Infragistics.Win;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.Control;
using WIZ.Forms;

namespace WIZ.SY
{
    public class SY0090 : BaseMDIChildForm
    {
        private UltraGridUtil _GridUtil = new UltraGridUtil();

        private Common _Common = new Common();

        private new IContainer components = null;

        private WIZ.Control.Grid grid1;

        private SLabel lblPlanDT;

        private SLabel lblMaker;

        private SLabel sLabel1;

        private SCodeNMComboBox cboLang;

        private WIZ.Control.STextBox txtWord;

        private WIZ.Control.STextBox txtDiv;

        public SY0090()
        {
            InitializeComponent();
        }

        private void SY0090_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "Lang", "언어", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "wKey", "Key문장", false, GridColDataType_emu.VarChar, 500, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "OpKey", "구분", false, GridColDataType_emu.VarChar, 80, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "Translate", "번역 문장", false, GridColDataType_emu.VarChar, 1000, true, true);
            _GridUtil.SetColumnTextHAlign(grid1, "wKey", HAlign.Left);
            _GridUtil.SetColumnTextHAlign(grid1, "Translate", HAlign.Left);
            _GridUtil.SetHeadForeColor(grid1, "Translate", Color.Yellow);
            _GridUtil.SetHeadColumnBold(grid1, "Translate");
            _GridUtil.SetInitUltraGridBind(grid1);
            DataTable dtInData = _Common.GET_BM0000_CODE("LANG");
            UltraGridUtil.SetComboUltraGrid(grid1, "Lang", dtInData, "CODE_ID", "CODE_NAME");
        }

        public override void DoInquire()
        {
            base.DoInquire();
            _GridUtil.Grid_Clear(grid1);
            DBHelper dBHelper = new DBHelper(completedClose: false);
            try
            {
                DataTable dataTable = dBHelper.FillTable("USP_SY0090_S1", CommandType.StoredProcedure, false, true, dBHelper.CreateParameter("Lang", (cboLang.Value.ToString() == "ALL") ? "" : cboLang.Value.ToString(), DbType.DateTime, ParameterDirection.Input), dBHelper.CreateParameter("wKey", txtWord.Text, DbType.DateTime, ParameterDirection.Input), dBHelper.CreateParameter("OpKey", txtDiv.Text, DbType.DateTime, ParameterDirection.Input));
                if (dataTable != null)
                {
                    grid1.DataSource = dataTable;
                    grid1.DataBinds();
                }
            }
            catch (Exception ex)
            {
                ThrowError(ex);
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public override void DoNew()
        {
            try
            {
                base.DoNew();
                int dtRowNum = grid1.InsertRow();
                UltraGridUtil.ActivationAllowEdit(grid1, "Lang", dtRowNum);
                UltraGridUtil.ActivationAllowEdit(grid1, "wKey", dtRowNum);
                UltraGridUtil.ActivationAllowEdit(grid1, "OpKey", dtRowNum);
            }
            catch (Exception ex)
            {
                ThrowError(ex);
            }
        }

        public override void DoDelete()
        {
            base.DoDelete();
            if (grid1.IsActivate)
            {
                grid1.DeleteRow();
            }
        }

        public override void DoSave()
        {
            DataTable dataTable = grid1.chkChange();
            if (dataTable != null)
            {
                DBHelper dBHelper = new DBHelper("", bTrans: true);
                try
                {
                    Focus();
                    if (ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) == DialogResult.Cancel)
                    {
                        base.CancelProcess = true;
                    }
                    else
                    {
                        base.DoSave();
                        foreach (DataRow row in dataTable.Rows)
                        {
                            switch (row.RowState)
                            {
                                case DataRowState.Deleted:
                                    row.RejectChanges();
                                    dBHelper.ExecuteNoneQuery("USP_SY0090_D1", CommandType.StoredProcedure, false, true, dBHelper.CreateParameter("Lang", Convert.ToString(row["Lang"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("wKey", Convert.ToString(row["wKey"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("OpKey", Convert.ToString(row["OpKey"]), DbType.String, ParameterDirection.Input));
                                    row.Delete();
                                    break;
                                case DataRowState.Added:
                                    dBHelper.ExecuteNoneQuery("USP_SY0090_I2", CommandType.StoredProcedure, false, false, dBHelper.CreateParameter("Lang", Convert.ToString(row["Lang"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("wKey", Convert.ToString(row["wKey"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("OpKey", Convert.ToString(row["OpKey"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("Translate", Convert.ToString(row["Translate"]), DbType.String, ParameterDirection.Input));
                                    break;
                                case DataRowState.Modified:
                                    dBHelper.ExecuteNoneQuery("USP_SY0090_U1", CommandType.StoredProcedure, false, true, dBHelper.CreateParameter("Lang", Convert.ToString(row["Lang"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("wKey", Convert.ToString(row["wKey"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("OpKey", Convert.ToString(row["OpKey"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("Translate", Convert.ToString(row["Translate"]), DbType.String, ParameterDirection.Input));
                                    break;
                            }
                            grid1.SetRowError(row, dBHelper.RSMSG, dBHelper.RSCODE);
                        }
                        grid1.SetAcceptChanges();
                        dBHelper.Commit();
                    }
                }
                catch (Exception ex)
                {
                    base.CancelProcess = true;
                    dBHelper.Rollback();
                    ShowDialog(ex.ToString());
                }
                finally
                {
                    dBHelper.Close();
                }
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

        private new void InitializeComponent()
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
            lblPlanDT = new WIZ.Control.SLabel();
            lblMaker = new WIZ.Control.SLabel();
            grid1 = new WIZ.Control.Grid(components);
            sLabel1 = new WIZ.Control.SLabel();
            cboLang = new WIZ.Control.SCodeNMComboBox();
            txtWord = new WIZ.Control.STextBox(components);
            txtDiv = new WIZ.Control.STextBox(components);
            ((System.ComponentModel.ISupportInitialize)gbxHeader).BeginInit();
            gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gbxBody).BeginInit();
            gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboLang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtWord).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDiv).BeginInit();
            SuspendLayout();
            gbxHeader.ContentPadding.Bottom = 2;
            gbxHeader.ContentPadding.Left = 2;
            gbxHeader.ContentPadding.Right = 2;
            gbxHeader.ContentPadding.Top = 4;
            gbxHeader.Controls.Add(txtDiv);
            gbxHeader.Controls.Add(txtWord);
            gbxHeader.Controls.Add(cboLang);
            gbxHeader.Controls.Add(sLabel1);
            gbxHeader.Controls.Add(lblMaker);
            gbxHeader.Controls.Add(lblPlanDT);
            gbxHeader.Controls.SetChildIndex(lblPlanDT, 0);
            gbxHeader.Controls.SetChildIndex(lblMaker, 0);
            gbxHeader.Controls.SetChildIndex(sLabel1, 0);
            gbxHeader.Controls.SetChildIndex(cboLang, 0);
            gbxHeader.Controls.SetChildIndex(txtWord, 0);
            gbxHeader.Controls.SetChildIndex(txtDiv, 0);
            gbxBody.ContentPadding.Bottom = 4;
            gbxBody.ContentPadding.Left = 4;
            gbxBody.ContentPadding.Right = 4;
            gbxBody.ContentPadding.Top = 6;
            gbxBody.Controls.Add(grid1);
            appearance.FontData.BoldAsString = "False";
            appearance.FontData.UnderlineAsString = "False";
            appearance.ForeColor = System.Drawing.Color.Black;
            appearance.TextHAlignAsString = "Left";
            appearance.TextVAlignAsString = "Middle";
            lblPlanDT.Appearance = appearance;
            lblPlanDT.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            lblPlanDT.DbField = null;
            lblPlanDT.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblPlanDT.Location = new System.Drawing.Point(110, 10);
            lblPlanDT.Name = "lblPlanDT";
            lblPlanDT.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblPlanDT.Size = new System.Drawing.Size(145, 25);
            lblPlanDT.TabIndex = 16;
            lblPlanDT.Text = "언어";
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            lblMaker.Appearance = appearance2;
            lblMaker.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            lblMaker.DbField = null;
            lblMaker.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblMaker.Location = new System.Drawing.Point(306, 10);
            lblMaker.Name = "lblMaker";
            lblMaker.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblMaker.Size = new System.Drawing.Size(145, 25);
            lblMaker.TabIndex = 19;
            lblMaker.Text = "Key문장";
            grid1.AutoResizeColumn = true;
            grid1.AutoUserColumn = true;
            grid1.ContextMenuCopyEnabled = true;
            grid1.ContextMenuDeleteEnabled = false;
            grid1.ContextMenuExcelEnabled = true;
            grid1.ContextMenuInsertEnabled = false;
            grid1.ContextMenuPasteEnabled = true;
            grid1.DeleteButtonEnable = true;
            appearance3.BorderColor = System.Drawing.Color.FromArgb(224, 224, 224);
            grid1.DisplayLayout.Appearance = appearance3;
            grid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.Color.Gray;
            grid1.DisplayLayout.CaptionAppearance = appearance4;
            grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.RoyalBlue;
            grid1.DisplayLayout.GroupByBox.Hidden = true;
            grid1.DisplayLayout.InterBandSpacing = 2;
            grid1.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance5.BackColor = System.Drawing.Color.RoyalBlue;
            appearance5.FontData.BoldAsString = "True";
            appearance5.ForeColor = System.Drawing.Color.White;
            grid1.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.All;
            grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010ScrollbarButton;
            appearance6.BackColor = System.Drawing.Color.DimGray;
            appearance6.BackColor2 = System.Drawing.Color.Silver;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.BorderColor = System.Drawing.Color.White;
            appearance6.FontData.BoldAsString = "True";
            appearance6.ForeColor = System.Drawing.Color.White;
            grid1.DisplayLayout.Override.HeaderAppearance = appearance6;
            grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance7.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            appearance7.BackColor2 = System.Drawing.Color.Gray;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            grid1.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance7;
            grid1.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            grid1.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
            grid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.RowConnectorColor = System.Drawing.Color.Silver;
            grid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            grid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            grid1.EnterNextRowEnable = true;
            grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75f);
            grid1.Location = new System.Drawing.Point(6, 6);
            grid1.Name = "grid1";
            grid1.Size = new System.Drawing.Size(1124, 743);
            grid1.TabIndex = 3;
            grid1.Text = "DE";
            grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            appearance8.FontData.BoldAsString = "False";
            appearance8.FontData.UnderlineAsString = "False";
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Left";
            appearance8.TextVAlignAsString = "Middle";
            sLabel1.Appearance = appearance8;
            sLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            sLabel1.DbField = null;
            sLabel1.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            sLabel1.Location = new System.Drawing.Point(652, 10);
            sLabel1.Name = "sLabel1";
            sLabel1.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            sLabel1.Size = new System.Drawing.Size(145, 25);
            sLabel1.TabIndex = 216;
            sLabel1.Text = "구분";
            cboLang.AutoSize = false;
            cboLang.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            cboLang.ComboDataType = WIZ.Control.ComboDataType.All;
            cboLang.DbConfig = null;
            cboLang.DefaultValue = "";
            appearance9.BorderColor = System.Drawing.Color.FromArgb(224, 224, 224);
            cboLang.DisplayLayout.Appearance = appearance9;
            cboLang.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            cboLang.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            cboLang.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance10.BackColor = System.Drawing.Color.Gray;
            cboLang.DisplayLayout.CaptionAppearance = appearance10;
            cboLang.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            cboLang.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.RoyalBlue;
            cboLang.DisplayLayout.InterBandSpacing = 2;
            cboLang.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance11.BackColor = System.Drawing.Color.RoyalBlue;
            appearance11.FontData.BoldAsString = "True";
            appearance11.ForeColor = System.Drawing.Color.White;
            cboLang.DisplayLayout.Override.ActiveRowAppearance = appearance11;
            appearance12.FontData.BoldAsString = "True";
            cboLang.DisplayLayout.Override.ActiveRowCellAppearance = appearance12;
            cboLang.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            cboLang.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            cboLang.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.None;
            cboLang.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010ScrollbarButton;
            appearance13.BackColor = System.Drawing.Color.DimGray;
            appearance13.BackColor2 = System.Drawing.Color.Silver;
            appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance13.BorderColor = System.Drawing.Color.White;
            appearance13.FontData.BoldAsString = "True";
            appearance13.ForeColor = System.Drawing.Color.White;
            cboLang.DisplayLayout.Override.HeaderAppearance = appearance13;
            cboLang.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance14.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            appearance14.BackColor2 = System.Drawing.Color.Gray;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            cboLang.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance14;
            cboLang.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            cboLang.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            cboLang.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            cboLang.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
            appearance15.BackColor = System.Drawing.Color.FromArgb(99, 133, 188);
            appearance15.FontData.BoldAsString = "True";
            cboLang.DisplayLayout.Override.SelectedRowAppearance = appearance15;
            cboLang.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            cboLang.DisplayLayout.RowConnectorColor = System.Drawing.Color.Silver;
            cboLang.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            cboLang.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            cboLang.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            cboLang.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            cboLang.Location = new System.Drawing.Point(110, 35);
            cboLang.MajorCode = "LANG";
            cboLang.Name = "cboLang";
            cboLang.SelectedValue = null;
            cboLang.ShowDefaultValue = true;
            cboLang.Size = new System.Drawing.Size(150, 26);
            cboLang.TabIndex = 220;
            appearance16.FontData.BoldAsString = "False";
            appearance16.FontData.UnderlineAsString = "False";
            appearance16.ForeColor = System.Drawing.Color.Black;
            txtWord.Appearance = appearance16;
            txtWord.AutoSize = false;
            txtWord.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtWord.Location = new System.Drawing.Point(306, 35);
            txtWord.Name = "txtWord";
            txtWord.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtWord.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtWord.Size = new System.Drawing.Size(300, 26);
            txtWord.TabIndex = 244;
            appearance17.FontData.BoldAsString = "False";
            appearance17.FontData.UnderlineAsString = "False";
            appearance17.ForeColor = System.Drawing.Color.Black;
            txtDiv.Appearance = appearance17;
            txtDiv.AutoSize = false;
            txtDiv.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtDiv.Location = new System.Drawing.Point(652, 35);
            txtDiv.Name = "txtDiv";
            txtDiv.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtDiv.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtDiv.Size = new System.Drawing.Size(150, 26);
            txtDiv.TabIndex = 245;
            base.ClientSize = new System.Drawing.Size(1136, 825);
            base.Name = "SY0090";
            base.Load += new System.EventHandler(SY0090_Load);
            ((System.ComponentModel.ISupportInitialize)gbxHeader).EndInit();
            gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gbxBody).EndInit();
            gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grid1).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboLang).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtWord).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDiv).EndInit();
            ResumeLayout(false);
        }
    }
}

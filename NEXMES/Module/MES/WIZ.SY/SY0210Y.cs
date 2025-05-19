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
    public class SY0210Y : BaseMDIChildForm
    {
        private UltraGridUtil _GridUtil = new UltraGridUtil();

        private Common _Common = new Common();

        private DataTable rtnDtTemp = new DataTable();

        private new IContainer components = null;

        private SLabel lblUseFlag_H;

        private WIZ.Control.Grid grid1;

        private UltraTextEditor txtPwd;

        private ScboGRPIDCode cboGrpID;

        private SCodeNMComboBox cboUseFlag_H;

        private SBtnTextEditor txtCustCode_H;

        private UltraTextEditor txtCustName_H;

        private SLabel lblWorkerID;

        public SY0210Y()
        {
            InitializeComponent();
        }

        private void SY0210Y_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", false, GridColDataType_emu.VarChar, 120, 100, HAlign.Left);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "외주업체", false, GridColDataType_emu.VarChar, 200, 100, HAlign.Left);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERID", "사용자ID", false, GridColDataType_emu.VarChar, 120, 100, HAlign.Center);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME", "사용자명", false, GridColDataType_emu.VarChar, 200, 100, HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PWD", "패스워드", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG", "사용여부", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 80, 100, HAlign.Center);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일자", false, GridColDataType_emu.VarChar, 150, 100, HAlign.Center);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 80, 100, HAlign.Center);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일자", false, GridColDataType_emu.VarChar, 150, 100, HAlign.Center);
            _GridUtil.SetInitUltraGridBind(grid1);
            rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            rtnDtTemp = _Common.GET_BM0030_CODE(LoginInfo.PlantCode, "V");
            UltraGridUtil.SetComboUltraGrid(grid1, "CUSTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");
            rtnDtTemp = _Common.GET_BM0000_CODE("USEFLAG");
            UltraGridUtil.SetComboUltraGrid(grid1, "USEFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");
            txtCustCode_H.ControlAdded += tCodeControlAdd;
            txtCustName_H.ControlAdded += tNameControlAdd;
        }

        public override void DoInquire()
        {
            DBHelper dBHelper = new DBHelper(completedClose: false);
            try
            {
                base.DoInquire();
                string plantCode = LoginInfo.PlantCode;
                string value = DBHelper.nvlString(txtCustCode_H.Text);
                string value2 = DBHelper.nvlString(txtCustName_H.Text);
                string value3 = DBHelper.nvlString(cboUseFlag_H.Value);
                rtnDtTemp = dBHelper.FillTable("USP_SY0210Y_S1", CommandType.StoredProcedure, dBHelper.CreateParameter("PLANTCODE", plantCode, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("CUSTCODE", value, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("CUSTNAME", value2, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("USEFLAG", value3, DbType.String, ParameterDirection.Input));
                ClosePrgForm();
                grid1.DataSource = rtnDtTemp;
                grid1.DataBind();
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellAppearance.TextVAlign = VAlign.Top;
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
                grid1.DisplayLayout.Bands[0].Columns["CUSTCODE"].MergedCellStyle = MergedCellStyle.Always;
                grid1.DisplayLayout.Bands[0].Columns["CUSTCODE"].MergedCellAppearance.TextVAlign = VAlign.Top;
                grid1.DisplayLayout.Bands[0].Columns["CUSTCODE"].MergedCellContentArea = MergedCellContentArea.VisibleRect;
                grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["CUSTCODE"].CellActivation = Activation.NoEdit;
                grid1.DisplayLayout.Bands[0].Columns["WORKERID"].CellActivation = Activation.NoEdit;
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
                grid1.SetDefaultValue("PLANTCODE", LoginInfo.PlantCode);
                grid1.SetDefaultValue("USEFLAG", "Y");
                UltraGridUtil.ActivationAllowEdit(grid1, "PLANTCODE", dtRowNum);
                UltraGridUtil.ActivationAllowEdit(grid1, "CUSTCODE", dtRowNum);
                UltraGridUtil.ActivationAllowEdit(grid1, "WORKERID", dtRowNum);
                UltraGridUtil.ActivationAllowEdit(grid1, "WORKERNAME", dtRowNum);
                UltraGridUtil.ActivationAllowEdit(grid1, "PWD", dtRowNum);
                UltraGridUtil.ActivationAllowEdit(grid1, "USEFLAG", dtRowNum);
            }
            catch (Exception ex)
            {
                ThrowError(ex);
            }
        }

        public override void DoDelete()
        {
            base.DoDelete();
            grid1.DeleteRow();
        }

        public override void DoSave()
        {
            DataTable dataTable = grid1.chkChange();
            if (dataTable != null)
            {
                DBHelper dBHelper = new DBHelper(completedClose: false);
                try
                {
                    Focus();
                    if (ShowDialog(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG")) != DialogResult.Cancel)
                    {
                        base.DoSave();
                        grid1.UpdateData();
                        UltraGridUtil.DataRowDelete(grid1);
                        grid1.PerformAction(UltraGridAction.DeactivateCell);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (row.RowState != DataRowState.Deleted)
                            {
                                if (DBHelper.nvlString(row["PLANTCODE"]) == string.Empty)
                                {
                                    ClosePrgForm();
                                    ShowDialog(Common.getLangText("공장을 선택하세요. 필수 항목입니다.", "MSG"), DialogForm.DialogType.OK);
                                    return;
                                }
                                if (DBHelper.nvlString(row["CUSTCODE"]) == string.Empty)
                                {
                                    ClosePrgForm();
                                    ShowDialog(Common.getLangText("거래처코드를 입력하세요. 필수 항목입니다.", "MSG"), DialogForm.DialogType.OK);
                                    return;
                                }
                                if (DBHelper.nvlString(row["WORKERID"]).Length > 20)
                                {
                                    ClosePrgForm();
                                    ShowDialog(Common.getLangText("사용자ID는 최대 20자리까지 입력 가능합니다.", "MSG"), DialogForm.DialogType.OK);
                                    return;
                                }
                                if (DBHelper.nvlString(row["WORKERNAME"]).Length > 100)
                                {
                                    ClosePrgForm();
                                    ShowDialog(Common.getLangText("사용자명은 최대 100자리까지 입력 가능합니다.", "MSG"), DialogForm.DialogType.OK);
                                    return;
                                }
                            }
                            switch (row.RowState)
                            {
                                case DataRowState.Deleted:
                                    row.RejectChanges();
                                    dBHelper.ExecuteNoneQuery("USP_SY0210Y_D1", CommandType.StoredProcedure, dBHelper.CreateParameter("PLANTCODE", DBHelper.nvlString(row["PLANTCODE"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("WORKERID", DBHelper.nvlString(row["WORKERID"]), DbType.String, ParameterDirection.Input));
                                    row.Delete();
                                    break;
                                case DataRowState.Added:
                                    dBHelper.ExecuteNoneQuery("USP_SY0210Y_I1", CommandType.StoredProcedure, dBHelper.CreateParameter("PLANTCODE", DBHelper.nvlString(row["PLANTCODE"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("CUSTCODE", DBHelper.nvlString(row["CUSTCODE"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("WORKERID", DBHelper.nvlString(row["WORKERID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("WORKERNAME", DBHelper.nvlString(row["WORKERNAME"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("PWD", DBHelper.nvlString(row["PWD"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("USEFLAG", DBHelper.nvlString(row["USEFLAG"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("MAKER", LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                                    break;
                                case DataRowState.Modified:
                                    dBHelper.ExecuteNoneQuery("USP_SY0210Y_U1", CommandType.StoredProcedure, dBHelper.CreateParameter("PLANTCODE", DBHelper.nvlString(row["PLANTCODE"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("CUSTCODE", DBHelper.nvlString(row["CUSTCODE"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("WORKERID", DBHelper.nvlString(row["WORKERID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("WORKERNAME", DBHelper.nvlString(row["WORKERNAME"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("PWD", DBHelper.nvlString(row["PWD"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("USEFLAG", DBHelper.nvlString(row["USEFLAG"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("EDITOR", LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                                    break;
                            }
                        }
                        if (dBHelper.RSCODE == "S")
                        {
                            ClosePrgForm();
                            dBHelper.Commit();
                            DoInquire();
                        }
                        else if (dBHelper.RSCODE == "E")
                        {
                            ClosePrgForm();
                            dBHelper.Rollback();
                            ShowDialog(dBHelper.RSMSG, DialogForm.DialogType.OK);
                        }
                    }
                }
                catch (Exception ex)
                {
                    base.CancelProcess = true;
                    dBHelper.Rollback();
                    ThrowError(ex);
                }
                finally
                {
                    dBHelper.Close();
                }
            }
        }

        private void txtCustCode_H_ButtonClick(object sender, EventArgs e)
        {
            PopManagerBase popManagerBase = new PopManagerBase();
            DataTable dataTable = popManagerBase.OpenPopupShow("WIZ.PopUp", "POP_TBM0301", "거래선정보 검색", new string[5]
            {
                "",
                "",
                LoginInfo.PlantCode,
                "V",
                DBHelper.nvlString(cboUseFlag_H.Value)
            });
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                txtCustCode_H.Text = Convert.ToString(dataTable.Rows[0]["CUSTCODE"]);
                txtCustName_H.Text = Convert.ToString(dataTable.Rows[0]["CUSTNAME"]);
            }
        }

        private void txtCustCode_H_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                PopManagerBase popManagerBase = new PopManagerBase();
                DataTable dataTable = popManagerBase.OpenPopupShow("WIZ.PopUp", "POP_TBM0301", "거래선정보 검색", new string[5]
                {
                    txtCustCode_H.Text,
                    txtCustName_H.Text,
                    LoginInfo.PlantCode,
                    "",
                    DBHelper.nvlString(cboUseFlag_H.Value)
                });
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    txtCustCode_H.Text = Convert.ToString(dataTable.Rows[0]["CUSTCODE"]);
                    txtCustName_H.Text = Convert.ToString(dataTable.Rows[0]["CUSTNAME"]);
                }
            }
            else
            {
                txtCustName_H.Text = string.Empty;
            }
        }

        private void tCodeControlAdd(object sender, ControlEventArgs e)
        {
            e.Control.DoubleClick += tCodeBox_DoubleClick;
        }

        private void tCodeBox_DoubleClick(object sender, EventArgs e)
        {
            txtCustCode_H_ButtonClick(null, null);
        }

        private void tNameControlAdd(object sender, ControlEventArgs e)
        {
            e.Control.DoubleClick += tNameBox_DoubleClick;
        }

        private void tNameBox_DoubleClick(object sender, EventArgs e)
        {
            txtCustCode_H_ButtonClick(null, null);
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
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            lblUseFlag_H = new WIZ.Control.SLabel();
            grid1 = new WIZ.Control.Grid(components);
            txtPwd = new WIZ.Control.STextBox();
            cboGrpID = new WIZ.Control.ScboGRPIDCode();
            cboUseFlag_H = new WIZ.Control.SCodeNMComboBox();
            txtCustCode_H = new WIZ.Control.SBtnTextEditor();
            txtCustName_H = new WIZ.Control.STextBox();
            lblWorkerID = new WIZ.Control.SLabel();
            ((System.ComponentModel.ISupportInitialize)gbxHeader).BeginInit();
            gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gbxBody).BeginInit();
            gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPwd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboGrpID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboUseFlag_H).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCustCode_H).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCustName_H).BeginInit();
            SuspendLayout();
            gbxHeader.ContentPadding.Bottom = 2;
            gbxHeader.ContentPadding.Left = 2;
            gbxHeader.ContentPadding.Right = 2;
            gbxHeader.ContentPadding.Top = 4;
            gbxHeader.Controls.Add(txtCustCode_H);
            gbxHeader.Controls.Add(txtCustName_H);
            gbxHeader.Controls.Add(lblWorkerID);
            gbxHeader.Controls.Add(cboUseFlag_H);
            gbxHeader.Controls.Add(lblUseFlag_H);
            gbxHeader.Size = new System.Drawing.Size(1136, 57);
            gbxHeader.Controls.SetChildIndex(lblUseFlag_H, 0);
            gbxHeader.Controls.SetChildIndex(cboUseFlag_H, 0);
            gbxHeader.Controls.SetChildIndex(lblWorkerID, 0);
            gbxHeader.Controls.SetChildIndex(txtCustName_H, 0);
            gbxHeader.Controls.SetChildIndex(txtCustCode_H, 0);
            gbxBody.ContentPadding.Bottom = 4;
            gbxBody.ContentPadding.Left = 4;
            gbxBody.ContentPadding.Right = 4;
            gbxBody.ContentPadding.Top = 6;
            gbxBody.Controls.Add(grid1);
            gbxBody.Controls.Add(txtPwd);
            gbxBody.Controls.Add(cboGrpID);
            gbxBody.Location = new System.Drawing.Point(0, 57);
            gbxBody.Size = new System.Drawing.Size(1136, 768);
            appearance.FontData.BoldAsString = "False";
            appearance.FontData.UnderlineAsString = "False";
            appearance.ForeColor = System.Drawing.Color.Black;
            appearance.TextHAlignAsString = "Right";
            lblUseFlag_H.Appearance = appearance;
            lblUseFlag_H.DbField = null;
            lblUseFlag_H.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblUseFlag_H.Location = new System.Drawing.Point(493, 16);
            lblUseFlag_H.Name = "lblUseFlag_H";
            lblUseFlag_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblUseFlag_H.Size = new System.Drawing.Size(100, 25);
            lblUseFlag_H.TabIndex = 21;
            lblUseFlag_H.Text = "사용여부";
            grid1.AutoResizeColumn = true;
            grid1.AutoUserColumn = true;
            grid1.ContextMenuCopyEnabled = true;
            grid1.ContextMenuDeleteEnabled = true;
            grid1.ContextMenuExcelEnabled = true;
            grid1.ContextMenuInsertEnabled = true;
            grid1.ContextMenuPasteEnabled = true;
            grid1.DeleteButtonEnable = true;
            grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            grid1.DisplayLayout.GroupByBox.Hidden = true;
            grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.All;
            grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            grid1.EnterNextRowEnable = true;
            grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75f);
            grid1.Location = new System.Drawing.Point(6, 6);
            grid1.Name = "grid1";
            grid1.Size = new System.Drawing.Size(1124, 756);
            grid1.TabIndex = 31;
            grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus;
            grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            txtPwd.Location = new System.Drawing.Point(275, 131);
            txtPwd.Name = "txtPwd";
            txtPwd.Nullable = false;
            txtPwd.PasswordChar = '*';
            txtPwd.Size = new System.Drawing.Size(100, 29);
            txtPwd.TabIndex = 3;
            cboGrpID.ComboDataType = WIZ.Control.ComboDataType.CodeOnly;
            cboGrpID.DbConfig = null;
            cboGrpID.DefaultValue = "";
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            cboGrpID.DisplayLayout.Appearance = appearance2;
            cboGrpID.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            cboGrpID.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            cboGrpID.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            cboGrpID.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            cboGrpID.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            cboGrpID.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            cboGrpID.DisplayLayout.MaxColScrollRegions = 1;
            cboGrpID.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            cboGrpID.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            cboGrpID.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            cboGrpID.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            cboGrpID.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            cboGrpID.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            cboGrpID.DisplayLayout.Override.CellAppearance = appearance9;
            cboGrpID.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            cboGrpID.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            cboGrpID.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.TextHAlignAsString = "Left";
            cboGrpID.DisplayLayout.Override.HeaderAppearance = appearance11;
            cboGrpID.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            cboGrpID.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            cboGrpID.DisplayLayout.Override.RowAppearance = appearance12;
            cboGrpID.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            cboGrpID.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            cboGrpID.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            cboGrpID.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            cboGrpID.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            cboGrpID.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            cboGrpID.Location = new System.Drawing.Point(250, 139);
            cboGrpID.MajorCode = null;
            cboGrpID.Name = "cboGrpID";
            cboGrpID.ShowDefaultValue = false;
            cboGrpID.Size = new System.Drawing.Size(145, 30);
            cboGrpID.TabIndex = 32;
            cboUseFlag_H.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            cboUseFlag_H.ComboDataType = WIZ.Control.ComboDataType.All;
            cboUseFlag_H.DbConfig = null;
            cboUseFlag_H.DefaultValue = "";
            appearance14.BorderColor = System.Drawing.Color.FromArgb(224, 224, 224);
            cboUseFlag_H.DisplayLayout.Appearance = appearance14;
            cboUseFlag_H.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            cboUseFlag_H.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            cboUseFlag_H.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance15.BackColor = System.Drawing.Color.Gray;
            cboUseFlag_H.DisplayLayout.CaptionAppearance = appearance15;
            cboUseFlag_H.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            cboUseFlag_H.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.RoyalBlue;
            cboUseFlag_H.DisplayLayout.InterBandSpacing = 2;
            cboUseFlag_H.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance16.BackColor = System.Drawing.Color.RoyalBlue;
            appearance16.FontData.BoldAsString = "True";
            appearance16.ForeColor = System.Drawing.Color.White;
            cboUseFlag_H.DisplayLayout.Override.ActiveRowAppearance = appearance16;
            appearance17.FontData.BoldAsString = "True";
            cboUseFlag_H.DisplayLayout.Override.ActiveRowCellAppearance = appearance17;
            cboUseFlag_H.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            cboUseFlag_H.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            cboUseFlag_H.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.None;
            cboUseFlag_H.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010ScrollbarButton;
            appearance18.BackColor = System.Drawing.Color.DimGray;
            appearance18.BackColor2 = System.Drawing.Color.Silver;
            appearance18.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance18.BorderColor = System.Drawing.Color.White;
            appearance18.FontData.BoldAsString = "True";
            appearance18.ForeColor = System.Drawing.Color.White;
            cboUseFlag_H.DisplayLayout.Override.HeaderAppearance = appearance18;
            cboUseFlag_H.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance19.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            appearance19.BackColor2 = System.Drawing.Color.Gray;
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            cboUseFlag_H.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance19;
            cboUseFlag_H.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            cboUseFlag_H.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            cboUseFlag_H.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            cboUseFlag_H.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
            appearance20.BackColor = System.Drawing.Color.FromArgb(99, 133, 188);
            appearance20.FontData.BoldAsString = "True";
            cboUseFlag_H.DisplayLayout.Override.SelectedRowAppearance = appearance20;
            cboUseFlag_H.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            cboUseFlag_H.DisplayLayout.RowConnectorColor = System.Drawing.Color.Silver;
            cboUseFlag_H.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            cboUseFlag_H.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            cboUseFlag_H.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            cboUseFlag_H.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            cboUseFlag_H.Location = new System.Drawing.Point(599, 16);
            cboUseFlag_H.MajorCode = "USEFLAG";
            cboUseFlag_H.Name = "cboUseFlag_H";
            cboUseFlag_H.SelectedValue = null;
            cboUseFlag_H.ShowDefaultValue = true;
            cboUseFlag_H.Size = new System.Drawing.Size(133, 25);
            cboUseFlag_H.TabIndex = 222;
            appearance21.FontData.BoldAsString = "False";
            appearance21.FontData.UnderlineAsString = "False";
            appearance21.ForeColor = System.Drawing.Color.Black;
            txtCustCode_H.Appearance = appearance21;
            txtCustCode_H.btnImgType = WIZ.Control.SBtnTextEditor.ButtonImgTypeEnum.Type1;
            txtCustCode_H.btnWidth = 26;
            txtCustCode_H.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtCustCode_H.Location = new System.Drawing.Point(174, 15);
            txtCustCode_H.Name = "txtCustCode_H";
            txtCustCode_H.RequireFlag = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            txtCustCode_H.RequirePop = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            txtCustCode_H.Size = new System.Drawing.Size(122, 27);
            txtCustCode_H.TabIndex = 223;
            txtCustCode_H.ButtonClick += new System.EventHandler(txtCustCode_H_ButtonClick);
            txtCustCode_H.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCustCode_H_KeyPress);
            appearance22.BackColor = System.Drawing.SystemColors.InactiveBorder;
            txtCustName_H.Appearance = appearance22;
            txtCustName_H.AutoSize = false;
            txtCustName_H.BackColor = System.Drawing.SystemColors.InactiveBorder;
            txtCustName_H.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtCustName_H.Location = new System.Drawing.Point(302, 15);
            txtCustName_H.Name = "txtCustName_H";
            txtCustName_H.Size = new System.Drawing.Size(185, 27);
            txtCustName_H.TabIndex = 225;
            appearance23.BorderColor = System.Drawing.Color.FromArgb(224, 224, 224);
            appearance23.FontData.BoldAsString = "False";
            appearance23.FontData.UnderlineAsString = "False";
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.TextHAlignAsString = "Right";
            appearance23.TextVAlignAsString = "Middle";
            lblWorkerID.Appearance = appearance23;
            lblWorkerID.DbField = null;
            lblWorkerID.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblWorkerID.Location = new System.Drawing.Point(70, 16);
            lblWorkerID.Name = "lblWorkerID";
            lblWorkerID.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblWorkerID.Size = new System.Drawing.Size(100, 25);
            lblWorkerID.TabIndex = 224;
            lblWorkerID.Text = "업체";
            base.ClientSize = new System.Drawing.Size(1136, 825);
            base.Name = "SY0210Y";
            base.Load += new System.EventHandler(SY0210Y_Load);
            ((System.ComponentModel.ISupportInitialize)gbxHeader).EndInit();
            gbxHeader.ResumeLayout(false);
            gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gbxBody).EndInit();
            gbxBody.ResumeLayout(false);
            gbxBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grid1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPwd).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboGrpID).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboUseFlag_H).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCustCode_H).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCustName_H).EndInit();
            ResumeLayout(false);
        }
    }
}

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
    public class SY0030 : BaseMDIChildForm
    {
        private UltraGridUtil _GridUtil = new UltraGridUtil();

        private Common _Common = new Common();

        private new IContainer components = null;

        private SLabel lblUseFlag_H;

        private WIZ.Control.Grid grid1;

        private UltraTextEditor txtPwd;

        private ScboGRPIDCode cboGrpID;

        private WIZ.Control.Grid grid2;

        private SCodeNMComboBox cboUseFlag_H;

        private SBtnTextEditor txtWorkerID_H;

        private SLabel lblWorkerID;

        private WIZ.Control.STextBox txtWorkerName_H;

        public SY0030()
        {
            InitializeComponent();
        }

        private void SY0030_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkerID", "사용자ID", false, GridColDataType_emu.VarChar, 125, 100, HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "WorkerName", "사용자명", false, GridColDataType_emu.VarChar, 180, 100, HAlign.Default, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Pwd", "패스워드", false, GridColDataType_emu.VarChar, 250, 100, HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "GRPID", "그룹명", true, GridColDataType_emu.VarChar, 200, 100, HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "기본사업장", true, GridColDataType_emu.VarChar, 130, 100, HAlign.Default, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Lang", "Lang", true, GridColDataType_emu.VarChar, 100, 100, HAlign.Center, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "UseFlag", "사용여부", true, GridColDataType_emu.VarChar, 160, 100, HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", true, GridColDataType_emu.VarChar, 160, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "등록일", true, GridColDataType_emu.VarChar, 180, 100, HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "Editor", "수정자", true, GridColDataType_emu.VarChar, 160, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정일", true, GridColDataType_emu.VarChar, 180, 100, HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK_PWD", "비번확인", true, GridColDataType_emu.VarChar, 180, 100, HAlign.Center, false, true, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
            grid1.DisplayLayout.Bands[0].Columns["Pwd"].EditorComponent = txtPwd;
            grid1.DisplayLayout.Bands[0].Columns["GRPID"].EditorComponent = cboGrpID;
            _GridUtil.InitializeGrid(grid2, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid2, "UseCheck", " ", true, GridColDataType_emu.CheckBox, 40, 1, HAlign.Center, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PlantName", "사용가능사업장", true, GridColDataType_emu.VarChar, 125, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PlantCode", "사업장", true, GridColDataType_emu.VarChar, 1, 100, HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid2);
            grid2.DisplayLayout.Override.RowSelectorWidth = 1;
            DataTable dtInData = _Common.GET_BM0000_CODE("USEFLAG");
            UltraGridUtil.SetComboUltraGrid(grid1, "UseFlag", dtInData, "CODE_ID", "CODE_NAME");
            dtInData = _Common.GET_BM0000_CODE("PLANTCODE");
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtInData, "CODE_ID", "CODE_NAME");
            txtWorkerID_H.ControlAdded += tCodeControlAdd;
            txtWorkerName_H.ControlAdded += tNameControlAdd;
        }

        public override void DoInquire()
        {
            DBHelper dBHelper = new DBHelper(completedClose: false);
            try
            {
                base.DoInquire();
                string value = Convert.ToString(txtWorkerID_H.Text);
                string value2 = Convert.ToString(txtWorkerName_H.Text);
                string value3 = DBHelper.nvlString(cboUseFlag_H.Value);
                DataTable dataTable = new DataTable();
                dataTable = dBHelper.FillTable("USP_SY0030_S1", CommandType.StoredProcedure, dBHelper.CreateParameter("WorkerID", value, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("WorkerName", value2, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("UseFlag", value3, DbType.String, ParameterDirection.Input));
                grid1.DataSource = dataTable;
                grid1.DataBind();
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
                UltraGridUtil.ActivationAllowEdit(grid1, "WorkerID", dtRowNum);
                UltraGridUtil.ActivationAllowEdit(grid1, "WorkerName", dtRowNum);
                UltraGridUtil.ActivationAllowEdit(grid1, "Pwd", dtRowNum);
                UltraGridUtil.ActivationAllowEdit(grid1, "GRPID", dtRowNum);
                UltraGridUtil.ActivationAllowEdit(grid1, "UseFlag", dtRowNum);
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
                    int num = 0;
                    foreach (DataRow row in ((DataTable)grid1.DataSource).Rows)
                    {
                        switch (row.RowState)
                        {
                            case DataRowState.Deleted:
                                row.RejectChanges();
                                dBHelper.ExecuteNoneQuery("USP_SY0030_D1", CommandType.StoredProcedure, dBHelper.CreateParameter("WorkerID", row["WorkerID"].ToString(), DbType.String, ParameterDirection.Input));
                                row.Delete();
                                break;
                            case DataRowState.Added:
                                dBHelper.ExecuteNoneQuery("USP_SY0030_I1", CommandType.StoredProcedure, dBHelper.CreateParameter("WorkerID", row["WorkerID"].ToString(), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("WorkerName", row["WorkerName"].ToString(), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("Pwd", Common.MD5Hash(DBHelper.nvlString(row["Pwd"])), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("GRPID", row["GRPID"].ToString(), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("PLANTCODE", row["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("UseFlag", row["UseFlag"].ToString(), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("Maker", LoginInfo.UserID, DbType.String, ParameterDirection.Input));
                                break;
                            case DataRowState.Modified:
                                if (DBHelper.nvlString(row["Pwd"]).ToString() == DBHelper.nvlString(row["CHK_PWD"]).ToString())
                                {
                                    num = 1;
                                }
                                if (num == 1)
                                {
                                    dBHelper.ExecuteNoneQuery("USP_SY0030_U1", CommandType.StoredProcedure, dBHelper.CreateParameter("WorkerID", row["WorkerID"].ToString(), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("WorkerName", row["WorkerName"].ToString(), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("Pwd", DBHelper.nvlString(row["Pwd"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("GRPID", row["GRPID"].ToString(), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("PLANTCODE", row["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("UseFlag", row["UseFlag"].ToString(), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("Editor", LoginInfo.UserID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("SYSTEMID", Common.SystemID, DbType.String, ParameterDirection.Input));
                                }
                                else
                                {
                                    dBHelper.ExecuteNoneQuery("USP_SY0030_U1", CommandType.StoredProcedure, dBHelper.CreateParameter("WorkerID", row["WorkerID"].ToString(), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("WorkerName", row["WorkerName"].ToString(), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("Pwd", Common.MD5Hash(DBHelper.nvlString(row["Pwd"])), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("GRPID", row["GRPID"].ToString(), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("PLANTCODE", row["PLANTCODE"].ToString(), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("UseFlag", row["UseFlag"].ToString(), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("Editor", LoginInfo.UserID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("SYSTEMID", Common.SystemID, DbType.String, ParameterDirection.Input));
                                }
                                break;
                        }
                    }
                    dBHelper.Commit();
                }
            }
            catch (Exception ex)
            {
                dBHelper.Rollback();
                ThrowError(ex);
            }
            finally
            {
                dBHelper.Close();
                DoInquire();
            }
        }

        private void grid1_ClickCell(object sender, EventArgs e)
        {
            DBHelper dBHelper = new DBHelper(completedClose: false);
            try
            {
                grid2.DataSource = dBHelper.FillTable("USP_SY0030_S2", CommandType.StoredProcedure, dBHelper.CreateParameter("WorkerID", grid1.ActiveRow.Cells["WorkerID"].Value, DbType.String, ParameterDirection.Input));
                grid2.DataBinds();
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

        private void grid1_BeforeRowDeactivate(object sender, CancelEventArgs e)
        {
            if (((DataTable)grid2.DataSource).GetChanges() != null)
            {
                DBHelper dBHelper = new DBHelper(completedClose: false);
                try
                {
                    dBHelper.ExecuteNoneQuery("USP_SY0030_D2", CommandType.StoredProcedure, dBHelper.CreateParameter("WorkerID", grid1.ActiveRow.Cells["WorkerID"].Value, DbType.String, ParameterDirection.Input));
                    foreach (DataRow row in ((DataTable)grid2.DataSource).Rows)
                    {
                        if (row["UseCheck"].ToString() == "1")
                        {
                            dBHelper.ExecuteNoneQuery("USP_SY0030_I2", CommandType.StoredProcedure, dBHelper.CreateParameter("WorkerID", grid1.ActiveRow.Cells["WorkerID"].Value, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("PlantCode", row["PlantCode"].ToString(), DbType.String, ParameterDirection.Input));
                        }
                    }
                    dBHelper.Commit();
                }
                catch (Exception ex)
                {
                    dBHelper.Rollback();
                    ThrowError(ex);
                }
                finally
                {
                    dBHelper.Close();
                }
            }
        }

        private void txtWorkerID_H_ButtonClick(object sender, EventArgs e)
        {
            PopManagerBase popManagerBase = new PopManagerBase();
            DataTable dataTable = popManagerBase.OpenPopupShow("WIZ.SY", "POP_TSY0030", "사용자 검색", new string[7]
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
                txtWorkerID_H.Text = Convert.ToString(dataTable.Rows[0]["WorkerID"]);
                txtWorkerName_H.Text = Convert.ToString(dataTable.Rows[0]["WorkerName"]);
            }
        }

        private void tCodeControlAdd(object sender, ControlEventArgs e)
        {
            e.Control.DoubleClick += tCodeBox_DoubleClick;
        }

        private void tCodeBox_DoubleClick(object sender, EventArgs e)
        {
            txtWorkerID_H_ButtonClick(null, null);
        }

        private void tNameControlAdd(object sender, ControlEventArgs e)
        {
            e.Control.DoubleClick += tNameBox_DoubleClick;
        }

        private void tNameBox_DoubleClick(object sender, EventArgs e)
        {
            txtWorkerID_H_ButtonClick(null, null);
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
            grid2 = new WIZ.Control.Grid(components);
            cboUseFlag_H = new WIZ.Control.SCodeNMComboBox();
            txtWorkerID_H = new WIZ.Control.SBtnTextEditor();
            lblWorkerID = new WIZ.Control.SLabel();
            txtWorkerName_H = new WIZ.Control.STextBox(components);
            ((System.ComponentModel.ISupportInitialize)gbxHeader).BeginInit();
            gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gbxBody).BeginInit();
            gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPwd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboGrpID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grid2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboUseFlag_H).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtWorkerID_H).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtWorkerName_H).BeginInit();
            SuspendLayout();
            gbxHeader.ContentPadding.Bottom = 2;
            gbxHeader.ContentPadding.Left = 2;
            gbxHeader.ContentPadding.Right = 2;
            gbxHeader.ContentPadding.Top = 4;
            gbxHeader.Controls.Add(txtWorkerName_H);
            gbxHeader.Controls.Add(txtWorkerID_H);
            gbxHeader.Controls.Add(lblWorkerID);
            gbxHeader.Controls.Add(cboUseFlag_H);
            gbxHeader.Controls.Add(lblUseFlag_H);
            gbxHeader.Controls.SetChildIndex(lblUseFlag_H, 0);
            gbxHeader.Controls.SetChildIndex(cboUseFlag_H, 0);
            gbxHeader.Controls.SetChildIndex(lblWorkerID, 0);
            gbxHeader.Controls.SetChildIndex(txtWorkerID_H, 0);
            gbxHeader.Controls.SetChildIndex(txtWorkerName_H, 0);
            gbxBody.ContentPadding.Bottom = 4;
            gbxBody.ContentPadding.Left = 4;
            gbxBody.ContentPadding.Right = 4;
            gbxBody.ContentPadding.Top = 6;
            gbxBody.Controls.Add(grid2);
            gbxBody.Controls.Add(grid1);
            gbxBody.Controls.Add(txtPwd);
            gbxBody.Controls.Add(cboGrpID);
            appearance.FontData.BoldAsString = "False";
            appearance.FontData.UnderlineAsString = "False";
            appearance.ForeColor = System.Drawing.Color.Black;
            appearance.TextHAlignAsString = "Left";
            lblUseFlag_H.Appearance = appearance;
            lblUseFlag_H.DbField = null;
            lblUseFlag_H.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblUseFlag_H.Location = new System.Drawing.Point(508, 10);
            lblUseFlag_H.Name = "lblUseFlag_H";
            lblUseFlag_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblUseFlag_H.Size = new System.Drawing.Size(145, 25);
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
            grid1.Dock = System.Windows.Forms.DockStyle.Left;
            grid1.EnterNextRowEnable = true;
            grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75f);
            grid1.Location = new System.Drawing.Point(6, 6);
            grid1.Name = "grid1";
            grid1.Size = new System.Drawing.Size(1085, 743);
            grid1.TabIndex = 31;
            grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus;
            grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;

            grid1.ClickCell += new Infragistics.Win.UltraWinGrid.ClickCellEventHandler(grid1_ClickCell);
            grid1.BeforeRowDeactivate += new System.ComponentModel.CancelEventHandler(grid1_BeforeRowDeactivate);
            txtPwd.Location = new System.Drawing.Point(933, 131);
            txtPwd.Name = "txtPwd";
            txtPwd.Nullable = false;
            txtPwd.PasswordChar = '*';
            txtPwd.Size = new System.Drawing.Size(85, 29);
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
            grid2.AutoResizeColumn = true;
            grid2.AutoUserColumn = true;
            grid2.ContextMenuCopyEnabled = true;
            grid2.ContextMenuDeleteEnabled = true;
            grid2.ContextMenuExcelEnabled = true;
            grid2.ContextMenuInsertEnabled = true;
            grid2.ContextMenuPasteEnabled = true;
            grid2.DeleteButtonEnable = true;
            grid2.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            grid2.DisplayLayout.GroupByBox.Hidden = true;
            grid2.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            grid2.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.All;
            grid2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            grid2.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            grid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            grid2.DisplayLayout.SelectionOverlayBorderThickness = 2;
            grid2.Dock = System.Windows.Forms.DockStyle.Fill;
            grid2.EnterNextRowEnable = true;
            grid2.Font = new System.Drawing.Font("맑은 고딕", 9.75f);
            grid2.Location = new System.Drawing.Point(1091, 6);
            grid2.Name = "grid2";
            grid2.Size = new System.Drawing.Size(39, 743);
            grid2.TabIndex = 33;
            grid2.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            grid2.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus;
            grid2.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            grid2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            cboUseFlag_H.AutoSize = false;
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
            cboUseFlag_H.Location = new System.Drawing.Point(508, 35);
            cboUseFlag_H.MajorCode = "USEFLAG";
            cboUseFlag_H.Name = "cboUseFlag_H";
            cboUseFlag_H.SelectedValue = null;
            cboUseFlag_H.ShowDefaultValue = true;
            cboUseFlag_H.Size = new System.Drawing.Size(166, 26);
            cboUseFlag_H.TabIndex = 222;
            appearance21.FontData.BoldAsString = "False";
            appearance21.FontData.UnderlineAsString = "False";
            appearance21.ForeColor = System.Drawing.Color.Black;
            txtWorkerID_H.Appearance = appearance21;
            txtWorkerID_H.AutoSize = false;
            txtWorkerID_H.btnImgType = WIZ.Control.SBtnTextEditor.ButtonImgTypeEnum.Type1;
            txtWorkerID_H.btnWidth = 26;
            txtWorkerID_H.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtWorkerID_H.Location = new System.Drawing.Point(110, 35);
            txtWorkerID_H.Name = "txtWorkerID_H";
            txtWorkerID_H.RequireFlag = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            txtWorkerID_H.RequirePop = WIZ.Control.SBtnTextEditor.RequireFlagEnum.NO;
            txtWorkerID_H.Size = new System.Drawing.Size(150, 26);
            txtWorkerID_H.TabIndex = 223;
            txtWorkerID_H.ButtonClick += new System.EventHandler(txtWorkerID_H_ButtonClick);
            appearance22.BorderColor = System.Drawing.Color.FromArgb(224, 224, 224);
            appearance22.FontData.BoldAsString = "False";
            appearance22.FontData.UnderlineAsString = "False";
            appearance22.ForeColor = System.Drawing.Color.Black;
            appearance22.TextHAlignAsString = "Left";
            appearance22.TextVAlignAsString = "Middle";
            lblWorkerID.Appearance = appearance22;
            lblWorkerID.DbField = null;
            lblWorkerID.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblWorkerID.Location = new System.Drawing.Point(110, 10);
            lblWorkerID.Name = "lblWorkerID";
            lblWorkerID.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblWorkerID.Size = new System.Drawing.Size(145, 25);
            lblWorkerID.TabIndex = 224;
            lblWorkerID.Text = "사용자ID";
            appearance23.FontData.BoldAsString = "False";
            appearance23.FontData.UnderlineAsString = "False";
            appearance23.ForeColor = System.Drawing.Color.Black;
            txtWorkerName_H.Appearance = appearance23;
            txtWorkerName_H.AutoSize = false;
            txtWorkerName_H.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtWorkerName_H.Location = new System.Drawing.Point(262, 35);
            txtWorkerName_H.Name = "txtWorkerName_H";
            txtWorkerName_H.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtWorkerName_H.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            txtWorkerName_H.Size = new System.Drawing.Size(200, 27);
            txtWorkerName_H.TabIndex = 240;
            base.ClientSize = new System.Drawing.Size(1136, 825);
            base.Name = "SY0030";
            base.Load += new System.EventHandler(SY0030_Load);
            ((System.ComponentModel.ISupportInitialize)gbxHeader).EndInit();
            gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gbxBody).EndInit();
            gbxBody.ResumeLayout(false);
            gbxBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grid1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPwd).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboGrpID).EndInit();
            ((System.ComponentModel.ISupportInitialize)grid2).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboUseFlag_H).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtWorkerID_H).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtWorkerName_H).EndInit();
            ResumeLayout(false);
        }
    }
}

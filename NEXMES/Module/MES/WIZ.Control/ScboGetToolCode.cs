using Infragistics.Win.UltraWinGrid;
using System.ComponentModel;
using System.Data;

namespace WIZ.Control
{
    public class ScboGetToolCode : UltraCombo
    {
        public string dbConfig;

        private string toolType;

        private ComboDataType cboType = ComboDataType.All;

        private bool showDefaultValue = false;

        private string defaultValue = "";

        private IContainer components = null;

        public string DefaultValue
        {
            get
            {
                return defaultValue;
            }
            set
            {
                defaultValue = value;
            }
        }

        public bool ShowDefaultValue
        {
            get
            {
                return showDefaultValue;
            }
            set
            {
                showDefaultValue = value;
            }
        }

        public ComboDataType ComboDataType
        {
            get
            {
                return cboType;
            }
            set
            {
                cboType = value;
            }
        }

        public string DbConfig
        {
            get
            {
                return dbConfig;
            }
            set
            {
                dbConfig = value;
            }
        }

        public string ToolType
        {
            get
            {
                return toolType;
            }
            set
            {
                toolType = value;
            }
        }

        public ScboGetToolCode()
        {
            InitializeComponent();
        }

        public void InitComboBox()
        {
            DBHelper dBHelper = new DBHelper(completedClose: true);
            try
            {
                base.DataSource = dBHelper.FillTable("USP_ScboGetStorageLocCode_S", CommandType.StoredProcedure, dBHelper.CreateParameter("ToolType", (toolType == null) ? "" : toolType, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("CboType", (cboType == ComboDataType.All) ? "ALL" : "", DbType.String, ParameterDirection.Input));
                DataBind();
                base.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
                base.DisplayLayout.Bands[0].Columns["ToolCode"].Hidden = true;
                base.DisplayLayout.Bands[0].ColHeadersVisible = false;
            }
            catch
            {
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (!base.DesignMode)
            {
                InitComboBox();
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

        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            AutoSize = false;
            base.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            base.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            base.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance.BackColor = System.Drawing.Color.FromArgb(99, 133, 188);
            appearance.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel;
            appearance.FontData.BoldAsString = "True";
            appearance.ForeColor = System.Drawing.Color.White;
            base.DisplayLayout.Override.ActiveRowAppearance = appearance;
            appearance2.FontData.BoldAsString = "True";
            base.DisplayLayout.Override.ActiveRowCellAppearance = appearance2;
            base.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            base.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            base.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.None;
            appearance3.BackColor = System.Drawing.Color.FromArgb(99, 133, 188);
            appearance3.FontData.BoldAsString = "True";
            base.DisplayLayout.Override.SelectedRowAppearance = appearance3;
            base.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            base.DisplayMember = "ToolName";
            Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            base.Size = new System.Drawing.Size(100, 26);
            base.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            base.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            base.ValueMember = "ToolCode";
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }
    }
}

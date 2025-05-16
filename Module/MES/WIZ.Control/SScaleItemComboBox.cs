using Infragistics.Win.UltraWinGrid;
using System.ComponentModel;
using System.Data;

namespace WIZ.Control
{
    public class SScaleItemComboBox : UltraCombo
    {
        public string dbConfig;

        private string _ComboSelCommandText = "   SELECT ScaleItem                             ,ScaleItemNM                       FROM B_ScaleItem                      WHERE ScaleItemGrp = @ScaleItemGrp  ORDER BY ScaleItem                    ";

        private bool showDefaultValue = false;

        private string defaultValue = "";

        private string scaleItemGrp = "";

        private IContainer components = null;

        public string ScaleItemGrp
        {
            get
            {
                return scaleItemGrp;
            }
            set
            {
                scaleItemGrp = value;
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

        public SScaleItemComboBox()
        {
            InitializeComponent();
        }

        public void InitComboBox()
        {
            if (!base.DesignMode)
            {
                DBHelper dBHelper = new DBHelper(completedClose: true);
                try
                {
                    base.DataSource = dBHelper.FillTable(_ComboSelCommandText, CommandType.Text, dBHelper.CreateParameter("ScaleItemGrp", ScaleItemGrp, DbType.AnsiString, ParameterDirection.Input));
                    DataBind();
                    base.ValueMember = "ScaleItem";
                    base.DisplayMember = "ScaleItemNM";
                    base.DisplayLayout.Bands[0].ColHeadersVisible = false;
                    base.DisplayLayout.Bands[0].Columns["ScaleItem"].Hidden = true;
                    if (showDefaultValue)
                    {
                        base.Value = defaultValue;
                    }
                }
                catch
                {
                }
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
            base.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            base.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            base.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            base.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True;
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
            Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            base.Size = new System.Drawing.Size(100, 26);
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }
    }
}

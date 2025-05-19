using Infragistics.Win.UltraWinGrid;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace WIZ.Control
{
    public class SCodeComboBox : UltraCombo
    {
        public string dbConfig;

        private string majorCD;

        private DataSet dsCombo = new DataSet();

        private ComboDataType cboType = ComboDataType.All;

        private bool showDefaultValue = false;

        private string defaultValue = "";

        private ComboDataTypeYN emptyFlag = ComboDataTypeYN.Yes;

        private string selCommandText1 = string.Empty;

        private string selCommandText2 = string.Empty;

        private string selCommandText3 = string.Empty;

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

        public string MajorCode
        {
            get
            {
                return majorCD;
            }
            set
            {
                majorCD = value;
            }
        }

        public ComboDataTypeYN EmptyFlag
        {
            get
            {
                return emptyFlag;
            }
            set
            {
                emptyFlag = value;
            }
        }

        public SCodeComboBox()
        {
            InitializeComponent();
        }

        public void InitComboBox()
        {
            try
            {
                selCommandText1 = "  SELECT ''     AS MinorCode         ,'ALL'  AS CodeName         ,0      AS DisplayNo UNION ALL ";
                selCommandText3 = "  SELECT NULL     AS MinorCode         ,'(none)' AS CodeName         ,0        AS DisplayNo UNION ALL ";
                selCommandText2 = "  SELECT MinorCode AS MinorCode         ,'[' + MinorCode + '] ' + dbo.FN_Translate( '" + Common.Lang + "', CodeName,'BM0000') AS CodeName         ,DisplayNo   AS DisplayNo     FROM TBM0000 A    WHERE MajorCode =  '" + MajorCode.ToUpper() + "'      AND MinorCode <> '$' ORDER BY DisplayNo ";
                DBHelper dBHelper = new DBHelper(completedClose: true);
                if (dBHelper.dataFactory.GetType().Namespace.ToString() == "Oracle.DataAccess.Client")
                {
                    selCommandText2 = selCommandText2.Replace("+", "||").Replace("dbo.", "");
                }
                string query = (cboType == ComboDataType.All) ? (selCommandText1 + selCommandText2) : ((emptyFlag != ComboDataTypeYN.No) ? (selCommandText3 + selCommandText2) : selCommandText2);
                SqlParameter[] parameters = new SqlParameter[0];
                dsCombo = dBHelper.FillDataSet(query, CommandType.Text, parameters);
                base.DataSource = dsCombo;
                base.ValueMember = "MinorCode";
                base.DisplayMember = "CodeName";
                base.DisplayLayout.Bands[0].ColHeadersVisible = false;
                base.DisplayLayout.Bands[0].Columns["MinorCode"].Hidden = true;
                base.DisplayLayout.Bands[0].Columns["DisplayNo"].Hidden = true;
                if (!base.DesignMode || showDefaultValue)
                {
                    base.Value = defaultValue;
                }
                if (base.Rows.Count > 0)
                {
                    base.Rows[0].Activated = true;
                }
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
            base.DisplayMember = "CodeName";
            Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            base.Size = new System.Drawing.Size(100, 26);
            base.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            base.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            base.ValueMember = "MinorCode";
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }
    }
}

using Infragistics.Win.UltraWinGrid;
using System.ComponentModel;
using System.Data;

namespace WIZ.Control
{
    public class SCodeNMComboBox : UltraCombo
    {
        public string dbConfig;

        private string majorCode;

        private string selCommandText1 = "  SELECT '' AS MINORCODE           ,'ALL' AS CODENAME            ,0     AS DISPLAYNO     UNION ALL                    ";

        private string selCommandText2 = "  SELECT MINORCODE AS MINORCODE          ,'[' + MINORCODE + '] '+ dbo.FN_Translate( '" + Common.Lang + "', CodeName,'BM0000') AS CODENAME           ,DISPLAYNO   AS DISPLAYNO        FROM BM0000 A    WHERE MAJORCODE =  @MAJORCODE      AND MINORCODE <> '$'      ORDER BY DISPLAYNO               ";

        private string selCommandText3 = "  SELECT '' AS MINORCODE           ,'ALL' AS CODENAME            ,0     AS DISPLAYNO       FROM DUAL                 UNION ALL                     ";

        private string selCommandText4 = "  SELECT MINORCODE AS MINORCODE          ,'[' || MINORCODE || '] ' || FN_Translate( '" + Common.Lang + "', CodeName,'BM0000') AS CODENAME           ,DISPLAYNO   AS DISPLAYNO        FROM BM0000 A    WHERE MAJORCODE =  :MAJORCODE      AND MINORCODE <> '$'      ORDER BY DISPLAYNO               ";

        private string SelCommand;

        private DataSet dsCombo = new DataSet();

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

        public string MajorCode
        {
            get
            {
                return majorCode;
            }
            set
            {
                majorCode = value;
            }
        }

        public string SelectedValue
        {
            get;
            set;
        }

        public SCodeNMComboBox()
        {
            InitializeComponent();
        }

        public void InitComboBox()
        {
            try
            {
                DBHelper dBHelper = new DBHelper(completedClose: true);
                if (dBHelper.ConType == "OracleConnection")
                {
                    if (cboType == ComboDataType.All)
                    {
                        SelCommand = selCommandText3 + selCommandText4;
                    }
                    else
                    {
                        SelCommand = selCommandText4;
                    }
                }
                else if (cboType == ComboDataType.All)
                {
                    SelCommand = selCommandText1 + selCommandText2;
                }
                else
                {
                    SelCommand = selCommandText2;
                }
                dsCombo = dBHelper.FillDataSet(SelCommand, CommandType.Text, dBHelper.CreateParameter("MAJORCODE", MajorCode, DbType.String, ParameterDirection.Input));
                base.DataSource = dsCombo;
                base.ValueMember = "MINORCODE";
                base.DisplayMember = "CODENAME";
                base.DisplayLayout.Bands[0].ColHeadersVisible = false;
                base.DisplayLayout.Bands[0].Columns["MINORCODE"].Hidden = true;
                base.DisplayLayout.Bands[0].Columns["DISPLAYNO"].Hidden = true;
                if (showDefaultValue)
                {
                    base.Value = ((defaultValue == null) ? "" : defaultValue);
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
            Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            base.Size = new System.Drawing.Size(100, 25);
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }
    }
}

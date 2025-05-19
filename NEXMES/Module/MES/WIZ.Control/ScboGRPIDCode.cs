using Infragistics.Win.UltraWinGrid;
using System.ComponentModel;

namespace WIZ.Control
{
    public class ScboGRPIDCode : UltraCombo
    {
        public string dbConfig;

        private string majorCode;

        private string selCommandText1 = "  SELECT 'ALL'     AS GRPID             ,'ALL'  AS GRPName , 0      AS DisplayNo  UNION ALL                     ";

        private string selCommandText2 = "  SELECT GRPID AS GRPID             ,'[' + GRPID + '] '+  GRPName AS GRPName, ISNULL(DisplayNo, 999) AS DisplayNo       FROM TSY0080 with(nolock)   ORDER BY DISPLAYNO              ";

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

        public ScboGRPIDCode()
        {
            InitializeComponent();
        }

        public void InitComboBox()
        {
            DBHelper dBHelper = new DBHelper(completedClose: true);
            try
            {
                if (dBHelper.dataFactory.GetType().Namespace.ToString() == "Oracle.DataAccess.Client")
                {
                    selCommandText2 = selCommandText2.Replace("+", "||");
                }
                if (cboType == ComboDataType.All)
                {
                    base.DataSource = dBHelper.FillTable(selCommandText1 + selCommandText2);
                }
                else
                {
                    base.DataSource = dBHelper.FillTable(selCommandText2);
                }
                DataBind();
                base.ValueMember = "GRPID";
                base.DisplayMember = "GRPName";
                base.DisplayLayout.Bands[0].ColHeadersVisible = false;
                base.DisplayLayout.Bands[0].Columns["GRPID"].Hidden = true;
                base.DisplayLayout.Bands[0].Columns["DisplayNo"].Hidden = true;
                base.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
                if (showDefaultValue)
                {
                    base.Value = defaultValue;
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
            components = new System.ComponentModel.Container();
        }
    }
}

using Infragistics.Win.UltraWinGrid;
using System.ComponentModel;

namespace WIZ.Control
{
    public class SCodeTBM0600ComboBox : UltraCombo
    {
        public string dbConfig;

        private string selCommandText1 = "  SELECT ''     AS WorkCenterCode                 ,'전체' AS WorkCenterName               ,0      AS DisplayNo       UNION ALL                           ";

        private string selCommandText2 = "  SELECT WorkCenterCode as WorkCenterCode             ,'[' + WorkCenterCode + '] '+  WorkCenterName AS WorkCenterName         ,1     AS DisplayNo           FROM TBM0600                      WHERE Useflag   = 'Y'           ORDER BY DisplayNo, WorkCenterCode                ";

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

        public SCodeTBM0600ComboBox()
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
                base.ValueMember = "WorkCenterCode";
                base.DisplayMember = "WorkCenterName";
                base.DisplayLayout.Bands[0].ColHeadersVisible = false;
                base.DisplayLayout.Bands[0].Columns["WorkCenterCode"].Hidden = true;
                base.DisplayLayout.Bands[0].Columns["DisplayNo"].Hidden = true;
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

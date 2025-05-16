using Infragistics.Win.UltraWinGrid;
using System.Data;

namespace WIZ.Control
{
    public class ScboGetFaultCode : UltraCombo
    {
        public string dbConfig;

        private string faultType;

        private DataSet dsCombo = new DataSet();

        private ComboDataType cboType = ComboDataType.All;

        private bool showDefaultValue = false;

        private string defaultValue = "";

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

        public string FaultType
        {
            get
            {
                return faultType;
            }
            set
            {
                faultType = value;
            }
        }

        public ScboGetFaultCode()
        {
            InitializeComponent();
        }

        public void InitComboBox()
        {
            DBHelper dBHelper = new DBHelper(completedClose: true);
            try
            {
                base.DataSource = dBHelper.FillTable("USP_ScboGetFaultCode_S", CommandType.StoredProcedure, dBHelper.CreateParameter("FaultType", (faultType == null) ? "" : faultType, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("CboType", (cboType == ComboDataType.All) ? "ALL" : "", DbType.String, ParameterDirection.Input));
                DataBind();
                base.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
                base.DisplayLayout.Bands[0].Columns["FaultCode"].Hidden = true;
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

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            base.Size = new System.Drawing.Size(100, 22);
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }
    }
}

using Infragistics.Win.UltraWinGrid;
using System.Data;

namespace WIZ.Control
{
    public class ScboGetCustCode : UltraCombo
    {
        public string dbConfig;

        private string custtype;

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

        public string CustType
        {
            get
            {
                return custtype;
            }
            set
            {
                custtype = value;
            }
        }

        public ScboGetCustCode()
        {
            InitializeComponent();
        }

        public void InitComboBox()
        {
            DBHelper dBHelper = new DBHelper(completedClose: true);
            try
            {
                base.DataSource = dBHelper.FillTable(".USP_ScboGetCustCode_S", CommandType.StoredProcedure, dBHelper.CreateParameter("CustType", (custtype == null) ? "" : custtype, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("CboType", (cboType == ComboDataType.All) ? "ALL" : "", DbType.String, ParameterDirection.Input));
                DataBind();
                base.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
                base.DisplayLayout.Bands[0].Columns["CustCode"].Hidden = true;
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
            base.DisplayMember = "CustName";
            base.Size = new System.Drawing.Size(100, 22);
            base.ValueMember = "CustCode";
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }
    }
}

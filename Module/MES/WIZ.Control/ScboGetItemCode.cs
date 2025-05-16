using Infragistics.Win.UltraWinGrid;
using System.Data;

namespace WIZ.Control
{
    public class ScboGetItemCode : UltraCombo
    {
        public string dbConfig;

        private string plantcode;

        private string itemtype;

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

        public string PlantCode
        {
            get
            {
                return plantcode;
            }
            set
            {
                plantcode = value;
            }
        }

        public string ItemType
        {
            get
            {
                return itemtype;
            }
            set
            {
                itemtype = value;
            }
        }

        public ScboGetItemCode()
        {
            InitializeComponent();
        }

        public void InitComboBox()
        {
            try
            {
                DBHelper dBHelper = new DBHelper(completedClose: true);
                base.DataSource = dBHelper.FillTable("USP_ScboGetItemCode_S", CommandType.StoredProcedure, dBHelper.CreateParameter("PlantCode", (plantcode == null) ? "" : plantcode, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("ItemType", (itemtype == null) ? "" : itemtype, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("CboType", (cboType == ComboDataType.All) ? "ALL" : "", DbType.String, ParameterDirection.Input));
                DataBind();
                base.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
                base.DisplayLayout.Bands[0].Columns["ItemCode"].Hidden = true;
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
            base.DisplayMember = "ItemName";
            base.Size = new System.Drawing.Size(100, 22);
            base.ValueMember = "ItemCode";
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }
    }
}

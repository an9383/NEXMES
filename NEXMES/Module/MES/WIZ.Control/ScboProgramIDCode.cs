using Infragistics.Win.UltraWinGrid;
using System;
using System.ComponentModel;
using System.Data;

namespace WIZ.Control
{
    public class ScboProgramIDCode : UltraCombo
    {
        public string dbConfig;

        private string majorCode;

        private string selCommandText1 = "  SELECT ''     AS ProgramID             ,'전체' AS ProgramName   UNION ALL                     ";

        private string selCommandText2 = "  SELECT ProgramID AS ProgramID             ,'[' + ProgramID + '] '+  ProgramName AS ProgramName       FROM TSY0010 WITH(NOLOCK)                       WHERE WorkerID = 'SYSTEM'           and SystemID = '{0}'        ORDER BY ProgramID                  ";

        //private DbCommand ComboSelCommand;

        private DataSet dsCombo = new DataSet();

        private ComboDataType cboType = ComboDataType.All;

        private bool showDefaultValue = false;

        private string defaultValue = "";

        private string system = "";

        private IContainer components = null;

        public string SystemID
        {
            get
            {
                return system;
            }
            set
            {
                system = value;
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

        public ScboProgramIDCode()
        {
            InitializeComponent();
        }

        public void InitComboBox()
        {
            try
            {
                DBHelper dBHelper = new DBHelper();
                string text = "";
                string text2 = string.Format(selCommandText2, system);
                if (dBHelper.dataFactory.GetType().Namespace.ToString() == "Oracle.DataAccess.Client")
                {
                    text2 = text2.Replace("+", "||");
                }
                text = ((cboType != 0) ? text2 : (selCommandText1 + text2));
                dsCombo.EnforceConstraints = false;
                dsCombo = dBHelper.FillDataSet(text);
                base.DataSource = null;
                base.DataSource = dsCombo;
                base.ValueMember = "ProgramID";
                base.DisplayMember = "ProgramName";
                base.DisplayLayout.Bands[0].ColHeadersVisible = false;
                base.DisplayLayout.Bands[0].Columns["ProgramID"].Hidden = true;
                if (showDefaultValue)
                {
                    base.Value = defaultValue;
                }
            }
            catch (Exception)
            {
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
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

using System;
using System.Data.Common;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WIZ.Control
{
    public partial class DBForm : Form
    {
        private classDBInfo dbinfo;

        public bool bEncrypt = true;

        public class classDBInfo
        {
            public string DB_Title;
            public string SQLType;
            public string IP;
            public string Port;
            public string DBName;
            public string User;
            public string Pass;

            public bool bEncrypt = false;

            public classDBInfo(string sConnectionString, string sConnName = "", bool bEncrypt = true)
            {
                string sConn = "";

                this.bEncrypt = bEncrypt;

                if (bEncrypt)
                {
                    sConn = Common.DecryptString(sConnectionString);
                }
                else
                {
                    sConn = sConnectionString;
                }

                if (sConn != "")
                {
                    DbProviderFactory dataFactory = DbProviderFactories.GetFactory(CModule.GetAppSetting(CModule.sProvider, sConn));
                    DbConnection conn = dataFactory.CreateConnection();
                    conn.ConnectionString = sConn;

                    SetClassDBInfo(sConn);

                }

                DB_Title = sConnName;
            }
            private void SetClassDBInfo(string sConnectionString)
            {
                // Data Source=210.109.60.40,4085;Initial Catalog=P1904;User ID=mes;Password="wizcore!23"
                string[] sArr = sConnectionString.Split(';');

                foreach (string s in sArr)
                {
                    string[] arr = s.Split('=');

                    if (arr.Length == 2)
                    {
                        switch (arr[0].ToUpper().Trim())
                        {
                            case "DATA SOURCE":
                                string[] arr2 = arr[1].Split(',');
                                if (arr2.Length == 2)
                                {
                                    Port = arr2[1];
                                }
                                else
                                {
                                    Port = "1433";
                                }

                                IP = arr2[0];
                                break;
                            case "INITIAL CATALOG":
                                DBName = arr[1];
                                break;
                            case "USER ID":
                                User = arr[1];
                                break;
                            case "PASSWORD":
                                Pass = arr[1];
                                if (Pass.StartsWith("\""))
                                {
                                    Pass = Pass.Substring(1, Pass.Length - 1);
                                }

                                if (Pass.EndsWith("\""))
                                {
                                    Pass = Pass.Substring(0, Pass.Length - 1);
                                }
                                break;
                        }
                    }
                }

                SQLType = "MSSQL";
            }

            public string GetConnectionString(bool bEncrypt = true)
            {
                string sConnectionString = "";

                // Data Source=210.109.60.40,4085;Initial Catalog=P1904;User ID=mes;Password="wizcore!23"
                sConnectionString = "Data Source=" + IP + "," + Port + ";Initial Catalog=" + DBName + ";User ID=" + User + ";Password=\"" + Pass + "\"";

                if (bEncrypt)
                {
                    sConnectionString = Common.EncryptString(sConnectionString);
                }

                return sConnectionString;
            }
        }


        public DBForm(string sConnection, string sName)
        {
            InitializeComponent();

            bEncrypt = CModule.GetAppSetting("ENCRYTION", "YES") == "YES";

            if (sConnection == "")
            {
                dbinfo = new classDBInfo(CModule.sConnectionString, sName, bEncrypt);
            }
            else
            {
                dbinfo = new classDBInfo(sConnection, sName, bEncrypt);
            }
            SetDBForm();
        }

        public DBForm(classDBInfo dbinfo)
        {
            InitializeComponent();

            this.dbinfo = dbinfo;

            SetDBForm();
        }

        private void SetDBForm()
        {
            SetSQLCombo();
            LoadConfig();
        }

        protected virtual void SetSQLCombo()
        {
            cmbSQLType.Items.Clear();

            cmbSQLType.Items.Add("MSSQL");
        }

        protected string TextServer
        {
            get { return txtServer.Text; }
            set { txtServer.Text = value; }
        }

        protected string TextPort
        {
            get { return txtPort.Text; }
            set { txtPort.Text = value; }
        }

        protected string TextDatabase
        {
            get { return txtDataBase.Text; }
            set { txtDataBase.Text = value; }
        }
        protected string TextUser
        {
            get { return txtUser.Text; }
            set { txtUser.Text = value; }
        }
        protected string TextPass
        {
            get { return txtPass.Text; }
            set { txtPass.Text = value; }
        }
        protected string SQLType
        {
            get { return cmbSQLType.Text; }
            set { cmbSQLType.Text = value; }
        }
        /// <summary>
        /// 환경 로드하는 메소드
        /// 기본은 Common 이 DBInfo 를 처리하도록 되어 있다.
        /// </summary>
        protected virtual void LoadConfig()
        {
            if (CModule.ToString(dbinfo.SQLType) == "")
            {
                dbinfo.SQLType = "MSSQL";
            }

            cmbSQLType.Text = dbinfo.SQLType;
            TextServer = dbinfo.IP;
            TextPort = dbinfo.Port;
            TextDatabase = dbinfo.DBName;
            TextUser = dbinfo.User;
            TextPass = dbinfo.Pass;
            txtTitle.Text = dbinfo.DB_Title;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (bDBConnectTest())
            {
                MessageBox.Show("연결 테스트에 성공했습니다.", "연결 성공", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("연결 테스트에 실패했습니다.", "연결 실패", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        protected virtual bool bDBConnectTest()
        {
            try
            {
                dbinfo.SQLType = cmbSQLType.Text;
                dbinfo.IP = TextServer.Trim();
                dbinfo.Port = TextPort.Trim();
                dbinfo.Port = dbinfo.Port == "" ? "1433" : dbinfo.Port;
                dbinfo.DBName = TextDatabase.Trim();
                dbinfo.User = TextUser.Trim();
                dbinfo.Pass = TextPass.Trim();
                dbinfo.DB_Title = txtTitle.Text.Trim();

                string sconn = dbinfo.GetConnectionString(false);

                OleDbConnection con = new OleDbConnection("Provider=SQLOleDB;" + sconn + ";Persist Security Info=False");
                con.Open();
                con.Close();
                //_msg.Exe_MessageForm("Connection Successful.", MessageBoxButtons.OK, "");
                //_msg.ShowDialog();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (SaveEnvironment())
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("연결 테스트에 실패했습니다.", "연결 실패", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        protected virtual bool SaveEnvironment()
        {
            if (bDBConnectTest())
            {
                CModule.SetAppSetting(CModule.sConnectionString, dbinfo.GetConnectionString(bEncrypt));
                CModule.SetAppSetting("DBConnectionName", dbinfo.DB_Title);

                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}

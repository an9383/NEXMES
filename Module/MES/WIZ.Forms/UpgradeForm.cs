using Infragistics.Win.Misc;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using WIZ.Control;

namespace WIZ.Forms
{
    public class UpgradeForm : Form
    {
        private bool ismove = false;

        private Point temp;

        private BackgroundWorker splashBackGroundWorker;

        private Configuration appConfig;

        private string luServer = string.Empty;

        private string luUserID = string.Empty;

        private string luPassword = string.Empty;

        private string luPort = string.Empty;

        private string luPath = string.Empty;

        private string projectID = string.Empty;

        private AutoResetEvent eventflag = new AutoResetEvent(initialState: false);

        private long downloadFileSize = 0L;

        public string version = "";

        private string oldversion = "";

        private string applicationpath = Application.StartupPath;

        private string backuppath = Application.StartupPath + "\\BACKUP";

        private string temppath = Application.StartupPath + "\\TEMP";

        private string rollbackpath = Application.StartupPath + "\\ROLLBACK";

        private string updatepath = Application.StartupPath + "\\UPDATE";

        private string clientID = string.Empty;

        private string loginid = string.Empty;

        private string lustatus = "SUCCESS";

        public bool re = false;

        private IContainer components = null;

        private CircularProgressControl indProgress;

        private UltraLabel lblCOPY;

        private UltraLabel gbxLogo;

        private UltraPanel pnlSplash;

        private RichTextBox txtLogo;

        public UpgradeForm()
        {
            InitializeComponent();
            Common.ProcessName = Process.GetCurrentProcess().ProcessName;
            appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (CModule.GetAppSetting("MODE", "RELEASE") == "DEBUG")
            {
                base.DialogResult = DialogResult.OK;
                return;
            }
            splashBackGroundWorker = new BackgroundWorker();
            splashBackGroundWorker.DoWork += splashBackGroundWorker_DoWork;
            splashBackGroundWorker.WorkerReportsProgress = true;
            splashBackGroundWorker.WorkerSupportsCancellation = true;
            clientID = Dns.GetHostName();
            string iPAddress = Common.GetIPAddress();
            clientID = clientID + "[" + iPAddress + "]";
            ShowDialog();
        }

        public UpgradeForm(string loginid, Bitmap bm)
        {
            InitializeComponent();
            gbxLogo.Appearance.ImageBackground = bm;
            appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (CModule.GetAppSetting("MODE", "REALESE") == "DEBUG")
            {
                base.DialogResult = DialogResult.OK;
                return;
            }
            splashBackGroundWorker = new BackgroundWorker();
            splashBackGroundWorker.DoWork += splashBackGroundWorker_DoWork;
            splashBackGroundWorker.WorkerReportsProgress = true;
            splashBackGroundWorker.WorkerSupportsCancellation = true;
            this.loginid = loginid;
            ShowDialog();
        }

        private void UpgradeForm_Load(object sender, EventArgs e)
        {
            splashBackGroundWorker.RunWorkerAsync();
        }

        private void splashBackGroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int num = 0;
            indProgress.Start();
            SetMessage("GET CLIENT ID(IP ADDRESS).");
            GetClientID();
            SetMessage("GET LIVEUPDATE CONFIGURATION.");
            GetLuConfig();
            SetMessage("START LIVEUPDATE.");
            DataTable lUData;
            bool[] array;
            try
            {
                if (CheckNetwork() != 1)
                {
                    Thread.Sleep(1000);
                    if (CheckNetwork() != 1)
                    {
                        Thread.Sleep(1000);
                        if (CheckNetwork() != 1)
                        {
                            Thread.Sleep(1000);
                            if (CheckNetwork() != 1)
                            {
                                FinishUpdate();
                                return;
                            }
                        }
                    }
                }
                UpdateLog("LIVE UPDATE START");
                lUData = GetLUData(projectID, clientID);
                if (lUData == null)
                {
                    FinishUpdate();
                    return;
                }
                array = new bool[lUData.Rows.Count];
                for (int i = 0; i < lUData.Rows.Count; i++)
                {
                    string str = Convert.ToString(lUData.Rows[i]["FILEID"]);
                    decimal d = Convert.ToDecimal(Convert.ToString(lUData.Rows[i]["FILEVER"]).Replace(".", ""));
                    if (File.Exists(Application.StartupPath + "\\" + str))
                    {
                        Assembly assembly = Assembly.LoadFrom(Application.StartupPath + "\\" + str);
                        decimal d2 = Convert.ToDecimal(assembly.GetName().Version.ToString().Replace(".", ""));
                        if (d2 < d)
                        {
                            num++;
                            array[i] = true;
                        }
                    }
                    else
                    {
                        num++;
                        array[i] = true;
                    }
                }
                if (num > 0)
                {
                    InitiateUpdate();
                    BackUPFile(lUData, array);
                    DownLoadFile(lUData, array);
                }
            }
            catch (Exception ex)
            {
                UpdateLog("ERROR : " + Environment.NewLine + ex.Message);
                lustatus = "FAIL";
                FinishUpdate();
                Thread.Sleep(50);
                return;
            }
            try
            {
                if (lUData.Rows.Count > 0 && num > 0)
                {
                    SetMessage("Updating.");
                    UpdateSystem(lUData, array);
                }
            }
            catch (Exception ex2)
            {
                SetMessage("UPDATE 오류 : " + Environment.NewLine + ex2.Message);
                UpdateLog("UPDATE 오류 : " + Environment.NewLine + ex2.Message);
                lustatus = "FAIL";
                RollBackSystem();
            }
            if (lustatus == "SUCCESS")
            {
            }
            if (re)
            {
                SetMessage("프로그램 구성이 바뀌었습니다. 프로그램을 재실행주세요.");
                CModule.SetAppSetting("STATUS", "RESTART");
            }
            SetMessage("LiveUpdate Complete.");
            UpdateLog("LIVE UPDATE END");
            FinishUpdate();
            Thread.Sleep(500);
        }

        public void GetLuConfig()
        {
            SetMessage("GET SERVER INFORMATION.");
            projectID = CModule.GetAppSetting("SYSTEMID", "NexMES");
        }

        public DataTable GetLUData(string projectid, string clientid)
        {
            SetMessage("GET UPDATE INFORMATION.");
            DBHelper dBHelper = new DBHelper(completedClose: false);
            DataSet dataSet = new DataSet();
            try
            {
                dataSet = dBHelper.FillDataSet("USP_ZZ0020_S1", CommandType.StoredProcedure, dBHelper.CreateParameter("SYSTEMID", projectid, DbType.String, ParameterDirection.Input));
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageForm messageForm = new MessageForm(ex);
                messageForm.ShowDialog();
                return null;
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GetLUFileData(string projectid, string fileid)
        {
            SetMessage("GET UPDATE FILE DATA");
            DBHelper dBHelper = new DBHelper(completedClose: false);
            DataSet dataSet = new DataSet();
            try
            {
                dataSet = dBHelper.FillDataSet("USP_ZZ0020_S2", CommandType.StoredProcedure, dBHelper.CreateParameter("SYSTEMID", projectid, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("FILEID", fileid, DbType.String, ParameterDirection.Input));
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageForm messageForm = new MessageForm(ex);
                messageForm.ShowDialog();
                return null;
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public void InitiateUpdate()
        {
            try
            {
                SetMessage("Initiate Update Folder.");
                InitateDirectory(updatepath);
                SetMessage("Initiate BACKUP Folder.");
                InitateDirectory(backuppath);
                SetMessage("Initiate TEMP Folder.");
                InitateDirectory(temppath);
                SetMessage("Initiate ROLLBACK Folder.");
                InitateDirectory(rollbackpath);
            }
            catch (Exception ex)
            {
                UpdateLog("INITIATE UPDATE ERROR" + Environment.NewLine + ex.Message);
                throw ex;
            }
        }

        public void InitateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] files = directoryInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo fileInfo in files)
            {
                try
                {
                    fileInfo.Attributes = FileAttributes.Normal;
                    fileInfo.Delete();
                    Thread.Sleep(50);
                }
                catch (Exception ex)
                {
                    UpdateLog("DELETE Error >> " + ex.Message);
                }
            }
        }

        private void FinishUpdate()
        {
            FileInfo fileInfo = new FileInfo(Application.StartupPath + "/" + projectID + ".exe");
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings["VERSION"].Value = FileVersionInfo.GetVersionInfo(fileInfo.FullName).FileVersion;
            configuration.Save();
            if (configuration.AppSettings.Settings["STATUS"].Value.ToString() == "RESTART")
            {
                base.DialogResult = DialogResult.Cancel;
            }
            else
            {
                base.DialogResult = DialogResult.OK;
            }
        }

        private void BackUPFile(DataTable dtUpdate, bool[] Chk)
        {
            SetMessage("BackUp File.");
            for (int i = 0; i < dtUpdate.Rows.Count; i++)
            {
                try
                {
                    if (Chk[i])
                    {
                        string str = Convert.ToString(dtUpdate.Rows[i]["FILEID"]);
                        FileInfo fileInfo = new FileInfo(applicationpath + "\\" + str);
                        File.Copy(fileInfo.FullName, backuppath + fileInfo.FullName.Replace(applicationpath, ""), overwrite: true);
                        UpdateLog("BackUp " + dtUpdate.Rows[i]["FILEID"].ToString());
                        Thread.Sleep(50);
                    }
                }
                catch (Exception ex)
                {
                    UpdateLog("BackUp Error : " + dtUpdate.Rows[i]["FILEID"].ToString() + Environment.NewLine + ex.ToString());
                    throw ex;
                }
            }
        }

        private void DownLoadFile(DataTable dtUpdate, bool[] Chk)
        {
            SetMessage("Download File.");
            for (int i = 0; i < dtUpdate.Rows.Count; i++)
            {
                try
                {
                    if (Chk[i])
                    {
                        DataTable lUFileData = GetLUFileData(projectID, Convert.ToString(dtUpdate.Rows[i]["FILEID"]));
                        if (lUFileData.Rows.Count == 0)
                        {
                            SetMessage("Download Error : " + dtUpdate.Rows[i]["FileID"].ToString() + " NOT EXSITS.");
                            UpdateLog("Download Error : " + dtUpdate.Rows[i]["FileID"].ToString() + " NOT EXSITS.");
                        }
                        else
                        {
                            byte[] array = new byte[0];
                            array = (byte[])lUFileData.Rows[0]["FILEIMAGE"];
                            FileStream fileStream = new FileStream(Application.StartupPath + "\\UPDATE\\" + lUFileData.Rows[0]["FILEID"].ToString(), FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                            fileStream.Write(array, 0, array.Length);
                            fileStream.Close();
                            UpdateLog("Download " + dtUpdate.Rows[i]["FILEID"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    UpdateLog("Download Error : " + dtUpdate.Rows[i]["FILEID"].ToString() + Environment.NewLine + ex.ToString());
                    throw ex;
                }
            }
        }

        public void UpdateSystem(DataTable dtUpdate, bool[] Chk)
        {
            for (int i = 0; i < dtUpdate.Rows.Count; i++)
            {
                Thread.Sleep(50);
                if (!Chk[i])
                {
                    continue;
                }
                SetMessage("UPDATE " + dtUpdate.Rows[i]["FILEID"].ToString());
                UpdateLog("UPDATE " + dtUpdate.Rows[i]["FILEID"].ToString() + "(" + dtUpdate.Rows[i]["FILEVER"].ToString() + ")");
                switch (dtUpdate.Rows[i]["PROCGB"].ToString())
                {
                    case "COPY":
                        try
                        {
                            if (!Directory.Exists(Application.StartupPath + dtUpdate.Rows[i]["CPath"].ToString()))
                            {
                                Directory.CreateDirectory(Application.StartupPath + dtUpdate.Rows[i]["CPath"].ToString());
                            }
                            File.Delete(Application.StartupPath + dtUpdate.Rows[i]["CPath"].ToString() + dtUpdate.Rows[i]["FileID"].ToString());
                        }
                        catch
                        {
                            UpdateLog("SET RESTART : " + dtUpdate.Rows[i]["FileID"].ToString());
                            File.Move(Application.StartupPath + dtUpdate.Rows[i]["CPath"].ToString() + dtUpdate.Rows[i]["FileID"].ToString(), Application.StartupPath + "\\TEMP\\" + dtUpdate.Rows[i]["FileID"].ToString());
                            ConfigurationManager.AppSettings.Set("STATUS", "RESTART");
                        }
                        finally
                        {
                            File.Copy(Application.StartupPath + "\\UPDATE\\" + dtUpdate.Rows[i]["FileID"].ToString(), Application.StartupPath + dtUpdate.Rows[i]["CPath"].ToString() + dtUpdate.Rows[i]["FileID"].ToString());
                        }
                        break;
                    case "EXEC":
                        {
                            string text = Convert.ToString(dtUpdate.Rows[i]["FileID"]);
                            string str = text.Replace(".exe", "") + "_TEMP.exe";
                            if (File.Exists(Application.StartupPath + "\\" + str))
                            {
                                File.Delete(Application.StartupPath + "\\" + str);
                            }
                            if (File.Exists(Application.StartupPath + "\\" + text))
                            {
                                File.Move(Application.StartupPath + "\\" + text, Application.StartupPath + "\\" + str);
                            }
                            File.Copy(Application.StartupPath + "\\UPDATE\\" + dtUpdate.Rows[i]["FileID"].ToString(), Application.StartupPath + dtUpdate.Rows[i]["CPath"].ToString() + dtUpdate.Rows[i]["FileID"].ToString());
                            re = true;
                            break;
                        }
                }
            }
        }

        public void RollBackSystem()
        {
            UpdateLog("ROLLBACK SYSTEM");
            string[] files = Directory.GetFiles(applicationpath);
            foreach (string text in files)
            {
                try
                {
                    File.Move(text, rollbackpath + text.Replace(applicationpath, ""));
                    Thread.Sleep(50);
                }
                catch (Exception ex)
                {
                    UpdateLog("ROLLBACK TEMP MOVE 오류 : " + ex.Message);
                }
            }
            string[] files2 = Directory.GetFiles(backuppath);
            foreach (string text2 in files2)
            {
                try
                {
                    File.Copy(text2, applicationpath + text2.Replace(backuppath, ""));
                    Thread.Sleep(50);
                }
                catch (Exception ex2)
                {
                    UpdateLog("ROLLBACK MOVE 오류 : " + ex2.Message);
                }
            }
            ConfigurationManager.AppSettings.Set("STATUS", "RESTART");
        }

        public void SetMessage(string message)
        {
            Thread.Sleep(100);
            if (txtLogo.InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    message = "> " + message + Environment.NewLine;
                    txtLogo.Text = message.ToUpper() + txtLogo.Text;
                    txtLogo.Select(0, message.Length);
                    txtLogo.SelectionFont = new Font("Tahoma", 11f, FontStyle.Italic);
                    txtLogo.SelectionColor = Color.Lime;
                    txtLogo.Select(message.Length - 1, txtLogo.Text.Length - message.Length);
                    txtLogo.SelectionFont = new Font("Tahoma", 11f, FontStyle.Italic);
                    txtLogo.SelectionColor = Color.YellowGreen;
                });
            }
            else
            {
                txtLogo.Text = message + Environment.NewLine + txtLogo.Text;
            }
        }

        public void UpdateLog(string message)
        {
            DBHelper dBHelper = new DBHelper(completedClose: false);
            dBHelper.ExecuteNoneQuery("USP_ZZ0040_I1", CommandType.StoredProcedure, dBHelper.CreateParameter("AS_SYSTEMID", projectID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_CLIENTID", clientID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_DESCRIPT", message, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_MAKER", loginid, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_EDITOR", loginid, DbType.String, ParameterDirection.Input));
            string[] array = message.Split('.', '(');
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == "Config" || array[i] == "config")
                {
                    re = true;
                }
            }
        }

        public void GetClientID()
        {
            clientID = Common.GetIPAddress();
        }

        private int CheckNetwork()
        {
            try
            {
                int num = 0;
                NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface networkInterface in allNetworkInterfaces)
                {
                    if (num != 0)
                    {
                        break;
                    }
                    NetworkInterfaceType networkInterfaceType = networkInterface.NetworkInterfaceType;
                    if ((networkInterfaceType == NetworkInterfaceType.Ethernet || networkInterfaceType == NetworkInterfaceType.Isdn || networkInterfaceType == NetworkInterfaceType.Wireless80211) && networkInterface.Name.ToUpper().IndexOf("VMWARE") < 0 && networkInterface.OperationalStatus == OperationalStatus.Up)
                    {
                        num = 1;
                    }
                }
                return num;
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    default:
                        return 0;
                }
            }
            catch (Exception ex2)
            {
                SetMessage(ex2.Message);
                return 0;
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
            indProgress = new WIZ.Control.CircularProgressControl();
            lblCOPY = new Infragistics.Win.Misc.UltraLabel();
            gbxLogo = new Infragistics.Win.Misc.UltraLabel();
            pnlSplash = new Infragistics.Win.Misc.UltraPanel();
            txtLogo = new System.Windows.Forms.RichTextBox();
            pnlSplash.ClientArea.SuspendLayout();
            pnlSplash.SuspendLayout();
            SuspendLayout();
            indProgress.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            indProgress.BackColor = System.Drawing.Color.Black;
            indProgress.CenterMessage = "100%";
            indProgress.Font = new System.Drawing.Font("맑은 고딕", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            indProgress.ForeColor = System.Drawing.Color.YellowGreen;
            indProgress.InnerRadiousFactor = 0.65f;
            indProgress.Interval = 50;
            indProgress.IsShowMessage = false;
            indProgress.Location = new System.Drawing.Point(3, 232);
            indProgress.Message = "";
            indProgress.MessagePosition = WIZ.Control.CircularProgressControl.MessagePositionType.Right;
            indProgress.MinimumSize = new System.Drawing.Size(28, 28);
            indProgress.Name = "indProgress";
            indProgress.OuterRadiousFactor = 0.84f;
            indProgress.Percent = 100.0;
            indProgress.Rotation = WIZ.Control.CircularProgressControl.Direction.CLOCKWISE;
            indProgress.ShowTime = true;
            indProgress.Size = new System.Drawing.Size(102, 155);
            indProgress.SpokesCount = 100;
            indProgress.SpokeThick = 2;
            indProgress.StartAngle = 270f;
            indProgress.TabIndex = 0;
            indProgress.TickColor = System.Drawing.Color.YellowGreen;
            indProgress.Type = WIZ.Control.CircularProgressControl.ControlType.PROGRESS;
            appearance.FontData.BoldAsString = "True";
            appearance.FontData.Name = "Tahoma";
            appearance.FontData.SizeInPoints = 6f;
            appearance.ForeColor = System.Drawing.Color.Silver;
            appearance.TextHAlignAsString = "Right";
            appearance.TextVAlignAsString = "Middle";
            lblCOPY.Appearance = appearance;
            lblCOPY.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblCOPY.Location = new System.Drawing.Point(0, 387);
            lblCOPY.Name = "lblCOPY";
            lblCOPY.Size = new System.Drawing.Size(583, 23);
            lblCOPY.TabIndex = 1;
            lblCOPY.Text = "Copyright ⓒ WIZ INFORMATION SYSTEMS. All rights reserved.";
            lblCOPY.Visible = false;
            gbxLogo.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            appearance2.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched;
            gbxLogo.Appearance = appearance2;
            gbxLogo.Location = new System.Drawing.Point(3, 2);
            gbxLogo.Name = "gbxLogo";
            gbxLogo.Size = new System.Drawing.Size(578, 235);
            gbxLogo.TabIndex = 2;
            appearance3.BorderColor = System.Drawing.Color.DarkGray;
            pnlSplash.Appearance = appearance3;
            pnlSplash.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            pnlSplash.ClientArea.Controls.Add(txtLogo);
            pnlSplash.ClientArea.Controls.Add(indProgress);
            pnlSplash.ClientArea.Controls.Add(gbxLogo);
            pnlSplash.ClientArea.Controls.Add(lblCOPY);
            pnlSplash.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlSplash.Location = new System.Drawing.Point(0, 0);
            pnlSplash.Name = "pnlSplash";
            pnlSplash.Size = new System.Drawing.Size(585, 412);
            pnlSplash.TabIndex = 3;
            txtLogo.BackColor = System.Drawing.SystemColors.WindowText;
            txtLogo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtLogo.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            txtLogo.ForeColor = System.Drawing.Color.YellowGreen;
            txtLogo.Location = new System.Drawing.Point(100, 232);
            txtLogo.Name = "txtLogo";
            txtLogo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            txtLogo.Size = new System.Drawing.Size(481, 155);
            txtLogo.TabIndex = 4;
            txtLogo.Text = "";
            txtLogo.WordWrap = false;
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.White;
            base.ClientSize = new System.Drawing.Size(585, 412);
            base.Controls.Add(pnlSplash);
            DoubleBuffered = true;
            Font = new System.Drawing.Font("맑은 고딕", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            base.Name = "UpgradeForm";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SPLASH";
            base.Load += new System.EventHandler(UpgradeForm_Load);
            pnlSplash.ClientArea.ResumeLayout(false);
            pnlSplash.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}

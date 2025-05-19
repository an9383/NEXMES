using Microsoft.Win32;
using System;
using System.Data;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WIZ
{
    public class License
    {
        private DataTable rtnDtTemp = new DataTable();

        private DataTable dtHederCheck = new DataTable();

        public static string sLicValue = string.Empty;

        public static string sLicProjectID = string.Empty;

        public static string sLicSystemID = string.Empty;

        public static string sLicSetupLoc = string.Empty;

        public static string sLicConnect = string.Empty;

        private static int iLicTrialDay = 15;

        private static int iLicDemoDay = 180;

        public string LicenseCheckProcess()
        {
            string result = string.Empty;
            try
            {
                string a = Common.DecryptString(sLicValue);
                if (!(a == "LC-ONLINE"))
                {
                    if (a == "LC-OFFLINE")
                    {
                        string text = LicOfflineCheck();
                        string[] array = text.Split(']');
                        switch (array[0])
                        {
                            case "[S":
                            case "[Trial":
                            case "[Demo":
                                result = text;
                                break;
                            case "[E":
                                result = Common.getLangText("[E] 라이센스가 만료 되었습니다.", "MSG");
                                break;
                        }
                    }
                }
                else
                {
                    dtHederCheck = LicHederCheck();
                    if (dtHederCheck.Rows.Count == 0)
                    {
                        if (LicHederADD())
                        {
                            result = Common.getLangText("[S] 라이센스 헤더정보를 등록 하였습니다.", "MSG");
                            result = ((!LicDetailADD()) ? Common.getLangText("[E] 라이센스 등록 오류가 발생 하였습니다.", "MSG") : Common.getLangText("[S] 해당 단말기의 라이센스를 등록 하였습니다.", "MSG"));
                        }
                        else
                        {
                            result = Common.getLangText("[E] 라이센스 헤더정보 등록 오류가 발생 하였습니다.", "MSG");
                        }
                    }
                    else if (Convert.ToString(dtHederCheck.Rows[0]["USEFLAG"]) == "Y")
                    {
                        if (LicCloseDayCheck())
                        {
                            string text2 = LicDetailCheck();
                            string[] array2 = text2.Split(']');
                            switch (array2[0])
                            {
                                case "[S":
                                    LicDetailUpdate();
                                    result = Common.getLangText(text2, "MSG");
                                    break;
                                case "[N":
                                    result = Common.getLangText(text2, "MSG");
                                    break;
                                case "[E":
                                    result = ((!LicQtyCheck()) ? ((!LicDetailADD()) ? Common.getLangText("[E] 라이센스 등록 오류가 발생 하였습니다.", "MSG") : Common.getLangText("[S] 해당 단말기의 라이센스를 등록 하였습니다.", "MSG")) : Common.getLangText("[E] 라이센스 수량이 초과되어 등록이 불가능 합니다.", "MSG"));
                                    break;
                            }
                        }
                        else
                        {
                            result = Common.getLangText("[E] 라이센스가 만료 되었습니다.", "MSG");
                        }
                    }
                    else
                    {
                        result = Common.getLangText("[E] 라이센스가 만료 되었습니다.", "MSG");
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private DataTable LicHederCheck()
        {
            StringBuilder stringBuilder = null;
            DBHelper dBHelper = new DBHelper(false, sLicConnect);
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                stringBuilder.AppendLine(" SELECT PROJECTID, SYSTEMID, SETUPLOC, LICQTY, ST_DT, EN_DT, USEFLAG ");
                stringBuilder.AppendLine("   FROM T_LICENSE_H WITH (NOLOCK) ");
                stringBuilder.AppendLine("  WHERE PROJECTID = '" + sLicProjectID + "'");
                stringBuilder.AppendLine("    AND SYSTEMID  = '" + sLicSystemID + "'");
                rtnDtTemp = dBHelper.FillTable(Convert.ToString(stringBuilder));
                return rtnDtTemp;
            }
            catch
            {
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        private bool LicHederADD()
        {
            StringBuilder stringBuilder = null;
            DBHelper dBHelper = new DBHelper(false, sLicConnect);
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                stringBuilder.AppendLine(" INSERT INTO T_LICENSE_H ( PROJECTID, SYSTEMID, SETUPLOC, EN_DT ) ");
                stringBuilder.AppendLine("                  VALUES ( '" + sLicProjectID + "', ");
                stringBuilder.AppendLine("                           '" + sLicSystemID + "',  ");
                stringBuilder.AppendLine("                           '" + sLicSetupLoc + "',  ");
                stringBuilder.AppendLine("                           '" + DateTime.Now.AddDays(iLicTrialDay).ToString("yyyy-MM-dd hh:mm:ss") + "' ) ");
                dBHelper.ExecuteNoneQuery(Convert.ToString(stringBuilder), CommandType.Text);
                dBHelper.Commit();
                return true;
            }
            catch
            {
                dBHelper.Rollback();
                return false;
            }
            finally
            {
                dBHelper.Close();
            }
        }

        private bool LicDetailADD()
        {
            StringBuilder stringBuilder = null;
            DBHelper dBHelper = new DBHelper(false, sLicConnect);
            try
            {
                string str = Convert.ToString(Dns.GetHostName());
                string text = Convert.ToString(NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress());
                if (text.Length != 12)
                {
                    MessageBox.Show(Common.getLangText("[E] 랜카드를 확인 하세요.", "MSG"));
                    return false;
                }
                string text2 = CheckIP();
                if (text2 == string.Empty)
                {
                    MessageBox.Show(Common.getLangText("[E] IP 정보 수집을 실패 하였습니다.", "MSG"));
                    return false;
                }
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                stringBuilder.AppendLine(" INSERT INTO T_LICENSE_D ( PROJECTID, SYSTEMID, MACADDRESS, HOSTNAME, OUTIP ) ");
                stringBuilder.AppendLine("                  VALUES ( '" + sLicProjectID + "', ");
                stringBuilder.AppendLine("                           '" + sLicSystemID + "',  ");
                stringBuilder.AppendLine("                           '" + text + "',   ");
                stringBuilder.AppendLine("                           '" + str + "',    ");
                stringBuilder.AppendLine("                           '" + text2 + "' )       ");
                dBHelper.ExecuteNoneQuery(Convert.ToString(stringBuilder), CommandType.Text);
                dBHelper.Commit();
                return true;
            }
            catch
            {
                dBHelper.Rollback();
                return false;
            }
            finally
            {
                dBHelper.Close();
            }
        }

        private string CheckIP()
        {
            try
            {
                string address = (Common.gsIPSite == string.Empty) ? "http://ipconfig.kr/" : Common.gsIPSite;
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.Default;
                string input = webClient.DownloadString(address);
                Regex regex = new Regex("\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}");
                Match value = regex.Match(input);
                return Convert.ToString(value);
            }
            catch
            {
                return string.Empty;
            }
        }

        private bool LicCloseDayCheck()
        {
            try
            {
                DateTime t = Convert.ToDateTime(dtHederCheck.Rows[0]["EN_DT"]);
                DateTime now = DateTime.Now;
                if (t > now)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private string LicDetailCheck()
        {
            StringBuilder stringBuilder = null;
            DBHelper dBHelper = new DBHelper(false, sLicConnect);
            try
            {
                string text = Convert.ToString(NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress());
                if (text.Length != 12)
                {
                    return "[E] 랜카드를 확인 하세요.";
                }
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                stringBuilder.AppendLine(" SELECT PROJECTID, SYSTEMID, LICSEQ, MACADDRESS, HOSTNAME, RUN_DT, USEFLAG ");
                stringBuilder.AppendLine("   FROM T_LICENSE_D WITH (NOLOCK)            ");
                stringBuilder.AppendLine("  WHERE PROJECTID  = '" + sLicProjectID + "' ");
                stringBuilder.AppendLine("    AND SYSTEMID   = '" + sLicSystemID + "'  ");
                stringBuilder.AppendLine("    AND MACADDRESS = '" + text + "'   ");
                rtnDtTemp = dBHelper.FillTable(Convert.ToString(stringBuilder));
                if (rtnDtTemp.Rows.Count > 0)
                {
                    if (Convert.ToString(rtnDtTemp.Rows[0]["USEFLAG"]) == "N")
                    {
                        return "[N] 해당 단말기의 라이센스는 사용 불가능 합니다.";
                    }
                    return "[S] 라이센스 등록 된 단말기 입니다.";
                }
                return "[E] 라이센스 미등록 된 단말기 입니다.";
            }
            catch
            {
                return "[E] 라이센스 상세정보 조회 오류 입니다.";
            }
            finally
            {
                dBHelper.Close();
            }
        }

        private void LicDetailUpdate()
        {
            StringBuilder stringBuilder = null;
            DBHelper dBHelper = new DBHelper(false, sLicConnect);
            try
            {
                string text = Convert.ToString(NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress());
                if (text.Length != 12)
                {
                    MessageBox.Show(Common.getLangText("[E] 랜카드를 확인 하세요.", "MSG"));
                }
                else
                {
                    stringBuilder = new StringBuilder();
                    stringBuilder.Remove(0, stringBuilder.Length);
                    stringBuilder.AppendLine(" UPDATE T_LICENSE_D                          ");
                    stringBuilder.AppendLine("    SET RUN_DT = GETDATE()                   ");
                    stringBuilder.AppendLine("  WHERE PROJECTID  = '" + sLicProjectID + "' ");
                    stringBuilder.AppendLine("    AND SYSTEMID   = '" + sLicSystemID + "'  ");
                    stringBuilder.AppendLine("    AND MACADDRESS = '" + text + "'   ");
                    dBHelper.ExecuteNoneQuery(Convert.ToString(stringBuilder), CommandType.Text);
                    dBHelper.Commit();
                }
            }
            catch
            {
                dBHelper.Rollback();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        private bool LicQtyCheck()
        {
            StringBuilder stringBuilder = null;
            DBHelper dBHelper = new DBHelper(false, sLicConnect);
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                stringBuilder.AppendLine(" SELECT A1.PROJECTID, A1.SYSTEMID, A1.SETUPLOC, A1.LICQTY, ISNULL(COUNT(A2.MACADDRESS), 0) AS USERQTY ");
                stringBuilder.AppendLine("   FROM T_LICENSE_H A1 WITH (NOLOCK) LEFT JOIN                                                        ");
                stringBuilder.AppendLine("        T_LICENSE_D A2 WITH (NOLOCK) ON A2.PROJECTID = A1.PROJECTID AND A2.SYSTEMID = A1.SYSTEMID     ");
                stringBuilder.AppendLine("  WHERE A1.PROJECTID = '" + sLicProjectID + "'                                                        ");
                stringBuilder.AppendLine("    AND A1.SYSTEMID  = '" + sLicSystemID + "'                                                         ");
                stringBuilder.AppendLine("    AND A2.USEFLAG   = 'Y'                                                                            ");
                stringBuilder.AppendLine("  GROUP BY A1.PROJECTID, A1.SYSTEMID, A1.SETUPLOC, A1.LICQTY                                          ");
                rtnDtTemp = dBHelper.FillTable(Convert.ToString(stringBuilder));
                if (rtnDtTemp.Rows.Count > 0)
                {
                    int num = DBHelper.nvlInt(rtnDtTemp.Rows[0]["LICQTY"]);
                    int num2 = DBHelper.nvlInt(rtnDtTemp.Rows[0]["USERQTY"]);
                    if (num <= num2)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch
            {
                return true;
            }
            finally
            {
                dBHelper.Close();
            }
        }

        private string LicOfflineCheck()
        {
            try
            {
                string result = string.Empty;
                string text = Convert.ToString(NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress());
                if (text.Length != 12)
                {
                    return "[E] 랜카드를 확인 하세요.";
                }
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\WizLic");
                if (registryKey == null)
                {
                    registryKey = Registry.LocalMachine.CreateSubKey("Software\\WizLic");
                    registryKey.Close();
                }
                RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("Software\\WizLic").OpenSubKey("02");
                if (registryKey2 == null)
                {
                    registryKey2 = Registry.LocalMachine.CreateSubKey("Software\\WizLic").CreateSubKey("02");
                    registryKey2.SetValue("ProdVer", Common.EncryptString("Trial"));
                    registryKey2.SetValue("ProdKey", Common.EncryptString("Wizcore"));
                    registryKey2.SetValue("DateKey", Common.EncryptString("{DateTime.Now:yyyy-MM-dd}"));
                    registryKey2.Close();
                }
                registryKey2 = Registry.LocalMachine.OpenSubKey("Software\\WizLic").OpenSubKey("02", writable: true);
                string text2 = Common.DecryptString(Convert.ToString(registryKey2.GetValue("ProdVer", string.Empty)));
                string text3 = Common.DecryptString(Convert.ToString(registryKey2.GetValue("DateKey", string.Empty)));
                string a = Convert.ToString(registryKey2.GetValue("ProdKey", string.Empty));
                registryKey2.Close();
                if (text2 == string.Empty || a == string.Empty || text3 == string.Empty)
                {
                    registryKey2 = Registry.LocalMachine.OpenSubKey("Software\\WizLic").OpenSubKey("02", writable: true);
                    registryKey2.SetValue("ProdVer", string.Empty);
                    registryKey2.SetValue("ProdKey", string.Empty);
                    registryKey2.Close();
                    return Common.getLangText("[E] 라이센스가 만료 되었습니다.", "MSG");
                }
                DateTime dateTime = Convert.ToDateTime(text3);
                switch (text2)
                {
                    case "Trial":
                        if (DateTime.Compare(DateTime.Now, dateTime.AddDays(iLicTrialDay)) >= 0)
                        {
                            registryKey2 = Registry.LocalMachine.OpenSubKey("Software\\WizLic").OpenSubKey("02", writable: true);
                            registryKey2.SetValue("ProdVer", string.Empty);
                            registryKey2.SetValue("ProdKey", string.Empty);
                            registryKey2.Close();
                            result = Common.getLangText("[E] 라이센스가 만료 되었습니다.", "MSG");
                        }
                        else
                        {
                            result = "[Trial] " + "{dateTime.AddDays(iLicTrialDay):yyyy-MM-dd}" + " " + Common.getLangText("라이센스가 완료 됩니다.", "MSG");
                        }
                        break;
                    case "Demo":
                        if (DateTime.Compare(DateTime.Now, dateTime.AddDays(iLicDemoDay)) >= 0)
                        {
                            registryKey2 = Registry.LocalMachine.OpenSubKey("Software\\WizLic").OpenSubKey("02", writable: true);
                            registryKey2.SetValue("ProdVer", string.Empty);
                            registryKey2.SetValue("ProdKey", string.Empty);
                            registryKey2.Close();
                            result = Common.getLangText("[E] 라이센스가 만료 되었습니다.", "MSG");
                        }
                        else
                        {
                            result = "[Demo] " + "{dateTime.AddDays(iLicDemoDay):yyyy-MM-dd}" + " " + Common.getLangText("라이센스가 완료 됩니다.", "MSG");
                        }
                        break;
                    case "Release":
                        if (a != Common.EncryptString(text + "coRe"))
                        {
                            registryKey2 = Registry.LocalMachine.OpenSubKey("Software\\WizLic").OpenSubKey("02", writable: true);
                            registryKey2.SetValue("ProdVer", string.Empty);
                            registryKey2.SetValue("ProdKey", string.Empty);
                            registryKey2.Close();
                            result = Common.getLangText("[E] 라이센스가 만료 되었습니다.", "MSG");
                        }
                        else
                        {
                            result = Common.getLangText("[S] 라이센스 등록 된 단말기 입니다.", "MSG");
                        }
                        break;
                }
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

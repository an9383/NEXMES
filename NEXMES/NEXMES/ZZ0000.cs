#region [ HEADER AREA ]
// *---------------------------------------------------------------------------------------------*
//   Form ID        : ZZ0000
//   Form Name      : 로그인 & 서버IP 설정
//   Name Space     : NEXMES
//   Created Date   : 2017.01.01
//   Made By        : WIZ
//   Description    : 
//   DB Table       : 
//   StoreProcedure : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region [ USING AREA ]
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

using WIZ;
using WIZ.Forms;
#endregion

namespace NEXMES
{
    public partial class ZZ0000 : Form
    {
        #region [ MEMBER AREA ]
        private DataTable dtSite;

        private int iLoginCnt = 0;
        private const int iLogonCnt_Stand = 3;

        public string sUserID = "SYSTEM";
        public string sUserNM = string.Empty;

        Common _common = new Common();
        #endregion

        #region [ CONSTRUCTOR ]
        public ZZ0000()
        {
            InitializeComponent();

            WIZ.Common.ProcessName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            WIZ.Common.MESFileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName;

            try
            {
                //System.Collections.Specialized.NameValueCollection sitecollection = (System.Collections.Specialized.NameValueCollection)ConfigurationManager.GetSection("site");
                //System.Collections.Specialized.NameValueCollection sitenamecollection = (System.Collections.Specialized.NameValueCollection)ConfigurationManager.GetSection("sitename");

                dtSite = new DataTable();
                dtSite.Columns.Add("SITE");
                dtSite.Columns.Add("SITENAME");

                List<IniValue> listValues = CModule.GetConfigGroupList("SITE");

                for (int i = 0; i < listValues.Count; i++)
                {
                    DataRow drTemp = dtSite.NewRow();
                    drTemp["SITE"] = listValues[i].Key;
                    drTemp["SITENAME"] = listValues[i].Value;
                    dtSite.Rows.Add(drTemp);
                }

                if (dtSite.Rows.Count == 0)
                {
                    DataRow drTemp = dtSite.NewRow();
                    drTemp["SITE"] = "10";
                    drTemp["SITENAME"] = "WIZCORE";
                    dtSite.Rows.Add(drTemp);
                }

                this.cboSite.DataSource = dtSite;
                this.cboSite.ValueMember = "SITE";
                this.cboSite.DisplayMember = "SITENAME";
                this.cboSite.Value = CModule.GetAppSetting("SITE", "10");

                if (CModule.GetAppSetting("MODE", "RELEASE") == "DEBUG")
                {
                    this.sUserID = "SYSTEM";
                    this.DialogResult = DialogResult.OK;

                    License.sLicValue = ConfigurationManager.AppSettings.GetValues("LICVALUE")[0];
                    License.sLicProjectID = ConfigurationManager.AppSettings.GetValues("PROJECTID")[0];
                    License.sLicSystemID = ConfigurationManager.AppSettings.GetValues("SYSTEMID")[0];
                    License.sLicSetupLoc = ConfigurationManager.AppSettings.GetValues("SETUPLOC")[0];
                    License.sLicConnect = ConfigurationManager.AppSettings.GetValues("LICCONNECT")[0];

                    return;
                }

                if (CModule.GetAppSetting("CHECKLOGIN", "Y") == "N")
                {
                    this.sUserID = CModule.GetAppSetting("LOGINID", "");
                    this.DialogResult = DialogResult.OK;

                    License.sLicValue = ConfigurationManager.AppSettings.GetValues("LICVALUE")[0];
                    License.sLicProjectID = ConfigurationManager.AppSettings.GetValues("PROJECTID")[0];
                    License.sLicSystemID = ConfigurationManager.AppSettings.GetValues("SYSTEMID")[0];
                    License.sLicSetupLoc = ConfigurationManager.AppSettings.GetValues("SETUPLOC")[0];
                    License.sLicConnect = ConfigurationManager.AppSettings.GetValues("LICCONNECT")[0];

                    return;
                }

                this.txtWorkerID.Text = CModule.GetAppSetting("LOGINID", "");

                Common.SQLTIMEOUT = CModule.GetAppSetting("SQLTIMEOUT", "180");
                Common.gsFTPSite = Common.DecryptString(ConfigurationManager.AppSettings.GetValues("FTPCONNECT")[0]);

                this.iLoginCnt = iLogonCnt_Stand;

                License.sLicValue = ConfigurationManager.AppSettings.GetValues("LICVALUE")[0];
                License.sLicProjectID = ConfigurationManager.AppSettings.GetValues("PROJECTID")[0];
                License.sLicSystemID = ConfigurationManager.AppSettings.GetValues("SYSTEMID")[0];
                License.sLicSetupLoc = ConfigurationManager.AppSettings.GetValues("SETUPLOC")[0];
                License.sLicConnect = ConfigurationManager.AppSettings.GetValues("LICCONNECT")[0];

            }
            catch (Exception ex)
            {

            }

            this.ShowDialog();
        }
        #endregion

        #region [ ZZ0000_Load ]
        private void ZZ0000_Load(object sender, EventArgs e)
        {
            WIZ.Common.DefaultLang = "KO";
            WIZ.Common.Lang = CModule.GetAppSetting("LANGUAGE", "KO");

            rtx_Notice();
            cboLangSet();
            LicenseIPSet();
        }
        #endregion

        #region [ EVENT AREA ]
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Password_Confirm();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            ZZ0300 zz0300 = new ZZ0300(txtWorkerID.Text.Trim());
            zz0300.ShowDialog();
        }

        private void lblLogonWorkerID_DoubleClick(object sender, EventArgs e)
        {
            ZZ0200 zz0200 = new ZZ0200(Convert.ToString(cboSite.Value));
            zz0200.ShowDialog();
        }

        private void lblPassword_DoubleClick(object sender, EventArgs e)
        {
            if (txtWorkerID.Text.Equals("SYSTEM"))
                txtPassword.Text = "1";
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            ZZ0200 zz0200 = new ZZ0200();
            zz0200.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboSite_ValueChanged(object sender, EventArgs e)
        {
            //System.Collections.Specialized.NameValueCollection sitecollection = (System.Collections.Specialized.NameValueCollection)ConfigurationManager.GetSection("site");

            //for (int i = 0; i < Common.appConfig.ConnectionStrings.ConnectionStrings.Count; i++)
            //{
            //    Common.appConfig.ConnectionStrings.ConnectionStrings[i].ConnectionString = Convert.ToString(sitecollection[Convert.ToString(cboSite.Value)]);
            //}
            //CModule.SetAppSetting("SITE", DBHelper.nvlString(this.cboSite.Value));

            cboLangSet();
        }

        private void cboLang_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(this.cboLang.Value) != "")
                {
                    CModule.SetAppSetting("LANGUAGE", Convert.ToString(this.cboLang.Value));

                    WIZ.Common.Lang = Convert.ToString(this.cboLang.Value);

                    this.FontSet(WIZ.Common.Lang);
                }
            }
            catch (Exception ex)
            {
                this.ShowDialog(Common.getLangText(ex.Message, "MSG"), DialogForm.DialogType.OK);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Password_Confirm();
            }
        }
        #endregion

        #region [ METHOD AREA ]
        private void Password_Confirm()
        {
            string sMyIP = Common.GetIPAddress();

            this.lblLogonWorkerID.Enabled = false;
            this.lblPassword.Enabled = false;
            this.txtWorkerID.Enabled = false;
            this.txtPassword.Enabled = false;
            this.btnConfirm.Enabled = false;
            this.btnClose.Enabled = false;
            this.btnChange.Enabled = false;

            DBHelper helper = new DBHelper(false);
            DateTime sLastDate = DateTime.Now;
            string sPlantCode = "";

            try
            {
                DataTable dt = helper.FillTable("USP_ZGETWORKERINFO_S", CommandType.StoredProcedure
                             , helper.CreateParameter("pWorkerID", this.txtWorkerID.Text.Trim(), DbType.String, ParameterDirection.Input));

                if (dt.Rows.Count == 0)
                {
                    ShowDialog(Common.getLangText("MEMBER ID를 확인하세요.", "MSG"));

                    this.lblLogonWorkerID.Enabled = true;
                    this.lblPassword.Enabled = true;
                    this.txtWorkerID.Enabled = true;
                    this.txtPassword.Enabled = true;
                    this.btnConfirm.Enabled = true;
                    this.btnClose.Enabled = true;
                    this.btnChange.Enabled = true;

                    return;
                }

                string sPWD = DBHelper.nvlString(dt.Rows[0]["Password"]);
                sUserNM = DBHelper.nvlString(dt.Rows[0]["WORKERNAME"]);
                sLastDate = Convert.ToDateTime(dt.Rows[0]["EDITDATE"]);
                sPlantCode = DBHelper.nvlString(dt.Rows[0]["PLANTCODE"]);

                bool bpwok = false;

                if (sPWD == Common.MD5Hash(this.txtPassword.Text.Trim())) //WIZ.Common.EncryptString(this.txtPassword.Text)
                    bpwok = true;

                if (bpwok == false)
                {
                    iLoginCnt--;

                    if (iLoginCnt == 0)
                    {
                        ShowDialog(Common.getLangText("로그인에 실패 했습니다. 시스템을 종료합니다.", "MSG"), DialogForm.DialogType.OK);
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    }
                    else
                    {
                        ShowDialog(Common.getLangText("사용자 아이디나, 패스워드가 틀립니다.", "MSG"));

                        this.lblLogonWorkerID.Enabled = true;
                        this.lblPassword.Enabled = true;
                        this.txtWorkerID.Enabled = true;
                        this.txtPassword.Enabled = true;
                        this.btnConfirm.Enabled = true;
                        this.btnClose.Enabled = true;
                        this.btnChange.Enabled = true;

                        this.txtPassword.Focus();
                    }

                    return;
                }
            }
            catch (SqlException)
            {
                ShowDialog(Common.getLangText("연결 상태를 확인하세요.", "MSG"));
                this.DialogResult = DialogResult.Cancel;
                this.Close();

                return;
            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message);
                this.DialogResult = DialogResult.Cancel;
                this.Close();

                return;
            }

            if (sLastDate.AddDays(90) < DateTime.Now)
            {
                DialogForm _Diag = new DialogForm(Common.getLangText("암호를 변경한지 90일이 넘었습니다." + Environment.NewLine + "암호를 변경하세요.", "MSG")
                                            , DialogForm.DialogType.YESNOCANCEL, new string[] { "변경", "갱신", "취소" });

                DialogResult dResult = _Diag.ShowDialog();

                if (DialogResult.Yes == dResult)
                {
                    ZZ0300 zz0300 = new ZZ0300(txtWorkerID.Text.Trim());
                    zz0300.ShowDialog();
                }
                else if (DialogResult.No == dResult)
                {
                    helper.FillTable("USP_ZZ0300_U1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("pWorkerID", txtWorkerID.Text.Trim(), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("pPWD", "", DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("pChgPWD", "", DbType.String, ParameterDirection.Input));
                }

                this.lblLogonWorkerID.Enabled = true;
                this.lblPassword.Enabled = true;
                this.txtWorkerID.Enabled = true;
                this.txtPassword.Enabled = true;
                this.btnConfirm.Enabled = true;
                this.btnClose.Enabled = true;
                this.btnChange.Enabled = true;

                return;
            }

            CModule.SetAppSetting("PLANTCODE", sPlantCode);

            this.DialogResult = DialogResult.OK;

            this.sUserID = this.txtWorkerID.Text.Trim();

            SaveDoWorkType(this.sUserID, sMyIP, "LOGIN");

            CModule.SetAppSetting("LOGINID", sUserID);
        }

        private void SaveDoWorkType(string sUser, string sIP, string sType)
        {
            try
            {
                DBHelper Helper = new WIZ.DBHelper("", true);

                try
                {
                    Helper.ExecuteNoneQuery("USP_SY0110_I1", CommandType.StoredProcedure
                                                           , Helper.CreateParameter("PROGRAMID", "MAIN", DbType.String, ParameterDirection.Input)
                                                           , Helper.CreateParameter("WORKERID", sUser, DbType.String, ParameterDirection.Input)
                                                           , Helper.CreateParameter("WORKTYPE", sType, DbType.String, ParameterDirection.Input)
                                                           , Helper.CreateParameter("IP", sIP, DbType.String, ParameterDirection.Input)
                                                           , Helper.CreateParameter("COMNAME", Convert.ToString(Environment.MachineName), DbType.String, ParameterDirection.Input));

                    Helper.Commit();
                }
                catch (Exception ex)
                {
                    Helper.Rollback();

                    ShowDialog(ex.Message);
                }
                finally
                {
                    Helper.Close();
                }
            }
            catch (Exception)
            {
                ShowDialog(Common.getLangText("Network 연결을 확인하세요.", "MSG"));
            }
        }

        private void rtx_Notice()
        {
            DBHelper helper = new DBHelper(false);

            try
            {

                DataTable rtnDtTemp = helper.FillTable("USP_SY0140_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("AS_PLANTCODE", this.cboSite.Value, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    rtxNotice.Text = Convert.ToString(rtnDtTemp.Rows[0]["MTTEXT"]);
                    rtxNotice.Rtf = Convert.ToString(rtnDtTemp.Rows[0]["MTRTF"]);
                }
                else
                {
                    rtxNotice.Text = string.Empty;
                    rtxNotice.Rtf = string.Empty;
                }
            }
            catch (Exception ex)
            {
                rtxNotice.Text = ex.ToString();
            }
            finally
            {
                helper.Close();
            }
        }

        private void cboLangSet()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                cboLang.DataSource = helper.FillTable("USP_ZA0000_S3", CommandType.StoredProcedure);
                cboLang.Value = CModule.GetAppSetting("LANGUAGE", "KO");
            }
            catch (Exception ex)
            {
                cboLang.Value = CModule.GetAppSetting("LANGUAGE", "KO");
            }
            finally
            {
                helper.Close();
            }
        }

        private void LicenseIPSet()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                DataTable rtnDtTemp = helper.FillTable("USP_ZA0000_S4", CommandType.StoredProcedure
                                     , helper.CreateParameter("AS_PLANTCODE", this.cboSite.Value, DbType.String, ParameterDirection.Input));

                if (rtnDtTemp.Rows.Count > 0)
                {
                    Common.gsIPSite = Convert.ToString(rtnDtTemp.Rows[0]["RELCODE4"]);
                }
            }
            catch
            {
            }
            finally
            {
                helper.Close();
            }
        }

        private DialogResult ShowDialog(string sMessageID, DialogForm.DialogType sType = DialogForm.DialogType.OK)
        {
            DialogForm _Diag = new DialogForm(sMessageID, sType);

            return _Diag.ShowDialog();
        }

        private void FontSet(string lang)
        {
            try
            {
                DataTable dtTemp = _common.GET_BM0000_CODE("LANG"); ;

                Common.FontName = Convert.ToString(((DataRow[])dtTemp.Select("CODE_ID = '" + lang + "'"))[0]["RelCode1"]);
            }
            catch (Exception ex)
            {
                this.ShowDialog(Common.getLangText("기초정보가 없습니다.", "MSG"), DialogForm.DialogType.OK);
            }
        }
        #endregion
    }
}
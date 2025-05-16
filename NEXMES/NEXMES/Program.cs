using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NEXMES
{

    static class Program
    {
        [DllImport("user32.dll")]
        public static extern void BringWindowToTop(IntPtr hWnd);

        [DllImport("User32", EntryPoint = "SetForegroundWindow")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("User32")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //WIZ.License _lic = new WIZ.License();

            string sUserid = string.Empty;
            string sUserName = string.Empty;
            string sUserPlantCode = string.Empty;

            WIZ.CModule.LoadEnvironment();  // 환경설정 로딩

            // RESTART인 경우, 로그인을 하지 않고 시작
            if (NEXMES.Program.CheckMultiProcess())
            {
                // 2020-02-04 - TEST, 영보공업 MES 데이터 확인을 위해 중복 실행 불가 옵션 임시로 해제
                //return;

            }

            // 프로그램 전체에서 사용되어지는 Style 파일을 정의
            Microsoft.Win32.RegistryKey rkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"NEXMES\UI");

            if (rkey != null)
            {
                WIZ.Common.UIStyle = rkey.GetValue("STYLE").ToString();
            }

            // 프로그램 전체에서 사용되어지는 Style 파일을 정의
            if (WIZ.Common.UIStyle != "")
            {
                Infragistics.Win.AppStyling.StyleManager.Load(Application.StartupPath + @"\" + WIZ.Common.UIStyle + ".isl");
            }
            else
            {
                if (System.IO.File.Exists(Application.StartupPath + @"\DarkGray.isl"))
                {
                    Infragistics.Win.AppStyling.StyleManager.Load(Application.StartupPath + @"\DarkGray.isl");
                }
                else
                {
                    Infragistics.Win.AppStyling.StyleManager.Load(Application.StartupPath + @"\Style.isl");
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (WIZ.CModule.GetAppSetting("SQLSERVER_SELECT", "Y") == "Y" && WIZ.CModule.GetAppSetting("MODE", "DEBUG") == "DEBUG")
            {
                ZZ0200 zz0200 = new ZZ0200("10");
                zz0200.ShowDialog();
            }

            if (WIZ.CModule.GetAppSetting("STATUS", "START") == "START")
            {
                ZZ0000 zz0000 = new ZZ0000();

                if (zz0000.DialogResult != DialogResult.OK)
                {
                    return;
                }

                sUserid = zz0000.sUserID;
                sUserName = zz0000.sUserNM;

                ZZ0100 zz0100 = new ZZ0100();

                if (zz0100.DialogResult == DialogResult.Cancel)
                {
                    Application.Restart();

                    return;
                }
            }
            else
            {
                WIZ.CModule.SetAppSetting("STATUS", "START");
                sUserid = WIZ.CModule.GetAppSetting("LOGINID", "");
            }

            NEXMES.Program.RunApplication(new string[] { sUserid, sUserName });
            //string sLicMsg = _lic.LicenseCheckProcess();
            //string[] sArr = sLicMsg.Split(']');

            //if (sArr[0] == "[S")
            //{
            //	
            //}
            //else
            //{
            //	WIZ.Forms.DialogForm _Diag = new WIZ.Forms.DialogForm(WIZ.Common.getLangText(sLicMsg, "MSG"), WIZ.Forms.DialogForm.DialogType.OK);

            //	_Diag.ShowDialog();
            //}
        }

        /// <summary>
        /// 중복프로그램 실행 확인
        /// </summary>
        /// <returns></returns>
        public static Boolean CheckMultiProcess()
        {
            int thisID = System.Diagnostics.Process.GetCurrentProcess().Id; // 현재 기동한 프로그램 id

            //실행중인 프로그램중 현재 기동한 프로그램과 같은 프로그램들 수집
            System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName);

            if (p.Length > 1)
            {
                for (int i = 0; i < p.Length; i++)
                {
                    if (p[i].Id == thisID) continue;

                    ShowWindow(p[i].MainWindowHandle, 1);
                    BringWindowToTop(p[i].MainWindowHandle);
                    SetForegroundWindow(p[i].MainWindowHandle);

                    break;
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// APPLICATION 실행
        /// </summary>
        /// <param name="args"></param>
        public static void RunApplication(params object[] args)  //params 키워드를 사용하면 가변 개수의 인수를 사용하는 params를 지정할 수 있습니다. 매개 변수 배열은 1차원 배열이어야 합니다.
        {
            Assembly assembly;
            Type typeForm;
            Form newForm;

            assembly = Assembly.LoadFrom(Application.StartupPath + @"\" + WIZ.CModule.GetAppSetting("STARTFORMFILE", "WIZ.MAIN.DLL"));
            typeForm = assembly.GetType(WIZ.CModule.GetAppSetting("STARTFORM", "WIZ.MAIN.ZA0003"), true);
            newForm = (Form)Activator.CreateInstance(typeForm, args);
            Application.Run(newForm);
            //Application.Run(new Form1());
        }
    }
}

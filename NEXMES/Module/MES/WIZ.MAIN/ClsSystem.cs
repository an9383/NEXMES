using System;
using System.Drawing;           //Image
using System.Globalization;     //DaylightTime 개체에서 사용
using System.IO;                //MemoryStream
using System.Reflection;        //MethodBase, Assembly 사용시 필요
using System.Windows.Forms;     //MessageBox

namespace WIZ.MAIN
{
    /// <summary>
    /// 클래스 - 윈도우 등 시스템 함수 정보
    /// <para> 2020-12-31 add : 신효철 </para>
    /// </summary>
    public class ClsSystem
    {
        /// <summary>
        /// 파일실행 방법- 종류 
        /// <para> 2021-01-08 add : 신효철 </para>
        /// </summary>
        public enum FileExecuteType
        {
            /// <summary>
            /// 파일실행 방법 - Process.Start(프로그램명 또는 sDirPathFileName 값 )으로 즉시 실행
            /// </summary>
            FileExecuteType_Start,
            /// <summary>
            /// 파일실행 방법 - Process.StartInfo에 세부적인 실행설정 추가 후 Start()로 실행
            /// </summary>
            FileExecuteType_StartInfoAdd,
            /// <summary>
            /// 파일실행 방법 - ShellExecute API로 실행설정 후 실행 - 2020-03-22 add
            /// </summary>
            FileExecuteType_ShellExecute
        }



        /// <summary> 
        /// Assembly.GetExecutingAssembly.GetName.Version Text로 부터 ProgramVersion 구합니다.
        /// <para> 프로젝트 - 속성 - 어플리케이션 - {어셈블리 정보 - 어셈블리 버전 }</para>
        /// <para> 2020-12-31 add : 신효철 </para>
        /// </summary> 
        /// <returns></returns> 
        public string DoApplication_GetBuildProgramVersion()
        {
            //실행파일의 어셈블리 버전
            string sDeploymentVersion;//= "";
            sDeploymentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            //ClsConst.gsNowProgramVersion = sDeploymentVersion;

            return sDeploymentVersion;

            //return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }


        /// <summary> 
        /// Assembly.GetExecutingAssembly.FullName Text로부터 Build된 일시를 구합니다.
        /// <para> 2021-01-08 add : 신효철 </para>
        /// </summary> 
        /// <returns></returns> 
        public DateTime DoApplication_GetBuildDateTime()
        {
            //1. Assembly.GetExecutingAssembly().FullName의 값은  
            //'ApplicationName, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' 
            //와 같다.  
            string strBuildText = Assembly.GetExecutingAssembly().FullName
                    .Split(',')[1]
                    .Trim()
                    .Split('=')[1];
            //2. Version Text의 세번째 값(Build Number)은 2000년 1월 1일부터  2019-04-09까지는 7038(2019년=103)임
            //Build된 날짜까지의 총 일(Days) 수 이다. 
            int intDays = Convert.ToInt32(strBuildText.Split('.')[2]);

            DateTime refDate;
            DateTime dtBuildDate;

            if (intDays == 0)
            {   //2018-12-24 IF절 추가하여 분기처리
                //      [assembly: AssemblyVersion("2019.4.0.*")] 이렇게 된 경우 3번째가 0값이 나오게 됨★★★

                //2019-04-09 EDIT : 시간은 제외해야하며. 아래 3번에서 컴파일 시간을 더해준다.
                ////refDate = System.DateTime.Now;   //new DateTime(System.DateTime.Now.Year(), System.DateTime.Now.Month(), System.DateTime.Now.Day());

                string sYY = DateTime.Now.ToString("yyyy");
                string sMM = DateTime.Now.ToString("MM");
                string sDD = DateTime.Now.ToString("dd");
                int iYear = Int32.Parse(sYY);
                int iMonth = Int32.Parse(sMM);
                int iDay = Int32.Parse(sDD);
                refDate = new DateTime(iYear, iMonth, iDay);



                dtBuildDate = refDate;//.AddDays(intDays);
            }
            else
            {
                refDate = new DateTime(2000, 1, 1);
                dtBuildDate = refDate.AddDays(intDays);//2000-01-01일에 경과일수 값을 더해서 컴파일+배포일을 만든다.
            }

            //3. Verion Text의 네번째 값(Revision NUmber)은 자정으로부터 Build된 
            //시간까지의 지나간 초(Second) 값 이다. 
            int intSeconds = Convert.ToInt32(strBuildText.Split('.')[3]);

            // IDE0054	복합형 할당 사용 - 2020-09-19 edit
            intSeconds *= 2;    //시간(자정부터 Sec/2 Sec)값은  초의 반값임으로 *2 해줘야함

            dtBuildDate = dtBuildDate.AddSeconds(intSeconds);


            //4. 시차조정 
            DaylightTime daylingTime = TimeZone.CurrentTimeZone
                    .GetDaylightChanges(dtBuildDate.Year);

            if (TimeZone.IsDaylightSavingTime(dtBuildDate, daylingTime))
                dtBuildDate = dtBuildDate.Add(daylingTime.Delta);


            return dtBuildDate;
        }


        /// <summary>
        /// IExplore.exe를 실행하여 지정한 URL OPEN/보여주기( Tab or NewWindows 모드)
        /// <para> * 2021-01-09 add : 신효철 </para>
        /// </summary>
        /// <param name="openUrl">오픈할 SiteUrl 데이터</param>
        /// <param name="NewWindowsMode"> 오픈시 매번 새로운 별도창으로 할지여부(false = Tab 추가형태) 
        /// <para> * Explorer6 이하 버전에서는 정상적으로 새창이 뜨면서 실행이 되는데 </para>
        /// <para> * Explorer7 이상에서는 새창이 열리는 설정이 새탭에서 실행되게끔 되어있어 새로운 탭으로 실행이 됩니다.</para>
        /// <para> * 그래서 아래와 같은 방법으로 Explorer7 이상의 버전에서도 새창이 뜨면서 실행되도록 하실 수 있습니다.</para>
        /// </param>
        /// <returns>정상처리 true, 오류 false</returns>
        public bool DoIExplore_SiteShow(string openUrl, bool NewWindowsMode)
        {
            // 요약:
            //     이 System.Diagnostics.Process 구성 요소의 System.Diagnostics.Process.StartInfo
            //     속성으로 지정된 프로세스 리소스를 시작하거나 다시 사용하여 구성 요소에 연결합니다.
            //
            // 반환 값:
            //     프로세스 리소스가 시작된 경우에는 true이고 기존 프로세스를 다시 사용한 경우처럼 새 프로세스 리소스가 시작되지 않은 경우에는 false입니다.
            //

            bool bSiteOpen = false;

            try
            {
                //Cursor.Current = Cursors.WaitCursor;

                if (!NewWindowsMode)
                {   //1브라우져로 Tab이 추가되는 형태임
                    System.Diagnostics.Process.Start("iexplore.exe", openUrl);
                }
                else
                {
                    //https://dotnetmvp.tistory.com/m/69
                    //그런데 Explorer6이하 버전에서는 정상적으로 새창이 뜨면서 실행이 되는데 
                    //  Explorer7 이상에서는 새창이 열리는 설정이 새탭에서 실행되게끔 되어있어 새로운 탭으로 실행이 됩니다.
                    //그래서 아래와 같은 방법으로 Explorer7 이상의 버전에서도 새창이 뜨면서 실행되도록 하실 수 있습니다.

                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    string prgFilesPath;
                    //prgFilesPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles);
                    prgFilesPath = GetSpecialFolder(Environment.SpecialFolder.ProgramFiles);

                    //process.StartInfo = new System.Diagnostics.ProcessStartInfo(
                    //                                  prgFilesPath + "\\Naver\\Naver Whale\\Application\\whale.exe"
                    //                                , openUrl);
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(
                                  prgFilesPath + "\\Internet Explorer\\iexplore.exe"
                                , openUrl);
                    process.Start();
                }
                bSiteOpen = true;   //성공
            }
            catch (Exception)// ex)
            {
                //Msgbox(ex.Message, ClsEnum.MsgboxType.ERROR);
            }
            finally
            {
                //Cursor.Current = Cursors.Default;
            }
            return bSiteOpen;
        }




        ///// <summary>
        ///// IExplore.exe를 실행하여 지정한 URL OPEN/보여주기 (DoFile_Execute )
        ///// <para> 2021-01-08 add : 신효철 </para>
        ///// </summary>
        ///// <param name="openUrl">오픈할 SiteUrl 데이터</param>
        ///// <returns>정상처리 true, 오류 false</returns>
        //public bool DoIExplore_SiteShow(string openUrl)
        //{

        //    // 요약:
        //    //     이 System.Diagnostics.Process 구성 요소의 System.Diagnostics.Process.StartInfo
        //    //     속성으로 지정된 프로세스 리소스를 시작하거나 다시 사용하여 구성 요소에 연결합니다.
        //    //
        //    // 반환 값:
        //    //     프로세스 리소스가 시작된 경우에는 true이고 기존 프로세스를 다시 사용한 경우처럼 새 프로세스 리소스가 시작되지 않은 경우에는 false입니다.
        //    //

        //    //2018-09-12 add
        //    bool bSiteOpen = false;

        //    try
        //    {
        //        //Cursor.Current = Cursors.WaitCursor;

        //        //2019-10-24 add/edit
        //        bSiteOpen = DoFile_Execute("IExplore.exe"
        //                                    , FileExecuteType.FileExecuteType_StartInfoAdd
        //                                    , openUrl
        //                                    , ProcessWindowStyle.Hidden
        //                                    , fileExistCheck: false);  //브라우저는 bFileExistCheck 속성을 FALSE로하여 경로+파일체크를 안해야함
        //        //System.Diagnostics.Process UserProcess = new System.Diagnostics.Process();
        //        //// 요약:
        //        ////     이 System.Diagnostics.Process 구성 요소의 System.Diagnostics.Process.StartInfo
        //        ////     속성으로 지정된 프로세스 리소스를 시작하거나 다시 사용하여 구성 요소에 연결합니다.
        //        //UserProcess.StartInfo.UseShellExecute = true;
        //        //UserProcess.StartInfo.FileName = "IExplore.exe";
        //        //UserProcess.StartInfo.CreateNoWindow = true;
        //        //UserProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        //        //UserProcess.StartInfo.Arguments = vOpenUrl; //"www.haesol.net"; //argument가 필요없으면 삭제하세요.
        //        //// 반환 값:
        //        ////     프로세스 리소스가 시작된 경우에는 true이고 기존 프로세스를 다시 사용한 경우처럼 새 프로세스 리소스가 시작되지 않은 경우에는 false입니다.
        //        //bSiteOpen = UserProcess.Start();  //성공 or 실패
        //        ////Process.Start() - 윈도우-시작-실행 창에서 여는 명령어


        //        //**bSiteOpen = true;   //성공
        //    }
        //    catch (Exception)// ex)
        //    {
        //        //Msgbox(ex.Message, ClsEnum.MsgboxType.ERROR);
        //    }
        //    finally
        //    {
        //        //Cursor.Current = Cursors.Default;
        //    }
        //    return bSiteOpen;

        //}



        ///// <summary>
        ///// 디렉토리에 파일을 바로 실행하기(or 파일 미리보기) 
        /////     <para> 2021-01-08 add : 신효철 </para>
        /////     <para>&#160;</para>
        /////     <para> - 특정 뷰어가 있다면 바로 해당 뷰어를 실행해서 보여줌 </para>
        /////     <para> - pdf파일이라면 아크로벳리터를 실행해줌(Ex. System.Diagnostics.Process.Start("powerpnt") ) </para>
        ///// </summary>
        ///// <param name="dirPathFileName"> 확인할 폴더 경로+파일명(Ex. C:\\xxx\\AddFiles\mes.ico) </param>
        ///// <param name="fileExecuteType"> 파일실행 방법- 종류(기본. Process.Start()으로 즉시 실행, System.Diagnostics.Process.StartInfo 사용시 세부속성 설정가능) </param>
        ///// <param name="args"> 응용 프로그램을 시작時 사용할 명령줄 인수 집합을 설정합니다.(기본값은 빈 문자열="" ) </param>
        ///// <param name="windowStyle"> 시스템에서 프로세스가 시작될때 새창이 나타나는 방법을 지정 </param>
        ///// <param name="fileExistCheck"> IExplore.Exe 등 실행시 파일 존재여부 체크는 안하게 한다. </param>
        ///// <returns>정상존재/실행 true, 오류 false</returns>        
        //public bool DoFile_Execute(string dirPathFileName, FileExecuteType fileExecuteType = FileExecuteType.FileExecuteType_Start
        //                          , string args = ""
        //                          , System.Diagnostics.ProcessWindowStyle windowStyle = System.Diagnostics.ProcessWindowStyle.Normal
        //                          , bool fileExistCheck = true)
        //{
        //    bool bFileExecute = false;//파일 실행전 + 파일없음
        //    try
        //    {
        //        if (string.IsNullOrEmpty(dirPathFileName))
        //        {
        //            return bFileExecute;    //2020-03-06 add
        //        }

        //        //Cursor.Current = Cursors.WaitCursor;// AppStarting

        //        if (fileExistCheck == true)
        //        {
        //            bFileExecute = System.IO.File.Exists(dirPathFileName);// DoFile_Exists(dirPathFileName, false);
        //        }
        //        else
        //        {
        //            //2019-10-24 add: 브라우저 같은것 실행시.. 파일체크는 안하게 한다.
        //            bFileExecute = true;
        //        }

        //        if (true == bFileExecute)
        //        {
        //            ////Exists => PASS
        //            //bFileExecute = true; //실행가능 + 존재함

        //            //if (fileExecuteType == FileExecuteType.FileExecuteType_Start)
        //            //{
        //            //    //프로그램(엑셀...) 바로 실행                        
        //            //    // 반환 값:
        //            //    //     프로세스 리소스가 시작된 경우에는 true이고 기존 프로세스를 다시 사용한 경우처럼 새 프로세스 리소스가 시작되지 않은 경우에는 false입니다.
        //            //    System.Diagnostics.Process.Start(dirPathFileName);    //윈도우-시작-실행 창에서 여는 명령어

        //            //    ////특정 뷰어가 있다면 바로 해당 뷰어를 실행해서 보여줌
        //            //    ////  pdf파일이라면 아크로벳리터를 실행해줌
        //            //    //process.Start();
        //            //    ////예시.  --System.Diagnostics.Process.Start("powerpnt"); 

        //            //    //오류	59	암시적으로 'System.Diagnostics.Process' 형식을 'bool' 형식으로 변환할 수 없습니다.
        //            //    //bFileExecute = System.Diagnostics.Process.Start(sDirPathFileName); 
        //            //    //  - System.Diagnostics.Process.Start(ClsConst.gsfdDialog.FileName); 
        //            //}
        //            //else if (fileExecuteType == FileExecuteType.FileExecuteType_ShellExecute)
        //            //{
        //            //    //2020-03-22 add : https://kdsoft-zeros.tistory.com/105?category=846221
        //            //    //                              IntPtr hwnd, string lpOperation, 
        //            //    //                                              string lpFile, string lpParameters, string lpDirectory, int nShowCmd
        //            //    //WINAPI.SafeNativeMethods.ShellExecute(&0, "open", dirPathFileName, "", "", WINAPI.SW_SHOWNOACTIVATE);
        //            //    ////WINAPI.SafeNativeMethods.ShellExecute(this.Handle, "open", "calc.exe", "", "", 4); 


        //            //    //프로그램 내에서 다른 프로그램을 관리자 권한으로 실행하기       https://bspfp.pe.kr/archives/594
        //            //    //WINAPI.SafeNativeMethods.ShellExecute(IntPtr.Zero, "open", dirPathFileName, "", "", WINAPI.SW_SHOWNOACTIVATE);
        //            //    WINAPI.SafeNativeMethods.ShellExecute(IntPtr.Zero, "runas", dirPathFileName, "", "", WINAPI.SW_SHOWNOACTIVATE);

        //            //}
        //            //else
        //            //{
        //                //2019-10-08 add : 현재는 위 기능과 동일하나  
        //                //                  ★★★추후 세부적인 속성들을 조사하여  수정 및 설정하여 사용하기를 권장함★★
        //                //C#5.0 - IDE0017	개체 초기화를 간단하게 만들 수 있습니다.
        //                //변경후
        //                System.Diagnostics.Process UserProcess = new System.Diagnostics.Process
        //                {
        //                    //     프로세스가 종료될 때 System.Diagnostics.Process.Exited 이벤트를 발생시켜야 하는지 여부를 나타내는 값을
        //                    //     가져오거나 설정합니다.
        //                    //     [DefaultValue(false)]
        //                    EnableRaisingEvents = false
        //                };


        //                // 요약:
        //                //     이 System.Diagnostics.Process 구성 요소의 System.Diagnostics.Process.StartInfo
        //                //     속성으로 지정된 프로세스 리소스를 시작하거나 다시 사용하여 구성 요소에 연결합니다.

        //                //     프로세스를 시작할 때 운영 체제 셸을 사용할지 여부를 나타내는 값을 가져오거나 설정합니다.
        //                //      [DefaultValue(true)]
        //                UserProcess.StartInfo.UseShellExecute = true;
        //                //     시작할 응용 프로그램 또는 문서를 가져오거나 설정합니다.
        //                //      System.Diagnostics.Process.Start(sDirPathFileName)   형식으로 실행하는 것과 동일
        //                UserProcess.StartInfo.FileName = dirPathFileName;
        //                //     프로세스를 새 창에서 시작할지 여부를 나타내는 값을 가져오거나 설정합니다.
        //                //      [DefaultValue(false)]
        //                UserProcess.StartInfo.CreateNoWindow = true;
        //                //     프로세스가 시작될 때 사용할 창 상태를 가져오거나 설정합니다.
        //                //      기본값은 normal입니다.
        //                //UserProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        //                UserProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
        //                //     응용 프로그램을 시작할 때 사용할 명령줄 인수 집합을 가져오거나 설정합니다.
        //                //
        //                // 반환 값:
        //                //     System.Diagnostics.ProcessStartInfo.FileName 속성에 지정된 응용 프로그램에 연결될 수 있는 파일
        //                //     형식별 인수입니다.기본값은 빈 문자열("")입니다.프로세스의 전체 경로 길이에 추가되는 인수의 길이는 2080자보다 짧아야 합니다.
        //                //     [DefaultValue("")]
        //                UserProcess.StartInfo.Arguments = args; //argument가 필요없으면 삭제하세요.


        //                //https://social.msdn.microsoft.com/Forums/ko-KR/5acd5638-a31c-4f15-bcd2-228ddb8482be/tipnet-?forum=visualbasicko
        //                //'Verb를 runas로 (관리자 권한으로 실행 명령) - 2020-03-22 add
        //                UserProcess.StartInfo.Verb = "runas";


        //                // 반환 값:
        //                //     프로세스 리소스가 시작된 경우에는 true이고 기존 프로세스를 다시 사용한 경우처럼 새 프로세스 리소스가 시작되지 않은 경우에는 false입니다.
        //                UserProcess.Start();

        //                UserProcess = null;
        //            //}

        //        }
        //        else
        //        {
        //            bFileExecute = false; //실행불가 + 존재 안함                    
        //        }

        //    }
        //    catch (System.IO.FileNotFoundException ex)
        //    {
        //        //Msgbox(ex.Message, ClsEnum.MsgboxType.ERROR);
        //    }
        //    catch (Exception ex)
        //    {
        //        //Msgbox(ex.Message, ClsEnum.MsgboxType.ERROR);
        //    }
        //    finally
        //    {
        //        if (bFileExecute == false)
        //        {
        //            ////존재 안함      
        //            ////  Console.WriteLine("File does not exist in the D:\ㅁㅁㅁ directory!");

        //            //Msgbox(ClsConst.gcsCrlf + ClsConst.gcsCrlf +
        //            //     dirPathFileName.Replace("/", "\\").Trim()
        //            //     + csCrlf + "파일을 찾을 수 없어서 실행에 실패 했습니다.", ClsEnum.MsgboxType.ERROR);
        //        }
        //        //Cursor.Current = Cursors.Default;
        //    }
        //    return bFileExecute;
        //}



        /// <summary>
        /// 시스템 특수 폴더에 대한 디렉터리 경로 반환
        /// <para> * 2019-10-16 add : 신효철 </para>
        /// </summary>
        /// <param name="specialFolderType">바탕화면,내문서,등등...특수폴더 선택</param>
        /// <returns>문자열 String값 반환</returns>
        public string GetSpecialFolder(System.Environment.SpecialFolder specialFolderType)
        {

            //시작 폴더
            //System.Environment.GetFolderPath(System.Environment.SpecialFolder.StartMenu) + @"\Programs";

            //      데스크톱에서 실제로 파일 개체를 저장하는 데 사용되는 디렉터리입니다.
            //System.Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);      //바탕화면 Folder 경로
            //      실제 파일 시스템 위치가 아니라 논리 데스크톱입니다.
            //System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);       

            //System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles)

            string sPath = System.Environment.GetFolderPath(specialFolderType);

            return sPath.Trim();
        }




        #region ConvertImageToByteArray
        /// <summary>
        /// ConvertImageToByteArray
        /// <para> 2021-01-15 add : 신효철, 자주/수입 검사항목 품목별 스펙관리에서 가져옴 </para>
        /// </summary>
        /// <param name="theImage"></param>
        /// <returns></returns>
        public byte[] ConvertImageToByteArray(Image theImage)
        {
            MemoryStream ms = new MemoryStream();
            byte[] pByte;

            theImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            pByte = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(pByte, 0, (int)ms.Length);
            ms.Close();
            return pByte;
        }
        #endregion

        #region BYTE[]를 이미지로 변환

        /// <summary>
        /// ConvertByteArrayToImage
        /// <para> 2021-01-15 add : 신효철, 자주/수입 검사항목 품목별 스펙관리에서 가져옴 </para>
        /// </summary>
        /// <param name="pByte"></param>
        /// <returns></returns>
        public Image ConvertByteArrayToImage(byte[] pByte)
        {
            MemoryStream ms = new MemoryStream();

            Image theImage = null;

            try
            {
                ms.Position = 0;

                ms.Write(pByte, 0, (int)pByte.Length);

                theImage = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return theImage;
        }

        #endregion



        /// <summary>
        /// TabTip - 키보드 닫기
        ///     <para>&#160;</para>
        ///	    <para> *Windows 8 에서 텍스트 박스 포커스시 키패드 호출</para>
        /// </summary>
        /// <param name="processesByName">프로세스 비교 대상 : 프로젝트-속성-응용프로그램{어셈블리 이름} 과 비교함
        ///	    <para> *Windows10 한글 화상 키보드 프로그램(OSK)</para>
        ///	    <para> *Windows 8 영문      키패드 프로그램(TabTip)</para>
        /// </param>
        public void DoKeyBoardClose_TabTip(string processesByName)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;// AppStarting

                DoApplication_Kill(processesByName);
                //DoApplication_Kill("TabTip");
                //DoApplication_Kill("OSK");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Msgbox(ex.Message, ClsEnum.MsgboxType.ERROR);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        /// <summary>
        /// TabTip- 키보드 표시
        ///     <para>&#160;</para>
        ///	    <para> *Windows 8 에서 텍스트 박스 포커스시 키패드 호출</para>
        /// </summary>
        public void DoKeyBoardOpen_TabTip()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;// AppStarting

                //if (!string.IsNullOrEmpty(ClsConst.gsKeyboardPath)) //if (ClsConst.gsKeyboardPath != "")
                //{

                //System.Diagnostics.Process.Start(@"C:\WINDOWS\SYSTEM32\OSK.exe"); //경로+파일명
                System.Diagnostics.Process.Start(@"C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe"); //경로+파일명

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Msgbox(ex.Message, ClsEnum.MsgboxType.ERROR);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }



        /// <summary>
        /// 실행중인 프로세스 KILL - 2019-10-07 ADD 
        /// </summary>
        /// <param name="processesByName">프로세스 비교 대상 : 프로젝트-속성-응용프로그램{어셈블리 이름} 과 비교함</param>
        /// <param name="showMsg">질문 메시지 표시 여부</param>
        /// <returns>Kill 발생 true, 최초실행 false</returns>
        public bool DoApplication_Kill(string processesByName, bool showMsg = false)
        {
            bool bRtn = false;
            if (string.IsNullOrEmpty(processesByName)) //if (vProcessName.Trim() == "") 
            {
                return bRtn;
            }

            try
            {
                processesByName = processesByName.Trim();

                //vProcessName = 확장자 제외
                //지정한 프로세스 들 대상
                System.Diagnostics.Process[] processList;
                processList = System.Diagnostics.Process.GetProcessesByName(processesByName);

                if (processList.Length > 0)
                {
                    //----------------------------------------------------------------------//2019-12-13 질문 추가 : mainFileName + " 
                    if (showMsg == false)
                    {

                        if (MessageBox.Show("파일이 실행되고 있습니다.\n\r" +
                                   processesByName + "프로세스를 종료후 진행하시겠습니까?", processesByName, MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return bRtn;
                        }

                        //if (Msgbox("파일이 실행되고 있습니다." + ClsConst.gcsCrlf +
                        //           processesByName + "프로세스를 종료후 진행하시겠습니까?", processesByName,
                        //           ClsEnum.MsgboxType.QUESTION) == DialogResult.No)
                        //{
                        //    return bRtn;
                        //}
                    }
                    //----------------------------------------------------------------------

                    //에러시 조치사항 - 2021-01-18 ADD
                    //  에러내용 : "32비트 프로세스에서 64비트 프로세스의 모듈에 액세스할 수 없습니다."
                    //  조치방법 : NEXMES - 빌드 - 플랫폼대상 X86 -> Any CPU로 변경필요

                    foreach (System.Diagnostics.Process theprocess in processList)
                    {
                        Console.WriteLine("Process: {0} ID: {1} m: {2}", theprocess.ProcessName, theprocess.Id, theprocess.MainModule.ModuleName);
                        theprocess.Kill();

                        bRtn = true;
                    }
                }
                return bRtn;

            }
            catch (Exception ex)
            {
                //Msgbox(ex.Message, ClsEnum.MsgboxType.ERROR);
                MessageBox.Show(ex.Message);
            }

            return bRtn;
        }




    }
}

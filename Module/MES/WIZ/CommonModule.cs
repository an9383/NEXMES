using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace WIZ
{
    public class CModule
    {
        #region 선언부
        public static int iSendBuffSize = 1024;
        public enum DisplayType { ALL, LOG, SEARCH, ERR, TRANSFER, CATCH, RECATCH, COMPLETE, RECEIVE }

        #region 멤버변수
        public static string sLogFolderName = "";
        public static string sIniFileName = "Config.cfg";
        public static string sConnectionString = "CONNECTIONSTRING";
        public static string sDefualtConnectString = "gl5RnCm96RxdLYHJ0UGXgLy81zYPYHJAJX/6F/bkyhVKU3z6QqpOdhVexNEdxlI/jp6GjdUGss6+2XMECc0ItgFUAC807w5+UaSjQ+5F9FWYb1UBLEBTQhfLACAvYO+ZE4brSbZd7yyNwpbV2h2wPg3CNkbCKnHPr/LAlcZsoxQ5FmwHTgdqfmgDftevxGXjJWBWSh3yAOOKI7W8JVekIIK3U1fZH7cD9tE1gJ5Gg6E=";
        public static string sProvider = "PROVIDER";
        public static string sDefualtProvider = "System.Data.SqlClient";
        public static string sLocalIP = "";
        public static IniFileData iniFile;

        #region DB 정보
        public static class DBInfo
        {
            public static string IP;
            public static string Port;
            public static string DBName;
            public static string User;
            public static string Pass;
        }

        public static class TCPInfo
        {
            public static string IP;
            public static int Port;
        }
        #endregion

        #endregion
        #endregion

        #region 문자상수 선언
        public struct _gCharList
        {
            public const char NULL = '\x00';  //Dec=00
            public const char SOH = '\x01';  //Dec=01
            public const char STX = '\x02';  //Dec=02
            public const char ETX = '\x03';  //Dec=03
            public const char EOT = '\x04';  //Dec=04
            public const char ENQ = '\x05';  //Dec=05
            public const char ACK = '\x06';  //Dec=06
            public const char BEL = '\x07';  //Dec=07
            public const char BACK = '\x08';  //Dec=08
            public const char TAB = '\x09';  //Dec=09
            public const char LF = '\x0A';  //Dec=10
            public const char VT = '\x0B';  //Dec=11
            public const char FF = '\x0C';  //Dec=12
            public const char CR = '\x0D';  //Dec=13
            public const char SO = '\x0E';  //Dec=14
            public const char SI = '\x0F';  //Dec=15
            public const char DLE = '\x10';  //Dec=16
            public const char DC1 = '\x11';  //Dec=17
            public const char DC2 = '\x12';  //Dec=18
            public const char DC3 = '\x13';  //Dec=19
            public const char DC4 = '\x14';  //Dec=20
            public const char NAK = '\x15';  //Dec=21
            public const char SYN = '\x16';  //Dec=22
            public const char ETB = '\x17';  //Dec=23
            public const char CAN = '\x18';  //Dec=24
            public const char EM = '\x19';  //Dec=25
            public const char SUB = '\x1A';  //Dec=26
            public const char ESC = '\x1B';  //Dec=27
            public const char FS = '\x1C';  //Dec=28
            public const char GS = '\x1D';  //Dec=29
            public const char RS = '\x1E';  //Dec=30
            public const char US = '\x1F';  //Dec=31

            public const char SPACE = '\x20';  //Dec=32( )
            public const char EXCLAMATION_MARK = '\x21';  //Dec=33(!)
            public const char DBL_QUOTATION = '\x22';  //Dec=34(")
            public const char SHARP = '\x23';  //Dec=35(#)
            public const char DOLLAR = '\x24';  //Dec=36($)
            public const char PERCENT = '\x25';  //Dec=37(%)
            public const char EM_PERCENT = '\x26';  //Dec=38(&)
            public const char SINGLE_QUOTATION = '\x27';  //Dec=39(')
            public const char LBRACKET_SMALL = '\x28';  //Dec=40(()
            public const char RBRACKET_SMALL = '\x29';  //Dec=41())
            public const char MULTIPLY = '\x2A';  //Dec=42(*)
            public const char PLUS = '\x2B';  //Dec=43(+)
            public const char COMMA = '\x2C';  //Dec=44(,)
            public const char MINUS = '\x2D';  //Dec=45(-)
            public const char DOT = '\x2E';  //Dec=46(.)
            public const char SLASH = '\x2F';  //Dec=47(/)
            public const char ZERO = '\x30';  //Dec=48(0)
            public const char ONE = '\x31';  //Dec=49(1)
            public const char TWO = '\x32';  //Dec=50(2)
            public const char THREE = '\x33';  //Dec=51(3)
            public const char FOUR = '\x34';  //Dec=52(4)
            public const char FIVE = '\x35';  //Dec=53(5)
            public const char SIX = '\x36';  //Dec=54(6)
            public const char SEVEN = '\x37';  //Dec=55(7)
            public const char EIGHT = '\x38';  //Dec=56(8)
            public const char NINE = '\x39';  //Dec=57(9)
            public const char SEMICOLON = '\x3A';  //Dec=58(:)
            public const char COLON = '\x3B';  //Dec=59(;)
            public const char LSHIFT = '\x3C';  //Dec=60(<)
            public const char EQUAL = '\x3D';  //Dec=61(=)
            public const char RSHIFT = '\x3E';  //Dec=62(>)
            public const char QUESTION_MARK = '\x3F';  //Dec=63(?)
            public const char ATMARK = '\x40';  //Dec=64(@)
            public const char ALPHA_A = '\x41';  //Dec=65(A)
            public const char ALPHA_B = '\x42';  //Dec=66(B)
            public const char ALPHA_C = '\x43';  //Dec=67(C)
            public const char ALPHA_D = '\x44';  //Dec=68(D)
            public const char ALPHA_E = '\x45';  //Dec=69(E)
            public const char ALPHA_F = '\x46';  //Dec=70(F)
            public const char ALPHA_G = '\x47';  //Dec=71(G)
            public const char ALPHA_H = '\x48';  //Dec=72(H)
            public const char ALPHA_I = '\x49';  //Dec=73(I)
            public const char ALPHA_J = '\x4A';  //Dec=74(J)
            public const char ALPHA_K = '\x4B';  //Dec=75(K)
            public const char ALPHA_L = '\x4C';  //Dec=76(L)
            public const char ALPHA_M = '\x4D';  //Dec=77(M)
            public const char ALPHA_N = '\x4E';  //Dec=78(N)
            public const char ALPHA_O = '\x4F';  //Dec=79(O)
            public const char ALPHA_P = '\x50';  //Dec=80(P)
            public const char ALPHA_Q = '\x51';  //Dec=81(Q)
            public const char ALPHA_R = '\x52';  //Dec=82(R)
            public const char ALPHA_S = '\x53';  //Dec=83(S)
            public const char ALPHA_T = '\x54';  //Dec=84(T)
            public const char ALPHA_U = '\x55';  //Dec=85(U)
            public const char ALPHA_V = '\x56';  //Dec=86(V)
            public const char ALPHA_W = '\x57';  //Dec=87(W)
            public const char ALPHA_X = '\x58';  //Dec=88(X)
            public const char ALPHA_Y = '\x59';  //Dec=89(Y)
            public const char ALPHA_Z = '\x5A';  //Dec=90(Z)
            public const char LBRACKET_LARGE = '\x5B';  //Dec=91([)
            public const char WONUNIT = '\x5C';  //Dec=92(\)
            public const char RBRACKET_LARGE = '\x5D';  //Dec=93(])
            public const char CARET = '\x5E';  //Dec=94(^)
            public const char alpha_a = '\x61';  //Dec=97(a)
            public const char alpha_b = '\x62';  //Dec=98(b)
            public const char alpha_c = '\x63';  //Dec=99(c)
            public const char alpha_d = '\x64';  //Dec=100(d)
            public const char alpha_e = '\x65';  //Dec=101(e)
            public const char alpha_f = '\x66';  //Dec=102(f)
            public const char alpha_g = '\x67';  //Dec=103(g)
            public const char alpha_h = '\x68';  //Dec=104(h)
            public const char alpha_i = '\x69';  //Dec=105(i)
            public const char alpha_j = '\x6A';  //Dec=106(j)
            public const char alpha_k = '\x6B';  //Dec=107(l)
            public const char alpha_l = '\x6C';  //Dec=108(l)
            public const char alpha_m = '\x6D';  //Dec=109(m)
            public const char alpha_n = '\x6E';  //Dec=110(n)
            public const char alpha_o = '\x6F';  //Dec=111(o)
            public const char alpha_p = '\x70';  //Dec=112(p)
            public const char alpha_q = '\x71';  //Dec=113(q)
            public const char alpha_r = '\x72';  //Dec=114(r)
            public const char alpha_s = '\x73';  //Dec=115(s)
            public const char alpha_t = '\x74';  //Dec=116(t)
            public const char alpha_u = '\x75';  //Dec=117(u)
            public const char alpha_v = '\x76';  //Dec=118(v)
            public const char alpha_w = '\x77';  //Dec=119(w)
            public const char alpha_x = '\x78';  //Dec=120(x)
            public const char alpha_y = '\x79';  //Dec=121(y)
            public const char alpha_z = '\x7A';  //Dec=122(z)
            public const char LBRACKET2_LARGE = '\x7B';  //Dec=123({)
            public const char DELIMETER = '\x7C';  //Dec=124(|)
            public const char RBRACKET2_LARGE = '\x7D';  //Dec=125(})
            public const char SWUNG_DASH = '\x7E';  //Dec=126(~)
        }

        #endregion

        #region 메소드 일람

        #region Config 파일 처리
        public static void LoadEnvironment()
        {
            iniFile = new IniFileData();
            iniFile.ReadFile(CModule.sIniFileName);
        }

        public static void SaveEnvironment()
        {
            iniFile.WriteFile(CModule.sIniFileName);
        }

        /// <summary>
        /// 설정값 반환
        /// </summary>
        /// <param name="sTitle"></param>
        /// <param name="sDefualt"></param>
        /// <returns></returns>
        public static string GetAppSetting(string sTitle, string sDefualt = "")
        {
            if (null == iniFile["CONFIG", sTitle])
            {
                iniFile["CONFIG", sTitle] = sDefualt;
                SaveEnvironment();
                return sDefualt;
            }

            return iniFile["CONFIG", sTitle];
        }

        /// <summary>
        /// 설정값 저장
        /// </summary>
        /// <param name="sTitle"></param>
        /// <param name="sValue"></param>
        public static void SetAppSetting(string sTitle, string sValue)
        {
            iniFile["CONFIG", sTitle] = sValue;

            SaveEnvironment();
        }

        public static List<IniValue> GetConfigGroupList(string sGroup)
        {
            return iniFile.GetList(sGroup);
        }
        #endregion


        #region 로그 저장
        /// <summary>
        /// 로그를 파일에 저장한다.
        /// </summary>
        /// <param name="pType"></param>
        /// <param name="sMes"></param>
        public static void LogSave(string sName, DisplayType pType, string sMes, string sTarget, string sDateTime = "")
        {
            // 로그 처리 폴더 
            //    D:\실행파일 폴더\Log\ALL\2017\2017-07\ALL-20170731_IP.log
            //    폴더               구분  년   년월    구분-년월일_대상.log
            string sStr = WIZ.CModule.ToString(sMes);

            if (sMes.Length == 0)
                return;

            if (sLogFolderName == "")
            {
                sLogFolderName = Environment.CurrentDirectory + "\\Log";
            }
            //{ ALL, LOG, SEARCH, ERR, TRANSFER, CATCH, RECATCH, COMPLETE, RECEIVE }
            string[] sLogGubnList = new string[] { "ALL", "LOG", "SEARCH", "ERR", "TRANSFER", "CATCH", "RECATCH", "COMPLETE", "RECEIVE" };

            string sGubn = sLogGubnList[(int)pType];

            if (sDateTime == "")
            {
                sDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }

            string sYYYY = sDateTime.Substring(0, 4);
            string sYYMM = sDateTime.Substring(0, 7);
            string sDate = sDateTime.Substring(0, 10);

            string sLogFolder = sLogFolderName + @"\" + sName + @"\" + sGubn + @"\" + sYYYY + @"\" + sYYMM + @"\";
            string sLogFile = sGubn + "-" + sDate.Replace("-", "") + "_" + sTarget + ".log";

            string sFullName = sLogFolder + sLogFile;

            if (!Directory.Exists(sLogFolder))
            {
                Directory.CreateDirectory(sLogFolder);
            }

            FileStream fs = new FileStream(sFullName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(sGubn + " [" + sDateTime + "] " + sMes);

            sw.Close();
            fs.Close();
        }
        #endregion

        #region 데이터 변환
        /// <summary>
        /// 숫자인지 확인한다.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool isNumeric(object value)
        {
            if (value == null) return false;

            if (value == DBNull.Value) return false;

            double dResult;

            if (double.TryParse(value.ToString(), out dResult))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// int32 로 변환한다
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt32(object value)
        {
            if (value == null) return 0;

            if (value == DBNull.Value) return 0;

            if (isNumeric(value))
            {
                return Convert.ToInt32(value);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// int64 로 변환한다
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToInt64(object value)
        {
            if (value == null) return 0;

            if (value == DBNull.Value) return 0;

            if (isNumeric(value))
            {
                return Convert.ToInt64(value);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// double 형으로 변환한다.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ToDouble(object value)
        {
            if (value == null) return 0;

            if (value == DBNull.Value) return 0;

            if (isNumeric(value))
            {
                return Convert.ToDouble(value);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// float 형으로 변환한다.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float ToFloat(object value)
        {
            if (value == null) return 0;

            if (value == DBNull.Value) return 0;

            if (isNumeric(value))
            {
                return (float)Convert.ToDouble(value);
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 문자열로 변환한다.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToString(object value)
        {
            try
            {
                if (value == null) return "";

                if (value == DBNull.Value) return "";

                return value.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static bool ToBool(object value)
        {
            if (value == null) return false;

            if (value == DBNull.Value) return false;

            return Convert.ToBoolean(value);
        }

        public static string ToDateTimeString(object value)
        {
            if (value == null) return "";

            if (value == DBNull.Value) return "";

            DateTime vDate = DateTime.Now;

            if (DateTime.TryParse(value.ToString(), out vDate))
            {
                return vDate.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                string sdt = value.ToString();

                if (sdt.Length == 19)
                {
                    if (sdt.Replace("-", "").Length == 14)
                    {
                        // 유진 하이텍 시간 양식
                        vDate = new DateTime(
                              ToInt32(sdt.Substring(0, 4))
                            , ToInt32(sdt.Substring(5, 2))
                            , ToInt32(sdt.Substring(8, 2))
                            , ToInt32(sdt.Substring(11, 2))
                            , ToInt32(sdt.Substring(14, 2))
                            , ToInt32(sdt.Substring(17, 2)));
                    }

                    return vDate.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    foreach (CultureInfo c in CultureInfo.GetCultures(CultureTypes.FrameworkCultures))
                    {
                        try
                        {
                            if (DateTime.TryParse(value.ToString(), c, DateTimeStyles.None, out vDate))
                            {
                                return vDate.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }

                return "";
            }
        }

        public static string ToDateString(object value)
        {
            if (value == null) return "";

            if (value == DBNull.Value) return "";

            DateTime vDate = DateTime.Now;

            if (DateTime.TryParse(value.ToString(), out vDate))
            {
                return vDate.ToString("yyyy-MM-dd");
            }
            else
            {
                foreach (CultureInfo c in CultureInfo.GetCultures(CultureTypes.FrameworkCultures))
                {
                    try
                    {
                        if (DateTime.TryParse(value.ToString(), c, DateTimeStyles.None, out vDate))
                        {
                            return vDate.ToString("yyyy-MM-dd");
                        }
                    }
                    catch (Exception)
                    {

                    }
                }

                return "";
            }
        }

        public static string ToTimeString(object value)
        {
            if (value == null) return "";

            if (value == DBNull.Value) return "";

            DateTime vDate = DateTime.Now;

            if (DateTime.TryParse(value.ToString(), out vDate))
            {
                return vDate.ToString("HH:mm:ss");
            }
            else
            {
                foreach (CultureInfo c in CultureInfo.GetCultures(CultureTypes.FrameworkCultures))
                {
                    try
                    {
                        if (DateTime.TryParse(value.ToString(), c, DateTimeStyles.None, out vDate))
                        {
                            return vDate.ToString("HH:mm:ss");
                        }
                    }
                    catch (Exception)
                    {
                    }
                }

                return "";
            }
        }
        #endregion

        #region 문자열 처리 메소드
        #region 중복 문자열 정리용 메소드
        public static string DupSpaceRemover(string str, char cDupSpace)
        {
            int idx = str.IndexOf(cDupSpace);

            bool bDup = false;

            char pc = '\0';

            while (true)
            {
                bDup = false;

                foreach (char c in str)
                {
                    if (cDupSpace == c)
                    {
                        if (pc == c)
                        {
                            bDup = true;
                            break;
                        }

                        pc = c;
                    }
                    else
                    {
                        pc = '\0';
                    }
                }

                if (bDup)
                {
                    str = str.Replace(cDupSpace.ToString() + cDupSpace.ToString(), cDupSpace.ToString());
                }
                else
                {
                    break;
                }
            }

            return str;
        }
        #endregion

        #region 문자열 분할 메소드
        public static string[] SplitCSV(string s, char cDeli, char cStart = '\"', char cEnd = '\"')
        {
            List<string> sList = new List<string>();

            string sc = "";

            bool bStart = false;
            bool bDeli = true;

            for (int i = 0; i < s.Length; i++)
            {
                if (bStart)
                {
                    if (s[i] == cEnd)
                    {
                        sList.Add(sc);

                        sc = "";

                        bStart = false;

                        bDeli = false;

                        continue;
                    }
                }
                else
                {
                    if (s[i] == cStart)
                    {
                        bStart = true;

                        bDeli = false;

                        continue;
                    }

                    if (s[i] == cDeli)
                    {
                        if (bDeli)
                        {
                            sList.Add(sc);
                        }

                        bDeli = true;

                        sc = "";

                        continue;
                    }
                }

                if (s[i] == cEnd)
                {
                    bStart = false;

                    continue;
                }

                sc += s[i];
            }

            if (sc.Trim() != "")
                sList.Add(sc.Trim());

            return sList.ToArray();
        }
        #endregion

        /// <summary>
        /// 왼쪽에서 iCount 만큼 문자열을 반환
        /// </summary>
        /// <param name="s"></param>
        /// <param name="iCount"></param>
        /// <returns></returns>
        public static string Left(string s, int iCount)
        {
            return s.Substring(0, iCount);
        }

        /// <summary>
        /// 오른쪽에서 iCount 만큼 문자열 반환
        /// </summary>
        /// <param name="s"></param>
        /// <param name="iCount"></param>
        /// <returns></returns>
        public static string Right(string s, int iCount)
        {
            return Right(s, iCount, iCount);
        }

        /// <summary>
        /// 우측 iStart 지전부터 iCount 만큼 반환
        /// </summary>
        /// <param name="s"></param>
        /// <param name="iStart"></param>
        /// <param name="iCount"></param>
        /// <returns></returns>
        public static string Right(string s, int iStart, int iCount)
        {
            return s.Substring(s.Length - iStart, iCount);
        }

        #region _StringCompare() 두 문자열의 값을 비교
        /// <summary>
        /// [함수] 문자열의 값을 비교
        /// </summary>
        /// <param name="pValue1">비교값1</param>
        /// <param name="pValue2">비교값2</param>
        /// <param name="pGubun">비교구분</param>
        /// <returns>True:비교성공</returns>
        public static bool _StringCompare(string pValue1, string pGubun, string pValue2)
        {
            bool bReturn = false;

            if (pValue1 != null && pGubun != null && pValue2 != null)
            {
                if (pGubun == "EQUAL" || pGubun == "EQ") pGubun = "=";
                if (pGubun == "GREATER" || pGubun == "GR") pGubun = ">";
                if (pGubun == "LESSER" || pGubun == "LE") pGubun = "<";

                if (pGubun == "=" && string.Compare(pValue1, pValue2) == 0)             // 같은것(A=B)
                    bReturn = true;
                else if (pGubun == ">" && string.Compare(pValue1, pValue2) > 0)         // 큰것(A>B)
                    bReturn = true;
                else if (pGubun == "<" && string.Compare(pValue1, pValue2) < 0)         // 작은것(A<B)
                    bReturn = true;
                else if (pGubun == ">=" && (string.Compare(pValue1, pValue2) > 0 ||    // 작거나 같은것(A>=B)
                                            string.Compare(pValue1, pValue2) == 0))
                    bReturn = true;
                else if (pGubun == "<=" && (string.Compare(pValue1, pValue2) < 0 ||    // 크거나 같은것(A<=B)
                                            string.Compare(pValue1, pValue2) == 0))
                    bReturn = true;
            }

            return bReturn;
        }
        #endregion

        #region _RedimString() string 배열 재정의
        /// <summary>
        /// [함수] string 배열 재정의
        /// </summary>
        /// <param name="pString"></param>
        public static void _RedimString(ref string[] pString)
        {
            string[] tmpString = new string[pString.Length + 1];
            System.Array.Copy(pString, tmpString, pString.Length);
            pString = tmpString;
        }
        #endregion

        #region _GetStringMid() 문자열의 n번째에서 x개의 문자열을 반환 [각 문자열=문자기준]
        /// <summary>
        /// [함수] 문자열에서 지정한 위치에서부터 길이만큼의 문자를 반환
        /// </summary>
        /// <param name="pValue">문자열</param>
        /// <param name="pStart">시작</param>
        /// <param name="pLength">길이</param>
        /// <param name="pTrim">Trim여부</param>
        /// <returns>n번째에서 x개의 문자열</returns>
        public static string _GetStringMid(string pValue, int pStart, int pLength, bool pTrim)
        {
            string sReturn = string.Empty;

            if (pValue != null && pValue != string.Empty)
            {
                int tLength = pValue.Length;

                if (tLength >= pStart)
                {
                    if (pStart <= 0) pStart = 1;
                    if (pStart == tLength) pLength = 1;

                    if (pLength <= 0) pLength = tLength;
                    if (tLength - pLength <= 0) pLength = tLength - pStart + 1;
                    if (pValue.Substring(pStart - 1).Length < pLength) pLength = pValue.Substring(pStart - 1).Length;

                    if (tLength >= pStart)
                    {
                        sReturn = pValue.Substring(pStart - 1, pLength);
                    }

                    if (pTrim == true)
                        sReturn = sReturn.Trim();
                }
            }

            return sReturn;
        }

        /// <summary>
        /// [함수] 문자열에서 지정한 위치에서부터 길이만큼의 문자를 반환 [문자앞뒤의 공백제거]
        /// </summary>
        /// <param name="pValue">문자열</param>
        /// <param name="pStart">시작</param>
        /// <param name="pLength">길이</param>
        /// <returns>n번째에서 x개의 문자열</returns>
        public static string _GetStringMid(string pValue, int pStart, int pLength)
        {
            return _GetStringMid(pValue, pStart, pLength, false);
        }

        /// <summary>
        /// [함수] 문자열에서 지정한 위치에서부터 문자를 반환 [길이=-1:시작위치 이후 문자, 문자앞뒤의 공백제거]
        /// </summary>
        /// <param name="pValue">문자열</param>
        /// <param name="pStart">시작</param>
        /// <returns>n번째부터의 문자열</returns>
        public static string _GetStringMid(string pValue, int pStart)
        {
            return _GetStringMid(pValue, pStart, -1, false);
        }
        #endregion

        #region _GetStringLeft() 문자열의 왼쪽에서부터 지정한 길이만큼의 문자를 반환 [각 문자열=문자기준]
        /// <summary>
        /// [함수] 문자열의 왼쪽에서부터 지정한 길이만큼의 문자를 반환
        /// </summary>
        /// <param name="pValue">문자열</param>
        /// <param name="pLength">길이</param>
        /// <param name="pTrim">Trim여부</param>
        /// <returns>왼쪽을 기준으로 n개의 문자</returns>
        public static string _GetStringLeft(string pValue, int pLength, bool pTrim)
        {
            string sReturn = string.Empty;

            if (pValue != null && pValue != string.Empty)
            {
                int tLength = pValue.Length;

                if (pLength < 0 || pLength > tLength) pLength = tLength;
                if (tLength >= pLength)
                {
                    sReturn = pValue.Substring(0, pLength);
                }

                if (pTrim == true)
                    sReturn = sReturn.Trim();
            }

            return sReturn;
        }

        /// <summary>
        /// [함수] 문자열의 왼쪽에서부터 지정한 길이만큼의 문자를 반환 [문자앞뒤의 공백제거]
        /// </summary>
        /// <param name="pValue">문자열</param>
        /// <param name="pLength">길이</param>
        /// <returns>왼쪽을 기준으로 n개의 문자</returns>
        public static string _GetStringLeft(string pValue, int pLength)
        {
            return _GetStringLeft(pValue, pLength, false);
        }
        #endregion

        #region _GetStringRight() 문자열의 오른쪽에서부터 지정한 길이만큼의 문자를 반환 [각 문자열=문자기준]
        /// <summary>
        /// [함수] 문자열의 오른쪽에서부터 지정한 길이만큼의 문자를 반환
        /// </summary>
        /// <param name="pValue">문자열</param>
        /// <param name="pLength">길이</param>
        /// <param name="pTrim">Trim여부</param>
        /// <returns>오른쪽을 기준으로 n개의 문자</returns>
        public static string _GetStringRight(string pValue, int pLength, bool pTrim)
        {
            string sReturn = string.Empty;

            if (pValue != null && pValue != string.Empty)
            {
                int tLength = pValue.Length;

                if (pLength < 0 || pLength > tLength) pLength = tLength;
                if (tLength >= pLength)
                {
                    sReturn = pValue.Substring(tLength - pLength, pLength);
                }

                if (pTrim == true)
                    sReturn = sReturn.Trim();
            }

            return sReturn;
        }

        /// <summary>
        /// [함수] 문자열의 오른쪽에서부터 지정한 길이만큼의 문자를 반환 [문자앞뒤의 공백제거]
        /// </summary>
        /// <param name="pValue">문자열</param>
        /// <param name="pLength">길이</param>
        /// <returns>오른쪽을 기준으로 n개의 문자</returns>
        public static string _GetStringRight(string pValue, int pLength)
        {
            return _GetStringRight(pValue, pLength, false);
        }
        #endregion

        #region 문자열에서 특정 문자열을 찾기위한 함수 ( 동일한 문자열이 있다면, 몇번째에 등장하는지 )
        public static int FindIndexOf(string sText, string sFindText, int iCount = 1, bool bForward = true)
        {
            int iIndex = -1;

            iCount--;
            if (bForward) //true 선행
            {
                iIndex = sText.IndexOf(sFindText);

                if (iCount == 0)
                    return iIndex;

                if (sText.Contains(sFindText))
                {
                    iIndex += FindIndexOf(sText.Substring(iIndex), sFindText, iCount, bForward);
                }
            }
            else //역행
            {
                iIndex = sText.LastIndexOf(sFindText);

                if (iCount == 0)
                    return iIndex;

                if (sText.Contains(sFindText))
                {
                    iIndex = FindIndexOf(sText.Substring(0, iIndex), sFindText, iCount, bForward);
                }
            }

            return iIndex;
        }
        #endregion

        #endregion

        #region 기타

        public static string GetByteString(long iByte)
        {
            if (iByte < 1024)
                return iByte.ToString() + " byte";
            else if (iByte < 1024 * 1024)
                return (iByte / 1024.0).ToString("#,##0.###") + " kb";
            else if (iByte < 1024 * 1024 * 1024)
                return (iByte / 1024.0 / 1024.0).ToString("#,##0.###") + " mb";
            else
                return (iByte / 1024.0 / 1024.0 / 1024.0).ToString("#,##0.###") + " gb";
        }

        #region MAC 어드레스 변경
        public static string MAC12toMAC17(string sMac12)
        {
            string sMac = sMac12;
            if (sMac.Length == 12)
            {
                sMac = sMac.Substring(0, 2) + "-" + sMac.Substring(2, 2) + "-" + sMac.Substring(4, 2) + "-" + sMac.Substring(6, 2) + "-" + sMac.Substring(8, 2) + "-" + sMac.Substring(10, 2);
            }

            return sMac;
        }

        public static string MAC17toMAC12(string sMac17)
        {
            string sMac = sMac17;
            if (sMac.Length == 17)
            {
                sMac = sMac.Replace("-", "");
            }

            return sMac;
        }
        #endregion

        #region _TrimNumeric() 임의의 값에서 숫자값만을 추출하여 반환
        /// <summary>
        /// [함수] 임의의 값에서 숫자값만을 추출하여 반환
        /// </summary>
        /// <param name="pValue">문자열</param>
        /// <param name="pDotInclude">소숫점포함여부</param>
        /// <param name="pSignInclude">부호포함여부</param>
        /// <returns>숫자값</returns>
        public static string _TrimNumeric(string pValue, bool pDotInclude, bool pSignInclude)
        {
            string sReturn = string.Empty;

            if (pValue != null && pValue != string.Empty)
            {
                for (int i = 0; i < pValue.Length; i++)
                {
                    bool bAdd = false;
                    if (i == 0)
                        bAdd = ((Char.IsNumber(pValue, i) == true) ||
                                (pSignInclude == true &&
                                 (pValue.Substring(i, 1) == "+" ||
                                  pValue.Substring(i, 1) == "-")));
                    else
                        bAdd = ((Char.IsNumber(pValue, i) == true) ||
                                (pDotInclude == true && pValue.Substring(i, 1) == "."));

                    if (bAdd == true)
                    {
                        sReturn += pValue.Substring(i, 1);
                    }
                }
                if (sReturn == string.Empty) sReturn = pValue;
            }

            return sReturn;
        }

        /// <summary>
        /// [함수] 임의의 값에서 숫자값만을 추출하여 반환
        /// </summary>
        /// <param name="pValue">문자열</param>
        /// <param name="pDotInclude">소숫점포함여부</param>
        /// <returns>숫자값</returns>
        public static string _TrimNumeric(string pValue, bool pDotInclude)
        {
            return _TrimNumeric(pValue, pDotInclude, false);
        }

        /// <summary>
        /// [함수] 임의의 값에서 숫자값만을 추출하여 반환 [.불포함]
        /// </summary>
        /// <param name="pValue">문자열</param>
        /// <returns>숫자값</returns>
        public static string _TrimNumeric(string pValue)
        {
            return _TrimNumeric(pValue, false, false);
        }
        #endregion

        #region _GetCurrentDT() PC의 현재일시를 반환
        /// <summary>
        /// [함수] 현재일시를 반환
        /// </summary>
        /// <param name="pTrimDelimiter">구분자제거</param>
        /// <returns>현재일시</returns>
        public static string _GetCurrentDT(bool pTrimDelimiter)
        {
            string sReturn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (pTrimDelimiter == true) sReturn = _TrimNumeric(sReturn);

            return sReturn;
        }

        /// <summary>
        /// [함수] 현재일시를 반환 [구분자 포함]
        /// </summary>
        /// <returns>현재일시</returns>
        public static string _GetCurrentDT()
        {
            return _GetCurrentDT(false);
        }
        #endregion

        #region _FormatIP() IP어드레스 포맷 변환(000.000.000.000)
        public static string _FormatIP(string pIP)
        {
            string sReturn = pIP;

            string sFormatIP = string.Empty;
            if (pIP.IndexOf(".") > 0)
            {
                string[] sIPs = pIP.Split('.');
                for (int i = 0; i < sIPs.Length; i++)
                {
                    if (sFormatIP.Length > 0) sFormatIP += ".";
                    sFormatIP += ToInt32(sIPs[i]).ToString("000");

                    if (i == sIPs.Length - 1)
                        sReturn = sFormatIP;
                }
            }

            return sReturn;
        }
        #endregion


        #region _GetCpLCode() 임의의 문자열에서 구분자 기준 좌측의 문자열을 반환
        /// <summary>
        /// [함수] 임의의 문자열에서 구분자 기준 좌측의 문자열을 반환
        /// </summary>
        /// <remarks>
        ///  분리문자가 없거나 해당 분리문자를 찾지 못할 경우 문자열 전체를 반환
        /// </remarks>
        /// <param name="pValue">문자값</param>
        /// <param name="pDelimiter">구분자</param>
        /// <param name="pTrim">Trim여부</param>
        /// <returns>구분자 좌측값</returns>
        public static string _GetCpLCode(string pValue, string pDelimiter, bool pTrim)
        {
            string sReturn = string.Empty;

            if (pValue != null && pValue != string.Empty)
            {
                if (pDelimiter == null || pDelimiter == string.Empty) pDelimiter = ":";

                string[] sTemp = new string[0];
                if (pDelimiter.Length == 1)
                    sTemp = pValue.Split(Convert.ToChar(pDelimiter));
                else
                {
                    char[] sDelimiter = pDelimiter.ToCharArray();
                    sTemp = pValue.Split(sDelimiter, StringSplitOptions.RemoveEmptyEntries);
                }

                if (sTemp.Length >= 1)
                {
                    sReturn = sTemp[0];
                }

                if (pTrim == true)
                    sReturn = sReturn.Trim();
            }

            return sReturn;
        }

        /// <summary>
        /// [함수] 임의의 문자열에서 구분자 기준 좌측의 문자열을 반환 [문자앞뒤의 공백제거]
        /// </summary>
        /// <remarks>
        ///  분리문자가 없거나 해당 분리문자를 찾지 못할 경우 문자열 전체를 반환
        /// </remarks>
        /// <param name="pValue">문자값</param>
        /// <param name="pDelimiter">구분자</param>
        /// <returns>구분자 좌측값</returns>
        public static string _GetCpLCode(string pValue, string pDelimiter)
        {
            return _GetCpLCode(pValue, pDelimiter, true);
        }

        /// <summary>
        /// [함수] 임의의 문자열에서 구분자 기준 좌측의 문자열을 반환 [구분자=":",문자앞뒤의 공백제거]
        /// </summary>
        /// <remarks>
        ///  분리문자가 없거나 해당 분리문자를 찾지 못할 경우 문자열 전체를 반환
        /// </remarks>
        /// <param name="pValue">문자값</param>
        /// <returns>구분자 좌측값</returns>
        public static string _GetCpLCode(string pValue)
        {
            return _GetCpLCode(pValue, ":", true);
        }
        #endregion


        #region _GetCpMCode() 임의의 문자열에서 구분자 기준 n번째 문자열을 반환
        /// <summary>
        /// [함수] 임의의 문자열에서 구분자 기준 n번째 문자열을 반환
        /// </summary>
        /// <remarks>
        /// <param name="pValue">문자값</param>
        /// <param name="pIndex">가져올 위치</param>
        /// <param name="pDelimiter">구분자</param>
        /// <param name="pTrim">Trim여부</param>
        /// <returns>구분자 기준 n번째값</returns>
        public static string _GetCpMCode(string pValue, int pIndex, string pDelimiter, bool pTrim)
        {
            string sReturn = string.Empty;

            if (pValue != null && pValue != string.Empty)
            {
                if (pDelimiter == null || pDelimiter == string.Empty) pDelimiter = ":";

                string[] sTemp = new string[0];
                if (pDelimiter.Length == 1)
                    sTemp = pValue.Split(Convert.ToChar(pDelimiter));
                else
                {
                    char[] sDelimiter = pDelimiter.ToCharArray();
                    sTemp = pValue.Split(sDelimiter, StringSplitOptions.RemoveEmptyEntries);
                }

                if (sTemp.Length >= 1 && sTemp.Length >= pIndex)
                {
                    sReturn = sTemp[pIndex - 1];
                }

                if (pTrim == true)
                    sReturn = sReturn.Trim();
            }

            return sReturn;
        }

        /// <summary>
        /// [함수] 임의의 문자열에서 구분자 기준 n번째 문자열을 반환 [문자앞뒤의 공백제거]
        /// </summary>
        /// <remarks>
        /// <param name="pValue">문자값</param>
        /// <param name="pIndex">가져올 위치</param>
        /// <param name="pDelimiter">구분자</param>
        /// <returns>구분자 기준 n번째값</returns>
        public static string _GetCpMCode(string pValue, int pIndex, string pDelimiter)
        {
            return _GetCpMCode(pValue, pIndex, pDelimiter, true);
        }

        /// <summary>
        /// [함수] 임의의 문자열에서 구분자 기준 n번째 문자열을 반환 [구분자=":", 문자앞뒤의 공백제거]
        /// </summary>
        /// <param name="pValue">문자값</param>
        /// <param name="pIndex">가져올 위치</param>
        /// <returns>구분자 기준 n번째값</returns>
        public static string _GetCpMCode(string pValue, int pIndex)
        {
            return _GetCpMCode(pValue, pIndex, ":", true);
        }
        #endregion


        #region _GetCpRCode() 임의의 문자열에서 구분자 기준 우측의 문자열을 반환
        /// <summary>
        /// [함수] 임의의 문자열에서 구분자 기준 우측의 문자열을 반환
        /// </summary>
        /// <remarks>
        ///  분리문자가 없거나 해당 분리문자를 찾지 못할 경우 문자열 전체를 반환
        /// </remarks>
        /// <param name="pValue">문자값</param>
        /// <param name="pDelimiter">구분자</param>
        /// <param name="pTrim">Trim여부</param>
        /// <returns>구분자 기준 우측값</returns>
        public static string _GetCpRCode(string pValue, string pDelimiter, bool pTrim)
        {
            string sReturn = string.Empty;

            if (pValue != null && pValue != string.Empty)
            {
                if (pDelimiter == null || pDelimiter == string.Empty) pDelimiter = ":";

                string[] sTemp = new string[0];
                if (pDelimiter.Length == 1)
                    sTemp = pValue.Split(Convert.ToChar(pDelimiter));
                else
                {
                    char[] sDelimiter = pDelimiter.ToCharArray();
                    sTemp = pValue.Split(sDelimiter, StringSplitOptions.RemoveEmptyEntries);
                }

                if (sTemp.Length >= 1)
                {
                    sReturn = sTemp[sTemp.Length - 1];
                }

                if (pTrim == true)
                    sReturn = sReturn.Trim();
            }

            return sReturn;
        }

        /// <summary>
        /// [함수] 임의의 문자열에서 구분자 기준 우측의 문자열을 반환 [문자앞뒤의 공백제거]
        /// </summary>
        /// <remarks>
        ///  분리문자가 없거나 해당 분리문자를 찾지 못할 경우 문자열 전체를 반환
        /// </remarks>
        /// <param name="pValue">문자값</param>
        /// <param name="pDelimiter">구분자</param>
        /// <param name="pTrim">Trim여부</param>
        /// <returns>구분자 기준 우측값</returns>
        public static string _GetCpRCode(string pValue, string pDelimiter)
        {
            return _GetCpRCode(pValue, pDelimiter, true);
        }

        /// <summary>
        /// [함수] 임의의 문자열에서 구분자 기준 우측의 문자열을 반환 [구분자=":",문자앞뒤의 공백제거]
        /// </summary>
        /// <remarks>
        ///  분리문자가 없거나 해당 분리문자를 찾지 못할 경우 문자열 전체를 반환
        /// </remarks>
        /// <param name="pValue">문자값</param>
        /// <returns>구분자 기준 우측값</returns>
        public static string _GetCpRCode(string pValue)
        {
            return _GetCpRCode(pValue, ":", true);
        }
        #endregion
        #endregion

        #endregion

        #region 

        #endregion

        #region 테스트 수정 영역

        #endregion
    }
}
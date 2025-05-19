using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace WIZ
{
    public class Common
    {
        private struct IconInfo
        {
            public bool fIcon;

            public int xHotspot;

            public int yHotspot;

            public IntPtr hbmMask;

            public IntPtr hbmColor;
        }

        public static string Lang = "KO";

        public static string DefaultLang = "KO";

        public static string SystemID;

        public static string ProcessName;
        public static string MESFileName;

        public static string FontName;

        public static string UIStyle = "DarkGray";

        public static string UIMenu = "TREE";

        public static string gsFTPSite;

        public static string SQLTIMEOUT;

        public static string gsIPSite = string.Empty;

        public static bool bPlantAuth = true;

        private const string WMI_query = "SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled='True'";

        private DataTable rtnDtTemp = new DataTable();

        private Hashtable ComboEtcData = new Hashtable();

        public static DataTable langTable = null;

        private static string passkey = "wiz";

        private static string bLicense = "";

        public static DataTable dtPlantAuth = null;

        private static bool bPlantAuthALL = true;

        public static string PLANTNAME = "";

        public static string gsSelFormID;

        public static string gsSelFormName;

        public string PassKey
        {
            set
            {
                passkey = value;
            }
        }

        [DllImport("psapi")]
        public static extern int EmptyWorkingSet(IntPtr handle);

        public void CleanProcess(string processName)
        {
            Process[] processesByName = Process.GetProcessesByName(processName);
            if (processesByName.Length == 1)
            {
                EmptyWorkingSet(processesByName[0].Handle);
            }
        }

        //public static string GetAppSetting(string sTitle, string sDefualt = "")
        //{
        //    try
        //    {
        //        Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        //        if (appConfig.AppSettings.Settings[sTitle] != null)
        //        {
        //            return DBHelper.nvlString(appConfig.AppSettings.Settings[sTitle].Value);
        //        }
        //        else
        //        {
        //            return sDefualt;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return sDefualt;
        //    }
        //}

        //public static void SetAppSetting(string sTitle, string sValue)
        //{
        //    Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        //    if (appConfig.AppSettings.Settings[sTitle] == null)
        //    {
        //        appConfig.AppSettings.Settings.Add(sTitle, sValue);
        //    }
        //    else
        //    {
        //        appConfig.AppSettings.Settings[sTitle].Value = sValue;
        //    }

        //    appConfig.Save();

        //    ConfigurationManager.RefreshSection("appSettings");

        //    return;
        //}

        public string EtcData(string MajorCode, string minorCode, int relCodeNum)
        {
            string result = null;
            if (ComboEtcData[MajorCode] != null)
            {
                Hashtable hashtable = (Hashtable)ComboEtcData[MajorCode];
                result = ((string[])hashtable[minorCode])[relCodeNum - 1];
            }
            return result;
        }

        private void SetEtcData(string MajorCode, string minorCode, string[] sList)
        {
            Hashtable hashtable = (Hashtable)ComboEtcData[MajorCode];
            if (hashtable == null)
            {
                hashtable = new Hashtable();
                ComboEtcData.Add(MajorCode, hashtable);
            }
            if (hashtable[minorCode] != null)
            {
                hashtable.Add(minorCode, sList);
            }
        }

        private void SetEtcData(string MajorCode, string MinorCodeColumnName, DataRow dr)
        {
            string[] array = new string[5];
            string minorCode = "";
            foreach (DataColumn column in dr.Table.Columns)
            {
                if (column.ColumnName.ToUpper().Contains("RELCODE"))
                {
                    int num = Convert.ToInt32(column.ColumnName.Substring(column.ColumnName.Length - 1, 1)) - 1;
                    array[num] = DBHelper.nvlString(dr[column.ColumnName]);
                }
                else if (column.ColumnName.ToUpper().Contains(MinorCodeColumnName))
                {
                    minorCode = DBHelper.nvlString(dr[column.ColumnName]);
                }
            }
            SetEtcData(MajorCode, minorCode, array);
        }

        /// <summary>
        /// COMBO_BOX 용 데이터 테이블을 만들어서 반환한다.
        /// </summary>
        /// <param name="sTableName">사용하려는 테이블 명</param>
        /// <param name="sCodeColumn">코드 컬럼명</param>
        /// <param name="sNameColumn">명칭 컬럼명</param>
        /// <param name="sWhere">WHERE 문 추가시 ( where 제외하고 입력 ) </param>
        /// <param name="sOrderColumn">정렬 문자열 디폴트 : 1</param>
        /// <param name="sExColumnList">추가로 조회 하고자 하는 컬럼명</param>
        /// <returns></returns>
        public DataTable GET_COMBOBOX_CODE(string sTableName, string sCodeColumn, string sNameColumn, string sWhere = "", string sOrderColumn = "1", string[] sExColumnList = null)
        {
            StringBuilder sSQL = new StringBuilder();
            DBHelper db = new DBHelper(false);

            sSQL.AppendLine(" SELECT " + sCodeColumn + " as CODE_ID ");
            sSQL.AppendLine("        , '['  + " + sCodeColumn + " + '] ' + " + sNameColumn + " AS CODE_NAME ");
            sSQL.AppendLine("        , " + sNameColumn + " AS CODE_NAME_ORG ");

            if (sExColumnList != null)
            {
                foreach (string s in sExColumnList)
                {
                    sSQL.Append(", " + s);
                }
            }

            sSQL.AppendLine(" FROM   " + sTableName + " with (NOLOCK) ");

            if (sWhere != "")
            {
                sSQL.AppendLine(" WHERE " + sWhere);
            }

            sSQL.AppendLine(" ORDER BY " + sOrderColumn);

            return db.FillTable(sSQL.ToString());
        }

        public DataTable GET_BM0000_CODE(string MajorCode, string sSql = " ")
        {
            //string name = new StackFrame().GetMethod().Name;
            StringBuilder stringBuilder = null;
            DBHelper dBHelper = new DBHelper(false);
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (MajorCode == "ORDERSTATUSR" && dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT MINORCODE AS CODE_ID, ");
                    stringBuilder.AppendLine("          '['  || MINORCODE || '] '||  FN_Translate('" + Lang + "', CodeName,'BM0000') AS CODE_NAME, ");
                    stringBuilder.AppendLine("        FN_Translate('" + Lang + "', CodeName, 'BM0000') AS CODE_NAME_ORG, ");
                    stringBuilder.AppendLine("         RelCode1,RelCode2,RelCode3,RelCode4,RelCode5, DisplayNo   AS DisplayNo ");
                    stringBuilder.AppendLine(" FROM   BM0000 ");
                    stringBuilder.AppendLine(" WHERE  MajorCode = 'ORDERSTATUS' ");
                    stringBuilder.AppendLine(" AND    MinorCode <> '$' ");
                    stringBuilder.AppendLine(" AND    MINORCODE <> 'R'");
                    stringBuilder.AppendLine(" AND    MINORCODE <> 'S'");
                }
                else if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT MINORCODE AS CODE_ID, ");
                    stringBuilder.AppendLine("        '['  || MinorCode || '] '||  FN_Translate('" + Lang + "', CodeName,'BM0000') AS CODE_NAME, ");
                    stringBuilder.AppendLine("        FN_Translate('" + Lang + "', CodeName, 'BM0000') AS CODE_NAME_ORG, ");
                    stringBuilder.AppendLine("        RelCode1,RelCode2,RelCode3,RelCode4,RelCode5, DisplayNo   AS DisplayNo ");
                    stringBuilder.AppendLine(" FROM   BM0000 WITH(NOLOCK)  ");
                    stringBuilder.AppendLine(" WHERE  MajorCode = '" + MajorCode.ToUpper() + "'");
                    stringBuilder.AppendLine(" AND    MinorCode <> '$' ");
                    if (sSql != " ")
                    {
                        stringBuilder.AppendLine(" AND RELCODE1 = '" + sSql + "'");
                    }
                }
                else
                {
                    stringBuilder.AppendLine(" SELECT MinorCode AS CODE_ID, ");
                    stringBuilder.AppendLine("        '[' + MinorCode + '] '+ dbo.FN_Translate('" + Lang + "', CodeName,'BM0000') AS CODE_NAME, ");
                    stringBuilder.AppendLine("        dbo.FN_Translate('" + Lang + "', CodeName, 'BM0000') AS CODE_NAME_ORG, ");
                    stringBuilder.AppendLine("        RelCode1,RelCode2,RelCode3,RelCode4,RelCode5, DisplayNo   AS DisplayNo ");
                    stringBuilder.AppendLine(" FROM   BM0000 WITH(NOLOCK) ");
                    stringBuilder.AppendLine(" WHERE  MajorCode = '" + MajorCode + "'");
                    stringBuilder.AppendLine(" AND    MinorCode <> '$' ");
                    if (sSql != " ")
                    {
                        stringBuilder.AppendLine(" AND  " + sSql);
                    }
                }
                stringBuilder.AppendLine(" AND UseFlag ='Y'");
                stringBuilder.AppendLine(" ORDER BY DisplayNo ");
                rtnDtTemp = dBHelper.FillTable(Convert.ToString(stringBuilder));
                return rtnDtTemp;
            }
            catch (Exception)
            {
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        /// <summary>
        /// 그리드에서 로그인ID 선택 
        /// </summary>
        /// <param name="MajorCode"></param>
        /// <param name="sSql"></param>
        /// <returns></returns>
        public DataTable GET_TSY0030_CODE(string MajorCode, string sSql = " ")
        {
            //string name = new StackFrame().GetMethod().Name;
            StringBuilder stringBuilder = null;
            DBHelper dBHelper = new DBHelper(false);
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (MajorCode == "USERID" && dBHelper.ConType == "OracleConnection")
                {

                }
                else if (dBHelper.ConType == "OracleConnection")
                {

                }
                else
                {
                    stringBuilder.AppendLine(" SELECT WORKERID AS CODE_ID,  ");
                    stringBuilder.AppendLine(" '[' + WORKERID + '] '+ dbo.FN_Translate('" + Lang + "', WORKERNAME,'TSY0030') AS CODE_NAME ");
                    stringBuilder.AppendLine(" FROM   TSY0030 ");
                    stringBuilder.AppendLine(" WHERE  USEFLAG = 'Y' ");
                    stringBuilder.AppendLine(" ORDER BY WORKERID ");
                }


                rtnDtTemp = dBHelper.FillTable(Convert.ToString(stringBuilder));
                return rtnDtTemp;
            }
            catch (Exception)
            {
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }
        public DataTable GET_BM4010_CODE(string MajorCode, string sSql = " ")
        {
            //string name = new StackFrame().GetMethod().Name;
            StringBuilder stringBuilder = null;
            DBHelper dBHelper = new DBHelper(false);
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (MajorCode == "USERID" && dBHelper.ConType == "OracleConnection")
                {

                }
                else if (dBHelper.ConType == "OracleConnection")
                {

                }
                else
                {
                    stringBuilder.AppendLine(" SELECT PROCESSGROUP AS CODE_ID,  ");
                    stringBuilder.AppendLine(" '[' + PROCESSGROUP + '] '+ dbo.FN_Translate('" + Lang + "', GROUPNAME,'BM4010') AS CODE_NAME ");
                    stringBuilder.AppendLine(" FROM   BM4010 ");
                }


                rtnDtTemp = dBHelper.FillTable(Convert.ToString(stringBuilder));
                return rtnDtTemp;
            }
            catch (Exception)
            {
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        /// <summary>
        /// 설비 키컬럼 리스트(DG0000) 코드 가져가기 - 2020-09-14 ADD
        /// </summary>
        /// <param name="PlantCode">사업장코드</param>
        /// <param name="MajorCode">조회코드 1조건</param>
        /// <param name="sSql">붙여서 쿼리할 쿼리문</param>
        /// <returns></returns>
        public DataTable GET_DG0000_CODE(string PlantCode, string MajorCode = "", string sSql = "")
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (MajorCode == "XXXX" && dBHelper.ConType == "OracleConnection")
                {

                }
                else if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT Type_No AS CODE_ID, ");
                    stringBuilder.AppendLine("        '['  || Type_No || '] '||  FN_Translate('" + Lang + "', Remark,'DG0000') AS CODE_NAME, ");
                    stringBuilder.AppendLine("        FN_Translate('" + Lang + "', Remark, 'DG0000') AS CODE_NAME_ORG ");
                    stringBuilder.AppendLine(" FROM   DG0000 WITH(NOLOCK)  ");
                    stringBuilder.AppendLine(" WHERE  PlantCode = '" + PlantCode.Trim() + "'");

                    if (MajorCode != "")
                    {
                        stringBuilder.AppendLine(" AND    Type_No = '" + MajorCode.Trim() + "'");
                    }
                    if (sSql != "")
                    {
                        stringBuilder.AppendLine(" AND " + sSql);
                    }
                }
                else
                {
                    stringBuilder.AppendLine(" SELECT Type_No AS CODE_ID, ");
                    stringBuilder.AppendLine("        '[' + Type_No + '] '+ dbo.FN_Translate('" + Lang + "', Remark,'DG0000') AS CODE_NAME, ");
                    stringBuilder.AppendLine("        dbo.FN_Translate('" + Lang + "', Remark, 'DG0000') AS CODE_NAME_ORG ");
                    stringBuilder.AppendLine(" FROM   DG0000 WITH(NOLOCK) ");


                    stringBuilder.AppendLine(" WHERE  PlantCode = '" + PlantCode.Trim() + "'");
                    if (MajorCode != "")
                    {
                        stringBuilder.AppendLine(" AND    Type_No = '" + MajorCode.Trim() + "'");
                    }

                    if (sSql != "")
                    {
                        stringBuilder.AppendLine(" AND  " + sSql);
                    }
                }
                //stringBuilder.AppendLine(" AND UseFlag ='Y'");
                stringBuilder.AppendLine(" ORDER BY Type_No, Remark ");
                rtnDtTemp = dBHelper.FillTable(Convert.ToString(stringBuilder));
                return rtnDtTemp;
            }
            catch (Exception)
            {
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }


        /// <summary>
        /// 설비 인터페이스 타입(컬럼명) (DG0100) 코드 가져가기 - 2020-09-15 ADD
        /// </summary>
        /// <param name="PlantCode">사업장코드</param>
        /// <param name="MajorCode">조회코드 1조건</param>
        /// <param name="sSql">붙여서 쿼리할 쿼리문</param>
        /// <returns></returns>
        public DataTable GET_DG0100_CODE(string PlantCode, string MajorCode = "", string sSql = "")
        {
            DBHelper dBHelper = new DBHelper();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (MajorCode == "XXXX" && dBHelper.ConType == "OracleConnection")
                {

                }
                else if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT ColName AS CODE_ID, ");
                    stringBuilder.AppendLine("        '['  || ColName || '] '||  FN_Translate('" + Lang + "', Caption,'DG0100') AS CODE_NAME, ");
                    stringBuilder.AppendLine("        FN_Translate('" + Lang + "', Caption, 'DG0100') AS CODE_NAME_ORG ");
                    stringBuilder.AppendLine(" FROM   DG0100 WITH(NOLOCK)  ");
                    stringBuilder.AppendLine(" WHERE  PlantCode = '" + PlantCode.Trim() + "'");

                    if (MajorCode != "")
                    {
                        stringBuilder.AppendLine(" AND    Type_No = '" + MajorCode.Trim() + "'");
                    }
                    if (sSql != "")
                    {
                        stringBuilder.AppendLine(" AND " + sSql);
                    }
                }
                else
                {
                    stringBuilder.AppendLine(" SELECT DISTINCT ColName AS CODE_ID, ");
                    stringBuilder.AppendLine("        '[' + ColName + '] '+ dbo.FN_Translate('" + Lang + "', Caption,'DG0100') AS CODE_NAME, ");
                    stringBuilder.AppendLine("        dbo.FN_Translate('" + Lang + "', Caption, 'DG0100') AS CODE_NAME_ORG ");
                    stringBuilder.AppendLine(" FROM   DG0100 WITH(NOLOCK) ");


                    stringBuilder.AppendLine(" WHERE  PlantCode = '" + PlantCode.Trim() + "'");
                    if (MajorCode != "")
                    {
                        stringBuilder.AppendLine(" AND    Type_No = '" + MajorCode.Trim() + "'");
                    }

                    if (sSql != "")
                    {
                        stringBuilder.AppendLine(" AND  " + sSql);
                    }
                }
                //stringBuilder.AppendLine(" AND UseFlag ='Y'");
                stringBuilder.AppendLine(" ORDER BY CODE_ID, CODE_NAME ");
                rtnDtTemp = dBHelper.FillTable(Convert.ToString(stringBuilder));
                return rtnDtTemp;
            }
            catch (Exception)
            {
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }







        public DataTable GET_YQM0000_CODE(string MajorCode, string sSql = " ")
        {
            string name = new StackFrame().GetMethod().Name;
            StringBuilder stringBuilder = null;
            DBHelper dBHelper = new DBHelper(false);
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT MGRCODE AS CODE_ID, ");
                    stringBuilder.AppendLine("        '['  || MGRCODE || '] '||  MGRNAME AS CODE_NAME ");
                    stringBuilder.AppendLine(" FROM   YQM0000 ");
                    stringBuilder.AppendLine(" WHERE  MGRGROUP = '" + MajorCode.ToString() + "' and USEFLAG = 'Y'");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_YQM0000_CODE2(string MajorCode, string sSql = " ")
        {
            string name = new StackFrame().GetMethod().Name;
            StringBuilder stringBuilder = null;
            DBHelper dBHelper = new DBHelper(false);
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT MGRCODE AS CODE_ID, ");
                    stringBuilder.AppendLine("        '['  || substr(MGRCODE,2,1) || '] '||  MGRNAME AS CODE_NAME ");
                    stringBuilder.AppendLine(" FROM   YQM0000 ");
                    stringBuilder.AppendLine(" Where mgrgroup = 'WORK_VOLUME'");
                    switch (MajorCode.ToString())
                    {
                        case "02":
                            stringBuilder.AppendLine(" and MGRCODE like 'C%' ");
                            break;
                        case "06":
                            stringBuilder.AppendLine(" and MGRCODE like 'S%' ");
                            break;
                        case "10":
                            stringBuilder.AppendLine(" and MGRCODE like 'H%' ");
                            break;
                    }
                    stringBuilder.AppendLine("   and USEFLAG = 'Y'");
                    stringBuilder.AppendLine(" Order by MGRCODE");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder), CommandType.Text, dBHelper.CreateParameter("MajorCode", MajorCode, DbType.String, ParameterDirection.Input));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_YQM0100_CODE(string MajorCode, string sSql = " ")
        {
            string name = new StackFrame().GetMethod().Name;
            StringBuilder stringBuilder = null;
            DBHelper dBHelper = new DBHelper(false);
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT TRIM(TO_CHAR(IOPCODE,'0000')) AS CODE_ID, ");
                    stringBuilder.AppendLine("        '['  || TRIM(TO_CHAR(IOPCODE,'0000')) || '] '||  IOPCODENAME AS CODE_NAME ");
                    stringBuilder.AppendLine(" FROM   YQM0100 ");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_YQM0200_CODE(string MajorCode, string sSql = " ")
        {
            string name = new StackFrame().GetMethod().Name;
            StringBuilder stringBuilder = null;
            DBHelper dBHelper = new DBHelper(false);
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT  TRIM(TO_CHAR(IITEMNO,'000')) AS CODE_ID,  ");
                    stringBuilder.AppendLine(" '['  || TRIM(TO_CHAR(IITEMNO,'000')) || '] '||  TO_CHAR(IOPCODE,'0000') || ' - ' || IITEMNAME AS CODE_NAME ");
                    stringBuilder.AppendLine(" FROM   YQM0200 ");
                    stringBuilder.AppendLine("WHERE   IOPCODE LIKE '" + MajorCode.ToString() + "%'");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_BM0040_CODE(string OPCode)
        {
            string name = new StackFrame().GetMethod().Name;
            DBHelper dBHelper = new DBHelper(false);
            StringBuilder stringBuilder = null;
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT OPCODE AS CODE_ID, ");
                    stringBuilder.AppendLine("        '[' || OPCODE || '] '||  FN_Translate('" + Lang + "', OPNAME,'BM0400') AS CODE_NAME ");
                    stringBuilder.AppendLine(" FROM   BM0040 ");
                    stringBuilder.AppendLine(" WHERE  OPCODE LIKE '" + OPCode + "%'");
                }
                else
                {
                    stringBuilder.AppendLine(" SELECT OPCODE AS CODE_ID, ");
                    stringBuilder.AppendLine("        '[' + OPCODE + '] '+  dbo.FN_Translate('" + Lang + "', OPNAME,'BM0400') AS CODE_NAME ");
                    stringBuilder.AppendLine(" FROM   BM0040 WITH(NOLOCK) ");
                    stringBuilder.AppendLine(" WHERE  OPCODE LIKE '" + OPCode + "%'");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_BM0050_CODE(string plantcode)
        {
            string name = new StackFrame().GetMethod().Name;
            DBHelper dBHelper = new DBHelper(false);
            StringBuilder stringBuilder = null;
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT LINECODE AS CODE_ID, ");
                    stringBuilder.AppendLine("        '[' || LINECODE || '] '||  FN_Translate('" + Lang + "', LINENAME,'BM0500') AS CODE_NAME ");
                    stringBuilder.AppendLine(" FROM   BM0050 ");
                    stringBuilder.AppendLine(" WHERE  PLANTCODE LIKE '" + plantcode + "%'");
                }
                else
                {
                    stringBuilder.AppendLine(" SELECT LINECODE AS CODE_ID, ");
                    stringBuilder.AppendLine("        '[' + LINECODE + '] '+   dbo.FN_Translate('" + Lang + "', LINENAME,'BM0500') AS CODE_NAME ");
                    stringBuilder.AppendLine(" FROM   BM0050 WITH(NOLOCK) ");
                    stringBuilder.AppendLine(" WHERE  PLANTCODE LIKE '" + plantcode + "%'");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_BM0060_CODE(string WorkCenterCode)
        {
            string name = new StackFrame().GetMethod().Name;
            DBHelper dBHelper = new DBHelper(false);
            StringBuilder stringBuilder = null;
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT WorkCenterCode AS CODE_ID, ");
                    stringBuilder.AppendLine("        '[' || WorkCenterCode || '] '||  FN_Translate('" + Lang + "', WorkCenterName,'BM0600') AS CODE_NAME ");
                    stringBuilder.AppendLine(" FROM   BM0060 ");
                    stringBuilder.AppendLine(" WHERE  WorkCenterCode LIKE '" + WorkCenterCode + "%' ");
                    stringBuilder.AppendLine("   AND  USEFLAG = 'Y' ");
                    stringBuilder.AppendLine(" ORDER BY WorkCenterCode ");
                }
                else
                {
                    stringBuilder.AppendLine(" SELECT WorkCenterCode AS CODE_ID, ");
                    stringBuilder.AppendLine("        '[' + WorkCenterCode + '] '+ dbo.FN_Translate('" + Lang + "', WorkCenterName,'BM0600')  AS CODE_NAME ");
                    stringBuilder.AppendLine(" FROM   BM0060 WITH(NOLOCK) ");
                    stringBuilder.AppendLine(" WHERE  WorkCenterCode LIKE '" + WorkCenterCode + "%' ");
                    stringBuilder.AppendLine("   AND  USEFLAG = 'Y' ");
                    stringBuilder.AppendLine(" ORDER BY WorkCenterCode ");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_BM0070_CODE(string MachCode)
        {
            string name = new StackFrame().GetMethod().Name;
            DBHelper dBHelper = new DBHelper(false);
            StringBuilder stringBuilder = null;
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT MachCode AS CODE_ID, ");
                    stringBuilder.AppendLine("        '[' || MachCode || '] '||  FN_Translate('" + Lang + "', MachName,'BM0700') AS CODE_NAME ");
                    stringBuilder.AppendLine(" FROM   BM0070 ");
                    stringBuilder.AppendLine(" WHERE  MachCode LIKE '" + MachCode + "%' ");
                    stringBuilder.AppendLine(" ORDER BY MachCode ");
                }
                else
                {
                    stringBuilder.AppendLine(" SELECT MachCode AS CODE_ID, ");
                    stringBuilder.AppendLine("        '[' + MachCode + '] '+  dbo.FN_Translate('" + Lang + "', MachName,'BM0700')  AS CODE_NAME ");
                    stringBuilder.AppendLine(" FROM   BM0070 WITH(NOLOCK) ");
                    stringBuilder.AppendLine(" WHERE  MachCode LIKE '" + MachCode + "%' ");
                    stringBuilder.AppendLine(" ORDER BY MachCode ");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_BM0010_CODE(string ItemCode)
        {
            string name = new StackFrame().GetMethod().Name;
            DBHelper dBHelper = new DBHelper(false);
            StringBuilder stringBuilder = null;
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT ItemCode AS CODE_ID, ");
                    stringBuilder.AppendLine("        '[' || ItemCode || '] '||  FN_Translate('" + Lang + "', ItemName,'BM0100') AS CODE_NAME ");
                    stringBuilder.AppendLine(" FROM   BM0010 ");
                    stringBuilder.AppendLine(" WHERE  ItemCode LIKE '" + ItemCode + "%' ");
                }
                else
                {
                    stringBuilder.AppendLine(" SELECT ItemCode AS CODE_ID, ");
                    stringBuilder.AppendLine("        '[' + ItemCode + '] '+  dbo.FN_Translate('" + Lang + "', ItemName,'BM0100')    AS CODE_NAME ");
                    stringBuilder.AppendLine(" FROM   BM0010 WITH(NOLOCK) ");
                    stringBuilder.AppendLine(" WHERE  ItemCode LIKE '" + ItemCode + "%' ");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_TBM0100Y_CODE(string ItemCode)
        {
            string name = new StackFrame().GetMethod().Name;
            DBHelper dBHelper = new DBHelper(false);
            StringBuilder stringBuilder = null;
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT ItemCode AS CODE_ID, ");
                    stringBuilder.AppendLine("        '[' || ItemCode || '] '||  FN_Translate('" + Lang + "', ItemName,'BM0100Y') AS CODE_NAME ");
                    stringBuilder.AppendLine(" FROM   TBM0100Y ");
                    stringBuilder.AppendLine(" WHERE  ItemCode LIKE '" + ItemCode + "%' ");
                }
                else
                {
                    stringBuilder.AppendLine(" SELECT ItemCode AS CODE_ID, ");
                    stringBuilder.AppendLine("        '[' + ItemCode + '] '+  dbo.FN_Translate('" + Lang + "', ItemName,'BM0100Y')    AS CODE_NAME ");
                    stringBuilder.AppendLine(" FROM   TBM0100Y WITH(NOLOCK) ");
                    stringBuilder.AppendLine(" WHERE  ItemCode LIKE '" + ItemCode + "%' ");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_TBM0000_1_CODE(string MajorCode, string sSql = "")
        {
            //string name = new StackFrame().GetMethod().Name;
            DBHelper dBHelper = new DBHelper();
            DbParameter[] array = new DbParameter[1];
            StringBuilder stringBuilder = null;
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT CodeName AS CODE_ID, ");
                    stringBuilder.AppendLine("        '[' || MinorCode || '] '||  FN_Translate('" + Lang + "', CodeName,'BM0000') AS CODE_NAME, ");
                    stringBuilder.AppendLine("        RelCode1,RelCode2,RelCode3,RelCode4,RelCode5, DisplayNo   AS DisplayNo ");
                    stringBuilder.AppendLine(" FROM   TBM0000 WITH(NOLOCK) ");
                    stringBuilder.AppendLine(" WHERE  CodeName =  '합격' ");
                    stringBuilder.AppendLine(" OR  CodeName =  '불합격' ");
                    stringBuilder.AppendLine(" AND    MinorCode <> '$' ");
                }
                else
                {
                    stringBuilder.AppendLine(" SELECT CodeName AS CODE_ID, ");
                    stringBuilder.AppendLine("        '[' + MinorCode + '] '+  dbo.FN_Translate('" + Lang + "', CodeName,'BM0000') AS CODE_NAME, ");
                    stringBuilder.AppendLine("        RelCode1,RelCode2,RelCode3,RelCode4,RelCode5, DisplayNo   AS DisplayNo ");
                    stringBuilder.AppendLine(" FROM   TBM0000 WITH(NOLOCK) ");
                    stringBuilder.AppendLine(" WHERE  CodeName =  '합격' ");
                    stringBuilder.AppendLine(" OR  CodeName =  '불합격' ");
                    stringBuilder.AppendLine(" AND    MinorCode <> '$' ");
                }
                if (sSql != "")
                {
                    stringBuilder.AppendLine(" AND  " + sSql);
                }
                stringBuilder.AppendLine(" ORDER BY DisplayNo ");
                return dBHelper.FillTable(Convert.ToString(stringBuilder));
            }
            catch (Exception)
            {
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_TBM0000_2_CODE(string MinorCode, string sSql = "")
        {
            string name = new StackFrame().GetMethod().Name;
            DBHelper dBHelper = new DBHelper(false);
            StringBuilder stringBuilder = null;
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT FN_Translate('" + Lang + "', CodeName,'BM0000') AS CODE_ID, RelCode AS CODE_NAME FROM                      ");
                    stringBuilder.AppendLine(" (SELECT CodeName, RelCode1, RelCode2 FROM TBM0000                          ");
                    stringBuilder.AppendLine("  WHERE MAJORCODE = 'INSPVALTYPE' AND MINORCODE ='" + MinorCode.ToUpper() + "'");
                    stringBuilder.AppendLine(" AND    MinorCode <> '$'  ) p                                               ");
                    stringBuilder.AppendLine(" UNPIVOT                                                                    ");
                    stringBuilder.AppendLine(" (RelCode FOR RelCode3 IN (RelCode1, RelCode2))AS unpvt                     ");
                }
                else
                {
                    stringBuilder.AppendLine(" SELECT dbo.FN_Translate('" + Lang + "', CodeName,'BM0000') AS CODE_ID, RelCode AS CODE_NAME FROM                      ");
                    stringBuilder.AppendLine(" (SELECT CodeName, RelCode1, RelCode2 FROM TBM0000                          ");
                    stringBuilder.AppendLine("  WHERE MAJORCODE = 'INSPVALTYPE' AND MINORCODE ='" + MinorCode + "'");
                    stringBuilder.AppendLine(" AND    MinorCode <> '$'  ) p                                               ");
                    stringBuilder.AppendLine(" UNPIVOT                                                                    ");
                    stringBuilder.AppendLine(" (RelCode FOR RelCode3 IN (RelCode1, RelCode2))AS unpvt                     ");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_BM0000_CODE(string MajorCode, string[] sArr)
        {
            //string name = new StackFrame().GetMethod().Name;
            DBHelper dBHelper = new DBHelper();
            StringBuilder stringBuilder = null;
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT MinorCode AS CODE_ID, ");
                    stringBuilder.AppendLine("        '[' || MinorCode || '] '|| FN_Translate('" + Lang + "', CodeName,'BM0000') AS CODE_NAME, ");
                    stringBuilder.AppendLine("        FN_Translate('" + Lang + "', CodeName, 'BM0000') AS CODE_NAME_ORG, ");
                    stringBuilder.AppendLine("         DisplayNo   AS DisplayNo ");
                    stringBuilder.AppendLine(" FROM   BM0000  ");
                    stringBuilder.AppendLine(" WHERE  MajorCode =  :MajorCode ");
                    stringBuilder.AppendLine(" AND    MinorCode <> '$' ");
                }
                else
                {
                    stringBuilder.AppendLine(" SELECT MinorCode AS CODE_ID, ");
                    stringBuilder.AppendLine("        '[' + MinorCode + '] '+  dbo.FN_Translate('" + Lang + "', CodeName,'BM0000') AS CODE_NAME, ");
                    stringBuilder.AppendLine("        dbo.FN_Translate('" + Lang + "', CodeName, 'BM0000') AS CODE_NAME_ORG, ");
                    stringBuilder.AppendLine("         DisplayNo   AS DisplayNo ");
                    stringBuilder.AppendLine(" FROM   BM0000 WITH(NOLOCK) ");
                    stringBuilder.AppendLine(" WHERE  MajorCode =  @MajorCode ");
                    stringBuilder.AppendLine(" AND    MinorCode <> '$' ");
                }
                for (int i = 0; i < sArr.Length; i += 2)
                {
                    stringBuilder.AppendLine(" AND  " + sArr[i] + " = '" + sArr[i + 1] + "' ");
                }
                stringBuilder.AppendLine(" ORDER BY DisplayNo ");
                return dBHelper.FillTable(Convert.ToString(stringBuilder));
            }
            catch (Exception)
            {
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_BM0030_CODE(string CustCode)
        {
            return GET_BM0030_CODE(CustCode, "");
        }

        public DataTable GET_BM0030_CODE(string CustCode, string InCustType)
        {
            string name = new StackFrame().GetMethod().Name;
            DBHelper dBHelper = new DBHelper(false);
            StringBuilder stringBuilder = null;
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (InCustType == "CustType")
                {
                    if (dBHelper.ConType == "OracleConnection")
                    {
                        stringBuilder.AppendLine(" SELECT CUSTCODE AS CODE_ID, ");
                        stringBuilder.AppendLine("        '[' || CUSTCODE || '] '||  FN_Translate('" + Lang + "', CustName,'BM0300') AS CODE_NAME ");
                        stringBuilder.AppendLine(" FROM   BM0030  ");
                        stringBuilder.AppendLine(" WHERE  CustType =  'P' ");
                        stringBuilder.AppendLine(" AND    CustCode like '" + CustCode + "%'");
                        stringBuilder.AppendLine(" ORDER BY CustCode ");
                    }
                    else
                    {
                        stringBuilder.AppendLine(" SELECT CustCode AS CODE_ID, ");
                        stringBuilder.AppendLine("        '[' + CustCode + '] '+   dbo.FN_Translate('" + Lang + "', CustName,'BM0300')  AS CODE_NAME ");
                        stringBuilder.AppendLine(" FROM   BM0030 WITH(NOLOCK) ");
                        stringBuilder.AppendLine(" WHERE  CustType =  'P' ");
                        stringBuilder.AppendLine(" AND    CustCode like '" + CustCode + "%'");
                        stringBuilder.AppendLine(" ORDER BY CustCode ");
                    }
                    return dBHelper.FillTable(Convert.ToString(stringBuilder));
                }
                if (InCustType == "")
                {
                    if (dBHelper.ConType == "OracleConnection")
                    {
                        stringBuilder.AppendLine(" SELECT CustCode AS CODE_ID, ");
                        stringBuilder.AppendLine("        '[' || CustCode || '] '||  FN_Translate('" + Lang + "', CustName,'BM0300') AS CODE_NAME ");
                        stringBuilder.AppendLine(" FROM   BM0030  ");
                        stringBuilder.AppendLine(" WHERE  CustType =  'V' ");
                        stringBuilder.AppendLine(" AND    CustCode <> '$' ");
                        stringBuilder.AppendLine(" AND    CustCode like '" + CustCode + "%'");
                        stringBuilder.AppendLine(" ORDER BY CustCode ");
                    }
                    else
                    {
                        stringBuilder.AppendLine(" SELECT CustCode AS CODE_ID, ");
                        stringBuilder.AppendLine("        '[' + CustCode + '] '+   dbo.FN_Translate('" + Lang + "', CustName,'BM0300')   AS CODE_NAME ");
                        stringBuilder.AppendLine(" FROM   BM0030 WITH(NOLOCK) ");
                        stringBuilder.AppendLine(" WHERE  CustType =  'V' ");
                        stringBuilder.AppendLine(" AND    CustCode <> '$' ");
                        stringBuilder.AppendLine(" AND    CustCode like '" + CustCode + "%'");
                        stringBuilder.AppendLine(" ORDER BY CustCode ");
                    }
                    return dBHelper.FillTable(Convert.ToString(stringBuilder));
                }
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT CUSTCODE AS CODE_ID, ");
                    stringBuilder.AppendLine("        '[' || CUSTCODE || '] '||  FN_Translate('" + Lang + "', CustName,'BM0300') AS CODE_NAME ");
                    stringBuilder.AppendLine(" FROM   BM0030  ");
                    stringBuilder.AppendLine(" WHERE  CustType in  (" + InCustType + ") ");
                    stringBuilder.AppendLine(" AND    CustCode like '" + CustCode + "%'");
                    stringBuilder.AppendLine(" ORDER BY CustCode ");
                }
                else
                {
                    stringBuilder.AppendLine(" SELECT CustCode AS CODE_ID, ");
                    stringBuilder.AppendLine("        '[' + CustCode + '] '+   dbo.FN_Translate('" + Lang + "', CustName,'BM0300')  AS CODE_NAME ");
                    stringBuilder.AppendLine(" FROM   BM0030 WITH(NOLOCK) ");
                    stringBuilder.AppendLine(" WHERE  CustType in  (" + InCustType + ")");
                    stringBuilder.AppendLine(" AND    CustCode like '" + CustCode + "%'");
                    stringBuilder.AppendLine(" ORDER BY CustCode ");
                }
                rtnDtTemp = dBHelper.FillTable(Convert.ToString(stringBuilder));
                if (bPlantAuth && LoginInfo.UserID != "SYSTEM")
                {
                    SetPlantAuth();
                }
                return rtnDtTemp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_BM0130_CODE(string sUseFlag)
        {
            string name = new StackFrame().GetMethod().Name;
            DBHelper dBHelper = new DBHelper(false);
            StringBuilder stringBuilder = null;
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT UnitCode AS CODE_ID, ");
                    stringBuilder.AppendLine("        UnitCode AS CODE_NAME, ");
                    stringBuilder.AppendLine("         DisplayNo   AS DisplayNo ");
                    stringBuilder.AppendLine(" FROM   BM0130  ");
                    stringBuilder.AppendLine(" WHERE  UseFlag =  '" + sUseFlag + "' ");
                    stringBuilder.AppendLine(" ORDER BY DisplayNo ");
                }
                else
                {
                    stringBuilder.AppendLine(" SELECT UNITCODE   AS CODE_ID                           ");
                    stringBuilder.AppendLine("      , '[' + UNITCODE + '] ' +  UNITNAME  AS CODE_NAME ");
                    stringBuilder.AppendLine("      , DISPLAYNO  AS DISPLAYNO                         ");
                    stringBuilder.AppendLine("   FROM BM0130 WITH (NOLOCK)                            ");
                    stringBuilder.AppendLine("  WHERE USEFLAG LIKE '" + sUseFlag + "' + '%'           ");
                    stringBuilder.AppendLine("  ORDER BY DISPLAYNO                                    ");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_BM0135_CODE(string sUseFlag)
        {
            string name = new StackFrame().GetMethod().Name;
            DBHelper dBHelper = new DBHelper(false);
            StringBuilder stringBuilder = null;
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT UnitCode AS CODE_ID, ");
                    stringBuilder.AppendLine("        UnitCode AS CODE_NAME, ");
                    stringBuilder.AppendLine("        DisplayNo   AS DisplayNo ");
                    stringBuilder.AppendLine(" FROM   BM0135  ");
                    stringBuilder.AppendLine(" WHERE  UseFlag =  '" + sUseFlag + "' ");
                    stringBuilder.AppendLine(" ORDER BY DisplayNo ");
                }
                else
                {
                    stringBuilder.AppendLine(" SELECT UNITCODE   AS CODE_ID                           ");
                    stringBuilder.AppendLine("      , '[' + UNITCODE + '] ' +  UNITNAME  AS CODE_NAME ");
                    stringBuilder.AppendLine("      , DISPLAYNO  AS DISPLAYNO                         ");
                    stringBuilder.AppendLine("   FROM BM0135 WITH (NOLOCK)                            ");
                    stringBuilder.AppendLine("  WHERE USEFLAG LIKE '" + sUseFlag + "' + '%'           ");
                    stringBuilder.AppendLine("  ORDER BY DISPLAYNO                                    ");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_BM0145_CODE(string sUseFlag)
        {
            string name = new StackFrame().GetMethod().Name;
            DBHelper dBHelper = new DBHelper(false);
            StringBuilder stringBuilder = null;
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT UnitCode AS CODE_ID, ");
                    stringBuilder.AppendLine("        UnitCode AS CODE_NAME, ");
                    stringBuilder.AppendLine("         DisplayNo   AS DisplayNo ");
                    stringBuilder.AppendLine(" FROM   BM0145  ");
                    stringBuilder.AppendLine(" WHERE  UseFlag =  '" + sUseFlag + "' ");
                    stringBuilder.AppendLine(" ORDER BY DisplayNo ");
                }
                else
                {
                    stringBuilder.AppendLine(" SELECT UNITCODE   AS CODE_ID                           ");
                    stringBuilder.AppendLine("      , '[' + UNITCODE + '] ' +  UNITNAME  AS CODE_NAME ");
                    stringBuilder.AppendLine("      , DISPLAYNO  AS DISPLAYNO                         ");
                    stringBuilder.AppendLine("   FROM BM0145 WITH (NOLOCK)                            ");
                    stringBuilder.AppendLine("  WHERE USEFLAG LIKE '" + sUseFlag + "' + '%'           ");
                    stringBuilder.AppendLine("  ORDER BY DISPLAYNO                                    ");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_BM0170_CODE(string plantcode, string sUseFlag)
        {
            string name = new StackFrame().GetMethod().Name;
            DBHelper dBHelper = new DBHelper(false);
            StringBuilder stringBuilder = null;
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    //stringBuilder.AppendLine(" SELECT UnitCode AS CODE_ID, ");
                    //stringBuilder.AppendLine("        UnitCode AS CODE_NAME, ");
                    //stringBuilder.AppendLine("         DisplayNo   AS DisplayNo ");
                    //stringBuilder.AppendLine(" FROM   BM0130  ");
                    //stringBuilder.AppendLine(" WHERE  UseFlag =  '" + sUseFlag + "' ");
                    //stringBuilder.AppendLine(" ORDER BY DisplayNo ");
                }
                else
                {
                    stringBuilder.AppendLine(" SELECT MACODE   AS CODE_ID                           ");
                    stringBuilder.AppendLine("      , '[' + MACODE + '] ' +  MANAME  AS CODE_NAME ");
                    stringBuilder.AppendLine("   FROM BM0710 WITH (NOLOCK)                            ");
                    stringBuilder.AppendLine("  WHERE PLANTCODE LIKE '" + plantcode + "' + '%'           ");
                    stringBuilder.AppendLine("  AND   USEFLAG LIKE '" + sUseFlag + "' + '%'           ");
                    stringBuilder.AppendLine("  ORDER BY MACODE                                    ");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_BM0130_CODE_1(string sUnitType, string sUseflag)
        {
            string name = new StackFrame().GetMethod().Name;
            StringBuilder stringBuilder = null;
            DBHelper dBHelper = new DBHelper(false);
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT UnitCode AS CODE_ID, ");
                    stringBuilder.AppendLine("        '[' || UnitCode || ']'  AS CODE_NAME, ");
                    stringBuilder.AppendLine("         DisplayNo   AS DisplayNo ");
                    stringBuilder.AppendLine(" FROM   BM0130  ");
                    stringBuilder.AppendLine(" WHERE  UseFlag =  :useflag ");
                    stringBuilder.AppendLine("   AND  unitType =  :unitType ");
                    stringBuilder.AppendLine(" ORDER BY DisplayNo ");
                }
                else
                {
                    stringBuilder.AppendLine(" SELECT UnitCode AS CODE_ID, ");
                    stringBuilder.AppendLine("        UnitCode AS CODE_NAME, ");
                    stringBuilder.AppendLine("         DisplayNo   AS DisplayNo ");
                    stringBuilder.AppendLine(" FROM   BM0130 WITH(NOLOCK) ");
                    stringBuilder.AppendLine(" WHERE  UseFlag =  @useflag ");
                    stringBuilder.AppendLine("   AND  unitType =  @unitType ");
                    stringBuilder.AppendLine(" ORDER BY DisplayNo ");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder), CommandType.Text, dBHelper.CreateParameter("useflag", sUseflag, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("unitType", sUnitType, DbType.String, ParameterDirection.Input));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }
        public DataTable GET_BM0685_CODE(string sUnitType, string sUseflag)
        {
            string name = new StackFrame().GetMethod().Name;
            StringBuilder stringBuilder = null;
            DBHelper dBHelper = new DBHelper(false);
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT MODINSPCODE AS CODE_ID ");
                    stringBuilder.AppendLine("        , '[' || MODINSPNAME || ']'  AS CODE_NAME ");
                    //stringBuilder.AppendLine("         , DisplayNo   AS DisplayNo ");
                    stringBuilder.AppendLine(" FROM   BM0685  ");
                    stringBuilder.AppendLine(" WHERE  UseFlag =  :useflag ");
                    //stringBuilder.AppendLine("   AND  unitType =  :unitType ");
                    stringBuilder.AppendLine(" ORDER BY MODINSPCODE ");
                }
                else
                {
                    stringBuilder.AppendLine(" SELECT MODINSPCODE AS CODE_ID ");
                    stringBuilder.AppendLine("        , '['+ MODINSPCODE + '] ' + MODINSPNAME AS CODE_NAME ");
                    stringBuilder.AppendLine("        , MODINSPNAME AS ORG_CODE_NAME ");
                    //stringBuilder.AppendLine("         , DisplayNo   AS DisplayNo ");
                    stringBuilder.AppendLine(" FROM   BM0685 WITH(NOLOCK) ");
                    stringBuilder.AppendLine(" WHERE  UseFlag =  @useflag ");
                    //stringBuilder.AppendLine("   AND  unitType =  @unitType ");
                    stringBuilder.AppendLine(" ORDER BY MODINSPCODE ");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder), CommandType.Text
                    , dBHelper.CreateParameter("useflag", sUseflag, DbType.String, ParameterDirection.Input)
                    , dBHelper.CreateParameter("unitType", sUnitType, DbType.String, ParameterDirection.Input));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }
        public DataTable GET_BM0686_CODE(string sUnitType, string sUseflag)
        {
            string name = new StackFrame().GetMethod().Name;
            StringBuilder stringBuilder = null;
            DBHelper dBHelper = new DBHelper(false);
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT ACTIONCODE AS CODE_ID ");
                    stringBuilder.AppendLine("        , '[' || ACTIONNAME || ']'  AS CODE_NAME ");
                    //stringBuilder.AppendLine("         , DisplayNo   AS DisplayNo ");
                    stringBuilder.AppendLine(" FROM   BM0686  ");
                    stringBuilder.AppendLine(" WHERE  UseFlag =  :useflag ");
                    //stringBuilder.AppendLine("   AND  unitType =  :unitType ");
                    stringBuilder.AppendLine(" ORDER BY ACTIONCODE ");
                }
                else
                {
                    stringBuilder.AppendLine(" SELECT ACTIONCODE AS CODE_ID ");
                    stringBuilder.AppendLine("        , '[' + ACTIONCODE +'] '+ACTIONNAME AS CODE_NAME ");
                    stringBuilder.AppendLine("        , ACTIONNAME AS ORG_CODE_NAME ");
                    //stringBuilder.AppendLine("         , DisplayNo   AS DisplayNo ");
                    stringBuilder.AppendLine(" FROM   BM0686 WITH(NOLOCK) ");
                    stringBuilder.AppendLine(" WHERE  UseFlag =  @useflag ");
                    //stringBuilder.AppendLine("   AND  unitType =  @unitType ");
                    stringBuilder.AppendLine(" ORDER BY ACTIONCODE ");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder), CommandType.Text
                    , dBHelper.CreateParameter("useflag", sUseflag, DbType.String, ParameterDirection.Input)
                    , dBHelper.CreateParameter("unitType", sUnitType, DbType.String, ParameterDirection.Input));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_BM0080_CODE(string sPlantCode)
        {
            string name = new StackFrame().GetMethod().Name;
            DBHelper dBHelper = new DBHelper(false);
            StringBuilder stringBuilder = null;
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT  WHCode AS CODE_ID,                        ");
                    stringBuilder.AppendLine("       '[' || WHCode || ']' || FN_Translate('" + Lang + "', WHName,'BM0800')   AS CODE_NAME");
                    stringBuilder.AppendLine("  FROM   BM0080                                   ");
                    stringBuilder.AppendLine(" WHERE  PlantCode  Like  '" + sPlantCode.ToUpper() + "' || '%'         ");
                    stringBuilder.AppendLine(" ORDER BY PlantCode, WHCode                        ");
                }
                else
                {
                    stringBuilder.AppendLine(" SELECT  WHCode AS CODE_ID,                        ");
                    stringBuilder.AppendLine("        '[' + WHCode + ']' +  dbo.FN_Translate('" + Lang + "', WHName,'BM0800')  AS CODE_NAME  ");
                    stringBuilder.AppendLine("  FROM   BM0080 WITH(NOLOCK)                      ");
                    stringBuilder.AppendLine(" WHERE  PlantCode  Like  '" + sPlantCode + "%'          ");
                    stringBuilder.AppendLine(" ORDER BY PlantCode, WHCode                        ");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_TBM0800_1_CODE(string WHType)
        {
            string name = new StackFrame().GetMethod().Name;
            DBHelper dBHelper = new DBHelper(false);
            StringBuilder stringBuilder = null;
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT  WHCode AS CODE_ID,                         ");
                    stringBuilder.AppendLine("        '[' || WHCode || ']' || FN_Translate('" + Lang + "', WHName,'BM0800')  AS CODE_NAME");
                    stringBuilder.AppendLine("  FROM   TBM0800                                    ");
                    stringBuilder.AppendLine(" WHERE  '" + WHType.ToUpper() + "'  =  'Y'             ");
                    stringBuilder.AppendLine(" ORDER BY PlantCode, WHCode                         ");
                }
                else
                {
                    stringBuilder.AppendLine(" SELECT  WHCode AS CODE_ID,                        ");
                    stringBuilder.AppendLine("        '[' + WHCode + ']' + dbo.FN_Translate('" + Lang + "', WHName,'BM0800')   AS CODE_NAME  ");
                    stringBuilder.AppendLine("  FROM   TBM0800 WITH(NOLOCK)                      ");
                    stringBuilder.AppendLine(" WHERE  '" + WHType.ToUpper() + "' =  'Y'           ");
                    stringBuilder.AppendLine(" ORDER BY PlantCode, WHCode                        ");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_YBM8400_CODE(string destcity)
        {
            string name = new StackFrame().GetMethod().Name;
            DBHelper dBHelper = new DBHelper(false);
            StringBuilder stringBuilder = null;
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine(" SELECT  CITYCODE AS CODE_ID,                         ");
                    stringBuilder.AppendLine("        '[' || CITYCODE || ']' || CITYNAME  AS CODE_NAME");
                    stringBuilder.AppendLine("  FROM   YBM8400                                    ");
                    stringBuilder.AppendLine(" ORDER BY CITYCODE                                  ");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_TMM0900_CODE(string InspResultDesc)
        {
            string name = new StackFrame().GetMethod().Name;
            DBHelper dBHelper = new DBHelper();
            StringBuilder stringBuilder = null;
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                stringBuilder.AppendLine(" SELECT  InspResultDesc AS CODE_ID,                        ");
                stringBuilder.AppendLine(" InspResultDesc  AS CODE_NAME  ");
                stringBuilder.AppendLine("  FROM   TMM0900 WITH(NOLOCK)                      ");
                stringBuilder.AppendLine(" WHERE  InspResultDesc  Like '" + InspResultDesc + "%'          ");
                stringBuilder.AppendLine(" ORDER BY InspResultDesc                     ");
                return dBHelper.FillTable(Convert.ToString(stringBuilder));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public DataTable GET_BM0090_CODE(string sWHCode)
        {
            string name = new StackFrame().GetMethod().Name;
            DBHelper dBHelper = new DBHelper(false);
            StringBuilder stringBuilder = null;
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine("   SELECT  STORAGELOCCODE  AS CODE_ID,                               ");
                    stringBuilder.AppendLine("        '[' || STORAGELOCCODE ||']' + FN_Translate('" + Lang + "', STORAGELOCNAME,'BM0900') AS CODE_NAME     ");
                    stringBuilder.AppendLine("   FROM BM0090                                                      ");
                    stringBuilder.AppendLine("  WHERE WHCode LIKE '" + sWHCode.ToUpper() + "' || '%'                                    ");
                    stringBuilder.AppendLine("   ORDER BY WHCode, STORAGELOCCODE                                    ");
                }
                else
                {
                    stringBuilder.AppendLine("   SELECT  STORAGELOCCODE  AS CODE_ID,                               ");
                    stringBuilder.AppendLine("        '[' + STORAGELOCCODE +']' +  dbo.FN_Translate('" + Lang + "', STORAGELOCNAME,'BM0900') AS CODE_NAME     ");
                    stringBuilder.AppendLine("   FROM BM0090 WITH(NOLOCK)                                                     ");
                    stringBuilder.AppendLine("  WHERE WHCode LIKE " + sWHCode + " + '%'                                    ");
                    stringBuilder.AppendLine("   ORDER BY WHCode, STORAGELOCCODE                                    ");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }
        public DataTable GET_BM0090_CODE_ALL()
        {
            string name = new StackFrame().GetMethod().Name;
            DBHelper dBHelper = new DBHelper(false);
            StringBuilder stringBuilder = null;
            try
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
                if (dBHelper.ConType == "OracleConnection")
                {
                    stringBuilder.AppendLine("   SELECT  STORAGELOCCODE  AS CODE_ID,                               ");
                    stringBuilder.AppendLine("        '[' || STORAGELOCCODE ||']' + FN_Translate('" + Lang + "', STORAGELOCNAME,'BM0900') AS CODE_NAME     ");
                    stringBuilder.AppendLine("   FROM BM0090                                                      ");
                    //stringBuilder.AppendLine("  WHERE WHCode LIKE '" + sWHCode.ToUpper() + "' || '%'                                    ");
                    stringBuilder.AppendLine("   ORDER BY WHCode, STORAGELOCCODE                                    ");
                }
                else
                {
                    stringBuilder.AppendLine("   SELECT  STORAGELOCCODE  AS CODE_ID,                               ");
                    stringBuilder.AppendLine("        '[' + STORAGELOCCODE +']' +  dbo.FN_Translate('" + Lang + "', STORAGELOCNAME,'BM0900') AS CODE_NAME     ");
                    stringBuilder.AppendLine("   FROM BM0090 WITH(NOLOCK)                                                     ");
                    //stringBuilder.AppendLine("  WHERE WHCode LIKE " + sWHCode + " + '%'                                    ");
                    stringBuilder.AppendLine("   ORDER BY WHCode, STORAGELOCCODE                                    ");
                }
                return dBHelper.FillTable(Convert.ToString(stringBuilder));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), name);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public static void FillComboboxMaster(UltraCombo comboBox, object DataSource, string ValueField, string DisplayField, string InitText, string InitValue)
        {
            comboBox.DropDownStyle = UltraComboStyle.DropDown;
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            if (InitText != null && bPlantAuthALL)
            {
                list.Add(new KeyValuePair<string, string>(InitValue, InitText));
            }
            bPlantAuthALL = true;
            if (DataSource.GetType() == typeof(DataSet))
            {
                foreach (DataRow row in (DataSource as DataSet).Tables[0].Rows)
                {
                    list.Add(new KeyValuePair<string, string>(row[ValueField].ToString(), row[DisplayField].ToString()));
                }
            }
            else if (DataSource.GetType() == typeof(DataTable))
            {
                foreach (DataRow row2 in (DataSource as DataTable).Rows)
                {
                    list.Add(new KeyValuePair<string, string>(row2[ValueField].ToString(), row2[DisplayField].ToString()));
                }
            }
            else if (DataSource.GetType() == typeof(Dictionary<string, string>))
            {
                foreach (KeyValuePair<string, string> item in DataSource as Dictionary<string, string>)
                {
                    list.Add(item);
                }
            }
            comboBox.ValueMember = "Key";
            comboBox.DisplayMember = "Value";
            comboBox.DataSource = list;
            comboBox.MouseWheel += comboBox_MouseWheel;
        }

        public static void FillComboboxMaster(UltraComboEditor comboBox, object DataSource, string ValueField, string DisplayField, string InitText, string InitValue)
        {
            comboBox.DropDownStyle = DropDownStyle.DropDownList;
            comboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            if (InitText != null && bPlantAuthALL)
            {
                list.Add(new KeyValuePair<string, string>(InitValue, InitText));
            }
            bPlantAuthALL = true;
            if (DataSource.GetType() == typeof(DataSet))
            {
                foreach (DataRow row in (DataSource as DataSet).Tables[0].Rows)
                {
                    list.Add(new KeyValuePair<string, string>(row[ValueField].ToString(), row[DisplayField].ToString()));
                }
            }
            else if (DataSource.GetType() == typeof(DataTable))
            {
                foreach (DataRow row2 in (DataSource as DataTable).Rows)
                {
                    list.Add(new KeyValuePair<string, string>(row2[ValueField].ToString(), row2[DisplayField].ToString()));
                }
            }
            else if (DataSource.GetType() == typeof(Dictionary<string, string>))
            {
                foreach (KeyValuePair<string, string> item in DataSource as Dictionary<string, string>)
                {
                    list.Add(item);
                }
            }
            comboBox.ValueMember = "Key";
            comboBox.DisplayMember = "Value";
            comboBox.DataSource = list;
            comboBox.MouseWheel += comboBox_MouseWheel;
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }

        public static void FillComboboxMaster(ComboBox comboBox, object DataSource, string ValueField, string DisplayField, string InitText, string InitValue, bool bMakeComboEtcData = false, string selectValue = "")
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            if (InitText != null && bPlantAuthALL)
            {
                list.Add(new KeyValuePair<string, string>(InitValue, InitText));
            }
            bPlantAuthALL = true;
            if (DataSource.GetType() == typeof(DataSet))
            {
                foreach (DataRow row in (DataSource as DataSet).Tables[0].Rows)
                {
                    list.Add(new KeyValuePair<string, string>(row[ValueField].ToString(), row[DisplayField].ToString()));
                }
            }
            else if (DataSource.GetType() == typeof(DataTable))
            {
                foreach (DataRow row2 in (DataSource as DataTable).Rows)
                {
                    list.Add(new KeyValuePair<string, string>(row2[ValueField].ToString(), row2[DisplayField].ToString()));
                }
            }
            else if (DataSource.GetType() == typeof(Dictionary<string, string>))
            {
                foreach (KeyValuePair<string, string> item in DataSource as Dictionary<string, string>)
                {
                    list.Add(item);
                }
            }
            comboBox.ValueMember = "Key";
            comboBox.DisplayMember = "Value";
            comboBox.DataSource = list;
            comboBox.MouseWheel += comboBox_MouseWheel;
            if (comboBox.Items.Count > 0)
            {
                if (selectValue != null && selectValue != "")
                {
                    int num = 0;
                    foreach (KeyValuePair<string, string> item2 in comboBox.Items)
                    {
                        if (item2.Key == selectValue)
                        {
                            comboBox.SelectedIndex = num;
                            break;
                        }
                        num++;
                    }
                }
                else
                {
                    comboBox.SelectedIndex = 0;
                }
            }
        }

        public static void comboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
            try
            {
                if (((ComboBox)sender).SelectedIndex == 0)
                {
                    if (e.Delta / 120 == -1)
                    {
                        ((ComboBox)sender).SelectedIndex += e.Delta / 120 * -1;
                    }
                }
                else
                {
                    ((ComboBox)sender).SelectedIndex += e.Delta / 120 * -1;
                }
            }
            catch
            {
            }
        }

        public static void FillUltraComboboxMaster(UltraComboEditor comboBox, object DataSource, string ValueField, string DisplayField, string InitText, string InitValue)
        {
            comboBox.DropDownStyle = DropDownStyle.DropDownList;
            comboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            if (InitText != null)
            {
                list.Add(new KeyValuePair<string, string>(InitValue, InitText));
            }
            if (DataSource.GetType() == typeof(DataSet))
            {
                foreach (DataRow row in (DataSource as DataSet).Tables[0].Rows)
                {
                    list.Add(new KeyValuePair<string, string>(row[ValueField].ToString(), row[DisplayField].ToString()));
                }
            }
            else if (DataSource.GetType() == typeof(DataTable))
            {
                foreach (DataRow row2 in (DataSource as DataTable).Rows)
                {
                    list.Add(new KeyValuePair<string, string>(row2[ValueField].ToString(), row2[DisplayField].ToString()));
                }
            }
            else if (DataSource.GetType() == typeof(Dictionary<string, string>))
            {
                foreach (KeyValuePair<string, string> item in DataSource as Dictionary<string, string>)
                {
                    list.Add(item);
                }
            }
            comboBox.ValueMember = "Key";
            comboBox.DisplayMember = "Value";
            comboBox.DataSource = list;
            comboBox.MouseWheel += comboBox_MouseWheel;
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }

        public void Grid_Column_Width(UltraGrid grid)
        {
            string text = string.Empty;
            for (int i = 0; i < grid.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                text = text + Convert.ToString(grid.DisplayLayout.Bands[0].Columns[i].Width) + " ";
            }
            Clipboard.Clear();
            Clipboard.SetText(text);
        }

        private Control gGetControl(Control con, string name)
        {
            if (con == null)
            {
                return null;
            }
            if (con.Name == name)
            {
                return con;
            }
            foreach (Control control in con.Controls)
            {
                con = gGetControl(control, name);
                if (con != null)
                {
                    return con;
                }
            }
            return null;
        }

        public static Control gRemoveControl(Control con, string name)
        {
            if (con == null)
            {
                return null;
            }
            if (con.Name == name)
            {
                Control parent = con.Parent;
                parent.Controls.Remove(con);
                return null;
            }
            foreach (Control control in con.Controls)
            {
                con = gRemoveControl(control, name);
            }
            return null;
        }

        public static DataSet MultiGridRelations(DataTable DtTemp, bool Relations)
        {
            DataSet dataSet = new DataSet();
            int num = 1;
            for (int i = 1; i < DtTemp.Rows.Count; i++)
            {
                if (num < Convert.ToInt32(DtTemp.Rows[i]["LEVEL"]))
                {
                    num = Convert.ToInt32(DtTemp.Rows[i]["LEVEL"]);
                }
            }
            DataTable[] array = new DataTable[num];
            for (int j = 0; j < array.Length; j++)
            {
                array[j] = DtTemp.Clone();
                DataRow[] array2 = DtTemp.Select("LEVEL= '" + (j + 1) + "'");
                foreach (DataRow row in array2)
                {
                    array[j].ImportRow(row);
                    array[j].TableName = j.ToString();
                }
                dataSet.Tables.Add(array[j]);
            }
            int num2 = num - 1;
            for (int l = 0; l < num; l++)
            {
                if (num2 != l)
                {
                    dataSet.Relations.Add("MultiGrid" + l, dataSet.Tables[l].Columns["TAG_NAME"], dataSet.Tables[l + 1].Columns["TAG_NAME"], Relations);
                }
            }
            return dataSet;
        }

        public static Color FromStringToColor(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Color.Black;
            }
            if (name.Equals(""))
            {
                return Color.Black;
            }

            KnownColor result;

            if (Enum.TryParse(name, out result))
            {
                return Color.FromKnownColor(result);
            }
            if (name.IndexOf(",") < 0)
            {
                return Color.Black;
            }
            string[] array = name.Split(',');
            int alpha = 255;
            int red = 255;
            int green = 255;
            int blue = 255;
            string[] array2 = array;
            foreach (string text in array2)
            {
                string[] array3 = text.Split('=');
                if (array3[0].IndexOf("A") >= 0)
                {
                    alpha = Convert.ToInt32(array3[1]);
                }
                if (array3[0].IndexOf("R") >= 0)
                {
                    red = Convert.ToInt32(array3[1]);
                }
                if (array3[0].IndexOf("G") >= 0)
                {
                    green = Convert.ToInt32(array3[1]);
                }
                if (array3[0].IndexOf("B") >= 0)
                {
                    blue = Convert.ToInt32(array3[1]);
                }
            }
            return Color.FromArgb(alpha, red, green, blue);
        }

        public static string GetIPAddress()
        {
            string result = string.Empty;
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled='True'");
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(query);
            try
            {
                using (ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectSearcher.Get().GetEnumerator())
                {
                    if (managementObjectEnumerator.MoveNext())
                    {
                        ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
                        result = ((string[])managementObject["IPAddress"])[0];
                    }
                }
            }
            catch (Exception)
            {
                result = "127.0.0.1";
            }
            return result;
        }

        public enum FindControlEnum { NAME, TAG, TEXT };

        private static List<Control> cList = null;

        public static List<Control> FindControlList(Control control, string sText, FindControlEnum eEnum = FindControlEnum.NAME, bool bAllText = false)
        {
            cList = new List<Control>();

            FindControlListSub(control, sText, eEnum, bAllText);

            return cList;
        }

        private static void FindControlListSub(Control control, string sText, FindControlEnum eEnum = FindControlEnum.NAME, bool bAllText = false)
        {
            if (CheckControl(control, sText, eEnum, bAllText))
            {
                cList.Add(control);
            }

            foreach (Control c in control.Controls)
            {
                FindControlListSub(c, sText, eEnum, bAllText);
            }
        }

        private static bool CheckControl(Control con, string sText, FindControlEnum eEnum, bool bAllText)
        {
            if (con == null)
            {
                return false;
            }

            sText = sText.ToUpper();

            switch (eEnum)
            {
                case FindControlEnum.NAME:
                    if (bAllText)
                    {
                        if (con.Name.ToUpper() == sText)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (con.Name.ToUpper().Contains(sText))
                        {
                            return true;
                        }
                    }
                    break;
                case FindControlEnum.TEXT:
                    if (bAllText)
                    {
                        if (con.Text.ToUpper() == sText)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (con.Text.ToUpper().Contains(sText))
                        {
                            return true;
                        }
                    }
                    break;
                case FindControlEnum.TAG:

                    if (bAllText)
                    {
                        if (CModule.ToString(con.Tag).ToUpper() == sText)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (CModule.ToString(con.Tag).ToUpper().Contains(sText))
                        {
                            return true;
                        }
                    }
                    break;
            }

            return false;
        }

        public static Control FindControl(Control.ControlCollection controlcollection, string controlid)
        {
            if (controlcollection[controlid] != null)
            {
                return controlcollection[controlid];
            }
            for (int i = 0; i < controlcollection.Count; i++)
            {
                Control control = FindControl(controlcollection[i].Controls, controlid);
                if (control != null)
                {
                    return control;
                }
            }
            return null;
        }

        public static string getLangText(string cText)
        {
            return getLangText(cText, "");
        }

        public static string getLangText(string cText, string cOp)
        {
            if (Lang == "KO")
            {
                return cText;
            }
            if (langTable == null)
            {
                DBHelper dBHelper = new DBHelper(completedClose: true);
                langTable = dBHelper.FillTable("USP_SY0090_S2", CommandType.StoredProcedure);
                langTable.PrimaryKey = new DataColumn[2]
                {
                    langTable.Columns["WKEY"],
                    langTable.Columns["OPKEY"]
                };
            }
            DataRowCollection rows = langTable.Rows;
            object[] keys = new string[2]
            {
                cText,
                cOp
            };
            DataRow dataRow = rows.Find(keys);
            if (dataRow != null)
            {
                return dataRow["Translate"].ToString();
            }
            DBHelper dBHelper2 = new DBHelper(false);
            try
            {
                cText = dBHelper2.ExecuteScalar("USP_SY0090_S3", CommandType.StoredProcedure, dBHelper2.CreateParameter("wKey", cText, DbType.String, ParameterDirection.Input), dBHelper2.CreateParameter("OpKey", cOp, DbType.String, ParameterDirection.Input)).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dBHelper2.Close();
            }
            return cText;
        }

        public static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            MemoryStream memoryStream = new MemoryStream();
            Rijndael rijndael = Rijndael.Create();
            rijndael.Key = Key;
            rijndael.IV = IV;
            CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(clearData, 0, clearData.Length);
            cryptoStream.Close();
            return memoryStream.ToArray();
        }

        public static string EncryptString(string InputText)
        {
            if (InputText.Length == 0)
            {
                return "";
            }
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            byte[] bytes = Encoding.Unicode.GetBytes(InputText);
            byte[] bytes2 = Encoding.ASCII.GetBytes(passkey.Length.ToString());
            PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(passkey, bytes2);
            ICryptoTransform transform = rijndaelManaged.CreateEncryptor(passwordDeriveBytes.GetBytes(32), passwordDeriveBytes.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] inArray = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(inArray);
        }

        public static string DecryptString(string InputText)
        {
            if (InputText.Length == 0)
            {
                return "";
            }
            string result = "";
            try
            {
                RijndaelManaged rijndaelManaged = new RijndaelManaged();
                byte[] array = Convert.FromBase64String(InputText);
                byte[] bytes = Encoding.ASCII.GetBytes(passkey.Length.ToString());
                PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(passkey, bytes);
                ICryptoTransform transform = rijndaelManaged.CreateDecryptor(passwordDeriveBytes.GetBytes(32), passwordDeriveBytes.GetBytes(16));
                MemoryStream memoryStream = new MemoryStream(array);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
                byte[] array2 = new byte[array.Length];
                int count = cryptoStream.Read(array2, 0, array2.Length);
                memoryStream.Close();
                cryptoStream.Close();
                result = Encoding.Unicode.GetString(array2, 0, count);
            }
            catch
            {
            }
            return result;
        }

        public static string MD5Hash(string Data)
        {
            if (Data.Length == 0)
            {
                return "";
            }
            MD5 mD = new MD5CryptoServiceProvider();
            byte[] array = mD.ComputeHash(Encoding.ASCII.GetBytes(Data));
            StringBuilder stringBuilder = new StringBuilder();
            byte[] array2 = array;
            foreach (byte b in array2)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }

        [DllImport("user32.dll")]
        private static extern IntPtr CreateIconIndirect(ref IconInfo icon);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);

        public static Cursor CreateCursor(string str)
        {
            Font font = new Font(FontFamily.GenericSansSerif, 10f, FontStyle.Bold);
            SizeF sizeF;
            using (Bitmap image = new Bitmap(1, 1))
            {
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    sizeF = graphics.MeasureString(str, font);
                }
            }
            Bitmap bitmap = new Bitmap((int)Math.Ceiling(sizeF.Width), (int)Math.Ceiling(sizeF.Height));
            using (Graphics graphics2 = Graphics.FromImage(bitmap))
            {
                graphics2.DrawString(str, font, Brushes.Black, 0f, 0f);
            }
            IconInfo icon = default(IconInfo);
            GetIconInfo(bitmap.GetHicon(), ref icon);
            icon.xHotspot = 0;
            icon.yHotspot = 0;
            icon.fIcon = false;
            Cursor result = new Cursor(CreateIconIndirect(ref icon));
            bitmap.Dispose();
            font.Dispose();
            return result;
        }

        public static bool LicenseChek()
        {
            if (bLicense != "")
            {
                return (bLicense == "T") ? true : false;
            }
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string text = configuration.ConnectionStrings.ConnectionStrings["ConnectionString"].ConnectionString;
                if (configuration.AppSettings.Settings["ENCRYTION"].Value == "YES")
                {
                    text = DecryptString(text);
                }
                text = text.ToUpper();
                int i = text.IndexOf("DATA SOURCE");
                if (i == -1)
                {
                    i = text.IndexOf("HOST");
                }
                if (i == -1)
                {
                    bLicense = "F";
                    return false;
                }
                string text2 = "";
                int num = 0;
                for (; i < text.Length; i++)
                {
                    string text3 = text.Substring(i, 1);
                    if (text3 == "." || (text3.CompareTo("0") >= 0 && text3.CompareTo("9") <= 0))
                    {
                        text2 += text3;
                        if (text3 == ".")
                        {
                            num++;
                        }
                    }
                    else if (num == 3)
                    {
                        break;
                    }
                }
                string text4 = passkey;
                passkey = "WIZcomputerpk";
                text = EncryptString(text2);
                passkey = text4;
                try
                {
                    string value = configuration.AppSettings.Settings["SMCLicense1"].Value;
                    if (text == value)
                    {
                        bLicense = "T";
                        return true;
                    }
                    value = configuration.AppSettings.Settings["SMCLicense2"].Value;
                    if (text == value)
                    {
                        bLicense = "T";
                        return true;
                    }
                    value = configuration.AppSettings.Settings["SMCLicense3"].Value;
                    if (text == value)
                    {
                        bLicense = "T";
                        return true;
                    }
                    value = configuration.AppSettings.Settings["SMCLicense4"].Value;
                    if (text == value)
                    {
                        bLicense = "T";
                        return true;
                    }
                    value = configuration.AppSettings.Settings["SMCLicense5"].Value;
                    if (text == value)
                    {
                        bLicense = "T";
                        return true;
                    }
                }
                catch
                {
                }
                bLicense = "F";
                return false;
            }
            catch
            {
            }
            bLicense = "";
            return true;
        }

        public void SetPlantAuth()
        {
            if (dtPlantAuth == null)
            {
                DBHelper dBHelper = new DBHelper(completedClose: true);
                dtPlantAuth = dBHelper.FillTable("SELECT PlantCode FROM TSY0301 where WorkerID='" + LoginInfo.UserID + "'");
            }
            bPlantAuthALL = true;
            if (rtnDtTemp.Rows.Count == dtPlantAuth.Rows.Count)
            {
                return;
            }
            int num = rtnDtTemp.Rows.Count - 1;
            while (0 <= num)
            {
                bool flag = false;
                foreach (DataRow row in dtPlantAuth.Rows)
                {
                    if (rtnDtTemp.Rows[num]["CODE_ID"].ToString() == row["PlantCode"].ToString())
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    rtnDtTemp.Rows.RemoveAt(num);
                }
                num--;
            }
            if (rtnDtTemp.Rows.Count < 2)
            {
                bPlantAuthALL = false;
            }
        }

        public string INSP_OKNG(string sSpecType, double dUSL, double dLSL, double dInspValue)
        {
            string result = string.Empty;
            if (sSpecType == "N")
            {
                result = "X";
            }
            else if (sSpecType == "D")
            {
                result = ((!(dInspValue >= dLSL) || !(dInspValue <= dUSL)) ? "NG" : "OK");
            }
            else if (sSpecType == "U")
            {
                result = ((!(dInspValue <= dUSL)) ? "NG" : "OK");
            }
            else if (sSpecType == "L")
            {
                result = ((!(dInspValue >= dLSL)) ? "NG" : "OK");
            }
            return result;
        }

        public static bool isYYYYMMDD(string sDate)
        {
            string[] formats = new string[2]
            {
                "yyyyMMdd",
                "yyyy-MM-dd"
            };


            DateTime dt;

            if (!DateTime.TryParseExact(sDate, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
            {
                return false;
            }
            return true;
        }

        public static bool isYYYY_MM_DD(string sDate)
        {
            string[] formats = new string[2]
            {
                "yyyyMMdd",
                "yyyy-MM-dd"
            };

            DateTime dt;

            if (!DateTime.TryParseExact(sDate, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
            {
                return false;
            }
            return true;
        }

        private DataTable GetExcel(string sFilePath)
        {
            string empty;//= string.Empty;
            empty = ((sFilePath.IndexOf(".xlsx") <= -1) ? ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFilePath + ";Extended Properties='Excel 8.0;HDR=No'") : ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sFilePath + ";Extended Properties='Excel 12.0;;HDR=No;IMEX=1'"));
            DataTable dataTable = null;
            OleDbDataAdapter oleDbDataAdapter;// = null;
            using (OleDbConnection oleDbConnection = new OleDbConnection(empty))
            {
                oleDbConnection.Open();
                DataTable oleDbSchemaTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string arg = oleDbSchemaTable.Rows[0]["TABLE_NAME"].ToString();
                string selectCommandText = " SELECT * FROM [{arg}] ";
                dataTable = new DataTable();
                oleDbDataAdapter = new OleDbDataAdapter(selectCommandText, oleDbConnection);
                oleDbDataAdapter.Fill(dataTable);
            }
            return dataTable;
        }

        public static DataTable GetFTPFileList(string sOrderNOTemp)
        {
            DataTable dataTable = new DataTable();
            List<string> list = new List<string>();
            try
            {
                string[] array = gsFTPSite.Split(';');
                string requestUriString = "ftp://{array[0]}/{sOrderNOTemp}";
                string userName = array[1];
                string password = array[2];
                FtpWebRequest ftpWebRequest = WebRequest.Create(requestUriString) as FtpWebRequest;
                ftpWebRequest.Credentials = new NetworkCredential(userName, password);
                ftpWebRequest.Method = "NLST";
                StreamReader streamReader = new StreamReader(ftpWebRequest.GetResponse().GetResponseStream());
                while (true)
                {
                    string text = streamReader.ReadLine();
                    if (string.IsNullOrEmpty(text))
                    {
                        break;
                    }
                    list.Add(text);
                }
                streamReader.Close();
                dataTable.Columns.Add("DRAWING", typeof(Image));
                dataTable.Columns.Add("FILENAME", typeof(string));
                foreach (string item in list)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["DRAWING"] = (Image)WIZ.Properties.Resources.ResourceManager.GetObject("Drawing");
                    dataRow["FILENAME"] = item;
                    dataTable.Rows.Add(dataRow);
                }
                return dataTable;
            }
            catch
            {
                return dataTable;
            }
        }

        public static Tuple<string, Image> DownloadFileFromFTP(string sOrderNOTemp, string sFileNameTemp)
        {
            Tuple<string, Image> result = null;
            Image image;//= null;
            try
            {
                string[] array = gsFTPSite.Split(';');
                string uriString = "ftp://{array[0]}/{sOrderNOTemp}/{sFileNameTemp}";
                string userName = array[1];
                string password = array[2];
                FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(uriString));
                ftpWebRequest.Method = "RETR";
                ftpWebRequest.UseBinary = true;
                ftpWebRequest.UsePassive = true;
                ftpWebRequest.Credentials = new NetworkCredential(userName, password);
                string path = Application.StartupPath + "\\FTPDown";
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                }
                using (FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse())
                {
                    Stream responseStream = ftpWebResponse.GetResponseStream();
                    MemoryStream memoryStream = new MemoryStream();
                    string text = string.Format("{0}\\{1}\\{2}", Application.StartupPath, "FTPDown", sFileNameTemp);
                    FileInfo fileInfo = new FileInfo(text);
                    FileStream fileStream = null;
                    if (!fileInfo.Exists)
                    {
                        fileStream = new FileStream(text, FileMode.Create, FileAccess.Write);
                    }
                    byte[] array2 = new byte[1024];
                    while (true)
                    {
                        int num = responseStream.Read(array2, 0, array2.Length);
                        if (num == 0)
                        {
                            break;
                        }
                        memoryStream.Write(array2, 0, num);
                        if (!fileInfo.Exists)
                        {
                            fileStream.Write(array2, 0, num);
                        }
                    }
                    memoryStream.Position = 0L;
                    try
                    {
                        image = Image.FromStream(memoryStream);
                    }
                    catch
                    {
                        image = (Image)WIZ.Properties.Resources.ResourceManager.GetObject("NoImage");
                    }
                    result = new Tuple<string, Image>(text, image);
                    fileStream.Close();
                    memoryStream.Close();
                    responseStream.Close();
                    ftpWebResponse.Close();
                    return result;
                }
            }
            catch (Exception)
            {
                return result;
            }
        }
        public static void SendData(string IP, string ZPL)
        {
            Socket socket = null;
            IPEndPoint printerIP = null;
            NetworkStream ns = null;

            try
            {
                Thread.Sleep(500);

                if (IP == string.Empty)
                {
                    IP = "192.168.100.251";
                }

                if (printerIP == null)
                {
                    /* 6101 is the common port of all our Zebra printers. */
                    printerIP = new IPEndPoint(IPAddress.Parse(IP), 6101);
                }

                socket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);
                socket.Connect(printerIP);

                ns = new NetworkStream(socket);
                byte[] toSend = ASCIIEncoding.ASCII.GetBytes(ZPL);
                ns.Write(toSend, 0, toSend.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (ns != null)
                    ns.Close();

                if (socket != null && socket.Connected)
                    socket.Close();
            }
        }

        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError;// = 0;
            Int32 dwWritten;//= 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "Zebra RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendStringToBytePrinter(string szPrinterName, string szString)
        {
            string tPrinterName = string.Empty;

            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (printer.Contains(szPrinterName))
                {
                    tPrinterName = printer;
                }
            }

            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            //pBytes = Marshal.StringToCoTaskMemAnsi(szString);

            Byte[] bytes = Encoding.Default.GetBytes(szString);

            bool bSuccess;// = false;
                          // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(bytes.Length);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(tPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }

        public class DateCheck
        {
            public static bool CheckDate(string sDate, string eDate)
            {
                int Start = int.Parse(string.Format("{0:yyyyMMdd}", sDate.Replace("-", "")));
                int End = int.Parse(string.Format("{0:yyyyMMdd}", eDate.Replace("-", "")));

                if (Start > End)
                    return false;
                else
                    return true;
            }
        }

        public class CustomMergedCellEvalutor : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
        {
            string Col1 = string.Empty;
            string Col2 = string.Empty;

            public CustomMergedCellEvalutor(string pCol1, string pCol2)
            {
                Col1 = pCol1;
                Col2 = pCol2;
            }

            public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn col)
            {
                try
                {
                    if (row1.GetCellValue(Col1).GetType().ToString() != "System.DBNull"
                        && row2.GetCellValue(Col1).GetType().ToString() != "System.DBNull"
                        && row1.GetCellValue(Col2).GetType().ToString() != "System.DBNull"
                        && row2.GetCellValue(Col2).GetType().ToString() != "System.DBNull")
                    {
                        string value1 = (string)row1.GetCellValue(Col1);
                        string value2 = (string)row2.GetCellValue(Col1);

                        string value3 = (string)row1.GetCellValue(Col2);
                        string value4 = (string)row2.GetCellValue(Col2);

                        return (value1 + value3) == (value2 + value4);
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Control 에 포함된 Contol 중 TextBox, STextBox, UltraComboEditor, ComboBox 에 대한 항목들 초기화
        /// </summary>
        /// <param name="con"></param>
        /// <param name="sText"></param>
        public static void DoInit(System.Windows.Forms.Control con, string sText = "")
        {
            foreach (System.Windows.Forms.Control c in con.Controls)
            {
                switch (c.GetType().Name.ToUpper())
                {
                    case "STEXTBOX":
                    case "TEXTBOX":
                    case "MASKEDTEXTBOX":
                        {
                            c.Text = sText;
                        }
                        break;
                    case "ULTRACOMBOEDITOR":
                        {
                            Infragistics.Win.UltraWinEditors.UltraComboEditor e = c as Infragistics.Win.UltraWinEditors.UltraComboEditor;

                            if (e != null)
                            {
                                if (e.Items.Count > 0)
                                {
                                    e.SelectedIndex = 0;
                                }
                            }
                        }
                        break;
                    case "COMBOBOX":
                        {
                            ComboBox e = c as ComboBox;

                            if (e != null)
                            {
                                if (e.Items.Count > 0)
                                {
                                    e.SelectedIndex = 0;
                                }
                            }
                        }
                        break;

                }
            }
        }
    }
}

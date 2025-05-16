using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WIZ
{
    public class FnUtil
    {
        public static bool isDate(string date)
        {
            date = isNull(date);
            date = date.Replace("-", "").Replace("/", "");
            if (date.Length != 8 || !isNumeric(date))
            {
                return false;
            }
            CultureInfo cultureInfo = new CultureInfo(CultureInfo.CurrentCulture.Name);
            date = date.Substring(0, 4) + cultureInfo.DateTimeFormat.DateSeparator + date.Substring(4, 2) + cultureInfo.DateTimeFormat.DateSeparator + date.Substring(6);
            DateTime result;
            return DateTime.TryParse(date, out result);
        }

        public static string isNull(string source)
        {
            return isNull(source, "");
        }

        public static string isNull(string source, string target)
        {
            if (source != null && !(source == ""))
            {
                return source;
            }
            return target;
        }

        public static bool isNumeric(string source)
        {
            if (source == null)
            {
                return false;
            }
            return Regex.IsMatch(source, "^([1-9]\\d*)$|^0$");
        }

        public static bool CheckDateMinValue(string date, string minDate)
        {
            string date2 = "";
            string date3 = "";
            if (date.Length == 6)
            {
                date2 = date + "01";
            }
            if (date.Length == 4)
            {
                date2 = date + "0101";
            }
            if (minDate.Length == 6)
            {
                date3 = minDate + "01";
            }
            if (minDate.Length == 4)
            {
                date3 = minDate + "0101";
            }
            if (!isDate(date2))
            {
                MessageBox.Show(string.Format(Common.getLangText("비교 대상 값 [{0}]이 올바른 날짜형식이 아닙니다."), date), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (!isDate(date3))
            {
                MessageBox.Show(string.Format(Common.getLangText("비교 값 [{0}]이 올바른 날짜형식이 아닙니다."), minDate), Common.getLangText("입력오류"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (getDateTime(date2) < getDateTime(date3))
            {
                return false;
            }
            return true;
        }

        public static DateTime getDateTime(string date)
        {
            if (!isDate(date))
            {
                return new DateTime(1900, 1, 1);
            }
            date = date.Replace("-", "").Replace("/", "");
            return new DateTime(int.Parse(date.Substring(0, 4)), int.Parse(date.Substring(4, 2)), int.Parse(date.Substring(6)));
        }

        public static bool CheckDateMaxValue(string date, string maxDate)
        {
            string date2 = "";
            string date3 = "";
            if (date.Length == 6)
            {
                date2 = date + "01";
            }
            if (date.Length == 4)
            {
                date2 = date + "0101";
            }
            if (maxDate.Length == 6)
            {
                date3 = maxDate + "01";
            }
            if (maxDate.Length == 4)
            {
                date3 = maxDate + "0101";
            }
            if (!isDate(date2))
            {
                MessageBox.Show(string.Format(Common.getLangText("비교 대상 값 [{0}]이 올바른 날짜형식이 아닙니다."), date), "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (!isDate(date3))
            {
                MessageBox.Show(string.Format(Common.getLangText("비교 값 [{0}]이 올바른 날짜형식이 아닙니다."), maxDate), "입력오류", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (getDateTime(date2) > getDateTime(date3))
            {
                return false;
            }
            return true;
        }

        public static bool ChekcStringMaxLength(string inData, int maxLength)
        {
            if (fnStringByteLength(inData) > maxLength)
            {
                return false;
            }
            return true;
        }

        public static int fnStringByteLength(string stringLength)
        {
            return Encoding.GetEncoding(0).GetByteCount(stringLength);
        }

        public static bool isInt(string source)
        {
            if (source == null)
            {
                return false;
            }
            int result;
            return int.TryParse(source, out result);
        }

        public static bool CheckDataMinValue(int inData, int maxValue)
        {
            if (inData < maxValue)
            {
                return false;
            }
            return true;
        }

        public static bool CheckDataMinValue(string inData, decimal maxValue)
        {
            if (decimal.Parse(inData) < maxValue)
            {
                return false;
            }
            return true;
        }

        public static bool CheckDataMinValue(string inData, int maxValue)
        {
            if (int.Parse(inData) < maxValue)
            {
                return false;
            }
            return true;
        }

        public static bool CheckDataMinValue(string inData, string maxValue)
        {
            decimal d = decimal.Parse(inData);
            decimal d2 = decimal.Parse(maxValue);
            if (d < d2)
            {
                return false;
            }
            return true;
        }

        public static bool CheckDataMaxValue(int inData, int maxValue)
        {
            if (inData > maxValue)
            {
                return false;
            }
            return true;
        }

        public static bool CheckDataMaxValue(string inData, decimal maxValue)
        {
            if (decimal.Parse(inData) > maxValue)
            {
                return false;
            }
            return true;
        }

        public static bool CheckDataMaxValue(string inData, int maxValue)
        {
            if (int.Parse(inData) > maxValue)
            {
                return false;
            }
            return true;
        }

        public static bool CheckDataMaxValue(string inData, string maxValue)
        {
            decimal d = decimal.Parse(inData);
            decimal d2 = decimal.Parse(maxValue);
            if (d > d2)
            {
                return false;
            }
            return true;
        }

        public static bool isDecimal(string source)
        {
            if (source == null)
            {
                return false;
            }
            decimal result;
            return decimal.TryParse(source, out result);
        }
    }
}

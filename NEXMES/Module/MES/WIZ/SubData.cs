using System;
using System.Data;
using System.Text;

namespace WIZ
{
    public class SubData
    {
        private DataTable dt;

        public int GetRowCount()
        {
            if (dt == null)
            {
                return 0;
            }

            return dt.Rows.Count;
        }

        public SubData(string sFormName)
        {
            SetSubData(sFormName);
        }

        private void SetSubData(string sFormName)
        {
            StringBuilder sSQL = new StringBuilder();

            sSQL.Append("SELECT * from TSY0230 with (NOLOCK) " + Environment.NewLine);
            sSQL.Append(" where FORM_ID = '" + sFormName + "' " + Environment.NewLine);
            sSQL.Append(" order by Seq ");

            DBHelper db = new DBHelper();

            try

            {
                dt = db.FillTable(sSQL.ToString());

            }
            catch (Exception ex)
            {

            }
            finally
            {
                db.Close();
            }
        }

        public string this[int iRow, string sColName]
        {
            get
            {
                if (iRow + 1 >= dt.Rows.Count)
                {
                    return "";
                }

                if (dt.Columns.Contains(sColName))
                {
                    return DBHelper.nvlString(dt.Rows[iRow][sColName]);
                }

                return "";
            }
        }

        public string this[string sColName]
        {
            get
            {
                if (dt.Rows.Count == 0)
                {
                    return "";
                }

                if (dt.Columns.Contains(sColName))
                {
                    return DBHelper.nvlString(dt.Rows[0][sColName]);
                }

                return "";
            }
        }

        public string this[int iColIndex]
        {
            get
            {
                if (dt.Rows.Count == 0)
                {
                    return "";
                }

                if (dt.Columns.Count <= iColIndex)
                {
                    return DBHelper.nvlString(dt.Rows[0][iColIndex]);
                }

                return "";
            }
        }

        public DataRow this[string sColName, string sColData]
        {
            get
            {
                if (dt.Rows.Count == 0)
                {
                    return null;
                }

                if (dt.Columns.Contains(sColName))
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        string sValue = CModule.ToString(dr[sColName]);

                        if (sValue == sColData)
                        {
                            return dr;
                        }
                    }
                }

                return null;
            }
        }
    }
}

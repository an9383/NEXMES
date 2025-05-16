using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace WIZ.WM
{
    public enum AggregateFunction
    {
        Count = 1,
        Sum = 2,
        First = 3,
        Last = 4,
        Average = 5,
        Max = 6,
        Min = 7,
        Exists = 8
    }

    public class Pivot
    {
        public Pivot(DataTable SourceTable)
        {
            //_SourceTable = SourceTable;
            //_Source = SourceTable.Rows.Cast<DataRow>();
        }

        /// <summary>
        /// Pivots the DataTable based on provided RowField, DataField, Aggregate Function and ColumnFields.//
        /// </summary>
        /// <param name="rowField">The column name of the Source Table which you want to spread into rows</param>
        /// <param name="dataField">The column name of the Source Table which you want to spread into Data Part</param>
        /// <param name="aggregate">The Aggregate function which you want to apply in case matching data found more than once</param>
        /// <param name="columnFields">The List of column names which you want to spread as columns</param>
        /// <returns>A DataTable containing the Pivoted Data</returns>
        public static DataTable PivotData(DataTable dtsource, string rowField, string dataField, AggregateFunction aggregate, params string[] columnFields)
        {
            DataTable dt = new DataTable();
            IEnumerable<DataRow> source = new List<DataRow>();
            source = dtsource.Rows.Cast<DataRow>();

            string Separator = ".";
            List<string> rowList = source.Select(x => x[rowField].ToString()).Distinct().ToList();
            // Gets the list of columns .(dot) separated.
            var colList = source.Select(x => (columnFields.Select(n => x[n]).Aggregate((a, b) => a += Separator + b.ToString())).ToString()).Distinct().OrderBy(m => m);

            dt.Columns.Add(rowField);
            foreach (var colName in colList) dt.Columns.Add(colName);

            foreach (string rowName in rowList)
            {
                DataRow row = dt.NewRow();
                row[rowField] = rowName;
                foreach (string colName in colList)
                {
                    string strFilter = rowField + " = '" + rowName + "'";
                    string[] strColValues = colName.Split(Separator.ToCharArray(), StringSplitOptions.None);
                    for (int i = 0; i < columnFields.Length; i++)
                        strFilter += " and " + columnFields[i] + " = '" + strColValues[i] + "'";
                    row[colName] = GetData(dtsource, strFilter, dataField, aggregate);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        public static DataTable PivotData(DataTable dtsource, string dataField, AggregateFunction aggregate, string rowField, bool showSubTotal, params string[] columnFields)
        {
            DataTable dt = new DataTable();
            IEnumerable<DataRow> source = new List<DataRow>();
            source = dtsource.Rows.Cast<DataRow>();

            string Separator = ".";
            List<string> rowList = source.Select(x => x[rowField].ToString()).Distinct().ToList();
            // Gets the list of columns .(dot) separated.
            List<string> colList = source.Select(x => columnFields.Aggregate((a, b) => x[a].ToString() + Separator + x[b].ToString())).Distinct().OrderBy(m => m).ToList();

            if (showSubTotal && columnFields.Length > 1)
            {
                string totalField = string.Empty;
                for (int i = 0; i < columnFields.Length - 1; i++)
                    totalField += columnFields[i] + "(Total)" + Separator;
                List<string> totalList = source.Select(x => totalField + x[columnFields.Last()].ToString()).Distinct().OrderBy(m => m).ToList();
                colList.InsertRange(0, totalList);
            }

            dt.Columns.Add(rowField);
            colList.ForEach(x => dt.Columns.Add(x));

            foreach (string rowName in rowList)
            {
                DataRow row = dt.NewRow();
                row[rowField] = rowName;
                foreach (string colName in colList)
                {
                    string filter = rowField + " = '" + rowName + "'";
                    string[] colValues = colName.Split(Separator.ToCharArray(), StringSplitOptions.None);
                    for (int i = 0; i < columnFields.Length; i++)
                        if (!colValues[i].Contains("(Total)"))
                            filter += " and " + columnFields[i] + " = '" + colValues[i] + "'";
                    row[colName] = GetData(dtsource, filter, dataField, colName.Contains("(Total)") ? AggregateFunction.Sum : aggregate);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        public static DataTable PivotData(DataTable dtsource, string DataField, AggregateFunction Aggregate, string[] RowFields, string[] ColumnFields)
        {
            DataTable dt = new DataTable();
            IEnumerable<DataRow> source = new List<DataRow>();
            source = dtsource.Rows.Cast<DataRow>();

            string Separator = ".";
            var RowList = dtsource.DefaultView.ToTable(true, RowFields).AsEnumerable().ToList();
            for (int index = RowFields.Count() - 1; index >= 0; index--)
                RowList = RowList.OrderBy(x => x.Field<object>(RowFields[index])).ToList();
            // Gets the list of columns .(dot) separated.
            var ColList = (from x in dtsource.AsEnumerable()
                           select new
                           {
                               Name = ColumnFields.Select(n => x.Field<object>(n))
                                   .Aggregate((a, b) => a += Separator + b.ToString())
                           })
                               .Distinct()
                               .OrderBy(m => m.Name);

            //dt.Columns.Add(RowFields);
            foreach (string s in RowFields)
                dt.Columns.Add(s);

            foreach (var col in ColList)
                dt.Columns.Add(col.Name.ToString());  // Cretes the result columns.//

            foreach (var RowName in RowList)
            {
                DataRow row = dt.NewRow();
                string strFilter = string.Empty;

                foreach (string Field in RowFields)
                {
                    row[Field] = RowName[Field];
                    strFilter += " and " + Field + " = '" + Regex.Replace(RowName[Field].ToString(), "'", "''") + "'";
                }
                strFilter = strFilter.Substring(5);

                foreach (var col in ColList)
                {
                    string filter = strFilter;
                    string[] strColValues = col.Name.ToString().Split(Separator.ToCharArray(), StringSplitOptions.None);
                    for (int i = 0; i < ColumnFields.Length; i++)
                        filter += " and " + ColumnFields[i] + " = '"
                               + Regex.Replace(strColValues[i].ToString(), "'", "''") + "'";
                    row[col.Name.ToString()] = GetData(dtsource, filter, DataField, Aggregate);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        public static DataTable PivotData(DataTable dtsource, string[] datafields, AggregateFunction aggregate, string[] rowfields, string[] columnfields)
        {
            DataTable dt = new DataTable();
            IEnumerable<DataRow> source = new List<DataRow>();

            source = dtsource.Rows.Cast<DataRow>();

            string separator = ".";
            var rowlist = dtsource.DefaultView.ToTable(true, rowfields).AsEnumerable().ToList();
            for (int i = rowfields.Count() - 1; i >= 0; i--)
                rowlist = rowlist.OrderBy(x => x.Field<object>(rowfields[i])).ToList();
            // Gets the list of columns .(dot) separated.
            var collist = (from x in dtsource.AsEnumerable()
                           select new
                           {
                               Name = columnfields.Select(n => x.Field<object>(n))
                                        .Aggregate((a, b) => a += separator + b.ToString())
                           }
                           )
                           .Distinct()
                           .OrderBy(m => m.Name);

            foreach (string s in rowfields)
                dt.Columns.Add(s);

            foreach (var col in collist)
            {
                if (datafields.Length == 1)
                {
                    dt.Columns.Add(col.Name.ToString());
                    continue;
                }
                for (int i = 0; i < datafields.Length; i++)
                    dt.Columns.Add(datafields[i] + "_" + col.Name.ToString());
            }


            foreach (var RowName in rowlist)
            {
                DataRow row = dt.NewRow();
                string strFilter = string.Empty;

                foreach (string Field in rowfields)
                {
                    row[Field] = RowName[Field];
                    strFilter += " and " + Field + " = '" + Regex.Replace(RowName[Field].ToString(), "'", "''") + "'";
                }
                strFilter = strFilter.Substring(5);

                foreach (var col in collist)
                {
                    string filter = strFilter;
                    string[] strColValues = col.Name.ToString().Split(separator.ToCharArray(), StringSplitOptions.None);
                    for (int i = 0; i < columnfields.Length; i++)
                        filter += " and " + columnfields[i] + " = '"
                                + Regex.Replace(strColValues[i].ToString(), "'", "''") + "'";

                    if (datafields.Length == 1)
                    {
                        row[col.Name.ToString()] = GetData(dtsource, filter, datafields[0], aggregate);
                        continue;
                    }
                    else
                    {
                        for (int j = 0; j < datafields.Length; j++)
                            row[datafields[j] + "_" + col.Name.ToString()] = GetData(dtsource, filter, datafields[j], aggregate);
                    }
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        public static DataTable PivotData(DataTable dtsource
                                         , string[] rowfields, string[] columnfields, string[] datafields, AggregateFunction aggregate)
        {
            DataTable dt = new DataTable();
            IEnumerable<DataRow> source = new List<DataRow>();

            source = dtsource.Rows.Cast<DataRow>();

            string separator = ".";
            var rowlist = dtsource.DefaultView.ToTable(true, rowfields).AsEnumerable().ToList();
            for (int i = rowfields.Count() - 1; i >= 0; i--)
                rowlist = rowlist.OrderBy(x => x.Field<object>(rowfields[i])).ToList();
            // Gets the list of columns .(dot) separated.
            var collist = (from x in dtsource.AsEnumerable()
                           select new
                           {
                               Name = columnfields.Select(n => x.Field<object>(n))
                                        .Aggregate((a, b) => a += separator + b.ToString())
                           }
                           )
                           .Distinct()
                           .OrderBy(m => m.Name);

            foreach (string s in rowfields)
                dt.Columns.Add(s);

            foreach (var col in collist)
            {
                if (datafields.Length == 1)
                {
                    dt.Columns.Add(col.Name.ToString());
                    continue;
                }
                for (int i = 0; i < datafields.Length; i++)
                    dt.Columns.Add(datafields[i] + "_" + col.Name.ToString());
            }


            foreach (var RowName in rowlist)
            {
                DataRow row = dt.NewRow();
                string strFilter = string.Empty;

                foreach (string Field in rowfields)
                {
                    row[Field] = RowName[Field];
                    strFilter += " and " + Field + " = '" + Regex.Replace(RowName[Field].ToString(), "'", "''") + "'";
                }
                strFilter = strFilter.Substring(5);

                foreach (var col in collist)
                {
                    string filter = strFilter;
                    string[] strColValues = col.Name.ToString().Split(separator.ToCharArray(), StringSplitOptions.None);
                    for (int i = 0; i < columnfields.Length; i++)
                        filter += " and " + columnfields[i] + " = '"
                                + Regex.Replace(strColValues[i].ToString(), "'", "''") + "'";

                    if (datafields.Length == 1)
                    {
                        row[col.Name.ToString()] = GetData(dtsource, filter, datafields[0], aggregate);
                        continue;
                    }
                    else
                    {
                        for (int j = 0; j < datafields.Length; j++)
                            row[datafields[j] + "_" + col.Name.ToString()] = GetData(dtsource, filter, datafields[j], aggregate);
                    }
                }
                dt.Rows.Add(row);
            }

            return dt;
        }

        public static void PivotData(DataTable dtsource, DataTable dttarget
                                    , string[] rowfields, string[] columnfields, string[] datafields, AggregateFunction aggregate)
        {
            dttarget.Clear();
            IEnumerable<DataRow> source = new List<DataRow>();

            source = dtsource.Rows.Cast<DataRow>();

            string separator = ".";
            var rowlist = dtsource.DefaultView.ToTable(true, rowfields).AsEnumerable().ToList();
            for (int i = rowfields.Count() - 1; i >= 0; i--)
                rowlist = rowlist.OrderBy(x => x.Field<object>(rowfields[i])).ToList();
            // Gets the list of columns .(dot) separated.
            var collist = (from x in dtsource.AsEnumerable()
                           select new
                           {
                               Name = columnfields.Select(n => x.Field<object>(n))
                                        .Aggregate((a, b) => a += separator + b.ToString())
                           }
                           )
                           .Distinct()
                           .OrderBy(m => m.Name);

            foreach (var RowName in rowlist)
            {
                DataRow row = dttarget.NewRow();
                string strFilter = string.Empty;

                foreach (string Field in rowfields)
                {
                    row[Field] = RowName[Field];
                    strFilter += " and " + Field + " = '" + Regex.Replace(RowName[Field].ToString(), "'", "''") + "'";
                }
                strFilter = strFilter.Substring(5);

                foreach (var col in collist)
                {
                    string filter = strFilter;
                    string[] strColValues = col.Name.ToString().Split(separator.ToCharArray(), StringSplitOptions.None);
                    for (int i = 0; i < columnfields.Length; i++)
                        filter += " and " + columnfields[i] + " = '"
                                + Regex.Replace(strColValues[i].ToString(), "'", "''") + "'";

                    if (datafields.Length == 1)
                    {
                        row[col.Name.ToString()] = GetData(dtsource, filter, datafields[0], aggregate);
                        continue;
                    }
                    else
                    {
                        for (int j = 0; j < datafields.Length; j++)
                            row[datafields[j] + "_" + col.Name.ToString()] = GetData(dtsource, filter, datafields[j], aggregate);
                    }
                }
                dttarget.Rows.Add(row);
            }
        }

        /// <summary>
        /// Retrives the data for matching RowField value and ColumnFields values with Aggregate function applied on them.
        /// </summary>
        /// <param name="Filter">DataTable Filter condition as a string</param>
        /// <param name="DataField">The column name which needs to spread out in Data Part of the Pivoted table</param>
        /// <param name="Aggregate">Enumeration to determine which function to apply to aggregate the data</param>
        /// <returns></returns>
        private static object GetData(DataTable dtsource, string Filter, string DataField, AggregateFunction Aggregate)
        {
            try
            {
                DataRow[] FilteredRows = dtsource.Select(Filter);
                object[] objList = FilteredRows.Select(x => x.Field<object>(DataField)).ToArray();

                switch (Aggregate)
                {
                    case AggregateFunction.Average:
                        return GetAverage(objList);
                    case AggregateFunction.Count:
                        return objList.Count();
                    case AggregateFunction.Exists:
                        return (objList.Count() == 0) ? "False" : "True";
                    case AggregateFunction.First:
                        return GetFirst(objList);
                    case AggregateFunction.Last:
                        return GetLast(objList);
                    case AggregateFunction.Max:
                        return GetMax(objList);
                    case AggregateFunction.Min:
                        return GetMin(objList);
                    case AggregateFunction.Sum:
                        return GetSum(objList);
                    default:
                        return null;
                }
            }
            catch (Exception ex)
            {
                return "#Error";
            }
        }

        private static object GetAverage(object[] objList)
        {
            return objList.Count() == 0 ? 0 : (object)(Convert.ToDecimal(GetSum(objList)) / objList.Count());
        }
        private static object GetSum(object[] objList)
        {
            return objList.Count() == 0 ? 0 : (object)(objList.Aggregate(new decimal(), (x, y) => x += Convert.ToDecimal(y)));
        }
        private static object GetFirst(object[] objList)
        {
            return (objList.Count() == 0) ? 0 : objList.First();
        }
        private static object GetLast(object[] objList)
        {
            return (objList.Count() == 0) ? 0 : objList.Last();
        }
        private static object GetMax(object[] objList)
        {
            return (objList.Count() == 0) ? 0 : objList.Max();
        }
        private static object GetMin(object[] objList)
        {
            return (objList.Count() == 0) ? 0 : objList.Min();
        }
    }
}

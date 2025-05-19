using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace WIZ
{
    public class DBHelper
    {
        private DbConnection _sConn = null;

        private DbTransaction _sTran = null;

        private DbCommand oCmd = null;

        private bool _completedClose = false;

        public DbProviderFactory dataFactory = null;

        public string RSCODE = "S";

        public string RSMSG = string.Empty;

        public bool bConFail = false;

        private bool _bEncrypt = false;

        public string ConType
        {
            get
            {
                try
                {
                    return _sConn.GetType().Name;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }

        public DbConnection DBConnect
        {
            get
            {
                return _sConn;
            }
        }

        public DbParameterCollection Parameters
        {
            get
            {
                try
                {
                    return oCmd.Parameters;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        private bool Init(string conStr, bool btran, bool completedClose)
        {
            try
            {
                if (conStr == "")
                {
                    conStr = CModule.GetAppSetting(CModule.sConnectionString, CModule.sDefualtConnectString);

                }
                if (CModule.GetAppSetting("ENCRYTION", "YES") == "YES")
                {
                    conStr = Common.DecryptString(conStr);
                }
                _completedClose = completedClose;
                dataFactory = DbProviderFactories.GetFactory(CModule.GetAppSetting(CModule.sProvider, CModule.sDefualtProvider));
                _completedClose = completedClose;
                _sConn = dataFactory.CreateConnection();
                _sConn.ConnectionString = conStr;
                _sConn.Open();
                if (btran)
                {
                    _sTran = _sConn.BeginTransaction();
                }
            }
            catch (Exception)
            {
                bConFail = true;
                return true;
            }
            bConFail = false;
            return false;
        }

        public DBHelper()
        {
            Init("", false, false);
        }

        public DBHelper(bool completedClose)
        {
            Init("", false, completedClose);
        }

        public DBHelper(bool completedClose, string conStr)
        {
            Init(conStr, false, completedClose);
        }

        public DBHelper(string conStr, bool bTrans)
        {
            Init(conStr, bTrans, false);
        }

        public DBHelper(bool completedClose, string conStr, bool bTrans)
        {
            Init(conStr, bTrans, completedClose);
        }

        public void Close()
        {
            Close(bCommit: true);
        }

        public void Close(bool bCommit)
        {
            try
            {
                if (_sTran != null)
                {
                    if (bCommit)
                    {
                        _sTran.Commit();
                    }
                    else
                    {
                        _sTran.Rollback();
                    }
                }
                _sConn.Close();
            }
            catch
            {
            }
        }

        public void Commit()
        {
            if (_sTran != null)
            {
                _sTran.Commit();
                _sTran = null;
            }
        }

        public void Rollback()
        {
            if (_sTran != null)
            {
                _sTran.Rollback();
                _sTran = null;
            }
        }
        /*
        ///
		public Database CreateDataBase()
		{
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Expected O, but got Unknown
			Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			string connectionString = configuration.ConnectionStrings.ConnectionStrings["ConnectionString"].ConnectionString;
			connectionString = Common.DecryptString(connectionString);
			ConfigurationSourceBuilder val = (ConfigurationSourceBuilder)(object)new ConfigurationSourceBuilder();
			((IDatabaseDefaultConnectionString)DatabaseProviderExtensions.ASqlDatabase(((IDatabaseConfigurationProviderEntry)((IDatabaseConfiguration)DataConfigurationSourceBuilderExtensions.ConfigureData((IConfigurationSourceBuilder)(object)val)).ForDatabaseNamed("DBConn")).get_ThatIs())).WithConnectionString(connectionString);
			DictionaryConfigurationSource val2 = (DictionaryConfigurationSource)(object)new DictionaryConfigurationSource();
			val.UpdateConfigurationWithReplace((IConfigurationSource)(object)val2);

            EnterpriseLibraryContainer.Current = EnterpriseLibraryContainer.CreateDefaultContainer((IConfigurationSource)(object)val2);
			return DatabaseFactory.CreateDatabase("DBConn");
		}
        */

        public void FillSchema(DataTable dt, string query, CommandType commandType)  //지정된 DataTable에 DataSet을 추가합니다.
        {
            oCmd = _sConn.CreateCommand();
            oCmd.Connection = _sConn;
            oCmd.CommandText = query;
            oCmd.CommandType = commandType;
            oCmd.CommandTimeout = Convert.ToInt16(Common.SQLTIMEOUT);
            DbDataAdapter dbDataAdapter = dataFactory.CreateDataAdapter();
            dbDataAdapter.SelectCommand = oCmd;
            dbDataAdapter.FillSchema(dt, SchemaType.Source);
            if (_completedClose)
            {
                Close();
            }
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].ColumnName = dt.Columns[i].ColumnName.ToUpper();
            }
        }

        public void FillTable(DataTable dt, string query, CommandType commandType, params object[] parameters)
        {
            FillTable(dt, query, commandType, true, true, parameters);
        }

        public void FillTable(DataTable dt, string query, CommandType commandType, bool baddLang, bool baddOut, params object[] parameters)
        {
            oCmd = _sConn.CreateCommand();
            oCmd.Connection = _sConn;
            oCmd.CommandText = query;
            oCmd.CommandType = commandType;
            oCmd.CommandTimeout = Convert.ToInt16(Common.SQLTIMEOUT);
            RSCODE = "S";
            RSMSG = string.Empty;
            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    oCmd.Parameters.Add(parameters[i]);
                }
            }
            if (commandType == CommandType.StoredProcedure)
            {
                if (baddLang)
                {
                    oCmd.Parameters.Add(CreateParameter("Lang", DbType.String, Common.Lang));
                }
                if (baddOut)
                {
                    oCmd.Parameters.Add(CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 10));
                    oCmd.Parameters.Add(CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200));
                }
            }
            DbDataAdapter dbDataAdapter = dataFactory.CreateDataAdapter();
            if (_sTran != null && oCmd.GetType().Name != "OracleCommand")
            {
                oCmd.Transaction = _sTran;
            }
            dbDataAdapter.SelectCommand = oCmd;
            dbDataAdapter.Fill(dt);
            if (commandType == CommandType.StoredProcedure && baddOut)
            {
                RSMSG = DBHelper.nvlString(oCmd.Parameters["RS_MSG"].Value);
                RSCODE = DBHelper.nvlString(oCmd.Parameters["RS_CODE"].Value).Trim();
            }
            if (_completedClose)
            {
                Close();
            }
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                dt.Columns[j].ColumnName = dt.Columns[j].ColumnName.ToUpper();
            }
        }

        public DataTable FillTable(string query, CommandType commandType, params object[] parameters)
        {
            return FillTable(query, commandType, true, true, parameters);
        }

        public DataTable FillTable(string query, CommandType commandType, bool baddLang, bool baddOut, params object[] parameters)
        {
            oCmd = _sConn.CreateCommand();
            oCmd.Connection = _sConn;
            oCmd.CommandText = query;
            oCmd.CommandType = commandType;
            oCmd.CommandTimeout = Convert.ToInt16(Common.SQLTIMEOUT);
            RSCODE = "S";
            RSMSG = string.Empty;
            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    oCmd.Parameters.Add(parameters[i]);
                }
            }
            if (commandType == CommandType.StoredProcedure)
            {
                if (baddLang)
                {
                    oCmd.Parameters.Add(CreateParameter("Lang", DbType.String, Common.Lang));
                }
                if (baddOut)
                {
                    oCmd.Parameters.Add(CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 10));
                    oCmd.Parameters.Add(CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200));
                }
            }
            DbDataAdapter dbDataAdapter = dataFactory.CreateDataAdapter();
            if (_sTran != null && oCmd.GetType().Name != "OracleCommand")
            {
                oCmd.Transaction = _sTran;
            }

            dbDataAdapter.SelectCommand = oCmd;
            DataTable dataTable = new DataTable();
            dbDataAdapter.Fill(dataTable);
            if (commandType == CommandType.StoredProcedure && baddOut)
            {
                RSMSG = DBHelper.nvlString(oCmd.Parameters["RS_MSG"].Value);
                RSCODE = DBHelper.nvlString(oCmd.Parameters["RS_CODE"].Value).Trim();
            }
            if (_completedClose)
            {
                Close();
            }
            for (int j = 0; j < dataTable.Columns.Count; j++)
            {
                dataTable.Columns[j].ColumnName = dataTable.Columns[j].ColumnName.ToUpper();
            }
            return dataTable;
        }

        public static DataTable Join(DataTable First, DataTable Second, string[] FJC, string[] SJC, string flg = "JOIN")
        {
            DataTable dataTable = new DataTable("Join");

            DataSet dataSet = new DataSet();
            dataSet.Tables.AddRange(new DataTable[2]
            {
                    First.Copy(),
                    Second.Copy()
            });
            DataColumn[] array = new DataColumn[FJC.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = dataSet.Tables[0].Columns[FJC[i].ToString()];
            }
            DataColumn[] array2 = new DataColumn[SJC.Length];
            for (int j = 0; j < array2.Length; j++)
            {
                array2[j] = dataSet.Tables[1].Columns[SJC[j].ToString()];
            }
            DataRelation relation = new DataRelation(string.Empty, array, array2, createConstraints: false);
            if (flg != "CJOIN")
            {
                dataSet.Relations.Add(relation);
            }
            for (int k = 0; k < First.Columns.Count; k++)
            {
                dataTable.Columns.Add(First.Columns[k].ColumnName, First.Columns[k].DataType);
                dataTable.Columns[k].DefaultValue = 0;
            }
            for (int l = 0; l < Second.Columns.Count; l++)
            {
                if (!dataTable.Columns.Contains(Second.Columns[l].ColumnName))
                {
                    dataTable.Columns.Add(Second.Columns[l].ColumnName, Second.Columns[l].DataType);
                }
                else
                {
                    dataTable.Columns.Add(Second.Columns[l].ColumnName + "_" + Second.TableName, Second.Columns[l].DataType);
                }
                dataTable.Columns[First.Columns.Count + l].DefaultValue = 0;
            }
            dataTable.BeginLoadData();
            if (flg.ToUpper() == "JOIN")
            {
                object[] array3 = null;
                object[] array4 = null;
                object[] array5 = null;
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    array3 = row.ItemArray;
                    array5 = new object[array3.Length];
                    Array.Copy(array3, 0, array5, 0, array3.Length);
                    dataTable.LoadDataRow(array5, fAcceptChanges: true);
                }
                foreach (DataRow row2 in dataSet.Tables[1].Rows)
                {
                    array4 = row2.ItemArray;
                    array5 = new object[array4.Length];
                    Array.Copy(array4, 0, array5, 0, array4.Length);
                    dataTable.LoadDataRow(array5, fAcceptChanges: true);
                }
            }
            else if (flg == "CJOIN")
            {
                object[] array6 = null;
                object[] array7 = null;
                object[] array8 = null;
                foreach (DataRow row3 in dataSet.Tables[0].Rows)
                {
                    array6 = row3.ItemArray;
                    foreach (DataRow row4 in dataSet.Tables[1].Rows)
                    {
                        array7 = row4.ItemArray;
                        array8 = new object[array6.Length + array7.Length];
                        Array.Copy(array6, 0, array8, 0, array6.Length);
                        Array.Copy(array7, 0, array8, array6.Length, array7.Length);
                        dataTable.LoadDataRow(array8, fAcceptChanges: true);
                    }
                }
            }
            else
            {
                foreach (DataRow row5 in dataSet.Tables[0].Rows)
                {
                    DataRow[] childRows = row5.GetChildRows(relation);
                    if (flg.ToUpper() == "LOJ")
                    {
                        object[] itemArray = row5.ItemArray;
                        object[] array9 = null;
                        if (childRows != null && childRows.Length != 0)
                        {
                            DataRow[] array10 = childRows;
                            foreach (DataRow dataRow6 in array10)
                            {
                                object[] itemArray2 = dataRow6.ItemArray;
                                array9 = new object[itemArray.Length + itemArray2.Length];
                                Array.Copy(itemArray, 0, array9, 0, itemArray.Length);
                                Array.Copy(itemArray2, 0, array9, itemArray.Length, itemArray2.Length);
                                dataTable.LoadDataRow(array9, fAcceptChanges: true);
                            }
                        }
                        else
                        {
                            array9 = new object[itemArray.Length];
                            Array.Copy(itemArray, 0, array9, 0, itemArray.Length);
                            dataTable.LoadDataRow(array9, fAcceptChanges: true);
                        }
                    }
                    else if (flg.ToUpper() == "IJ" && childRows != null && childRows.Length != 0)
                    {
                        object[] itemArray3 = row5.ItemArray;
                        DataRow[] array11 = childRows;
                        foreach (DataRow dataRow7 in array11)
                        {
                            object[] itemArray4 = dataRow7.ItemArray;
                            object[] array12 = new object[itemArray3.Length + itemArray4.Length];
                            Array.Copy(itemArray3, 0, array12, 0, itemArray3.Length);
                            Array.Copy(itemArray4, 0, array12, itemArray3.Length, itemArray4.Length);
                            dataTable.LoadDataRow(array12, fAcceptChanges: true);
                        }
                    }
                }
            }
            dataTable.EndLoadData();

            return dataTable;
        }

        public DataTable FillTable(string query)
        {
            object[] parameters = null;
            return FillTable(query, CommandType.Text, parameters);
        }

        public DataTable FillTable(string query, CommandType commandType, List<DbParameter> param)
        {
            object[] parameters = param.ToArray();
            return FillTable(query, commandType, parameters);
        }

        public DataSet FillDataSet(string query, CommandType commandType, params object[] parameters)
        {
            return FillDataSet(query, commandType, true, true, parameters);
        }

        public DataSet FillDataSet(string query, CommandType commandType, bool baddLang, bool baddOut, params object[] parameters)
        {
            oCmd = _sConn.CreateCommand();
            oCmd.Connection = _sConn;
            oCmd.CommandText = query;
            oCmd.CommandType = commandType;
            oCmd.CommandTimeout = Convert.ToInt16(Common.SQLTIMEOUT);
            RSCODE = "S";
            RSMSG = string.Empty;
            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    oCmd.Parameters.Add(parameters[i]);
                }
            }
            if (commandType == CommandType.StoredProcedure)
            {
                if (baddLang)
                {
                    oCmd.Parameters.Add(CreateParameter("Lang", DbType.String, Common.Lang));
                }
                if (baddOut)
                {
                    oCmd.Parameters.Add(CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 10));
                    oCmd.Parameters.Add(CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200));
                }
            }
            DbDataAdapter dbDataAdapter = dataFactory.CreateDataAdapter();
            dbDataAdapter.SelectCommand = oCmd;

            if (_sTran != null && oCmd.GetType().Name != "OracleCommand")
            {
                oCmd.Transaction = _sTran;
            }

            DataSet dataSet = new DataSet();
            dbDataAdapter.Fill(dataSet);
            if (commandType == CommandType.StoredProcedure && baddOut)
            {
                RSMSG = DBHelper.nvlString(oCmd.Parameters["RS_MSG"].Value);
                RSCODE = DBHelper.nvlString(oCmd.Parameters["RS_CODE"].Value).Trim();
            }
            if (_completedClose)
            {
                Close();
            }
            foreach (DataTable table in dataSet.Tables)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    table.Columns[j].ColumnName = table.Columns[j].ColumnName.ToUpper();
                }
            }
            return dataSet;
        }

        public DataSet FillDataSet(string query, CommandType commandType, List<DbParameter> param)
        {
            object[] parameters = param.ToArray();
            return FillDataSet(query, commandType, parameters);
        }

        public DataSet FillDataSet(string query)
        {
            object[] parameters = null;
            return FillDataSet(query, CommandType.Text, parameters);
        }

        public int ExecuteNoneQuery(string query, CommandType commandType, params object[] parameters)
        {
            return ExecuteNoneQuery(query, commandType, true, true, parameters);
        }

        public int ExecuteNoneQuery(string query, CommandType commandType, List<DbParameter> param)
        {
            object[] parameters = param.ToArray();
            return ExecuteNoneQuery(query, commandType, parameters);
        }

        public int ExecuteNoneQuery(string query, CommandType commandType, bool baddLang, bool baddOut, params object[] parameters)
        {
            oCmd = _sConn.CreateCommand();
            oCmd.Connection = _sConn;
            oCmd.CommandText = query;
            oCmd.CommandType = commandType;
            oCmd.CommandTimeout = Convert.ToInt16(Common.SQLTIMEOUT);
            RSCODE = "S";
            RSMSG = string.Empty;
            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    oCmd.Parameters.Add(parameters[i]);
                }
            }
            if (commandType == CommandType.StoredProcedure)
            {
                if (baddLang)
                {
                    oCmd.Parameters.Add(CreateParameter("Lang", DbType.String, Common.Lang));
                }
                if (baddOut)
                {
                    oCmd.Parameters.Add(CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 10));
                    oCmd.Parameters.Add(CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200));
                }
            }
            if (_sTran != null && oCmd.GetType().Name != "OracleCommand")
            {
                oCmd.Transaction = _sTran;
            }
            int result = oCmd.ExecuteNonQuery();
            if (commandType == CommandType.StoredProcedure && baddOut)
            {
                RSMSG = DBHelper.nvlString(oCmd.Parameters["RS_MSG"].Value);
                RSCODE = DBHelper.nvlString(oCmd.Parameters["RS_CODE"].Value).Trim();
            }
            if (_completedClose)
            {
                Close();
            }
            return result;
        }

        public int ExecuteNoneQuery(string query)
        {
            object[] parameters = null;
            return ExecuteNoneQuery(query, CommandType.Text, parameters);
        }

        public int ExecuteNoneQuery(string query, CommandType commandType, ref string RS_CODE, ref string RS_MSG, ref string TakingORDNO, params object[] parameters)
        {
            oCmd = _sConn.CreateCommand();
            oCmd.Connection = _sConn;
            oCmd.CommandText = query;
            oCmd.CommandType = commandType;
            oCmd.CommandTimeout = Convert.ToInt16(Common.SQLTIMEOUT);
            RSCODE = "S";
            RSMSG = string.Empty;
            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    oCmd.Parameters.Add(parameters[i]);
                }
            }
            oCmd.Parameters.Add(CreateParameter("TakingORDNO", DbType.String, ParameterDirection.Output, null, 50));
            oCmd.Parameters.Add(CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 10));
            oCmd.Parameters.Add(CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200));
            if (_sTran != null && oCmd.GetType().Name != "OracleCommand")
            {
                oCmd.Transaction = _sTran;
            }
            int result = oCmd.ExecuteNonQuery();
            RS_MSG = DBHelper.nvlString(oCmd.Parameters["RS_MSG"].Value);
            RS_CODE = DBHelper.nvlString(oCmd.Parameters["RS_CODE"].Value).Trim();
            TakingORDNO = DBHelper.nvlString(oCmd.Parameters["TakingORDNO"].Value);
            RSMSG = DBHelper.nvlString(oCmd.Parameters["RS_MSG"].Value);
            RSCODE = DBHelper.nvlString(oCmd.Parameters["RS_CODE"].Value).Trim();
            if (_completedClose)
            {
                Close();
            }
            return result;
        }

        public int ExecuteNoneIFSP(string query, CommandType commandType, params object[] parameters)
        {
            oCmd = _sConn.CreateCommand();
            oCmd.Connection = _sConn;
            oCmd.CommandText = query;
            oCmd.CommandType = commandType;
            oCmd.CommandTimeout = Convert.ToInt16(Common.SQLTIMEOUT);
            RSCODE = "S";
            RSMSG = string.Empty;
            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    oCmd.Parameters.Add(parameters[i]);
                }
            }
            oCmd.Parameters.Add(CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 10));
            oCmd.Parameters.Add(CreateParameter("RS_CODE_TYPE", DbType.String, ParameterDirection.Output, null, 1));
            oCmd.Parameters.Add(CreateParameter("RS_CNT", DbType.String, ParameterDirection.Output, null, 200));
            oCmd.Parameters.Add(CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200));
            if (_sTran != null && oCmd.GetType().Name != "OracleCommand")
            {
                oCmd.Transaction = _sTran;
            }
            int result = oCmd.ExecuteNonQuery();
            RSMSG = DBHelper.nvlString(oCmd.Parameters["RS_MSG"].Value);
            RSCODE = DBHelper.nvlString(oCmd.Parameters["RS_CODE"].Value).Trim();
            if (_completedClose)
            {
                Close();
            }
            return result;
        }

        public DbDataReader ExecuteReader(string query, CommandType commandType, params object[] parameters)
        {
            oCmd = _sConn.CreateCommand();
            oCmd.Connection = _sConn;
            oCmd.CommandText = query;
            oCmd.CommandType = commandType;
            oCmd.CommandTimeout = Convert.ToInt16(Common.SQLTIMEOUT);
            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    oCmd.Parameters.Add(parameters[i]);
                }
            }
            if (commandType == CommandType.StoredProcedure)
            {
                oCmd.Parameters.Add(CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 10));
                oCmd.Parameters.Add(CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200));
            }
            DbDataReader result = oCmd.ExecuteReader();
            if (commandType == CommandType.StoredProcedure)
            {
                RSMSG = DBHelper.nvlString(oCmd.Parameters["RS_MSG"].Value);
                RSCODE = DBHelper.nvlString(oCmd.Parameters["RS_CODE"].Value).Trim();
            }
            if (_completedClose)
            {
                Close();
            }
            return result;
        }

        public object ExecuteScalar(string query, CommandType commandType, params object[] parameters)
        {
            return ExecuteScalar(query, commandType, true, true, parameters);
        }

        public object ExecuteScalar(string query, CommandType commandType, bool baddLang, bool baddOut, params object[] parameters)
        {
            oCmd = _sConn.CreateCommand();
            oCmd.Connection = _sConn;
            oCmd.CommandText = query;
            oCmd.CommandType = commandType;
            oCmd.CommandTimeout = Convert.ToInt16(Common.SQLTIMEOUT);
            RSCODE = "S";
            RSMSG = string.Empty;
            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    oCmd.Parameters.Add(parameters[i]);
                }
            }
            if (commandType == CommandType.StoredProcedure)
            {
                if (baddLang)
                {
                    oCmd.Parameters.Add(CreateParameter("Lang", DbType.String, Common.Lang));
                }
                if (baddOut)
                {
                    oCmd.Parameters.Add(CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 10));
                    oCmd.Parameters.Add(CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200));
                }
            }
            object result = oCmd.ExecuteScalar();
            if (commandType == CommandType.StoredProcedure && baddOut)
            {
                RSMSG = DBHelper.nvlString(oCmd.Parameters["RS_MSG"].Value);
                RSCODE = DBHelper.nvlString(oCmd.Parameters["RS_CODE"].Value).Trim();
            }
            if (_completedClose)
            {
                Close();
            }
            return result;
        }

        public object ExecuteScalar(string query)
        {
            object[] parameters = null;
            return ExecuteScalar(query, CommandType.Text, parameters);
        }

        public DbParameter CreateParameter(string name, object value, DbType SqlType, ParameterDirection direction)
        {
            DbParameter dbParameter = dataFactory.CreateParameter();
            dbParameter.ParameterName = name.ToUpper();
            dbParameter.Value = value;
            dbParameter.Direction = direction;
            return dbParameter;
        }

        public DbParameter CreateParameter(string parameterName, DbType DbType, ParameterDirection parameterDirection, object value, int? size)
        {
            DbParameter dbParameter = null;
            try
            {
                dbParameter = dataFactory.CreateParameter();
                dbParameter.ParameterName = parameterName.ToUpper();
                dbParameter.DbType = DbType;
                dbParameter.Direction = parameterDirection;
                dbParameter.Value = value;
                if (size.HasValue)
                {
                    dbParameter.Size = size.Value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dbParameter;
        }

        public DbParameter CreateParameter(string parameterName, DbType DbType, object value)
        {
            DbParameter dbParameter = null;
            try
            {
                dbParameter = dataFactory.CreateParameter();
                dbParameter.ParameterName = parameterName.ToUpper();
                dbParameter.DbType = DbType;
                dbParameter.Value = value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dbParameter;
        }

        public static int nvlInt(object obj, int def = 0)
        {
            if (obj == null)
            {
                return def;
            }
            if (obj == DBNull.Value)
            {
                return def;
            }
            if (obj.ToString() == "")
            {
                return def;
            }
            return Convert.ToInt32(nvlString(obj).Replace(",", ""));
        }

        public static double nvlDouble(object obj, double def = 0.0)
        {
            if (obj == null)
            {
                return def;
            }
            if (obj == DBNull.Value)
            {
                return def;
            }
            if (obj.ToString() == "")
            {
                return def;
            }
            return Convert.ToDouble(nvlString(obj).Replace(",", ""));
        }

        public static string nvlString(object obj, string def = "")
        {
            if (obj == null)
            {
                return def;
            }
            if (obj == DBNull.Value)
            {
                return def;
            }
            if (obj.ToString() == "")
            {
                return def;
            }
            if (obj.ToString().ToUpper() == "ALL")
            {
                return def;
            }
            if (obj.ToString() == Common.getLangText("전체"))
            {
                return def;
            }
            return obj.ToString();
        }

        public static bool nvlBoolean(object obj, bool def = false)
        {
            if (obj == null)
            {
                return def;
            }
            if (obj == DBNull.Value)
            {
                return def;
            }
            if (obj.ToString() == "")
            {
                return def;
            }
            if (obj.ToString().ToUpper() == "ALL")
            {
                return def;
            }
            if (obj.ToString() == Common.getLangText("전체"))
            {
                return def;
            }
            if (obj.ToString() == "0" || obj.ToString() == "False")
            {
                return def;
            }
            def = true;
            return def;
        }

        public static DateTime nvlDateTime(object obj)
        {
            try
            {
                if (obj == null)
                {
                    return Convert.ToDateTime("2000-01-01 00:00:00");
                }
                if (obj == DBNull.Value)
                {
                    return Convert.ToDateTime("2000-01-01 00:00:00");
                }
                if (obj.ToString() == "")
                {
                    return Convert.ToDateTime("2000-01-01 00:00:00");
                }
                return Convert.ToDateTime(obj);
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }

        public static string gGetCode(object obj, string def = "")
        {
            if (obj == null)
            {
                return def;
            }
            if (obj == DBNull.Value)
            {
                return def;
            }
            if (obj.ToString() == "")
            {
                return "";
            }
            string text = obj.ToString();
            int num = text.IndexOf('[');
            int num2 = text.IndexOf(']');
            if (num < 0 && num2 < 0)
            {
                return text;
            }
            return text.Substring(num + 1, num2 - num - 1).Trim();
        }

        public static string gGetName(object obj, string def = "")
        {
            if (obj == null)
            {
                return def;
            }
            if (obj == DBNull.Value)
            {
                return def;
            }
            if (obj.ToString() == "")
            {
                return "";
            }
            string text = obj.ToString();
            int num = text.IndexOf('[');
            int num2 = text.IndexOf(']');
            if (num < 0 && num2 < 0)
            {
                return text;
            }
            return text.Substring(num2 + 1).Trim();
        }
    }
}

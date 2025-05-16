using System;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace WIZ.Control
{
    public class FileImporter
    {
        private const string ConnectStringExcel97To2003 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"{0}\";Mode=ReadWrite|Share Deny None;Extended Properties='Excel 8.0; HDR={1}; IMEX={2}';Persist Security Info=False";

        private const string ConnectStringExcel = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"{0}\";Mode=ReadWrite|Share Deny None;Extended Properties='Excel 12.0; HDR={1}; IMEX={2}';Persist Security Info=False";

        public int ExcelFileType(string XlsFile)
        {
            byte[,] array = new byte[2, 5]
            {
                {
                    208,
                    207,
                    17,
                    224,
                    161
                },
                {
                    80,
                    75,
                    3,
                    4,
                    20
                }
            };
            int num = -1;
            FileInfo fileInfo = new FileInfo(XlsFile);
            FileStream fileStream = fileInfo.Open(FileMode.Open);
            try
            {
                byte[] array2 = new byte[5];
                fileStream.Read(array2, 0, 5);
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 5 && array2[j] == array[i, j]; j++)
                    {
                        if (j == 4)
                        {
                            num = i;
                        }
                    }
                    if (num >= 0)
                    {
                        break;
                    }
                }
            }
            catch
            {
                num = -2;
            }
            finally
            {
                fileStream.Close();
            }
            return num;
        }

        public DataSet LoadExcelFile(string FileName, bool UseHeader)
        {
            DataSet dataSet = null;
            string[] array = new string[2]
            {
                "NO",
                "YES"
            };
            string text = "";
            string connectionString = "";
            text = ((!UseHeader) ? array[0] : array[1]);
            switch (ExcelFileType(FileName))
            {
                case -2:
                    throw new Exception(FileName + "의 형식검사중 오류가 발생하였습니다.");
                case -1:
                    throw new Exception(FileName + "은 엑셀 파일형식이 아닙니다.");
                case 0:
                    connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"{0}\";Mode=ReadWrite|Share Deny None;Extended Properties='Excel 8.0; HDR={1}; IMEX={2}';Persist Security Info=False", FileName, text, "1");
                    break;
                case 1:
                    connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"{0}\";Mode=ReadWrite|Share Deny None;Extended Properties='Excel 12.0; HDR={1}; IMEX={2}';Persist Security Info=False", FileName, text, "1");
                    break;
            }
            OleDbConnection oleDbConnection = null;
            OleDbDataAdapter oleDbDataAdapter = null;
            try
            {
                oleDbConnection = new OleDbConnection(connectionString);
                oleDbConnection.Open();
                DataTable oleDbSchemaTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[4]
                {
                    null,
                    null,
                    null,
                    "TABLE"
                });
                dataSet = new DataSet();
                foreach (DataRow row in oleDbSchemaTable.Rows)
                {
                    oleDbDataAdapter = new OleDbDataAdapter(row["TABLE_NAME"].ToString(), oleDbConnection);
                    oleDbDataAdapter.SelectCommand.CommandType = CommandType.TableDirect;
                    oleDbDataAdapter.AcceptChangesDuringFill = false;
                    string srcTable = row["TABLE_NAME"].ToString().Replace("$", string.Empty).Replace("'", string.Empty);
                    if (row["TABLE_NAME"].ToString().Contains("$"))
                    {
                        oleDbDataAdapter.Fill(dataSet, srcTable);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oleDbConnection?.Close();
            }
            return dataSet;
        }

        public DataSet LoadCsv(string filename, string filepath)
        {
            DataSet dataSet = new DataSet();
            try
            {
                string text = "Driver={Microsoft Text Driver (*.txt; *.csv)};DefaultDir=" + filepath.Trim() + ";Extensions=asc,csv,tab,txt;Persist Security Info=False";
                OdbcConnection odbcConnection = new OdbcConnection(text.Trim());
                odbcConnection.Open();
                string selectCommandText = "select * from [{0}]" + filename;
                OdbcDataAdapter odbcDataAdapter = new OdbcDataAdapter(selectCommandText, odbcConnection);
                odbcDataAdapter.Fill(dataSet, "csv");
                odbcConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error - LoadCSV", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return dataSet;
        }
    }
}

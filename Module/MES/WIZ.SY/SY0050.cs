using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using WIZ.Control;
using WIZ.Forms;

namespace WIZ.SY
{
    public class SY0050 : BaseMDIChildForm
    {
        private DataTable DtTemp = new DataTable();

        private DataTable DtGrid1 = new DataTable();

        private DataTable DtGrid2 = new DataTable();

        private UltraGridUtil _GridUtil = new UltraGridUtil();

        private Common _Com = new Common();

        private string luPath = string.Empty;

        private bool StatusCheck = false;

        private new IContainer components = null;

        private SLabel lblSystemID;

        public UltraGroupBox gbxVersionList;

        private UltraSplitter ultraSplitter1;

        public UltraGroupBox gbxVersion;

        private SCodeNMComboBox cbxJobGB;

        private SCodeNMComboBox cbxSystemID;

        private UltraLabel ultraLabel1;

        private WIZ.Control.Grid grid1;

        private WIZ.Control.Grid grid2;

        private SCodeNMComboBox cboSystemID_H;

        private Hashtable hash;

        public SY0050()
        {
            InitializeComponent();
        }

        private void SY0050_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(grid1, true, true, false, "", activeRowWhiteColor: true);
            _GridUtil.InitColumnUltraGrid(grid1, "SYSTEMID", "시스템", false, GridColDataType_emu.VarChar, 180, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "REGUSERID", "버전등록자", false, GridColDataType_emu.VarChar, 85, 100, HAlign.Center, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DESCRIPT", "비고", false, GridColDataType_emu.VarChar, 250, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "FILETYPE", "FILETYPE", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일자", false, GridColDataType_emu.VarChar, 185, 100, HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 250, 100, HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일자", false, GridColDataType_emu.VarChar, 250, 100, HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
            DtGrid1 = (DataTable)grid1.DataSource;
            _GridUtil.InitializeGrid(grid2, true, true, false, "", activeRowWhiteColor: true);
            _GridUtil.InitColumnUltraGrid(grid2, "CLIENTID", "클라이언트", false, GridColDataType_emu.VarChar, 150, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "JOBID", "JobID", false, GridColDataType_emu.VarChar, 60, 100, HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "JOBSEQ", "순서", false, GridColDataType_emu.VarChar, 60, 100, HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "FILEID", "파일", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "FILEVER", "파일버전", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "FileTime", "파일시간", false, GridColDataType_emu.VarChar, 150, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "CPATH", "클라이언트 저장위치", false, GridColDataType_emu.VarChar, 150, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "PROCGB", "작업구분", false, GridColDataType_emu.VarChar, 80, 100, HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "FILESIZE", "파일크기(KB)", false, GridColDataType_emu.VarChar, 100, 100, HAlign.Right, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "DESCRIPT", "비고", false, GridColDataType_emu.VarChar, 180, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SYSTEMID", "시스템", false, GridColDataType_emu.VarChar, 150, 100, HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "SPATH", "", false, GridColDataType_emu.VarChar, 150, 100, HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "FILEIMAGE", "파일", false, GridColDataType_emu.Image, 150, 100, HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER", "등록자", false, GridColDataType_emu.VarChar, 150, 100, HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE", "등록일", false, GridColDataType_emu.VarChar, 150, 100, HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITOR", "수정자", false, GridColDataType_emu.VarChar, 150, 100, HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "EDITDATE", "수정일", false, GridColDataType_emu.VarChar, 150, 100, HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid2, "UPLOADPATH", "업로드경로", false, GridColDataType_emu.VarChar, 150, 300, HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid2);
            DtGrid2 = (DataTable)grid2.DataSource;
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("CODE_ID", typeof(string));
            dataTable.Columns.Add("CODE_NAME", typeof(string));
            dataTable.Rows.Add("COPY", "COPY");
            dataTable.Rows.Add("EXEC", "EXEC");
            dataTable.Rows.Add("SQL", "SQL");
            UltraGridUtil.SetComboUltraGrid(grid2, "PROCGB", dataTable, "CODE_ID", "CODE_NAME");
            cboSystemID_H.Value = Common.SystemID;
            DataTable dtInData = _Com.GET_BM0000_CODE("SYSTEMID");
            UltraGridUtil.SetComboUltraGrid(grid1, "SYSTEMID", dtInData, "CODE_ID", "CODE_NAME");
        }

        public override void DoInquire()
        {
            string aS_SYSTEMID = string.Empty;

            hash = new Hashtable();

            if (cboSystemID_H.Value != null)
            {
                aS_SYSTEMID = ((cboSystemID_H.Value.ToString() == "ALL") ? "" : cboSystemID_H.Value.ToString());
            }
            if (!StatusCheck)
            {
                base.DoInquire();
                _GridUtil.Grid_Clear(grid1);
                _GridUtil.Grid_Clear(grid2);
                DtTemp = USP_SY0050_S1(aS_SYSTEMID);
                grid1.DataSource = DtTemp;
                grid1.DataBind();
                DtGrid1 = DtTemp;
                ComboBox_Refresh();
                grid1.GetRow();
            }
            else if (UltraGridUtil.CheckSearchDataGrid(this, grid1, DtGrid1))
            {
                DialogResult dialogResult = ShowDialog(Common.getLangText("자료를 저장하지 않았습니다. \n\r저장하지 않고 검색하겠습니까?", "MSG"));
                if (dialogResult != DialogResult.Yes)
                {
                    StatusCheck = true;
                    return;
                }
                StatusCheck = false;
                DoInquire();
            }
            else
            {
                StatusCheck = false;
                DoInquire();
            }
        }

        public override void DoNew()
        {
            base.DoNew();
            if (grid2.IsActivate)
            {
                if (grid1.Rows.Count == 0 || grid1.ActiveRow.Cells["SYSTEMID"].Value.ToString() == "")
                {
                    return;
                }
                string text = Convert.ToString(grid1.ActiveRow.Cells["FILETYPE"].Value);
                int num = 0;
                for (int i = 0; i < grid2.Rows.Count; i++)
                {
                    if (num < Convert.ToInt32(grid2.Rows[i].Cells["JOBID"].Value))
                    {
                        num = Convert.ToInt32(grid2.Rows[i].Cells["JOBID"].Value);
                    }
                }
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = Application.StartupPath;
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                for (int j = 0; j < openFileDialog.FileNames.Length; j++)
                {
                    grid2.InsertRow();
                    grid2.ActiveRow.Cells["SYSTEMID"].Value = grid1.ActiveRow.Cells["SYSTEMID"].Value;
                    grid2.ActiveRow.Cells["SPath"].Value = luPath + grid1.ActiveRow.Cells["SYSTEMID"].Value + "/";
                    grid2.ActiveRow.Cells["JOBID"].Value = num + 1;
                    grid2.ActiveRow.Cells["JOBSEQ"].Value = num + 1;
                    FileInfo fileInfo = new FileInfo(openFileDialog.FileNames[j]);
                    grid2.ActiveRow.Cells["FileID"].Value = fileInfo.Name;
                    grid2.ActiveRow.Cells["FileVer"].Value = FileVersionInfo.GetVersionInfo(fileInfo.FullName).FileVersion;
                    grid2.ActiveRow.Cells["FileSize"].Value = fileInfo.Length / 1024;
                    grid2.ActiveRow.Cells["FileTime"].Value = fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                    if (grid2.ActiveRow.Cells["CPath"].Value.ToString() == "")
                    {
                        grid2.ActiveRow.Cells["CPath"].Value = "\\";
                    }
                    grid2.ActiveRow.Cells["UploadPath"].Value = fileInfo.FullName;
                    grid2.ActiveRow.Cells["UploadPath"].Value = fileInfo.FullName;
                    grid2.ActiveRow.Cells["ProcGB"].Value = "COPY";
                    FileStream fileStream = new FileStream(fileInfo.FullName, FileMode.OpenOrCreate, FileAccess.Read);
                    byte[] array = new byte[fileStream.Length];
                    fileStream.Read(array, 0, Convert.ToInt32(fileStream.Length));
                    if (hash.ContainsKey(fileInfo.Name))
                    {
                        hash[fileInfo.Name] = array;
                    }
                    else
                    {
                        hash.Add(fileInfo.Name, array);
                    }
                    fileStream.Close();
                }
            }
            else
            {
                int index = grid1.InsertRow();
                UltraGridUtil.ActivationAllowEdit(grid1, "SYSTEMID");
                grid1.Rows[index].Cells["SYSTEMID"].Value = cboSystemID_H.Value;
                DataRow[] array2 = _Com.GET_BM0000_CODE("SYSTEMID").Select("CODE_ID='" + cboSystemID_H.Value + "'");
                if (array2 != null && array2.Length != 0)
                {
                    grid1.ActiveRow.Cells["FILETYPE"].Value = array2[0][7].ToString();
                }
            }
        }

        public override void DoDelete()
        {
            base.DoDelete();
            if (grid2.IsActivate)
            {
                grid2.DeleteRow();
                return;
            }
            int count = grid2.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                grid2.DeleteRow();
            }
            grid1.DeleteRow();
        }

        public override void DoSave()
        {
            base.DoSave();
            grid1.SetRow();
            grid1.PerformAction(UltraGridAction.DeactivateCell);
            if (UltraGridUtil.CheckSaveDataGrid(this, grid1, DtGrid1))
            {
                USP_SY0050_CRUD_GRD1(DtGrid1, WorkerID);
                StatusCheck = false;
            }
            grid2.PerformAction(UltraGridAction.DeactivateCell);
            if (UltraGridUtil.CheckSaveDataGrid(this, grid2, DtGrid2))
            {
                USP_SY0051_CRUD_GRD2(DtGrid2, WorkerID);
                StatusCheck = false;
            }
        }

        private void grid1_ClickCellButton(object sender, CellEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            if (e.Cell.Row.Cells["FileID"].Value == null)
            {
                openFileDialog.Filter = "ALL|*.*";
            }
            else
            {
                openFileDialog.FileName = e.Cell.Row.Cells["FileID"].Value.ToString();
                openFileDialog.Filter = "FILE|" + e.Cell.Row.Cells["FileID"].Value.ToString() + "|ALL|*.*";
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                e.Cell.Row.Cells["FileID"].Value = fileInfo.Name;
                e.Cell.Row.Cells["Uploader"].Value = WorkerID;
                e.Cell.Row.Cells["FileSize"].Value = fileInfo.Length;
                e.Cell.Row.Cells["FileTime"].Value = fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                e.Cell.Row.Cells["LocalFile"].Value = fileInfo.FullName;
                e.Cell.Row.Cells["CreateDate"].Value = fileInfo.CreationTime;
            }
        }

        private void grid1_ClickCell(object sender, EventArgs e)
        {
            _GridUtil.Grid_Clear(grid2);
            if (!(Convert.ToString(grid1.ActiveRow.Cells["SYSTEMID"].Value) == string.Empty))
            {
                DtTemp = USP_SY0051_S1(Convert.ToString(grid1.ActiveRow.Cells["SYSTEMID"].Value));
                if (DtTemp != null)
                {
                    grid2.DataSource = DtTemp;
                    grid2.DataBind();
                    DtGrid2 = DtTemp;
                    grid2.GetRow();
                }
            }
        }

        private void grid1_AfterRowInsert(object sender, RowEventArgs e)
        {
            e.Row.Cells["RegUserID"].Value = WorkerID;
        }

        private void grid2_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            if (e.Cell.Column.Key != "FILEID")
            {
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            if (e.Cell.Row.Cells["FileID"].Value == null)
            {
                openFileDialog.Filter = "ALL|*.*";
            }
            else
            {
                openFileDialog.FileName = e.Cell.Row.Cells["FileID"].Value.ToString();
                openFileDialog.Filter = "FILE|" + e.Cell.Row.Cells["FileID"].Value.ToString() + "|ALL|*.*";
            }
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
            decimal d = Convert.ToDecimal(Convert.ToString(e.Cell.Row.Cells["FileVer"].Value).Replace(".", ""));
            decimal d2 = Convert.ToDecimal(FileVersionInfo.GetVersionInfo(fileInfo.FullName).FileVersion.Replace(".", ""));
            if (!(d >= d2) || ShowDialog("업로드 할 파일이 업로드 된 파일보다 이전(또는 동일) 버전 입니다." + Environment.NewLine + "그래도 파일 업로드를 하시겠습니까?" + Environment.NewLine + "(주의) 다운로드가 정상적으로 되지 않을 수 있습니다!") != DialogResult.No)
            {
                e.Cell.Row.Cells["FileID"].Value = fileInfo.Name;
                e.Cell.Row.Cells["FileVer"].Value = FileVersionInfo.GetVersionInfo(fileInfo.FullName).FileVersion;
                e.Cell.Row.Cells["FileSize"].Value = fileInfo.Length / 1024;
                e.Cell.Row.Cells["FileTime"].Value = fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                if (e.Cell.Row.Cells["CPath"].Value.ToString() == "")
                {
                    e.Cell.Row.Cells["CPath"].Value = "\\";
                }
                e.Cell.Row.Cells["UploadPath"].Value = fileInfo.FullName;
                FileStream fileStream = new FileStream(fileInfo.FullName, FileMode.OpenOrCreate, FileAccess.Read);
                byte[] array = new byte[fileStream.Length];
                fileStream.Read(array, 0, Convert.ToInt32(fileStream.Length));
                if (hash.ContainsKey(fileInfo.Name))
                {
                    hash[fileInfo.Name] = array;
                }
                else
                {
                    hash.Add(fileInfo.Name, array);
                }
                fileStream.Close();
            }
        }

        private void grid2_ClickCellButton(object sender, CellEventArgs e)
        {
            if (e.Cell.Row.Tag == null || e.Cell.Row.Tag.ToString() != "NEW")
            {
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            if (e.Cell.Row.Cells["FileID"].Value == null)
            {
                openFileDialog.Filter = "ALL|*.*";
            }
            else
            {
                openFileDialog.FileName = e.Cell.Row.Cells["FileID"].Value.ToString();
                openFileDialog.Filter = "FILE|" + e.Cell.Row.Cells["FileID"].Value.ToString() + "|ALL|*.*";
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                e.Cell.Row.Cells["FileID"].Value = fileInfo.Name;
                e.Cell.Row.Cells["FileSize"].Value = fileInfo.Length;
                e.Cell.Row.Cells["FileTime"].Value = fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                if (e.Cell.Row.Cells["CPath"].Value.ToString() == "")
                {
                    e.Cell.Row.Cells["CPath"].Value = "\\";
                }
                e.Cell.Row.Cells["UploadPath"].Value = fileInfo.FullName;
                FileStream fileStream = new FileStream(fileInfo.FullName, FileMode.OpenOrCreate, FileAccess.Read);
                byte[] array = new byte[fileStream.Length];
                fileStream.Read(array, 0, Convert.ToInt32(fileStream.Length));

                if (hash.ContainsKey(fileInfo.Name))
                {
                    hash[fileInfo.Name] = array;
                }
                else
                {
                    hash.Add(fileInfo.Name, array);
                }
                fileStream.Close();
            }
        }

        private DataTable USP_SY0050_S1(string AS_SYSTEMID)
        {
            DBHelper dBHelper = new DBHelper(completedClose: false);
            try
            {
                return dBHelper.FillTable("USP_SY0050_S1", CommandType.StoredProcedure, dBHelper.CreateParameter("SYSTEMID", AS_SYSTEMID, DbType.String, ParameterDirection.Input));
            }
            catch (Exception ex)
            {
                ThrowError(ex);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        private DataTable USP_SY0051_S1(string AS_SYSTEMID)
        {
            DBHelper dBHelper = new DBHelper(completedClose: false);
            try
            {
                return dBHelper.FillTable("USP_SY0051_S1", CommandType.StoredProcedure, dBHelper.CreateParameter("SYSTEMID", AS_SYSTEMID, DbType.String, ParameterDirection.Input));
            }
            catch (Exception ex)
            {
                ThrowError(ex);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public void USP_SY0050_CRUD_GRD1(DataTable DtChange, string USER_ID)
        {
            DBHelper dBHelper = new DBHelper(string.Empty, bTrans: true);
            try
            {
                foreach (DataRow row in DtChange.Rows)
                {
                    switch (row.RowState)
                    {
                        case DataRowState.Deleted:
                            row.RejectChanges();
                            dBHelper.ExecuteNoneQuery("USP_SY0050_D1", CommandType.StoredProcedure, dBHelper.CreateParameter("SYSTEMID", Convert.ToString(row["SYSTEMID"]), DbType.String, ParameterDirection.Input));
                            break;
                        case DataRowState.Added:
                            dBHelper.ExecuteNoneQuery("USP_SY0050_I1", CommandType.StoredProcedure, dBHelper.CreateParameter("SYSTEMID", Convert.ToString(row["SYSTEMID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("REGUSERID", Convert.ToString(row["REGUSERID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("DESCRIPT", Convert.ToString(row["DESCRIPT"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("MAKER", USER_ID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("EDITOR", USER_ID, DbType.String, ParameterDirection.Input));
                            break;
                        case DataRowState.Modified:
                            dBHelper.ExecuteNoneQuery("USP_SY0050_U1", CommandType.StoredProcedure, dBHelper.CreateParameter("SYSTEMID", Convert.ToString(row["SYSTEMID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("REGUSERID", Convert.ToString(row["REGUSERID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("DESCRIPT", Convert.ToString(row["DESCRIPT"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("EDITOR", USER_ID, DbType.String, ParameterDirection.Input));
                            break;
                    }
                }
                dBHelper.Commit();
            }
            catch (Exception ex)
            {
                dBHelper.Rollback();
                ThrowError(ex);
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public void USP_SY0051_CRUD_GRD2(DataTable DtChange, string USER_ID)
        {
            DBHelper dBHelper = new DBHelper(string.Empty, bTrans: true);
            try
            {
                foreach (DataRow row in DtChange.Rows)
                {
                    switch (row.RowState)
                    {
                        case DataRowState.Deleted:
                            row.RejectChanges();
                            dBHelper.ExecuteNoneQuery("USP_SY0051_D1", CommandType.StoredProcedure
                                , dBHelper.CreateParameter("SYSTEMID", Convert.ToString(row["SYSTEMID"]), DbType.String, ParameterDirection.Input)
                                , dBHelper.CreateParameter("FILEID", Convert.ToString(row["FILEID"]), DbType.String, ParameterDirection.Input));
                            break;
                        case DataRowState.Added:
                            dBHelper.ExecuteNoneQuery("USP_SY0051_I1", CommandType.StoredProcedure
                                , dBHelper.CreateParameter("SYSTEMID", Convert.ToString(row["SYSTEMID"]), DbType.String, ParameterDirection.Input)
                                , dBHelper.CreateParameter("FILEID", Convert.ToString(row["FILEID"]), DbType.String, ParameterDirection.Input)
                                , dBHelper.CreateParameter("FILEVER", Convert.ToString(row["FILEVER"]), DbType.String, ParameterDirection.Input)
                                , dBHelper.CreateParameter("SPATH", Convert.ToString(row["SPATH"]), DbType.String, ParameterDirection.Input)
                                , dBHelper.CreateParameter("CPATH", Convert.ToString(row["CPATH"]), DbType.String, ParameterDirection.Input)
                                , dBHelper.CreateParameter("PROCGB", Convert.ToString(row["PROCGB"]), DbType.String, ParameterDirection.Input)
                                , dBHelper.CreateParameter("FILETIME", Convert.ToString(row["FILETIME"]), DbType.String, ParameterDirection.Input)
                                , dBHelper.CreateParameter("FILESIZE", Convert.ToString(row["FILESIZE"]), DbType.Decimal, ParameterDirection.Input)
                                , dBHelper.CreateParameter("FILEIMAGE", DbType.Binary, hash[Convert.ToString(row["FILEID"])])
                                , dBHelper.CreateParameter("DESCRIPT", Convert.ToString(row["DESCRIPT"]), DbType.String, ParameterDirection.Input)
                                , dBHelper.CreateParameter("MAKER", USER_ID, DbType.String, ParameterDirection.Input));
                            break;
                        case DataRowState.Modified:
                            dBHelper.ExecuteNoneQuery("USP_SY0051_U1", CommandType.StoredProcedure
                                , dBHelper.CreateParameter("SYSTEMID", Convert.ToString(row["SYSTEMID"]), DbType.String, ParameterDirection.Input)
                                , dBHelper.CreateParameter("JOBID", Convert.ToString(row["JOBID"]), DbType.Decimal, ParameterDirection.Input)
                                , dBHelper.CreateParameter("FILEID", Convert.ToString(row["FILEID"]), DbType.String, ParameterDirection.Input)
                                , dBHelper.CreateParameter("FILEVER", Convert.ToString(row["FILEVER"]), DbType.String, ParameterDirection.Input)
                                , dBHelper.CreateParameter("SPATH", Convert.ToString(row["SPATH"]), DbType.String, ParameterDirection.Input)
                                , dBHelper.CreateParameter("CPATH", Convert.ToString(row["CPATH"]), DbType.String, ParameterDirection.Input)
                                , dBHelper.CreateParameter("PROCGB", Convert.ToString(row["PROCGB"]), DbType.String, ParameterDirection.Input)
                                , dBHelper.CreateParameter("FILETIME", Convert.ToString(row["FILETIME"]), DbType.String, ParameterDirection.Input)
                                , dBHelper.CreateParameter("FILESIZE", Convert.ToString(row["FILESIZE"]), DbType.Decimal, ParameterDirection.Input)
                                , dBHelper.CreateParameter("FILEIMAGE", DbType.Binary, hash[Convert.ToString(row["FILEID"])])
                                , dBHelper.CreateParameter("DESCRIPT", Convert.ToString(row["DESCRIPT"]), DbType.String, ParameterDirection.Input)
                                , dBHelper.CreateParameter("EDITOR", USER_ID, DbType.String, ParameterDirection.Input));
                            break;
                    }
                }
                dBHelper.Commit();
            }
            catch (Exception ex)
            {
                dBHelper.Rollback();
                ThrowError(ex);
            }
            finally
            {
                dBHelper.Close();
                DoInquire();
            }
        }

        private void ComboBox_Refresh()
        {
            DtTemp = _Com.GET_BM0000_CODE("SYSTEMID");
            UltraGridUtil.SetComboUltraGrid(grid1, "SYSTEMID", DtTemp, "CODE_ID", "CODE_NAME");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private new void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            cbxJobGB = new WIZ.Control.SCodeNMComboBox();
            cbxSystemID = new WIZ.Control.SCodeNMComboBox();
            lblSystemID = new WIZ.Control.SLabel();
            gbxVersionList = new Infragistics.Win.Misc.UltraGroupBox();
            grid2 = new WIZ.Control.Grid(components);
            ultraSplitter1 = new Infragistics.Win.Misc.UltraSplitter();
            gbxVersion = new Infragistics.Win.Misc.UltraGroupBox();
            grid1 = new WIZ.Control.Grid(components);
            ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            cboSystemID_H = new WIZ.Control.SCodeNMComboBox();
            ((System.ComponentModel.ISupportInitialize)gbxHeader).BeginInit();
            gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gbxBody).BeginInit();
            gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cbxJobGB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbxSystemID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gbxVersionList).BeginInit();
            gbxVersionList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gbxVersion).BeginInit();
            gbxVersion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboSystemID_H).BeginInit();
            SuspendLayout();
            gbxHeader.ContentPadding.Bottom = 2;
            gbxHeader.ContentPadding.Left = 2;
            gbxHeader.ContentPadding.Right = 2;
            gbxHeader.ContentPadding.Top = 4;
            gbxHeader.Controls.Add(cboSystemID_H);
            gbxHeader.Controls.Add(ultraLabel1);
            gbxHeader.Controls.Add(lblSystemID);
            gbxHeader.Controls.SetChildIndex(lblSystemID, 0);
            gbxHeader.Controls.SetChildIndex(ultraLabel1, 0);
            gbxHeader.Controls.SetChildIndex(cboSystemID_H, 0);
            gbxBody.ContentPadding.Bottom = 4;
            gbxBody.ContentPadding.Left = 4;
            gbxBody.ContentPadding.Right = 4;
            gbxBody.ContentPadding.Top = 6;
            gbxBody.Controls.Add(gbxVersionList);
            gbxBody.Controls.Add(ultraSplitter1);
            gbxBody.Controls.Add(gbxVersion);
            gbxBody.Size = new System.Drawing.Size(1136, 704);
            cbxJobGB.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            cbxJobGB.ComboDataType = WIZ.Control.ComboDataType.CodeOnly;
            cbxJobGB.DbConfig = null;
            cbxJobGB.DefaultValue = "COPY";
            appearance.BackColor = System.Drawing.SystemColors.Window;
            appearance.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            cbxJobGB.DisplayLayout.Appearance = appearance;
            cbxJobGB.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            cbxJobGB.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            cbxJobGB.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            cbxJobGB.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            cbxJobGB.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            cbxJobGB.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            cbxJobGB.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            cbxJobGB.DisplayLayout.MaxColScrollRegions = 1;
            cbxJobGB.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            cbxJobGB.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            cbxJobGB.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            appearance7.FontData.BoldAsString = "True";
            cbxJobGB.DisplayLayout.Override.ActiveRowCellAppearance = appearance7;
            cbxJobGB.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            cbxJobGB.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            cbxJobGB.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.None;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            cbxJobGB.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            cbxJobGB.DisplayLayout.Override.CellAppearance = appearance9;
            cbxJobGB.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            cbxJobGB.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            cbxJobGB.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.TextHAlignAsString = "Left";
            cbxJobGB.DisplayLayout.Override.HeaderAppearance = appearance11;
            cbxJobGB.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            cbxJobGB.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            cbxJobGB.DisplayLayout.Override.RowAppearance = appearance12;
            cbxJobGB.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.Color.FromArgb(99, 133, 188);
            appearance13.FontData.BoldAsString = "True";
            cbxJobGB.DisplayLayout.Override.SelectedRowAppearance = appearance13;
            appearance14.BackColor = System.Drawing.SystemColors.ControlLight;
            cbxJobGB.DisplayLayout.Override.TemplateAddRowAppearance = appearance14;
            cbxJobGB.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            cbxJobGB.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            cbxJobGB.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            cbxJobGB.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            cbxJobGB.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            cbxJobGB.Location = new System.Drawing.Point(269, 188);
            cbxJobGB.MajorCode = "JOBGB";
            cbxJobGB.Name = "cbxJobGB";
            cbxJobGB.SelectedValue = null;
            cbxJobGB.ShowDefaultValue = false;
            cbxJobGB.Size = new System.Drawing.Size(141, 25);
            cbxJobGB.TabIndex = 13;
            cbxSystemID.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            cbxSystemID.ComboDataType = WIZ.Control.ComboDataType.CodeOnly;
            cbxSystemID.DbConfig = null;
            cbxSystemID.DefaultValue = "";
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            appearance15.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            cbxSystemID.DisplayLayout.Appearance = appearance15;
            cbxSystemID.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            cbxSystemID.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            cbxSystemID.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance16.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance16.BorderColor = System.Drawing.SystemColors.Window;
            cbxSystemID.DisplayLayout.GroupByBox.Appearance = appearance16;
            appearance17.ForeColor = System.Drawing.SystemColors.GrayText;
            cbxSystemID.DisplayLayout.GroupByBox.BandLabelAppearance = appearance17;
            cbxSystemID.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance18.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance18.BackColor2 = System.Drawing.SystemColors.Control;
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance18.ForeColor = System.Drawing.SystemColors.GrayText;
            cbxSystemID.DisplayLayout.GroupByBox.PromptAppearance = appearance18;
            cbxSystemID.DisplayLayout.MaxColScrollRegions = 1;
            cbxSystemID.DisplayLayout.MaxRowScrollRegions = 1;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            appearance19.ForeColor = System.Drawing.SystemColors.ControlText;
            cbxSystemID.DisplayLayout.Override.ActiveCellAppearance = appearance19;
            appearance20.BackColor = System.Drawing.SystemColors.Highlight;
            appearance20.ForeColor = System.Drawing.SystemColors.HighlightText;
            cbxSystemID.DisplayLayout.Override.ActiveRowAppearance = appearance20;
            appearance21.FontData.BoldAsString = "True";
            cbxSystemID.DisplayLayout.Override.ActiveRowCellAppearance = appearance21;
            cbxSystemID.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            cbxSystemID.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            cbxSystemID.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.None;
            appearance22.BackColor = System.Drawing.SystemColors.Window;
            cbxSystemID.DisplayLayout.Override.CardAreaAppearance = appearance22;
            appearance23.BorderColor = System.Drawing.Color.Silver;
            appearance23.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            cbxSystemID.DisplayLayout.Override.CellAppearance = appearance23;
            cbxSystemID.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            cbxSystemID.DisplayLayout.Override.CellPadding = 0;
            appearance24.BackColor = System.Drawing.SystemColors.Control;
            appearance24.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance24.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance24.BorderColor = System.Drawing.SystemColors.Window;
            cbxSystemID.DisplayLayout.Override.GroupByRowAppearance = appearance24;
            appearance25.TextHAlignAsString = "Left";
            cbxSystemID.DisplayLayout.Override.HeaderAppearance = appearance25;
            cbxSystemID.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            cbxSystemID.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance26.BackColor = System.Drawing.SystemColors.Window;
            appearance26.BorderColor = System.Drawing.Color.Silver;
            cbxSystemID.DisplayLayout.Override.RowAppearance = appearance26;
            cbxSystemID.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance27.BackColor = System.Drawing.Color.FromArgb(99, 133, 188);
            appearance27.FontData.BoldAsString = "True";
            cbxSystemID.DisplayLayout.Override.SelectedRowAppearance = appearance27;
            appearance28.BackColor = System.Drawing.SystemColors.ControlLight;
            cbxSystemID.DisplayLayout.Override.TemplateAddRowAppearance = appearance28;
            cbxSystemID.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            cbxSystemID.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            cbxSystemID.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            cbxSystemID.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            cbxSystemID.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            cbxSystemID.Location = new System.Drawing.Point(188, 188);
            cbxSystemID.MajorCode = "SYSTEMID";
            cbxSystemID.Name = "cbxSystemID";
            cbxSystemID.SelectedValue = null;
            cbxSystemID.ShowDefaultValue = false;
            cbxSystemID.Size = new System.Drawing.Size(259, 25);
            cbxSystemID.TabIndex = 2;
            appearance29.FontData.BoldAsString = "False";
            appearance29.FontData.UnderlineAsString = "False";
            appearance29.ForeColor = System.Drawing.Color.Black;
            appearance29.TextHAlignAsString = "Left";
            appearance29.TextVAlignAsString = "Middle";
            lblSystemID.Appearance = appearance29;
            lblSystemID.DbField = null;
            lblSystemID.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            lblSystemID.Location = new System.Drawing.Point(110, 10);
            lblSystemID.Name = "lblSystemID";
            lblSystemID.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            lblSystemID.Size = new System.Drawing.Size(145, 25);
            lblSystemID.TabIndex = 10;
            lblSystemID.Text = "시스템";
            appearance30.FontData.SizeInPoints = 10f;
            gbxVersionList.Appearance = appearance30;
            gbxVersionList.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.HeaderSolid;
            gbxVersionList.Controls.Add(grid2);
            gbxVersionList.Controls.Add(cbxJobGB);
            gbxVersionList.Dock = System.Windows.Forms.DockStyle.Fill;
            gbxVersionList.Location = new System.Drawing.Point(590, 6);
            gbxVersionList.Margin = new System.Windows.Forms.Padding(2);
            gbxVersionList.Name = "gbxVersionList";
            gbxVersionList.Size = new System.Drawing.Size(540, 692);
            gbxVersionList.TabIndex = 8;
            gbxVersionList.Text = "프로그램 파일 내역";
            gbxVersionList.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.XP;
            grid2.AutoResizeColumn = true;
            grid2.AutoUserColumn = true;
            grid2.ContextMenuCopyEnabled = true;
            grid2.ContextMenuDeleteEnabled = true;
            grid2.ContextMenuExcelEnabled = true;
            grid2.ContextMenuInsertEnabled = true;
            grid2.ContextMenuPasteEnabled = true;
            grid2.DeleteButtonEnable = true;
            appearance31.BackColor = System.Drawing.SystemColors.Window;
            appearance31.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            grid2.DisplayLayout.Appearance = appearance31;
            grid2.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            grid2.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            grid2.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance32.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance32.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance32.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance32.BorderColor = System.Drawing.SystemColors.Window;
            grid2.DisplayLayout.GroupByBox.Appearance = appearance32;
            appearance33.ForeColor = System.Drawing.SystemColors.GrayText;
            grid2.DisplayLayout.GroupByBox.BandLabelAppearance = appearance33;
            grid2.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            grid2.DisplayLayout.GroupByBox.Hidden = true;
            appearance34.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance34.BackColor2 = System.Drawing.SystemColors.Control;
            appearance34.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance34.ForeColor = System.Drawing.SystemColors.GrayText;
            grid2.DisplayLayout.GroupByBox.PromptAppearance = appearance34;
            grid2.DisplayLayout.MaxColScrollRegions = 1;
            grid2.DisplayLayout.MaxRowScrollRegions = 1;
            appearance35.BackColor = System.Drawing.SystemColors.Window;
            appearance35.ForeColor = System.Drawing.SystemColors.ControlText;
            grid2.DisplayLayout.Override.ActiveCellAppearance = appearance35;
            appearance36.BackColor = System.Drawing.SystemColors.Highlight;
            appearance36.ForeColor = System.Drawing.SystemColors.HighlightText;
            grid2.DisplayLayout.Override.ActiveRowAppearance = appearance36;
            grid2.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            grid2.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.All;
            grid2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            grid2.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance37.BackColor = System.Drawing.SystemColors.Window;
            grid2.DisplayLayout.Override.CardAreaAppearance = appearance37;
            appearance38.BorderColor = System.Drawing.Color.Silver;
            appearance38.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            grid2.DisplayLayout.Override.CellAppearance = appearance38;
            grid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            grid2.DisplayLayout.Override.CellPadding = 0;
            appearance39.BackColor = System.Drawing.SystemColors.Control;
            appearance39.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance39.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance39.BorderColor = System.Drawing.SystemColors.Window;
            grid2.DisplayLayout.Override.GroupByRowAppearance = appearance39;
            appearance40.TextHAlignAsString = "Left";
            grid2.DisplayLayout.Override.HeaderAppearance = appearance40;
            grid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            grid2.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            grid2.DisplayLayout.Override.MinRowHeight = 30;
            appearance41.BackColor = System.Drawing.SystemColors.Window;
            appearance41.BorderColor = System.Drawing.Color.Silver;
            grid2.DisplayLayout.Override.RowAppearance = appearance41;
            grid2.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance42.BackColor = System.Drawing.SystemColors.ControlLight;
            grid2.DisplayLayout.Override.TemplateAddRowAppearance = appearance42;
            grid2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            grid2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            grid2.DisplayLayout.SelectionOverlayBorderThickness = 2;
            grid2.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            grid2.Dock = System.Windows.Forms.DockStyle.Fill;
            grid2.EnterNextRowEnable = true;
            grid2.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            grid2.Location = new System.Drawing.Point(1, 22);
            grid2.Margin = new System.Windows.Forms.Padding(0);
            grid2.Name = "grid2";
            grid2.Size = new System.Drawing.Size(538, 669);
            grid2.TabIndex = 200;
            grid2.Text = "grid2";
            grid2.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            grid2.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            grid2.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            grid2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            grid2.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(grid2_ClickCellButton);
            grid2.DoubleClickCell += new Infragistics.Win.UltraWinGrid.DoubleClickCellEventHandler(grid2_DoubleClickCell);
            ultraSplitter1.Location = new System.Drawing.Point(584, 6);
            ultraSplitter1.Name = "ultraSplitter1";
            ultraSplitter1.RestoreExtent = 0;
            ultraSplitter1.Size = new System.Drawing.Size(6, 692);
            ultraSplitter1.TabIndex = 6;
            appearance43.FontData.SizeInPoints = 10f;
            gbxVersion.Appearance = appearance43;
            gbxVersion.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.HeaderSolid;
            gbxVersion.Controls.Add(grid1);
            gbxVersion.Controls.Add(cbxSystemID);
            gbxVersion.Dock = System.Windows.Forms.DockStyle.Left;
            gbxVersion.Location = new System.Drawing.Point(6, 6);
            gbxVersion.Margin = new System.Windows.Forms.Padding(2);
            gbxVersion.Name = "gbxVersion";
            gbxVersion.Size = new System.Drawing.Size(578, 692);
            gbxVersion.TabIndex = 7;
            gbxVersion.Text = "프로그램 목록";
            gbxVersion.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.XP;
            grid1.AutoResizeColumn = true;
            grid1.AutoUserColumn = true;
            grid1.ContextMenuCopyEnabled = true;
            grid1.ContextMenuDeleteEnabled = true;
            grid1.ContextMenuExcelEnabled = true;
            grid1.ContextMenuInsertEnabled = true;
            grid1.ContextMenuPasteEnabled = true;
            grid1.DeleteButtonEnable = true;
            appearance44.BackColor = System.Drawing.SystemColors.Window;
            appearance44.BorderColor = System.Drawing.Color.Silver;
            appearance44.BorderColor2 = System.Drawing.Color.Transparent;
            grid1.DisplayLayout.Appearance = appearance44;
            grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.TwoColor;
            grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance45.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance45.BorderColor = System.Drawing.SystemColors.Window;
            grid1.DisplayLayout.GroupByBox.Appearance = appearance45;
            appearance46.ForeColor = System.Drawing.SystemColors.GrayText;
            grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance46;
            grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance47.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance47.BackColor2 = System.Drawing.SystemColors.Control;
            appearance47.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance47.ForeColor = System.Drawing.SystemColors.GrayText;
            grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance47;
            grid1.DisplayLayout.MaxColScrollRegions = 1;
            grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance48.BackColor = System.Drawing.SystemColors.Window;
            appearance48.ForeColor = System.Drawing.SystemColors.ControlText;
            grid1.DisplayLayout.Override.ActiveCellAppearance = appearance48;
            appearance49.BackColor = System.Drawing.SystemColors.Highlight;
            appearance49.ForeColor = System.Drawing.SystemColors.HighlightText;
            grid1.DisplayLayout.Override.ActiveRowAppearance = appearance49;
            grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            grid1.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.All;
            grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance50.BackColor = System.Drawing.SystemColors.Window;
            grid1.DisplayLayout.Override.CardAreaAppearance = appearance50;
            appearance51.BorderColor = System.Drawing.Color.Silver;
            appearance51.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            grid1.DisplayLayout.Override.CellAppearance = appearance51;
            grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            grid1.DisplayLayout.Override.CellPadding = 0;
            appearance52.BackColor = System.Drawing.SystemColors.Control;
            appearance52.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance52.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance52.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance52.BorderColor = System.Drawing.SystemColors.Window;
            grid1.DisplayLayout.Override.GroupByRowAppearance = appearance52;
            appearance53.TextHAlignAsString = "Left";
            grid1.DisplayLayout.Override.HeaderAppearance = appearance53;
            grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            grid1.DisplayLayout.Override.MinRowHeight = 30;
            appearance54.BackColor = System.Drawing.SystemColors.Window;
            appearance54.BorderColor = System.Drawing.Color.Silver;
            grid1.DisplayLayout.Override.RowAppearance = appearance54;
            grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance55.BackColor = System.Drawing.SystemColors.ControlLight;
            grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance55;
            grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            grid1.EnterNextRowEnable = true;
            grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            grid1.Location = new System.Drawing.Point(1, 22);
            grid1.Margin = new System.Windows.Forms.Padding(0);
            grid1.Name = "grid1";
            grid1.Size = new System.Drawing.Size(576, 669);
            grid1.TabIndex = 199;
            grid1.Text = "grid1";
            grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;

            grid1.ClickCell += new Infragistics.Win.UltraWinGrid.ClickCellEventHandler(grid1_ClickCell);
            grid1.AfterRowInsert += new Infragistics.Win.UltraWinGrid.RowEventHandler(grid1_AfterRowInsert);
            grid1.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(grid1_ClickCellButton);
            appearance56.ForeColor = System.Drawing.Color.Red;
            appearance56.TextVAlignAsString = "Middle";
            ultraLabel1.Appearance = appearance56;
            ultraLabel1.Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Bold);
            ultraLabel1.Location = new System.Drawing.Point(316, 34);
            ultraLabel1.Name = "ultraLabel1";
            ultraLabel1.Size = new System.Drawing.Size(800, 28);
            ultraLabel1.TabIndex = 201;
            ultraLabel1.Text = "주의사항 : First Setup사용자를 위해 전체 버젼업된 리스트가 존재하여야 함.";
            cboSystemID_H.AutoSize = false;
            cboSystemID_H.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            cboSystemID_H.ComboDataType = WIZ.Control.ComboDataType.CodeOnly;
            cboSystemID_H.DbConfig = null;
            cboSystemID_H.DefaultValue = "";
            appearance57.BorderColor = System.Drawing.Color.FromArgb(224, 224, 224);
            cboSystemID_H.DisplayLayout.Appearance = appearance57;
            cboSystemID_H.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            cboSystemID_H.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            cboSystemID_H.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance58.BackColor = System.Drawing.Color.Gray;
            cboSystemID_H.DisplayLayout.CaptionAppearance = appearance58;
            cboSystemID_H.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            cboSystemID_H.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.RoyalBlue;
            cboSystemID_H.DisplayLayout.InterBandSpacing = 2;
            cboSystemID_H.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance59.BackColor = System.Drawing.Color.RoyalBlue;
            appearance59.FontData.BoldAsString = "True";
            appearance59.ForeColor = System.Drawing.Color.White;
            cboSystemID_H.DisplayLayout.Override.ActiveRowAppearance = appearance59;
            appearance60.FontData.BoldAsString = "True";
            cboSystemID_H.DisplayLayout.Override.ActiveRowCellAppearance = appearance60;
            cboSystemID_H.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            cboSystemID_H.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            cboSystemID_H.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.None;
            cboSystemID_H.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010ScrollbarButton;
            appearance61.BackColor = System.Drawing.Color.DimGray;
            appearance61.BackColor2 = System.Drawing.Color.Silver;
            appearance61.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance61.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance61.BorderColor = System.Drawing.Color.White;
            appearance61.FontData.BoldAsString = "True";
            appearance61.ForeColor = System.Drawing.Color.White;
            cboSystemID_H.DisplayLayout.Override.HeaderAppearance = appearance61;
            cboSystemID_H.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance62.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            appearance62.BackColor2 = System.Drawing.Color.Gray;
            appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            cboSystemID_H.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance62;
            cboSystemID_H.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            cboSystemID_H.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            cboSystemID_H.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            cboSystemID_H.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
            appearance63.BackColor = System.Drawing.Color.FromArgb(99, 133, 188);
            appearance63.FontData.BoldAsString = "True";
            cboSystemID_H.DisplayLayout.Override.SelectedRowAppearance = appearance63;
            cboSystemID_H.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            cboSystemID_H.DisplayLayout.RowConnectorColor = System.Drawing.Color.Silver;
            cboSystemID_H.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            cboSystemID_H.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            cboSystemID_H.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            cboSystemID_H.DropDownWidth = 250;
            cboSystemID_H.Font = new System.Drawing.Font("맑은 고딕", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            cboSystemID_H.Location = new System.Drawing.Point(110, 35);
            cboSystemID_H.MajorCode = "SYSTEMID";
            cboSystemID_H.Name = "cboSystemID_H";
            cboSystemID_H.SelectedValue = null;
            cboSystemID_H.ShowDefaultValue = true;
            cboSystemID_H.Size = new System.Drawing.Size(200, 26);
            cboSystemID_H.TabIndex = 202;
            base.ClientSize = new System.Drawing.Size(1136, 774);
            base.Name = "SY0050";
            base.Load += new System.EventHandler(SY0050_Load);
            ((System.ComponentModel.ISupportInitialize)gbxHeader).EndInit();
            gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gbxBody).EndInit();
            gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cbxJobGB).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbxSystemID).EndInit();
            ((System.ComponentModel.ISupportInitialize)gbxVersionList).EndInit();
            gbxVersionList.ResumeLayout(false);
            gbxVersionList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grid2).EndInit();
            ((System.ComponentModel.ISupportInitialize)gbxVersion).EndInit();
            gbxVersion.ResumeLayout(false);
            gbxVersion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grid1).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboSystemID_H).EndInit();
            ResumeLayout(false);
        }
    }
}

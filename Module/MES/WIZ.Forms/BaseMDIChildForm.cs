using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using WIZ.Control;

namespace WIZ.Forms
{
    public class BaseMDIChildForm : BaseForm, IDisposable
    {
        private delegate void ClosePrgFormCallBack();

        public FormInfor FormInformation;

        protected AutoResetEvent AutoReset = new AutoResetEvent(initialState: false);

        protected BaseProgressForm ProgressForm;

        protected BaseProgressFormGif ProgressFormGif;

        protected bool IsShowDialog = false;

        protected string stsMessage = string.Empty;

        //private bool bDisposed = false;

        private string Flag = "N";

        private bool _bCancel;

        public bool bDoInquire = true;

        public bool bDoSave = true;

        public bool bDefaultFont = true;

        private ArrayList fControls = new ArrayList();

        //private new IContainer components = null;

        public UltraGroupBox gbxHeader;

        public UltraGroupBox gbxBody;

        private BackgroundWorker bgProcess;

        private SLabel lblInguiry;

        public bool bSetPupClosed = false;

        public SubData subData;

        public bool CancelProcess
        {
            get
            {
                return _bCancel;
            }
            set
            {
                _bCancel = value;
            }
        }

        public new bool DefaultFont
        {
            get
            {
                return bDefaultFont;
            }
            set
            {
                bDefaultFont = value;
            }
        }

        protected void ClosePrgForm()
        {
            IsShowDialog = false;
            try
            {
                if (ProgressForm != null)
                {
                    Thread.Sleep(100);
                    if (ProgressForm.InvokeRequired)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            ProgressForm.Close();
                            ProgressForm = null;
                        });
                    }
                    else
                    {
                        ProgressForm.Close();
                        ProgressForm = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageForm messageForm = new MessageForm(ex);
                messageForm.ShowDialog();
            }
        }

        protected void ClosePrgFormNew()
        {
            IsShowDialog = false;
            try
            {
                if (ProgressFormGif != null)
                {
                    Thread.Sleep(100);
                    if (ProgressFormGif.InvokeRequired)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            ProgressFormGif.Close();
                            ProgressFormGif = null;
                        });
                    }
                    else
                    {
                        ProgressFormGif.Close();
                        ProgressFormGif = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageForm messageForm = new MessageForm(ex);
                messageForm.ShowDialog();
            }
        }

        private void bgProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            ProgressFormGif = new BaseProgressFormGif(base.MdiParent.Location, base.MdiParent.Width, base.MdiParent.Height);
            ProgressFormGif.Activated += ProgressFormGif_Activated;
            ProgressFormGif.TopMost = true;
            ProgressFormGif.ShowDialog();
        }

        private void ProgressForm_Activated(object sender, EventArgs e)
        {
            AutoReset.Set();
        }

        private void ProgressFormGif_Activated(object sender, EventArgs e)
        {
            AutoReset.Set();
        }

        public BaseMDIChildForm()
        {
            InitializeComponentBase();
        }

        public new void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        ~BaseMDIChildForm()
        {
            Dispose(disposing: false);
        }

        #region 폼 오픈시 WSRYU 2021-05-17 최종 수정
        protected override void OnLoad(EventArgs e)
        {
            subData = new SubData(this.Name);
            base.OnLoad(e);
            if (!base.DesignMode && base.MdiParent != null)
            {
                FormInformation = new FormInfor(WorkerID, base.Name, ((BaseForm)base.MdiParent).Lang);
                FormInformation.ManageForm(this);

                // 각 개별 상속받은 form 의 Load 이벤트 처리 이후 실행
                // 컬럼 리스트 조회하여 처리
                SetGridHead();

                SetListColumnsName();

                SetSubData();
            }

            SaveDoWorkType("OPEN");
        }

        protected virtual void SetSubData()
        {
        }

        /// <summary>
        /// 폼 종료시 저장한 데이터를 기반으로 마지막으로 처리한 화면에 대한 정보를 읽어서
        /// 마지막 사용 상황과 똩같이 처리한다.
        /// </summary>
        private void SetGridHead()
        {
            DBHelper db = new DBHelper(false);

            try
            {
                // 이 시점에서 그리드 자체 설정에 따른 정보가 있음

                #region 그리드 설정 - 그리드 설정 정보 취득 후 처리

                DataSet ds = db.FillDataSet("USP_ZA0003_S0", CommandType.StoredProcedure
                                , db.CreateParameter("AS_SCREEN_ID", DbType.String, this.Name)
                                , db.CreateParameter("AS_USER_ID", DbType.String, LoginInfo.UserID));

                if (ds.Tables.Count == 3)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        // 사용자별 SplitContainer, UltraSplitter 등의 위치 조정 처리
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            string sConName = CModule.ToString(dr["CONTROLNAME"]);

                            System.Windows.Forms.Control con = Common.FindControl(this.Controls, sConName);

                            int ix = CModule.ToInt32(dr["X"]);
                            int iy = CModule.ToInt32(dr["Y"]);

                            switch (con.GetType().Name)
                            {
                                case "SplitContainer":
                                    {
                                        SplitContainer s = con as SplitContainer;

                                        if (s != null)
                                        {
                                            if (ix > 0)
                                            {
                                                if (iy == 1)
                                                {
                                                    s.SplitterDistance = (int)((ix / 100.0) * s.Height / 100);
                                                }
                                                else
                                                {
                                                    s.SplitterDistance = (int)((ix / 100.0) * s.Width / 100);
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case "UltraSplitter":
                                    {
                                        UltraSplitter s = con as UltraSplitter;

                                        if (s != null)
                                        {
                                            System.Windows.Forms.Control control = GetLeftControl(s);

                                            // 못 찾으면 아무 일도 일어 나지 않음.
                                            if (control != null)
                                            {
                                                // 가로가 세로보다 길면 1 - 세로 배열 - Height 수정
                                                // 가로가 세로보다 짧으면 0 - 가로 배열 - Width 수정
                                                if (iy == 1)
                                                {
                                                    control.Height = ix;
                                                }
                                                else
                                                {
                                                    control.Width = ix;
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case "CheckBox":
                                    {
                                        CheckBox c = con as CheckBox;

                                        if (c != null)
                                        {
                                            c.Checked = ix == 1;
                                        }
                                    }
                                    break;
                                case "RadioButton":
                                    {
                                        RadioButton r = con as RadioButton;

                                        if (r != null)
                                        {
                                            r.Checked = ix == 1;
                                        }
                                    }
                                    break;
                            }
                        }
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            UltraGridUtil _GridUtil = new UltraGridUtil();

                            string sGridName = CModule.ToString(dr["GRID_NAME"]);
                            // 별도로 입력한 조회 컬럼 정보가 있을 때 처리
                            DataRow[] drArr = ds.Tables[2].Select("GRID_NAME = '" + sGridName + "' ");

                            if (drArr.Length > 0)
                            {
                                // 컬럼 정보가 있을 경우에만 처리
                                // 없으면 처리 안함
                                System.Windows.Forms.Control con = Common.FindControl(this.Controls, sGridName);

                                if (con.GetType().Name == "Grid")
                                {
                                    Control.Grid grid = con as Control.Grid;

                                    if (grid != null)
                                    {
                                        bool bContextMenu = CModule.ToString(dr["CONTEXT_MENU"]) == "Y";
                                        bool bAllowEditable = CModule.ToString(dr["ALLOW_EDITABLE"]) == "Y";
                                        bool bExtendLastCol = CModule.ToString(dr["ExtendLastCol"]) == "Y";
                                        string sGridCaption = CModule.ToString(dr["GridCaption"]);
                                        bool bActiveRowWhiteColor = CModule.ToString(dr["ActiveRowWhiteColor"]) == "Y";
                                        string sAddColumns = CModule.ToString(dr["ADDCOLUMNS"]);

                                        if (sAddColumns == "N")
                                        {
                                            // 해당 항목이 N 이면 초기화 후 처리
                                            // 컬럼을 기존에 있는 것에서 추가할 것인지를 확인
                                            grid.Columns.ClearUnbound();
                                            grid.DataSource = null;

                                            if (grid.bInitSubQuery)
                                            {
                                                grid.sListColumnsUse.Clear();
                                            }
                                        }

                                        _GridUtil.InitializeGrid(grid, bContextMenu, bAllowEditable, bExtendLastCol, sGridCaption, bActiveRowWhiteColor);

                                        foreach (DataRow tdr in drArr)
                                        {
                                            string sCode = CModule.ToString(tdr["COL_KEY"]);

                                            if (grid.Columns.Exists(sCode))
                                            {
                                                continue;
                                            }

                                            string sName = CModule.ToString(tdr["COL_CAPTION"]);
                                            bool bNotNull = CModule.ToString(tdr["COL_NULLABLE"]) == "Y";

                                            GridColDataType_emu e = WIZ.GridColDataType.getGridColDataType(CModule.ToString(tdr["COL_TYPE"]));

                                            int iColWidth = CModule.ToInt32(tdr["COL_WIDTH"]);
                                            int iColLength = CModule.ToInt32(tdr["COL_MAXLENGTH"]);

                                            Infragistics.Win.HAlign hAlign = Infragistics.Win.HAlign.Default;

                                            switch (CModule.ToString(tdr["COL_ALIGN"]).ToUpper())
                                            {
                                                case "LEFT":
                                                case "L":
                                                    hAlign = HAlign.Left;
                                                    break;
                                                case "CENTER":
                                                case "C":
                                                    hAlign = HAlign.Center;
                                                    break;
                                                case "RIGHT":
                                                case "R":
                                                    hAlign = HAlign.Right;
                                                    break;
                                            }

                                            bool bVisible = CModule.ToString(tdr["COL_VISIBLE"]) == "Y";
                                            bool bEditable = CModule.ToString(tdr["COL_EDITABLE"]) == "Y";

                                            if (grid.bInitSubQuery)
                                            {
                                                if (bVisible)
                                                {
                                                    grid.sListColumnsUse.Add(sCode, sName, hAlign, false);
                                                }
                                            }

                                            _GridUtil.InitColumnUltraGrid(grid, sCode, sName, bNotNull, e, iColWidth, iColLength, hAlign, bVisible, bEditable);
                                        }

                                        grid.bInitSubQuery = false;

                                        _GridUtil.SetInitUltraGridBind(grid);
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion

                #region 그리드 추가 정보 설정
                // WSRYU 2021-11-12 추가
                // 컬럼 정보 : 합계, 부분합계, 숨기기, 정렬 
                // 적용지점 : DataBinds

                #endregion
            }
            catch (Exception ex)
            {
                // 아무 것도 처리하지 않음
                // 해당 로직에서 오류가 나더라도 프로그램 사용에 문제가 되지 않음.
            }
        }

        private void SetListColumnsName()
        {
            findControls(this, true);

            foreach (System.Windows.Forms.Control con in fControls)
            {
                if (con.GetType().ToString() == "WIZ.Control.Grid")
                {
                    WIZ.Control.Grid grid = con as WIZ.Control.Grid;

                    if (grid != null)
                    {
                        grid.SetListColumnsName();
                    }
                }
            }
        }
        #endregion

        private void ProgressForm_Load(object sender, EventArgs e)
        {
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            if (base.MdiParent != null)
            {
                foreach (DictionaryEntry item in FormInformation.FormFunction)
                {
                    ((IForm)base.MdiParent).SetToolBarButton((string)item.Key, (bool)item.Value);
                }

                System.Windows.Forms.Control con = GetControl(this, "cbo_PLANTCODE_H");

                if (con != null)
                {
                    Infragistics.Win.UltraWinEditors.UltraComboEditor t = con as Infragistics.Win.UltraWinEditors.UltraComboEditor;
                    if (t != null)
                    {
                        t.Value = WIZ.LoginInfo.PlantCode;
                    }
                }

                SetStatusMessage(stsMessage);
                ((IForm)base.MdiParent).SetFormID(base.Name);
                ((IForm)base.MdiParent).SetLink(this, bLink: true);
                ((IForm)this.MdiParent).SetTextForID("", "stbLastUpdate");
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (base.MdiParent != null && FormInformation != null)
            {
                SetStatusMessage(string.Empty);
                SaveDoWorkType("CLOSE");
            }
        }

        protected override void OnDeactivate(EventArgs e)
        {
            if (Flag == "N")
            {
                base.OnDeactivate(e);
                if (base.MdiParent != null)
                {
                    foreach (DictionaryEntry item in FormInformation.FormFunction)
                    {
                        ((IForm)base.MdiParent).SetToolBarButton((string)item.Key, isBtnEnabled: false);
                    }
                    ((IForm)base.MdiParent).SetFormID("");
                    ((IForm)base.MdiParent).SetLink(this, bLink: false);
                }
            }
            else
            {
                Flag = "N";
            }
        }

        public override void DoToolBarClick(string key)
        {
            if (!bgProcess.IsBusy)
            {
                switch (key)
                {
                    case "InqFunc":
                        DoBaseInquire(showMessage: true);
                        SaveDoWorkType("QUERY");
                        break;
                    case "SaveFunc":
                        DoBaseSave();
                        SaveDoWorkType("SAVE");
                        break;
                    case "ExcelFunc":
                        DoBaseDownloadExcel();
                        SaveDoWorkType("EXCEL");
                        break;
                    case "ExeImFunc":
                        DoBaseImportExcel();
                        SaveDoWorkType("EXCELUPLOAD");
                        break;
                    case "NewFunc":
                        DoBaseNew();
                        SaveDoWorkType("ADD");
                        break;
                    case "DelFunc":
                        DoBaseDelete();
                        SaveDoWorkType("DELETE");
                        break;
                    case "SumFunc":
                        DoBaseSum();
                        break;
                    case "PrintFunc":
                        DoReport();
                        break;
                    case "CloseFunc":
                        DoBaseClose();
                        return;
                }
                SetStatusMessage(stsMessage);
            }
        }

        #region 조회
        public void DoBaseInquire(bool showMessage)
        {
            try
            {
                stsMessage = string.Empty;
                bDoInquire = false;
                SetTextRowCount("");
                ((IForm)this.MdiParent).SetTextForID("", "stbLastUpdate");
                DoInquire();
                if (CancelProcess)
                {
                    IsShowDialog = false;
                    ClosePrgForm();
                    ClosePrgFormNew();
                }
                else
                {
                    if (!CancelProcess && stsMessage == string.Empty)
                    {
                        stsMessage = Common.getLangText("데이터가 조회되었습니다.", "MSG");
                    }

                    LoadLastSaveTime();

                    // 데이터 조회 후 조회한 그리드의 컬럼을 확인 후 처리
                    // WSRYU 2021-05-17 추가
                    // 조회 한 데이터지만, 설정되어 있지 않은 컬럼이라면 안 보이도록 함
                    DataRow dr = subData["METHOD_TYPE", "NOT_HIDDEN"];

                    if (dr == null)
                    {
                        SetColumnViewStatus();
                    }
                    CancelProcess = false;
                }
            }
            catch (SException ex)
            {
                ClosePrgForm();
                ClosePrgFormNew();
                MessageForm messageForm = new MessageForm(ex);
                stsMessage = messageForm.lblMessage.Text;
                messageForm.ShowDialog();
            }
            catch (Exception ex2)
            {
                ClosePrgFormNew();
                MessageForm messageForm2 = new MessageForm(ex2);
                messageForm2.ShowDialog();
            }
            finally
            {
                ClosePrgFormNew();
                bDoInquire = true;
            }
        }

        private void LoadLastSaveTime()
        {
            DBHelper db = new DBHelper(false);

            try
            {

                DataTable dt = db.FillTable("USP_ZA0003_S1", CommandType.StoredProcedure
                                , db.CreateParameter("AS_PLANTCODE", DbType.String, LoginInfo.PlantCode)
                                , db.CreateParameter("AS_PROGRAMID", DbType.String, this.Name));

                if (dt.Rows.Count >= 0)
                {
                    string s = CModule.ToString(dt.Rows[0]["WORKERNAME"]) + " " + CModule.ToString(dt.Rows[0]["LASTDATETIME"]);
                    ((IForm)this.MdiParent).SetTextForID(s, "stbLastUpdate");
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// WSRYU 2021-05-17 추가
        /// 조회한 데이터지만, 설정되어 있지 않은 컬럼이라면 안 보이도록 함
        /// </summary>
        private void SetColumnViewStatus()
        {
            findControls(this);

            foreach (System.Windows.Forms.Control con in fControls)
            {
                if (con.GetType().ToString() == "WIZ.Control.Grid")
                {
                    WIZ.Control.Grid grid = con as WIZ.Control.Grid;

                    if (grid != null)
                    {
                        foreach (UltraGridColumn uc in grid.Columns)
                        {
                            if (!grid.sListColumnsName.Contains(uc.Key))
                            {
                                uc.Hidden = true;
                            }
                        }
                    }
                }
            }
        }

        public virtual void DoInquire()
        {
            if (bDoInquire)
            {
                DoBaseInquire(showMessage: true);
            }
            else if (!bgProcess.IsBusy)
            {
                bgProcess.RunWorkerAsync("Searching...");
                AutoReset.WaitOne();
            }
        }
        #endregion

        public void DoBaseNew()
        {
            try
            {
                stsMessage = string.Empty;
                DoNew();
                if (stsMessage == string.Empty)
                {
                    stsMessage = Common.getLangText("데이터 행이 추가되었습니다.", "MSG");
                }
            }
            catch (SException ex)
            {
                MessageForm messageForm = new MessageForm(ex);
                stsMessage = messageForm.lblMessage.Text;
                messageForm.ShowDialog();
            }
            catch (Exception ex2)
            {
                MessageForm messageForm2 = new MessageForm(ex2);
                stsMessage = messageForm2.lblMessage.Text;
                messageForm2.ShowDialog();
            }
        }

        public virtual void DoNew()
        {
        }

        public void DoBaseDelete()
        {
            try
            {
                stsMessage = string.Empty;
                DoDelete();
                if (stsMessage == string.Empty)
                {
                    stsMessage = Common.getLangText("데이터 행 삭제 상태로 변경(저장시 반영) 되었습니다.", "MSG");
                }
            }
            catch (SException ex)
            {
                MessageForm messageForm = new MessageForm(ex);
                stsMessage = messageForm.lblMessage.Text;
                messageForm.ShowDialog();
            }
        }

        public virtual void DoDelete()
        {
        }

        public virtual string CanDeleteCheck(UltraGridRow ugr)
        {
            return "";
        }

        public virtual string CanModifyCheck(UltraGridRow ugr)
        {
            return "";
        }

        public void DoBaseSave()
        {
            try
            {
                stsMessage = string.Empty;
                CancelProcess = false;
                bDoSave = false;
                DoSave();
                if (CancelProcess)
                {
                    IsShowDialog = false;
                    ClosePrgForm();
                    ClosePrgFormNew();
                }
                else
                {
                    if (stsMessage == string.Empty)
                    {
                        stsMessage = Common.getLangText("데이터가 저장되었습니다.", "MSG");
                    }

                    // 마지막 저장한 시각 저장
                    SaveLastSaveTime();

                    ClosePrgFormNew();
                }
            }
            catch (SException ex)
            {
                ClosePrgFormNew();
                MessageForm messageForm = new MessageForm(ex);
                messageForm.ShowDialog();
            }
            catch (Exception ex2)
            {
                ClosePrgFormNew();
                MessageForm messageForm2 = new MessageForm(ex2);
                messageForm2.ShowDialog();
            }
        }

        private void SaveLastSaveTime()
        {
            DBHelper db = new DBHelper("", true);

            try
            {
                db.ExecuteNoneQuery("USP_ZA0003_U1", CommandType.StoredProcedure
                                , db.CreateParameter("AS_PLANTCODE", DbType.String, LoginInfo.PlantCode)
                                , db.CreateParameter("AS_PROGRAMID", DbType.String, this.Name)
                                , db.CreateParameter("AS_WORKER", DbType.String, LoginInfo.UserID));

                db.Commit();
            }
            catch (Exception ex)
            {

            }
        }

        public virtual void DoSave()
        {
            if (bDoSave)
            {
                DoBaseSave();
            }
            else if (!bgProcess.IsBusy)
            {
                bgProcess.RunWorkerAsync("Save...");
                AutoReset.WaitOne();
            }
        }

        public void DoBaseDownloadExcel()
        {
            try
            {
                DoDownloadExcel();
                ClosePrgFormNew();
            }
            catch (SException ex)
            {
                MessageForm messageForm = new MessageForm(ex);
                stsMessage = messageForm.lblMessage.Text;
                messageForm.ShowDialog();
            }
            catch (Exception ex2)
            {
                MessageForm messageForm2 = new MessageForm(ex2);
                stsMessage = messageForm2.lblMessage.Text;
                messageForm2.ShowDialog();
            }
        }

        public void DoBaseImportExcel()
        {
            try
            {
                DoImportExcel();
                ClosePrgFormNew();
            }
            catch (SException ex)
            {
                MessageForm messageForm = new MessageForm(ex);
                stsMessage = messageForm.lblMessage.Text;
                messageForm.ShowDialog();
            }
            catch (Exception ex2)
            {
                MessageForm messageForm2 = new MessageForm(ex2);
                stsMessage = messageForm2.lblMessage.Text;
                messageForm2.ShowDialog();
            }
        }

        public virtual void DoDownloadExcel()
        {
            if (!bgProcess.IsBusy)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.FileName = this.Text + " " + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    bgProcess.RunWorkerAsync("Downloading...");
                    AutoReset.WaitOne();
                    ((IForm)base.MdiParent).ExportExcel(saveFileDialog.FileName);
                }
            }
        }

        public virtual void DoImportExcel()
        {
            ((IForm)base.MdiParent).ImportExcel();
        }

        public new virtual void Tree_Refresh()
        {
            ((IForm)base.MdiParent).Tree_Refresh();
        }

        public void OpenWaitForm()
        {
            bgProcess.RunWorkerAsync("Downloading...");
            AutoReset.WaitOne();
        }

        public virtual void DoBaseSum()
        {
        }

        public virtual void DoReport()
        {
        }

        public void DoBaseClose()
        {
            DoClose();
            Close();
        }

        public virtual void DoClose()
        {
        }

        public DialogResult ShowDialog(string messageid, DialogForm.DialogType sType = DialogForm.DialogType.YESNO)
        {
            DialogForm dialogForm = new DialogForm(messageid, sType);
            DialogResult dialogResult;
            return dialogResult = dialogForm.ShowDialog();
        }

        protected void SetStatusMessage(string message)
        {
            ((IForm)base.MdiParent).SetStatusBarMessage(message);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!base.ProcessCmdKey(ref msg, keyData))
            {
                return false;
            }
            return true;
        }

        private void SaveDoWorkType(string sType)
        {
            if (!(base.Name == "BaseMDIChildForm"))
            {
                try
                {
                    DBHelper dBHelper = new DBHelper(completedClose: false);
                    try
                    {
                        dBHelper.ExecuteNoneQuery("USP_SY0700_I1", CommandType.StoredProcedure, dBHelper.CreateParameter("ProgramID", base.Name, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("WorkerID", WorkerID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("WorkType", sType, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("IP", IP, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("Comname", Environment.MachineName.ToString(), DbType.String, ParameterDirection.Input));
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage(ex);
                    }
                    finally
                    {
                        dBHelper.Close();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        public void ThrowError(string ErrorCode)
        {
            SException ex = new SException(ErrorCode, null);
            throw ex;
        }

        public void ThrowError(string errorcode, string msg)
        {
            SException ex = new SException(errorcode, null);
            throw ex;
        }

        public void ThrowError(Exception ex)
        {
            throw ex;
        }

        public void ThrowError(SException ex)
        {
            throw ex;
        }

        public void ShowProgressForm(string msg)
        {
            if (!bgProcess.IsBusy)
            {
                bgProcess.RunWorkerAsync(FormInformation.GetMessage(msg));
                AutoReset.WaitOne();
            }
        }

        public void ShowErrorMessage(Exception ex)
        {
            MessageForm messageForm = new MessageForm(ex);
            stsMessage = messageForm.lblMessage.Text;
            messageForm.ShowDialog();
        }

        public void ShowErrorMessage(SException ex)
        {
            MessageForm messageForm = new MessageForm(ex);
            stsMessage = messageForm.lblMessage.Text;
            messageForm.ShowDialog();
        }

        #region 폼 닫힐때 이벤트 - WSRYU 2021-05-17 최종수정
        private void BaseMDIChildForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // WSRYU 2021-05-11 수정
            findControls(this);

            foreach (System.Windows.Forms.Control fControl in fControls)
            {
                SetControlData(fControl);
            }
        }

        /// <summary>
        /// 각 컨트롤에 따라서 필요한 기능에 대한 기본 정보를 DB에 등록한다.
        /// </summary>
        /// <param name="con"></param>
        private void SetControlData(System.Windows.Forms.Control con)
        {
            switch (con.GetType().ToString())
            {
                case "Infragistics.Win.Misc.UltraSplitter":
                case "System.Windows.Forms.SplitContainer":
                    {
                        int ix = 0;
                        int iy = 0;
                        switch (con.GetType().ToString())
                        {
                            case "Infragistics.Win.Misc.UltraSplitter":
                                {
                                    UltraSplitter s = con as UltraSplitter;

                                    System.Windows.Forms.Control control = GetLeftControl(s);

                                    // 가로가 세로보다 길면 1 - 세로 배열 - Height 수정
                                    // 가로가 세로보다 짧으면 0 - 가로 배열 - Width 수정
                                    iy = s.Width > s.Height ? 1 : 0;

                                    if (control != null)
                                    {
                                        ix = iy == 1 ? control.Height : control.Width;
                                    }
                                    else
                                    {
                                        ix = 0;
                                    }
                                }
                                break;

                            case "System.Windows.Forms.SplitContainer":
                                {
                                    SplitContainer s = con as SplitContainer;

                                    if (s.Orientation == Orientation.Horizontal)
                                    {
                                        ix = (int)(1.0 * s.SplitterDistance / s.Height * 100.0 * 100.0);
                                        iy = 1;
                                    }
                                    else
                                    {
                                        ix = (int)(1.0 * s.SplitterDistance / s.Width * 100.0 * 100.0);
                                        iy = 0;
                                    }

                                }
                                break;
                        }


                        DBHelper db = new DBHelper("", true);

                        try
                        {
                            db.ExecuteNoneQuery("USP_ZA0003_U2", CommandType.StoredProcedure
                                            , db.CreateParameter("AS_SCREEN_ID", DbType.String, this.Name)
                                            , db.CreateParameter("AS_CONTROLNAME", DbType.String, con.Name)
                                            , db.CreateParameter("AS_USER", DbType.String, LoginInfo.UserID)
                                            , db.CreateParameter("AS_X", DbType.Int32, ix)
                                            , db.CreateParameter("AS_Y", DbType.Int32, iy)
                                            );

                            db.Commit();
                        }
                        catch (Exception ex)
                        {
                            // 오류 처리하지 않음.
                            // 이 기능이 동작하지 않는다고 시스템에 영향이 미치지 않는다.
                        }
                    }
                    break;
                case "WIZ.Control.Grid":
                    ((WIZ.Control.Grid)con).Close();
                    break;
                case "System.Windows.Forms.CheckBox":
                case "System.Windows.Forms.RadioButton":
                    {
                        bool bCheck = false;
                        bool bOK = false;

                        if (con.GetType().ToString() == "System.Windows.Forms.CheckBox")
                        {
                            CheckBox c = con as CheckBox;

                            bCheck = c.Checked;

                            bOK = true;
                        }


                        if (con.GetType().ToString() == "System.Windows.Forms.RadioButton")
                        {
                            RadioButton c = con as RadioButton;

                            bCheck = c.Checked;

                            bOK = true;
                        }

                        if (bOK)
                        {
                            DBHelper db = new DBHelper("", true);

                            try
                            {
                                db.ExecuteNoneQuery("USP_ZA0003_U2", CommandType.StoredProcedure
                                                , db.CreateParameter("AS_SCREEN_ID", DbType.String, this.Name)
                                                , db.CreateParameter("AS_CONTROLNAME", DbType.String, con.Name)
                                                , db.CreateParameter("AS_USER", DbType.String, LoginInfo.UserID)
                                                , db.CreateParameter("AS_X", DbType.Int32, (bCheck ? 1 : 0))
                                                , db.CreateParameter("AS_Y", DbType.Int32, 0)
                                                );

                                db.Commit();
                            }
                            catch (Exception ex)
                            {
                                // 오류 처리하지 않음.
                                // 이 기능이 동작하지 않는다고 시스템에 영향이 미치지 않는다.
                            }
                        }
                    }
                    break;
            }
        }

        private System.Windows.Forms.Control GetLeftControl(UltraSplitter con)
        {
            System.Windows.Forms.Control c = con.Parent;
            System.Windows.Forms.Control tCon = null;
            bool bHorizon = false;

            if (c != null)
            {
                int iPoint = 0;

                if (con.Width > con.Height)
                {
                    // 가로가 높이보다 더 길다 ( 가로 분할 )
                    iPoint = con.Top;
                    bHorizon = true;
                }
                else
                {
                    // 그렇지 않다 ( 세로 분할 )
                    iPoint = con.Left;
                    bHorizon = false;
                }

                foreach (System.Windows.Forms.Control co in c.Controls)
                {
                    if (co.Name != con.Name)
                    {
                        if (bHorizon)
                        {
                            if (co.Top + co.Height <= iPoint)
                            {
                                if (tCon != null)
                                {
                                    // 
                                    if (co.Top + co.Height > tCon.Top + tCon.Height)
                                    {
                                        tCon = co;
                                    }
                                }
                                else
                                {
                                    tCon = co;
                                }
                            }
                        }
                        else
                        {
                            if (co.Left + co.Width <= iPoint)
                            {
                                if (tCon != null)
                                {
                                    // 
                                    if (co.Left + co.Width > tCon.Left + tCon.Width)
                                    {
                                        tCon = co;
                                    }
                                }
                                else
                                {
                                    tCon = co;
                                }
                            }
                        }
                    }
                }
            }

            return tCon;
        }

        private string[] sListFindControl = new string[] { "WIZ.Control.Grid", "Infragistics.Win.Misc.UltraSplitter", "System.Windows.Forms.SplitContainer"
            , "System.Windows.Forms.CheckBox", "System.Windows.Forms.RadioButton" };
        #endregion

        private void findControls(System.Windows.Forms.Control pControl, bool binit = true)
        {
            try
            {
                if (binit)
                {
                    fControls.Clear();
                }
                foreach (System.Windows.Forms.Control control in pControl.Controls)
                {
                    foreach (string s in sListFindControl)
                    {
                        if (control.GetType().ToString().Equals(s))
                        {
                            fControls.Add(control);
                        }
                    }

                    findControls(control, binit: false);
                }
            }
            catch
            {
            }
        }

        private System.Windows.Forms.Control GetControl(string sControlName)
        {
            return GetControl(this, sControlName);
        }

        private System.Windows.Forms.Control GetControl(System.Windows.Forms.Control con, string sControlName)
        {
            if (con.Name == sControlName)
            {
                return con;
            }

            foreach (System.Windows.Forms.Control c in con.Controls)
            {
                System.Windows.Forms.Control co = GetControl(c, sControlName);

                if (co == null) continue;

                if (co.Name == sControlName)
                    return co;
            }

            return null;
        }


        protected override void Dispose(bool disposing)
        {
            //if (disposing && components != null)
            //{
            //	components.Dispose();
            //}
            base.Dispose(disposing);
        }

        private void InitializeComponentBase()
        {
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WIZ.Forms.BaseMDIChildForm));
            gbxHeader = new Infragistics.Win.Misc.UltraGroupBox();
            lblInguiry = new WIZ.Control.SLabel();
            gbxBody = new Infragistics.Win.Misc.UltraGroupBox();
            bgProcess = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)gbxHeader).BeginInit();
            gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gbxBody).BeginInit();
            SuspendLayout();
            appearance.BackColor = System.Drawing.Color.FromArgb(239, 243, 246);
            appearance.BackColor2 = System.Drawing.Color.FromArgb(239, 243, 246);
            gbxHeader.Appearance = appearance;
            gbxHeader.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.Rounded;
            gbxHeader.ContentPadding.Bottom = 2;
            gbxHeader.ContentPadding.Left = 2;
            gbxHeader.ContentPadding.Right = 2;
            gbxHeader.ContentPadding.Top = 4;
            gbxHeader.Controls.Add(lblInguiry);
            gbxHeader.Dock = System.Windows.Forms.DockStyle.Top;
            gbxHeader.Location = new System.Drawing.Point(0, 0);
            gbxHeader.Margin = new System.Windows.Forms.Padding(2);
            gbxHeader.Name = "gbxHeader";
            gbxHeader.Size = new System.Drawing.Size(1136, 70);
            gbxHeader.TabIndex = 1;
            gbxHeader.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.XP;
            appearance2.BackColor = System.Drawing.Color.FromArgb(215, 218, 221);
            appearance2.FontData.BoldAsString = "True";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.White;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            lblInguiry.Appearance = appearance2;
            lblInguiry.DbField = null;
            lblInguiry.Dock = System.Windows.Forms.DockStyle.Left;
            lblInguiry.Font = new System.Drawing.Font("HG꼬딕씨 40g", 9f, System.Drawing.FontStyle.Bold);
            lblInguiry.Location = new System.Drawing.Point(5, 4);
            lblInguiry.Margin = new System.Windows.Forms.Padding(0);
            lblInguiry.Name = "lblInguiry";
            lblInguiry.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.Default;
            lblInguiry.Size = new System.Drawing.Size(70, 61);
            lblInguiry.TabIndex = 1;
            lblInguiry.Text = "조회항목";
            appearance3.BackColor = System.Drawing.Color.FromArgb(239, 243, 246);
            appearance3.FontData.BoldAsString = "True";
            gbxBody.Appearance = appearance3;
            gbxBody.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            gbxBody.Dock = System.Windows.Forms.DockStyle.Fill;
            gbxBody.Location = new System.Drawing.Point(0, 70);
            gbxBody.Margin = new System.Windows.Forms.Padding(2);
            gbxBody.Name = "gbxBody";
            gbxBody.Size = new System.Drawing.Size(1136, 755);
            gbxBody.TabIndex = 2;
            gbxBody.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.XP;
            bgProcess.WorkerSupportsCancellation = true;
            bgProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(bgProcess_DoWork);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            base.ClientSize = new System.Drawing.Size(1136, 825);
            base.Controls.Add(gbxBody);
            base.Controls.Add(gbxHeader);
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.Name = "BaseMDIChildForm";
            Text = "";
            base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(BaseMDIChildForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)gbxHeader).EndInit();
            gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gbxBody).EndInit();
            ResumeLayout(false);
        }
    }
}

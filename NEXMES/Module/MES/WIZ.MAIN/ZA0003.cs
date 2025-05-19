using Infragistics.Win;
using Infragistics.Win.AppStyling;
using Infragistics.Win.IGControls;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinForm;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinStatusBar;
using Infragistics.Win.UltraWinTabbedMdi;
using Infragistics.Win.UltraWinTree;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using WIZ.Control;
using WIZ.Forms;

namespace WIZ.MAIN
{
    public class ZA0003 : BaseForm
    {
        private delegate void SetTextCallback(string text, string sID);

        private delegate void ClosePrgFormCallBack();

        protected BackgroundWorker bgProcess;

        protected BaseProgressForm ProgressForm;

        protected BaseProgressFormGif ProgressFormGif;

        protected AutoResetEvent AutoReset = new AutoResetEvent(initialState: false);

        public bool CloseCheck = false;

        protected bool IsShowDialog = false;

        protected BackgroundWorker bgLiveUpdate;

        private Configuration appConfig;

        private string systemID;

        private string version;

        private int lvchecktime;

        public FormInfor FormInformation;

        private bool close = false;

        private Point LastMouseDown;

        private string loginName;

        private bool bMainBody = false;

        private WIZ.Control.Grid activeGrid;

        private DataTable rtnDtTemp1 = new DataTable();

        private Hashtable hash = new Hashtable();

        private IGMenuItem miAllClose;

        private IGMenuItem miSeparator;

        private IGMenuItem miOthersClose;

        private IGMenuItem miSeparator2;

        private IGMenuItem miLang;

        private string Tab_AllClose = "All Close";

        private string Tab_OthersClose = "Others Close";

        private string Tab_LANG = "Language Localization";

        private string LastActiveNode = string.Empty;

        private DataTable TreeDT = new DataTable();

        private Common _common = new Common();

        private bool binit = false;

        private int cboMenuIndex = -1;

        private int cboStyleIndex = -1;

        private bool allowResize = false;

        private UltraGridRow dragRow = null;

        private UltraTreeNode dragUtn = null;

        private Point pPFV = new Point(0, 0);

        private Point mPFV = new Point(0, 0);

        private DataTable dtControl = new DataTable();

        private new IContainer components = null;

        private UltraStatusBar stsMain;

        private UltraFormDockArea _BaseForm_UltraFormManager_Dock_Area_Left;

        private UltraFormDockArea _BaseForm_UltraFormManager_Dock_Area_Right;

        private UltraFormDockArea _BaseForm_UltraFormManager_Dock_Area_Top;

        private UltraFormDockArea _BaseForm_UltraFormManager_Dock_Area_Bottom;

        private UltraTabbedMdiManager udtMdiManager;

        public AutoHideControl _BaseFormAutoHideControl;

        public UltraDockManager dockManager;

        public UnpinnedTabArea _BaseFormUnpinnedTabAreaTop;

        public UnpinnedTabArea _BaseFormUnpinnedTabAreaBottom;

        public UnpinnedTabArea _BaseFormUnpinnedTabAreaRight;

        public UnpinnedTabArea _BaseFormUnpinnedTabAreaLeft;

        private ToolStrip tlbMain;

        private ToolStripButton InqFunc;

        private ToolStripButton NewFunc;

        private ToolStripButton DelFunc;

        private ToolStripButton SaveFunc;

        private ToolStripButton ExcelFunc;

        private ToolStripButton PrintFunc;

        private ToolStripButton CloseFunc;

        private UltraFormDockArea _BaseForm_UltraFormManager_Dock_Area_1_Left;

        private UltraFormManager ufmForm;

        private UltraFormDockArea _BaseForm_UltraFormManager_Dock_Area_1_Right;

        private UltraFormDockArea _BaseForm_UltraFormManager_Dock_Area_1_Top;

        private UltraFormDockArea _BaseForm_UltraFormManager_Dock_Area_1_Bottom;

        private ToolStripSeparator tss03;

        private ToolStripButton FilterFunc;

        private ToolStripButton SumFunc;

        private ImageList imlMenu;

        private ToolStripButton HelpFunc;

        private ToolStripLabel lblMenu;

        private ToolStripComboBox cboMenu;

        private MenuStrip menuStrip1;

        private ToolStripButton FavoriteFunc;

        private UltraPanel ultraPanelFV;

        private WIZ.Control.Grid gridFV;

        private UltraGridColumnChooser ultraGridColumnChooser1;

        private UltraPanel ultraPanelCC;

        private PictureBox picResize;

        private ToolStripLabel lblStyle;

        private ToolStripComboBox cboStyle;

        private ImageList imgMenu1;

        private ImageList imgMenu2;

        private UltraPanel picMainBody;

        private UltraPanel ultraPanel1;

        private UltraTree treMenu;

        private ToolStripSeparator tss01;

        private PictureBox pictureBox1;
        private STextBox txtSearch;
        private ToolStripLabel lblLogo;

        private ToolStripComboBox cboSite;

        private WindowDockingArea windowDockingArea1;

        private DockableWindow dockableWindow1;

        private ToolStripSeparator tss02;

        private ToolStripButton ExitFunc;

        private ToolStripButton LangFunc;

        private UltraPanel pnlLang;

        private UltraComboEditor cboLang;

        private PictureBox picExit;

        private ToolStripButton ExeImFunc;

        public object[] param
        {
            get;
            set;
        }

        public UltraTree TreeMenu => treMenu;

        public WIZ.Control.Grid ActiveGrid
        {
            get
            {
                if (activeGrid == null)
                {
                    if (hash.Values.Count >= 1)
                    {
                        if (hash.ContainsKey("grid1"))
                        {
                            return (WIZ.Control.Grid)hash["grid1"];
                        }
                        {
                            IEnumerator enumerator = hash.Values.GetEnumerator();
                            try
                            {
                                if (enumerator.MoveNext())
                                {
                                    return (WIZ.Control.Grid)enumerator.Current;
                                }
                            }
                            finally
                            {
                                IDisposable disposable = enumerator as IDisposable;
                                if (disposable != null)
                                {
                                    disposable.Dispose();
                                }
                            }
                        }
                    }
                    return null;
                }
                return activeGrid;
            }
        }

        public ZA0003()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Text = "";
        }

        public ZA0003(string workerid, string WorkerName)
        {
            try
            {
                InitializeComponent();
                base.ImeMode = ImeMode.Hangul;
                Common.ProcessName = Process.GetCurrentProcess().ProcessName;
                WorkerID = workerid;
                appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                LoginInfo.UserID = WorkerID;
                LoginInfo.PlantCode = CModule.GetAppSetting("PLANTCODE", "10");
                Lang = CModule.GetAppSetting("LANGUAGE", "KO");
                try
                {
                    if (CModule.GetAppSetting("PLANTAUTH") == "NO")
                    {
                        Common.bPlantAuth = false;
                    }
                }
                catch
                {
                }
                Construct(WorkerName);
                EventHandler onClick = OnMenuItemEditSettingsClick;
                miSeparator = new IGMenuItem("-");
                miAllClose = new IGMenuItem(Tab_AllClose, onClick);
                miOthersClose = new IGMenuItem(Tab_OthersClose, onClick);
                components.Add(miSeparator);
                components.Add(miAllClose);
                components.Add(miOthersClose);
                if (WorkerID.Equals("SYSTEM"))
                {
                    miSeparator2 = new IGMenuItem("-");
                    miLang = new IGMenuItem(Tab_LANG, onClick);
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message, DialogForm.DialogType.OK);
            }
        }

        private void ZA0003_Load(object sender, EventArgs e)
        {
            if (!base.DesignMode)
            {
                if (base.MdiParent != null)
                {
                    FormInformation = new FormInfor(WorkerID, base.Name, ((BaseForm)base.MdiParent).Lang);
                    if (Text == "")
                    {
                        Text = systemID + " (Ver : " + version + ")";
                    }
                    FormInformation.ManageForm(this);
                }
                else
                {
                    FormInformation = new FormInfor(WorkerID, base.Name, Lang);
                    if (Text == "")
                    {
                        Text = systemID + " (Ver : " + version + ")";
                    }
                    FormInformation.ManageForm(this);
                }
            }
            try
            {
                string[] files = Directory.GetFiles(Application.StartupPath + "\\Resources\\", "*.*", SearchOption.TopDirectoryOnly);
                if (files.Length != 0)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        string fileName = Path.GetFileName(files[i]);
                        if (fileName.ToUpper().IndexOf("MAINBODY") >= 0)
                        {
                            picMainBody.Visible = true;
                            picMainBody.Appearance.ImageBackground = new Bitmap(Application.StartupPath + "\\Resources\\" + fileName);
                            bMainBody = true;
                        }
                        // 회사 로고
                        if (fileName.ToUpper().IndexOf("COMPANYLOGO") >= 0)
                        {
                            //Common _Common = new Common();

                            //DataTable rtnDtTemp = new DataTable();
                            //rtnDtTemp = _Common.GET_BM0000_CODE("PLANTCODE");
                            //DBHelper.nvlString(rtnDtTemp.Rows[0]["CODE_NAME_ORG"]);

                            //Bitmap image = new Bitmap(Application.StartupPath + "\\Resources\\" + fileName);
                            //lblLogo.Image = image;

                            //if(DBHelper.nvlString(rtnDtTemp.Rows[0]["CODE_NAME_ORG"]) == "제노스")
                            //{
                            //	fileName = "COMPANYLOGO_genoss.png";
                            //}
                            //else if (회사명)
                            //{

                            //}

                            Bitmap image = new Bitmap(Application.StartupPath + "\\Resources\\" + fileName);
                            lblLogo.Image = image;
                        }
                        /* 기본 로고
                        if (fileName.ToUpper().IndexOf("MAINLOGO") >= 0)
                        {
                            Bitmap image = new Bitmap(Application.StartupPath + "\\Resources\\" + fileName);
                            lblLogo.Image = image;
                        }
                        */
                    }
                }
            }
            catch (Exception ex)
            {
            }
            SetFavorite();
            binit = true;
            cboLang_ValueChanged(null, null);
        }

        private void SetFavorite()
        {
            try
            {
                DBHelper dBHelper = new DBHelper(completedClose: false);
                gridFV.DataSource = dBHelper.FillTable("USP_TSY0130_S1", CommandType.StoredProcedure, dBHelper.CreateParameter("UserID", WorkerID, DbType.String, ParameterDirection.Input));
            }
            catch
            {
            }
        }

        private void treMenu_SelectionDragStart(object sender, EventArgs e)
        {
            treMenu.DoDragDrop(treMenu.SelectedNodes[0], DragDropEffects.Copy);
        }

        private void treMenu_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            Cursor.Current = Common.CreateCursor(treMenu.SelectedNodes[0].Text);
        }

        private void tlbMain_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        public void Construct(string workerName)
        {
            try
            {
                loginName = workerName;
                bgProcess = new BackgroundWorker();
                bgProcess.DoWork += bgProcess_DoWork;
                bgProcess.WorkerSupportsCancellation = true;
                for (int i = 0; i < tlbMain.Items.Count; i++)
                {
                    if (tlbMain.Items[i].Tag != null)
                    {
                        tlbMain.Items[i].Enabled = false;
                        if (tlbMain.Items[i].Tag.ToString() == "LangFunc")
                        {
                            tlbMain.Items[i].Enabled = true;
                        }
                        if (tlbMain.Items[i].Tag.ToString() == "ExitFunc")
                        {
                            tlbMain.Items[i].Enabled = true;
                        }
                        if (tlbMain.Items[i].Tag.ToString() == "HelpFunc")
                        {
                            tlbMain.Items[i].Enabled = true;
                        }
                    }
                }
                SetLoginID("[" + WorkerID + "] " + loginName);
                systemID = CModule.GetAppSetting("SYSTEMID", "NexMES");
                version = CModule.GetAppSetting("VERSION", "");
                lvchecktime = Convert.ToInt32(CModule.GetAppSetting("LVCHECKTIME", "60")) * 1000 * 60;
                Common.SystemID = systemID;
                cboLangSet();
                cboMenuSet();
                cboStyleSet();
                BtnManyLangFlag();
                for (int j = 0; j < tlbMain.Items.Count; j++)
                {
                    if (tlbMain.Items[j].Tag != null)
                    {
                        tlbMain.Items[j].Click += tlbMain_Click;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public void cboLangSet()
        {
            try
            {
                DBHelper dBHelper = new DBHelper(completedClose: false);
                try
                {
                    DataTable dataTable = dBHelper.FillTable("USP_ZA0000_S3", CommandType.StoredProcedure);
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        cboLang.Items.Add(dataTable.Rows[i]["MinorCode"]);
                    }
                    cboLang.Text = Common.Lang;
                }
                catch (Exception)
                {
                    ShowDialog(Common.getLangText("선택한 폼의 정보를 찾을 수 없습니다. 관리자에게 문의하세요.", "MSG"), DialogForm.DialogType.OK);
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

        public void cboMenuSet()
        {
            try
            {
                DataTable dataTable = _common.GET_BM0000_CODE("MENUPATTERN");
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    cboMenu.Items.Add(dataTable.Rows[i]["CODE_NAME_ORG"]);
                }
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(systemID + "\\UI");
                if (registryKey != null)
                {
                    cboMenu.SelectedIndex = cboMenu.FindString(DBHelper.nvlString(registryKey.GetValue("MENU")));
                    Common.UIMenu = DBHelper.nvlString(registryKey.GetValue("MENU"));
                }
                else
                {
                    cboMenu.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {
                ShowDialog(Common.getLangText("기초정보가 없습니다.", "MSG"), DialogForm.DialogType.OK);
            }
        }

        public void cboStyleSet()
        {
            try
            {
                DataTable dataTable = _common.GET_BM0000_CODE("STYLEPATTERN");
                if (dataTable != null)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        cboStyle.Items.Add(dataTable.Rows[i]["CODE_NAME"]);
                    }
                }
                if (cboStyle.Items.Count <= 0)
                {
                    string[] files = Directory.GetFiles(Application.StartupPath, "*.isl", SearchOption.TopDirectoryOnly);
                    if (files.Length != 0)
                    {
                        for (int j = 0; j < files.Length; j++)
                        {
                            string fileName = Path.GetFileName(files[j]);
                            fileName = fileName.Substring(0, fileName.LastIndexOf('.'));
                            if (!fileName.Equals("Style"))
                            {
                                cboStyle.Items.Add(fileName);
                            }
                        }
                    }
                }
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(systemID + "\\UI");
                if (registryKey != null)
                {
                    cboStyle.SelectedIndex = cboStyle.FindString(DBHelper.nvlString(registryKey.GetValue("STYLE")));
                    Common.UIStyle = DBHelper.nvlString(registryKey.GetValue("STYLE"));
                }
                else
                {
                    cboStyle.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {
                ShowDialog(Common.getLangText("기초정보가 없습니다.", "MSG"), DialogForm.DialogType.OK);
            }
        }

        private void BtnManyLangFlag()
        {
            DataTable dataTable = _common.GET_BM0000_CODE("MANYLANGFLAG");
            if (dataTable.Rows.Count != 0)
            {
                if (Convert.ToString(dataTable.Rows[0]["RELCODE1"]) == "Y")
                {
                    tlbMain.Items["LangFunc"].Visible = true;
                }
                else
                {
                    tlbMain.Items["LangFunc"].Visible = false;
                }
            }
            else
            {
                tlbMain.Items["LangFunc"].Visible = false;
            }
        }

        private void bgLiveUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            bool flag = false;
            int num = 0;
            try
            {
                DBHelper dBHelper = new DBHelper(completedClose: false);
                try
                {
                    do
                    {
                        Thread.Sleep(lvchecktime);
                        num++;
                        rtnDtTemp1 = dBHelper.FillTable("SELECT ISNULL(MAX(VER), '') FROM TSY0050 WITH(NOLOCK) WHERE SystemID = '" + systemID + "'", CommandType.Text);
                        string text = rtnDtTemp1.Rows[0][0].ToString();
                        if (text.CompareTo(version) > 0 && ShowDialog(Common.getLangText("프로그램 구성 변경을 감지하였습니다. 업데이터 하시겠습니까? (주의, 프로그램 재실행)", "MSG")) == DialogResult.OK)
                        {
                            close = true;
                            flag = true;
                            Application.Restart();
                        }
                    }
                    while (!bgLiveUpdate.CancellationPending);
                    if (flag)
                    {
                        close = true;
                        ShowDialog(Common.getLangText("프로그램 구성이 바뀌었습니다. 재실행하세요.", "MSG"), DialogForm.DialogType.OK);
                        Application.Restart();
                    }
                }
                catch (Exception)
                {
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

        public void tlbMain_Click_ByTag(string sTag)
        {
            foreach (ToolStripItem item in tlbMain.Items)
            {
                if (CModule.ToString(item.Tag) == sTag)
                {
                    tlbMain_Click(item, new EventArgs());
                    return;
                }
            }
        }

        public void tlbMain_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender == null)
                    return;

                if (!ToolBarButtonBeforeFunction(((ToolStripItem)sender).Tag.ToString()))
                {
                    return;
                }
                ((IForm)base.ActiveMdiChild).DoToolBarClick(((ToolStripItem)sender).Tag.ToString());
            }
            catch
            {
            }
            ToolBarButtonAfeterFunction(((ToolStripItem)sender).Tag.ToString());
        }

        private bool ToolBarButtonBeforeFunction(string sTag)
        {
            switch (sTag)
            {
                case "ExitFunc":
                    Close();
                    return false;
                case "LangFunc":
                    pnlLang.Visible = !pnlLang.Visible;
                    if (pnlLang.Visible)
                    {
                        pnlLang.Left = tlbMain.Right - (pnlLang.Width + 70);
                        pnlLang.Top = tlbMain.Bottom - 3;
                        pnlLang.BringToFront();
                    }
                    return false;
                case "CloseFunc":
                    base.ActiveMdiChild.Close();
                    setColumnChooser(null);
                    ultraPanelCC.Visible = false;
                    if (base.ActiveMdiChild == null)
                    {
                        tlbMain.Items["CloseFunc"].Enabled = false;
                        LastActiveNode = "";
                        if (bMainBody)
                        {
                            picMainBody.Visible = true;
                        }
                        return false;
                    }
                    return false;
                case "NewFunc":
                case "SaveFunc":
                case "DelFunc":
                case "InqFunc":
                    if (base.ActiveMdiChild == null)
                    {
                        tlbMain.Items[sTag].Enabled = false;
                        return false;
                    }
                    foreach (WIZ.Control.Grid value in hash.Values)
                    {
                        value.ClearSummary();
                        foreach (UltraGridBand band in value.DisplayLayout.Bands)
                        {
                            band.ColumnFilters.ClearAllFilters();
                        }
                        if (sTag == "SaveFunc")
                        {
                            UltraGridCell activeCell = value.ActiveCell;
                            try
                            {
                                value.ActiveCell = value.ActiveRow.Cells[value.ActiveCell.Column.Index + 1];
                            }
                            catch
                            {
                            }
                            value.ActiveCell = activeCell;
                        }
                    }
                    if (sTag == "NewFunc")
                    {
                    }
                    break;
                case "PrintFunc":
                case "ExcelFunc":
                case "ExcelUPFunc":
                case "FilterFunc":
                case "SumFunc":
                    if (base.ActiveMdiChild == null)
                    {
                        tlbMain.Items[sTag].Enabled = false;
                        return false;
                    }
                    if (sTag == "FilterFunc" && ActiveGrid != null)
                    {
                        if (ActiveGrid.DisplayLayout.Override.AllowRowFiltering != DefaultableBoolean.True)
                        {
                            ValueList filterOperatorsValueList = ActiveGrid.DisplayLayout.FilterOperatorsValueList;
                            foreach (ValueListItem valueListItem in filterOperatorsValueList.ValueListItems)
                            {
                                FilterComparisionOperator filterComparisionOperator = (FilterComparisionOperator)valueListItem.DataValue;
                                if (FilterComparisionOperator.Contains == filterComparisionOperator)
                                {
                                    valueListItem.DisplayText = Common.getLangText("포함");
                                }
                                else if (FilterComparisionOperator.StartsWith == filterComparisionOperator)
                                {
                                    valueListItem.DisplayText = Common.getLangText("앞", "filter");
                                }
                                else if (FilterComparisionOperator.EndsWith == filterComparisionOperator)
                                {
                                    valueListItem.DisplayText = Common.getLangText("뒤", "filter");
                                }
                                else if (filterComparisionOperator == FilterComparisionOperator.Equals)
                                {
                                    valueListItem.DisplayText = Common.getLangText("같음");
                                }
                            }
                            ActiveGrid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow;
                            ActiveGrid.DisplayLayout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnEnterKeyOrLeaveCell;
                            ActiveGrid.DisplayLayout.Override.FilterOperatorDropDownItems = (FilterOperatorDropDownItems.Equals | FilterOperatorDropDownItems.StartsWith | FilterOperatorDropDownItems.EndsWith | FilterOperatorDropDownItems.Contains);
                            ActiveGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
                        }
                        else
                        {
                            foreach (UltraGridBand band2 in ActiveGrid.DisplayLayout.Bands)
                            {
                                band2.ColumnFilters.ClearAllFilters();
                            }
                            ActiveGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.False;
                        }
                    }
                    break;
                case "HelpFunc":
                    try
                    {
                        Help.ShowHelp(this, Application.StartupPath + "/" + systemID + "_help.chm", HelpNavigator.TopicId, DBHelper.nvlString(((BaseMDIChildForm)base.ActiveMdiChild).FormInformation._nTopicID));
                    }
                    catch
                    {
                    }
                    break;
            }
            return true;
        }

        public bool GetToolBarStatus(string itemTag)
        {
            foreach (ToolStripItem item in tlbMain.Items)
            {
                if (CModule.ToString(item.Tag) == itemTag)
                {
                    return item.Enabled;
                }
            }
            return false;
        }

        private void ToolBarButtonAfeterFunction(string sTag)
        {
            if (!(sTag == "InqFunc"))
            {
                if (sTag == "NewFunc")
                {
                }
            }
            else
            {
                foreach (WIZ.Control.Grid value in hash.Values)
                {
                    if (!SaveFunc.Enabled)
                    {
                        value.DoReadOnly(!SaveFunc.Enabled);
                    }
                }
            }
        }

        private void bgProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            ProgressFormGif = new BaseProgressFormGif(base.Location, base.Width, base.Height);
            ProgressFormGif.Activated += ProgressFormGif_Activated;
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

        public DialogResult ShowDialog(string messageid, DialogForm.DialogType sType = DialogForm.DialogType.YESNO)
        {
            DialogForm dialogForm = new DialogForm(messageid, sType);
            if (IsShowDialog)
            {
                return DialogResult.OK;
            }
            DialogResult dialogResult;
            return dialogResult = dialogForm.ShowDialog();
        }

        public override void SetToolBarButton(string key, bool allowbutton)
        {
            try
            {
                if (!key.Equals("TopicID"))
                {
                    tlbMain.Items[key].Enabled = allowbutton;
                }
            }
            catch (Exception)
            {
            }
        }

        public override void SetFormID(string formid)
        {
            stsMain.Panels["stbFormID"].Text = formid;
            if (LastActiveNode != formid)
            {
                setColumnChooser(null);
            }
            LastActiveNode = formid;

            Common.gsSelFormID = formid;
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType().Name == formid)
                {
                    Common.gsSelFormName = f.Text;
                }
            }
        }

        public override void ExportExcel(string sFileName = "")
        {
            foreach (WIZ.Control.Grid value in hash.Values)
            {
                if (value.Focused)
                {
                    value.ExportExcel(sFileName);
                    return;
                }
            }
            if (hash.Values.Count >= 1)
            {
                {
                    IEnumerator enumerator2 = hash.Values.GetEnumerator();
                    try
                    {
                        if (enumerator2.MoveNext())
                        {
                            WIZ.Control.Grid grid2 = (WIZ.Control.Grid)enumerator2.Current;
                            grid2.ExportExcel(sFileName);
                        }
                    }
                    finally
                    {
                        IDisposable disposable = enumerator2 as IDisposable;
                        if (disposable != null)
                        {
                            disposable.Dispose();
                        }
                    }
                }
            }
        }

        public override void SetTextRowCount(string value)
        {
            stsMain.Panels["stbRowCount"].Text = "";
        }

        private void ClearHash()
        {
            foreach (WIZ.Control.Grid value in hash.Values)
            {
                value.GotFocus -= grid_GotFocus;
                value.Error -= grid_Error;
                value.AfterSelectChange -= g_AfterSelectChange;
            }
            hash.Clear();
            activeGrid = null;
        }

        private void grid_GotFocus(object sender, EventArgs e)
        {
            try
            {
                WIZ.Control.Grid grid = (WIZ.Control.Grid)sender;
                if (grid.Rows != null)
                {
                    stsMain.Panels["stbRowCount"].Text = grid.Rows.Count.ToString();
                    activeGrid = grid;
                }
            }
            catch (Exception)
            {

            }
        }

        private void g_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            WIZ.Control.Grid grid = (WIZ.Control.Grid)sender;
            if (e.Type.Name == "UltraGridCell")
            {
                int count = grid.Selected.Cells.Count;
                if (count <= 1)
                {
                    stsMain.Panels["stbRowCount"].Text = grid.Rows.Count.ToString();
                }
                else
                {
                    stsMain.Panels["stbRowCount"].Text = count.ToString();
                }
            }
            else
            {
                stsMain.Panels["stbRowCount"].Text = grid.Selected.Rows.Count.ToString() + " / " + grid.Rows.Count.ToString();
            }
        }

        public override void SetLink(Form f, bool bLink)
        {
            try
            {
                if (bLink)
                {
                    stsMain.Panels["stbRowCount"].Text = "";
                    ClearHash();
                    while (true)
                    {
                        WIZ.Control.Grid grid = getGrid(f);
                        if (grid == null)
                        {
                            break;
                        }
                        if (!SaveFunc.Enabled)
                        {
                            grid.DoReadOnly(!SaveFunc.Enabled);
                        }
                        SetGrid(grid);
                        hash.Add(grid.Name, grid);
                    }
                }
                else
                {
                    ClearHash();
                }
            }
            catch (Exception)
            {
            }
        }

        private void SetGrid(WIZ.Control.Grid grid)
        {
            grid.GotFocus += grid_GotFocus;
            grid.ContextMenuInsertEnabled = false;
            grid.ContextMenuDeleteEnabled = false;
            grid.ContextMenuExcelEnabled = ExcelFunc.Enabled;
            grid.Error += grid_Error;
            grid.AfterSelectChange += g_AfterSelectChange;
            grid.AfterDeleRowFilterChanged += grid_AfterRowFilterChanged;
            if (grid.Focused && grid.Rows != null)
            {
                stsMain.Panels["stbRowCount"].Text = grid.Rows.Count.ToString();
            }
        }

        private void grid_AfterRowFilterChanged(WIZ.Control.Grid sender, AfterRowFilterChangedEventArgs e)
        {
            tlbMain_Click(SumFunc, new EventArgs());
        }

        private void grid_Error(object sender, Infragistics.Win.UltraWinGrid.ErrorEventArgs e)
        {
            e.Cancel = true;
            switch (e.ErrorType)
            {
                case ErrorType.Data:
                    SetStatusBarMessage("Data");
                    break;
                case ErrorType.Mask:
                    SetStatusBarMessage("Mask");
                    break;
                case ErrorType.MultiCellOperation:
                    SetStatusBarMessage("MultiCellOperation");
                    break;
                case ErrorType.Printing:
                    SetStatusBarMessage("Printing");
                    break;
                case ErrorType.Generic:
                    SetStatusBarMessage("Generic");
                    break;
            }
        }

        private WIZ.Control.Grid getGrid(System.Windows.Forms.Control con)
        {
            WIZ.Control.Grid grid = null;
            if (con == null)
            {
                return null;
            }
            if (con.GetType().ToString() == "WIZ.Control.Grid" && hash[con.Name] == null)
            {
                return (WIZ.Control.Grid)con;
            }
            foreach (System.Windows.Forms.Control control in con.Controls)
            {
                grid = getGrid(control);
                if (grid != null)
                {
                    break;
                }
            }
            return grid;
        }

        public override void SetLoginID(string loginid)
        {
            stsMain.Panels["stbLoginID"].Text = loginid;
        }

        public override void SetLoginName(string loginName)
        {
            stsMain.Panels["stbLoginName"].Text = loginName;
        }

        public void SetLang(string loginid, string lang)
        {
            Common.Lang = (Lang = lang);
            if (!loginid.Equals("SYSTEM"))
            {
            }
        }

        private void SetText(string text, string sID)
        {
            if (base.InvokeRequired)
            {
                SetTextCallback method = SetText;
                Invoke(method, text);
            }
            else
            {
                stsMain.Panels[sID].Text = text;
            }
        }

        public override void SetStatusBarMessage(string message)
        {
            SetText(message, "stbMessage");
        }

        public override void SetTextForID(string message, string sID)
        {
            SetText(message, sID);
        }

        private void ZA0003_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close)
            {
                return;
            }
            DialogForm dialogForm = new DialogForm(Common.getLangText("프로그램을 종료하시겠습니까?", "MSG"));
            dialogForm.ShowDialog();
            if (dialogForm.result == "OK")
            {
                int num = base.MdiChildren.Length;
                for (int i = 0; i < num; i++)
                {
                    if (base.MdiChildren[0] != null)
                    {
                        base.MdiChildren[0].Close();
                    }
                }
                SaveDoWorkType();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void cboLang_ValueChanged(object sender, EventArgs e)
        {
            if (!binit)
            {
                return;
            }
            bool flag = !(Lang == cboLang.Text);
            Common.Lang = (Lang = cboLang.Text);
            FontSet(Common.Lang);
            if (FormInformation == null)
            {
                return;
            }
            if (base.MdiChildren.Length != 0)
            {
                DialogForm dialogForm = new DialogForm(Common.getLangText("열려있는 화면은 닫힙니다. 진행 하시겠습니까?", "MSG"));
                dialogForm.ShowDialog();
                if (dialogForm.result != "OK")
                {
                    return;
                }
            }
            if (flag || Common.Lang != "KO")
            {
                Common.langTable = null;
                binit = false;
                FormInformation.SetControl(this, Lang);
                cboLang.Text = Common.Lang;
                binit = true;
                gridFV.DisplayLayout.Bands[0].Columns[0].Header.Caption = Common.getLangText("북마크");
                gridFV.cmsMenu.Items.Clear();
                gridFV.DisplayLayout.Scrollbars = Scrollbars.None;
                picMainBody.Visible = true;
            }
            if (cboMenu.SelectedItem.Equals("TREE"))
            {
                CreateTree();
                dockManager.Visible = true;
                menuStrip1.Visible = false;
            }
            else
            {
                CreateMenu();
                dockManager.Visible = false;
                menuStrip1.Visible = true;
            }
            for (int num = base.MdiChildren.Length - 1; num >= 0; num--)
            {
                base.MdiChildren[num].Close();
            }
            CModule.SetAppSetting("LANGUAGE", Convert.ToString(cboLang.Text));
            if (Common.FontName != "")
            {
                treMenu.Appearance.FontData.Name = Common.FontName;
                udtMdiManager.Appearance.FontData.Name = Common.FontName;
            }
            pnlLang.Visible = false;
            ActiveNode_Select();
        }

        private void cboSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = cboSite.Text.Substring(1, 4);
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            NameValueCollection nameValueCollection = (NameValueCollection)ConfigurationManager.GetSection("site");
            for (int i = 0; i < configuration.ConnectionStrings.ConnectionStrings.Count; i++)
            {
                configuration.ConnectionStrings.ConnectionStrings[i].ConnectionString = nameValueCollection[text].ToString();
            }
            configuration.ConnectionStrings.ConnectionStrings["ConnectionString"].ConnectionString = nameValueCollection[text].ToString();
            configuration.AppSettings.Settings["SITE"].Value = text;
            configuration.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
            ConfigurationManager.RefreshSection("configuration");
        }

        private void cboMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!binit)
            {
                return;
            }
            if (cboMenu.SelectedIndex == 0)
            {
                if (cboMenuIndex == 0)
                {
                    return;
                }
                cboMenuIndex = 0;
                CreateTree();
                dockManager.Visible = true;
                menuStrip1.Visible = false;
            }
            else if (cboMenu.SelectedIndex == 1)
            {
                if (cboMenuIndex == 1)
                {
                    return;
                }
                cboMenuIndex = 1;
                CreateMenu();
                dockManager.Visible = false;
                menuStrip1.Visible = true;
            }
            tlbMain.BringToFront();
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(systemID + "\\UI");
            registryKey = ((registryKey != null) ? Registry.CurrentUser.OpenSubKey(systemID + "\\UI", writable: true) : Registry.CurrentUser.CreateSubKey(systemID + "\\UI"));
            registryKey.SetValue("MENU", DBHelper.nvlString(cboMenu.SelectedItem));
            Common.UIMenu = DBHelper.nvlString(cboMenu.SelectedItem);
        }

        private void cboStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStyle.Items.Count <= 0 || !(DBHelper.nvlString(cboStyle.SelectedItem) != ""))
            {
                return;
            }
            string text = Application.StartupPath + "\\" + cboStyle.SelectedItem + ".isl";
            if (!File.Exists(text))
            {
                text = Application.StartupPath + "\\Style.isl";
            }
            StyleManager.Load(text);
            Application.EnableVisualStyles();
            cboStyleIndex = cboStyle.SelectedIndex;
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(systemID + "\\UI");
            registryKey = ((registryKey != null) ? Registry.CurrentUser.OpenSubKey(systemID + "\\UI", writable: true) : Registry.CurrentUser.CreateSubKey(systemID + "\\UI"));
            registryKey.SetValue("STYLE", DBHelper.nvlString(cboStyle.SelectedItem));
            Common.UIStyle = DBHelper.nvlString(cboStyle.SelectedItem);
            string a = cboStyle.SelectedItem.ToString();
            if (!(a == "LightBlue"))
            {
                if (a == "LightGreen")
                {
                    treMenu.ImageList = imgMenu2;
                    tlbMain.BackColor = Color.Ivory;
                }
                else
                {
                    treMenu.ImageList = imgMenu1;
                    tlbMain.BackColor = Color.White;
                }
            }
            else
            {
                treMenu.ImageList = imlMenu;
                tlbMain.BackColor = Color.FromArgb(213, 228, 242);
            }
            Form[] mdiChildren = base.MdiChildren;
            foreach (Form treeChild in mdiChildren)
            {
                SetTreeChild(treeChild);
            }
        }

        private System.Windows.Forms.Control SetTreeChild(System.Windows.Forms.Control control)
        {
            foreach (System.Windows.Forms.Control control2 in control.Controls)
            {
                try
                {
                    string name = control2.GetType().Name;
                    if (name == "UltraTree")
                    {
                        ((UltraTree)control2).ImageList = treMenu.ImageList;
                    }
                }
                catch (Exception)
                {
                }
                if (control2.Parent.GetType().Name != "MdiClient")
                {
                    SetTreeChild(control2);
                }
            }
            return null;
        }

        public Form OpenChildForm(string MenuID)
        {
            string text = string.Empty;
            string str = string.Empty;
            string text2 = string.Empty;
            string str2 = string.Empty;
            for (int i = 0; i < base.MdiChildren.Length; i++)
            {
                if (base.MdiChildren[i].Name == MenuID)
                {
                    base.MdiChildren[i].Activate();
                    LastActiveNode = MenuID;
                    return base.MdiChildren[i];
                }
            }
            DataRow[] array = TreeDT.Select();
            for (int j = 0; j < array.Length; j++)
            {
                if (array[j]["ProgramID"].ToString() == MenuID && array[j]["MenuType"].ToString() == "P")
                {
                    text = array[j]["FileID"].ToString();
                    str = array[j]["NameSpace"].ToString();
                    str2 = array[j]["ProgramID"].ToString();
                    text2 = array[j]["MenuName"].ToString();
                    LastActiveNode = MenuID;
                    if (!bgProcess.IsBusy)
                    {
                        bgProcess.RunWorkerAsync("LOADING");
                        AutoReset.WaitOne();
                    }
                    break;
                }
            }
            if (text == "")
            {
                return null;
            }
            try
            {
                Assembly assembly = Assembly.LoadFrom(Application.StartupPath + "\\" + text);
                Type type = assembly.GetType(str + "." + str2, throwOnError: true);
                Form form = (Form)Activator.CreateInstance(type);
                form.MdiParent = this;
                ((BaseForm)form).WorkerID = WorkerID;
                ((BaseForm)form).Lang = Lang;
                ((BaseForm)form).IP = IP;
                form.Text = text2;
                form.Show();
                picMainBody.Visible = false;
                tlbMain.Items["CloseFunc"].Enabled = true;
                ClosePrgForm_NEW();
                return form;
            }
            catch (TypeLoadException)
            {
                ClosePrgForm_NEW();
            }
            return null;
        }

        private void treMenu_DoubleClick(object sender, EventArgs e)
        {
            UltraTreeNode nodeFromPoint = treMenu.GetNodeFromPoint(LastMouseDown);
            string str = string.Empty;
            string str2 = string.Empty;
            if (nodeFromPoint != null)
            {
                try
                {
                    if (!(nodeFromPoint.Key == ""))
                    {
                        string[] array = null;
                        if (nodeFromPoint.Tag != null && nodeFromPoint.Tag.ToString() != "M")
                        {
                            array = nodeFromPoint.Tag.ToString().Split('|');
                            for (int i = 0; i < base.MdiChildren.Length; i++)
                            {
                                if (base.MdiChildren[i].Name == array[1])
                                {
                                    base.MdiChildren[i].Activate();
                                    LastActiveNode = nodeFromPoint.Key;
                                    return;
                                }
                            }
                        }
                        setColumnChooser(null);
                        DataRow[] array2 = TreeDT.Select();
                        for (int j = 0; j < array2.Length; j++)
                        {
                            if (array2[j]["MenuID"].ToString() == nodeFromPoint.Key && array2[j]["MenuType"].ToString() == "P")
                            {
                                str = array2[j]["FileID"].ToString();
                                str2 = array2[j]["NameSpace"].ToString();
                                LastActiveNode = nodeFromPoint.Key;
                                if (!bgProcess.IsBusy)
                                {
                                    bgProcess.RunWorkerAsync("LOADING");
                                    AutoReset.WaitOne();
                                }
                                break;
                            }
                            if (array2[j]["MenuID"].ToString() == nodeFromPoint.Key && array2[j]["MenuType"].ToString() == "M")
                            {
                                if (nodeFromPoint.RootNode.Nodes.Count == 0)
                                {
                                    nodeFromPoint.Override.NodeAppearance.Image = 2;
                                    nodeFromPoint.Override.ExpandedNodeAppearance.Image = 2;
                                }
                                return;
                            }
                        }
                        try
                        {
                            Assembly assembly = Assembly.LoadFrom(Application.StartupPath + "\\" + str);
                            Type type = assembly.GetType(str2 + "." + array[1], throwOnError: true);
                            Form form = (Form)Activator.CreateInstance(type);
                            if (((BaseForm)form).bPopUp)
                            {
                                ClosePrgForm_NEW();
                                form.Show();
                            }
                            else
                            {
                                form.MdiParent = this;
                                ((BaseForm)form).WorkerID = WorkerID;
                                ((BaseForm)form).Lang = Lang;
                                ((BaseForm)form).IP = IP;
                                form.Text = Common.getLangText(array[4], "MN");
                                form.Show();
                                tlbMain.Items["CloseFunc"].Enabled = true;
                                picMainBody.Visible = false;
                            }
                            ClosePrgForm_NEW();
                        }
                        catch (TypeLoadException)
                        {
                            ClosePrgForm_NEW();
                            ShowDialog(Common.getLangText("선택한 폼의 정보를 찾을 수 없습니다. 관리자에게 문의하세요.", "MSG"), DialogForm.DialogType.OK);
                        }
                        catch (Exception ex2)
                        {
                            ClosePrgForm_NEW();
                            MessageForm messageForm = new MessageForm(ex2);
                            messageForm.ShowDialog();
                        }
                    }
                }
                catch (Exception)
                {
                    ClosePrgForm_NEW();
                    ShowDialog(Common.getLangText("선택한 폼의 정보를 찾을 수 없습니다. 관리자에게 문의하세요.", "MSG"), DialogForm.DialogType.OK);
                }
            }
        }

        private void treMenu_MouseDown(object sender, MouseEventArgs e)
        {
            LastMouseDown = new Point(e.X, e.Y);
        }

        private void OnMenuItemEditSettingsClick(object sender, EventArgs e)
        {
            try
            {
                IGMenuItem iGMenuItem = sender as IGMenuItem;
                if (iGMenuItem != null)
                {
                    int num = base.MdiChildren.Length;
                    string name = base.ActiveMdiChild.Name;
                    string text = iGMenuItem.Text;
                    if (!(text == "All Close"))
                    {
                        if (!(text == "Others Close"))
                        {
                            if (text == "Language Localization")
                            {
                                if (base.ActiveMdiChild != null)
                                {
                                    try
                                    {
                                        ModifyControl(base.ActiveMdiChild);
                                    }
                                    catch
                                    {
                                    }
                                }
                                Assembly assembly = Assembly.LoadFrom(Application.StartupPath + "\\WIZ.SY.dll");
                                Type type = assembly.GetType("WIZ.SY.POP_SY1600", throwOnError: true);
                                Form form = (Form)Activator.CreateInstance(type, dtControl);
                                form.ShowDialog();
                            }
                        }
                        else
                        {
                            for (int i = 0; i < num; i++)
                            {
                                if (((BaseMDIChildForm)base.MdiChildren[0]).Name != name)
                                {
                                    ((BaseMDIChildForm)base.MdiChildren[0]).Close();
                                }
                                if (base.MdiChildren.Length > 1 && ((BaseMDIChildForm)base.MdiChildren[1]).Name != name)
                                {
                                    ((BaseMDIChildForm)base.MdiChildren[1]).Close();
                                }
                            }
                            LastActiveNode = ((BaseMDIChildForm)base.MdiChildren[0]).Name;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < num; j++)
                        {
                            ((BaseMDIChildForm)base.MdiChildren[0]).Close();
                        }
                        tlbMain.Items["CloseFunc"].Enabled = false;
                        LastActiveNode = "";
                        if (bMainBody)
                        {
                            picMainBody.Visible = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void udtMdiManager_InitializeContextMenu(object sender, MdiTabContextMenuEventArgs e)
        {
            int num = base.MdiChildren.Length;
            int count = e.ContextMenu.MenuItems.Count;
            int num2 = count - 2;
            int num3 = count - 1;
            if (WorkerID.Equals("SYSTEM") && Common.Lang.Equals("KO"))
            {
                e.ContextMenu.MenuItems.AddRange(new MenuItem[5]
                {
                    miSeparator,
                    miOthersClose,
                    miAllClose,
                    miSeparator2,
                    miLang
                });
                count = e.ContextMenu.MenuItems.Count;
                num2 = count - 4;
                num3 = count - 3;
            }
            else
            {
                e.ContextMenu.MenuItems.AddRange(new MenuItem[3]
                {
                    miSeparator,
                    miOthersClose,
                    miAllClose
                });
                count = e.ContextMenu.MenuItems.Count;
                num2 = count - 2;
                num3 = count - 1;
            }
            if (num <= 1)
            {
                e.ContextMenu.MenuItems[num2].Enabled = false;
                e.ContextMenu.MenuItems[num3].Enabled = false;
            }
            else
            {
                e.ContextMenu.MenuItems[num2].Enabled = true;
                e.ContextMenu.MenuItems[num3].Enabled = true;
            }
        }

        private void udtMdiManager_TabClosed(object sender, MdiTabEventArgs e)
        {
            if (base.MdiChildren.Length == 0)
            {
                LastActiveNode = "";
                tlbMain.Items["CloseFunc"].Enabled = false;
                if (bMainBody)
                {
                    picMainBody.Visible = true;
                }
            }
            ClosePrgForm_NEW();
        }

        public override void Tree_Refresh()
        {
            CreateTree();
            ActiveNode_Select();
        }

        private void FavoriteFunc_Click(object sender, EventArgs e)
        {
            ultraPanelFV.Visible = !ultraPanelFV.Visible;
            picResize.BackColor = gridFV.BackColor;
            gridFV.DisplayLayout.Bands[0].Columns[0].Width = ultraPanelFV.Width;
        }

        private void picResize_MouseDown(object sender, MouseEventArgs e)
        {
            allowResize = true;
        }

        private void picResize_MouseMove(object sender, MouseEventArgs e)
        {
            if (allowResize)
            {
                ultraPanelFV.Height = picResize.Top + e.Y;
                ultraPanelFV.Width = picResize.Left + e.X;
                gridFV.DisplayLayout.Bands[0].Columns[0].Width = ultraPanelFV.Width;
            }
        }

        private void picResize_MouseUp(object sender, MouseEventArgs e)
        {
            allowResize = false;
        }

        private void gridFV_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            try
            {
                ultraPanelFV.Visible = false;
                try
                {
                    string[] array = gridFV.ActiveRow.Cells["Tag"].Value.ToString().Split('|');
                    for (int i = 0; i < base.MdiChildren.Length; i++)
                    {
                        if (base.MdiChildren[i].Name == array[1])
                        {
                            base.MdiChildren[i].Activate();
                            LastActiveNode = array[1];
                            return;
                        }
                    }
                    if (!bgProcess.IsBusy)
                    {
                        bgProcess.RunWorkerAsync("LOADING");
                        AutoReset.WaitOne();
                    }
                    Assembly assembly = Assembly.LoadFrom(Application.StartupPath + "\\" + array[2]);
                    Type type = assembly.GetType(array[3] + "." + array[1], throwOnError: true);
                    Form form = (Form)Activator.CreateInstance(type);
                    if (((BaseForm)form).bPopUp)
                    {
                        ClosePrgForm_NEW();
                        form.Show();
                    }
                    else
                    {
                        form.MdiParent = this;
                        ((BaseForm)form).WorkerID = WorkerID;
                        ((BaseForm)form).Lang = Lang;
                        ((BaseForm)form).IP = IP;
                        form.Text = gridFV.ActiveRow.Cells[0].Value.ToString();
                        form.Show();
                        tlbMain.Items["CloseFunc"].Enabled = true;
                    }
                    picMainBody.Visible = false;
                    ClosePrgForm_NEW();
                }
                catch (TypeLoadException)
                {
                    ClosePrgForm_NEW();
                    ShowDialog(Common.getLangText("선택한 폼의 정보를 찾을 수 없습니다. 관리자에게 문의하세요.", "MSG"), DialogForm.DialogType.OK);
                }
            }
            catch (TypeLoadException)
            {
                ClosePrgForm_NEW();
                ShowDialog(Common.getLangText("선택한 폼의 정보를 찾을 수 없습니다. 관리자에게 문의하세요.", "MSG"), DialogForm.DialogType.OK);
            }
        }

        private void addFavorite(UltraTreeNode utn)
        {
            if (utn.Tag.ToString() != "M")
            {
                DBHelper dBHelper = new DBHelper(completedClose: false);
                string[] array = utn.Tag.ToString().Split('|');
                dBHelper.ExecuteNoneQuery("USP_ZZ9001_I1", CommandType.StoredProcedure, dBHelper.CreateParameter("UserID", WorkerID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("MenuID", array[5], DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("MenuName", array[4], DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("Tag", utn.Tag.ToString(), DbType.String, ParameterDirection.Input));
                ultraPanelFV.Visible = true;
                if (dBHelper.RSCODE == "S")
                {
                    ((DataTable)gridFV.DataSource).Rows.Add(utn.Text, utn.Tag);
                }
            }
        }

        private void gridFV_DragLeave(object sender, EventArgs e)
        {
            if (dragRow == null && dragUtn == null)
            {
                return;
            }
            if (dragRow != null)
            {
                Point point = gridFV.PointToClient(new Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y));
                if (point.X < 0 || point.Y < 0 || point.X > gridFV.Width || point.Y > gridFV.Height)
                {
                    DBHelper dBHelper = new DBHelper(completedClose: false);
                    string text = dragRow.Cells["Tag"].Value.ToString();
                    string[] array = text.Split('|');
                    dBHelper.ExecuteNoneQuery("USP_ZZ9001_D1", CommandType.StoredProcedure, dBHelper.CreateParameter("UserID", WorkerID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("MenuID", array[5], DbType.String, ParameterDirection.Input));
                    foreach (DataRow row in ((DataTable)gridFV.DataSource).Rows)
                    {
                        if (row["Tag"].ToString() == text)
                        {
                            ((DataTable)gridFV.DataSource).Rows.Remove(row);
                            break;
                        }
                    }
                }
            }
            if (dragUtn != null)
            {
                addFavorite(dragUtn);
            }
            dragRow = null;
            dragUtn = null;
        }

        private void gridFV_SelectionDrag(object sender, CancelEventArgs e)
        {
            dragRow = gridFV.ActiveRow;
            gridFV.DoDragDrop(gridFV.ActiveRow, DragDropEffects.Copy);
        }

        private void gridFV_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            if (dragRow != null)
            {
                Cursor.Current = Common.CreateCursor(dragRow.Cells["name"].Value.ToString());
            }
        }

        private void gridFV_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                dragUtn = (UltraTreeNode)e.Data.GetData(typeof(UltraTreeNode));
            }
            catch
            {
                dragUtn = null;
            }
        }

        private void gridFV_MouseDown(object sender, MouseEventArgs e)
        {
            UIElement lastElementEntered = gridFV.DisplayLayout.UIElement.LastElementEntered;
            Infragistics.Win.UltraWinGrid.ColumnHeader columnHeader = lastElementEntered.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader)) as Infragistics.Win.UltraWinGrid.ColumnHeader;
            if (columnHeader != null)
            {
                mPFV = new Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y);
                pPFV = new Point(ultraPanelFV.Left, ultraPanelFV.Top);
            }
        }

        private void gridFV_MouseMove(object sender, MouseEventArgs e)
        {
            if (pPFV.X != 0)
            {
                ultraPanelFV.Left = pPFV.X - mPFV.X + System.Windows.Forms.Control.MousePosition.X;
                ultraPanelFV.Top = pPFV.Y - mPFV.Y + System.Windows.Forms.Control.MousePosition.Y;
            }
        }

        private void gridFV_MouseUp(object sender, MouseEventArgs e)
        {
            pPFV = new Point(0, 0);
        }

        private void ClosePrgForm()
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

        private void ClosePrgForm_NEW()
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

        public void SetLogo(Image image, string title = "")
        {
            if (image != null)
            {
                lblLogo.Image = image;
            }
            if (title != "")
            {
                Text = title;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            int num = 0;
            Keys keys = keyData & ~(Keys.Shift | Keys.Control | Keys.Alt);
            if ((keyData & Keys.Control) != 0)
            {
                switch (keys)
                {
                    case Keys.F2:
                        num = 1;
                        break;
                    case Keys.F3:
                        num = 2;
                        break;
                    case Keys.F4:
                        num = 3;
                        break;
                    case Keys.F5:
                        num = 4;
                        break;
                    case Keys.F6:
                        num = 5;
                        break;
                    case Keys.F7:
                        num = 6;
                        break;
                    case Keys.F8:
                        num = 7;
                        break;
                    case Keys.F9:
                        num = 8;
                        break;
                    case Keys.F10:
                        if (tlbMain.Items["CloseFunc"].Enabled)
                        {
                            tlbMain_Click(tlbMain.Items["CloseFunc"], null);
                            return true;
                        }
                        num = 0;
                        break;
                    default:
                        num = 0;
                        break;
                }
            }
            if (keyData.Equals(Keys.Return) && base.ActiveMdiChild != null && !txtSearch.Focused)
            {
                System.Windows.Forms.Control control = FindFocusedControl(base.ActiveMdiChild);
                if (control != null && getGBoxChild(control))
                {
                    switch (control.GetType().ToString())
                    {
                        case "Infragistics.Win.UltraWinEditors.UltraTextEditor":
                        case "Infragistics.Win.EmbeddableTextBoxWithUIPermissions":
                        case "System.Windows.Forms.TextBox":
                        case "WIZ.Control.SCodeNMComboBox":
                        case "Infragistics.Win.UltraWinGrid.UltraCombo":
                        case "Infragistics.Win.UltraWinEditors.UltraComboEditor":
                        case "WIZ.Control.SBtnTextEdit":
                        case "WIZ.Control.STextBox":
                            num = 1;
                            break;
                    }
                }
            }
            if (num > 0)
            {
                foreach (ToolStripItem item in tlbMain.Items)
                {
                    if (item.GetType().Name == "ToolStripButton" && --num == 0)
                    {
                        if (!item.Enabled)
                        {
                            break;
                        }
                        tlbMain_Click(item, null);
                        return true;
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private System.Windows.Forms.Control FindFocusedControl(System.Windows.Forms.Control control)
        {
            ContainerControl containerControl = control as ContainerControl;
            return (containerControl != null) ? FindFocusedControl(containerControl.ActiveControl) : control;
        }

        private bool getGBoxChild(System.Windows.Forms.Control ctl)
        {
            int num = 0;
            bool result = false;
            try
            {
                while (++num < 10 && ctl.Parent != null && !(ctl.Parent.GetType().Name == "MdiClient"))
                {
                    if (ctl.Parent.GetType().ToString().Equals("Infragistics.Win.Misc.UltraGroupBox") && ctl.Parent.Name.Equals("gbxHeader"))
                    {
                        result = true;
                        break;
                    }
                    ctl = ctl.Parent;
                }
                return result;
            }
            catch
            {
                return false;
            }
        }

        private void SaveDoWorkType()
        {
            try
            {
                DBHelper dBHelper = new DBHelper(completedClose: false);
                try
                {
                    dBHelper.ExecuteNoneQuery("USP_SY0700_I1", CommandType.StoredProcedure, dBHelper.CreateParameter("PROGRAMID", "MAIN", DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("WORKERID", WorkerID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("WORKTYPE", "LOGOUT", DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("IP", IP, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("COMNAME", Environment.MachineName.ToString(), DbType.String, ParameterDirection.Input));
                }
                catch (Exception)
                {
                    ShowDialog(Common.getLangText("시스템 오류입니다.  담당자에게 연락하십시오.", "MSG"), DialogForm.DialogType.OK);
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

        public void CreateTree(string sData = "")
        {
            DBHelper dBHelper = new DBHelper(completedClose: false);
            int num = 0;
            int num2 = 0;
            try
            {
                TreeDT = dBHelper.FillTable("USP_ZA0000_S1_FIND", CommandType.StoredProcedure
                    , dBHelper.CreateParameter("WorkerID", WorkerID, DbType.String, ParameterDirection.Input)
                    , dBHelper.CreateParameter("SystemID", systemID, DbType.String, ParameterDirection.Input)
                    , dBHelper.CreateParameter("FINDTEXT", sData, DbType.String, ParameterDirection.Input));
                DataRow[] array = TreeDT.Select();
                treMenu.Nodes.Clear();
                for (int i = 0; i < array.Length; i++)
                {
                    num = i;
                    if (array[i]["ParMenuID"].ToString() == "0" && array[i]["MenuType"].ToString() == "M")
                    {
                        string langText = Common.getLangText(array[i]["MenuName"].ToString(), "MN");
                        string key = array[i]["MenuID"].ToString();
                        UltraTreeNode ultraTreeNode = treMenu.Nodes.Add(key, langText);
                        ultraTreeNode.Override.NodeAppearance.Image = 2;
                        ultraTreeNode.Override.ExpandedNodeAppearance.Image = 4;
                        string text = "";
                        text = array[i]["MenuID"].ToString();
                        for (int j = 0; j < array.Length; j++)
                        {
                            num2 = j;
                            if ((text == array[j]["ParMenuID"].ToString()) & (array[j]["MenuType"].ToString() == "P"))
                            {
                                string key2 = array[j]["MenuID"].ToString();
                                string langText2 = Common.getLangText(array[j]["MenuName"].ToString(), "MN");
                                UltraTreeNode ultraTreeNode2 = ultraTreeNode.Nodes.Add(key2, langText2);
                                ultraTreeNode2.Override.NodeAppearance.Image = 3;
                                ultraTreeNode2.Tag = "P|" + array[j]["ProgramID"].ToString() + "|" + array[j]["FileID"].ToString() + "|" + array[j]["NameSpace"].ToString() + "|" + array[j]["MenuName"].ToString() + "|" + array[j]["MenuID"].ToString();
                            }
                            if ((text == array[j]["ParMenuID"].ToString()) & (array[j]["MenuType"].ToString() == "M"))
                            {
                                string key2 = array[j]["MenuID"].ToString();
                                string langText2 = Common.getLangText(array[j]["MenuName"].ToString(), "MN");
                                UltraTreeNode ultraTreeNode2 = ultraTreeNode.Nodes.Add(key2, langText2);
                                ultraTreeNode2.Override.NodeAppearance.Image = 2;
                                ultraTreeNode2.Override.ExpandedNodeAppearance.Image = 4;
                                ultraTreeNode2.Tag = "M";
                                string text2 = "";
                                text2 = array[j]["MenuID"].ToString();
                                node_set(array, text2, ultraTreeNode2);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                dBHelper.Close();
            }
        }

        private void node_set(DataRow[] Table, string rootID_, UltraTreeNode ChildNode)
        {
            for (int i = 0; i < Table.Length; i++)
            {
                if ((rootID_ == Table[i]["ParMenuID"].ToString()) & (Table[i]["MenuType"].ToString() == "P"))
                {
                    string key = Table[i]["MenuID"].ToString();
                    string langText = Common.getLangText(Table[i]["MenuName"].ToString(), "MN");
                    UltraTreeNode ultraTreeNode = ChildNode.Nodes.Add(key, langText);
                    ultraTreeNode.Override.NodeAppearance.Image = 3;
                    ultraTreeNode.Tag = "P|" + Table[i]["ProgramID"].ToString() + "|" + Table[i]["FileID"].ToString() + "|" + Table[i]["NameSpace"].ToString() + "|" + Table[i]["MenuName"].ToString() + "|" + Table[i]["MenuID"].ToString();
                }
                if ((rootID_ == Table[i]["ParMenuID"].ToString()) & (Table[i]["MenuType"].ToString() == "M"))
                {
                    string key = Table[i]["MenuID"].ToString();
                    string langText = Common.getLangText(Table[i]["MenuName"].ToString(), "MN");
                    UltraTreeNode ultraTreeNode = ChildNode.Nodes.Add(key, langText);
                    ultraTreeNode.Override.NodeAppearance.Image = 2;
                    ultraTreeNode.Override.ExpandedNodeAppearance.Image = 4;
                    ultraTreeNode.Tag = "M";
                    string text = "";
                    text = Table[i]["MenuID"].ToString();
                    node_set(Table, text, ultraTreeNode);
                }
            }
        }

        private void CreateMenu()
        {
            try
            {
                menuStrip1.Items.Clear();
                DataTable dataTable = MenuTable("USP_ZA0000_S2", WorkerID, Common.Lang, 0);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(Convert.ToString(dataTable.Rows[i]["ProgramID"]));
                    toolStripMenuItem.Text = Convert.ToString(dataTable.Rows[i]["MenuName"]);
                    Font font2 = toolStripMenuItem.Font = new Font(Common.FontName, 9f);
                    menuStrip1.Items.Add(toolStripMenuItem);
                    toolStripMenuItem.DropDownItemClicked += MenuItem_Click;
                    CreateMenu1(toolStripMenuItem, int.Parse(Convert.ToString(dataTable.Rows[i]["MenuID"])));
                }
            }
            catch (Exception)
            {
            }
        }

        public void CreateMenu1(ToolStripMenuItem parmenu, int parmenuid)
        {
            DataTable dataTable = MenuTable("USP_ZA0000_S2", WorkerID, cboLang.Text, parmenuid);
            ImageList imageList = new ImageList();
            string a = DBHelper.nvlString(cboStyle.SelectedItem);
            imageList = ((a == "LightBlue") ? imlMenu : ((!(a == "LightGreen")) ? imgMenu1 : imgMenu2));
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i]["MenuType"].ToString() == "M")
                {
                    ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(Convert.ToString(dataTable.Rows[i]["ProgramID"]));
                    toolStripMenuItem.Text = Common.getLangText(Convert.ToString(dataTable.Rows[i]["MenuName"]), "MN");
                    Font font2 = toolStripMenuItem.Font = new Font(Common.FontName, 9f);
                    toolStripMenuItem.Image = imageList.Images[2];
                    parmenu.DropDownItems.Add(toolStripMenuItem);
                    toolStripMenuItem.DropDownItemClicked += MenuItem_Click;
                    CreateMenu1(toolStripMenuItem, int.Parse(Convert.ToString(dataTable.Rows[i]["MenuID"])));
                }
                else
                {
                    ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem(Convert.ToString(dataTable.Rows[i]["ProgramID"]));
                    toolStripMenuItem2.Text = Convert.ToString(dataTable.Rows[i]["MenuName"]);
                    toolStripMenuItem2.Tag = Convert.ToString(dataTable.Rows[i]["NameSpace"]);
                    toolStripMenuItem2.Name = Convert.ToString(dataTable.Rows[i]["ProgramID"]);
                    Font font4 = toolStripMenuItem2.Font = new Font(Common.FontName, 9f);
                    toolStripMenuItem2.Image = imageList.Images[3];
                    parmenu.DropDownItems.Add(toolStripMenuItem2);
                }
            }
        }

        public DataTable MenuTable(string sp, string workerid, string lang, int parmenuid)
        {
            DBHelper dBHelper = new DBHelper(completedClose: false);
            try
            {
                return dBHelper.FillTable(sp, CommandType.StoredProcedure, dBHelper.CreateParameter("WORKERID", workerid, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("SYSTEMID", systemID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("PARMENUID", parmenuid, DbType.String, ParameterDirection.Input));
            }
            catch (Exception)
            {
                CheckForm checkForm = new CheckForm(Common.getLangText(" 화면 개발중입니다. 관리자에게 문의하세요 ", "MSG"));
                checkForm.ShowDialog();
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        private void MenuItem_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem.Tag != null && !(e.ClickedItem.Name == LastActiveNode))
                {
                    for (int i = 0; i < base.MdiChildren.Length; i++)
                    {
                        if (base.MdiChildren[i].Name == e.ClickedItem.Name)
                        {
                            base.MdiChildren[i].Activate();
                            tlbMain.Items[6].Enabled = true;
                            LastActiveNode = e.ClickedItem.Name;
                            return;
                        }
                    }
                    setColumnChooser(null);
                    if (!bgProcess.IsBusy)
                    {
                        bgProcess.RunWorkerAsync("LOADING");
                        AutoReset.WaitOne();
                    }
                    Assembly assembly = Assembly.LoadFrom(Application.StartupPath + "\\" + e.ClickedItem.Tag.ToString() + ".DLL");
                    Type type = assembly.GetType(e.ClickedItem.Tag.ToString() + "." + e.ClickedItem.Name, throwOnError: true);
                    Form form = (Form)Activator.CreateInstance(type);
                    form.MdiParent = this;
                    ((BaseForm)form).WorkerID = WorkerID;
                    ((BaseForm)form).Lang = Lang;
                    ((BaseForm)form).IP = IP;
                    form.Text = e.ClickedItem.Text;
                    form.Show();
                    picMainBody.Visible = false;
                    tlbMain.Items["CloseFunc"].Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageForm messageForm = new MessageForm(ex);
                messageForm.ShowDialog();
            }
            finally
            {
                ClosePrgForm_NEW();
            }
        }

        private void ActiveNode_Select()
        {
            if (LastActiveNode != "")
            {
                try
                {
                    UltraTreeNode ultraTreeNode = treMenu.GetNodeByKey(LastActiveNode);
                    UltraTreeNode nodeByKey = treMenu.GetNodeByKey(LastActiveNode);
                    int level = ultraTreeNode.Level;
                    for (int i = 0; i < level; i++)
                    {
                        if (ultraTreeNode.Parent != null)
                        {
                            ultraTreeNode.Parent.Nodes.ParentNode.Expanded = true;
                            ultraTreeNode = node_refresh(ultraTreeNode);
                        }
                    }
                    nodeByKey.Selected = true;
                    treMenu.ActiveNode = nodeByKey;
                }
                catch (Exception)
                {
                }
            }
        }

        private UltraTreeNode node_refresh(UltraTreeNode node)
        {
            node.Parent.Nodes.ParentNode.Expanded = true;
            UltraTreeNode nodeByKey = treMenu.GetNodeByKey(node.Parent.Nodes.ParentNode.Key);
            if (nodeByKey.Parent != null)
            {
                return nodeByKey;
            }
            return null;
        }

        public void FontSet(string lang = "KO")
        {
            try
            {
                DataTable dataTable = _common.GET_BM0000_CODE("LANG");
                Common.FontName = Convert.ToString(dataTable.Select("CODE_ID = '" + lang + "'")[0]["RelCode1"]);
            }
            catch (Exception)
            {
                ShowDialog(Common.getLangText("기초정보가 없습니다.", "MSG"), DialogForm.DialogType.OK);
            }
        }

        public void setColumnChooser(WIZ.Control.Grid ugrid)
        {
            if (ugrid == null)
            {
                ultraPanelCC.Visible = false;
                return;
            }
            ultraPanelCC.Visible = !ultraPanelCC.Visible;
            if (ultraPanelCC.Visible)
            {
                ultraGridColumnChooser1.SourceGrid = ugrid;
                ultraPanelCC.Left = System.Windows.Forms.Control.MousePosition.X - base.Left + 5;
                ultraPanelCC.Top = System.Windows.Forms.Control.MousePosition.Y - base.Top + 30;
            }
        }

        private void ModifyControl(Form form)
        {
            if (dtControl.Columns.Count == 0)
            {
                dtControl.Columns.Add("WKEY", typeof(string));
                dtControl.Columns.Add("OPKEY", typeof(string));
                dtControl.Columns.Add("CONTROLID", typeof(string));
                dtControl.Columns.Add("CONTROLNAME", typeof(string));
            }
            dtControl.Clear();
            ProcessControl(form.Controls, "");
        }

        private void ProcessControl(System.Windows.Forms.Control.ControlCollection controlcollection, string tabindex)
        {
            for (int i = 0; i < controlcollection.Count; i++)
            {
                AddControlInformation(controlcollection[i], tabindex + "." + controlcollection[i].TabIndex.ToString());
                if (controlcollection[i].Controls.Count != 0)
                {
                    ProcessControl(controlcollection[i].Controls, tabindex + "." + controlcollection[i].TabIndex.ToString());
                }
            }
        }

        private void AddControlInformation(System.Windows.Forms.Control control, string tabindex)
        {
            if (!(control.Name == ""))
            {
                try
                {
                    string a = control.GetType().ToString();
                    if (!(a == "WIZ.Control.Grid"))
                    {
                        if (!(a == "System.Windows.Forms.ToolStrip"))
                        {
                            if (!(a == "Infragistics.Win.UltraWinEditors.UltraTextEditor") && !(a == "WIZ.Control.SCodeNMComboBox") && !(a == "Infragistics.Win.Misc.UltraSplitter") && !(a == "System.Windows.Forms.TreeView") && !control.Text.Trim().Equals(""))
                            {
                                dtControl.Rows.Add(control.Text.Trim(), "", control.GetType().Name, control.GetType().ToString());
                            }
                        }
                        else
                        {
                            for (int i = 0; i < ((ToolStrip)control).Items.Count; i++)
                            {
                                if (!((ToolStrip)control).Items[i].Text.Trim().Equals(""))
                                {
                                    dtControl.Rows.Add(((ToolStrip)control).Items[i].Text.Trim(), "", control.GetType().Name, control.GetType().ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < ((WIZ.Control.Grid)control).Rows.Count; j++)
                        {
                            for (int k = 0; k < ((WIZ.Control.Grid)control).Columns.Count; k++)
                            {
                                if (!((WIZ.Control.Grid)control).Columns[k].Header.ToString().Trim().Equals(""))
                                {
                                    dtControl.Rows.Add(((WIZ.Control.Grid)control).Columns[k].Header.ToString().Trim(), "", control.GetType().Name, control.GetType().ToString());
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private void txtSearch_EditorButtonClick(object sender, EditorButtonEventArgs e)
        {
            if (e.Button.Key == "expand")
            {
                TreeMenu.ExpandAll();
            }
            if (e.Button.Key == "collapse")
            {
                TreeMenu.CollapseAll();
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                CreateTree(txtSearch.Text);
                if (txtSearch.Text != "" && TreeMenu.Nodes.Count > 0)
                {
                    TreeMenu.ExpandAll();
                }
                if (txtSearch.Text != "")
                {
                    treMenu.DrawFilter = new CustomColorNodeTextDrawFilter(new string[1]
                    {
                        txtSearch.Text
                    }, Color.Blue);
                }
                else
                {
                    treMenu.DrawFilter = null;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ultraPanelCC.Visible = false;
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            pnlLang.Visible = false;
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTree.UltraTreeColumnSet ultraTreeColumnSet1 = new Infragistics.Win.UltraWinTree.UltraTreeColumnSet();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZA0003));
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("collapse");
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton2 = new Infragistics.Win.UltraWinEditors.EditorButton("expand");
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel6 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("8143ad3c-d26d-4f3a-b45b-1f70b6c8f6b4"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("965d9ef4-1b81-4ab1-80cb-33c364e8f18d"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("8143ad3c-d26d-4f3a-b45b-1f70b6c8f6b4"), -1);
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Name", 0, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Tag", 1);
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
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.treMenu = new Infragistics.Win.UltraWinTree.UltraTree();
            this.imlMenu = new System.Windows.Forms.ImageList(this.components);
            this.txtSearch = new WIZ.Control.STextBox(this.components);
            this.stsMain = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this._BaseForm_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._BaseForm_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._BaseForm_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._BaseForm_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this.udtMdiManager = new Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager(this.components);
            this.dockManager = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._BaseFormAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this._BaseFormUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._BaseFormUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._BaseFormUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._BaseFormUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this.tlbMain = new System.Windows.Forms.ToolStrip();
            this.lblLogo = new System.Windows.Forms.ToolStripLabel();
            this.tss01 = new System.Windows.Forms.ToolStripSeparator();
            this.InqFunc = new System.Windows.Forms.ToolStripButton();
            this.NewFunc = new System.Windows.Forms.ToolStripButton();
            this.DelFunc = new System.Windows.Forms.ToolStripButton();
            this.SaveFunc = new System.Windows.Forms.ToolStripButton();
            this.ExcelFunc = new System.Windows.Forms.ToolStripButton();
            this.ExeImFunc = new System.Windows.Forms.ToolStripButton();
            this.CloseFunc = new System.Windows.Forms.ToolStripButton();
            this.tss02 = new System.Windows.Forms.ToolStripSeparator();
            this.PrintFunc = new System.Windows.Forms.ToolStripButton();
            this.FilterFunc = new System.Windows.Forms.ToolStripButton();
            this.SumFunc = new System.Windows.Forms.ToolStripButton();
            this.HelpFunc = new System.Windows.Forms.ToolStripButton();
            this.FavoriteFunc = new System.Windows.Forms.ToolStripButton();
            this.tss03 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitFunc = new System.Windows.Forms.ToolStripButton();
            this.LangFunc = new System.Windows.Forms.ToolStripButton();
            this.cboStyle = new System.Windows.Forms.ToolStripComboBox();
            this.lblStyle = new System.Windows.Forms.ToolStripLabel();
            this.cboSite = new System.Windows.Forms.ToolStripComboBox();
            this.cboMenu = new System.Windows.Forms.ToolStripComboBox();
            this.lblMenu = new System.Windows.Forms.ToolStripLabel();
            this.ufmForm = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this._BaseForm_UltraFormManager_Dock_Area_1_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._BaseForm_UltraFormManager_Dock_Area_1_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._BaseForm_UltraFormManager_Dock_Area_1_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._BaseForm_UltraFormManager_Dock_Area_1_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ultraPanelFV = new Infragistics.Win.Misc.UltraPanel();
            this.picResize = new System.Windows.Forms.PictureBox();
            this.gridFV = new WIZ.Control.Grid(this.components);
            this.ultraGridColumnChooser1 = new Infragistics.Win.UltraWinGrid.UltraGridColumnChooser();
            this.ultraPanelCC = new Infragistics.Win.Misc.UltraPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imgMenu1 = new System.Windows.Forms.ImageList(this.components);
            this.imgMenu2 = new System.Windows.Forms.ImageList(this.components);
            this.picMainBody = new Infragistics.Win.Misc.UltraPanel();
            this.windowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.pnlLang = new Infragistics.Win.Misc.UltraPanel();
            this.cboLang = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.picExit = new System.Windows.Forms.PictureBox();
            this.ultraPanel1.ClientArea.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtMdiManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.tlbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ufmForm)).BeginInit();
            this.ultraPanelFV.ClientArea.SuspendLayout();
            this.ultraPanelFV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridColumnChooser1)).BeginInit();
            this.ultraPanelCC.ClientArea.SuspendLayout();
            this.ultraPanelCC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.picMainBody.ClientArea.SuspendLayout();
            this.picMainBody.SuspendLayout();
            this.windowDockingArea1.SuspendLayout();
            this.dockableWindow1.SuspendLayout();
            this.pnlLang.ClientArea.SuspendLayout();
            this.pnlLang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraPanel1
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.ultraPanel1.Appearance = appearance1;
            this.ultraPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            // 
            // ultraPanel1.ClientArea
            // 
            this.ultraPanel1.ClientArea.Controls.Add(this.treMenu);
            this.ultraPanel1.ClientArea.Controls.Add(this.txtSearch);
            this.ultraPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel1.ForeColor = System.Drawing.Color.Black;
            this.ultraPanel1.Location = new System.Drawing.Point(0, 20);
            this.ultraPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(262, 628);
            this.ultraPanel1.TabIndex = 1051;
            // 
            // treMenu
            // 
            this.treMenu.AllowDrop = true;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            appearance2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            appearance2.FontData.BoldAsString = "True";
            appearance2.FontData.Name = "맑은 고딕";
            appearance2.FontData.SizeInPoints = 10F;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            this.treMenu.Appearance = appearance2;
            this.treMenu.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance3.ForeColor = System.Drawing.Color.White;
            this.treMenu.ColumnSettings.ActiveCellAppearance = appearance3;
            appearance4.ForeColor = System.Drawing.Color.White;
            this.treMenu.ColumnSettings.CellAppearance = appearance4;
            this.treMenu.ColumnSettings.ColumnAutoSizeMode = Infragistics.Win.UltraWinTree.ColumnAutoSizeMode.VisibleNodes;
            appearance5.ForeColor = System.Drawing.Color.White;
            this.treMenu.ColumnSettings.ColumnHeaderAppearance = appearance5;
            this.treMenu.ColumnSettings.LabelPosition = Infragistics.Win.UltraWinTree.NodeLayoutLabelPosition.None;
            appearance6.ForeColor = System.Drawing.Color.White;
            ultraTreeColumnSet1.ActiveCellAppearance = appearance6;
            appearance7.ForeColor = System.Drawing.Color.White;
            ultraTreeColumnSet1.CellAppearance = appearance7;
            appearance8.ForeColor = System.Drawing.Color.White;
            ultraTreeColumnSet1.ColumnHeaderAppearance = appearance8;
            this.treMenu.ColumnSettings.RootColumnSet = ultraTreeColumnSet1;
            this.treMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treMenu.HideSelection = false;
            this.treMenu.ImageList = this.imlMenu;
            this.treMenu.ImagePadding = 15;
            this.treMenu.Location = new System.Drawing.Point(0, 23);
            this.treMenu.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.treMenu.Name = "treMenu";
            appearance9.ForeColor = System.Drawing.Color.White;
            _override1.LabelEditAppearance = appearance9;
            _override1.ShowColumns = Infragistics.Win.DefaultableBoolean.False;
            this.treMenu.Override = _override1;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.treMenu.ScrollBarLook = scrollBarLook1;
            this.treMenu.Size = new System.Drawing.Size(262, 605);
            this.treMenu.TabIndex = 71;
            this.treMenu.UpdateMode = Infragistics.Win.UltraWinTree.UpdateMode.OnActiveNodeChange;
            this.treMenu.SelectionDragStart += new System.EventHandler(this.treMenu_SelectionDragStart);
            this.treMenu.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.treMenu_GiveFeedback);
            this.treMenu.DoubleClick += new System.EventHandler(this.treMenu_DoubleClick);
            this.treMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treMenu_MouseDown);
            // 
            // imlMenu
            // 
            this.imlMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlMenu.ImageStream")));
            this.imlMenu.TransparentColor = System.Drawing.Color.Transparent;
            this.imlMenu.Images.SetKeyName(0, "Folder Yellow Live Back.png");
            this.imlMenu.Images.SetKeyName(1, "window_dialog.ico");
            this.imlMenu.Images.SetKeyName(2, "blue+.png");
            this.imlMenu.Images.SetKeyName(3, "bluefile.png");
            this.imlMenu.Images.SetKeyName(4, "blue-.png");
            // 
            // txtSearch
            // 
            appearance38.FontData.BoldAsString = "False";
            appearance38.FontData.UnderlineAsString = "False";
            appearance38.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Appearance = appearance38;
            this.txtSearch.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance10.Image = ((object)(resources.GetObject("appearance10.Image")));
            editorButton1.Appearance = appearance10;
            editorButton1.Key = "collapse";
            editorButton1.Width = 25;
            appearance11.Image = ((object)(resources.GetObject("appearance11.Image")));
            editorButton2.Appearance = appearance11;
            editorButton2.Key = "expand";
            editorButton2.Width = 25;
            this.txtSearch.ButtonsLeft.Add(editorButton1);
            this.txtSearch.ButtonsLeft.Add(editorButton2);
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtSearch.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtSearch.Size = new System.Drawing.Size(262, 23);
            this.txtSearch.TabIndex = 70;
            this.txtSearch.Visible = false;
            this.txtSearch.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.txtSearch_EditorButtonClick);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // stsMain
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(35)))), ((int)(((byte)(49)))));
            appearance12.FontData.BoldAsString = "True";
            appearance12.FontData.Name = "맑은 고딕";
            appearance12.FontData.SizeInPoints = 13.5F;
            appearance12.ForeColor = System.Drawing.Color.Cornsilk;
            appearance12.TextVAlignAsString = "Middle";
            this.stsMain.Appearance = appearance12;
            this.stsMain.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.stsMain.BorderStylePanel = Infragistics.Win.UIElementBorderStyle.Solid;
            this.stsMain.Location = new System.Drawing.Point(0, 729);
            this.stsMain.Name = "stsMain";
            appearance13.BorderColor = System.Drawing.Color.Gray;
            appearance13.TextHAlignAsString = "Center";
            appearance13.TextVAlignAsString = "Middle";
            ultraStatusPanel1.Appearance = appearance13;
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            ultraStatusPanel1.MinWidth = 160;
            ultraStatusPanel1.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Time;
            ultraStatusPanel1.Width = 263;
            appearance14.BorderColor = System.Drawing.Color.Silver;
            appearance14.TextHAlignAsString = "Left";
            appearance14.TextVAlignAsString = "Middle";
            ultraStatusPanel2.Appearance = appearance14;
            ultraStatusPanel2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel2.Key = "stbMessage";
            ultraStatusPanel2.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel3.Key = "stbLastUpdate";
            ultraStatusPanel3.Width = 360;
            appearance15.TextHAlignAsString = "Right";
            appearance15.TextVAlignAsString = "Middle";
            ultraStatusPanel4.Appearance = appearance15;
            ultraStatusPanel4.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel4.Key = "stbRowCount";
            appearance16.TextHAlignAsString = "Center";
            appearance16.TextVAlignAsString = "Middle";
            ultraStatusPanel5.Appearance = appearance16;
            ultraStatusPanel5.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel5.Key = "stbFormID";
            ultraStatusPanel5.Width = 120;
            appearance17.TextHAlignAsString = "Center";
            appearance17.TextVAlignAsString = "Middle";
            ultraStatusPanel6.Appearance = appearance17;
            ultraStatusPanel6.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel6.Key = "stbLoginID";
            ultraStatusPanel6.Width = 220;
            this.stsMain.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3,
            ultraStatusPanel4,
            ultraStatusPanel5,
            ultraStatusPanel6});
            this.stsMain.Size = new System.Drawing.Size(1436, 33);
            this.stsMain.TabIndex = 38;
            this.stsMain.UseAppStyling = false;
            this.stsMain.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.stsMain.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // _BaseForm_UltraFormManager_Dock_Area_Top
            // 
            this._BaseForm_UltraFormManager_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._BaseForm_UltraFormManager_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._BaseForm_UltraFormManager_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Top;
            this._BaseForm_UltraFormManager_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._BaseForm_UltraFormManager_Dock_Area_Top.Location = new System.Drawing.Point(0, 27);
            this._BaseForm_UltraFormManager_Dock_Area_Top.Name = "_BaseForm_UltraFormManager_Dock_Area_Top";
            this._BaseForm_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(1436, 0);
            // 
            // _BaseForm_UltraFormManager_Dock_Area_Bottom
            // 
            this._BaseForm_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._BaseForm_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._BaseForm_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._BaseForm_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._BaseForm_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 729);
            this._BaseForm_UltraFormManager_Dock_Area_Bottom.Name = "_BaseForm_UltraFormManager_Dock_Area_Bottom";
            this._BaseForm_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(1436, 0);
            // 
            // _BaseForm_UltraFormManager_Dock_Area_Left
            // 
            this._BaseForm_UltraFormManager_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._BaseForm_UltraFormManager_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._BaseForm_UltraFormManager_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Left;
            this._BaseForm_UltraFormManager_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._BaseForm_UltraFormManager_Dock_Area_Left.Location = new System.Drawing.Point(4, 27);
            this._BaseForm_UltraFormManager_Dock_Area_Left.Name = "_BaseForm_UltraFormManager_Dock_Area_Left";
            this._BaseForm_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(0, 702);
            // 
            // _BaseForm_UltraFormManager_Dock_Area_Right
            // 
            this._BaseForm_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._BaseForm_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._BaseForm_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._BaseForm_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._BaseForm_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(1432, 27);
            this._BaseForm_UltraFormManager_Dock_Area_Right.Name = "_BaseForm_UltraFormManager_Dock_Area_Right";
            this._BaseForm_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(0, 702);
            // 
            // udtMdiManager
            // 
            appearance18.ForeColor = System.Drawing.Color.Black;
            this.udtMdiManager.Appearance = appearance18;
            this.udtMdiManager.BorderColor = System.Drawing.Color.White;
            this.udtMdiManager.MdiParent = this;
            appearance36.BackColor = System.Drawing.Color.White;
            appearance36.ForeColor = System.Drawing.Color.Black;
            this.udtMdiManager.TabGroupSettings.TabAreaAppearance = appearance36;
            appearance37.ForeColor = System.Drawing.Color.Black;
            this.udtMdiManager.TabSettings.TabAppearance = appearance37;
            this.udtMdiManager.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.udtMdiManager.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.udtMdiManager.ViewStyle = Infragistics.Win.UltraWinTabbedMdi.ViewStyle.Office2003;
            this.udtMdiManager.InitializeContextMenu += new Infragistics.Win.UltraWinTabbedMdi.MdiTabContextMenuEventHandler(this.udtMdiManager_InitializeContextMenu);
            this.udtMdiManager.TabClosed += new Infragistics.Win.UltraWinTabbedMdi.MdiTabEventHandler(this.udtMdiManager_TabClosed);
            // 
            // dockManager
            // 
            this.dockManager.AllowDrop = false;
            this.dockManager.AnimationSpeed = Infragistics.Win.UltraWinDock.AnimationSpeed.StandardSpeedPlus2;
            this.dockManager.AutoHideDelay = 1;
            this.dockManager.BorderStyleSplitterBars = Infragistics.Win.UIElementBorderStyle.None;
            this.dockManager.BorderStyleUnpinnedTabArea = Infragistics.Win.UIElementBorderStyle.None;
            this.dockManager.DefaultPaneSettings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Control = this.ultraPanel1;
            dockableControlPane1.FlyoutSize = new System.Drawing.Size(262, -1);
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(23, 149, 216, 169);
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "Menu";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(262, 648);
            this.dockManager.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1});
            this.dockManager.DragWindowStyle = Infragistics.Win.UltraWinDock.DragWindowStyle.LayeredWindowWithIndicators;
            this.dockManager.HostControl = this;
            this.dockManager.ShowCloseButton = false;
            this.dockManager.SplitterBarWidth = 1;
            this.dockManager.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDIPlus;
            this.dockManager.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.dockManager.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // _BaseFormAutoHideControl
            // 
            this._BaseFormAutoHideControl.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this._BaseFormAutoHideControl.Location = new System.Drawing.Point(33, 89);
            this._BaseFormAutoHideControl.Name = "_BaseFormAutoHideControl";
            this._BaseFormAutoHideControl.Owner = this.dockManager;
            this._BaseFormAutoHideControl.Size = new System.Drawing.Size(35, 644);
            this._BaseFormAutoHideControl.TabIndex = 74;
            // 
            // _BaseFormUnpinnedTabAreaRight
            // 
            this._BaseFormUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._BaseFormUnpinnedTabAreaRight.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this._BaseFormUnpinnedTabAreaRight.Location = new System.Drawing.Point(1432, 81);
            this._BaseFormUnpinnedTabAreaRight.Name = "_BaseFormUnpinnedTabAreaRight";
            this._BaseFormUnpinnedTabAreaRight.Owner = this.dockManager;
            this._BaseFormUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 648);
            this._BaseFormUnpinnedTabAreaRight.TabIndex = 71;
            // 
            // _BaseFormUnpinnedTabAreaBottom
            // 
            this._BaseFormUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._BaseFormUnpinnedTabAreaBottom.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this._BaseFormUnpinnedTabAreaBottom.Location = new System.Drawing.Point(4, 729);
            this._BaseFormUnpinnedTabAreaBottom.Name = "_BaseFormUnpinnedTabAreaBottom";
            this._BaseFormUnpinnedTabAreaBottom.Owner = this.dockManager;
            this._BaseFormUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1428, 0);
            this._BaseFormUnpinnedTabAreaBottom.TabIndex = 73;
            // 
            // _BaseFormUnpinnedTabAreaTop
            // 
            this._BaseFormUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._BaseFormUnpinnedTabAreaTop.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this._BaseFormUnpinnedTabAreaTop.Location = new System.Drawing.Point(4, 81);
            this._BaseFormUnpinnedTabAreaTop.Name = "_BaseFormUnpinnedTabAreaTop";
            this._BaseFormUnpinnedTabAreaTop.Owner = this.dockManager;
            this._BaseFormUnpinnedTabAreaTop.Size = new System.Drawing.Size(1428, 0);
            this._BaseFormUnpinnedTabAreaTop.TabIndex = 72;
            // 
            // _BaseFormUnpinnedTabAreaLeft
            // 
            this._BaseFormUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._BaseFormUnpinnedTabAreaLeft.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this._BaseFormUnpinnedTabAreaLeft.Location = new System.Drawing.Point(4, 81);
            this._BaseFormUnpinnedTabAreaLeft.Name = "_BaseFormUnpinnedTabAreaLeft";
            this._BaseFormUnpinnedTabAreaLeft.Owner = this.dockManager;
            this._BaseFormUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 648);
            this._BaseFormUnpinnedTabAreaLeft.TabIndex = 70;
            // 
            // tlbMain
            // 
            this.tlbMain.AllowDrop = true;
            this.tlbMain.AutoSize = false;
            this.tlbMain.BackColor = System.Drawing.Color.White;
            this.tlbMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tlbMain.GripMargin = new System.Windows.Forms.Padding(0);
            this.tlbMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlbMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tlbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblLogo,
            this.tss01,
            this.InqFunc,
            this.NewFunc,
            this.DelFunc,
            this.SaveFunc,
            this.ExcelFunc,
            this.ExeImFunc,
            this.CloseFunc,
            this.tss02,
            this.PrintFunc,
            this.FilterFunc,
            this.SumFunc,
            this.HelpFunc,
            this.FavoriteFunc,
            this.tss03,
            this.ExitFunc,
            this.LangFunc,
            this.cboStyle,
            this.lblStyle,
            this.cboSite,
            this.cboMenu,
            this.lblMenu});
            this.tlbMain.Location = new System.Drawing.Point(4, 27);
            this.tlbMain.Name = "tlbMain";
            this.tlbMain.Padding = new System.Windows.Forms.Padding(0);
            this.tlbMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tlbMain.Size = new System.Drawing.Size(1428, 50);
            this.tlbMain.TabIndex = 85;
            this.tlbMain.Text = "Main ToolBar";
            this.tlbMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.tlbMain_DragEnter);
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = false;
            this.lblLogo.BackColor = System.Drawing.Color.Transparent;
            this.lblLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblLogo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lblLogo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.lblLogo.ImageTransparentColor = System.Drawing.Color.White;
            this.lblLogo.Margin = new System.Windows.Forms.Padding(0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(260, 45);
            this.lblLogo.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // tss01
            // 
            this.tss01.Name = "tss01";
            this.tss01.Size = new System.Drawing.Size(6, 50);
            // 
            // InqFunc
            // 
            this.InqFunc.AutoSize = false;
            this.InqFunc.BackColor = System.Drawing.Color.Transparent;
            this.InqFunc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.InqFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.InqFunc.ForeColor = System.Drawing.Color.White;
            this.InqFunc.Image = global::WIZ.MAIN.Properties.Resources.btnSearch;
            this.InqFunc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.InqFunc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InqFunc.Margin = new System.Windows.Forms.Padding(0);
            this.InqFunc.Name = "InqFunc";
            this.InqFunc.Size = new System.Drawing.Size(100, 45);
            this.InqFunc.Tag = "InqFunc";
            this.InqFunc.Text = "조회";
            this.InqFunc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.InqFunc.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.InqFunc.ToolTipText = "조회(Ctrl+F2) ";
            // 
            // NewFunc
            // 
            this.NewFunc.AutoSize = false;
            this.NewFunc.BackColor = System.Drawing.Color.Transparent;
            this.NewFunc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NewFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.NewFunc.ForeColor = System.Drawing.Color.White;
            this.NewFunc.Image = global::WIZ.MAIN.Properties.Resources.btnAdd;
            this.NewFunc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.NewFunc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewFunc.Margin = new System.Windows.Forms.Padding(0);
            this.NewFunc.Name = "NewFunc";
            this.NewFunc.Size = new System.Drawing.Size(100, 45);
            this.NewFunc.Tag = "NewFunc";
            this.NewFunc.Text = "추가";
            this.NewFunc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NewFunc.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.NewFunc.ToolTipText = "추가(Ctrl+F3)";
            // 
            // DelFunc
            // 
            this.DelFunc.AutoSize = false;
            this.DelFunc.BackColor = System.Drawing.Color.Transparent;
            this.DelFunc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DelFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.DelFunc.ForeColor = System.Drawing.Color.White;
            this.DelFunc.Image = global::WIZ.MAIN.Properties.Resources.btnDelete;
            this.DelFunc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DelFunc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DelFunc.Margin = new System.Windows.Forms.Padding(0);
            this.DelFunc.Name = "DelFunc";
            this.DelFunc.Size = new System.Drawing.Size(100, 45);
            this.DelFunc.Tag = "DelFunc";
            this.DelFunc.Text = "삭제";
            this.DelFunc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DelFunc.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.DelFunc.ToolTipText = "삭제(Ctrl+F4)";
            // 
            // SaveFunc
            // 
            this.SaveFunc.AutoSize = false;
            this.SaveFunc.BackColor = System.Drawing.Color.Transparent;
            this.SaveFunc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.SaveFunc.ForeColor = System.Drawing.Color.White;
            this.SaveFunc.Image = global::WIZ.MAIN.Properties.Resources.btnSave;
            this.SaveFunc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SaveFunc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveFunc.Margin = new System.Windows.Forms.Padding(0);
            this.SaveFunc.Name = "SaveFunc";
            this.SaveFunc.Size = new System.Drawing.Size(100, 45);
            this.SaveFunc.Tag = "SaveFunc";
            this.SaveFunc.Text = "저장";
            this.SaveFunc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SaveFunc.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.SaveFunc.ToolTipText = "저장(Ctrl+F5)";
            // 
            // ExcelFunc
            // 
            this.ExcelFunc.AutoSize = false;
            this.ExcelFunc.BackColor = System.Drawing.Color.Transparent;
            this.ExcelFunc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ExcelFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.ExcelFunc.ForeColor = System.Drawing.Color.White;
            this.ExcelFunc.Image = global::WIZ.MAIN.Properties.Resources.excel_down;
            this.ExcelFunc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ExcelFunc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExcelFunc.Margin = new System.Windows.Forms.Padding(0);
            this.ExcelFunc.Name = "ExcelFunc";
            this.ExcelFunc.Size = new System.Drawing.Size(100, 45);
            this.ExcelFunc.Tag = "ExcelFunc";
            this.ExcelFunc.Text = "엑셀";
            this.ExcelFunc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExcelFunc.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.ExcelFunc.ToolTipText = "엑셀(Ctrl+F6)";
            // 
            // ExeImFunc
            // 
            this.ExeImFunc.AutoSize = false;
            this.ExeImFunc.BackColor = System.Drawing.Color.Transparent;
            this.ExeImFunc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ExeImFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.ExeImFunc.ForeColor = System.Drawing.Color.White;
            this.ExeImFunc.Image = global::WIZ.MAIN.Properties.Resources.excel_up;
            this.ExeImFunc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ExeImFunc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExeImFunc.Margin = new System.Windows.Forms.Padding(0);
            this.ExeImFunc.Name = "ExeImFunc";
            this.ExeImFunc.Size = new System.Drawing.Size(100, 45);
            this.ExeImFunc.Tag = "ExeImFunc";
            this.ExeImFunc.Text = "엑셀";
            this.ExeImFunc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExeImFunc.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.ExeImFunc.ToolTipText = "엑셀업로드(Ctrl+F7)";
            // 
            // CloseFunc
            // 
            this.CloseFunc.AutoSize = false;
            this.CloseFunc.BackColor = System.Drawing.Color.Transparent;
            this.CloseFunc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CloseFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.CloseFunc.ForeColor = System.Drawing.Color.White;
            this.CloseFunc.Image = global::WIZ.MAIN.Properties.Resources.btnClose;
            this.CloseFunc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CloseFunc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CloseFunc.Margin = new System.Windows.Forms.Padding(0);
            this.CloseFunc.Name = "CloseFunc";
            this.CloseFunc.Size = new System.Drawing.Size(100, 45);
            this.CloseFunc.Tag = "CloseFunc";
            this.CloseFunc.Text = "닫기";
            this.CloseFunc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CloseFunc.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.CloseFunc.ToolTipText = "닫기(Ctrl+F10)";
            // 
            // tss02
            // 
            this.tss02.AutoSize = false;
            this.tss02.Name = "tss02";
            this.tss02.Size = new System.Drawing.Size(6, 40);
            this.tss02.Visible = false;
            // 
            // PrintFunc
            // 
            this.PrintFunc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PrintFunc.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.PrintFunc.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.PrintFunc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PrintFunc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PrintFunc.Margin = new System.Windows.Forms.Padding(0);
            this.PrintFunc.Name = "PrintFunc";
            this.PrintFunc.Size = new System.Drawing.Size(23, 50);
            this.PrintFunc.Tag = "PrintFunc";
            this.PrintFunc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PrintFunc.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.PrintFunc.ToolTipText = "출력(Ctrl+F7)";
            this.PrintFunc.Visible = false;
            // 
            // FilterFunc
            // 
            this.FilterFunc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.FilterFunc.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.FilterFunc.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.FilterFunc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.FilterFunc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FilterFunc.Margin = new System.Windows.Forms.Padding(0);
            this.FilterFunc.Name = "FilterFunc";
            this.FilterFunc.Size = new System.Drawing.Size(23, 50);
            this.FilterFunc.Tag = "FilterFunc";
            this.FilterFunc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.FilterFunc.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.FilterFunc.ToolTipText = "필터(Ctrl+F8)";
            this.FilterFunc.Visible = false;
            // 
            // SumFunc
            // 
            this.SumFunc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SumFunc.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SumFunc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SumFunc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SumFunc.Margin = new System.Windows.Forms.Padding(0);
            this.SumFunc.Name = "SumFunc";
            this.SumFunc.Size = new System.Drawing.Size(23, 50);
            this.SumFunc.Tag = "SumFunc";
            this.SumFunc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SumFunc.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.SumFunc.ToolTipText = "합계(Ctrl+F9)";
            this.SumFunc.Visible = false;
            // 
            // HelpFunc
            // 
            this.HelpFunc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.HelpFunc.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.HelpFunc.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HelpFunc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HelpFunc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HelpFunc.Margin = new System.Windows.Forms.Padding(0);
            this.HelpFunc.Name = "HelpFunc";
            this.HelpFunc.Size = new System.Drawing.Size(23, 50);
            this.HelpFunc.Tag = "HelpFunc";
            this.HelpFunc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.HelpFunc.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.HelpFunc.Visible = false;
            // 
            // FavoriteFunc
            // 
            this.FavoriteFunc.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.FavoriteFunc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.FavoriteFunc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FavoriteFunc.Margin = new System.Windows.Forms.Padding(0);
            this.FavoriteFunc.Name = "FavoriteFunc";
            this.FavoriteFunc.Size = new System.Drawing.Size(23, 50);
            this.FavoriteFunc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.FavoriteFunc.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.FavoriteFunc.Visible = false;
            this.FavoriteFunc.Click += new System.EventHandler(this.FavoriteFunc_Click);
            // 
            // tss03
            // 
            this.tss03.Name = "tss03";
            this.tss03.Size = new System.Drawing.Size(6, 50);
            this.tss03.Visible = false;
            // 
            // ExitFunc
            // 
            this.ExitFunc.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ExitFunc.AutoSize = false;
            this.ExitFunc.BackColor = System.Drawing.Color.Transparent;
            this.ExitFunc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ExitFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.ExitFunc.ForeColor = System.Drawing.Color.White;
            this.ExitFunc.Image = global::WIZ.MAIN.Properties.Resources.btnExit;
            this.ExitFunc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ExitFunc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExitFunc.Margin = new System.Windows.Forms.Padding(0);
            this.ExitFunc.Name = "ExitFunc";
            this.ExitFunc.Size = new System.Drawing.Size(100, 45);
            this.ExitFunc.Tag = "ExitFunc";
            this.ExitFunc.Text = "종료";
            this.ExitFunc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExitFunc.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // LangFunc
            // 
            this.LangFunc.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.LangFunc.AutoSize = false;
            this.LangFunc.BackColor = System.Drawing.Color.Transparent;
            this.LangFunc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LangFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.LangFunc.ForeColor = System.Drawing.Color.White;
            this.LangFunc.Image = global::WIZ.MAIN.Properties.Resources.btnLang;
            this.LangFunc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.LangFunc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LangFunc.Margin = new System.Windows.Forms.Padding(0);
            this.LangFunc.Name = "LangFunc";
            this.LangFunc.Size = new System.Drawing.Size(100, 45);
            this.LangFunc.Tag = "LangFunc";
            this.LangFunc.Text = "언어";
            this.LangFunc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LangFunc.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.LangFunc.ToolTipText = "언어";
            // 
            // cboStyle
            // 
            this.cboStyle.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cboStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStyle.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboStyle.Margin = new System.Windows.Forms.Padding(0);
            this.cboStyle.Name = "cboStyle";
            this.cboStyle.Size = new System.Drawing.Size(80, 50);
            this.cboStyle.Visible = false;
            this.cboStyle.SelectedIndexChanged += new System.EventHandler(this.cboStyle_SelectedIndexChanged);
            // 
            // lblStyle
            // 
            this.lblStyle.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblStyle.Margin = new System.Windows.Forms.Padding(0);
            this.lblStyle.Name = "lblStyle";
            this.lblStyle.Size = new System.Drawing.Size(43, 15);
            this.lblStyle.Text = "스타일";
            this.lblStyle.Visible = false;
            // 
            // cboSite
            // 
            this.cboSite.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cboSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSite.Name = "cboSite";
            this.cboSite.Size = new System.Drawing.Size(80, 23);
            this.cboSite.Visible = false;
            // 
            // cboMenu
            // 
            this.cboMenu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cboMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMenu.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboMenu.Margin = new System.Windows.Forms.Padding(0);
            this.cboMenu.Name = "cboMenu";
            this.cboMenu.Size = new System.Drawing.Size(85, 25);
            this.cboMenu.Visible = false;
            this.cboMenu.SelectedIndexChanged += new System.EventHandler(this.cboMenu_SelectedIndexChanged);
            // 
            // lblMenu
            // 
            this.lblMenu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblMenu.Margin = new System.Windows.Forms.Padding(0);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(38, 15);
            this.lblMenu.Text = "Menu";
            this.lblMenu.Visible = false;
            // 
            // ufmForm
            // 
            this.ufmForm.Form = this;
            this.ufmForm.FormStyleSettings.IsGlassSupported = true;
            this.ufmForm.FormStyleSettings.Style = Infragistics.Win.UltraWinForm.UltraFormStyle.Office2010;
            this.ufmForm.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.ufmForm.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // _BaseForm_UltraFormManager_Dock_Area_1_Left
            // 
            this._BaseForm_UltraFormManager_Dock_Area_1_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._BaseForm_UltraFormManager_Dock_Area_1_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._BaseForm_UltraFormManager_Dock_Area_1_Left.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Left;
            this._BaseForm_UltraFormManager_Dock_Area_1_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._BaseForm_UltraFormManager_Dock_Area_1_Left.FormManager = this.ufmForm;
            this._BaseForm_UltraFormManager_Dock_Area_1_Left.InitialResizeAreaExtent = 4;
            this._BaseForm_UltraFormManager_Dock_Area_1_Left.Location = new System.Drawing.Point(0, 27);
            this._BaseForm_UltraFormManager_Dock_Area_1_Left.Name = "_BaseForm_UltraFormManager_Dock_Area_1_Left";
            this._BaseForm_UltraFormManager_Dock_Area_1_Left.Size = new System.Drawing.Size(4, 702);
            // 
            // _BaseForm_UltraFormManager_Dock_Area_1_Right
            // 
            this._BaseForm_UltraFormManager_Dock_Area_1_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._BaseForm_UltraFormManager_Dock_Area_1_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._BaseForm_UltraFormManager_Dock_Area_1_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._BaseForm_UltraFormManager_Dock_Area_1_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._BaseForm_UltraFormManager_Dock_Area_1_Right.FormManager = this.ufmForm;
            this._BaseForm_UltraFormManager_Dock_Area_1_Right.InitialResizeAreaExtent = 4;
            this._BaseForm_UltraFormManager_Dock_Area_1_Right.Location = new System.Drawing.Point(1432, 27);
            this._BaseForm_UltraFormManager_Dock_Area_1_Right.Name = "_BaseForm_UltraFormManager_Dock_Area_1_Right";
            this._BaseForm_UltraFormManager_Dock_Area_1_Right.Size = new System.Drawing.Size(4, 702);
            // 
            // _BaseForm_UltraFormManager_Dock_Area_1_Top
            // 
            this._BaseForm_UltraFormManager_Dock_Area_1_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._BaseForm_UltraFormManager_Dock_Area_1_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._BaseForm_UltraFormManager_Dock_Area_1_Top.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Top;
            this._BaseForm_UltraFormManager_Dock_Area_1_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._BaseForm_UltraFormManager_Dock_Area_1_Top.FormManager = this.ufmForm;
            this._BaseForm_UltraFormManager_Dock_Area_1_Top.Location = new System.Drawing.Point(0, 0);
            this._BaseForm_UltraFormManager_Dock_Area_1_Top.Name = "_BaseForm_UltraFormManager_Dock_Area_1_Top";
            this._BaseForm_UltraFormManager_Dock_Area_1_Top.Size = new System.Drawing.Size(1436, 27);
            // 
            // _BaseForm_UltraFormManager_Dock_Area_1_Bottom
            // 
            this._BaseForm_UltraFormManager_Dock_Area_1_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._BaseForm_UltraFormManager_Dock_Area_1_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._BaseForm_UltraFormManager_Dock_Area_1_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._BaseForm_UltraFormManager_Dock_Area_1_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._BaseForm_UltraFormManager_Dock_Area_1_Bottom.FormManager = this.ufmForm;
            this._BaseForm_UltraFormManager_Dock_Area_1_Bottom.Location = new System.Drawing.Point(0, 729);
            this._BaseForm_UltraFormManager_Dock_Area_1_Bottom.Name = "_BaseForm_UltraFormManager_Dock_Area_1_Bottom";
            this._BaseForm_UltraFormManager_Dock_Area_1_Bottom.Size = new System.Drawing.Size(1436, 0);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(4, 77);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1428, 4);
            this.menuStrip1.TabIndex = 95;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ultraPanelFV
            // 
            this.ultraPanelFV.AllowDrop = true;
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ultraPanelFV.Appearance = appearance20;
            this.ultraPanelFV.BorderStyle = Infragistics.Win.UIElementBorderStyle.TwoColor;
            // 
            // ultraPanelFV.ClientArea
            // 
            this.ultraPanelFV.ClientArea.Controls.Add(this.picResize);
            this.ultraPanelFV.ClientArea.Controls.Add(this.gridFV);
            this.ultraPanelFV.Location = new System.Drawing.Point(565, 128);
            this.ultraPanelFV.Name = "ultraPanelFV";
            this.ultraPanelFV.Size = new System.Drawing.Size(208, 231);
            this.ultraPanelFV.TabIndex = 1001;
            this.ultraPanelFV.TabStop = false;
            this.ultraPanelFV.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.ultraPanelFV.Visible = false;
            // 
            // picResize
            // 
            this.picResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picResize.BackColor = System.Drawing.Color.Transparent;
            this.picResize.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.picResize.Image = ((System.Drawing.Image)(resources.GetObject("picResize.Image")));
            this.picResize.Location = new System.Drawing.Point(189, 213);
            this.picResize.Name = "picResize";
            this.picResize.Size = new System.Drawing.Size(13, 12);
            this.picResize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picResize.TabIndex = 1002;
            this.picResize.TabStop = false;
            this.picResize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picResize_MouseDown);
            this.picResize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picResize_MouseMove);
            this.picResize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picResize_MouseUp);
            // 
            // gridFV
            // 
            this.gridFV.AllowDrop = true;
            this.gridFV.AutoResizeColumn = false;
            this.gridFV.AutoUserColumn = false;
            this.gridFV.ContextMenuCopyEnabled = false;
            this.gridFV.ContextMenuDeleteEnabled = false;
            this.gridFV.ContextMenuExcelEnabled = false;
            this.gridFV.ContextMenuInsertEnabled = false;
            this.gridFV.ContextMenuPasteEnabled = false;
            this.gridFV.DeleteButtonEnable = false;
            appearance21.BackColor = System.Drawing.SystemColors.Window;
            appearance21.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.gridFV.DisplayLayout.Appearance = appearance21;
            appearance22.TextHAlignAsString = "Center";
            appearance22.TextVAlignAsString = "Middle";
            ultraGridColumn1.Header.Appearance = appearance22;
            ultraGridColumn1.Header.Caption = "북마크";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.MinWidth = 100;
            ultraGridColumn1.Width = 198;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2});
            this.gridFV.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.gridFV.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridFV.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.gridFV.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance23.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance23.BorderColor = System.Drawing.SystemColors.Window;
            this.gridFV.DisplayLayout.GroupByBox.Appearance = appearance23;
            appearance24.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridFV.DisplayLayout.GroupByBox.BandLabelAppearance = appearance24;
            this.gridFV.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.gridFV.DisplayLayout.GroupByBox.Hidden = true;
            appearance25.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance25.BackColor2 = System.Drawing.SystemColors.Control;
            appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance25.ForeColor = System.Drawing.SystemColors.GrayText;
            this.gridFV.DisplayLayout.GroupByBox.PromptAppearance = appearance25;
            this.gridFV.DisplayLayout.MaxColScrollRegions = 1;
            this.gridFV.DisplayLayout.MaxRowScrollRegions = 1;
            appearance26.BackColor = System.Drawing.SystemColors.Window;
            appearance26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridFV.DisplayLayout.Override.ActiveCellAppearance = appearance26;
            appearance27.BackColor = System.Drawing.SystemColors.Highlight;
            appearance27.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridFV.DisplayLayout.Override.ActiveRowAppearance = appearance27;
            this.gridFV.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.gridFV.DisplayLayout.Override.AllowMultiCellOperations = ((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)(((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut)
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste)));
            this.gridFV.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.gridFV.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance28.BackColor = System.Drawing.SystemColors.Window;
            this.gridFV.DisplayLayout.Override.CardAreaAppearance = appearance28;
            appearance29.BorderColor = System.Drawing.Color.Silver;
            appearance29.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.gridFV.DisplayLayout.Override.CellAppearance = appearance29;
            this.gridFV.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.gridFV.DisplayLayout.Override.CellPadding = 0;
            appearance30.BackColor = System.Drawing.SystemColors.Control;
            appearance30.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance30.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance30.BorderColor = System.Drawing.SystemColors.Window;
            this.gridFV.DisplayLayout.Override.GroupByRowAppearance = appearance30;
            appearance31.TextHAlignAsString = "Left";
            this.gridFV.DisplayLayout.Override.HeaderAppearance = appearance31;
            this.gridFV.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.gridFV.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance32.BackColor = System.Drawing.SystemColors.Window;
            appearance32.BorderColor = System.Drawing.Color.Silver;
            this.gridFV.DisplayLayout.Override.RowAppearance = appearance32;
            this.gridFV.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance33.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gridFV.DisplayLayout.Override.TemplateAddRowAppearance = appearance33;
            this.gridFV.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None;
            this.gridFV.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.gridFV.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.gridFV.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.gridFV.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.gridFV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFV.EnterNextRowEnable = false;
            this.gridFV.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gridFV.Location = new System.Drawing.Point(0, 0);
            this.gridFV.Name = "gridFV";
            this.gridFV.Size = new System.Drawing.Size(204, 227);
            this.gridFV.TabIndex = 1001;
            this.gridFV.Text = "grid1";
            this.gridFV.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.gridFV.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnRowChange;
            this.gridFV.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.gridFV.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.gridFV.Visible = false;
            this.gridFV.SelectionDrag += new System.ComponentModel.CancelEventHandler(this.gridFV_SelectionDrag);
            this.gridFV.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.gridFV_DoubleClickRow);
            this.gridFV.DragEnter += new System.Windows.Forms.DragEventHandler(this.gridFV_DragEnter);
            this.gridFV.DragLeave += new System.EventHandler(this.gridFV_DragLeave);
            this.gridFV.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.gridFV_GiveFeedback);
            this.gridFV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridFV_MouseDown);
            this.gridFV.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridFV_MouseMove);
            this.gridFV.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridFV_MouseUp);
            // 
            // ultraGridColumnChooser1
            // 
            this.ultraGridColumnChooser1.ColumnDisplayOrder = Infragistics.Win.UltraWinGrid.ColumnDisplayOrder.SameAsGrid;
            this.ultraGridColumnChooser1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.ultraGridColumnChooser1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGridColumnChooser1.DisplayLayout.MaxColScrollRegions = 1;
            this.ultraGridColumnChooser1.DisplayLayout.MaxRowScrollRegions = 1;
            this.ultraGridColumnChooser1.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.ultraGridColumnChooser1.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            this.ultraGridColumnChooser1.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.ultraGridColumnChooser1.DisplayLayout.Override.AllowRowLayoutLabelSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.ultraGridColumnChooser1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.ultraGridColumnChooser1.DisplayLayout.Override.CellPadding = 2;
            this.ultraGridColumnChooser1.DisplayLayout.Override.ExpansionIndicator = Infragistics.Win.UltraWinGrid.ShowExpansionIndicator.Never;
            this.ultraGridColumnChooser1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
            this.ultraGridColumnChooser1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGridColumnChooser1.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            this.ultraGridColumnChooser1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGridColumnChooser1.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGridColumnChooser1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGridColumnChooser1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.ultraGridColumnChooser1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGridColumnChooser1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraGridColumnChooser1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ultraGridColumnChooser1.Location = new System.Drawing.Point(0, 0);
            this.ultraGridColumnChooser1.MultipleBandSupport = Infragistics.Win.UltraWinGrid.MultipleBandSupport.DisplayColumnsFromAllBands;
            this.ultraGridColumnChooser1.Name = "ultraGridColumnChooser1";
            this.ultraGridColumnChooser1.Size = new System.Drawing.Size(167, 179);
            this.ultraGridColumnChooser1.Style = Infragistics.Win.UltraWinGrid.ColumnChooserStyle.AllColumnsWithCheckBoxes;
            this.ultraGridColumnChooser1.StyleLibraryName = "";
            this.ultraGridColumnChooser1.StyleSetName = "";
            this.ultraGridColumnChooser1.TabIndex = 1011;
            this.ultraGridColumnChooser1.Text = "ultraGridColumnChooser1";
            // 
            // ultraPanelCC
            // 
            appearance35.BackColor = System.Drawing.Color.DimGray;
            this.ultraPanelCC.Appearance = appearance35;
            // 
            // ultraPanelCC.ClientArea
            // 
            this.ultraPanelCC.ClientArea.Controls.Add(this.pictureBox1);
            this.ultraPanelCC.ClientArea.Controls.Add(this.ultraGridColumnChooser1);
            this.ultraPanelCC.Location = new System.Drawing.Point(93, 211);
            this.ultraPanelCC.Name = "ultraPanelCC";
            this.ultraPanelCC.Size = new System.Drawing.Size(167, 202);
            this.ultraPanelCC.TabIndex = 1021;
            this.ultraPanelCC.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Maroon;
            this.pictureBox1.Location = new System.Drawing.Point(143, 180);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1012;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // imgMenu1
            // 
            this.imgMenu1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgMenu1.ImageStream")));
            this.imgMenu1.TransparentColor = System.Drawing.Color.Transparent;
            this.imgMenu1.Images.SetKeyName(0, "Folder Yellow Live Back.ico");
            this.imgMenu1.Images.SetKeyName(1, "Window_Form.png");
            this.imgMenu1.Images.SetKeyName(2, "MTree01.png");
            this.imgMenu1.Images.SetKeyName(3, "Mtree03.png");
            this.imgMenu1.Images.SetKeyName(4, "MTree02.png");
            // 
            // imgMenu2
            // 
            this.imgMenu2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgMenu2.ImageStream")));
            this.imgMenu2.TransparentColor = System.Drawing.Color.Transparent;
            this.imgMenu2.Images.SetKeyName(0, "Folder Yellow Live Back.ico");
            this.imgMenu2.Images.SetKeyName(1, "Window_Form.png");
            this.imgMenu2.Images.SetKeyName(2, "green+.png");
            this.imgMenu2.Images.SetKeyName(3, "greenfile.png");
            this.imgMenu2.Images.SetKeyName(4, "green-.png");
            // 
            // picMainBody
            // 
            appearance34.BackColor = System.Drawing.Color.White;
            appearance34.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(44)))), ((int)(((byte)(61)))));
            appearance34.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(44)))), ((int)(((byte)(61)))));
            appearance34.FontData.BoldAsString = "False";
            appearance34.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered;
            this.picMainBody.Appearance = appearance34;
            this.picMainBody.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            // 
            // picMainBody.ClientArea
            // 
            this.picMainBody.ClientArea.Controls.Add(this.ultraPanelCC);
            this.picMainBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMainBody.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.picMainBody.Location = new System.Drawing.Point(267, 81);
            this.picMainBody.Margin = new System.Windows.Forms.Padding(0);
            this.picMainBody.Name = "picMainBody";
            this.picMainBody.Size = new System.Drawing.Size(1165, 648);
            this.picMainBody.TabIndex = 1041;
            // 
            // windowDockingArea1
            // 
            this.windowDockingArea1.Controls.Add(this.dockableWindow1);
            this.windowDockingArea1.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowDockingArea1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.windowDockingArea1.Location = new System.Drawing.Point(4, 81);
            this.windowDockingArea1.Name = "windowDockingArea1";
            this.windowDockingArea1.Owner = this.dockManager;
            this.windowDockingArea1.Size = new System.Drawing.Size(263, 648);
            this.windowDockingArea1.TabIndex = 1052;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Controls.Add(this.ultraPanel1);
            this.dockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Owner = this.dockManager;
            this.dockableWindow1.Size = new System.Drawing.Size(262, 648);
            this.dockableWindow1.TabIndex = 1072;
            // 
            // pnlLang
            // 
            appearance19.ImageBackground = global::WIZ.MAIN.Properties.Resources.btnLangBG;
            this.pnlLang.Appearance = appearance19;
            // 
            // pnlLang.ClientArea
            // 
            this.pnlLang.ClientArea.Controls.Add(this.cboLang);
            this.pnlLang.ClientArea.Controls.Add(this.picExit);
            this.pnlLang.Location = new System.Drawing.Point(759, 361);
            this.pnlLang.Name = "pnlLang";
            this.pnlLang.Size = new System.Drawing.Size(170, 40);
            this.pnlLang.TabIndex = 1062;
            this.pnlLang.Visible = false;
            // 
            // cboLang
            // 
            this.cboLang.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboLang.Location = new System.Drawing.Point(8, 7);
            this.cboLang.Name = "cboLang";
            this.cboLang.Size = new System.Drawing.Size(120, 27);
            this.cboLang.TabIndex = 1013;
            this.cboLang.ValueChanged += new System.EventHandler(this.cboLang_ValueChanged);
            // 
            // picExit
            // 
            this.picExit.BackColor = System.Drawing.Color.Transparent;
            this.picExit.Image = global::WIZ.MAIN.Properties.Resources.btnLangExit;
            this.picExit.Location = new System.Drawing.Point(135, 7);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(27, 27);
            this.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picExit.TabIndex = 1012;
            this.picExit.TabStop = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // ZA0003
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1436, 762);
            this.Controls.Add(this._BaseFormAutoHideControl);
            this.Controls.Add(this.pnlLang);
            this.Controls.Add(this.ultraPanelFV);
            this.Controls.Add(this.picMainBody);
            this.Controls.Add(this.windowDockingArea1);
            this.Controls.Add(this._BaseFormUnpinnedTabAreaTop);
            this.Controls.Add(this._BaseFormUnpinnedTabAreaBottom);
            this.Controls.Add(this._BaseFormUnpinnedTabAreaLeft);
            this.Controls.Add(this._BaseFormUnpinnedTabAreaRight);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tlbMain);
            this.Controls.Add(this._BaseForm_UltraFormManager_Dock_Area_Left);
            this.Controls.Add(this._BaseForm_UltraFormManager_Dock_Area_Right);
            this.Controls.Add(this._BaseForm_UltraFormManager_Dock_Area_1_Left);
            this.Controls.Add(this._BaseForm_UltraFormManager_Dock_Area_1_Right);
            this.Controls.Add(this._BaseForm_UltraFormManager_Dock_Area_Top);
            this.Controls.Add(this._BaseForm_UltraFormManager_Dock_Area_Bottom);
            this.Controls.Add(this._BaseForm_UltraFormManager_Dock_Area_1_Top);
            this.Controls.Add(this._BaseForm_UltraFormManager_Dock_Area_1_Bottom);
            this.Controls.Add(this.stsMain);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ZA0003";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ZA0003_FormClosing);
            this.Load += new System.EventHandler(this.ZA0003_Load);
            this.ultraPanel1.ClientArea.ResumeLayout(false);
            this.ultraPanel1.ClientArea.PerformLayout();
            this.ultraPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stsMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtMdiManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.tlbMain.ResumeLayout(false);
            this.tlbMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ufmForm)).EndInit();
            this.ultraPanelFV.ClientArea.ResumeLayout(false);
            this.ultraPanelFV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picResize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridColumnChooser1)).EndInit();
            this.ultraPanelCC.ClientArea.ResumeLayout(false);
            this.ultraPanelCC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.picMainBody.ClientArea.ResumeLayout(false);
            this.picMainBody.ResumeLayout(false);
            this.windowDockingArea1.ResumeLayout(false);
            this.dockableWindow1.ResumeLayout(false);
            this.pnlLang.ClientArea.ResumeLayout(false);
            this.pnlLang.ClientArea.PerformLayout();
            this.pnlLang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboLang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WIZ.Forms
{
    public class BasePopupForm : Form
    {
        private delegate void ClosePrgFormCallBack();

        public string Lang = string.Empty;

        public string WorkerID = string.Empty;

        protected AutoResetEvent AutoReset = new AutoResetEvent(initialState: false);

        protected BaseProgressForm ProgressForm;

        protected BaseProgressFormGif ProgressFormGif;

        public FormInfor FormInformation;

        private ArrayList fControls = new ArrayList();

        private UltraPanel ultraPanelCC;

        private UltraGridColumnChooser ultraGridColumnChooser1;

        private bool _bCancel;

        protected bool IsShowDialog = false;

        private IContainer components = null;

        private BackgroundWorker bgProcess;

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

        public void ShowProgressForm(string msg)
        {
            bgProcess.RunWorkerAsync(FormInformation.GetMessage(msg));
            AutoReset.WaitOne();
        }

        protected void ClosePrgForm()
        {
            IsShowDialog = false;
            try
            {
                if (ProgressForm != null)
                {
                    if (ProgressForm.InvokeRequired)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            Thread.Sleep(200);
                            ProgressForm.Close();
                        });
                    }
                    else
                    {
                        ProgressForm.Close();
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
                    if (ProgressFormGif.InvokeRequired)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            Thread.Sleep(200);
                            ProgressFormGif.Close();
                        });
                    }
                    else
                    {
                        ProgressFormGif.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageForm messageForm = new MessageForm(ex);
                messageForm.ShowDialog();
            }
        }

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
                    if (control.GetType().ToString().Equals("WIZ.Control.Grid"))
                    {
                        fControls.Add(control);
                    }
                    findControls(control, binit: false);
                }
            }
            catch
            {
            }
        }

        public void setColumnChooserPOP(WIZ.Control.Grid ugrid, object frm)
        {
            if (ugrid == null)
            {
                ultraPanelCC.Visible = false;
                return;
            }
            ultraPanelCC.Visible = !ultraPanelCC.Visible;
            ultraPanelCC.BringToFront();
            if (ultraPanelCC.Visible)
            {
                ultraGridColumnChooser1.SourceGrid = ugrid;
                ultraPanelCC.Left = System.Windows.Forms.Control.MousePosition.X - ((Form)frm).Location.X + 5;
                ultraPanelCC.Top = System.Windows.Forms.Control.MousePosition.Y - ((Form)frm).Location.Y + 20;
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

        public void ShowErrorMessage(Exception ex)
        {
            MessageForm messageForm = new MessageForm(ex);
            messageForm.ShowDialog();
        }

        public void ShowErrorMessage(SException ex)
        {
            MessageForm messageForm = new MessageForm(ex);
            messageForm.ShowDialog();
        }

        public BasePopupForm()
        {
            InitializeComponent();
        }

        public virtual string CanDeleteCheck(UltraGridRow ugr)
        {
            return "";
        }

        public virtual string CanModifyCheck(UltraGridRow ugr)
        {
            return "";
        }

        protected override void OnLoad(EventArgs e)
        {
            subData = new SubData(this.Name);
            base.OnLoad(e);
            Lang = Common.Lang;
            if (!base.DesignMode && this != null)
            {
                FormInformation = new FormInfor(base.Name, Text, Lang, "POP");
                FormInformation.ManageForm(this);

                SetSubData();
            }
            findControls(this);
            if (fControls.Count > 0)
            {
                ultraPanelCC = new UltraPanel();
                ultraGridColumnChooser1 = new UltraGridColumnChooser();
                ultraPanelCC.ClientArea.SuspendLayout();
                ultraPanelCC.SuspendLayout();
                ((ISupportInitialize)ultraGridColumnChooser1).BeginInit();
                ultraPanelCC.ClientArea.Controls.Add(ultraGridColumnChooser1);
                ultraPanelCC.Location = new Point(50, 51);
                ultraPanelCC.Name = "ultraPanelCC";
                ultraPanelCC.Size = new Size(167, 202);
                ultraPanelCC.TabIndex = 1022;
                ultraPanelCC.Visible = false;
                ultraPanelCC.Appearance.BackColor = Color.DimGray;
                ultraGridColumnChooser1.ColumnDisplayOrder = ColumnDisplayOrder.SameAsGrid;
                ultraGridColumnChooser1.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
                ultraGridColumnChooser1.DisplayLayout.CaptionVisible = DefaultableBoolean.False;
                ultraGridColumnChooser1.DisplayLayout.MaxColScrollRegions = 1;
                ultraGridColumnChooser1.DisplayLayout.MaxRowScrollRegions = 1;
                ultraGridColumnChooser1.DisplayLayout.Override.AllowColMoving = AllowColMoving.NotAllowed;
                ultraGridColumnChooser1.DisplayLayout.Override.AllowColSizing = AllowColSizing.None;
                ultraGridColumnChooser1.DisplayLayout.Override.AllowRowLayoutCellSizing = RowLayoutSizing.None;
                ultraGridColumnChooser1.DisplayLayout.Override.AllowRowLayoutLabelSizing = RowLayoutSizing.None;
                ultraGridColumnChooser1.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
                ultraGridColumnChooser1.DisplayLayout.Override.CellPadding = 2;
                ultraGridColumnChooser1.DisplayLayout.Override.ExpansionIndicator = ShowExpansionIndicator.Never;
                ultraGridColumnChooser1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
                ultraGridColumnChooser1.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
                ultraGridColumnChooser1.DisplayLayout.Override.RowSizing = RowSizing.AutoFixed;
                ultraGridColumnChooser1.DisplayLayout.Override.SelectTypeCell = SelectType.None;
                ultraGridColumnChooser1.DisplayLayout.Override.SelectTypeCol = SelectType.None;
                ultraGridColumnChooser1.DisplayLayout.Override.SelectTypeRow = SelectType.None;
                ultraGridColumnChooser1.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
                ultraGridColumnChooser1.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
                ultraGridColumnChooser1.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
                ultraGridColumnChooser1.Location = new Point(3, 3);
                ultraGridColumnChooser1.MultipleBandSupport = MultipleBandSupport.DisplayColumnsFromAllBands;
                ultraGridColumnChooser1.Name = "ultraGridColumnChooser1";
                ultraGridColumnChooser1.Size = new Size(160, 195);
                ultraGridColumnChooser1.Style = ColumnChooserStyle.AllColumnsWithCheckBoxes;
                ultraGridColumnChooser1.StyleLibraryName = "";
                ultraGridColumnChooser1.StyleSetName = "";
                ultraGridColumnChooser1.TabIndex = 1011;
                ultraGridColumnChooser1.Text = "ultraGridColumnChooser1";
                base.Controls.Add(ultraPanelCC);
                ultraPanelCC.ClientArea.ResumeLayout(performLayout: false);
                ultraPanelCC.ResumeLayout(performLayout: false);
                ((ISupportInitialize)ultraGridColumnChooser1).EndInit();
            }
        }

        protected virtual void SetSubData()
        {
        }

        private void BasePopupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            findControls(this);
            foreach (System.Windows.Forms.Control fControl in fControls)
            {
                ((WIZ.Control.Grid)fControl).Close();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WIZ.Forms.BasePopupForm));
            bgProcess = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            bgProcess.WorkerSupportsCancellation = true;
            bgProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(bgProcess_DoWork);
            base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(239, 243, 246);
            base.ClientSize = new System.Drawing.Size(409, 362);
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.Name = "BasePopupForm";
            Text = "BasePopupForm";
            base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(BasePopupForm_FormClosing);
            ResumeLayout(false);
        }
    }
}

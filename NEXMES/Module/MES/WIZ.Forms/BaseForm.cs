using System.Windows.Forms;

namespace WIZ.Forms
{
    public class BaseForm : Form, IForm
    {
        public string WorkerID = "";

        public string Lang = "";

        public string IP = "";

        public bool bPopUp = false;

        //public IContainer components = null;

        public BaseForm()
        {
            InitializeComponentBaseForm();
        }

        public virtual void SetToolBarButton(string key, bool isBtnEnabled)
        {
        }

        public virtual void SetStatusBarMessage(string message)
        {
        }

        public virtual void SetTextForID(string message, string sID)
        {
        }

        public virtual void SetFormID(string formid)
        {
        }

        public virtual void SetLoginID(string loginid)
        {
        }

        public virtual void SetLoginName(string loginName)
        {
        }

        public virtual void DoToolBarClick(string key)
        {
        }

        public virtual void SetLink(Form childForm, bool bLink)
        {
        }

        public virtual void SetTextRowCount(string value)
        {
        }

        public virtual void ExportExcel(string sFileName)
        {
        }

        public virtual void ImportExcel()
        {
        }

        public virtual void Tree_Refresh()
        {
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing && components != null)
            //{
            //	components.Dispose();
            //}
            base.Dispose(disposing);
        }

        private void InitializeComponentBaseForm()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WIZ.Forms.BaseForm));
            SuspendLayout();
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(239, 243, 246);
            base.ClientSize = new System.Drawing.Size(304, 282);
            DoubleBuffered = true;
            Font = new System.Drawing.Font("맑은 고딕", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.Name = "BaseForm";
            Text = "BaseForm";
            ResumeLayout(false);
        }
    }
}

using Infragistics.Win;
using Infragistics.Win.Misc;
using System.ComponentModel;
using System.Drawing;

namespace WIZ.Control
{
    public class SLabel : UltraLabel
    {
        public enum RequireFlagEnum
        {
            YES,
            NO,
            Default
        }

        public string dbConfig;

        private string dbField;

        private RequireFlagEnum _RequireFlag = RequireFlagEnum.Default;

        private IContainer components = null;

        public string DbField
        {
            get
            {
                return dbField;
            }
            set
            {
                dbField = value;
            }
        }

        public new string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        public RequireFlagEnum RequireFlag
        {
            get
            {
                return _RequireFlag;
            }
            set
            {
                _RequireFlag = value;
                SetDisplay();
            }
        }

        public SLabel()
        {
            InitializeComponent();
        }

        private void SetDisplay()
        {
            switch (_RequireFlag)
            {
                case RequireFlagEnum.YES:
                    base.Appearance.ForeColor = Color.Blue;
                    base.Appearance.FontData.Underline = DefaultableBoolean.True;
                    base.Appearance.FontData.Bold = DefaultableBoolean.True;
                    break;
                case RequireFlagEnum.NO:
                    base.Appearance.ForeColor = Color.Black;
                    base.Appearance.FontData.Underline = DefaultableBoolean.False;
                    base.Appearance.FontData.Bold = DefaultableBoolean.False;
                    break;
                case RequireFlagEnum.Default:
                    base.Appearance.ForeColor = Color.White;
                    base.Appearance.FontData.Underline = DefaultableBoolean.False;
                    base.Appearance.FontData.Bold = DefaultableBoolean.True;
                    break;
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
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            SuspendLayout();
            appearance.TextHAlignAsString = "Right";
            appearance.TextVAlignAsString = "Middle";
            base.Appearance = appearance;
            Font = new System.Drawing.Font("맑은 고딕", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            ResumeLayout(false);
        }
    }
}

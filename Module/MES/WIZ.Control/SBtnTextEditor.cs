using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WIZ.Control
{
    public class SBtnTextEditor : UltraTextEditor
    {
        public enum ButtonImgTypeEnum
        {
            Type1,
            Type2,
            Type3
        }

        public enum RequireFlagEnum
        {
            YES,
            NO
        }

        private readonly UltraButton _button;

        private int _width;

        private ButtonImgTypeEnum _ImgType = ButtonImgTypeEnum.Type1;

        private RequireFlagEnum _RequireFlag = RequireFlagEnum.NO;

        private RequireFlagEnum _PopupColor = RequireFlagEnum.NO;

        private string sValue1 = string.Empty;

        private string sValue2 = string.Empty;

        private IContainer components = null;

        public UltraButton Button => _button;

        public int btnWidth
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                OnResize(null);
            }
        }

        public ButtonImgTypeEnum btnImgType
        {
            get
            {
                return _ImgType;
            }
            set
            {
                _ImgType = value;
                SetDisplay();
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

        public RequireFlagEnum RequirePop
        {
            get
            {
                return _PopupColor;
            }
            set
            {
                _PopupColor = value;
                SetDisplay();
            }
        }

        public event EventHandler ButtonClick
        {
            add
            {
                _button.Click += value;
            }
            remove
            {
                _button.Click -= value;
            }
        }

        public SBtnTextEditor()
        {
            InitializeComponent();
            _width = 26;
            _button = new UltraButton
            {
                Cursor = Cursors.Default
            };
            _button.SizeChanged += delegate (object o, EventArgs e)
            {
                OnResize(e);
            };
            _button.Appearance.ImageHAlign = HAlign.Center;
            _button.Appearance.ImageVAlign = VAlign.Middle;
            _button.ImageSize = new Size(12, 12);
            base.Controls.Add(_button);
            base.AfterEnterEditMode -= Text_AfterEnterEditMode;
            base.AfterEnterEditMode += Text_AfterEnterEditMode;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            _button.Size = new Size(_width, base.ClientSize.Height - 4);
            _button.Location = new Point(base.ClientSize.Width - _button.Width - 2, 2);
            _button.Cursor = Cursors.Default;
            SetDisplay();
            SendMessage(base.Handle, 211, (IntPtr)2, (IntPtr)(_button.Width << 12));
        }

        private void SetDisplay()
        {
            switch (_ImgType)
            {
                case ButtonImgTypeEnum.Type1:
                    _button.Appearance.Image = WIZ.Control.Properties.Resources.Popup01;
                    break;
                case ButtonImgTypeEnum.Type2:
                    _button.Appearance.Image = WIZ.Control.Properties.Resources.Popup02;
                    break;
                case ButtonImgTypeEnum.Type3:
                    _button.Appearance.Image = WIZ.Control.Properties.Resources.Popup03;
                    break;
            }
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
            }
            switch (_PopupColor)
            {
                case RequireFlagEnum.YES:
                    base.Appearance.BackColor = SystemColors.InactiveBorder;
                    break;
                case RequireFlagEnum.NO:
                    base.Appearance.BackColor = Color.Empty;
                    break;
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }

        private void Text_AfterEnterEditMode(object sender, EventArgs e)
        {
            try
            {
                UltraTextEditor ultraTextEditor = sender as UltraTextEditor;
                if (ultraTextEditor != null && ultraTextEditor.Editor != null)
                {
                    ultraTextEditor.Editor.KeyUp -= Editor_KeyUp;
                    ultraTextEditor.Editor.KeyUp += Editor_KeyUp;
                    ultraTextEditor.Editor.BeforeExitEditMode -= Editor_BeforeExitEditMode;
                    ultraTextEditor.Editor.BeforeExitEditMode += Editor_BeforeExitEditMode;
                }
            }
            catch
            {
            }
        }

        private void Editor_KeyUp(object sender, KeyEventArgs e)
        {
            EmbeddableEditorBase embeddableEditorBase = sender as EmbeddableEditorBase;
            if (embeddableEditorBase != null)
            {
                sValue1 = $"{embeddableEditorBase.Value}";
                sValue2 = embeddableEditorBase.CurrentEditText;
            }
        }

        private void Editor_BeforeExitEditMode(object sender, BeforeExitEditModeEventArgs e)
        {
            EmbeddableEditorBase embeddableEditorBase = sender as EmbeddableEditorBase;
            if (embeddableEditorBase != null && sValue1 != sValue2)
            {
                embeddableEditorBase.Value = sValue2;
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
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            appearance.BackColor = System.Drawing.SystemColors.InactiveBorder;
            base.Appearance = appearance;
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }
    }
}

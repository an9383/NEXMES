using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WIZ.Control
{
    public class STextBox : UltraTextEditor
    {
        public enum RequireFlagEnum
        {
            YES,
            NO
        }

        private RequireFlagEnum _RequireFlag = RequireFlagEnum.NO;

        private RequireFlagEnum _PopupColor = RequireFlagEnum.NO;

        private string sValue1 = string.Empty;

        private string sValue2 = string.Empty;

        private IContainer components = null;

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

        public STextBox()
        {
            InitializeComponent();
            base.AfterEnterEditMode -= Text_AfterEnterEditMode;
            base.AfterEnterEditMode += Text_AfterEnterEditMode;
        }

        public STextBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            base.AfterEnterEditMode -= Text_AfterEnterEditMode;
            base.AfterEnterEditMode += Text_AfterEnterEditMode;
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
        }
    }
}

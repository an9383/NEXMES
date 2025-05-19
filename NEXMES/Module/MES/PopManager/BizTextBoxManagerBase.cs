using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WIZ.Control;

namespace WIZ.PopManager
{
    public class BizTextBoxManagerBase
    {
        public delegate void ClosePopUpHandler(object sender, ClosePopUpArgument e);

        public class ClosePopUpArgument
        {
            private object _tCodeBox;

            private object _tNameBox;

            public object CodeBox => _tCodeBox;

            public object NameBox => _tNameBox;

            public ClosePopUpArgument(object tCodeBox, object tNameBox)
            {
                _tCodeBox = tCodeBox;
                _tNameBox = tNameBox;
            }
        }

        public delegate void InitTextBoxHandler(object sender, InitTextBoxArgument e);

        public class InitTextBoxArgument
        {
            private object _TextBox;

            public object TextBox => _TextBox;

            public InitTextBoxArgument(object textBox)
            {
                _TextBox = textBox;
            }
        }

        private class PopUpClass
        {
            private BizTextBoxManagerBase _parent;

            public object tCodeBox;

            public object tNameBox;

            public string PopUpName;

            public object[] Param;

            public string[] ColumnList;

            public object[] ObjectList;

            private string sType = "T";

            public PopUpClass()
            {
            }

            public PopUpClass(BizTextBoxManagerBase tManager, object codeBox, object nameBox, string sPopUpFunction, object[] param, string[] columnList = null, object[] objectList = null)
            {
                tCodeBox = codeBox;
                tNameBox = nameBox;
                PopUpName = sPopUpFunction;
                Param = param;
                switch (codeBox.GetType().Name)
                {
                    case "TextBox":
                        ((TextBox)tCodeBox).KeyDown += tCodeBox_KeyDown;
                        ((TextBox)tCodeBox).KeyPress += tCodeBox_KeyPress;
                        ((TextBox)tCodeBox).MouseDoubleClick += tCodeBox_MouseDoubleClick;
                        sType = "T";
                        break;
                    case "SBtnTextEditor":
                        ((System.Windows.Forms.Control)(object)(SBtnTextEditor)tCodeBox).KeyDown += tCodeBox_KeyDown;
                        ((System.Windows.Forms.Control)(object)(SBtnTextEditor)tCodeBox).KeyPress += tCodeBox_KeyPress;
                        ((System.Windows.Forms.Control)(object)(SBtnTextEditor)tCodeBox).ControlAdded += tCodeControlAdd;
                        ((System.Windows.Forms.Control)(object)((SBtnTextEditor)codeBox).Button).MouseClick += tCodeBox_Click;
                        sType = "B";
                        break;
                    case "UltraTextEditor":
                    case "STextBox":
                        ((System.Windows.Forms.Control)(object)(UltraTextEditor)tCodeBox).KeyDown += tCodeBox_KeyDown;
                        ((System.Windows.Forms.Control)(object)(UltraTextEditor)tCodeBox).KeyPress += tCodeBox_KeyPress;
                        ((System.Windows.Forms.Control)(object)(UltraTextEditor)tCodeBox).ControlAdded += tCodeControlAdd;
                        sType = "U";
                        break;
                }
                switch (nameBox.GetType().Name)
                {
                    case "TextBox":
                        ((TextBox)tNameBox).KeyDown += tNameBox_KeyDown;
                        ((TextBox)tNameBox).KeyPress += tNameBox_KeyPress;
                        ((TextBox)tNameBox).MouseDoubleClick += tNameBox_MouseDoubleClick;
                        break;
                    case "SBtnTextEditor":
                        ((System.Windows.Forms.Control)(object)(SBtnTextEditor)tNameBox).KeyDown += tNameBox_KeyDown;
                        ((System.Windows.Forms.Control)(object)(SBtnTextEditor)tNameBox).KeyPress += tNameBox_KeyPress;
                        ((System.Windows.Forms.Control)(object)(SBtnTextEditor)tNameBox).ControlAdded += tNameBoxControlAdd;
                        break;
                    case "UltraTextEditor":
                    case "STextBox":
                        ((System.Windows.Forms.Control)(object)(UltraTextEditor)tNameBox).KeyDown += tNameBox_KeyDown;
                        ((System.Windows.Forms.Control)(object)(UltraTextEditor)tNameBox).KeyPress += tNameBox_KeyPress;
                        ((System.Windows.Forms.Control)(object)(UltraTextEditor)tNameBox).ControlAdded += tNameBoxControlAdd;
                        break;
                }
                ColumnList = columnList;
                ObjectList = objectList;
                _parent = tManager;
            }

            private void tCodeControlAdd(object sender, ControlEventArgs e)
            {
                e.Control.DoubleClick += tCodeBox_DoubleClick;
            }

            private void tNameBoxControlAdd(object sender, ControlEventArgs e)
            {
                e.Control.DoubleClick += tNameBox_DoubleClick;
            }

            private void tNameBox_KeyDown(object sender, KeyEventArgs e)
            {
                textInit(sender);
            }

            private void tCodeBox_KeyDown(object sender, KeyEventArgs e)
            {
                textInit(sender);
            }

            private void tCodeBox_Click(object sender, MouseEventArgs e)
            {
                pop();
            }

            private void SetText(object CodeBox, string sValue)
            {
                string name = CodeBox.GetType().Name;
                switch (name)
                {
                    default:
                        if (!(name == "STextBox"))
                        {
                            return;
                        }
                        break;
                    case "TextBox":
                        ((TextBox)CodeBox).Text = sValue;
                        return;
                    case "SBtnTextEditor":
                        ((System.Windows.Forms.Control)(object)(SBtnTextEditor)CodeBox).Text = sValue;
                        return;
                    case "UltraTextEditor":
                        break;
                }
                ((System.Windows.Forms.Control)(object)(UltraTextEditor)CodeBox).Text = sValue;
            }

            private string GetText(object CodeBox)
            {
                string result = string.Empty;
                switch (CodeBox.GetType().Name)
                {
                    case "TextBox":
                        result = ((TextBox)CodeBox).Text;
                        break;
                    case "SBtnTextEditor":
                        result = ((System.Windows.Forms.Control)(object)(SBtnTextEditor)CodeBox).Text;
                        break;
                    case "UltraTextEditor":
                    case "STextBox":
                        result = ((System.Windows.Forms.Control)(object)(UltraTextEditor)CodeBox).Text;
                        break;
                }
                return result;
            }

            private string GetName(object sType)
            {
                string result = string.Empty;
                switch (sType.GetType().Name)
                {
                    case "TextBox":
                        result = ((TextBox)sType).Name;
                        break;
                    case "SBtnTextEditor":
                        result = ((System.Windows.Forms.Control)(object)(SBtnTextEditor)sType).Name;
                        break;
                    case "UltraTextEditor":
                    case "STextBox":
                        result = ((System.Windows.Forms.Control)(object)(UltraTextEditor)sType).Name;
                        break;
                }
                return result;
            }

            private bool GetBool(object sCode, string sType)
            {
                bool result = false;
                switch (sCode.GetType().Name)
                {
                    case "TextBox":
                        if (sType.Equals("Enabled"))
                        {
                            result = ((TextBox)sCode).Enabled;
                        }
                        if (sType.Equals("ReadOnly"))
                        {
                            result = ((TextBox)sCode).ReadOnly;
                        }
                        break;
                    case "SBtnTextEditor":
                        if (sType.Equals("Enabled"))
                        {
                            result = ((System.Windows.Forms.Control)(object)(SBtnTextEditor)sCode).Enabled;
                        }
                        if (sType.Equals("ReadOnly"))
                        {
                            result = ((SBtnTextEditor)sCode).ReadOnly;
                        }
                        break;
                    case "UltraTextEditor":
                    case "STextBox":
                        if (sType.Equals("Enabled"))
                        {
                            result = ((System.Windows.Forms.Control)(object)(UltraTextEditor)sCode).Enabled;
                        }
                        if (sType.Equals("ReadOnly"))
                        {
                            result = ((UltraTextEditor)sCode).ReadOnly;
                        }
                        break;
                }
                return result;
            }

            private void tCodeBox_DoubleClick(object sender, EventArgs e)
            {
                pop();
            }

            private void tNameBox_DoubleClick(object sender, EventArgs e)
            {
                pop();
            }

            private void tNameBox_MouseDoubleClick(object sender, MouseEventArgs e)
            {
                pop();
            }

            private void tNameBox_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == '\r')
                {
                    pop();
                }
            }

            private void tCodeBox_MouseDoubleClick(object sender, MouseEventArgs e)
            {
                pop();
            }

            private void tCodeBox_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == '\r')
                {
                    pop();
                }
            }

            private void pop()
            {
                if (!IsNotNull())
                {
                    return;
                }
                string text = "";
                object[] array = null;
                if (GetBool(tCodeBox, "ReadOnly") || GetBool(tNameBox, "ReadOnly") || !GetBool(tCodeBox, "Enabled") || !GetBool(tNameBox, "Enabled"))
                {
                    return;
                }
                text = PopUpName;
                array = Param;
                if (text == "")
                {
                    return;
                }
                string text2 = GetText(tCodeBox);
                string text3 = GetText(tNameBox);
                string[] array2 = new string[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == null)
                    {
                        array2[i] = "";
                        continue;
                    }
                    switch (array[i].GetType().ToString())
                    {
                        case "System.Windows.Forms.ComboBox":
                            array2[i] = DBHelper.gGetCode(((ComboBox)array[i]).SelectedValue);
                            break;
                        case "System.Windows.Forms.TextBox":
                            array2[i] = DBHelper.nvlString(((TextBox)array[i]).Text);
                            break;
                        case "Infragistics.Win.UltraWinEditors.UltraTextEditor":
                            array2[i] = DBHelper.nvlString(((System.Windows.Forms.Control)(object)(UltraTextEditor)array[i]).Text);
                            break;
                        case "Infragistics.Win.UltraWinEditors.UltraComboEditor":
                            array2[i] = DBHelper.gGetCode(((UltraComboEditor)array[i]).Value);
                            break;
                        case "Infragistics.Win.UltraWinGrid.UltraCombo":
                            array2[i] = DBHelper.gGetCode(((UltraCombo)array[i]).Value);
                            break;
                        case "WIZ.Control.SCodeNMComboBox":
                            array2[i] = DBHelper.gGetCode(((SCodeNMComboBox)array[i]).Value);
                            break;
                        case "WIZ.Control.SCodeComboBox":
                            array2[i] = DBHelper.gGetCode(((SCodeComboBox)array[i]).Value);
                            break;
                        case "Control.SLabel":
                            array2[i] = ((SLabel)array[i]).Text;
                            break;
                        case "Infragistics.Win.Misc.UltraLabel":
                            array2[i] = ((System.Windows.Forms.Control)(object)(UltraLabel)array[i]).Text;
                            break;
                        case "System.Windows.Forms.Label":
                            array2[i] = ((Label)array[i]).Text;
                            break;
                        case "System.String":
                            array2[i] = (string)array[i];
                            break;
                        default:
                            {
                                // WSRYU 2021-03-11 수정
                                // 팝업처리시 위에 나열된 Control 이 아닌 다른 컨트롤이 들어온다면,
                                System.Windows.Forms.Control c = array[i] as System.Windows.Forms.Control;

                                if (c != null)
                                {
                                    array2[i] = c.Text;
                                }
                                else
                                {
                                    array2[i] = "";
                                }
                                break;
                            }
                    }
                }
                _parent.Bz_Pop(text, tCodeBox, tNameBox, text2, text3, array2, ColumnList, ObjectList);
                if (_parent.ClosePopUpEvent != null)
                {
                    _parent.ClosePopUpEvent(this, new ClosePopUpArgument(tCodeBox, tNameBox));
                }
            }

            private void textInit(object tBox)
            {
                if (IsNotNull())
                {
                    try
                    {
                        if (!GetBool(tCodeBox, "ReadOnly") && !GetBool(tNameBox, "ReadOnly") && GetBool(tCodeBox, "Enabled") && GetBool(tNameBox, "Enabled"))
                        {
                            if (GetName(tBox) == GetName(tCodeBox))
                            {
                                SetText(tNameBox, "");
                                if (_parent.InitTextBoxEvent != null)
                                {
                                    _parent.InitTextBoxEvent(this, new InitTextBoxArgument(tNameBox));
                                }
                            }
                            else
                            {
                                SetText(tCodeBox, "");
                                if (_parent.InitTextBoxEvent != null)
                                {
                                    _parent.InitTextBoxEvent(this, new InitTextBoxArgument(tCodeBox));
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            private bool IsNotNull()
            {
                return tCodeBox != null && tNameBox != null;
            }
        }

        private List<PopUpClass> ListPopUpClass = null;

        public event ClosePopUpHandler ClosePopUpEvent;

        public event InitTextBoxHandler InitTextBoxEvent;

        public void PopUpClear()
        {
            ListPopUpClass.Clear();
        }

        public virtual void Bz_Pop(string sFunctionName, object tCodeBox, object tNameBox, string sValueCode, string sValueName, string[] aParam, string[] ColumnList, object[] ObjectList)
        {
        }

        public bool PopUpAdd(object codeBox, object nameBox, string sPopUpFunction, object[] param, string[] columnList = null, object[] objectList = null)
        {
            foreach (PopUpClass item2 in ListPopUpClass)
            {
                if (GetName(item2.tCodeBox) == GetName(codeBox) || GetName(item2.tNameBox) == GetName(nameBox))
                {
                    return false;
                }
            }
            PopUpClass item = new PopUpClass(this, codeBox, nameBox, sPopUpFunction, param, columnList, objectList);
            ListPopUpClass.Add(item);
            return true;
        }

        private string GetName(object sType)
        {
            string result = string.Empty;
            switch (sType.GetType().Name)
            {
                case "TextBox":
                    result = ((TextBox)sType).Name;
                    break;
                case "SBtnTextEditor":
                    result = ((System.Windows.Forms.Control)(object)(SBtnTextEditor)sType).Name;
                    break;
                case "UltraTextEditor":
                case "STextBox":
                    result = ((System.Windows.Forms.Control)(object)(UltraTextEditor)sType).Name;
                    break;
            }
            return result;
        }

        public bool PopUpRemove(object codeBox)
        {
            PopUpClass popUpClass = null;
            for (int i = 0; i < ListPopUpClass.Count; i++)
            {
                if (GetName(ListPopUpClass[i].tCodeBox) == GetName(codeBox))
                {
                    popUpClass = ListPopUpClass[i];
                    break;
                }
            }
            if (popUpClass == null)
            {
                return false;
            }
            ListPopUpClass.Remove(popUpClass);
            return true;
        }

        public BizTextBoxManagerBase()
        {
            ListPopUpClass = new List<PopUpClass>();
        }

        private PopUpClass getPopUpClass(string sKey)
        {
            foreach (PopUpClass item in ListPopUpClass)
            {
                if (GetName(item.tCodeBox) == sKey || GetName(item.tNameBox) == sKey)
                {
                    return item;
                }
            }
            return null;
        }
    }
}

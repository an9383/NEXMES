using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WIZ.Forms;

namespace WIZ.PopManager
{
    public class BizGridManagerBase
    {
        private class PopUpClass
        {
            public string Code;

            public string Name;

            public string PopUpName;

            public string[] Param;

            public string[] Param2;

            public string[] Param3;

            public PopUpClass(string sCode, string sName, string sPopUpFunction, string[] param, string[] param2 = null, string[] param3 = null)
            {
                Code = sCode;
                Name = sName;
                PopUpName = sPopUpFunction;
                Param = param;
                Param2 = param2;
                Param3 = param3;
            }
        }

        private WIZ.Control.Grid _grid;

        private bool bPOP = false;

        private List<PopUpClass> ListPopUpClass = null;

        public WIZ.Control.Grid grid => _grid;

        public void PopUpClear()
        {
            ListPopUpClass.Clear();
        }

        public bool PopUpAdd(string sCode, string sName, string sPopUpFunction, string[] param, string[] param2 = null, string[] param3 = null)
        {
            foreach (PopUpClass item2 in ListPopUpClass)
            {
                if (item2.Code == sCode || item2.Name == sName)
                {
                    return false;
                }
            }
            PopUpClass item = new PopUpClass(sCode, sName, sPopUpFunction, param, param2, param3);
            ListPopUpClass.Add(item);
            if (grid != null)
            {
                grid.PopUpColumnListAdd(sCode);
                grid.PopUpColumnListAdd(sName);
            }
            return true;
        }

        public bool PopUpRemove(string sCode)
        {
            PopUpClass popUpClass = null;
            for (int i = 0; i < ListPopUpClass.Count; i++)
            {
                if (ListPopUpClass[i].Code == sCode)
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

        public BizGridManagerBase()
        {
        }

        public BizGridManagerBase(WIZ.Control.Grid grid0)
        {
            init(grid0);
        }

        protected void init(WIZ.Control.Grid grid0)
        {
            _grid = grid0;
            grid.ClickCellButton += grid_ClickCellButton;
            grid.DoubleClickCell += grid_DoubleClickCell;
            grid.KeyPressed += grid_KeyPressed;
            grid.CellChange += grid_CellChange;
            ListPopUpClass = new List<PopUpClass>();
        }

        private void grid_CellChange(object sender, CellEventArgs e)
        {
            bool flag = false;
            if (grid != null && grid.ActiveRow != null && grid.ActiveCell != null)
            {
                try
                {
                    string key = grid.ActiveCell.Column.Key;
                    PopUpClass popUpClass = getPopUpClass(key);
                    if (popUpClass != null)
                    {
                        string key2 = (key == popUpClass.Code.ToUpper()) ? popUpClass.Name.ToUpper() : popUpClass.Code.ToUpper();
                        if (grid.ActiveRow.Cells[key2].IgnoreRowColActivation)
                        {
                            if (grid.ActiveRow.Cells[key2].Activation == Activation.AllowEdit)
                            {
                                flag = true;
                            }
                        }
                        else if (grid.Columns[key2].CellActivation == Activation.AllowEdit)
                        {
                            grid.ActiveRow.Cells[key2].Value = string.Empty;
                            flag = true;
                        }
                        try
                        {
                            if (flag && popUpClass.Param2.Length >= popUpClass.Param3.Length)
                            {
                                for (int i = 0; i < popUpClass.Param3.Length; i++)
                                {
                                    if (popUpClass.Param3[i] == "Y")
                                    {
                                        string text = "";
                                        string[] array = popUpClass.Param2[i].Split('|');
                                        text = array[0];
                                        grid.ActiveRow.Cells[text].Value = string.Empty;
                                    }
                                }
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            DialogForm dialogForm = new DialogForm("C:S00017", DialogForm.DialogType.OK);
                        }
                        catch (Exception ex2)
                        {
                            throw ex2;
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void grid_KeyDowned(WIZ.Control.Grid sender, KeyEventArgs e)
        {
            bool flag = false;
            if (grid != null && grid.ActiveRow != null && grid.ActiveCell != null)
            {
                try
                {
                    string key = grid.ActiveCell.Column.Key;
                    PopUpClass popUpClass = getPopUpClass(key);
                    if (popUpClass != null)
                    {
                        string key2 = (key == popUpClass.Code) ? popUpClass.Name : popUpClass.Code;
                        if (grid.ActiveRow.Cells[key2].IgnoreRowColActivation)
                        {
                            if (grid.ActiveRow.Cells[key2].Activation == Activation.AllowEdit)
                            {
                                grid.ActiveRow.Cells[key2].Value = string.Empty;
                                flag = true;
                            }
                        }
                        else if (grid.Columns[key2].CellActivation == Activation.AllowEdit)
                        {
                            grid.ActiveRow.Cells[key2].Value = string.Empty;
                            flag = true;
                        }
                        try
                        {
                            if (flag && popUpClass.Param2.Length >= popUpClass.Param3.Length)
                            {
                                for (int i = 0; i < popUpClass.Param3.Length; i++)
                                {
                                    if (popUpClass.Param3[i] == "Y")
                                    {
                                        string text = "";
                                        string[] array = popUpClass.Param2[i].Split('|');
                                        text = array[0];
                                        grid.ActiveRow.Cells[text].Value = string.Empty;
                                    }
                                }
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            DialogForm dialogForm = new DialogForm("C:S00017", DialogForm.DialogType.OK);
                        }
                        catch (Exception ex2)
                        {
                            throw ex2;
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void grid_KeyPressed(WIZ.Control.Grid sender, KeyPressEventArgs e)
        {
            if (grid.ActiveRow != null && grid.ActiveCell != null && e.KeyChar == '\r')
            {
                grid_Popup();
            }
        }

        private void grid_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            if (grid.ActiveRow != null && grid.ActiveCell != null)
            {
                grid_Popup();
            }
        }

        private void grid_ClickCellButton(object sender, CellEventArgs e)
        {
            if (grid.ActiveRow != null && grid.ActiveCell != null)
            {
                bPOP = true;
                grid_Popup();
                bPOP = false;
            }
        }

        public void grid_Popup(string sKey = "")
        {
            if (grid == null || grid.ActiveRow == null)
            {
                return;
            }
            if (sKey == "")
            {
                sKey = grid.ActiveCell.Column.Key;
            }
            sKey = sKey.ToUpper();
            string text = "";
            string text2 = "";
            string text3 = "";
            string[] array = null;
            string[] array2 = null;
            PopUpClass popUpClass = getPopUpClass(sKey);
            if (popUpClass == null || grid.ActiveRow.Activation != 0)
            {
                return;
            }
            if (grid.ActiveRow.Cells[popUpClass.Code].IgnoreRowColActivation)
            {
                if (grid.ActiveRow.Cells[popUpClass.Code].Activation != 0)
                {
                    return;
                }
            }
            else if (grid.Columns[popUpClass.Code].CellActivation != 0)
            {
                return;
            }
            text = popUpClass.Code;
            text2 = popUpClass.Name;
            text3 = popUpClass.PopUpName;
            array = popUpClass.Param;
            if (text3 == "")
            {
                return;
            }
            string sValueCode = DBHelper.nvlString(grid.ActiveRow.Cells[text].Text);
            string sValueName = "";
            try
            {
                if (!grid.ActiveRow.Cells[text2].Hidden && grid.ActiveRow.Cells[text2].IsInEditMode)
                {
                    sValueName = DBHelper.nvlString(grid.ActiveRow.Cells[text2].Text);
                }
            }
            catch
            {
            }
            string[] array3 = new string[array.Length];
            if (text3 == "BM0000")
            {
                array3[0] = array[0];
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (grid.Columns.Exists(array[i]))
                    {
                        array3[i] = DBHelper.gGetCode(grid.ActiveRow.Cells[array[i]].Text);
                    }
                    else
                    {
                        array3[i] = array[i];
                    }
                }
            }
            array2 = popUpClass.Param2;
            if (bPOP)
            {
                getPopupGrid(text3, text, text2, "", "", array3, array2);
            }
            else
            {
                getPopupGrid(text3, text, text2, sValueCode, sValueName, array3, array2);
            }
            grid.ActiveRow.Update();
        }

        public virtual void getPopupGrid(string sFunctionName, string sCode, string sName, string sValueCode, string sValueName, string[] aParam1, string[] sParam2)
        {
        }

        private PopUpClass getPopUpClass(string sKey)
        {
            foreach (PopUpClass item in ListPopUpClass)
            {
                if (item.Code.ToUpper() == sKey || item.Name.ToUpper() == sKey)
                {
                    return item;
                }
            }
            return null;
        }
    }
}

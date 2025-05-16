using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinStatusBar;
using Infragistics.Win.UltraWinTabControl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;
using WIZ.Control;

namespace WIZ.Forms
{
    public class FormInfor
    {
        public Hashtable FormFunction = new Hashtable();

        public int _nTopicID = 0;

        private string getFormInforText = "USP_ZGETPROGRAMINFOR_S";

        public string SystemID = string.Empty;

        public string ProgramID = string.Empty;

        public string ProgramName = string.Empty;

        public string Lang = string.Empty;

        public string PopupColor = string.Empty;

        private Configuration appConfig;

        private bool binit = false;

        private int textpos = -1;

        private ArrayList arrText = new ArrayList();

        public FormInfor(string formid, string formname, string lang, string popup)
        {
            ProgramID = formid;
            Lang = lang;
            appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            SystemID = CModule.GetAppSetting("SystemID", "NexMES");
            PopupColor = CModule.GetAppSetting("POPUPCOLOR", "");
        }

        public FormInfor(string userid, string formid, string lang)
        {
            try
            {
                ProgramID = formid;
                Lang = lang;
                appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                SystemID = CModule.GetAppSetting("SYSTEMID", "NexMES");
                PopupColor = CModule.GetAppSetting("POPUPCOLOR", "");
                DBHelper dBHelper = new DBHelper();
                if (dBHelper.ConType == "OracleConnection")
                {
                    DbDataReader dbDataReader = dBHelper.ExecuteReader(getFormInforText, CommandType.StoredProcedure, dBHelper.CreateParameter("userid", DbType.String, userid), dBHelper.CreateParameter("formid", DbType.String, formid));
                    dbDataReader.Read();
                    FormFunction.Add("InqFunc", Convert.ToBoolean(dbDataReader["InqFlag"]));
                    FormFunction.Add("NewFunc", Convert.ToBoolean(dbDataReader["NewFlag"]));
                    FormFunction.Add("DelFunc", Convert.ToBoolean(dbDataReader["DelFlag"]));
                    FormFunction.Add("SaveFunc", Convert.ToBoolean(dbDataReader["SaveFlag"]));
                    FormFunction.Add("ExcelFunc", Convert.ToBoolean(dbDataReader["ExcelFlag"]));
                    FormFunction.Add("PrintFunc", Convert.ToBoolean(dbDataReader["PrnFlag"]));
                    FormFunction.Add("FilterFunc", Convert.ToBoolean(dbDataReader["InqFlag"]));
                    FormFunction.Add("SumFunc", Convert.ToBoolean(dbDataReader["InqFlag"]));
                    _nTopicID = DBHelper.nvlInt(dbDataReader["TopicID"]);
                    dbDataReader.Close();
                }
                else
                {
                    DataTable dataTable = dBHelper.FillTable(getFormInforText, CommandType.StoredProcedure, dBHelper.CreateParameter("userid", DbType.String, userid), dBHelper.CreateParameter("formid", DbType.String, formid));
                    FormFunction.Add("InqFunc", Convert.ToBoolean(dataTable.Rows[0]["InqFlag"]));
                    FormFunction.Add("NewFunc", Convert.ToBoolean(dataTable.Rows[0]["NewFlag"]));
                    FormFunction.Add("DelFunc", Convert.ToBoolean(dataTable.Rows[0]["DelFlag"]));
                    FormFunction.Add("SaveFunc", Convert.ToBoolean(dataTable.Rows[0]["SaveFlag"]));
                    FormFunction.Add("ExcelFunc", Convert.ToBoolean(dataTable.Rows[0]["ExcelFlag"]));
                    FormFunction.Add("PrintFunc", Convert.ToBoolean(dataTable.Rows[0]["PrnFlag"]));
                    FormFunction.Add("FilterFunc", Convert.ToBoolean(dataTable.Rows[0]["InqFlag"]));
                    FormFunction.Add("SumFunc", Convert.ToBoolean(dataTable.Rows[0]["InqFlag"]));
                    FormFunction.Add("ExeImFunc", Convert.ToBoolean(dataTable.Rows[0]["ExeImFlag"]));
                    _nTopicID = DBHelper.nvlInt(dataTable.Rows[0]["TopicID"]);
                }
            }
            catch
            {
            }
        }

        public string GetMessage(string msgcode)
        {
            return "";
        }

        public string GetProgramName(string formid, string lang)
        {
            return "";
        }

        public void ManageForm(Form form)
        {
            SetControl(form, Common.Lang);
            binit = true;
        }

        public void SetControl(Form form, string lang)
        {
            textpos = -1;
            SetControlText(form);
        }

        public void SetControl(UserControl form, string lang)
        {
            textpos = -1;
            SetControlText(form);
        }

        private UserControl SetControlText(UserControl control)
        {
            foreach (System.Windows.Forms.Control control2 in control.Controls)
            {
                try
                {
                    switch (control2.GetType().Name)
                    {
                        case "SLabel":
                        case "UltraLabel":
                        case "UltraButton":
                        case "UltraGroupBox":
                        case "UltraCheckEditor":
                        case "RadioButton":
                        case "ToolStripButton":
                        case "ToolStripLabel":
                        case "SBtnTextEditor":
                        case "GroupBox":
                        case "Button":
                            try
                            {
                                string text = control2.Text;
                                if (!binit)
                                {
                                    arrText.Add(control2.Text);
                                }
                                textpos++;
                                control2.Text = Common.getLangText(arrText[textpos].ToString());
                                if (Common.FontName != "")
                                {
                                    control2.Font = new Font(Common.FontName, control2.Font.Size, control2.Font.Style);
                                }
                            }
                            catch
                            {
                            }
                            break;
                        case "UltraTabPageControl":
                            if (!binit)
                            {
                                arrText.Add(((UltraTabPageControl)control2).Tab.Text);
                            }
                            textpos++;
                            ((UltraTabPageControl)control2).Tab.Text = Common.getLangText(arrText[textpos].ToString());
                            if (Common.FontName != "")
                            {
                                ((UltraTabPageControl)control2).Tab.Appearance.FontData.Name = Common.FontName;
                            }
                            break;
                        case "ToolStrip":
                            {
                                for (int j = 0; j < ((ToolStrip)control2).Items.Count; j++)
                                {
                                    if (!binit)
                                    {
                                        arrText.Add(((ToolStrip)control2).Items[j].Text);
                                    }
                                    textpos++;
                                    ((ToolStrip)control2).Items[j].Text = Common.getLangText(arrText[textpos].ToString());
                                    ((ToolStrip)control2).Items[j].Font = new Font(Common.FontName, ((ToolStrip)control2).Items[j].Font.Size, ((ToolStrip)control2).Items[j].Font.Style);
                                }
                                break;
                            }
                        case "UltraTree":
                        case "MenuStrip":
                        case "BaseMDIChildForm":
                        case "MdiClient":
                        case "UltraPanel":
                        case "ComboBox":
                        case "UltraPanelClientAreaUnsafe":
                        case "UnpinnedTabArea":
                        case "Grid":
                        case "Grid1":
                        case "Grid2":
                        case "Grid3":
                        case "SCodeNMComboBox":
                        case "UltraComboEditor":
                            if (Common.FontName != "")
                            {
                                control2.Font = new Font(Common.FontName, control2.Font.Size, control2.Font.Style);
                            }
                            if (Common.bPlantAuth && control2.Name.ToUpper().IndexOf("PLANTCODE") >= 0 && !DBHelper.nvlString(LoginInfo.PlantCode).Equals(""))
                            {
                                int num = 0;
                                switch (control2.GetType().Name)
                                {
                                    case "SCodeNMComboBox":
                                        ((SCodeNMComboBox)control2).DefaultValue = LoginInfo.PlantCode;
                                        break;
                                    case "UltraComboEditor":
                                        ((UltraComboEditor)control2).Value = LoginInfo.PlantCode;
                                        break;
                                    case "ComboBox":
                                        foreach (KeyValuePair<string, string> item in ((ComboBox)control2).Items)
                                        {
                                            if (item.Key == LoginInfo.PlantCode)
                                            {
                                                ((ComboBox)control2).SelectedIndex = num;
                                                break;
                                            }
                                            num++;
                                        }
                                        break;
                                }
                            }
                            if (control2.GetType().Name.ToUpper().IndexOf("GRID") >= 0 && ((WIZ.Control.Grid)control2).ListPopupColumn != null)
                            {
                                foreach (string item2 in ((WIZ.Control.Grid)control2).ListPopupColumn)
                                {
                                    for (int i = 0; i < ((WIZ.Control.Grid)control2).DisplayLayout.Bands[0].Columns.Count; i++)
                                    {
                                        if (item2.ToUpper().Equals(((WIZ.Control.Grid)control2).DisplayLayout.Bands[0].Columns[i].Key.ToUpper()))
                                        {
                                            ((WIZ.Control.Grid)control2).DisplayLayout.Bands[0].Columns[i].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
                                            ((WIZ.Control.Grid)control2).DisplayLayout.Bands[0].Columns[i].CellAppearance.ForeColor = Common.FromStringToColor(PopupColor);
                                            break;
                                        }
                                    }
                                }
                            }
                            break;
                    }
                }
                catch (Exception)
                {
                }
                if (control2.Parent.GetType().Name != "MdiClient")
                {
                    SetControlText(control2);
                }
            }
            return null;
        }

        private System.Windows.Forms.Control SetControlText(System.Windows.Forms.Control control)
        {
            foreach (System.Windows.Forms.Control control2 in control.Controls)
            {
                try
                {
                    switch (control2.GetType().Name)
                    {
                        case "UltraStatusBar":
                            if (Common.FontName != "")
                            {
                                ((UltraStatusBar)control2).Appearance.FontData.Name = Common.FontName;
                            }
                            break;
                        case "UltraLabel":
                            if (!binit)
                            {
                                arrText.Add(control2.Text);
                            }
                            textpos++;
                            control2.Text = Common.getLangText(arrText[textpos].ToString());
                            if (Common.FontName != "")
                            {
                                ((UltraLabel)control2).Appearance.FontData.Name = Common.FontName;
                            }
                            break;
                        case "UltraButton":
                            if (!binit)
                            {
                                arrText.Add(control2.Text);
                            }
                            textpos++;
                            control2.Text = Common.getLangText(arrText[textpos].ToString());
                            if (Common.FontName != "")
                            {
                                ((UltraButton)control2).Appearance.FontData.Name = Common.FontName;
                            }
                            break;
                        case "SLabel":
                        case "UltraGroupBox":
                        case "UltraCheckEditor":
                        case "RadioButton":
                        case "ToolStripButton":
                        case "ToolStripLabel":
                        case "SBtnTextEditor":
                        case "GroupBox":
                        case "Button":
                            try
                            {
                                if (!binit)
                                {
                                    arrText.Add(control2.Text);
                                }
                                textpos++;
                                control2.Text = Common.getLangText(arrText[textpos].ToString());
                                if (Common.FontName != "")
                                {
                                    control2.Font = new Font(Common.FontName, control2.Font.Size, control2.Font.Style);
                                }
                            }
                            catch
                            {
                            }
                            break;
                        case "UltraTabPageControl":
                            if (!binit)
                            {
                                arrText.Add(((UltraTabPageControl)control2).Tab.Text);
                            }
                            textpos++;
                            ((UltraTabPageControl)control2).Tab.Text = Common.getLangText(arrText[textpos].ToString());
                            if (Common.FontName != "")
                            {
                                ((UltraTabPageControl)control2).Tab.Appearance.FontData.Name = Common.FontName;
                            }
                            break;
                        case "ToolStrip":
                            {
                                for (int j = 0; j < ((ToolStrip)control2).Items.Count; j++)
                                {
                                    if (!binit)
                                    {
                                        arrText.Add(((ToolStrip)control2).Items[j].Text);
                                    }
                                    textpos++;
                                    ((ToolStrip)control2).Items[j].Text = Common.getLangText(arrText[textpos].ToString());
                                    ((ToolStrip)control2).Items[j].Font = new Font(Common.FontName, ((ToolStrip)control2).Items[j].Font.Size, ((ToolStrip)control2).Items[j].Font.Style);
                                }
                                break;
                            }
                        case "UltraTree":
                        case "MenuStrip":
                        case "BaseMDIChildForm":
                        case "MdiClient":
                        case "UltraPanel":
                        case "ComboBox":
                        case "UltraPanelClientAreaUnsafe":
                        case "UnpinnedTabArea":
                        case "Grid":
                        case "Grid1":
                        case "Grid2":
                        case "Grid3":
                        case "SCodeNMComboBox":
                        case "UltraComboEditor":
                            if (Common.FontName != "")
                            {
                                control2.Font = new Font(Common.FontName, control2.Font.Size, control2.Font.Style);
                            }
                            if (Common.bPlantAuth && control2.Name.ToUpper().IndexOf("PLANTCODE") >= 0 && !DBHelper.nvlString(LoginInfo.PlantCode).Equals(""))
                            {
                                int num = 0;
                                switch (control2.GetType().Name)
                                {
                                    case "SCodeNMComboBox":
                                        ((SCodeNMComboBox)control2).DefaultValue = LoginInfo.PlantCode;
                                        break;
                                    case "UltraComboEditor":
                                        ((UltraComboEditor)control2).Value = LoginInfo.PlantCode;
                                        break;
                                    case "ComboBox":
                                        foreach (KeyValuePair<string, string> item in ((ComboBox)control2).Items)
                                        {
                                            if (item.Key == LoginInfo.PlantCode)
                                            {
                                                ((ComboBox)control2).SelectedIndex = num;
                                                break;
                                            }
                                            num++;
                                        }
                                        break;
                                }
                            }
                            if (control2.GetType().Name.ToUpper().IndexOf("GRID") >= 0 && ((WIZ.Control.Grid)control2).ListPopupColumn != null)
                            {
                                foreach (string item2 in ((WIZ.Control.Grid)control2).ListPopupColumn)
                                {
                                    for (int i = 0; i < ((WIZ.Control.Grid)control2).DisplayLayout.Bands[0].Columns.Count; i++)
                                    {
                                        if (item2.ToUpper().Equals(((WIZ.Control.Grid)control2).DisplayLayout.Bands[0].Columns[i].Key.ToUpper()))
                                        {
                                            ((WIZ.Control.Grid)control2).DisplayLayout.Bands[0].Columns[i].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
                                            ((WIZ.Control.Grid)control2).DisplayLayout.Bands[0].Columns[i].CellAppearance.ForeColor = Common.FromStringToColor(PopupColor);
                                            break;
                                        }
                                    }
                                }
                            }
                            break;
                    }
                }
                catch (Exception)
                {
                }
                if (control2.Parent.GetType().Name != "MdiClient")
                {
                    SetControlText(control2);
                }
            }
            return null;
        }
    }
}

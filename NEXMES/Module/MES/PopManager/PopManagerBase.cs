using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace WIZ.PopManager
{
    public class PopManagerBase
    {
        public virtual DataTable OpenPopUp(string strPopUpName, string[] param)
        {
            return null;
        }

        public DataTable OpenPopupShow(string formAssembly, string FrmName, string formCaption, string[] param)
        {
            string text = null;
            text = formAssembly + "." + FrmName;
            string assemblyFile = Application.StartupPath + "\\" + formAssembly + ".dll";
            Assembly assembly = Assembly.LoadFrom(assemblyFile);
            Type type = assembly.GetType(text);
            Form form = (Form)Activator.CreateInstance(type, new object[1]
            {
                param
            });

            SetInit(form);

            form.ShowDialog();

            return (DataTable)form.Tag;
        }

        /// <summary>
        /// // form 을 생성한 뒤 추가 작업 처리 - 초기값 지정 ( PLANTCODE, USEFLAG )
        /// </summary>
        /// <param name="form"></param>
        private void SetInit(Form form)
        {
            List<KeyValuePair<string, string>> kList = new List<KeyValuePair<string, string>>();
            kList.Add(new KeyValuePair<string, string>("PLANTCODE", WIZ.LoginInfo.PlantCode));
            kList.Add(new KeyValuePair<string, string>("USEFLAG", "Y"));

            foreach (KeyValuePair<string, string> k in kList)
            {
                List<System.Windows.Forms.Control> co = Common.FindControlList(form, k.Key);

                foreach (System.Windows.Forms.Control c in co)
                {
                    switch (c.GetType().Name.ToUpper())
                    {
                        case "STEXTBOX":
                        case "TEXTBOX":
                            {
                                c.Text = k.Value;
                            }
                            break;
                        case "ULTRACOMBOEDITOR":
                            {
                                Infragistics.Win.UltraWinEditors.UltraComboEditor e = c as Infragistics.Win.UltraWinEditors.UltraComboEditor;

                                if (e != null)
                                {
                                    if (e.Items.Count > 0)
                                    {
                                        e.Value = k.Value;
                                    }
                                }
                            }
                            break;
                        case "COMBOBOX":
                            {
                                ComboBox e = c as ComboBox;

                                if (e != null)
                                {
                                    if (e.Items.Count > 0)
                                    {
                                        e.SelectedValue = k.Value;
                                    }
                                }
                            }
                            break;

                    }
                }
            }
        }
    }
}

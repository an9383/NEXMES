using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WIZ.ETC
{
    public class ETC_Common
    {
        public static clsControlLinkCollection ControlLinkCollection = new clsControlLinkCollection();

        /// <summary>
        /// 이벤트를 발생할 때 해당 컨트럴의 데이터가 자동으로 변경됨.
        /// </summary>
        /// <param name="sForm">현재 SetLink 를 호출하는 폼</param>
        /// <param name="con">이벤트 발생시 내용이 변경되는 컨트럴</param>
        /// <param name="conList">이벤트를 발생시키는 컨트럴 리스트</param>
        /// <param name="sSQLName">이벤트 발생시 조회하는 쿼리 이름</param>
        public static void SetLink(Form sForm, System.Windows.Forms.Control con, System.Windows.Forms.Control[] conList, string sSQLName)
        {
            clsControlLink c = ControlLinkCollection[sForm.Name, con.Name];

            if (c != null)
            {
                return;
            }

            c = new clsControlLink(con, conList, sSQLName);
            ControlLinkCollection.Add(sForm.Name, c);

            c.setLink();

            return;
        }

        #region classArgu
        /// <summary>
        /// SQL 쿼리에서 각 Where 문에 대한 개별 조건을 저장하는 클래스
        /// </summary>
        public class classArgu
        {
            private int _seq;
            private string _query;
            private System.Windows.Forms.Control _linkControl;

            public int Seq
            {
                get { return _seq; }
                set { _seq = value; }
            }

            public string Query
            {
                get { return _query; }
                set { _query = value; }
            }

            public System.Windows.Forms.Control LinkControl
            {
                get { return _linkControl; }
                set { _linkControl = value; }
            }

            public classArgu(int iSeq, string query, System.Windows.Forms.Control con = null)
            {
                _seq = iSeq;
                _query = query;
                _linkControl = con;
            }
        }

        /// <summary>
        /// classArgu 모음
        /// </summary>
        public class classArguCollection : System.Collections.ObjectModel.Collection<classArgu>
        {
            public classArgu this[string sSeq]
            {
                get
                {
                    int iSeq = CModule.ToInt32(sSeq);

                    foreach (classArgu c in this)
                    {
                        if (c.Seq == iSeq)
                        {
                            return c;
                        }
                    }

                    classArgu ca = new classArgu(iSeq, "", null);
                    this.Add(ca);

                    return ca;
                }
            }
        }
        #endregion

        #region 데이터 처리 저장용
        /// <summary>
        /// 컨트럴 이벤트 발생시 조회 쿼리 변경에 따른 처리를 지원하는 클래스
        /// </summary>
        public class clsControlLink
        {
            public string sFormName;
            public System.Windows.Forms.Control control;
            public List<System.Windows.Forms.Control> controlList;
            public string QueryID;

            public clsControlLink(System.Windows.Forms.Control con, System.Windows.Forms.Control[] cList, string sQueryID)
            {
                control = con;
                controlList = new List<System.Windows.Forms.Control>();
                controlList.AddRange(cList);
                this.QueryID = sQueryID;
            }

            public string ControlName
            {
                get
                {
                    if (control != null)
                        return control.Name;
                    else return null;
                }
            }

            public void setLink()
            {
                foreach (System.Windows.Forms.Control c in controlList)
                {
                    if (c.Name != control.Name)
                    {
                        c.Tag = control;
                        switch (c.GetType().Name.ToUpper())
                        {
                            case "STEXTBOX":
                            case "TEXTBOX":
                            case "MASKEDTEXTBOX":
                                {
                                    c.TextChanged += TextBox_TextChanged;
                                }
                                break;
                            case "SBTNTEXTDEITOR":
                                {
                                    WIZ.Control.SBtnTextEditor e = c as WIZ.Control.SBtnTextEditor;
                                    if (e != null)
                                    {
                                        e.ValueChanged += SBtnTextEditor_ValueChanged;
                                    }
                                }
                                break;
                            case "ULTRACOMBOEDITOR":
                                {
                                    Infragistics.Win.UltraWinEditors.UltraComboEditor e = c as Infragistics.Win.UltraWinEditors.UltraComboEditor;

                                    if (e != null)
                                    {
                                        e.AfterCloseUp += UltraCombo_AfterCloseUp;
                                    }
                                }
                                break;
                            case "COMBOBOX":
                                {
                                    ComboBox e = c as ComboBox;

                                    if (e != null)
                                    {
                                        e.DropDownClosed += ComboBox_DropDownClosed;
                                    }
                                }
                                break;
                        }
                    }
                }
            }

            private void ComboBox_DropDownClosed(object sender, EventArgs e)
            {
                ComboBox c = sender as ComboBox;

                if (c != null)
                {
                    System.Windows.Forms.Control con = c.Tag as System.Windows.Forms.Control;
                    switch (con.GetType().Name.ToUpper())
                    {
                        case "ULTRACOMBOEDITOR":
                            Infragistics.Win.UltraWinEditors.UltraComboEditor ucb = con as Infragistics.Win.UltraWinEditors.UltraComboEditor;
                            //WIZ.Common.FillComboboxMaster(ucb, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, null, null);
                            break;
                        case "COMBOBOX":
                            ComboBox cb = con as ComboBox;
                            //cb.Items.Clear();
                            //cb.Items.AddRange();
                            break;
                    }
                }
            }
            private void UltraCombo_AfterCloseUp(object sender, EventArgs e)
            {
                Infragistics.Win.UltraWinEditors.UltraComboEditor c = sender as Infragistics.Win.UltraWinEditors.UltraComboEditor;

                if (c != null)
                {
                }
            }

            private void TextBox_TextChanged(object sender, EventArgs e)
            {
                TextBox c = sender as TextBox;
                if (c != null)
                {
                }
            }

            private void SBtnTextEditor_ValueChanged(object sender, EventArgs e)
            {
                WIZ.Control.SBtnTextEditor c = sender as WIZ.Control.SBtnTextEditor;
                if (c != null)
                {
                }
            }

            private DataTable GetData()
            {
                //QueryID = DBHelper.nvlString(QueryID);

                //DBHelper helper = new DBHelper(false);

                DataTable rtnDtTemp = null; // = helper.FillTable("USP_POP_BM5050_S1", CommandType.StoredProcedure
                                            //                        , helper.CreateParameter("QueryID", QueryID, DbType.String, ParameterDirection.Input));


                StringBuilder stringBuilder = null;
                DBHelper dBHelper = new DBHelper(false);
                try
                {
                    stringBuilder = new StringBuilder();
                    stringBuilder.Remove(0, stringBuilder.Length);
                    if (QueryID != "") // && dBHelper.ConType == "OracleConnection")
                    {
                        stringBuilder.AppendLine(" SELECT   Text AS TEXT ");
                        stringBuilder.AppendLine(" FROM     BM4500 ");
                        stringBuilder.AppendLine(" WHERE    QueryID = '" + QueryID + "' ");
                        rtnDtTemp = dBHelper.FillTable(Convert.ToString(stringBuilder));
                    }
                    //return rtnDtTemp;
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    dBHelper.Close();
                }



                string query = rtnDtTemp.Rows[0]["TEXT"].ToString();
                //for (int i = 0; i < controlList.Length; i++)
                //{
                //    query.Replace("@" + i, "'" + controlList[i].Text + "'");
                //}

                try
                {
                    if (QueryID != "") // && dBHelper.ConType == "OracleConnection")
                    {
                        rtnDtTemp = dBHelper.FillTable(query);
                    }
                    //return rtnDtTemp;
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    dBHelper.Close();
                }

                return null;
            }
        }

        /// <summary>
        /// 컨트럴 이벤트 발생시 조회 쿼리 변경에 따른 처리를 지원하는 클래스 모음
        /// </summary>
        public class clsControlLinkCollection : System.Collections.ObjectModel.Collection<clsControlLink>
        {
            public clsControlLink this[string sFormName, string sControlName]
            {
                get
                {
                    foreach (clsControlLink c in this)
                    {
                        if (c.sFormName == sFormName)
                        {
                            if (c.ControlName != null)
                            {
                                if (c.ControlName == sControlName)
                                {
                                    return c;
                                }
                            }
                        }
                    }

                    return null;
                }
            }

            public void Add(string sFormName, clsControlLink c)
            {
                c.sFormName = sFormName;
                this.Add(c);
            }

            //public void SetLink()
            //{
            //    foreach (clsControlLink c in this)
            //    {
            //        c.SetLink();
            //    }
            //}
        }
        #endregion
    }
}

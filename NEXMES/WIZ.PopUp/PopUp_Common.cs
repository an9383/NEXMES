using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WIZ.PopUp
{
    public class PopUp_Common
    {
        public static PopList popList = new PopList();
        //private static System.Windows.Forms.Control[] controls;
        //private static classArguCollection ArguCollection = new classArguCollection();
        private static ClsControlLink clsControlLink = null;
        private static UltraGridUtil _GridUtil = new UltraGridUtil(); //그리드 객체 생성

        /// <summary>
        /// 이벤트를 발생할 때 해당 컨트럴의 데이터가 자동으로 변경됨.
        /// </summary>
        /// <param name="sForm">현재 SetLink 를 호출하는 폼</param>
        /// <param name="con">이벤트 발생시 내용이 변경되는 컨트럴</param>
        /// <param name="conList">이벤트를 발생시키는 컨트럴 리스트</param>
        /// <param name="sSQLName">이벤트 발생시 조회하는 쿼리 이름</param>
        public static void SetLink(Form sForm, System.Windows.Forms.Control con, System.Windows.Forms.Control[] conList, string sSQLName)
        {
            clsControlLink = new ClsControlLink(sForm.Name, con, conList, sSQLName);

            clsControlLink.setLink();
            clsControlLink.SetData(clsControlLink.control);

            return;
        }

        /// <summary>
        /// 화면별로 팝업에 컨트롤을 유동적으로 배치하여 사용할 수 있는 메소드
        /// </summary>
        /// <param name="SendCons">이전 폼에서 값을 넘길 컨트롤 리스트, 해당 컨트롤의 버튼을 누르면 지정한 팝업이 뜨게 되고 이 컨트롤 리스트에서 팝업에 생성되는 컨트롤으로 값도 넘길 수 있다</param>
        /// <param name="QueryID">팝업 아이디, 첫번째 매개변수안 SendCons 내의 컨트롤에서 버튼을 클릭할 경우 팝업 아이디에 해당하는 팝업이 띄워진다</param>
        /// <param name="RcvCons">팝업에서 데이터 선택 후 값을 받을 컨트롤 리스트, 팝업에서 데이터를 선택하면 팝업이 닫기며 이 리스트 내의 컨트롤로 값을 넘겨받게 된다</param>
        public static void SetPop(object[] SendCons, string QueryID, object[] RcvCons = null, PopUp_Common.ClassPop.delePopupCloseMethod dele = null)
        {
            if (RcvCons == null)
            {
                RcvCons = SendCons;
            }

            ClassPop pop = new ClassPop(SendCons, QueryID, RcvCons, dele);
            popList.Add(pop);
        }

        public static object[] GetQuery(string QueryID, string FormID)
        {
            DataTable rtnDtTemp = null;
            DataTable dt = null;

            string sQuery = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            DBHelper dbHelper = new DBHelper(false);
            classArguCollection argus = new classArguCollection();

            try
            {
                if (QueryID != "")
                {
                    // 기본 쿼리 가져오기
                    stringBuilder.AppendLine(" SELECT   Text AS TEXT ");
                    stringBuilder.AppendLine(" FROM     BM4500 ");
                    stringBuilder.AppendLine(" WHERE    QueryID = '" + QueryID + "' ");
                    rtnDtTemp = dbHelper.FillTable(stringBuilder.ToString());
                    sQuery = CModule.ToString(rtnDtTemp.Rows[0]["TEXT"]);
                    sQuery = sQuery.Replace(Environment.NewLine, " ");
                    sQuery = sQuery.Replace("\t", " ");

                    stringBuilder = new StringBuilder();


                    stringBuilder.AppendLine("select *" + Environment.NewLine);
                    stringBuilder.AppendLine("from" + Environment.NewLine);
                    stringBuilder.AppendLine("  (" + Environment.NewLine);
                    stringBuilder.AppendLine("select RANK() over(ORDER BY RAN desc) as RAN1, " + Environment.NewLine);
                    stringBuilder.AppendLine("   *" + Environment.NewLine);
                    stringBuilder.AppendLine("  from" + Environment.NewLine);
                    stringBuilder.AppendLine("  (" + Environment.NewLine);

                    // 디테일 쿼리 가져오기
                    stringBuilder.AppendLine(" SELECT       A.ParamName AS PARAMNAME, A.DetailText AS DETAILTEXT " + Environment.NewLine);
                    stringBuilder.AppendLine("              , A.ControlID AS CONTROLID, B.CODENAME AS CONTROLTYPE " + Environment.NewLine);
                    stringBuilder.AppendLine("              , A.LabelText AS LABELTEXT, A.OrderSeq AS ORDERSEQ " + Environment.NewLine);
                    stringBuilder.AppendLine("              , A.DefaultValue AS DEFAULTVALUE, A.SearchSeq AS SEARCHSEQ " + Environment.NewLine);
                    stringBuilder.AppendLine("              , A.ComboData AS COMBODATA, C.CODENAME AS TEXTTYPE" + Environment.NewLine +
                                             "              , A.LinkSeqList AS LinkSeqList " + Environment.NewLine);
                    stringBuilder.AppendLine("			  , case when A.FormID = '' then 'A' else 'B' end as RAN" + Environment.NewLine);
                    stringBuilder.AppendLine(" FROM         BM4505 A " + Environment.NewLine);
                    stringBuilder.AppendLine(" LEFT JOIN    (SELECT * " + Environment.NewLine +
                                             "                 FROM BM0000 " + Environment.NewLine +
                                             "                WHERE MAJORCODE = 'CONTROLTYPE') B ON A.ControlType = B.MINORCODE " + Environment.NewLine);
                    stringBuilder.AppendLine(" LEFT JOIN    (SELECT * " + Environment.NewLine +
                                             "                 FROM BM0000 " + Environment.NewLine +
                                             "                WHERE MAJORCODE = 'POPARGUTYPE') C ON A.TextType = C.MINORCODE " + Environment.NewLine);
                    stringBuilder.AppendLine(" WHERE        A.QueryID = '" + QueryID + "' " + Environment.NewLine);
                    stringBuilder.AppendLine(" AND          ( A.FormID = '" + FormID + "' or A.FormID = ''  )" + Environment.NewLine);
                    //stringBuilder.AppendLine(" AND          B.MAJORCODE = 'CONTROLTYPE' ");
                    //stringBuilder.AppendLine(" AND          c.MAJORCODE = 'POPARGUTYPE' ");


                    stringBuilder.AppendLine(") A" + Environment.NewLine);
                    stringBuilder.AppendLine(") a" + Environment.NewLine);
                    stringBuilder.AppendLine("where RAN1 = 1" + Environment.NewLine);


                    stringBuilder.AppendLine(" ORDER BY     A.OrderSeq " + Environment.NewLine);

                    dt = dbHelper.FillTable(stringBuilder.ToString());

                    // ArguCollection 비우기
                    //ArguCollection.Clear();

                    // ArguCollection에 조회한 데이터 채우기
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        int seq = CModule.ToInt32(dr["ORDERSEQ"]);
                        string param = CModule.ToString(dr["PARAMNAME"]);
                        string controlID = CModule.ToString(dr["CONTROLID"]);
                        string controlType = CModule.ToString(dr["CONTROLTYPE"]);
                        string query = " " + CModule.ToString(dr["TEXTTYPE"]) + " " + CModule.ToString(dr["DETAILTEXT"]);
                        string labelText = CModule.ToString(dr["LABELTEXT"]);
                        string defaultValue = CModule.ToString(dr["DEFAULTVALUE"]);
                        string searchseq = CModule.ToString(dr["SEARCHSEQ"]);
                        string combodata = CModule.ToString(dr["COMBODATA"]);
                        string linkseqlist = CModule.ToString(dr["LINKSEQLIST"]);
                        System.Windows.Forms.Control con = null;

                        //if(controlType != "")
                        //{
                        switch (controlType.ToUpper())
                        {
                            default:
                                con = new System.Windows.Forms.Control();
                                break;
                            case "STEXTBOX":
                                con = new WIZ.Control.STextBox();
                                break;
                            case "TEXTBOX":
                                con = new TextBox();
                                break;
                            case "MASKEDTEXTBOX":
                                con = new MaskedTextBox();
                                break;
                            case "SBTNTEXTEDITOR":
                                con = new WIZ.Control.SBtnTextEditor();
                                break;
                            case "ULTRACOMBOEDITOR":
                                con = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
                                break;
                            case "COMBOBOX":
                                con = new ComboBox();
                                break;
                        }

                        con.Name = controlID;
                        //}

                        //if(controlType != "")
                        //{
                        //}

                        classArgu ca = new classArgu(seq, param, query, labelText, defaultValue, searchseq, combodata, linkseqlist, con);
                        argus.Add(ca);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                dbHelper.Close();
            }

            return new object[] { sQuery, argus };
        }

        public static DataTable ExecuteQuery(string sQuery, classArguCollection classArgus, System.Windows.Forms.Control[] cons = null)
        {
            const string STR_W = "WHERE";
            const string STR_G = "GROUP BY";
            const string STR_O = "ORDER BY";
            DataTable rtnDtTemp = null;

            DBHelper dbHelper = new DBHelper(false);

            try
            {
                string sValue;                          // @@ 자리에 들어갈 값
                string sParam;                          // 쿼리가 대신 들어갈 자리
                string sDefault;                        // 지정한 디폴트값
                string sDetailQuery;                    // 디테일 쿼리
                System.Windows.Forms.Control con;       // 연결된 컨트롤

                foreach (classArgu ca in classArgus)
                {
                    sParam = ca.Param;
                    sDefault = ca.Default;
                    sDetailQuery = ca.Query;
                    con = ca.LinkControl;

                    // 연결된 컨트롤이 없을 때
                    if (con == null)
                    {
                        // 지정된 디폴트 값이 없으면 조회조건 삭제
                        if (sDefault == "")
                        {
                            sQuery = sQuery.Replace(ca.Param, "");
                            continue;
                        }
                        // 지정된 디폴트 값이 ''이면 빈 문자열 삽입
                        else if (sDefault == "''")
                        {
                            sValue = string.Empty;
                        }
                        // 지정된 디폴트 값이 있으면 디폴트값 삽입
                        else
                        {
                            sValue = sDefault;
                        }
                    }
                    // 연결된 컨트롤이 있을 때
                    else
                    {
                        if (cons == null)
                        {
                            switch (con.GetType().Name.ToUpper())
                            {
                                default:
                                    sValue = "";
                                    break;
                                case "STEXTBOX":
                                case "TEXTBOX":
                                case "MASKEDTEXTBOX":
                                case "SBTNTEXTEDITOR":
                                    sValue = con.Text;
                                    break;
                                case "ULTRACOMBOEDITOR":
                                    Infragistics.Win.UltraWinEditors.UltraComboEditor ucb = con as Infragistics.Win.UltraWinEditors.UltraComboEditor;
                                    sValue = CModule.ToString(ucb.Value);
                                    break;
                                case "COMBOBOX":
                                    ComboBox cb = con as ComboBox;
                                    sValue = CModule.ToString(cb.SelectedValue);
                                    break;
                            }
                        }
                        else
                        {
                            sValue = "";
                            foreach (System.Windows.Forms.Control c in cons)
                            {
                                if (con.Name == c.Name)
                                {
                                    switch (c.GetType().Name.ToUpper())
                                    {
                                        default:
                                            sValue = "";
                                            break;
                                        case "STEXTBOX":
                                        case "TEXTBOX":
                                        case "MASKEDTEXTBOX":
                                        case "SBTNTEXTEDITOR":
                                            sValue = c.Text;
                                            break;
                                        case "ULTRACOMBOEDITOR":
                                            Infragistics.Win.UltraWinEditors.UltraComboEditor ucb = c as Infragistics.Win.UltraWinEditors.UltraComboEditor;
                                            sValue = CModule.ToString(ucb.Value);
                                            break;
                                        case "COMBOBOX":
                                            ComboBox cb = c as ComboBox;
                                            sValue = CModule.ToString(cb.SelectedValue);
                                            break;
                                    }
                                }
                            }
                        }
                    }

                    // WHERE가 있으면 AND로 바꿔서 삽입
                    if (sDetailQuery.Contains(STR_W) && sQuery.Contains(STR_W))
                    {
                        sDetailQuery = sDetailQuery.Replace(STR_W, "AND");
                    }
                    // GROUP BY가 있으면 ,로 바꿔서 삽입
                    else if (sDetailQuery.Contains(STR_G) && sQuery.Contains(STR_G))
                    {
                        sDetailQuery = sDetailQuery.Replace(STR_G, ",");
                    }
                    // ORDER BY가 있으면 ,로 바꿔서 삽입
                    else if (sDetailQuery.Contains(STR_O) && sQuery.Contains(STR_O))
                    {
                        sDetailQuery = sDetailQuery.Replace(STR_O, ",");
                    }

                    // @@를 컨트롤의 값으로 변경
                    sDetailQuery = sDetailQuery.Replace("@@", sValue);
                    // 대체문자를 조회조건으로 변경
                    sQuery = sQuery.Replace(sParam, sDetailQuery);
                }

                sQuery = RemoveBlinkParam(sQuery);


                rtnDtTemp = dbHelper.FillTable(sQuery);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                dbHelper.Close();
            }

            return rtnDtTemp;
        }

        private static string RemoveBlinkParam(string sQuery)
        {
            string sItem = "";
            string sObj = "";

            while (true)
            {
                sObj = "";

                if (sQuery.Length == 0) break;

                char c = sQuery[0];

                sQuery = RemoveFirstChar(sQuery);

                sObj += c;

                if (c == '@')
                {
                    sObj = "";

                    while (true)
                    {
                        if (sQuery.Length == 0) break;

                        c = sQuery[0];

                        sQuery = RemoveFirstChar(sQuery);

                        if (!(c >= '0' && c <= '9'))
                        {
                            break;
                        }
                    }
                }
                else
                {
                    sItem += sObj;
                }
            }

            return sItem;
        }

        private static string RemoveFirstChar(string s, int iCount = 1)
        {
            if (s.Length == 0 || s.Length == iCount)
                return "";

            return s.Substring(iCount, s.Length - iCount);
        }

        #region classArgu
        /// <summary>
        /// SQL 쿼리에서 각 Where 문에 대한 개별 조건을 저장하는 클래스
        /// </summary>
        public class classArgu
        {
            private int _seq;
            private string _param;
            private string _query;
            private string _labeltext;
            private string _default;
            private string _searchseq;
            private string _combodata;
            private string _linkseqlist;
            private System.Windows.Forms.Control _linkControl;

            public int Seq
            {
                get { return _seq; }
                set { _seq = value; }
            }

            public string Param
            {
                get { return _param; }
                set { _param = value; }
            }

            public string Query
            {
                get { return _query; }
                set { _query = value; }
            }

            public string LabelText
            {
                get { return _labeltext; }
                set { _labeltext = value; }
            }

            public string Default
            {
                get { return _default; }
                set { _default = value; }
            }

            public string SearchSeq
            {
                get { return _searchseq; }
                set { _searchseq = value; }
            }

            public string ComboData
            {
                get { return _combodata; }
                set { _combodata = value; }
            }

            public string LinkSeqList
            {
                get { return _linkseqlist; }
                set { _linkseqlist = value; }
            }

            public System.Windows.Forms.Control LinkControl
            {
                get { return _linkControl; }
                set { _linkControl = value; }
            }

            public classArgu(int iSeq, string param, string query, string labeltext, string defaultValue,
                                string searchseq, string combodata, string linkseqlist, System.Windows.Forms.Control con = null)
            {
                _seq = iSeq;
                _param = param;
                _query = query;
                _labeltext = labeltext;
                _default = defaultValue;
                _searchseq = searchseq;
                _combodata = combodata;
                _linkseqlist = linkseqlist;
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

                    classArgu ca = new classArgu(iSeq, "", "", "", "", "", "", null);
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
        public class ClsControlLink
        {
            public string sFormName;
            public System.Windows.Forms.Control control;
            public List<System.Windows.Forms.Control> controlList;
            public string QueryID;
            public classArguCollection arguList;

            public ClsControlLink(string formName, System.Windows.Forms.Control con, System.Windows.Forms.Control[] cList, string sQueryID)
            {
                sFormName = formName;
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
                //arguList = ArguCollection;
                foreach (System.Windows.Forms.Control c in controlList)
                {
                    if (c != null)
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
                                        c.Leave += TextBox_Leave;
                                    }
                                    break;
                                case "SBTNTEXTEDITOR":
                                    {
                                        WIZ.Control.SBtnTextEditor e = c as WIZ.Control.SBtnTextEditor;
                                        if (e != null)
                                        {
                                            e.Leave += SBtnTextEditor_Leave;
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
            }

            private void ComboBox_DropDownClosed(object sender, EventArgs e)
            {
                ComboBox c = sender as ComboBox;

                if (c != null)
                {
                    System.Windows.Forms.Control con = c.Tag as System.Windows.Forms.Control;
                    if (con != null)
                    {
                        SetData(con);
                    }
                }
            }
            private void UltraCombo_AfterCloseUp(object sender, EventArgs e)
            {
                Infragistics.Win.UltraWinEditors.UltraComboEditor c = sender as Infragistics.Win.UltraWinEditors.UltraComboEditor;

                if (c != null)
                {
                    System.Windows.Forms.Control con = c.Tag as System.Windows.Forms.Control;
                    if (con != null)
                    {
                        SetData(con);
                    }

                }
            }

            private void TextBox_Leave(object sender, EventArgs e)
            {
                System.Windows.Forms.Control c = sender as System.Windows.Forms.Control;
                if (c != null)
                {
                    System.Windows.Forms.Control con = c.Tag as System.Windows.Forms.Control;
                    if (con != null)
                    {
                        SetData(con);
                    }
                }
            }

            private void SBtnTextEditor_Leave(object sender, EventArgs e)
            {
                WIZ.Control.SBtnTextEditor c = sender as WIZ.Control.SBtnTextEditor;
                if (c != null)
                {
                    System.Windows.Forms.Control con = c.Tag as System.Windows.Forms.Control;
                    if (con != null)
                    {
                        SetData(con);
                    }
                }
            }

            public void SetData(System.Windows.Forms.Control c)
            {
                string type = c.GetType().Name.ToUpper();

                if (type != "ULTRACOMBOEDITOR" && type != "COMBOBOX")
                {
                    return;
                }

                DataTable rtnDtTemp = null;    // 쿼리를 실행하여 가져올 내용

                object[] objs = GetQuery(QueryID, sFormName);
                string sQuery = CModule.ToString(objs[0]);
                arguList = objs[1] as classArguCollection;

                if (sQuery == null)
                {
                    return;
                }

                sQuery = sQuery.Replace(Environment.NewLine, " ");
                sQuery = sQuery.Replace("\t", " ");

                //arguList = ArguCollection;

                // 콤보박스? 뭐가 될진 모르겠지만..

                rtnDtTemp = ExecuteQuery(sQuery, arguList, controlList.ToArray());

                if (rtnDtTemp != null)
                {
                    switch (type)
                    {
                        case "ULTRACOMBOEDITOR":
                            Infragistics.Win.UltraWinEditors.UltraComboEditor ucb = c as Infragistics.Win.UltraWinEditors.UltraComboEditor;
                            WIZ.Common.FillComboboxMaster(ucb, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", null);
                            break;
                        case "COMBOBOX":
                            ComboBox cb = c as ComboBox;
                            WIZ.Common.FillComboboxMaster(cb, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", null);
                            break;
                    }
                }
            }
        }

        public class ClassPop : WIZ.Forms.BasePopupForm
        {
            private string sQuery;

            private string title;

            private object[] SendCons;
            //private string[] SendColList;
            private string _QueryID;
            private string _FormID;
            private object[] RcvCons;
            //private string[] RcvColList;

            private Infragistics.Win.Misc.UltraButton btn;
            private WIZ.Control.Grid grid;

            private Infragistics.Win.UltraWinGrid.CellEventArgs _activeCell;

            private TableLayoutPanel tlp;
            public Form form;

            private classArguCollection argus;

            public delegate void delePopupCloseMethod(UltraGrid grid, UltraGridRow udr, Infragistics.Win.UltraWinGrid.CellEventArgs e);

            public delePopupCloseMethod PopupClosed;

            public string QueryID
            {
                get { return _QueryID; }
            }

            public string FormID
            {
                get { return _FormID; }
            }

            //public ClassPop(object[] SendCons, string[] SendColList, string QueryID, string FormID, object[] RcvCons, string[] RcvColList)
            //{
            //    InitializeComponent();

            //    this.SendCons = SendCons;
            //    //this.SendColList = SendColList;
            //    this._QueryID = QueryID;
            //    this._FormID = FormID;
            //    this.RcvCons = RcvCons;
            //    //this.RcvColList = RcvColList;


            //    foreach(object obj in SendCons)
            //    {
            //        switch(obj.GetType().Name.ToUpper())
            //        {
            //            case "TEXTBOX":
            //                ((TextBox)obj).KeyDown += textBox_KeyDown;
            //                ((TextBox)obj).MouseDoubleClick += textBox_MouseDoubleClick;
            //                break;
            //            case "SBTNTEXTEDITOR":
            //                ((System.Windows.Forms.Control)(object)(WIZ.Control.SBtnTextEditor)obj).KeyDown += textBox_KeyDown;
            //                ((System.Windows.Forms.Control)(object)((WIZ.Control.SBtnTextEditor)obj).Button).MouseClick += textBox_Click;
            //                break;
            //            case "ULTRATEXTEDITOR":
            //            case "STEXTBOX":
            //                ((System.Windows.Forms.Control)(object)(Infragistics.Win.UltraWinEditors.UltraTextEditor)obj).KeyDown += textBox_KeyDown;
            //                ((System.Windows.Forms.Control)(object)(Infragistics.Win.UltraWinEditors.UltraTextEditor)obj).ControlAdded += textBox_ControlAdded;
            //                ((System.Windows.Forms.Control)(object)(Infragistics.Win.UltraWinEditors.UltraTextEditor)obj).DoubleClick += textBox_MouseDoubleClick;
            //                break;
            //            case "GRID":
            //                WIZ.Control.Grid tempGrid = obj as WIZ.Control.Grid;
            //                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in tempGrid.Columns)
            //                {
            //                    foreach(string colName in SendColList)
            //                    {
            //                        if(col.Key == colName)
            //                        {
            //                            tempGrid.PopUpColumnListAdd(colName);
            //                            //col.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            //                        }
            //                    }
            //                }
            //                tempGrid.ClickCellButton += Grid_ClickCellButton;
            //                break;
            //        }
            //    }
            //}

            public ClassPop(object[] SendCons, string QueryID, object[] RcvCons, delePopupCloseMethod dele)
            {
                InitializeComponent();

                this.SendCons = SendCons;
                this._QueryID = QueryID;
                this.RcvCons = RcvCons;

                SetEvent();
                GetTitle();

                PopupClosed = dele;
                _activeCell = null;

                System.Windows.Forms.Control con = (SendCons[0] as System.Windows.Forms.Control).Parent;

                if (con != null)
                {
                    while (!(con is Form))
                    {
                        if (con.Parent == null) break;

                        con = con.Parent;
                    }

                    if (con != null)
                    {
                        this.form = con as Form;
                        this._FormID = con.Name;

                        Forms.BaseMDIChildForm b = this.form as Forms.BaseMDIChildForm;

                        if (b != null)
                        {
                            if (!b.bSetPupClosed)
                            {
                                b.bSetPupClosed = true;
                                this.form.FormClosed += Form_FormClosed;
                            }
                        }
                    }
                }
            }
            private void Form_FormClosed(object sender, FormClosedEventArgs e)
            {
                popList.CloseForm(this._FormID);
            }

            private void ClassPop_Load(object sender, EventArgs e)
            {
                object[] objs = GetQuery(_QueryID, _FormID);
                sQuery = CModule.ToString(objs[0]);
                argus = objs[1] as classArguCollection;

                grid.DataSource = new DataTable();
                grid.DataBinds();

                int xMax = 0;
                int yMax = 0;
                int x = 0;
                int y = 0;

                tlp.Controls.Clear();
                tlp.ColumnStyles.Clear();
                tlp.RowStyles.Clear();

                WIZ.Control.Grid gr = SendCons[0] as WIZ.Control.Grid;

                for (int i = 0; i < argus.Count; i++)
                {
                    classArgu ca = argus[i];
                    // 테이블 레이아웃 사이즈 지정을 위한 x, y 최댓값 찾기
                    if (ca.SearchSeq.Contains(","))
                    {
                        string[] seq = ca.SearchSeq.Trim().Split(new char[] { ',' });
                        x = CModule.ToInt32(seq[0]);
                        y = CModule.ToInt32(seq[1]);

                        if (x > xMax)
                        {
                            xMax = x;
                        }
                        if (y > yMax)
                        {
                            yMax = y;
                        }
                    }
                    // 컨트롤 위에 라벨을 넣기 위해 로우카운트 2배
                    tlp.RowCount = (xMax + 1) * 2;
                    tlp.ColumnCount = yMax + 1;

                    tlp.Controls.Add(ca.LinkControl, y, (x * 2) + 1);
                    //switch (ca.LinkControl.GetType().Name.ToUpper())
                    //{
                    //    case "ULTRACOMBOEDITOR":
                    //        Infragistics.Win.UltraWinEditors.UltraComboEditor ucb = ca.LinkControl as Infragistics.Win.UltraWinEditors.UltraComboEditor;
                    //        ca.LinkControl = ucb;
                    //        break;
                    //    case "COMBOBOX":
                    //        break;
                    //}

                    if (ca.ComboData != "")
                    {
                        List<System.Windows.Forms.Control> cons = new List<System.Windows.Forms.Control>();
                        string[] seqs = ca.LinkSeqList.Trim().Split(new char[] { ',' });
                        foreach (string seq in seqs)
                        {
                            foreach (classArgu argu in argus)
                            {
                                if (ca != argu)
                                {
                                    if (argu.Seq == CModule.ToInt32(seq))
                                    {
                                        argu.LinkControl.Tag = ca.LinkControl;
                                        cons.Add(argu.LinkControl);
                                        break;
                                    }
                                }
                            }
                        }

                        System.Windows.Forms.Control[] conList = cons.ToArray<System.Windows.Forms.Control>();

                        if (conList.Length != 0)
                        {
                            SetLink(form, ca.LinkControl, conList, ca.ComboData);
                        }
                        else
                        {
                            clsControlLink = new ClsControlLink(form.Name, ca.LinkControl, conList, ca.ComboData);
                            clsControlLink.SetData(ca.LinkControl);
                        }
                    }

                    // 이전 폼에서 값을 넘길 컨트롤과 이름을 비교하여 이름이 같으면 값을 넘김
                    System.Windows.Forms.Control c;
                    string value = "";

                    if (gr != null)
                    {
                        if (ca.LinkControl != null && ca.LinkControl.Name == gr.Name)
                        {
                            if (gr.ActiveRow != null)
                            {
                                string colName = CModule.ToString(SendCons[i + 1]);
                                value = CModule.ToString(gr.ActiveRow.Cells[colName].Value);

                                switch (ca.LinkControl.GetType().Name.ToUpper())
                                {
                                    default:
                                    case "STEXTBOX":
                                    case "TEXTBOX":
                                    case "MASKEDTEXTBOX":
                                    case "SBTNTEXTEDITOR":
                                        ca.LinkControl.Text = value;
                                        ca.LinkControl.KeyDown += textBox_KeyDown_PopUp;
                                        break;
                                    case "ULTRACOMBOEDITOR":
                                        Infragistics.Win.UltraWinEditors.UltraComboEditor ucb = ca.LinkControl as Infragistics.Win.UltraWinEditors.UltraComboEditor;

                                        for (int j = 0; j < ucb.Items.Count; j++)
                                        {
                                            if (Convert.ToString(ucb.Items[j].DataValue) == value)
                                            {
                                                ucb.SelectedIndex = j;
                                                break;
                                            }
                                        }
                                        ucb.AfterCloseUp += combobox_AfterDropDown;
                                        break;
                                    case "COMBOBOX":
                                        ComboBox cb = ca.LinkControl as ComboBox;
                                        cb.SelectedValue = value;
                                        cb.DropDownClosed += combobox_AfterDropDown;
                                        break;
                                }
                            }
                        }
                    }


                    else
                    {
                        foreach (object o in SendCons)
                        {
                            c = o as System.Windows.Forms.Control;
                            if (ca.LinkControl != null && ca.LinkControl.Name == c.Name)
                            {
                                switch (c.GetType().Name.ToUpper())
                                {
                                    default:
                                        value = "";
                                        break;
                                    case "STEXTBOX":
                                    case "TEXTBOX":
                                    case "MASKEDTEXTBOX":
                                    case "SBTNTEXTEDITOR":
                                        value = c.Text;
                                        break;
                                    case "ULTRACOMBOEDITOR":
                                        Infragistics.Win.UltraWinEditors.UltraComboEditor ucb = c as Infragistics.Win.UltraWinEditors.UltraComboEditor;
                                        value = CModule.ToString(ucb.Value);
                                        break;
                                    case "COMBOBOX":
                                        ComboBox cb = c as ComboBox;
                                        value = CModule.ToString(cb.SelectedValue);
                                        break;
                                }

                                switch (ca.LinkControl.GetType().Name.ToUpper())
                                {
                                    default:
                                    case "STEXTBOX":
                                    case "TEXTBOX":
                                    case "MASKEDTEXTBOX":
                                    case "SBTNTEXTEDITOR":
                                        ca.LinkControl.Text = value;
                                        ca.LinkControl.KeyDown += textBox_KeyDown_PopUp;
                                        break;
                                    case "ULTRACOMBOEDITOR":
                                        Infragistics.Win.UltraWinEditors.UltraComboEditor ucb = ca.LinkControl as Infragistics.Win.UltraWinEditors.UltraComboEditor;
                                        ucb.Value = value;
                                        ucb.AfterCloseUp += combobox_AfterDropDown;
                                        break;
                                    case "COMBOBOX":
                                        ComboBox cb = ca.LinkControl as ComboBox;
                                        cb.SelectedValue = value;
                                        cb.DropDownClosed += combobox_AfterDropDown;
                                        break;
                                }
                            }
                        }
                    }

                    // 라벨  추가
                    Infragistics.Win.Misc.UltraLabel lb = new Infragistics.Win.Misc.UltraLabel();
                    lb.AutoSize = false;
                    lb.Text = ca.LabelText;
                    lb.Size = new System.Drawing.Size(144, 26);
                    tlp.Controls.Add(lb, y, x * 2);

                    // 컨트롤 추가
                    ca.LinkControl.Name = ca.LabelText;
                    ca.LinkControl.AutoSize = false;
                    ca.LinkControl.Size = new System.Drawing.Size(160, 27);
                    ca.LinkControl.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));

                }

                // 내부 컨트롤의 크기에 맞게 테이블 레이아웃 크기 조절
                int height;
                for (int i = 0; i < tlp.RowCount; i++)
                {
                    if (i % 2 == 0)      // 라벨 
                    {
                        height = 22;
                    }
                    else                // 컨트롤
                    {
                        height = 38;
                    }
                    tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, height));
                }

                for (int i = 0; i < tlp.ColumnCount; i++)
                {
                    tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Absolute, 200));
                }

                this.Size = new System.Drawing.Size(170 + 200 * tlp.ColumnCount, 540);
                this.Text = title;

                tlp.Size = new System.Drawing.Size(200 * tlp.ColumnCount, 30 * tlp.RowCount);

                btn.Size = new System.Drawing.Size(110, 30 * tlp.RowCount);
                btn.Location = new System.Drawing.Point(200 * tlp.ColumnCount + 20, 20);

                grid.Location = new System.Drawing.Point(10, 50 + 30 * tlp.RowCount);
                grid.Size = new System.Drawing.Size(this.Width - 20, this.Height - grid.Location.Y - 40);
                grid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                _GridUtil.InitializeGrid(grid, false, false, true, "", false);
                _GridUtil.SetInitUltraGridBind(grid);

                Search();
            }


            private void GetTitle()
            {
                DBHelper helper = new DBHelper(false);
                StringBuilder stringBuilder = new StringBuilder();

                try
                {
                    stringBuilder.AppendLine(" SELECT Title AS TITLE ");
                    stringBuilder.AppendLine("   FROM BM4500 ");
                    stringBuilder.AppendLine("  WHERE QueryID = '" + _QueryID + "' ");

                    DataTable dt = helper.FillTable(stringBuilder.ToString());
                    title = CModule.ToString(dt.Rows[0]["TITLE"]);
                }
                catch (Exception)
                {
                    title = "POP-UP";
                }
                finally
                {
                    helper.Close();
                }
            }

            private void SetEvent()
            {
                if (SendCons != null && SendCons.Length != 0)
                {
                    if (SendCons[0].GetType().Name.ToUpper() == "GRID")
                    {
                        WIZ.Control.Grid tempGrid = SendCons[0] as WIZ.Control.Grid;
                        for (int i = 1; i < SendCons.Length; i++)
                        {
                            string colName = CModule.ToString(SendCons[i]);
                            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in tempGrid.Columns)
                            {
                                if (col.Key == colName)
                                {
                                    tempGrid.PopUpColumnListAdd(colName);
                                    col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                                    col.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnMouseEnter;
                                }
                            }
                        }
                        tempGrid.ClickCellButton += Grid_ClickCellButton;
                        return;
                    }

                    foreach (object obj in SendCons)
                    {
                        switch (obj.GetType().Name.ToUpper())
                        {
                            case "TEXTBOX":
                                ((TextBox)obj).KeyDown += textBox_KeyDown;
                                ((TextBox)obj).DoubleClick += textBox_MouseDoubleClick;
                                break;
                            case "SBTNTEXTEDITOR":
                                ((WIZ.Control.SBtnTextEditor)obj).KeyDown += textBox_KeyDown;
                                ((WIZ.Control.SBtnTextEditor)obj).Button.Click += textBox_Click;
                                break;
                            case "ULTRATEXTEDITOR":
                                ((Infragistics.Win.UltraWinEditors.UltraTextEditor)obj).KeyDown += textBox_KeyDown;
                                //((Infragistics.Win.UltraWinEditors.UltraTextEditor)obj).ControlAdded += textBox_ControlAdded;
                                ((Infragistics.Win.UltraWinEditors.UltraTextEditor)obj).DoubleClick += textBox_MouseDoubleClick;
                                break;
                            case "STEXTBOX":
                                ((WIZ.Control.STextBox)obj).KeyDown += textBox_KeyDown;
                                //((Infragistics.Win.UltraWinEditors.UltraTextEditor)obj).ControlAdded += textBox_ControlAdded;
                                ((WIZ.Control.STextBox)obj).DoubleClick += textBox_MouseDoubleClick;
                                break;
                        }
                    }
                }
            }

            private void SelectData(object grid)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow ugr = (grid as Infragistics.Win.UltraWinGrid.UltraGrid).ActiveRow;
                if (ugr == null) return;

                if (RcvCons[0] is WIZ.Control.Grid)
                {
                    WIZ.Control.Grid tempGrid = RcvCons[0] as WIZ.Control.Grid;
                    if (tempGrid != null && tempGrid.ActiveRow != null)
                    {
                        string colName;
                        for (int i = 1; i < RcvCons.Length; i++)
                        {
                            colName = CModule.ToString(RcvCons[i]);
                            if (!tempGrid.Columns.Exists(colName))
                                break;
                            tempGrid.ActiveRow.Cells[colName].Value = ugr.Cells[i - 1].Value;
                        }
                    }
                }
                else
                {
                    System.Windows.Forms.Control con;
                    for (int i = 0; i < RcvCons.Length; i++)
                    {
                        con = RcvCons[i] as System.Windows.Forms.Control;
                        switch (con.GetType().Name.ToUpper())
                        {
                            case "TEXTBOX":
                            case "SBTNTEXTEDITOR":
                            case "ULTRATEXTEDITOR":
                            case "STEXTBOX":
                                con.Text = CModule.ToString(ugr.Cells[i].Value);
                                break;
                            case "ULTRACOMBOEDITOR":
                                Infragistics.Win.UltraWinEditors.UltraComboEditor ucb = con as Infragistics.Win.UltraWinEditors.UltraComboEditor;
                                ucb.Value = CModule.ToString(ugr.Cells[i].Value);
                                break;
                            case "COMBOBOX":
                                ComboBox cb = con as ComboBox;
                                cb.SelectedValue = CModule.ToString(ugr.Cells[i].Value);
                                break;
                        }
                    }
                }

                if (PopupClosed != null)
                {
                    PopupClosed((UltraGrid)grid, ugr, _activeCell);
                }
                this.Close();
            }

            private void Search()
            {
                DataTable dt = ExecuteQuery(sQuery, argus);
                if (dt == null) return;
                grid.DataSource = dt;
                grid.DataBinds(dt);

                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ugc in grid.Columns)
                {
                    ugc.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }
            }

            private void button_Click(object sender, EventArgs e)
            {
                Search();
            }

            private void Grid_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
            {
                SelectData(sender);
            }

            private void textBox_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.ShowDialog();
                }
            }

            private void textBox_MouseDoubleClick(object sender, EventArgs e)
            {
                this.ShowDialog();
            }

            private void textBox_ControlAdded(object sender, EventArgs e)
            {
                this.ShowDialog();
            }

            private void textBox_Click(object sender, EventArgs e)
            {
                this.ShowDialog();
            }

            private void Grid_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
            {
                WIZ.Control.Grid tempGrid = sender as WIZ.Control.Grid;
                if (tempGrid.ActiveRow != null && tempGrid.ActiveCell != null)
                {
                    _activeCell = e;
                    this.ShowDialog();
                }
            }

            private void combobox_AfterDropDown(object sender, EventArgs e)
            {
                Search();
                //switch(sender.GetType().Name.ToUpper())
                //{
                //    case "ULTRACOMBOEDITOR":
                //        break;
                //    case "COMBOBOX":
                //        break;
                //}
            }

            private void textBox_KeyDown_PopUp(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //Infragistics.Win.UltraWinEditors.UltraComboEditor ucb = argus[0].LinkControl as Infragistics.Win.UltraWinEditors.UltraComboEditor;
                    //TextBox tb = sender as TextBox;
                    //ucb.Value = tb.Text;
                    Search();
                }
            }

            private void InitializeComponent()
            {
                // 내부 컨트롤의 크기에 맞게 테이블 레이아웃 크기 조절
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                this.StartPosition = FormStartPosition.CenterScreen;
                this.AutoSize = false;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Text = "POP-UP";
                this.Load += ClassPop_Load;

                // 테이블 레이아웃 추가
                tlp = new TableLayoutPanel();
                tlp.Location = new System.Drawing.Point(20, 20);
                tlp.RowCount = 2;
                tlp.ColumnCount = 1;
                this.Controls.Add(tlp);

                // 조회 버튼 추가
                btn = new Infragistics.Win.Misc.UltraButton();
                btn.Font = new System.Drawing.Font("맑은 고딕", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                btn.AutoSize = false;
                btn.Text = "조회";
                btn.Size = new System.Drawing.Size(110, 30 * tlp.RowCount);
                btn.Location = new System.Drawing.Point(200 * tlp.ColumnCount + 20, 20);
                btn.Click += button_Click;
                this.Controls.Add(btn);

                // 그리드 추가
                grid = new WIZ.Control.Grid();
                grid.Location = new System.Drawing.Point(10, 50 + 30 * tlp.RowCount);
                grid.Size = new System.Drawing.Size(this.Width - 30, this.Height - grid.Location.Y - 30);
                grid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                grid.AutoResizeColumn = true;
                grid.AutoUserColumn = true;
                grid.ContextMenuCopyEnabled = true;
                grid.ContextMenuDeleteEnabled = true;
                grid.ContextMenuExcelEnabled = true;
                grid.ContextMenuInsertEnabled = true;
                grid.ContextMenuPasteEnabled = true;
                grid.DeleteButtonEnable = true;
                grid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                grid.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
                grid.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
                grid.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                grid.DisplayLayout.GroupByBox.Hidden = true;
                grid.DisplayLayout.MaxColScrollRegions = 1;
                grid.DisplayLayout.MaxRowScrollRegions = 1;
                grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
                grid.DisplayLayout.Override.AllowMultiCellOperations = ((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)((((((((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders)
                | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut)
                | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Delete)
                | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste)
                | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Undo)
                | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Redo)
                | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Reserved)));
                grid.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
                grid.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
                grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
                grid.DisplayLayout.Override.CellPadding = 0;
                grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
                grid.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
                grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
                grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
                grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
                grid.DisplayLayout.SelectionOverlayBorderThickness = 2;
                grid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
                grid.EnterNextRowEnable = true;
                grid.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                grid.Margin = new System.Windows.Forms.Padding(0);
                grid.Name = "grid";
                grid.TabIndex = 1;
                grid.Text = "grid";
                grid.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
                grid.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
                grid.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                grid.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                grid.DoubleClickRow += Grid_DoubleClickRow;
                this.Controls.Add(grid);
            }
        }

        public class PopList : List<ClassPop>
        {

            public void CloseForm(string sFormID)
            {
                for (int i = this.Count - 1; i >= 0; i--)
                {
                    ClassPop p = this[i];

                    if (p.FormID == sFormID)
                    {
                        this.RemoveAt(i);
                    }
                }
            }
        }

        #endregion
    }
}

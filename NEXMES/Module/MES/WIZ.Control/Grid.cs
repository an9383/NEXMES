using Infragistics.Documents.Excel;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinGrid.DocumentExport;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace WIZ.Control
{
    public class Grid : UltraGrid
    {
        #region 멤버 변수

        private UltraGridRow SummaryRow;

        private bool bSummaries = false;

        private string[] sSummariesList = null;

        private string[] sAverageList = null;

        public Hashtable KeyCollection = new Hashtable();

        public bool IsActivate = false;

        public bool bSaveFuncNoEditable = true;

        public bool bError = false;

        private List<string> sListHasPopupColumn = null;

        private bool _bEnterNext = true;

        private bool _bDeleteBtn = true;

        private bool _bReadOnly = false;

        private string[] column = null;

        private string[] aMergeList = new string[5]
        {
            "",
            "",
            "",
            "",
            ""
        };

        private string[] aFixedList = new string[5]
        {
            "",
            "",
            "",
            "",
            ""
        };

        private string[] asgColumnKey = new string[5]
        {
            "",
            "",
            "",
            "",
            ""
        };

        private string[] _sColumRowMerge = null;

        private ArrayList[] asubgridColumn = new ArrayList[5]
        {
            new ArrayList(),
            new ArrayList(),
            new ArrayList(),
            new ArrayList(),
            new ArrayList()
        };

        private bool _AutoResizeColumn = true;

        private bool _AutoUserColumn = true;

        private int lastRowSeq = 0;

        private string sValue1 = string.Empty;

        private string sValue2 = string.Empty;

        private Report rpt;

        private int[] aColwidth = new int[100];

        private int rows = 0;

        private UltraGridRow gUGR = null;

        private IContainer components = null;

        public UltraGridExcelExporter ugeExcelExporter;

        public ContextMenuStrip cmsMenu;

        public ToolStripMenuItem mnuInsert;

        public ToolStripMenuItem mnuDelete;

        private ToolStripMenuItem mnuExcelExporter;

        private ToolStripSeparator mnuSeparator1;

        public ToolStripMenuItem mnuCopy;

        public ToolStripMenuItem mnuPaste;

        public ToolStripMenuItem mnuCut;

        private ToolStripSeparator toolStripSeparator1;

        private ToolStripMenuItem mnuSubGrid;

        private ToolStripMenuItem mnuMerge;

        private ToolStripMenuItem mnuFixed;

        private ToolStripMenuItem mnuPDFExporter;

        private ToolStripMenuItem mnuReport;

        private ToolStripMenuItem mnuFilter;
        private ToolStripMenuItem mnuInit;
        private ToolStripMenuItem mnuRename;
        private ToolStripMenuItem mnuExcelImport;
        private ToolStripMenuItem mnuPartSum;

        public GridExtendUtil.clsUnitTrans clsUnitTrans;

        /// <summary>
        /// 그리드 Embedded Base 기능을 적용할 리스트 init() 메소드에서 설정 정의함
        /// </summary>
        private List<Infragistics.Win.UltraWinGrid.ColumnStyle> UseEmbededBaseList;

        #region GridExtendUtil.cs 에서 사용하는 멤버 변수
        public delegate void UseLinkMethod();
        public UseLinkMethod useLinkMethod;
        public string RowStatusCode;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem mnuCustom;
        #endregion

        #region DataBinds 를 통한 조회 시 없는 데이터는 보이지 않도록 하기 위해서 사용하는 멤버변수
        /// <summary>
        /// 연관된 메소드 - DataBinds 실행시 MDIChildForm 의 SetListColumnsName
        /// , 사용을 위한 처리는 MDIChildForm 의 DoInquire 처리 이후 사용 
        /// - 조회 후 해당 리스트에 없는 컬럼의 경우 숨김 처리
        /// </summary>
        public List<string> sListColumnsName = new List<string>();

        public void SetListColumnsName()
        {
            sListColumnsName = new List<string>();
            foreach (UltraGridColumn uc in this.Columns)
            {
                sListColumnsName.Add(uc.Key);
            }
        }
        #endregion

        #region WSRYU 21-11-15 수정

        /// <summary>
        /// 최초 조회시
        /// </summary>
        private bool bInit = true;
        /// <summary>
        /// TSY0230 조회시
        /// </summary>
        public bool bInitSubQuery = true;

        /// <summary>
        /// 연관된 클래스 - GridSetUpForm.cs
        /// , 해당 클래스에서 볼수 있는 컬럼 리스트
        /// </summary>
        public ColumnInfoCollectoin sListColumnsUse = new ColumnInfoCollectoin();

        public class clsColumnInfo
        {
            public string key;
            public string name;
            public Infragistics.Win.HAlign align;
            public bool Hidden;
        }

        public class ColumnInfoCollectoin : Collection<clsColumnInfo>
        {
            public void Add(string sKey, string sName, Infragistics.Win.HAlign sAlign, bool sHidden)
            {
                clsColumnInfo c = new clsColumnInfo();
                c.key = sKey;
                c.name = sName;
                c.align = sAlign;
                c.Hidden = sHidden;

                base.Add(c);
            }
        }


        #endregion

        #endregion

        #region 속성
        public string[] ColumRowMerge
        {
            set
            {
                _sColumRowMerge = value;
            }
        }

        public List<string> ListPopupColumn => sListHasPopupColumn;

        public bool AutoResizeColumn
        {
            get
            {
                return _AutoResizeColumn;
            }
            set
            {
                _AutoResizeColumn = value;
            }
        }

        public bool AutoUserColumn
        {
            get
            {
                return _AutoUserColumn;
            }
            set
            {
                _AutoUserColumn = value;
            }
        }

        public bool EnterNextRowEnable
        {
            get
            {
                return _bEnterNext;
            }
            set
            {
                _bEnterNext = value;
            }
        }

        public bool DeleteButtonEnable
        {
            get
            {
                return _bDeleteBtn;
            }
            set
            {
                _bDeleteBtn = value;
            }
        }

        private string[] SummariesList
        {
            get
            {
                return sSummariesList;
            }
            set
            {
                sSummariesList = value;
            }
        }

        public bool ContextMenuInsertEnabled
        {
            get
            {
                return mnuInsert.Enabled;
            }
            set
            {
                mnuInsert.Enabled = value;
                mnuInsert.Visible = value;
            }
        }

        public bool ContextMenuDeleteEnabled
        {
            get
            {
                return mnuDelete.Enabled;
            }
            set
            {
                mnuDelete.Enabled = value;
                mnuDelete.Visible = value;
            }
        }

        public bool ContextMenuExcelEnabled
        {
            get
            {
                return mnuExcelExporter.Enabled;
            }
            set
            {
                mnuExcelExporter.Enabled = value;
                mnuExcelExporter.Visible = value;
            }
        }

        public bool ContextMenuCopyEnabled
        {
            get
            {
                return mnuCopy.Enabled;
            }
            set
            {
                mnuCopy.Enabled = value;
                mnuCopy.Visible = value;
            }
        }

        public bool ContextMenuPasteEnabled
        {
            get
            {
                return mnuPaste.Enabled;
            }
            set
            {
                mnuPaste.Enabled = value;
                mnuPaste.Visible = value;
            }
        }

        public ColumnsCollection Columns => base.DisplayLayout.Bands[0].Columns;

        public ArrayList[] SubGridColumn
        {
            set
            {
                asubgridColumn = value;
            }
        }
        #endregion

        #region 이벤트 처리기 선언부
        public class GridPopUpResultEventArg
        {
            public UltraGridRow row;

            public UltraGridColumn column;

            public UltraGridCell cell;

            public string Message;

            public GridPopUpResultEventArg(UltraGridCell cell, string sMsg = "")
            {
                this.cell = cell;
                row = cell.Row;
                column = cell.Column;
                Message = sMsg;
            }
        }

        public delegate void GridPopUpClose(object sender, GridPopUpResultEventArg e);

        public delegate void Grid_DeleAfterRowFilterChanged(Grid sender, AfterRowFilterChangedEventArgs e);

        public delegate void Grid_KeyPressed(Grid sender, KeyPressEventArgs e);

        public event GridPopUpClose GridPopUpClosed;

        public event Grid_DeleAfterRowFilterChanged AfterDeleRowFilterChanged;

        public event Grid_KeyPressed KeyPressed;
        #endregion

        #region 생성자
        public Grid()
        {
            InitializeComponent();
            init();
        }

        public Grid(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            init();
        }

        private void init()
        {
            sListHasPopupColumn = new List<string>();
            base.KeyActionMappings.Add(new GridKeyActionMapping(Keys.Down, UltraGridAction.BelowRow, (UltraGridState)0, UltraGridState.InEdit, (SpecialKeys)0, (SpecialKeys)0));
            base.KeyActionMappings.Add(new GridKeyActionMapping(Keys.Up, UltraGridAction.PrevRow, (UltraGridState)0, UltraGridState.InEdit, (SpecialKeys)0, (SpecialKeys)0));

            SetUseEmbeddedBaseList();
        }

        private void SetUseEmbeddedBaseList()
        {
            UseEmbededBaseList = new List<Infragistics.Win.UltraWinGrid.ColumnStyle>();

            UseEmbededBaseList.Add(Infragistics.Win.UltraWinGrid.ColumnStyle.Double);
            UseEmbededBaseList.Add(Infragistics.Win.UltraWinGrid.ColumnStyle.DoubleNonNegative);
            UseEmbededBaseList.Add(Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive);
            UseEmbededBaseList.Add(Infragistics.Win.UltraWinGrid.ColumnStyle.Integer);
            UseEmbededBaseList.Add(Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerNonNegative);
            UseEmbededBaseList.Add(Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerPositive);
            UseEmbededBaseList.Add(Infragistics.Win.UltraWinGrid.ColumnStyle.Default);

        }
        #endregion

        private void SetContextMenuLang()
        {
            foreach (ToolStripItem item in cmsMenu.Items)
            {
                try
                {
                    item.Text = Common.getLangText(item.Text);
                }
                catch
                {
                }
            }
        }

        private void DataBindings_CollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            for (int i = 0; i < Columns.Count; i++)
            {
                Columns[i].PerformAutoResize(PerformAutoSizeType.AllRowsInBand);
            }
        }

        #region 그리드 이벤트 외부 발생 처리
        private void OnGridClickEvent(object obj, GridPopUpResultEventArg e)
        {
            if (this.GridPopUpClosed != null)
            {
                this.GridPopUpClosed(obj, e);
            }
        }

        public void GridPopUpCloseAccured(object sender, UltraGridCell cell, string Message = "")
        {
            GridPopUpResultEventArg e = new GridPopUpResultEventArg(cell, Message);
            OnGridClickEvent(this, e);
        }
        #endregion

        public void PopUpColumnListAdd(string ColumnName)
        {
            if (!sListHasPopupColumn.Contains(ColumnName))
            {
                sListHasPopupColumn.Add(ColumnName);
            }
        }

        #region 데이터 연결
        public void DataBinds()
        {
            DataBinds(null);
        }

        public void DataBinds(object oSource)
        {
            DataBinds(oSource, true);
        }

        public void DataBinds(object oSource, bool bFirst = true)
        {
            if (oSource != null)
            {
                base.DataSource = oSource;
            }

            #region 추가 그리드 데이터 구현
            // 합계처리 구현 
            // WSRYU 2021-11-15 
            // 추가 설정 창 데이터를 기반으로 처리함
            // 합계처리 로직을 다시 처리하여 DataBinds 를 bFirst 를 false 로 다시 호출한다.
            if (bFirst)
            {
                SetExtendSum();
            }
            #endregion

            if (!Columns.Exists("ROWSEQ"))
            {
                UltraGridUtil ultraGridUtil = new UltraGridUtil();
                ultraGridUtil.InitColumnUltraGrid(this, "ROWSEQ", "rowSeq", false, GridColDataType_emu.Integer, 1, 1, HAlign.Center, false, false, null, null, null, null, null);
            }
            if (!((DataTable)base.DataSource).Columns.Contains("ROWSEQ"))
            {
                int num = 0;
                ((DataTable)base.DataSource).Columns.Add("ROWSEQ");
                foreach (DataRow row in ((DataTable)base.DataSource).Rows)
                {
                    row["ROWSEQ"] = num++;
                }
                lastRowSeq = num;
            }
            else if (base.DisplayLayout.Bands[0].RowLayoutStyle == RowLayoutStyle.GroupLayout && ((DataTable)base.DataSource).Columns.Contains("ROWSEQ"))
            {
                if (((DataTable)base.DataSource).Rows.Count > 0 && Convert.ToInt32(((DataTable)base.DataSource).Rows[0]["ROWSEQ"]) == 0)
                {
                    int num2 = 0;
                    foreach (DataRow row2 in ((DataTable)base.DataSource).Rows)
                    {
                        row2["ROWSEQ"] = num2++;
                    }
                    lastRowSeq = num2;
                }
                else
                {
                    lastRowSeq = 100000000;
                }
            }
            else
            {
                lastRowSeq = 100000000;
            }
            DataBind();
            ((DataTable)base.DataSource).AcceptChanges();
            for (int i = 0; i < aFixedList.Length; i++)
            {
                string[] array = aFixedList[i].Split(',');
                string[] array2 = array;
                foreach (string text in array2)
                {
                    if (text != "")
                    {
                        base.DisplayLayout.Bands[i].Columns[text].Header.Fixed = true;
                    }
                }
            }

            for (int k = 0; k < aMergeList.Length; k++)
            {
                CellMerge(k);
            }
        }

        private class clsSubSumGrid
        {
            public string sColName;
            public string sGroup_SUM;
            public string sTotal_SUM;

            public string sLastColValue;
            public string sLastColText;

            public double dGroup;
            public double dTotal;
        }
        private void SetExtendSum()
        {
            if (this.DataSource != null)
            {
                if (this.DataSource.GetType().Name != "DataTable")
                {
                    return;
                }

                DBHelper helper = new DBHelper();

                string mdiChildID = getMdiChildID(this);

                DataTable dtGrid = helper.FillTable("USP_ZA0003_S2", CommandType.StoredProcedure
                       , helper.CreateParameter("AS_PCODE", "S2", DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_SCREEN_ID", mdiChildID, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_USER_ID", WIZ.LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                       , helper.CreateParameter("AS_GRID_ID", this.Name, DbType.String, ParameterDirection.Input)
                       );

                if (dtGrid.Rows.Count > 0)
                {
                    List<clsSubSumGrid> sArrList = new List<clsSubSumGrid>();

                    bool bTotal = false;
                    bool bGroup = false;

                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        string sCol = CModule.ToString(dtGrid.Rows[i]["COLKEY"]);
                        string sGroup = CModule.ToString(dtGrid.Rows[i]["GROUP_SUM"]);
                        string sTotal = CModule.ToString(dtGrid.Rows[i]["TOTAL_SUM"]);

                        clsSubSumGrid sg = new clsSubSumGrid();

                        sg.sColName = sCol;
                        sg.sGroup_SUM = sGroup;
                        sg.sTotal_SUM = sTotal == "" ? sGroup : sTotal;
                        sg.sLastColValue = "";
                        sg.dGroup = 0;
                        sg.dTotal = 0;

                        sArrList.Add(sg);

                        if ((sTotal == "" ? sGroup : sTotal) != "")
                        {
                            bTotal = true;
                        }

                        if (sGroup != "")
                        {
                            bGroup = true;
                        }
                    }

                    // 합계 처리
                    DataTable dt = ((DataTable)(this.DataSource)).Clone();

                    for (int i = 0; i < this.Rows.Count; i++)
                    {
                        UltraGridRow ur = this.Rows[i];

                        bool bAddRow = false;
                        DataRow tdr2 = null;

                        for (int j = 0; j < sArrList.Count; j++)
                        {
                            clsSubSumGrid s = sArrList[j];

                            if (s.sGroup_SUM != "")
                            {
                                if (s.sLastColValue != CModule.ToString(ur.Cells[s.sGroup_SUM].Value))
                                {
                                    if (s.sLastColValue != "")
                                    {
                                        //for (int k = 0; k < sArrList.Count; k++)
                                        //{
                                        //    strSubSumGrid s2 = sArrList[k];

                                        if (s.sGroup_SUM != "")
                                        {
                                            if (!bAddRow)
                                            {
                                                bAddRow = true;
                                                tdr2 = dt.NewRow();
                                                dt.Rows.Add(tdr2);
                                            }

                                            tdr2[s.sColName] = s.dGroup;
                                            tdr2[s.sGroup_SUM] = "[" + s.sLastColText + " 합계 ]";
                                            s.dGroup = 0;
                                        }
                                        //}
                                    }

                                    s.sLastColText = CModule.ToString(ur.Cells[s.sGroup_SUM].Text);
                                    s.sLastColValue = CModule.ToString(ur.Cells[s.sGroup_SUM].Value);
                                }
                            }

                            if (CModule.ToDouble(ur.Cells[s.sColName].Value) != 0)
                            {
                                if (s.sGroup_SUM != "")
                                {
                                    s.dGroup += CModule.ToDouble(ur.Cells[s.sColName].Value);
                                }

                                if (s.sTotal_SUM != "")
                                {
                                    s.dTotal += CModule.ToDouble(ur.Cells[s.sColName].Value);
                                }
                            }
                        }

                        DataRow tdr = dt.NewRow();

                        foreach (DataColumn dc in dt.Columns)
                        {
                            tdr[dc] = ur.Cells[dc.ColumnName].Value;
                        }

                        dt.Rows.Add(tdr);

                    }

                    if (bGroup)
                    {
                        DataRow tdr2 = dt.NewRow();

                        for (int j = 0; j < sArrList.Count; j++)
                        {
                            clsSubSumGrid s = sArrList[j];

                            if (s.sGroup_SUM != "")
                            {
                                tdr2[s.sColName] = s.dGroup;
                                tdr2[s.sGroup_SUM] = "[" + s.sLastColText + " 합계 ]";
                            }
                        }

                        dt.Rows.Add(tdr2);
                    }

                    if (bTotal)
                    {
                        DataRow tdr2 = dt.NewRow();

                        for (int j = 0; j < sArrList.Count; j++)
                        {
                            clsSubSumGrid s = sArrList[j];

                            tdr2[s.sColName] = s.dTotal;
                            tdr2[s.sTotal_SUM] = "[ 합계 ]";
                        }

                        dt.Rows.Add(tdr2);
                    }

                    DataBinds(dt, false);
                }
            }
        }

        #endregion

        #region 필터 설정
        public void SetFilter(string columnname, FilterComparisionOperator filtercondition, object value)
        {
            base.Rows.ColumnFilters.ClearAllFilters();
            base.Rows.ColumnFilters[columnname].FilterConditions.Add(filtercondition, value);
        }

        public void SetFilter()
        {
            if (base.DisplayLayout.Override.AllowRowFiltering != DefaultableBoolean.True)
            {
                ValueList filterOperatorsValueList = base.DisplayLayout.FilterOperatorsValueList;
                foreach (ValueListItem valueListItem in filterOperatorsValueList.ValueListItems)
                {
                    FilterComparisionOperator filterComparisionOperator = (FilterComparisionOperator)valueListItem.DataValue;
                    if (FilterComparisionOperator.Contains == filterComparisionOperator)
                    {
                        valueListItem.DisplayText = Common.getLangText("포함");
                    }
                    else if (FilterComparisionOperator.StartsWith == filterComparisionOperator)
                    {
                        valueListItem.DisplayText = Common.getLangText("앞", "filter");
                    }
                    else if (FilterComparisionOperator.EndsWith == filterComparisionOperator)
                    {
                        valueListItem.DisplayText = Common.getLangText("뒤", "filter");
                    }
                    else if (filterComparisionOperator == FilterComparisionOperator.Equals)
                    {
                        valueListItem.DisplayText = Common.getLangText("같음");
                    }
                }
                base.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow;
                base.DisplayLayout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnEnterKeyOrLeaveCell;
                base.DisplayLayout.Override.FilterOperatorDropDownItems = (FilterOperatorDropDownItems.Equals | FilterOperatorDropDownItems.StartsWith | FilterOperatorDropDownItems.EndsWith | FilterOperatorDropDownItems.Contains);
                base.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            }
            else
            {
                foreach (UltraGridBand band in base.DisplayLayout.Bands)
                {
                    band.ColumnFilters.ClearAllFilters();
                }
                base.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.False;
            }
        }
        #endregion

        #region Row 삽입처리
        public int InsertRow(bool bCopy = false)
        {
            if (asubgridColumn[0].Count > 0)
            {
                MessageBox.Show(Common.getLangText("그룹모음 해제후 추가할수있습니다.", "MSG"));
                return -1;
            }
            Cursor = Cursors.WaitCursor;
            bool flag = false;
            if (!base.IsUpdating)
            {
                BeginUpdate();
                flag = true;
            }
            int num = (base.ActiveRow != null) ? base.ActiveRow.Index : 0;
            int num2 = (base.ActiveRowScrollRegion.FirstRow != null) ? base.ActiveRowScrollRegion.FirstRow.Index : 0;
            base.DisplayLayout.Bands[0].AddNew();
            base.ActiveRow.Tag = "NEW";
            if (base.Rows.Count != 1)
            {
                base.Rows.Move(base.Rows[base.Rows.Count - 1], num + 1);
                base.ActiveRowScrollRegion.FirstRow = base.Rows[num2 + 1];
            }
            base.ActiveRow.Appearance.BackColor = Color.FromArgb(237, 251, 255);
            for (int i = 0; i < base.ActiveRow.Cells.Count; i++)
            {
                string key = base.ActiveRow.Cells[i].Column.Key;
                string a = (string)base.DisplayLayout.Bands[0].Columns[key].Tag;
                if (!(a == "K"))
                {
                    if (a == "M")
                    {
                        base.ActiveRow.Cells[i].Appearance.BackColor = Color.FromArgb(255, 255, 153);
                    }
                }
                else
                {
                    base.ActiveRow.Cells[i].Appearance.BackColor = Color.FromArgb(240, 255, 210);
                }
                if (base.DisplayLayout.Bands[0].Columns[key].CellActivation == Activation.NoEdit)
                {
                    for (int j = 0; j < base.Rows.Count; j++)
                    {
                        if (base.Rows[j].Tag == null || !base.Rows[j].Tag.Equals("NEW"))
                        {
                            base.Rows[j].Cells[key].IgnoreRowColActivation = false;
                            base.Rows[j].Cells[key].Activation = Activation.NoEdit;
                        }
                    }
                }
                else
                {
                    base.ActiveRow.Cells[key].IgnoreRowColActivation = true;
                    base.ActiveRow.Cells[key].Activation = Activation.AllowEdit;
                }

                if (bCopy)
                {
                    base.ActiveRow.Cells[key].Value = base.Rows[num].Cells[key].Value;
                }
            }
            try
            {
                base.ActiveRow.Cells["rowSeq"].Value = GetLastRow();
            }
            catch
            {

            }

            if (flag)
            {
                EndUpdate();
            }
            Cursor = Cursors.Default;
            return base.ActiveRow.Index;
        }

        public int InsertRowAt(int rowindex)
        {
            //int num = rowindex;
            if (rowindex > base.Rows.Count)
            {
                rowindex = base.Rows.Count - 1;
            }
            if (base.Rows.Count > 0)
            {
                base.Rows[rowindex].Activate();
            }
            return InsertRow();
        }
        #endregion

        #region Row 삭제처리
        public void DeleteRow()
        {
            bool flag = false;
            if (!base.IsUpdating)
            {
                BeginUpdate();
                flag = true;
            }
            //int num = (base.ActiveRow != null) ? base.ActiveRow.Index : 0;
            if (base.Rows.Count == 0)
            {
                if (flag)
                {
                    EndUpdate();
                }
                return;
            }
            if (base.ActiveRow == null)
            {
                base.Rows[0].Activate();
            }
            if (!base.ActiveRow.Selected)
            {
                base.ActiveRow.Selected = true;
            }
            object mdiChild = getMdiChild(this);
            MethodInfo method = mdiChild.GetType().GetMethod("CanDeleteCheck");
            int num2 = base.Selected.Rows.Count - 1;
            while (0 <= num2)
            {
                if (base.Selected.Rows[num2].Activation != Activation.NoEdit)
                {
                    string text = "";
                    try
                    {
                        text = (string)method.Invoke(mdiChild, new object[1]
                        {
                            base.Selected.Rows[num2]
                        });
                        if (text != "")
                        {
                            MessageBox.Show(text, Common.getLangText("삭제 확인", "MSG"));
                        }
                    }
                    catch (Exception)
                    {
                    }
                    if (text == "")
                    {
                        base.Selected.Rows[num2].Delete(displayPrompt: false);
                    }
                }
                num2--;
            }
            if (flag)
            {
                EndUpdate();
            }
        }

        public void DeleteRowAt(int rowindex)
        {
            int num = rowindex;
            if (base.Rows.Count > 0)
            {
                if (base.Rows.Count >= num)
                {
                    num = base.Rows.Count - 1;
                }
                try
                {
                    object mdiChild = getMdiChild(this);
                    MethodInfo method = mdiChild.GetType().GetMethod("CanDeleteCheck");
                    string text = (string)method.Invoke(mdiChild, new object[1]
                    {
                        base.Rows[num]
                    });
                    if (text != "")
                    {
                        MessageBox.Show(text, Common.getLangText("삭제 확인", "MSG"));
                    }
                }
                catch (Exception)
                {
                }
                base.Rows[num].Delete(displayPrompt: false);
            }
        }
        #endregion

        #region 그리드 초기화시 - Format 및 문자열 잘림 현상 완화

        private void Grid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            for (int i = 0; i < this.Columns.Count; i++)
            {
                if (this.DisplayLayout.Bands[0].Columns[i].ValueList == null)
                {
                    if (UseEmbededBaseList.Contains(this.DisplayLayout.Bands[0].Columns[i].Style))
                    {
                        DefaultEditorOwnerSettings defaultEditorOwnerSettings = new DefaultEditorOwnerSettings();
                        DefaultEditorOwner deo = new DefaultEditorOwner(defaultEditorOwnerSettings);

                        EmbeddableEditorBase emd = null;

                        defaultEditorOwnerSettings.DataType = typeof(string);
                        emd = new EditorWithText(deo);

                        if (CModule.ToString(this.DisplayLayout.Bands[0].Columns[i].MaskInput).Length == 0)
                        {
                            emd.BeforeExitEditMode += Emd_BeforeExitEditMode;
                            emd.BeforeEnterEditMode += Emd_BeforeEnterEditMode;
                            emd.Tag = e.Row.Cells[i];
                        }

                        e.Row.Cells[i].Editor = emd;
                    }
                }
            }
        }

        private void Emd_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            EmbeddableEditorBase emd = sender as EmbeddableEditorBase;

            if (emd != null)
            {
                if (emd.Tag != null)
                {
                    UltraGridCell ugc = emd.Tag as UltraGridCell;

                    if (ugc != null)
                    {
                        this.sValue1 = CModule.ToString(ugc.Value);
                    }
                }
            }
        }

        private void Emd_BeforeExitEditMode(object sender, Infragistics.Win.BeforeExitEditModeEventArgs e)
        {
            EmbeddableEditorBase emd = sender as EmbeddableEditorBase;

            if (emd != null)
            {
                if (emd.Tag != null)
                {
                    UltraGridCell ugc = emd.Tag as UltraGridCell;

                    if (ugc != null)
                    {
                        if (this.sValue1 != emd.CurrentEditText)
                        {
                            //2021-05-04 수정 하기전
                            //ugc.Value = emd.CurrentEditText;

                            //2021-05-04 add : 행추가후.. 입력중에 엔터키 없는 상태 + ugc.Value = null상태에서 [조회]를 누르면 에러 발생함으로
                            //             : if 조건절 추가함
                            // 수정 후
                            if (ugc.Value != null)
                            {
                                ugc.Value = emd.CurrentEditText;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region 엑셀 처리
        #region 엑셀 생성
        public void ExportExcel(string sFileName)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                ugeExcelExporter.Export(this, sFileName, WorkbookFormat.Excel2007);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor = Cursors.Default;
        }

        public void ExportExcel()
        {
            cmsMenu.Close();


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.FileName = Common.gsSelFormName + " " + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                Cursor = Cursors.WaitCursor;
                try
                {
                    ugeExcelExporter.Export(this, saveFileDialog.FileName, WorkbookFormat.Excel2007);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }
        #endregion

        #region 엑셀 리딩
        //public static DataSet ReadExcelFile(string sFIleName)
        //{
        //    DataSet ds = null;
        //    // 엑셀 문서 내용 추출
        //    string connectionString = string.Empty;

        //    if (File.Exists(sFIleName))  // 파일 확장자 검사
        //    {
        //        if (Path.GetExtension(sFIleName).ToLower() == ".xls")
        //        {   // Microsoft.Jet.OLEDB.4.0 은 32 bit 에서만 동작되므로 빌드할 때 64비트로 하면 에러가 발생함.
        //            connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 8.0;IMEX=1\"", sFIleName);
        //        }
        //        else if (Path.GetExtension(sFIleName).ToLower() == ".xlsx")
        //        {
        //            connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Mode=ReadWrite; Data Source={0};Extended Properties=Excel 12.0;", sFIleName);
        //        }
        //    }

        //    OleDbConnection oleConn = null;
        //    OleDbCommand oleCmd = null;
        //    OleDbDataAdapter dataAdapter = null;

        //    String[] SheetName = ExcelSheetNames(sFIleName);
        //    string strQuery = null;

        //    if (SheetName == null)
        //    {
        //        return null;
        //    }

        //    try
        //    {
        //        ds = new DataSet();

        //        for (int i = 0; i < SheetName.Length; i++)
        //        {
        //            if (String.IsNullOrEmpty(SheetName[i]) == false)
        //            {
        //                strQuery = "SELECT * FROM [" + SheetName[i] + "$]";  // 엑셀 시트명 Sheet1의 모든 데이터를 가져오기
        //                oleConn = new OleDbConnection(connectionString);
        //                oleConn.Open();
        //                oleCmd = new OleDbCommand(strQuery, oleConn);
        //                dataAdapter = new OleDbDataAdapter(oleCmd);

        //                DataTable dataTable = new DataTable();
        //                dataTable.TableName = SheetName[i];
        //                dataAdapter.Fill(dataTable);
        //                ds.Tables.Add(dataTable);
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        ds = null;
        //    }
        //    finally
        //    {
        //        if (oleConn != null)
        //        {
        //            dataAdapter = null;
        //            oleCmd = null;

        //            oleConn.Close();

        //            oleConn = null;
        //        }
        //    }
        //    //dgv.DataSource = data.Tables[0].DefaultView;

        //    return ds;
        //}
        //public static String[] ExcelSheetNames(string excelFile)
        //{
        //    string[] sheetNames = null;
        //    String connectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0;"
        //        , excelFile);
        //    using (OleDbConnection excelConnection = new OleDbConnection(connectionString))
        //    {
        //        DataTable dtSheets = new DataTable();

        //        try
        //        {
        //            excelConnection.Open();
        //            dtSheets = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" });


        //            if (dtSheets == null)
        //            {
        //                sheetNames = null;
        //                return sheetNames;
        //            }

        //            List<String> sList = new List<string>();

        //            for (int i = 0; i < dtSheets.Rows.Count; i++)
        //            {
        //                if (Common.ToString(dtSheets.Rows[i]["TABLE_NAME"]).EndsWith("$") || Common.ToString(dtSheets.Rows[i]["TABLE_NAME"]).EndsWith("$'"))
        //                {
        //                    sList.Add(dtSheets.Rows[i]["TABLE_NAME"].ToString().Trim('\'').Replace("$", ""));
        //                }
        //            }

        //            sheetNames = sList.ToArray();
        //        }
        //        catch (Exception ex)
        //        {
        //            return null;
        //        }
        //        finally
        //        {

        //            excelConnection.Close();
        //        }
        //    }
        //    return sheetNames;
        //}

        public void ImportExcel()
        {
            cmsMenu.Close();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files (2003이하) (*.xls)|*.xls|Excel Files (2007이상) (*.xlsx)|*.xlsx|CSV 쉼표로 분리 TEXT (*.csv)|*.csv";
            ofd.DefaultExt = "xls";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    string oledbConnStr = string.Empty;
                    string sFilePath = ofd.FileName;

                    if (sFilePath.EndsWith(".xlsx"))
                    {
                        // 엑셀 2007 이상
                        oledbConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"" + sFilePath + "\";Extended Properties='Excel 8.0;HDR=NO'";

                    }
                    else if (sFilePath.EndsWith(".xls"))
                    {
                        // 엑셀 2003 및 이하 버전
                        //connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 8.0;IMEX=1\"", sFIleName);
                        oledbConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" + sFilePath + "\";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'";
                    }
                    else
                    {
                        // CSV
                        oledbConnStr = "";
                    }

                    DataTable dtExcel = null;

                    if (oledbConnStr != "")
                    {
                        OleDbDataAdapter adt = null;

                        using (OleDbConnection con = new OleDbConnection(oledbConnStr))
                        {
                            con.Open();

                            DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                            string sheetName = dt.Rows[0]["TABLE_NAME"].ToString();             //엑셀 첫 번째 시트명
                            string sQuery = string.Format(" SELECT * FROM [{0}] ", sheetName);  //조회 쿼리

                            dtExcel = new DataTable();
                            adt = new OleDbDataAdapter(sQuery, con);
                            adt.Fill(dtExcel);

                            this.DataSource = dtExcel;
                        }
                    }
                    else
                    {
                        // Text 처리 ( csv )
                        FileStream fs = new FileStream(sFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        StreamReader sr = new StreamReader(fs);

                        dtExcel = new DataTable();
                        while (!sr.EndOfStream)
                        {
                            string s = sr.ReadLine();
                            string[] sArr = s.Split(',');

                            if (dtExcel.Columns.Count == 0)
                            {
                                for (int i = 0; i < sArr.Length; i++)
                                {
                                    dtExcel.Columns.Add(sArr[i], typeof(string));
                                }
                            }
                            else
                            {
                                dtExcel.Rows.Add(sArr);
                            }
                        }

                        this.DataSource = dtExcel;
                    }
                }
                catch (FileNotFoundException ex)
                {
                    //MessageBox.Show("파일을 찾을 수 없습니다.");
                    MessageBox.Show(ex.Message);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }
        #endregion
        #endregion

        #region PDF 
        public void ExportPDF()
        {
            cmsMenu.Close();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Portable Document Files (*.pdf)|*.pdf";
            saveFileDialog.DefaultExt = "pdf";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    UltraGridDocumentExporter ultraGridDocumentExporter = new UltraGridDocumentExporter();
                    ultraGridDocumentExporter.Export(this, saveFileDialog.FileName, GridExportFileFormat.PDF);
                }
                catch
                {
                }
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region 읽기전용 처리
        public void DoReadOnly(bool bReadOnly)
        {
            _bReadOnly = bReadOnly;
            DoReadOnly();
        }

        private void DoReadOnly()
        {
            if (bSaveFuncNoEditable)
            {
                if (_bReadOnly)
                {
                    foreach (UltraGridRow row in base.Rows)
                    {
                        row.Activation = Activation.NoEdit;
                    }
                }
                else
                {
                    foreach (UltraGridRow row2 in base.Rows)
                    {
                        row2.Activation = Activation.AllowEdit;
                    }
                }
            }
        }
        #endregion

        #region Summary 관련
        public void ClearSummary()
        {
            if (SummaryRow != null)
            {
                SummaryRow.Delete(displayPrompt: false);
                SummaryRow = null;
            }
        }

        public void SetSummaries(string[] sSumList, string[] sAverList = null)
        {
            sSummariesList = sSumList;
            sAverageList = sAverList;
        }

        public UltraGridRow DoSummaries(string[] sSumList, string[] sAverList = null)
        {
            sSummariesList = sSumList;
            sAverageList = sAverList;
            return DoSummaries();
        }

        private void setSummariesList()
        {
            if (sSummariesList != null)
            {
                return;
            }
            ArrayList arrayList = new ArrayList();
            DataTable dataTable = null;
            if (base.DataSource.GetType().Name.ToUpper() == "DATATABLE")
            {
                dataTable = (DataTable)base.DataSource;
            }
            else
            {
                DataSet dataSet = (DataSet)base.DataSource;
                dataTable = dataSet.Tables[dataSet.Tables.Count - 1];
            }
            foreach (DataColumn column2 in dataTable.Columns)
            {
                switch (column2.DataType.Name)
                {
                    case "Decimal":
                    case "Double":
                    case "Int16":
                    case "Int32":
                    case "Int64":
                    case "UInt16":
                    case "UInt32":
                    case "UInt64":
                        arrayList.Add(column2.ColumnName);
                        break;
                }
            }
            if (arrayList.Count != 0)
            {
                sSummariesList = new string[arrayList.Count];
                for (int i = 0; i < arrayList.Count; i++)
                {
                    sSummariesList[i] = arrayList[i].ToString();
                }
            }
        }

        public UltraGridRow DoSummaries()
        {
            if (base.Rows.Count == 0)
            {
                return null;
            }
            setSummariesList();
            if (sSummariesList == null)
            {
                return null;
            }
            if (SummaryRow == null)
            {
                bSummaries = false;
            }
            bool flag = false;
            if (!base.IsUpdating)
            {
                BeginUpdate();
                flag = true;
            }
            try
            {
                if (SummaryRow != null)
                {
                    SummaryRow.Delete(displayPrompt: false);
                    SummaryRow = null;
                }
                if (!bSummaries)
                {
                    base.DisplayLayout.Override.FixedRowStyle = FixedRowStyle.Bottom;
                    bSummaries = true;
                    SummaryRow = DoSummariesProcess();
                }
                else
                {
                    bSummaries = false;
                }
                if (flag)
                {
                    EndUpdate();
                }
                return SummaryRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (flag)
                {
                    EndUpdate();
                }
            }
        }

        private UltraGridRow DoSummariesProcess()
        {
            UltraGridRow ultraGridRow = base.DisplayLayout.Bands[0].AddNew();
            ultraGridRow.Activation = Activation.NoEdit;
            base.Rows.FixedRows.Add(ultraGridRow);
            foreach (ColumnFilter item in (IEnumerable)base.DisplayLayout.Bands[0].ColumnFilters)
            {
                if (item.FilterConditions.Count != 0)
                {
                    bool flag = false;
                    string[] array = sSummariesList;
                    foreach (string b in array)
                    {
                        if (item.Column.Key == b)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        string[] array2 = sAverageList;
                        foreach (string b2 in array2)
                        {
                            if (item.Column.Key == b2)
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (!flag)
                    {
                        ultraGridRow.Cells[item.Column.Key].Value = item.FilterConditions[0].CompareValue;
                    }
                }
            }
            if (sSummariesList != null)
            {
                string[] array3 = sSummariesList;
                foreach (string key in array3)
                {
                    if (!Columns.Exists(key))
                    {
                        continue;
                    }
                    double num = 0.0;
                    for (int l = 0; l < base.Rows.Count; l++)
                    {
                        if (!base.Rows[l].HiddenResolved && base.Rows[l] != ultraGridRow)
                        {
                            num += nvlDouble(base.Rows[l].Cells[key].Value);
                        }
                    }
                    ultraGridRow.Cells[key].Value = num;
                }
            }
            if (sAverageList != null)
            {
                string[] array4 = sAverageList;
                foreach (string key2 in array4)
                {
                    if (!Columns.Exists(key2))
                    {
                        continue;
                    }
                    double num2 = 0.0;
                    for (int n = 0; n < base.Rows.Count; n++)
                    {
                        if (base.Rows[n] != ultraGridRow && !base.Rows[n].HiddenResolved)
                        {
                            num2 += nvlDouble(base.Rows[n].Cells[key2].Value);
                        }
                    }
                    ultraGridRow.Cells[key2].Value = num2 / (double)base.Rows.Count;
                    ultraGridRow.Cells[key2].Appearance.ForeColor = Color.Blue;
                }
            }
            string key3 = base.DisplayLayout.Bands[0].Columns[0].Key;
            int num3 = 999;
            foreach (UltraGridColumn column2 in base.DisplayLayout.Bands[0].Columns)
            {
                if (!column2.Hidden && column2.Header.VisiblePosition < num3 && nvlString(ultraGridRow.Cells[column2.Key].Value) == "")
                {
                    num3 = column2.Header.VisiblePosition;
                    key3 = column2.Key;
                }
            }
            ultraGridRow.Cells[key3].Value = Common.getLangText("합계");
            ultraGridRow.Update();
            return ultraGridRow;
        }
        #endregion

        #region 데이터 정리
        private double nvlDouble(object obj, double def = 0.0)
        {
            if (obj == null)
            {
                return def;
            }
            if (obj == DBNull.Value)
            {
                return def;
            }
            if (obj.ToString() == "")
            {
                return def;
            }
            return Convert.ToDouble(obj);
        }

        public string nvlString(object obj, string def = "")
        {
            if (obj == null)
            {
                return def;
            }
            if (obj == DBNull.Value)
            {
                return def;
            }
            if (obj.ToString() == "")
            {
                return def;
            }
            if (obj.ToString().ToUpper() == "ALL")
            {
                return def;
            }
            if (obj.ToString() == Common.getLangText("전체"))
            {
                return def;
            }
            return obj.ToString();
        }
        #endregion

        #region 컨트롤 공통 처리
        public string getMdiChildID(System.Windows.Forms.Control ctl)
        {
            int num = 0;
            string result = "";
            while (++num < 10)
            {
                if (ctl.Parent == null)
                {
                    result = ctl.GetType().Name;
                    break;
                }
                if (ctl.Parent.GetType().Name == "MdiClient")
                {
                    result = ctl.GetType().Name;
                    break;
                }
                ctl = ctl.Parent;
            }
            return result;
        }

        public object getMdiChild(System.Windows.Forms.Control ctl)
        {
            int num = 0;
            while (++num < 10)
            {
                if (ctl.Parent == null)
                {
                    return ctl;
                }
                if (ctl.Parent.GetType().Name == "MdiClient")
                {
                    break;
                }
                ctl = ctl.Parent;
            }
            return ctl.Parent;
        }
        #endregion

        #region 창 닫힐 때 처리
        public void Close()
        {
            if (AutoUserColumn)
            {
                try
                {
                    string mdiChildID = getMdiChildID(this);
                    string name = base.Name;
                    string text = "";
                    string[] array = new string[base.DisplayLayout.Bands[0].Columns.Count];
                    foreach (UltraGridColumn column2 in base.DisplayLayout.Bands[0].Columns)
                    {
                        if (!column2.Hidden)
                        {
                            array[column2.Header.VisiblePosition] = column2.Key;
                        }
                    }
                    int num = 0;
                    string[] array2 = array;
                    foreach (string text2 in array2)
                    {
                        if (text2 != null && !(text2.ToUpper() == "ROWSEQ"))
                        {
                            UltraGridColumn ultraGridColumn = base.DisplayLayout.Bands[0].Columns[text2];
                            string[] obj = new string[8]
                            {
                                text,
                                ultraGridColumn.Key,
                                "^",
                                null,
                                null,
                                null,
                                null,
                                null
                            };
                            int num2 = num + 1;
                            num = num2;
                            obj[3] = num2.ToString();
                            obj[4] = "^";
                            obj[5] = ultraGridColumn.Width.ToString();
                            obj[6] = "^0^";
                            obj[7] = ultraGridColumn.Header.Caption + "|";
                            text = string.Concat(obj);
                        }
                    }
                    foreach (UltraGridColumn column3 in base.DisplayLayout.Bands[0].Columns)
                    {
                        if (column3.Hidden)
                        {
                            string[] obj2 = new string[8]
                            {
                                text,
                                column3.Key,
                                "^",
                                null,
                                null,
                                null,
                                null,
                                null
                            };
                            int num2 = num + 1;
                            num = num2;
                            obj2[3] = num2.ToString();
                            obj2[4] = "^";
                            obj2[5] = column3.Width.ToString();
                            obj2[6] = "^1^";
                            obj2[7] = column3.Header.Caption + "|";
                            text = string.Concat(obj2);
                        }
                    }
                    string text3 = "";
                    string text4 = "";
                    string text5 = "";
                    //string text6 = "";

                    for (int j = 0; j < base.DisplayLayout.Bands.Count; j++)
                    {
                        foreach (string item in asubgridColumn[j])
                        {
                            if (!base.DisplayLayout.Bands[j].Columns[item].Hidden)
                            {
                                text3 = text3 + item + ",";
                            }
                        }
                        text3 += "^";
                        foreach (UltraGridColumn column4 in base.DisplayLayout.Bands[j].Columns)
                        {
                            if (column4.MergedCellStyle == MergedCellStyle.Always)
                            {
                                text4 = text4 + column4.Key + ",";
                            }
                            if (column4.Header.Fixed)
                            {
                                text5 = text5 + column4.Key + ",";
                            }
                        }
                        text4 += "^";
                        text5 += "^";
                    }

                    text = text + text3 + "|" + text4 + "|" + text5;


                    try
                    {
                        DBHelper dBHelper = new DBHelper(completedClose: true);
                        dBHelper.ExecuteNoneQuery("USP_ZZ9000_I1", CommandType.StoredProcedure, dBHelper.CreateParameter("UserID", LoginInfo.UserID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("MdiChildID", mdiChildID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("GridID", name, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("Status", text, DbType.String, ParameterDirection.Input));
                    }
                    catch
                    {
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        #endregion

        #region 사용자 정의 컬럼 설정
        public void setUserColumn()
        {
            if (AutoUserColumn)
            {
                try
                {
                    if (bInit)
                    {
                        this.sListColumnsUse.Clear();

                        foreach (UltraGridColumn dc in this.Columns)
                        {
                            if (!dc.Hidden)
                            {
                                sListColumnsUse.Add(dc.Key, dc.Header.Caption, dc.CellAppearance.TextHAlign, false);
                            }
                        }

                        bInit = false;
                    }

                    string mdiChildID = getMdiChildID(this);
                    string name = base.Name;
                    DBHelper dBHelper = new DBHelper(completedClose: true);
                    object obj = dBHelper.ExecuteScalar("USP_ZZ9000_S1", CommandType.StoredProcedure
                        , dBHelper.CreateParameter("UserID", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                        , dBHelper.CreateParameter("MdiChildID", mdiChildID, DbType.String, ParameterDirection.Input)
                        , dBHelper.CreateParameter("GridID", name, DbType.String, ParameterDirection.Input));

                    string text = CModule.ToString(obj);

                    if (text == "") return;

                    string[] array = text.Split('|');
                    for (int i = 0; i < array.Length - 3; i++)
                    {
                        try
                        {
                            string[] array2 = array[i].Split('^');
                            base.DisplayLayout.Bands[0].Columns[array2[0]].Header.VisiblePosition = Convert.ToInt32(array2[1]);
                            base.DisplayLayout.Bands[0].Columns[array2[0]].Width = Convert.ToInt32(array2[2]);
                            base.DisplayLayout.Bands[0].Columns[array2[0]].Hidden = ((array2[3] == "1") ? true : false);
                            if (array2.Length >= 5)
                            {
                                base.DisplayLayout.Bands[0].Columns[array2[0]].Header.Caption = CModule.ToString(array2[4]);
                            }
                        }
                        catch
                        {
                        }
                    }
                    ArrayList[] array3 = asubgridColumn;
                    foreach (ArrayList arrayList in array3)
                    {
                        arrayList.Clear();
                    }
                    aMergeList = new string[5]
                    {
                        "",
                        "",
                        "",
                        "",
                        ""
                    };
                    aFixedList = new string[5]
                    {
                        "",
                        "",
                        "",
                        "",
                        ""
                    };
                    string[] array4 = array[array.Length - 3].Split('^');
                    string[] array5 = array[array.Length - 2].Split('^');
                    string[] array6 = array[array.Length - 1].Split('^');
                    int num = 0;
                    string[] array7 = array4;
                    foreach (string text2 in array7)
                    {
                        if (text2 != "")
                        {
                            string[] array8 = text2.Split(',');
                            string[] array9 = array8;
                            foreach (string text3 in array9)
                            {
                                try
                                {
                                    if (text3 != "" && base.DisplayLayout.Bands[0].Columns[text3] != null)
                                    {
                                        asubgridColumn[num].Add(text3);
                                    }
                                }
                                catch
                                {
                                }
                            }
                        }
                        num++;
                    }
                    num = 0;
                    string[] array10 = array5;
                    foreach (string text4 in array10)
                    {
                        if (text4 != "")
                        {
                            string[] array11 = text4.Split(',');
                            string[] array12 = array11;
                            foreach (string text5 in array12)
                            {
                                if (text5 != "")
                                {
                                    string reference = aMergeList[num];
                                    reference = reference + "," + text5;
                                }
                            }
                        }
                        num++;
                    }
                    num = 0;
                    string[] array13 = array6;
                    foreach (string text6 in array13)
                    {
                        if (text6 != "")
                        {
                            string[] array14 = text6.Split(',');
                            string[] array15 = array14;
                            foreach (string text7 in array15)
                            {
                                if (text7 != "")
                                {
                                    string reference2 = aFixedList[num];
                                    reference2 = reference2 + "," + text7;
                                    if (num == 0)
                                    {
                                        base.DisplayLayout.Bands[0].Columns[text7].Header.Fixed = true;
                                    }
                                }
                            }
                        }
                        num++;
                    }
                }
                catch (Exception)    //(Exception ex)
                {
                }
            }
        }

        private void GridUserSetInit()
        {
            string mdiChildID = getMdiChildID(this);
            string name = base.Name;
            string text = "";

            DBHelper dBHelper = new DBHelper(completedClose: true);
            dBHelper.ExecuteNoneQuery("USP_ZZ9000_I1"
                    , CommandType.StoredProcedure
                    , dBHelper.CreateParameter("UserID", LoginInfo.UserID, DbType.String, ParameterDirection.Input)
                    , dBHelper.CreateParameter("MdiChildID", mdiChildID, DbType.String, ParameterDirection.Input)
                    , dBHelper.CreateParameter("GridID", name, DbType.String, ParameterDirection.Input)
                    , dBHelper.CreateParameter("Status", text, DbType.String, ParameterDirection.Input));

            AutoUserColumn = false;

            CloseForm(mdiChildID);
        }

        private void GridPopupOpen()
        {
            string mdiChildID = getMdiChildID(this);

            GridSetUpForm gsf = new GridSetUpForm(this);
            gsf.sScreenID = mdiChildID;
            gsf.sUserID = WIZ.LoginInfo.UserID;
            gsf.sGridID = this.Name;

            gsf.SetData();
            gsf.ShowDialog();
        }

        private void CloseForm(string mdiChildID)
        {
            Form t = FindForm(this, mdiChildID) as Form;

            if (t != null)
            {
                t.Close();
            }
        }

        private System.Windows.Forms.Control FindForm(System.Windows.Forms.Control c, string name)
        {
            if (c == null)
                return null;

            if (c.GetType().Name == name)
            {
                return c;
            }

            if (c.Parent == null)
                return null;

            return FindForm(c.Parent, name);
        }
        #endregion

        #region 기타 이벤트 메소드
        protected override void OnBeforeCellActivate(CancelableCellEventArgs e)
        {
            base.OnBeforeCellActivate(e);
            if (base.DataSource != null)
            {
                if (base.ActiveRow.Tag != null && base.ActiveRow.Tag.ToString() == "NEW")
                {
                    e.Cell.Column.CellActivation = Activation.AllowEdit;
                }
                else if ((string)e.Cell.Column.Tag == "K")
                {
                    e.Cell.Column.CellActivation = Activation.NoEdit;
                }
            }
        }

        public void UpdateGridData()
        {
            base.Selected.Rows.Clear();
            InsertRow();
            DeleteRow();
            UpdateData();
            base.Rows[0].Activate();
        }

        protected override void OnInitializeRow(InitializeRowEventArgs e)
        {
            base.OnInitializeRow(e);
            if (!e.ReInitialize)
            {
                return;
            }
            if (e.Row.Tag == null)
            {
                e.Row.Tag = "";
            }
            if (e.Row.Tag.ToString() == "NEW")
            {
                return;
            }
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (e.Row.Cells[i].DataChanged)
                {
                    string a = (string)e.Row.Cells[i].Column.Tag;
                    if (!(a == "K"))
                    {
                        if (a == "M")
                        {
                            e.Row.Cells[i].Appearance.BackColor = Color.GreenYellow;
                        }
                        else
                        {
                            e.Row.Cells[i].Appearance.BackColor = Color.NavajoWhite;
                        }
                    }
                    else
                    {
                        e.Row.Cells[i].Appearance.BackColor = Color.Azure;
                    }
                }
                else
                {
                    string a2 = (string)e.Row.Cells[i].Column.Tag;
                    if (!(a2 == "K") && a2 == "M")
                    {
                        e.Row.Cells[i].Appearance.BackColor = Color.Honeydew;
                    }
                }
            }
            e.Row.Tag = "MODIFIED";
        }

        public void AddColumnValueList(string columnname, DataTable dtvaluelist)
        {
            base.DisplayLayout.ValueLists.Add(columnname);
            for (int i = 0; i < dtvaluelist.Rows.Count; i++)
            {
                base.DisplayLayout.ValueLists[columnname].ValueListItems.Add(dtvaluelist.Rows[i][0], dtvaluelist.Rows[i][1].ToString());
            }
            base.DisplayLayout.Bands[0].Columns[columnname].ValueList = base.DisplayLayout.ValueLists[columnname];
            base.DisplayLayout.Bands[0].Columns[columnname].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
        }

        protected override void OnEnter(EventArgs e)
        {
            try
            {
                base.OnEnter(e);

                if (base.DisplayLayout == null)
                {   //2020-10-28 add : 신효철
                    IsActivate = true;
                    return;
                }


                base.DisplayLayout.Appearance.BorderColor = Color.CornflowerBlue;
                base.DisplayLayout.Appearance.BorderColor2 = Color.CornflowerBlue;
                base.DisplayLayout.BorderStyle = UIElementBorderStyle.TwoColor;
                IsActivate = true;
            }
            catch
            {
            }
        }

        protected override void OnClickCellButton(CellEventArgs e)
        {
            base.OnClickCellButton(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            try
            {
                if (base.DisplayLayout == null)
                {   //2020-09-15 add
                    IsActivate = false;
                    return;
                    //MessageBox.Show("base.DisplayLayout = null");
                }

                base.DisplayLayout.Appearance.BorderColor2 = Color.White;
                base.DisplayLayout.Appearance.BorderColor = Color.Silver;
                base.DisplayLayout.Appearance.BorderColor2 = Color.Transparent;
                IsActivate = false;
            }
            catch
            {
            }
        }

        protected override void OnInitializeLayout(InitializeLayoutEventArgs e)
        {
            base.OnInitializeLayout(e);
            try
            {
                DataTable dataTable = null;
                if (base.DataSource.GetType().BaseType.ToString() == "System.Data.DataSet")
                {
                    dataTable = ((!(base.DataMember == "") && base.DataMember != null) ? ((DataSet)base.DataSource).Tables[base.DataMember] : ((DataSet)base.DataSource).Tables[0]);
                }
                else if (base.DataSource.GetType().ToString() == "System.Data.DataTable")
                {
                    dataTable = (DataTable)base.DataSource;
                }
                if (dataTable != null)
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        if (base.DisplayLayout.Bands[0].Columns[dataTable.Columns[i].ColumnName] != null)
                        {
                            if (!dataTable.Columns[i].AllowDBNull)
                            {
                                base.DisplayLayout.Bands[0].Columns[dataTable.Columns[i].ColumnName].Tag = "M";
                            }
                            else
                            {
                                base.DisplayLayout.Bands[0].Columns[dataTable.Columns[i].ColumnName].Tag = "N";
                            }
                        }
                    }
                    for (int j = 0; j < dataTable.PrimaryKey.Length; j++)
                    {
                        base.DisplayLayout.Bands[0].Columns[dataTable.PrimaryKey[j].ColumnName].CellAppearance.BackColor = Color.WhiteSmoke;
                        base.DisplayLayout.Bands[0].Columns[dataTable.PrimaryKey[j].ColumnName].Tag = "K";
                    }
                }
                if (!base.DesignMode)
                {
                    SetContextMenuLang();
                }
                if (_sColumRowMerge != null)
                {
                    for (int k = 0; k < _sColumRowMerge.Length; k++)
                    {
                        e.Layout.Bands[0].Columns[_sColumRowMerge[k]].MergedCellStyle = MergedCellStyle.Always;
                        e.Layout.Bands[0].Columns[_sColumRowMerge[k]].MergedCellEvaluator = new MergedGroupCellEvaluator(_sColumRowMerge);
                    }
                }
                if (base.Rows.Count > 0 && AutoResizeColumn)
                {
                }
            }
            catch
            {
            }
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            try
            {
                UIElement lastElementEntered = base.DisplayLayout.UIElement.LastElementEntered;
                if (lastElementEntered.GetType().Name == "RowSelectorHeaderUIElement" && lastElementEntered.Rect.X < 42)
                {
                    object mdiChild = getMdiChild(this);
                    if (mdiChild.GetType().Name.Equals("MdiClient"))
                    {
                        MethodInfo method = ((MdiClient)mdiChild).Parent.GetType().GetMethod("setColumnChooser");
                        method.Invoke(((MdiClient)mdiChild).Parent, new object[1]
                        {
                            this
                        });
                    }
                    else
                    {
                        MethodInfo method2 = mdiChild.GetType().GetMethod("setColumnChooserPOP");
                        method2.Invoke(mdiChild, new object[2]
                        {
                            this,
                            mdiChild
                        });
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected override void OnAfterRowActivate()
        {
            //base.OnAfterRowActivate();
            if (base.ActiveRow.Band.Index != base.DisplayLayout.Bands.Count - 1)
            {
                base.ActiveRow.Activation = Activation.NoEdit;
            }
            else
            {
                try
                {
                    object obj = getMdiChild(this);
                    if (obj.GetType().Name.Equals("MdiClient"))
                    {
                        obj = ((MdiClient)getMdiChild(this)).MdiChildren[0];
                    }
                    MethodInfo method = obj.GetType().GetMethod("CanModifyCheck");
                    string a = (string)method.Invoke(obj, new object[1]
                    {
                        base.ActiveRow
                    });
                    if (a != "")
                    {
                        base.ActiveRow.Activation = Activation.NoEdit;
                    }
                }
                catch (Exception)
                {
                }
            }
        }


        protected override void OnAfterRowFilterChanged(AfterRowFilterChangedEventArgs e)
        {
            base.OnAfterRowFilterChanged(e);
            if (bSummaries)
            {
                if (SummaryRow != null)
                {
                    SummaryRow.Delete(displayPrompt: false);
                    SummaryRow = null;
                }
                if (this.AfterDeleRowFilterChanged != null)
                {
                    this.AfterDeleRowFilterChanged(this, e);
                }
            }
        }
        #endregion

        #region 그리드 이벤트 처리
        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            EmbeddableEditorBase embeddableEditorBase = sender as EmbeddableEditorBase;
            if (embeddableEditorBase != null)
            {
                sValue1 = $"{embeddableEditorBase.Value}";
                sValue2 = embeddableEditorBase.CurrentEditText;
            }
        }

        private void Grid_BeforeExitEditMode(object sender, Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs e)
        {
            EmbeddableEditorBase embeddableEditorBase = sender as EmbeddableEditorBase;
            if (embeddableEditorBase != null && sValue1 != sValue2)
            {
                embeddableEditorBase.Value = sValue2;
            }
        }

        private void Grid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (_bEnterNext && base.ActiveCell != null && !sListHasPopupColumn.Contains(base.ActiveCell.Column.Key) && base.ActiveCell.IsInEditMode)
                {
                    PerformAction(UltraGridAction.ExitEditMode);
                    int num = base.ActiveCell.Row.Index + 1;
                    if (base.Rows.Count > num)
                    {
                        base.ActiveCell = base.Rows[num].Cells[base.ActiveCell.Column.Index];
                        if ((base.ActiveCell.Activation == Activation.AllowEdit && base.ActiveCell.IgnoreRowColActivation) || base.ActiveCell.Column.CellActivation == Activation.AllowEdit)
                        {
                            if (base.ActiveCell.ValueList != null)
                            {
                                PerformAction(UltraGridAction.EnterEditModeAndDropdown);
                            }
                            else
                            {
                                PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                    }
                }
            }
            else if (e.KeyChar == '\b' && _bDeleteBtn && base.ActiveCell != null && (base.ActiveCell.Column.CellActivation == Activation.AllowEdit || (base.ActiveCell.IgnoreRowColActivation && base.ActiveCell.Activation == Activation.AllowEdit)) && (base.ActiveCell.Column.ValueList != null || base.ActiveCell.ValueList != null))
            {
                base.ActiveCell.SetValue(null, storeInUndoStatck: true);
                if (base.ActiveCell.Column.ValueList != null)
                {
                    base.ActiveCell.Column.ValueList.SelectedItemIndex = -1;
                }
                else
                {
                    base.ActiveCell.ValueList.SelectedItemIndex = -1;
                }
            }
            if (this.KeyPressed != null)
            {
                this.KeyPressed(this, e);
            }
        }
        #endregion

        #region 행 설정 관련
        public void SetRow()
        {
            if (base.ActiveRow != null)
            {
                int count = base.DisplayLayout.Bands[0].Columns.Count;
                column = new string[count];
                for (int i = 0; i < count; i++)
                {
                    column[i] = base.ActiveRow.Cells[i].Text;
                }
            }
        }

        public void GetRow()
        {
            CellMerge();
            if (column == null)
            {
                return;
            }
            int count = base.DisplayLayout.Bands[0].Columns.Count;
            int num = 0;
            int index = 0;
            int i = 0;
            int num2;//= 0;
            for (; i < base.Rows.Count; i++)
            {
                num2 = 0;
                for (int j = 0; j < count; j++)
                {
                    if (base.Rows[i].Cells[j].Value != DBNull.Value && base.Rows[i].Cells[j].Text == column[j])
                    {
                        num2++;
                        if (count == num2)
                        {
                            base.Rows[i].Activated = true;
                            column = null;
                            return;
                        }
                    }
                    if (j == count - 1 && num < num2)
                    {
                        num = num2;
                        index = i;
                    }
                }
            }
            base.Rows[index].Activated = true;
            column = null;
        }
        #endregion

        #region Merge
        private void SetMerge(string tag)
        {
            if (!(tag == ""))
            {
                string[] array = tag.Split('|');
                int num = Convert.ToInt32(array[2]);
                if (array[0] == "M")
                {
                    string reference = aMergeList[num];
                    reference = reference + "," + array[1];
                }
                else
                {
                    aMergeList[num] = aMergeList[num].Replace(array[1], "");
                }
                CellMerge(num);
            }
        }

        private void CellMerge()
        {
            CellMerge(0);
        }

        private void CellMerge(int bandidx)
        {
            try
            {
                foreach (UltraGridColumn column2 in base.DisplayLayout.Bands[bandidx].Columns)
                {
                    column2.MergedCellStyle = MergedCellStyle.Default;
                }
                if (!(aMergeList[bandidx] == string.Empty))
                {
                    string[] array = aMergeList[bandidx].Split(',');
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] != "")
                        {
                            base.DisplayLayout.Bands[bandidx].Columns[array[i]].MergedCellContentArea = MergedCellContentArea.VisibleRect;
                            base.DisplayLayout.Bands[bandidx].Columns[array[i]].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
                            base.DisplayLayout.Bands[bandidx].Columns[array[i]].MergedCellStyle = MergedCellStyle.Always;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public void SetCellMerge(string cols, int bandidx = 0)
        {
            try
            {
                string[] array = cols.Split(',');
                string[] array2 = array;
                foreach (string text in array2)
                {
                    if (text != "")
                    {
                        base.DisplayLayout.Bands[bandidx].Columns[text].MergedCellContentArea = MergedCellContentArea.VisibleRect;
                        base.DisplayLayout.Bands[bandidx].Columns[text].MergedCellEvaluationType = MergedCellEvaluationType.MergeSameValue;
                        base.DisplayLayout.Bands[bandidx].Columns[text].MergedCellStyle = MergedCellStyle.Always;
                    }
                }
            }
            catch
            {
            }
        }
        #endregion

        #region 고정 및 숨김 처리 관련
        private void SetFixed(string tag)
        {
            if (!(tag == ""))
            {
                string[] array = tag.Split('|');
                int num = Convert.ToInt32(array[2]);
                if (array[0] == "M")
                {
                    base.DisplayLayout.Bands[num].Columns[array[1]].Header.Fixed = true;
                    string reference = aFixedList[num];
                    reference = reference + "," + array[1];
                }
                else
                {
                    base.DisplayLayout.Bands[num].Columns[array[1]].Header.Fixed = false;
                    aFixedList[num] = aFixedList[num].Replace("," + array[1], "");
                }
            }
        }

        private void SetHide(string tag)
        {
            if (!(tag == ""))
            {
                //string[] array = tag.Split('|');
                //int num = Convert.ToInt32(array[2]);
                //if (array[0] == "M")
                //{
                //    string reference = aMergeList[num];
                //    reference = reference + "," + array[1];
                //}
                //else
                //{
                //    aMergeList[num] = aMergeList[num].Replace(array[1], "");
                //}
                //CellMerge(num);

            }
        }
        #endregion

        #region 팝업 메뉴 처리
        private void cmsMenu_Opening(object sender, CancelEventArgs e)
        {
            if (cmsMenu.Items.Count == 0)
            {
                return;
            }
            UIElement lastElementEntered = base.DisplayLayout.UIElement.LastElementEntered;
            Infragistics.Win.UltraWinGrid.ColumnHeader columnHeader = lastElementEntered.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader)) as Infragistics.Win.UltraWinGrid.ColumnHeader;
            if (columnHeader != null)
            {
                cmsMenu.Items["mnuSubGrid"].Visible = true;
                cmsMenu.Items["toolStripSeparator1"].Visible = true;
                cmsMenu.Items["mnuMerge"].Visible = true;
                cmsMenu.Items["mnuFixed"].Visible = true;
                string key = columnHeader.Column.Key;
                int index = columnHeader.Band.Index;
                cmsMenu.Items["mnuSubGrid"].Enabled = true;
                if (index == 5)
                {
                    cmsMenu.Items["mnuSubGrid"].Text = Common.getLangText("5단계 제한");
                    cmsMenu.Items["mnuSubGrid"].Enabled = false;
                }
                else
                {
                    for (int num = index - 1; num >= 0; num--)
                    {
                        if (asubgridColumn[num].IndexOf(key) != -1)
                        {
                            cmsMenu.Items["mnuSubGrid"].Text = Common.getLangText("상위그룹");
                            cmsMenu.Items["mnuSubGrid"].Enabled = false;
                            break;
                        }
                    }
                }

                if (cmsMenu.Items["mnuSubGrid"].Enabled)
                {
                    int num2 = asubgridColumn[index].IndexOf(key);
                    if (num2 != -1)
                    {
                        if (asubgridColumn[index].Count == 1)
                        {
                            cmsMenu.Items["mnuSubGrid"].Text = Common.getLangText("그룹해제");
                        }
                        else
                        {
                            cmsMenu.Items["mnuSubGrid"].Text = Common.getLangText("그룹제외");
                        }
                        cmsMenu.Items["mnuSubGrid"].Tag = "C|" + key + "|" + index.ToString();
                    }
                    else
                    {
                        cmsMenu.Items["mnuSubGrid"].Text = Common.getLangText("그룹모음");
                        cmsMenu.Items["mnuSubGrid"].Tag = "M|" + key + "|" + index.ToString();
                    }
                }

                if (aMergeList[index].IndexOf(key.ToUpper()) == -1)
                {
                    cmsMenu.Items["mnuMerge"].Text = Common.getLangText("셀 병합");
                    cmsMenu.Items["mnuMerge"].Tag = "M|" + key + "|" + index.ToString();
                }
                else
                {
                    cmsMenu.Items["mnuMerge"].Text = Common.getLangText("병합해제");
                    cmsMenu.Items["mnuMerge"].Tag = "C|" + key + "|" + index.ToString();
                }

                if (!base.DisplayLayout.Bands[index].Columns[key].Header.Fixed)
                {
                    cmsMenu.Items["mnuFixed"].Text = Common.getLangText("컬럼고정");
                    cmsMenu.Items["mnuFixed"].Tag = "M|" + key + "|" + index.ToString();
                }
                else
                {
                    cmsMenu.Items["mnuFixed"].Text = Common.getLangText("고정해제");
                    cmsMenu.Items["mnuFixed"].Tag = "C|" + key + "|" + index.ToString();
                }

                cmsMenu.Items["mnuRename"].Tag = key;

                cmsMenu.Items["toolStripSeparator1"].Visible = false;
                cmsMenu.Items["mnuCopy"].Visible = false;
                cmsMenu.Items["mnuPaste"].Visible = false;
                cmsMenu.Items["mnuCut"].Visible = false;
                cmsMenu.Items["mnuPartSum"].Visible = false;
            }
            else
            {
                cmsMenu.Items["mnuCopy"].Visible = true;
                cmsMenu.Items["mnuPaste"].Visible = true;
                cmsMenu.Items["mnuCut"].Visible = true;
                cmsMenu.Items["mnuPartSum"].Visible = true;
                cmsMenu.Items["mnuSubGrid"].Visible = false;
                cmsMenu.Items["toolStripSeparator1"].Visible = false;
                cmsMenu.Items["mnuMerge"].Visible = false;
                cmsMenu.Items["mnuFixed"].Visible = false;
            }
            if (base.DisplayLayout.Override.AllowRowFiltering == DefaultableBoolean.True)
            {
                cmsMenu.Items["mnuFilter"].Text = Common.getLangText("필터해제");
            }
            else
            {
                cmsMenu.Items["mnuFilter"].Text = Common.getLangText("필터");
            }
        }

        private void cmsMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "mnuInsert":
                    InsertRow();
                    break;
                case "mnuDelete":
                    DeleteRow();
                    break;
                case "mnuExcelExporter":
                    ExportExcel();
                    break;
                case "mnuExcelImport":
                    ImportExcel();
                    break;
                case "mnuPDFExporter":
                    ExportPDF();
                    break;
                case "mnuCopy":
                    PerformAction(UltraGridAction.Copy);
                    break;
                case "mnuPaste":
                    PerformAction(UltraGridAction.Paste);
                    break;
                case "mnuCut":
                    PerformAction(UltraGridAction.Cut);
                    break;
                case "mnuSubGrid":
                    SubGrid(e.ClickedItem.Tag.ToString());
                    break;
                case "mnuMerge":
                    SetMerge(e.ClickedItem.Tag.ToString());
                    break;
                case "mnuFixed":
                    SetFixed(e.ClickedItem.Tag.ToString());
                    break;
                case "mnuReport":
                    Reporting();
                    break;
                case "mnuFilter":
                    SetFilter();
                    break;
                case "mnuPartSum":
                    partialSum();
                    break;
                case "mnuRename":
                    RenameColumn(CModule.ToString(e.ClickedItem.Tag));
                    break;
                case "mnuInit":
                    GridUserSetInit();
                    break;
                case "mnuCustom":
                    GridPopupOpen();
                    break;
            }
        }

        private void RenameColumn(string sTag)
        {
            if (sTag != "")
            {
                string sColName = this.Columns[sTag].Header.Caption;

                TwoTextBoxForm tForm = new TwoTextBoxForm("컬럼 이름 바꾸기", TwoTextBoxForm.DialogType.YESNO);

                tForm.txtBox1.Text = sColName;
                tForm.txtBox2.Text = "";
                tForm.lblTitle1.Text = "원래 이름";
                tForm.lblTitle2.Text = "바꿀 이름";

                if (DialogResult.OK == tForm.ShowDialog())
                {
                    string sName = tForm.txtBox2.Text.Trim();

                    string sNotAllow = "|^,";

                    foreach (char c in sNotAllow)
                    {
                        if (sName.Contains(c.ToString()))
                        {
                            MessageBox.Show("[ | ^ , ] 는 사용할 수 없는 문자열입니다.");
                            return;
                        }
                    }

                    this.Columns[sTag].Header.Caption = sName;
                }
            }
        }
        #endregion

        #region SubGrid - Tree 형 그리드로 변형
        private void SubGrid()
        {
            SubGrid("");
        }

        private void SubGrid(string tag)
        {
            try
            {
                if (!(tag == "") || asubgridColumn[0].Count != 0)
                {
                    ClearSummary();
                    int num = 0;
                    string text = "";
                    if (tag != "")
                    {
                        string[] array = tag.ToString().Split('|');
                        num = Convert.ToInt32(array[2]);
                        text = array[1];
                    }
                    else
                    {
                        for (int num2 = asubgridColumn.Length - 1; num2 > 0; num2--)
                        {
                            if (asubgridColumn[num2].Count > 0)
                            {
                                num = num2;
                                break;
                            }
                        }
                    }
                    if (text != "")
                    {
                        int num3 = asubgridColumn[num].IndexOf(text);
                        if (num3 != -1)
                        {
                            base.DisplayLayout.Bands[num].Columns[text].Header.Fixed = false;
                            asubgridColumn[num].RemoveAt(num3);
                            base.DisplayLayout.Bands[num].Columns[text].Header.Appearance.ForeColor = Color.White;
                            if (asubgridColumn[num].Count == 0 && num > 0)
                            {
                                num--;
                            }
                        }
                        else
                        {
                            asubgridColumn[num].Add(text);
                            base.DisplayLayout.Bands[num].Columns[text].Header.Appearance.ForeColor = Color.Yellow;
                        }
                        for (int i = num + 1; i < asubgridColumn.Length; i++)
                        {
                            asubgridColumn[i].Clear();
                        }
                    }
                    DataSet dataSet = null;
                    DataTable dataTable = null;
                    if (asubgridColumn[0].Count == 0)
                    {
                        try
                        {
                            dataTable = ((DataSet)base.DataSource).Tables[((DataSet)base.DataSource).Tables.Count - 1].Copy();
                            dataTable.TableName = "BANDX";
                            dataSet = new DataSet();
                            dataSet.Tables.Add(dataTable);
                            base.DataSource = dataSet;
                            DataBind();
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        string text2 = "";
                        for (int j = 0; j <= num; j++)
                        {
                            for (int k = 0; k < asubgridColumn[j].Count; k++)
                            {
                                text2 = text2 + asubgridColumn[j][k].ToString() + ",";
                            }
                        }
                        text2 = text2.Substring(0, text2.Length - 1);
                        if (base.DataSource.GetType().Name.ToUpper() == "DATATABLE")
                        {
                            ((DataTable)base.DataSource).DefaultView.Sort = text2;
                            dataTable = ((DataTable)base.DataSource).DefaultView.ToTable();
                        }
                        else
                        {
                            dataSet = (DataSet)base.DataSource;
                            int index = dataSet.Tables.Count - 1;
                            dataSet.Tables[index].DefaultView.Sort = text2;
                            dataTable = dataSet.Tables[index].DefaultView.ToTable();
                            dataTable.TableName = "BANDX";
                        }
                        ArrayList arrayList = new ArrayList();
                        foreach (DataColumn column2 in dataTable.Columns)
                        {
                            switch (column2.DataType.Name)
                            {
                                case "Decimal":
                                case "Double":
                                case "Int16":
                                case "Int32":
                                case "Int64":
                                case "UInt16":
                                case "UInt32":
                                case "UInt64":
                                    arrayList.Add(column2.ColumnName);
                                    break;
                            }
                        }
                        dataSet = new DataSet();
                        ArrayList arrayList2 = new ArrayList();
                        for (int l = 0; l <= num; l++)
                        {
                            foreach (string item in asubgridColumn[l])
                            {
                                arrayList2.Add(item);
                            }
                            DataTable dataTable2 = dataTable.Clone();
                            dataTable2.TableName = "BAND" + l.ToString();
                            int num4 = 0;
                            DataRow dataRow = null;
                            string a = "*^&";
                            foreach (DataRow row in dataTable.Rows)
                            {
                                num4++;
                                string text3 = "";
                                foreach (string item2 in arrayList2)
                                {
                                    text3 = text3 + row[item2] + "|";
                                }
                                if (a != text3)
                                {
                                    if (a != "*^&")
                                    {
                                        dataTable2.Rows.Add(dataRow);
                                    }
                                    num4 = 0;
                                    a = text3;
                                    dataRow = dataTable2.NewRow();
                                    foreach (object item3 in arrayList)
                                    {
                                        dataRow[item3.ToString()] = 0;
                                    }
                                    foreach (string item4 in arrayList2)
                                    {
                                        dataRow[item4] = row[item4];
                                    }
                                }
                                foreach (object item5 in arrayList)
                                {
                                    if (arrayList2.IndexOf(item5.ToString()) == -1)
                                    {
                                        switch (dataTable.Columns[item5.ToString()].DataType.Name)
                                        {
                                            case "Decimal":
                                                dataRow[item5.ToString()] = Convert.ToDecimal(dataRow[item5.ToString()]) + ((row[item5.ToString()].GetType().Name == "DBNull") ? 0m : Convert.ToDecimal(row[item5.ToString()]));
                                                break;
                                            case "Double":
                                                dataRow[item5.ToString()] = Convert.ToDouble(dataRow[item5.ToString()]) + ((row[item5.ToString()].GetType().Name == "DBNull") ? 0.0 : Convert.ToDouble(row[item5.ToString()]));
                                                break;
                                            case "Int16":
                                                dataRow[item5.ToString()] = Convert.ToInt16(dataRow[item5.ToString()]) + ((!(row[item5.ToString()].GetType().Name == "DBNull")) ? Convert.ToInt16(row[item5.ToString()]) : 0);
                                                break;
                                            case "Int32":
                                                dataRow[item5.ToString()] = Convert.ToInt32(dataRow[item5.ToString()]) + ((!(row[item5.ToString()].GetType().Name == "DBNull")) ? Convert.ToInt32(row[item5.ToString()]) : 0);
                                                break;
                                            case "Int64":
                                                dataRow[item5.ToString()] = Convert.ToInt64(dataRow[item5.ToString()]) + ((row[item5.ToString()].GetType().Name == "DBNull") ? 0 : Convert.ToInt64(row[item5.ToString()]));
                                                break;
                                            case "UInt16":
                                                dataRow[item5.ToString()] = Convert.ToUInt16(dataRow[item5.ToString()]) + ((!(row[item5.ToString()].GetType().Name == "DBNull")) ? Convert.ToUInt16(row[item5.ToString()]) : 0);
                                                break;
                                            case "UInt32":
                                                dataRow[item5.ToString()] = Convert.ToUInt32(dataRow[item5.ToString()]) + ((!(row[item5.ToString()].GetType().Name == "DBNull")) ? Convert.ToUInt32(row[item5.ToString()]) : 0);
                                                break;
                                            case "UInt64":
                                                dataRow[item5.ToString()] = Convert.ToUInt64(dataRow[item5.ToString()]) + ((row[item5.ToString()].GetType().Name == "DBNull") ? 0 : Convert.ToUInt64(row[item5.ToString()]));
                                                break;
                                        }
                                    }
                                }
                            }
                            dataTable2.Rows.Add(dataRow);
                            dataTable2.AcceptChanges();
                            dataSet.Tables.Add(dataTable2);
                        }
                        dataTable.AcceptChanges();
                        dataSet.Tables.Add(dataTable);
                        for (int m = 0; m < arrayList2.Count; m++)
                        {
                            base.DisplayLayout.Bands[0].Columns[arrayList2[m].ToString()].Header.VisiblePosition = m;
                        }
                        arrayList2.Clear();
                        dataSet.Relations.Clear();
                        for (int n = 0; n <= num; n++)
                        {
                            foreach (string item6 in asubgridColumn[n])
                            {
                                arrayList2.Add(item6);
                            }
                            DataColumn[] array2 = new DataColumn[arrayList2.Count];
                            DataColumn[] array3 = new DataColumn[arrayList2.Count];
                            for (int num5 = 0; num5 < arrayList2.Count; num5++)
                            {
                                string name = arrayList2[num5].ToString();
                                array2[num5] = dataSet.Tables[n].Columns[name];
                                array3[num5] = dataSet.Tables[n + 1].Columns[name];
                            }
                            dataSet.Relations.Add("Relation" + n.ToString(), array2, array3, createConstraints: false);
                        }
                        base.DataSource = dataSet;
                        DataBind();
                        int num6 = 0;
                        string key = base.DisplayLayout.Bands[0].Columns[base.DisplayLayout.Bands[0].Columns.Count - 1].Key;
                        arrayList2.Clear();
                        for (int num7 = 0; num7 <= num; num7++)
                        {
                            foreach (UltraGridColumn column3 in base.DisplayLayout.Bands[num7].Columns)
                            {
                                column3.Header.Appearance.ForeColor = Color.White;
                            }
                            foreach (UltraGridColumn column4 in base.DisplayLayout.Bands[num7 + 1].Columns)
                            {
                                column4.Header.Appearance.ForeColor = Color.White;
                            }
                            foreach (string item7 in asubgridColumn[num7])
                            {
                                arrayList2.Add(item7);
                            }
                            for (int num8 = 0; num8 < arrayList2.Count; num8++)
                            {
                                string key2 = arrayList2[num8].ToString();
                                base.DisplayLayout.Bands[num7].Columns[key2].Header.Appearance.ForeColor = Color.Yellow;
                                base.DisplayLayout.Bands[num7].Columns[key2].Header.Fixed = true;
                                base.DisplayLayout.Bands[num7 + 1].Columns[key2].Header.Appearance.ForeColor = Color.Yellow;
                                base.DisplayLayout.Bands[num7].Columns[key2].Header.Fixed = true;
                            }
                            num6 = num7 + 1;
                            foreach (UltraGridColumn column5 in base.DisplayLayout.Bands[0].Columns)
                            {
                                try
                                {
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].Header.Caption = column5.Header.Caption;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].Header.VisiblePosition = column5.Header.VisiblePosition;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].Header.Appearance.TextHAlign = column5.Header.Appearance.TextHAlign;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].CellAppearance.TextHAlign = column5.CellAppearance.TextHAlign;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].Hidden = column5.Hidden;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].Style = column5.Style;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].MaskInput = column5.MaskInput;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].MaxLength = column5.MaxLength;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].Format = column5.Format;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].MaxValue = column5.MaxValue;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].MinValue = column5.MinValue;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].ButtonDisplayStyle = column5.ButtonDisplayStyle;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].Header.CheckBoxVisibility = column5.Header.CheckBoxVisibility;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].AutoSizeMode = column5.AutoSizeMode;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].MergedCellStyle = column5.MergedCellStyle;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].MaskClipMode = column5.MaskClipMode;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].MaskDisplayMode = column5.MaskDisplayMode;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].MaskDataMode = column5.MaskDataMode;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].CellActivation = column5.CellActivation;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].ButtonDisplayStyle = column5.ButtonDisplayStyle;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].ValueList = column5.ValueList;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].Tag = column5.Tag;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].Level = column5.Level;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].ImeMode = column5.ImeMode;
                                    base.DisplayLayout.Bands[num6].Columns[column5.Key].ColSpan = column5.ColSpan;
                                    if (arrayList2.IndexOf(column5.Key) != -1)
                                    {
                                        base.DisplayLayout.Bands[num6].Columns[column5.Key].Hidden = true;
                                    }
                                }
                                catch (Exception)
                                {
                                }
                            }
                            if (num == num7)
                            {
                                base.DisplayLayout.Bands[num7 + 1].Columns[key].PerformAutoResize(PerformAutoSizeType.AllRowsInBand);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region 리포트 생성 
        private void Reporting()
        {
            Cursor = Cursors.WaitCursor;
            rpt = new Report(null, null, false, "ReportPage_Print");
            int num = 0;
            foreach (UltraGridColumn column2 in base.DisplayLayout.Bands[0].Columns)
            {
                if (!column2.Hidden)
                {
                    num += column2.Width;
                }
            }
            if (num > rpt.ReportWidth)
            {
                rpt.PrintDocument.DefaultPageSettings.Landscape = true;
            }
            rpt.ParentControl = this;
            rpt.ReportHeightFooter = 20;
            rows = 0;
            rpt.BeginReport();
            Cursor = Cursors.Default;
        }

        public void ReportPage_Print(PrintPageEventArgs e)
        {
            int num = (int)((double)rpt.ReportTextSize("1", rpt.ReportFont).Height * 0.2);
            rpt.ReportPadding = new Padding(2, num, 2, num);
            if (rpt.ReportPageCurrent <= 1)
            {
                rows = 0;
            }
            drawHeader(rpt);
            bool hasMorePages = drawData(rpt);
            rpt.ReportCurrentY = rpt.ReportHeightHeader + rpt.ReportHeightSection;
            drawFooter(rpt);
            e.HasMorePages = hasMorePages;
        }

        private void drawHeader(Report rpt)
        {
            rpt.ReportDrawText(Text, rpt.ReportWidth, StringAlignment.Center);
            rpt.ReportLineFeed();
            int num = -1;
            foreach (UltraGridColumn column2 in base.DisplayLayout.Bands[0].Columns)
            {
                if (!column2.Hidden && column2.Width > 0)
                {
                    aColwidth[++num] = column2.Width;
                }
            }
            rpt.ReportAutoColSize(ref aColwidth);
            Brush bgbrush = new SolidBrush(Color.LightGray);
            num = -1;
            foreach (UltraGridColumn column3 in base.DisplayLayout.Bands[0].Columns)
            {
                if (!column3.Hidden && column3.Width > 0)
                {
                    if (rpt.ReportCurrentX > 0)
                    {
                        int num2 = --rpt.ReportCurrentX;
                        rpt.ReportDrawText(column3.Header.Caption, aColwidth[++num] + 1, StringAlignment.Center, true, true, null, null, bgbrush, rpt.ReportPen);
                    }
                    else
                    {
                        rpt.ReportDrawText(column3.Header.Caption, aColwidth[++num], StringAlignment.Center, true, true, null, null, bgbrush, rpt.ReportPen);
                    }
                }
            }
            rpt.ReportLineFeed();
            rpt.ReportLineFeed(1);
        }

        private void drawFooter(Report rpt)
        {
            rpt.ReportLineFeed(5);
            rpt.ReportDrawText(rpt.ReportPageCurrent.ToString(), rpt.ReportWidth, StringAlignment.Center);
            rpt.ReportDrawRectangle(new Point(0, 0), new Size(rpt.ReportWidth, rpt.ReportHeight));
        }

        private bool drawData(Report rpt)
        {
            DataTable dataTable;
            if (base.DataSource.GetType().Name.ToUpper() == "DATATABLE")
            {
                dataTable = (DataTable)base.DataSource;
            }
            else
            {
                int index = base.DisplayLayout.Bands.Count - 1;
                dataTable = ((DataSet)base.DataSource).Tables[index];
            }
            Pen pen = new Pen(Color.LightGray, 1f);
            for (int i = rows; i < dataTable.Rows.Count; i++)
            {
                int num2;
                if (rpt.ReportChkPage)
                {
                    int num = -1;
                    foreach (UltraGridColumn column2 in base.DisplayLayout.Bands[0].Columns)
                    {
                        if (!column2.Hidden && column2.Width > 0)
                        {
                            if (rpt.ReportCurrentX > 0)
                            {
                                num2 = --rpt.ReportCurrentX;
                                rpt.ReportDrawText(dataTable.Rows[i][column2.Key].ToString(), aColwidth[++num] + 1, StringAlignment.Near, true, true, null, null, null, pen);
                            }
                            else
                            {
                                rpt.ReportDrawText(dataTable.Rows[i][column2.Key].ToString(), aColwidth[++num], StringAlignment.Near, true, true, null, null, null, pen);
                            }
                        }
                    }
                }
                rows++;
                if (!rpt.ReportLineFeed())
                {
                    if (rows < dataTable.Rows.Count)
                    {
                        return true;
                    }
                    return false;
                }
                //num2 = --rpt.ReportCurrentY;
            }
            return false;
        }
        #endregion

        #region 부분합
        private void partialSum()
        {
            if (base.Selected.Rows.Count == 0)
            {
                MessageBox.Show(Common.getLangText("선택된 Row가 없습니다.", "MSG"));
                return;
            }
            DataTable dataTable;
            if (base.DataSource.GetType().Name.ToUpper() == "DATATABLE")
            {
                dataTable = (DataTable)base.DataSource;
            }
            else
            {
                int index = base.DisplayLayout.Bands.Count - 1;
                dataTable = ((DataSet)base.DataSource).Tables[index];
            }
            DataTable dataTable2 = new DataTable();
            dataTable2.Columns.Add("COLNAME", typeof(string));
            dataTable2.Columns.Add("SUM", typeof(string));
            dataTable2.Columns.Add("AVE", typeof(string));
            dataTable2.Columns.Add("COL", typeof(string));
            dataTable2.Columns.Add("ISUM", typeof(double));
            foreach (DataColumn column2 in dataTable.Columns)
            {
                switch (column2.DataType.Name)
                {
                    case "Decimal":
                    case "Double":
                    case "Int16":
                    case "Int32":
                    case "Int64":
                    case "UInt16":
                    case "UInt32":
                    case "UInt64":
                        {
                            DataRow dataRow = dataTable2.NewRow();
                            dataRow["col"] = column2.ColumnName;
                            dataRow["colName"] = base.DisplayLayout.Bands[0].Columns[column2.ColumnName].Header.Caption;
                            dataRow["isum"] = 0;
                            dataTable2.Rows.Add(dataRow);
                            break;
                        }
                }
            }
            if (dataTable2.Rows.Count == 0)
            {
                MessageBox.Show(Common.getLangText("숫자 컬럼이 없습니다.", "MSG"));
                return;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataRow row2 in dataTable2.Rows)
                {
                    string columnName = row2["col"].ToString();
                    if (row[columnName].GetType().Name != "DBNull" && row[columnName].ToString() != "")
                    {
                        row2["isum"] = Convert.ToDouble(row2["isum"]) + Convert.ToDouble(row[columnName]);
                    }
                }
            }
            int count = base.Selected.Rows.Count;
            foreach (DataRow row3 in dataTable2.Rows)
            {
                row3["Sum"] = string.Format("{0:N2}", Convert.ToDouble(row3["isum"]));
                row3["Ave"] = string.Format("{0:N2}", Convert.ToDouble(row3["isum"]) / (double)count);
            }
            partialSumForm partialSumForm = new partialSumForm();
            partialSumForm.dataSource = dataTable2;
            partialSumForm.Msg = string.Format(Common.getLangText("{0:N0}개의 row"), count);
            partialSumForm.ShowDialog();
        }
        #endregion

        #region 행에 대한 오류 발생시 처리
        public void SetRowError(DataRow dr, string errMsg, string RSCODE = "")
        {
            if (dr.RowState == DataRowState.Deleted)
            {
                return;
            }
            DataTable dataTable = null;
            if (base.DataSource.GetType().Name.ToUpper() == "DATATABLE")
            {
                dataTable = (DataTable)base.DataSource;
            }
            else
            {
                int index = ((DataSet)base.DataSource).Tables.Count - 1;
                dataTable = ((DataSet)base.DataSource).Tables[index];
            }
            bool flag;//= false;
            int num = 0;
            while (true)
            {
                if (num >= dataTable.Rows.Count)
                {
                    return;
                }
                if (dataTable.Rows[num].RowState != DataRowState.Deleted)
                {
                    flag = true;
                    if (Columns.Exists("ROWSEQ"))
                    {
                        if (Convert.ToInt32(dataTable.Rows[num]["ROWSEQ"]) != Convert.ToInt32(dr["ROWSEQ"]))
                        {
                            flag = false;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dr.ItemArray.Length; i++)
                        {
                            if (dr.ItemArray[i].GetType().Name.ToUpper() == "DBNULL" && dataTable.Rows[num].ItemArray[i].GetType().Name.ToUpper() != "DBNULL")
                            {
                                flag = false;
                                break;
                            }
                            if (dr.ItemArray[i].GetType().Name.ToUpper() != "DBNULL" && dataTable.Rows[num].ItemArray[i].GetType().Name.ToUpper() == "DBNULL")
                            {
                                flag = false;
                                break;
                            }
                            if (dr.ItemArray[i].ToString() != dataTable.Rows[num].ItemArray[i].ToString())
                            {
                                flag = false;
                                break;
                            }
                        }
                    }
                    if (flag)
                    {
                        break;
                    }
                }
                num++;
            }
            if (RSCODE == "S")
            {
                dataTable.Rows[num].ClearErrors();
            }
            else
            {
                dataTable.Rows[num].RowError = "[" + ((dr.RowState == DataRowState.Added) ? "A" : "M") + "] " + errMsg;
            }
        }
        #endregion

        #region Cell 에 값 삽입
        public void SetCellValue(DataRow dr, string colnm, object value)
        {
            DataTable dataTable = null;
            if (base.DataSource.GetType().Name.ToUpper() == "DATATABLE")
            {
                dataTable = (DataTable)base.DataSource;
            }
            else
            {
                int index = ((DataSet)base.DataSource).Tables.Count - 1;
                dataTable = ((DataSet)base.DataSource).Tables[index];
            }
            bool flag;//= false;
            int num = 0;
            while (true)
            {
                if (num >= dataTable.Rows.Count)
                {
                    return;
                }
                if (dataTable.Rows[num].RowState != DataRowState.Deleted)
                {
                    flag = true;
                    if (Columns.Exists("ROWSEQ"))
                    {
                        if (Convert.ToInt32(dataTable.Rows[num]["ROWSEQ"]) != Convert.ToInt32(dr["ROWSEQ"]))
                        {
                            flag = false;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dr.ItemArray.Length; i++)
                        {
                            if (dr.ItemArray[i].GetType().Name.ToUpper() == "DBNULL" && dataTable.Rows[num].ItemArray[i].GetType().Name.ToUpper() != "DBNULL")
                            {
                                flag = false;
                                break;
                            }
                            if (dr.ItemArray[i].GetType().Name.ToUpper() != "DBNULL" && dataTable.Rows[num].ItemArray[i].GetType().Name.ToUpper() == "DBNULL")
                            {
                                flag = false;
                                break;
                            }
                            if (dr.ItemArray[i].ToString() != dataTable.Rows[num].ItemArray[i].ToString())
                            {
                                flag = false;
                                break;
                            }
                        }
                    }
                    if (flag)
                    {
                        break;
                    }
                }
                num++;
            }
            dataTable.Rows[num][colnm] = value;
        }
        #endregion

        #region 데이터 처리 관련
        public void SetAcceptChanges(string Keys = "")
        {
            DataTable dataTable = null;
            if (base.DataSource.GetType().Name.ToUpper() == "DATATABLE")
            {
                dataTable = (DataTable)base.DataSource;
            }
            else
            {
                int index = ((DataSet)base.DataSource).Tables.Count - 1;
                dataTable = ((DataSet)base.DataSource).Tables[index];
            }
            dataTable.AcceptChanges();
            string[] array = Keys.Split(',');
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i].RowError.StartsWith("[A"))
                {
                    dataTable.Rows[i].SetAdded();
                }
                else if (dataTable.Rows[i].RowError.StartsWith("[M"))
                {
                    dataTable.Rows[i].SetModified();
                }
                else if (dataTable.Rows[i].RowError.StartsWith("[D"))
                {
                    dataTable.Rows[i].ClearErrors();
                }
                else
                {
                    if (!(Keys != "") || !(dataTable.Rows[i].RowError == ""))
                    {
                        continue;
                    }
                    string[] array2 = array;
                    foreach (string text in array2)
                    {
                        if (text != "")
                        {
                            try
                            {
                                base.Rows[i].Cells[text].Activation = Activation.NoEdit;
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }
        }

        public DataTable chkChange()
        {
            DataTable dataTable = null;
            if (base.DataSource.GetType().Name.ToUpper() == "DATATABLE")
            {
                dataTable = (DataTable)base.DataSource;
            }
            else
            {
                int index = ((DataSet)base.DataSource).Tables.Count - 1;
                dataTable = ((DataSet)base.DataSource).Tables[index];
            }
            UpdateData();
            return dataTable.GetChanges();
        }
        #endregion

        #region 행 처리 관련
        public int GetLastRow()
        {
            return ++lastRowSeq;
        }

        public DataRow GetDataRow(UltraGridRow actrow = null)
        {
            if (actrow == null)
            {
                actrow = base.ActiveRow;
            }
            return (actrow.ListObject as DataRowView).Row;
        }

        public void SetNewRow(UltraGridRow actrow, DataRow newrow)
        {
            for (int i = 0; i < actrow.Band.Index; i++)
            {
                foreach (string item in asubgridColumn[i])
                {
                    newrow[item] = actrow.Cells[item].Value;
                }
            }
        }

        public void SetDefaultValue(string columnName, object value, UltraGridRow ugr = null)
        {
            if (ugr == null)
            {
                ugr = base.ActiveRow;
            }
            if (ugr == null)
            {
                return;
            }
            columnName = columnName.ToUpper();
            if (base.DisplayLayout.Bands.Count > 1)
            {
                for (int i = 0; i < ugr.Band.Index; i++)
                {
                    foreach (string item in asubgridColumn[i])
                    {
                        if (item == columnName)
                        {
                            return;
                        }
                    }
                }
            }
            ugr.Cells[columnName].Value = value;
        }

        public UltraGridRow GetUltraGridRow(int dtrowpos)
        {
            if (base.DisplayLayout.Bands.Count == 1)
            {
                return base.Rows[dtrowpos];
            }
            gUGR = null;
            DataTable dataTable = null;
            if (base.DataSource.GetType().Name.ToUpper() == "DATATABLE")
            {
                dataTable = (DataTable)base.DataSource;
            }
            else
            {
                int index = ((DataSet)base.DataSource).Tables.Count - 1;
                dataTable = ((DataSet)base.DataSource).Tables[index];
            }
            string rowseq = dataTable.Rows[dtrowpos]["rowSeq"].ToString();
            for (int i = 0; i < base.Rows.Count; i++)
            {
                GetUltraGridRowR(base.Rows[i], rowseq);
                if (gUGR != null)
                {
                    return gUGR;
                }
            }
            return null;
        }

        private void GetUltraGridRowR(UltraGridRow ugr, string rowseq)
        {
            if (rowseq == ugr.Cells["ROWSEQ"].Value.ToString())
            {
                gUGR = ugr;
            }
            else
            {
                if (ugr.ChildBands == null)
                {
                    return;
                }
                for (int i = 0; i < ugr.ChildBands.Count; i++)
                {
                    if (ugr.ChildBands[i].Rows != null)
                    {
                        foreach (UltraGridRow row in ugr.ChildBands[i].Rows)
                        {
                            GetUltraGridRowR(row, rowseq);
                            if (gUGR != null)
                            {
                                return;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region 찾고자 하는 찾아서 컨트롤을 반환
        public static System.Windows.Forms.Control FindControl(ControlCollection controlcollection, string controlid)
        {
            if (controlcollection[controlid] != null)
            {
                return controlcollection[controlid];
            }
            for (int i = 0; i < controlcollection.Count; i++)
            {
                System.Windows.Forms.Control control = FindControl(controlcollection[i].Controls, controlid);
                if (control != null)
                {
                    return control;
                }
            }
            return null;
        }
        #endregion

        public void SetColumnRowMerge()
        {
        }

        #region 소멸자
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region InitializeComponent
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Grid));
            this.ugeExcelExporter = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(this.components);
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExcelImport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExcelExporter = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPDFExporter = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPartSum = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSubGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMerge = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFixed = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsMenu
            // 
            this.cmsMenu.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsert,
            this.mnuDelete,
            this.mnuExcelImport,
            this.mnuExcelExporter,
            this.mnuPDFExporter,
            this.mnuReport,
            this.mnuSeparator1,
            this.mnuCopy,
            this.mnuPaste,
            this.mnuCut,
            this.mnuPartSum,
            this.toolStripSeparator1,
            this.mnuSubGrid,
            this.mnuMerge,
            this.mnuFixed,
            this.mnuFilter,
            this.mnuRename,
            this.mnuInit,
            this.toolStripSeparator2,
            this.mnuCustom});
            this.cmsMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cmsMenu.Size = new System.Drawing.Size(192, 430);
            this.cmsMenu.Opening += new System.ComponentModel.CancelEventHandler(this.cmsMenu_Opening);
            this.cmsMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsMenu_ItemClicked);
            // 
            // mnuInsert
            // 
            this.mnuInsert.Image = ((System.Drawing.Image)(resources.GetObject("mnuInsert.Image")));
            this.mnuInsert.Name = "mnuInsert";
            this.mnuInsert.ShortcutKeyDisplayString = "(Ctrl+I)";
            this.mnuInsert.Size = new System.Drawing.Size(191, 24);
            this.mnuInsert.Text = "행추가";
            this.mnuInsert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuDelete.Image")));
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.ShortcutKeyDisplayString = "(Ctrl+D)";
            this.mnuDelete.Size = new System.Drawing.Size(191, 24);
            this.mnuDelete.Text = "행삭제";
            this.mnuDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mnuExcelImport
            // 
            this.mnuExcelImport.Name = "mnuExcelImport";
            this.mnuExcelImport.Size = new System.Drawing.Size(191, 24);
            this.mnuExcelImport.Text = "엑셀파일 읽기";
            // 
            // mnuExcelExporter
            // 
            this.mnuExcelExporter.Name = "mnuExcelExporter";
            this.mnuExcelExporter.Size = new System.Drawing.Size(191, 24);
            this.mnuExcelExporter.Text = "엑셀파일로 저장";
            // 
            // mnuPDFExporter
            // 
            this.mnuPDFExporter.Image = ((System.Drawing.Image)(resources.GetObject("mnuPDFExporter.Image")));
            this.mnuPDFExporter.Name = "mnuPDFExporter";
            this.mnuPDFExporter.Size = new System.Drawing.Size(191, 24);
            this.mnuPDFExporter.Text = "PDF파일로 저장";
            // 
            // mnuReport
            // 
            this.mnuReport.Name = "mnuReport";
            this.mnuReport.Size = new System.Drawing.Size(191, 24);
            this.mnuReport.Text = "인쇄(미리보기)";
            // 
            // mnuSeparator1
            // 
            this.mnuSeparator1.Name = "mnuSeparator1";
            this.mnuSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // mnuCopy
            // 
            this.mnuCopy.Image = ((System.Drawing.Image)(resources.GetObject("mnuCopy.Image")));
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.ShortcutKeyDisplayString = "(Ctrl+C)";
            this.mnuCopy.Size = new System.Drawing.Size(191, 24);
            this.mnuCopy.Text = "복사";
            this.mnuCopy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mnuPaste
            // 
            this.mnuPaste.Image = ((System.Drawing.Image)(resources.GetObject("mnuPaste.Image")));
            this.mnuPaste.Name = "mnuPaste";
            this.mnuPaste.ShortcutKeyDisplayString = "(Ctrl+P)";
            this.mnuPaste.Size = new System.Drawing.Size(191, 24);
            this.mnuPaste.Text = "붙여넣기";
            this.mnuPaste.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mnuCut
            // 
            this.mnuCut.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.mnuCut.Name = "mnuCut";
            this.mnuCut.ShortcutKeyDisplayString = "(Ctrl+X)";
            this.mnuCut.Size = new System.Drawing.Size(191, 24);
            this.mnuCut.Text = "잘라내기";
            this.mnuCut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mnuPartSum
            // 
            this.mnuPartSum.Name = "mnuPartSum";
            this.mnuPartSum.Size = new System.Drawing.Size(191, 24);
            this.mnuPartSum.Text = "부분합계";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // mnuSubGrid
            // 
            this.mnuSubGrid.Name = "mnuSubGrid";
            this.mnuSubGrid.Size = new System.Drawing.Size(191, 24);
            this.mnuSubGrid.Text = "그룹모음";
            this.mnuSubGrid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mnuMerge
            // 
            this.mnuMerge.Name = "mnuMerge";
            this.mnuMerge.Size = new System.Drawing.Size(191, 24);
            this.mnuMerge.Text = "셀 병합";
            // 
            // mnuFixed
            // 
            this.mnuFixed.Name = "mnuFixed";
            this.mnuFixed.Size = new System.Drawing.Size(191, 24);
            this.mnuFixed.Text = "컬럼고정";
            // 
            // mnuFilter
            // 
            this.mnuFilter.Name = "mnuFilter";
            this.mnuFilter.Size = new System.Drawing.Size(191, 24);
            this.mnuFilter.Text = "필터";
            // 
            // mnuRename
            // 
            this.mnuRename.Name = "mnuRename";
            this.mnuRename.Size = new System.Drawing.Size(191, 24);
            this.mnuRename.Text = "컬럼이름 바꾸기";
            // 
            // mnuInit
            // 
            this.mnuInit.Name = "mnuInit";
            this.mnuInit.Size = new System.Drawing.Size(191, 24);
            this.mnuInit.Text = "그리드 초기화";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(188, 6);
            // 
            // mnuCustom
            // 
            this.mnuCustom.Name = "mnuCustom";
            this.mnuCustom.Size = new System.Drawing.Size(191, 24);
            this.mnuCustom.Text = "그리드 상세 수정";
            // 
            // Grid
            // 
            this.ContextMenuStrip = this.cmsMenu;
            this.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            this.DisplayLayout.GroupByBox.Hidden = true;
            this.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.DisplayLayout.Override.AllowMultiCellOperations = ((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)(((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut)
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste)));
            this.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            this.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.Grid_InitializeRow);
            this.BeforeExitEditMode += new Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventHandler(this.Grid_BeforeExitEditMode);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Grid_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyUp);
            this.cmsMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

    }
}

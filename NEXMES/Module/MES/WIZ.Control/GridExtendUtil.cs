using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WIZ.Control
{
    public class GridExtendUtil
    {
        #region 그리드 & Panel 기준 데이터 동기화
        /// <summary>
        /// Grid 의 한 Row 와 Control 을 연결해서, 동기화 처리를 할 수 있다.
        /// 로우 선택이 바뀔 경우 특정 메소드를 실행할 수도 있으며,
        /// 로우 상태가 변경될 경우 해당 내용을 상태값을 저장하는 컬럼에 저장할 수도 있다.
        /// 연결을 위해선 Control 패널에 포함된 컨트롤의 Tag 와 Grid 의 Columns 코드와 일치시켜야 한다. ( 샘플 : BM5800 )
        /// 이 기능을 사용하기 위해선 Contrainer 와 grid 의 Tag 는 비어 있어야 한다.
        /// con, grid 를 null 로 입력하고, 그리드 Row 선택이 바꼈을 때 조회 기능 연결 용으로 써도 된다.
        /// (3번째 WIZ.Control.Grid.UseLinkMethod func 는 단독으로 동작 가능)
        /// </summary>
        /// <param name="con">연결 대상이 되는 Control - Panel 등 컨테이너 컨트롤 </param>
        /// <param name="grid">연결 대상이 되는 그리드 </param>
        /// <param name="func">그리드에서 선택값이 바뀔 때 실행할 메소드 - void method() 형태로 고정 </param>
        /// <param name="sRowStatusCode">그리드에서 변경된 값에 대한 내용을 저장하기 위한 컬럼 이름, 변경 될 경우 해당 컬럼의 값이 "U" 로 변경 </param>
        public static void SetLink(System.Windows.Forms.Control con, WIZ.Control.Grid grid, WIZ.Control.Grid.UseLinkMethod func = null, string sRowStatusCode = "")
        {
            grid.ClickCell += grid_ClickCell;
            grid.KeyUp += grid_KeyUp;
            grid.useLinkMethod = func;
            grid.RowStatusCode = sRowStatusCode;

            if (con != null)
            {
                con.Tag = grid;
                grid.Tag = con;

                foreach (System.Windows.Forms.Control c in con.Controls)
                {
                    if (CModule.ToString(c.Tag) != "")
                    {
                        SetLink(c);
                    }
                }
            }
        }

        #region 그리드 선택시 처리
        private static void grid_ClickCell(object sender, ClickCellEventArgs e)
        {
            WIZ.Control.Grid grid = sender as WIZ.Control.Grid;

            if (grid != null)
            {
                Grid_Search(grid);

                grid.useLinkMethod?.Invoke();
                //if (grid.useLinkMethod != null)
                //{
                //    grid.useLinkMethod();
                //}

            }
        }

        #region grid1에서 키보드 ↑, ↓ 입력시 grid2 조회 기능
        private static void grid_KeyUp(object sender, KeyEventArgs e)
        {
            WIZ.Control.Grid grid = sender as WIZ.Control.Grid;

            if (grid != null)
            {
                if (e.KeyCode.Equals(Keys.Up) || e.KeyCode.Equals(Keys.Down))
                {
                    Grid_Search(grid);

                    grid.useLinkMethod?.Invoke();
                }
            }
        }
        #endregion

        private static void Grid_Search(WIZ.Control.Grid grid)
        {
            if (grid.ActiveRow != null)
            {
                System.Windows.Forms.Control con = grid.Tag as System.Windows.Forms.Control;

                if (con != null)
                {
                    foreach (System.Windows.Forms.Control c in con.Controls)
                    {
                        if (CModule.ToString(c.Tag) != "")
                        {
                            SetText(c, grid.ActiveRow.Cells[CModule.ToString(c.Tag)].Value);
                        }
                    }
                }
            }
        }

        private static void SetText(System.Windows.Forms.Control c, object o)
        {
            switch (c.GetType().Name.ToUpper())
            {
                case "STEXTBOX":
                case "TEXTBOX":
                case "MASKEDTEXTBOX":
                case "NUMTEXTBOX":
                    {
                        c.Text = CModule.ToString(o);
                    }
                    break;
                case "ULTRACOMBOEDITOR":
                    {
                        Infragistics.Win.UltraWinEditors.UltraComboEditor e = c as Infragistics.Win.UltraWinEditors.UltraComboEditor;

                        if (e != null)
                        {
                            e.Value = o;
                        }
                    }
                    break;
                case "COMBOBOX":
                    {
                        ComboBox e = c as ComboBox;

                        if (e != null)
                        {
                            e.SelectedValue = o;
                        }
                    }
                    break;
                case "CHECKBOX":
                    {
                        CheckBox e = c as CheckBox;

                        if (e != null)
                        {
                            e.Checked = CModule.ToString(o) == "Y";
                        }
                    }
                    break;
                    //case "DATETIMEPICKER":
                    //    {
                    //        DateTimePicker e = c as DateTimePicker;
                    //        //e.Format = DateTimePickerFormat.Custom;
                    //        //e.CustomFormat = "yyyy-mm-dd";

                    //        if (e != null)
                    //        {
                    //            //포멧이 안맞아서 에러 뜸
                    //            //e.Value -> {2021-04-23 오전 12:00:00}
                    //            //o -> 2021-04-22

                    //            e.Value = DateTime.Parse( CModule.ToDateTimeString(o ));
                    //        }
                    //    }
                    //    break;

            }
        }
        #endregion

        private static void SetLink(System.Windows.Forms.Control c)
        {
            switch (c.GetType().Name.ToUpper())
            {
                case "STEXTBOX":
                case "TEXTBOX":
                case "MASKEDTEXTBOX":
                case "NUMTEXTBOX":
                    {
                        c.TextChanged += TextBox_TextChanged;
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
                case "CHECKBOX":
                    {
                        CheckBox e = c as CheckBox;

                        if (e != null)
                        {
                            e.CheckedChanged += CheckBox_CheckedChanged;
                        }
                    }
                    break;
                    //case "DATETIMEPICKER":
                    //    {
                    //        DateTimePicker e = c as DateTimePicker;

                    //        if (e != null)
                    //        {
                    //            e.ValueChanged += DateTimePicker__ValueChanged;
                    //        }
                    //    }
                    //    break;
            }
        }

        #region 컨트럴 데이터 변경시
        private static void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox c = sender as ComboBox;

            if (c != null)
            {
                string sTag = CModule.ToString(c.Tag);

                if (sTag != "")
                {
                    WIZ.Control.Grid grid = c.Parent.Tag as WIZ.Control.Grid;

                    if (grid != null)
                    {
                        if (grid.ActiveRow != null)
                        {
                            grid.ActiveRow.Cells[sTag].Value = c.SelectedValue;

                            if (grid.RowStatusCode != "")
                            {
                                grid.ActiveRow.Cells[grid.RowStatusCode].Value = "U";
                            }
                        }
                    }
                }
            }
        }

        private static void UltraCombo_AfterCloseUp(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinEditors.UltraComboEditor c = sender as Infragistics.Win.UltraWinEditors.UltraComboEditor;

            if (c != null)
            {
                string sTag = CModule.ToString(c.Tag);

                if (sTag != "")
                {
                    WIZ.Control.Grid grid = c.Parent.Tag as WIZ.Control.Grid;

                    if (grid != null)
                    {
                        if (grid.ActiveRow != null)
                        {
                            grid.ActiveRow.Cells[sTag].Value = c.Value;

                            if (grid.RowStatusCode != "")
                            {
                                grid.ActiveRow.Cells[grid.RowStatusCode].Value = "U";
                            }
                        }
                    }
                }
            }
        }

        private static void TextBox_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.Control c = sender as System.Windows.Forms.Control;
            if (c != null)
            {
                string sTag = CModule.ToString(c.Tag);

                if (sTag != "")
                {
                    WIZ.Control.Grid grid = c.Parent.Tag as WIZ.Control.Grid;

                    if (grid != null)
                    {
                        if (grid.ActiveRow != null)
                        {
                            grid.ActiveRow.Cells[sTag].Value = c.Text;

                            if (grid.RowStatusCode != "")
                            {
                                grid.ActiveRow.Cells[grid.RowStatusCode].Value = "U";
                            }
                        }
                    }
                }
            }
        }

        private static void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            if (c != null)
            {
                string sTag = CModule.ToString(c.Tag);

                if (sTag != "")
                {
                    WIZ.Control.Grid grid = c.Parent.Tag as WIZ.Control.Grid;

                    if (grid != null)
                    {
                        if (grid.ActiveRow != null)
                        {
                            grid.ActiveRow.Cells[sTag].Value = c.Checked ? "Y" : "N";

                            if (grid.RowStatusCode != "")
                            {
                                grid.ActiveRow.Cells[grid.RowStatusCode].Value = "U";
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #endregion

        #region 그리드 내에서 단위변환 처리
        public class clsUnitTrans
        {
            public string sUnitCode;
            public string sUnitWgtCode;
            public string sUnit_Value;
            public string sUnitWgt_Value;
            public string sUnitWgt;

            public string sUnitTrans;

            public List<string> sColList;
        }

        public static void SetUnitTrans(SubData sub, WIZ.Control.Grid grid)
        {
            // 단위변환 기능 필요할 때 처리
            // METHOD_TYPE - 값이 TRANS 여야함
            // RELCODE1 - 단위|포장단위
            // RELCODE2 - 수량|변환수량
            // RELCODE3 - UNITWGT
            // 셋 모두 들어가 있어야 한다. 
            // 각각의 항목들은 모두 grid 에 컬럼으로 추가되어 있어야 사용 가능.
            DataRow dr = sub["METHOD_TYPE", "TRANS"];

            clsUnitTrans cls = new clsUnitTrans();
            cls.sColList = new List<string>();
            grid.clsUnitTrans = cls;

            if (dr != null)
            {
                // 단위변환 대상 항목 ( 단위 처리 )
                // ( UNITCODE (기존 품목마스터의 기준단위), UNITWGT_UNIT (품목마스터의 포장 단위) )
                string s = CModule.ToString(dr["RELCODE1"]);

                if (s.Contains("|"))
                {
                    string[] sArr = s.Split('|');

                    if (sArr.Length > 0)
                    {
                        cls.sUnitCode = sArr[0];
                        cls.sColList.Add(cls.sUnitCode);
                    }

                    if (sArr.Length > 1)
                    {
                        cls.sUnitWgtCode = sArr[1];
                        cls.sColList.Add(cls.sUnitWgtCode);
                    }
                }

                // 단위변환 하는 숫자가 들어가게 되는 컬럼 정보 ( UNITCODE_VALUE (기존 수량), UNITWGT_VALUE (변환 수량) )
                // 처리는 UNITCODE_VALUE 가 기존의 수량으로 연결하면 됨
                s = CModule.ToString(dr["RELCODE2"]);

                if (s.Contains("|"))
                {
                    string[] sArr = s.Split('|');

                    if (sArr.Length > 0)
                    {
                        cls.sUnit_Value = sArr[0];
                        cls.sColList.Add(cls.sUnit_Value);
                    }

                    if (sArr.Length > 1)
                    {
                        cls.sUnitWgt_Value = sArr[1];
                        cls.sColList.Add(cls.sUnitWgt_Value);
                    }
                }

                // 단위변환 대상이 되는 단위수량 ( UNITWGT )
                cls.sUnitWgt = CModule.ToString(dr["RELCODE3"]);
                cls.sColList.Add(cls.sUnitWgt);

                if (cls.sUnitCode == "" || cls.sUnitWgtCode == "" || cls.sUnit_Value == "" || cls.sUnitWgt_Value == "" || cls.sUnitWgt == "")
                {
                    cls.sUnitTrans = "";
                }
                else
                {
                    bool bOK = true;

                    foreach (string sClsCol in cls.sColList)
                    {
                        int iCount = 0;
                        foreach (string sCol in grid.sListColumnsName)
                        {
                            if (sClsCol == sCol)
                            {
                                iCount++;
                            }
                        }

                        if (iCount == 0)
                        {
                            bOK = false;
                        }
                    }

                    cls.sUnitTrans = bOK == true ? "Y" : "N";
                }

                grid.AfterExitEditMode += Grid_AfterExitEditMode;
            }
        }

        private static void Grid_AfterExitEditMode(object sender, EventArgs e)
        {
            // 그리드 수정시
            WIZ.Control.Grid grid = sender as WIZ.Control.Grid;

            if (grid != null)
            {
                clsUnitTrans cls = grid.clsUnitTrans;

                if (cls != null)
                {
                    if (cls.sUnitTrans == "Y")
                    {
                        // 여기까지 설정되면 처리
                        // 단위변환 처리 진행
                    }
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// ListView 관련 처리 로직
    /// 조회 후 처리 로직 구현
    /// DAS 처럼 조회 결과에서 화면 컬럼 정보 수정 처리
    /// </summary>
    public static class CmmnListView
    {
        public static void SetData(ListView view, DataSet ds)
        {
            if (ds.Tables.Count >= 2)
            {
                SetHead(view, ds);

                SetData(view, ds.Tables[1]);
            }
            else
            {
                SetData(view, ds.Tables[0]);
            }
        }

        public static bool SetData(ListView view, DataTable dt)
        {
            view.Items.Clear();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lvl = new ListViewItem();

                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        lvl.SubItems.Add(CModule.ToString(dt.Rows[i][j]));
                    }

                    view.Items.Add(lvl);
                }

                view.EndUpdate();

                return true;
            }
            else
            {
                return false;
            }
        }

        public static void SetHead(ListView view, DataSet ds)
        {
            view.Items.Clear();
            view.Columns.Clear();

            string sHeader = CModule.ToString(ds.Tables[0].Rows[0][0]);

            string[] array = sHeader.Split('|');

            string empty = string.Empty;
            string empty2 = string.Empty;

            for (int i = 0; i < array.Length; i++)
            {
                empty = string.Empty;
                empty2 = string.Empty;

                int result = 0;

                //// 데이터셋에서 두번째 테이블의 정보가 있어야만 다음으로 진행
                //if (i <= ds.Tables[1].Columns.Count )
                //{
                //    break;
                //}

                if (array.Length > i)
                {
                    if (array[i] != null)
                    {
                        string[] array2 = array[i].Split('@');
                        if (array2.Length == 2)
                        {
                            empty = array2[0];
                            string[] array3 = array2[1].Split('^');
                            if (array3.Length == 2)
                            {
                                empty2 = array3[0];

                                result = CModule.ToInt32(array3[1]);

                                if (result == 0)
                                {
                                    result = 100;
                                }
                            }
                            else
                            {
                                empty2 = array2[1];
                            }
                        }
                        else
                        {
                            empty = array2[0];
                            empty2 = "L";
                            result = 100;
                        }
                    }
                }
                else
                {
                    empty = string.Empty;
                }

                HorizontalAlignment align = align = HorizontalAlignment.Left;

                if (empty2 == "C")
                {
                    align = HorizontalAlignment.Center;
                }
                else if (empty2 == "L")
                {
                    align = HorizontalAlignment.Left;
                }
                else if (empty2 == "R")
                {
                    align = HorizontalAlignment.Right;
                }
                else if (empty2 == "H")
                {
                    align = HorizontalAlignment.Left;
                    result = 0;
                }

                view.Columns.Add(new WIZ.Grid.ColHeader(empty, result, align, true));

                if (i >= ds.Tables[0].Columns.Count - 1 && i >= array.Length - 1)
                {
                    break;
                }
            }
        }
    }
}

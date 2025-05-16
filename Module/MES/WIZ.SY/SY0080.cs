using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTree;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.Control;
using WIZ.Forms;

namespace WIZ.SY
{
    public class SY0080 : BaseMDIChildForm
    {
        private UltraTree_DropHightLight_DrawFilter_Class UltraTree_DropHightLight_DrawFilter = new UltraTree_DropHightLight_DrawFilter_Class();

        private UltraGridUtil _GridUtil = new UltraGridUtil();

        private string _sWorkerID = string.Empty;

        private DataSet rtnDsTemp = new DataSet();

        private int menuid = 0;

        private Binding INQFLAG = null;

        private Binding DELFLAG = null;

        private Binding PRNFLAG = null;

        private Binding NEWFLAG = null;

        private Binding SAVEFLAG = null;

        private Binding EXCELFLAG = null;

        private Binding EXEIMFLAG = null;

        private bool flag = false;

        private string LastActiveNode = string.Empty;

        private string[] Ex_Node;

        private int ex_node_cnt = 0;

        private bool _bSave = false;

        private Point LastMouseDown;

        private DataTable dtTemp = new DataTable();

        private new IContainer components = null;

        private SLabel lblWorkerID;

        private UltraGroupBox ultraGroupBox1;

        private UltraTree treMenu;

        private UltraSplitter ultraSplitter1;

        private WIZ.Control.Grid grid1;

        private UltraGroupBox gbxMenuInfor;

        private UltraGroupBox gbxProgramInfor;

        private UltraSplitter ultraSplitter2;
        private STextBox txtPwd;
        private UltraButton btnCopy;

        internal BindingSource bs;

        private SCodeNMComboBox cboSystemType_H;

        private SLabel sLabel6;

        private ImageList imlMenu;

        private SLabel lblMenuType;

        private SCodeNMComboBox cboMenuType;

        private SLabel sLabel3;

        private SLabel lblMenuID;

        private SCodeNMComboBox UseFlag;

        private SLabel lblRemark;
        private STextBox txtProgramID;
        private SLabel sLabel1;

        private SLabel sLabel2;

        private SLabel lblRemark1;

        private SLabel lblNameSpace;

        private SLabel lblFileID;

        private UltraCheckEditor uceExcelIMFlag;

        private UltraCheckEditor uceSumFlag;

        private UltraCheckEditor uceExcelFlag;

        private UltraCheckEditor ucePrnFlag;

        private UltraCheckEditor uceSaveFlag;

        private UltraCheckEditor uceDelFlag;

        private UltraCheckEditor uceNewFlag;

        private UltraCheckEditor uceInqFlag;

        private WIZ.Control.STextBox txtWorkerName_H;

        private WIZ.Control.STextBox txtWorkerID_H;

        private WIZ.Control.STextBox txtMenuName;

        private WIZ.Control.STextBox txtRemark;

        private WIZ.Control.STextBox txtProgramType;

        private WIZ.Control.STextBox txtNameSpace;

        private WIZ.Control.STextBox txtFileID;

        private WIZ.Control.STextBox txtRemark1;

        private ScboProgramIDCode scboProgramIDCode1;

        public SY0080()
        {
            InitializeComponent();
            UltraTree_DropHightLight_DrawFilter.Invalidate += UltraTree_DropHightLight_DrawFilter_Invalidate;
            UltraTree_DropHightLight_DrawFilter.QueryStateAllowedForNode += UltraTree_DropHightLight_DrawFilter_QueryStateAllowedForNode;
        }

        private void SY0080_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "GRPID", "그룹ID", true, GridColDataType_emu.VarChar, 100, 100, HAlign.Left, true, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "GRPNAME", "그룹명", true, GridColDataType_emu.VarChar, 130, 100, HAlign.Left, true, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "DISPLAYNO", "표시순서", true, GridColDataType_emu.Integer, 100, 100, HAlign.Right, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "SYSTEMID", "SYSTEMID", true, GridColDataType_emu.VarChar, 130, 100, HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 160, 100, HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일", true, GridColDataType_emu.VarChar, 130, 100, HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", true, GridColDataType_emu.VarChar, 160, 100, HAlign.Left, false, false, null, null, null, null, null);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE", "수정일", true, GridColDataType_emu.VarChar, 100, 100, HAlign.Left, false, true, null, null, null, null, null);
            _GridUtil.SetInitUltraGridBind(grid1);
            cboSystemType_H.Value = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings["SYSTEMID"].Value;
            treMenu.DrawFilter = UltraTree_DropHightLight_DrawFilter;
            treMenu.Override.SelectionType = Infragistics.Win.UltraWinTree.SelectType.ExtendedAutoDrag;
            treMenu.Appearances.Add("DropHighLightAppearance");
            treMenu.Appearances["DropHighLightAppearance"].BackColor = Color.Cyan;
            treMenu.ImageList = imlMenu;
        }

        public override void DoInquire()
        {
            base.DoInquire();
            string value = Convert.ToString(txtWorkerID_H.Value);
            string value2 = Convert.ToString(txtWorkerName_H.Value);
            DBHelper dBHelper = new DBHelper(completedClose: false);
            try
            {
                grid1.DataSource = dBHelper.FillTable("USP_SY0080_S1", CommandType.StoredProcedure, dBHelper.CreateParameter("GRPID", value, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("GRPName", value2, DbType.String, ParameterDirection.Input));
                grid1.DataBind();
                grid1.GetRow();
            }
            catch (Exception ex)
            {
                ThrowError(ex);
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public override void DoNew()
        {
            try
            {
                base.DoNew();
                if (grid1.IsActivate)
                {
                    int dtRowNum = grid1.InsertRow();
                    UltraGridUtil.ActivationAllowEdit(grid1, "GRPID", dtRowNum);
                    UltraGridUtil.ActivationAllowEdit(grid1, "GRPName", dtRowNum);
                    UltraGridUtil.ActivationAllowEdit(grid1, "Displayno", dtRowNum);
                }
                else if (treMenu.ActiveNode != null)
                {
                    if (treMenu.ActiveNode.Nodes.Count == 0)
                    {
                        treMenu.ActiveNode = treMenu.ActiveNode.NextVisibleNode;
                    }
                    if (grid1.Rows.Count != 0)
                    {
                        DataRow dataRow = rtnDsTemp.Tables[0].NewRow();
                        dataRow["WorkerID"] = Convert.ToString(grid1.ActiveRow.Cells["GRPID"].Value);
                        if (treMenu.ActiveNode == null)
                        {
                            dataRow["PARMENUID"] = "0";
                            dataRow["SORT"] = 0;
                        }
                        else
                        {
                            dataRow["SORT"] = ((treMenu.ActiveNode.Cells["SORT"].Value != null) ? Convert.ToInt32(treMenu.ActiveNode.Cells["SORT"].Value) : 0);
                            dataRow["PARMENUID"] = ((treMenu.ActiveNode.Cells["PARMENUID"].Value == null) ? "0" : treMenu.ActiveNode.Cells["PARMENUID"].Value);
                        }
                        dataRow["MENUID"] = --menuid;
                        dataRow["MENUNAME"] = "";
                        dataRow["PROGRAMID"] = "";
                        dataRow["MENUTYPE"] = "";
                        dataRow["REMARK"] = "";
                        dataRow["USEFLAG"] = "Y";
                        dataRow["MAKER"] = "";
                        dataRow["EDITOR"] = "";
                        dataRow["PROGRAMNAME"] = "";
                        dataRow["PROGTYPE"] = "";
                        dataRow["INQFLAG"] = false;
                        dataRow["NEWFLAG"] = false;
                        dataRow["DELFLAG"] = false;
                        dataRow["SAVEFLAG"] = false;
                        dataRow["EXCELFLAG"] = false;
                        dataRow["PRNFLAG"] = false;
                        dataRow["EXEIMFLAG"] = false;
                        dataRow["NAMESPACE"] = "";
                        dataRow["FILEID"] = "";
                        dataRow["PROGRAMREMARK"] = "";
                        rtnDsTemp.Tables[0].Rows.Add(dataRow);
                        treMenu.RefreshSort();
                        treMenu.ActiveNode = treMenu.ActiveNode.NextVisibleNode;
                    }
                }
            }
            catch (Exception ex)
            {
                ThrowError(ex);
            }
        }

        public override void DoDelete()
        {
            try
            {
                base.DoDelete();
                if (grid1.IsActivate)
                {
                    grid1.DeleteRow();
                }
                else if (treMenu.ActiveNode != null)
                {
                    if (treMenu.ActiveNode.Cells["MENUTYPE"].Value.ToString() == "M")
                    {
                        DialogForm dialogForm = new DialogForm(Common.getLangText("변경된 사항을 저장하시겠습니까?", "MSG"));
                        dialogForm.ShowDialog();
                        if (dialogForm.result == "OK")
                        {
                            string text = treMenu.ActiveNode.Cells["MenuID"].Value.ToString();
                            foreach (DataRow row in rtnDsTemp.Tables[0].Rows)
                            {
                                DataRowState rowState = row.RowState;
                                if (rowState != DataRowState.Deleted && row["ParMenuID"].ToString() == text)
                                {
                                    if (row["MENUTYPE"].ToString() == "M")
                                    {
                                        DoDelSub(row["MENUID"].ToString());
                                    }
                                    row.Delete();
                                }
                            }
                            rtnDsTemp.Tables[0].Rows.Find(text).Delete();
                        }
                    }
                    else
                    {
                        string key = treMenu.ActiveNode.Cells["MenuID"].Value.ToString();
                        rtnDsTemp.Tables[0].Rows.Find(key).Delete();
                    }
                }
            }
            catch (Exception ex)
            {
                ThrowError(ex);
            }
        }

        private void DoDelSub(string sMID)
        {
            foreach (DataRow row in rtnDsTemp.Tables[0].Rows)
            {
                DataRowState rowState = row.RowState;
                if (rowState != DataRowState.Deleted && row["ParMenuID"].ToString() == sMID)
                {
                    if (row["MENUTYPE"].ToString() == "M")
                    {
                        DoDelSub(row["MENUID"].ToString());
                    }
                    row.Delete();
                }
            }
        }

        public override void DoSave()
        {
            base.DoSave();
            grid1.PerformAction(UltraGridAction.DeactivateCell);
            Grid1ToolAct();
            treMenu.PerformAction(UltraTreeAction.DeactivateCell, shift: false, control: true);
            ((CurrencyManager)BindingContext[bs]).EndCurrentEdit();
            if (grid1.ActiveRow != null)
            {
                USP_SY0070_CRUD((rtnDsTemp.Tables.Count > 0) ? rtnDsTemp.Tables[0] : null, Convert.ToString(grid1.ActiveRow.Cells["GRPID"].Value));
            }
            grid1.DisplayLayout.Bands[0].Columns["GRPID"].CellActivation = Activation.NoEdit;
            grid1_ClickCell(null, null);
        }

        private void Grid1ToolAct()
        {
            DataTable dataTable = grid1.chkChange();
            if (dataTable != null)
            {
                DBHelper dBHelper = new DBHelper("", bTrans: true);
                try
                {
                    base.DoSave();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row.RowState != DataRowState.Deleted && row["GRPID"].ToString().Trim() == "")
                        {
                            grid1.SetRowError(row, Common.getLangText("그룹ID 미입력 오류!", "MSG"));
                        }
                        else
                        {
                            switch (row.RowState)
                            {
                                case DataRowState.Deleted:
                                    row.RejectChanges();
                                    dBHelper.ExecuteNoneQuery("USP_SY0080_D1", CommandType.StoredProcedure, dBHelper.CreateParameter("GRPID", Convert.ToString(row["GRPID"]), DbType.String, ParameterDirection.Input));
                                    break;
                                case DataRowState.Added:
                                    dBHelper.ExecuteNoneQuery("USP_SY0080_I1", CommandType.StoredProcedure, dBHelper.CreateParameter("GRPID", Convert.ToString(row["GRPID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("GRPName", Convert.ToString(row["GRPName"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("Displayno", Convert.ToString(row["Displayno"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("Maker", WorkerID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("Editor", WorkerID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_SYSTEMID", DBHelper.nvlString(cboSystemType_H.Value), DbType.String, ParameterDirection.Input));
                                    break;
                                case DataRowState.Modified:
                                    dBHelper.ExecuteNoneQuery("USP_SY0080_U1", CommandType.StoredProcedure, dBHelper.CreateParameter("GRPID", Convert.ToString(row["GRPID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("GRPName", Convert.ToString(row["GRPName"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("Displayno", Convert.ToString(row["Displayno"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("Editor", WorkerID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_SYSTEMID", Convert.ToString(row["SystemID"]), DbType.String, ParameterDirection.Input));
                                    break;
                            }
                            grid1.SetRowError(row, dBHelper.RSMSG, dBHelper.RSCODE);
                        }
                    }
                    grid1.SetAcceptChanges();
                    dBHelper.Commit();
                }
                catch (SException ex)
                {
                    base.CancelProcess = true;
                    dBHelper.Rollback();
                    ThrowError(ex);
                }
                finally
                {
                    dBHelper.Close();
                }
            }
        }

        private void treMenu_DragDrop(object sender, DragEventArgs e)
        {
            UltraTreeNode dropHightLightNode = UltraTree_DropHightLight_DrawFilter.DropHightLightNode;
            SelectedNodesCollection selectedNodesCollection = (SelectedNodesCollection)e.Data.GetData(typeof(SelectedNodesCollection));
            selectedNodesCollection = (selectedNodesCollection.Clone() as SelectedNodesCollection);
            selectedNodesCollection.SortByPosition();
            switch (UltraTree_DropHightLight_DrawFilter.DropLinePosition)
            {
                case DropLinePositionEnum.OnNode:
                    {
                        if (dropHightLightNode.Cells["MenuType"].Value.ToString() == "P")
                        {
                            return;
                        }
                        for (int i = 0; i <= selectedNodesCollection.Count - 1; i++)
                        {
                            rtnDsTemp.Tables["Table1"].Rows.Find(selectedNodesCollection[i].Cells["MenuID"].Value.ToString())["ParMenuID"] = dropHightLightNode.Cells["MenuID"].Value;
                            treMenu.RefreshSort();
                            SetNodesSort(selectedNodesCollection[i]);
                        }
                        break;
                    }
                case DropLinePositionEnum.BelowNode:
                    {
                        string text2 = Convert.ToString(selectedNodesCollection[0].Cells["MenuID"].Value);
                        for (int i = 0; i <= selectedNodesCollection.Count - 1; i++)
                        {
                            rtnDsTemp.Tables["Table1"].Rows.Find(selectedNodesCollection[i].Cells["MenuID"].Value.ToString())["Sort"] = Convert.ToInt32(dropHightLightNode.Cells["Sort"].Value) + 1;
                            rtnDsTemp.Tables["Table1"].Rows.Find(selectedNodesCollection[i].Cells["MenuID"].Value.ToString())["ParMenuID"] = dropHightLightNode.Cells["ParMenuID"].Value;
                            treMenu.RefreshSort();
                            SetNodesSort(selectedNodesCollection[i].Parent);
                        }
                        break;
                    }
                case DropLinePositionEnum.AboveNode:
                    {
                        string text = Convert.ToString(selectedNodesCollection[0].Cells["MenuID"].Value);
                        for (int i = 0; i <= selectedNodesCollection.Count - 1; i++)
                        {
                            rtnDsTemp.Tables["Table1"].Rows.Find(selectedNodesCollection[i].Cells["MenuID"].Value.ToString())["Sort"] = Convert.ToInt32(dropHightLightNode.Cells["Sort"].Value) - 1;
                            rtnDsTemp.Tables["Table1"].Rows.Find(selectedNodesCollection[i].Cells["MenuID"].Value.ToString())["ParMenuID"] = dropHightLightNode.Cells["ParMenuID"].Value;
                            treMenu.RefreshSort();
                            SetNodesSort(selectedNodesCollection[i].Parent);
                        }
                        break;
                    }
            }
            treMenu.RefreshSort();
            UltraTree_DropHightLight_DrawFilter.ClearDropHighlight();
            try
            {
                LastActiveNode = dropHightLightNode.Cells["MenuID"].Value.ToString();
            }
            catch (Exception ex)
            {
                ThrowError(ex);
            }
        }

        private void treMenu_DragLeave(object sender, EventArgs e)
        {
            UltraTree_DropHightLight_DrawFilter.ClearDropHighlight();
        }

        private void treMenu_DragOver(object sender, DragEventArgs e)
        {
            Point point = treMenu.PointToClient(new Point(e.X, e.Y));
            UltraTreeNode nodeFromPoint = treMenu.GetNodeFromPoint(point);
            if (nodeFromPoint == null)
            {
                e.Effect = DragDropEffects.None;
                UltraTree_DropHightLight_DrawFilter.ClearDropHighlight();
            }
            else if (IsContinentNode(nodeFromPoint) && IsContinentNodeSelected(treMenu) && point.Y > nodeFromPoint.Bounds.Top + 2 && point.Y < nodeFromPoint.Bounds.Bottom - 2)
            {
                e.Effect = DragDropEffects.None;
                UltraTree_DropHightLight_DrawFilter.ClearDropHighlight();
            }
            else if (IsAnyParentSelected(nodeFromPoint))
            {
                e.Effect = DragDropEffects.None;
                UltraTree_DropHightLight_DrawFilter.ClearDropHighlight();
            }
            else
            {
                UltraTree_DropHightLight_DrawFilter.SetDropHighlightNode(nodeFromPoint, point);
                e.Effect = DragDropEffects.Move;
            }
        }

        private void treMenu_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            if (e.EscapePressed)
            {
                e.Action = DragAction.Cancel;
                UltraTree_DropHightLight_DrawFilter.ClearDropHighlight();
            }
        }

        private void treMenu_SelectionDragStart(object sender, EventArgs e)
        {
            treMenu.DoDragDrop(treMenu.SelectedNodes, DragDropEffects.Move);
        }

        private void treMenu_ColumnSetGenerated(object sender, ColumnSetGeneratedEventArgs e)
        {
            e.ColumnSet.Columns["Sort"].SortType = SortType.Ascending;
            string key = e.ColumnSet.Key;
            if (!(key == "rel_db"))
            {
                if (key == "Table1")
                {
                    e.ColumnSet.NodeTextColumn = e.ColumnSet.Columns[rtnDsTemp.Tables["Table1"].Columns["MENUNAME"].ToString()];
                }
            }
            else
            {
                e.ColumnSet.NodeTextColumn = e.ColumnSet.Columns[rtnDsTemp.Tables["Table1"].Columns["MENUNAME"].ToString()];
            }
        }

        private void treMenu_Click(object sender, EventArgs e)
        {
            if (treMenu.ActiveNode != null && treMenu.ActiveNode.Cells["MenuID"].Value != null)
            {
                bs.Position = bs.Find("MenuID", treMenu.ActiveNode.Cells["MenuID"].Value);
            }
        }

        private void treMenu_InitializeDataNode(object sender, InitializeDataNodeEventArgs e)
        {
            if (e.Node.Parent == null && e.Node.Cells["ParMenuID"].Value.ToString() != "0")
            {
                e.Node.Visible = false;
                try
                {
                    e.Node.Key = Convert.ToString(e.Node.Cells["MENUID"].Value);
                }
                catch (Exception ex)
                {
                    ThrowError(ex);
                }
                return;
            }
            if (e.Node.Cells["MenuType"].Value.ToString() == "M")
            {
                e.Node.Override.NodeAppearance.Image = 2;
                if (_bSave && e.Node.Key == Ex_Node[ex_node_cnt])
                {
                    e.Node.Expanded = true;
                    ex_node_cnt++;
                    node(e.Node);
                    _bSave = false;
                }
            }
            else
            {
                e.Node.Override.NodeAppearance.Image = 3;
            }
            e.Node.Override.ImageSize = new Size(16, 16);
        }

        private void treMenu_MouseDown(object sender, MouseEventArgs e)
        {
            LastMouseDown = new Point(e.X, e.Y);
            try
            {

                String treeKey;//2020-09-07 ADD : 신효철
                treeKey = treMenu.GetNodeFromPoint(LastMouseDown).Key;

                if (treeKey == null || treeKey == "")
                {
                    LastActiveNode = "";//2020-09-07 ADD : 신효철
                }
                else
                {
                    LastActiveNode = treeKey;// treMenu.GetNodeFromPoint(LastMouseDown).Key;
                }

            }

            catch (Exception)// ex)
            {
                //throw ex;//2020-09-07 ADD : 신효철
            }
        }

        private void treMenu_MouseUp(object sender, MouseEventArgs e)
        {
            LastMouseDown = new Point(e.X, e.Y);
        }

        private void grid1_ClickCell(object sender, EventArgs e)
        {
            treeSetting();
        }

        private void UltraTree_DropHightLight_DrawFilter_Invalidate(object sender, EventArgs e)
        {
            treMenu.Invalidate();
        }

        private void UltraTree_DropHightLight_DrawFilter_QueryStateAllowedForNode(object sender, UltraTree_DropHightLight_DrawFilter_Class.QueryStateAllowedForNodeEventArgs e)
        {
            e.StatesAllowed = DropLinePositionEnum.All;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            string[] array = new string[5];
            if (grid1.Rows.Count == 0)
            {
                IsShowDialog = false;
                ShowDialog(Common.getLangText("조회할 데이터가 없습니다.", "MSG"), DialogForm.DialogType.OK);
                return;
            }
            string text = DBHelper.nvlString(grid1.ActiveRow.Cells["GRPID"].Value);
            string text2 = DBHelper.nvlString(grid1.ActiveRow.Cells["GRPNAME"].Value);
            if (text != "" && text2 != "")
            {
                array[0] = text;
                array[1] = text2;
                array[3] = DBHelper.nvlString(cboSystemType_H.Value);
                array[4] = "G";
                SY0081 sY = new SY0081(array);
                sY.ShowDialog();
            }
            else
            {
                ShowDialog(Common.getLangText("권한 대상자를 선택하십시오.", "MSG"), DialogForm.DialogType.OK);
            }
        }

        private void cboSystemType_H_ValueChanged(object sender, EventArgs e)
        {
            scboProgramIDCode1.SystemID = cboSystemType_H.Value.ToString();
            scboProgramIDCode1.InitComboBox();
        }

        private void scboProgramIDCode1_ValueChanged(object sender, EventArgs e)
        {
            DBHelper dBHelper = new DBHelper(completedClose: false);
            try
            {
                if (!(_sWorkerID == "") && scboProgramIDCode1.Value != null && !scboProgramIDCode1.Value.ToString().Equals("") && rtnDsTemp.Tables[0].Rows[bs.Position].RowState == DataRowState.Added && !rtnDsTemp.Tables[0].Rows[bs.Position]["EDITOR"].Equals(scboProgramIDCode1.Value.ToString()))
                {
                    string query = "   SELECT *                           FROM TSY0010 WITH(NOLOCK)                    WHERE WorkerID  = 'SYSTEM'        AND ProgramID = '" + scboProgramIDCode1.Value + "' ";
                    DataTable dataTable = new DataTable();
                    dataTable = dBHelper.FillTable(query, CommandType.Text);
                    if (dataTable.Rows.Count > 0)
                    {
                        rtnDsTemp.Tables[0].Rows[bs.Position].BeginEdit();
                        txtFileID.Text = dataTable.Rows[0]["FILEID"].ToString();
                        txtNameSpace.Text = dataTable.Rows[0]["NameSpace"].ToString();
                        txtProgramType.Text = dataTable.Rows[0]["ProgType"].ToString();
                        txtMenuName.Text = dataTable.Rows[0]["ProgramName"].ToString();
                        cboMenuType.Value = dataTable.Rows[0]["ProgType"].ToString();
                        uceDelFlag.Checked = DBHelper.nvlBoolean(dataTable.Rows[0]["DELFLAG"].ToString());
                        uceExcelFlag.Checked = DBHelper.nvlBoolean(dataTable.Rows[0]["EXCELFLAG"].ToString());
                        uceInqFlag.Checked = DBHelper.nvlBoolean(dataTable.Rows[0]["INQFLAG"].ToString());
                        uceNewFlag.Checked = DBHelper.nvlBoolean(dataTable.Rows[0]["NEWFLAG"].ToString());
                        ucePrnFlag.Checked = DBHelper.nvlBoolean(dataTable.Rows[0]["PRNFLAG"].ToString());
                        uceSaveFlag.Checked = DBHelper.nvlBoolean(dataTable.Rows[0]["SAVEFLAG"].ToString());
                        uceExcelIMFlag.Checked = DBHelper.nvlBoolean(dataTable.Rows[0]["EXEIMFLAG"].ToString());
                        rtnDsTemp.Tables[0].Rows[bs.Position]["INQFLAG"] = dataTable.Rows[0]["INQFLAG"];
                        rtnDsTemp.Tables[0].Rows[bs.Position]["NEWFLAG"] = dataTable.Rows[0]["NEWFLAG"];
                        rtnDsTemp.Tables[0].Rows[bs.Position]["DELFLAG"] = dataTable.Rows[0]["DELFLAG"];
                        rtnDsTemp.Tables[0].Rows[bs.Position]["EXCELFLAG"] = dataTable.Rows[0]["EXCELFLAG"];
                        rtnDsTemp.Tables[0].Rows[bs.Position]["PRNFLAG"] = dataTable.Rows[0]["PRNFLAG"];
                        rtnDsTemp.Tables[0].Rows[bs.Position]["SAVEFLAG"] = dataTable.Rows[0]["SAVEFLAG"];
                        rtnDsTemp.Tables[0].Rows[bs.Position]["EXEIMFLAG"] = dataTable.Rows[0]["EXEIMFLAG"];
                        rtnDsTemp.Tables[0].Rows[bs.Position]["MENUTYPE"] = dataTable.Rows[0]["ProgType"].ToString();
                        rtnDsTemp.Tables[0].Rows[bs.Position]["ProgType"] = dataTable.Rows[0]["ProgType"].ToString();
                        rtnDsTemp.Tables[0].Rows[bs.Position]["FILEID"] = dataTable.Rows[0]["FILEID"].ToString();
                        rtnDsTemp.Tables[0].Rows[bs.Position]["ProgramName"] = dataTable.Rows[0]["ProgramName"].ToString();
                        rtnDsTemp.Tables[0].Rows[bs.Position]["NameSpace"] = dataTable.Rows[0]["NameSpace"].ToString();
                        rtnDsTemp.Tables[0].Rows[bs.Position]["PROGRAMID"] = dataTable.Rows[0]["PROGRAMID"].ToString();
                        rtnDsTemp.Tables[0].Rows[bs.Position]["MENUNAME"] = dataTable.Rows[0]["ProgramName"].ToString();
                        rtnDsTemp.Tables[0].Rows[bs.Position]["EDITOR"] = LoginInfo.UserID;
                        rtnDsTemp.Tables[0].Rows[bs.Position].EndEdit();
                    }
                    treMenu.Update();
                    treMenu.Invalidate();
                }
            }
            catch (Exception ex)
            {
                ThrowError(ex);
            }
            finally
            {
                dBHelper.Close();
            }
        }

        private void node(UltraTreeNode node)
        {
            try
            {
                int num = 0;
                while (true)
                {
                    if (num >= node.RootNode.Nodes.Count)
                    {
                        return;
                    }
                    if (Convert.ToString(node.RootNode.Nodes[num].Cells["MENUID"].Value) == Convert.ToString(Ex_Node[ex_node_cnt]))
                    {
                        break;
                    }
                    num++;
                }
                ex_node_cnt++;
                UltraTreeNode ultraTreeNode = node.RootNode.Nodes[num];
                ultraTreeNode.Expanded = true;
                this.node(ultraTreeNode);
            }
            catch (Exception)
            {
            }
        }

        private bool IsContinentNode(UltraTreeNode Node)
        {
            string key = Node.Key;
            string[] array = key.Split(':');
            return array[0] == "Continent";
        }

        private bool IsContinentNodeSelected(UltraTree tree)
        {
            foreach (UltraTreeNode selectedNode in tree.SelectedNodes)
            {
                if (IsContinentNode(selectedNode))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsAnyParentSelected(UltraTreeNode Node)
        {
            bool result = false;
            for (UltraTreeNode parent = Node.Parent; parent != null; parent = parent.Parent)
            {
                if (parent.Selected)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        private void treeSetting()
        {
            if (grid1.ActiveRow != null)
            {
                _sWorkerID = grid1.ActiveRow.Cells["GRPID"].Value.ToString();
                DataTable dataTable = new DataTable();
                dataTable = USP_SY0070_S1();
                if (dataTable.Rows.Count > 0)
                {
                    rtnDsTemp = new DataSet();
                    BindingClear();
                    rtnDsTemp.Tables.Add(dataTable);
                    rtnDsTemp.Tables[0].PrimaryKey = new DataColumn[1]
                    {
                        rtnDsTemp.Tables[0].Columns["MenuID"]
                    };
                    rtnDsTemp.Relations.Add("rel_db", rtnDsTemp.Tables["Table1"].Columns["MenuID"], rtnDsTemp.Tables["Table1"].Columns["ParMenuID"], createConstraints: false);
                    rtnDsTemp.Tables[0].DefaultView.Sort = "Sort";
                    treMenu.SetDataBinding(rtnDsTemp, "Table1");
                    bs.DataSource = rtnDsTemp;
                    bs.DataMember = "Table1";
                    rtnDsTemp.EnforceConstraints = false;
                    treMenu.SynchronizeCurrencyManager = true;
                    treMenu.BorderStyle = UIElementBorderStyle.None;
                    treMenu.CausesValidation = false;
                    treMenu.Override.ShowColumns = DefaultableBoolean.False;
                    treMenu.ColumnSettings.LabelPosition = NodeLayoutLabelPosition.None;
                    treMenu.ColumnSettings.ColumnAutoSizeMode = Infragistics.Win.UltraWinTree.ColumnAutoSizeMode.VisibleNodes;
                    treMenu.ColumnSettings.AllowSorting = DefaultableBoolean.True;
                    treMenu.UseFlatMode = DefaultableBoolean.True;
                    treMenu.Override.ShowExpansionIndicator = Infragistics.Win.UltraWinTree.ShowExpansionIndicator.CheckOnDisplay;
                    treMenu.AllowDrop = true;
                    treMenu.ScrollBounds = Infragistics.Win.UltraWinTree.ScrollBounds.ScrollToFill;
                    flag = true;
                    Binding();
                }
                else
                {
                    treMenu.DataSource = null;
                }
            }
        }

        private void SetNodesSort(UltraTreeNode node)
        {
            if (node != null)
            {
                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    rtnDsTemp.Tables[0].Rows.Find(node.Nodes[i].Cells["MenuID"].Value.ToString())["Sort"] = node.Nodes[i].Index;
                }
            }
        }

        private void BindingClear()
        {
            txtMenuName.DataBindings.Clear();
            cboMenuType.DataBindings.Clear();
            UseFlag.DataBindings.Clear();
            txtRemark1.DataBindings.Clear();
            txtProgramID.DataBindings.Clear();
            txtProgramType.DataBindings.Clear();
            uceInqFlag.DataBindings.Clear();
            uceDelFlag.DataBindings.Clear();
            ucePrnFlag.DataBindings.Clear();
            uceNewFlag.DataBindings.Clear();
            uceSaveFlag.DataBindings.Clear();
            uceExcelFlag.DataBindings.Clear();
            uceExcelIMFlag.DataBindings.Clear();
            txtNameSpace.DataBindings.Clear();
            txtFileID.DataBindings.Clear();
            txtRemark1.DataBindings.Clear();
        }

        private void Binding()
        {
            BindingClear();
            txtMenuName.DataBindings.Clear();
            txtMenuName.DataBindings.Add("Value", bs, "MENUNAME");
            cboMenuType.DataBindings.Clear();
            cboMenuType.DataBindings.Add("Value", bs, "MENUTYPE");
            UseFlag.DataBindings.Clear();
            UseFlag.DataBindings.Add("Value", bs, "USEFLAG");
            txtRemark1.DataBindings.Clear();
            txtRemark1.DataBindings.Add("Value", bs, "REMARK");
            txtProgramID.DataBindings.Clear();
            txtProgramID.DataBindings.Add("Value", bs, "PROGRAMID");
            scboProgramIDCode1.DataBindings.Clear();
            scboProgramIDCode1.DataBindings.Add("Value", bs, "PROGRAMID");
            txtProgramType.DataBindings.Clear();
            txtProgramType.DataBindings.Add("Value", bs, "PROGTYPE");
            INQFLAG = new Binding("Checked", bs, "INQFLAG");
            DELFLAG = new Binding("Checked", bs, "DELFLAG");
            PRNFLAG = new Binding("Checked", bs, "PRNFLAG");
            NEWFLAG = new Binding("Checked", bs, "NEWFLAG");
            SAVEFLAG = new Binding("Checked", bs, "SAVEFLAG");
            EXCELFLAG = new Binding("Checked", bs, "EXCELFLAG");
            EXEIMFLAG = new Binding("Checked", bs, "EXEIMFLAG");
            INQFLAG.Format += ComboBind;
            DELFLAG.Format += ComboBind;
            PRNFLAG.Format += ComboBind;
            NEWFLAG.Format += ComboBind;
            SAVEFLAG.Format += ComboBind;
            EXCELFLAG.Format += ComboBind;
            EXEIMFLAG.Format += ComboBind;
            uceInqFlag.DataBindings.Clear();
            uceInqFlag.DataBindings.Add(INQFLAG);
            uceDelFlag.DataBindings.Clear();
            uceDelFlag.DataBindings.Add(DELFLAG);
            ucePrnFlag.DataBindings.Clear();
            ucePrnFlag.DataBindings.Add(PRNFLAG);
            uceNewFlag.DataBindings.Clear();
            uceNewFlag.DataBindings.Add(NEWFLAG);
            uceSaveFlag.DataBindings.Clear();
            uceSaveFlag.DataBindings.Add(SAVEFLAG);
            uceExcelFlag.DataBindings.Clear();
            uceExcelFlag.DataBindings.Add(EXCELFLAG);
            uceExcelIMFlag.DataBindings.Clear();
            uceExcelIMFlag.DataBindings.Add(EXEIMFLAG);
            txtNameSpace.DataBindings.Clear();
            txtNameSpace.DataBindings.Add("Value", bs, "NAMESPACE");
            txtFileID.DataBindings.Clear();
            txtFileID.DataBindings.Add("Value", bs, "FILEID");
            txtRemark1.DataBindings.Clear();
            txtRemark1.DataBindings.Add("Value", bs, "PROGRAMREMARK");
        }

        private void ComboBind(object send, ConvertEventArgs e)
        {
            if (e.Value == DBNull.Value)
            {
                e.Value = false;
            }
            e.Value = (Convert.ToString(e.Value) != "0" && (Convert.ToString(e.Value) == "1" || Convert.ToBoolean(e.Value)));
        }

        private DataTable USP_SY0070_S1()
        {
            DBHelper dBHelper = new DBHelper(completedClose: false);
            string value = Convert.ToString(grid1.ActiveRow.Cells["GRPID"].Value);
            try
            {
                return dBHelper.FillTable("USP_SY0070_S1", CommandType.StoredProcedure, dBHelper.CreateParameter("WORKERID", value, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("SYSTEMID", cboSystemType_H.Value.ToString(), DbType.String, ParameterDirection.Input));
            }
            catch (Exception ex)
            {
                ThrowError(ex);
                return new DataTable();
            }
            finally
            {
                dBHelper.Close();
            }
        }

        public void USP_SY0070_CRUD(DataTable DtChange, string USER_ID)
        {
            grid1.SetRow();
            DBHelper dBHelper = new DBHelper(completedClose: false);
            string empty = string.Empty;
            int num = 0;
            txtProgramID.Focus();
            try
            {
                empty = Convert.ToString(grid1.ActiveRow.Cells["GRPID"].Value);
                if (DtChange.GetChanges() != null)
                {
                    foreach (DataRow row in DtChange.GetChanges().Rows)
                    {
                        switch (row.RowState)
                        {
                            case DataRowState.Deleted:
                                row.RejectChanges();
                                dBHelper.ExecuteNoneQuery("USP_SY0070_D1", CommandType.StoredProcedure, dBHelper.CreateParameter("AS_WORKERID", empty, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_MENUID", Convert.ToString(row["MENUID"]), DbType.String, ParameterDirection.Input));
                                break;
                            case DataRowState.Added:
                                num = Convert.ToInt32(row["MENUID"]);
                                dBHelper.ExecuteNoneQuery("USP_SY0070_I1", CommandType.StoredProcedure, dBHelper.CreateParameter("AS_WORKERID", empty, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_MENUID", num, DbType.Int32, ParameterDirection.Input), dBHelper.CreateParameter("AS_MENUNAME", Convert.ToString(row["MENUNAME"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_PARMENUID", Convert.ToInt32(row["PARMENUID"]), DbType.Int32, ParameterDirection.Input), dBHelper.CreateParameter("AS_SORT", Convert.ToInt32(row["SORT"]), DbType.Int32, ParameterDirection.Input), dBHelper.CreateParameter("AS_PROGRAMID", Convert.ToString(row["PROGRAMID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_MENUTYPE", Convert.ToString(row["MENUTYPE"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_USEFLAG", Convert.ToString(row["USEFLAG"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_REMARK", Convert.ToString(row["REMARK"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_MAKER", WorkerID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_EDITOR", WorkerID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_PROGRAMNAME", Convert.ToString(row["PROGRAMNAME"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_PROGTYPE", Convert.ToString(row["PROGTYPE"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_FILEID", Convert.ToString(row["FILEID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_NAMESPACE", Convert.ToString(row["NAMESPACE"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_INQFLAG", Convert.ToString(row["INQFLAG"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_NEWFLAG", Convert.ToString(row["NEWFLAG"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_DELFLAG", Convert.ToString(row["DELFLAG"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_SAVEFLAG", Convert.ToString(row["SAVEFLAG"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_EXCELFLAG", Convert.ToString(row["EXCELFLAG"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_PRNFLAG", Convert.ToString(row["PRNFLAG"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_EXEIMFLAG", Convert.ToString(row["EXEIMFLAG"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_PROGRAMREMARK", Convert.ToString(row["PROGRAMREMARK"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_SYSTEMID", DBHelper.nvlString(cboSystemType_H.Value), DbType.String, ParameterDirection.Input));
                                break;
                            case DataRowState.Modified:
                                num = Convert.ToInt32(row["MENUID"]);
                                dBHelper.ExecuteNoneQuery("USP_SY0070_U1", CommandType.StoredProcedure, dBHelper.CreateParameter("AS_WORKERID", empty, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_MENUID", num, DbType.Int32, ParameterDirection.Input), dBHelper.CreateParameter("AS_MENUNAME", Convert.ToString(row["MENUNAME"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_PARMENUID", Convert.ToInt32(row["PARMENUID"]), DbType.Int32, ParameterDirection.Input), dBHelper.CreateParameter("AS_SORT", Convert.ToInt32(row["SORT"]), DbType.Int16, ParameterDirection.Input), dBHelper.CreateParameter("AS_PROGRAMID", Convert.ToString(row["PROGRAMID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_MENUTYPE", Convert.ToString(row["MENUTYPE"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_USEFLAG", Convert.ToString(row["USEFLAG"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_REMARK", Convert.ToString(row["REMARK"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_MAKER", WorkerID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_EDITOR", WorkerID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_PROGRAMNAME", Convert.ToString(row["PROGRAMNAME"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_PROGTYPE", Convert.ToString(row["PROGTYPE"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_FILEID", Convert.ToString(row["FILEID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_NAMESPACE", Convert.ToString(row["NAMESPACE"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_INQFLAG", Convert.ToString(row["INQFLAG"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_NEWFLAG", Convert.ToString(row["NEWFLAG"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_DELFLAG", Convert.ToString(row["DELFLAG"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_SAVEFLAG", Convert.ToString(row["SAVEFLAG"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_EXCELFLAG", Convert.ToString(row["EXCELFLAG"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_PRNFLAG", Convert.ToString(row["PRNFLAG"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_EXEIMFLAG", Convert.ToString(row["EXEIMFLAG"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("AS_PROGRAMREMARK", Convert.ToString(row["PROGRAMREMARK"]), DbType.String, ParameterDirection.Input));
                                break;
                        }
                    }
                    dBHelper.Commit();
                }
            }
            catch (Exception ex)
            {
                base.CancelProcess = true;
                dBHelper.Rollback();
                ThrowError(ex);
            }
            finally
            {
                dBHelper.Close();
            }
        }

        private void scboProgramIDCode1_TextChanged(object sender, EventArgs e)
        {
            string text = Convert.ToString(scboProgramIDCode1.Value);
            DBHelper dBHelper = new DBHelper(completedClose: false);
            DataTable dataTable = new DataTable();
            try
            {
                string query = "   SELECT *                           FROM TSY0010 WITH(NOLOCK)       WHERE WorkerID  = 'SYSTEM'        AND ProgramID = '" + scboProgramIDCode1.Value + "' ";
                dataTable = dBHelper.FillTable(query, CommandType.Text);
                if (dataTable.Rows.Count > 0)
                {
                    cboMenuType.Value = Convert.ToString(dataTable.Rows[0]["PROGTYPE"]);
                    UseFlag.Value = 'Y';
                    txtProgramType.Text = Convert.ToString(dataTable.Rows[0]["PROGTYPE"]);
                    txtProgramID.Text = Convert.ToString(dataTable.Rows[0]["PROGRAMID"]);
                    uceDelFlag.Checked = DBHelper.nvlBoolean(dataTable.Rows[0]["DELFLAG"].ToString());
                    uceExcelFlag.Checked = DBHelper.nvlBoolean(dataTable.Rows[0]["EXCELFLAG"].ToString());
                    uceInqFlag.Checked = DBHelper.nvlBoolean(dataTable.Rows[0]["INQFLAG"].ToString());
                    uceNewFlag.Checked = DBHelper.nvlBoolean(dataTable.Rows[0]["NEWFLAG"].ToString());
                    ucePrnFlag.Checked = DBHelper.nvlBoolean(dataTable.Rows[0]["PRNFLAG"].ToString());
                    uceSaveFlag.Checked = DBHelper.nvlBoolean(dataTable.Rows[0]["SAVEFLAG"].ToString());
                    uceExcelIMFlag.Checked = DBHelper.nvlBoolean(dataTable.Rows[0]["EXEIMFLAG"].ToString());
                    txtFileID.Text = dataTable.Rows[0]["FILEID"].ToString();
                    txtNameSpace.Text = dataTable.Rows[0]["NameSpace"].ToString();
                }
            }
            catch (Exception ex)
            {
                ThrowError(ex);
            }
            finally
            {
                dBHelper.Close();
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

        private new void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTree.UltraTreeColumnSet ultraTreeColumnSet1 = new Infragistics.Win.UltraWinTree.UltraTreeColumnSet();
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SY0080));
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            this.txtPwd = new WIZ.Control.STextBox(this.components);
            this.lblWorkerID = new WIZ.Control.SLabel();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.gbxMenuInfor = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtRemark = new WIZ.Control.STextBox(this.components);
            this.txtMenuName = new WIZ.Control.STextBox(this.components);
            this.lblMenuType = new WIZ.Control.SLabel();
            this.cboMenuType = new WIZ.Control.SCodeNMComboBox();
            this.sLabel3 = new WIZ.Control.SLabel();
            this.lblMenuID = new WIZ.Control.SLabel();
            this.UseFlag = new WIZ.Control.SCodeNMComboBox();
            this.lblRemark = new WIZ.Control.SLabel();
            this.gbxProgramInfor = new Infragistics.Win.Misc.UltraGroupBox();
            this.scboProgramIDCode1 = new WIZ.Control.ScboProgramIDCode();
            this.txtRemark1 = new WIZ.Control.STextBox(this.components);
            this.txtFileID = new WIZ.Control.STextBox(this.components);
            this.txtNameSpace = new WIZ.Control.STextBox(this.components);
            this.txtProgramType = new WIZ.Control.STextBox(this.components);
            this.uceExcelIMFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.uceSumFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.uceExcelFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ucePrnFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.uceSaveFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.uceDelFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.uceNewFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.uceInqFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtProgramID = new WIZ.Control.STextBox(this.components);
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.sLabel1 = new WIZ.Control.SLabel();
            this.sLabel2 = new WIZ.Control.SLabel();
            this.lblRemark1 = new WIZ.Control.SLabel();
            this.lblNameSpace = new WIZ.Control.SLabel();
            this.lblFileID = new WIZ.Control.SLabel();
            this.ultraSplitter2 = new Infragistics.Win.Misc.UltraSplitter();
            this.treMenu = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraSplitter1 = new Infragistics.Win.Misc.UltraSplitter();
            this.grid1 = new WIZ.Control.Grid(this.components);
            this.btnCopy = new Infragistics.Win.Misc.UltraButton();
            this.cboSystemType_H = new WIZ.Control.SCodeNMComboBox();
            this.sLabel6 = new WIZ.Control.SLabel();
            this.imlMenu = new System.Windows.Forms.ImageList(this.components);
            this.txtWorkerName_H = new WIZ.Control.STextBox(this.components);
            this.txtWorkerID_H = new WIZ.Control.STextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxMenuInfor)).BeginInit();
            this.gbxMenuInfor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMenuName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMenuType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UseFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxProgramInfor)).BeginInit();
            this.gbxProgramInfor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scboProgramIDCode1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameSpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProgramType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceExcelIMFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceSumFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceExcelFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucePrnFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceSaveFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceDelFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceNewFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceInqFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProgramID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSystemType_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerName_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerID_H)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.txtWorkerID_H);
            this.gbxHeader.Controls.Add(this.txtWorkerName_H);
            this.gbxHeader.Controls.Add(this.cboSystemType_H);
            this.gbxHeader.Controls.Add(this.sLabel6);
            this.gbxHeader.Controls.Add(this.btnCopy);
            this.gbxHeader.Controls.Add(this.lblWorkerID);
            this.gbxHeader.Size = new System.Drawing.Size(1400, 70);
            this.gbxHeader.Controls.SetChildIndex(this.lblWorkerID, 0);
            this.gbxHeader.Controls.SetChildIndex(this.btnCopy, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel6, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboSystemType_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtWorkerName_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.txtWorkerID_H, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.ultraGroupBox1);
            this.gbxBody.Size = new System.Drawing.Size(1400, 755);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(132, 121);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtPwd.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtPwd.Size = new System.Drawing.Size(152, 29);
            this.txtPwd.TabIndex = 78;
            this.txtPwd.Text = "txtPassword";
            // 
            // lblWorkerID
            // 
            appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance.FontData.BoldAsString = "False";
            appearance.FontData.UnderlineAsString = "False";
            appearance.ForeColor = System.Drawing.Color.Black;
            appearance.TextHAlignAsString = "Left";
            this.lblWorkerID.Appearance = appearance;
            this.lblWorkerID.DbField = null;
            this.lblWorkerID.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWorkerID.Location = new System.Drawing.Point(110, 10);
            this.lblWorkerID.Name = "lblWorkerID";
            this.lblWorkerID.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblWorkerID.Size = new System.Drawing.Size(145, 25);
            this.lblWorkerID.TabIndex = 2;
            this.lblWorkerID.Text = "그룹ID";
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            this.ultraGroupBox1.Controls.Add(this.gbxMenuInfor);
            this.ultraGroupBox1.Controls.Add(this.gbxProgramInfor);
            this.ultraGroupBox1.Controls.Add(this.ultraSplitter2);
            this.ultraGroupBox1.Controls.Add(this.treMenu);
            this.ultraGroupBox1.Controls.Add(this.ultraSplitter1);
            this.ultraGroupBox1.Controls.Add(this.grid1);
            this.ultraGroupBox1.Controls.Add(this.txtPwd);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.Location = new System.Drawing.Point(6, 6);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(1388, 743);
            this.ultraGroupBox1.TabIndex = 2;
            // 
            // gbxMenuInfor
            // 
            this.gbxMenuInfor.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            this.gbxMenuInfor.Controls.Add(this.txtRemark);
            this.gbxMenuInfor.Controls.Add(this.txtMenuName);
            this.gbxMenuInfor.Controls.Add(this.lblMenuType);
            this.gbxMenuInfor.Controls.Add(this.cboMenuType);
            this.gbxMenuInfor.Controls.Add(this.sLabel3);
            this.gbxMenuInfor.Controls.Add(this.lblMenuID);
            this.gbxMenuInfor.Controls.Add(this.UseFlag);
            this.gbxMenuInfor.Controls.Add(this.lblRemark);
            this.gbxMenuInfor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxMenuInfor.Location = new System.Drawing.Point(564, 0);
            this.gbxMenuInfor.Name = "gbxMenuInfor";
            this.gbxMenuInfor.Size = new System.Drawing.Size(822, 251);
            this.gbxMenuInfor.TabIndex = 77;
            this.gbxMenuInfor.Text = "메뉴정보";
            // 
            // txtRemark
            // 
            this.txtRemark.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.txtRemark.Appearance = appearance2;
            this.txtRemark.AutoSize = false;
            this.txtRemark.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRemark.Location = new System.Drawing.Point(16, 161);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtRemark.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtRemark.Size = new System.Drawing.Size(790, 84);
            this.txtRemark.TabIndex = 244;
            // 
            // txtMenuName
            // 
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            this.txtMenuName.Appearance = appearance3;
            this.txtMenuName.AutoSize = false;
            this.txtMenuName.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMenuName.Location = new System.Drawing.Point(16, 56);
            this.txtMenuName.Name = "txtMenuName";
            this.txtMenuName.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtMenuName.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtMenuName.Size = new System.Drawing.Size(790, 27);
            this.txtMenuName.TabIndex = 243;
            // 
            // lblMenuType
            // 
            appearance4.FontData.BoldAsString = "False";
            appearance4.FontData.UnderlineAsString = "False";
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Left";
            this.lblMenuType.Appearance = appearance4;
            this.lblMenuType.DbField = null;
            this.lblMenuType.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMenuType.Location = new System.Drawing.Point(16, 84);
            this.lblMenuType.Name = "lblMenuType";
            this.lblMenuType.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblMenuType.Size = new System.Drawing.Size(210, 27);
            this.lblMenuType.TabIndex = 37;
            this.lblMenuType.Text = "메뉴유형";
            // 
            // cboMenuType
            // 
            this.cboMenuType.AutoSize = false;
            this.cboMenuType.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cboMenuType.ComboDataType = WIZ.Control.ComboDataType.CodeOnly;
            this.cboMenuType.DbConfig = null;
            this.cboMenuType.DefaultValue = "";
            appearance5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cboMenuType.DisplayLayout.Appearance = appearance5;
            this.cboMenuType.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.cboMenuType.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cboMenuType.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance6.BackColor = System.Drawing.Color.Gray;
            this.cboMenuType.DisplayLayout.CaptionAppearance = appearance6;
            this.cboMenuType.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.cboMenuType.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.RoyalBlue;
            this.cboMenuType.DisplayLayout.InterBandSpacing = 2;
            this.cboMenuType.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance7.BackColor = System.Drawing.Color.RoyalBlue;
            appearance7.FontData.BoldAsString = "True";
            appearance7.ForeColor = System.Drawing.Color.White;
            this.cboMenuType.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            appearance8.FontData.BoldAsString = "True";
            this.cboMenuType.DisplayLayout.Override.ActiveRowCellAppearance = appearance8;
            this.cboMenuType.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            this.cboMenuType.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.cboMenuType.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.None;
            this.cboMenuType.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010ScrollbarButton;
            appearance9.BackColor = System.Drawing.Color.DimGray;
            appearance9.BackColor2 = System.Drawing.Color.Silver;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance9.BorderColor = System.Drawing.Color.White;
            appearance9.FontData.BoldAsString = "True";
            appearance9.ForeColor = System.Drawing.Color.White;
            this.cboMenuType.DisplayLayout.Override.HeaderAppearance = appearance9;
            this.cboMenuType.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            appearance10.BackColor2 = System.Drawing.Color.Gray;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.cboMenuType.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance10;
            this.cboMenuType.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            this.cboMenuType.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            this.cboMenuType.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.cboMenuType.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(133)))), ((int)(((byte)(188)))));
            appearance11.FontData.BoldAsString = "True";
            this.cboMenuType.DisplayLayout.Override.SelectedRowAppearance = appearance11;
            this.cboMenuType.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            this.cboMenuType.DisplayLayout.RowConnectorColor = System.Drawing.Color.Silver;
            this.cboMenuType.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.cboMenuType.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.cboMenuType.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.cboMenuType.Location = new System.Drawing.Point(16, 111);
            this.cboMenuType.MajorCode = "MENUTYPE";
            this.cboMenuType.Name = "cboMenuType";
            this.cboMenuType.SelectedValue = null;
            this.cboMenuType.ShowDefaultValue = false;
            this.cboMenuType.Size = new System.Drawing.Size(210, 25);
            this.cboMenuType.TabIndex = 36;
            // 
            // sLabel3
            // 
            appearance12.FontData.BoldAsString = "False";
            appearance12.FontData.UnderlineAsString = "False";
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.TextHAlignAsString = "Left";
            this.sLabel3.Appearance = appearance12;
            this.sLabel3.DbField = null;
            this.sLabel3.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel3.Location = new System.Drawing.Point(278, 84);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel3.Size = new System.Drawing.Size(169, 27);
            this.sLabel3.TabIndex = 35;
            this.sLabel3.Text = "사용구분";
            // 
            // lblMenuID
            // 
            appearance13.FontData.BoldAsString = "False";
            appearance13.FontData.UnderlineAsString = "False";
            appearance13.ForeColor = System.Drawing.Color.Black;
            appearance13.TextHAlignAsString = "Left";
            this.lblMenuID.Appearance = appearance13;
            this.lblMenuID.DbField = null;
            this.lblMenuID.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMenuID.Location = new System.Drawing.Point(16, 31);
            this.lblMenuID.Name = "lblMenuID";
            this.lblMenuID.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblMenuID.Size = new System.Drawing.Size(522, 23);
            this.lblMenuID.TabIndex = 30;
            this.lblMenuID.Text = "메뉴";
            // 
            // UseFlag
            // 
            this.UseFlag.AutoSize = false;
            this.UseFlag.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.UseFlag.ComboDataType = WIZ.Control.ComboDataType.CodeOnly;
            this.UseFlag.DbConfig = null;
            this.UseFlag.DefaultValue = "";
            appearance14.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance14.FontData.BoldAsString = "False";
            appearance14.FontData.UnderlineAsString = "False";
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.TextHAlignAsString = "Left";
            appearance14.TextVAlignAsString = "Middle";
            this.UseFlag.DisplayLayout.Appearance = appearance14;
            this.UseFlag.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.UseFlag.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.UseFlag.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.UseFlag.DisplayLayout.CaptionAppearance = appearance15;
            this.UseFlag.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.UseFlag.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.RoyalBlue;
            this.UseFlag.DisplayLayout.InterBandSpacing = 2;
            this.UseFlag.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance16.BackColor = System.Drawing.Color.RoyalBlue;
            appearance16.FontData.BoldAsString = "True";
            appearance16.ForeColor = System.Drawing.Color.White;
            this.UseFlag.DisplayLayout.Override.ActiveRowAppearance = appearance16;
            appearance17.FontData.BoldAsString = "True";
            this.UseFlag.DisplayLayout.Override.ActiveRowCellAppearance = appearance17;
            this.UseFlag.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            this.UseFlag.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.UseFlag.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.None;
            this.UseFlag.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010ScrollbarButton;
            appearance18.BackColor = System.Drawing.Color.DimGray;
            appearance18.BackColor2 = System.Drawing.Color.Silver;
            appearance18.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance18.BorderColor = System.Drawing.Color.White;
            appearance18.FontData.BoldAsString = "True";
            appearance18.ForeColor = System.Drawing.Color.White;
            this.UseFlag.DisplayLayout.Override.HeaderAppearance = appearance18;
            this.UseFlag.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            appearance19.BackColor2 = System.Drawing.Color.Gray;
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.UseFlag.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance19;
            this.UseFlag.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            this.UseFlag.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            this.UseFlag.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.UseFlag.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(133)))), ((int)(((byte)(188)))));
            appearance20.FontData.BoldAsString = "True";
            this.UseFlag.DisplayLayout.Override.SelectedRowAppearance = appearance20;
            this.UseFlag.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            this.UseFlag.DisplayLayout.RowConnectorColor = System.Drawing.Color.Silver;
            this.UseFlag.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.UseFlag.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.UseFlag.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.UseFlag.Location = new System.Drawing.Point(278, 111);
            this.UseFlag.MajorCode = "USEFLAG";
            this.UseFlag.Name = "UseFlag";
            this.UseFlag.SelectedValue = null;
            this.UseFlag.ShowDefaultValue = false;
            this.UseFlag.Size = new System.Drawing.Size(169, 25);
            this.UseFlag.TabIndex = 34;
            // 
            // lblRemark
            // 
            appearance21.FontData.BoldAsString = "False";
            appearance21.FontData.UnderlineAsString = "False";
            appearance21.ForeColor = System.Drawing.Color.Black;
            appearance21.TextHAlignAsString = "Left";
            this.lblRemark.Appearance = appearance21;
            this.lblRemark.DbField = null;
            this.lblRemark.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRemark.Location = new System.Drawing.Point(16, 138);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblRemark.Size = new System.Drawing.Size(100, 21);
            this.lblRemark.TabIndex = 32;
            this.lblRemark.Text = "비고";
            // 
            // gbxProgramInfor
            // 
            this.gbxProgramInfor.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            this.gbxProgramInfor.Controls.Add(this.scboProgramIDCode1);
            this.gbxProgramInfor.Controls.Add(this.txtRemark1);
            this.gbxProgramInfor.Controls.Add(this.txtFileID);
            this.gbxProgramInfor.Controls.Add(this.txtNameSpace);
            this.gbxProgramInfor.Controls.Add(this.txtProgramType);
            this.gbxProgramInfor.Controls.Add(this.uceExcelIMFlag);
            this.gbxProgramInfor.Controls.Add(this.uceSumFlag);
            this.gbxProgramInfor.Controls.Add(this.uceExcelFlag);
            this.gbxProgramInfor.Controls.Add(this.ucePrnFlag);
            this.gbxProgramInfor.Controls.Add(this.uceSaveFlag);
            this.gbxProgramInfor.Controls.Add(this.uceDelFlag);
            this.gbxProgramInfor.Controls.Add(this.uceNewFlag);
            this.gbxProgramInfor.Controls.Add(this.uceInqFlag);
            this.gbxProgramInfor.Controls.Add(this.txtProgramID);
            this.gbxProgramInfor.Controls.Add(this.sLabel1);
            this.gbxProgramInfor.Controls.Add(this.sLabel2);
            this.gbxProgramInfor.Controls.Add(this.lblRemark1);
            this.gbxProgramInfor.Controls.Add(this.lblNameSpace);
            this.gbxProgramInfor.Controls.Add(this.lblFileID);
            this.gbxProgramInfor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbxProgramInfor.Location = new System.Drawing.Point(564, 251);
            this.gbxProgramInfor.Name = "gbxProgramInfor";
            this.gbxProgramInfor.Size = new System.Drawing.Size(822, 490);
            this.gbxProgramInfor.TabIndex = 76;
            this.gbxProgramInfor.Text = "프로그램 정보";
            // 
            // scboProgramIDCode1
            // 
            this.scboProgramIDCode1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scboProgramIDCode1.AutoSize = false;
            this.scboProgramIDCode1.ComboDataType = WIZ.Control.ComboDataType.CodeOnly;
            this.scboProgramIDCode1.DbConfig = null;
            this.scboProgramIDCode1.DefaultValue = "";
            appearance22.BackColor = System.Drawing.SystemColors.Window;
            appearance22.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.scboProgramIDCode1.DisplayLayout.Appearance = appearance22;
            this.scboProgramIDCode1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.scboProgramIDCode1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.scboProgramIDCode1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance23.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance23.BorderColor = System.Drawing.SystemColors.Window;
            this.scboProgramIDCode1.DisplayLayout.GroupByBox.Appearance = appearance23;
            appearance24.ForeColor = System.Drawing.SystemColors.GrayText;
            this.scboProgramIDCode1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance24;
            this.scboProgramIDCode1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance25.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance25.BackColor2 = System.Drawing.SystemColors.Control;
            appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance25.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance25.ForeColor = System.Drawing.SystemColors.GrayText;
            this.scboProgramIDCode1.DisplayLayout.GroupByBox.PromptAppearance = appearance25;
            this.scboProgramIDCode1.DisplayLayout.MaxColScrollRegions = 1;
            this.scboProgramIDCode1.DisplayLayout.MaxRowScrollRegions = 1;
            this.scboProgramIDCode1.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance26.BackColor = System.Drawing.Color.DimGray;
            appearance26.BackColor2 = System.Drawing.Color.Silver;
            appearance26.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance26.BorderColor = System.Drawing.Color.White;
            appearance26.FontData.BoldAsString = "True";
            appearance26.ForeColor = System.Drawing.Color.White;
            this.scboProgramIDCode1.DisplayLayout.Override.ActiveCellAppearance = appearance26;
            appearance27.BackColor = System.Drawing.Color.RoyalBlue;
            appearance27.FontData.BoldAsString = "True";
            appearance27.ForeColor = System.Drawing.Color.White;
            this.scboProgramIDCode1.DisplayLayout.Override.ActiveRowAppearance = appearance27;
            appearance28.FontData.BoldAsString = "True";
            this.scboProgramIDCode1.DisplayLayout.Override.ActiveRowCellAppearance = appearance28;
            this.scboProgramIDCode1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            this.scboProgramIDCode1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.scboProgramIDCode1.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.None;
            this.scboProgramIDCode1.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010ScrollbarButton;
            appearance29.BackColor = System.Drawing.SystemColors.Window;
            this.scboProgramIDCode1.DisplayLayout.Override.CardAreaAppearance = appearance29;
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            appearance30.BorderColor = System.Drawing.Color.Silver;
            this.scboProgramIDCode1.DisplayLayout.Override.CellAppearance = appearance30;
            this.scboProgramIDCode1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.scboProgramIDCode1.DisplayLayout.Override.CellPadding = 0;
            appearance31.BackColor = System.Drawing.Color.Gray;
            appearance31.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance31.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance31.BorderColor = System.Drawing.SystemColors.Window;
            this.scboProgramIDCode1.DisplayLayout.Override.GroupByRowAppearance = appearance31;
            appearance32.BackColor = System.Drawing.Color.RoyalBlue;
            appearance32.FontData.BoldAsString = "True";
            appearance32.ForeColor = System.Drawing.Color.White;
            appearance32.TextHAlignAsString = "Left";
            this.scboProgramIDCode1.DisplayLayout.Override.HeaderAppearance = appearance32;
            this.scboProgramIDCode1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.scboProgramIDCode1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance33.BackColor = System.Drawing.SystemColors.Window;
            appearance33.BorderColor = System.Drawing.Color.Silver;
            this.scboProgramIDCode1.DisplayLayout.Override.RowAppearance = appearance33;
            this.scboProgramIDCode1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance34.BackColor = System.Drawing.SystemColors.ControlLight;
            this.scboProgramIDCode1.DisplayLayout.Override.TemplateAddRowAppearance = appearance34;
            this.scboProgramIDCode1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.scboProgramIDCode1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.scboProgramIDCode1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.scboProgramIDCode1.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.scboProgramIDCode1.Location = new System.Drawing.Point(18, 49);
            this.scboProgramIDCode1.MajorCode = null;
            this.scboProgramIDCode1.Name = "scboProgramIDCode1";
            this.scboProgramIDCode1.ShowDefaultValue = false;
            this.scboProgramIDCode1.Size = new System.Drawing.Size(790, 30);
            this.scboProgramIDCode1.SystemID = "";
            this.scboProgramIDCode1.TabIndex = 249;
            this.scboProgramIDCode1.ValueChanged += new System.EventHandler(this.scboProgramIDCode1_ValueChanged);
            this.scboProgramIDCode1.TextChanged += new System.EventHandler(this.scboProgramIDCode1_TextChanged);
            // 
            // txtRemark1
            // 
            this.txtRemark1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance35.FontData.BoldAsString = "False";
            appearance35.FontData.UnderlineAsString = "False";
            appearance35.ForeColor = System.Drawing.Color.Black;
            this.txtRemark1.Appearance = appearance35;
            this.txtRemark1.AutoSize = false;
            this.txtRemark1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRemark1.Location = new System.Drawing.Point(18, 333);
            this.txtRemark1.Name = "txtRemark1";
            this.txtRemark1.ReadOnly = true;
            this.txtRemark1.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtRemark1.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtRemark1.Size = new System.Drawing.Size(790, 135);
            this.txtRemark1.TabIndex = 248;
            // 
            // txtFileID
            // 
            appearance36.FontData.BoldAsString = "False";
            appearance36.FontData.UnderlineAsString = "False";
            appearance36.ForeColor = System.Drawing.Color.Black;
            this.txtFileID.Appearance = appearance36;
            this.txtFileID.AutoSize = false;
            this.txtFileID.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtFileID.Location = new System.Drawing.Point(18, 277);
            this.txtFileID.Name = "txtFileID";
            this.txtFileID.ReadOnly = true;
            this.txtFileID.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtFileID.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtFileID.Size = new System.Drawing.Size(790, 27);
            this.txtFileID.TabIndex = 247;
            // 
            // txtNameSpace
            // 
            appearance37.FontData.BoldAsString = "False";
            appearance37.FontData.UnderlineAsString = "False";
            appearance37.ForeColor = System.Drawing.Color.Black;
            this.txtNameSpace.Appearance = appearance37;
            this.txtNameSpace.AutoSize = false;
            this.txtNameSpace.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtNameSpace.Location = new System.Drawing.Point(18, 223);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.ReadOnly = true;
            this.txtNameSpace.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtNameSpace.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtNameSpace.Size = new System.Drawing.Size(790, 27);
            this.txtNameSpace.TabIndex = 246;
            // 
            // txtProgramType
            // 
            appearance38.FontData.BoldAsString = "False";
            appearance38.FontData.UnderlineAsString = "False";
            appearance38.ForeColor = System.Drawing.Color.Black;
            this.txtProgramType.Appearance = appearance38;
            this.txtProgramType.AutoSize = false;
            this.txtProgramType.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProgramType.Location = new System.Drawing.Point(18, 104);
            this.txtProgramType.Name = "txtProgramType";
            this.txtProgramType.ReadOnly = true;
            this.txtProgramType.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtProgramType.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtProgramType.Size = new System.Drawing.Size(243, 27);
            this.txtProgramType.TabIndex = 245;
            // 
            // uceExcelIMFlag
            // 
            this.uceExcelIMFlag.Location = new System.Drawing.Point(354, 170);
            this.uceExcelIMFlag.Name = "uceExcelIMFlag";
            this.uceExcelIMFlag.Size = new System.Drawing.Size(144, 20);
            this.uceExcelIMFlag.TabIndex = 52;
            this.uceExcelIMFlag.Text = "엑셀 ▲";
            // 
            // uceSumFlag
            // 
            this.uceSumFlag.Location = new System.Drawing.Point(518, 171);
            this.uceSumFlag.Name = "uceSumFlag";
            this.uceSumFlag.Size = new System.Drawing.Size(144, 20);
            this.uceSumFlag.TabIndex = 50;
            this.uceSumFlag.Text = "합계";
            this.uceSumFlag.Visible = false;
            // 
            // uceExcelFlag
            // 
            this.uceExcelFlag.Location = new System.Drawing.Point(185, 171);
            this.uceExcelFlag.Name = "uceExcelFlag";
            this.uceExcelFlag.Size = new System.Drawing.Size(144, 20);
            this.uceExcelFlag.TabIndex = 51;
            this.uceExcelFlag.Text = "엑셀 ▼";
            // 
            // ucePrnFlag
            // 
            this.ucePrnFlag.Location = new System.Drawing.Point(18, 170);
            this.ucePrnFlag.Name = "ucePrnFlag";
            this.ucePrnFlag.Size = new System.Drawing.Size(144, 20);
            this.ucePrnFlag.TabIndex = 49;
            this.ucePrnFlag.Text = "출력";
            // 
            // uceSaveFlag
            // 
            this.uceSaveFlag.Location = new System.Drawing.Point(518, 145);
            this.uceSaveFlag.Name = "uceSaveFlag";
            this.uceSaveFlag.Size = new System.Drawing.Size(144, 20);
            this.uceSaveFlag.TabIndex = 48;
            this.uceSaveFlag.Text = "저장";
            // 
            // uceDelFlag
            // 
            this.uceDelFlag.Location = new System.Drawing.Point(354, 145);
            this.uceDelFlag.Name = "uceDelFlag";
            this.uceDelFlag.Size = new System.Drawing.Size(144, 20);
            this.uceDelFlag.TabIndex = 47;
            this.uceDelFlag.Text = "삭제";
            // 
            // uceNewFlag
            // 
            this.uceNewFlag.Location = new System.Drawing.Point(185, 144);
            this.uceNewFlag.Name = "uceNewFlag";
            this.uceNewFlag.Size = new System.Drawing.Size(144, 20);
            this.uceNewFlag.TabIndex = 46;
            this.uceNewFlag.Text = "신규";
            // 
            // uceInqFlag
            // 
            this.uceInqFlag.Location = new System.Drawing.Point(18, 144);
            this.uceInqFlag.Name = "uceInqFlag";
            this.uceInqFlag.Size = new System.Drawing.Size(144, 20);
            this.uceInqFlag.TabIndex = 45;
            this.uceInqFlag.Text = "조회";
            // 
            // txtProgramID
            // 
            this.txtProgramID.AutoSize = false;
            this.txtProgramID.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bs, "ProgramID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtProgramID.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProgramID.Location = new System.Drawing.Point(402, 104);
            this.txtProgramID.Name = "txtProgramID";
            this.txtProgramID.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtProgramID.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtProgramID.Size = new System.Drawing.Size(169, 27);
            this.txtProgramID.TabIndex = 28;
            this.txtProgramID.Visible = false;
            // 
            // bs
            // 
            this.bs.AllowNew = true;
            // 
            // sLabel1
            // 
            appearance39.FontData.BoldAsString = "False";
            appearance39.FontData.UnderlineAsString = "False";
            appearance39.ForeColor = System.Drawing.Color.Black;
            appearance39.TextHAlignAsString = "Left";
            this.sLabel1.Appearance = appearance39;
            this.sLabel1.DbField = null;
            this.sLabel1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel1.Location = new System.Drawing.Point(18, 27);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(680, 23);
            this.sLabel1.TabIndex = 27;
            this.sLabel1.Text = "프로그램";
            // 
            // sLabel2
            // 
            appearance40.FontData.BoldAsString = "False";
            appearance40.FontData.UnderlineAsString = "False";
            appearance40.ForeColor = System.Drawing.Color.Black;
            appearance40.TextHAlignAsString = "Left";
            this.sLabel2.Appearance = appearance40;
            this.sLabel2.DbField = null;
            this.sLabel2.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel2.Location = new System.Drawing.Point(18, 79);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel2.Size = new System.Drawing.Size(333, 23);
            this.sLabel2.TabIndex = 29;
            this.sLabel2.Text = "프로그램유형";
            // 
            // lblRemark1
            // 
            appearance41.FontData.BoldAsString = "False";
            appearance41.FontData.UnderlineAsString = "False";
            appearance41.ForeColor = System.Drawing.Color.Black;
            appearance41.TextHAlignAsString = "Left";
            this.lblRemark1.Appearance = appearance41;
            this.lblRemark1.DbField = null;
            this.lblRemark1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRemark1.Location = new System.Drawing.Point(18, 306);
            this.lblRemark1.Name = "lblRemark1";
            this.lblRemark1.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblRemark1.Size = new System.Drawing.Size(100, 27);
            this.lblRemark1.TabIndex = 41;
            this.lblRemark1.Text = "비고";
            // 
            // lblNameSpace
            // 
            appearance42.FontData.BoldAsString = "False";
            appearance42.FontData.UnderlineAsString = "False";
            appearance42.ForeColor = System.Drawing.Color.Black;
            appearance42.TextHAlignAsString = "Left";
            this.lblNameSpace.Appearance = appearance42;
            this.lblNameSpace.DbField = null;
            this.lblNameSpace.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNameSpace.Location = new System.Drawing.Point(18, 198);
            this.lblNameSpace.Name = "lblNameSpace";
            this.lblNameSpace.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblNameSpace.Size = new System.Drawing.Size(680, 23);
            this.lblNameSpace.TabIndex = 37;
            this.lblNameSpace.Text = "네임스페이스";
            // 
            // lblFileID
            // 
            appearance43.FontData.BoldAsString = "False";
            appearance43.FontData.UnderlineAsString = "False";
            appearance43.ForeColor = System.Drawing.Color.Black;
            appearance43.TextHAlignAsString = "Left";
            this.lblFileID.Appearance = appearance43;
            this.lblFileID.DbField = null;
            this.lblFileID.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblFileID.Location = new System.Drawing.Point(18, 252);
            this.lblFileID.Name = "lblFileID";
            this.lblFileID.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblFileID.Size = new System.Drawing.Size(680, 23);
            this.lblFileID.TabIndex = 39;
            this.lblFileID.Text = "파일";
            // 
            // ultraSplitter2
            // 
            this.ultraSplitter2.Location = new System.Drawing.Point(556, 0);
            this.ultraSplitter2.Name = "ultraSplitter2";
            this.ultraSplitter2.RestoreExtent = 350;
            this.ultraSplitter2.Size = new System.Drawing.Size(8, 741);
            this.ultraSplitter2.TabIndex = 78;
            // 
            // treMenu
            // 
            this.treMenu.AllowDrop = true;
            this.treMenu.Appearance = appearance51;
            this.treMenu.ColumnSettings.AllowSorting = Infragistics.Win.DefaultableBoolean.True;
            this.treMenu.ColumnSettings.ColumnAutoSizeMode = Infragistics.Win.UltraWinTree.ColumnAutoSizeMode.VisibleNodes;
            this.treMenu.ColumnSettings.LabelPosition = Infragistics.Win.UltraWinTree.NodeLayoutLabelPosition.None;
            this.treMenu.ColumnSettings.NullText = "*";
            ultraTreeColumnSet1.LabelPosition = Infragistics.Win.UltraWinTree.NodeLayoutLabelPosition.None;
            ultraTreeColumnSet1.NullText = "*";
            this.treMenu.ColumnSettings.RootColumnSet = ultraTreeColumnSet1;
            this.treMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.treMenu.ImagePadding = 15;
            this.treMenu.Location = new System.Drawing.Point(281, 0);
            this.treMenu.Name = "treMenu";
            this.treMenu.NodeConnectorColor = System.Drawing.Color.Gray;
            this.treMenu.NodeConnectorStyle = Infragistics.Win.UltraWinTree.NodeConnectorStyle.Solid;
            _override1.AllowAutoDragExpand = Infragistics.Win.UltraWinTree.AllowAutoDragExpand.ExpandOnDragHoverWhenExpansionIndicatorVisible;
            _override1.SelectionType = Infragistics.Win.UltraWinTree.SelectType.SingleAutoDrag;
            _override1.ShowColumns = Infragistics.Win.DefaultableBoolean.False;
            _override1.Sort = Infragistics.Win.UltraWinTree.SortType.Ascending;
            this.treMenu.Override = _override1;
            this.treMenu.Size = new System.Drawing.Size(275, 741);
            this.treMenu.TabIndex = 70;
            this.treMenu.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.treMenu.SelectionDragStart += new System.EventHandler(this.treMenu_SelectionDragStart);
            this.treMenu.InitializeDataNode += new Infragistics.Win.UltraWinTree.InitializeDataNodeEventHandler(this.treMenu_InitializeDataNode);
            this.treMenu.ColumnSetGenerated += new Infragistics.Win.UltraWinTree.ColumnSetGeneratedEventHandler(this.treMenu_ColumnSetGenerated);
            this.treMenu.Click += new System.EventHandler(this.treMenu_Click);
            this.treMenu.DragDrop += new System.Windows.Forms.DragEventHandler(this.treMenu_DragDrop);
            this.treMenu.DragOver += new System.Windows.Forms.DragEventHandler(this.treMenu_DragOver);
            this.treMenu.DragLeave += new System.EventHandler(this.treMenu_DragLeave);
            this.treMenu.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.treMenu_QueryContinueDrag);
            this.treMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treMenu_MouseDown);
            this.treMenu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treMenu_MouseUp);
            // 
            // ultraSplitter1
            // 
            this.ultraSplitter1.Location = new System.Drawing.Point(273, 0);
            this.ultraSplitter1.Name = "ultraSplitter1";
            this.ultraSplitter1.RestoreExtent = 439;
            this.ultraSplitter1.Size = new System.Drawing.Size(8, 741);
            this.ultraSplitter1.TabIndex = 73;
            // 
            // grid1
            // 
            this.grid1.AutoResizeColumn = true;
            this.grid1.AutoUserColumn = true;
            this.grid1.ContextMenuCopyEnabled = true;
            this.grid1.ContextMenuDeleteEnabled = true;
            this.grid1.ContextMenuExcelEnabled = true;
            this.grid1.ContextMenuInsertEnabled = true;
            this.grid1.ContextMenuPasteEnabled = true;
            this.grid1.DeleteButtonEnable = true;
            appearance44.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance44.BackColor2 = System.Drawing.SystemColors.Control;
            appearance44.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance44.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance44.ForeColor = System.Drawing.Color.Black;
            this.grid1.DisplayLayout.Appearance = appearance44;
            this.grid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance45.BackColor = System.Drawing.Color.Gray;
            appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance45.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance45.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.CaptionAppearance = appearance45;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.RoyalBlue;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            this.grid1.DisplayLayout.InterBandSpacing = 2;
            this.grid1.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance46.BackColor = System.Drawing.Color.RoyalBlue;
            appearance46.FontData.BoldAsString = "True";
            appearance46.ForeColor = System.Drawing.Color.White;
            appearance46.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance46;
            this.grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.DisplayLayout.Override.AllowMultiCellOperations = ((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)((((((((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders)
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut)
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Delete)
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste)
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Undo)
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Redo)
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Reserved)));
            this.grid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010ScrollbarButton;
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            appearance47.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.DataErrorRowAppearance = appearance47;
            appearance48.BackColor = System.Drawing.Color.DimGray;
            appearance48.BackColor2 = System.Drawing.Color.Silver;
            appearance48.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance48.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance48.BorderColor = System.Drawing.Color.White;
            appearance48.FontData.BoldAsString = "True";
            appearance48.ForeColor = System.Drawing.Color.White;
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance48;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.grid1.DisplayLayout.Override.RowEditTemplateUIType = Infragistics.Win.UltraWinGrid.RowEditTemplateUIType.None;
            appearance49.TextHAlignAsString = "Center";
            this.grid1.DisplayLayout.Override.RowSelectorAppearance = appearance49;
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            appearance50.BackColor2 = System.Drawing.Color.Gray;
            appearance50.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grid1.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance50;
            this.grid1.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            this.grid1.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
            this.grid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.RowsAndCells;
            this.grid1.DisplayLayout.RowConnectorColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Left;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.grid1.Location = new System.Drawing.Point(2, 0);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(271, 741);
            this.grid1.TabIndex = 72;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.ClickCell += new Infragistics.Win.UltraWinGrid.ClickCellEventHandler(this.grid1_ClickCell);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            appearance51.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            appearance51.FontData.BoldAsString = "True";
            appearance51.FontData.Name = "맑은 고딕";
            appearance51.FontData.SizeInPoints = 10F;
            appearance51.Image = global::WIZ.SY.Properties.Resources.edit_copy;
            this.btnCopy.Appearance = appearance51;
            this.btnCopy.Location = new System.Drawing.Point(1257, 12);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(126, 49);
            this.btnCopy.TabIndex = 30;
            this.btnCopy.Text = "권한 복사";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // cboSystemType_H
            // 
            this.cboSystemType_H.AutoSize = false;
            this.cboSystemType_H.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cboSystemType_H.ComboDataType = WIZ.Control.ComboDataType.CodeOnly;
            this.cboSystemType_H.DbConfig = null;
            this.cboSystemType_H.DefaultValue = "";
            appearance52.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cboSystemType_H.DisplayLayout.Appearance = appearance52;
            this.cboSystemType_H.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.cboSystemType_H.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cboSystemType_H.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance53.BackColor = System.Drawing.Color.Gray;
            this.cboSystemType_H.DisplayLayout.CaptionAppearance = appearance53;
            this.cboSystemType_H.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.cboSystemType_H.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.RoyalBlue;
            this.cboSystemType_H.DisplayLayout.InterBandSpacing = 2;
            this.cboSystemType_H.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance54.BackColor = System.Drawing.Color.RoyalBlue;
            appearance54.FontData.BoldAsString = "True";
            appearance54.ForeColor = System.Drawing.Color.White;
            this.cboSystemType_H.DisplayLayout.Override.ActiveRowAppearance = appearance54;
            appearance55.FontData.BoldAsString = "True";
            this.cboSystemType_H.DisplayLayout.Override.ActiveRowCellAppearance = appearance55;
            this.cboSystemType_H.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            this.cboSystemType_H.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.cboSystemType_H.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.None;
            this.cboSystemType_H.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010ScrollbarButton;
            appearance56.BackColor = System.Drawing.Color.DimGray;
            appearance56.BackColor2 = System.Drawing.Color.Silver;
            appearance56.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance56.BorderColor = System.Drawing.Color.White;
            appearance56.FontData.BoldAsString = "True";
            appearance56.ForeColor = System.Drawing.Color.White;
            this.cboSystemType_H.DisplayLayout.Override.HeaderAppearance = appearance56;
            this.cboSystemType_H.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            appearance57.BackColor2 = System.Drawing.Color.Gray;
            appearance57.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.cboSystemType_H.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance57;
            this.cboSystemType_H.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            this.cboSystemType_H.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            this.cboSystemType_H.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.cboSystemType_H.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(133)))), ((int)(((byte)(188)))));
            appearance58.FontData.BoldAsString = "True";
            this.cboSystemType_H.DisplayLayout.Override.SelectedRowAppearance = appearance58;
            this.cboSystemType_H.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            this.cboSystemType_H.DisplayLayout.RowConnectorColor = System.Drawing.Color.Silver;
            this.cboSystemType_H.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.cboSystemType_H.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.cboSystemType_H.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cboSystemType_H.DropDownWidth = 250;
            this.cboSystemType_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboSystemType_H.Location = new System.Drawing.Point(486, 35);
            this.cboSystemType_H.MajorCode = "SYSTEMID";
            this.cboSystemType_H.Name = "cboSystemType_H";
            this.cboSystemType_H.SelectedValue = null;
            this.cboSystemType_H.ShowDefaultValue = false;
            this.cboSystemType_H.Size = new System.Drawing.Size(204, 26);
            this.cboSystemType_H.TabIndex = 225;
            this.cboSystemType_H.ValueChanged += new System.EventHandler(this.cboSystemType_H_ValueChanged);
            // 
            // sLabel6
            // 
            appearance59.FontData.BoldAsString = "False";
            appearance59.FontData.UnderlineAsString = "False";
            appearance59.ForeColor = System.Drawing.Color.Black;
            appearance59.TextHAlignAsString = "Left";
            appearance59.TextVAlignAsString = "Middle";
            this.sLabel6.Appearance = appearance59;
            this.sLabel6.DbField = null;
            this.sLabel6.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel6.Location = new System.Drawing.Point(486, 9);
            this.sLabel6.Name = "sLabel6";
            this.sLabel6.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel6.Size = new System.Drawing.Size(238, 27);
            this.sLabel6.TabIndex = 224;
            this.sLabel6.Text = "시스템구분";
            // 
            // imlMenu
            // 
            this.imlMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlMenu.ImageStream")));
            this.imlMenu.TransparentColor = System.Drawing.Color.Transparent;
            this.imlMenu.Images.SetKeyName(0, "Folder Yellow Live Back.png");
            this.imlMenu.Images.SetKeyName(1, "window_dialog.ico");
            this.imlMenu.Images.SetKeyName(2, "folder01+.gif");
            this.imlMenu.Images.SetKeyName(3, "file01.gif");
            this.imlMenu.Images.SetKeyName(4, "folder02-.gif");
            // 
            // txtWorkerName_H
            // 
            appearance60.FontData.BoldAsString = "False";
            appearance60.FontData.UnderlineAsString = "False";
            appearance60.ForeColor = System.Drawing.Color.Black;
            this.txtWorkerName_H.Appearance = appearance60;
            this.txtWorkerName_H.AutoSize = false;
            this.txtWorkerName_H.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtWorkerName_H.Location = new System.Drawing.Point(232, 35);
            this.txtWorkerName_H.Name = "txtWorkerName_H";
            this.txtWorkerName_H.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtWorkerName_H.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtWorkerName_H.Size = new System.Drawing.Size(208, 26);
            this.txtWorkerName_H.TabIndex = 242;
            // 
            // txtWorkerID_H
            // 
            appearance61.FontData.BoldAsString = "False";
            appearance61.FontData.UnderlineAsString = "False";
            appearance61.ForeColor = System.Drawing.Color.Black;
            this.txtWorkerID_H.Appearance = appearance61;
            this.txtWorkerID_H.AutoSize = false;
            this.txtWorkerID_H.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtWorkerID_H.Location = new System.Drawing.Point(110, 35);
            this.txtWorkerID_H.Name = "txtWorkerID_H";
            this.txtWorkerID_H.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtWorkerID_H.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtWorkerID_H.Size = new System.Drawing.Size(120, 26);
            this.txtWorkerID_H.TabIndex = 243;
            // 
            // SY0080
            // 
            this.ClientSize = new System.Drawing.Size(1400, 825);
            this.Name = "SY0080";
            this.Load += new System.EventHandler(this.SY0080_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxMenuInfor)).EndInit();
            this.gbxMenuInfor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMenuName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMenuType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UseFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxProgramInfor)).EndInit();
            this.gbxProgramInfor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scboProgramIDCode1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameSpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProgramType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceExcelIMFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceSumFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceExcelFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucePrnFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceSaveFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceDelFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceNewFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceInqFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProgramID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSystemType_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerName_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerID_H)).EndInit();
            this.ResumeLayout(false);

        }
    }
}

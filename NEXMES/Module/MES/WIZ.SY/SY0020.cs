using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinTree;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WIZ.Control;
using WIZ.Forms;

namespace WIZ.SY
{
    public class SY0020 : BaseMDIChildForm
    {
        private UltraTree_DropHightLight_DrawFilter_Class UltraTree_DropHightLight_DrawFilter = new UltraTree_DropHightLight_DrawFilter_Class();

        private DataTable DtTemp = new DataTable();

        private DataSet rtnDsTemp = new DataSet();

        private bool binit = false;

        private int menuid = 0;

        private Binding INQFLAG = null;

        private Binding DELFLAG = null;

        private Binding PRNFLAG = null;

        private Binding NEWFLAG = null;

        private Binding SAVEFLAG = null;

        private Binding EXCELFLAG = null;

        private Binding EXEIMFLAG = null;

        private string[] Ex_Node;

        private int ex_node_cnt = 0;

        private bool _bSave = false;

        private UltraTreeNode DragNode = null;

        private UltraTreeNode DropNode = null;

        private new IContainer components = null;

        private SLabel lblUseFlag_H;

        private UltraGroupBox ultraGroupBox1;
        private STextBox txtRemark1;
        private SLabel lblRemark1;
        private STextBox txtFileID;
        private SLabel lblFileID;
        private STextBox txtNameSpace;
        private SLabel lblNameSpace;
        private STextBox txtProgramType;
        private SLabel sLabel2;

        private SLabel sLabel1;

        private UltraSplitter ultraSplitter1;

        private UltraTree treMenu;

        private UltraGroupBox gbxMenuInfor;

        private SLabel lblMenuType;

        private SLabel sLabel3;

        private SLabel lblMenuID;

        private SLabel lblRemark;

        private UltraGroupBox gbxProgramInfor;

        private BindingSource bs;

        private ImageList imlMenu;

        private SLabel sLabel6;

        private SCodeNMComboBox cboUseFlag_H;
        private STextBox txtProgramID;
        private SCodeNMComboBox cboMenuType;

        private SCodeNMComboBox UseFlag;

        private SCodeNMComboBox cboSystemType_H;

        private ScboProgramIDCode scboProgramIDCode1;

        private UltraCheckEditor uceExcelIMFlag;

        private UltraCheckEditor uceSumFlag;

        private UltraCheckEditor uceExcelFlag;

        private UltraCheckEditor ucePrnFlag;

        private UltraCheckEditor uceSaveFlag;

        private UltraCheckEditor uceDelFlag;

        private UltraCheckEditor uceNewFlag;

        private UltraCheckEditor uceInqFlag;

        private WIZ.Control.STextBox txtMenuName;

        private WIZ.Control.STextBox txtRemark;

        public SY0020()
        {
            InitializeComponent();
            UltraTree_DropHightLight_DrawFilter.Invalidate += UltraTree_DropHightLight_DrawFilter_Invalidate;
            UltraTree_DropHightLight_DrawFilter.QueryStateAllowedForNode += UltraTree_DropHightLight_DrawFilter_QueryStateAllowedForNode;
            treMenu.DrawFilter = UltraTree_DropHightLight_DrawFilter;
        }

        private void SY0020_Load(object sender, EventArgs e)
        {
            if (Common.Lang != "KO")
            {
                txtMenuName.Enabled = false;
            }
            treMenu.ImageList = imlMenu;
            cboSystemType_H.Value = Common.SystemID;
            binit = true;
            bDoInquire = true;
            scboProgramIDCode1.SystemID = cboSystemType_H.Value.ToString();
            scboProgramIDCode1.InitComboBox();
        }

        private void ComboBind(object send, ConvertEventArgs e)
        {
            if (e.Value == DBNull.Value)
            {
                e.Value = false;
            }
            e.Value = (Convert.ToString(e.Value) != "0" && (Convert.ToString(e.Value) == "1" || Convert.ToBoolean(e.Value)));
        }

        public override void DoInquire()
        {
            DBHelper dBHelper = new DBHelper(completedClose: false);
            try
            {
                base.DoInquire();
                DataTable dataTable = new DataTable();
                dataTable = dBHelper.FillTable("USP_SY0020_S1", CommandType.StoredProcedure, dBHelper.CreateParameter("WORKERID", "SYSTEM", DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("SYSTEMID", cboSystemType_H.Value.ToString(), DbType.String, ParameterDirection.Input));
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
                    treMenu.Nodes.Override.Sort = SortType.Ascending;
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
                    Binding();
                }
                else
                {
                    treMenu.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                ThrowError(ex);
            }
        }

        public override void DoNew()
        {
            try
            {
                base.DoNew();
                DataRow dataRow = rtnDsTemp.Tables[0].NewRow();
                if (treMenu.ActiveNode == null)
                {
                    dataRow["Sort"] = 0;
                    dataRow["ParMenuID"] = "0";
                }
                else
                {
                    dataRow["Sort"] = ((treMenu.ActiveNode.Cells["Sort"].Value != null) ? Convert.ToInt32(treMenu.ActiveNode.Cells["Sort"].Value) : 0);
                    dataRow["ParMenuID"] = ((treMenu.ActiveNode.Cells["PARMENUID"].Value == null) ? "0" : treMenu.ActiveNode.Cells["PARMENUID"].Value);
                }
                dataRow["WorkerID"] = "SYSTEM";
                dataRow["MENUID"] = --menuid;
                dataRow["Lang"] = Common.Lang;
                rtnDsTemp.Tables[0].Rows.Add(dataRow);
                treMenu.RefreshSort();
                treMenu.ActiveNode = treMenu.ActiveNode.NextVisibleNode;
                treMenu_Click(treMenu, null);
            }
            catch
            {
            }
        }

        public override void DoDelete()
        {
            try
            {
                base.DoDelete();
                if (treMenu.ActiveNode.Cells["MENUTYPE"].Value.ToString() == "M")
                {
                    DialogForm dialogForm = new DialogForm(Common.getLangText("하위도 삭제됩니다.\n\n삭제하시겠습니까?", "MSG"));
                    dialogForm.ShowDialog();
                    if (dialogForm.result == "OK")
                    {
                        string text = treMenu.ActiveNode.Cells["MenuID"].Value.ToString();
                        foreach (DataRow row in rtnDsTemp.Tables[0].Rows)
                        {
                            DataRowState rowState = row.RowState;
                            if (rowState != DataRowState.Deleted && row["ParMenuID"].ToString() == text)
                            {
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
            catch (Exception)
            {
            }
        }

        public override void DoSave()
        {
            txtProgramID.Focus();
            base.DoSave();
            ((CurrencyManager)BindingContext[bs]).EndCurrentEdit();
            USP_SY0100_CRUD(rtnDsTemp.Tables[0], WorkerID);
            DoInquire();
            base.Tree_Refresh();
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
            if (e.ColumnSet.Key == null)
            {
                return;
            }
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
            if (bs.Count != 0)
            {
                bs.Position = bs.Find("MenuID", treMenu.ActiveNode.Cells["MenuID"].Value);
            }
        }

        private void cboSystemType_H_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (binit)
                {
                    DoInquire();
                    ClosePrgForm();
                }
            }
            catch
            {
            }
        }

        private void scboProgramIDCode1_TextChanged(object sender, EventArgs e)
        {
            DBHelper dBHelper = new DBHelper(completedClose: false);
            try
            {
                if (scboProgramIDCode1.Value != null && !scboProgramIDCode1.Value.ToString().Equals("") && rtnDsTemp.Tables[0].Rows[bs.Position].RowState == DataRowState.Added && !rtnDsTemp.Tables[0].Rows[bs.Position]["EDITOR"].Equals(scboProgramIDCode1.Value.ToString()))
                {
                    string query = "   SELECT *                           FROM TSY0010 WITH(NOLOCK)       WHERE WorkerID  = 'SYSTEM'        AND ProgramID = '" + scboProgramIDCode1.Value + "' ";
                    DtTemp = dBHelper.FillTable(query, CommandType.Text);
                    if (DtTemp.Rows.Count > 0)
                    {
                        rtnDsTemp.Tables[0].Rows[bs.Position].BeginEdit();
                        txtFileID.Text = DtTemp.Rows[0]["FILEID"].ToString();
                        txtNameSpace.Text = DtTemp.Rows[0]["NameSpace"].ToString();
                        txtProgramType.Text = DtTemp.Rows[0]["ProgType"].ToString();
                        txtMenuName.Text = DtTemp.Rows[0]["ProgramName"].ToString();
                        cboMenuType.Value = DtTemp.Rows[0]["ProgType"].ToString();
                        uceDelFlag.Checked = DBHelper.nvlBoolean(DtTemp.Rows[0]["DELFLAG"].ToString());
                        uceExcelFlag.Checked = DBHelper.nvlBoolean(DtTemp.Rows[0]["EXCELFLAG"].ToString());
                        uceInqFlag.Checked = DBHelper.nvlBoolean(DtTemp.Rows[0]["INQFLAG"].ToString());
                        uceNewFlag.Checked = DBHelper.nvlBoolean(DtTemp.Rows[0]["NEWFLAG"].ToString());
                        ucePrnFlag.Checked = DBHelper.nvlBoolean(DtTemp.Rows[0]["PRNFLAG"].ToString());
                        uceSaveFlag.Checked = DBHelper.nvlBoolean(DtTemp.Rows[0]["SAVEFLAG"].ToString());
                        uceExcelIMFlag.Checked = DBHelper.nvlBoolean(DtTemp.Rows[0]["EXCELFLAG"].ToString());
                        rtnDsTemp.Tables[0].Rows[bs.Position]["INQFLAG"] = DtTemp.Rows[0]["INQFLAG"];
                        rtnDsTemp.Tables[0].Rows[bs.Position]["NEWFLAG"] = DtTemp.Rows[0]["NEWFLAG"];
                        rtnDsTemp.Tables[0].Rows[bs.Position]["DELFLAG"] = DtTemp.Rows[0]["DELFLAG"];
                        rtnDsTemp.Tables[0].Rows[bs.Position]["EXCELFLAG"] = DtTemp.Rows[0]["EXCELFLAG"];
                        rtnDsTemp.Tables[0].Rows[bs.Position]["PRNFLAG"] = DtTemp.Rows[0]["PRNFLAG"];
                        rtnDsTemp.Tables[0].Rows[bs.Position]["SAVEFLAG"] = DtTemp.Rows[0]["SAVEFLAG"];
                        rtnDsTemp.Tables[0].Rows[bs.Position]["EXCELFLAG"] = DtTemp.Rows[0]["EXCELFLAG"];
                        rtnDsTemp.Tables[0].Rows[bs.Position]["MENUTYPE"] = DtTemp.Rows[0]["ProgType"].ToString();
                        rtnDsTemp.Tables[0].Rows[bs.Position]["PROGTYPE"] = DtTemp.Rows[0]["ProgType"].ToString();
                        rtnDsTemp.Tables[0].Rows[bs.Position]["FILEID"] = DtTemp.Rows[0]["FILEID"].ToString();
                        rtnDsTemp.Tables[0].Rows[bs.Position]["PROGRAMNAME"] = DtTemp.Rows[0]["ProgramName"].ToString();
                        rtnDsTemp.Tables[0].Rows[bs.Position]["NAMESPACE"] = DtTemp.Rows[0]["NAMESPACE"].ToString();
                        rtnDsTemp.Tables[0].Rows[bs.Position]["PROGRAMID"] = DtTemp.Rows[0]["PROGRAMID"].ToString();
                        rtnDsTemp.Tables[0].Rows[bs.Position]["MENUNAME"] = DtTemp.Rows[0]["ProgramName"].ToString();
                        rtnDsTemp.Tables[0].Rows[bs.Position]["EDITOR"] = LoginInfo.UserID;
                        rtnDsTemp.Tables[0].Rows[bs.Position].EndEdit();
                        treMenu.Update();
                        treMenu.Invalidate();
                    }
                }
            }
            catch (Exception ex)
            {
                ThrowError(ex);
            }
        }

        private void UltraTree_DropHightLight_DrawFilter_Invalidate(object sender, EventArgs e)
        {
            treMenu.Invalidate();
        }

        private void UltraTree_DropHightLight_DrawFilter_QueryStateAllowedForNode(object sender, UltraTree_DropHightLight_DrawFilter_Class.QueryStateAllowedForNodeEventArgs e)
        {
            e.StatesAllowed = DropLinePositionEnum.All;
        }

        private void BindingClear()
        {
            txtMenuName.DataBindings.Clear();
            txtMenuName.Text = "";
            cboMenuType.DataBindings.Clear();
            UseFlag.DataBindings.Clear();
            txtRemark.DataBindings.Clear();
            txtRemark.Text = "";
            txtProgramID.DataBindings.Clear();
            txtProgramID.Text = "";
            txtProgramType.DataBindings.Clear();
            txtProgramType.Text = "";
            uceInqFlag.DataBindings.Clear();
            uceInqFlag.Checked = false;
            uceDelFlag.DataBindings.Clear();
            uceDelFlag.Checked = false;
            ucePrnFlag.DataBindings.Clear();
            ucePrnFlag.Checked = false;
            uceNewFlag.DataBindings.Clear();
            uceNewFlag.Checked = false;
            uceSaveFlag.DataBindings.Clear();
            uceSaveFlag.Checked = false;
            uceExcelFlag.DataBindings.Clear();
            uceExcelFlag.Checked = false;
            uceExcelIMFlag.DataBindings.Clear();
            uceExcelIMFlag.Checked = false;
            txtNameSpace.DataBindings.Clear();
            txtNameSpace.Text = "";
            txtFileID.DataBindings.Clear();
            txtFileID.Text = "";
            txtRemark1.DataBindings.Clear();
            txtRemark1.Text = "";
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
            txtRemark.DataBindings.Clear();
            txtRemark.DataBindings.Add("Value", bs, "REMARK");
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

        private void node(UltraTreeNode node)
        {
            int num = 0;
            while (true)
            {
                if (num < node.RootNode.Nodes.Count)
                {
                    if (Convert.ToString(node.RootNode.Nodes[num].Cells["MENUID"].Value) == Convert.ToString(Ex_Node[ex_node_cnt]))
                    {
                        break;
                    }
                    num++;
                    continue;
                }
                return;
            }
            ex_node_cnt++;
            UltraTreeNode ultraTreeNode = node.RootNode.Nodes[num];
            ultraTreeNode.Expanded = true;
            this.node(ultraTreeNode);
        }

        public void USP_SY0100_CRUD(DataTable DtChange, string USER_ID)
        {
            if (DtChange.GetChanges() != null)
            {
                DBHelper dBHelper = new DBHelper(completedClose: false);
                txtProgramType.Focus();
                try
                {
                    foreach (DataRow row in DtChange.GetChanges().Rows)
                    {
                        switch (row.RowState)
                        {
                            case DataRowState.Deleted:
                                row.RejectChanges();
                                dBHelper.ExecuteNoneQuery("USP_SY0020_D1", CommandType.StoredProcedure, dBHelper.CreateParameter("WORKERID", Convert.ToString(row["WORKERID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("MENUID", Convert.ToString(row["MENUID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("PROGRAMID", Convert.ToString(row["PROGRAMID"]), DbType.String, ParameterDirection.Input));
                                row.Delete();
                                break;
                            case DataRowState.Added:
                                dBHelper.ExecuteNoneQuery("USP_SY0020_I1", CommandType.StoredProcedure, dBHelper.CreateParameter("WORKERID", Convert.ToString(row["WORKERID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("MENUID", 0, DbType.Int32, ParameterDirection.Input), dBHelper.CreateParameter("MENUNAME", row["MENUNAME"], DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("PARMENUID", Convert.ToInt32(row["PARMENUID"]), DbType.Int32, ParameterDirection.Input), dBHelper.CreateParameter("SORT", Convert.ToInt32(row["SORT"]), DbType.Int32, ParameterDirection.Input), dBHelper.CreateParameter("PROGRAMID", Convert.ToString(row["PROGRAMID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("MENUTYPE", Convert.ToString(row["MENUTYPE"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("USEFLAG", Convert.ToString(row["USEFLAG"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("REMARK", Convert.ToString(row["REMARK"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("PROGRAMNAME", Convert.ToString(row["PROGRAMNAME"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("PROGTYPE", Convert.ToString(row["PROGTYPE"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("FILEID", Convert.ToString(row["FILEID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("NAMESPACE", Convert.ToString(row["NAMESPACE"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("MAKER", USER_ID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("EDITOR", USER_ID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("SYSTEMID", cboSystemType_H.Value.ToString(), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("UIDNAME", row["UIDNAME"], DbType.String, ParameterDirection.Input));
                                break;
                            case DataRowState.Modified:
                                dBHelper.ExecuteNoneQuery("USP_SY0020_U1", CommandType.StoredProcedure, dBHelper.CreateParameter("WORKERID", Convert.ToString(row["WORKERID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("MENUID", Convert.ToInt32(row["MENUID"]), DbType.Int32, ParameterDirection.Input), dBHelper.CreateParameter("MENUNAME", Convert.ToString(row["MENUNAME"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("PARMENUID", Convert.ToInt32(row["PARMENUID"]), DbType.Int32, ParameterDirection.Input), dBHelper.CreateParameter("SORT", Convert.ToInt32(row["SORT"]), DbType.Int32, ParameterDirection.Input), dBHelper.CreateParameter("PROGRAMID", Convert.ToString(row["PROGRAMID"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("MENUTYPE", Convert.ToString(row["MENUTYPE"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("USEFLAG", Convert.ToString(row["USEFLAG"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("REMARK", Convert.ToString(row["REMARK"]), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("EDITOR", USER_ID, DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("SYSTEMID", cboSystemType_H.Value.ToString(), DbType.String, ParameterDirection.Input), dBHelper.CreateParameter("UIDNAME", Convert.ToString(row["UIDNAME"]), DbType.String, ParameterDirection.Input));
                                break;
                        }
                    }
                    DtChange.AcceptChanges();
                    dBHelper.Commit();
                }
                catch (Exception ex)
                {
                    dBHelper.Rollback();
                    ThrowError(ex);
                }
                finally
                {
                    dBHelper.Close();
                }
            }
        }

        private void txtMenuName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                treMenu.Invalidate();
                treMenu.ActiveNode.Text = txtMenuName.Text;
            }
        }

        private void txtMenuName_Leave(object sender, EventArgs e)
        {
            treMenu.Update();
            treMenu.Invalidate();
            treMenu.ActiveNode.Text = txtMenuName.Text;
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
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTree.UltraTreeColumnSet ultraTreeColumnSet1 = new Infragistics.Win.UltraWinTree.UltraTreeColumnSet();
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SY0020));
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
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
            this.lblUseFlag_H = new WIZ.Control.SLabel();
            this.ultraSplitter1 = new Infragistics.Win.Misc.UltraSplitter();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.gbxMenuInfor = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtRemark = new WIZ.Control.STextBox(this.components);
            this.txtMenuName = new WIZ.Control.STextBox(this.components);
            this.cboMenuType = new WIZ.Control.SCodeNMComboBox();
            this.UseFlag = new WIZ.Control.SCodeNMComboBox();
            this.lblMenuType = new WIZ.Control.SLabel();
            this.sLabel3 = new WIZ.Control.SLabel();
            this.lblMenuID = new WIZ.Control.SLabel();
            this.lblRemark = new WIZ.Control.SLabel();
            this.gbxProgramInfor = new Infragistics.Win.Misc.UltraGroupBox();
            this.uceExcelIMFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.uceSumFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.uceExcelFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ucePrnFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.uceSaveFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.uceDelFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.uceNewFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.uceInqFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.scboProgramIDCode1 = new WIZ.Control.ScboProgramIDCode();
            this.txtProgramID = new WIZ.Control.STextBox(this.components);
            this.sLabel1 = new WIZ.Control.SLabel();
            this.txtRemark1 = new WIZ.Control.STextBox(this.components);
            this.sLabel2 = new WIZ.Control.SLabel();
            this.lblRemark1 = new WIZ.Control.SLabel();
            this.txtProgramType = new WIZ.Control.STextBox(this.components);
            this.txtFileID = new WIZ.Control.STextBox(this.components);
            this.lblNameSpace = new WIZ.Control.SLabel();
            this.lblFileID = new WIZ.Control.SLabel();
            this.txtNameSpace = new WIZ.Control.STextBox(this.components);
            this.treMenu = new Infragistics.Win.UltraWinTree.UltraTree();
            this.imlMenu = new System.Windows.Forms.ImageList(this.components);
            this.sLabel6 = new WIZ.Control.SLabel();
            this.cboUseFlag_H = new WIZ.Control.SCodeNMComboBox();
            this.cboSystemType_H = new WIZ.Control.SCodeNMComboBox();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.uceExcelIMFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceSumFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceExcelFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucePrnFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceSaveFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceDelFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceNewFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceInqFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scboProgramIDCode1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProgramID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProgramType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameSpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUseFlag_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSystemType_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.cboSystemType_H);
            this.gbxHeader.Controls.Add(this.cboUseFlag_H);
            this.gbxHeader.Controls.Add(this.sLabel6);
            this.gbxHeader.Controls.Add(this.lblUseFlag_H);
            this.gbxHeader.Controls.SetChildIndex(this.lblUseFlag_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.sLabel6, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboUseFlag_H, 0);
            this.gbxHeader.Controls.SetChildIndex(this.cboSystemType_H, 0);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.ultraGroupBox1);
            this.gbxBody.Controls.Add(this.ultraSplitter1);
            this.gbxBody.Controls.Add(this.treMenu);
            // 
            // lblUseFlag_H
            // 
            appearance.FontData.BoldAsString = "False";
            appearance.FontData.UnderlineAsString = "False";
            appearance.ForeColor = System.Drawing.Color.Black;
            appearance.TextHAlignAsString = "Left";
            appearance.TextVAlignAsString = "Middle";
            this.lblUseFlag_H.Appearance = appearance;
            this.lblUseFlag_H.DbField = null;
            this.lblUseFlag_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUseFlag_H.Location = new System.Drawing.Point(356, 10);
            this.lblUseFlag_H.Name = "lblUseFlag_H";
            this.lblUseFlag_H.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblUseFlag_H.Size = new System.Drawing.Size(145, 25);
            this.lblUseFlag_H.TabIndex = 21;
            this.lblUseFlag_H.Text = "사용여부";
            // 
            // ultraSplitter1
            // 
            this.ultraSplitter1.Location = new System.Drawing.Point(379, 6);
            this.ultraSplitter1.Name = "ultraSplitter1";
            this.ultraSplitter1.RestoreExtent = 0;
            this.ultraSplitter1.Size = new System.Drawing.Size(8, 743);
            this.ultraSplitter1.TabIndex = 1;
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            this.ultraGroupBox1.Controls.Add(this.gbxMenuInfor);
            this.ultraGroupBox1.Controls.Add(this.gbxProgramInfor);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.Location = new System.Drawing.Point(387, 6);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(743, 743);
            this.ultraGroupBox1.TabIndex = 2;
            // 
            // gbxMenuInfor
            // 
            this.gbxMenuInfor.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            this.gbxMenuInfor.Controls.Add(this.txtRemark);
            this.gbxMenuInfor.Controls.Add(this.txtMenuName);
            this.gbxMenuInfor.Controls.Add(this.cboMenuType);
            this.gbxMenuInfor.Controls.Add(this.UseFlag);
            this.gbxMenuInfor.Controls.Add(this.lblMenuType);
            this.gbxMenuInfor.Controls.Add(this.sLabel3);
            this.gbxMenuInfor.Controls.Add(this.lblMenuID);
            this.gbxMenuInfor.Controls.Add(this.lblRemark);
            this.gbxMenuInfor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxMenuInfor.Location = new System.Drawing.Point(2, 0);
            this.gbxMenuInfor.Name = "gbxMenuInfor";
            this.gbxMenuInfor.Size = new System.Drawing.Size(739, 281);
            this.gbxMenuInfor.TabIndex = 29;
            this.gbxMenuInfor.Text = "메뉴정보";
            // 
            // txtRemark
            // 
            this.txtRemark.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance56.FontData.BoldAsString = "False";
            appearance56.FontData.UnderlineAsString = "False";
            appearance56.ForeColor = System.Drawing.Color.Black;
            this.txtRemark.Appearance = appearance56;
            this.txtRemark.AutoSize = false;
            this.txtRemark.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRemark.Location = new System.Drawing.Point(10, 160);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtRemark.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtRemark.Size = new System.Drawing.Size(721, 115);
            this.txtRemark.TabIndex = 246;
            // 
            // txtMenuName
            // 
            appearance55.FontData.BoldAsString = "False";
            appearance55.FontData.UnderlineAsString = "False";
            appearance55.ForeColor = System.Drawing.Color.Black;
            this.txtMenuName.Appearance = appearance55;
            this.txtMenuName.AutoSize = false;
            this.txtMenuName.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMenuName.Location = new System.Drawing.Point(10, 51);
            this.txtMenuName.Name = "txtMenuName";
            this.txtMenuName.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtMenuName.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtMenuName.Size = new System.Drawing.Size(721, 27);
            this.txtMenuName.TabIndex = 245;
            // 
            // cboMenuType
            // 
            this.cboMenuType.AutoSize = false;
            this.cboMenuType.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cboMenuType.ComboDataType = WIZ.Control.ComboDataType.CodeOnly;
            this.cboMenuType.DbConfig = null;
            this.cboMenuType.DefaultValue = "";
            appearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cboMenuType.DisplayLayout.Appearance = appearance2;
            this.cboMenuType.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.cboMenuType.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cboMenuType.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance3.BackColor = System.Drawing.Color.Gray;
            this.cboMenuType.DisplayLayout.CaptionAppearance = appearance3;
            this.cboMenuType.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.cboMenuType.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.RoyalBlue;
            this.cboMenuType.DisplayLayout.InterBandSpacing = 2;
            this.cboMenuType.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance4.BackColor = System.Drawing.Color.RoyalBlue;
            appearance4.FontData.BoldAsString = "True";
            appearance4.ForeColor = System.Drawing.Color.White;
            this.cboMenuType.DisplayLayout.Override.ActiveRowAppearance = appearance4;
            appearance5.FontData.BoldAsString = "True";
            this.cboMenuType.DisplayLayout.Override.ActiveRowCellAppearance = appearance5;
            this.cboMenuType.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            this.cboMenuType.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.cboMenuType.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.None;
            this.cboMenuType.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010ScrollbarButton;
            appearance6.BackColor = System.Drawing.Color.DimGray;
            appearance6.BackColor2 = System.Drawing.Color.Silver;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.BorderColor = System.Drawing.Color.White;
            appearance6.FontData.BoldAsString = "True";
            appearance6.ForeColor = System.Drawing.Color.White;
            this.cboMenuType.DisplayLayout.Override.HeaderAppearance = appearance6;
            this.cboMenuType.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            appearance7.BackColor2 = System.Drawing.Color.Gray;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.cboMenuType.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance7;
            this.cboMenuType.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            this.cboMenuType.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            this.cboMenuType.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.cboMenuType.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(133)))), ((int)(((byte)(188)))));
            appearance8.FontData.BoldAsString = "True";
            this.cboMenuType.DisplayLayout.Override.SelectedRowAppearance = appearance8;
            this.cboMenuType.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            this.cboMenuType.DisplayLayout.RowConnectorColor = System.Drawing.Color.Silver;
            this.cboMenuType.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.cboMenuType.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.cboMenuType.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cboMenuType.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.cboMenuType.Location = new System.Drawing.Point(10, 108);
            this.cboMenuType.MajorCode = "MENUTYPE";
            this.cboMenuType.Name = "cboMenuType";
            this.cboMenuType.SelectedValue = null;
            this.cboMenuType.ShowDefaultValue = false;
            this.cboMenuType.Size = new System.Drawing.Size(169, 25);
            this.cboMenuType.TabIndex = 226;
            // 
            // UseFlag
            // 
            this.UseFlag.AutoSize = false;
            this.UseFlag.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.UseFlag.ComboDataType = WIZ.Control.ComboDataType.CodeOnly;
            this.UseFlag.DbConfig = null;
            this.UseFlag.DefaultValue = "";
            appearance9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance9.TextHAlignAsString = "Left";
            this.UseFlag.DisplayLayout.Appearance = appearance9;
            this.UseFlag.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.UseFlag.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.UseFlag.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.UseFlag.DisplayLayout.CaptionAppearance = appearance10;
            this.UseFlag.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.UseFlag.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.RoyalBlue;
            this.UseFlag.DisplayLayout.InterBandSpacing = 2;
            this.UseFlag.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance11.BackColor = System.Drawing.Color.RoyalBlue;
            appearance11.FontData.BoldAsString = "True";
            appearance11.ForeColor = System.Drawing.Color.White;
            this.UseFlag.DisplayLayout.Override.ActiveRowAppearance = appearance11;
            appearance12.FontData.BoldAsString = "True";
            this.UseFlag.DisplayLayout.Override.ActiveRowCellAppearance = appearance12;
            this.UseFlag.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            this.UseFlag.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.UseFlag.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.None;
            this.UseFlag.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010ScrollbarButton;
            appearance13.BackColor = System.Drawing.Color.DimGray;
            appearance13.BackColor2 = System.Drawing.Color.Silver;
            appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance13.BorderColor = System.Drawing.Color.White;
            appearance13.FontData.BoldAsString = "True";
            appearance13.ForeColor = System.Drawing.Color.White;
            this.UseFlag.DisplayLayout.Override.HeaderAppearance = appearance13;
            this.UseFlag.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            appearance14.BackColor2 = System.Drawing.Color.Gray;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.UseFlag.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance14;
            this.UseFlag.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            this.UseFlag.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            this.UseFlag.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.UseFlag.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(133)))), ((int)(((byte)(188)))));
            appearance15.FontData.BoldAsString = "True";
            this.UseFlag.DisplayLayout.Override.SelectedRowAppearance = appearance15;
            this.UseFlag.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            this.UseFlag.DisplayLayout.RowConnectorColor = System.Drawing.Color.Silver;
            this.UseFlag.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.UseFlag.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.UseFlag.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.UseFlag.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.UseFlag.Location = new System.Drawing.Point(307, 108);
            this.UseFlag.MajorCode = "USEFLAG";
            this.UseFlag.Name = "UseFlag";
            this.UseFlag.SelectedValue = null;
            this.UseFlag.ShowDefaultValue = false;
            this.UseFlag.Size = new System.Drawing.Size(169, 25);
            this.UseFlag.TabIndex = 225;
            // 
            // lblMenuType
            // 
            appearance16.FontData.BoldAsString = "False";
            appearance16.FontData.UnderlineAsString = "False";
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Left";
            this.lblMenuType.Appearance = appearance16;
            this.lblMenuType.DbField = null;
            this.lblMenuType.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMenuType.Location = new System.Drawing.Point(10, 81);
            this.lblMenuType.Name = "lblMenuType";
            this.lblMenuType.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblMenuType.Size = new System.Drawing.Size(169, 27);
            this.lblMenuType.TabIndex = 29;
            this.lblMenuType.Text = "메뉴유형";
            // 
            // sLabel3
            // 
            appearance17.FontData.BoldAsString = "False";
            appearance17.FontData.UnderlineAsString = "False";
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.TextHAlignAsString = "Left";
            this.sLabel3.Appearance = appearance17;
            this.sLabel3.DbField = null;
            this.sLabel3.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel3.Location = new System.Drawing.Point(307, 81);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel3.Size = new System.Drawing.Size(169, 27);
            this.sLabel3.TabIndex = 27;
            this.sLabel3.Text = "사용구분";
            // 
            // lblMenuID
            // 
            appearance18.FontData.BoldAsString = "False";
            appearance18.FontData.UnderlineAsString = "False";
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.TextHAlignAsString = "Left";
            this.lblMenuID.Appearance = appearance18;
            this.lblMenuID.DbField = null;
            this.lblMenuID.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMenuID.Location = new System.Drawing.Point(10, 26);
            this.lblMenuID.Name = "lblMenuID";
            this.lblMenuID.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblMenuID.Size = new System.Drawing.Size(100, 23);
            this.lblMenuID.TabIndex = 3;
            this.lblMenuID.Text = "메뉴";
            // 
            // lblRemark
            // 
            appearance19.FontData.BoldAsString = "False";
            appearance19.FontData.UnderlineAsString = "False";
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.TextHAlignAsString = "Left";
            this.lblRemark.Appearance = appearance19;
            this.lblRemark.DbField = null;
            this.lblRemark.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRemark.Location = new System.Drawing.Point(10, 136);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblRemark.Size = new System.Drawing.Size(721, 21);
            this.lblRemark.TabIndex = 24;
            this.lblRemark.Text = "비고";
            // 
            // gbxProgramInfor
            // 
            this.gbxProgramInfor.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            this.gbxProgramInfor.Controls.Add(this.uceExcelIMFlag);
            this.gbxProgramInfor.Controls.Add(this.uceSumFlag);
            this.gbxProgramInfor.Controls.Add(this.uceExcelFlag);
            this.gbxProgramInfor.Controls.Add(this.ucePrnFlag);
            this.gbxProgramInfor.Controls.Add(this.uceSaveFlag);
            this.gbxProgramInfor.Controls.Add(this.uceDelFlag);
            this.gbxProgramInfor.Controls.Add(this.uceNewFlag);
            this.gbxProgramInfor.Controls.Add(this.uceInqFlag);
            this.gbxProgramInfor.Controls.Add(this.scboProgramIDCode1);
            this.gbxProgramInfor.Controls.Add(this.txtProgramID);
            this.gbxProgramInfor.Controls.Add(this.sLabel1);
            this.gbxProgramInfor.Controls.Add(this.txtRemark1);
            this.gbxProgramInfor.Controls.Add(this.sLabel2);
            this.gbxProgramInfor.Controls.Add(this.lblRemark1);
            this.gbxProgramInfor.Controls.Add(this.txtProgramType);
            this.gbxProgramInfor.Controls.Add(this.txtFileID);
            this.gbxProgramInfor.Controls.Add(this.lblNameSpace);
            this.gbxProgramInfor.Controls.Add(this.lblFileID);
            this.gbxProgramInfor.Controls.Add(this.txtNameSpace);
            this.gbxProgramInfor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbxProgramInfor.Location = new System.Drawing.Point(2, 281);
            this.gbxProgramInfor.Name = "gbxProgramInfor";
            this.gbxProgramInfor.Size = new System.Drawing.Size(739, 460);
            this.gbxProgramInfor.TabIndex = 28;
            this.gbxProgramInfor.Text = "프로그램 정보";
            // 
            // uceExcelIMFlag
            // 
            this.uceExcelIMFlag.Enabled = false;
            this.uceExcelIMFlag.Location = new System.Drawing.Point(346, 178);
            this.uceExcelIMFlag.Name = "uceExcelIMFlag";
            this.uceExcelIMFlag.Size = new System.Drawing.Size(144, 20);
            this.uceExcelIMFlag.TabIndex = 36;
            this.uceExcelIMFlag.Text = "엑셀 ▲";
            // 
            // uceSumFlag
            // 
            this.uceSumFlag.Enabled = false;
            this.uceSumFlag.Location = new System.Drawing.Point(510, 179);
            this.uceSumFlag.Name = "uceSumFlag";
            this.uceSumFlag.Size = new System.Drawing.Size(144, 20);
            this.uceSumFlag.TabIndex = 34;
            this.uceSumFlag.Text = "합계";
            this.uceSumFlag.Visible = false;
            // 
            // uceExcelFlag
            // 
            this.uceExcelFlag.Enabled = false;
            this.uceExcelFlag.Location = new System.Drawing.Point(177, 179);
            this.uceExcelFlag.Name = "uceExcelFlag";
            this.uceExcelFlag.Size = new System.Drawing.Size(144, 20);
            this.uceExcelFlag.TabIndex = 35;
            this.uceExcelFlag.Text = "엑셀 ▼";
            // 
            // ucePrnFlag
            // 
            this.ucePrnFlag.Enabled = false;
            this.ucePrnFlag.Location = new System.Drawing.Point(10, 178);
            this.ucePrnFlag.Name = "ucePrnFlag";
            this.ucePrnFlag.Size = new System.Drawing.Size(144, 20);
            this.ucePrnFlag.TabIndex = 33;
            this.ucePrnFlag.Text = "출력";
            // 
            // uceSaveFlag
            // 
            this.uceSaveFlag.Enabled = false;
            this.uceSaveFlag.Location = new System.Drawing.Point(510, 153);
            this.uceSaveFlag.Name = "uceSaveFlag";
            this.uceSaveFlag.Size = new System.Drawing.Size(144, 20);
            this.uceSaveFlag.TabIndex = 32;
            this.uceSaveFlag.Text = "저장";
            // 
            // uceDelFlag
            // 
            this.uceDelFlag.Enabled = false;
            this.uceDelFlag.Location = new System.Drawing.Point(346, 153);
            this.uceDelFlag.Name = "uceDelFlag";
            this.uceDelFlag.Size = new System.Drawing.Size(144, 20);
            this.uceDelFlag.TabIndex = 31;
            this.uceDelFlag.Text = "삭제";
            // 
            // uceNewFlag
            // 
            this.uceNewFlag.Enabled = false;
            this.uceNewFlag.Location = new System.Drawing.Point(177, 152);
            this.uceNewFlag.Name = "uceNewFlag";
            this.uceNewFlag.Size = new System.Drawing.Size(144, 20);
            this.uceNewFlag.TabIndex = 30;
            this.uceNewFlag.Text = "신규";
            // 
            // uceInqFlag
            // 
            this.uceInqFlag.Enabled = false;
            this.uceInqFlag.Location = new System.Drawing.Point(10, 152);
            this.uceInqFlag.Name = "uceInqFlag";
            this.uceInqFlag.Size = new System.Drawing.Size(144, 20);
            this.uceInqFlag.TabIndex = 29;
            this.uceInqFlag.Text = "조회";
            // 
            // scboProgramIDCode1
            // 
            this.scboProgramIDCode1.AutoSize = false;
            this.scboProgramIDCode1.ComboDataType = WIZ.Control.ComboDataType.CodeOnly;
            this.scboProgramIDCode1.DbConfig = null;
            this.scboProgramIDCode1.DefaultValue = "";
            appearance20.BackColor = System.Drawing.SystemColors.Window;
            appearance20.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.scboProgramIDCode1.DisplayLayout.Appearance = appearance20;
            this.scboProgramIDCode1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.scboProgramIDCode1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.scboProgramIDCode1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance21.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance21.BorderColor = System.Drawing.SystemColors.Window;
            this.scboProgramIDCode1.DisplayLayout.GroupByBox.Appearance = appearance21;
            appearance22.ForeColor = System.Drawing.SystemColors.GrayText;
            this.scboProgramIDCode1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance22;
            this.scboProgramIDCode1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance23.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance23.BackColor2 = System.Drawing.SystemColors.Control;
            appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance23.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance23.ForeColor = System.Drawing.SystemColors.GrayText;
            this.scboProgramIDCode1.DisplayLayout.GroupByBox.PromptAppearance = appearance23;
            this.scboProgramIDCode1.DisplayLayout.MaxColScrollRegions = 1;
            this.scboProgramIDCode1.DisplayLayout.MaxRowScrollRegions = 1;
            this.scboProgramIDCode1.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance24.BackColor = System.Drawing.Color.DimGray;
            appearance24.BackColor2 = System.Drawing.Color.Silver;
            appearance24.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance24.BorderColor = System.Drawing.Color.White;
            appearance24.FontData.BoldAsString = "True";
            appearance24.ForeColor = System.Drawing.Color.White;
            this.scboProgramIDCode1.DisplayLayout.Override.ActiveCellAppearance = appearance24;
            appearance25.BackColor = System.Drawing.Color.RoyalBlue;
            appearance25.FontData.BoldAsString = "True";
            appearance25.ForeColor = System.Drawing.Color.White;
            this.scboProgramIDCode1.DisplayLayout.Override.ActiveRowAppearance = appearance25;
            appearance26.FontData.BoldAsString = "True";
            this.scboProgramIDCode1.DisplayLayout.Override.ActiveRowCellAppearance = appearance26;
            this.scboProgramIDCode1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            this.scboProgramIDCode1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.scboProgramIDCode1.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.None;
            this.scboProgramIDCode1.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010ScrollbarButton;
            appearance27.BackColor = System.Drawing.SystemColors.Window;
            this.scboProgramIDCode1.DisplayLayout.Override.CardAreaAppearance = appearance27;
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            appearance28.BorderColor = System.Drawing.Color.Silver;
            this.scboProgramIDCode1.DisplayLayout.Override.CellAppearance = appearance28;
            this.scboProgramIDCode1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.scboProgramIDCode1.DisplayLayout.Override.CellPadding = 0;
            appearance29.BackColor = System.Drawing.Color.Gray;
            appearance29.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance29.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance29.BorderColor = System.Drawing.SystemColors.Window;
            this.scboProgramIDCode1.DisplayLayout.Override.GroupByRowAppearance = appearance29;
            appearance30.BackColor = System.Drawing.Color.RoyalBlue;
            appearance30.FontData.BoldAsString = "True";
            appearance30.ForeColor = System.Drawing.Color.White;
            appearance30.TextHAlignAsString = "Left";
            this.scboProgramIDCode1.DisplayLayout.Override.HeaderAppearance = appearance30;
            this.scboProgramIDCode1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.scboProgramIDCode1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance31.BackColor = System.Drawing.SystemColors.Window;
            appearance31.BorderColor = System.Drawing.Color.Silver;
            this.scboProgramIDCode1.DisplayLayout.Override.RowAppearance = appearance31;
            this.scboProgramIDCode1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance32.BackColor = System.Drawing.SystemColors.ControlLight;
            this.scboProgramIDCode1.DisplayLayout.Override.TemplateAddRowAppearance = appearance32;
            this.scboProgramIDCode1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.scboProgramIDCode1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.scboProgramIDCode1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.scboProgramIDCode1.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.scboProgramIDCode1.Location = new System.Drawing.Point(10, 59);
            this.scboProgramIDCode1.MajorCode = null;
            this.scboProgramIDCode1.Name = "scboProgramIDCode1";
            this.scboProgramIDCode1.ShowDefaultValue = false;
            this.scboProgramIDCode1.Size = new System.Drawing.Size(721, 27);
            this.scboProgramIDCode1.SystemID = "";
            this.scboProgramIDCode1.TabIndex = 28;
            this.scboProgramIDCode1.TextChanged += new System.EventHandler(this.scboProgramIDCode1_TextChanged);
            // 
            // txtProgramID
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.txtProgramID.Appearance = appearance1;
            this.txtProgramID.AutoSize = false;
            this.txtProgramID.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProgramID.Location = new System.Drawing.Point(506, 116);
            this.txtProgramID.Name = "txtProgramID";
            this.txtProgramID.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtProgramID.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtProgramID.Size = new System.Drawing.Size(225, 25);
            this.txtProgramID.TabIndex = 27;
            this.txtProgramID.Visible = false;
            // 
            // sLabel1
            // 
            appearance33.FontData.BoldAsString = "False";
            appearance33.FontData.UnderlineAsString = "False";
            appearance33.ForeColor = System.Drawing.Color.Black;
            appearance33.TextHAlignAsString = "Left";
            this.sLabel1.Appearance = appearance33;
            this.sLabel1.DbField = null;
            this.sLabel1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel1.Location = new System.Drawing.Point(10, 34);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(721, 23);
            this.sLabel1.TabIndex = 3;
            this.sLabel1.Text = "프로그램";
            // 
            // txtRemark1
            // 
            this.txtRemark1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance34.FontData.BoldAsString = "False";
            appearance34.FontData.UnderlineAsString = "False";
            appearance34.ForeColor = System.Drawing.Color.Black;
            appearance34.TextVAlignAsString = "Top";
            this.txtRemark1.Appearance = appearance34;
            this.txtRemark1.AutoSize = false;
            this.txtRemark1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRemark1.Location = new System.Drawing.Point(10, 337);
            this.txtRemark1.Multiline = true;
            this.txtRemark1.Name = "txtRemark1";
            this.txtRemark1.ReadOnly = true;
            this.txtRemark1.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtRemark1.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtRemark1.Size = new System.Drawing.Size(721, 115);
            this.txtRemark1.TabIndex = 25;
            // 
            // sLabel2
            // 
            appearance35.FontData.BoldAsString = "False";
            appearance35.FontData.UnderlineAsString = "False";
            appearance35.ForeColor = System.Drawing.Color.Black;
            appearance35.TextHAlignAsString = "Left";
            this.sLabel2.Appearance = appearance35;
            this.sLabel2.DbField = null;
            this.sLabel2.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel2.Location = new System.Drawing.Point(10, 90);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel2.Size = new System.Drawing.Size(255, 23);
            this.sLabel2.TabIndex = 6;
            this.sLabel2.Text = "프로그램유형";
            // 
            // lblRemark1
            // 
            appearance36.FontData.BoldAsString = "False";
            appearance36.FontData.UnderlineAsString = "False";
            appearance36.ForeColor = System.Drawing.Color.Black;
            appearance36.TextHAlignAsString = "Left";
            this.lblRemark1.Appearance = appearance36;
            this.lblRemark1.DbField = null;
            this.lblRemark1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRemark1.Location = new System.Drawing.Point(10, 310);
            this.lblRemark1.Name = "lblRemark1";
            this.lblRemark1.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblRemark1.Size = new System.Drawing.Size(721, 27);
            this.lblRemark1.TabIndex = 24;
            this.lblRemark1.Text = "비고";
            // 
            // txtProgramType
            // 
            appearance57.FontData.BoldAsString = "False";
            appearance57.FontData.UnderlineAsString = "False";
            appearance57.ForeColor = System.Drawing.Color.Black;
            this.txtProgramType.Appearance = appearance57;
            this.txtProgramType.AutoSize = false;
            this.txtProgramType.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProgramType.Location = new System.Drawing.Point(10, 115);
            this.txtProgramType.Name = "txtProgramType";
            this.txtProgramType.ReadOnly = true;
            this.txtProgramType.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtProgramType.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtProgramType.Size = new System.Drawing.Size(256, 27);
            this.txtProgramType.TabIndex = 7;
            // 
            // txtFileID
            // 
            this.txtFileID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance58.FontData.BoldAsString = "False";
            appearance58.FontData.UnderlineAsString = "False";
            appearance58.ForeColor = System.Drawing.Color.Black;
            this.txtFileID.Appearance = appearance58;
            this.txtFileID.AutoSize = false;
            this.txtFileID.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtFileID.Location = new System.Drawing.Point(10, 281);
            this.txtFileID.Name = "txtFileID";
            this.txtFileID.ReadOnly = true;
            this.txtFileID.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtFileID.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtFileID.Size = new System.Drawing.Size(721, 27);
            this.txtFileID.TabIndex = 17;
            // 
            // lblNameSpace
            // 
            appearance37.FontData.BoldAsString = "False";
            appearance37.FontData.UnderlineAsString = "False";
            appearance37.ForeColor = System.Drawing.Color.Black;
            appearance37.TextHAlignAsString = "Left";
            this.lblNameSpace.Appearance = appearance37;
            this.lblNameSpace.DbField = null;
            this.lblNameSpace.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNameSpace.Location = new System.Drawing.Point(10, 203);
            this.lblNameSpace.Name = "lblNameSpace";
            this.lblNameSpace.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblNameSpace.Size = new System.Drawing.Size(721, 23);
            this.lblNameSpace.TabIndex = 14;
            this.lblNameSpace.Text = "네임스페이스";
            // 
            // lblFileID
            // 
            appearance38.FontData.BoldAsString = "False";
            appearance38.FontData.UnderlineAsString = "False";
            appearance38.ForeColor = System.Drawing.Color.Black;
            appearance38.TextHAlignAsString = "Left";
            this.lblFileID.Appearance = appearance38;
            this.lblFileID.DbField = null;
            this.lblFileID.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblFileID.Location = new System.Drawing.Point(10, 256);
            this.lblFileID.Name = "lblFileID";
            this.lblFileID.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.lblFileID.Size = new System.Drawing.Size(721, 23);
            this.lblFileID.TabIndex = 16;
            this.lblFileID.Text = "파일";
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance59.FontData.BoldAsString = "False";
            appearance59.FontData.UnderlineAsString = "False";
            appearance59.ForeColor = System.Drawing.Color.Black;
            this.txtNameSpace.Appearance = appearance59;
            this.txtNameSpace.AutoSize = false;
            this.txtNameSpace.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtNameSpace.Location = new System.Drawing.Point(10, 228);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.ReadOnly = true;
            this.txtNameSpace.RequireFlag = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtNameSpace.RequirePop = WIZ.Control.STextBox.RequireFlagEnum.NO;
            this.txtNameSpace.Size = new System.Drawing.Size(721, 27);
            this.txtNameSpace.TabIndex = 15;
            // 
            // treMenu
            // 
            this.treMenu.AllowDrop = true;
            appearance39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            appearance39.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            appearance39.FontData.Name = "맑은 고딕";
            appearance39.FontData.SizeInPoints = 10F;
            this.treMenu.Appearance = appearance39;
            this.treMenu.ColumnSettings.AllowSorting = Infragistics.Win.DefaultableBoolean.True;
            this.treMenu.ColumnSettings.ColumnAutoSizeMode = Infragistics.Win.UltraWinTree.ColumnAutoSizeMode.VisibleNodes;
            this.treMenu.ColumnSettings.LabelPosition = Infragistics.Win.UltraWinTree.NodeLayoutLabelPosition.None;
            this.treMenu.ColumnSettings.NullText = "*";
            ultraTreeColumnSet1.LabelPosition = Infragistics.Win.UltraWinTree.NodeLayoutLabelPosition.None;
            ultraTreeColumnSet1.NullText = "*";
            this.treMenu.ColumnSettings.RootColumnSet = ultraTreeColumnSet1;
            this.treMenu.DisplayStyle = Infragistics.Win.UltraWinTree.UltraTreeDisplayStyle.Standard;
            this.treMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.treMenu.ImageList = this.imlMenu;
            this.treMenu.ImagePadding = 15;
            this.treMenu.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.treMenu.Location = new System.Drawing.Point(6, 6);
            this.treMenu.Name = "treMenu";
            this.treMenu.NodeConnectorColor = System.Drawing.Color.Gray;
            this.treMenu.NodeConnectorStyle = Infragistics.Win.UltraWinTree.NodeConnectorStyle.Solid;
            _override1.AllowAutoDragExpand = Infragistics.Win.UltraWinTree.AllowAutoDragExpand.ExpandOnDragHoverWhenExpansionIndicatorVisible;
            _override1.SelectionType = Infragistics.Win.UltraWinTree.SelectType.SingleAutoDrag;
            _override1.ShowColumns = Infragistics.Win.DefaultableBoolean.False;
            _override1.Sort = Infragistics.Win.UltraWinTree.SortType.Ascending;
            this.treMenu.Override = _override1;
            this.treMenu.Size = new System.Drawing.Size(373, 743);
            this.treMenu.TabIndex = 70;
            this.treMenu.ViewStyle = Infragistics.Win.UltraWinTree.ViewStyle.Standard;
            this.treMenu.SelectionDragStart += new System.EventHandler(this.treMenu_SelectionDragStart);
            this.treMenu.InitializeDataNode += new Infragistics.Win.UltraWinTree.InitializeDataNodeEventHandler(this.treMenu_InitializeDataNode);
            this.treMenu.ColumnSetGenerated += new Infragistics.Win.UltraWinTree.ColumnSetGeneratedEventHandler(this.treMenu_ColumnSetGenerated);
            this.treMenu.Click += new System.EventHandler(this.treMenu_Click);
            this.treMenu.DragDrop += new System.Windows.Forms.DragEventHandler(this.treMenu_DragDrop);
            this.treMenu.DragOver += new System.Windows.Forms.DragEventHandler(this.treMenu_DragOver);
            this.treMenu.DragLeave += new System.EventHandler(this.treMenu_DragLeave);
            this.treMenu.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.treMenu_QueryContinueDrag);
            // 
            // imlMenu
            // 
            this.imlMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlMenu.ImageStream")));
            this.imlMenu.TransparentColor = System.Drawing.Color.Transparent;
            this.imlMenu.Images.SetKeyName(0, "Folder Yellow Live Back.png");
            this.imlMenu.Images.SetKeyName(1, "window_dialog.ico");
            this.imlMenu.Images.SetKeyName(2, "MTree01.png");
            this.imlMenu.Images.SetKeyName(3, "Mtree03.png");
            this.imlMenu.Images.SetKeyName(4, "MTree02.png");
            // 
            // sLabel6
            // 
            appearance40.FontData.BoldAsString = "False";
            appearance40.FontData.UnderlineAsString = "False";
            appearance40.ForeColor = System.Drawing.Color.Black;
            appearance40.TextHAlignAsString = "Left";
            appearance40.TextVAlignAsString = "Middle";
            this.sLabel6.Appearance = appearance40;
            this.sLabel6.DbField = null;
            this.sLabel6.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel6.Location = new System.Drawing.Point(110, 10);
            this.sLabel6.Name = "sLabel6";
            this.sLabel6.RequireFlag = WIZ.Control.SLabel.RequireFlagEnum.NO;
            this.sLabel6.Size = new System.Drawing.Size(145, 25);
            this.sLabel6.TabIndex = 216;
            this.sLabel6.Text = "시스템구분";
            // 
            // cboUseFlag_H
            // 
            this.cboUseFlag_H.AutoSize = false;
            this.cboUseFlag_H.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cboUseFlag_H.ComboDataType = WIZ.Control.ComboDataType.All;
            this.cboUseFlag_H.DbConfig = null;
            this.cboUseFlag_H.DefaultValue = "";
            appearance41.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cboUseFlag_H.DisplayLayout.Appearance = appearance41;
            this.cboUseFlag_H.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.cboUseFlag_H.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cboUseFlag_H.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance42.BackColor = System.Drawing.Color.Gray;
            this.cboUseFlag_H.DisplayLayout.CaptionAppearance = appearance42;
            this.cboUseFlag_H.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.cboUseFlag_H.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.RoyalBlue;
            this.cboUseFlag_H.DisplayLayout.InterBandSpacing = 2;
            this.cboUseFlag_H.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance43.BackColor = System.Drawing.Color.RoyalBlue;
            appearance43.FontData.BoldAsString = "True";
            appearance43.ForeColor = System.Drawing.Color.White;
            this.cboUseFlag_H.DisplayLayout.Override.ActiveRowAppearance = appearance43;
            appearance44.FontData.BoldAsString = "True";
            this.cboUseFlag_H.DisplayLayout.Override.ActiveRowCellAppearance = appearance44;
            this.cboUseFlag_H.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            this.cboUseFlag_H.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.cboUseFlag_H.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.None;
            this.cboUseFlag_H.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010ScrollbarButton;
            appearance45.BackColor = System.Drawing.Color.DimGray;
            appearance45.BackColor2 = System.Drawing.Color.Silver;
            appearance45.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance45.BorderColor = System.Drawing.Color.White;
            appearance45.FontData.BoldAsString = "True";
            appearance45.ForeColor = System.Drawing.Color.White;
            this.cboUseFlag_H.DisplayLayout.Override.HeaderAppearance = appearance45;
            this.cboUseFlag_H.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            appearance46.BackColor2 = System.Drawing.Color.Gray;
            appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.cboUseFlag_H.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance46;
            this.cboUseFlag_H.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            this.cboUseFlag_H.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            this.cboUseFlag_H.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.cboUseFlag_H.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(133)))), ((int)(((byte)(188)))));
            appearance47.FontData.BoldAsString = "True";
            this.cboUseFlag_H.DisplayLayout.Override.SelectedRowAppearance = appearance47;
            this.cboUseFlag_H.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            this.cboUseFlag_H.DisplayLayout.RowConnectorColor = System.Drawing.Color.Silver;
            this.cboUseFlag_H.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.cboUseFlag_H.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.cboUseFlag_H.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cboUseFlag_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboUseFlag_H.Location = new System.Drawing.Point(356, 36);
            this.cboUseFlag_H.MajorCode = "USEFLAG";
            this.cboUseFlag_H.Name = "cboUseFlag_H";
            this.cboUseFlag_H.SelectedValue = null;
            this.cboUseFlag_H.ShowDefaultValue = true;
            this.cboUseFlag_H.Size = new System.Drawing.Size(150, 25);
            this.cboUseFlag_H.TabIndex = 221;
            // 
            // cboSystemType_H
            // 
            this.cboSystemType_H.AutoSize = false;
            this.cboSystemType_H.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cboSystemType_H.ComboDataType = WIZ.Control.ComboDataType.CodeOnly;
            this.cboSystemType_H.DbConfig = null;
            this.cboSystemType_H.DefaultValue = "";
            appearance48.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cboSystemType_H.DisplayLayout.Appearance = appearance48;
            this.cboSystemType_H.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.cboSystemType_H.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cboSystemType_H.DisplayLayout.BorderStyleCaption = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance49.BackColor = System.Drawing.Color.Gray;
            this.cboSystemType_H.DisplayLayout.CaptionAppearance = appearance49;
            this.cboSystemType_H.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.cboSystemType_H.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.RoyalBlue;
            this.cboSystemType_H.DisplayLayout.InterBandSpacing = 2;
            this.cboSystemType_H.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance50.BackColor = System.Drawing.Color.RoyalBlue;
            appearance50.FontData.BoldAsString = "True";
            appearance50.ForeColor = System.Drawing.Color.White;
            this.cboSystemType_H.DisplayLayout.Override.ActiveRowAppearance = appearance50;
            appearance51.FontData.BoldAsString = "True";
            this.cboSystemType_H.DisplayLayout.Override.ActiveRowCellAppearance = appearance51;
            this.cboSystemType_H.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            this.cboSystemType_H.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.cboSystemType_H.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.None;
            this.cboSystemType_H.DisplayLayout.Override.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010ScrollbarButton;
            appearance52.BackColor = System.Drawing.Color.DimGray;
            appearance52.BackColor2 = System.Drawing.Color.Silver;
            appearance52.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance52.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance52.BorderColor = System.Drawing.Color.White;
            appearance52.FontData.BoldAsString = "True";
            appearance52.ForeColor = System.Drawing.Color.White;
            this.cboSystemType_H.DisplayLayout.Override.HeaderAppearance = appearance52;
            this.cboSystemType_H.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            appearance53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            appearance53.BackColor2 = System.Drawing.Color.Gray;
            appearance53.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.cboSystemType_H.DisplayLayout.Override.RowSelectorHeaderAppearance = appearance53;
            this.cboSystemType_H.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            this.cboSystemType_H.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex;
            this.cboSystemType_H.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.cboSystemType_H.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.XPThemed;
            appearance54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(133)))), ((int)(((byte)(188)))));
            appearance54.FontData.BoldAsString = "True";
            this.cboSystemType_H.DisplayLayout.Override.SelectedRowAppearance = appearance54;
            this.cboSystemType_H.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            this.cboSystemType_H.DisplayLayout.RowConnectorColor = System.Drawing.Color.Silver;
            this.cboSystemType_H.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.cboSystemType_H.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.cboSystemType_H.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList;
            this.cboSystemType_H.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboSystemType_H.Location = new System.Drawing.Point(110, 35);
            this.cboSystemType_H.MajorCode = "SYSTEMID";
            this.cboSystemType_H.Name = "cboSystemType_H";
            this.cboSystemType_H.SelectedValue = null;
            this.cboSystemType_H.ShowDefaultValue = false;
            this.cboSystemType_H.Size = new System.Drawing.Size(200, 26);
            this.cboSystemType_H.TabIndex = 222;
            this.cboSystemType_H.ValueChanged += new System.EventHandler(this.cboSystemType_H_ValueChanged);
            // 
            // SY0020
            // 
            this.ClientSize = new System.Drawing.Size(1136, 825);
            this.Name = "SY0020";
            this.Load += new System.EventHandler(this.SY0020_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxMenuInfor)).EndInit();
            this.gbxMenuInfor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMenuName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMenuType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UseFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxProgramInfor)).EndInit();
            this.gbxProgramInfor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uceExcelIMFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceSumFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceExcelFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ucePrnFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceSaveFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceDelFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceNewFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uceInqFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scboProgramIDCode1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProgramID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProgramType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameSpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUseFlag_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSystemType_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.ResumeLayout(false);

        }
    }
}

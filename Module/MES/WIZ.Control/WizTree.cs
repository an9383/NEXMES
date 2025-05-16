using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinTree;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WIZ.Control
{
    public class WizTree : UltraTree
    {
        #region 멤버 변수
        public ImageList imlMenu;
        private UltraTree_DropHightLight_DrawFilter_Class UltraTree_DropHightLight_DrawFilter = new UltraTree_DropHightLight_DrawFilter_Class();

        private DataSet rtnDsTemp = new DataSet();

        private int ex_node_cnt = 0;

        private bool _bSave = false;

        private BindingSource bs;
        public string RelationDBName = "rel_db";

        private int menuid = 0;

        public string KeyColumnName;
        public string ParentKeyColumnName;
        public string SortColumnName;
        public string TextColumnName;
        public string LinkTableName;

        public System.Windows.Forms.Control bindingComponent;
        #endregion

        #region 생성자 및 초기화
        public WizTree()
        {
            InitializeComponent();

            UltraTree_DropHightLight_DrawFilter.Invalidate += UltraTree_DropHightLight_DrawFilter_Invalidate;
            UltraTree_DropHightLight_DrawFilter.QueryStateAllowedForNode += UltraTree_DropHightLight_DrawFilter_QueryStateAllowedForNode;
            this.DrawFilter = UltraTree_DropHightLight_DrawFilter;
        }

        private void InitializeComponent()
        {
            Infragistics.Win.UltraWinTree.UltraTreeColumnSet ultraTreeColumnSet1 = new Infragistics.Win.UltraWinTree.UltraTreeColumnSet();
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            this.bs = new System.Windows.Forms.BindingSource(new System.ComponentModel.Container());
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager();
            this.imlMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlMenu.ImageStream")));
            this.imlMenu.TransparentColor = System.Drawing.Color.Transparent;
            this.imlMenu.Images.SetKeyName(0, "Item.bmp");
            this.imlMenu.Images.SetKeyName(1, "window_dialog.ico");
            this.imlMenu.Images.SetKeyName(2, "MTree01.png");
            this.imlMenu.Images.SetKeyName(3, "Mtree03.png");
            this.imlMenu.Images.SetKeyName(4, "MTree02.png");

            this.AllowDrop = true;
            this.ColumnSettings.AllowSorting = Infragistics.Win.DefaultableBoolean.True;
            this.ColumnSettings.ColumnAutoSizeMode = Infragistics.Win.UltraWinTree.ColumnAutoSizeMode.VisibleNodes;
            this.ColumnSettings.LabelPosition = Infragistics.Win.UltraWinTree.NodeLayoutLabelPosition.None;
            this.ColumnSettings.NullText = "*";
            ultraTreeColumnSet1.LabelPosition = Infragistics.Win.UltraWinTree.NodeLayoutLabelPosition.None;
            ultraTreeColumnSet1.NullText = "*";
            this.ColumnSettings.RootColumnSet = ultraTreeColumnSet1;
            this.DisplayStyle = Infragistics.Win.UltraWinTree.UltraTreeDisplayStyle.Standard;
            this.ImageList = this.imlMenu;
            this.ImagePadding = 15;
            this.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.NodeConnectorColor = System.Drawing.Color.Gray;
            this.NodeConnectorStyle = Infragistics.Win.UltraWinTree.NodeConnectorStyle.Solid;
            _override1.AllowAutoDragExpand = Infragistics.Win.UltraWinTree.AllowAutoDragExpand.ExpandOnDragHoverWhenExpansionIndicatorVisible;
            _override1.SelectionType = Infragistics.Win.UltraWinTree.SelectType.SingleAutoDrag;
            _override1.ShowColumns = Infragistics.Win.DefaultableBoolean.False;
            _override1.Sort = Infragistics.Win.UltraWinTree.SortType.Ascending;
            this.Override = _override1;
            this.ViewStyle = Infragistics.Win.UltraWinTree.ViewStyle.Standard;
            this.SelectionDragStart += new System.EventHandler(this.WizTree_SelectionDragStart);
            this.InitializeDataNode += new Infragistics.Win.UltraWinTree.InitializeDataNodeEventHandler(this.WizTree_InitializeDataNode);
            this.ColumnSetGenerated += new Infragistics.Win.UltraWinTree.ColumnSetGeneratedEventHandler(this.WizTree_ColumnSetGenerated);
            this.Click += new System.EventHandler(this.WizTree_Click);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.WizTree_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.WizTree_DragOver);
            this.DragLeave += new System.EventHandler(this.WizTree_DragLeave);
            this.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.WizTree_QueryContinueDrag);
        }
        #endregion

        #region 트리 액션 메소드
        private void WizTree_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            if (e.EscapePressed)
            {
                e.Action = DragAction.Cancel;
                UltraTree_DropHightLight_DrawFilter.ClearDropHighlight();
            }
        }

        private void WizTree_DragLeave(object sender, EventArgs e)
        {
            UltraTree_DropHightLight_DrawFilter.ClearDropHighlight();
        }

        private void WizTree_DragOver(object sender, DragEventArgs e)
        {
            Point point = this.PointToClient(new Point(e.X, e.Y));
            UltraTreeNode nodeFromPoint = this.GetNodeFromPoint(point);
            if (nodeFromPoint == null)
            {
                e.Effect = DragDropEffects.None;
                UltraTree_DropHightLight_DrawFilter.ClearDropHighlight();
            }
            else if (IsContinentNode(nodeFromPoint) && IsContinentNodeSelected(this) && point.Y > nodeFromPoint.Bounds.Top + 2 && point.Y < nodeFromPoint.Bounds.Bottom - 2)
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

        private void WizTree_DragDrop(object sender, DragEventArgs e)
        {
            UltraTreeNode dropHightLightNode = UltraTree_DropHightLight_DrawFilter.DropHightLightNode;
            SelectedNodesCollection selectedNodesCollection = (SelectedNodesCollection)e.Data.GetData(typeof(SelectedNodesCollection));
            selectedNodesCollection = (selectedNodesCollection.Clone() as SelectedNodesCollection);
            selectedNodesCollection.SortByPosition();
            switch (UltraTree_DropHightLight_DrawFilter.DropLinePosition)
            {
                case DropLinePositionEnum.OnNode:
                    {
                        //if (dropHightLightNode.Cells["MenuType"].Value.ToString() == "P")
                        //{
                        //    return;
                        //}
                        for (int i = 0; i <= selectedNodesCollection.Count - 1; i++)
                        {
                            rtnDsTemp.Tables[LinkTableName].Rows.Find(selectedNodesCollection[i].Cells[KeyColumnName].Value.ToString())[ParentKeyColumnName] = dropHightLightNode.Cells[KeyColumnName].Value;
                            this.RefreshSort();
                            SetNodesSort(selectedNodesCollection[i]);
                        }
                        break;
                    }
                case DropLinePositionEnum.BelowNode:
                    {
                        string text2 = Convert.ToString(selectedNodesCollection[0].Cells[KeyColumnName].Value);
                        for (int i = 0; i <= selectedNodesCollection.Count - 1; i++)
                        {
                            rtnDsTemp.Tables[LinkTableName].Rows.Find(selectedNodesCollection[i].Cells[KeyColumnName].Value.ToString())[SortColumnName] = Convert.ToInt32(dropHightLightNode.Cells[SortColumnName].Value) + 1;
                            rtnDsTemp.Tables[LinkTableName].Rows.Find(selectedNodesCollection[i].Cells[KeyColumnName].Value.ToString())[ParentKeyColumnName] = dropHightLightNode.Cells[ParentKeyColumnName].Value;
                            this.RefreshSort();
                            SetNodesSort(selectedNodesCollection[i].Parent);
                        }
                        break;
                    }
                case DropLinePositionEnum.AboveNode:
                    {
                        string text = Convert.ToString(selectedNodesCollection[0].Cells[KeyColumnName].Value);
                        for (int i = 0; i <= selectedNodesCollection.Count - 1; i++)
                        {
                            rtnDsTemp.Tables[LinkTableName].Rows.Find(selectedNodesCollection[i].Cells[KeyColumnName].Value.ToString())[SortColumnName] = Convert.ToInt32(dropHightLightNode.Cells[SortColumnName].Value) - 1;
                            rtnDsTemp.Tables[LinkTableName].Rows.Find(selectedNodesCollection[i].Cells[KeyColumnName].Value.ToString())[ParentKeyColumnName] = dropHightLightNode.Cells[ParentKeyColumnName].Value;
                            this.RefreshSort();
                            SetNodesSort(selectedNodesCollection[i].Parent);
                        }
                        break;
                    }
            }
            this.RefreshSort();
            UltraTree_DropHightLight_DrawFilter.ClearDropHighlight();
        }

        private void WizTree_Click(object sender, EventArgs e)
        {
            if (bs.Count != 0)
            {
                bs.Position = bs.Find(KeyColumnName, this.ActiveNode.Cells[KeyColumnName].Value);
            }
        }

        private void WizTree_ColumnSetGenerated(object sender, ColumnSetGeneratedEventArgs e)
        {
            e.ColumnSet.Columns[SortColumnName].SortType = SortType.Ascending;
            if (e.ColumnSet.Key == null)
            {
                return;
            }
            string key = e.ColumnSet.Key;
            if (!(key == RelationDBName))
            {
                if (key == LinkTableName)
                {
                    e.ColumnSet.NodeTextColumn = e.ColumnSet.Columns[rtnDsTemp.Tables[LinkTableName].Columns[TextColumnName].ToString()];
                }
            }
            else
            {
                e.ColumnSet.NodeTextColumn = e.ColumnSet.Columns[rtnDsTemp.Tables[LinkTableName].Columns[TextColumnName].ToString()];
            }
        }

        private void WizTree_InitializeDataNode(object sender, InitializeDataNodeEventArgs e)
        {
            try
            {

                if (e.Node.Parent == null && e.Node.Cells[ParentKeyColumnName].Value.ToString() != "0")
                {
                    e.Node.Visible = false;
                    try
                    {
                        e.Node.Key = Convert.ToString(e.Node.Cells[KeyColumnName].Value);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    return;
                }
                //if (e.Node.Cells["MenuType"].Value.ToString() == "M")
                //{
                //    e.Node.Override.NodeAppearance.Image = 2;
                //    //if (_bSave && e.Node.Key == Ex_Node[ex_node_cnt])
                //    //{
                //    //    e.Node.Expanded = true;
                //    //    ex_node_cnt++;
                //    //    node(e.Node);
                //    //    _bSave = false;
                //    //}
                //}
                //else
                //{
                //    e.Node.Override.NodeAppearance.Image = 3;
                //}
                e.Node.Override.ImageSize = new Size(16, 16);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void WizTree_SelectionDragStart(object sender, EventArgs e)
        {
            this.DoDragDrop(this.SelectedNodes, DragDropEffects.Move);
        }
        #endregion

        #region 이벤트 처리
        private void UltraTree_DropHightLight_DrawFilter_Invalidate(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void UltraTree_DropHightLight_DrawFilter_QueryStateAllowedForNode(object sender, UltraTree_DropHightLight_DrawFilter_Class.QueryStateAllowedForNodeEventArgs e)
        {
            e.StatesAllowed = DropLinePositionEnum.All;
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
                    rtnDsTemp.Tables[0].Rows.Find(node.Nodes[i].Cells[KeyColumnName].Value.ToString())[SortColumnName] = node.Nodes[i].Index;
                }
            }
        }

        private void node(UltraTreeNode node)
        {
            int num = 0;
            //while (true)
            //{
            //    if (num < node.RootNode.Nodes.Count)
            //    {
            //        //if (Convert.ToString(node.RootNode.Nodes[num].Cells[KeyColumnName].Value) == Convert.ToString(Ex_Node[ex_node_cnt]))
            //        //{
            //        //    break;
            //        //}
            //        num++;
            //        continue;
            //    }
            //    return;
            //}
            ex_node_cnt++;
            UltraTreeNode ultraTreeNode = node.RootNode.Nodes[num];
            ultraTreeNode.Expanded = true;
            this.node(ultraTreeNode);
        }

        #endregion

        #region 데이터 처리
        private void BindingClear()
        {
            if (bindingComponent == null) return;

            foreach (System.Windows.Forms.Control c in bindingComponent.Controls)
            {
                c.DataBindings.Clear();

                switch (c.GetType().Name.ToUpper())
                {
                    case "ULTRACHECKEDITOR":
                        UltraCheckEditor uce = c as UltraCheckEditor;

                        if (uce != null)
                        {
                            uce.Checked = false;
                        }
                        break;
                    case "CHECKBOX":
                        CheckBox chk = c as CheckBox;

                        if (chk != null)
                        {
                            chk.Checked = false;
                        }
                        break;
                    case "ULTRACOMBOEDITOR":
                        {
                            Infragistics.Win.UltraWinEditors.UltraComboEditor e = c as Infragistics.Win.UltraWinEditors.UltraComboEditor;

                            if (e != null)
                            {
                                e.Value = null;
                            }
                        }
                        break;
                    case "COMBOBOX":
                        {
                            ComboBox e = c as ComboBox;

                            if (e != null)
                            {
                                e.SelectedValue = null;
                            }
                        }
                        break;
                    default:
                        c.Text = "";
                        break;
                }

            }
        }

        private void Binding()
        {
            BindingClear();

            if (bindingComponent == null) return;

            foreach (System.Windows.Forms.Control c in bindingComponent.Controls)
            {
                string sTag = CModule.ToString(c.Tag);

                switch (c.GetType().Name.ToUpper())
                {
                    case "ULTRACHECKEDITOR":
                    case "CHECKBOX":
                        {
                            Binding bTemp = new Binding("Checked", bs, sTag);
                            bTemp.Format += ComboBind;
                            c.DataBindings.Add(bTemp);
                        }
                        break;
                    case "ULTRACOMBOEDITOR":
                    case "COMBOBOX":
                    default:
                        {
                            c.DataBindings.Add("Value", bs, sTag);
                        }
                        break;
                }
            }
        }

        private void ComboBind(object send, ConvertEventArgs e)
        {
            if (e.Value == DBNull.Value)
            {
                e.Value = false;
            }
            e.Value = (Convert.ToString(e.Value) != "0" && (Convert.ToString(e.Value) == "1" || Convert.ToBoolean(e.Value)));
        }

        public void DoInquire(DataTable dataTable, string sKey, string sParentKey, string sTextColumnName, string sSortColName)
        {
            try
            {
                if (dataTable == null)
                {
                    return;
                }

                if (dataTable.Rows.Count > 0)
                {
                    rtnDsTemp = new DataSet();

                    BindingClear();

                    KeyColumnName = sKey;
                    ParentKeyColumnName = sParentKey;
                    SortColumnName = sSortColName;
                    TextColumnName = sTextColumnName;

                    rtnDsTemp.Tables.Add(dataTable);
                    rtnDsTemp.Tables[0].PrimaryKey = new DataColumn[1]
                    {
                        rtnDsTemp.Tables[0].Columns[sKey]
                    };

                    LinkTableName = dataTable.TableName;
                    rtnDsTemp.Relations.Add(RelationDBName, rtnDsTemp.Tables[0].Columns[sKey], rtnDsTemp.Tables[0].Columns[sParentKey], createConstraints: false);
                    rtnDsTemp.Tables[0].DefaultView.Sort = sSortColName;
                    this.SetDataBinding(rtnDsTemp, LinkTableName);
                    this.Nodes.Override.Sort = SortType.Ascending;
                    bs.DataSource = rtnDsTemp;
                    bs.DataMember = LinkTableName;
                    rtnDsTemp.EnforceConstraints = false;
                    this.SynchronizeCurrencyManager = true;
                    this.BorderStyle = UIElementBorderStyle.None;
                    this.CausesValidation = false;
                    this.Override.ShowColumns = DefaultableBoolean.False;
                    this.ColumnSettings.LabelPosition = NodeLayoutLabelPosition.None;
                    this.ColumnSettings.ColumnAutoSizeMode = Infragistics.Win.UltraWinTree.ColumnAutoSizeMode.VisibleNodes;
                    this.ColumnSettings.AllowSorting = DefaultableBoolean.True;
                    this.UseFlatMode = DefaultableBoolean.True;
                    this.Override.ShowExpansionIndicator = Infragistics.Win.UltraWinTree.ShowExpansionIndicator.CheckOnDisplay;
                    this.AllowDrop = true;
                    this.ScrollBounds = Infragistics.Win.UltraWinTree.ScrollBounds.ScrollToFill;

                    Binding();
                }
                else
                {
                    this.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DoNew()
        {
            try
            {
                DataRow dataRow = rtnDsTemp.Tables[0].NewRow();
                if (this.ActiveNode == null)
                {
                    dataRow[SortColumnName] = 0;
                    dataRow[ParentKeyColumnName] = "0";
                }
                else
                {
                    dataRow[SortColumnName] = (this.ActiveNode.Cells[SortColumnName].Value != null) ? CModule.ToInt32(this.ActiveNode.Cells[SortColumnName].Value) : 0;
                    dataRow[ParentKeyColumnName] = (this.ActiveNode.Cells[ParentKeyColumnName].Value ?? "0");
                }
                dataRow[KeyColumnName] = -1;
                rtnDsTemp.Tables[0].Rows.Add(dataRow);
                this.RefreshSort();
                this.ActiveNode = this.ActiveNode.NextVisibleNode;
                WizTree_Click(this, null);
            }
            catch
            {
            }
        }

        public void DoDelete()
        {
            try
            {
                //if (this.ActiveNode.Cells["MENUTYPE"].Value.ToString() == "M")
                //{
                //    if (MessageBox.Show(Common.getLangText("하위도 삭제됩니다.\n\n삭제하시겠습니까?", "MSG"), "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //    {
                //        string text = this.ActiveNode.Cells[KeyColumnName].Value.ToString();
                //        foreach (DataRow row in rtnDsTemp.Tables[0].Rows)
                //        {
                //            DataRowState rowState = row.RowState;
                //            if (rowState != DataRowState.Deleted && row[ParentKeyColumnName].ToString() == text)
                //            {
                //                row.Delete();
                //            }
                //        }
                //        rtnDsTemp.Tables[0].Rows.Find(text).Delete();
                //    }
                //}
                //else
                //{
                string key = this.ActiveNode.Cells[KeyColumnName].Value.ToString();
                rtnDsTemp.Tables[0].Rows.Find(key).Delete();
                //}
            }
            catch (Exception)
            {
            }
        }
        #endregion
    }
}

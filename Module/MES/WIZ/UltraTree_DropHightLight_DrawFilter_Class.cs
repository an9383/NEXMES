using Infragistics.Win;
using Infragistics.Win.UltraWinTree;
using System;
using System.Drawing;

namespace WIZ
{
    public class UltraTree_DropHightLight_DrawFilter_Class : IUIElementDrawFilter
    {
        public delegate void QueryStateAllowedForNodeEventHandler(object sender, QueryStateAllowedForNodeEventArgs e);

        public class QueryStateAllowedForNodeEventArgs : EventArgs
        {
            public UltraTreeNode Node;

            public DropLinePositionEnum DropLinePosition;

            public DropLinePositionEnum StatesAllowed;
        }

        private UltraTreeNode mvarDropHighLightNode;

        private DropLinePositionEnum mvarDropLinePosition;

        private int mvarDropLineWidth;

        private Color mvarDropHighLightBackColor;

        private Color mvarDropHighLightForeColor;

        private Color mvarDropLineColor;

        private int mvarEdgeSensitivity;

        public UltraTreeNode DropHightLightNode
        {
            get
            {
                return mvarDropHighLightNode;
            }
            set
            {
                if (!mvarDropHighLightNode.Equals(value))
                {
                    mvarDropHighLightNode = value;
                    PositionChanged();
                }
            }
        }

        public DropLinePositionEnum DropLinePosition
        {
            get
            {
                return mvarDropLinePosition;
            }
            set
            {
                if (mvarDropLinePosition != value)
                {
                    mvarDropLinePosition = value;
                    PositionChanged();
                }
            }
        }

        public int DropLineWidth
        {
            get
            {
                return mvarDropLineWidth;
            }
            set
            {
                mvarDropLineWidth = value;
            }
        }

        public Color DropHighLightBackColor
        {
            get
            {
                return mvarDropHighLightBackColor;
            }
            set
            {
                mvarDropHighLightBackColor = value;
            }
        }

        public Color DropHighLightForeColor
        {
            get
            {
                return mvarDropHighLightForeColor;
            }
            set
            {
                mvarDropHighLightForeColor = value;
            }
        }

        public Color DropLineColor
        {
            get
            {
                return mvarDropLineColor;
            }
            set
            {
                mvarDropLineColor = value;
            }
        }

        public int EdgeSensitivity
        {
            get
            {
                return mvarEdgeSensitivity;
            }
            set
            {
                mvarEdgeSensitivity = value;
            }
        }

        public event EventHandler Invalidate;

        public event QueryStateAllowedForNodeEventHandler QueryStateAllowedForNode;

        public UltraTree_DropHightLight_DrawFilter_Class()
        {
            InitProperties();
        }

        private void InitProperties()
        {
            mvarDropHighLightNode = null;
            mvarDropLinePosition = DropLinePositionEnum.None;
            mvarDropHighLightBackColor = SystemColors.Highlight;
            mvarDropHighLightForeColor = SystemColors.HighlightText;
            mvarDropLineColor = SystemColors.ControlText;
            mvarEdgeSensitivity = 0;
            mvarDropLineWidth = 2;
        }

        public void Dispose()
        {
            mvarDropHighLightNode = null;
        }

        private void PositionChanged()
        {
            if (this.Invalidate != null)
            {
                EventArgs empty = EventArgs.Empty;
                this.Invalidate(this, empty);
            }
        }

        public void ClearDropHighlight()
        {
            SetDropHighlightNode(null, DropLinePositionEnum.None);
        }

        public void SetDropHighlightNode(UltraTreeNode Node, Point PointInTreeCoords)
        {
            int num = mvarEdgeSensitivity;
            if (num == 0)
            {
                num = Node.Bounds.Height / 3;
            }
            DropLinePositionEnum dropLinePosition = (PointInTreeCoords.Y < Node.Bounds.Top + num) ? DropLinePositionEnum.AboveNode : ((PointInTreeCoords.Y <= Node.Bounds.Bottom - num - 1) ? DropLinePositionEnum.OnNode : DropLinePositionEnum.BelowNode);
            SetDropHighlightNode(Node, dropLinePosition);
        }

        private void SetDropHighlightNode(UltraTreeNode Node, DropLinePositionEnum DropLinePosition)
        {
            bool flag = false;
            try
            {
                flag = ((mvarDropHighLightNode == null || !mvarDropHighLightNode.Equals(Node) || mvarDropLinePosition != DropLinePosition) ? true : false);
            }
            catch
            {
                if (mvarDropHighLightNode == null)
                {
                    flag = (Node != null);
                }
            }
            mvarDropHighLightNode = Node;
            mvarDropLinePosition = DropLinePosition;
            if (flag)
            {
                PositionChanged();
            }
        }

        DrawPhase IUIElementDrawFilter.GetPhasesToFilter(ref UIElementDrawParams drawParams)
        {
            return DrawPhase.BeforeDrawElement | DrawPhase.AfterDrawElement;
        }

        bool IUIElementDrawFilter.DrawElement(DrawPhase drawPhase, ref UIElementDrawParams drawParams)
        {
            if (mvarDropHighLightNode == null || mvarDropLinePosition == DropLinePositionEnum.None)
            {
                return false;
            }
            QueryStateAllowedForNodeEventArgs queryStateAllowedForNodeEventArgs = new QueryStateAllowedForNodeEventArgs();
            queryStateAllowedForNodeEventArgs.Node = mvarDropHighLightNode;
            queryStateAllowedForNodeEventArgs.DropLinePosition = mvarDropLinePosition;
            queryStateAllowedForNodeEventArgs.StatesAllowed = DropLinePositionEnum.All;
            this.QueryStateAllowedForNode(this, queryStateAllowedForNodeEventArgs);
            if ((queryStateAllowedForNodeEventArgs.StatesAllowed & mvarDropLinePosition) != mvarDropLinePosition)
            {
                return false;
            }
            UIElement element = drawParams.Element;
            switch (drawPhase)
            {
                case DrawPhase.BeforeDrawElement:
                    if ((mvarDropLinePosition & DropLinePositionEnum.OnNode) == DropLinePositionEnum.OnNode && element.GetType() == typeof(NodeTextUIElement))
                    {
                        UltraTreeNode ultraTreeNode = (UltraTreeNode)element.GetContext(typeof(UltraTreeNode));
                        if (ultraTreeNode.Equals(mvarDropHighLightNode))
                        {
                            drawParams.AppearanceData.BackColor = mvarDropHighLightBackColor;
                            drawParams.AppearanceData.ForeColor = mvarDropHighLightForeColor;
                        }
                    }
                    break;
                case DrawPhase.AfterDrawElement:
                    if (element.GetType() == typeof(UltraTreeUIElement))
                    {
                        Pen pen = new Pen(mvarDropLineColor, mvarDropLineWidth);
                        Graphics graphics = drawParams.Graphics;
                        NodeSelectableAreaUIElement nodeSelectableAreaUIElement = (NodeSelectableAreaUIElement)drawParams.Element.GetDescendant(typeof(NodeSelectableAreaUIElement), mvarDropHighLightNode);
                        int num = nodeSelectableAreaUIElement.Rect.Left - 4;
                        UltraTree ultraTree = (UltraTree)nodeSelectableAreaUIElement.GetContext(typeof(UltraTree));
                        int num2 = ultraTree.DisplayRectangle.Right - 4;
                        if ((mvarDropLinePosition & DropLinePositionEnum.AboveNode) == DropLinePositionEnum.AboveNode)
                        {
                            int top = mvarDropHighLightNode.Bounds.Top;
                            graphics.DrawLine(pen, num, top, num2, top);
                            pen.Width = 1f;
                            graphics.DrawLine(pen, num, top - 3, num, top + 2);
                            graphics.DrawLine(pen, num + 1, top - 2, num + 1, top + 1);
                            graphics.DrawLine(pen, num2, top - 3, num2, top + 2);
                            graphics.DrawLine(pen, num2 - 1, top - 2, num2 - 1, top + 1);
                        }
                        if ((mvarDropLinePosition & DropLinePositionEnum.BelowNode) == DropLinePositionEnum.BelowNode)
                        {
                            int top = mvarDropHighLightNode.Bounds.Bottom;
                            graphics.DrawLine(pen, num, top, num2, top);
                            pen.Width = 1f;
                            graphics.DrawLine(pen, num, top - 3, num, top + 2);
                            graphics.DrawLine(pen, num + 1, top - 2, num + 1, top + 1);
                            graphics.DrawLine(pen, num2, top - 3, num2, top + 2);
                            graphics.DrawLine(pen, num2 - 1, top - 2, num2 - 1, top + 1);
                        }
                    }
                    break;
            }
            return false;
        }
    }
}

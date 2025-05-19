using Infragistics.Win;
using Infragistics.Win.UltraWinTree;
using System;
using System.Drawing;

namespace WIZ.MAIN
{
    public class CustomColorNodeTextDrawFilter : IUIElementDrawFilter
    {
        private string[] separator;

        private Color[] colors;

        public CustomColorNodeTextDrawFilter(string[] separator, params Color[] colors)
        {
            this.separator = separator;
            this.colors = colors;
        }

        DrawPhase IUIElementDrawFilter.GetPhasesToFilter(ref UIElementDrawParams drawParams)
        {
            return (drawParams.Element is NodeTextUIElement) ? DrawPhase.BeforeDrawForeground : DrawPhase.None;
        }

        bool IUIElementDrawFilter.DrawElement(DrawPhase drawPhase, ref UIElementDrawParams drawParams)
        {
            UltraTreeNode ultraTreeNode = drawParams.Element.GetContext(typeof(UltraTreeNode), checkParentElementContexts: true) as UltraTreeNode;
            if (ultraTreeNode != null)
            {
                string text = ultraTreeNode.Text;
                float width = drawParams.Graphics.MeasureString(" ", drawParams.Font).Width;
                float num = 0f;
                RectangleF rectangleF = drawParams.Element.RectInsideBorders;
                RectangleF layoutRectangle = rectangleF;
                if (text.IndexOf(separator[0]) >= 0)
                {
                    string[] array = text.Split(separator, StringSplitOptions.None);
                    for (int i = 0; i < array.Length; i++)
                    {
                        string text2;
                        float width2;
                        Color color;
                        if (i == 1)
                        {
                            text2 = separator[0];
                            width2 = drawParams.Graphics.MeasureString(text2, drawParams.Font).Width;
                            num += width2;
                            num -= width;
                            color = colors[0];
                            using (SolidBrush brush = new SolidBrush(color))
                            {
                                drawParams.Graphics.DrawString(text2, drawParams.Font, brush, layoutRectangle);
                            }
                            layoutRectangle = new RectangleF(rectangleF.Left + num, rectangleF.Y, rectangleF.Width - num, rectangleF.Height);
                        }
                        text2 = array[i];
                        width2 = drawParams.Graphics.MeasureString(text2, drawParams.Font).Width;
                        num += width2;
                        num -= width;
                        color = Color.Black;
                        using (SolidBrush brush2 = new SolidBrush(color))
                        {
                            drawParams.Graphics.DrawString(text2, drawParams.Font, brush2, layoutRectangle);
                        }
                        layoutRectangle = new RectangleF(rectangleF.Left + num, rectangleF.Y, rectangleF.Width - num, rectangleF.Height);
                    }
                }
                else
                {
                    string text2 = text;
                    float width2 = drawParams.Graphics.MeasureString(text2, drawParams.Font).Width;
                    num += width2;
                    num -= width;
                    Color color = Color.Black;
                    using (SolidBrush brush3 = new SolidBrush(color))
                    {
                        drawParams.Graphics.DrawString(text2, drawParams.Font, brush3, layoutRectangle);
                    }
                    layoutRectangle = new RectangleF(rectangleF.Left + num, rectangleF.Y, rectangleF.Width - num, rectangleF.Height);
                }
            }
            return true;
        }
    }
}

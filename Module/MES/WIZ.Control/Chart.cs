using Infragistics.Win.UltraWinChart;
using System;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;

namespace WIZ.Control
{
    public class Chart : UltraChart
    {
        private IContainer components = null;

        public ContextMenuStrip cmsMenu;

        public ToolStripMenuItem mnuExport;

        public Chart()
        {
            InitializeComponent();
        }

        public Chart(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        private void cmsMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "chart.png";
                saveFileDialog.Filter = "Png (*.png )|*.png";
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    PropertyInfo property = typeof(ImageFormat).GetProperty("Png");
                    SaveTo(saveFileDialog.FileName, (ImageFormat)property.GetValue(null, null));
                }
            }
            catch
            {
            }
        }

        private void Chart_Load(object sender, EventArgs e)
        {
            if (!base.DesignMode)
            {
                try
                {
                    foreach (ToolStripItem item in cmsMenu.Items)
                    {
                        item.Text = Common.getLangText(item.Text);
                    }
                }
                catch
                {
                }
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

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WIZ.Control.Chart));
            cmsMenu = new System.Windows.Forms.ContextMenuStrip(components);
            mnuExport = new System.Windows.Forms.ToolStripMenuItem();
            cmsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            cmsMenu.Font = new System.Drawing.Font("맑은 고딕", 10f);
            cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[1]
            {
                mnuExport
            });
            cmsMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            cmsMenu.Name = "cmsMenu";
            cmsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            cmsMenu.Size = new System.Drawing.Size(201, 28);
            cmsMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(cmsMenu_ItemClicked);
            mnuExport.Image = (System.Drawing.Image)resources.GetObject("mnuExport.Image");
            mnuExport.Name = "mnuExport";
            mnuExport.ShortcutKeyDisplayString = "";
            mnuExport.Size = new System.Drawing.Size(200, 24);
            mnuExport.Text = "이미지 파일로 저장";
            mnuExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            base.Axis.BackColor = System.Drawing.Color.FromArgb(255, 248, 220);
            base.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            base.Axis.X.Labels.ItemFormatString = "<ITEM_LABEL>";
            base.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            base.Axis.X.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center;
            base.Axis.X.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            base.Axis.X.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            base.Axis.X.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            base.Axis.X.MajorGridLines.AlphaLevel = byte.MaxValue;
            base.Axis.X.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            base.Axis.X.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            base.Axis.X.MajorGridLines.Visible = true;
            base.Axis.X.MinorGridLines.AlphaLevel = byte.MaxValue;
            base.Axis.X.MinorGridLines.Color = System.Drawing.Color.LightGray;
            base.Axis.X.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            base.Axis.X.MinorGridLines.Visible = false;
            base.Axis.X.Visible = true;
            base.Axis.X2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            base.Axis.X2.Labels.ItemFormatString = "<ITEM_LABEL>";
            base.Axis.X2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            base.Axis.X2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center;
            base.Axis.X2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            base.Axis.X2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            base.Axis.X2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            base.Axis.X2.Labels.Visible = false;
            base.Axis.X2.MajorGridLines.AlphaLevel = byte.MaxValue;
            base.Axis.X2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            base.Axis.X2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            base.Axis.X2.MajorGridLines.Visible = true;
            base.Axis.X2.MinorGridLines.AlphaLevel = byte.MaxValue;
            base.Axis.X2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            base.Axis.X2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            base.Axis.X2.MinorGridLines.Visible = false;
            base.Axis.X2.Visible = false;
            base.Axis.Y.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            base.Axis.Y.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            base.Axis.Y.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            base.Axis.Y.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center;
            base.Axis.Y.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            base.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            base.Axis.Y.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            base.Axis.Y.MajorGridLines.AlphaLevel = byte.MaxValue;
            base.Axis.Y.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            base.Axis.Y.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            base.Axis.Y.MajorGridLines.Visible = true;
            base.Axis.Y.MinorGridLines.AlphaLevel = byte.MaxValue;
            base.Axis.Y.MinorGridLines.Color = System.Drawing.Color.LightGray;
            base.Axis.Y.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            base.Axis.Y.MinorGridLines.Visible = false;
            base.Axis.Y.Visible = true;
            base.Axis.Y2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            base.Axis.Y2.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            base.Axis.Y2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            base.Axis.Y2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center;
            base.Axis.Y2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            base.Axis.Y2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            base.Axis.Y2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            base.Axis.Y2.Labels.Visible = false;
            base.Axis.Y2.MajorGridLines.AlphaLevel = byte.MaxValue;
            base.Axis.Y2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            base.Axis.Y2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            base.Axis.Y2.MajorGridLines.Visible = true;
            base.Axis.Y2.MinorGridLines.AlphaLevel = byte.MaxValue;
            base.Axis.Y2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            base.Axis.Y2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            base.Axis.Y2.MinorGridLines.Visible = false;
            base.Axis.Y2.Visible = false;
            base.Axis.Z.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            base.Axis.Z.Labels.ItemFormatString = "";
            base.Axis.Z.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            base.Axis.Z.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center;
            base.Axis.Z.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            base.Axis.Z.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            base.Axis.Z.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            base.Axis.Z.MajorGridLines.AlphaLevel = byte.MaxValue;
            base.Axis.Z.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            base.Axis.Z.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            base.Axis.Z.MajorGridLines.Visible = true;
            base.Axis.Z.MinorGridLines.AlphaLevel = byte.MaxValue;
            base.Axis.Z.MinorGridLines.Color = System.Drawing.Color.LightGray;
            base.Axis.Z.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            base.Axis.Z.MinorGridLines.Visible = false;
            base.Axis.Z.Visible = false;
            base.Axis.Z2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            base.Axis.Z2.Labels.ItemFormatString = "";
            base.Axis.Z2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            base.Axis.Z2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center;
            base.Axis.Z2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            base.Axis.Z2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            base.Axis.Z2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            base.Axis.Z2.Labels.Visible = false;
            base.Axis.Z2.MajorGridLines.AlphaLevel = byte.MaxValue;
            base.Axis.Z2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            base.Axis.Z2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            base.Axis.Z2.MajorGridLines.Visible = true;
            base.Axis.Z2.MinorGridLines.AlphaLevel = byte.MaxValue;
            base.Axis.Z2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            base.Axis.Z2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            base.Axis.Z2.MinorGridLines.Visible = false;
            base.Axis.Z2.Visible = false;
            base.ColorModel.AlphaLevel = 150;
            ContextMenuStrip = cmsMenu;
            base.Name = "Chart";
            base.Load += new System.EventHandler(Chart_Load);
            cmsMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }
    }
}

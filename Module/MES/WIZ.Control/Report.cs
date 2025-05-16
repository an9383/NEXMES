using Infragistics.Win.Printing;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Reflection;
using System.Windows.Forms;

namespace WIZ.Control
{
    public class Report : Component
    {
        private PrintDialog printDialog = new PrintDialog();

        private PrintDocument _printDocument = new PrintDocument();

        private PageSetupDialog pageSetupDialog = new PageSetupDialog();

        private UltraPrintPreviewDialog ultraPrintPreviewDialog = new UltraPrintPreviewDialog();

        private int Report_Width = 0;

        private int Report_Height = 0;

        private int Height_Header = 0;

        private int Height_Section = 0;

        private int Height_Footer = 0;

        private int _CurrentY = 0;

        private int _CurrentX = 0;

        private Font Report_Font = new Font("굴림체", 9f, FontStyle.Regular);

        private Brush Report_Brush = new SolidBrush(Color.Black);

        private Pen Report_Pen = new Pen(Color.Black);

        private Graphics Report_Graphics = null;

        private int Report_FromPage = 0;

        private int Report_ToPage = 0;

        private int Report_CurrentPage = 0;

        private Padding Report_Padding = new Padding(2, 3, 2, 3);

        private Form ParentForm;

        public System.Windows.Forms.Control ParentControl;

        private string PagePrnFName = "";

        private IContainer components = null;

        public PrintDocument PrintDocument => _printDocument;

        public Padding ReportPadding
        {
            get
            {
                return Report_Padding;
            }
            set
            {
                Report_Padding = value;
            }
        }

        public Font ReportFont
        {
            get
            {
                return Report_Font;
            }
            set
            {
                Report_Font = value;
            }
        }

        public Brush ReportBrush
        {
            get
            {
                return Report_Brush;
            }
            set
            {
                Report_Brush = value;
            }
        }

        public Pen ReportPen
        {
            get
            {
                return Report_Pen;
            }
            set
            {
                Report_Pen = value;
            }
        }

        public Graphics ReportGraphics => Report_Graphics;

        public int ReportPageFrom => Report_FromPage;

        public int ReportPageTo => Report_ToPage;

        public int ReportPageCurrent => Report_CurrentPage;

        public int ReportWidth => Report_Width;

        public int ReportHeight => Report_Height;

        public int ReportHeightFooter
        {
            get
            {
                return Height_Footer;
            }
            set
            {
                Height_Footer = value;
            }
        }

        public int ReportHeightHeader
        {
            get
            {
                return Height_Header;
            }
            set
            {
                Height_Header = value;
            }
        }

        public int ReportHeightSection => Height_Section;

        public int ReportCurrentY
        {
            get
            {
                return _CurrentY;
            }
            set
            {
                _CurrentY = value;
            }
        }

        public int ReportCurrentX
        {
            get
            {
                return _CurrentX;
            }
            set
            {
                _CurrentX = value;
            }
        }

        public int ReportHeightDefaultLine => (int)(ReportTextSize("1", ReportFont).Height + (float)Report_Padding.Top + (float)Report_Padding.Bottom);

        public bool ReportChkPage
        {
            get
            {
                if (ReportPageFrom <= ReportPageCurrent && ReportPageCurrent <= ReportPageTo)
                {
                    return true;
                }
                return true;
            }
        }

        public Report(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public Report(Form parentForm, Margins margin = null, bool bLandscape = false, string pagePrnFName = "ReportPage_Print")
        {
            InitializeComponent();
            ParentForm = parentForm;
            PagePrnFName = pagePrnFName;
            try
            {
                _printDocument.BeginPrint -= _printDocument_BeginPrint;
                _printDocument.EndPrint -= _printDocument_EndPrint;
                _printDocument.PrintPage -= _printDocument_PrintPage;
            }
            catch
            {
            }
            _printDocument.BeginPrint += _printDocument_BeginPrint;
            _printDocument.EndPrint += _printDocument_EndPrint;
            _printDocument.PrintPage += _printDocument_PrintPage;
            if (margin == null)
            {
                margin = new Margins(100, 100, 100, 100);
            }
            _printDocument.DefaultPageSettings.Landscape = bLandscape;
            _printDocument.DefaultPageSettings.Margins.Left = (int)((double)margin.Left / 2.54);
            _printDocument.DefaultPageSettings.Margins.Right = (int)((double)margin.Right / 2.54);
            _printDocument.DefaultPageSettings.Margins.Top = (int)((double)margin.Top / 2.54);
            _printDocument.DefaultPageSettings.Margins.Bottom = (int)((double)margin.Bottom / 2.54);
            printDialog.AllowSomePages = true;
            printDialog.Document = _printDocument;
            printDialog.PrinterSettings.FromPage = 0;
            printDialog.PrinterSettings.ToPage = 9999;
            ultraPrintPreviewDialog.PreviewSettings.Zoom = 1.5;
            ultraPrintPreviewDialog.Document = _printDocument;
            ultraPrintPreviewDialog.Text = "Print Preview";
            pageSetupDialog.AllowOrientation = false;
            pageSetupDialog.Document = _printDocument;
            Report_Width = _printDocument.DefaultPageSettings.Bounds.Width - (_printDocument.DefaultPageSettings.Margins.Left + _printDocument.DefaultPageSettings.Margins.Right);
            Report_Height = _printDocument.DefaultPageSettings.Bounds.Height - (_printDocument.DefaultPageSettings.Margins.Top + _printDocument.DefaultPageSettings.Margins.Bottom);
        }

        private void _printDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            if (!_printDocument.PrinterSettings.IsValid)
            {
                e.Cancel = true;
                return;
            }
            Report_CurrentPage = 0;
            onReportBegin(e);
        }

        public virtual void onReportBegin(PrintEventArgs e)
        {
        }

        private void _printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Report_Width = e.MarginBounds.Width;
            Report_Height = e.MarginBounds.Height;
            Height_Section = Report_Height - Height_Header - Height_Footer;
            Report_Graphics = e.Graphics;
            Report_Graphics.ResetTransform();
            Report_Graphics.TranslateTransform(e.MarginBounds.X, e.MarginBounds.Y);
            Report_CurrentPage++;
            _CurrentX = 0;
            _CurrentY = 0;
            onReportPage(e);
        }

        public virtual void onReportPage(PrintPageEventArgs e)
        {
            if (ParentControl != null)
            {
                MethodInfo method = ParentControl.GetType().GetMethod(PagePrnFName);
                method.Invoke(ParentControl, new object[1]
                {
                    e
                });
            }
            else
            {
                MethodInfo method2 = ParentForm.GetType().GetMethod(PagePrnFName);
                method2.Invoke(ParentForm, new object[1]
                {
                    e
                });
            }
        }

        private void _printDocument_EndPrint(object sender, PrintEventArgs e)
        {
            Report_CurrentPage = 0;
            Report_Graphics.Dispose();
            onReportEnd(e);
        }

        public virtual void onReportEnd(PrintEventArgs e)
        {
        }

        public void BeginReport(bool bPreview = true)
        {
            if (bPreview)
            {
                ultraPrintPreviewDialog.ShowDialog();
            }
            else if (printDialog.ShowDialog() == DialogResult.OK)
            {
                Report_FromPage = printDialog.PrinterSettings.FromPage;
                Report_ToPage = printDialog.PrinterSettings.ToPage;
                _printDocument.Print();
            }
        }

        public void ReportDrawLine(Point pointLT, Point pointRB, Pen pen = null)
        {
            ReportGraphics.DrawLine((pen == null) ? Report_Pen : pen, pointLT, pointRB);
        }

        public void ReportDrawLine(Point point, Size size, Pen pen = null)
        {
            ReportGraphics.DrawLine((pen == null) ? Report_Pen : pen, point, new Point(point.X + size.Width, point.Y + size.Height));
        }

        public void ReportDrawRectangle(Point point, Size size, Pen pen = null, Brush brush = null)
        {
            if (brush != null)
            {
                ReportGraphics.FillRectangle(brush, point.X, point.Y, size.Width, size.Height);
            }
            ReportGraphics.DrawRectangle((pen == null) ? Report_Pen : pen, point.X, point.Y, size.Width, size.Height);
        }

        public void ReportDrawText(string text, Point Point, int width, StringAlignment alignment = StringAlignment.Near, bool bAutoSize = false, bool bPadding = false, Font font = null, Brush brush = null, Brush bgbrush = null, Pen pen = null)
        {
            int num = (int)ReportTextSize("1", (font == null) ? ReportFont : font, bPadding).Height + (bPadding ? (Report_Padding.Top + Report_Padding.Bottom) : 0);
            Rectangle rectangle = new Rectangle(ReportCurrentX, ReportCurrentY, width - 1, num - 1);
            ReportDrawText(text, rectangle, alignment, bAutoSize, bPadding, font, brush, bgbrush, pen);
        }

        public void ReportDrawText(string text, int width, StringAlignment alignment = StringAlignment.Near, bool bAutoSize = false, bool bPadding = false, Font font = null, Brush brush = null, Brush bgbrush = null, Pen pen = null)
        {
            int num = (int)ReportTextSize("1", (font == null) ? ReportFont : font, bPadding).Height + (bPadding ? (Report_Padding.Top + Report_Padding.Bottom) : 0);
            Rectangle rectangle = new Rectangle(ReportCurrentX, ReportCurrentY, width - 1, num - 1);
            ReportDrawText(text, rectangle, alignment, bAutoSize, bPadding, font, brush, bgbrush, pen);
        }

        public void ReportDrawText(string text, Rectangle rectangle, StringAlignment alignment = StringAlignment.Near, bool bAutoSize = false, bool bPadding = false, Font font = null, Brush brush = null, Brush bgbrush = null, Pen pen = null)
        {
            if (bgbrush != null)
            {
                ReportGraphics.FillRectangle(bgbrush, rectangle);
            }
            if (pen != null)
            {
                ReportGraphics.DrawRectangle(pen, rectangle);
            }
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = alignment;
            stringFormat.LineAlignment = StringAlignment.Center;
            Font font2 = (font == null) ? Report_Font : font;
            SizeF sizeF = ReportTextSize(text, font2, bPadding);
            if (bAutoSize)
            {
                while (sizeF.Width > (float)rectangle.Width && font2.Size > 5f)
                {
                    font2 = new Font(font2.FontFamily, font2.Size - 1f, font2.Style);
                    sizeF = ReportTextSize(text, font2, bPadding);
                }
            }
            rectangle.Offset(Report_Padding.Left, 0);
            ReportGraphics.DrawString(text, font2, (brush == null) ? Report_Brush : brush, rectangle, stringFormat);
            ReportCurrentX = rectangle.X + rectangle.Width - 1;
        }

        public void ReportDrawImage(string fileName, Rectangle rectangle)
        {
            Image image = Image.FromFile(fileName);
            ReportGraphics.DrawImage(image, rectangle);
        }

        public void ReportDrawImage(Image image, Rectangle rectangle)
        {
            ReportGraphics.DrawImage(image, rectangle);
        }

        public SizeF ReportTextSize(string text, Font font, bool bAddpadding = false)
        {
            if (!bAddpadding)
            {
                return ReportGraphics.MeasureString(text, font);
            }
            SizeF result = ReportGraphics.MeasureString(text, font);
            result.Width += Report_Padding.Left + Report_Padding.Right;
            return result;
        }

        public bool ReportLineFeed(int height = 0)
        {
            int num = (height == 0) ? ReportHeightDefaultLine : height;
            ReportCurrentY += num;
            ReportCurrentX = 0;
            if (ReportCurrentY + num > ReportHeightSection)
            {
                return false;
            }
            return true;
        }

        public int ReportAutoColSize(ref int[] aColWidth)
        {
            int num = 0;
            int num2 = 0;
            int[] array = aColWidth;
            foreach (int num3 in array)
            {
                if (num3 == 0)
                {
                    break;
                }
                num += num3;
                num2++;
            }
            int num4 = 0;
            for (int j = 0; j < num2 - 1; j++)
            {
                int num5 = ReportWidth * aColWidth[j] / num;
                aColWidth[j] = num5;
                num4 += num5;
            }
            aColWidth[num2 - 1] = ReportWidth - num4;
            return num2;
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
            components = new Container();
        }
    }
}

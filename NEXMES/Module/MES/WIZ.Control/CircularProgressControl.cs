using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Timers;
using System.Windows.Forms;

namespace WIZ.Control
{
    public class CircularProgressControl : UserControl
    {
        public enum Direction
        {
            CLOCKWISE,
            ANTICLOCKWISE
        }

        public enum ControlType
        {
            PROGRESS,
            PERCENT
        }

        public enum MessagePositionType
        {
            Top,
            Bottom,
            Left,
            Right
        }

        private struct Spoke
        {
            public PointF StartPoint;

            public PointF EndPoint;

            public Spoke(PointF pt1, PointF pt2)
            {
                StartPoint = pt1;
                EndPoint = pt2;
            }
        }

        private const int DEFAULT_INTERVAL = 60;

        private readonly Color DEFAULT_TICK_COLOR = Color.FromArgb(58, 58, 58);

        private const int DEFAULT_TICK_WIDTH = 2;

        private const int MINIMUM_INNER_RADIUS = 4;

        private const int MINIMUM_OUTER_RADIUS = 8;

        private Size MINIMUM_CONTROL_SIZE = new Size(28, 28);

        private const int MINIMUpen_WIDTH = 2;

        private const float INNER_RADIUS_FACTOR = 0.4f;

        private const float OUTER_RADIUS_FACTOR = 0.45f;

        private const int DEFAULT_SPOKES_COUNT = 12;

        private int interval;

        private int spokeThick = 0;

        private double timeThick = 0.0;

        private float innerRadiousFactor = 0f;

        private float outerRadiousFactor = 0.5f;

        private Pen pen = null;

        private PointF centerPt = default(PointF);

        private int innerRadius = 0;

        private int outerRadius = 0;

        private int spokeCount = 12;

        private int alphaChange = 0;

        private int alphaLowerLimit = 0;

        private float startAngle = 0f;

        private float angleIncrement = 0f;

        private Direction rotation;

        private System.Timers.Timer timer = null;

        private List<Spoke> spokes = null;

        private bool showTime = true;

        private bool isshowMessage = true;

        private double percent = 0.0;

        private ControlType controlType = ControlType.PROGRESS;

        private MessagePositionType messagePositionType = MessagePositionType.Bottom;

        private string centerMessage = string.Empty;

        private string message = string.Empty;

        private RectangleF centerMessageRect;

        private RectangleF messageRect;

        private IContainer components = null;

        public MessagePositionType MessagePosition
        {
            get
            {
                return messagePositionType;
            }
            set
            {
                messagePositionType = value;
                CalculatePosition();
                Invalidate();
            }
        }

        public int Interval
        {
            get
            {
                return interval;
            }
            set
            {
                if (value > 0)
                {
                    interval = value;
                }
                else
                {
                    interval = 60;
                }
            }
        }

        public Color TickColor
        {
            get;
            set;
        }

        public Direction Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                rotation = value;
                CalculatePosition();
            }
        }

        public float StartAngle
        {
            get
            {
                return startAngle;
            }
            set
            {
                startAngle = value;
            }
        }

        public int SpokesCount
        {
            get
            {
                return spokeCount;
            }
            set
            {
                spokeCount = value;
                CalculatePosition();
                Invalidate();
            }
        }

        public int SpokeThick
        {
            get
            {
                return spokeThick;
            }
            set
            {
                spokeThick = value;
                CalculatePosition();
                Invalidate();
            }
        }

        public string CenterMessage
        {
            get
            {
                return centerMessage;
            }
            set
            {
                centerMessage = value;
                Invalidate();
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                Invalidate();
            }
        }

        public float InnerRadiousFactor
        {
            get
            {
                return innerRadiousFactor * 2f;
            }
            set
            {
                innerRadiousFactor = value / 2f;
                CalculatePosition();
                Invalidate();
            }
        }

        public float OuterRadiousFactor
        {
            get
            {
                return outerRadiousFactor * 2f;
            }
            set
            {
                outerRadiousFactor = value / 2f;
                CalculatePosition();
                Invalidate();
            }
        }

        public bool ShowTime
        {
            get
            {
                return showTime;
            }
            set
            {
                showTime = value;
            }
        }

        public bool IsShowMessage
        {
            get
            {
                return isshowMessage;
            }
            set
            {
                isshowMessage = value;
                CalculatePosition();
                Invalidate();
            }
        }

        public double Percent
        {
            get
            {
                return percent;
            }
            set
            {
                percent = value;
                SetText(percent.ToString("##0") + "%");
                Invalidate();
            }
        }

        public ControlType Type
        {
            get
            {
                return controlType;
            }
            set
            {
                controlType = value;
                Invalidate();
            }
        }

        public CircularProgressControl()
        {
            DoubleBuffered = true;
            InitializeComponent();
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            TickColor = DEFAULT_TICK_COLOR;
            MinimumSize = MINIMUM_CONTROL_SIZE;
            Interval = 60;
            StartAngle = 270f;
            spokeCount = 12;
            alphaLowerLimit = 15;
            pen = new Pen(TickColor, 2f);
            pen.EndCap = LineCap.Round;
            pen.StartCap = LineCap.Round;
            Rotation = Direction.CLOCKWISE;
            CalculatePosition();
            timer = new System.Timers.Timer(Interval);
            timer.Elapsed += OnTimerElapsed;
        }

        private void CalculatePosition()
        {
            int num = CalculateMessagePoint();
            spokes = new List<Spoke>();
            angleIncrement = 360f / (float)spokeCount;
            alphaChange = (255 - alphaLowerLimit) / spokeCount;
            if (spokeThick == 0)
            {
                pen.Width = num / 15;
                if (pen.Width < 2f)
                {
                    pen.Width = 2f;
                }
            }
            else
            {
                pen.Width = spokeThick;
            }
            innerRadius = (int)((float)num * innerRadiousFactor);
            if (innerRadius < 4)
            {
                innerRadius = 4;
            }
            outerRadius = (int)((float)num * outerRadiousFactor);
            if (outerRadius < 8)
            {
                outerRadius = 8;
            }
            float num2 = 0f;
            for (int i = 0; i < spokeCount; i++)
            {
                PointF pt = new PointF((float)innerRadius * (float)Math.Cos(ConvertDegreesToRadians(num2)), (float)innerRadius * (float)Math.Sin(ConvertDegreesToRadians(num2)));
                PointF pt2 = new PointF((float)outerRadius * (float)Math.Cos(ConvertDegreesToRadians(num2)), (float)outerRadius * (float)Math.Sin(ConvertDegreesToRadians(num2)));
                Spoke item = new Spoke(pt, pt2);
                spokes.Add(item);
                if (Rotation == Direction.CLOCKWISE)
                {
                    num2 -= angleIncrement;
                }
                else if (Rotation == Direction.ANTICLOCKWISE)
                {
                    num2 += angleIncrement;
                }
            }
        }

        private int CalculateMessagePoint()
        {
            Graphics graphics = CreateGraphics();
            int num = 0;
            if (!isshowMessage)
            {
                centerMessageRect = new RectangleF(0f, (float)(base.Height / 2) - Font.SizeInPoints * graphics.DpiY / 72f * 1.1f / 2f, base.Width, Font.SizeInPoints * graphics.DpiY / 72f * 1.1f);
                num = ((base.Width < base.Height) ? base.Width : base.Height);
                centerPt = new PointF(base.Width / 2, base.Height / 2);
                return num;
            }
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            switch (messagePositionType)
            {
                case MessagePositionType.Top:
                    num = (((float)base.Width < (float)base.Height - messageRect.Height) ? base.Width : Convert.ToInt16((float)base.Height - messageRect.Height));
                    num3 = base.Width;
                    num2 = Convert.ToInt16(Font.SizeInPoints * graphics.DpiY / 72f * 1.2f);
                    num7 = base.Width;
                    num4 = Convert.ToInt16(Font.SizeInPoints * graphics.DpiY / 72f * 2f);
                    num5 = 0;
                    num6 = (base.Height + num4 - num2) / 2;
                    num8 = 0;
                    num9 = 0;
                    centerPt = new PointF(base.Width / 2, (base.Height + num4) / 2);
                    break;
                case MessagePositionType.Bottom:
                    num = (((float)base.Width < (float)base.Height - messageRect.Height) ? base.Width : Convert.ToInt16((float)base.Height - messageRect.Height));
                    num3 = base.Width;
                    num2 = Convert.ToInt16(Font.SizeInPoints * graphics.DpiY / 72f * 1.2f);
                    num7 = base.Width;
                    num4 = Convert.ToInt16(Font.SizeInPoints * graphics.DpiY / 72f * 2f);
                    num5 = 0;
                    num6 = (base.Height - num4 - num2) / 2;
                    num8 = 0;
                    num9 = base.Height - num4;
                    centerPt = new PointF(base.Width / 2, (base.Height - num4) / 2);
                    break;
                case MessagePositionType.Left:
                    num = ((base.Width < base.Height) ? base.Width : base.Height);
                    num2 = Convert.ToInt16(Font.SizeInPoints * graphics.DpiY / 72f * 1.2f);
                    num3 = num;
                    num7 = ((base.Width - num >= 0) ? (base.Width - num) : 0);
                    num4 = Convert.ToInt16(Font.SizeInPoints * graphics.DpiY / 72f * 1.2f);
                    num5 = num7;
                    num6 = (base.Height - num2) / 2;
                    num8 = 0;
                    num9 = (base.Height - num4) / 2;
                    centerPt = new PointF(num7 + num / 2, base.Height / 2);
                    break;
                case MessagePositionType.Right:
                    num = ((base.Width < base.Height) ? base.Width : base.Height);
                    num2 = Convert.ToInt16(Font.SizeInPoints * graphics.DpiY / 72f * 1.2f);
                    num3 = num;
                    num7 = ((base.Width - num >= 0) ? (base.Width - num) : 0);
                    num4 = Convert.ToInt16(Font.SizeInPoints * graphics.DpiY / 72f * 1.2f);
                    num5 = 0;
                    num6 = (base.Height - num2) / 2;
                    num8 = num;
                    num9 = (base.Height - num4) / 2;
                    centerPt = new PointF(num / 2, base.Height / 2);
                    break;
            }
            messageRect = new RectangleF(num8, num9, num7, num4);
            centerMessageRect = new RectangleF(num5, num6, num3, num2);
            return num;
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            CalculatePosition();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (Rotation == Direction.CLOCKWISE)
            {
                startAngle += angleIncrement;
                if (startAngle >= 360f)
                {
                    startAngle = 0f;
                }
            }
            else if (Rotation == Direction.ANTICLOCKWISE)
            {
                startAngle -= angleIncrement;
                if (startAngle <= -360f)
                {
                    startAngle = 0f;
                }
            }
            if (showTime)
            {
                timeThick += (double)Interval / 1000.0;
                SetText(timeThick.ToString("#,##0.0"));
            }
            else
            {
                SetText(centerMessage + "\r\n( " + timeThick.ToString("#,##0.0") + " )");
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            StringFormat stringFormat = new StringFormat();
            StringFormat stringFormat2 = new StringFormat(StringFormatFlags.MeasureTrailingSpaces);
            SolidBrush brush = new SolidBrush(ForeColor);
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat2.LineAlignment = StringAlignment.Center;
            switch (MessagePosition)
            {
                case MessagePositionType.Top:
                case MessagePositionType.Bottom:
                    stringFormat2.Alignment = StringAlignment.Center;
                    break;
                case MessagePositionType.Right:
                    stringFormat2.Alignment = StringAlignment.Near;
                    break;
                case MessagePositionType.Left:
                    stringFormat2.Alignment = StringAlignment.Far;
                    break;
            }
            e.Graphics.DrawString(CenterMessage, Font, brush, centerMessageRect, stringFormat);
            if (isshowMessage)
            {
                e.Graphics.DrawString(message, Font, brush, messageRect, stringFormat2);
            }
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TranslateTransform(centerPt.X, centerPt.Y, MatrixOrder.Prepend);
            e.Graphics.RotateTransform(startAngle, MatrixOrder.Prepend);
            int num = 255;
            for (int i = 0; i < spokeCount; i++)
            {
                pen.Color = Color.FromArgb(num, TickColor);
                e.Graphics.DrawLine(pen, spokes[i].StartPoint, spokes[i].EndPoint);
                if (controlType == ControlType.PROGRESS)
                {
                    num -= alphaChange;
                    if (num < alphaLowerLimit)
                    {
                        num = 255 - alphaChange;
                    }
                }
                else
                {
                    num = (((double)i / (double)spokeCount * 100.0 < percent) ? 255 : 0);
                }
            }
            e.Graphics.RotateTransform(0f - startAngle, MatrixOrder.Append);
            e.Graphics.TranslateTransform(0f - centerPt.X, 0f - centerPt.Y, MatrixOrder.Append);
        }

        private double ConvertDegreesToRadians(float degrees)
        {
            return Math.PI / 180.0 * (double)degrees;
        }

        public void SetText(string text)
        {
            CenterMessage = text;
        }

        public void SetMessage(string text)
        {
            Message = text;
        }

        public void Start()
        {
            if (controlType != ControlType.PERCENT && timer != null)
            {
                timeThick = 0.0;
                timer.Interval = Interval;
                timer.Enabled = true;
            }
        }

        public void Stop()
        {
            if (timer != null)
            {
                timer.Enabled = false;
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
            SuspendLayout();
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            DoubleBuffered = true;
            base.Name = "CircularProgressControl";
            ResumeLayout(false);
        }
    }
}

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
    class RegionOnPaint : Control
    {
        static Rectangle Rectangle { get; set; }
        private float roundingPercent = 100;
        public float Rounding
        {
            get => roundingPercent;
            set
            {
                if (value  >=0 && value <= 100)
                {
                    roundingPercent = value;
                    Refresh();
                }
            }
        }
        public RegionOnPaint()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(100, 50);
            Location = new Point(100, 50);
            BackColor = Color.Transparent;
            Font = new Font("Arial", 14f, FontStyle.Regular);
            Rectangle = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
        }

        private GraphicsPath RoundRectangle(float roundSize)
        { 
            GraphicsPath graphics = new GraphicsPath();
            graphics.AddArc(Rectangle.X, Rectangle.Y, roundSize, roundSize, 180, 90);
            graphics.AddArc(Rectangle.X + Rectangle.Width - roundSize, Rectangle.Y, roundSize, roundSize, 270, 90);
            graphics.AddArc(Rectangle.X + Rectangle.Width - roundSize, Rectangle.Y + Rectangle.Height - roundSize, roundSize, roundSize, 0, 90);
            graphics.AddArc(Rectangle.X, Rectangle.Y + Rectangle.Height - roundSize, roundSize, roundSize, 90, 90);
            return graphics;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            GraphicsPath graphicsPath = RoundRectangle((float)Rectangle.Height / 100 * roundingPercent);
            graphics.SetClip(graphicsPath);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillPath(new SolidBrush(Color.Red), graphicsPath);
            graphics.DrawPath(new Pen(Color.Green), graphicsPath);
            graphics.DrawString("Sosi", DefaultFont, new SolidBrush(Color.Wheat), 10, 5);
        }
    }
}

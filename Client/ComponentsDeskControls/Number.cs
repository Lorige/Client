using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Client.ComponentsDeskControls
{
    class Number : Control
    {
        private Rectangle Rectangle { get; set; }
        public Control GetNumber { get; private set; }

        public Number()
        {
            Size = new Size(60, 30);
            Location = new Point(0, 0);
            BackColor = Color.Red;
            SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            DoubleBuffered = true;
            Rectangle = new Rectangle(Location.X, Location.Y, Size.Width, Size.Height - 1);
            Text = "255";
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            e.Graphics.Clear(Parent.BackColor);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            GraphicsPath graphicsPath = GraphicsPath(new GraphicsPath());
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            graphics.FillPath(new SolidBrush(Color.AliceBlue), graphicsPath);
        }

        private GraphicsPath GraphicsPath(GraphicsPath graphics)
        {
            graphics.AddLine(0, 0, 0, Rectangle.Height);
            graphics.AddLine(0, Rectangle.Height, Rectangle.Width, Rectangle.Height);
            graphics.AddLine(Rectangle.Width, Rectangle.Height, (int)((float)Rectangle.Width / 1.6f), 0);
            graphics.AddLine(Rectangle.Width / 2, 0, 0, 0);
            return graphics;
        }
    }
}

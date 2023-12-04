using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    public partial class TitleForm : Form
    {
        public enum Preset
        {
            Manager,
            Designer,
            Print
        }
        #region Свойства

        public static Form GetTitleForm { get; private set; }
        public static Rectangle startRechtagle { get; private set; }
        public static Preset PresetDB { get; private set; }

        #endregion Свойства


        public TitleForm(Preset preset)
        {
            InitializeComponent();
            GetTitleForm = this;
            PresetDB = preset;
            Controls.Add(new DataTableViewControl());
        }

        private void TitleForm_Load(object sender, EventArgs e)
        {
            startRechtagle = new Rectangle(Location.X, Location.Y, ClientRectangle.Width, ClientRectangle.Height);
        }

        private void TitleForm_Resize(object sender, EventArgs e)
        {
            resizeControl(DataTableViewControl.StartTableRechtagle, Controls[0]);
        }
        private void resizeControl(Rectangle rectangle, Control control)
        {
            float xRatio = (float)(ClientRectangle.Width) / (float)(startRechtagle.Width);
            float yRatio = (float)(ClientRectangle.Height) / (float)(startRechtagle.Height);

            int newX = (int)(rectangle.X * xRatio);
            int newY = (int)(rectangle.Y * yRatio);

            int newWidth = (int)(rectangle.Width * xRatio);
            int newHeigth = (int)(rectangle.Height * yRatio);

            control.Location = new Point(newX, newY);
            control.Size = new Size(newWidth, newHeigth);
        }
    }
}

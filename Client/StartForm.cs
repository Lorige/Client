using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;

namespace Client
{
    public partial class LoadForm : Form

    {
        public LoadForm()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            this.AllowTransparency = true;
            RegionOnPaint regionOnPaint = new RegionOnPaint();
            Controls.Add(regionOnPaint);
            InitializeComponent();
            BackColor = Color.FromArgb(0, 255, 255, 255);
        }
        public Point GetClientSize()
        {
            return new Point(ClientSize.Width/2, ClientSize.Height / 2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void BtnManager_Click(object sender, EventArgs e)
        {
            TitleForm titleForm = new TitleForm(TitleForm.Preset.Manager);
            titleForm.Show();
        }
        private void ControlAdd(Control nameControl, Point location, Size size, string textControl)
        {
            nameControl.Location = location;
            nameControl.Size = size;
            nameControl.Text = textControl;
            Controls.Add(nameControl);
        }

        private void FormShowDialog()
        {
        }
    }

}
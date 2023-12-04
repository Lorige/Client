using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    partial class FullDescriptionRow 
    {
        #region Properity
        private DataGridViewCellMouseEventArgs EventMouseArgs { get; set; }
        public GroupBox InfoRowBox { get; private set; }
        private Control[] InfoRowBoxControls { get; set; }
        public Control[] GetControls;

        #endregion Properity
        #region Construct
        public FullDescriptionRow(DataGridViewCellMouseEventArgs e)
        {
            InfoRowBox = new GroupBox();
            EventMouseArgs = e;
            CreateTextBox();
            foreach (var a in GetControls)
                InfoRowBox.Controls.Add(a);
            Initialize();
        }
        #endregion Construct
        public void Initialize()
        {
            InfoRowBox.Size = new Size(DataTableViewControl.DataTableView.ClientRectangle.Width / 100 * 85, DataTableViewControl.DataTableView.Height / 100 * 85);
            InfoRowBox.Location = new Point((DataTableViewControl.DataTableView.ClientRectangle.Height - InfoRowBox.ClientRectangle.Height) / 2, (DataTableViewControl.DataTableView.ClientRectangle.Width - InfoRowBox.ClientRectangle.Width) / 2);
            InfoRowBox.BackColor = Color.White;
            var btn = new Button();
            btn.Size = new Size(200, 50);
            btn.Text = "Add";
            btn.Location = new Point(InfoRowBox.Location.X + InfoRowBox.Width - btn.Width, InfoRowBox.Location.Y  + InfoRowBox.Height);
            btn.MouseClick += Btn_MouseClick;
            DataTableViewControl.DataTableView.Controls.Add(btn);
            DataTableViewControl.DataTableView.Controls.Add(InfoRowBox);
            var btnClose = new Button();
            btnClose.Size = new Size(20, 20);
            btnClose.Location = new Point(0, 0);
            btnClose.BackColor = Color.Red;
            btnClose.Text = "X";
            btnClose.MouseClick += BtnClose_MouseClick;
            InfoRowBox.Controls.Add(btnClose);
        }

        private void Btn_MouseClick(object sender, MouseEventArgs e)
        {
            var ColumnNamesValues = new ColumnValue[];
            for (int i = 0; i<ColumnNamesValues.Length; i++)
                ColumnNamesValues[i] = new ColumnValue(GetControls[i].Name, GetControls[i].Text);
            var dataBase = new DataBaseCommand(ColumnNamesValues);
            dataBase.DataBaseSQLExpressionConnect(dataBase.SQLExpressionInsert);
        }

        private void BtnClose_MouseClick(object sender, MouseEventArgs e) => InfoRowBox.Dispose();
    }
}

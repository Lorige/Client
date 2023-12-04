using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace Client
{
    partial class FullDescriptionRow
    {
        #region Properity

        #endregion Properity
        
        private void CreateTextBox()
        {
            Control[]  c = new Control[DBColumns.Columns.Length];
            for (int i = 0; i < DBColumns.Columns.Length; i++)
            {
                c[0] = CreateLabel(DBColumns.Columns[0].Name, new Point(50, 20));
                c[1] = CreateLabel(DBColumns.Columns[1].Name, new Point(50, 70));
                c[2] = CreateLabel(DBColumns.Columns[2].Name, new Point(50, 120));
                c[3] = CreateLabel(DBColumns.Columns[3].Name, new Point(50, 190));
            }
            GetControls = c;
        } 

        private TextBox CreateLabel(string nameCol, Point location)
        {
            TextBox label = new TextBox();
            label.Name = nameCol;
            label.Text = DataTableViewControl.DataTableView[nameCol, EventMouseArgs.RowIndex].Value.ToString();
            label.Size = new Size(200, 50);
            label.Location = location;
            return label;
        }
    }
}

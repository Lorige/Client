using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    class DataTableViewControl : DataGridView, IDisposable
    {
        #region Свойства
        public static DataTableViewControl DataTableView;
        public static DataTable DataTable { get; set; }
        public static Rectangle StartTableRechtagle { get; private set; }
        public ColumnTran[] LoadColumns { get; private set; }
        #endregion
        #region Methods
        public DataTableViewControl()
        {
            DataTable = new DataTable();
            DataTableView = this;
            TableInitialize();
        }
        private async void TableInitialize()
        {
            await SelectDBValues.SQLDataBaseSelect(DataTable);
            DataSource = DataTable;
            DoubleBuffered = true;
            Size = new Size(TitleForm.GetTitleForm.ClientRectangle.Width, TitleForm.GetTitleForm.ClientRectangle.Height);
            AllowUserToOrderColumns = false;
            RowHeadersVisible = false;
            TitleForm.GetTitleForm.Controls.Add(this);
            LoadColumns = DBColumns.PresetColumns;
            for (int counter = 0; counter < Columns.Count; counter++)
                Columns[counter].Visible = false;
            foreach (var columnPreset in DBColumns.PresetColumns)
            {
                Columns[columnPreset.Name].Visible = true;
                Columns[columnPreset.Name].HeaderText = columnPreset.NameRUColumn;
                Columns[columnPreset.Name].Width = columnPreset.WidthColumn;
            }
            CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal;
            BackgroundColor = Color.MediumAquamarine;
            ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            AllowUserToResizeRows = false;
            AllowUserToResizeColumns = false;
            Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            AllowUserToDeleteRows = false;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            EditMode = DataGridViewEditMode.EditProgrammatically;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            Resize += new EventHandler(DataTableView_Resize);
            CellMouseDoubleClick += DataTableViewControl_CellMouseDoubleClick;
            StartTableRechtagle = new Rectangle(ClientRectangle.Location, ClientRectangle.Size);
        }
        private void TableSizeConfig()
        {
            float xRatio = (float)DataTableView.ClientRectangle.Width / (float)StartTableRechtagle.Width;
            int countSize = 0;
            for (int i = 0; i < LoadColumns.Length - 1; i++)
            {
                DataTableView.Columns[LoadColumns[i].Name].Width = (int)(LoadColumns[i].WidthColumn * xRatio);
                countSize += DataTableView.Columns[LoadColumns[i].Name].Width;
            }
            DataTableView.Columns[LoadColumns[LoadColumns.Length -1].Name].Width = DataTableView.ClientRectangle.Width - countSize;
        }
        #endregion

        #region Events
        private void DataTableView_Resize(object sender, EventArgs e)
        {
            TableSizeConfig();
        }
        private void DataTableViewControl_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Controls.Add(new FullDescriptionRow(e).InfoRowBox);
        }

        #endregion
    }
}

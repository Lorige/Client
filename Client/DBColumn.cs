using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    class DBColumns
    {
        #region Properity
        private static string[] NameENColumns =
        {
            "PrimaryKey",
            "Number",
            "Name",
            "PhoneNumber",
            "Description",
            "ResponsibleManager",
            "Messenger",
            "OGroup",
            "PhotoPath",
            "Prepayment",
            "Payment",
            "Cashless",
            "DateOfAccept",
            "DateOfDelivery",
            "DateOfEnd",
            "FilePath",
            "Status"
        };
        private static string[] NameRUColumns =
        {
            "Ключ",
            "№",
            "Имя",
            "Номер телефона" ,
            "Описание" ,
            "Менеджер" ,
            "Мессенджер",
            "Группа" ,
            "Фото",
            "Предоплата" ,
            "Оплата" ,
            "Безнал" ,
            "Дата принятия" ,
            "Дата отправки" ,
            "Дата отдачи" ,
            "Файл",
            "Статус"
        };
        private static int[] ManagerWidth =
{
            5,
            40,
            10,
            10,
            5,
            5,
            5,
            10,
            10
        };
        private static int[] DesignerWidth =
{
            10,
            40,
            10,
            10,
            5,
            10,
            5,
            10
        };
        private static int[] PrintWidth =
{
            10,
            40,
            10,
            10,
            5,
            10,
            20
        };
        #endregion Properity
        #region Construct
        public static ColumnTran[] Columns
        {
            get
            {
                return DBColumnsFill();
            }
        }
        public static ColumnTran[] PresetColumns
        {
            get
            {
                return SelectColumnsPreset();
            }
        }
        #endregion Construct
         #region Methods
        private static ColumnTran[] DBColumnsFill()
        {
            var columns = new ColumnTran[NameENColumns.Length];
            for (int i = 0; i < NameENColumns.Length; i++)
            {
                columns[i] = new ColumnTran(NameRUColumns[i], NameENColumns[i]);
            }
            return columns;
        }
        private static ColumnTran[] DBColumnsFill(int[] width, int[] indexColumns)
        {
            var columns = new ColumnTran[indexColumns.Length];
            for (int i = 0; i < indexColumns.Length; i++)
                columns[i] = new ColumnTran(NameRUColumns[indexColumns[i]], NameENColumns[indexColumns[i]], (int)((float)DataTableViewControl.DataTableView.Width / 100 * width[i]));
            return columns;
        }

        private static ColumnTran[] SelectColumnsPreset()
        {
            switch (TitleForm.PresetDB)
            {
                case TitleForm.Preset.Manager:
                    return DBColumnsFill(ManagerWidth, new int[] { 1, 2, 3, 5, 7, 9, 11, 13, 16 });
                case TitleForm.Preset.Designer:
                    return DBColumnsFill(DesignerWidth, new int[] { 1, 2, 6, 7, 8, 13, 15, 16 });
                case TitleForm.Preset.Print:
                    return DBColumnsFill(PrintWidth, new int[] { 1, 2, 7, 8, 13, 15, 16 });
            }
            return null;
        }
        #endregion Methods
    }
}
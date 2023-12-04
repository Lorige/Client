using System;

namespace Client
{
	public class Column
	{
		public string Name;
		public Column(string name)
		{
			Name = name;
		}
	}
    class ColumnTran : Column
    {
        #region
        public string NameRUColumn { get; private set; }
        public int WidthColumn { get; private set; }
        #endregion
        public ColumnTran(string nameRU, string name) : base (name) 
        {
            NameRUColumn = nameRU;
        }
        public ColumnTran(string nameRU, string name, int width) : this(nameRU, name)
        {
            WidthColumn = width;
        }
    }
    class ColumnValue : Column
    {
        public object Value;
        public ColumnValue(string name, object value) : base (name)
        {
            Value = value;
        }
    }
}

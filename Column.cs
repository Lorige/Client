using System;

namespace Client
{
	public class Column
	{
		private string Name;
		private object Volume;
		public Column(string name, object volume)
		{
			Name = name;
			Volume = volume;
		}
	}
}

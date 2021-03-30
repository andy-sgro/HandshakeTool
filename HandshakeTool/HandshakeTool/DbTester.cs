using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandshakeTool
{
	public class DbTester
	{
		public static void Test()
		{
			DB.Init();
			string[] columns = new string[] { "folder" };
			string[] values = new string[] { "./fjiejij/" };
			DB.Insert(DB.Table.ImageFolder, columns, values);

			columns = new string[] { "label" };
			values = new string[] { "car" };
			DB.Insert(DB.Table.Label, columns, values);

			columns = new string[] { "filename", "imageFolder", "label", "xmin", "xmax", "ymin", "ymax" };
			values = new string[] { "photo1", "0", "0", "70", "68", "32", "76" };
			DB.Insert(DB.Table.Box, columns, values);

			columns = new string[] { "filename" };
			values = new string[] { "photo2" };
			DB.Remove(DB.Table.Box, columns, values);

		}
	}
}

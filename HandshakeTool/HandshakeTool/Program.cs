using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandshakeTool
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			if ((args != null) && (args.Length > 0))
			{
				string filename = args[0]
					.Remove(args[0].LastIndexOf('.'))
					.Remove(0, args[0].LastIndexOf('\\'));
				Global.ProjectFolder = args[0].Remove(args[0].LastIndexOf('\\')) + filename + '\\';
			}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new HandshakeTool());
		}
	}
}

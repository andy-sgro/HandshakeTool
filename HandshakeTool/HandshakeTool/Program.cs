using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HandshakeTool
{
	static class Program
	{
		public static HandshakeTool app = null;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			app = new HandshakeTool();

			bool anoterInstanceIsRunning = System.Diagnostics.Process.GetProcessesByName(Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1;
			if (anoterInstanceIsRunning)
			{
				MessageBox.Show("The Handshake Tool is already running.");
			}
			else
			{
				if ((args != null) && (args.Length > 0))
				{
					string filename = args[0]
						.Remove(args[0].LastIndexOf('.'))
						.Remove(0, args[0].LastIndexOf('\\'));
					Files.ProjectFolder = new DirectoryInfo(args[0].Remove(args[0].LastIndexOf('\\')) + filename + '\\');
					app.LoadMainPage();
				}

				Application.Run(app);
			}
		}
	}
}

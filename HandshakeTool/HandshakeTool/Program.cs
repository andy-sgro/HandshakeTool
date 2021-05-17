/*
* FILE			: Program.cs
* PROJECT		: Handshake Engine
* PROGRAMMER	: Polytechnica Team - Andy Sgro, Caleb Bolsonello
* FIRST VERSION : March 12, 2021
* DESCRIPTION	: This has the Main() function. It opens a project
*				  if the user clicked on a project, or the start page
*				  if not.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HandshakeTool
{
	/**
	* NAME	  : Program
	* PURPOSE : 
	*	- This class is the entry point of the Handshake Tool.
	*	- It opens a project if the user clicked on a project,
	*	  or the start page if not.
	*	- This class uses the Files class to open/start a project,
	*	  and uses the HandshakeTool class to open the main page
	*	  when the user opens the project.
	*/
	static class Program
	{
		public static HandshakeTool app = null;

		/**
		* \brief	The main entry point for the application.
		*
		* \details	It opens a project if the user clicked on a project,
		*			or the start page if not.
		*
		* \param	string[] args : The filepath of the project that was opened.
		*
		* \return	void
		*/
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

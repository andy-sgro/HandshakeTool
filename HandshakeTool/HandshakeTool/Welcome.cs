using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HandshakeTool
{
	public partial class Welcome : Form
	{
		public Welcome()
		{
			InitializeComponent();
		}

		private void newProject(object sender, EventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Filter = "Handshake Tool files (*.hst)|*.hst";

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				// assign project folder
				File.Create(dialog.FileName);
				Files.ProjectFolder = new DirectoryInfo(
					dialog.FileName.Remove(dialog.FileName.LastIndexOf('.')));

				// ensure project & images folders exist
				if (!Files.ProjectFolder.Exists)
				{
					Files.ProjectFolder.Create();
				}
				if (!Files.ImageFolder.Exists)
				{
					Files.ImageFolder.Create();
				}
				HandshakeTool mainpage = new HandshakeTool();
				mainpage.Show();
			}
		}

		private void loadProject(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Handshake Tool files (*.hst)|*.hst";

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				Files.ProjectFolder = new DirectoryInfo(
					dialog.FileName.Remove(dialog.FileName.LastIndexOf('.')));
				HandshakeTool mainpage = new HandshakeTool();
				mainpage.Show();
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace HandshakeTool
{
	public static class Files
	{
		public static DirectoryInfo ImageFolder { get; private set; } = null;
		public static DirectoryInfo AnnotationsFolder { get; private set; } = null;

		private static DirectoryInfo projectFolder;
		public static DirectoryInfo ProjectFolder
		{
			get { return projectFolder; }
			set
			{
				char lastChar = value.FullName[value.FullName.Length - 1];
				if ((lastChar != '\\') & (lastChar != '/'))
				{
					projectFolder = new DirectoryInfo(value.FullName + '\\');
					ImageFolder = new DirectoryInfo(ProjectFolder.FullName + "Images\\");
					AnnotationsFolder = new DirectoryInfo(ProjectFolder.FullName + "Annotations\\");

					if (!ImageFolder.Exists)
					{
						ImageFolder.Create();
					}
					if (!AnnotationsFolder.Exists)
					{
						AnnotationsFolder.Create();
					}
				}
				else
				{
					projectFolder = value;
				}
			}
		}


		public static string GetFilename(string filepath)
		{
			return filepath.Remove(filepath.LastIndexOf('.'))
				.Remove(0, filepath.LastIndexOf('\\'));
		}


		public static string ChangeExtension(string filepath, string newExtension)
		{
			return filepath.Remove(filepath.LastIndexOf('.')) + newExtension;
		}


		public static bool NewProject()
		{
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Filter = "Handshake Tool files (*.hst)|*.hst";

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				// assign project folder
				File.Create(dialog.FileName);
				ProjectFolder = new DirectoryInfo(
					dialog.FileName.Remove(dialog.FileName.LastIndexOf('.')));

				// ensure project & images folders exist
				if (!ProjectFolder.Exists)
				{
					ProjectFolder.Create();
				}
				if (!ImageFolder.Exists)
				{
					ImageFolder.Create();
				}
				return true;
			}
			return false;
		}


		public static bool OpenProject()
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Handshake Tool files (*.hst)|*.hst";

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				ProjectFolder = new DirectoryInfo(
					dialog.FileName.Remove(dialog.FileName.LastIndexOf('.')));

				return true;
			}
			return false;
		}
	}
}

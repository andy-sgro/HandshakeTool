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
				// append slash
				char lastChar = value.FullName[value.FullName.Length - 1];
				if ((lastChar != '\\') & (lastChar != '/'))
				{
					projectFolder = new DirectoryInfo(value.FullName + '\\');
				}
				else
				{
					projectFolder = value;
				}

				// set sub folders
				ImageFolder = new DirectoryInfo(ProjectFolder.FullName + "Images\\");
				AnnotationsFolder = new DirectoryInfo(ProjectFolder.FullName + "Annotations\\");

				if (!ImageFolder.Exists)
				{
					ImageFolder.Create();
				}
				else
				{
					// ensure Images folder is capitlized
					DirectoryInfo[] children = ProjectFolder.GetDirectories();
					foreach (DirectoryInfo child in children)
					{
						if (child.Name == "images")
						{
							string fakeFolder = ProjectFolder.FullName + "images\\";
							string superFakeFolder = ProjectFolder.FullName + "anton 123\\";
							Directory.Move(fakeFolder, superFakeFolder);
							Directory.Move(superFakeFolder, ImageFolder.FullName);
							break;
						}
					}
				}
				if (!AnnotationsFolder.Exists)
				{
					AnnotationsFolder.Create();
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


		public static void CopyDirectory(string sourceDirName, string destDirName, bool copySubDirs)
		{
			// Get the subdirectories for the specified directory.
			DirectoryInfo dir = new DirectoryInfo(sourceDirName);

			if (dir.Exists)
			{
				DirectoryInfo[] dirs = dir.GetDirectories();

				// If the destination directory doesn't exist, create it.       
				Directory.CreateDirectory(destDirName);

				// Get the files in the directory and copy them to the new location.
				FileInfo[] files = dir.GetFiles();
				foreach (FileInfo file in files)
				{
					string tempPath = Path.Combine(destDirName, file.Name);
					file.CopyTo(tempPath, false);
				}

				// If copying subdirectories, copy them and their contents to new location.
				if (copySubDirs)
				{
					foreach (DirectoryInfo subdir in dirs)
					{
						string tempPath = Path.Combine(destDirName, subdir.Name);
						CopyDirectory(subdir.FullName, tempPath, copySubDirs);
					}
				}
			}
		}
	}
}

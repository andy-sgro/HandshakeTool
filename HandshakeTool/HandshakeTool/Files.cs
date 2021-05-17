/*
* FILE			: Files.cs
* PROJECT		: Handshake Engine
* PROGRAMMER	: Polytechnica Team - Andy Sgro, Caleb Bolsonello
* FIRST VERSION : March 12, 2021
* DESCRIPTION	: This class stores the filepaths to the project, image, and annotions folders.
*				  It also has generic FileIO functions.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace HandshakeTool
{
	/**
	* NAME	  : Files
	* PURPOSE : 
	*	- This class allows the user to open projects, start new projects, and
	*	  access the project, image, and annotions folders.
	*	- This class also has generic FileIO functions, like CopyDirectory, GetFilename,
	*	  and ChangeExtension.
	*	- This class is used by every other class in this project.
	*	- This class is not dependent on any other class in this project.
	*/
	public static class Files
	{
		public static DirectoryInfo ImageFolder { get; private set; } = null;
		public static DirectoryInfo AnnotationsFolder { get; private set; } = null;


		/**
		* \brief	Gets and sets the project folder
		*
		* \details	When ProjectFolder is set, ImageFolder and AnnotationsFolder are too.
		*
		* \param	N/A
		*
		* \return	Returns the project folder as a DirectoryInfo object.
		*/
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


		/**
		* \brief	Gets the filename of the filepath.
		*
		* \details	If the filepath is 'C:Docs/happyFile.txt',
		*			then the filename is 'happyFile'.
		*
		* \param	string filepath : The filepath to get the filename from.
		*
		* \return	Returns the filename of the filepath as a string.
		*/
		public static string GetFilename(string filepath)
		{
			return filepath.Remove(filepath.LastIndexOf('.'))
				.Remove(0, filepath.LastIndexOf('\\'));
		}


		/**
		* \brief	Changes the extension of a filepath.
		*
		* \param	string filepath     : The filepath to modify.
		* \param	string newExtension : The extension that the filepath will have.
		*
		* \return	Returns a new filepath with the specified extension.
		*/
		public static string ChangeExtension(string filepath, string newExtension)
		{
			return filepath.Remove(filepath.LastIndexOf('.')) + newExtension;
		}


		/**
		* \brief	Allows the user to start a new project.
		*
		* \param	N/A
		*
		* \return	Returns true if the user confirmed that they want to start a new project.
		*			Otherwise false is returned.
		*/
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


		/**
		* \brief	Allows the user to open an existing project.
		*
		* \param	N/A
		*
		* \return	Returns true if the user confirmed that they want to open an existing project.
		*			Otherwise false is returned.
		*/
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


		/**
		* \brief	Copys a directory.
		* 
		* \details	Src: https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories
		*
		* \param	string sourceDirName : The directory to copy.
		* \param	string destDirName	 : The filepath to copy to.
		* \param	bool copySubDirs	 : Set to true if the subfolders should be copied too.
		*
		* \return	void
		*/
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
					file.CopyTo(tempPath, true);
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

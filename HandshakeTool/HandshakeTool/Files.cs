using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HandshakeTool
{
	public static class Files
	{
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
				}
				else
				{
					projectFolder = value;
				}
			}
		}

		private static DirectoryInfo imageFolder = null;
		public static DirectoryInfo ImageFolder
		{
			get
			{
				if (imageFolder == null)
				{
					imageFolder = new DirectoryInfo(ProjectFolder.FullName + "images\\");
				}
				return imageFolder;
			}
		}

		private static DirectoryInfo annotationsFolder = null;
		public static DirectoryInfo AnnotationsFolder
		{
			get
			{
				if (annotationsFolder == null)
				{
					annotationsFolder = new DirectoryInfo(ProjectFolder.FullName + "annotations\\");
				}
				return annotationsFolder;
			}
		}
	}
}

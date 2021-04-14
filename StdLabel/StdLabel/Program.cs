using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StdLabel
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				Console.Write("1 - Count all labels\n"
					+ "2 - Standardize labels\n"
					+ "3 - Replace a label\n"
					+ "4 - Separate files into folders\n"
					+ "5 - Remove unlabeled images\n"
					+ "6 - Reduce bit depth\n>>");
				
				switch(Console.ReadKey().KeyChar)
				{
					case ('1'):
						Console.WriteLine();
						countAllLabels();
						Console.WriteLine();
						break;

					case ('2'):
						Console.WriteLine();
						standardizeLabels();
						Console.WriteLine();
						break;

					case ('3'):
						Console.WriteLine();
						replaceLabel();
						Console.WriteLine();
						break;

					case ('4'):
						Console.WriteLine();
						separateIntoFolders();
						Console.WriteLine();
						break;

					case ('5'):
						Console.WriteLine();
						removeUnlabelledImages();
						Console.WriteLine();
						break;
					
					case ('6'):
						Console.WriteLine();
						fixDepth();
						Console.WriteLine();
						break;
				}
			}
		}


		private static void standardizeLabels()
		{
			Console.Write("Enter the label:\n>>");
			string label = Console.ReadLine();
			Console.Write("Enter the folder:\n>>");
			string[] filepaths = Directory.GetFiles(Console.ReadLine(), "*.xml");
			foreach (string filepath in filepaths)
			{
				string fileContent = File.ReadAllText(filepath);
				int nameIndex = fileContent.IndexOf("<name>");
				if (nameIndex >= 0)
				{
					nameIndex += "<name>".Length;
					int nameTerminator = fileContent.IndexOf("</name>");
					int nameLength = nameTerminator - nameIndex;
					fileContent = fileContent.Remove(nameIndex, nameLength).Insert(nameIndex, label);
					File.WriteAllText(filepath, fileContent);
				}
			}
		}


		private static void countAllLabels()
		{
			Console.Write("Enter the folder:\n>>");
			string[] filepaths = Directory.GetFiles(Console.ReadLine(), "*.xml");
			Dictionary<string, int> labels = new Dictionary<string, int>();
			foreach (string filepath in filepaths)
			{
				string fileContent = File.ReadAllText(filepath);
				int nameIndex = fileContent.IndexOf("<name>");
				if (nameIndex >= 0)
				{
					nameIndex += "<name>".Length;
					int nameTerminator = fileContent.IndexOf("</name>");
					int nameLength = nameTerminator - nameIndex;

					string label = fileContent.Substring(nameIndex, nameLength);
					if (labels.ContainsKey(label))
					{
						++labels[label];
					}
					else
					{
						labels.Add(label, 1);
					}
				}
			}
			foreach (KeyValuePair<string, int> label in labels)
			{
				Console.WriteLine(label.Key + " " + label.Value);
			}
		}


		private static void replaceLabel()
		{
			Console.Write("Enter the label:\n>>");
			string labelToFind = Console.ReadLine();
			Console.Write("Enter the new label:\n>>");
			string newLabel = Console.ReadLine();
			Console.Write("Enter the folder:\n>>");
			string[] filepaths = Directory.GetFiles(Console.ReadLine(), "*.xml");
			foreach (string filepath in filepaths)
			{
				string fileContent = File.ReadAllText(filepath);
				int nameIndex = fileContent.IndexOf("<name>");
				if (nameIndex >= 0)
				{
					nameIndex += "<name>".Length;
					int nameTerminator = fileContent.IndexOf("</name>");
					int nameLength = nameTerminator - nameIndex;

					string actualLabel = fileContent.Substring(nameIndex, nameLength);
					if (actualLabel.Equals(labelToFind))
					{
						fileContent = fileContent.Remove(nameIndex, nameLength).Insert(nameIndex, newLabel);
					}

					File.WriteAllText(filepath, fileContent);
				}
			}
		}


		private static void separateIntoFolders()
		{
			Console.Write("Enter the folder:\n>>");
			string folder = Console.ReadLine();
			string[] xmlFilepaths = Directory.GetFiles(folder, "*.xml");
			foreach (string xmlFilepath in xmlFilepaths)
			{
				string fileContent = File.ReadAllText(xmlFilepath);
				int nameIndex = fileContent.IndexOf("<name>");
				if (nameIndex >= 0)
				{
					nameIndex += "<name>".Length;
					int nameTerminator = fileContent.IndexOf("</name>");
					int nameLength = nameTerminator - nameIndex;
					string label = fileContent.Substring(nameIndex, nameLength);

					string childFolder = folder + '\\' + label + '\\';
					if (!Directory.Exists(childFolder))
					{
						Directory.CreateDirectory(childFolder);
					}
					string filename = getFilename(xmlFilepath);
					File.Copy(xmlFilepath, childFolder + filename + ".xml", true);
					string imgFilepath = xmlFilepath.Remove(xmlFilepath.Length - 3, 3) + "jpg";
					File.Copy(imgFilepath, childFolder + filename + ".jpg");
				}
			}
		}


		private static void removeUnlabelledImages()
		{
			Console.Write("Enter the folder:\n>>");
			string folder = Console.ReadLine();

			// remove xml files that don't have labels
			string[] filepaths = Directory.GetFiles(folder, "*.xml");
			foreach (string filepath in filepaths)
			{
				string fileContent = File.ReadAllText(filepath);
				int nameIndex = fileContent.IndexOf("<name>");
				if (nameIndex < 0)
				{
					File.Delete(filepath);
				}
			}

			// remove image files that don't have associated xml files
			filepaths = Directory.GetFiles(folder, "*.jpg");
			foreach (string filepath in filepaths)
			{
				if (!File.Exists(changeExtension(filepath, "xml")))
				{
					File.Delete(filepath);
				}
			}
		}


		private static void fixDepth()
		{
			Console.Write("Enter the folder:\n>>");
			string[] filepaths = Directory.GetFiles(Console.ReadLine(), "*.xml");
			foreach (string filepath in filepaths)
			{
				string fileContent = File.ReadAllText(filepath);
				int i = fileContent.IndexOf("<height>");
				if (i >= 0)
				{
					// find second instance of '<height>'
					i = fileContent.IndexOf('\n', i);
					i = fileContent.IndexOf("<height>", i);
					// fix
					fileContent = fileContent.Remove(i, "<height>3</height>".Length).Insert(i, "<depth>1</depth>");
					File.WriteAllText(filepath, fileContent);
				}
			}
		}


		private static string changeExtension(string filepath, string newExtension)
		{
			return filepath.Remove(filepath.Length - newExtension.Length, newExtension.Length) + newExtension;
		}


		private static string getFilename(string filepath)
		{
			return filepath.Remove(filepath.Length - 4, 4).Remove(0, filepath.LastIndexOf('\\'));
		}
	}
}

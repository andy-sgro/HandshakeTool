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
	public partial class Relabeller : Form
	{
		string[] imgFilepaths = null;

		public Relabeller()
		{
			InitializeComponent();
			Text = "Find and Replace";

			imgFilepaths = Directory.GetFiles(Files.ImageFolder.FullName, "*.jpg");
			minIndex.Maximum = imgFilepaths.Length;
			maxIndex.Maximum = imgFilepaths.Length;
			maxIndex.Value = imgFilepaths.Length;
		}

		private void findAll_CheckedChanged(object sender, EventArgs e)
		{
			if (findAll.Checked)
			{
				labelToFind.Enabled = false;
				findLabel.Enabled = false;
			}
			else
			{
				labelToFind.Enabled = true;
				findLabel.Enabled = true;
			}
			replaceBtn.Enabled = valid;
		}


		private void replaceBtn_Click(object sender, EventArgs e)
		{
			int changeCount = 0;

			for (int i = ((int)minIndex.Value - 1); i < (int)maxIndex.Value; ++i)
			{
				// get xml file
				string xmlFilepath = Files.ChangeExtension(imgFilepaths[i], ".xml");

				if (File.Exists(xmlFilepath))
				{
					string fileContent = File.ReadAllText(xmlFilepath);
					int nameIndex = fileContent.IndexOf("<name>");
					if (nameIndex >= 0)
					{
						nameIndex += "<name>".Length;
						int nameTerminator = fileContent.IndexOf("</name>");
						int nameLength = nameTerminator - nameIndex;

						string actualLabel = fileContent.Substring(nameIndex, nameLength);
						if (findAll.Checked || actualLabel.Equals(labelToFind.Text.Trim()))
						{
							fileContent = fileContent.Remove(nameIndex, nameLength).Insert(nameIndex, newLabel.Text.Trim());
							++changeCount;
						}

						File.WriteAllText(xmlFilepath, fileContent);
					}
				}
			}
			MessageBox.Show(changeCount + " out of " + imgFilepaths.Length + " files updated.");
		}

		private void labelToFind_TextChanged(object sender, EventArgs e)
		{
			replaceBtn.Enabled = valid;
		}

		private void newLabel_TextChanged(object sender, EventArgs e)
		{
			replaceBtn.Enabled = valid;
		}

		private bool valid
		{
			get
			{
				return !string.IsNullOrWhiteSpace(newLabel.Text)
					& (findAll.Checked || !string.IsNullOrWhiteSpace(labelToFind.Text));
			}
		}
	}
}

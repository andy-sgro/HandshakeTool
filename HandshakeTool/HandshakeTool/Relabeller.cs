/*
* FILE			: Relabeller.cs
* PROJECT		: Handshake Tool
* PROGRAMMER	: Polytechnica Team - Andy Sgro, Caleb Bolsonello
* FIRST VERSION : March 12, 2021
* DESCRIPTION	: This class / dialog allows the user to perform a
*				  find & replace operation on the labels in the images.
*/

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
	/**
	* NAME	  : Relabeller
	* PURPOSE : 
	*	- This class / dialog allows the user to perform a
	*	  find & replace operation on the labels in the images.
	*	- The user is directed to this page by the MainPage.cs class.
	*/
	public partial class Relabeller : Form
	{
		// Contains all the filepaths to the images.
		string[] imgFilepaths = null;

		/**
		* \brief	Initilizes the Relabeller.
		*
		* \details	Adjusts the min and max values of the numerical scrollers,
		*			depending on the number of images in the folder.
		*
		* \param	N/A
		*
		* \return	N/A
		*/
		public Relabeller()
		{
			InitializeComponent();
			Text = "Find and Replace";

			imgFilepaths = Directory.GetFiles(Files.ImageFolder.FullName, "*.jpg");
			minIndex.Maximum = imgFilepaths.Length;
			maxIndex.Maximum = imgFilepaths.Length;
			maxIndex.Value = imgFilepaths.Length;
		}


		/**
		* \brief	Disables the 'Find' field when the 'Find All' checkbox is checked.
		*
		* \param	object sender, EventArgs e : Not used.
		*
		* \return	void
		*/
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


		/**
		* \brief	When the 'Find and Replace' button is clicked,
		*			find and replace the labels, as specified by the user.
		*
		* \param	object sender, EventArgs e : Not used.
		*
		* \return	void
		*/
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


		/**
		* \brief	When the text is changed, conditionally enable the 
		*			'Find and Replace' button if the required fields are filled.
		*
		* \param	object sender, EventArgs e : Not used.
		*
		* \return	void
		*/
		private void labelToFind_TextChanged(object sender, EventArgs e)
		{
			replaceBtn.Enabled = valid;
		}


		/**
		* \brief	When the text is changed, conditionally enable the 
		*			'Find and Replace' button if the required fields are filled.
		*
		* \param	object sender, EventArgs e : Not used.
		*
		* \return	void
		*/
		private void newLabel_TextChanged(object sender, EventArgs e)
		{
			replaceBtn.Enabled = valid;
		}


		/**
		* \brief	Checks if the required fields are filled.
		*
		* \return	Returns true if all the required feilds are filled.
		*			Otherwise false is returned.
		*/
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

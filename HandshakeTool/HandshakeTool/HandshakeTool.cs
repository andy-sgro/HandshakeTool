/*
* FILE			: HandshakeTool.cs
* PROJECT		: Handshake Engine
* PROGRAMMER	: Polytechnica Team - Andy Sgro, Caleb Bolsonello
* FIRST VERSION : March 12, 2021
* DESCRIPTION	: This class stores the filepaths to the project, image, and annotions folders.
*				  It also has generic FileIO functions.
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
	* NAME	  : HandshakeTool
	* PURPOSE : 
	*	- This is the start page of the Tool.
	*	- It is a main menu, with buttons for loading / starting a new project.
	*	- This gets started by the Program.cs class, and directs the user to the
	*	  MainPage.cs class.
	*/
	public partial class HandshakeTool : Form
	{
		/**
		* \brief	Initializes the Handshake Tool and sets the window text
		* \param	N/A
		* \return	N/A
		*/
		public HandshakeTool()
		{
			InitializeComponent();
			Text = "Handshake Tool";
		}


		/**
		* \brief	Starts a new project.
		* \details	This function is called when the user presses the 'New Project' button.
		* \param	object sender, EventArgs e : Not used.
		* \return	void
		*/
		private void newProject(object sender, EventArgs e)
		{
			if (Files.NewProject())
			{
				LoadMainPage();
			}
		}


		/**
		* \brief	Opens an existing project.
		* \details	This function is called when the user presses the 'Open Project' button.
		* \param	object sender, EventArgs e : Not used.
		* \return	void
		*/
		private void loadProject(object sender, EventArgs e)
		{
			if (Files.OpenProject())
			{
				LoadMainPage();
			}
		}


		/**
		* \brief	Loads the main page, which allows the user to edit/add gestures.
		* \param	N/A
		* \return	void
		*/
		public void LoadMainPage()
		{
			MainPage mainPage = new MainPage();
			mainPage.Dock = DockStyle.Fill;
			panel.Controls.Clear();
			panel.Controls.Add(mainPage);
		}
	}
}

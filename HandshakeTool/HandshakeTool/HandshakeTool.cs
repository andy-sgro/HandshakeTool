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
	public partial class HandshakeTool : Form
	{
		public HandshakeTool()
		{
			InitializeComponent();
		}


		private void newProject(object sender, EventArgs e)
		{
			if (Files.NewProject())
			{
				LoadMainPage();
			}
		}


		private void loadProject(object sender, EventArgs e)
		{
			if (Files.OpenProject())
			{
				LoadMainPage();
			}
		}


		public void LoadMainPage()
		{
			MainPage mainPage = new MainPage();
			mainPage.Dock = DockStyle.Fill;
			panel.Controls.Clear();
			panel.Controls.Add(mainPage);
		}
	}
}

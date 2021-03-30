using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandshakeTool
{
	public partial class HandshakeTool : Form
	{
		Labeller labeller = new Labeller();
		Camera camera = new Camera();
		public string ImageFolder { get; private set; } = null;
		private UserControl activeUserControl = null;

		public HandshakeTool()
		{
			InitializeComponent();

			camera.mainPage = this;

			panel.Controls.Add(camera);
			camera.Dock = DockStyle.Fill;
			activeUserControl = camera;

			if (Global.ProjectFolder != null)
			{
				MessageBox.Show(Global.ProjectFolder);
			}
			//DbTester.Test();
		}


		public void OpenImageFolder(object sender, EventArgs e)
		{
			OpenFileDialog fileBrowser = new OpenFileDialog();
			if (fileBrowser.ShowDialog() == DialogResult.OK)
			{
				string imageFolder = fileBrowser.FileName.Remove(fileBrowser.FileName.LastIndexOf('\\') + 1);
				if (activeUserControl == labeller)
				{
					if (labeller.NumPhotosInFolder(imageFolder) <= 0)
					{
						MessageBox.Show("There are no images in that folder.");
					}
					else
					{
						labeller.GetPhotos(imageFolder);
						ImageFolder = imageFolder;
					}
				}
				else if (activeUserControl == camera)
				{
					ImageFolder = imageFolder;
				}
			}
		}


		private void cameraToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// remove
			panel.Controls.Remove(labeller);
			// add
			panel.Controls.Add(camera);
			camera.Init();
			camera.Dock = DockStyle.Fill;
			activeUserControl = camera;
		}

		private void gotoLabeller()
		{
			// remove
			camera.Delete();
			panel.Controls.Remove(camera);
			// add
			panel.Controls.Add(labeller);
			labeller.Dock = DockStyle.Fill;

			activeUserControl = labeller;
			labeller.GetPhotos(ImageFolder);
		}

		private void labellerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ImageFolder == null)
			{
				OpenImageFolder(null, null);
				if (ImageFolder != null)
				{
					if (labeller.NumPhotosInFolder(ImageFolder) <= 0)
					{
						MessageBox.Show("There are currently no images to label.");
					}
					else
					{
						gotoLabeller();
					}
				}
			}
			else if (ImageFolder != null)
			{
				if (labeller.NumPhotosInFolder(ImageFolder) > 0)
				{
					gotoLabeller();
				}
				else
				{
					OpenImageFolder(null, null);
					if (ImageFolder != null)
					{
						if (labeller.NumPhotosInFolder(ImageFolder) <= 0)
						{
							MessageBox.Show("There are currently no images to label.");
						}
						else
						{
							gotoLabeller();
						}
					}
				}
			}
		}

		private void NewProject(object sender, EventArgs e)
		{

		}

		private void OpenProject(object sender, EventArgs e)
		{
			OpenFileDialog fileBrowser = new OpenFileDialog()
			{
				Filter = "Handshake Tool files (*.hst)|*.hst"
			};
			if (fileBrowser.ShowDialog() == DialogResult.OK)
			{
				
			}
		}
	}
}

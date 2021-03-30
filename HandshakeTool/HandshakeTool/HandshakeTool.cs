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
using System.Threading;

namespace HandshakeTool
{
	public partial class HandshakeTool : Form
	{
		private FolderBrowserDialog folderBrowserDlg = new FolderBrowserDialog();
		int TotalImageFiles = 0;
		int locX = 40;
		int locY = 10;
		Panel[] bigThumbPanels;
		Panel[] smallThumbPanels;
		PictureBox[] thumbImages;
		public string[] AllImageFileNames = null;
		int sizeWidth = 130;
		private int CurrentIndex = 0;
		int sizeHeight = 130;
		int SELECTED_PADDING = 2;
		bool imageSelected = false;


		private DirectoryInfo projectFolder
		{
			get { return Global.ProjectFolder; }
		}

		private DirectoryInfo _imageFolder = null;
		private DirectoryInfo imageFolder
		{
			get
			{
				if (_imageFolder == null)
				{
					_imageFolder = new DirectoryInfo(projectFolder.FullName + "\\images");
				}
				return _imageFolder;
			}
		}

		private DirectoryInfo _annotationsFolder = null;
		private DirectoryInfo annotationsFolder
		{
			get
			{
				if (_annotationsFolder == null)
				{
					_annotationsFolder = new DirectoryInfo(projectFolder.FullName + "\\annotations");
				}
				return _annotationsFolder;
			}
		}

		public string ImageFolder { get; private set; } = null;
		private UserControl activeUserControl = null;


		public HandshakeTool()
		{
			InitializeComponent();
			LoadImages();

			cameraIndex.SelectedIndex = 0;

			if (Global.ProjectFolder != null)
			{
				MessageBox.Show(projectFolder.FullName);
				MessageBox.Show(imageFolder.FullName);
			}

		}

		private void shootBtn_Click(object sender, EventArgs e)
		{
			Task.Run(() => takePhotos());
		}


		private void takePhotos()
		{
			for (int remainingPhotos = (int)numberOfShots.Value;
				remainingPhotos > 0; --remainingPhotos)
			{
				Thread.Sleep((int)(timePerShots.Value * 1000));
				saveImg();
			}
		}

		private void saveImg()
		{
			DateTime now = DateTime.Now;
			string date = now.ToString("s").Replace('T', '_').Replace(':', '-') + '-' + now.ToString("ffff");
			//string filepath = mainPage.ImageFolder + date + ".jpg";
			//img.Save(filepath);
		}


		private void fillImage(int index)
		{
			viewport.Image = Image.FromFile(AllImageFileNames[index]);
		}

		public void LoadImages()
		{
			//DialogResult result = this.folderBrowserDlg.ShowDialog();
			imageSelected = false;
			//if (result == DialogResult.OK)
			//{

				var imageFiles = imageFolder.GetFiles("*.jpg")
					  .Concat(imageFolder.GetFiles("*.gif"))
					  .Concat(imageFolder.GetFiles("*.png"))
					  .Concat(imageFolder.GetFiles("*.jpeg"))
					  .Concat(imageFolder.GetFiles("*.bmp")).ToArray(); // Here we filter all image files 
				filmstrip.Controls.Clear();
				if (imageFiles.Length > 0)
				{
					imageSelected = true;
					TotalImageFiles = imageFiles.Length;
				}
				else
				{
					return;
				}
				int locnewX = locX;
				int locnewY = locY;

				thumbImages = new PictureBox[TotalImageFiles];
				bigThumbPanels = new Panel[TotalImageFiles];
				smallThumbPanels = new Panel[TotalImageFiles];
				AllImageFileNames = new string[TotalImageFiles];
				int imageindexs = 0;
				foreach (FileInfo img in imageFiles)
				{
					AllImageFileNames[imageindexs] = img.FullName;
					loadImagestoPanel(img.Name, img.FullName, locnewX, locnewY, imageindexs);
					locnewX = locnewX + sizeWidth + 10;
					imageindexs = imageindexs + 1;

				}
				CurrentIndex = 0;
			//}
		}

		private void loadImagestoPanel(String imageName, String ImageFullName, int newLocX, int newLocY, int imageIndex)
		{
			bigThumbPanels[imageIndex] = new Panel();
			bigThumbPanels[imageIndex].Name = "thumbPanel" + imageIndex;
			bigThumbPanels[imageIndex].BackColor = Color.Black;
			bigThumbPanels[imageIndex].Location = new Point(newLocX, newLocY);
			bigThumbPanels[imageIndex].Size = new Size(sizeWidth - 30, sizeHeight - 60);
			bigThumbPanels[imageIndex].BorderStyle = BorderStyle.None;

			smallThumbPanels[imageIndex] = new Panel();
			smallThumbPanels[imageIndex].BackColor = Color.Black;
			smallThumbPanels[imageIndex].Dock = DockStyle.Fill;
			smallThumbPanels[imageIndex].Padding = new Padding(SELECTED_PADDING);

			thumbImages[imageIndex] = new PictureBox();
			thumbImages[imageIndex].MouseClick += fillImage;
			thumbImages[imageIndex].Name = "thumbImage" + imageIndex;
			thumbImages[imageIndex].Image = Image.FromFile(ImageFullName);
			thumbImages[imageIndex].BackColor = Color.Black;
			thumbImages[imageIndex].Location = new Point(0, 0);
			thumbImages[imageIndex].BorderStyle = BorderStyle.None;
			thumbImages[imageIndex].SizeMode = PictureBoxSizeMode.Zoom;
			thumbImages[imageIndex].Dock = DockStyle.Fill;

			filmstrip.Controls.Add(bigThumbPanels[imageIndex]);
			bigThumbPanels[imageIndex].Controls.Add(smallThumbPanels[imageIndex]);
			smallThumbPanels[imageIndex].Controls.Add(thumbImages[imageIndex]);


		}

		private void fillImage(object sender, EventArgs e)
		{
			smallThumbPanels[CurrentIndex].BackColor = Color.Black;

			PictureBox picture = (PictureBox)sender;
			int index = int.Parse(picture.Name.Remove(0, "thumbPanel".Length));
			fillImage(index);
			CurrentIndex = index;
			smallThumbPanels[index].BackColor = Color.White;
		}

		


		public void OpenImageFolder(object sender, EventArgs e)
		{
			OpenFileDialog fileBrowser = new OpenFileDialog();
			if (fileBrowser.ShowDialog() == DialogResult.OK)
			{
				string imageFolder = fileBrowser.FileName.Remove(fileBrowser.FileName.LastIndexOf('\\') + 1);


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

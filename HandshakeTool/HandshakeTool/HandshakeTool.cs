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
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace HandshakeTool
{
	public partial class HandshakeTool : Form
	{
		private FolderBrowserDialog folderBrowserDlg = new FolderBrowserDialog();
		int TotalImageFiles = 0;

		const int FIRST_THUMB_X = 40;
		const int FIRST_THUMB_Y = 10;
		const int THUMB_SPACING = 10;
		const int THUMB_WIDTH = 100;
		const int THUMB_HEIGHT = 70;

		bool showingBox = false;
		bool drawingBox = false;
		Point boxStart = new Point();
		Point boxEnd = new Point();

		int nextThumbX = FIRST_THUMB_X;
		int nextThumbY = FIRST_THUMB_Y;

		Panel[] bigThumbPanels;
		Panel[] smallThumbPanels;
		PictureBox[] thumbImages;
		public string[] AllImageFileNames = null;
		private int currentIndex = 0;
		int SELECTED_PADDING = 2;
		bool imageSelected = false;
		private Image<Bgr, byte> img = null;
		private Capture capture = null;
		private bool appIsChangingTab = false;

		private void drawBoundingBox()
		{
			if (img != null)
			{
				Image<Bgr, byte> overlay = img.Copy();
				Image<Bgr, byte> output = img.Copy();

				if (showingBox)
				{
					CvInvoke.Rectangle(overlay, new Rectangle(
						boxStart.X,
						boxStart.Y,
						(boxEnd.X - boxStart.X),
						(boxEnd.Y - boxStart.Y)),
						new MCvScalar(255, 200, 10), -1);

					CvInvoke.AddWeighted(overlay, 0.3, img, 0.7, 0, output);
				}

				Bitmap bmp = output.Bitmap;
				viewport.Image = bmp;
			}
		}

		private Point screenToImage(Point pt)
		{
			// scale
			float widthFactor = (float)img.Width / viewport.Width;
			float heightFactor = (float)img.Height / viewport.Height;
			float x = pt.X * widthFactor;
			float y = pt.Y * heightFactor;

			float imgRatio = (float)img.Width / img.Height;
			float viewportRatio = (float)viewport.Width / viewport.Height;
			
			// if it's letterboxed horizontally
			if (viewportRatio > imgRatio)
			{
				// scale horizontally
				float viewportImgWidth = (viewport.Height * imgRatio);
				x *= (viewport.Width / viewportImgWidth);

				// translate x
				float xBarViewportWidth = (viewport.Width - viewportImgWidth) / 2f;
				float xBarPercent = xBarViewportWidth / viewportImgWidth;
				float xBarImgWidth = img.Width * xBarPercent;
				x -= xBarImgWidth;
			}
			// if it's letterboxed vertically
			else if (viewportRatio < imgRatio)
			{
				// scale vertically
				float viewportImgHeight = (viewport.Width * (1 / imgRatio));
				y *= (viewport.Height / viewportImgHeight);

				// translate y
				float yBarViewportHeight = (viewport.Height - viewportImgHeight) / 2f;
				float yBarPercent = yBarViewportHeight / viewportImgHeight;
				float yBarImgHeight = img.Height * yBarPercent;
				y -= yBarImgHeight;
			}

			//clamp
			return new Point(clamp(x, 0, img.Width), clamp(y, 0, img.Height));
		}

		private int clamp(float input, int min, int max)
		{
			if (input < min)
			{
				input = min;
			}
			else if (input > max)
			{
				input = max;
			}
			return (int)Math.Round(input);
		}




		private void viewport_MouseDown(object sender, MouseEventArgs e)
		{
			if (tabControl.SelectedIndex == (int)tab.photoInfo)
			{
				showingBox = true;
				drawingBox = true;
				boxStart = screenToImage(e.Location);
				boxEnd = screenToImage(e.Location);
			}
		}

		private void viewport_MouseMove(object sender, MouseEventArgs e)
		{
			if (drawingBox)
			{
				boxEnd = screenToImage(e.Location);
				drawBoundingBox();
			}
		}

		private void viewport_MouseUp(object sender, MouseEventArgs e)
		{
			drawingBox = false;
			drawBoundingBox();
		}

		enum tab
		{
			camera,
			photoInfo
		}


		#region properties

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

		#endregion

		private UserControl activeUserControl = null;


		public HandshakeTool()
		{
			InitializeComponent();
			fillFilmstrip();

			cameraIndex.SelectedIndex = 1;

			if (Global.ProjectFolder != null)
			{
				//MessageBox.Show(projectFolder.FullName);
				//MessageBox.Show(imageFolder.FullName);
			}

		}

		private void HandshakeTool_Load(object sender, EventArgs e)
		{
			enableCamera();
		}

		private void streaming(object sender, System.EventArgs e)
		{
			img = capture.QueryFrame().ToImage<Bgr, byte>();
			Bitmap bmp = img.Bitmap;
			viewport.Image = bmp;
		}
		

		private void shootBtn_Click(object sender, EventArgs e)
		{
			Task.Run(() => takePhotos());
		}


		private void takePhotos()
		{
			int _numberOfShots = (int)numberOfShots.Value;
			for (int i = 0; i < _numberOfShots; ++i)
			{
				Thread.Sleep((int)(timePerShots.Value * 1000));
				saveImg();
				progressBar.Value = (int)(((double)(i + 1) / _numberOfShots) * 100);
				//MessageBox.Show(progressBar.Value.ToString());
				progressBar.PerformStep();
			}
			progressBar.Value = 0;
			MessageBox.Show("Photo capture is complete.");
			progressBar.BackColor = Color.Black;
		}

		private void saveImg()
		{
			DateTime now = DateTime.Now;
			string date = now.ToString("s").Replace('T', '_').Replace(':', '-') + '-' + now.ToString("ffff");
			string filepath = imageFolder + "\\" + date + ".jpg";
			img.Save(filepath);
		}


		private void showcaseImage(int index)
		{
			smallThumbPanels[currentIndex].BackColor = Color.Black;
			disableCamera();
			viewport.Image = Image.FromFile(AllImageFileNames[index]);
			img = new Image<Bgr, byte>(AllImageFileNames[index]);

			currentIndex = index;
			smallThumbPanels[index].BackColor = Color.White;
		}

		private void enableCamera()
		{
			capture = new Capture(cameraIndex.SelectedIndex);
			Application.Idle += streaming;
		}

		private void disableCamera()
		{
			Application.Idle -= streaming;
			capture.Stop();
			capture.Dispose();
		}


		public void fillFilmstrip()
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
				

				thumbImages = new PictureBox[TotalImageFiles];
				bigThumbPanels = new Panel[TotalImageFiles];
				smallThumbPanels = new Panel[TotalImageFiles];
				AllImageFileNames = new string[TotalImageFiles];
				int imageindexs = 0;
				foreach (FileInfo img in imageFiles)
				{
					AllImageFileNames[imageindexs] = img.FullName;
					appendFilmstrip(img.Name, img.FullName, imageindexs);
					
					imageindexs = imageindexs + 1;

				}
				currentIndex = 0;
			//}
		}

		private void appendFilmstrip(string imageName, string ImageFullName, int imageIndex)
		{
			bigThumbPanels[imageIndex] = new Panel();
			bigThumbPanels[imageIndex].Name = "thumbPanel" + imageIndex;
			bigThumbPanels[imageIndex].BackColor = Color.Black;
			bigThumbPanels[imageIndex].Location = new Point(nextThumbX, nextThumbY);
			bigThumbPanels[imageIndex].Size = new Size(THUMB_WIDTH, THUMB_HEIGHT);
			bigThumbPanels[imageIndex].BorderStyle = BorderStyle.None;

			smallThumbPanels[imageIndex] = new Panel();
			smallThumbPanels[imageIndex].BackColor = Color.Black;
			smallThumbPanels[imageIndex].Dock = DockStyle.Fill;
			smallThumbPanels[imageIndex].Padding = new Padding(SELECTED_PADDING);

			thumbImages[imageIndex] = new PictureBox();
			thumbImages[imageIndex].MouseClick += thumb_Click;
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

			nextThumbX += THUMB_WIDTH + THUMB_SPACING;
		}

		private void thumb_Click(object sender, EventArgs e)
		{
			

			PictureBox picture = (PictureBox)sender;
			int index = int.Parse(picture.Name.Remove(0, "thumbPanel".Length));
			showcaseImage(index);

			appIsChangingTab = true;
			tabControl.SelectedIndex = (int)tab.photoInfo;
			appIsChangingTab = false;
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

		private void tabChanged(object sender, EventArgs e)
		{
			
			if (tabControl.SelectedIndex == (int)tab.camera)
			{
				if (!appIsChangingTab)
				{
					smallThumbPanels[currentIndex].BackColor = Color.Black;
					enableCamera();
				}
				viewport.Cursor = Cursors.Default;
				viewport.MouseDown -= viewport_MouseDown;
				viewport.MouseUp -= viewport_MouseUp;
				viewport.MouseMove -= viewport_MouseMove;
			}
			else if (tabControl.SelectedIndex == (int)tab.photoInfo)
			{
				if (!appIsChangingTab)
				{
					showcaseImage(currentIndex);
				}
				viewport.Cursor = Cursors.Cross;
				viewport.MouseDown += viewport_MouseDown;
				viewport.MouseUp += viewport_MouseUp;
				viewport.MouseMove += viewport_MouseMove;
			}
		}

	}
}

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
		#region fields
		private FolderBrowserDialog folderBrowserDlg = new FolderBrowserDialog();

		const int FIRST_THUMB_X = 40;
		const int FIRST_THUMB_Y = 10;
		const int THUMB_SPACING = 10;
		const int THUMB_WIDTH = 100;
		const int THUMB_HEIGHT = 70;

		bool showingCross = false;
		bool showingBox = false;
		bool drawingBox = false;
		Point boxStart = new Point();
		Point boxEnd = new Point();

		int nextThumbX = FIRST_THUMB_X;
		int nextThumbY = FIRST_THUMB_Y;

		List<Panel> bigThumbPanels = new List<Panel>();
		List<Panel> smallThumbPanels = new List<Panel>();
		List<PictureBox> thumbImages = new List<PictureBox>();
		public List<string> imgFilepaths = new List<string>();
		private int currentIndex = -1;
		int THUMB_PADDING = 2;
		private Image<Bgr, byte> mainImage = null;
		private Image<Bgr, byte> boxImage = null;
		private Capture capture = null;
		private bool appIsChangingTab = false;
		#endregion


		public HandshakeTool()
		{
			InitializeComponent();
		}

		private void HandshakeTool_Load(object sender, EventArgs e)
		{
			cameraIndex.SelectedIndex = 1;
			fillFilmstrip();
			enableCamera();
		}

		private void drawCross(Point cursor)
		{
			Image<Bgr, byte> image = boxImage.Copy();

			MCvScalar colour = new MCvScalar(0, 0, 0);

			// horizontal line
			Point left = new Point(0, cursor.Y);
			Point right = new Point(image.Width, cursor.Y);
			CvInvoke.Line(image, left, right, colour);

			// vertical line
			Point top = new Point(cursor.X, 0);
			Point bottom = new Point(cursor.X, image.Height);
			CvInvoke.Line(image, top, bottom, colour);

			viewport.Image = image.Bitmap;
		}

		private void drawBoundingBox()
		{
			if (mainImage != null)
			{
				Image<Bgr, byte> overlay = mainImage.Copy();

				if (showingBox)
				{
					CvInvoke.Rectangle(overlay, new Rectangle(
						boxStart.X,
						boxStart.Y,
						(boxEnd.X - boxStart.X),
						(boxEnd.Y - boxStart.Y)),
						new MCvScalar(255, 200, 10), -1);

					CvInvoke.AddWeighted(overlay, 0.3, mainImage, 0.7, 0, boxImage);
				}

				viewport.Image = boxImage.Bitmap;
			}
		}

		private Point screenToImage(Point pt)
		{
			// scale
			float widthFactor = (float)mainImage.Width / viewport.Width;
			float heightFactor = (float)mainImage.Height / viewport.Height;
			float x = pt.X * widthFactor;
			float y = pt.Y * heightFactor;

			float imgRatio = (float)mainImage.Width / mainImage.Height;
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
				float xBarImgWidth = mainImage.Width * xBarPercent;
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
				float yBarImgHeight = mainImage.Height * yBarPercent;
				y -= yBarImgHeight;
			}

			//clamp
			return new Point(clamp(x, 0, mainImage.Width), clamp(y, 0, mainImage.Height));
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
			if (tabControl.SelectedTab == imgInfoTab)
			{
				showingBox = true;
				drawingBox = true;
				boxStart = screenToImage(e.Location);
				boxEnd = screenToImage(e.Location);
			}
		}

		private void viewport_MouseMove(object sender, MouseEventArgs e)
		{
			Point cursor = screenToImage(e.Location);

			if (drawingBox)
			{
				boxEnd = cursor;
				drawBoundingBox();
			}
			if (showingCross)
			{
				drawCross(cursor);
			}
		}

		private void viewport_MouseUp(object sender, MouseEventArgs e)
		{
			drawingBox = false;
			drawBoundingBox();
		}

		private void viewport_MouseEnter(object sender, EventArgs e)
		{
			if (tabControl.SelectedTab == imgInfoTab)
			{
				showingCross = true;
			}
		}

		private void viewport_MouseLeave(object sender, EventArgs e)
		{
			if (tabControl.SelectedTab == imgInfoTab)
			{
				drawBoundingBox();
			}
		}






	

		private void streaming(object sender, System.EventArgs e)
		{
			mainImage = capture.QueryFrame().ToImage<Bgr, byte>();
			Bitmap bmp = mainImage.Bitmap;
			viewport.Image = bmp;
		}
		

		private void shootBtn_Click(object sender, EventArgs e)
		{
			Task.Run(() => takePhotos());
		}

		delegate void SetProgressBarCallback(int value);
		private void setProgressBar(int value)
		{
			if (progressBar.InvokeRequired)
			{
				SetProgressBarCallback d = new SetProgressBarCallback(setProgressBar);
				Invoke(d, new object[] { value });
			}
			else
			{
				progressBar.Value = value;
			}
		}


		private void takePhotos()
		{
			int _numberOfShots = (int)numberOfShots.Value;
			for (int i = 0; i < _numberOfShots; ++i)
			{
				Thread.Sleep((int)(timePerShots.Value * 1000));
				saveImg();
				setProgressBar((int)(((double)(i + 1) / _numberOfShots) * 100));
			}
			setProgressBar(0);
			MessageBox.Show("Photo capture is complete.");
			progressBar.BackColor = Color.Black;
		}

		private void saveImg()
		{
			DateTime now = DateTime.Now;
			string date = now.ToString("s").Replace('T', '_').Replace(':', '-') + '-' + now.ToString("ffff");
			string filepath = Files.ImageFolder + date + ".jpg";
			mainImage.Save(filepath);
			appendFilmstrip(filepath);
		}


		private void showcaseImage(int index)
		{
			index = clamp(index, 0, imgFilepaths.Count - 1);
			if (currentIndex >= 0)
			{
				smallThumbPanels[currentIndex].BackColor = Color.Black;
			}
			disableCamera();
			mainImage = new Image<Bgr, byte>(imgFilepaths[index]);

			boxImage = mainImage.Copy();
			
			showingBox = readXmlBox(index);
			if (showingBox)
			{
				drawBoundingBox();
			}
			else
			{
				viewport.Image = mainImage.Bitmap;
			}

			currentIndex = index;
			smallThumbPanels[index].BackColor = Color.White;
		}

		private bool readXmlBox(int index)
		{
			string filepath = imgFilepaths[index]
				.Remove(imgFilepaths[index].LastIndexOf('.') + 1)
				+ "xml";

			if (File.Exists(filepath))
			{
				string xmlContent = File.ReadAllText(filepath);

				int xmin = getXmlBoxPoint(ref xmlContent, "<xmin>", "</xmin>");
				int xmax = getXmlBoxPoint(ref xmlContent, "<xmax>", "</xmax>");
				int ymin = getXmlBoxPoint(ref xmlContent, "<ymin>", "</ymin>");
				int ymax = getXmlBoxPoint(ref xmlContent, "<ymax>", "</ymax>");

				boxStart = new Point(xmin, ymin);
				boxEnd = new Point(xmax, ymax);

				return true;
			}
			return false;
		}

		private int getXmlBoxPoint(ref string xmlContent, string startTag, string endTag)
		{
			int index = xmlContent.IndexOf(startTag) + startTag.Length;
			int length = xmlContent.IndexOf(endTag) - index;
			return int.Parse(xmlContent.Substring(index, length));
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
			filmstrip.Controls.Clear();
			var imageFiles = Files.ImageFolder.GetFiles("*.jpg")
					.Concat(Files.ImageFolder.GetFiles("*.gif"))
					.Concat(Files.ImageFolder.GetFiles("*.png"))
					.Concat(Files.ImageFolder.GetFiles("*.jpeg"))
					.Concat(Files.ImageFolder.GetFiles("*.bmp")).ToArray();

			if (imageFiles.Length > 0)
			{
				currentIndex = 0;
				foreach (FileInfo img in imageFiles)
				{
					appendFilmstrip(img.FullName);
				}
			}
		}

		private void appendFilmstrip(string filepath)
		{
			int index = imgFilepaths.Count;
			imgFilepaths.Add(filepath);
			Panel bigThumbPanel = new Panel();
			bigThumbPanels.Add(bigThumbPanel);
			Panel smallThumbPanel = new Panel();
			smallThumbPanels.Add(smallThumbPanel);
			PictureBox thumbImage = new PictureBox();
			thumbImages.Add(thumbImage);

			bigThumbPanel.Name = "thumbPanel" + index;
			bigThumbPanel.BackColor = Color.Black;
			bigThumbPanel.Location = new Point(nextThumbX + filmstrip.AutoScrollPosition.X, nextThumbY);
			bigThumbPanel.Size = new Size(THUMB_WIDTH, THUMB_HEIGHT);
			bigThumbPanel.BorderStyle = BorderStyle.None;

			smallThumbPanel.BackColor = Color.Black;
			smallThumbPanel.Dock = DockStyle.Fill;
			smallThumbPanel.Padding = new Padding(THUMB_PADDING);

			thumbImage.MouseClick += thumb_Click;
			thumbImage.Name = "thumbImage" + index;
			thumbImage.Image = Image.FromFile(filepath);
			thumbImage.BackColor = Color.Black;
			thumbImage.Location = new Point(0, 0);
			thumbImage.BorderStyle = BorderStyle.None;
			thumbImage.SizeMode = PictureBoxSizeMode.Zoom;
			thumbImage.Dock = DockStyle.Fill;

			AppendFilmstrip2(bigThumbPanel, smallThumbPanel, thumbImage);

			nextThumbX += THUMB_WIDTH + THUMB_SPACING;
		}

		delegate void AppendFilmstripCallback(Panel bigPanel, Panel smallPanel, PictureBox picture);

		private void AppendFilmstrip2(Panel bigPanel, Panel smallPanel, PictureBox picture)
		{
			if (filmstrip.InvokeRequired)
			{
				AppendFilmstripCallback callback = new AppendFilmstripCallback(AppendFilmstrip2);
				Invoke(callback, new object[] { bigPanel, smallPanel, picture });
			}
			else
			{
				filmstrip.Controls.Add(bigPanel);
				bigPanel.Controls.Add(smallPanel);
				smallPanel.Controls.Add(picture);
			}
		}

		private void thumb_Click(object sender, EventArgs e)
		{
			PictureBox picture = (PictureBox)sender;
			int index = int.Parse(picture.Name.Remove(0, "thumbPanel".Length));
			showcaseImage(index);

			appIsChangingTab = true;
			tabControl.SelectedTab = imgInfoTab;
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
			
			if (tabControl.SelectedTab == cameraTab)
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
			else if (tabControl.SelectedTab == imgInfoTab)
			{
				if (imgFilepaths.Count <= 0)
				{
					MessageBox.Show("Please add an image first.");
					tabControl.SelectedTab = cameraTab;
				}
				else
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

		private void btnSaveXml_Click(object sender, EventArgs e)
		{
			writeXmlFile();
			showcaseImage(currentIndex + 1);
		}

		private bool writeXmlFile()
		{
			if (string.IsNullOrWhiteSpace(label.Text) | !showingBox)
			{
				MessageBox.Show("A label and bounding box must be specified.");
				return false;
			}
			else
			{
				string filepath = imgFilepaths[currentIndex]
					.Remove(imgFilepaths[currentIndex].LastIndexOf('.'));
				Size imgSize = viewport.Image.Size;
				char[] separator = { '\\' };
				string[] pathStructure = filepath.Split(separator);
				string folder = pathStructure[pathStructure.Length - 2];
				string filename = pathStructure[pathStructure.Length - 1];

				string xmlContent = "<annotation>"
					+ "\r\n\t<folder>" + folder + "</folder>"
					+ "\r\n\t<filename>" + filename + ".jpg</filename>"
					+ "\r\n\t<path>" + filepath + ".jpg</path>"
					+ "\r\n\t<source><database>Unknown</database></source>"
					+ "\r\n\t<size>"
					+ "\r\n\t\t<width>" + imgSize.Width + "</width>"
					+ "\r\n\t\t<height>" + imgSize.Height + "</height>"
					+ "\r\n\t\t<height>3</height>"
					+ "\r\n\t</size>"
					+ "\r\n\t<segmented>0</segmented>"
					+ "\r\n\t<object>"
					+ "\r\n\t\t<name>" + label.Text + "</name>"
					+ "\r\n\t\t<pose>Unspecified</pose>"
					+ "\r\n\t\t<truncated>0</truncated>"
					+ "\r\n\t\t<difficult>0</difficult>"
					+ "\r\n\t\t<bndbox>"
					+ "\r\n\t\t\t<xmin>" + boxStart.X + "</xmin>"
					+ "\r\n\t\t\t<ymin>" + boxStart.Y + "</ymin>"
					+ "\r\n\t\t\t<xmax>" + boxEnd.X + "</xmax>"
					+ "\r\n\t\t\t<ymax>" + boxEnd.Y + "</ymax>"
					+ "\r\n\t\t</bndbox>"
					+ "\r\n\t</object>"
					+ "\r\n</annotation>";

				File.WriteAllText(filepath + ".xml", xmlContent);
				return true;
			}
		}

		private void HandshakeTool_Enter(object sender, EventArgs e)
		{
			MessageBox.Show("focused");
		}
	}
}

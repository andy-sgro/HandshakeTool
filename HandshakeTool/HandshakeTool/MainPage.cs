﻿using System;
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
using System.Diagnostics;

namespace HandshakeTool
{
	public partial class MainPage : UserControl
	{
		#region fields
		const int FIRST_THUMB_Y = 10;
		const int THUMB_SPACING = 10;
		const int FIRST_THUMB_X = THUMB_SPACING;
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
		private bool userIsChangingTab = true;
		private bool userIsChangingCamera = true;
		#endregion


		public MainPage()
		{
			InitializeComponent();
			userIsChangingCamera = false;
			cameraIndex.SelectedIndex = 0;
			userIsChangingCamera = true;
			enableCamera();
			fillFilmstrip();
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
			ActiveControl = btnSaveXml;
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
				Thread.Sleep((int)(timePerShot.Value * 1000));
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
			writeXmlFile(imgFilepaths.Count - 1, optionalGesture.Text);
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

			string labelName = null;
			string xmlContent = getXmlContent(index);

			// if there isn't a box, optionaly clear box
			if (xmlContent == null)
			{
				if (clearBox.Checked)
				{
					showingBox = false;
				}
				updateGesturePrompt.Text = "Add New Gesture:";
			}
			// if there is a box, always show it
			else
			{
				updateGesturePrompt.Text = "Update Gesture:";
				showingBox = getXmlBox(xmlContent);
				labelName = getXmlField(xmlContent, "<name>", "</name>");
			}

			if (showingBox)
			{
				drawBoundingBox();
			}
			else
			{
				viewport.Image = mainImage.Bitmap;
			}

			// update old label
			oldLabel.Text = (labelName == null)
					? "" : labelName;

			// update new label
			if (clearLabel.Checked)
			{
				newLabel.Text = "";
			}

			currentIndex = index;
			smallThumbPanels[index].BackColor = Color.White;

			// autoscroll to thumbnail
			//int picX = bigThumbPanels[index].Location.X;
			//int picWidth = bigThumbPanels[index].Width;
			//int scrollX = filmstrip.AutoScrollPosition.X;
			//int filmWidth = filmstrip.Width;
			//// if thumbnail is to the left
			//if ((picX + picWidth) > (scrollX + filmWidth))
			//{
			//	filmstrip.AutoScrollPosition = new Point(
			//		picX - filmWidth + picWidth, filmstrip.AutoScrollPosition.Y);
			//}
			//// if thumbnail is to the right
			//if ((picX + picWidth) < scrollX)
			//{
			//	filmstrip.AutoScrollPosition = new Point(
			//		picX, filmstrip.AutoScrollPosition.Y);
			//}

			// fill title bar
			Program.app.Text = imgFilepaths[index]
				.Remove(0, imgFilepaths[index].LastIndexOf('\\') + 1) 
				+ " (" + (index+1) + '/' + imgFilepaths.Count + ") - Handshake Tool";
		}


		private string getXmlContent(int index)
		{
			string filepath = imgFilepaths[index]
				.Remove(imgFilepaths[index].LastIndexOf('.') + 1)
				+ "xml";

			if (File.Exists(filepath))
			{
				return File.ReadAllText(filepath);
			}
			return null;
		}


		private bool getXmlBox(string xmlContent)
		{
			if ((xmlContent != null) && (xmlContent.IndexOf("<bndbox>") >= 0))
			{
				int xmin = int.Parse(getXmlField(xmlContent, "<xmin>", "</xmin>"));
				int xmax = int.Parse(getXmlField(xmlContent, "<xmax>", "</xmax>"));
				int ymin = int.Parse(getXmlField(xmlContent, "<ymin>", "</ymin>"));
				int ymax = int.Parse(getXmlField(xmlContent, "<ymax>", "</ymax>"));

				boxStart = new Point(xmin, ymin);
				boxEnd = new Point(xmax, ymax);

				return true;
			}
			return false;
		}


		private string getXmlField(string xmlContent, string startTag, string endTag)
		{
			if (xmlContent != null)
			{
				int index = xmlContent.IndexOf(startTag) + startTag.Length;
				int length = xmlContent.IndexOf(endTag) - index;
				return xmlContent.Substring(index, length);
			}
			return null;
		}


		private void restartCamera()
		{
			disableCamera();
			enableCamera();
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
			nextThumbX = FIRST_THUMB_X;
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
				if (tabControl.SelectedTab == imgInfoTab)
				{
					showcaseImage(0);
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

			userIsChangingTab = false;
			tabControl.SelectedTab = imgInfoTab;
			userIsChangingTab = true;
		}


		public void OpenImageFolder(object sender, EventArgs e)
		{
			OpenFileDialog fileBrowser = new OpenFileDialog();
			if (fileBrowser.ShowDialog() == DialogResult.OK)
			{
				string imageFolder = fileBrowser.FileName.Remove(fileBrowser.FileName.LastIndexOf('\\') + 1);


			}
		}


		private void newProject(object sender, EventArgs e)
		{
			if (Files.NewProject())
			{
				fillFilmstrip();
			}
		}


		private void openProject(object sender, EventArgs e)
		{
			if (Files.OpenProject())
			{
				fillFilmstrip();
			}
		}


		private void tabChanged(object sender, EventArgs e)
		{

			if (tabControl.SelectedTab == cameraTab)
			{
				if (userIsChangingTab)
				{
					smallThumbPanels[currentIndex].BackColor = Color.Black;
					enableCamera();
				}
				viewport.Cursor = Cursors.Default;
				viewport.MouseDown -= viewport_MouseDown;
				viewport.MouseUp -= viewport_MouseUp;
				viewport.MouseMove -= viewport_MouseMove;
				Program.app.Text = "Handshake Tool";
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
					if (userIsChangingTab)
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
			if (string.IsNullOrWhiteSpace(newLabel.Text))
			{
				MessageBox.Show("Please Enter a gesture name.");
			}
			else
			{
				writeXmlFile(currentIndex, newLabel.Text);
				showcaseImage(currentIndex + 1);
			}
		}


		private bool writeXmlFile(int index, string label)
		{
			// if there is a label, write it
			if (!string.IsNullOrWhiteSpace(label))
			{
				string filepath = imgFilepaths[index]
					.Remove(imgFilepaths[index].LastIndexOf('.'));
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
					+ "\r\n\t\t<name>" + label + "</name>"
					+ "\r\n\t\t<pose>Unspecified</pose>"
					+ "\r\n\t\t<truncated>0</truncated>"
					+ "\r\n\t\t<difficult>0</difficult>";
					
				if (showingBox)
				{
					xmlContent += "\r\n\t\t<bndbox>"
						+ "\r\n\t\t\t<xmin>" + boxStart.X + "</xmin>"
						+ "\r\n\t\t\t<ymin>" + boxStart.Y + "</ymin>"
						+ "\r\n\t\t\t<xmax>" + boxEnd.X + "</xmax>"
						+ "\r\n\t\t\t<ymax>" + boxEnd.Y + "</ymax>"
						+ "\r\n\t\t</bndbox>";
				}

				xmlContent += "\r\n\t</object>"
					+ "\r\n</annotation>";

				File.WriteAllText(filepath + ".xml", xmlContent);
				return true;
			}
			return false;
		}


		private void HandshakeTool_Enter(object sender, EventArgs e)
		{
			MessageBox.Show("focused");
		}


		private void changeCamera(object sender, EventArgs e)
		{
			if (userIsChangingCamera)
			{
				restartCamera();
			}
		}


		private void openProjectFolder(object sender, EventArgs e)
		{
			Process.Start(Files.ProjectFolder.FullName);
		}


		private void close(object sender, EventArgs e)
		{
			Application.Exit();
		}


		private void batchRelabel(object sender, EventArgs e)
		{

		}


		private void createLabelMap(object sender, EventArgs e)
		{
			string[] labels = getLabelStats().Keys.ToArray();
			string labelMapContent = "";

			for (int i = 0; i < labels.Length; ++i)
			{
				labelMapContent += "item {\n\tid: " + (i+1) + "\n\tname: '"
					+ labels[i] + "\'\n}\n\n";
			}

			File.WriteAllText(Files.AnnotationsFolder + "label_map.pbtxt", labelMapContent);
			Process.Start(Files.AnnotationsFolder.FullName);
		}


		private void separateImagesIntoFolders(object sender, EventArgs e)
		{
			FileInfo[] xmlFilepathInfos = Files.ImageFolder.GetFiles("*.xml");

			if (xmlFilepathInfos.Length <= 0)
			{
				MessageBox.Show("The images must be labelled before they can be aggregated");
			}
			else
			{
				string aggregatedFolder = Files.ImageFolder + "aggregated" + '\\';

				foreach (FileInfo xmlFilepathInfo in xmlFilepathInfos)
				{
					string xmlFilepath = xmlFilepathInfo.FullName;
					string fileContent = File.ReadAllText(xmlFilepath);
					int nameIndex = fileContent.IndexOf("<name>");
					int bndboxIndex = fileContent.IndexOf("<bndbox>");

					if ((nameIndex >= 0) & (bndboxIndex >= 0))
					{
						nameIndex += "<name>".Length;
						int nameTerminator = fileContent.IndexOf("</name>");
						int nameLength = nameTerminator - nameIndex;
						string label = fileContent.Substring(nameIndex, nameLength);

						string childFolder = aggregatedFolder + label + '\\';

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
				Process.Start(aggregatedFolder);
			}
		}


		private static string getFilename(string filepath)
		{
			return filepath.Remove(filepath.LastIndexOf('.'))
				.Remove(0, filepath.LastIndexOf('\\'));
		}


		private static void separateIntoFolders()
		{
			
		}


		private Dictionary<string, int> getLabelStats()
		{
			Dictionary<string, int> stats = new Dictionary<string, int>();

			foreach (FileInfo filepath in Files.ImageFolder.GetFiles("*.xml"))
			{
				string fileContent = File.ReadAllText(filepath.FullName);
				int nameIndex = fileContent.IndexOf("<name>");
				if (nameIndex >= 0)
				{
					nameIndex += "<name>".Length;
					int nameTerminator = fileContent.IndexOf("</name>");
					int nameLength = nameTerminator - nameIndex;

					string label = fileContent.Substring(nameIndex, nameLength);
					if (stats.ContainsKey(label))
					{
						++stats[label];
					}
					else
					{
						stats.Add(label, 1);
					}
				}
			}
			return stats;
		}


		private void showStats(object sender, EventArgs e)
		{
			Dictionary<string, int> labels = getLabelStats();

			string stats = "Images: " + imgFilepaths.Count
				+ "\nUnique gestures: " + labels.Count;

			foreach (KeyValuePair<string, int> label in labels)
			{
				stats += "\n   - " + label.Key + ": " + label.Value;
			}
			MessageBox.Show(stats);
		}


		private static void countAllLabels()
		{
			
		}
	}
}

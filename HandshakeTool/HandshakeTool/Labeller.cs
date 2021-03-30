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
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;


namespace HandshakeTool
{
	public partial class Labeller : UserControl
	{
		public string[] Photos { get; private set; } = null;
		private const int NUM_THUMBNAILS = 5;
		PictureBox[] thumbnails = null;
		Image<Bgr, byte> mainPicture = null;
		bool showingBox = false;
		bool drawingBox = false;
		Point boxStart = new Point();
		Point boxEnd = new Point();

		private int thumbnailIndex = -1;
		private int _photoIndex = -1;
		private int photoIndex
		{
			get { return _photoIndex; }
			set
			{
				if (Photos.Length > 0)
				{
					if (value >= Photos.Length)
					{
						MessageBox.Show("This is the last image in the folder.");
					}
					else
					{
						if (value <= 2)
						{
							thumbnailIndex = 0;
							if (value < 0)
							{
								value = 0;
							}
						}
						else if (value >= (Photos.Length - 3))
						{
							thumbnailIndex = Photos.Length - 5;
						}
						else
						{
							thumbnailIndex = (value - 2);
						}
						showingBox = false;
						_photoIndex = value;
						mainPicture = new Image<Bgr, byte>(Photos[_photoIndex]);
						drawThumbnails();
						updateViewport();
					}
				}
			}
		}

		private void drawThumbnails()
		{
			int imagesToDraw = Math.Min(NUM_THUMBNAILS, Photos.Length);

			for (int i = 0; i < imagesToDraw; ++i)
			{
				Image<Bgr, byte> img = new Image<Bgr, byte>(Photos[thumbnailIndex + i]);
				Bitmap bmp = img.Bitmap;
				thumbnails[i].Image = bmp;

				if (i == thumbnailIndex)
				{
					// highlight the selected image
					//Image<Bgr, byte> overlay = img.Copy();

					//CvInvoke.Rectangle(overlay, new Rectangle(
					//			(int)(boxStart.X * widthFactor),
					//			(int)(boxStart.Y * heightFactor),
					//			(int)((boxEnd.X - boxStart.X) * widthFactor),
					//			(int)((boxEnd.Y - boxStart.Y) * heightFactor)),
					//			new MCvScalar(255, 200, 10), -1);

					//CvInvoke.AddWeighted(overlay, 0.3, mainPicture, 0.7, 0, output);
				}
			}			
		}


		public Labeller()
		{
			InitializeComponent();
			thumbnails = new PictureBox[NUM_THUMBNAILS];
		}


		public void GetPhotos(string directory)
		{
			Photos = Directory.GetFiles(directory, "*.jpg");
			photoIndex = photoIndex;
		}

		public int NumPhotosInFolder(string directory)
		{
			return Directory.GetFiles(directory, "*.jpg").Length;
		}


		private void Labeller_Load(object sender, EventArgs e)
		{
			thumbnails[0] = thumbnail0;
			thumbnails[1] = thumbnail1;
			thumbnails[2] = thumbnail2;
			thumbnails[3] = thumbnail3;
			thumbnails[4] = thumbnail4;
		}


		private void updateViewport()
		{
			if (mainPicture != null)
			{
				Image<Bgr, byte> overlay = mainPicture.Copy();
				Image<Bgr, byte> output = mainPicture.Copy();

				if (showingBox)
				{
					//overlay(mainPicture, boxStart.X, boxStart.Y,
					//	boxEnd.X - boxStart.X,
					//	boxEnd.Y - boxStart.Y,
					//	viewport, 0.3
					//	);
					
					float widthFactor = (float)overlay.Size.Width / viewport.Width;
					float heightFactor = (float)overlay.Size.Height / viewport.Height;

					CvInvoke.Rectangle(overlay, new Rectangle(
						(int)(boxStart.X * widthFactor), 
						(int)(boxStart.Y * heightFactor), 
						(int)((boxEnd.X - boxStart.X) * widthFactor), 
						(int)((boxEnd.Y - boxStart.Y) * heightFactor)), 
						new MCvScalar(255, 200, 10), -1);

					CvInvoke.AddWeighted(overlay, 0.3, mainPicture, 0.7, 0, output);
				}

				Bitmap bmp = output.Bitmap;
				viewport.Image = bmp;
			}
		}

		private Rectangle overlay(Image<Bgr, byte> input, int x, int y, int width, int height, PictureBox pictureBox, double alpha)
		{
			Image<Bgr, byte> overlay = input.Copy();
			Image<Bgr, byte> output = input.Copy();

			float widthFactor = (float)input.Size.Width / pictureBox.Width;
			float heightFactor = (float)input.Size.Height / pictureBox.Height;
			Rectangle rect = new Rectangle(
						(int)(boxStart.X * widthFactor),
						(int)(boxStart.Y * heightFactor),
						(int)((boxEnd.X - boxStart.X) * widthFactor),
						(int)((boxEnd.Y - boxStart.Y) * heightFactor));

			CvInvoke.Rectangle(overlay, rect, new MCvScalar(255, 200, 10), -1);
			CvInvoke.AddWeighted(overlay, alpha, mainPicture, 1 - alpha, 0, output);
			viewport.Image = output.Bitmap;

			return rect;
		}


		private void viewport_MouseDown(object sender, MouseEventArgs e)
		{
			showingBox = true;
			drawingBox = true;
			boxStart.X = e.X;
			boxStart.Y = e.Y;
			boxEnd.X = e.X;
			boxEnd.Y = e.Y;
		}

		private void viewport_MouseMove(object sender, MouseEventArgs e)
		{
			if (drawingBox)
			{
				boxEnd.X = e.X;
				boxEnd.Y = e.Y;
				updateViewport();
			}
		}

		private void viewport_MouseUp(object sender, MouseEventArgs e)
		{
			drawingBox = false;
			updateViewport();
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
				string filepath = Photos[photoIndex].Remove(Photos[photoIndex].LastIndexOf('.'));
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

		private void prev_Click(object sender, EventArgs e)
		{
			--photoIndex;
		}

		private void next_Click(object sender, EventArgs e)
		{
			++photoIndex;
		}

		private void thumbnail_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < NUM_THUMBNAILS; ++i)
			{
				if (sender == thumbnails[i])
				{
					photoIndex = (thumbnailIndex + i);
					break;
				}
			}
		}

		private void Labeller_KeyUp(object sender, KeyEventArgs e)
		{
			
		}

		private void saveBtn_Click(object sender, EventArgs e)
		{
			if (writeXmlFile())
			{
				++photoIndex;
			}
		}

		private void viewport_KeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (writeXmlFile())
				{
					++photoIndex;
				}
			}
			else if (e.Modifiers.HasFlag(Keys.Control) & (e.KeyCode == Keys.S))
			{
				writeXmlFile();
			}
			else if (e.KeyCode == Keys.Left)
			{
				--photoIndex;
			}
			else if (e.KeyCode == Keys.Right)
			{
				++photoIndex;
			}
		}
	}
}

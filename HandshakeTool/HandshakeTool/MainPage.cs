/*
* FILE			: MainPage.cs
* PROJECT		: Handshake Engine
* PROGRAMMER	: Polytechnica Team - Andy Sgro, Caleb Bolsonello
* FIRST VERSION : March 12, 2021
* DESCRIPTION	: This class is the editor page for the Handshake Tool.
*				  It allows the user to add photos and label them as gestures.
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
using System.Threading;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Diagnostics;

namespace HandshakeTool
{
	/**
	* NAME	  : MainPage
	* PURPOSE : 
	*	- This class is the editor page for the Handshake Tool.
	*	- It allows the user to add photos and label them as gestures.
	*	- It also has the capability to export the images for training.
	*	- This class is often navigated to from the HandshakeTool.cs class,
	*	  uses the File.cs class for fileIO operations, and can direct the user
	*	  to the BatchRelabeller.cs page/class for batch relabelling.
	*/
	public partial class MainPage : UserControl
	{
		#region fields
		// Positions of the thumbnails in the filmstrip
		const int FIRST_THUMB_Y = 10;
		const int THUMB_SPACING = 10;
		const int FIRST_THUMB_X = THUMB_SPACING;
		const int THUMB_WIDTH = 100;
		const int THUMB_HEIGHT = 70;
		int nextThumbX = FIRST_THUMB_X;
		int nextThumbY = FIRST_THUMB_Y;
		int THUMB_PADDING = 2;

		// Specifies when the main viewport displays a bounding box inside itself
		bool showingCross = false;
		bool showingBox = false;
		bool drawingBox = false;
		Point boxStart = new Point();
		Point boxEnd = new Point();

		// Photo panels for the filmstrip
		List<Panel> bigThumbPanels = new List<Panel>();
		List<Panel> smallThumbPanels = new List<Panel>();
		List<PictureBox> thumbImages = new List<PictureBox>();
		public List<string> imgFilepaths = new List<string>();
		private int currentIndex = -1;
		
		// Main viewport / webcam
		private Image<Bgr, byte> mainImage = null;
		private Image<Bgr, byte> boxImage = null;
		private Capture capture = null;

		// These become false if the UI is changing tab/camera
		// without the user's input. It stops some events from triggering.
		private bool userIsChangingTab = true;
		private bool userIsChangingCamera = true;

		/// <summary>
		/// Lets other functions know where the user clicked from.
		/// </summary>
		enum ClickingFrom
		{
			Tab,
			Thumbnail,
			SaveBtn,
			ClearBtn
		}
		#endregion


		/**
		* \brief	Instantiates the Editor page.
		* \param	N/A
		* \return	N/A
		*/
		public MainPage()
		{
			InitializeComponent();
			// Set this to false to protect the event from triggering
			userIsChangingCamera = false;
			cameraIndex.SelectedIndex = 0;
			userIsChangingCamera = true;
			enableCamera();
			fillFilmstrip();
			Program.app.WindowState = FormWindowState.Maximized;
		}


		#region filmstrip
		/**
		* \brief	Fills the filmstrip with images from the Files.ImageFolder.
		* \details	This function fills the imgFilepaths variable.
		* \param	void
		* \return	void
		*/
		public void fillFilmstrip()
		{
			filmstrip.Controls.Clear();
			imgFilepaths.Clear();
			bigThumbPanels.Clear();
			smallThumbPanels.Clear();
			thumbImages.Clear();
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
					showcaseImage(0, ClickingFrom.Thumbnail);
				}
			}
		}


		/**
		* \brief	Appends a photo to the filmstrip.
		* \details	This function also appends to the imgFilepaths variable.
		* \param	string filepath : The image to append.
		* \return	void
		*/
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


		/**
		* \brief	A helper function for appendFilmstrip(). It it nessessary because
		*			the UI needs a to do it in a thread-safe way. This funciton is only
		*			called by appendFilmstrip(), and it simply completes the last
		*			step of the process, there the images are finally appended to the filmstrip.
		*
		* \param	Panel bigPanel	   : A container for the image.
		* \param	Panel smallPanel   : A smaller container, used to keep the aspect ratio the same.
		* \param	PictureBox picture : The image to append.
		*
		* \return	void
		*/
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
		#endregion


		#region viewport_mouse_events
		/**
		* \brief	Erases the cross from the viewport when the
		*			mouse cursor leave it.
		*
		* \param	object sender, EventArgs e : Not used.
		*
		* \return	void
		*/
		private void viewport_MouseLeave(object sender, EventArgs e)
		{
			if (tabControl.SelectedTab == imgInfoTab)
			{
				drawBoundingBox();
			}
		}


		/**
		* \brief	When the user holds the mouse down over the viewport,
		*			display the bounding box.
		*
		* \param	object sender, MouseEventArgs e : Not used.
		*
		* \return	void
		*/
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


		/**
		* \brief	When the user moves the mouse cursor over the viewport,
		*			and the mouse is held down at the same time, then redraw 
		*			the bounding box.
		*
		* \param	object sender, MouseEventArgs e : Not used.
		*
		* \return	void
		*/
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


		/**
		* \brief	Stops redrawing the bounding box when the user
		*			lifts their mouse up.
		*
		* \param	object sender, MouseEventArgs e : Not used.
		*
		* \return	void
		*/
		private void viewport_MouseUp(object sender, MouseEventArgs e)
		{
			drawingBox = false;
			drawBoundingBox();
			ActiveControl = btnSaveXml;
		}


		/**
		* \brief	Displays the cross over the mouse cursor when the
		*			cursor enters the viewport frame.
		*
		* \param	object sender, EventArgs e : Not used.
		*
		* \return	void
		*/
		private void viewport_MouseEnter(object sender, EventArgs e)
		{
			if (tabControl.SelectedTab == imgInfoTab)
			{
				showingCross = true;
			}
		}
		#endregion


		#region viewport_graphics
		/**
		* \brief	When the user clicks on a thumbnail, display the image in the viewport.
		* \param	object sender, EventArgs e : Not used.
		* \return	void
		*/
		private void thumb_Click(object sender, EventArgs e)
		{
			PictureBox picture = (PictureBox)sender;
			int index = int.Parse(picture.Name.Remove(0, "thumbPanel".Length));
			showcaseImage(index, ClickingFrom.Thumbnail);

			userIsChangingTab = false;
			tabControl.SelectedTab = imgInfoTab;
			userIsChangingTab = true;
		}


		/**
		* \brief	Draws a cross on the viewport, where the cursor is.
		*
		* \param	Point cursor : where the cursor is.
		*
		* \return	void
		*/
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


		/**
		* \brief	Draws a bounding box on the viewport.
		* \param	void
		* \return	void
		*/
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


		/**
		* \brief	Converts the screen coordinates to image viewport coordinates.
		*
		* \details	Used when the cursor's position needs to be drawn on a image
		*			that has been streched vertically and horizontally.
		*
		* \param	Point pt : The screen-based coordinates of the cursor.
		*
		* \return	Returns the image-based coordinates
		*/
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


		/**
		 * \brief	Displays an image in the viewport.
		 * 
		 * \param	int index				  : The index of the image to display,
		 *									    from the imgFilepaths array.
		 * \param	ClickingFrom clickingFrom : Where the user is clicking from.
		 * 
		 * \return	void
		 */
		private void showcaseImage(int index, ClickingFrom clickingFrom)
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

			if (xmlContent == null)
			{
				updateGesturePrompt.Text = "Add New Gesture:";
				showingBox = (!clearBox.Checked & (clickingFrom == ClickingFrom.SaveBtn));
			}
			else
			{
				bool hasBox = (xmlContent.IndexOf("<bndbox>") >= 0);
				updateGesturePrompt.Text = "Update Gesture:";
				labelName = getXmlField(xmlContent, "<name>", "</name>");

				// if there isn't a box, only show it if the user has uncheck the 'clear' button and is saving their previous image
				if (!hasBox)
				{
					showingBox = (!clearBox.Checked & (clickingFrom == ClickingFrom.SaveBtn));
				}
				// if there is a box, always show it
				else
				{
					showingBox = getXmlBox(xmlContent);
				}
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
			filmstrip.ScrollControlIntoView(bigThumbPanels[index]);

			// fill title bar
			Program.app.Text = imgFilepaths[index]
				.Remove(0, imgFilepaths[index].LastIndexOf('\\') + 1)
				+ " (" + (index + 1) + '/' + imgFilepaths.Count + ") - Handshake Tool";
		}
		#endregion


		#region xml
		/**
		* \brief	Clears the gesture.
		*
		* \details	Removes the bounding box and deletes the corresponding XML file.
		*
		* \param	object sender, EventArgs e : Not used.
		*
		* \return	void
		*/
		private void clearGesture(object sender, EventArgs e)
		{
			showingBox = false;
			string xmliFilepath = Files.ChangeExtension(imgFilepaths[currentIndex], ".xml");
			File.Delete(xmliFilepath);
			showcaseImage(currentIndex, ClickingFrom.ClearBtn);

		}


		/**
		* \brief	Saves an xml file for the image, which contains the label and bounding box.
		* \details	Triggered by the 'Save Gesture' button.
		* \param	void
		* \return	void
		*/
		private void btnSaveXml_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(newLabel.Text))
			{
				prompt("Please Enter a gesture name.");
			}
			else
			{
				writeXmlFile(currentIndex, newLabel.Text);
				showcaseImage(currentIndex + 1, ClickingFrom.SaveBtn);
			}
		}


		/**
		* \brief	Saves an xml file for the image, which contains the label and bounding box.
		* \details	Triggered by the 'Save Gesture' button.
		* \param	void
		* \return	void
		*/
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
					+ "\r\n\t\t<depth>1</depth>"
					+ "\r\n\t</size>"
					+ "\r\n\t<segmented>0</segmented>"
					+ "\r\n\t<object>"
					+ "\r\n\t\t<name>" + label.Trim() + "</name>"
					+ "\r\n\t\t<pose>Unspecified</pose>"
					+ "\r\n\t\t<truncated>0</truncated>"
					+ "\r\n\t\t<difficult>0</difficult>";

				if (showingBox)
				{
					// swap mins and maxes if nessessary
					int xmin = 0;
					int xmax = 0;
					int ymin = 0;
					int ymax = 0;

					if (boxStart.X <= boxEnd.X)
					{
						xmin = boxStart.X;
						xmax = boxEnd.X;
					}
					else
					{
						xmin = boxEnd.X;
						xmax = boxStart.X;
					}

					if (boxStart.Y <= boxEnd.Y)
					{
						ymin = boxStart.Y;
						ymax = boxEnd.Y;
					}
					else
					{
						ymin = boxEnd.Y;
						ymax = boxStart.Y;
					}

					xmlContent += "\r\n\t\t<bndbox>"
						+ "\r\n\t\t\t<xmin>" + xmin + "</xmin>"
						+ "\r\n\t\t\t<ymin>" + ymin + "</ymin>"
						+ "\r\n\t\t\t<xmax>" + xmax + "</xmax>"
						+ "\r\n\t\t\t<ymax>" + ymax + "</ymax>"
						+ "\r\n\t\t</bndbox>";
				}

				xmlContent += "\r\n\t</object>"
					+ "\r\n</annotation>";

				File.WriteAllText(filepath + ".xml", xmlContent);
				return true;
			}
			return false;
		}


		/**
		* \brief	Gets content of the XML file.
		*
		* \param	int index : The index of the image that corresponds to the
		*						XML that we're trying to read.
		*
		* \return	Returns the XML content as a string, or returns
		*			null if there is no XML file.
		*/
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


		/**
		* \brief	Extracts the bounding box from an XML file.
		*
		* \param	string xmlContent : The xml content to extract from.
		*
		* \return	Retruns true if a bounding box was successfully extracted.
		*			Returns false if there was no bounding box in the XML content,
		*			or if the XML content was empty / null.
		*/
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


		/**
		* \brief	Extracts a field from XML content.
		*
		* \param	string xmlContent : The XML content to extract from.
		* \param	string startTag	  : The start tag of the XML field.
		* \param	string endTag	  : The end tag of the XML field.
		*
		* \return	Returns the XML field as a string.
		*/
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
		#endregion


		#region viewport_streaming
		/**
		* \brief	When the user changes the camera index via the dropdown UI element,
		*			turn off the current webcam and turn on the next one.
		*
		* \details	restartCamera() looks at the index of the dropdown UI element,
		*			so this function doesn't have to.
		*
		* \param	object sender, EventArgs e : Not used.
		*
		* \return	void
		*/
		private void changeCamera(object sender, EventArgs e)
		{
			if (userIsChangingCamera)
			{
				restartCamera();
			}
		}


		/**
		* \brief	When the user navigates to the webcam tab, then activate the
		*			webcam and start streaming its video feed into the viewport.
		*			When the user navigates to the 'Image Info' tab, have the
		*			viewport display the seclected image on their harddrive.
		*
		* \param	object sender, EventArgs e : Not used.
		*
		* \return	void
		*/
		private void tabChanged(object sender, EventArgs e)
		{

			if (tabControl.SelectedTab == cameraTab)
			{
				if (userIsChangingTab & (smallThumbPanels.Count > 0))
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
					prompt("Please add an image first.");
					tabControl.SelectedTab = cameraTab;
				}
				else
				{
					if (userIsChangingTab)
					{
						showcaseImage(currentIndex, ClickingFrom.Tab);
					}
					viewport.Cursor = Cursors.Cross;
					viewport.MouseDown += viewport_MouseDown;
					viewport.MouseUp += viewport_MouseUp;
					viewport.MouseMove += viewport_MouseMove;
				}
			}
		}


		/**
		* \brief	Disables and re-enables the webcam.
		* \param	void
		* \return	void
		*/
		private void restartCamera()
		{
			disableCamera();
			enableCamera();
		}


		/**
		* \brief	Enables the webcam and streams its video feed to the viewport
		* \param	void
		* \return	void
		*/
		private void enableCamera()
		{
			capture = new Capture(cameraIndex.SelectedIndex);
			Application.Idle += streaming;
		}


		/**
		* \brief	Disables the webcam, stopping its stream to the viewport
		* \param	void
		* \return	void
		*/
		private void disableCamera()
		{
			Application.Idle -= streaming;
			capture.Stop();
			capture.Dispose();
		}


		/**
		* \brief	Displays the webcam video feed in the viewport.
		* \param	object sender, EventArgs e : Not used.
		* \return	void
		*/
		private void streaming(object sender, EventArgs e)
		{
			mainImage = capture.QueryFrame().ToImage<Bgr, byte>();
			Bitmap bmp = mainImage.Bitmap;
			viewport.Image = bmp;
		}
		#endregion


		#region saving_photos
		/**
		* \brief	Takes a photo when the user clicks the 'Take Photo' button.
		* \param	object sender, EventArgs e : Not used.
		* \return	void
		*/
		private void shootBtn_Click(object sender, EventArgs e)
		{
			Task.Run(() => takePhotos());
		}


		/**
		* \brief	Sets the progress bar's value in a thread safe way.
		*
		* \details	The progress bar's value only changes when the user
		*			is taking a batch of photos.
		*
		* \param	int value : The value to set the progress bar to.
		*
		* \return	void
		*/
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


		/**
		* \brief	Takes a batch of photos
		* \details	The parameters are specified by user input in the UI elements.
		* \param	See above.
		* \return	void
		*/
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


		/**
		* \brief	Saves an image.
		* \details	The image's filename will have its date/time, to ensure it's unique.
		* \param	void
		* \return	void
		*/
		private void saveImg()
		{
			DateTime now = DateTime.Now;
			string date = now.ToString("s").Replace('T', '_').Replace(':', '-') + '-' + now.ToString("ffff");
			string filepath = Files.ImageFolder + date + ".jpg";
			mainImage.Save(filepath);
			appendFilmstrip(filepath);
			writeXmlFile(imgFilepaths.Count - 1, optionalGesture.Text);
		}
		#endregion


		#region labels
		/**
		* \brief	Shows project stats to the user, including:
		*				- Number of images
		*				- Number of unique gestures
		*				- What each gesture is called
		*				- And how many of each gesture there is
		*
		* \param	object sender, EventArgs e : Not used.
		*
		* \return	void
		*/
		private void showStats(object sender, EventArgs e)
		{
			Dictionary<string, int> labels = getLabelStats();

			string stats = "Images: " + imgFilepaths.Count
				+ "\nUnique Gestures: " + labels.Count;

			if (labels.Count > 0)
			{
				stats += "\n\nGesture Stats:";
				foreach (KeyValuePair<string, int> label in labels)
				{
					stats += "\n     " + label.Value + " - " + label.Key;
				}
			}
			prompt(stats);
		}


		/**
		* \brief	Combs through the XML files and tallies the number of
		*			files that pertain to label.
		*
		* \param	void
		*
		* \return	Returns a dictionary, where the keys represent every label,
		*			each value corresponds to the sum of each key.
		*/
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


		/**
		* \brief	Opens the Relabeller / Find and Replace dialog.
		* \param	object sender, EventArgs e : Not used.
		* \return	void
		*/
		private void batchRelabel(object sender, EventArgs e)
		{
			Relabeller relabeller = new Relabeller();

			// Pause the camera while we show the dialog
			if (tabControl.SelectedTab == cameraTab)
			{
				disableCamera();
				relabeller.ShowDialog();
				enableCamera();
			}
			else
			{
				relabeller.ShowDialog();
			}

			// When the user closes the dialog, update the label text in the UI
			// to match what it's been relabelled to
			string xmlFilepath = Files.ChangeExtension(imgFilepaths[currentIndex], ".xml");
			if (File.Exists(xmlFilepath))
			{
				string name = getXmlField(File.ReadAllText(xmlFilepath), "<name>", "</name>");
				if (name != null)
				{
					oldLabel.Text = name;
				}
			}
		}


		/**
		* \brief	Creates a label map.
		*
		* \details	This function only exists so that it can connect to the UI
		*			as an event through its parameters.
		*
		* \param	object sender, EventArgs e : Not used.
		*
		* \return	void
		*/
		private void createLabelMap(object sender, EventArgs e)
		{
			createLabelMap();
		}


		/**
		* \brief	Creates a label map.
		*
		* \details	This function differs from createLabelMap() because of its
		*			parameters and return value. This is called by other functions,
		*			wheras the other function isn't.
		*
		* \param	void
		*
		* \return	Number of labels.
		*/
		private int createLabelMap()
		{
			string[] labels = getLabelStats().Keys.ToArray();
			string labelMapContent = "";

			for (int i = 0; i < labels.Length; ++i)
			{
				labelMapContent += "item {\n\tid: " + (i + 1) + "\n\tname: '"
					+ labels[i] + "\'\n}\n\n";
			}

			File.WriteAllText(Files.AnnotationsFolder + "label_map.pbtxt", labelMapContent);
			Process.Start(Files.AnnotationsFolder.FullName);
			return labels.Length;
		}
		#endregion


		#region exporting
		/**
		* \brief	Exports a training environment.
		*
		* \details	The training environment is used by Tensorflow to train the model.
		*
		* \param	object sender, EventArgs e : Not used.
		*
		* \return	void
		*/
		private void createTrainingEnvironmentToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string exePath = Path.GetDirectoryName(
				System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6) + "\\MachineLearning\\";

			// create label map
			int labelsCount = createLabelMap();

			// copy model
			DirectoryInfo newModel = new DirectoryInfo(Files.ProjectFolder + "Model\\");
			newModel.Create();

			// edit and save pipeline.config
			string pipelineConfig = File.ReadAllText(exePath + "Model\\pipeline.config");
			const string NUM_CLASSES_STR = "num_classes: ";
			int numClassesIndex = pipelineConfig.IndexOf(NUM_CLASSES_STR) + NUM_CLASSES_STR.Length;
			pipelineConfig = pipelineConfig.Insert(numClassesIndex, labelsCount.ToString());
			File.WriteAllText(newModel + "pipeline.config", pipelineConfig);

			// copy pre-trained model
			Files.CopyDirectory(exePath + "Pretrained-Model", Files.ProjectFolder + "Pretrained-Model", true);

			// copy scripts
			File.Copy(exePath + "1-generate-tf-record.py", Files.ProjectFolder + "1-generate-tf-record.py", true);
			File.Copy(exePath + "2-train.py", Files.ProjectFolder + "2-train.py", true);
			File.Copy(exePath + "3-export.py", Files.ProjectFolder + "3-export.py", true);
			File.Copy(exePath + "README.txt", Files.ProjectFolder + "README.txt", true);
			File.Copy(exePath + "real-time-detection.py", Files.ProjectFolder + "real-time-detection.py", true);
			File.Copy(exePath + "test-gestures.py", Files.ProjectFolder + "test-gestures.py", true);

			Process.Start(Files.ProjectFolder.FullName);
		}


		/**
		* \brief	Exports the photos and XML files to the 'Images/Train' and 'Images/Test' folders.
		*
		* \details	The images are grey-scaled and are only copied if they have an XML file
		*			that corresponds to it. 10% of valid images are copied to the 'Test'
		*			folder, wheras the other 90% are copied to the 'Train' folder.
		*
		* \param	object sender, EventArgs e : Not used.
		*
		* \return	void
		*/
		private void exportImagesForTraining(object sender, EventArgs e)
		{
			int i = 0;
			DialogResult confirmResult = DialogResult.Yes;

			string exportedFolder = Files.ImageFolder + "Exported" + '\\';
			if (Directory.Exists(exportedFolder))
			{
				confirmResult = MessageBox.Show("This operation will overwrite the Images\\Exported folder. Are you sure you want to continue?",
									 "Warning", MessageBoxButtons.YesNo);
			}
			else
			{
				Directory.CreateDirectory(exportedFolder);
			}

			if (confirmResult == DialogResult.Yes)
			{
				// delete everything in the aggregated folder
				foreach (string folder in Directory.GetDirectories(exportedFolder))
				{
					Directory.Delete(folder, true);
				}

				// add train and test folders
				string trainFolder = exportedFolder + "Train\\";
				string testFolder = exportedFolder + "Test\\";
				Directory.CreateDirectory(trainFolder);
				Directory.CreateDirectory(testFolder);

				// fill the aggregated folder
				Dictionary<int, FileInfo> xmlFilepathInfos = new Dictionary<int, FileInfo>();

				foreach (string imgFilepath in imgFilepaths)
				{
					string xmlFilepath = Files.ChangeExtension(imgFilepath, ".xml");
					if (File.Exists(xmlFilepath))
					{
						string xmlContent = File.ReadAllText(xmlFilepath);
						int nameIndex = xmlContent.IndexOf("<name>");
						int bndboxIndex = xmlContent.IndexOf("<bndbox>");

						if ((nameIndex >= 0) & (bndboxIndex >= 0))
						{
							string baseName = imgFilepath.Remove(imgFilepath.LastIndexOf('.'))
								.Remove(0, imgFilepath.LastIndexOf('\\') + 1);
							string newXmlFilepath = Files.ImageFolder.FullName + "Exported\\";
							string newImgFilepath = Files.ImageFolder.FullName + "Exported\\";

							if ((i++ % 10) == 0)
							{
								newXmlFilepath += "Test\\" + baseName + ".xml";
								newImgFilepath += "Test\\" + baseName + ".jpg";
							}
							else
							{
								newXmlFilepath += "Train\\" + baseName + ".xml";
								newImgFilepath += "Train\\" + baseName + ".jpg";
							}

							File.Copy(xmlFilepath, newXmlFilepath, true);
							Image<Bgr, byte> image = new Image<Bgr, byte>(imgFilepath);
							Image<Gray, byte> grey = new Image<Gray, byte>(image.Bitmap);
							grey.Save(newImgFilepath);
							//File.Copy(imgFilepath, newImgFilepath, true);
						}
					}
				}

				if (i > 0)
				{
					Process.Start(exportedFolder);
				}
				else
				{
					prompt("The images must be labelled before they can be aggregated.");
				}
			}
		}


		/**
		* \brief	Iterates through each image, copying them into auto-generated
		*			folders that match their label name.
		*
		* \param	object sender, EventArgs e : Not used.
		*
		* \return	void
		*/
		private void separateImagesIntoFolders(object sender, EventArgs e)
		{
			DialogResult confirmResult = DialogResult.Yes;

			string aggregatedFolder = Files.ImageFolder + "Aggregated" + '\\';
			if (Directory.Exists(aggregatedFolder))
			{
				confirmResult = MessageBox.Show("This operation will overwrite the Images\\Aggregated folder. Are you sure you want to continue?",
									 "Warning", MessageBoxButtons.YesNo);
			}
			else
			{
				Directory.CreateDirectory(aggregatedFolder);
			}

			if (confirmResult == DialogResult.Yes)
			{
				// delete everything in the aggregated folder
				foreach (string folder in Directory.GetDirectories(aggregatedFolder))
				{
					Directory.Delete(folder, true);
				}

				// fill the aggregated folder
				FileInfo[] xmlFilepathInfos = Files.ImageFolder.GetFiles("*.xml");

				if (xmlFilepathInfos.Length <= 0)
				{
					prompt("The images must be labelled before they can be aggregated.");
				}
				else
				{
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
							string filename = Files.GetFilename(xmlFilepath);
							File.Copy(xmlFilepath, childFolder + filename + ".xml", true);
							string imgFilepath = xmlFilepath.Remove(xmlFilepath.LastIndexOf('.') + 1) + "jpg";
							File.Copy(imgFilepath, childFolder + filename + ".jpg");
						}
					}
					Process.Start(aggregatedFolder);
				}
			}
		}
		#endregion


		#region misc
		/**
		* \brief	Opens the project folder in windows explorer.
		* \detail	Called when the user clicks the 'Open Project Folder' menu item.
		* \param	object sender, EventArgs e : Not used.
		* \return	void
		*/
		private void openProjectFolder(object sender, EventArgs e)
		{
			Process.Start(Files.ProjectFolder.FullName);
		}


		/**
		* \brief	Exits the program
		* \details	Called when the user clicks the 'Close' menu item.
		* \param	object sender, EventArgs e : Not used.
		* \return	void
		*/
		private void close(object sender, EventArgs e)
		{
			Application.Exit();
		}


		/**
		* \brief	Starts a new project.
		* \details	If the user confirms the new project, then the filmstrip is cleared.
		* \param	object sender, EventArgs e : Not used.
		* \return	void
		*/
		private void newProject(object sender, EventArgs e)
		{
			if (Files.NewProject())
			{
				fillFilmstrip();
			}
		}


		/**
		* \brief	Opens an existing project.
		*
		* \details	If the user confirms the load operation, then the filmstrip is cleared
		*			and refilled with teh images in the loaded project's image folder.
		*
		* \param	object sender, EventArgs e : Not used.
		*
		* \return	void
		*/
		private void openProject(object sender, EventArgs e)
		{
			if (Files.OpenProject())
			{
				fillFilmstrip();
			}
		}



		/**
		* \brief	Clamps a float and converts it to an int.
		*
		* \param	float input	: The number to clamp.
		* \param	int min		: The minimum allowable value.
		* \param	int max		: The maximum allowable value.
		*
		* \return	Returns a clamped int.
		*/
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


		/**
		* \brief	A wrapper for MessageBox.Show(), where the webcam is disabled
		*			during the duration that the prompt is present.
		*
		* \param	string msg : The message to put in MessageBox.Show().
		*
		* \return	void
		*/
		private void prompt(string msg)
		{
			if (tabControl.SelectedTab == cameraTab)
			{
				disableCamera();
				MessageBox.Show(msg);
				enableCamera();
			}
			else
			{
				MessageBox.Show(msg);
			}
		}
		#endregion

	}
}

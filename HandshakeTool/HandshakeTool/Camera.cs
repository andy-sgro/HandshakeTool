using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace HandshakeTool
{
	public partial class Camera : UserControl
	{
		private Capture capture = null;
		private int cameraIndex = 0;
		private Image<Bgr, byte> img = null;
		public HandshakeTool mainPage = null;

		public Camera()
		{
			InitializeComponent();
		}

		private void camera_Load(object sender, EventArgs e)
		{
			cameraIndex = (int)cameraIndexPicker.Value;
			capture = new Capture(cameraIndex);
			remainingShots.Text = "";
			Init();
		}

		public void Delete()
		{
			Application.Idle -= streaming;
			capture.Stop();
		}

		public void Init()
		{
			Application.Idle += streaming;
		}

		private void streaming(object sender, System.EventArgs e)
		{
			img = capture.QueryFrame().ToImage<Bgr, byte>();
			Bitmap bmp = img.Bitmap;
			viewport.Image = bmp;
		}


		private void cameraIndexPicker_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				capture = new Capture((int)cameraIndexPicker.Value);
				cameraIndex = (int)cameraIndexPicker.Value;
			}
			catch
			{

			}
		}


		private void shootBtn_Click(object sender, EventArgs e)
		{
			if (mainPage.ImageFolder == null)
			{
				mainPage.OpenImageFolder(null, null);
			}
			if (mainPage.ImageFolder != null)
			{
				Task.Run(() => takePhotos());
			}
		}

		delegate void SetTextCallback(string text);

		private void SetRemainingPhotosText(string text)
		{
			// InvokeRequired required compares the thread ID of the
			// calling thread to the thread ID of the creating thread.
			// If these threads are different, it returns true.
			if (remainingShots.InvokeRequired)
			{
				SetTextCallback d = new SetTextCallback(SetRemainingPhotosText);
				Invoke(d, new object[] { text });
			}
			else
			{
				remainingShots.Text = text;
			}
		}


		private void takePhotos()
		{
			for (int remainingPhotos = (int)numberOfShots.Value;
				remainingPhotos > 0; --remainingPhotos)
			{
				SetRemainingPhotosText(remainingPhotos + " shots remaining");
				Thread.Sleep((int)(timePerShot.Value * 1000));
				saveImg();
			}

			remainingShots.Text = "";
		}

		private void saveImg()
		{
			DateTime now = DateTime.Now;
			string date = now.ToString("s").Replace('T', '_').Replace(':', '-') + '-' + now.ToString("ffff");
			string filepath = mainPage.ImageFolder + date + ".jpg";
			img.Save(filepath);
		}
	}
}

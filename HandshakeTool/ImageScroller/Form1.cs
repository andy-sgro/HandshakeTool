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

namespace ImageScroller
{
	public partial class Form1 : Form
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



        public Form1()
		{
			InitializeComponent();
            LoadImages();

            foreach(PictureBox picture in thumbImages)
			{
                //picture.Click = 
			}
            fillImage(0);
        }

        private void fillImage(int index)
		{
            pictureBox.Image = Image.FromFile(AllImageFileNames[index]);
        }

        public void LoadImages()
        {
            DirectoryInfo Folder;
            DialogResult result = this.folderBrowserDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                Folder = new DirectoryInfo(folderBrowserDlg.SelectedPath);


                var imageFiles = Folder.GetFiles("*.jpg")
                      .Concat(Folder.GetFiles("*.gif"))
                      .Concat(Folder.GetFiles("*.png"))
                      .Concat(Folder.GetFiles("*.jpeg"))
                      .Concat(Folder.GetFiles("*.bmp")).ToArray(); // Here we filter all image files 
                filmStrip.Controls.Clear();
                if (imageFiles.Length > 0)
                {
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
            }
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

            filmStrip.Controls.Add(bigThumbPanels[imageIndex]);
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
	}
}

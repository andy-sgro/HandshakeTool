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
        private FolderBrowserDialog folderBrowserDlg = new System.Windows.Forms.FolderBrowserDialog();
        private bool imageselected = false;
        int TotalimageFiles = 0;
        int locX = 40;
        int locY = 10;
        PictureBox[] ctrl;
        public string[] AllImageFileNames = null;
        int sizeWidth = 130;
        private int CurrentIndex = 0;
        private int StartIndex = 0;
        private int LastIndex = 0;
        int sizeHeight = 130;



        public Form1()
		{
			InitializeComponent();
            LoadImages();

            foreach(PictureBox picture in ctrl)
			{
                //picture.Click = 
			}
            fillImage(0);
        }

        private void fillImage(int index)
		{
            picImageSlide.Image = Image.FromFile(AllImageFileNames[index]);
        }

        public void LoadImages()
        {
            DirectoryInfo Folder;
            DialogResult result = this.folderBrowserDlg.ShowDialog();
            imageselected = false;
            if (result == DialogResult.OK)
            {
                Folder = new DirectoryInfo(folderBrowserDlg.SelectedPath);


                var imageFiles = Folder.GetFiles("*.jpg")
                      .Concat(Folder.GetFiles("*.gif"))
                      .Concat(Folder.GetFiles("*.png"))
                      .Concat(Folder.GetFiles("*.jpeg"))
                      .Concat(Folder.GetFiles("*.bmp")).ToArray(); // Here we filter all image files 
                pnlThumb.Controls.Clear();
                if (imageFiles.Length > 0)
                {
                    imageselected = true;
                    TotalimageFiles = imageFiles.Length;
                }
                else
                {
                    return;
                }
                int locnewX = locX;
                int locnewY = locY;

                ctrl = new PictureBox[TotalimageFiles];
                AllImageFileNames = new String[TotalimageFiles];
                int imageindexs = 0;
                foreach (FileInfo img in imageFiles)
                {
                    AllImageFileNames[imageindexs] = img.FullName;
                    loadImagestoPanel(img.Name, img.FullName, locnewX, locnewY, imageindexs);
                    locnewX = locnewX + sizeWidth + 10;
                    imageindexs = imageindexs + 1;

                }
                CurrentIndex = 0;
                StartIndex = 0;
                LastIndex = 0;
            }
        }

        private void loadImagestoPanel(String imageName, String ImageFullName, int newLocX, int newLocY, int imageIndex)
        {
            ctrl[imageIndex] = new PictureBox();
            ctrl[imageIndex].Name = "thumbnail" + imageIndex;
            ctrl[imageIndex].Image = Image.FromFile(ImageFullName);
            ctrl[imageIndex].BackColor = Color.Black;
            ctrl[imageIndex].Location = new Point(newLocX, newLocY);
            ctrl[imageIndex].Size = new System.Drawing.Size(sizeWidth - 30, sizeHeight - 60);
            ctrl[imageIndex].BorderStyle = BorderStyle.None;
            ctrl[imageIndex].SizeMode = PictureBoxSizeMode.StretchImage;
            ctrl[imageIndex].MouseClick += fillImage;
            pnlThumb.Controls.Add(ctrl[imageIndex]);


        }

		private void fillImage(object sender, EventArgs e)
		{
            int index = int.Parse(((PictureBox)sender).Name.Remove(0, "thumbnail".Length));
            fillImage(index);
        }
	}
}

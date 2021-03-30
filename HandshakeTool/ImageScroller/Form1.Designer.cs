
namespace ImageScroller
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pnlThumb = new System.Windows.Forms.Panel();
			this.picImageSlide = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picImageSlide)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlThumb
			// 
			this.pnlThumb.AutoScroll = true;
			this.pnlThumb.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlThumb.Location = new System.Drawing.Point(0, 498);
			this.pnlThumb.Name = "pnlThumb";
			this.pnlThumb.Size = new System.Drawing.Size(1185, 224);
			this.pnlThumb.TabIndex = 0;
			// 
			// picImageSlide
			// 
			this.picImageSlide.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picImageSlide.Location = new System.Drawing.Point(0, 0);
			this.picImageSlide.Name = "picImageSlide";
			this.picImageSlide.Size = new System.Drawing.Size(1185, 498);
			this.picImageSlide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picImageSlide.TabIndex = 1;
			this.picImageSlide.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1185, 722);
			this.Controls.Add(this.picImageSlide);
			this.Controls.Add(this.pnlThumb);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.picImageSlide)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlThumb;
		private System.Windows.Forms.PictureBox picImageSlide;
	}
}


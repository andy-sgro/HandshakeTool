
namespace HandshakeTool
{
	partial class Labeller
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Labeller));
			this.viewport = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label = new System.Windows.Forms.TextBox();
			this.thumbnail0 = new System.Windows.Forms.PictureBox();
			this.thumbnail1 = new System.Windows.Forms.PictureBox();
			this.thumbnail2 = new System.Windows.Forms.PictureBox();
			this.deleteBtn = new System.Windows.Forms.Button();
			this.thumbnail3 = new System.Windows.Forms.PictureBox();
			this.thumbnail4 = new System.Windows.Forms.PictureBox();
			this.nextBtn = new System.Windows.Forms.PictureBox();
			this.prevBtn = new System.Windows.Forms.PictureBox();
			this.saveBtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.viewport)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.thumbnail0)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.thumbnail1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.thumbnail2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.thumbnail3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.thumbnail4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nextBtn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.prevBtn)).BeginInit();
			this.SuspendLayout();
			// 
			// viewport
			// 
			this.viewport.Cursor = System.Windows.Forms.Cursors.Cross;
			this.viewport.Location = new System.Drawing.Point(252, 23);
			this.viewport.Name = "viewport";
			this.viewport.Size = new System.Drawing.Size(1062, 583);
			this.viewport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.viewport.TabIndex = 0;
			this.viewport.TabStop = false;
			this.viewport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.viewport_MouseDown);
			this.viewport.MouseMove += new System.Windows.Forms.MouseEventHandler(this.viewport_MouseMove);
			this.viewport.MouseUp += new System.Windows.Forms.MouseEventHandler(this.viewport_MouseUp);
			this.viewport.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.viewport_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(19, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "Label:";
			// 
			// label
			// 
			this.label.Location = new System.Drawing.Point(22, 59);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(192, 22);
			this.label.TabIndex = 2;
			// 
			// thumbnail0
			// 
			this.thumbnail0.Cursor = System.Windows.Forms.Cursors.Hand;
			this.thumbnail0.Location = new System.Drawing.Point(97, 632);
			this.thumbnail0.Name = "thumbnail0";
			this.thumbnail0.Size = new System.Drawing.Size(189, 134);
			this.thumbnail0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.thumbnail0.TabIndex = 3;
			this.thumbnail0.TabStop = false;
			this.thumbnail0.Click += new System.EventHandler(this.thumbnail_Click);
			// 
			// thumbnail1
			// 
			this.thumbnail1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.thumbnail1.Location = new System.Drawing.Point(327, 635);
			this.thumbnail1.Name = "thumbnail1";
			this.thumbnail1.Size = new System.Drawing.Size(202, 134);
			this.thumbnail1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.thumbnail1.TabIndex = 4;
			this.thumbnail1.TabStop = false;
			this.thumbnail1.Click += new System.EventHandler(this.thumbnail_Click);
			// 
			// thumbnail2
			// 
			this.thumbnail2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.thumbnail2.Location = new System.Drawing.Point(569, 635);
			this.thumbnail2.Name = "thumbnail2";
			this.thumbnail2.Size = new System.Drawing.Size(198, 133);
			this.thumbnail2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.thumbnail2.TabIndex = 5;
			this.thumbnail2.TabStop = false;
			this.thumbnail2.Click += new System.EventHandler(this.thumbnail_Click);
			// 
			// deleteBtn
			// 
			this.deleteBtn.BackColor = System.Drawing.Color.Gray;
			this.deleteBtn.FlatAppearance.BorderSize = 0;
			this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.deleteBtn.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.deleteBtn.ForeColor = System.Drawing.Color.White;
			this.deleteBtn.Location = new System.Drawing.Point(23, 576);
			this.deleteBtn.Name = "deleteBtn";
			this.deleteBtn.Size = new System.Drawing.Size(136, 30);
			this.deleteBtn.TabIndex = 6;
			this.deleteBtn.Text = "Delete Image";
			this.deleteBtn.UseVisualStyleBackColor = false;
			// 
			// thumbnail3
			// 
			this.thumbnail3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.thumbnail3.Location = new System.Drawing.Point(804, 634);
			this.thumbnail3.Name = "thumbnail3";
			this.thumbnail3.Size = new System.Drawing.Size(200, 133);
			this.thumbnail3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.thumbnail3.TabIndex = 7;
			this.thumbnail3.TabStop = false;
			this.thumbnail3.Click += new System.EventHandler(this.thumbnail_Click);
			// 
			// thumbnail4
			// 
			this.thumbnail4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.thumbnail4.Location = new System.Drawing.Point(1037, 635);
			this.thumbnail4.Name = "thumbnail4";
			this.thumbnail4.Size = new System.Drawing.Size(202, 133);
			this.thumbnail4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.thumbnail4.TabIndex = 8;
			this.thumbnail4.TabStop = false;
			this.thumbnail4.Click += new System.EventHandler(this.thumbnail_Click);
			// 
			// nextBtn
			// 
			this.nextBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.nextBtn.Image = ((System.Drawing.Image)(resources.GetObject("nextBtn.Image")));
			this.nextBtn.InitialImage = null;
			this.nextBtn.Location = new System.Drawing.Point(1276, 632);
			this.nextBtn.Name = "nextBtn";
			this.nextBtn.Size = new System.Drawing.Size(38, 134);
			this.nextBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.nextBtn.TabIndex = 9;
			this.nextBtn.TabStop = false;
			this.nextBtn.Click += new System.EventHandler(this.next_Click);
			// 
			// prevBtn
			// 
			this.prevBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.prevBtn.Image = ((System.Drawing.Image)(resources.GetObject("prevBtn.Image")));
			this.prevBtn.Location = new System.Drawing.Point(22, 633);
			this.prevBtn.Name = "prevBtn";
			this.prevBtn.Size = new System.Drawing.Size(40, 134);
			this.prevBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.prevBtn.TabIndex = 10;
			this.prevBtn.TabStop = false;
			this.prevBtn.Click += new System.EventHandler(this.prev_Click);
			// 
			// saveBtn
			// 
			this.saveBtn.BackColor = System.Drawing.Color.Gray;
			this.saveBtn.FlatAppearance.BorderSize = 0;
			this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.saveBtn.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.saveBtn.ForeColor = System.Drawing.Color.White;
			this.saveBtn.Location = new System.Drawing.Point(22, 110);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new System.Drawing.Size(136, 30);
			this.saveBtn.TabIndex = 11;
			this.saveBtn.Text = "Save && Continue";
			this.saveBtn.UseVisualStyleBackColor = false;
			this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
			// 
			// Labeller
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.Controls.Add(this.saveBtn);
			this.Controls.Add(this.prevBtn);
			this.Controls.Add(this.nextBtn);
			this.Controls.Add(this.thumbnail4);
			this.Controls.Add(this.thumbnail3);
			this.Controls.Add(this.deleteBtn);
			this.Controls.Add(this.thumbnail2);
			this.Controls.Add(this.thumbnail1);
			this.Controls.Add(this.thumbnail0);
			this.Controls.Add(this.label);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.viewport);
			this.Name = "Labeller";
			this.Size = new System.Drawing.Size(1336, 800);
			this.Load += new System.EventHandler(this.Labeller_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Labeller_KeyUp);
			((System.ComponentModel.ISupportInitialize)(this.viewport)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.thumbnail0)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.thumbnail1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.thumbnail2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.thumbnail3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.thumbnail4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nextBtn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.prevBtn)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox viewport;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox label;
		private System.Windows.Forms.PictureBox thumbnail0;
		private System.Windows.Forms.PictureBox thumbnail1;
		private System.Windows.Forms.PictureBox thumbnail2;
		private System.Windows.Forms.Button deleteBtn;
		private System.Windows.Forms.PictureBox thumbnail3;
		private System.Windows.Forms.PictureBox thumbnail4;
		private System.Windows.Forms.PictureBox nextBtn;
		private System.Windows.Forms.PictureBox prevBtn;
		private System.Windows.Forms.Button saveBtn;
	}
}

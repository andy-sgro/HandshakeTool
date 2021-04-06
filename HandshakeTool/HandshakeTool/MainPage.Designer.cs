
namespace HandshakeTool
{
	partial class MainPage
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
			this.components = new System.ComponentModel.Container();
			this.filmstrip = new System.Windows.Forms.Panel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.machineLearningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tabControl = new System.Windows.Forms.TabControl();
			this.cameraTab = new System.Windows.Forms.TabPage();
			this.cameraIndex = new System.Windows.Forms.ComboBox();
			this.timePerShot = new System.Windows.Forms.NumericUpDown();
			this.numberOfShots = new System.Windows.Forms.NumericUpDown();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.imgInfoTab = new System.Windows.Forms.TabPage();
			this.btnSaveXml = new System.Windows.Forms.Button();
			this.label = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.viewport = new System.Windows.Forms.PictureBox();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.menuStrip1.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.cameraTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.timePerShot)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numberOfShots)).BeginInit();
			this.imgInfoTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.viewport)).BeginInit();
			this.SuspendLayout();
			// 
			// filmstrip
			// 
			this.filmstrip.AutoScroll = true;
			this.filmstrip.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.filmstrip.Location = new System.Drawing.Point(0, 611);
			this.filmstrip.Name = "filmstrip";
			this.filmstrip.Size = new System.Drawing.Size(841, 135);
			this.filmstrip.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.modeToolStripMenuItem,
            this.machineLearningToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(841, 30);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.loadProjectToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newProjectToolStripMenuItem
			// 
			this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
			this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
			this.newProjectToolStripMenuItem.Text = "New Project...";
			this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProject);
			// 
			// loadProjectToolStripMenuItem
			// 
			this.loadProjectToolStripMenuItem.Name = "loadProjectToolStripMenuItem";
			this.loadProjectToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
			this.loadProjectToolStripMenuItem.Text = "Open Project...";
			this.loadProjectToolStripMenuItem.Click += new System.EventHandler(this.openProject);
			// 
			// modeToolStripMenuItem
			// 
			this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
			this.modeToolStripMenuItem.Size = new System.Drawing.Size(62, 26);
			this.modeToolStripMenuItem.Text = "Mode";
			// 
			// machineLearningToolStripMenuItem
			// 
			this.machineLearningToolStripMenuItem.Name = "machineLearningToolStripMenuItem";
			this.machineLearningToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
			this.machineLearningToolStripMenuItem.Text = "Machine Learning";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.cameraTab);
			this.tabControl.Controls.Add(this.imgInfoTab);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Left;
			this.tabControl.Location = new System.Drawing.Point(0, 30);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(200, 571);
			this.tabControl.TabIndex = 3;
			this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabChanged);
			// 
			// cameraTab
			// 
			this.cameraTab.Controls.Add(this.cameraIndex);
			this.cameraTab.Controls.Add(this.timePerShot);
			this.cameraTab.Controls.Add(this.numberOfShots);
			this.cameraTab.Controls.Add(this.button1);
			this.cameraTab.Controls.Add(this.label2);
			this.cameraTab.Controls.Add(this.label1);
			this.cameraTab.Location = new System.Drawing.Point(4, 25);
			this.cameraTab.Name = "cameraTab";
			this.cameraTab.Padding = new System.Windows.Forms.Padding(3);
			this.cameraTab.Size = new System.Drawing.Size(192, 542);
			this.cameraTab.TabIndex = 0;
			this.cameraTab.Text = "Webcam";
			this.cameraTab.UseVisualStyleBackColor = true;
			// 
			// cameraIndex
			// 
			this.cameraIndex.FormattingEnabled = true;
			this.cameraIndex.Items.AddRange(new object[] {
            "Front facing camera",
            "Back facing camera"});
			this.cameraIndex.Location = new System.Drawing.Point(31, 214);
			this.cameraIndex.Name = "cameraIndex";
			this.cameraIndex.Size = new System.Drawing.Size(121, 24);
			this.cameraIndex.TabIndex = 5;
			// 
			// timePerShot
			// 
			this.timePerShot.Location = new System.Drawing.Point(30, 158);
			this.timePerShot.Name = "timePerShot";
			this.timePerShot.Size = new System.Drawing.Size(120, 22);
			this.timePerShot.TabIndex = 4;
			// 
			// numberOfShots
			// 
			this.numberOfShots.Location = new System.Drawing.Point(31, 74);
			this.numberOfShots.Name = "numberOfShots";
			this.numberOfShots.Size = new System.Drawing.Size(120, 22);
			this.numberOfShots.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(28, 266);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(105, 34);
			this.button1.TabIndex = 2;
			this.button1.Text = "Take Photos";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.shootBtn_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(28, 112);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(105, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Time per Photo";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(28, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(122, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Number of Photos";
			// 
			// imgInfoTab
			// 
			this.imgInfoTab.Controls.Add(this.btnSaveXml);
			this.imgInfoTab.Controls.Add(this.label);
			this.imgInfoTab.Controls.Add(this.label3);
			this.imgInfoTab.Location = new System.Drawing.Point(4, 25);
			this.imgInfoTab.Name = "imgInfoTab";
			this.imgInfoTab.Padding = new System.Windows.Forms.Padding(3);
			this.imgInfoTab.Size = new System.Drawing.Size(192, 542);
			this.imgInfoTab.TabIndex = 1;
			this.imgInfoTab.Text = "Image Info";
			this.imgInfoTab.UseVisualStyleBackColor = true;
			// 
			// btnSaveXml
			// 
			this.btnSaveXml.Location = new System.Drawing.Point(29, 119);
			this.btnSaveXml.Name = "btnSaveXml";
			this.btnSaveXml.Size = new System.Drawing.Size(107, 43);
			this.btnSaveXml.TabIndex = 2;
			this.btnSaveXml.Text = "Next Image";
			this.btnSaveXml.UseVisualStyleBackColor = true;
			this.btnSaveXml.Click += new System.EventHandler(this.btnSaveXml_Click);
			// 
			// label
			// 
			this.label.Location = new System.Drawing.Point(29, 58);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(118, 22);
			this.label.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(26, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(121, 17);
			this.label3.TabIndex = 0;
			this.label3.Text = "Detected Objects:";
			// 
			// viewport
			// 
			this.viewport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.viewport.Location = new System.Drawing.Point(200, 30);
			this.viewport.Name = "viewport";
			this.viewport.Size = new System.Drawing.Size(641, 571);
			this.viewport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.viewport.TabIndex = 0;
			this.viewport.TabStop = false;
			this.viewport.MouseEnter += new System.EventHandler(this.viewport_MouseEnter);
			this.viewport.MouseLeave += new System.EventHandler(this.viewport_MouseLeave);
			// 
			// progressBar
			// 
			this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.progressBar.Location = new System.Drawing.Point(0, 601);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(841, 10);
			this.progressBar.TabIndex = 5;
			// 
			// MainPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.Controls.Add(this.viewport);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.filmstrip);
			this.Controls.Add(this.menuStrip1);
			this.Name = "MainPage";
			this.Size = new System.Drawing.Size(841, 746);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.cameraTab.ResumeLayout(false);
			this.cameraTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.timePerShot)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numberOfShots)).EndInit();
			this.imgInfoTab.ResumeLayout(false);
			this.imgInfoTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.viewport)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel filmstrip;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage cameraTab;
		private System.Windows.Forms.TabPage imgInfoTab;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem machineLearningToolStripMenuItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.NumericUpDown timePerShot;
		private System.Windows.Forms.NumericUpDown numberOfShots;
		private System.Windows.Forms.ComboBox cameraIndex;
		private System.Windows.Forms.PictureBox viewport;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox label;
		private System.Windows.Forms.Button btnSaveXml;
		private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadProjectToolStripMenuItem;
	}
}

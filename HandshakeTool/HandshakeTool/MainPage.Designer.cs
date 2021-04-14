﻿
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
			this.openImageFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.batchRelabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createLabelMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.separateImagesIntoFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tabControl = new System.Windows.Forms.TabControl();
			this.cameraTab = new System.Windows.Forms.TabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.optionalGesture = new System.Windows.Forms.TextBox();
			this.cameraIndex = new System.Windows.Forms.ComboBox();
			this.timePerShot = new System.Windows.Forms.NumericUpDown();
			this.numberOfShots = new System.Windows.Forms.NumericUpDown();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.imgInfoTab = new System.Windows.Forms.TabPage();
			this.oldLabel = new System.Windows.Forms.TextBox();
			this.clearBox = new System.Windows.Forms.CheckBox();
			this.updateGesturePrompt = new System.Windows.Forms.Label();
			this.clearLabel = new System.Windows.Forms.CheckBox();
			this.btnSaveXml = new System.Windows.Forms.Button();
			this.newLabel = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.viewport = new System.Windows.Forms.PictureBox();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
			this.exportImagesForTrainingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.cameraTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.timePerShot)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numberOfShots)).BeginInit();
			this.imgInfoTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.viewport)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
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
            this.modeToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(841, 28);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.loadProjectToolStripMenuItem,
            this.openImageFolderToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newProjectToolStripMenuItem
			// 
			this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
			this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(308, 26);
			this.newProjectToolStripMenuItem.Text = "New Project...";
			this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProject);
			// 
			// loadProjectToolStripMenuItem
			// 
			this.loadProjectToolStripMenuItem.Name = "loadProjectToolStripMenuItem";
			this.loadProjectToolStripMenuItem.Size = new System.Drawing.Size(308, 26);
			this.loadProjectToolStripMenuItem.Text = "Open Project...";
			this.loadProjectToolStripMenuItem.Click += new System.EventHandler(this.openProject);
			// 
			// openImageFolderToolStripMenuItem
			// 
			this.openImageFolderToolStripMenuItem.Name = "openImageFolderToolStripMenuItem";
			this.openImageFolderToolStripMenuItem.Size = new System.Drawing.Size(308, 26);
			this.openImageFolderToolStripMenuItem.Text = "Open Project Folder in Explorer...";
			this.openImageFolderToolStripMenuItem.Click += new System.EventHandler(this.openProjectFolder);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(308, 26);
			this.exitToolStripMenuItem.Text = "Close";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.close);
			// 
			// modeToolStripMenuItem
			// 
			this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.batchRelabelToolStripMenuItem,
            this.createLabelMapToolStripMenuItem,
            this.separateImagesIntoFoldersToolStripMenuItem,
            this.showStatsToolStripMenuItem,
            this.exportImagesForTrainingToolStripMenuItem});
			this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
			this.modeToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
			this.modeToolStripMenuItem.Text = "Actions";
			// 
			// batchRelabelToolStripMenuItem
			// 
			this.batchRelabelToolStripMenuItem.Name = "batchRelabelToolStripMenuItem";
			this.batchRelabelToolStripMenuItem.Size = new System.Drawing.Size(294, 26);
			this.batchRelabelToolStripMenuItem.Text = "Batch Relabel...";
			this.batchRelabelToolStripMenuItem.Click += new System.EventHandler(this.batchRelabel);
			// 
			// createLabelMapToolStripMenuItem
			// 
			this.createLabelMapToolStripMenuItem.Name = "createLabelMapToolStripMenuItem";
			this.createLabelMapToolStripMenuItem.Size = new System.Drawing.Size(294, 26);
			this.createLabelMapToolStripMenuItem.Text = "Create Label Map...";
			this.createLabelMapToolStripMenuItem.Click += new System.EventHandler(this.createLabelMap);
			// 
			// separateImagesIntoFoldersToolStripMenuItem
			// 
			this.separateImagesIntoFoldersToolStripMenuItem.Name = "separateImagesIntoFoldersToolStripMenuItem";
			this.separateImagesIntoFoldersToolStripMenuItem.Size = new System.Drawing.Size(294, 26);
			this.separateImagesIntoFoldersToolStripMenuItem.Text = "Separate Images into Folders...";
			this.separateImagesIntoFoldersToolStripMenuItem.Click += new System.EventHandler(this.separateImagesIntoFolders);
			// 
			// showStatsToolStripMenuItem
			// 
			this.showStatsToolStripMenuItem.Name = "showStatsToolStripMenuItem";
			this.showStatsToolStripMenuItem.Size = new System.Drawing.Size(294, 26);
			this.showStatsToolStripMenuItem.Text = "Show Stats...";
			this.showStatsToolStripMenuItem.Click += new System.EventHandler(this.showStats);
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
			this.tabControl.Location = new System.Drawing.Point(0, 28);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(227, 573);
			this.tabControl.TabIndex = 1;
			this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabChanged);
			// 
			// cameraTab
			// 
			this.cameraTab.Controls.Add(this.label4);
			this.cameraTab.Controls.Add(this.optionalGesture);
			this.cameraTab.Controls.Add(this.cameraIndex);
			this.cameraTab.Controls.Add(this.timePerShot);
			this.cameraTab.Controls.Add(this.numberOfShots);
			this.cameraTab.Controls.Add(this.button1);
			this.cameraTab.Controls.Add(this.label2);
			this.cameraTab.Controls.Add(this.label1);
			this.cameraTab.Location = new System.Drawing.Point(4, 25);
			this.cameraTab.Name = "cameraTab";
			this.cameraTab.Padding = new System.Windows.Forms.Padding(3);
			this.cameraTab.Size = new System.Drawing.Size(219, 544);
			this.cameraTab.TabIndex = 0;
			this.cameraTab.Text = "Webcam";
			this.cameraTab.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(29, 29);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(168, 17);
			this.label4.TabIndex = 7;
			this.label4.Text = "Gesture Name (optional):";
			// 
			// optionalGesture
			// 
			this.optionalGesture.Location = new System.Drawing.Point(29, 52);
			this.optionalGesture.Name = "optionalGesture";
			this.optionalGesture.Size = new System.Drawing.Size(168, 22);
			this.optionalGesture.TabIndex = 2;
			// 
			// cameraIndex
			// 
			this.cameraIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cameraIndex.FormattingEnabled = true;
			this.cameraIndex.Items.AddRange(new object[] {
            "Front facing camera",
            "Back facing camera"});
			this.cameraIndex.Location = new System.Drawing.Point(29, 259);
			this.cameraIndex.Name = "cameraIndex";
			this.cameraIndex.Size = new System.Drawing.Size(168, 24);
			this.cameraIndex.TabIndex = 5;
			this.cameraIndex.SelectedIndexChanged += new System.EventHandler(this.changeCamera);
			// 
			// timePerShot
			// 
			this.timePerShot.DecimalPlaces = 1;
			this.timePerShot.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.timePerShot.Location = new System.Drawing.Point(29, 196);
			this.timePerShot.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.timePerShot.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.timePerShot.Name = "timePerShot";
			this.timePerShot.Size = new System.Drawing.Size(168, 22);
			this.timePerShot.TabIndex = 4;
			this.timePerShot.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// numberOfShots
			// 
			this.numberOfShots.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.numberOfShots.Location = new System.Drawing.Point(29, 122);
			this.numberOfShots.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.numberOfShots.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.numberOfShots.Name = "numberOfShots";
			this.numberOfShots.Size = new System.Drawing.Size(168, 22);
			this.numberOfShots.TabIndex = 3;
			this.numberOfShots.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(29, 324);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(107, 40);
			this.button1.TabIndex = 6;
			this.button1.Text = "Take Photos";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.shootBtn_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(27, 167);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(109, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Time per Photo:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 92);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(126, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Number of Photos:";
			// 
			// imgInfoTab
			// 
			this.imgInfoTab.Controls.Add(this.oldLabel);
			this.imgInfoTab.Controls.Add(this.clearBox);
			this.imgInfoTab.Controls.Add(this.updateGesturePrompt);
			this.imgInfoTab.Controls.Add(this.clearLabel);
			this.imgInfoTab.Controls.Add(this.btnSaveXml);
			this.imgInfoTab.Controls.Add(this.newLabel);
			this.imgInfoTab.Controls.Add(this.label3);
			this.imgInfoTab.Location = new System.Drawing.Point(4, 25);
			this.imgInfoTab.Name = "imgInfoTab";
			this.imgInfoTab.Padding = new System.Windows.Forms.Padding(3);
			this.imgInfoTab.Size = new System.Drawing.Size(219, 542);
			this.imgInfoTab.TabIndex = 1;
			this.imgInfoTab.Text = "Image Info";
			this.imgInfoTab.UseVisualStyleBackColor = true;
			// 
			// oldLabel
			// 
			this.oldLabel.Location = new System.Drawing.Point(29, 53);
			this.oldLabel.Name = "oldLabel";
			this.oldLabel.ReadOnly = true;
			this.oldLabel.Size = new System.Drawing.Size(154, 22);
			this.oldLabel.TabIndex = 2;
			// 
			// clearBox
			// 
			this.clearBox.AutoSize = true;
			this.clearBox.Checked = true;
			this.clearBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.clearBox.Location = new System.Drawing.Point(32, 286);
			this.clearBox.Name = "clearBox";
			this.clearBox.Size = new System.Drawing.Size(164, 21);
			this.clearBox.TabIndex = 6;
			this.clearBox.Text = "Clear Box Upon Save";
			this.clearBox.UseVisualStyleBackColor = true;
			// 
			// updateGesturePrompt
			// 
			this.updateGesturePrompt.AutoSize = true;
			this.updateGesturePrompt.Location = new System.Drawing.Point(29, 99);
			this.updateGesturePrompt.Name = "updateGesturePrompt";
			this.updateGesturePrompt.Size = new System.Drawing.Size(123, 17);
			this.updateGesturePrompt.TabIndex = 4;
			this.updateGesturePrompt.Text = "Add New Gesture:";
			// 
			// clearLabel
			// 
			this.clearLabel.AutoSize = true;
			this.clearLabel.Location = new System.Drawing.Point(32, 259);
			this.clearLabel.Name = "clearLabel";
			this.clearLabel.Size = new System.Drawing.Size(178, 21);
			this.clearLabel.TabIndex = 5;
			this.clearLabel.Text = "Clear Name Upon Save";
			this.clearLabel.UseVisualStyleBackColor = true;
			// 
			// btnSaveXml
			// 
			this.btnSaveXml.Location = new System.Drawing.Point(29, 187);
			this.btnSaveXml.Name = "btnSaveXml";
			this.btnSaveXml.Size = new System.Drawing.Size(154, 43);
			this.btnSaveXml.TabIndex = 4;
			this.btnSaveXml.Text = "Save Gesture";
			this.btnSaveXml.UseVisualStyleBackColor = true;
			this.btnSaveXml.Click += new System.EventHandler(this.btnSaveXml_Click);
			// 
			// newLabel
			// 
			this.newLabel.Location = new System.Drawing.Point(29, 130);
			this.newLabel.Name = "newLabel";
			this.newLabel.Size = new System.Drawing.Size(154, 22);
			this.newLabel.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(26, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(107, 17);
			this.label3.TabIndex = 0;
			this.label3.Text = "Saved Gesture:";
			// 
			// viewport
			// 
			this.viewport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.viewport.Location = new System.Drawing.Point(227, 28);
			this.viewport.Name = "viewport";
			this.viewport.Size = new System.Drawing.Size(614, 573);
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
			// fileSystemWatcher1
			// 
			this.fileSystemWatcher1.EnableRaisingEvents = true;
			this.fileSystemWatcher1.SynchronizingObject = this;
			// 
			// exportImagesForTrainingToolStripMenuItem
			// 
			this.exportImagesForTrainingToolStripMenuItem.Name = "exportImagesForTrainingToolStripMenuItem";
			this.exportImagesForTrainingToolStripMenuItem.Size = new System.Drawing.Size(294, 26);
			this.exportImagesForTrainingToolStripMenuItem.Text = "Export Images for Training...";
			this.exportImagesForTrainingToolStripMenuItem.Click += new System.EventHandler(this.exportImagesForTraining);
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
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
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
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.NumericUpDown timePerShot;
		private System.Windows.Forms.NumericUpDown numberOfShots;
		private System.Windows.Forms.ComboBox cameraIndex;
		private System.Windows.Forms.PictureBox viewport;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox newLabel;
		private System.Windows.Forms.Button btnSaveXml;
		private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadProjectToolStripMenuItem;
		private System.Windows.Forms.CheckBox clearLabel;
		private System.Windows.Forms.Label updateGesturePrompt;
		private System.IO.FileSystemWatcher fileSystemWatcher1;
		private System.Windows.Forms.CheckBox clearBox;
		private System.Windows.Forms.TextBox oldLabel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox optionalGesture;
		private System.Windows.Forms.ToolStripMenuItem openImageFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem batchRelabelToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem createLabelMapToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem separateImagesIntoFoldersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showStatsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportImagesForTrainingToolStripMenuItem;
	}
}

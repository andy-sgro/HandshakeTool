﻿
namespace HandshakeTool
{
	partial class _HandshakeTool
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
			this.components = new System.ComponentModel.Container();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openImageFolderBtn = new System.Windows.Forms.ToolStripMenuItem();
			this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.labellerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.machineLearningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.browseObjectDetectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.browsePipelineConfigFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.browseCheckpointFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.browseLabelMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.filmstrip = new System.Windows.Forms.Panel();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.cameraTab = new System.Windows.Forms.TabPage();
			this.shootBtn = new System.Windows.Forms.Button();
			this.timePerShots = new System.Windows.Forms.NumericUpDown();
			this.numberOfShots = new System.Windows.Forms.NumericUpDown();
			this.cameraIndex = new System.Windows.Forms.ComboBox();
			this.dsafae = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.imgInfoTab = new System.Windows.Forms.TabPage();
			this.btnSaveXml = new System.Windows.Forms.Button();
			this.label = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.viewport = new System.Windows.Forms.PictureBox();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuStrip1.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.cameraTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.timePerShots)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numberOfShots)).BeginInit();
			this.imgInfoTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.viewport)).BeginInit();
			this.SuspendLayout();
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
			this.menuStrip1.Size = new System.Drawing.Size(1359, 28);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageFolderBtn,
            this.openProjectToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openImageFolderBtn
			// 
			this.openImageFolderBtn.Name = "openImageFolderBtn";
			this.openImageFolderBtn.Size = new System.Drawing.Size(187, 26);
			this.openImageFolderBtn.Text = "New Project...";
			this.openImageFolderBtn.Click += new System.EventHandler(this.NewProject);
			// 
			// openProjectToolStripMenuItem
			// 
			this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
			this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
			this.openProjectToolStripMenuItem.Text = "Open Project...";
			this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.OpenProject);
			// 
			// modeToolStripMenuItem
			// 
			this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cameraToolStripMenuItem,
            this.labellerToolStripMenuItem});
			this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
			this.modeToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
			this.modeToolStripMenuItem.Text = "Mode";
			// 
			// cameraToolStripMenuItem
			// 
			this.cameraToolStripMenuItem.Name = "cameraToolStripMenuItem";
			this.cameraToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
			this.cameraToolStripMenuItem.Text = "Camera Mode";
			// 
			// labellerToolStripMenuItem
			// 
			this.labellerToolStripMenuItem.Name = "labellerToolStripMenuItem";
			this.labellerToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
			this.labellerToolStripMenuItem.Text = "Labeller Mode";
			// 
			// machineLearningToolStripMenuItem
			// 
			this.machineLearningToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browseObjectDetectorToolStripMenuItem,
            this.browsePipelineConfigFileToolStripMenuItem,
            this.browseCheckpointFolderToolStripMenuItem,
            this.browseLabelMapToolStripMenuItem});
			this.machineLearningToolStripMenuItem.Name = "machineLearningToolStripMenuItem";
			this.machineLearningToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
			this.machineLearningToolStripMenuItem.Text = "Machine Learning";
			// 
			// browseObjectDetectorToolStripMenuItem
			// 
			this.browseObjectDetectorToolStripMenuItem.Name = "browseObjectDetectorToolStripMenuItem";
			this.browseObjectDetectorToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
			this.browseObjectDetectorToolStripMenuItem.Text = "Import Trained Model...";
			// 
			// browsePipelineConfigFileToolStripMenuItem
			// 
			this.browsePipelineConfigFileToolStripMenuItem.Name = "browsePipelineConfigFileToolStripMenuItem";
			this.browsePipelineConfigFileToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
			this.browsePipelineConfigFileToolStripMenuItem.Text = "Partition Dataset...";
			// 
			// browseCheckpointFolderToolStripMenuItem
			// 
			this.browseCheckpointFolderToolStripMenuItem.Name = "browseCheckpointFolderToolStripMenuItem";
			this.browseCheckpointFolderToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
			this.browseCheckpointFolderToolStripMenuItem.Text = "Train Model...";
			// 
			// browseLabelMapToolStripMenuItem
			// 
			this.browseLabelMapToolStripMenuItem.Name = "browseLabelMapToolStripMenuItem";
			this.browseLabelMapToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
			this.browseLabelMapToolStripMenuItem.Text = "Export Trained Model...";
			// 
			// filmstrip
			// 
			this.filmstrip.AutoScroll = true;
			this.filmstrip.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.filmstrip.Location = new System.Drawing.Point(0, 772);
			this.filmstrip.Name = "filmstrip";
			this.filmstrip.Size = new System.Drawing.Size(1359, 161);
			this.filmstrip.TabIndex = 4;
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.cameraTab);
			this.tabControl.Controls.Add(this.imgInfoTab);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Left;
			this.tabControl.Location = new System.Drawing.Point(0, 28);
			this.tabControl.Multiline = true;
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(250, 739);
			this.tabControl.TabIndex = 5;
			this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabChanged);
			// 
			// cameraTab
			// 
			this.cameraTab.Controls.Add(this.shootBtn);
			this.cameraTab.Controls.Add(this.timePerShots);
			this.cameraTab.Controls.Add(this.numberOfShots);
			this.cameraTab.Controls.Add(this.cameraIndex);
			this.cameraTab.Controls.Add(this.dsafae);
			this.cameraTab.Controls.Add(this.label1);
			this.cameraTab.Location = new System.Drawing.Point(4, 25);
			this.cameraTab.Name = "cameraTab";
			this.cameraTab.Padding = new System.Windows.Forms.Padding(3);
			this.cameraTab.Size = new System.Drawing.Size(242, 710);
			this.cameraTab.TabIndex = 0;
			this.cameraTab.Text = "Webcam";
			this.cameraTab.UseVisualStyleBackColor = true;
			// 
			// shootBtn
			// 
			this.shootBtn.Location = new System.Drawing.Point(33, 262);
			this.shootBtn.Name = "shootBtn";
			this.shootBtn.Size = new System.Drawing.Size(118, 40);
			this.shootBtn.TabIndex = 5;
			this.shootBtn.Text = "Take Photos";
			this.shootBtn.UseVisualStyleBackColor = true;
			this.shootBtn.Click += new System.EventHandler(this.shootBtn_Click);
			// 
			// timePerShots
			// 
			this.timePerShots.DecimalPlaces = 2;
			this.timePerShots.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
			this.timePerShots.Location = new System.Drawing.Point(33, 134);
			this.timePerShots.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.timePerShots.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
			this.timePerShots.Name = "timePerShots";
			this.timePerShots.Size = new System.Drawing.Size(171, 22);
			this.timePerShots.TabIndex = 4;
			this.timePerShots.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// numberOfShots
			// 
			this.numberOfShots.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numberOfShots.Location = new System.Drawing.Point(33, 70);
			this.numberOfShots.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.numberOfShots.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numberOfShots.Name = "numberOfShots";
			this.numberOfShots.Size = new System.Drawing.Size(171, 22);
			this.numberOfShots.TabIndex = 3;
			this.numberOfShots.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// cameraIndex
			// 
			this.cameraIndex.CausesValidation = false;
			this.cameraIndex.Items.AddRange(new object[] {
            "Front facing camera",
            "Back facing camera"});
			this.cameraIndex.Location = new System.Drawing.Point(33, 191);
			this.cameraIndex.Name = "cameraIndex";
			this.cameraIndex.Size = new System.Drawing.Size(171, 24);
			this.cameraIndex.TabIndex = 2;
			// 
			// dsafae
			// 
			this.dsafae.AutoSize = true;
			this.dsafae.Location = new System.Drawing.Point(30, 103);
			this.dsafae.Name = "dsafae";
			this.dsafae.Size = new System.Drawing.Size(104, 17);
			this.dsafae.TabIndex = 1;
			this.dsafae.Text = "Time per photo";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(30, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(121, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Number of photos";
			// 
			// imgInfoTab
			// 
			this.imgInfoTab.Controls.Add(this.btnSaveXml);
			this.imgInfoTab.Controls.Add(this.label);
			this.imgInfoTab.Controls.Add(this.label2);
			this.imgInfoTab.Location = new System.Drawing.Point(4, 25);
			this.imgInfoTab.Name = "imgInfoTab";
			this.imgInfoTab.Padding = new System.Windows.Forms.Padding(3);
			this.imgInfoTab.Size = new System.Drawing.Size(242, 710);
			this.imgInfoTab.TabIndex = 1;
			this.imgInfoTab.Text = "Image Info";
			this.imgInfoTab.UseVisualStyleBackColor = true;
			// 
			// btnSaveXml
			// 
			this.btnSaveXml.Location = new System.Drawing.Point(33, 122);
			this.btnSaveXml.Name = "btnSaveXml";
			this.btnSaveXml.Size = new System.Drawing.Size(94, 28);
			this.btnSaveXml.TabIndex = 2;
			this.btnSaveXml.Text = "Next Image";
			this.btnSaveXml.UseVisualStyleBackColor = true;
			this.btnSaveXml.Click += new System.EventHandler(this.btnSaveXml_Click);
			// 
			// label
			// 
			this.label.Location = new System.Drawing.Point(33, 60);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(171, 22);
			this.label.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(30, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(110, 17);
			this.label2.TabIndex = 0;
			this.label2.Text = "Detected Object";
			// 
			// viewport
			// 
			this.viewport.BackColor = System.Drawing.Color.Black;
			this.viewport.Location = new System.Drawing.Point(557, 213);
			this.viewport.Name = "viewport";
			this.viewport.Size = new System.Drawing.Size(802, 554);
			this.viewport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.viewport.TabIndex = 6;
			this.viewport.TabStop = false;
			this.viewport.MouseEnter += new System.EventHandler(this.viewport_MouseEnter);
			this.viewport.MouseLeave += new System.EventHandler(this.viewport_MouseLeave);
			// 
			// progressBar
			// 
			this.progressBar.BackColor = System.Drawing.Color.Black;
			this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.progressBar.ForeColor = System.Drawing.Color.Lime;
			this.progressBar.Location = new System.Drawing.Point(0, 767);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(1359, 5);
			this.progressBar.Step = 1;
			this.progressBar.TabIndex = 7;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// _HandshakeTool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1359, 933);
			this.Controls.Add(this.viewport);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.filmstrip);
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "_HandshakeTool";
			this.Text = "Handshake Tool";
			this.Load += new System.EventHandler(this.HandshakeTool_Load);
			this.Enter += new System.EventHandler(this.HandshakeTool_Enter);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.cameraTab.ResumeLayout(false);
			this.cameraTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.timePerShots)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numberOfShots)).EndInit();
			this.imgInfoTab.ResumeLayout(false);
			this.imgInfoTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.viewport)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openImageFolderBtn;
		private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cameraToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem labellerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem machineLearningToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem browseObjectDetectorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem browsePipelineConfigFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem browseCheckpointFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem browseLabelMapToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
		private System.Windows.Forms.Panel filmstrip;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage cameraTab;
		private System.Windows.Forms.TabPage imgInfoTab;
		private System.Windows.Forms.PictureBox viewport;
		private System.Windows.Forms.Label dsafae;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown timePerShots;
		private System.Windows.Forms.NumericUpDown numberOfShots;
		private System.Windows.Forms.ComboBox cameraIndex;
		private System.Windows.Forms.TextBox label;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button shootBtn;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Button btnSaveXml;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
	}
}


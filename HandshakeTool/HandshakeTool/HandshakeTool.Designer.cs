
namespace HandshakeTool
{
	partial class HandshakeTool
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
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.panel = new System.Windows.Forms.Panel();
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
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel
			// 
			this.panel.Location = new System.Drawing.Point(0, 31);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(1359, 899);
			this.panel.TabIndex = 2;
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
			this.openImageFolderBtn.Size = new System.Drawing.Size(224, 26);
			this.openImageFolderBtn.Text = "New Project...";
			this.openImageFolderBtn.Click += new System.EventHandler(this.NewProject);
			// 
			// openProjectToolStripMenuItem
			// 
			this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
			this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
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
			this.cameraToolStripMenuItem.Click += new System.EventHandler(this.cameraToolStripMenuItem_Click);
			// 
			// labellerToolStripMenuItem
			// 
			this.labellerToolStripMenuItem.Name = "labellerToolStripMenuItem";
			this.labellerToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
			this.labellerToolStripMenuItem.Text = "Labeller Mode";
			this.labellerToolStripMenuItem.Click += new System.EventHandler(this.labellerToolStripMenuItem_Click);
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
			// HandshakeTool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(1359, 933);
			this.Controls.Add(this.panel);
			this.Controls.Add(this.menuStrip1);
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "HandshakeTool";
			this.Text = "Handshake Tool";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.Panel panel;
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
	}
}


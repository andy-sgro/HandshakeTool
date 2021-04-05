
namespace HandshakeTool
{
	partial class Welcome
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
			this.newProjectBtn = new System.Windows.Forms.Button();
			this.loadProjectBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// newProjectBtn
			// 
			this.newProjectBtn.Location = new System.Drawing.Point(336, 107);
			this.newProjectBtn.Name = "newProjectBtn";
			this.newProjectBtn.Size = new System.Drawing.Size(108, 33);
			this.newProjectBtn.TabIndex = 0;
			this.newProjectBtn.Text = "New Project";
			this.newProjectBtn.UseVisualStyleBackColor = true;
			this.newProjectBtn.Click += new System.EventHandler(this.newProject);
			// 
			// loadProjectBtn
			// 
			this.loadProjectBtn.Location = new System.Drawing.Point(336, 197);
			this.loadProjectBtn.Name = "loadProjectBtn";
			this.loadProjectBtn.Size = new System.Drawing.Size(108, 33);
			this.loadProjectBtn.TabIndex = 1;
			this.loadProjectBtn.Text = "Load Project";
			this.loadProjectBtn.UseVisualStyleBackColor = true;
			this.loadProjectBtn.Click += new System.EventHandler(this.loadProject);
			// 
			// Welcome
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.loadProjectBtn);
			this.Controls.Add(this.newProjectBtn);
			this.Name = "Welcome";
			this.Text = "Welcome";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button newProjectBtn;
		private System.Windows.Forms.Button loadProjectBtn;
	}
}
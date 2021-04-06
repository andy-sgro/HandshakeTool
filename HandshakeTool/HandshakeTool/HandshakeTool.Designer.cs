
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
			this.panel = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel
			// 
			this.panel.Controls.Add(this.button2);
			this.panel.Controls.Add(this.button1);
			this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel.Location = new System.Drawing.Point(0, 0);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(1232, 750);
			this.panel.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(570, 241);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(107, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "New Project";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.newProject);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(570, 362);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(107, 32);
			this.button2.TabIndex = 1;
			this.button2.Text = "Load Project";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.loadProject);
			// 
			// HandshakeTool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1232, 750);
			this.Controls.Add(this.panel);
			this.Name = "HandshakeTool";
			this.Text = "HandshakeTool";
			this.panel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
	}
}
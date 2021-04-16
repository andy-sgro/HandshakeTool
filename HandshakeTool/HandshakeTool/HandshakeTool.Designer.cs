
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
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel
			// 
			this.panel.Controls.Add(this.label1);
			this.panel.Controls.Add(this.button2);
			this.panel.Controls.Add(this.button1);
			this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel.Location = new System.Drawing.Point(0, 0);
			this.panel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(679, 539);
			this.panel.TabIndex = 0;
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(211, 308);
			this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(276, 75);
			this.button2.TabIndex = 1;
			this.button2.Text = "Load Project";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.loadProject);
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(211, 209);
			this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(276, 75);
			this.button1.TabIndex = 0;
			this.button1.Text = "New Project";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.newProject);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(203, 113);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(284, 47);
			this.label1.TabIndex = 2;
			this.label1.Text = "Handshake Tool";
			// 
			// HandshakeTool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(679, 539);
			this.Controls.Add(this.panel);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "HandshakeTool";
			this.Text = "HandshakeTool";
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
	}
}
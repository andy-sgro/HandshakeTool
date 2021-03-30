
namespace HandshakeTool
{
	partial class Camera
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
			this.viewport = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.timePerShot = new System.Windows.Forms.NumericUpDown();
			this.numberOfShots = new System.Windows.Forms.NumericUpDown();
			this.shootBtn = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.timeRemaining = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cameraIndexPicker = new System.Windows.Forms.NumericUpDown();
			this.remainingShots = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.viewport)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timePerShot)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numberOfShots)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cameraIndexPicker)).BeginInit();
			this.SuspendLayout();
			// 
			// viewport
			// 
			this.viewport.Location = new System.Drawing.Point(170, 24);
			this.viewport.Name = "viewport";
			this.viewport.Size = new System.Drawing.Size(1142, 767);
			this.viewport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.viewport.TabIndex = 0;
			this.viewport.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(114, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "Number of shots";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(19, 106);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 19);
			this.label2.TabIndex = 2;
			this.label2.Text = "Time per shot";
			// 
			// timePerShot
			// 
			this.timePerShot.DecimalPlaces = 2;
			this.timePerShot.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
			this.timePerShot.Location = new System.Drawing.Point(19, 141);
			this.timePerShot.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.timePerShot.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
			this.timePerShot.Name = "timePerShot";
			this.timePerShot.Size = new System.Drawing.Size(120, 22);
			this.timePerShot.TabIndex = 3;
			this.timePerShot.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// numberOfShots
			// 
			this.numberOfShots.BackColor = System.Drawing.Color.White;
			this.numberOfShots.ForeColor = System.Drawing.Color.Black;
			this.numberOfShots.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numberOfShots.Location = new System.Drawing.Point(19, 57);
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
			this.numberOfShots.Size = new System.Drawing.Size(120, 22);
			this.numberOfShots.TabIndex = 4;
			this.numberOfShots.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			// 
			// shootBtn
			// 
			this.shootBtn.BackColor = System.Drawing.Color.Gray;
			this.shootBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.shootBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.shootBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
			this.shootBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.shootBtn.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.shootBtn.ForeColor = System.Drawing.Color.White;
			this.shootBtn.Location = new System.Drawing.Point(19, 270);
			this.shootBtn.Name = "shootBtn";
			this.shootBtn.Size = new System.Drawing.Size(120, 59);
			this.shootBtn.TabIndex = 5;
			this.shootBtn.Text = "Take Photos";
			this.shootBtn.UseVisualStyleBackColor = false;
			this.shootBtn.Click += new System.EventHandler(this.shootBtn_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(16, 722);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(114, 19);
			this.label3.TabIndex = 6;
			this.label3.Text = "Time Remaining:";
			// 
			// timeRemaining
			// 
			this.timeRemaining.AutoSize = true;
			this.timeRemaining.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.timeRemaining.ForeColor = System.Drawing.Color.White;
			this.timeRemaining.Location = new System.Drawing.Point(19, 750);
			this.timeRemaining.Name = "timeRemaining";
			this.timeRemaining.Size = new System.Drawing.Size(55, 19);
			this.timeRemaining.TabIndex = 7;
			this.timeRemaining.Text = "0:00.00";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(19, 182);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(94, 19);
			this.label4.TabIndex = 8;
			this.label4.Text = "Camera Index";
			// 
			// cameraIndexPicker
			// 
			this.cameraIndexPicker.Location = new System.Drawing.Point(19, 213);
			this.cameraIndexPicker.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.cameraIndexPicker.Name = "cameraIndexPicker";
			this.cameraIndexPicker.Size = new System.Drawing.Size(120, 22);
			this.cameraIndexPicker.TabIndex = 9;
			this.cameraIndexPicker.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.cameraIndexPicker.ValueChanged += new System.EventHandler(this.cameraIndexPicker_ValueChanged);
			// 
			// remainingShots
			// 
			this.remainingShots.AutoSize = true;
			this.remainingShots.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.remainingShots.ForeColor = System.Drawing.Color.White;
			this.remainingShots.Location = new System.Drawing.Point(16, 689);
			this.remainingShots.Name = "remainingShots";
			this.remainingShots.Size = new System.Drawing.Size(121, 19);
			this.remainingShots.TabIndex = 11;
			this.remainingShots.Text = "7 shots remaining";
			// 
			// Camera
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.Controls.Add(this.remainingShots);
			this.Controls.Add(this.cameraIndexPicker);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.timeRemaining);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.shootBtn);
			this.Controls.Add(this.numberOfShots);
			this.Controls.Add(this.timePerShot);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.viewport);
			this.Name = "Camera";
			this.Size = new System.Drawing.Size(1333, 807);
			this.Load += new System.EventHandler(this.camera_Load);
			((System.ComponentModel.ISupportInitialize)(this.viewport)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timePerShot)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numberOfShots)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cameraIndexPicker)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox viewport;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown timePerShot;
		private System.Windows.Forms.NumericUpDown numberOfShots;
		private System.Windows.Forms.Button shootBtn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label timeRemaining;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown cameraIndexPicker;
		private System.Windows.Forms.Label remainingShots;
	}
}

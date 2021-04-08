
namespace HandshakeTool
{
	partial class Relabeller
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
			this.replaceBtn = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.findLabel = new System.Windows.Forms.Label();
			this.labelToFind = new System.Windows.Forms.TextBox();
			this.newLabel = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.minIndexLabel = new System.Windows.Forms.Label();
			this.maxIndex = new System.Windows.Forms.NumericUpDown();
			this.minIndex = new System.Windows.Forms.NumericUpDown();
			this.findAll = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.maxIndex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.minIndex)).BeginInit();
			this.SuspendLayout();
			// 
			// replaceBtn
			// 
			this.replaceBtn.Enabled = false;
			this.replaceBtn.Location = new System.Drawing.Point(121, 234);
			this.replaceBtn.Name = "replaceBtn";
			this.replaceBtn.Size = new System.Drawing.Size(141, 35);
			this.replaceBtn.TabIndex = 6;
			this.replaceBtn.Text = "Find and Replace";
			this.replaceBtn.UseVisualStyleBackColor = true;
			this.replaceBtn.Click += new System.EventHandler(this.replaceBtn_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(63, 71);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 17);
			this.label9.TabIndex = 26;
			this.label9.Text = "Replace:";
			// 
			// findLabel
			// 
			this.findLabel.AutoSize = true;
			this.findLabel.Location = new System.Drawing.Point(63, 33);
			this.findLabel.Name = "findLabel";
			this.findLabel.Size = new System.Drawing.Size(39, 17);
			this.findLabel.TabIndex = 25;
			this.findLabel.Text = "Find:";
			// 
			// labelToFind
			// 
			this.labelToFind.Location = new System.Drawing.Point(155, 28);
			this.labelToFind.Name = "labelToFind";
			this.labelToFind.Size = new System.Drawing.Size(133, 22);
			this.labelToFind.TabIndex = 1;
			this.labelToFind.TextChanged += new System.EventHandler(this.labelToFind_TextChanged);
			// 
			// newLabel
			// 
			this.newLabel.Location = new System.Drawing.Point(155, 66);
			this.newLabel.Name = "newLabel";
			this.newLabel.Size = new System.Drawing.Size(133, 22);
			this.newLabel.TabIndex = 3;
			this.newLabel.TextChanged += new System.EventHandler(this.newLabel_TextChanged);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(63, 176);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(116, 17);
			this.label11.TabIndex = 22;
			this.label11.Text = "Max Image Index:";
			// 
			// minIndexLabel
			// 
			this.minIndexLabel.AutoSize = true;
			this.minIndexLabel.Location = new System.Drawing.Point(63, 121);
			this.minIndexLabel.Name = "minIndexLabel";
			this.minIndexLabel.Size = new System.Drawing.Size(113, 17);
			this.minIndexLabel.TabIndex = 21;
			this.minIndexLabel.Text = "Min Image Index:";
			// 
			// maxIndex
			// 
			this.maxIndex.Location = new System.Drawing.Point(191, 174);
			this.maxIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.maxIndex.Name = "maxIndex";
			this.maxIndex.Size = new System.Drawing.Size(106, 22);
			this.maxIndex.TabIndex = 5;
			this.maxIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// minIndex
			// 
			this.minIndex.Location = new System.Drawing.Point(191, 119);
			this.minIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.minIndex.Name = "minIndex";
			this.minIndex.Size = new System.Drawing.Size(106, 22);
			this.minIndex.TabIndex = 4;
			this.minIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// findAll
			// 
			this.findAll.AutoSize = true;
			this.findAll.Location = new System.Drawing.Point(295, 28);
			this.findAll.Name = "findAll";
			this.findAll.Size = new System.Drawing.Size(76, 21);
			this.findAll.TabIndex = 2;
			this.findAll.Text = "Find All";
			this.findAll.UseVisualStyleBackColor = true;
			this.findAll.CheckedChanged += new System.EventHandler(this.findAll_CheckedChanged);
			// 
			// Relabeller
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(378, 310);
			this.Controls.Add(this.findAll);
			this.Controls.Add(this.replaceBtn);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.findLabel);
			this.Controls.Add(this.labelToFind);
			this.Controls.Add(this.newLabel);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.minIndexLabel);
			this.Controls.Add(this.maxIndex);
			this.Controls.Add(this.minIndex);
			this.Name = "Relabeller";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Relabeller";
			((System.ComponentModel.ISupportInitialize)(this.maxIndex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.minIndex)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button replaceBtn;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label findLabel;
		private System.Windows.Forms.TextBox labelToFind;
		private System.Windows.Forms.TextBox newLabel;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label minIndexLabel;
		private System.Windows.Forms.NumericUpDown maxIndex;
		private System.Windows.Forms.NumericUpDown minIndex;
		private System.Windows.Forms.CheckBox findAll;
	}
}
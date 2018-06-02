namespace ERPWinApp
{
	partial class Testform
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
			this.button1 = new System.Windows.Forms.Button();
			this.tbText = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(288, 364);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 40);
			this.button1.TabIndex = 0;
			this.button1.Text = "Submit";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// tbText
			// 
			this.tbText.Font = new System.Drawing.Font("Latha", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbText.Location = new System.Drawing.Point(12, 12);
			this.tbText.Multiline = true;
			this.tbText.Name = "tbText";
			this.tbText.Size = new System.Drawing.Size(691, 335);
			this.tbText.TabIndex = 1;
			// 
			// Testform
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(715, 435);
			this.Controls.Add(this.tbText);
			this.Controls.Add(this.button1);
			this.Name = "Testform";
			this.Text = "Testform";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox tbText;
	}
}
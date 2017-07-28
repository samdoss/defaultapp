namespace ERPWinApp
{
	partial class frmBackup
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtBrowsePath = new System.Windows.Forms.TextBox();
			this.btnBackupLocation = new System.Windows.Forms.Button();
			this.btnProcess = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Modern No. 20", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.label1.Location = new System.Drawing.Point(226, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(372, 50);
			this.label1.TabIndex = 8;
			this.label1.Text = "Backup Database";
			// 
			// txtBrowsePath
			// 
			this.txtBrowsePath.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBrowsePath.Location = new System.Drawing.Point(41, 133);
			this.txtBrowsePath.Name = "txtBrowsePath";
			this.txtBrowsePath.Size = new System.Drawing.Size(616, 31);
			this.txtBrowsePath.TabIndex = 7;
			// 
			// btnBackupLocation
			// 
			this.btnBackupLocation.BackColor = System.Drawing.Color.DarkSlateGray;
			this.btnBackupLocation.Location = new System.Drawing.Point(663, 130);
			this.btnBackupLocation.Name = "btnBackupLocation";
			this.btnBackupLocation.Size = new System.Drawing.Size(130, 34);
			this.btnBackupLocation.TabIndex = 6;
			this.btnBackupLocation.Text = "Backup Location";
			this.btnBackupLocation.UseVisualStyleBackColor = false;
			this.btnBackupLocation.Click += new System.EventHandler(this.btnBackupLocation_Click);
			// 
			// btnProcess
			// 
			this.btnProcess.BackColor = System.Drawing.Color.DarkSlateGray;
			this.btnProcess.Location = new System.Drawing.Point(309, 211);
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.Size = new System.Drawing.Size(232, 44);
			this.btnProcess.TabIndex = 9;
			this.btnProcess.Text = "Process";
			this.btnProcess.UseVisualStyleBackColor = false;
			this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
			// 
			// frmBackup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DarkSlateGray;
			this.ClientSize = new System.Drawing.Size(826, 299);
			this.Controls.Add(this.btnProcess);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtBrowsePath);
			this.Controls.Add(this.btnBackupLocation);
			this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmBackup";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Backup Database";
			this.Load += new System.EventHandler(this.frmBackup_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtBrowsePath;
		private System.Windows.Forms.Button btnBackupLocation;
		private System.Windows.Forms.Button btnProcess;
	}
}
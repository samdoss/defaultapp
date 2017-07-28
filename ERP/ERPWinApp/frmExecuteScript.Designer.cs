namespace ERPWinApp
{
	partial class frmExecuteScript
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
			this.btnBrowseScriptFile = new System.Windows.Forms.Button();
			this.txtBrowseFile = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtScripts = new System.Windows.Forms.TextBox();
			this.btnExecute = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnBrowseScriptFile
			// 
			this.btnBrowseScriptFile.BackColor = System.Drawing.Color.DarkSlateGray;
			this.btnBrowseScriptFile.Location = new System.Drawing.Point(688, 22);
			this.btnBrowseScriptFile.Name = "btnBrowseScriptFile";
			this.btnBrowseScriptFile.Size = new System.Drawing.Size(130, 34);
			this.btnBrowseScriptFile.TabIndex = 0;
			this.btnBrowseScriptFile.Text = "Browse";
			this.btnBrowseScriptFile.UseVisualStyleBackColor = false;
			this.btnBrowseScriptFile.Click += new System.EventHandler(this.btnBrowseScriptFile_Click);
			// 
			// txtBrowseFile
			// 
			this.txtBrowseFile.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBrowseFile.Location = new System.Drawing.Point(21, 25);
			this.txtBrowseFile.Name = "txtBrowseFile";
			this.txtBrowseFile.Size = new System.Drawing.Size(661, 31);
			this.txtBrowseFile.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtScripts);
			this.groupBox1.Location = new System.Drawing.Point(4, 71);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(853, 431);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			// 
			// txtScripts
			// 
			this.txtScripts.Location = new System.Drawing.Point(6, 19);
			this.txtScripts.Multiline = true;
			this.txtScripts.Name = "txtScripts";
			this.txtScripts.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtScripts.Size = new System.Drawing.Size(828, 401);
			this.txtScripts.TabIndex = 0;
			// 
			// btnExecute
			// 
			this.btnExecute.BackColor = System.Drawing.Color.DarkSlateGray;
			this.btnExecute.Location = new System.Drawing.Point(584, 507);
			this.btnExecute.Name = "btnExecute";
			this.btnExecute.Size = new System.Drawing.Size(130, 34);
			this.btnExecute.TabIndex = 3;
			this.btnExecute.Text = "Execute";
			this.btnExecute.UseVisualStyleBackColor = false;
			this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
			// 
			// btnClose
			// 
			this.btnClose.BackColor = System.Drawing.Color.DarkSlateGray;
			this.btnClose.Location = new System.Drawing.Point(720, 507);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(130, 34);
			this.btnClose.TabIndex = 4;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// frmExecuteScript
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DarkSlateGray;
			this.ClientSize = new System.Drawing.Size(862, 553);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnExecute);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.txtBrowseFile);
			this.Controls.Add(this.btnBrowseScriptFile);
			this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmExecuteScript";
			this.Text = "Execute Script";
			this.Load += new System.EventHandler(this.frmExecuteScript_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnBrowseScriptFile;
		private System.Windows.Forms.TextBox txtBrowseFile;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtScripts;
		private System.Windows.Forms.Button btnExecute;
		private System.Windows.Forms.Button btnClose;
	}
}
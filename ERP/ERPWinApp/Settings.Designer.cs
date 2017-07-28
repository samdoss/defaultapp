namespace ERPWinApp
{
	partial class frmSettings
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblInstalledDateValue = new System.Windows.Forms.Label();
			this.lblExpireinDays = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtUserID = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDatabaseName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtServerName = new System.Windows.Forms.TextBox();
			this.lblServerName = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnTestConnection = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.rbtnWindows = new System.Windows.Forms.RadioButton();
			this.rbtnServer = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Modern No. 20", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.label1.Location = new System.Drawing.Point(105, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(183, 50);
			this.label1.TabIndex = 0;
			this.label1.Text = "Settings";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbtnServer);
			this.groupBox1.Controls.Add(this.rbtnWindows);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.lblInstalledDateValue);
			this.groupBox1.Controls.Add(this.lblExpireinDays);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtPassword);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtUserID);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtDatabaseName);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtServerName);
			this.groupBox1.Controls.Add(this.lblServerName);
			this.groupBox1.Location = new System.Drawing.Point(12, 82);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(410, 267);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// lblInstalledDateValue
			// 
			this.lblInstalledDateValue.AutoSize = true;
			this.lblInstalledDateValue.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInstalledDateValue.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lblInstalledDateValue.Location = new System.Drawing.Point(122, 211);
			this.lblInstalledDateValue.Name = "lblInstalledDateValue";
			this.lblInstalledDateValue.Size = new System.Drawing.Size(0, 18);
			this.lblInstalledDateValue.TabIndex = 12;
			this.lblInstalledDateValue.Visible = false;
			// 
			// lblExpireinDays
			// 
			this.lblExpireinDays.AutoSize = true;
			this.lblExpireinDays.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblExpireinDays.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lblExpireinDays.Location = new System.Drawing.Point(138, 240);
			this.lblExpireinDays.Name = "lblExpireinDays";
			this.lblExpireinDays.Size = new System.Drawing.Size(15, 18);
			this.lblExpireinDays.TabIndex = 11;
			this.lblExpireinDays.Text = "0";
			this.lblExpireinDays.Visible = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label6.Location = new System.Drawing.Point(6, 240);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(126, 18);
			this.label6.TabIndex = 10;
			this.label6.Text = "Product Expire in";
			this.label6.Visible = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label5.Location = new System.Drawing.Point(18, 211);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(101, 18);
			this.label5.TabIndex = 8;
			this.label5.Text = "Installed Date";
			this.label5.Visible = false;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(125, 179);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(216, 20);
			this.txtPassword.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label4.Location = new System.Drawing.Point(51, 179);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(68, 18);
			this.label4.TabIndex = 6;
			this.label4.Text = "Password";
			// 
			// txtUserID
			// 
			this.txtUserID.Location = new System.Drawing.Point(125, 142);
			this.txtUserID.Name = "txtUserID";
			this.txtUserID.Size = new System.Drawing.Size(216, 20);
			this.txtUserID.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label3.Location = new System.Drawing.Point(58, 144);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 18);
			this.label3.TabIndex = 4;
			this.label3.Text = "User ID";
			// 
			// txtDatabaseName
			// 
			this.txtDatabaseName.Location = new System.Drawing.Point(125, 74);
			this.txtDatabaseName.Name = "txtDatabaseName";
			this.txtDatabaseName.Size = new System.Drawing.Size(216, 20);
			this.txtDatabaseName.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label2.Location = new System.Drawing.Point(12, 74);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(107, 18);
			this.label2.TabIndex = 2;
			this.label2.Text = "Database Name";
			// 
			// txtServerName
			// 
			this.txtServerName.Location = new System.Drawing.Point(125, 39);
			this.txtServerName.Name = "txtServerName";
			this.txtServerName.Size = new System.Drawing.Size(216, 20);
			this.txtServerName.TabIndex = 1;
			// 
			// lblServerName
			// 
			this.lblServerName.AutoSize = true;
			this.lblServerName.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblServerName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lblServerName.Location = new System.Drawing.Point(31, 41);
			this.lblServerName.Name = "lblServerName";
			this.lblServerName.Size = new System.Drawing.Size(88, 18);
			this.lblServerName.TabIndex = 0;
			this.lblServerName.Text = "Server Name";
			// 
			// btnSave
			// 
			this.btnSave.BackColor = System.Drawing.Color.DarkSlateGray;
			this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnSave.Location = new System.Drawing.Point(260, 355);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(78, 28);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnClose
			// 
			this.btnClose.BackColor = System.Drawing.Color.DarkSlateGray;
			this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnClose.Location = new System.Drawing.Point(344, 355);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(78, 28);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnTestConnection
			// 
			this.btnTestConnection.BackColor = System.Drawing.Color.DarkSlateGray;
			this.btnTestConnection.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnTestConnection.Location = new System.Drawing.Point(137, 355);
			this.btnTestConnection.Name = "btnTestConnection";
			this.btnTestConnection.Size = new System.Drawing.Size(117, 28);
			this.btnTestConnection.TabIndex = 4;
			this.btnTestConnection.Text = "Test Connection";
			this.btnTestConnection.UseVisualStyleBackColor = false;
			this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label7.Location = new System.Drawing.Point(14, 107);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(105, 18);
			this.label7.TabIndex = 13;
			this.label7.Text = "Authentication";
			// 
			// rbtnWindows
			// 
			this.rbtnWindows.AutoSize = true;
			this.rbtnWindows.Checked = true;
			this.rbtnWindows.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.rbtnWindows.Location = new System.Drawing.Point(125, 107);
			this.rbtnWindows.Name = "rbtnWindows";
			this.rbtnWindows.Size = new System.Drawing.Size(69, 17);
			this.rbtnWindows.TabIndex = 14;
			this.rbtnWindows.TabStop = true;
			this.rbtnWindows.Text = "Windows";
			this.rbtnWindows.UseVisualStyleBackColor = true;
			this.rbtnWindows.CheckedChanged += new System.EventHandler(this.rbtnWindows_CheckedChanged);
			// 
			// rbtnServer
			// 
			this.rbtnServer.AutoSize = true;
			this.rbtnServer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.rbtnServer.Location = new System.Drawing.Point(214, 107);
			this.rbtnServer.Name = "rbtnServer";
			this.rbtnServer.Size = new System.Drawing.Size(127, 17);
			this.rbtnServer.TabIndex = 15;
			this.rbtnServer.Text = "Server Authentication";
			this.rbtnServer.UseVisualStyleBackColor = true;
			this.rbtnServer.CheckedChanged += new System.EventHandler(this.rbtnServer_CheckedChanged);
			// 
			// frmSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DarkSlateGray;
			this.ClientSize = new System.Drawing.Size(434, 392);
			this.Controls.Add(this.btnTestConnection);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.frmSettings_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.TextBox txtServerName;
		private System.Windows.Forms.Label lblServerName;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtUserID;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDatabaseName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblExpireinDays;
		private System.Windows.Forms.Label lblInstalledDateValue;
		private System.Windows.Forms.Button btnTestConnection;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.RadioButton rbtnServer;
		private System.Windows.Forms.RadioButton rbtnWindows;
	}
}


namespace ERPWinApp
{
    partial class frmLogin
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
			this.picImage = new System.Windows.Forms.PictureBox();
			this.pnlLogin = new System.Windows.Forms.Panel();
			this.chkRemember = new System.Windows.Forms.CheckBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnLogin = new System.Windows.Forms.Button();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.lblPassword = new System.Windows.Forms.Label();
			this.lblLogin = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.PCSHelp = new System.Windows.Forms.HelpProvider();
			this.lblTrialVersion = new System.Windows.Forms.Label();
			this.lblCP = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
			this.SuspendLayout();
			// 
			// picImage
			// 
			this.picImage.BackgroundImage = global::ERPWinApp.Properties.Resources.splash_screen1;
			this.picImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picImage.Location = new System.Drawing.Point(219, -8);
			this.picImage.Name = "picImage";
			this.picImage.Size = new System.Drawing.Size(754, 510);
			this.picImage.TabIndex = 9;
			this.picImage.TabStop = false;
			// 
			// pnlLogin
			// 
			this.pnlLogin.BackColor = System.Drawing.Color.CornflowerBlue;
			this.pnlLogin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlLogin.Location = new System.Drawing.Point(3, 2);
			this.pnlLogin.Name = "pnlLogin";
			this.pnlLogin.Size = new System.Drawing.Size(28, 22);
			this.pnlLogin.TabIndex = 1;
			this.pnlLogin.Visible = false;
			// 
			// chkRemember
			// 
			this.chkRemember.AutoSize = true;
			this.chkRemember.BackColor = System.Drawing.Color.Gray;
			this.chkRemember.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkRemember.ForeColor = System.Drawing.SystemColors.Window;
			this.chkRemember.Location = new System.Drawing.Point(562, 253);
			this.chkRemember.Name = "chkRemember";
			this.chkRemember.Size = new System.Drawing.Size(131, 20);
			this.chkRemember.TabIndex = 3;
			this.chkRemember.Text = "Remember Me";
			this.chkRemember.UseVisualStyleBackColor = false;
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Verdana", 9.75F);
			this.btnCancel.Location = new System.Drawing.Point(631, 289);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(63, 27);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnLogin
			// 
			this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btnLogin.Font = new System.Drawing.Font("Verdana", 9.75F);
			this.btnLogin.Location = new System.Drawing.Point(562, 289);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(63, 27);
			this.btnLogin.TabIndex = 4;
			this.btnLogin.Text = "&Login";
			this.btnLogin.UseVisualStyleBackColor = false;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// txtPassword
			// 
			this.txtPassword.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPassword.Location = new System.Drawing.Point(562, 222);
			this.txtPassword.MaxLength = 20;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(164, 23);
			this.txtPassword.TabIndex = 2;
			// 
			// txtUserName
			// 
			this.txtUserName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUserName.Location = new System.Drawing.Point(562, 188);
			this.txtUserName.MaxLength = 20;
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(164, 23);
			this.txtUserName.TabIndex = 1;
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lblPassword.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lblPassword.Location = new System.Drawing.Point(478, 225);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(78, 16);
			this.lblPassword.TabIndex = 1;
			this.lblPassword.Text = "Password";
			// 
			// lblLogin
			// 
			this.lblLogin.AutoSize = true;
			this.lblLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.lblLogin.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lblLogin.Location = new System.Drawing.Point(469, 191);
			this.lblLogin.Name = "lblLogin";
			this.lblLogin.Size = new System.Drawing.Size(87, 16);
			this.lblLogin.TabIndex = 0;
			this.lblLogin.Text = "User Name";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label1.Location = new System.Drawing.Point(0, 478);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(114, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "Version 1.0.1";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label2.Location = new System.Drawing.Point(382, 649);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(500, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "ERP  Version 1.0  © 2008 ECGroup Datasoft Pvt. Ltd.";
			// 
			// PCSHelp
			// 
			this.PCSHelp.HelpNamespace = "\\Help\\HelpFile.chm";
			// 
			// lblTrialVersion
			// 
			this.lblTrialVersion.AutoSize = true;
			this.lblTrialVersion.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTrialVersion.ForeColor = System.Drawing.SystemColors.Desktop;
			this.lblTrialVersion.Location = new System.Drawing.Point(413, 500);
			this.lblTrialVersion.Name = "lblTrialVersion";
			this.lblTrialVersion.Size = new System.Drawing.Size(98, 16);
			this.lblTrialVersion.TabIndex = 7;
			this.lblTrialVersion.Text = "Trial Version";
			// 
			// lblCP
			// 
			this.lblCP.AutoSize = true;
			this.lblCP.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCP.ForeColor = System.Drawing.SystemColors.Desktop;
			this.lblCP.Location = new System.Drawing.Point(413, 530);
			this.lblCP.Name = "lblCP";
			this.lblCP.Size = new System.Drawing.Size(391, 16);
			this.lblCP.TabIndex = 8;
			this.lblCP.Text = "Contact Phone : 91 44 2616 1764, 2616 1766 Ext 301";
			// 
			// frmLogin
			// 
			this.AcceptButton = this.btnLogin;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.BackgroundImage = global::ERPWinApp.Properties.Resources.START;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(972, 503);
			this.Controls.Add(this.chkRemember);
			this.Controls.Add(this.lblCP);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.lblTrialVersion);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblPassword);
			this.Controls.Add(this.pnlLogin);
			this.Controls.Add(this.lblLogin);
			this.Controls.Add(this.picImage);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmLogin";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SoftwareName";
			this.Load += new System.EventHandler(this.frmLogin_Load);
			((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkRemember;
        internal System.Windows.Forms.HelpProvider PCSHelp;
        private System.Windows.Forms.Label lblTrialVersion;
        private System.Windows.Forms.Label lblCP;
    }
}
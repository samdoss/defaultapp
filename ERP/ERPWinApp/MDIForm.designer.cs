namespace ERPWinApp
{
    partial class MDIForm
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
            ERP.DataLayer.ActiveUsers _activeUsers = new ERP.DataLayer.ActiveUsers();
            ERP.CommonLayer.TransactionResult removeUserResult = _activeUsers.RemoveActiveUser(MDIForm.UserID);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatusUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusCompanyName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusCopyright = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusSystemDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tstripMenuIcons = new System.Windows.Forms.ToolStrip();
            this.tstripCustomers = new System.Windows.Forms.ToolStripButton();
            this.tstripCustomersBlank1 = new System.Windows.Forms.ToolStripLabel();
            this.tstripInvoice = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripUsers = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel9 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel10 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel11 = new System.Windows.Forms.ToolStripLabel();
            this.tstripInvoiceBlank2 = new System.Windows.Forms.ToolStripLabel();
            this.tstripHelpBlank1 = new System.Windows.Forms.ToolStripLabel();
            this.tstripHelp = new System.Windows.Forms.ToolStripButton();
            this.tstripHelpBlank2 = new System.Windows.Forms.ToolStripLabel();
            this.tstripAdministrationBlank = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLogout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tstripSeparator1 = new System.Windows.Forms.ToolStripLabel();
            this.ApplicationHelp = new System.Windows.Forms.HelpProvider();
            this.tstripExit = new System.Windows.Forms.ToolStripButton();
            this.crToolStripTextBox1 = new CrystalDecisions.Windows.Forms.CRToolStripTextBox();
            this.statusStrip.SuspendLayout();
            this.tstripMenuIcons.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusUserName,
            this.lblStatusCompanyName,
            this.lblStatusCopyright,
            this.lblStatusSystemDate});
            this.statusStrip.Location = new System.Drawing.Point(0, 715);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1020, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // lblStatusUserName
            // 
            this.lblStatusUserName.AutoSize = false;
            this.lblStatusUserName.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblStatusUserName.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.lblStatusUserName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusUserName.Name = "lblStatusUserName";
            this.lblStatusUserName.Size = new System.Drawing.Size(150, 17);
            this.lblStatusUserName.Text = "<Login User Name>";
            this.lblStatusUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatusCompanyName
            // 
            this.lblStatusCompanyName.AutoSize = false;
            this.lblStatusCompanyName.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblStatusCompanyName.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.lblStatusCompanyName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusCompanyName.Name = "lblStatusCompanyName";
            this.lblStatusCompanyName.Size = new System.Drawing.Size(487, 17);
            this.lblStatusCompanyName.Text = "<Company Name>";
            this.lblStatusCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatusCopyright
            // 
            this.lblStatusCopyright.AutoSize = false;
            this.lblStatusCopyright.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblStatusCopyright.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.lblStatusCopyright.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusCopyright.Name = "lblStatusCopyright";
            this.lblStatusCopyright.Size = new System.Drawing.Size(270, 17);
            this.lblStatusCopyright.Text = "©2017 Sams Technologies";
            this.lblStatusCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatusSystemDate
            // 
            this.lblStatusSystemDate.AutoSize = false;
            this.lblStatusSystemDate.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblStatusSystemDate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.lblStatusSystemDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusSystemDate.Name = "lblStatusSystemDate";
            this.lblStatusSystemDate.Size = new System.Drawing.Size(100, 17);
            this.lblStatusSystemDate.Text = "dd/MM/yyyy";
            this.lblStatusSystemDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tstripMenuIcons
            // 
            this.tstripMenuIcons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstripCustomers,
            this.tstripCustomersBlank1,
            this.tstripInvoice,
            this.toolStripLabel1,
            this.toolStripUsers,
            this.toolStripLabel3,
            this.toolStripLabel4,
            this.toolStripLabel5,
            this.toolStripLabel6,
            this.toolStripLabel7,
            this.toolStripLabel8,
            this.toolStripLabel9,
            this.toolStripLabel10,
            this.toolStripLabel11,
            this.tstripInvoiceBlank2,
            this.tstripHelpBlank1,
            this.tstripHelp,
            this.tstripHelpBlank2,
            this.tstripAdministrationBlank,
            this.toolStripLogout,
            this.toolStripSeparator1,
            this.tstripSeparator1,
            this.tstripExit,
            this.crToolStripTextBox1});
            this.tstripMenuIcons.Location = new System.Drawing.Point(0, 0);
            this.tstripMenuIcons.Name = "tstripMenuIcons";
            this.tstripMenuIcons.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tstripMenuIcons.Size = new System.Drawing.Size(1020, 39);
            this.tstripMenuIcons.TabIndex = 4;
            this.tstripMenuIcons.Text = "toolStrip1";
            // 
            // tstripCustomers
            // 
            this.tstripCustomers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tstripCustomers.Image = ((System.Drawing.Image)(resources.GetObject("tstripCustomers.Image")));
            this.tstripCustomers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tstripCustomers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstripCustomers.Name = "tstripCustomers";
            this.tstripCustomers.Size = new System.Drawing.Size(34, 36);
            this.tstripCustomers.Text = "Customers";
            // 
            // tstripCustomersBlank1
            // 
            this.tstripCustomersBlank1.AutoSize = false;
            this.tstripCustomersBlank1.Name = "tstripCustomersBlank1";
            this.tstripCustomersBlank1.Size = new System.Drawing.Size(16, 34);
            // 
            // tstripInvoice
            // 
            this.tstripInvoice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tstripInvoice.Image = ((System.Drawing.Image)(resources.GetObject("tstripInvoice.Image")));
            this.tstripInvoice.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tstripInvoice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstripInvoice.Name = "tstripInvoice";
            this.tstripInvoice.Size = new System.Drawing.Size(34, 36);
            this.tstripInvoice.Text = "Invoice";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(60, 34);
            // 
            // toolStripUsers
            // 
            this.toolStripUsers.AutoSize = false;
            this.toolStripUsers.Name = "toolStripUsers";
            this.toolStripUsers.Size = new System.Drawing.Size(60, 34);
            this.toolStripUsers.Text = "Users";
            this.toolStripUsers.ToolTipText = "Users";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.AutoSize = false;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(60, 34);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.AutoSize = false;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(60, 34);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.AutoSize = false;
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(60, 34);
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.AutoSize = false;
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(60, 34);
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.AutoSize = false;
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(60, 34);
            // 
            // toolStripLabel8
            // 
            this.toolStripLabel8.AutoSize = false;
            this.toolStripLabel8.Name = "toolStripLabel8";
            this.toolStripLabel8.Size = new System.Drawing.Size(60, 34);
            // 
            // toolStripLabel9
            // 
            this.toolStripLabel9.AutoSize = false;
            this.toolStripLabel9.Name = "toolStripLabel9";
            this.toolStripLabel9.Size = new System.Drawing.Size(60, 34);
            // 
            // toolStripLabel10
            // 
            this.toolStripLabel10.AutoSize = false;
            this.toolStripLabel10.Name = "toolStripLabel10";
            this.toolStripLabel10.Size = new System.Drawing.Size(60, 34);
            // 
            // toolStripLabel11
            // 
            this.toolStripLabel11.AutoSize = false;
            this.toolStripLabel11.Name = "toolStripLabel11";
            this.toolStripLabel11.Size = new System.Drawing.Size(60, 34);
            // 
            // tstripInvoiceBlank2
            // 
            this.tstripInvoiceBlank2.AutoSize = false;
            this.tstripInvoiceBlank2.Name = "tstripInvoiceBlank2";
            this.tstripInvoiceBlank2.Size = new System.Drawing.Size(33, 34);
            // 
            // tstripHelpBlank1
            // 
            this.tstripHelpBlank1.AutoSize = false;
            this.tstripHelpBlank1.Name = "tstripHelpBlank1";
            this.tstripHelpBlank1.Size = new System.Drawing.Size(20, 34);
            // 
            // tstripHelp
            // 
            this.tstripHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tstripHelp.Image = ((System.Drawing.Image)(resources.GetObject("tstripHelp.Image")));
            this.tstripHelp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tstripHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstripHelp.Name = "tstripHelp";
            this.tstripHelp.Size = new System.Drawing.Size(34, 36);
            this.tstripHelp.Text = "Help";
            this.tstripHelp.Click += new System.EventHandler(this.tstripHelp_Click);
            // 
            // tstripHelpBlank2
            // 
            this.tstripHelpBlank2.AutoSize = false;
            this.tstripHelpBlank2.Name = "tstripHelpBlank2";
            this.tstripHelpBlank2.Size = new System.Drawing.Size(13, 34);
            // 
            // tstripAdministrationBlank
            // 
            this.tstripAdministrationBlank.AutoSize = false;
            this.tstripAdministrationBlank.Name = "tstripAdministrationBlank";
            this.tstripAdministrationBlank.Size = new System.Drawing.Size(60, 34);
            // 
            // toolStripLogout
            // 
            this.toolStripLogout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLogout.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLogout.Image")));
            this.toolStripLogout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLogout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLogout.Name = "toolStripLogout";
            this.toolStripLogout.Size = new System.Drawing.Size(36, 36);
            this.toolStripLogout.Text = "Logout";
            this.toolStripLogout.ToolTipText = "Logout";
            this.toolStripLogout.Click += new System.EventHandler(this.toolStripLogout_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tstripSeparator1
            // 
            this.tstripSeparator1.AutoSize = false;
            this.tstripSeparator1.Name = "tstripSeparator1";
            this.tstripSeparator1.Size = new System.Drawing.Size(5, 34);
            // 
            // ApplicationHelp
            // 
            this.ApplicationHelp.HelpNamespace = "\\Help\\HelpFile.chm";
            // 
            // tstripExit
            // 
            this.tstripExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tstripExit.Image = ((System.Drawing.Image)(resources.GetObject("tstripExit.Image")));
            this.tstripExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tstripExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstripExit.Name = "tstripExit";
            this.tstripExit.Size = new System.Drawing.Size(36, 36);
            this.tstripExit.Text = "Exit";
            this.tstripExit.Click += new System.EventHandler(this.tstripExit_Click);
            // 
            // crToolStripTextBox1
            // 
            this.crToolStripTextBox1.Name = "crToolStripTextBox1";
            this.crToolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            // 
            // MDIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::ERPWinApp.Properties.Resources.backgroundimage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1020, 737);
            this.Controls.Add(this.tstripMenuIcons);
            this.Controls.Add(this.statusStrip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MDIForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERP (V.1.0.1)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDIPCS_FormClosing);
            this.Load += new System.EventHandler(this.MDIPCS_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MDIPCS_KeyPress);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tstripMenuIcons.ResumeLayout(false);
            this.tstripMenuIcons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.ToolStrip tstripMenuIcons;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusCopyright;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusUserName;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusSystemDate;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusCompanyName;
        private System.Windows.Forms.ToolStripButton tstripCustomers;
        private System.Windows.Forms.ToolStripButton tstripInvoice;
        private System.Windows.Forms.ToolStripButton tstripHelp;
        private System.Windows.Forms.ToolStripLabel tstripInvoiceBlank2;
        private System.Windows.Forms.ToolStripLabel tstripSeparator1;
        private System.Windows.Forms.ToolStripLabel tstripHelpBlank1;
        private System.Windows.Forms.ToolStripLabel tstripHelpBlank2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripLogout;
        private System.Windows.Forms.ToolStripLabel tstripAdministrationBlank;
        internal System.Windows.Forms.HelpProvider ApplicationHelp;
        private System.Windows.Forms.ToolStripLabel tstripCustomersBlank1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripUsers;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel7;
        private System.Windows.Forms.ToolStripLabel toolStripLabel8;
        private System.Windows.Forms.ToolStripLabel toolStripLabel9;
        private System.Windows.Forms.ToolStripLabel toolStripLabel10;
        private System.Windows.Forms.ToolStripLabel toolStripLabel11;
        private System.Windows.Forms.ToolStripButton tstripExit;
        private CrystalDecisions.Windows.Forms.CRToolStripTextBox crToolStripTextBox1;
    }
}




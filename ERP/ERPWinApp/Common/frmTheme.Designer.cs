namespace ERPWinApp
{
    partial class frmTheme
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
            this.pnlRoot = new System.Windows.Forms.Panel();
            this.lblMsgColor = new System.Windows.Forms.Label();
            this.lblUserMsg = new System.Windows.Forms.Label();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblSubHeading = new System.Windows.Forms.Label();
            this.ddlSubHeadFontName = new System.Windows.Forms.ComboBox();
            this.ddlColorName = new System.Windows.Forms.ComboBox();
            this.ddlFontName = new System.Windows.Forms.ComboBox();
            this.lblSubFontName = new System.Windows.Forms.Label();
            this.lblColorName = new System.Windows.Forms.Label();
            this.lblFontName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.ApplicationHelpProvider = new System.Windows.Forms.HelpProvider();
            this.pnlRoot.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRoot
            // 
            this.pnlRoot.Controls.Add(this.lblMsgColor);
            this.pnlRoot.Controls.Add(this.lblUserMsg);
            this.pnlRoot.Controls.Add(this.pnlSettings);
            this.pnlRoot.Location = new System.Drawing.Point(2, 63);
            this.pnlRoot.Name = "pnlRoot";
            this.pnlRoot.Size = new System.Drawing.Size(431, 204);
            this.pnlRoot.TabIndex = 0;
            // 
            // lblMsgColor
            // 
            this.lblMsgColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblMsgColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMsgColor.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgColor.Location = new System.Drawing.Point(63, 8);
            this.lblMsgColor.Name = "lblMsgColor";
            this.lblMsgColor.Size = new System.Drawing.Size(51, 17);
            this.lblMsgColor.TabIndex = 249;
            this.lblMsgColor.Text = "Yellow";
            this.lblMsgColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserMsg
            // 
            this.lblUserMsg.AutoSize = true;
            this.lblUserMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblUserMsg.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserMsg.Location = new System.Drawing.Point(10, 9);
            this.lblUserMsg.Name = "lblUserMsg";
            this.lblUserMsg.Size = new System.Drawing.Size(267, 13);
            this.lblUserMsg.TabIndex = 248;
            this.lblUserMsg.Text = "Fields in               must be entered / selected";
            // 
            // pnlSettings
            // 
            this.pnlSettings.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSettings.Controls.Add(this.btnClose);
            this.pnlSettings.Controls.Add(this.lblSubHeading);
            this.pnlSettings.Controls.Add(this.ddlSubHeadFontName);
            this.pnlSettings.Controls.Add(this.ddlColorName);
            this.pnlSettings.Controls.Add(this.ddlFontName);
            this.pnlSettings.Controls.Add(this.lblSubFontName);
            this.pnlSettings.Controls.Add(this.lblColorName);
            this.pnlSettings.Controls.Add(this.lblFontName);
            this.pnlSettings.Controls.Add(this.btnSave);
            this.pnlSettings.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSettings.Location = new System.Drawing.Point(9, 34);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(419, 168);
            this.pnlSettings.TabIndex = 10;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnClose.Location = new System.Drawing.Point(341, 134);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 27);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblSubHeading
            // 
            this.lblSubHeading.AutoSize = true;
            this.lblSubHeading.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubHeading.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSubHeading.Location = new System.Drawing.Point(20, 15);
            this.lblSubHeading.Name = "lblSubHeading";
            this.lblSubHeading.Size = new System.Drawing.Size(130, 16);
            this.lblSubHeading.TabIndex = 3;
            this.lblSubHeading.Text = "Fonts and Colors";
            // 
            // ddlSubHeadFontName
            // 
            this.ddlSubHeadFontName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ddlSubHeadFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSubHeadFontName.FormattingEnabled = true;
            this.ddlSubHeadFontName.Location = new System.Drawing.Point(196, 74);
            this.ddlSubHeadFontName.Name = "ddlSubHeadFontName";
            this.ddlSubHeadFontName.Size = new System.Drawing.Size(208, 24);
            this.ddlSubHeadFontName.TabIndex = 5;
            this.ddlSubHeadFontName.SelectedIndexChanged += new System.EventHandler(this.ddlSubHeadFontName_SelectedIndexChanged);
            // 
            // ddlColorName
            // 
            this.ddlColorName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ddlColorName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlColorName.FormattingEnabled = true;
            this.ddlColorName.Location = new System.Drawing.Point(196, 104);
            this.ddlColorName.Name = "ddlColorName";
            this.ddlColorName.Size = new System.Drawing.Size(208, 24);
            this.ddlColorName.TabIndex = 7;
            this.ddlColorName.SelectedIndexChanged += new System.EventHandler(this.ddlColorName_SelectedIndexChanged);
            // 
            // ddlFontName
            // 
            this.ddlFontName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ddlFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFontName.FormattingEnabled = true;
            this.ddlFontName.Location = new System.Drawing.Point(196, 44);
            this.ddlFontName.Name = "ddlFontName";
            this.ddlFontName.Size = new System.Drawing.Size(208, 24);
            this.ddlFontName.TabIndex = 2;
            this.ddlFontName.SelectedIndexChanged += new System.EventHandler(this.ddlFontName_SelectedIndexChanged);
            // 
            // lblSubFontName
            // 
            this.lblSubFontName.AutoSize = true;
            this.lblSubFontName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubFontName.Location = new System.Drawing.Point(65, 77);
            this.lblSubFontName.Name = "lblSubFontName";
            this.lblSubFontName.Size = new System.Drawing.Size(125, 16);
            this.lblSubFontName.TabIndex = 4;
            this.lblSubFontName.Text = "Sub Heading Font";
            // 
            // lblColorName
            // 
            this.lblColorName.AutoSize = true;
            this.lblColorName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColorName.Location = new System.Drawing.Point(27, 107);
            this.lblColorName.Name = "lblColorName";
            this.lblColorName.Size = new System.Drawing.Size(163, 16);
            this.lblColorName.TabIndex = 6;
            this.lblColorName.Text = "Color for Both Headings";
            // 
            // lblFontName
            // 
            this.lblFontName.AutoSize = true;
            this.lblFontName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFontName.Location = new System.Drawing.Point(95, 47);
            this.lblFontName.Name = "lblFontName";
            this.lblFontName.Size = new System.Drawing.Size(95, 16);
            this.lblFontName.TabIndex = 1;
            this.lblFontName.Text = "Heading Font";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnSave.Location = new System.Drawing.Point(272, 134);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 27);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(-2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(447, 60);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Theme Settings";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ApplicationHelpProvider
            // 
            this.ApplicationHelpProvider.HelpNamespace = "\\Help\\HelpFile.chm";
            // 
            // frmTheme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 270);
            this.ControlBox = false;
            this.Controls.Add(this.pnlRoot);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTheme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Theme Settings";
            this.Load += new System.EventHandler(this.frmTheme_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmTheme_KeyPress);
            this.pnlRoot.ResumeLayout(false);
            this.pnlRoot.PerformLayout();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRoot;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMsgColor;
        private System.Windows.Forms.Label lblUserMsg;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblSubHeading;
        private System.Windows.Forms.ComboBox ddlSubHeadFontName;
        private System.Windows.Forms.ComboBox ddlColorName;
        private System.Windows.Forms.ComboBox ddlFontName;
        private System.Windows.Forms.Label lblSubFontName;
        private System.Windows.Forms.Label lblColorName;
        private System.Windows.Forms.Label lblFontName;
        private System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.HelpProvider ApplicationHelpProvider;
    }
}
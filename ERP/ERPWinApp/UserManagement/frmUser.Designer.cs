namespace ERPWinApp
{
    partial class frmUser
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
            this.lblCaption = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPhoto = new System.Windows.Forms.Label();
            this.lblContactInfo = new System.Windows.Forms.Label();
            this.pnlContactInfo = new System.Windows.Forms.Panel();
            this.txtSTD1 = new System.Windows.Forms.TextBox();
            this.lblPhone2 = new System.Windows.Forms.Label();
            this.txtSTD2 = new System.Windows.Forms.TextBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.txtPhone2 = new System.Windows.Forms.TextBox();
            this.txtPhone1 = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.ddlCountry = new System.Windows.Forms.ComboBox();
            this.ddlState = new System.Windows.Forms.ComboBox();
            this.ddlCity = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtPincode = new System.Windows.Forms.TextBox();
            this.lblPhone1 = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblPincode = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblMobile = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtAddress3 = new System.Windows.Forms.TextBox();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.pnlPatientInfo = new System.Windows.Forms.Panel();
            this.lblddMonYear = new System.Windows.Forms.Label();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.txtDOB = new System.Windows.Forms.MaskedTextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtQualification = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.lblDesignation = new System.Windows.Forms.Label();
            this.lblQualification = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlRole = new System.Windows.Forms.ComboBox();
            this.ddlGender = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.ddlTitle = new System.Windows.Forms.ComboBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.pnlDoctorInfo = new System.Windows.Forms.Panel();
            this.txtAadharNo = new System.Windows.Forms.TextBox();
            this.lblRegNo = new System.Windows.Forms.Label();
            this.lblBasicInfo = new System.Windows.Forms.Label();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.pnlPhotoBtn = new System.Windows.Forms.Panel();
            this.btnPhoto = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblDoctorInfo = new System.Windows.Forms.Label();
            this.lblMsgColor = new System.Windows.Forms.Label();
            this.lblUserMsg = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ApplicationHelpProvider = new System.Windows.Forms.HelpProvider();
            this.pnlContactInfo.SuspendLayout();
            this.pnlPatientInfo.SuspendLayout();
            this.pnlDoctorInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            this.pnlPhotoBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCaption.Font = new System.Drawing.Font("Verdana", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCaption.Location = new System.Drawing.Point(-4, -1);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(973, 75);
            this.lblCaption.TabIndex = 197;
            this.lblCaption.Text = "User / Employee Information";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSearch.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnSearch.Location = new System.Drawing.Point(291, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(63, 27);
            this.btnSearch.TabIndex = 201;
            this.btnSearch.Text = "Searc&h";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnView.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnView.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnView.Location = new System.Drawing.Point(598, 495);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(63, 27);
            this.btnView.TabIndex = 28;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnClose.Location = new System.Drawing.Point(736, 495);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 27);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnSave.Location = new System.Drawing.Point(529, 495);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 27);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPhoto
            // 
            this.lblPhoto.AutoSize = true;
            this.lblPhoto.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPhoto.Location = new System.Drawing.Point(814, 95);
            this.lblPhoto.Name = "lblPhoto";
            this.lblPhoto.Size = new System.Drawing.Size(50, 16);
            this.lblPhoto.TabIndex = 215;
            this.lblPhoto.Text = "Photo";
            // 
            // lblContactInfo
            // 
            this.lblContactInfo.AutoSize = true;
            this.lblContactInfo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblContactInfo.Location = new System.Drawing.Point(416, 95);
            this.lblContactInfo.Name = "lblContactInfo";
            this.lblContactInfo.Size = new System.Drawing.Size(155, 16);
            this.lblContactInfo.TabIndex = 213;
            this.lblContactInfo.Text = "Contact Information";
            // 
            // pnlContactInfo
            // 
            this.pnlContactInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlContactInfo.Controls.Add(this.txtSTD1);
            this.pnlContactInfo.Controls.Add(this.lblPhone2);
            this.pnlContactInfo.Controls.Add(this.txtSTD2);
            this.pnlContactInfo.Controls.Add(this.lblArea);
            this.pnlContactInfo.Controls.Add(this.txtPhone2);
            this.pnlContactInfo.Controls.Add(this.txtPhone1);
            this.pnlContactInfo.Controls.Add(this.txtArea);
            this.pnlContactInfo.Controls.Add(this.ddlCountry);
            this.pnlContactInfo.Controls.Add(this.ddlState);
            this.pnlContactInfo.Controls.Add(this.ddlCity);
            this.pnlContactInfo.Controls.Add(this.txtEmail);
            this.pnlContactInfo.Controls.Add(this.txtMobile);
            this.pnlContactInfo.Controls.Add(this.txtPincode);
            this.pnlContactInfo.Controls.Add(this.lblPhone1);
            this.pnlContactInfo.Controls.Add(this.lblCountry);
            this.pnlContactInfo.Controls.Add(this.lblPincode);
            this.pnlContactInfo.Controls.Add(this.lblEmail);
            this.pnlContactInfo.Controls.Add(this.lblMobile);
            this.pnlContactInfo.Controls.Add(this.lblState);
            this.pnlContactInfo.Controls.Add(this.lblCity);
            this.pnlContactInfo.Controls.Add(this.txtAddress3);
            this.pnlContactInfo.Controls.Add(this.txtAddress2);
            this.pnlContactInfo.Controls.Add(this.txtAddress1);
            this.pnlContactInfo.Controls.Add(this.lblAddress);
            this.pnlContactInfo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlContactInfo.Location = new System.Drawing.Point(419, 114);
            this.pnlContactInfo.Name = "pnlContactInfo";
            this.pnlContactInfo.Size = new System.Drawing.Size(380, 365);
            this.pnlContactInfo.TabIndex = 12;
            // 
            // txtSTD1
            // 
            this.txtSTD1.Location = new System.Drawing.Point(108, 246);
            this.txtSTD1.MaxLength = 6;
            this.txtSTD1.Name = "txtSTD1";
            this.txtSTD1.Size = new System.Drawing.Size(73, 23);
            this.txtSTD1.TabIndex = 21;
            this.txtSTD1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSTD1_KeyPress);
            // 
            // lblPhone2
            // 
            this.lblPhone2.AutoSize = true;
            this.lblPhone2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone2.Location = new System.Drawing.Point(81, 278);
            this.lblPhone2.Name = "lblPhone2";
            this.lblPhone2.Size = new System.Drawing.Size(26, 16);
            this.lblPhone2.TabIndex = 131;
            this.lblPhone2.Text = "#2";
            // 
            // txtSTD2
            // 
            this.txtSTD2.Location = new System.Drawing.Point(108, 275);
            this.txtSTD2.MaxLength = 6;
            this.txtSTD2.Name = "txtSTD2";
            this.txtSTD2.Size = new System.Drawing.Size(73, 23);
            this.txtSTD2.TabIndex = 23;
            this.txtSTD2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSTD2_KeyPress);
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArea.Location = new System.Drawing.Point(17, 97);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(89, 16);
            this.lblArea.TabIndex = 130;
            this.lblArea.Text = "Area / Place";
            // 
            // txtPhone2
            // 
            this.txtPhone2.Location = new System.Drawing.Point(182, 275);
            this.txtPhone2.MaxLength = 10;
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.Size = new System.Drawing.Size(168, 23);
            this.txtPhone2.TabIndex = 24;
            this.txtPhone2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone2_KeyPress);
            // 
            // txtPhone1
            // 
            this.txtPhone1.Location = new System.Drawing.Point(182, 246);
            this.txtPhone1.MaxLength = 10;
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(168, 23);
            this.txtPhone1.TabIndex = 22;
            this.txtPhone1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone1_KeyPress);
            // 
            // txtArea
            // 
            this.txtArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtArea.Location = new System.Drawing.Point(108, 94);
            this.txtArea.MaxLength = 50;
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(242, 23);
            this.txtArea.TabIndex = 16;
            // 
            // ddlCountry
            // 
            this.ddlCountry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ddlCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCountry.FormattingEnabled = true;
            this.ddlCountry.Location = new System.Drawing.Point(108, 123);
            this.ddlCountry.MaxLength = 150;
            this.ddlCountry.Name = "ddlCountry";
            this.ddlCountry.Size = new System.Drawing.Size(242, 24);
            this.ddlCountry.TabIndex = 17;
            this.ddlCountry.Validated += new System.EventHandler(this.ddlCountry_Validated);
            // 
            // ddlState
            // 
            this.ddlState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ddlState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlState.FormattingEnabled = true;
            this.ddlState.Location = new System.Drawing.Point(108, 154);
            this.ddlState.MaxLength = 150;
            this.ddlState.Name = "ddlState";
            this.ddlState.Size = new System.Drawing.Size(242, 24);
            this.ddlState.TabIndex = 18;
            this.ddlState.Validated += new System.EventHandler(this.ddlState_Validated);
            // 
            // ddlCity
            // 
            this.ddlCity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ddlCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCity.FormattingEnabled = true;
            this.ddlCity.Location = new System.Drawing.Point(108, 184);
            this.ddlCity.MaxLength = 150;
            this.ddlCity.Name = "ddlCity";
            this.ddlCity.Size = new System.Drawing.Size(242, 24);
            this.ddlCity.TabIndex = 19;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(108, 333);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(242, 23);
            this.txtEmail.TabIndex = 26;
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // txtMobile
            // 
            this.txtMobile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMobile.Location = new System.Drawing.Point(108, 304);
            this.txtMobile.MaxLength = 10;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(242, 23);
            this.txtMobile.TabIndex = 25;
            this.txtMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobile_KeyPress);
            // 
            // txtPincode
            // 
            this.txtPincode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPincode.Location = new System.Drawing.Point(108, 214);
            this.txtPincode.MaxLength = 6;
            this.txtPincode.Name = "txtPincode";
            this.txtPincode.Size = new System.Drawing.Size(72, 23);
            this.txtPincode.TabIndex = 20;
            this.txtPincode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPincode_KeyPress);
            // 
            // lblPhone1
            // 
            this.lblPhone1.AutoSize = true;
            this.lblPhone1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone1.Location = new System.Drawing.Point(36, 249);
            this.lblPhone1.Name = "lblPhone1";
            this.lblPhone1.Size = new System.Drawing.Size(71, 16);
            this.lblPhone1.TabIndex = 118;
            this.lblPhone1.Text = "Phone #1";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.Location = new System.Drawing.Point(46, 127);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(60, 16);
            this.lblCountry.TabIndex = 117;
            this.lblCountry.Text = "Country";
            // 
            // lblPincode
            // 
            this.lblPincode.AutoSize = true;
            this.lblPincode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPincode.Location = new System.Drawing.Point(48, 217);
            this.lblPincode.Name = "lblPincode";
            this.lblPincode.Size = new System.Drawing.Size(59, 16);
            this.lblPincode.TabIndex = 116;
            this.lblPincode.Text = "Pincode";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(47, 336);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(60, 16);
            this.lblEmail.TabIndex = 115;
            this.lblEmail.Text = "Email ID";
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobile.Location = new System.Drawing.Point(42, 307);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(64, 16);
            this.lblMobile.TabIndex = 114;
            this.lblMobile.Text = "Mobile #";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(61, 157);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(45, 16);
            this.lblState.TabIndex = 113;
            this.lblState.Text = "State";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(9, 188);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(97, 16);
            this.lblCity.TabIndex = 112;
            this.lblCity.Text = "City / District";
            // 
            // txtAddress3
            // 
            this.txtAddress3.BackColor = System.Drawing.SystemColors.Window;
            this.txtAddress3.Location = new System.Drawing.Point(108, 67);
            this.txtAddress3.MaxLength = 100;
            this.txtAddress3.Name = "txtAddress3";
            this.txtAddress3.Size = new System.Drawing.Size(242, 23);
            this.txtAddress3.TabIndex = 15;
            // 
            // txtAddress2
            // 
            this.txtAddress2.BackColor = System.Drawing.SystemColors.Window;
            this.txtAddress2.Location = new System.Drawing.Point(108, 38);
            this.txtAddress2.MaxLength = 100;
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(242, 23);
            this.txtAddress2.TabIndex = 14;
            // 
            // txtAddress1
            // 
            this.txtAddress1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAddress1.Location = new System.Drawing.Point(108, 9);
            this.txtAddress1.MaxLength = 100;
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(242, 23);
            this.txtAddress1.TabIndex = 13;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(47, 12);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(60, 16);
            this.lblAddress.TabIndex = 108;
            this.lblAddress.Text = "Address";
            // 
            // pnlPatientInfo
            // 
            this.pnlPatientInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPatientInfo.Controls.Add(this.lblddMonYear);
            this.pnlPatientInfo.Controls.Add(this.dtpDOB);
            this.pnlPatientInfo.Controls.Add(this.txtDOB);
            this.pnlPatientInfo.Controls.Add(this.txtUserName);
            this.pnlPatientInfo.Controls.Add(this.txtQualification);
            this.pnlPatientInfo.Controls.Add(this.lblUserName);
            this.pnlPatientInfo.Controls.Add(this.txtDesignation);
            this.pnlPatientInfo.Controls.Add(this.lblDesignation);
            this.pnlPatientInfo.Controls.Add(this.lblQualification);
            this.pnlPatientInfo.Controls.Add(this.btnSearch);
            this.pnlPatientInfo.Controls.Add(this.lblAge);
            this.pnlPatientInfo.Controls.Add(this.label3);
            this.pnlPatientInfo.Controls.Add(this.ddlRole);
            this.pnlPatientInfo.Controls.Add(this.ddlGender);
            this.pnlPatientInfo.Controls.Add(this.lblGender);
            this.pnlPatientInfo.Controls.Add(this.lblDOB);
            this.pnlPatientInfo.Controls.Add(this.txtName);
            this.pnlPatientInfo.Controls.Add(this.lblTitle);
            this.pnlPatientInfo.Controls.Add(this.lblName);
            this.pnlPatientInfo.Controls.Add(this.ddlTitle);
            this.pnlPatientInfo.Controls.Add(this.txtUserID);
            this.pnlPatientInfo.Location = new System.Drawing.Point(12, 114);
            this.pnlPatientInfo.Name = "pnlPatientInfo";
            this.pnlPatientInfo.Size = new System.Drawing.Size(399, 242);
            this.pnlPatientInfo.TabIndex = 0;
            // 
            // lblddMonYear
            // 
            this.lblddMonYear.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblddMonYear.Location = new System.Drawing.Point(235, 99);
            this.lblddMonYear.Name = "lblddMonYear";
            this.lblddMonYear.Size = new System.Drawing.Size(75, 16);
            this.lblddMonYear.TabIndex = 286;
            this.lblddMonYear.Text = "(dd/mm/yyyy)";
            // 
            // dtpDOB
            // 
            this.dtpDOB.CalendarMonthBackground = System.Drawing.SystemColors.Menu;
            this.dtpDOB.CustomFormat = "dd/MM/yyyy";
            this.dtpDOB.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDOB.Location = new System.Drawing.Point(117, 93);
            this.dtpDOB.MaxDate = new System.DateTime(2000, 8, 6, 0, 0, 0, 0);
            this.dtpDOB.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.ShowUpDown = true;
            this.dtpDOB.Size = new System.Drawing.Size(112, 23);
            this.dtpDOB.TabIndex = 225;
            this.dtpDOB.Value = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.dtpDOB.ValueChanged += new System.EventHandler(this.dtpDOB_ValueChanged);
            // 
            // txtDOB
            // 
            this.txtDOB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDOB.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDOB.Location = new System.Drawing.Point(117, 93);
            this.txtDOB.Mask = "00/00/0000";
            this.txtDOB.Name = "txtDOB";
            this.txtDOB.Size = new System.Drawing.Size(76, 23);
            this.txtDOB.TabIndex = 227;
            this.txtDOB.ValidatingType = typeof(System.DateTime);
            this.txtDOB.Visible = false;
            this.txtDOB.Validated += new System.EventHandler(this.txtDOB_Validated);
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtUserName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(117, 6);
            this.txtUserName.MaxLength = 100;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(168, 23);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // txtQualification
            // 
            this.txtQualification.BackColor = System.Drawing.Color.White;
            this.txtQualification.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQualification.Location = new System.Drawing.Point(117, 211);
            this.txtQualification.MaxLength = 255;
            this.txtQualification.Name = "txtQualification";
            this.txtQualification.Size = new System.Drawing.Size(266, 23);
            this.txtQualification.TabIndex = 8;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(3, 9);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(111, 16);
            this.lblUserName.TabIndex = 223;
            this.lblUserName.Text = "User/Emp Name";
            // 
            // txtDesignation
            // 
            this.txtDesignation.BackColor = System.Drawing.Color.White;
            this.txtDesignation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesignation.Location = new System.Drawing.Point(117, 182);
            this.txtDesignation.MaxLength = 50;
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.Size = new System.Drawing.Size(266, 23);
            this.txtDesignation.TabIndex = 7;
            // 
            // lblDesignation
            // 
            this.lblDesignation.AutoSize = true;
            this.lblDesignation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesignation.Location = new System.Drawing.Point(31, 185);
            this.lblDesignation.Name = "lblDesignation";
            this.lblDesignation.Size = new System.Drawing.Size(84, 16);
            this.lblDesignation.TabIndex = 222;
            this.lblDesignation.Text = "Designation";
            // 
            // lblQualification
            // 
            this.lblQualification.AutoSize = true;
            this.lblQualification.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQualification.Location = new System.Drawing.Point(26, 214);
            this.lblQualification.Name = "lblQualification";
            this.lblQualification.Size = new System.Drawing.Size(89, 16);
            this.lblQualification.TabIndex = 221;
            this.lblQualification.Text = "Qualification";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.Location = new System.Drawing.Point(309, 97);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(45, 16);
            this.lblAge.TabIndex = 88;
            this.lblAge.Text = "(Age)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(80, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 217;
            this.label3.Text = "Role";
            // 
            // ddlRole
            // 
            this.ddlRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ddlRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlRole.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlRole.FormattingEnabled = true;
            this.ddlRole.Location = new System.Drawing.Point(117, 152);
            this.ddlRole.Name = "ddlRole";
            this.ddlRole.Size = new System.Drawing.Size(266, 24);
            this.ddlRole.TabIndex = 6;
            this.ddlRole.SelectedValueChanged += new System.EventHandler(this.ddlRole_SelectedValueChanged);
            // 
            // ddlGender
            // 
            this.ddlGender.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlGender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ddlGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGender.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlGender.FormattingEnabled = true;
            this.ddlGender.Location = new System.Drawing.Point(117, 122);
            this.ddlGender.Name = "ddlGender";
            this.ddlGender.Size = new System.Drawing.Size(112, 24);
            this.ddlGender.TabIndex = 5;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(61, 125);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(54, 16);
            this.lblGender.TabIndex = 85;
            this.lblGender.Text = "Gender";
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOB.Location = new System.Drawing.Point(21, 97);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(92, 16);
            this.lblDOB.TabIndex = 84;
            this.lblDOB.Text = "Date of Birth";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(117, 64);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(266, 23);
            this.txtName.TabIndex = 3;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(78, 38);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(37, 16);
            this.lblTitle.TabIndex = 69;
            this.lblTitle.Text = "Title";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(71, 67);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 16);
            this.lblName.TabIndex = 70;
            this.lblName.Text = "Name";
            // 
            // ddlTitle
            // 
            this.ddlTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ddlTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTitle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlTitle.FormattingEnabled = true;
            this.ddlTitle.Location = new System.Drawing.Point(117, 35);
            this.ddlTitle.Name = "ddlTitle";
            this.ddlTitle.Size = new System.Drawing.Size(112, 24);
            this.ddlTitle.TabIndex = 2;
            this.ddlTitle.TextChanged += new System.EventHandler(this.ddlTitle_TextChanged);
            // 
            // txtUserID
            // 
            this.txtUserID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtUserID.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.Location = new System.Drawing.Point(205, 6);
            this.txtUserID.MaxLength = 100;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(17, 23);
            this.txtUserID.TabIndex = 226;
            this.txtUserID.Visible = false;
            // 
            // pnlDoctorInfo
            // 
            this.pnlDoctorInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDoctorInfo.Controls.Add(this.txtAadharNo);
            this.pnlDoctorInfo.Controls.Add(this.lblRegNo);
            this.pnlDoctorInfo.Location = new System.Drawing.Point(18, 377);
            this.pnlDoctorInfo.Name = "pnlDoctorInfo";
            this.pnlDoctorInfo.Size = new System.Drawing.Size(388, 198);
            this.pnlDoctorInfo.TabIndex = 229;
            // 
            // txtAadharNo
            // 
            this.txtAadharNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAadharNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAadharNo.Location = new System.Drawing.Point(102, 4);
            this.txtAadharNo.MaxLength = 15;
            this.txtAadharNo.Name = "txtAadharNo";
            this.txtAadharNo.Size = new System.Drawing.Size(266, 23);
            this.txtAadharNo.TabIndex = 227;
            // 
            // lblRegNo
            // 
            this.lblRegNo.AutoSize = true;
            this.lblRegNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegNo.Location = new System.Drawing.Point(2, 7);
            this.lblRegNo.Name = "lblRegNo";
            this.lblRegNo.Size = new System.Drawing.Size(69, 16);
            this.lblRegNo.TabIndex = 228;
            this.lblRegNo.Text = "Aadhar #";
            // 
            // lblBasicInfo
            // 
            this.lblBasicInfo.AutoSize = true;
            this.lblBasicInfo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBasicInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBasicInfo.Location = new System.Drawing.Point(15, 95);
            this.lblBasicInfo.Name = "lblBasicInfo";
            this.lblBasicInfo.Size = new System.Drawing.Size(137, 16);
            this.lblBasicInfo.TabIndex = 222;
            this.lblBasicInfo.Text = "Basic Information";
            // 
            // picPhoto
            // 
            this.picPhoto.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPhoto.Location = new System.Drawing.Point(817, 113);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(140, 180);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPhoto.TabIndex = 237;
            this.picPhoto.TabStop = false;
            // 
            // pnlPhotoBtn
            // 
            this.pnlPhotoBtn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPhotoBtn.Controls.Add(this.btnPhoto);
            this.pnlPhotoBtn.Controls.Add(this.btnClear);
            this.pnlPhotoBtn.Location = new System.Drawing.Point(817, 302);
            this.pnlPhotoBtn.Name = "pnlPhotoBtn";
            this.pnlPhotoBtn.Size = new System.Drawing.Size(140, 41);
            this.pnlPhotoBtn.TabIndex = 238;
            // 
            // btnPhoto
            // 
            this.btnPhoto.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPhoto.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhoto.Location = new System.Drawing.Point(3, 7);
            this.btnPhoto.Name = "btnPhoto";
            this.btnPhoto.Size = new System.Drawing.Size(63, 27);
            this.btnPhoto.TabIndex = 31;
            this.btnPhoto.Text = "Se&lect";
            this.btnPhoto.UseVisualStyleBackColor = false;
            this.btnPhoto.Click += new System.EventHandler(this.btnPhoto_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClear.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(68, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(63, 27);
            this.btnClear.TabIndex = 32;
            this.btnClear.Text = "Cl&ear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblDoctorInfo
            // 
            this.lblDoctorInfo.AutoSize = true;
            this.lblDoctorInfo.BackColor = System.Drawing.SystemColors.Control;
            this.lblDoctorInfo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoctorInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDoctorInfo.Location = new System.Drawing.Point(15, 358);
            this.lblDoctorInfo.Name = "lblDoctorInfo";
            this.lblDoctorInfo.Size = new System.Drawing.Size(171, 16);
            this.lblDoctorInfo.TabIndex = 239;
            this.lblDoctorInfo.Text = "Additional Information";
            // 
            // lblMsgColor
            // 
            this.lblMsgColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblMsgColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMsgColor.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgColor.Location = new System.Drawing.Point(68, 75);
            this.lblMsgColor.Name = "lblMsgColor";
            this.lblMsgColor.Size = new System.Drawing.Size(49, 19);
            this.lblMsgColor.TabIndex = 241;
            this.lblMsgColor.Text = "Yellow";
            this.lblMsgColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserMsg
            // 
            this.lblUserMsg.AutoSize = true;
            this.lblUserMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblUserMsg.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserMsg.Location = new System.Drawing.Point(14, 76);
            this.lblUserMsg.Name = "lblUserMsg";
            this.lblUserMsg.Size = new System.Drawing.Size(267, 13);
            this.lblUserMsg.TabIndex = 240;
            this.lblUserMsg.Text = "Fields in               must be entered / selected";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnCancel.Location = new System.Drawing.Point(667, 495);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 27);
            this.btnCancel.TabIndex = 242;
            this.btnCancel.Text = "&Reset";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ApplicationHelpProvider
            // 
            this.ApplicationHelpProvider.HelpNamespace = "\\Help\\HelpFile.chm";
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 580);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblMsgColor);
            this.Controls.Add(this.lblUserMsg);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lblDoctorInfo);
            this.Controls.Add(this.picPhoto);
            this.Controls.Add(this.pnlDoctorInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlPhotoBtn);
            this.Controls.Add(this.lblBasicInfo);
            this.Controls.Add(this.lblPhoto);
            this.Controls.Add(this.lblContactInfo);
            this.Controls.Add(this.pnlContactInfo);
            this.Controls.Add(this.pnlPatientInfo);
            this.Controls.Add(this.lblCaption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Information";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmUser_KeyPress);
            this.pnlContactInfo.ResumeLayout(false);
            this.pnlContactInfo.PerformLayout();
            this.pnlPatientInfo.ResumeLayout(false);
            this.pnlPatientInfo.PerformLayout();
            this.pnlDoctorInfo.ResumeLayout(false);
            this.pnlDoctorInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.pnlPhotoBtn.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPhoto;
        private System.Windows.Forms.Label lblContactInfo;
        private System.Windows.Forms.Panel pnlContactInfo;
        private System.Windows.Forms.Label lblPhone2;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.ComboBox ddlCountry;
        private System.Windows.Forms.ComboBox ddlState;
        private System.Windows.Forms.ComboBox ddlCity;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtPincode;
        private System.Windows.Forms.Label lblPhone1;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblPincode;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtAddress3;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Panel pnlPatientInfo;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.ComboBox ddlGender;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox ddlTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlRole;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblBasicInfo;
        private System.Windows.Forms.Label lblDesignation;
        private System.Windows.Forms.Label lblQualification;
        private System.Windows.Forms.TextBox txtQualification;
        private System.Windows.Forms.TextBox txtDesignation;
        private System.Windows.Forms.TextBox txtSTD1;
        private System.Windows.Forms.TextBox txtSTD2;
        private System.Windows.Forms.TextBox txtPhone2;
        private System.Windows.Forms.TextBox txtPhone1;
        private System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.Panel pnlPhotoBtn;
        private System.Windows.Forms.Button btnPhoto;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlDoctorInfo;
        private System.Windows.Forms.Label lblDoctorInfo;
        private System.Windows.Forms.Label lblMsgColor;
        private System.Windows.Forms.Label lblUserMsg;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtAadharNo;
        private System.Windows.Forms.Label lblRegNo;
        internal System.Windows.Forms.HelpProvider ApplicationHelpProvider;
        private System.Windows.Forms.MaskedTextBox txtDOB;
        private System.Windows.Forms.Label lblddMonYear;
    }
}
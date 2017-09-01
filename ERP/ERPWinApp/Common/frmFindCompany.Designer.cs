namespace ERPWinApp
{
    partial class frmFindCompany

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
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblCaption = new System.Windows.Forms.Label();
            this.lsDrugList = new System.Windows.Forms.ListView();
            this.CompanyNames = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BrandName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.City = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PhoneNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DrugCompanyNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.White;
            this.txtUserName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(16, 109);
            this.txtUserName.MaxLength = 40;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(192, 23);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(13, 88);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(415, 16);
            this.lblName.TabIndex = 198;
            this.lblName.Text = "&Search Drug Company by Company Name, Place and Phone #";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnCancel.Location = new System.Drawing.Point(706, 402);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 27);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnOk.Location = new System.Drawing.Point(637, 402);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(63, 27);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCaption.Font = new System.Drawing.Font("Verdana", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCaption.Location = new System.Drawing.Point(-3, -1);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(801, 76);
            this.lblCaption.TabIndex = 203;
            this.lblCaption.Text = "Search Company";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lsDrugList
            // 
            this.lsDrugList.AllowColumnReorder = true;
            this.lsDrugList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CompanyNames,
            this.BrandName,
            this.City,
            this.PhoneNumber,
            this.DrugCompanyNo});
            this.lsDrugList.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsDrugList.FullRowSelect = true;
            this.lsDrugList.Location = new System.Drawing.Point(14, 139);
            this.lsDrugList.MultiSelect = false;
            this.lsDrugList.Name = "lsDrugList";
            this.lsDrugList.Size = new System.Drawing.Size(755, 257);
            this.lsDrugList.TabIndex = 1;
            this.lsDrugList.UseCompatibleStateImageBehavior = false;
            this.lsDrugList.View = System.Windows.Forms.View.Details;
            this.lsDrugList.DoubleClick += new System.EventHandler(this.lsDrugList_DoubleClick);
            // 
            // CompanyNames
            // 
            this.CompanyNames.Text = "Company Name";
            this.CompanyNames.Width = 250;
            // 
            // BrandName
            // 
            this.BrandName.Text = "Brand Name";
            this.BrandName.Width = 145;
            // 
            // City
            // 
            this.City.Text = "City";
            this.City.Width = 114;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.Text = "Phone #";
            this.PhoneNumber.Width = 218;
            // 
            // DrugCompanyNo
            // 
            this.DrugCompanyNo.Text = "Company Number";
            this.DrugCompanyNo.Width = 0;
            // 
            // frmFindCompany
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(782, 436);
            this.ControlBox = false;
            this.Controls.Add(this.lsDrugList);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblCaption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFindCompany";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Company";
            this.Load += new System.EventHandler(this.frmFindUser_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmFindUser_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.ListView lsDrugList;
        private System.Windows.Forms.ColumnHeader CompanyNames;
        private System.Windows.Forms.ColumnHeader BrandName;
        private System.Windows.Forms.ColumnHeader City;
        private System.Windows.Forms.ColumnHeader PhoneNumber;
        private System.Windows.Forms.ColumnHeader DrugCompanyNo;

    }
}
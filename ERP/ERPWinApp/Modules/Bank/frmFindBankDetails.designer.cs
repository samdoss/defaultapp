namespace ERPWinApp
{
    partial class frmFindBankDetails
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
            this.txtSearchText = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCaption = new System.Windows.Forms.Label();
            this.listUser = new System.Windows.Forms.ListView();
            this.BankAccountHolderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BankAccountNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BankName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IFSCCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BankDetailID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BranchName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.ApplicationHelpProvider = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // txtSearchText
            // 
            this.txtSearchText.BackColor = System.Drawing.Color.White;
            this.txtSearchText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchText.Location = new System.Drawing.Point(15, 115);
            this.txtSearchText.MaxLength = 40;
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(198, 23);
            this.txtSearchText.TabIndex = 0;
            this.txtSearchText.TextChanged += new System.EventHandler(this.txtSearchText_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(12, 93);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(375, 16);
            this.lblName.TabIndex = 198;
            this.lblName.Text = "&Search By Column name in Fields";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCaption.Font = new System.Drawing.Font("Verdana", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCaption.Location = new System.Drawing.Point(-3, -1);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(802, 80);
            this.lblCaption.TabIndex = 203;
            this.lblCaption.Text = "Search Bank Details";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listUser
            // 
            this.listUser.AllowColumnReorder = true;
            this.listUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BankAccountHolderName,
            this.BankAccountNumber,
            this.BankName,
            this.IFSCCode,
            this.BankDetailID,
            this.BranchName});
            this.listUser.FullRowSelect = true;
            this.listUser.Location = new System.Drawing.Point(14, 144);
            this.listUser.MultiSelect = false;
            this.listUser.Name = "listUser";
            this.listUser.Size = new System.Drawing.Size(771, 268);
            this.listUser.TabIndex = 1;
            this.listUser.UseCompatibleStateImageBehavior = false;
            this.listUser.View = System.Windows.Forms.View.Details;
            this.listUser.DoubleClick += new System.EventHandler(this.listUser_DoubleClick);
            // 
            // BankAccountHolderName
            // 
            this.BankAccountHolderName.Text = "Holder Name";
            this.BankAccountHolderName.Width = 150;
            // 
            // BankAccountNumber
            // 
            this.BankAccountNumber.Text = "Account Number";
            this.BankAccountNumber.Width = 100;
            // 
            // BankName
            // 
            this.BankName.Text = "Bank Name";
            this.BankName.Width = 100;
            // 
            // IFSCCode
            // 
            this.IFSCCode.Text = "IFSC Code";
            this.IFSCCode.Width = 100;
            // 
            // BankDetailID
            // 
            this.BankDetailID.Text = "BankDetailID";
            this.BankDetailID.Width = 0;
            // 
            // BranchName
            // 
            this.BranchName.Text = "Branch Name";
            this.BranchName.Width = 175;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnCancel.Location = new System.Drawing.Point(723, 423);
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
            this.btnOk.Location = new System.Drawing.Point(654, 423);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(63, 27);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ApplicationHelpProvider
            // 
            this.ApplicationHelpProvider.HelpNamespace = "\\Help\\HelpFile.chm";
            // 
            // frmFindBankDetails
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(798, 462);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.listUser);
            this.Controls.Add(this.txtSearchText);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCaption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFindBankDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Bank Details";
            this.Load += new System.EventHandler(this.frmFindBankDetails_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmFindBankDetails_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.ListView listUser;
        private System.Windows.Forms.ColumnHeader BankAccountHolderName;
        private System.Windows.Forms.ColumnHeader BankAccountNumber;
        private System.Windows.Forms.ColumnHeader BankName;
        private System.Windows.Forms.ColumnHeader IFSCCode;
        private System.Windows.Forms.ColumnHeader BankDetailID;
        private System.Windows.Forms.ColumnHeader BranchName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        internal System.Windows.Forms.HelpProvider ApplicationHelpProvider;

    }
}
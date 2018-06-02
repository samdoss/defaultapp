namespace ERPWinApp
{
    partial class BankDetails
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
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBranchName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIfscCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAccountHolderName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblBankDetailID = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bank Name";
            // 
            // txtBankName
            // 
            this.txtBankName.BackColor = System.Drawing.SystemColors.Info;
            this.txtBankName.Location = new System.Drawing.Point(142, 63);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(192, 20);
            this.txtBankName.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(167, 156);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(47, 26);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.BackColor = System.Drawing.SystemColors.Info;
            this.txtAccountNumber.Location = new System.Drawing.Point(142, 37);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(192, 20);
            this.txtAccountNumber.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Account Number";
            // 
            // txtBranchName
            // 
            this.txtBranchName.Location = new System.Drawing.Point(142, 121);
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.Size = new System.Drawing.Size(192, 20);
            this.txtBranchName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Branch Name";
            // 
            // txtIfscCode
            // 
            this.txtIfscCode.Location = new System.Drawing.Point(142, 89);
            this.txtIfscCode.Name = "txtIfscCode";
            this.txtIfscCode.Size = new System.Drawing.Size(192, 20);
            this.txtIfscCode.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "IFSC Code";
            // 
            // txtAccountHolderName
            // 
            this.txtAccountHolderName.BackColor = System.Drawing.SystemColors.Info;
            this.txtAccountHolderName.Location = new System.Drawing.Point(142, 11);
            this.txtAccountHolderName.Name = "txtAccountHolderName";
            this.txtAccountHolderName.Size = new System.Drawing.Size(192, 20);
            this.txtAccountHolderName.TabIndex = 0;
            this.txtAccountHolderName.Leave += new System.EventHandler(this.txtAccountHolderName_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Account Holder Name";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(220, 156);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 26);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Cancel";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblBankDetailID
            // 
            this.lblBankDetailID.AutoSize = true;
            this.lblBankDetailID.Location = new System.Drawing.Point(372, 163);
            this.lblBankDetailID.Name = "lblBankDetailID";
            this.lblBankDetailID.Size = new System.Drawing.Size(13, 13);
            this.lblBankDetailID.TabIndex = 12;
            this.lblBankDetailID.Text = "0";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSearch.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnSearch.Location = new System.Drawing.Point(342, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(63, 27);
            this.btnSearch.TabIndex = 202;
            this.btnSearch.Text = "Searc&h";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(285, 155);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(60, 26);
            this.btnClear.TabIndex = 203;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // BankDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 194);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblBankDetailID);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtAccountHolderName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBranchName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIfscCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAccountNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtBankName);
            this.Controls.Add(this.label1);
            this.Name = "BankDetails";
            this.Text = "BankDetails";
            this.Load += new System.EventHandler(this.BankDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBranchName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIfscCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAccountHolderName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblBankDetailID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
    }
}
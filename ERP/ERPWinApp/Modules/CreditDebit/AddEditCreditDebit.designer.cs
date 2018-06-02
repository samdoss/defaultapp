namespace ERPWinApp
{
    partial class AddEditCreditDebit
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ddlBankName = new System.Windows.Forms.ComboBox();
            this.lblShippingCountry = new System.Windows.Forms.Label();
            this.lblEntryDate = new System.Windows.Forms.Label();
            this.dtpEntryDate = new System.Windows.Forms.DateTimePicker();
            this.lblChequeAmount = new System.Windows.Forms.Label();
            this.txtCreditDebitAmount = new System.Windows.Forms.TextBox();
            this.lblShippingAddress = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.pnlAddCreditDebit = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rbCredit = new System.Windows.Forms.RadioButton();
            this.rbDebit = new System.Windows.Forms.RadioButton();
            this.lblUserMsg = new System.Windows.Forms.Label();
            this.lblCaption = new System.Windows.Forms.Label();
            this.lblMsgColor = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlAddCreditDebit.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.Controls.Add(this.ddlBankName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblShippingCountry, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblEntryDate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpEntryDate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblChequeAmount, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtCreditDebitAmount, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblShippingAddress, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtComments, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.pnlAddCreditDebit, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 85);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.857143F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.857143F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.619048F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.345972F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0939F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(417, 356);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ddlBankName
            // 
            this.ddlBankName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ddlBankName.Dock = System.Windows.Forms.DockStyle.Left;
            this.ddlBankName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBankName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlBankName.FormattingEnabled = true;
            this.ddlBankName.Location = new System.Drawing.Point(142, 3);
            this.ddlBankName.MaxLength = 150;
            this.ddlBankName.Name = "ddlBankName";
            this.ddlBankName.Size = new System.Drawing.Size(272, 27);
            this.ddlBankName.TabIndex = 2;
            // 
            // lblShippingCountry
            // 
            this.lblShippingCountry.AutoSize = true;
            this.lblShippingCountry.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblShippingCountry.Location = new System.Drawing.Point(6, 12);
            this.lblShippingCountry.Margin = new System.Windows.Forms.Padding(6, 12, 6, 6);
            this.lblShippingCountry.Name = "lblShippingCountry";
            this.lblShippingCountry.Size = new System.Drawing.Size(68, 15);
            this.lblShippingCountry.TabIndex = 17;
            this.lblShippingCountry.Text = "Bank Name";
            // 
            // lblEntryDate
            // 
            this.lblEntryDate.AutoSize = true;
            this.lblEntryDate.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblEntryDate.Location = new System.Drawing.Point(6, 61);
            this.lblEntryDate.Margin = new System.Windows.Forms.Padding(6, 12, 6, 6);
            this.lblEntryDate.Name = "lblEntryDate";
            this.lblEntryDate.Size = new System.Drawing.Size(108, 15);
            this.lblEntryDate.TabIndex = 2;
            this.lblEntryDate.Text = "Credit / Debit Date";
            // 
            // dtpEntryDate
            // 
            this.dtpEntryDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEntryDate.Location = new System.Drawing.Point(142, 52);
            this.dtpEntryDate.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.dtpEntryDate.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dtpEntryDate.Name = "dtpEntryDate";
            this.dtpEntryDate.Size = new System.Drawing.Size(188, 23);
            this.dtpEntryDate.TabIndex = 3;
            // 
            // lblChequeAmount
            // 
            this.lblChequeAmount.AutoSize = true;
            this.lblChequeAmount.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblChequeAmount.Location = new System.Drawing.Point(6, 153);
            this.lblChequeAmount.Margin = new System.Windows.Forms.Padding(6, 12, 6, 6);
            this.lblChequeAmount.Name = "lblChequeAmount";
            this.lblChequeAmount.Size = new System.Drawing.Size(125, 15);
            this.lblChequeAmount.TabIndex = 11;
            this.lblChequeAmount.Text = "Credit / Debit Amount";
            // 
            // txtCreditDebitAmount
            // 
            this.txtCreditDebitAmount.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditDebitAmount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCreditDebitAmount.Location = new System.Drawing.Point(145, 146);
            this.txtCreditDebitAmount.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtCreditDebitAmount.Name = "txtCreditDebitAmount";
            this.txtCreditDebitAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCreditDebitAmount.Size = new System.Drawing.Size(266, 27);
            this.txtCreditDebitAmount.TabIndex = 5;
            this.txtCreditDebitAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCreditDebitAmount_KeyPress);
            // 
            // lblShippingAddress
            // 
            this.lblShippingAddress.AutoSize = true;
            this.lblShippingAddress.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblShippingAddress.Location = new System.Drawing.Point(6, 197);
            this.lblShippingAddress.Margin = new System.Windows.Forms.Padding(6, 12, 6, 6);
            this.lblShippingAddress.Name = "lblShippingAddress";
            this.lblShippingAddress.Size = new System.Drawing.Size(64, 15);
            this.lblShippingAddress.TabIndex = 13;
            this.lblShippingAddress.Text = "Comments";
            // 
            // txtComments
            // 
            this.txtComments.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtComments.Location = new System.Drawing.Point(145, 190);
            this.txtComments.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.tableLayoutPanel1.SetRowSpan(this.txtComments, 2);
            this.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComments.Size = new System.Drawing.Size(266, 78);
            this.txtComments.TabIndex = 6;
            // 
            // pnlAddCreditDebit
            // 
            this.pnlAddCreditDebit.Controls.Add(this.btnClose);
            this.pnlAddCreditDebit.Controls.Add(this.btnReset);
            this.pnlAddCreditDebit.Controls.Add(this.btnSave);
            this.pnlAddCreditDebit.Location = new System.Drawing.Point(142, 323);
            this.pnlAddCreditDebit.Name = "pnlAddCreditDebit";
            this.pnlAddCreditDebit.Size = new System.Drawing.Size(252, 29);
            this.pnlAddCreditDebit.TabIndex = 38;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(172, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(88, 3);
            this.btnReset.Margin = new System.Windows.Forms.Padding(5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 2);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.rbCredit, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbDebit, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(142, 98);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(272, 40);
            this.tableLayoutPanel2.TabIndex = 41;
            // 
            // rbCredit
            // 
            this.rbCredit.AutoSize = true;
            this.rbCredit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rbCredit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbCredit.Location = new System.Drawing.Point(3, 3);
            this.rbCredit.Name = "rbCredit";
            this.rbCredit.Size = new System.Drawing.Size(130, 34);
            this.rbCredit.TabIndex = 40;
            this.rbCredit.Text = "Credit";
            this.rbCredit.UseVisualStyleBackColor = false;
            // 
            // rbDebit
            // 
            this.rbDebit.AutoSize = true;
            this.rbDebit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rbDebit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbDebit.Location = new System.Drawing.Point(139, 3);
            this.rbDebit.Name = "rbDebit";
            this.rbDebit.Size = new System.Drawing.Size(130, 34);
            this.rbDebit.TabIndex = 39;
            this.rbDebit.Text = "Debit";
            this.rbDebit.UseVisualStyleBackColor = false;
            // 
            // lblUserMsg
            // 
            this.lblUserMsg.AutoSize = true;
            this.lblUserMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblUserMsg.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserMsg.Location = new System.Drawing.Point(16, 69);
            this.lblUserMsg.Name = "lblUserMsg";
            this.lblUserMsg.Size = new System.Drawing.Size(263, 13);
            this.lblUserMsg.TabIndex = 258;
            this.lblUserMsg.Text = "Fields in              must be entered / selected";
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCaption.Font = new System.Drawing.Font("Verdana", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCaption.Location = new System.Drawing.Point(-3, -1);
            this.lblCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(454, 59);
            this.lblCaption.TabIndex = 257;
            this.lblCaption.Text = "Add Credit Debit";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMsgColor
            // 
            this.lblMsgColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblMsgColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMsgColor.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgColor.Location = new System.Drawing.Point(72, 66);
            this.lblMsgColor.Name = "lblMsgColor";
            this.lblMsgColor.Size = new System.Drawing.Size(45, 17);
            this.lblMsgColor.TabIndex = 259;
            this.lblMsgColor.Text = "Yellow";
            this.lblMsgColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddEditCreditDebit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(443, 448);
            this.Controls.Add(this.lblMsgColor);
            this.Controls.Add(this.lblUserMsg);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkCyan;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditCreditDebit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank";
            this.Load += new System.EventHandler(this.AddEditCreditDebit_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlAddCreditDebit.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblEntryDate;
        private System.Windows.Forms.Label lblChequeAmount;
        private System.Windows.Forms.TextBox txtCreditDebitAmount;
        private System.Windows.Forms.Panel pnlAddCreditDebit;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblShippingAddress;
		private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label lblShippingCountry;
        private System.Windows.Forms.Label lblUserMsg;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Label lblMsgColor;
        private System.Windows.Forms.ComboBox ddlBankName;
        private System.Windows.Forms.DateTimePicker dtpEntryDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton rbCredit;
        private System.Windows.Forms.RadioButton rbDebit;
    }
}
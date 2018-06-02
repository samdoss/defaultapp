namespace ERPWinApp
{
    partial class CreditDebitReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpSearchcCient = new System.Windows.Forms.TableLayoutPanel();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblSearchCreditDebit = new System.Windows.Forms.Label();
            this.lblBankAccount = new System.Windows.Forms.Label();
            this.pnlCreditDebitReport = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.cmbBankDetails = new System.Windows.Forms.ComboBox();
            this.txDepositDate = new System.Windows.Forms.TextBox();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.lblContactName = new System.Windows.Forms.Label();
            this.lblMsgColor = new System.Windows.Forms.Label();
            this.lblUserMsg = new System.Windows.Forms.Label();
            this.lblCaption = new System.Windows.Forms.Label();
            this.tcLayout = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNewCreditDebit = new System.Windows.Forms.Button();
            this.dgvCreditDebitResult = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateProcessed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebitAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankCreditDebitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPager = new System.Windows.Forms.Panel();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.lblSeperator = new System.Windows.Forms.Label();
            this.txtPageEnd = new System.Windows.Forms.TextBox();
            this.txtPageStart = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtResultsPerPage = new System.Windows.Forms.TextBox();
            this.lblPaging = new System.Windows.Forms.Label();
            this.lblTotalCreditAmount = new System.Windows.Forms.Label();
            this.lblTotalDebitAmount = new System.Windows.Forms.Label();
            this.tlpSearchcCient.SuspendLayout();
            this.pnlCreditDebitReport.SuspendLayout();
            this.tcLayout.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditDebitResult)).BeginInit();
            this.pnlPager.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpSearchcCient
            // 
            this.tlpSearchcCient.ColumnCount = 5;
            this.tlpSearchcCient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpSearchcCient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tlpSearchcCient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.tlpSearchcCient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tlpSearchcCient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.tlpSearchcCient.Controls.Add(this.lblEmail, 3, 1);
            this.tlpSearchcCient.Controls.Add(this.lblSearchCreditDebit, 0, 0);
            this.tlpSearchcCient.Controls.Add(this.lblBankAccount, 1, 1);
            this.tlpSearchcCient.Controls.Add(this.pnlCreditDebitReport, 2, 3);
            this.tlpSearchcCient.Controls.Add(this.cmbBankDetails, 2, 1);
            this.tlpSearchcCient.Controls.Add(this.txDepositDate, 4, 1);
            this.tlpSearchcCient.Controls.Add(this.txtChequeNo, 4, 2);
            this.tlpSearchcCient.Controls.Add(this.lblContactName, 3, 2);
            this.tlpSearchcCient.Location = new System.Drawing.Point(12, 84);
            this.tlpSearchcCient.Name = "tlpSearchcCient";
            this.tlpSearchcCient.RowCount = 4;
            this.tlpSearchcCient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.33333F));
            this.tlpSearchcCient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26F));
            this.tlpSearchcCient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSearchcCient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpSearchcCient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSearchcCient.Size = new System.Drawing.Size(1092, 150);
            this.tlpSearchcCient.TabIndex = 0;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblEmail.Location = new System.Drawing.Point(627, 45);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(77, 15);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Deposit Date";
            // 
            // lblSearchCreditDebit
            // 
            this.lblSearchCreditDebit.AutoSize = true;
            this.lblSearchCreditDebit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchCreditDebit.Location = new System.Drawing.Point(5, 10);
            this.lblSearchCreditDebit.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.lblSearchCreditDebit.Name = "lblSearchCreditDebit";
            this.lblSearchCreditDebit.Size = new System.Drawing.Size(130, 19);
            this.lblSearchCreditDebit.TabIndex = 0;
            this.lblSearchCreditDebit.Text = "Search CreditDebit";
            // 
            // lblBankAccount
            // 
            this.lblBankAccount.AutoSize = true;
            this.lblBankAccount.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblBankAccount.Location = new System.Drawing.Point(160, 45);
            this.lblBankAccount.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.lblBankAccount.Name = "lblBankAccount";
            this.lblBankAccount.Size = new System.Drawing.Size(81, 15);
            this.lblBankAccount.TabIndex = 1;
            this.lblBankAccount.Text = "Bank Account";
            // 
            // pnlCreditDebitReport
            // 
            this.tlpSearchcCient.SetColumnSpan(this.pnlCreditDebitReport, 2);
            this.pnlCreditDebitReport.Controls.Add(this.btnSearch);
            this.pnlCreditDebitReport.Controls.Add(this.btnReset);
            this.pnlCreditDebitReport.Location = new System.Drawing.Point(314, 114);
            this.pnlCreditDebitReport.Name = "pnlCreditDebitReport";
            this.pnlCreditDebitReport.Size = new System.Drawing.Size(457, 31);
            this.pnlCreditDebitReport.TabIndex = 11;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(161, 8);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(190, 5, 5, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(246, 8);
            this.btnReset.Margin = new System.Windows.Forms.Padding(5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cmbBankDetails
            // 
            this.cmbBankDetails.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBankDetails.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBankDetails.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbBankDetails.FormattingEnabled = true;
            this.cmbBankDetails.IntegralHeight = false;
            this.cmbBankDetails.Location = new System.Drawing.Point(317, 40);
            this.cmbBankDetails.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.cmbBankDetails.Name = "cmbBankDetails";
            this.cmbBankDetails.Size = new System.Drawing.Size(249, 23);
            this.cmbBankDetails.TabIndex = 28;
            // 
            // txDepositDate
            // 
            this.txDepositDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txDepositDate.Location = new System.Drawing.Point(783, 40);
            this.txDepositDate.Margin = new System.Windows.Forms.Padding(5);
            this.txDepositDate.Name = "txDepositDate";
            this.txDepositDate.Size = new System.Drawing.Size(101, 23);
            this.txDepositDate.TabIndex = 7;
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtChequeNo.Location = new System.Drawing.Point(783, 79);
            this.txtChequeNo.Margin = new System.Windows.Forms.Padding(5);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(115, 23);
            this.txtChequeNo.TabIndex = 6;
            this.txtChequeNo.Visible = false;
            // 
            // lblContactName
            // 
            this.lblContactName.AutoSize = true;
            this.lblContactName.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblContactName.Location = new System.Drawing.Point(627, 84);
            this.lblContactName.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.lblContactName.Name = "lblContactName";
            this.lblContactName.Size = new System.Drawing.Size(65, 15);
            this.lblContactName.TabIndex = 2;
            this.lblContactName.Text = "Cheque No";
            this.lblContactName.Visible = false;
            // 
            // lblMsgColor
            // 
            this.lblMsgColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblMsgColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMsgColor.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgColor.Location = new System.Drawing.Point(74, 65);
            this.lblMsgColor.Name = "lblMsgColor";
            this.lblMsgColor.Size = new System.Drawing.Size(45, 17);
            this.lblMsgColor.TabIndex = 262;
            this.lblMsgColor.Text = "Yellow";
            this.lblMsgColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserMsg
            // 
            this.lblUserMsg.AutoSize = true;
            this.lblUserMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblUserMsg.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserMsg.Location = new System.Drawing.Point(18, 68);
            this.lblUserMsg.Name = "lblUserMsg";
            this.lblUserMsg.Size = new System.Drawing.Size(263, 13);
            this.lblUserMsg.TabIndex = 261;
            this.lblUserMsg.Text = "Fields in              must be entered / selected";
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCaption.Font = new System.Drawing.Font("Verdana", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCaption.Location = new System.Drawing.Point(-1, -2);
            this.lblCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(1126, 59);
            this.lblCaption.TabIndex = 260;
            this.lblCaption.Text = "Credit Debit";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tcLayout
            // 
            this.tcLayout.Controls.Add(this.tabPage1);
            this.tcLayout.Location = new System.Drawing.Point(12, 239);
            this.tcLayout.Name = "tcLayout";
            this.tcLayout.SelectedIndex = 0;
            this.tcLayout.Size = new System.Drawing.Size(1096, 347);
            this.tcLayout.TabIndex = 263;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1088, 319);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cheque Views";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.86413F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.13587F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnNewCreditDebit, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvCreditDebitResult, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pnlPager, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-4, -17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.15484F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.4175F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.71337F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.71429F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1086, 332);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Location = new System.Drawing.Point(3, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 31);
            this.panel1.TabIndex = 28;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(170, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(88, 7);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(6, 7);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNewCreditDebit
            // 
            this.btnNewCreditDebit.Location = new System.Drawing.Point(981, 40);
            this.btnNewCreditDebit.Margin = new System.Windows.Forms.Padding(82, 10, 5, 0);
            this.btnNewCreditDebit.Name = "btnNewCreditDebit";
            this.btnNewCreditDebit.Size = new System.Drawing.Size(75, 23);
            this.btnNewCreditDebit.TabIndex = 11;
            this.btnNewCreditDebit.Text = "New CreditDebit";
            this.btnNewCreditDebit.UseVisualStyleBackColor = true;
            this.btnNewCreditDebit.Click += new System.EventHandler(this.btnNewCreditDebit_Click);
            // 
            // dgvCreditDebitResult
            // 
            this.dgvCreditDebitResult.AllowUserToAddRows = false;
            this.dgvCreditDebitResult.AllowUserToDeleteRows = false;
            this.dgvCreditDebitResult.AllowUserToResizeColumns = false;
            this.dgvCreditDebitResult.AllowUserToResizeRows = false;
            this.dgvCreditDebitResult.BackgroundColor = System.Drawing.Color.White;
            this.dgvCreditDebitResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCreditDebitResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Description,
            this.DateProcessed,
            this.CreditAmount,
            this.DebitAmount,
            this.BankCreditDebitID});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvCreditDebitResult, 2);
            this.dgvCreditDebitResult.Location = new System.Drawing.Point(3, 70);
            this.dgvCreditDebitResult.Name = "dgvCreditDebitResult";
            this.dgvCreditDebitResult.ReadOnly = true;
            this.dgvCreditDebitResult.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCreditDebitResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCreditDebitResult.Size = new System.Drawing.Size(1062, 222);
            this.dgvCreditDebitResult.TabIndex = 27;
            // 
            // No
            // 
            this.No.DataPropertyName = "No";
            this.No.Frozen = true;
            this.No.HeaderText = "No.";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.No.Width = 80;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.Frozen = true;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Description.Width = 300;
            // 
            // DateProcessed
            // 
            this.DateProcessed.DataPropertyName = "DateProcessed";
            this.DateProcessed.Frozen = true;
            this.DateProcessed.HeaderText = "Date";
            this.DateProcessed.MaxInputLength = 100;
            this.DateProcessed.Name = "DateProcessed";
            this.DateProcessed.ReadOnly = true;
            this.DateProcessed.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DateProcessed.Width = 160;
            // 
            // CreditAmount
            // 
            this.CreditAmount.DataPropertyName = "CreditAmount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CreditAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.CreditAmount.Frozen = true;
            this.CreditAmount.HeaderText = "Credit Amount";
            this.CreditAmount.Name = "CreditAmount";
            this.CreditAmount.ReadOnly = true;
            this.CreditAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CreditAmount.Width = 200;
            // 
            // DebitAmount
            // 
            this.DebitAmount.DataPropertyName = "DebitAmount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DebitAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.DebitAmount.Frozen = true;
            this.DebitAmount.HeaderText = "Debit Amount";
            this.DebitAmount.Name = "DebitAmount";
            this.DebitAmount.ReadOnly = true;
            this.DebitAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DebitAmount.ToolTipText = "Debit Amount";
            this.DebitAmount.Width = 150;
            // 
            // BankCreditDebitID
            // 
            this.BankCreditDebitID.DataPropertyName = "BankCreditDebitID";
            this.BankCreditDebitID.HeaderText = "BankCreditDebitID";
            this.BankCreditDebitID.Name = "BankCreditDebitID";
            this.BankCreditDebitID.ReadOnly = true;
            this.BankCreditDebitID.Visible = false;
            // 
            // pnlPager
            // 
            this.pnlPager.Controls.Add(this.lblTotalDebitAmount);
            this.pnlPager.Controls.Add(this.lblTotalCreditAmount);
            this.pnlPager.Controls.Add(this.btnRight);
            this.pnlPager.Controls.Add(this.btnLeft);
            this.pnlPager.Controls.Add(this.lblSeperator);
            this.pnlPager.Controls.Add(this.txtPageEnd);
            this.pnlPager.Controls.Add(this.txtPageStart);
            this.pnlPager.Controls.Add(this.btnApply);
            this.pnlPager.Controls.Add(this.txtResultsPerPage);
            this.pnlPager.Controls.Add(this.lblPaging);
            this.pnlPager.Location = new System.Drawing.Point(3, 298);
            this.pnlPager.Name = "pnlPager";
            this.pnlPager.Size = new System.Drawing.Size(893, 31);
            this.pnlPager.TabIndex = 29;
            // 
            // btnRight
            // 
            this.btnRight.BackgroundImage = global::ERPWinApp.Properties.Resources.Right;
            this.btnRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRight.Location = new System.Drawing.Point(431, 6);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(32, 23);
            this.btnRight.TabIndex = 8;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.BackgroundImage = global::ERPWinApp.Properties.Resources.Left;
            this.btnLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLeft.Location = new System.Drawing.Point(289, 6);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(32, 23);
            this.btnLeft.TabIndex = 7;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // lblSeperator
            // 
            this.lblSeperator.AutoSize = true;
            this.lblSeperator.Location = new System.Drawing.Point(368, 10);
            this.lblSeperator.Name = "lblSeperator";
            this.lblSeperator.Size = new System.Drawing.Size(12, 15);
            this.lblSeperator.TabIndex = 6;
            this.lblSeperator.Text = "/";
            // 
            // txtPageEnd
            // 
            this.txtPageEnd.Location = new System.Drawing.Point(385, 6);
            this.txtPageEnd.Name = "txtPageEnd";
            this.txtPageEnd.Size = new System.Drawing.Size(37, 23);
            this.txtPageEnd.TabIndex = 5;
            // 
            // txtPageStart
            // 
            this.txtPageStart.Location = new System.Drawing.Point(327, 6);
            this.txtPageStart.Name = "txtPageStart";
            this.txtPageStart.Size = new System.Drawing.Size(37, 23);
            this.txtPageStart.TabIndex = 4;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(170, 6);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtResultsPerPage
            // 
            this.txtResultsPerPage.Location = new System.Drawing.Point(112, 6);
            this.txtResultsPerPage.Name = "txtResultsPerPage";
            this.txtResultsPerPage.Size = new System.Drawing.Size(37, 23);
            this.txtResultsPerPage.TabIndex = 1;
            this.txtResultsPerPage.Text = "5";
            // 
            // lblPaging
            // 
            this.lblPaging.AutoSize = true;
            this.lblPaging.Location = new System.Drawing.Point(3, 9);
            this.lblPaging.Name = "lblPaging";
            this.lblPaging.Size = new System.Drawing.Size(103, 15);
            this.lblPaging.TabIndex = 0;
            this.lblPaging.Text = "Results Per Page :";
            // 
            // lblTotalCreditAmount
            // 
            this.lblTotalCreditAmount.AutoSize = true;
            this.lblTotalCreditAmount.Location = new System.Drawing.Point(583, 8);
            this.lblTotalCreditAmount.Name = "lblTotalCreditAmount";
            this.lblTotalCreditAmount.Size = new System.Drawing.Size(14, 15);
            this.lblTotalCreditAmount.TabIndex = 9;
            this.lblTotalCreditAmount.Text = "0";
            // 
            // lblTotalDebitAmount
            // 
            this.lblTotalDebitAmount.AutoSize = true;
            this.lblTotalDebitAmount.Location = new System.Drawing.Point(839, 9);
            this.lblTotalDebitAmount.Name = "lblTotalDebitAmount";
            this.lblTotalDebitAmount.Size = new System.Drawing.Size(14, 15);
            this.lblTotalDebitAmount.TabIndex = 10;
            this.lblTotalDebitAmount.Text = "0";
            // 
            // CreditDebitReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1120, 586);
            this.Controls.Add(this.tcLayout);
            this.Controls.Add(this.lblMsgColor);
            this.Controls.Add(this.lblUserMsg);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.tlpSearchcCient);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkCyan;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "CreditDebitReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CreditDebitReport_Load);
            this.tlpSearchcCient.ResumeLayout(false);
            this.tlpSearchcCient.PerformLayout();
            this.pnlCreditDebitReport.ResumeLayout(false);
            this.tcLayout.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditDebitResult)).EndInit();
            this.pnlPager.ResumeLayout(false);
            this.pnlPager.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpSearchcCient;
        private System.Windows.Forms.Label lblSearchCreditDebit;
        private System.Windows.Forms.TextBox txDepositDate;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblContactName;
        private System.Windows.Forms.Label lblBankAccount;
        private System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlCreditDebitReport;
        private System.Windows.Forms.ComboBox cmbBankDetails;
		private System.Windows.Forms.Label lblMsgColor;
		private System.Windows.Forms.Label lblUserMsg;
		private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.TabControl tcLayout;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNewCreditDebit;
        private System.Windows.Forms.DataGridView dgvCreditDebitResult;
        private System.Windows.Forms.Panel pnlPager;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Label lblSeperator;
        private System.Windows.Forms.TextBox txtPageEnd;
        private System.Windows.Forms.TextBox txtPageStart;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtResultsPerPage;
        private System.Windows.Forms.Label lblPaging;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateProcessed;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DebitAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankCreditDebitID;
        private System.Windows.Forms.Label lblTotalDebitAmount;
        private System.Windows.Forms.Label lblTotalCreditAmount;
    }
}
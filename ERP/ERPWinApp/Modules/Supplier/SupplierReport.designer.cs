namespace ERPWinApp
{
    partial class SuppliersReport
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
			this.tlpSearchcCient = new System.Windows.Forms.TableLayoutPanel();
			this.lblEmail = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.lblSearchSupplier = new System.Windows.Forms.Label();
			this.lblSupplierName = new System.Windows.Forms.Label();
			this.lblContactName = new System.Windows.Forms.Label();
			this.txtContactName = new System.Windows.Forms.TextBox();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.lblPhone = new System.Windows.Forms.Label();
			this.pnlSupplierReport = new System.Windows.Forms.Panel();
			this.btnSearch = new System.Windows.Forms.Button();
			this.btnReset = new System.Windows.Forms.Button();
			this.cmbSupplierName = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lblResults = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnView = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnNewSupplier = new System.Windows.Forms.Button();
			this.dgvSupplierResult = new System.Windows.Forms.DataGridView();
			this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ContactName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.BillingAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PrivateSupplierDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pnlPager = new System.Windows.Forms.Panel();
			this.btnRight = new System.Windows.Forms.Button();
			this.btnLeft = new System.Windows.Forms.Button();
			this.lblSeperator = new System.Windows.Forms.Label();
			this.txtPageEnd = new System.Windows.Forms.TextBox();
			this.txtPageStart = new System.Windows.Forms.TextBox();
			this.btnApply = new System.Windows.Forms.Button();
			this.txtResultsPerPage = new System.Windows.Forms.TextBox();
			this.lblPaging = new System.Windows.Forms.Label();
			this.lblMsgColor = new System.Windows.Forms.Label();
			this.lblUserMsg = new System.Windows.Forms.Label();
			this.lblCaption = new System.Windows.Forms.Label();
			this.tlpSearchcCient.SuspendLayout();
			this.pnlSupplierReport.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSupplierResult)).BeginInit();
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
			this.tlpSearchcCient.Controls.Add(this.txtEmail, 4, 1);
			this.tlpSearchcCient.Controls.Add(this.lblSearchSupplier, 0, 0);
			this.tlpSearchcCient.Controls.Add(this.lblSupplierName, 1, 1);
			this.tlpSearchcCient.Controls.Add(this.lblContactName, 1, 2);
			this.tlpSearchcCient.Controls.Add(this.txtContactName, 2, 2);
			this.tlpSearchcCient.Controls.Add(this.txtPhone, 4, 2);
			this.tlpSearchcCient.Controls.Add(this.lblPhone, 3, 2);
			this.tlpSearchcCient.Controls.Add(this.pnlSupplierReport, 2, 3);
			this.tlpSearchcCient.Controls.Add(this.cmbSupplierName, 2, 1);
			this.tlpSearchcCient.Location = new System.Drawing.Point(12, 100);
			this.tlpSearchcCient.Name = "tlpSearchcCient";
			this.tlpSearchcCient.RowCount = 4;
			this.tlpSearchcCient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpSearchcCient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpSearchcCient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpSearchcCient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpSearchcCient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpSearchcCient.Size = new System.Drawing.Size(947, 145);
			this.tlpSearchcCient.TabIndex = 0;
			// 
			// lblEmail
			// 
			this.lblEmail.AutoSize = true;
			this.lblEmail.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblEmail.Location = new System.Drawing.Point(545, 46);
			this.lblEmail.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
			this.lblEmail.Name = "lblEmail";
			this.lblEmail.Size = new System.Drawing.Size(38, 15);
			this.lblEmail.TabIndex = 3;
			this.lblEmail.Text = "Email";
			// 
			// txtEmail
			// 
			this.txtEmail.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtEmail.Location = new System.Drawing.Point(680, 41);
			this.txtEmail.Margin = new System.Windows.Forms.Padding(5);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(251, 23);
			this.txtEmail.TabIndex = 7;
			// 
			// lblSearchSupplier
			// 
			this.lblSearchSupplier.AutoSize = true;
			this.lblSearchSupplier.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSearchSupplier.Location = new System.Drawing.Point(5, 10);
			this.lblSearchSupplier.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
			this.lblSearchSupplier.Name = "lblSearchSupplier";
			this.lblSearchSupplier.Size = new System.Drawing.Size(101, 19);
			this.lblSearchSupplier.TabIndex = 0;
			this.lblSearchSupplier.Text = "Search Suppliers";
			// 
			// lblSupplierName
			// 
			this.lblSupplierName.AutoSize = true;
			this.lblSupplierName.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblSupplierName.Location = new System.Drawing.Point(140, 46);
			this.lblSupplierName.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
			this.lblSupplierName.Name = "lblSupplierName";
			this.lblSupplierName.Size = new System.Drawing.Size(73, 15);
			this.lblSupplierName.TabIndex = 1;
			this.lblSupplierName.Text = "Supplier Name";
			// 
			// lblContactName
			// 
			this.lblContactName.AutoSize = true;
			this.lblContactName.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblContactName.Location = new System.Drawing.Point(140, 82);
			this.lblContactName.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
			this.lblContactName.Name = "lblContactName";
			this.lblContactName.Size = new System.Drawing.Size(83, 15);
			this.lblContactName.TabIndex = 2;
			this.lblContactName.Text = "Contact Name";
			// 
			// txtContactName
			// 
			this.txtContactName.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtContactName.Location = new System.Drawing.Point(275, 77);
			this.txtContactName.Margin = new System.Windows.Forms.Padding(5);
			this.txtContactName.Name = "txtContactName";
			this.txtContactName.Size = new System.Drawing.Size(250, 23);
			this.txtContactName.TabIndex = 6;
			// 
			// txtPhone
			// 
			this.txtPhone.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtPhone.Location = new System.Drawing.Point(680, 77);
			this.txtPhone.Margin = new System.Windows.Forms.Padding(5);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(251, 23);
			this.txtPhone.TabIndex = 8;
			// 
			// lblPhone
			// 
			this.lblPhone.AutoSize = true;
			this.lblPhone.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblPhone.Location = new System.Drawing.Point(545, 82);
			this.lblPhone.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
			this.lblPhone.Name = "lblPhone";
			this.lblPhone.Size = new System.Drawing.Size(41, 15);
			this.lblPhone.TabIndex = 4;
			this.lblPhone.Text = "Phone";
			// 
			// pnlSupplierReport
			// 
			this.tlpSearchcCient.SetColumnSpan(this.pnlSupplierReport, 2);
			this.pnlSupplierReport.Controls.Add(this.btnSearch);
			this.pnlSupplierReport.Controls.Add(this.btnReset);
			this.pnlSupplierReport.Location = new System.Drawing.Point(273, 111);
			this.pnlSupplierReport.Name = "pnlSupplierReport";
			this.pnlSupplierReport.Size = new System.Drawing.Size(399, 31);
			this.pnlSupplierReport.TabIndex = 11;
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
			// cmbSupplierName
			// 
			this.cmbSupplierName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbSupplierName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbSupplierName.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbSupplierName.FormattingEnabled = true;
			this.cmbSupplierName.IntegralHeight = false;
			this.cmbSupplierName.Location = new System.Drawing.Point(276, 41);
			this.cmbSupplierName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.cmbSupplierName.Name = "cmbSupplierName";
			this.cmbSupplierName.Size = new System.Drawing.Size(249, 23);
			this.cmbSupplierName.TabIndex = 28;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.86413F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.13587F));
			this.tableLayoutPanel1.Controls.Add(this.lblResults, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.btnNewSupplier, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.dgvSupplierResult, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.pnlPager, 0, 3);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 264);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.15484F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.4175F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.71337F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.71429F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(947, 332);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// lblResults
			// 
			this.lblResults.AutoSize = true;
			this.lblResults.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblResults.Location = new System.Drawing.Point(5, 10);
			this.lblResults.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
			this.lblResults.Name = "lblResults";
			this.lblResults.Size = new System.Drawing.Size(57, 15);
			this.lblResults.TabIndex = 1;
			this.lblResults.Text = "Results";
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
			// btnNewSupplier
			// 
			this.btnNewSupplier.Location = new System.Drawing.Point(866, 40);
			this.btnNewSupplier.Margin = new System.Windows.Forms.Padding(82, 10, 5, 0);
			this.btnNewSupplier.Name = "btnNewSupplier";
			this.btnNewSupplier.Size = new System.Drawing.Size(75, 23);
			this.btnNewSupplier.TabIndex = 11;
			this.btnNewSupplier.Text = "New Supplier";
			this.btnNewSupplier.UseVisualStyleBackColor = true;
			this.btnNewSupplier.Click += new System.EventHandler(this.btnNewSupplier_Click);
			// 
			// dgvSupplierResult
			// 
			this.dgvSupplierResult.AllowUserToAddRows = false;
			this.dgvSupplierResult.AllowUserToDeleteRows = false;
			this.dgvSupplierResult.AllowUserToResizeColumns = false;
			this.dgvSupplierResult.AllowUserToResizeRows = false;
			this.dgvSupplierResult.BackgroundColor = System.Drawing.Color.White;
			this.dgvSupplierResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvSupplierResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.SupplierName,
            this.ContactName,
            this.BillingAddress,
            this.Email,
            this.Phone,
            this.PrivateSupplierDetails});
			this.tableLayoutPanel1.SetColumnSpan(this.dgvSupplierResult, 2);
			this.dgvSupplierResult.Location = new System.Drawing.Point(3, 70);
			this.dgvSupplierResult.Name = "dgvSupplierResult";
			this.dgvSupplierResult.ReadOnly = true;
			this.dgvSupplierResult.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvSupplierResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvSupplierResult.Size = new System.Drawing.Size(941, 222);
			this.dgvSupplierResult.TabIndex = 27;
			this.dgvSupplierResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSupplierResult_CellClick);
			// 
			// No
			// 
			this.No.DataPropertyName = "No";
			this.No.Frozen = true;
			this.No.HeaderText = "No.";
			this.No.Name = "No";
			this.No.ReadOnly = true;
			this.No.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.No.Width = 50;
			// 
			// SupplierName
			// 
			this.SupplierName.DataPropertyName = "SupplierName";
			this.SupplierName.Frozen = true;
			this.SupplierName.HeaderText = "Supplier Name";
			this.SupplierName.Name = "SupplierName";
			this.SupplierName.ReadOnly = true;
			this.SupplierName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.SupplierName.Width = 150;
			// 
			// ContactName
			// 
			this.ContactName.DataPropertyName = "ContactName";
			this.ContactName.Frozen = true;
			this.ContactName.HeaderText = "Contact Name";
			this.ContactName.Name = "ContactName";
			this.ContactName.ReadOnly = true;
			this.ContactName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.ContactName.Width = 150;
			// 
			// BillingAddress
			// 
			this.BillingAddress.DataPropertyName = "BillingAddress";
			this.BillingAddress.Frozen = true;
			this.BillingAddress.HeaderText = "Billing Address";
			this.BillingAddress.Name = "BillingAddress";
			this.BillingAddress.ReadOnly = true;
			this.BillingAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.BillingAddress.Width = 150;
			// 
			// Email
			// 
			this.Email.DataPropertyName = "Email";
			this.Email.Frozen = true;
			this.Email.HeaderText = "Email";
			this.Email.Name = "Email";
			this.Email.ReadOnly = true;
			this.Email.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Email.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Email.Width = 150;
			// 
			// Phone
			// 
			this.Phone.DataPropertyName = "Phone";
			this.Phone.Frozen = true;
			this.Phone.HeaderText = "Phone";
			this.Phone.Name = "Phone";
			this.Phone.ReadOnly = true;
			this.Phone.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Phone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// PrivateSupplierDetails
			// 
			this.PrivateSupplierDetails.DataPropertyName = "PrivateSupplierDetails";
			this.PrivateSupplierDetails.Frozen = true;
			this.PrivateSupplierDetails.HeaderText = "Private Details";
			this.PrivateSupplierDetails.Name = "PrivateSupplierDetails";
			this.PrivateSupplierDetails.ReadOnly = true;
			this.PrivateSupplierDetails.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.PrivateSupplierDetails.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.PrivateSupplierDetails.Width = 150;
			// 
			// pnlPager
			// 
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
			this.pnlPager.Size = new System.Drawing.Size(778, 31);
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
			this.lblCaption.Size = new System.Drawing.Size(981, 59);
			this.lblCaption.TabIndex = 260;
			this.lblCaption.Text = "Supplier";
			this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// SuppliersReport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(970, 602);
			this.Controls.Add(this.lblMsgColor);
			this.Controls.Add(this.lblUserMsg);
			this.Controls.Add(this.lblCaption);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.tlpSearchcCient);
			this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.DarkCyan;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SuppliersReport";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Suppliers Record";
			this.Load += new System.EventHandler(this.SuppliersReport_Load);
			this.tlpSearchcCient.ResumeLayout(false);
			this.tlpSearchcCient.PerformLayout();
			this.pnlSupplierReport.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvSupplierResult)).EndInit();
			this.pnlPager.ResumeLayout(false);
			this.pnlPager.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpSearchcCient;
        private System.Windows.Forms.Label lblSearchSupplier;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblContactName;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.TextBox txtContactName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Button btnNewSupplier;
        private System.Windows.Forms.DataGridView dgvSupplierResult;
        private System.Windows.Forms.Panel pnlSupplierReport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cmbSupplierName;
        private System.Windows.Forms.Panel pnlPager;
        private System.Windows.Forms.Label lblPaging;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtResultsPerPage;
        private System.Windows.Forms.TextBox txtPageStart;
        private System.Windows.Forms.TextBox txtPageEnd;
        private System.Windows.Forms.Label lblSeperator;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillingAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrivateSupplierDetails;
		private System.Windows.Forms.Label lblMsgColor;
		private System.Windows.Forms.Label lblUserMsg;
		private System.Windows.Forms.Label lblCaption;
    }
}
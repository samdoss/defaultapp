namespace ERPWinApp
{
    partial class EstimateReport
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
            this.lblSearchEstimate = new System.Windows.Forms.Label();
            this.lblClientName = new System.Windows.Forms.Label();
            this.lblEstimateNo = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbClientName = new System.Windows.Forms.ComboBox();
            this.txtEstimateNumber = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblIssuedBetween = new System.Windows.Forms.Label();
            this.lblDueBetween = new System.Windows.Forms.Label();
            this.lblQuickSearch = new System.Windows.Forms.Label();
            this.txtQuickSearch = new System.Windows.Forms.TextBox();
            this.pnlIssueBetween = new System.Windows.Forms.Panel();
            this.dtpissueBetn2 = new System.Windows.Forms.DateTimePicker();
            this.lblAnd1 = new System.Windows.Forms.Label();
            this.dtpIssueBetn1 = new System.Windows.Forms.DateTimePicker();
            this.pnlDueBetween = new System.Windows.Forms.Panel();
            this.dtpDueBetn2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDueBetn1 = new System.Windows.Forms.DateTimePicker();
            this.pnlSearhEstimate = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblResults = new System.Windows.Forms.Label();
            this.btnNewEstimate = new System.Windows.Forms.Button();
            this.dgvEstimate = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstimateNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrivateNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.View = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.lblSeperator = new System.Windows.Forms.Label();
            this.txtPageEnd = new System.Windows.Forms.TextBox();
            this.txtPageStart = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtResultsPerPage = new System.Windows.Forms.TextBox();
            this.lblPaging = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlIssueBetween.SuspendLayout();
            this.pnlDueBetween.SuspendLayout();
            this.pnlSearhEstimate.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstimate)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.89641F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.29598F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.28753F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.57928F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.02748F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.lblSearchEstimate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblClientName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblEstimateNo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblStatus, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbClientName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtEstimateNumber, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbStatus, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblIssuedBetween, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDueBetween, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblQuickSearch, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtQuickSearch, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.pnlIssueBetween, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlDueBetween, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.pnlSearhEstimate, 2, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1170, 168);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblSearchEstimate
            // 
            this.lblSearchEstimate.AutoSize = true;
            this.lblSearchEstimate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchEstimate.Location = new System.Drawing.Point(5, 10);
            this.lblSearchEstimate.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.lblSearchEstimate.Name = "lblSearchEstimate";
            this.lblSearchEstimate.Size = new System.Drawing.Size(109, 18);
            this.lblSearchEstimate.TabIndex = 1;
            this.lblSearchEstimate.Text = "Search Estimate";
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblClientName.Location = new System.Drawing.Point(5, 43);
            this.lblClientName.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(73, 15);
            this.lblClientName.TabIndex = 2;
            this.lblClientName.Text = "Client Name";
            // 
            // lblEstimateNo
            // 
            this.lblEstimateNo.AutoSize = true;
            this.lblEstimateNo.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblEstimateNo.Location = new System.Drawing.Point(5, 76);
            this.lblEstimateNo.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.lblEstimateNo.Name = "lblEstimateNo";
            this.lblEstimateNo.Size = new System.Drawing.Size(93, 15);
            this.lblEstimateNo.TabIndex = 3;
            this.lblEstimateNo.Text = "Estimate Number";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblStatus.Location = new System.Drawing.Point(5, 109);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 15);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status";
            // 
            // cmbClientName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbClientName, 2);
            this.cmbClientName.FormattingEnabled = true;
            this.cmbClientName.Location = new System.Drawing.Point(154, 36);
            this.cmbClientName.Name = "cmbClientName";
            this.cmbClientName.Size = new System.Drawing.Size(340, 23);
            this.cmbClientName.TabIndex = 5;
            // 
            // txtEstimateNumber
            // 
            this.txtEstimateNumber.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEstimateNumber.Location = new System.Drawing.Point(156, 71);
            this.txtEstimateNumber.Margin = new System.Windows.Forms.Padding(5);
            this.txtEstimateNumber.Name = "txtEstimateNumber";
            this.txtEstimateNumber.Size = new System.Drawing.Size(182, 23);
            this.txtEstimateNumber.TabIndex = 7;
            // 
            // cmbStatus
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbStatus, 2);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(154, 102);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(184, 23);
            this.cmbStatus.TabIndex = 8;
            // 
            // lblIssuedBetween
            // 
            this.lblIssuedBetween.AutoSize = true;
            this.lblIssuedBetween.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblIssuedBetween.Location = new System.Drawing.Point(608, 43);
            this.lblIssuedBetween.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.lblIssuedBetween.Name = "lblIssuedBetween";
            this.lblIssuedBetween.Size = new System.Drawing.Size(91, 15);
            this.lblIssuedBetween.TabIndex = 9;
            this.lblIssuedBetween.Text = "Issued Between";
            // 
            // lblDueBetween
            // 
            this.lblDueBetween.AutoSize = true;
            this.lblDueBetween.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblDueBetween.Location = new System.Drawing.Point(608, 76);
            this.lblDueBetween.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.lblDueBetween.Name = "lblDueBetween";
            this.lblDueBetween.Size = new System.Drawing.Size(76, 15);
            this.lblDueBetween.TabIndex = 10;
            this.lblDueBetween.Text = "Due Between";
            // 
            // lblQuickSearch
            // 
            this.lblQuickSearch.AutoSize = true;
            this.lblQuickSearch.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblQuickSearch.Location = new System.Drawing.Point(608, 109);
            this.lblQuickSearch.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.lblQuickSearch.Name = "lblQuickSearch";
            this.lblQuickSearch.Size = new System.Drawing.Size(79, 15);
            this.lblQuickSearch.TabIndex = 11;
            this.lblQuickSearch.Text = "Quick Search";
            // 
            // txtQuickSearch
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtQuickSearch, 2);
            this.txtQuickSearch.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtQuickSearch.Location = new System.Drawing.Point(755, 104);
            this.txtQuickSearch.Margin = new System.Windows.Forms.Padding(5);
            this.txtQuickSearch.Name = "txtQuickSearch";
            this.txtQuickSearch.Size = new System.Drawing.Size(311, 23);
            this.txtQuickSearch.TabIndex = 12;
            // 
            // pnlIssueBetween
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pnlIssueBetween, 2);
            this.pnlIssueBetween.Controls.Add(this.dtpissueBetn2);
            this.pnlIssueBetween.Controls.Add(this.lblAnd1);
            this.pnlIssueBetween.Controls.Add(this.dtpIssueBetn1);
            this.pnlIssueBetween.Location = new System.Drawing.Point(753, 36);
            this.pnlIssueBetween.Name = "pnlIssueBetween";
            this.pnlIssueBetween.Size = new System.Drawing.Size(334, 27);
            this.pnlIssueBetween.TabIndex = 13;
            // 
            // dtpissueBetn2
            // 
            this.dtpissueBetn2.CustomFormat = "dd/MM/yyyy";
            this.dtpissueBetn2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpissueBetn2.Location = new System.Drawing.Point(169, 1);
            this.dtpissueBetn2.Name = "dtpissueBetn2";
            this.dtpissueBetn2.Size = new System.Drawing.Size(144, 23);
            this.dtpissueBetn2.TabIndex = 1;
            this.dtpissueBetn2.Value = new System.DateTime(2015, 10, 20, 12, 4, 45, 0);
            // 
            // lblAnd1
            // 
            this.lblAnd1.AutoSize = true;
            this.lblAnd1.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblAnd1.Location = new System.Drawing.Point(140, 6);
            this.lblAnd1.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.lblAnd1.Name = "lblAnd1";
            this.lblAnd1.Size = new System.Drawing.Size(28, 15);
            this.lblAnd1.TabIndex = 5;
            this.lblAnd1.Text = "and";
            // 
            // dtpIssueBetn1
            // 
            this.dtpIssueBetn1.CustomFormat = "dd/MM/yyyy";
            this.dtpIssueBetn1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIssueBetn1.Location = new System.Drawing.Point(1, 0);
            this.dtpIssueBetn1.Name = "dtpIssueBetn1";
            this.dtpIssueBetn1.Size = new System.Drawing.Size(136, 23);
            this.dtpIssueBetn1.TabIndex = 0;
            this.dtpIssueBetn1.Value = new System.DateTime(2015, 10, 20, 12, 2, 59, 0);
            // 
            // pnlDueBetween
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pnlDueBetween, 2);
            this.pnlDueBetween.Controls.Add(this.dtpDueBetn2);
            this.pnlDueBetween.Controls.Add(this.label1);
            this.pnlDueBetween.Controls.Add(this.dtpDueBetn1);
            this.pnlDueBetween.Location = new System.Drawing.Point(753, 69);
            this.pnlDueBetween.Name = "pnlDueBetween";
            this.pnlDueBetween.Size = new System.Drawing.Size(334, 27);
            this.pnlDueBetween.TabIndex = 14;
            // 
            // dtpDueBetn2
            // 
            this.dtpDueBetn2.CustomFormat = "__ /__ /____";
            this.dtpDueBetn2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueBetn2.Location = new System.Drawing.Point(169, 1);
            this.dtpDueBetn2.Name = "dtpDueBetn2";
            this.dtpDueBetn2.Size = new System.Drawing.Size(144, 23);
            this.dtpDueBetn2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(140, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "and";
            // 
            // dtpDueBetn1
            // 
            this.dtpDueBetn1.CustomFormat = "__ /__ /____";
            this.dtpDueBetn1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueBetn1.Location = new System.Drawing.Point(1, 0);
            this.dtpDueBetn1.Name = "dtpDueBetn1";
            this.dtpDueBetn1.Size = new System.Drawing.Size(136, 23);
            this.dtpDueBetn1.TabIndex = 0;
            // 
            // pnlSearhEstimate
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pnlSearhEstimate, 2);
            this.pnlSearhEstimate.Controls.Add(this.btnSearch);
            this.pnlSearhEstimate.Controls.Add(this.btnReset);
            this.pnlSearhEstimate.Location = new System.Drawing.Point(392, 135);
            this.pnlSearhEstimate.Name = "pnlSearhEstimate";
            this.pnlSearhEstimate.Size = new System.Drawing.Size(286, 30);
            this.pnlSearhEstimate.TabIndex = 15;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(66, 4);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(190, 5, 5, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(151, 4);
            this.btnReset.Margin = new System.Windows.Forms.Padding(5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 89.21776F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.78224F));
            this.tableLayoutPanel2.Controls.Add(this.lblResults, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnNewEstimate, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.dgvEstimate, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 197);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.5261F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.93248F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.84566F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.53055F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1170, 311);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResults.Location = new System.Drawing.Point(5, 10);
            this.lblResults.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(57, 17);
            this.lblResults.TabIndex = 2;
            this.lblResults.Text = "Results";
            // 
            // btnNewEstimate
            // 
            this.btnNewEstimate.Location = new System.Drawing.Point(1048, 37);
            this.btnNewEstimate.Margin = new System.Windows.Forms.Padding(5);
            this.btnNewEstimate.Name = "btnNewEstimate";
            this.btnNewEstimate.Size = new System.Drawing.Size(93, 23);
            this.btnNewEstimate.TabIndex = 12;
            this.btnNewEstimate.Text = "New Estimate";
            this.btnNewEstimate.UseVisualStyleBackColor = true;
            this.btnNewEstimate.Click += new System.EventHandler(this.btnNewEstimate_Click);
            // 
            // dgvEstimate
            // 
            this.dgvEstimate.AllowUserToAddRows = false;
            this.dgvEstimate.AllowUserToDeleteRows = false;
            this.dgvEstimate.AllowUserToResizeColumns = false;
            this.dgvEstimate.AllowUserToResizeRows = false;
            this.dgvEstimate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEstimate.BackgroundColor = System.Drawing.Color.White;
            this.dgvEstimate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstimate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.ClientName,
            this.EstimateNo,
            this.IssueDate,
            this.DueDate,
            this.Amount,
            this.Tax,
            this.Total,
            this.Status,
            this.PrivateNotes,
            this.AmountPaid,
            this.Balance,
            this.Edit,
            this.View});
            this.tableLayoutPanel2.SetColumnSpan(this.dgvEstimate, 2);
            this.dgvEstimate.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEstimate.Location = new System.Drawing.Point(3, 69);
            this.dgvEstimate.Name = "dgvEstimate";
            this.dgvEstimate.RowHeadersVisible = false;
            this.dgvEstimate.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvEstimate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstimate.ShowEditingIcon = false;
            this.dgvEstimate.Size = new System.Drawing.Size(1164, 205);
            this.dgvEstimate.TabIndex = 13;
            this.dgvEstimate.Tag = "";
            // 
            // No
            // 
            this.No.DataPropertyName = "No";
            this.No.Frozen = true;
            this.No.HeaderText = "No.";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 40;
            // 
            // ClientName
            // 
            this.ClientName.DataPropertyName = "ClientName";
            this.ClientName.Frozen = true;
            this.ClientName.HeaderText = "Client Name";
            this.ClientName.Name = "ClientName";
            this.ClientName.ReadOnly = true;
            // 
            // EstimateNo
            // 
            this.EstimateNo.DataPropertyName = "EstimateNo";
            this.EstimateNo.Frozen = true;
            this.EstimateNo.HeaderText = "Estimate No";
            this.EstimateNo.Name = "EstimateNo";
            this.EstimateNo.ReadOnly = true;
            this.EstimateNo.Width = 90;
            // 
            // IssueDate
            // 
            this.IssueDate.DataPropertyName = "IssueDate";
            this.IssueDate.Frozen = true;
            this.IssueDate.HeaderText = "Issue Date";
            this.IssueDate.Name = "IssueDate";
            this.IssueDate.ReadOnly = true;
            this.IssueDate.Width = 90;
            // 
            // DueDate
            // 
            this.DueDate.DataPropertyName = "DueDate";
            this.DueDate.Frozen = true;
            this.DueDate.HeaderText = "Due Date";
            this.DueDate.Name = "DueDate";
            this.DueDate.ReadOnly = true;
            this.DueDate.Width = 90;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.Frozen = true;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 75;
            // 
            // Tax
            // 
            this.Tax.DataPropertyName = "Tax";
            this.Tax.Frozen = true;
            this.Tax.HeaderText = "Tax";
            this.Tax.Name = "Tax";
            this.Tax.ReadOnly = true;
            this.Tax.Width = 75;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            this.Total.Frozen = true;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 75;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.Frozen = true;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 75;
            // 
            // PrivateNotes
            // 
            this.PrivateNotes.DataPropertyName = "PrivateNotes";
            this.PrivateNotes.Frozen = true;
            this.PrivateNotes.HeaderText = "Private Notes";
            this.PrivateNotes.Name = "PrivateNotes";
            this.PrivateNotes.ReadOnly = true;
            this.PrivateNotes.Width = 110;
            // 
            // AmountPaid
            // 
            this.AmountPaid.DataPropertyName = "AmountPaid";
            this.AmountPaid.Frozen = true;
            this.AmountPaid.HeaderText = "Amount Paid";
            this.AmountPaid.Name = "AmountPaid";
            this.AmountPaid.ReadOnly = true;
            this.AmountPaid.Width = 110;
            // 
            // Balance
            // 
            this.Balance.DataPropertyName = "Balance";
            this.Balance.Frozen = true;
            this.Balance.HeaderText = "Balance";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            this.Balance.Width = 75;
            // 
            // Edit
            // 
            this.Edit.FillWeight = 75F;
            this.Edit.Frozen = true;
            this.Edit.HeaderText = "";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "Edit";
            this.Edit.ToolTipText = "Edit Estimate";
            this.Edit.UseColumnTextForButtonValue = true;
            this.Edit.Width = 70;
            // 
            // View
            // 
            this.View.FillWeight = 75F;
            this.View.Frozen = true;
            this.View.HeaderText = "";
            this.View.Name = "View";
            this.View.ReadOnly = true;
            this.View.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.View.Text = "Delete";
            this.View.ToolTipText = "Delete Estimate";
            this.View.UseColumnTextForButtonValue = true;
            this.View.Width = 70;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRight);
            this.panel2.Controls.Add(this.btnLeft);
            this.panel2.Controls.Add(this.lblSeperator);
            this.panel2.Controls.Add(this.txtPageEnd);
            this.panel2.Controls.Add(this.txtPageStart);
            this.panel2.Controls.Add(this.btnApply);
            this.panel2.Controls.Add(this.txtResultsPerPage);
            this.panel2.Controls.Add(this.lblPaging);
            this.panel2.Location = new System.Drawing.Point(3, 280);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(750, 28);
            this.panel2.TabIndex = 15;
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(432, 3);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(32, 23);
            this.btnRight.TabIndex = 16;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(290, 3);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(32, 23);
            this.btnLeft.TabIndex = 15;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // lblSeperator
            // 
            this.lblSeperator.AutoSize = true;
            this.lblSeperator.Location = new System.Drawing.Point(369, 7);
            this.lblSeperator.Name = "lblSeperator";
            this.lblSeperator.Size = new System.Drawing.Size(12, 15);
            this.lblSeperator.TabIndex = 14;
            this.lblSeperator.Text = "/";
            // 
            // txtPageEnd
            // 
            this.txtPageEnd.Location = new System.Drawing.Point(386, 3);
            this.txtPageEnd.Name = "txtPageEnd";
            this.txtPageEnd.Size = new System.Drawing.Size(37, 23);
            this.txtPageEnd.TabIndex = 13;
            // 
            // txtPageStart
            // 
            this.txtPageStart.Location = new System.Drawing.Point(328, 3);
            this.txtPageStart.Name = "txtPageStart";
            this.txtPageStart.Size = new System.Drawing.Size(37, 23);
            this.txtPageStart.TabIndex = 12;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(171, 3);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 11;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtResultsPerPage
            // 
            this.txtResultsPerPage.Location = new System.Drawing.Point(113, 3);
            this.txtResultsPerPage.Name = "txtResultsPerPage";
            this.txtResultsPerPage.Size = new System.Drawing.Size(37, 23);
            this.txtResultsPerPage.TabIndex = 10;
            this.txtResultsPerPage.Text = "5";
            // 
            // lblPaging
            // 
            this.lblPaging.AutoSize = true;
            this.lblPaging.Location = new System.Drawing.Point(4, 6);
            this.lblPaging.Name = "lblPaging";
            this.lblPaging.Size = new System.Drawing.Size(103, 15);
            this.lblPaging.TabIndex = 9;
            this.lblPaging.Text = "Results Per Page :";
            // 
            // EstimateReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1194, 551);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkCyan;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "EstimateReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Estimate Report";
            this.Load += new System.EventHandler(this.EstimateReport_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlIssueBetween.ResumeLayout(false);
            this.pnlIssueBetween.PerformLayout();
            this.pnlDueBetween.ResumeLayout(false);
            this.pnlDueBetween.PerformLayout();
            this.pnlSearhEstimate.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstimate)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblSearchEstimate;
        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.Label lblEstimateNo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbClientName;
        private System.Windows.Forms.TextBox txtEstimateNumber;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblIssuedBetween;
        private System.Windows.Forms.Label lblDueBetween;
        private System.Windows.Forms.Label lblQuickSearch;
        private System.Windows.Forms.TextBox txtQuickSearch;
        private System.Windows.Forms.Panel pnlIssueBetween;
        private System.Windows.Forms.Label lblAnd1;
        private System.Windows.Forms.DateTimePicker dtpIssueBetn1;
        private System.Windows.Forms.DateTimePicker dtpissueBetn2;
        private System.Windows.Forms.Panel pnlDueBetween;
        private System.Windows.Forms.DateTimePicker dtpDueBetn2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDueBetn1;
        private System.Windows.Forms.Panel pnlSearhEstimate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Button btnNewEstimate;
        private System.Windows.Forms.DataGridView dgvEstimate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Label lblSeperator;
        private System.Windows.Forms.TextBox txtPageEnd;
        private System.Windows.Forms.TextBox txtPageStart;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtResultsPerPage;
        private System.Windows.Forms.Label lblPaging;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstimateNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrivateNotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn View;
    }
}
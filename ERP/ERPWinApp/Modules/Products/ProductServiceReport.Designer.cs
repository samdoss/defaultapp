namespace ERPWinApp
{
    partial class ProductServiceReport
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
			this.lblSearchProductService = new System.Windows.Forms.Label();
			this.lblProductName = new System.Windows.Forms.Label();
			this.lblUnitPriceBetween = new System.Windows.Forms.Label();
			this.txtProductName = new System.Windows.Forms.TextBox();
			this.txtUnitPriceFrom = new System.Windows.Forms.TextBox();
			this.txtQuantityFrom = new System.Windows.Forms.TextBox();
			this.lblAnd1 = new System.Windows.Forms.Label();
			this.lblAnd2 = new System.Windows.Forms.Label();
			this.txtUnitPriceTo = new System.Windows.Forms.TextBox();
			this.txtQuantityTo = new System.Windows.Forms.TextBox();
			this.pnlClientReport = new System.Windows.Forms.Panel();
			this.btnSearch = new System.Windows.Forms.Button();
			this.btnReset = new System.Windows.Forms.Button();
			this.lblQuantityBetween = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.lblResults = new System.Windows.Forms.Label();
			this.btnNewProduct = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnView = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.dgvProducts = new System.Windows.Forms.DataGridView();
			this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
			this.pnlClientReport.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 5;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.05066F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.20815F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.08898F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.237288F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.77542F));
			this.tableLayoutPanel1.Controls.Add(this.lblSearchProductService, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblProductName, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.lblUnitPriceBetween, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.txtProductName, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.txtUnitPriceFrom, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.txtQuantityFrom, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.lblAnd1, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.lblAnd2, 3, 3);
			this.tableLayoutPanel1.Controls.Add(this.txtUnitPriceTo, 4, 2);
			this.tableLayoutPanel1.Controls.Add(this.txtQuantityTo, 4, 3);
			this.tableLayoutPanel1.Controls.Add(this.pnlClientReport, 2, 4);
			this.tableLayoutPanel1.Controls.Add(this.lblQuantityBetween, 1, 3);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 13);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(944, 190);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// lblSearchProductService
			// 
			this.lblSearchProductService.AutoSize = true;
			this.lblSearchProductService.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSearchProductService.Location = new System.Drawing.Point(6, 11);
			this.lblSearchProductService.Margin = new System.Windows.Forms.Padding(6, 11, 6, 5);
			this.lblSearchProductService.Name = "lblSearchProductService";
			this.lblSearchProductService.Size = new System.Drawing.Size(171, 19);
			this.lblSearchProductService.TabIndex = 0;
			this.lblSearchProductService.Text = "Search Products/Services";
			// 
			// lblProductName
			// 
			this.lblProductName.AutoSize = true;
			this.lblProductName.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblProductName.Location = new System.Drawing.Point(193, 48);
			this.lblProductName.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
			this.lblProductName.Name = "lblProductName";
			this.lblProductName.Size = new System.Drawing.Size(97, 23);
			this.lblProductName.TabIndex = 1;
			this.lblProductName.Text = "Product/Service Name";
			// 
			// lblUnitPriceBetween
			// 
			this.lblUnitPriceBetween.AutoSize = true;
			this.lblUnitPriceBetween.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblUnitPriceBetween.Location = new System.Drawing.Point(193, 86);
			this.lblUnitPriceBetween.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
			this.lblUnitPriceBetween.Name = "lblUnitPriceBetween";
			this.lblUnitPriceBetween.Size = new System.Drawing.Size(109, 15);
			this.lblUnitPriceBetween.TabIndex = 2;
			this.lblUnitPriceBetween.Text = "Unit Price Between";
			// 
			// txtProductName
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.txtProductName, 3);
			this.txtProductName.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtProductName.Location = new System.Drawing.Point(326, 43);
			this.txtProductName.Margin = new System.Windows.Forms.Padding(5);
			this.txtProductName.Name = "txtProductName";
			this.txtProductName.Size = new System.Drawing.Size(292, 23);
			this.txtProductName.TabIndex = 6;
			// 
			// txtUnitPriceFrom
			// 
			this.txtUnitPriceFrom.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtUnitPriceFrom.Location = new System.Drawing.Point(326, 81);
			this.txtUnitPriceFrom.Margin = new System.Windows.Forms.Padding(5);
			this.txtUnitPriceFrom.Name = "txtUnitPriceFrom";
			this.txtUnitPriceFrom.Size = new System.Drawing.Size(121, 23);
			this.txtUnitPriceFrom.TabIndex = 7;
			// 
			// txtQuantityFrom
			// 
			this.txtQuantityFrom.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtQuantityFrom.Location = new System.Drawing.Point(326, 119);
			this.txtQuantityFrom.Margin = new System.Windows.Forms.Padding(5);
			this.txtQuantityFrom.Name = "txtQuantityFrom";
			this.txtQuantityFrom.Size = new System.Drawing.Size(121, 23);
			this.txtQuantityFrom.TabIndex = 9;
			// 
			// lblAnd1
			// 
			this.lblAnd1.AutoSize = true;
			this.lblAnd1.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblAnd1.Location = new System.Drawing.Point(458, 86);
			this.lblAnd1.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
			this.lblAnd1.Name = "lblAnd1";
			this.lblAnd1.Size = new System.Drawing.Size(28, 15);
			this.lblAnd1.TabIndex = 4;
			this.lblAnd1.Text = "and";
			// 
			// lblAnd2
			// 
			this.lblAnd2.AutoSize = true;
			this.lblAnd2.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblAnd2.Location = new System.Drawing.Point(458, 124);
			this.lblAnd2.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
			this.lblAnd2.Name = "lblAnd2";
			this.lblAnd2.Size = new System.Drawing.Size(28, 15);
			this.lblAnd2.TabIndex = 5;
			this.lblAnd2.Text = "and";
			// 
			// txtUnitPriceTo
			// 
			this.txtUnitPriceTo.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtUnitPriceTo.Location = new System.Drawing.Point(497, 81);
			this.txtUnitPriceTo.Margin = new System.Windows.Forms.Padding(5);
			this.txtUnitPriceTo.Name = "txtUnitPriceTo";
			this.txtUnitPriceTo.Size = new System.Drawing.Size(121, 23);
			this.txtUnitPriceTo.TabIndex = 8;
			// 
			// txtQuantityTo
			// 
			this.txtQuantityTo.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtQuantityTo.Location = new System.Drawing.Point(497, 119);
			this.txtQuantityTo.Margin = new System.Windows.Forms.Padding(5);
			this.txtQuantityTo.Name = "txtQuantityTo";
			this.txtQuantityTo.Size = new System.Drawing.Size(121, 23);
			this.txtQuantityTo.TabIndex = 10;
			// 
			// pnlClientReport
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.pnlClientReport, 3);
			this.pnlClientReport.Controls.Add(this.btnSearch);
			this.pnlClientReport.Controls.Add(this.btnReset);
			this.pnlClientReport.Location = new System.Drawing.Point(324, 155);
			this.pnlClientReport.Name = "pnlClientReport";
			this.pnlClientReport.Size = new System.Drawing.Size(294, 31);
			this.pnlClientReport.TabIndex = 13;
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(65, 3);
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
			this.btnReset.Location = new System.Drawing.Point(159, 3);
			this.btnReset.Margin = new System.Windows.Forms.Padding(5);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(75, 23);
			this.btnReset.TabIndex = 12;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// lblQuantityBetween
			// 
			this.lblQuantityBetween.AutoSize = true;
			this.lblQuantityBetween.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblQuantityBetween.Location = new System.Drawing.Point(193, 124);
			this.lblQuantityBetween.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
			this.lblQuantityBetween.Name = "lblQuantityBetween";
			this.lblQuantityBetween.Size = new System.Drawing.Size(102, 15);
			this.lblQuantityBetween.TabIndex = 3;
			this.lblQuantityBetween.Text = "Quantity Between";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.83898F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.16102F));
			this.tableLayoutPanel2.Controls.Add(this.lblResults, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnNewProduct, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.dgvProducts, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 3);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(14, 218);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 4;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(944, 328);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// lblResults
			// 
			this.lblResults.AutoSize = true;
			this.lblResults.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblResults.Location = new System.Drawing.Point(6, 11);
			this.lblResults.Margin = new System.Windows.Forms.Padding(6, 11, 6, 5);
			this.lblResults.Name = "lblResults";
			this.lblResults.Size = new System.Drawing.Size(57, 16);
			this.lblResults.TabIndex = 14;
			this.lblResults.Text = "Results";
			// 
			// btnNewProduct
			// 
			this.btnNewProduct.Location = new System.Drawing.Point(786, 37);
			this.btnNewProduct.Margin = new System.Windows.Forms.Padding(5, 5, 5, 3);
			this.btnNewProduct.Name = "btnNewProduct";
			this.btnNewProduct.Size = new System.Drawing.Size(153, 24);
			this.btnNewProduct.TabIndex = 13;
			this.btnNewProduct.Text = "New Product / Services";
			this.btnNewProduct.UseVisualStyleBackColor = true;
			this.btnNewProduct.Click += new System.EventHandler(this.btnNewProduct_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnDelete);
			this.panel1.Controls.Add(this.btnView);
			this.panel1.Controls.Add(this.btnEdit);
			this.panel1.Location = new System.Drawing.Point(3, 35);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(405, 26);
			this.panel1.TabIndex = 16;
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(171, 2);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 5;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnView
			// 
			this.btnView.Location = new System.Drawing.Point(89, 2);
			this.btnView.Name = "btnView";
			this.btnView.Size = new System.Drawing.Size(75, 23);
			this.btnView.TabIndex = 4;
			this.btnView.Text = "View";
			this.btnView.UseVisualStyleBackColor = true;
			this.btnView.Click += new System.EventHandler(this.btnView_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(7, 2);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 23);
			this.btnEdit.TabIndex = 3;
			this.btnEdit.Text = "Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// dgvProducts
			// 
			this.dgvProducts.AllowUserToAddRows = false;
			this.dgvProducts.AllowUserToDeleteRows = false;
			this.dgvProducts.AllowUserToResizeColumns = false;
			this.dgvProducts.AllowUserToResizeRows = false;
			this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
			this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.ProductName,
            this.Description,
            this.Quantity,
            this.UnitPrice,
            this.Tax});
			this.tableLayoutPanel2.SetColumnSpan(this.dgvProducts, 2);
			this.dgvProducts.Location = new System.Drawing.Point(3, 67);
			this.dgvProducts.Name = "dgvProducts";
			this.dgvProducts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvProducts.Size = new System.Drawing.Size(938, 223);
			this.dgvProducts.TabIndex = 15;
			this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
			// 
			// No
			// 
			this.No.DataPropertyName = "No";
			this.No.Frozen = true;
			this.No.HeaderText = "No";
			this.No.Name = "No";
			this.No.ReadOnly = true;
			this.No.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// ProductName
			// 
			this.ProductName.DataPropertyName = "ProductName";
			this.ProductName.Frozen = true;
			this.ProductName.HeaderText = "Product/Service Name";
			this.ProductName.Name = "ProductName";
			this.ProductName.ReadOnly = true;
			this.ProductName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.ProductName.Width = 250;
			// 
			// Description
			// 
			this.Description.DataPropertyName = "Description";
			this.Description.Frozen = true;
			this.Description.HeaderText = "Description";
			this.Description.Name = "Description";
			this.Description.ReadOnly = true;
			this.Description.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Description.Width = 250;
			// 
			// Quantity
			// 
			this.Quantity.DataPropertyName = "Quantity";
			this.Quantity.Frozen = true;
			this.Quantity.HeaderText = "Quantity";
			this.Quantity.Name = "Quantity";
			this.Quantity.ReadOnly = true;
			this.Quantity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Quantity.Visible = false;
			// 
			// UnitPrice
			// 
			this.UnitPrice.DataPropertyName = "UnitPrice";
			this.UnitPrice.Frozen = true;
			this.UnitPrice.HeaderText = "Unit Price";
			this.UnitPrice.Name = "UnitPrice";
			this.UnitPrice.ReadOnly = true;
			this.UnitPrice.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.UnitPrice.Visible = false;
			// 
			// Tax
			// 
			this.Tax.DataPropertyName = "Tax";
			this.Tax.Frozen = true;
			this.Tax.HeaderText = "Tax";
			this.Tax.Name = "Tax";
			this.Tax.ReadOnly = true;
			this.Tax.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Tax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Tax.Visible = false;
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
			this.panel2.Location = new System.Drawing.Point(3, 296);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(615, 29);
			this.panel2.TabIndex = 17;
			// 
			// btnRight
			// 
			this.btnRight.Location = new System.Drawing.Point(440, 3);
			this.btnRight.Name = "btnRight";
			this.btnRight.Size = new System.Drawing.Size(32, 23);
			this.btnRight.TabIndex = 16;
			this.btnRight.UseVisualStyleBackColor = true;
			this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
			// 
			// btnLeft
			// 
			this.btnLeft.Location = new System.Drawing.Point(298, 3);
			this.btnLeft.Name = "btnLeft";
			this.btnLeft.Size = new System.Drawing.Size(32, 23);
			this.btnLeft.TabIndex = 15;
			this.btnLeft.UseVisualStyleBackColor = true;
			this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
			// 
			// lblSeperator
			// 
			this.lblSeperator.AutoSize = true;
			this.lblSeperator.Location = new System.Drawing.Point(377, 7);
			this.lblSeperator.Name = "lblSeperator";
			this.lblSeperator.Size = new System.Drawing.Size(12, 15);
			this.lblSeperator.TabIndex = 14;
			this.lblSeperator.Text = "/";
			// 
			// txtPageEnd
			// 
			this.txtPageEnd.Location = new System.Drawing.Point(394, 3);
			this.txtPageEnd.Name = "txtPageEnd";
			this.txtPageEnd.Size = new System.Drawing.Size(37, 23);
			this.txtPageEnd.TabIndex = 13;
			// 
			// txtPageStart
			// 
			this.txtPageStart.Location = new System.Drawing.Point(336, 3);
			this.txtPageStart.Name = "txtPageStart";
			this.txtPageStart.Size = new System.Drawing.Size(37, 23);
			this.txtPageStart.TabIndex = 12;
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(179, 3);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(75, 23);
			this.btnApply.TabIndex = 11;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// txtResultsPerPage
			// 
			this.txtResultsPerPage.Location = new System.Drawing.Point(121, 3);
			this.txtResultsPerPage.Name = "txtResultsPerPage";
			this.txtResultsPerPage.Size = new System.Drawing.Size(37, 23);
			this.txtResultsPerPage.TabIndex = 10;
			this.txtResultsPerPage.Text = "5";
			// 
			// lblPaging
			// 
			this.lblPaging.AutoSize = true;
			this.lblPaging.Location = new System.Drawing.Point(12, 6);
			this.lblPaging.Name = "lblPaging";
			this.lblPaging.Size = new System.Drawing.Size(103, 15);
			this.lblPaging.TabIndex = 9;
			this.lblPaging.Text = "Results Per Page :";
			// 
			// ProductServiceReport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(970, 540);
			this.Controls.Add(this.tableLayoutPanel2);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.DarkCyan;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProductServiceReport";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Product/Service report";
			this.Load += new System.EventHandler(this.ProductServiceReport_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.pnlClientReport.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblSearchProductService;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblUnitPriceBetween;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtUnitPriceFrom;
        private System.Windows.Forms.TextBox txtQuantityFrom;
        private System.Windows.Forms.Label lblAnd1;
        private System.Windows.Forms.Label lblAnd2;
        private System.Windows.Forms.TextBox txtUnitPriceTo;
        private System.Windows.Forms.TextBox txtQuantityTo;
        private System.Windows.Forms.Panel pnlClientReport;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnNewProduct;
        private System.Windows.Forms.Label lblQuantityBetween;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnEdit;
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
		private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Description;
		private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
		private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
		private System.Windows.Forms.DataGridViewTextBoxColumn Tax;
    }
}
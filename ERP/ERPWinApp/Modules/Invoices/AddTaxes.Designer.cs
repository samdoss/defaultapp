namespace ERPWinApp
{
    partial class AddTaxes
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
			this.lblTaxName = new System.Windows.Forms.Label();
			this.txtTaxName = new System.Windows.Forms.TextBox();
			this.lblTaxPercentage = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblPercentage = new System.Windows.Forms.Label();
			this.txtTaxPercentage = new System.Windows.Forms.TextBox();
			this.btnAddTax = new System.Windows.Forms.Button();
			this.lblAddTax = new System.Windows.Forms.Label();
			this.tlpTaxes = new System.Windows.Forms.TableLayoutPanel();
			this.dgvTaxes = new System.Windows.Forms.DataGridView();
			this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TaxName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TaxPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.IsDefault = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.lblTaxes = new System.Windows.Forms.Label();
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnView = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.pnlPaging = new System.Windows.Forms.Panel();
			this.btnRight = new System.Windows.Forms.Button();
			this.btnLeft = new System.Windows.Forms.Button();
			this.lblSeperator = new System.Windows.Forms.Label();
			this.txtPageEnd = new System.Windows.Forms.TextBox();
			this.txtPageStart = new System.Windows.Forms.TextBox();
			this.btnApply = new System.Windows.Forms.Button();
			this.txtResultsPerPage = new System.Windows.Forms.TextBox();
			this.lblPaging = new System.Windows.Forms.Label();
			this.btnCombinedTaxes = new System.Windows.Forms.Button();
			this.lblMsgColor = new System.Windows.Forms.Label();
			this.lblUserMsg = new System.Windows.Forms.Label();
			this.lblCaption = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tlpTaxes.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTaxes)).BeginInit();
			this.pnlButtons.SuspendLayout();
			this.pnlPaging.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 6;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.914712F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.47335F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.74414F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.88889F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.25758F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.70707F));
			this.tableLayoutPanel1.Controls.Add(this.lblTaxName, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.txtTaxName, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.lblTaxPercentage, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 4, 1);
			this.tableLayoutPanel1.Controls.Add(this.btnAddTax, 5, 1);
			this.tableLayoutPanel1.Controls.Add(this.lblAddTax, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 105);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(792, 76);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// lblTaxName
			// 
			this.lblTaxName.AutoSize = true;
			this.lblTaxName.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblTaxName.Location = new System.Drawing.Point(84, 50);
			this.lblTaxName.Margin = new System.Windows.Forms.Padding(6, 12, 6, 6);
			this.lblTaxName.Name = "lblTaxName";
			this.lblTaxName.Size = new System.Drawing.Size(59, 15);
			this.lblTaxName.TabIndex = 2;
			this.lblTaxName.Text = "Tax Name";
			// 
			// txtTaxName
			// 
			this.txtTaxName.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtTaxName.Location = new System.Drawing.Point(182, 43);
			this.txtTaxName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.txtTaxName.Name = "txtTaxName";
			this.txtTaxName.Size = new System.Drawing.Size(222, 23);
			this.txtTaxName.TabIndex = 9;
			// 
			// lblTaxPercentage
			// 
			this.lblTaxPercentage.AutoSize = true;
			this.lblTaxPercentage.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblTaxPercentage.Location = new System.Drawing.Point(417, 50);
			this.lblTaxPercentage.Margin = new System.Windows.Forms.Padding(6, 12, 6, 6);
			this.lblTaxPercentage.Name = "lblTaxPercentage";
			this.lblTaxPercentage.Size = new System.Drawing.Size(88, 15);
			this.lblTaxPercentage.TabIndex = 10;
			this.lblTaxPercentage.Text = "Tax Percentage";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblPercentage);
			this.panel1.Controls.Add(this.txtTaxPercentage);
			this.panel1.Location = new System.Drawing.Point(524, 41);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(91, 25);
			this.panel1.TabIndex = 10;
			// 
			// lblPercentage
			// 
			this.lblPercentage.AutoSize = true;
			this.lblPercentage.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblPercentage.Location = new System.Drawing.Point(74, 5);
			this.lblPercentage.Margin = new System.Windows.Forms.Padding(6, 12, 6, 6);
			this.lblPercentage.Name = "lblPercentage";
			this.lblPercentage.Size = new System.Drawing.Size(16, 15);
			this.lblPercentage.TabIndex = 11;
			this.lblPercentage.Text = "%";
			// 
			// txtTaxPercentage
			// 
			this.txtTaxPercentage.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtTaxPercentage.Location = new System.Drawing.Point(6, 1);
			this.txtTaxPercentage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.txtTaxPercentage.Name = "txtTaxPercentage";
			this.txtTaxPercentage.Size = new System.Drawing.Size(66, 23);
			this.txtTaxPercentage.TabIndex = 11;
			// 
			// btnAddTax
			// 
			this.btnAddTax.Location = new System.Drawing.Point(631, 43);
			this.btnAddTax.Margin = new System.Windows.Forms.Padding(5);
			this.btnAddTax.Name = "btnAddTax";
			this.btnAddTax.Size = new System.Drawing.Size(75, 23);
			this.btnAddTax.TabIndex = 12;
			this.btnAddTax.Text = "Add Tax";
			this.btnAddTax.UseVisualStyleBackColor = true;
			this.btnAddTax.Click += new System.EventHandler(this.btnAddTax_Click);
			// 
			// lblAddTax
			// 
			this.lblAddTax.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.lblAddTax, 2);
			this.lblAddTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAddTax.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblAddTax.Location = new System.Drawing.Point(3, 3);
			this.lblAddTax.Margin = new System.Windows.Forms.Padding(3);
			this.lblAddTax.Name = "lblAddTax";
			this.lblAddTax.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.lblAddTax.Size = new System.Drawing.Size(72, 27);
			this.lblAddTax.TabIndex = 1;
			this.lblAddTax.Text = "Add Tax";
			// 
			// tlpTaxes
			// 
			this.tlpTaxes.ColumnCount = 2;
			this.tlpTaxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.07595F));
			this.tlpTaxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.92405F));
			this.tlpTaxes.Controls.Add(this.dgvTaxes, 0, 2);
			this.tlpTaxes.Controls.Add(this.lblTaxes, 0, 0);
			this.tlpTaxes.Controls.Add(this.pnlButtons, 0, 1);
			this.tlpTaxes.Controls.Add(this.pnlPaging, 0, 3);
			this.tlpTaxes.Controls.Add(this.btnCombinedTaxes, 1, 0);
			this.tlpTaxes.Location = new System.Drawing.Point(14, 201);
			this.tlpTaxes.Name = "tlpTaxes";
			this.tlpTaxes.RowCount = 4;
			this.tlpTaxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.6041F));
			this.tlpTaxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.2628F));
			this.tlpTaxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.2355F));
			this.tlpTaxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tlpTaxes.Size = new System.Drawing.Size(790, 314);
			this.tlpTaxes.TabIndex = 1;
			// 
			// dgvTaxes
			// 
			this.dgvTaxes.AllowUserToAddRows = false;
			this.dgvTaxes.AllowUserToDeleteRows = false;
			this.dgvTaxes.AllowUserToResizeColumns = false;
			this.dgvTaxes.AllowUserToResizeRows = false;
			this.dgvTaxes.BackgroundColor = System.Drawing.Color.White;
			this.dgvTaxes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTaxes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.TaxName,
            this.TaxPercentage,
            this.IsDefault});
			this.tlpTaxes.SetColumnSpan(this.dgvTaxes, 2);
			this.dgvTaxes.Location = new System.Drawing.Point(3, 74);
			this.dgvTaxes.Name = "dgvTaxes";
			this.dgvTaxes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvTaxes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvTaxes.Size = new System.Drawing.Size(702, 203);
			this.dgvTaxes.TabIndex = 14;
			this.dgvTaxes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaxes_CellClick);
			// 
			// No
			// 
			this.No.DataPropertyName = "No";
			this.No.Frozen = true;
			this.No.HeaderText = "No.";
			this.No.Name = "No";
			this.No.ReadOnly = true;
			this.No.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.No.Width = 75;
			// 
			// TaxName
			// 
			this.TaxName.DataPropertyName = "TaxName";
			this.TaxName.Frozen = true;
			this.TaxName.HeaderText = "Tax Name";
			this.TaxName.Name = "TaxName";
			this.TaxName.ReadOnly = true;
			this.TaxName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.TaxName.Width = 300;
			// 
			// TaxPercentage
			// 
			this.TaxPercentage.DataPropertyName = "TaxPercentage";
			this.TaxPercentage.Frozen = true;
			this.TaxPercentage.HeaderText = "Tax Percentage";
			this.TaxPercentage.Name = "TaxPercentage";
			this.TaxPercentage.ReadOnly = true;
			this.TaxPercentage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.TaxPercentage.Width = 200;
			// 
			// IsDefault
			// 
			this.IsDefault.Frozen = true;
			this.IsDefault.HeaderText = "Is Default?";
			this.IsDefault.Name = "IsDefault";
			this.IsDefault.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// lblTaxes
			// 
			this.lblTaxes.AutoSize = true;
			this.lblTaxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTaxes.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblTaxes.Location = new System.Drawing.Point(3, 3);
			this.lblTaxes.Margin = new System.Windows.Forms.Padding(3);
			this.lblTaxes.Name = "lblTaxes";
			this.lblTaxes.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.lblTaxes.Size = new System.Drawing.Size(58, 27);
			this.lblTaxes.TabIndex = 2;
			this.lblTaxes.Text = "Taxes";
			// 
			// pnlButtons
			// 
			this.pnlButtons.Controls.Add(this.btnDelete);
			this.pnlButtons.Controls.Add(this.btnView);
			this.pnlButtons.Controls.Add(this.btnEdit);
			this.pnlButtons.Location = new System.Drawing.Point(3, 39);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new System.Drawing.Size(253, 29);
			this.pnlButtons.TabIndex = 15;
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(171, 3);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 5;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnView
			// 
			this.btnView.Location = new System.Drawing.Point(89, 3);
			this.btnView.Name = "btnView";
			this.btnView.Size = new System.Drawing.Size(75, 23);
			this.btnView.TabIndex = 4;
			this.btnView.Text = "View";
			this.btnView.UseVisualStyleBackColor = true;
			this.btnView.Click += new System.EventHandler(this.btnView_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(7, 3);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 23);
			this.btnEdit.TabIndex = 3;
			this.btnEdit.Text = "Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// pnlPaging
			// 
			this.pnlPaging.Controls.Add(this.btnRight);
			this.pnlPaging.Controls.Add(this.btnLeft);
			this.pnlPaging.Controls.Add(this.lblSeperator);
			this.pnlPaging.Controls.Add(this.txtPageEnd);
			this.pnlPaging.Controls.Add(this.txtPageStart);
			this.pnlPaging.Controls.Add(this.btnApply);
			this.pnlPaging.Controls.Add(this.txtResultsPerPage);
			this.pnlPaging.Controls.Add(this.lblPaging);
			this.pnlPaging.Location = new System.Drawing.Point(3, 284);
			this.pnlPaging.Name = "pnlPaging";
			this.pnlPaging.Size = new System.Drawing.Size(478, 27);
			this.pnlPaging.TabIndex = 16;
			// 
			// btnRight
			// 
			this.btnRight.BackgroundImage = global::ERPWinApp.Properties.Resources.Right;
			this.btnRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnRight.Location = new System.Drawing.Point(438, 2);
			this.btnRight.Name = "btnRight";
			this.btnRight.Size = new System.Drawing.Size(32, 23);
			this.btnRight.TabIndex = 16;
			this.btnRight.UseVisualStyleBackColor = true;
			this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
			// 
			// btnLeft
			// 
			this.btnLeft.BackgroundImage = global::ERPWinApp.Properties.Resources.Left;
			this.btnLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnLeft.Location = new System.Drawing.Point(296, 2);
			this.btnLeft.Name = "btnLeft";
			this.btnLeft.Size = new System.Drawing.Size(32, 23);
			this.btnLeft.TabIndex = 15;
			this.btnLeft.UseVisualStyleBackColor = true;
			this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
			// 
			// lblSeperator
			// 
			this.lblSeperator.AutoSize = true;
			this.lblSeperator.Location = new System.Drawing.Point(375, 6);
			this.lblSeperator.Name = "lblSeperator";
			this.lblSeperator.Size = new System.Drawing.Size(12, 15);
			this.lblSeperator.TabIndex = 14;
			this.lblSeperator.Text = "/";
			// 
			// txtPageEnd
			// 
			this.txtPageEnd.Location = new System.Drawing.Point(392, 2);
			this.txtPageEnd.Name = "txtPageEnd";
			this.txtPageEnd.Size = new System.Drawing.Size(37, 23);
			this.txtPageEnd.TabIndex = 13;
			// 
			// txtPageStart
			// 
			this.txtPageStart.Location = new System.Drawing.Point(334, 2);
			this.txtPageStart.Name = "txtPageStart";
			this.txtPageStart.Size = new System.Drawing.Size(37, 23);
			this.txtPageStart.TabIndex = 12;
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(177, 2);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(75, 23);
			this.btnApply.TabIndex = 11;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// txtResultsPerPage
			// 
			this.txtResultsPerPage.Location = new System.Drawing.Point(119, 2);
			this.txtResultsPerPage.Name = "txtResultsPerPage";
			this.txtResultsPerPage.Size = new System.Drawing.Size(37, 23);
			this.txtResultsPerPage.TabIndex = 10;
			this.txtResultsPerPage.Text = "5";
			// 
			// lblPaging
			// 
			this.lblPaging.AutoSize = true;
			this.lblPaging.Location = new System.Drawing.Point(10, 5);
			this.lblPaging.Name = "lblPaging";
			this.lblPaging.Size = new System.Drawing.Size(103, 15);
			this.lblPaging.TabIndex = 9;
			this.lblPaging.Text = "Results Per Page :";
			// 
			// btnCombinedTaxes
			// 
			this.btnCombinedTaxes.Location = new System.Drawing.Point(570, 5);
			this.btnCombinedTaxes.Margin = new System.Windows.Forms.Padding(48, 5, 5, 5);
			this.btnCombinedTaxes.Name = "btnCombinedTaxes";
			this.btnCombinedTaxes.Size = new System.Drawing.Size(136, 23);
			this.btnCombinedTaxes.TabIndex = 13;
			this.btnCombinedTaxes.Text = "% Combined Taxes";
			this.btnCombinedTaxes.UseVisualStyleBackColor = true;
			this.btnCombinedTaxes.Visible = false;
			// 
			// lblMsgColor
			// 
			this.lblMsgColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblMsgColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMsgColor.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMsgColor.Location = new System.Drawing.Point(68, 76);
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
			this.lblUserMsg.Location = new System.Drawing.Point(12, 79);
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
			this.lblCaption.Location = new System.Drawing.Point(-3, -1);
			this.lblCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblCaption.Name = "lblCaption";
			this.lblCaption.Size = new System.Drawing.Size(824, 65);
			this.lblCaption.TabIndex = 260;
			this.lblCaption.Text = "Tax Entry";
			this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// AddTaxes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(813, 524);
			this.Controls.Add(this.lblMsgColor);
			this.Controls.Add(this.lblUserMsg);
			this.Controls.Add(this.lblCaption);
			this.Controls.Add(this.tlpTaxes);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.DarkCyan;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddTaxes";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Taxes";
			this.Load += new System.EventHandler(this.AddTaxes_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tlpTaxes.ResumeLayout(false);
			this.tlpTaxes.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTaxes)).EndInit();
			this.pnlButtons.ResumeLayout(false);
			this.pnlPaging.ResumeLayout(false);
			this.pnlPaging.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTaxName;
        private System.Windows.Forms.TextBox txtTaxName;
        private System.Windows.Forms.Label lblTaxPercentage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.TextBox txtTaxPercentage;
        private System.Windows.Forms.Button btnAddTax;
        private System.Windows.Forms.Label lblAddTax;
        private System.Windows.Forms.TableLayoutPanel tlpTaxes;
        private System.Windows.Forms.Button btnCombinedTaxes;
        private System.Windows.Forms.DataGridView dgvTaxes;
        private System.Windows.Forms.Label lblTaxes;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel pnlPaging;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Label lblSeperator;
        private System.Windows.Forms.TextBox txtPageEnd;
        private System.Windows.Forms.TextBox txtPageStart;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtResultsPerPage;
        private System.Windows.Forms.Label lblPaging;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxPercentage;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsDefault;
		private System.Windows.Forms.Label lblMsgColor;
		private System.Windows.Forms.Label lblUserMsg;
		private System.Windows.Forms.Label lblCaption;
    }
}
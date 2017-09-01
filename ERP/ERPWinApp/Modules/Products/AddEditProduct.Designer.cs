namespace ERPWinApp
{
    partial class AddEditProduct
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
			this.lblAddClient = new System.Windows.Forms.Label();
			this.txtProductName = new System.Windows.Forms.TextBox();
			this.txtProdDesc = new System.Windows.Forms.TextBox();
			this.txtUnitPrice = new System.Windows.Forms.TextBox();
			this.lblQuantity = new System.Windows.Forms.Label();
			this.txtQuantity = new System.Windows.Forms.TextBox();
			this.lblTax = new System.Windows.Forms.Label();
			this.lblProductName = new System.Windows.Forms.Label();
			this.lblDescription = new System.Windows.Forms.Label();
			this.lblUnitPrice = new System.Windows.Forms.Label();
			this.pnlAddClient = new System.Windows.Forms.Panel();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.cmbTaxRate = new System.Windows.Forms.ComboBox();
			this.lblMsgColor = new System.Windows.Forms.Label();
			this.lblUserMsg = new System.Windows.Forms.Label();
			this.lblCaption = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			this.pnlAddClient.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 7;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.01903F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.5222F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.26216F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.196617F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.26216F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.342494F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.92389F));
			this.tableLayoutPanel1.Controls.Add(this.lblAddClient, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.txtProductName, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.txtProdDesc, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.txtUnitPrice, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.lblQuantity, 3, 3);
			this.tableLayoutPanel1.Controls.Add(this.txtQuantity, 4, 3);
			this.tableLayoutPanel1.Controls.Add(this.lblTax, 5, 3);
			this.tableLayoutPanel1.Controls.Add(this.lblProductName, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.lblDescription, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.lblUnitPrice, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.pnlAddClient, 3, 4);
			this.tableLayoutPanel1.Controls.Add(this.cmbTaxRate, 6, 3);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 86);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.55004F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.06327F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.58686F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.74765F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.05218F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(946, 253);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// lblAddClient
			// 
			this.lblAddClient.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.lblAddClient, 2);
			this.lblAddClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAddClient.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblAddClient.Location = new System.Drawing.Point(3, 3);
			this.lblAddClient.Margin = new System.Windows.Forms.Padding(3);
			this.lblAddClient.Name = "lblAddClient";
			this.lblAddClient.Padding = new System.Windows.Forms.Padding(5);
			this.lblAddClient.Size = new System.Drawing.Size(155, 27);
			this.lblAddClient.TabIndex = 0;
			this.lblAddClient.Text = "Add Product / Service";
			// 
			// txtProductName
			// 
			this.txtProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.tableLayoutPanel1.SetColumnSpan(this.txtProductName, 5);
			this.txtProductName.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtProductName.Location = new System.Drawing.Point(274, 46);
			this.txtProductName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.txtProductName.Name = "txtProductName";
			this.txtProductName.Size = new System.Drawing.Size(563, 23);
			this.txtProductName.TabIndex = 6;
			// 
			// txtProdDesc
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.txtProdDesc, 5);
			this.txtProdDesc.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtProdDesc.Location = new System.Drawing.Point(274, 86);
			this.txtProdDesc.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.txtProdDesc.Multiline = true;
			this.txtProdDesc.Name = "txtProdDesc";
			this.txtProdDesc.Size = new System.Drawing.Size(563, 70);
			this.txtProdDesc.TabIndex = 7;
			// 
			// txtUnitPrice
			// 
			this.txtUnitPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.txtUnitPrice.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtUnitPrice.Location = new System.Drawing.Point(274, 170);
			this.txtUnitPrice.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.txtUnitPrice.Name = "txtUnitPrice";
			this.txtUnitPrice.Size = new System.Drawing.Size(101, 23);
			this.txtUnitPrice.TabIndex = 8;
			this.txtUnitPrice.Visible = false;
			// 
			// lblQuantity
			// 
			this.lblQuantity.AutoSize = true;
			this.lblQuantity.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblQuantity.Location = new System.Drawing.Point(389, 177);
			this.lblQuantity.Margin = new System.Windows.Forms.Padding(6, 12, 6, 6);
			this.lblQuantity.Name = "lblQuantity";
			this.lblQuantity.Size = new System.Drawing.Size(54, 15);
			this.lblQuantity.TabIndex = 4;
			this.lblQuantity.Text = "Quantity";
			this.lblQuantity.Visible = false;
			// 
			// txtQuantity
			// 
			this.txtQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.txtQuantity.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtQuantity.Location = new System.Drawing.Point(475, 170);
			this.txtQuantity.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.txtQuantity.Name = "txtQuantity";
			this.txtQuantity.Size = new System.Drawing.Size(101, 23);
			this.txtQuantity.TabIndex = 9;
			this.txtQuantity.Visible = false;
			// 
			// lblTax
			// 
			this.lblTax.AutoSize = true;
			this.lblTax.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblTax.Location = new System.Drawing.Point(590, 177);
			this.lblTax.Margin = new System.Windows.Forms.Padding(6, 12, 6, 6);
			this.lblTax.Name = "lblTax";
			this.lblTax.Size = new System.Drawing.Size(25, 15);
			this.lblTax.TabIndex = 5;
			this.lblTax.Text = "Tax";
			this.lblTax.Visible = false;
			// 
			// lblProductName
			// 
			this.lblProductName.AutoSize = true;
			this.lblProductName.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblProductName.Location = new System.Drawing.Point(166, 53);
			this.lblProductName.Margin = new System.Windows.Forms.Padding(6, 12, 6, 6);
			this.lblProductName.Name = "lblProductName";
			this.lblProductName.Size = new System.Drawing.Size(84, 15);
			this.lblProductName.TabIndex = 1;
			this.lblProductName.Text = "Product Name";
			// 
			// lblDescription
			// 
			this.lblDescription.AutoSize = true;
			this.lblDescription.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblDescription.Location = new System.Drawing.Point(166, 93);
			this.lblDescription.Margin = new System.Windows.Forms.Padding(6, 12, 6, 6);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(70, 15);
			this.lblDescription.TabIndex = 2;
			this.lblDescription.Text = "Description";
			// 
			// lblUnitPrice
			// 
			this.lblUnitPrice.AutoSize = true;
			this.lblUnitPrice.ForeColor = System.Drawing.Color.DarkCyan;
			this.lblUnitPrice.Location = new System.Drawing.Point(166, 177);
			this.lblUnitPrice.Margin = new System.Windows.Forms.Padding(6, 12, 6, 6);
			this.lblUnitPrice.Name = "lblUnitPrice";
			this.lblUnitPrice.Size = new System.Drawing.Size(91, 15);
			this.lblUnitPrice.TabIndex = 3;
			this.lblUnitPrice.Text = "Unit Price (INR)";
			this.lblUnitPrice.Visible = false;
			// 
			// pnlAddClient
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.pnlAddClient, 3);
			this.pnlAddClient.Controls.Add(this.btnReset);
			this.pnlAddClient.Controls.Add(this.btnSave);
			this.pnlAddClient.Location = new System.Drawing.Point(386, 207);
			this.pnlAddClient.Name = "pnlAddClient";
			this.pnlAddClient.Size = new System.Drawing.Size(217, 43);
			this.pnlAddClient.TabIndex = 27;
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(88, 13);
			this.btnReset.Margin = new System.Windows.Forms.Padding(5);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(75, 23);
			this.btnReset.TabIndex = 12;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(3, 13);
			this.btnSave.Margin = new System.Windows.Forms.Padding(5);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 11;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// cmbTaxRate
			// 
			this.cmbTaxRate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbTaxRate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbTaxRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.cmbTaxRate.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbTaxRate.FormattingEnabled = true;
			this.cmbTaxRate.IntegralHeight = false;
			this.cmbTaxRate.Location = new System.Drawing.Point(649, 170);
			this.cmbTaxRate.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.cmbTaxRate.Name = "cmbTaxRate";
			this.cmbTaxRate.Size = new System.Drawing.Size(188, 23);
			this.cmbTaxRate.TabIndex = 34;
			this.cmbTaxRate.Visible = false;
			// 
			// lblMsgColor
			// 
			this.lblMsgColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lblMsgColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMsgColor.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMsgColor.Location = new System.Drawing.Point(68, 66);
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
			this.lblUserMsg.Location = new System.Drawing.Point(12, 69);
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
			this.lblCaption.Location = new System.Drawing.Point(-7, -1);
			this.lblCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblCaption.Name = "lblCaption";
			this.lblCaption.Size = new System.Drawing.Size(981, 59);
			this.lblCaption.TabIndex = 260;
			this.lblCaption.Text = "Product";
			this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// AddEditProduct
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(970, 342);
			this.Controls.Add(this.lblMsgColor);
			this.Controls.Add(this.lblUserMsg);
			this.Controls.Add(this.lblCaption);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.DarkCyan;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "AddEditProduct";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AddEditProduct";
			this.Load += new System.EventHandler(this.AddEditProduct_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.pnlAddClient.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblAddClient;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProdDesc;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Panel pnlAddClient;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbTaxRate;
		private System.Windows.Forms.Label lblMsgColor;
		private System.Windows.Forms.Label lblUserMsg;
		private System.Windows.Forms.Label lblCaption;
    }
}
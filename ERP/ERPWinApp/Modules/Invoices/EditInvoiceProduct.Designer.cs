namespace ERPWinApp
{
    partial class EditInvoiceProduct
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
			this.lblEditInvoiceProd = new System.Windows.Forms.Label();
			this.txtProduct = new System.Windows.Forms.TextBox();
			this.lblDescription = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.lblUnitPrice = new System.Windows.Forms.Label();
			this.lblProductOrService = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.lblTax = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.lblQuantity = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.65409F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.34591F));
			this.tableLayoutPanel1.Controls.Add(this.lblEditInvoiceProd, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.txtProduct, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.lblDescription, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.txtDescription, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.lblUnitPrice, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.lblProductOrService, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 6);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 14);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.98502F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.865169F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.73408F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.71535F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.98127F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.614232F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.35206F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(636, 260);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// lblEditInvoiceProd
			// 
			this.lblEditInvoiceProd.AutoSize = true;
			this.lblEditInvoiceProd.Location = new System.Drawing.Point(6, 6);
			this.lblEditInvoiceProd.Margin = new System.Windows.Forms.Padding(6);
			this.lblEditInvoiceProd.Name = "lblEditInvoiceProd";
			this.lblEditInvoiceProd.Size = new System.Drawing.Size(76, 18);
			this.lblEditInvoiceProd.TabIndex = 0;
			this.lblEditInvoiceProd.Text = "Edit Invoice Product";
			// 
			// txtProduct
			// 
			this.txtProduct.Location = new System.Drawing.Point(128, 53);
			this.txtProduct.Name = "txtProduct";
			this.txtProduct.Size = new System.Drawing.Size(499, 24);
			this.txtProduct.TabIndex = 2;
			// 
			// lblDescription
			// 
			this.lblDescription.AutoSize = true;
			this.lblDescription.Location = new System.Drawing.Point(6, 88);
			this.lblDescription.Margin = new System.Windows.Forms.Padding(6);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(72, 17);
			this.lblDescription.TabIndex = 3;
			this.lblDescription.Text = "Description";
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(128, 85);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(499, 64);
			this.txtDescription.TabIndex = 4;
			// 
			// lblUnitPrice
			// 
			this.lblUnitPrice.AutoSize = true;
			this.lblUnitPrice.Location = new System.Drawing.Point(6, 158);
			this.lblUnitPrice.Margin = new System.Windows.Forms.Padding(6);
			this.lblUnitPrice.Name = "lblUnitPrice";
			this.lblUnitPrice.Size = new System.Drawing.Size(95, 17);
			this.lblUnitPrice.TabIndex = 5;
			this.lblUnitPrice.Text = "Unit Price (INR)";
			// 
			// lblProductOrService
			// 
			this.lblProductOrService.AutoSize = true;
			this.lblProductOrService.Location = new System.Drawing.Point(6, 56);
			this.lblProductOrService.Margin = new System.Windows.Forms.Padding(6);
			this.lblProductOrService.Name = "lblProductOrService";
			this.lblProductOrService.Size = new System.Drawing.Size(110, 17);
			this.lblProductOrService.TabIndex = 1;
			this.lblProductOrService.Text = "Product or Service";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.textBox3);
			this.panel1.Controls.Add(this.lblTax);
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.lblQuantity);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Location = new System.Drawing.Point(128, 155);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(505, 31);
			this.panel1.TabIndex = 6;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(381, 3);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(118, 24);
			this.textBox3.TabIndex = 4;
			// 
			// lblTax
			// 
			this.lblTax.AutoSize = true;
			this.lblTax.Location = new System.Drawing.Point(335, 5);
			this.lblTax.Name = "lblTax";
			this.lblTax.Size = new System.Drawing.Size(27, 17);
			this.lblTax.TabIndex = 3;
			this.lblTax.Text = "Tax";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(205, 2);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(118, 24);
			this.textBox2.TabIndex = 2;
			// 
			// lblQuantity
			// 
			this.lblQuantity.AutoSize = true;
			this.lblQuantity.Location = new System.Drawing.Point(134, 3);
			this.lblQuantity.Name = "lblQuantity";
			this.lblQuantity.Size = new System.Drawing.Size(57, 17);
			this.lblQuantity.TabIndex = 1;
			this.lblQuantity.Text = "Quantity";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(3, 2);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(118, 24);
			this.textBox1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnSave);
			this.panel2.Location = new System.Drawing.Point(128, 214);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(505, 43);
			this.panel2.TabIndex = 7;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(424, 18);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			// 
			// EditInvoiceProduct
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(723, 286);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.DarkCyan;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditInvoiceProduct";
			this.Text = "Edit Invoice Product";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblEditInvoiceProd;
        private System.Windows.Forms.Label lblProductOrService;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
    }
}
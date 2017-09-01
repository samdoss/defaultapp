namespace ERPWinApp
{
    partial class EditTax
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
            this.lblTaxInformation = new System.Windows.Forms.Label();
            this.lblTaxName = new System.Windows.Forms.Label();
            this.lblTaxPercentage = new System.Windows.Forms.Label();
            this.txtTaxName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.txtTaxPercentage = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.17582F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.63736F));
            this.tableLayoutPanel1.Controls.Add(this.lblTaxInformation, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTaxName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTaxPercentage, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTaxName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 2, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.67533F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.32467F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.32467F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.67533F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(455, 152);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTaxInformation
            // 
            this.lblTaxInformation.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblTaxInformation, 3);
            this.lblTaxInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxInformation.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTaxInformation.Location = new System.Drawing.Point(3, 3);
            this.lblTaxInformation.Margin = new System.Windows.Forms.Padding(3);
            this.lblTaxInformation.Name = "lblTaxInformation";
            this.lblTaxInformation.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.lblTaxInformation.Size = new System.Drawing.Size(117, 27);
            this.lblTaxInformation.TabIndex = 2;
            this.lblTaxInformation.Text = "Tax Information";
            // 
            // lblTaxName
            // 
            this.lblTaxName.AutoSize = true;
            this.lblTaxName.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTaxName.Location = new System.Drawing.Point(6, 49);
            this.lblTaxName.Margin = new System.Windows.Forms.Padding(6, 12, 6, 6);
            this.lblTaxName.Name = "lblTaxName";
            this.lblTaxName.Size = new System.Drawing.Size(59, 14);
            this.lblTaxName.TabIndex = 3;
            this.lblTaxName.Text = "Tax Name";
            // 
            // lblTaxPercentage
            // 
            this.lblTaxPercentage.AutoSize = true;
            this.lblTaxPercentage.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTaxPercentage.Location = new System.Drawing.Point(6, 87);
            this.lblTaxPercentage.Margin = new System.Windows.Forms.Padding(6, 12, 6, 6);
            this.lblTaxPercentage.Name = "lblTaxPercentage";
            this.lblTaxPercentage.Size = new System.Drawing.Size(87, 14);
            this.lblTaxPercentage.TabIndex = 11;
            this.lblTaxPercentage.Text = "Tax Percentage";
            // 
            // txtTaxName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtTaxName, 2);
            this.txtTaxName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTaxName.Location = new System.Drawing.Point(157, 42);
            this.txtTaxName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtTaxName.Name = "txtTaxName";
            this.txtTaxName.Size = new System.Drawing.Size(274, 22);
            this.txtTaxName.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblPercentage);
            this.panel1.Controls.Add(this.txtTaxPercentage);
            this.panel1.Location = new System.Drawing.Point(154, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(110, 32);
            this.panel1.TabIndex = 13;
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblPercentage.Location = new System.Drawing.Point(81, 5);
            this.lblPercentage.Margin = new System.Windows.Forms.Padding(6, 12, 6, 6);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(16, 14);
            this.lblPercentage.TabIndex = 11;
            this.lblPercentage.Text = "%";
            // 
            // txtTaxPercentage
            // 
            this.txtTaxPercentage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTaxPercentage.Location = new System.Drawing.Point(4, 1);
            this.txtTaxPercentage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtTaxPercentage.Name = "txtTaxPercentage";
            this.txtTaxPercentage.Size = new System.Drawing.Size(72, 22);
            this.txtTaxPercentage.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(356, 118);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EditTax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(479, 177);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkCyan;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditTax";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditTax";
            this.Load += new System.EventHandler(this.EditTax_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTaxInformation;
        private System.Windows.Forms.Label lblTaxName;
        private System.Windows.Forms.Label lblTaxPercentage;
        private System.Windows.Forms.TextBox txtTaxName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.TextBox txtTaxPercentage;
        private System.Windows.Forms.Button btnSave;
    }
}
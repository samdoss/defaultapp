namespace ERPWinApp
{
    partial class frmFindBill

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
            this.txtBillDescription = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblCaption = new System.Windows.Forms.Label();
            this.lstBillDescription = new System.Windows.Forms.ListView();
            this.BillCode = new System.Windows.Forms.ColumnHeader();
            this.BillDesc = new System.Windows.Forms.ColumnHeader();
            this.BillID = new System.Windows.Forms.ColumnHeader();
            this.ApplicationHelpProvider = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // txtBillDescription
            // 
            this.txtBillDescription.BackColor = System.Drawing.Color.White;
            this.txtBillDescription.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillDescription.Location = new System.Drawing.Point(16, 109);
            this.txtBillDescription.MaxLength = 40;
            this.txtBillDescription.Name = "txtBillDescription";
            this.txtBillDescription.Size = new System.Drawing.Size(192, 23);
            this.txtBillDescription.TabIndex = 0;
            this.txtBillDescription.TextChanged += new System.EventHandler(this.txtBillDescription_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(13, 88);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(291, 16);
            this.lblName.TabIndex = 198;
            this.lblName.Text = "&Search for All Bill Code and Bill Description.";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnCancel.Location = new System.Drawing.Point(707, 410);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 27);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnOk.Location = new System.Drawing.Point(638, 410);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(63, 27);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCaption.Font = new System.Drawing.Font("Verdana", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCaption.Location = new System.Drawing.Point(-3, -1);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(801, 76);
            this.lblCaption.TabIndex = 203;
            this.lblCaption.Text = "Search Bill";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstBillDescription
            // 
            this.lstBillDescription.AllowColumnReorder = true;
            this.lstBillDescription.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BillCode,
            this.BillDesc,
            this.BillID});
            this.lstBillDescription.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBillDescription.FullRowSelect = true;
            this.lstBillDescription.Location = new System.Drawing.Point(15, 140);
            this.lstBillDescription.MultiSelect = false;
            this.lstBillDescription.Name = "lstBillDescription";
            this.lstBillDescription.Size = new System.Drawing.Size(755, 262);
            this.lstBillDescription.TabIndex = 1;
            this.lstBillDescription.UseCompatibleStateImageBehavior = false;
            this.lstBillDescription.View = System.Windows.Forms.View.Details;
            this.lstBillDescription.DoubleClick += new System.EventHandler(this.lstBillDescription_DoubleClick);
            // 
            // BillCode
            // 
            this.BillCode.Text = "Bill Code";
            this.BillCode.Width = 184;
            // 
            // BillDesc
            // 
            this.BillDesc.Text = "Bill Description";
            this.BillDesc.Width = 500;
            // 
            // BillID
            // 
            this.BillID.Text = "Bill ID";
            this.BillID.Width = 0;
            // 
            // ApplicationHelpProvider
            // 
            this.ApplicationHelpProvider.HelpNamespace = "\\Help\\HelpFile.chm";
            // 
            // frmFindBill
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(785, 449);
            this.ControlBox = false;
            this.Controls.Add(this.lstBillDescription);
            this.Controls.Add(this.txtBillDescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblCaption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFindBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Bill";
            this.Load += new System.EventHandler(this.frmFindBill_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmFindBill_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBillDescription;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.ListView lstBillDescription;
        private System.Windows.Forms.ColumnHeader BillCode;
        private System.Windows.Forms.ColumnHeader BillDesc;
        private System.Windows.Forms.ColumnHeader BillID;
        internal System.Windows.Forms.HelpProvider ApplicationHelpProvider;

    }
}
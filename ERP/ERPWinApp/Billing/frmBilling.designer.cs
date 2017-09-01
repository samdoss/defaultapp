namespace ERPWinApp
{
    partial class frmBilling
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCaption = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.ddlStatus = new System.Windows.Forms.ComboBox();
            this.dvBillingDesc = new System.Windows.Forms.DataGridView();
            this.BillSno = new ERP.CommonLayer.DataGridViewDisabledTextBoxColumn();
            this.BillCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillDesc = new ERP.CommonLayer.DataGridViewDisabledTextBoxColumn();
            this.BillPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillServiceTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillEdit = new ERP.CommonLayer.DataGridViewDisableButtonColumn();
            this.BillStatus = new ERP.CommonLayer.DataGridViewDisableButtonColumn();
            this.BillDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BillEditingChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Billno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strpGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ostrpDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ApplicationHelpProvider = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.dvBillingDesc)).BeginInit();
            this.strpGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCaption.Font = new System.Drawing.Font("Verdana", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCaption.Location = new System.Drawing.Point(-3, -1);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(740, 71);
            this.lblCaption.TabIndex = 198;
            this.lblCaption.Text = "Bill Descriptions";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnClose.Location = new System.Drawing.Point(656, 379);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 27);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnDelete.Location = new System.Drawing.Point(587, 379);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(63, 27);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnSave.Location = new System.Drawing.Point(518, 379);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 27);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(492, 82);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(98, 16);
            this.lblStatus.TabIndex = 235;
            this.lblStatus.Text = "Show Status";
            // 
            // ddlStatus
            // 
            this.ddlStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlStatus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlStatus.FormattingEnabled = true;
            this.ddlStatus.Location = new System.Drawing.Point(596, 79);
            this.ddlStatus.Name = "ddlStatus";
            this.ddlStatus.Size = new System.Drawing.Size(123, 22);
            this.ddlStatus.TabIndex = 1;
            this.ddlStatus.SelectedIndexChanged += new System.EventHandler(this.ddlStatus_SelectedIndexChanged);
            // 
            // dvBillingDesc
            // 
            this.dvBillingDesc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.dvBillingDesc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dvBillingDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvBillingDesc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dvBillingDesc.ColumnHeadersHeight = 40;
            this.dvBillingDesc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dvBillingDesc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BillSno,
            this.BillCode,
            this.BillDesc,
            this.BillPrice,
            this.BillServiceTax,
            this.BillEdit,
            this.BillStatus,
            this.BillDelete,
            this.BillEditingChk,
            this.Billno});
            this.dvBillingDesc.ContextMenuStrip = this.strpGrid;
            this.dvBillingDesc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dvBillingDesc.EnableHeadersVisualStyles = false;
            this.dvBillingDesc.Location = new System.Drawing.Point(13, 107);
            this.dvBillingDesc.MultiSelect = false;
            this.dvBillingDesc.Name = "dvBillingDesc";
            this.dvBillingDesc.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dvBillingDesc.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvBillingDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dvBillingDesc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dvBillingDesc.Size = new System.Drawing.Size(706, 265);
            this.dvBillingDesc.TabIndex = 0;
            this.dvBillingDesc.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dvBillingDesc_UserAddedRow);
            this.dvBillingDesc.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvBillingDesc_RowEnter);
            this.dvBillingDesc.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dvBillingDesc_MouseClick);
            this.dvBillingDesc.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dvBillingDesc_CellMouseDown);
            this.dvBillingDesc.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dvBillingDesc_UserDeletedRow);
            this.dvBillingDesc.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvBillingDesc_CellEndEdit);
            this.dvBillingDesc.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dvBillingDesc_EditingControlShowing);
            this.dvBillingDesc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvBillingDesc_CellContentClick);
            // 
            // BillSno
            // 
            this.BillSno.HeaderText = "S.No.";
            this.BillSno.MinimumWidth = 40;
            this.BillSno.Name = "BillSno";
            this.BillSno.ReadOnly = true;
            this.BillSno.Width = 40;
            // 
            // BillCode
            // 
            this.BillCode.HeaderText = "BillCode";
            this.BillCode.MaxInputLength = 5;
            this.BillCode.MinimumWidth = 65;
            this.BillCode.Name = "BillCode";
            this.BillCode.Width = 65;
            // 
            // BillDesc
            // 
            this.BillDesc.HeaderText = "Bill Description";
            this.BillDesc.MaxInputLength = 100;
            this.BillDesc.MinimumWidth = 205;
            this.BillDesc.Name = "BillDesc";
            this.BillDesc.Width = 205;
            // 
            // BillPrice
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.BillPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.BillPrice.HeaderText = "Amount in Rs.";
            this.BillPrice.MaxInputLength = 7;
            this.BillPrice.MinimumWidth = 70;
            this.BillPrice.Name = "BillPrice";
            this.BillPrice.Width = 70;
            // 
            // BillServiceTax
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.BillServiceTax.DefaultCellStyle = dataGridViewCellStyle4;
            this.BillServiceTax.HeaderText = "Service Tax";
            this.BillServiceTax.MaxInputLength = 2;
            this.BillServiceTax.MinimumWidth = 70;
            this.BillServiceTax.Name = "BillServiceTax";
            this.BillServiceTax.Width = 70;
            // 
            // BillEdit
            // 
            this.BillEdit.HeaderText = "Edit";
            this.BillEdit.MinimumWidth = 70;
            this.BillEdit.Name = "BillEdit";
            this.BillEdit.Width = 70;
            // 
            // BillStatus
            // 
            this.BillStatus.HeaderText = "Action";
            this.BillStatus.MinimumWidth = 70;
            this.BillStatus.Name = "BillStatus";
            this.BillStatus.Width = 70;
            // 
            // BillDelete
            // 
            this.BillDelete.HeaderText = "Delete";
            this.BillDelete.MinimumWidth = 70;
            this.BillDelete.Name = "BillDelete";
            this.BillDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BillDelete.Width = 70;
            // 
            // BillEditingChk
            // 
            this.BillEditingChk.HeaderText = "Editing";
            this.BillEditingChk.MinimumWidth = 40;
            this.BillEditingChk.Name = "BillEditingChk";
            this.BillEditingChk.Visible = false;
            this.BillEditingChk.Width = 40;
            // 
            // Billno
            // 
            this.Billno.HeaderText = "BillNo";
            this.Billno.MinimumWidth = 40;
            this.Billno.Name = "Billno";
            this.Billno.Visible = false;
            this.Billno.Width = 40;
            // 
            // strpGrid
            // 
            this.strpGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ostrpDelete});
            this.strpGrid.Name = "strpGrid";
            this.strpGrid.Size = new System.Drawing.Size(117, 26);
            // 
            // ostrpDelete
            // 
            this.ostrpDelete.Name = "ostrpDelete";
            this.ostrpDelete.Size = new System.Drawing.Size(116, 22);
            this.ostrpDelete.Text = "Delete";
            this.ostrpDelete.Click += new System.EventHandler(this.ostrpDelete_Click);
            // 
            // ApplicationHelpProvider
            // 
            this.ApplicationHelpProvider.HelpNamespace = "\\Help\\HelpFile.chm";
            // 
            // frmBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 415);
            this.ControlBox = false;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.ddlStatus);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.dvBillingDesc);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBilling";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bill Descriptions";
            this.Load += new System.EventHandler(this.frmBilling_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmBilling_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dvBillingDesc)).EndInit();
            this.strpGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvBillingDesc;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox ddlStatus;
        internal System.Windows.Forms.HelpProvider ApplicationHelpProvider;
        private System.Windows.Forms.ContextMenuStrip strpGrid;
        private System.Windows.Forms.ToolStripMenuItem ostrpDelete;
        private ERP.CommonLayer.DataGridViewDisabledTextBoxColumn BillSno;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillCode;
        private ERP.CommonLayer.DataGridViewDisabledTextBoxColumn BillDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillServiceTax;
        private ERP.CommonLayer.DataGridViewDisableButtonColumn BillEdit;
        private ERP.CommonLayer.DataGridViewDisableButtonColumn BillStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn BillDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn BillEditingChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Billno;
    }
}
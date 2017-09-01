namespace ERPWinApp
{
	partial class frmStockMaster
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
            this.dvStockingDesc = new System.Windows.Forms.DataGridView();
            this.strpGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ostrpDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ApplicationHelpProvider = new System.Windows.Forms.HelpProvider();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlMaterial = new System.Windows.Forms.ComboBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.ddlProduct = new System.Windows.Forms.ComboBox();
            this.StockSno = new ERP.CommonLayer.DataGridViewDisabledTextBoxColumn();
            this.StockCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockDesc = new ERP.CommonLayer.DataGridViewDisabledTextBoxColumn();
            this.StockPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockServiceTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockEdit = new ERP.CommonLayer.DataGridViewDisableButtonColumn();
            this.StockStatus = new ERP.CommonLayer.DataGridViewDisableButtonColumn();
            this.StockDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.StockEditingChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Stockno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dvStockingDesc)).BeginInit();
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
            this.lblCaption.Text = "Stock Descriptions";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnClose.Location = new System.Drawing.Point(656, 466);
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
            this.btnDelete.Location = new System.Drawing.Point(587, 466);
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
            this.btnSave.Location = new System.Drawing.Point(518, 466);
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
            // dvStockingDesc
            // 
            this.dvStockingDesc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.dvStockingDesc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dvStockingDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvStockingDesc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dvStockingDesc.ColumnHeadersHeight = 40;
            this.dvStockingDesc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dvStockingDesc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StockSno,
            this.StockCode,
            this.StockDesc,
            this.StockPrice,
            this.StockServiceTax,
            this.StockEdit,
            this.StockStatus,
            this.StockDelete,
            this.StockEditingChk,
            this.Stockno});
            this.dvStockingDesc.ContextMenuStrip = this.strpGrid;
            this.dvStockingDesc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dvStockingDesc.EnableHeadersVisualStyles = false;
            this.dvStockingDesc.Location = new System.Drawing.Point(13, 137);
            this.dvStockingDesc.MultiSelect = false;
            this.dvStockingDesc.Name = "dvStockingDesc";
            this.dvStockingDesc.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dvStockingDesc.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvStockingDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dvStockingDesc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dvStockingDesc.Size = new System.Drawing.Size(706, 322);
            this.dvStockingDesc.TabIndex = 0;
            this.dvStockingDesc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvStockingDesc_CellContentClick);
            this.dvStockingDesc.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvStockingDesc_CellEndEdit);
            this.dvStockingDesc.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dvStockingDesc_CellMouseDown);
            this.dvStockingDesc.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dvStockingDesc_EditingControlShowing);
            this.dvStockingDesc.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvStockingDesc_RowEnter);
            this.dvStockingDesc.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dvStockingDesc_UserAddedRow);
            this.dvStockingDesc.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dvStockingDesc_UserDeletedRow);
            this.dvStockingDesc.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dvStockingDesc_MouseClick);
            // 
            // strpGrid
            // 
            this.strpGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ostrpDelete});
            this.strpGrid.Name = "strpGrid";
            this.strpGrid.Size = new System.Drawing.Size(108, 26);
            // 
            // ostrpDelete
            // 
            this.ostrpDelete.Name = "ostrpDelete";
            this.ostrpDelete.Size = new System.Drawing.Size(107, 22);
            this.ostrpDelete.Text = "Delete";
            this.ostrpDelete.Click += new System.EventHandler(this.ostrpDelete_Click);
            // 
            // ApplicationHelpProvider
            // 
            this.ApplicationHelpProvider.HelpNamespace = "\\Help\\HelpFile.chm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(346, 109);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 263;
            this.label1.Text = "Material";
            // 
            // ddlMaterial
            // 
            this.ddlMaterial.AllowDrop = true;
            this.ddlMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ddlMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMaterial.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlMaterial.FormattingEnabled = true;
            this.ddlMaterial.Location = new System.Drawing.Point(418, 106);
            this.ddlMaterial.Margin = new System.Windows.Forms.Padding(4);
            this.ddlMaterial.Name = "ddlMaterial";
            this.ddlMaterial.Size = new System.Drawing.Size(216, 24);
            this.ddlMaterial.TabIndex = 262;
            this.ddlMaterial.SelectedIndexChanged += new System.EventHandler(this.ddlMaterial_SelectedIndexChanged);
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMaterial.Location = new System.Drawing.Point(18, 110);
            this.lblMaterial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(64, 16);
            this.lblMaterial.TabIndex = 261;
            this.lblMaterial.Text = "Product";
            // 
            // ddlProduct
            // 
            this.ddlProduct.AllowDrop = true;
            this.ddlProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ddlProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlProduct.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlProduct.FormattingEnabled = true;
            this.ddlProduct.Location = new System.Drawing.Point(90, 107);
            this.ddlProduct.Margin = new System.Windows.Forms.Padding(4);
            this.ddlProduct.Name = "ddlProduct";
            this.ddlProduct.Size = new System.Drawing.Size(216, 24);
            this.ddlProduct.TabIndex = 260;
            this.ddlProduct.SelectedIndexChanged += new System.EventHandler(this.ddlProduct_SelectedIndexChanged);
            // 
            // StockSno
            // 
            this.StockSno.HeaderText = "S.No.";
            this.StockSno.MinimumWidth = 40;
            this.StockSno.Name = "StockSno";
            this.StockSno.ReadOnly = true;
            this.StockSno.Width = 40;
            // 
            // StockCode
            // 
            this.StockCode.HeaderText = "StockCode";
            this.StockCode.MaxInputLength = 5;
            this.StockCode.MinimumWidth = 65;
            this.StockCode.Name = "StockCode";
            this.StockCode.Visible = false;
            this.StockCode.Width = 65;
            // 
            // StockDesc
            // 
            this.StockDesc.HeaderText = "Stock Description";
            this.StockDesc.MaxInputLength = 100;
            this.StockDesc.MinimumWidth = 205;
            this.StockDesc.Name = "StockDesc";
            this.StockDesc.Visible = false;
            this.StockDesc.Width = 205;
            // 
            // StockPrice
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.StockPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.StockPrice.HeaderText = "Stock Available";
            this.StockPrice.MaxInputLength = 5;
            this.StockPrice.MinimumWidth = 255;
            this.StockPrice.Name = "StockPrice";
            this.StockPrice.Width = 255;
            // 
            // StockServiceTax
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.StockServiceTax.DefaultCellStyle = dataGridViewCellStyle4;
            this.StockServiceTax.HeaderText = "Stock Price";
            this.StockServiceTax.MaxInputLength = 15;
            this.StockServiceTax.MinimumWidth = 170;
            this.StockServiceTax.Name = "StockServiceTax";
            this.StockServiceTax.Width = 170;
            // 
            // StockEdit
            // 
            this.StockEdit.HeaderText = "Edit";
            this.StockEdit.MinimumWidth = 70;
            this.StockEdit.Name = "StockEdit";
            this.StockEdit.Width = 70;
            // 
            // StockStatus
            // 
            this.StockStatus.HeaderText = "Action";
            this.StockStatus.MinimumWidth = 70;
            this.StockStatus.Name = "StockStatus";
            this.StockStatus.Width = 70;
            // 
            // StockDelete
            // 
            this.StockDelete.HeaderText = "Delete";
            this.StockDelete.MinimumWidth = 70;
            this.StockDelete.Name = "StockDelete";
            this.StockDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StockDelete.Width = 70;
            // 
            // StockEditingChk
            // 
            this.StockEditingChk.HeaderText = "Editing";
            this.StockEditingChk.MinimumWidth = 40;
            this.StockEditingChk.Name = "StockEditingChk";
            this.StockEditingChk.Visible = false;
            this.StockEditingChk.Width = 40;
            // 
            // Stockno
            // 
            this.Stockno.HeaderText = "StockNo";
            this.Stockno.MinimumWidth = 40;
            this.Stockno.Name = "Stockno";
            this.Stockno.Visible = false;
            this.Stockno.Width = 40;
            // 
            // frmStockMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 506);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlMaterial);
            this.Controls.Add(this.lblMaterial);
            this.Controls.Add(this.ddlProduct);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.ddlStatus);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.dvStockingDesc);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStockMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Descriptions";
            this.Load += new System.EventHandler(this.frmStocking_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmStocking_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dvStockingDesc)).EndInit();
            this.strpGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvStockingDesc;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox ddlStatus;
		internal System.Windows.Forms.HelpProvider ApplicationHelpProvider;
        private System.Windows.Forms.ContextMenuStrip strpGrid;
        private System.Windows.Forms.ToolStripMenuItem ostrpDelete;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox ddlMaterial;
		private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.ComboBox ddlProduct;
        private ERP.CommonLayer.DataGridViewDisabledTextBoxColumn StockSno;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockCode;
        private ERP.CommonLayer.DataGridViewDisabledTextBoxColumn StockDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockServiceTax;
        private ERP.CommonLayer.DataGridViewDisableButtonColumn StockEdit;
        private ERP.CommonLayer.DataGridViewDisableButtonColumn StockStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn StockDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn StockEditingChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stockno;
    }
}
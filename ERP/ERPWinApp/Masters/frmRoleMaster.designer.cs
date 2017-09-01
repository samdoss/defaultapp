namespace ERPWinApp
{
    partial class frmRoleMaster
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
			this.lblCaption = new System.Windows.Forms.Label();
			this.lblStatus = new System.Windows.Forms.Label();
			this.ddlStatus = new System.Windows.Forms.ComboBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.dvRoleDesc = new System.Windows.Forms.DataGridView();
			this.RoleSno = new ERP.CommonLayer.DataGridViewDisabledTextBoxColumn();
			this.RoleDesc = new ERP.CommonLayer.DataGridViewDisabledTextBoxColumn();
			this.RoleEdit = new ERP.CommonLayer.DataGridViewDisableButtonColumn();
			this.RoleStatus = new ERP.CommonLayer.DataGridViewDisableButtonColumn();
			this.RoleDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.RoleEditingChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Roleno = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.strpGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ostrpDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.ApplicationHelpProvider = new System.Windows.Forms.HelpProvider();
			((System.ComponentModel.ISupportInitialize)(this.dvRoleDesc)).BeginInit();
			this.strpGrid.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblCaption
			// 
			this.lblCaption.BackColor = System.Drawing.Color.DarkSlateGray;
			this.lblCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblCaption.Font = new System.Drawing.Font("Verdana", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCaption.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lblCaption.Location = new System.Drawing.Point(-7, -6);
			this.lblCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblCaption.Name = "lblCaption";
			this.lblCaption.Size = new System.Drawing.Size(571, 76);
			this.lblCaption.TabIndex = 204;
			this.lblCaption.Text = "Role Description";
			this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStatus.Location = new System.Drawing.Point(295, 86);
			this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(98, 16);
			this.lblStatus.TabIndex = 243;
			this.lblStatus.Text = "Show Status";
			// 
			// ddlStatus
			// 
			this.ddlStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ddlStatus.FormattingEnabled = true;
			this.ddlStatus.Location = new System.Drawing.Point(401, 83);
			this.ddlStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.ddlStatus.Name = "ddlStatus";
			this.ddlStatus.Size = new System.Drawing.Size(146, 24);
			this.ddlStatus.TabIndex = 242;
			this.ddlStatus.SelectedIndexChanged += new System.EventHandler(this.ddlStatus_SelectedIndexChanged);
			// 
			// btnClose
			// 
			this.btnClose.BackColor = System.Drawing.Color.DarkSlateGray;
			this.btnClose.Font = new System.Drawing.Font("Verdana", 9.75F);
			this.btnClose.Location = new System.Drawing.Point(483, 405);
			this.btnClose.Margin = new System.Windows.Forms.Padding(4);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(63, 27);
			this.btnClose.TabIndex = 247;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.BackColor = System.Drawing.Color.DarkSlateGray;
			this.btnDelete.Font = new System.Drawing.Font("Verdana", 9.75F);
			this.btnDelete.Location = new System.Drawing.Point(413, 405);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(63, 27);
			this.btnDelete.TabIndex = 246;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnSave
			// 
			this.btnSave.BackColor = System.Drawing.Color.DarkSlateGray;
			this.btnSave.Font = new System.Drawing.Font("Verdana", 9.75F);
			this.btnSave.Location = new System.Drawing.Point(343, 405);
			this.btnSave.Margin = new System.Windows.Forms.Padding(4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(63, 27);
			this.btnSave.TabIndex = 245;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// dvRoleDesc
			// 
			this.dvRoleDesc.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
			this.dvRoleDesc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dvRoleDesc.BackgroundColor = System.Drawing.Color.DarkSlateGray;
			this.dvRoleDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dvRoleDesc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dvRoleDesc.ColumnHeadersHeight = 40;
			this.dvRoleDesc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dvRoleDesc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoleSno,
            this.RoleDesc,
            this.RoleEdit,
            this.RoleStatus,
            this.RoleDelete,
            this.RoleEditingChk,
            this.Roleno});
			this.dvRoleDesc.ContextMenuStrip = this.strpGrid;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkSlateGray;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dvRoleDesc.DefaultCellStyle = dataGridViewCellStyle3;
			this.dvRoleDesc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dvRoleDesc.Location = new System.Drawing.Point(15, 118);
			this.dvRoleDesc.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.dvRoleDesc.MultiSelect = false;
			this.dvRoleDesc.Name = "dvRoleDesc";
			this.dvRoleDesc.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dvRoleDesc.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dvRoleDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dvRoleDesc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dvRoleDesc.Size = new System.Drawing.Size(531, 280);
			this.dvRoleDesc.TabIndex = 244;
			this.dvRoleDesc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvRoleDesc_CellContentClick);
			this.dvRoleDesc.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvRoleDesc_CellEndEdit);
			this.dvRoleDesc.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dvRoleDesc_CellMouseDown);
			this.dvRoleDesc.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dvRoleDesc_DataError);
			this.dvRoleDesc.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvRoleDesc_RowEnter);
			this.dvRoleDesc.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dvRoleDesc_UserAddedRow);
			this.dvRoleDesc.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dvRoleDesc_UserDeletedRow);
			this.dvRoleDesc.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dvRoleDesc_MouseClick);
			// 
			// RoleSno
			// 
			this.RoleSno.HeaderText = "S.No";
			this.RoleSno.MaxInputLength = 5;
			this.RoleSno.MinimumWidth = 40;
			this.RoleSno.Name = "RoleSno";
			this.RoleSno.ReadOnly = true;
			this.RoleSno.Width = 40;
			// 
			// RoleDesc
			// 
			this.RoleDesc.HeaderText = "Role";
			this.RoleDesc.MaxInputLength = 50;
			this.RoleDesc.MinimumWidth = 238;
			this.RoleDesc.Name = "RoleDesc";
			this.RoleDesc.Width = 238;
			// 
			// RoleEdit
			// 
			this.RoleEdit.HeaderText = "Edit";
			this.RoleEdit.MinimumWidth = 70;
			this.RoleEdit.Name = "RoleEdit";
			this.RoleEdit.Width = 70;
			// 
			// RoleStatus
			// 
			this.RoleStatus.HeaderText = "Action";
			this.RoleStatus.MinimumWidth = 70;
			this.RoleStatus.Name = "RoleStatus";
			this.RoleStatus.Width = 70;
			// 
			// RoleDelete
			// 
			this.RoleDelete.FalseValue = "False";
			this.RoleDelete.HeaderText = "Delete";
			this.RoleDelete.MinimumWidth = 70;
			this.RoleDelete.Name = "RoleDelete";
			this.RoleDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.RoleDelete.TrueValue = "True";
			this.RoleDelete.Width = 70;
			// 
			// RoleEditingChk
			// 
			this.RoleEditingChk.HeaderText = "Editing";
			this.RoleEditingChk.MinimumWidth = 40;
			this.RoleEditingChk.Name = "RoleEditingChk";
			this.RoleEditingChk.Visible = false;
			this.RoleEditingChk.Width = 40;
			// 
			// Roleno
			// 
			this.Roleno.HeaderText = "UnitNo";
			this.Roleno.MaxInputLength = 5;
			this.Roleno.MinimumWidth = 40;
			this.Roleno.Name = "Roleno";
			this.Roleno.Visible = false;
			this.Roleno.Width = 40;
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
			this.ApplicationHelpProvider.HelpNamespace = "*.chm";
			// 
			// frmRoleMaster
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DarkSlateGray;
			this.ClientSize = new System.Drawing.Size(561, 440);
			this.ControlBox = false;
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.dvRoleDesc);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.ddlStatus);
			this.Controls.Add(this.lblCaption);
			this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmRoleMaster";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Role Description";
			this.Load += new System.EventHandler(this.frmRoleMaster_Load);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmRoleMaster_KeyPress);
			((System.ComponentModel.ISupportInitialize)(this.dvRoleDesc)).EndInit();
			this.strpGrid.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox ddlStatus;
        private System.Windows.Forms.DataGridView dvRoleDesc;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
		private ERP.CommonLayer.DataGridViewDisabledTextBoxColumn RoleSno;
		private ERP.CommonLayer.DataGridViewDisabledTextBoxColumn RoleDesc;
		private ERP.CommonLayer.DataGridViewDisableButtonColumn RoleEdit;
		private ERP.CommonLayer.DataGridViewDisableButtonColumn RoleStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RoleDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RoleEditingChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Roleno;
        internal System.Windows.Forms.HelpProvider ApplicationHelpProvider;
        private System.Windows.Forms.ContextMenuStrip strpGrid;
        private System.Windows.Forms.ToolStripMenuItem ostrpDelete;
    }
}
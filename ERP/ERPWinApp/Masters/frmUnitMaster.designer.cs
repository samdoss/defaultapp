namespace ERPWinApp
{
    partial class frmUnitMaster
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
            this.dvUnitDesc = new System.Windows.Forms.DataGridView();
            this.UnitSno = new ERP.CommonLayer.DataGridViewDisabledTextBoxColumn();
            this.UnitDesc = new ERP.CommonLayer.DataGridViewDisabledTextBoxColumn();
            this.UnitEdit = new ERP.CommonLayer.DataGridViewDisableButtonColumn();
            this.UnitStatus = new ERP.CommonLayer.DataGridViewDisableButtonColumn();
            this.UnitDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UnitEditingChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Unitno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strpGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ostrpDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCaption = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.ddlStatus = new System.Windows.Forms.ComboBox();
            this.ApplicationHelpProvider = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.dvUnitDesc)).BeginInit();
            this.strpGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvUnitDesc
            // 
            this.dvUnitDesc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.dvUnitDesc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dvUnitDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvUnitDesc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dvUnitDesc.ColumnHeadersHeight = 40;
            this.dvUnitDesc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dvUnitDesc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UnitSno,
            this.UnitDesc,
            this.UnitEdit,
            this.UnitStatus,
            this.UnitDelete,
            this.UnitEditingChk,
            this.Unitno});
            this.dvUnitDesc.ContextMenuStrip = this.strpGrid;
            this.dvUnitDesc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dvUnitDesc.Location = new System.Drawing.Point(12, 107);
            this.dvUnitDesc.MultiSelect = false;
            this.dvUnitDesc.Name = "dvUnitDesc";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvUnitDesc.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dvUnitDesc.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dvUnitDesc.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvUnitDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dvUnitDesc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dvUnitDesc.Size = new System.Drawing.Size(534, 260);
            this.dvUnitDesc.TabIndex = 0;
            this.dvUnitDesc.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dvUnitDesc_UserAddedRow);
            this.dvUnitDesc.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvUnitDesc_RowEnter);
            this.dvUnitDesc.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dvUnitDesc_MouseClick);
            this.dvUnitDesc.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dvUnitDesc_CellMouseDown);
            this.dvUnitDesc.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dvUnitDesc_UserDeletedRow);
            this.dvUnitDesc.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvUnitDesc_CellEndEdit);
            this.dvUnitDesc.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dvUnitDesc_DataError);
            this.dvUnitDesc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvUnitDesc_CellContentClick);
            // 
            // UnitSno
            // 
            this.UnitSno.HeaderText = "S.No";
            this.UnitSno.MaxInputLength = 5;
            this.UnitSno.MinimumWidth = 40;
            this.UnitSno.Name = "UnitSno";
            this.UnitSno.ReadOnly = true;
            this.UnitSno.Width = 40;
            // 
            // UnitDesc
            // 
            this.UnitDesc.HeaderText = "Unit";
            this.UnitDesc.MaxInputLength = 50;
            this.UnitDesc.MinimumWidth = 236;
            this.UnitDesc.Name = "UnitDesc";
            this.UnitDesc.Width = 236;
            // 
            // UnitEdit
            // 
            this.UnitEdit.HeaderText = "Edit";
            this.UnitEdit.MinimumWidth = 70;
            this.UnitEdit.Name = "UnitEdit";
            this.UnitEdit.Width = 70;
            // 
            // UnitStatus
            // 
            this.UnitStatus.HeaderText = "Action";
            this.UnitStatus.MinimumWidth = 70;
            this.UnitStatus.Name = "UnitStatus";
            this.UnitStatus.Width = 70;
            // 
            // UnitDelete
            // 
            this.UnitDelete.HeaderText = "Delete";
            this.UnitDelete.MinimumWidth = 70;
            this.UnitDelete.Name = "UnitDelete";
            this.UnitDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UnitDelete.Width = 70;
            // 
            // UnitEditingChk
            // 
            this.UnitEditingChk.HeaderText = "Editing";
            this.UnitEditingChk.MinimumWidth = 40;
            this.UnitEditingChk.Name = "UnitEditingChk";
            this.UnitEditingChk.Visible = false;
            this.UnitEditingChk.Width = 40;
            // 
            // Unitno
            // 
            this.Unitno.HeaderText = "UnitNo";
            this.Unitno.MaxInputLength = 5;
            this.Unitno.MinimumWidth = 40;
            this.Unitno.Name = "Unitno";
            this.Unitno.Visible = false;
            this.Unitno.Width = 40;
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
            // lblCaption
            // 
            this.lblCaption.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCaption.Font = new System.Drawing.Font("Verdana", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCaption.Location = new System.Drawing.Point(-3, -1);
            this.lblCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(563, 66);
            this.lblCaption.TabIndex = 198;
            this.lblCaption.Text = "Units";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnClose.Location = new System.Drawing.Point(483, 374);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 27);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnDelete.Location = new System.Drawing.Point(413, 374);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(63, 27);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnSave.Location = new System.Drawing.Point(343, 374);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 27);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(296, 77);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(98, 16);
            this.lblStatus.TabIndex = 241;
            this.lblStatus.Text = "Show Status";
            // 
            // ddlStatus
            // 
            this.ddlStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlStatus.FormattingEnabled = true;
            this.ddlStatus.Location = new System.Drawing.Point(400, 75);
            this.ddlStatus.Name = "ddlStatus";
            this.ddlStatus.Size = new System.Drawing.Size(146, 24);
            this.ddlStatus.TabIndex = 4;
            this.ddlStatus.SelectedIndexChanged += new System.EventHandler(this.ddlStatus_SelectedIndexChanged);
            // 
            // ApplicationHelpProvider
            // 
            this.ApplicationHelpProvider.HelpNamespace = "\\Help\\HelpFile.chm";
            // 
            // frmUnitMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 409);
            this.ControlBox = false;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.ddlStatus);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.dvUnitDesc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUnitMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Units";
            this.Load += new System.EventHandler(this.frmUnit_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmUnitMaster_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dvUnitDesc)).EndInit();
            this.strpGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvUnitDesc;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox ddlStatus;
        private ERP.CommonLayer.DataGridViewDisabledTextBoxColumn UnitSno;
        private ERP.CommonLayer.DataGridViewDisabledTextBoxColumn UnitDesc;
        private ERP.CommonLayer.DataGridViewDisableButtonColumn UnitEdit;
        private ERP.CommonLayer.DataGridViewDisableButtonColumn UnitStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UnitDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UnitEditingChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unitno;
        internal System.Windows.Forms.HelpProvider ApplicationHelpProvider;
        private System.Windows.Forms.ContextMenuStrip strpGrid;
        private System.Windows.Forms.ToolStripMenuItem ostrpDelete;
    }
}
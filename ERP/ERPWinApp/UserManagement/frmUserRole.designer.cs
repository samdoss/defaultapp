namespace ERPWinApp
{
    partial class frmUserRole
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCaption = new System.Windows.Forms.Label();
            this.ddlUserName = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbluserName = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRights = new System.Windows.Forms.DataGridView();
            this.formLevelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.View = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Print = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.All = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblMsgColor = new System.Windows.Forms.Label();
            this.lblUserMsg = new System.Windows.Forms.Label();
            this.ApplicationHelpProvider = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRights)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCaption.Font = new System.Drawing.Font("Verdana", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCaption.Location = new System.Drawing.Point(-3, -2);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(720, 75);
            this.lblCaption.TabIndex = 198;
            this.lblCaption.Text = "User Rights";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ddlUserName
            // 
            this.ddlUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ddlUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ddlUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlUserName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlUserName.FormattingEnabled = true;
            this.ddlUserName.Location = new System.Drawing.Point(96, 101);
            this.ddlUserName.Name = "ddlUserName";
            this.ddlUserName.Size = new System.Drawing.Size(211, 24);
            this.ddlUserName.TabIndex = 0;
            this.ddlUserName.SelectedIndexChanged += new System.EventHandler(this.ddlUserName_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnClose.Location = new System.Drawing.Point(638, 378);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 27);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnSave.Location = new System.Drawing.Point(569, 378);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 27);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbluserName
            // 
            this.lbluserName.AutoSize = true;
            this.lbluserName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluserName.Location = new System.Drawing.Point(11, 104);
            this.lbluserName.Name = "lbluserName";
            this.lbluserName.Size = new System.Drawing.Size(78, 16);
            this.lbluserName.TabIndex = 202;
            this.lbluserName.Text = "User Name";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(323, 106);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(35, 16);
            this.lblRole.TabIndex = 203;
            this.lblRole.Text = "Role";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnabled.ForeColor = System.Drawing.Color.Black;
            this.chkEnabled.Location = new System.Drawing.Point(620, 105);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(81, 20);
            this.chkEnabled.TabIndex = 205;
            this.chkEnabled.Text = "Disabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.Click += new System.EventHandler(this.chkEnabled_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Task";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 160;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Add";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Edit";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "View";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Print";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Delete";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dgvRights
            // 
            this.dgvRights.AllowUserToAddRows = false;
            this.dgvRights.AllowUserToDeleteRows = false;
            this.dgvRights.AllowUserToResizeColumns = false;
            this.dgvRights.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRights.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRights.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvRights.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRights.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRights.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.formLevelID,
            this.Task,
            this.Add,
            this.Edit,
            this.Delete,
            this.View,
            this.Print,
            this.All});
            this.dgvRights.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvRights.EnableHeadersVisualStyles = false;
            this.dgvRights.Location = new System.Drawing.Point(14, 132);
            this.dgvRights.MultiSelect = false;
            this.dgvRights.Name = "dgvRights";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRights.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvRights.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvRights.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvRights.Size = new System.Drawing.Size(687, 238);
            this.dgvRights.TabIndex = 206;
            this.dgvRights.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRights_CellContentClick);
            // 
            // formLevelID
            // 
            this.formLevelID.HeaderText = "formLevelID";
            this.formLevelID.Name = "formLevelID";
            this.formLevelID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.formLevelID.Visible = false;
            // 
            // Task
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Task.DefaultCellStyle = dataGridViewCellStyle3;
            this.Task.HeaderText = "Task";
            this.Task.Name = "Task";
            this.Task.ReadOnly = true;
            this.Task.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Task.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Task.Width = 270;
            // 
            // Add
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.NullValue = false;
            this.Add.DefaultCellStyle = dataGridViewCellStyle4;
            this.Add.HeaderText = "Add";
            this.Add.Name = "Add";
            this.Add.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Add.Width = 60;
            // 
            // Edit
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.NullValue = false;
            this.Edit.DefaultCellStyle = dataGridViewCellStyle5;
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Edit.Width = 60;
            // 
            // Delete
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.NullValue = false;
            this.Delete.DefaultCellStyle = dataGridViewCellStyle6;
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Delete.Width = 60;
            // 
            // View
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.NullValue = false;
            this.View.DefaultCellStyle = dataGridViewCellStyle7;
            this.View.HeaderText = "View";
            this.View.Name = "View";
            this.View.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.View.Width = 60;
            // 
            // Print
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.NullValue = false;
            this.Print.DefaultCellStyle = dataGridViewCellStyle8;
            this.Print.HeaderText = "Print";
            this.Print.Name = "Print";
            this.Print.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Print.Width = 60;
            // 
            // All
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.NullValue = false;
            this.All.DefaultCellStyle = dataGridViewCellStyle9;
            this.All.HeaderText = "All";
            this.All.Name = "All";
            this.All.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.All.Width = 60;
            // 
            // lblMsgColor
            // 
            this.lblMsgColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblMsgColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMsgColor.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgColor.Location = new System.Drawing.Point(64, 76);
            this.lblMsgColor.Name = "lblMsgColor";
            this.lblMsgColor.Size = new System.Drawing.Size(49, 19);
            this.lblMsgColor.TabIndex = 234;
            this.lblMsgColor.Text = "Yellow";
            this.lblMsgColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserMsg
            // 
            this.lblUserMsg.AutoSize = true;
            this.lblUserMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblUserMsg.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserMsg.Location = new System.Drawing.Point(11, 78);
            this.lblUserMsg.Name = "lblUserMsg";
            this.lblUserMsg.Size = new System.Drawing.Size(263, 13);
            this.lblUserMsg.TabIndex = 233;
            this.lblUserMsg.Text = "Fields in              must be entered / selected";
            // 
            // ApplicationHelpProvider
            // 
            this.ApplicationHelpProvider.HelpNamespace = "\\Help\\HelpFile.chm";
            // 
            // frmUserRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 413);
            this.ControlBox = false;
            this.Controls.Add(this.lblMsgColor);
            this.Controls.Add(this.lblUserMsg);
            this.Controls.Add(this.dgvRights);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.ddlUserName);
            this.Controls.Add(this.lbluserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Rights";
            this.Load += new System.EventHandler(this.frmUserRole_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmUserRole_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRights)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.ComboBox ddlUserName;
        private System.Windows.Forms.Label lbluserName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridView dgvRights;
        private System.Windows.Forms.DataGridViewTextBoxColumn formLevelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Add;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Edit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Delete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn View;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Print;
        private System.Windows.Forms.DataGridViewCheckBoxColumn All;
        private System.Windows.Forms.Label lblMsgColor;
        private System.Windows.Forms.Label lblUserMsg;
        internal System.Windows.Forms.HelpProvider ApplicationHelpProvider;
    }
}
namespace ERPWinApp
{
    partial class frmAttendance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gvAttendance = new System.Windows.Forms.DataGridView();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDateofPurchase = new System.Windows.Forms.DateTimePicker();
            this.btSaveItems = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttendance)).BeginInit();
            this.SuspendLayout();
            // 
            // gvAttendance
            // 
            this.gvAttendance.AllowUserToAddRows = false;
            this.gvAttendance.AllowUserToResizeColumns = false;
            this.gvAttendance.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("FrankRuehl", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.gvAttendance.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.gvAttendance.BackgroundColor = System.Drawing.Color.White;
            this.gvAttendance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gvAttendance.CausesValidation = false;
            this.gvAttendance.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Baskerville Old Face", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvAttendance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gvAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvAttendance.DefaultCellStyle = dataGridViewCellStyle8;
            this.gvAttendance.Location = new System.Drawing.Point(12, 31);
            this.gvAttendance.MultiSelect = false;
            this.gvAttendance.Name = "gvAttendance";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("FrankRuehl", 15.75F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvAttendance.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gvAttendance.RowHeadersVisible = false;
            this.gvAttendance.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("FrankRuehl", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.BurlyWood;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.gvAttendance.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gvAttendance.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gvAttendance.Size = new System.Drawing.Size(1000, 425);
            this.gvAttendance.TabIndex = 16;
            this.gvAttendance.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvAttendance_CellValueChanged);
            this.gvAttendance.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvAttendance_ColumnHeaderMouseClick);
            this.gvAttendance.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gvAttendance_Scroll);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAll.ForeColor = System.Drawing.Color.DarkCyan;
            this.chkAll.Location = new System.Drawing.Point(948, 9);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(42, 20);
            this.chkAll.TabIndex = 18;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkCyan;
            this.label7.Location = new System.Drawing.Point(14, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 48;
            this.label7.Text = "Date:";
            this.label7.Visible = false;
            // 
            // txtDateofPurchase
            // 
            this.txtDateofPurchase.CalendarForeColor = System.Drawing.Color.DarkCyan;
            this.txtDateofPurchase.CustomFormat = "dd/MM/yyyy";
            this.txtDateofPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateofPurchase.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDateofPurchase.Location = new System.Drawing.Point(70, 6);
            this.txtDateofPurchase.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.txtDateofPurchase.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.txtDateofPurchase.Name = "txtDateofPurchase";
            this.txtDateofPurchase.Size = new System.Drawing.Size(124, 22);
            this.txtDateofPurchase.TabIndex = 47;
            this.txtDateofPurchase.ValueChanged += new System.EventHandler(this.txtDateofPurchase_ValueChanged);
            // 
            // btSaveItems
            // 
            this.btSaveItems.BackColor = System.Drawing.Color.White;
            this.btSaveItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSaveItems.ForeColor = System.Drawing.Color.DarkCyan;
            this.btSaveItems.Location = new System.Drawing.Point(876, 472);
            this.btSaveItems.Name = "btSaveItems";
            this.btSaveItems.Size = new System.Drawing.Size(136, 38);
            this.btSaveItems.TabIndex = 49;
            this.btSaveItems.Text = "Save Changes";
            this.btSaveItems.UseVisualStyleBackColor = true;
            this.btSaveItems.Click += new System.EventHandler(this.btSaveItems_Click);
            // 
            // frmAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 522);
            this.Controls.Add(this.btSaveItems);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDateofPurchase);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.gvAttendance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmAttendance";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Attendance";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Attendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvAttendance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView gvAttendance;
        internal System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker txtDateofPurchase;
        private System.Windows.Forms.Button btSaveItems;
    }
}
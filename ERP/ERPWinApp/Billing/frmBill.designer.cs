namespace ERPWinApp
{
    partial class frmBill
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCaption = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtGrossAmount = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblPatientNumber = new System.Windows.Forms.Label();
            this.txtPatientNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiscountAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNetAmount = new System.Windows.Forms.TextBox();
            this.dgvBill = new System.Windows.Forms.DataGridView();
            this.BillSNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillServiceTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillDescriptionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strpGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ostrpDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPayment = new System.Windows.Forms.TabControl();
            this.tabCheque = new System.Windows.Forms.TabPage();
            this.lblDDMonYY = new System.Windows.Forms.Label();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.txtChequeBranchName = new System.Windows.Forms.TextBox();
            this.txtChequeBankName = new System.Windows.Forms.TextBox();
            this.txtChequeAmt = new System.Windows.Forms.TextBox();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChequeDate = new System.Windows.Forms.MaskedTextBox();
            this.tabDemandDraft = new System.Windows.Forms.TabPage();
            this.lblddMonYear = new System.Windows.Forms.Label();
            this.dtpDateDD = new System.Windows.Forms.DateTimePicker();
            this.txtDDBranchName = new System.Windows.Forms.TextBox();
            this.txtDDBankName = new System.Windows.Forms.TextBox();
            this.txtDDAmt = new System.Windows.Forms.TextBox();
            this.txtDDNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDDDate = new System.Windows.Forms.MaskedTextBox();
            this.tabCard = new System.Windows.Forms.TabPage();
            this.lblCardType = new System.Windows.Forms.Label();
            this.ddlCardType = new System.Windows.Forms.ComboBox();
            this.txtCardNo = new System.Windows.Forms.MaskedTextBox();
            this.txtCardAmt = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCardHolderName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lstPreviousBill = new System.Windows.Forms.ListBox();
            this.lblPreviousBill = new System.Windows.Forms.Label();
            this.lblBillid = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMsgColor = new System.Windows.Forms.Label();
            this.lblUserMsg = new System.Windows.Forms.Label();
            this.ApplicationHelpProvider = new System.Windows.Forms.HelpProvider();
            this.lblPaymentMode = new System.Windows.Forms.Label();
            this.ddlBillMode = new System.Windows.Forms.ComboBox();
            this.tabDD = new System.Windows.Forms.TabControl();
            this.tabCredit = new System.Windows.Forms.TabControl();
            this.btnAddBill = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tpCash = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.txtCashBillAmount = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtBalanceAmount = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtReceivedAmount = new System.Windows.Forms.TextBox();
            this.tbCash = new System.Windows.Forms.TabControl();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMessageToUsers = new System.Windows.Forms.Label();
            this.lblBillDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).BeginInit();
            this.strpGrid.SuspendLayout();
            this.tabPayment.SuspendLayout();
            this.tabCheque.SuspendLayout();
            this.tabDemandDraft.SuspendLayout();
            this.tabCard.SuspendLayout();
            this.tabDD.SuspendLayout();
            this.tabCredit.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tpCash.SuspendLayout();
            this.tbCash.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCaption.Font = new System.Drawing.Font("Verdana", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCaption.Location = new System.Drawing.Point(-1, -2);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(887, 75);
            this.lblCaption.TabIndex = 198;
            this.lblCaption.Text = "Patient Bill";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnClose.Location = new System.Drawing.Point(810, 551);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 27);
            this.btnClose.TabIndex = 10;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnSave.Location = new System.Drawing.Point(603, 551);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 27);
            this.btnSave.TabIndex = 7;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtGrossAmount
            // 
            this.txtGrossAmount.BackColor = System.Drawing.SystemColors.Window;
            this.txtGrossAmount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrossAmount.Location = new System.Drawing.Point(780, 444);
            this.txtGrossAmount.MaxLength = 10;
            this.txtGrossAmount.Name = "txtGrossAmount";
            this.txtGrossAmount.ReadOnly = true;
            this.txtGrossAmount.Size = new System.Drawing.Size(93, 23);
            this.txtGrossAmount.TabIndex = 4;
            this.txtGrossAmount.TabStop = false;
            this.txtGrossAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(675, 447);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(99, 16);
            this.lblAmount.TabIndex = 233;
            this.lblAmount.Text = "Amount in Rs.";
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientName.Location = new System.Drawing.Point(299, 111);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(96, 16);
            this.lblPatientName.TabIndex = 239;
            this.lblPatientName.Text = "Patient Name";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(230, 106);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(63, 27);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "Searc&h";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblPatientNumber
            // 
            this.lblPatientNumber.AutoSize = true;
            this.lblPatientNumber.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientNumber.ForeColor = System.Drawing.Color.Black;
            this.lblPatientNumber.Location = new System.Drawing.Point(62, 111);
            this.lblPatientNumber.Name = "lblPatientNumber";
            this.lblPatientNumber.Size = new System.Drawing.Size(70, 16);
            this.lblPatientNumber.TabIndex = 241;
            this.lblPatientNumber.Text = "Patient #";
            // 
            // txtPatientNumber
            // 
            this.txtPatientNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPatientNumber.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientNumber.Location = new System.Drawing.Point(136, 108);
            this.txtPatientNumber.MaxLength = 9;
            this.txtPatientNumber.Name = "txtPatientNumber";
            this.txtPatientNumber.Size = new System.Drawing.Size(88, 23);
            this.txtPatientNumber.TabIndex = 0;
            this.txtPatientNumber.TextChanged += new System.EventHandler(this.txtPatientNumber_TextChanged);
            this.txtPatientNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatientNumber_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(668, 473);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 16);
            this.label3.TabIndex = 247;
            this.label3.Text = "Discount in Rs.";
            // 
            // txtDiscountAmount
            // 
            this.txtDiscountAmount.BackColor = System.Drawing.SystemColors.Window;
            this.txtDiscountAmount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountAmount.Location = new System.Drawing.Point(780, 470);
            this.txtDiscountAmount.MaxLength = 10;
            this.txtDiscountAmount.Name = "txtDiscountAmount";
            this.txtDiscountAmount.Size = new System.Drawing.Size(93, 23);
            this.txtDiscountAmount.TabIndex = 5;
            this.txtDiscountAmount.TabStop = false;
            this.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscountAmount.TextChanged += new System.EventHandler(this.txtDiscountAmount_TextChanged);
            this.txtDiscountAmount.Leave += new System.EventHandler(this.txtDiscountAmount_Leave);
            this.txtDiscountAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscountAmount_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(653, 501);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 16);
            this.label4.TabIndex = 249;
            this.label4.Text = "Bill Amount in Rs.";
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.BackColor = System.Drawing.SystemColors.Window;
            this.txtNetAmount.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetAmount.Location = new System.Drawing.Point(780, 496);
            this.txtNetAmount.MaxLength = 10;
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.ReadOnly = true;
            this.txtNetAmount.Size = new System.Drawing.Size(93, 27);
            this.txtNetAmount.TabIndex = 6;
            this.txtNetAmount.TabStop = false;
            this.txtNetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNetAmount.TextChanged += new System.EventHandler(this.txtNetAmount_TextChanged);
            // 
            // dgvBill
            // 
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.Gainsboro;
            this.dgvBill.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle15;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BillSNo,
            this.BillCode,
            this.BillDesc,
            this.BillServiceTax,
            this.BillPrice,
            this.BillTotal,
            this.BillDescriptionID});
            this.dgvBill.ContextMenuStrip = this.strpGrid;
            this.dgvBill.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvBill.Location = new System.Drawing.Point(12, 169);
            this.dgvBill.Name = "dgvBill";
            this.dgvBill.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvBill.ShowCellErrors = false;
            this.dgvBill.Size = new System.Drawing.Size(861, 242);
            this.dgvBill.TabIndex = 3;
            this.dgvBill.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvBill_UserAddedRow);
            this.dgvBill.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBill_RowEnter);
            this.dgvBill.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvBill_MouseClick);
            this.dgvBill.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBill_CellValidated);
            this.dgvBill.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvBill_PreviewKeyDown);
            this.dgvBill.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvBill_UserDeletedRow);
            this.dgvBill.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBill_CellEndEdit);
            this.dgvBill.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvBill_EditingControlShowing);
            // 
            // BillSNo
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.Format = "N0";
            dataGridViewCellStyle17.NullValue = null;
            this.BillSNo.DefaultCellStyle = dataGridViewCellStyle17;
            this.BillSNo.HeaderText = "S.No.";
            this.BillSNo.MaxInputLength = 5;
            this.BillSNo.MinimumWidth = 45;
            this.BillSNo.Name = "BillSNo";
            this.BillSNo.ReadOnly = true;
            this.BillSNo.Width = 45;
            // 
            // BillCode
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.BillCode.DefaultCellStyle = dataGridViewCellStyle18;
            this.BillCode.HeaderText = "Bill Code";
            this.BillCode.MaxInputLength = 25;
            this.BillCode.MinimumWidth = 100;
            this.BillCode.Name = "BillCode";
            // 
            // BillDesc
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.BillDesc.DefaultCellStyle = dataGridViewCellStyle19;
            this.BillDesc.HeaderText = "Description";
            this.BillDesc.MaxInputLength = 200;
            this.BillDesc.MinimumWidth = 340;
            this.BillDesc.Name = "BillDesc";
            this.BillDesc.ReadOnly = true;
            this.BillDesc.Width = 340;
            // 
            // BillServiceTax
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle20.Format = "N2";
            dataGridViewCellStyle20.NullValue = null;
            this.BillServiceTax.DefaultCellStyle = dataGridViewCellStyle20;
            this.BillServiceTax.HeaderText = "Service Tax (%)";
            this.BillServiceTax.MaxInputLength = 5;
            this.BillServiceTax.MinimumWidth = 140;
            this.BillServiceTax.Name = "BillServiceTax";
            this.BillServiceTax.ReadOnly = true;
            this.BillServiceTax.Width = 140;
            // 
            // BillPrice
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.Format = "N2";
            dataGridViewCellStyle21.NullValue = null;
            this.BillPrice.DefaultCellStyle = dataGridViewCellStyle21;
            this.BillPrice.HeaderText = "Price";
            this.BillPrice.MaxInputLength = 10;
            this.BillPrice.MinimumWidth = 89;
            this.BillPrice.Name = "BillPrice";
            this.BillPrice.Width = 89;
            // 
            // BillTotal
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.Format = "N2";
            dataGridViewCellStyle22.NullValue = null;
            this.BillTotal.DefaultCellStyle = dataGridViewCellStyle22;
            this.BillTotal.HeaderText = "Total";
            this.BillTotal.MaxInputLength = 10;
            this.BillTotal.Name = "BillTotal";
            this.BillTotal.ReadOnly = true;
            // 
            // BillDescriptionID
            // 
            this.BillDescriptionID.HeaderText = "BillDescriptionID";
            this.BillDescriptionID.MaxInputLength = 5;
            this.BillDescriptionID.Name = "BillDescriptionID";
            this.BillDescriptionID.Visible = false;
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
            // tabPayment
            // 
            this.tabPayment.Controls.Add(this.tabCheque);
            this.tabPayment.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPayment.Location = new System.Drawing.Point(12, 415);
            this.tabPayment.Name = "tabPayment";
            this.tabPayment.SelectedIndex = 0;
            this.tabPayment.Size = new System.Drawing.Size(452, 163);
            this.tabPayment.TabIndex = 253;
            // 
            // tabCheque
            // 
            this.tabCheque.Controls.Add(this.lblDDMonYY);
            this.tabCheque.Controls.Add(this.dtpDOB);
            this.tabCheque.Controls.Add(this.txtChequeBranchName);
            this.tabCheque.Controls.Add(this.txtChequeBankName);
            this.tabCheque.Controls.Add(this.txtChequeAmt);
            this.tabCheque.Controls.Add(this.txtChequeNo);
            this.tabCheque.Controls.Add(this.label8);
            this.tabCheque.Controls.Add(this.label7);
            this.tabCheque.Controls.Add(this.label6);
            this.tabCheque.Controls.Add(this.label5);
            this.tabCheque.Controls.Add(this.label1);
            this.tabCheque.Controls.Add(this.txtChequeDate);
            this.tabCheque.Location = new System.Drawing.Point(4, 25);
            this.tabCheque.Name = "tabCheque";
            this.tabCheque.Padding = new System.Windows.Forms.Padding(3);
            this.tabCheque.Size = new System.Drawing.Size(444, 134);
            this.tabCheque.TabIndex = 0;
            this.tabCheque.Text = "Cheque";
            this.tabCheque.UseVisualStyleBackColor = true;
            // 
            // lblDDMonYY
            // 
            this.lblDDMonYY.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDDMonYY.Location = new System.Drawing.Point(340, 34);
            this.lblDDMonYY.Name = "lblDDMonYY";
            this.lblDDMonYY.Size = new System.Drawing.Size(75, 16);
            this.lblDDMonYY.TabIndex = 275;
            this.lblDDMonYY.Text = "(dd/mm/yyyy)";
            // 
            // dtpDOB
            // 
            this.dtpDOB.CalendarMonthBackground = System.Drawing.SystemColors.Menu;
            this.dtpDOB.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpDOB.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpDOB.CustomFormat = "dd/MM/yyyy";
            this.dtpDOB.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDOB.Location = new System.Drawing.Point(332, 8);
            this.dtpDOB.MaxDate = new System.DateTime(2008, 10, 10, 0, 0, 0, 0);
            this.dtpDOB.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.ShowUpDown = true;
            this.dtpDOB.Size = new System.Drawing.Size(106, 23);
            this.dtpDOB.TabIndex = 256;
            this.dtpDOB.Value = new System.DateTime(2008, 10, 10, 0, 0, 0, 0);
            this.dtpDOB.ValueChanged += new System.EventHandler(this.dtpDOB_ValueChanged);
            // 
            // txtChequeBranchName
            // 
            this.txtChequeBranchName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtChequeBranchName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeBranchName.Location = new System.Drawing.Point(110, 97);
            this.txtChequeBranchName.MaxLength = 49;
            this.txtChequeBranchName.Name = "txtChequeBranchName";
            this.txtChequeBranchName.Size = new System.Drawing.Size(233, 23);
            this.txtChequeBranchName.TabIndex = 251;
            // 
            // txtChequeBankName
            // 
            this.txtChequeBankName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtChequeBankName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeBankName.Location = new System.Drawing.Point(110, 67);
            this.txtChequeBankName.MaxLength = 99;
            this.txtChequeBankName.Name = "txtChequeBankName";
            this.txtChequeBankName.Size = new System.Drawing.Size(233, 23);
            this.txtChequeBankName.TabIndex = 250;
            // 
            // txtChequeAmt
            // 
            this.txtChequeAmt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtChequeAmt.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeAmt.Location = new System.Drawing.Point(110, 38);
            this.txtChequeAmt.MaxLength = 10;
            this.txtChequeAmt.Name = "txtChequeAmt";
            this.txtChequeAmt.ReadOnly = true;
            this.txtChequeAmt.Size = new System.Drawing.Size(109, 23);
            this.txtChequeAmt.TabIndex = 249;
            this.txtChequeAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChequeAmt_KeyPress);
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtChequeNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeNo.Location = new System.Drawing.Point(110, 8);
            this.txtChequeNo.MaxLength = 9;
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(109, 23);
            this.txtChequeNo.TabIndex = 247;
            this.txtChequeNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChequeNo_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(5, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 16);
            this.label8.TabIndex = 246;
            this.label8.Text = "Amount in Rs.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(10, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 16);
            this.label7.TabIndex = 245;
            this.label7.Text = "Branch Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(24, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 244;
            this.label6.Text = "Bank Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(233, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 243;
            this.label5.Text = "Cheque Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(32, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 242;
            this.label1.Text = "Cheque #";
            // 
            // txtChequeDate
            // 
            this.txtChequeDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtChequeDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeDate.Location = new System.Drawing.Point(332, 8);
            this.txtChequeDate.Mask = "00/00/0000";
            this.txtChequeDate.Name = "txtChequeDate";
            this.txtChequeDate.Size = new System.Drawing.Size(21, 23);
            this.txtChequeDate.TabIndex = 255;
            this.txtChequeDate.ValidatingType = typeof(System.DateTime);
            this.txtChequeDate.Visible = false;
            this.txtChequeDate.Validated += new System.EventHandler(this.txtChequeDate_Validated);
            // 
            // tabDemandDraft
            // 
            this.tabDemandDraft.Controls.Add(this.lblddMonYear);
            this.tabDemandDraft.Controls.Add(this.dtpDateDD);
            this.tabDemandDraft.Controls.Add(this.txtDDBranchName);
            this.tabDemandDraft.Controls.Add(this.txtDDBankName);
            this.tabDemandDraft.Controls.Add(this.txtDDAmt);
            this.tabDemandDraft.Controls.Add(this.txtDDNo);
            this.tabDemandDraft.Controls.Add(this.label9);
            this.tabDemandDraft.Controls.Add(this.label10);
            this.tabDemandDraft.Controls.Add(this.label11);
            this.tabDemandDraft.Controls.Add(this.label12);
            this.tabDemandDraft.Controls.Add(this.label13);
            this.tabDemandDraft.Controls.Add(this.txtDDDate);
            this.tabDemandDraft.Location = new System.Drawing.Point(4, 25);
            this.tabDemandDraft.Name = "tabDemandDraft";
            this.tabDemandDraft.Padding = new System.Windows.Forms.Padding(3);
            this.tabDemandDraft.Size = new System.Drawing.Size(444, 134);
            this.tabDemandDraft.TabIndex = 1;
            this.tabDemandDraft.Text = "Demand Draft";
            this.tabDemandDraft.UseVisualStyleBackColor = true;
            // 
            // lblddMonYear
            // 
            this.lblddMonYear.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblddMonYear.Location = new System.Drawing.Point(340, 34);
            this.lblddMonYear.Name = "lblddMonYear";
            this.lblddMonYear.Size = new System.Drawing.Size(75, 16);
            this.lblddMonYear.TabIndex = 275;
            this.lblddMonYear.Text = "(dd/mm/yyyy)";
            // 
            // dtpDateDD
            // 
            this.dtpDateDD.CalendarMonthBackground = System.Drawing.SystemColors.Menu;
            this.dtpDateDD.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpDateDD.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpDateDD.CustomFormat = "dd/MM/yyyy";
            this.dtpDateDD.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateDD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateDD.Location = new System.Drawing.Point(332, 8);
            this.dtpDateDD.MaxDate = new System.DateTime(2008, 10, 10, 0, 0, 0, 0);
            this.dtpDateDD.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDateDD.Name = "dtpDateDD";
            this.dtpDateDD.ShowUpDown = true;
            this.dtpDateDD.Size = new System.Drawing.Size(106, 23);
            this.dtpDateDD.TabIndex = 263;
            this.dtpDateDD.Value = new System.DateTime(2008, 10, 10, 0, 0, 0, 0);
            this.dtpDateDD.ValueChanged += new System.EventHandler(this.dtpDateDD_ValueChanged);
            // 
            // txtDDBranchName
            // 
            this.txtDDBranchName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDDBranchName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDDBranchName.Location = new System.Drawing.Point(110, 97);
            this.txtDDBranchName.MaxLength = 49;
            this.txtDDBranchName.Name = "txtDDBranchName";
            this.txtDDBranchName.Size = new System.Drawing.Size(233, 23);
            this.txtDDBranchName.TabIndex = 261;
            // 
            // txtDDBankName
            // 
            this.txtDDBankName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDDBankName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDDBankName.Location = new System.Drawing.Point(110, 67);
            this.txtDDBankName.MaxLength = 99;
            this.txtDDBankName.Name = "txtDDBankName";
            this.txtDDBankName.Size = new System.Drawing.Size(233, 23);
            this.txtDDBankName.TabIndex = 260;
            // 
            // txtDDAmt
            // 
            this.txtDDAmt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDDAmt.Enabled = false;
            this.txtDDAmt.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDDAmt.Location = new System.Drawing.Point(110, 38);
            this.txtDDAmt.MaxLength = 10;
            this.txtDDAmt.Name = "txtDDAmt";
            this.txtDDAmt.ReadOnly = true;
            this.txtDDAmt.Size = new System.Drawing.Size(109, 23);
            this.txtDDAmt.TabIndex = 259;
            this.txtDDAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDDAmt_KeyPress);
            // 
            // txtDDNo
            // 
            this.txtDDNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDDNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDDNo.Location = new System.Drawing.Point(110, 8);
            this.txtDDNo.MaxLength = 9;
            this.txtDDNo.Name = "txtDDNo";
            this.txtDDNo.Size = new System.Drawing.Size(110, 23);
            this.txtDDNo.TabIndex = 257;
            this.txtDDNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDDNo_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(5, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 16);
            this.label9.TabIndex = 256;
            this.label9.Text = "Amount in Rs.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(10, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 16);
            this.label10.TabIndex = 255;
            this.label10.Text = "Branch Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(24, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 16);
            this.label11.TabIndex = 254;
            this.label11.Text = "Bank Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(249, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 16);
            this.label12.TabIndex = 253;
            this.label12.Text = "Draft Date";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(48, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 252;
            this.label13.Text = "Draft #";
            // 
            // txtDDDate
            // 
            this.txtDDDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDDDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDDDate.Location = new System.Drawing.Point(332, 8);
            this.txtDDDate.Mask = "00/00/0000";
            this.txtDDDate.Name = "txtDDDate";
            this.txtDDDate.Size = new System.Drawing.Size(21, 23);
            this.txtDDDate.TabIndex = 262;
            this.txtDDDate.ValidatingType = typeof(System.DateTime);
            this.txtDDDate.Visible = false;
            this.txtDDDate.Validated += new System.EventHandler(this.txtDDDate_Validated);
            // 
            // tabCard
            // 
            this.tabCard.Controls.Add(this.lblCardType);
            this.tabCard.Controls.Add(this.ddlCardType);
            this.tabCard.Controls.Add(this.txtCardNo);
            this.tabCard.Controls.Add(this.txtCardAmt);
            this.tabCard.Controls.Add(this.label16);
            this.tabCard.Controls.Add(this.txtCardHolderName);
            this.tabCard.Controls.Add(this.label14);
            this.tabCard.Controls.Add(this.label15);
            this.tabCard.Location = new System.Drawing.Point(4, 25);
            this.tabCard.Name = "tabCard";
            this.tabCard.Padding = new System.Windows.Forms.Padding(3);
            this.tabCard.Size = new System.Drawing.Size(444, 132);
            this.tabCard.TabIndex = 2;
            this.tabCard.Text = "Credit / Debit Card";
            this.tabCard.UseVisualStyleBackColor = true;
            // 
            // lblCardType
            // 
            this.lblCardType.AutoSize = true;
            this.lblCardType.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCardType.Location = new System.Drawing.Point(51, 12);
            this.lblCardType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(76, 16);
            this.lblCardType.TabIndex = 285;
            this.lblCardType.Text = "Card Type";
            // 
            // ddlCardType
            // 
            this.ddlCardType.AllowDrop = true;
            this.ddlCardType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlCardType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlCardType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ddlCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCardType.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCardType.FormattingEnabled = true;
            this.ddlCardType.Items.AddRange(new object[] {
            "--Select--",
            "MasterCard",
            "Visa",
            "AmericanExpress",
            "VisaElectron",
            "Bankcard",
            "DinersClubInternational",
            "DinersClubUSandCanada",
            "DiscoverCard",
            "JCB",
            "Maestro",
            "SoloDebit",
            "SwitchDebit",
            "enRoute"});
            this.ddlCardType.Location = new System.Drawing.Point(132, 9);
            this.ddlCardType.Margin = new System.Windows.Forms.Padding(4);
            this.ddlCardType.Name = "ddlCardType";
            this.ddlCardType.Size = new System.Drawing.Size(211, 24);
            this.ddlCardType.TabIndex = 284;
            this.ddlCardType.SelectedIndexChanged += new System.EventHandler(this.ddlCardType_SelectedIndexChanged);
            // 
            // txtCardNo
            // 
            this.txtCardNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCardNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNo.Location = new System.Drawing.Point(132, 40);
            this.txtCardNo.Mask = "0000 0000 0000 0000 000";
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(211, 23);
            this.txtCardNo.TabIndex = 265;
            this.txtCardNo.Leave += new System.EventHandler(this.txtCardNo_Leave);
            this.txtCardNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardNo_KeyPress);
            // 
            // txtCardAmt
            // 
            this.txtCardAmt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCardAmt.Enabled = false;
            this.txtCardAmt.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardAmt.Location = new System.Drawing.Point(132, 99);
            this.txtCardAmt.MaxLength = 10;
            this.txtCardAmt.Name = "txtCardAmt";
            this.txtCardAmt.ReadOnly = true;
            this.txtCardAmt.Size = new System.Drawing.Size(124, 23);
            this.txtCardAmt.TabIndex = 264;
            this.txtCardAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardAmt_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(28, 101);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 16);
            this.label16.TabIndex = 263;
            this.label16.Text = "Amount in Rs.";
            // 
            // txtCardHolderName
            // 
            this.txtCardHolderName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCardHolderName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardHolderName.Location = new System.Drawing.Point(132, 69);
            this.txtCardHolderName.MaxLength = 99;
            this.txtCardHolderName.Name = "txtCardHolderName";
            this.txtCardHolderName.Size = new System.Drawing.Size(211, 23);
            this.txtCardHolderName.TabIndex = 262;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(2, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 16);
            this.label14.TabIndex = 260;
            this.label14.Text = "Card Holder Name";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(73, 43);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 16);
            this.label15.TabIndex = 259;
            this.label15.Text = "Card #";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPrint.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnPrint.Location = new System.Drawing.Point(741, 551);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(63, 27);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.TabStop = false;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lstPreviousBill
            // 
            this.lstPreviousBill.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPreviousBill.FormattingEnabled = true;
            this.lstPreviousBill.ItemHeight = 16;
            this.lstPreviousBill.Location = new System.Drawing.Point(701, 95);
            this.lstPreviousBill.Name = "lstPreviousBill";
            this.lstPreviousBill.Size = new System.Drawing.Size(172, 68);
            this.lstPreviousBill.TabIndex = 11;
            this.lstPreviousBill.Click += new System.EventHandler(this.lstPreviousBill_Click);
            // 
            // lblPreviousBill
            // 
            this.lblPreviousBill.AutoSize = true;
            this.lblPreviousBill.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreviousBill.Location = new System.Drawing.Point(698, 76);
            this.lblPreviousBill.Name = "lblPreviousBill";
            this.lblPreviousBill.Size = new System.Drawing.Size(85, 16);
            this.lblPreviousBill.TabIndex = 268;
            this.lblPreviousBill.Text = "Previous Bill";
            // 
            // lblBillid
            // 
            this.lblBillid.AutoSize = true;
            this.lblBillid.Location = new System.Drawing.Point(591, 105);
            this.lblBillid.Name = "lblBillid";
            this.lblBillid.Size = new System.Drawing.Size(0, 13);
            this.lblBillid.TabIndex = 269;
            this.lblBillid.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.btnCancel.Location = new System.Drawing.Point(672, 551);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 27);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "&Reset";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMsgColor
            // 
            this.lblMsgColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblMsgColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMsgColor.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblMsgColor.Location = new System.Drawing.Point(58, 73);
            this.lblMsgColor.Name = "lblMsgColor";
            this.lblMsgColor.Size = new System.Drawing.Size(53, 19);
            this.lblMsgColor.TabIndex = 281;
            this.lblMsgColor.Text = "Yellow";
            this.lblMsgColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserMsg
            // 
            this.lblUserMsg.AutoSize = true;
            this.lblUserMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblUserMsg.Font = new System.Drawing.Font("Verdana", 8F);
            this.lblUserMsg.Location = new System.Drawing.Point(5, 76);
            this.lblUserMsg.Name = "lblUserMsg";
            this.lblUserMsg.Size = new System.Drawing.Size(267, 13);
            this.lblUserMsg.TabIndex = 280;
            this.lblUserMsg.Text = "Fields in               must be entered / selected";
            // 
            // ApplicationHelpProvider
            // 
            this.ApplicationHelpProvider.HelpNamespace = "\\Help\\HelpFile.chm";
            // 
            // lblPaymentMode
            // 
            this.lblPaymentMode.AutoSize = true;
            this.lblPaymentMode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentMode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPaymentMode.Location = new System.Drawing.Point(9, 140);
            this.lblPaymentMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaymentMode.Name = "lblPaymentMode";
            this.lblPaymentMode.Size = new System.Drawing.Size(123, 16);
            this.lblPaymentMode.TabIndex = 283;
            this.lblPaymentMode.Text = "Mode of Payment";
            // 
            // ddlBillMode
            // 
            this.ddlBillMode.AllowDrop = true;
            this.ddlBillMode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlBillMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlBillMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ddlBillMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBillMode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlBillMode.FormattingEnabled = true;
            this.ddlBillMode.Items.AddRange(new object[] {
            "--Select--",
            "Cash",
            "Cheque",
            "Demand Draft",
            "Credit/ Debit Card"});
            this.ddlBillMode.Location = new System.Drawing.Point(136, 137);
            this.ddlBillMode.Margin = new System.Windows.Forms.Padding(4);
            this.ddlBillMode.Name = "ddlBillMode";
            this.ddlBillMode.Size = new System.Drawing.Size(157, 24);
            this.ddlBillMode.TabIndex = 1;
            this.ddlBillMode.SelectedIndexChanged += new System.EventHandler(this.ddlBillMode_SelectedIndexChanged);
            // 
            // tabDD
            // 
            this.tabDD.Controls.Add(this.tabDemandDraft);
            this.tabDD.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDD.Location = new System.Drawing.Point(12, 415);
            this.tabDD.Name = "tabDD";
            this.tabDD.SelectedIndex = 0;
            this.tabDD.Size = new System.Drawing.Size(452, 163);
            this.tabDD.TabIndex = 284;
            // 
            // tabCredit
            // 
            this.tabCredit.Controls.Add(this.tabCard);
            this.tabCredit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCredit.Location = new System.Drawing.Point(12, 417);
            this.tabCredit.Name = "tabCredit";
            this.tabCredit.SelectedIndex = 0;
            this.tabCredit.Size = new System.Drawing.Size(452, 161);
            this.tabCredit.TabIndex = 285;
            // 
            // btnAddBill
            // 
            this.btnAddBill.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAddBill.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBill.Location = new System.Drawing.Point(300, 135);
            this.btnAddBill.Name = "btnAddBill";
            this.btnAddBill.Size = new System.Drawing.Size(69, 27);
            this.btnAddBill.TabIndex = 2;
            this.btnAddBill.TabStop = false;
            this.btnAddBill.Text = "&New Bill";
            this.btnAddBill.UseVisualStyleBackColor = false;
            this.btnAddBill.Click += new System.EventHandler(this.btnAddBill_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(600, 300);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Credit / Debit Card";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(132, 73);
            this.textBox1.MaxLength = 10;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(233, 23);
            this.textBox1.TabIndex = 264;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(28, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 263;
            this.label2.Text = "Amount in Rs.";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(132, 43);
            this.textBox2.MaxLength = 99;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(233, 23);
            this.textBox2.TabIndex = 262;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(132, 11);
            this.textBox3.MaxLength = 20;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(233, 23);
            this.textBox3.TabIndex = 261;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(2, 46);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(125, 16);
            this.label17.TabIndex = 260;
            this.label17.Text = "Card Holder Name";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(73, 14);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 16);
            this.label18.TabIndex = 259;
            this.label18.Text = "Card #";
            // 
            // tpCash
            // 
            this.tpCash.Controls.Add(this.label19);
            this.tpCash.Controls.Add(this.txtCashBillAmount);
            this.tpCash.Controls.Add(this.label20);
            this.tpCash.Controls.Add(this.txtBalanceAmount);
            this.tpCash.Controls.Add(this.label21);
            this.tpCash.Controls.Add(this.txtReceivedAmount);
            this.tpCash.Location = new System.Drawing.Point(4, 25);
            this.tpCash.Name = "tpCash";
            this.tpCash.Padding = new System.Windows.Forms.Padding(3);
            this.tpCash.Size = new System.Drawing.Size(444, 132);
            this.tpCash.TabIndex = 0;
            this.tpCash.Text = "Cash";
            this.tpCash.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(81, 20);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(121, 16);
            this.label19.TabIndex = 255;
            this.label19.Text = "Bill Amount in Rs.";
            // 
            // txtCashBillAmount
            // 
            this.txtCashBillAmount.BackColor = System.Drawing.SystemColors.Window;
            this.txtCashBillAmount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashBillAmount.Location = new System.Drawing.Point(208, 17);
            this.txtCashBillAmount.MaxLength = 10;
            this.txtCashBillAmount.Name = "txtCashBillAmount";
            this.txtCashBillAmount.ReadOnly = true;
            this.txtCashBillAmount.Size = new System.Drawing.Size(135, 23);
            this.txtCashBillAmount.TabIndex = 0;
            this.txtCashBillAmount.TabStop = false;
            this.txtCashBillAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(88, 80);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(114, 16);
            this.label20.TabIndex = 253;
            this.label20.Text = "Balance Due Rs.";
            // 
            // txtBalanceAmount
            // 
            this.txtBalanceAmount.BackColor = System.Drawing.SystemColors.Window;
            this.txtBalanceAmount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalanceAmount.Location = new System.Drawing.Point(208, 77);
            this.txtBalanceAmount.MaxLength = 10;
            this.txtBalanceAmount.Name = "txtBalanceAmount";
            this.txtBalanceAmount.ReadOnly = true;
            this.txtBalanceAmount.Size = new System.Drawing.Size(135, 23);
            this.txtBalanceAmount.TabIndex = 2;
            this.txtBalanceAmount.TabStop = false;
            this.txtBalanceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(70, 51);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(132, 16);
            this.label21.TabIndex = 251;
            this.label21.Text = "Cash Tendered Rs.";
            // 
            // txtReceivedAmount
            // 
            this.txtReceivedAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtReceivedAmount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceivedAmount.Location = new System.Drawing.Point(208, 48);
            this.txtReceivedAmount.MaxLength = 10;
            this.txtReceivedAmount.Name = "txtReceivedAmount";
            this.txtReceivedAmount.Size = new System.Drawing.Size(135, 23);
            this.txtReceivedAmount.TabIndex = 1;
            this.txtReceivedAmount.TabStop = false;
            this.txtReceivedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtReceivedAmount.TextChanged += new System.EventHandler(this.txtReceivedAmount_TextChanged);
            this.txtReceivedAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReceivedAmount_KeyPress);
            // 
            // tbCash
            // 
            this.tbCash.Controls.Add(this.tpCash);
            this.tbCash.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCash.Location = new System.Drawing.Point(12, 417);
            this.tbCash.Name = "tbCash";
            this.tbCash.SelectedIndex = 0;
            this.tbCash.Size = new System.Drawing.Size(452, 161);
            this.tbCash.TabIndex = 287;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.HeaderText = "S.No.";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn1.MinimumWidth = 70;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.HeaderText = "Bill Code";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 25;
            this.dataGridViewTextBoxColumn2.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewTextBoxColumn3.HeaderText = "Description";
            this.dataGridViewTextBoxColumn3.MaxInputLength = 200;
            this.dataGridViewTextBoxColumn3.MinimumWidth = 375;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 375;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridViewTextBoxColumn4.HeaderText = "Price";
            this.dataGridViewTextBoxColumn4.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn4.MinimumWidth = 90;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 90;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle25.Format = "N2";
            dataGridViewCellStyle25.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle25;
            this.dataGridViewTextBoxColumn5.HeaderText = "Price";
            this.dataGridViewTextBoxColumn5.MaxInputLength = 10;
            this.dataGridViewTextBoxColumn5.MinimumWidth = 89;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 89;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle26.Format = "N2";
            dataGridViewCellStyle26.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle26;
            this.dataGridViewTextBoxColumn6.HeaderText = "Total";
            this.dataGridViewTextBoxColumn6.MaxInputLength = 10;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "BillDescriptionID";
            this.dataGridViewTextBoxColumn7.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // lblMessageToUsers
            // 
            this.lblMessageToUsers.AutoSize = true;
            this.lblMessageToUsers.Location = new System.Drawing.Point(599, 417);
            this.lblMessageToUsers.Name = "lblMessageToUsers";
            this.lblMessageToUsers.Size = new System.Drawing.Size(274, 13);
            this.lblMessageToUsers.TabIndex = 288;
            this.lblMessageToUsers.Text = "Search the Bill Description - Press F2 in Bill Code Column";
            // 
            // lblBillDate
            // 
            this.lblBillDate.AutoSize = true;
            this.lblBillDate.Location = new System.Drawing.Point(511, 542);
            this.lblBillDate.Name = "lblBillDate";
            this.lblBillDate.Size = new System.Drawing.Size(0, 13);
            this.lblBillDate.TabIndex = 289;
            this.lblBillDate.Visible = false;
            // 
            // frmBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 587);
            this.ControlBox = false;
            this.Controls.Add(this.lblBillDate);
            this.Controls.Add(this.lblMessageToUsers);
            this.Controls.Add(this.btnAddBill);
            this.Controls.Add(this.lblPaymentMode);
            this.Controls.Add(this.ddlBillMode);
            this.Controls.Add(this.lblMsgColor);
            this.Controls.Add(this.lblUserMsg);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblBillid);
            this.Controls.Add(this.lblPreviousBill);
            this.Controls.Add(this.lstPreviousBill);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvBill);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNetAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDiscountAmount);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblPatientNumber);
            this.Controls.Add(this.txtPatientNumber);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtGrossAmount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.tbCash);
            this.Controls.Add(this.tabCredit);
            this.Controls.Add(this.tabDD);
            this.Controls.Add(this.tabPayment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patient Bill";
            this.Load += new System.EventHandler(this.frmBill_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmBill_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).EndInit();
            this.strpGrid.ResumeLayout(false);
            this.tabPayment.ResumeLayout(false);
            this.tabCheque.ResumeLayout(false);
            this.tabCheque.PerformLayout();
            this.tabDemandDraft.ResumeLayout(false);
            this.tabDemandDraft.PerformLayout();
            this.tabCard.ResumeLayout(false);
            this.tabCard.PerformLayout();
            this.tabDD.ResumeLayout(false);
            this.tabCredit.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tpCash.ResumeLayout(false);
            this.tpCash.PerformLayout();
            this.tbCash.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtGrossAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblPatientNumber;
        private System.Windows.Forms.TextBox txtPatientNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiscountAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNetAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridView dgvBill;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.TabControl tabPayment;
        private System.Windows.Forms.TabPage tabCheque;
        private System.Windows.Forms.TabPage tabDemandDraft;
        private System.Windows.Forms.TabPage tabCard;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChequeBranchName;
        private System.Windows.Forms.TextBox txtChequeBankName;
        private System.Windows.Forms.TextBox txtChequeAmt;
        private System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.TextBox txtDDBranchName;
        private System.Windows.Forms.TextBox txtDDBankName;
        private System.Windows.Forms.TextBox txtDDAmt;
        private System.Windows.Forms.TextBox txtDDNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCardHolderName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCardAmt;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.MaskedTextBox txtChequeDate;
        private System.Windows.Forms.MaskedTextBox txtDDDate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ListBox lstPreviousBill;
        private System.Windows.Forms.Label lblPreviousBill;
        private System.Windows.Forms.Label lblBillid;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMsgColor;
        private System.Windows.Forms.Label lblUserMsg;
        internal System.Windows.Forms.HelpProvider ApplicationHelpProvider;
        private System.Windows.Forms.Label lblPaymentMode;
        private System.Windows.Forms.ComboBox ddlBillMode;
        private System.Windows.Forms.TabControl tabDD;
        private System.Windows.Forms.TabControl tabCredit;
        private System.Windows.Forms.Button btnAddBill;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.DateTimePicker dtpDateDD;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.MaskedTextBox txtCardNo;
        private System.Windows.Forms.TabPage tpCash;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtCashBillAmount;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtBalanceAmount;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtReceivedAmount;
        private System.Windows.Forms.TabControl tbCash;
        private System.Windows.Forms.Label lblCardType;
        private System.Windows.Forms.ComboBox ddlCardType;
        private System.Windows.Forms.ContextMenuStrip strpGrid;
        private System.Windows.Forms.ToolStripMenuItem ostrpDelete;
        private System.Windows.Forms.Label lblDDMonYY;
        private System.Windows.Forms.Label lblddMonYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillSNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillServiceTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillDescriptionID;
        private System.Windows.Forms.Label lblMessageToUsers;
        private System.Windows.Forms.Label lblBillDate;
    }
}
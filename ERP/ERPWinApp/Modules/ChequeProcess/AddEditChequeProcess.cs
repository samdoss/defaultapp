using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ERP.CommonLayer;
using ERP.DataLayer;

namespace ERPWinApp
{
	public partial class AddNewChequeProcess : Form
	{
		ScreenMode userMode;
		Variables _variables = new Variables();
		ApplicationConnection _appConnection = new ApplicationConnection();

		internal string helpFile = "\\Help\\HelpFile.chm";
        public int ChequeDepositID = 0;
		public eFormsState formsState;

		public AddNewChequeProcess()
		{
			InitializeComponent();
		}

		private void AddNewChequeProcess_Load(object sender, EventArgs e)
		{
			try
			{

				string sSelected = "--Select--";
                BankDetailDL bankObj = new BankDetailDL();
				// Fill Country
                ddlBankName.DataSource = bankObj.GetBankDetailsList().Tables[0];
                ddlBankName.DisplayMember = "BankAccountHolderName";
                ddlBankName.ValueMember = "BankDetailID";

                
                SupplierDL supplierService = new SupplierDL();
                cbSupplier.DataSource = supplierService.GetSupplierDropDownList(MDIForm.CompanyID).Tables[0];
                cbSupplier.DisplayMember = "SupplierCompanyName";
                cbSupplier.ValueMember = "SupplierId";

				Common.SetDialogCoordinate(this);


                if (ChequeDepositID != 0)
				{
					ShowSelectedChequeProcessData();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error :" + ex.Message);
			}
		}
        
		private void ShowSelectedChequeProcessData()
		{
            ChequeProcessDL cpRecord = new ChequeProcessDL(ChequeDepositID, MDIForm.CompanyID, true);
            dtpEntryDate.Value = cpRecord.EntryDate;
            dtpChequeProcessDate.Value = cpRecord.ChequeProcessDate;
            dtpChequeDepositDate.Value = cpRecord.ChequeDepositDate;

            if (cpRecord.SupplierID != null)
				cbSupplier.SelectedValue = cpRecord.SupplierID;

            txtChequeNo.Text = cpRecord.ChequeNo;
			txtChequeAmount.Text = cpRecord.ChequeAmount.ToString();
			txtComments.Text = cpRecord.Comments;
			
			if (cpRecord.BankAccountID != null)
				ddlBankName.SelectedValue = cpRecord.BankAccountID;

            cbChequeProcessed.Checked = cpRecord.IsChequeProcessed;
            cbChequeFails.Checked = cpRecord.IsChequeFails;

			btnReset.Visible = false;

			if (formsState == eFormsState.View)
			{
				DisableControls();
			}
		}

		private void DisableControls()
		{
			dtpEntryDate.Enabled = false;
			dtpChequeDepositDate.Enabled = false;
			dtpChequeProcessDate.Enabled = false;			
			txtChequeNo.Enabled = false;			
			txtChequeAmount.Enabled = false;
			btnSave.Enabled = false;
			ddlBankName.Enabled = false;
			txtComments.Enabled = false;
		}

		private void bnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
            if (!FormValidation()) { return; }
            ChequeProcessDL chequeProcess = new ChequeProcessDL();

			chequeProcess.CompanyID = MDIForm.CompanyID;
            if (ddlBankName.SelectedValue != null)
                chequeProcess.BankAccountID = Convert.ToInt32(ddlBankName.SelectedValue.ToString());

            if (cbSupplier.SelectedValue != null)
                chequeProcess.SupplierID = Convert.ToInt32(cbSupplier.SelectedValue.ToString());

            chequeProcess.EntryDate = dtpEntryDate.Value.Date;
            chequeProcess.ChequeDepositDate = dtpChequeDepositDate.Value.Date;
            chequeProcess.ChequeProcessDate = dtpChequeProcessDate.Value.Date;
			chequeProcess.ChequeNo = txtChequeNo.Text.Trim();
            chequeProcess.ChequeAmount = Convert.ToDecimal(txtChequeAmount.Text);

            chequeProcess.IsChequeProcessed = Convert.ToBoolean(cbChequeProcessed.Checked);
            chequeProcess.IsChequeFails = Convert.ToBoolean(cbChequeFails.Checked);

            chequeProcess.Comments = txtComments.Text.Trim();
			
			
			chequeProcess.AuditUserID = MDIForm.UserID;
			if (ChequeDepositID == 0)
			{
				chequeProcess.AddEditOption = 0;
				TransactionResult result = null;
				chequeProcess.ScreenMode = ScreenMode.Add;
                result = chequeProcess.Commit(ScreenMode.Add);
				//MessageBox.Show(_Result.Message, "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
				CustomMessageBox.Show(string.Format(Constants.SUCCESSFULL_ADD_MESSAGE, Constants.CONSTANT_ChequeProcess, txtChequeNo.Text),
											  Constants.CONSTANT_INFORMATION,
											  CustomMessageBox.eDialogButtons.OK,
											  CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Success));
				ResetControls();
			}
			else
			{
				chequeProcess.AddEditOption = 1;
                chequeProcess.ChequeDepositID = ChequeDepositID;
				TransactionResult result = null;
				chequeProcess.ScreenMode = ScreenMode.Edit;
                result = chequeProcess.Commit(ScreenMode.Edit);
				CustomMessageBox.Show(string.Format(Constants.SUCCESSFULL_SAVE_MESSAGE, txtChequeNo.Text),
                                                              Constants.CONSTANT_ChequeProcess,
															  CustomMessageBox.eDialogButtons.OK,
															  CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Success));
			}

			this.Close();
		}

        private bool FormValidation()
        {
            bool valid = true;
            if ((Convert.ToString(ddlBankName.SelectedIndex) == "0") || (Convert.ToString(ddlBankName.SelectedIndex) == "0"))
            {
                ddlBankName.Focus();
                MessageBox.Show("Please Select Bank.", Constants.CONSTANT_ChequeProcess, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                valid = false;
            }
            else if ((Convert.ToString(cbSupplier.SelectedIndex) == "0") || (Convert.ToString(cbSupplier.SelectedIndex) == "0"))
            {
                cbSupplier.Focus();
                MessageBox.Show("Please Select Supplier.", Constants.CONSTANT_ChequeProcess, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                valid = false;
            }
            else if ((Convert.ToString(txtChequeNo.Text) == null) || (Convert.ToString(txtChequeNo.Text) == ""))
            {
                txtChequeNo.Focus();
                MessageBox.Show("Please Enter Cheque No.", Constants.CONSTANT_ChequeProcess, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                valid = false;
            }
            else if ((Convert.ToString(txtChequeAmount.Text) == null) || (Convert.ToString(txtChequeAmount.Text) == ""))
            {
                txtChequeAmount.Focus();
                MessageBox.Show("Please Enter Cheque Amount.", Constants.CONSTANT_ChequeProcess, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                valid = false;
            }
           
            return valid;
        }
		private void ResetControls()
		{			
			txtChequeNo.Text = String.Empty;		
			txtChequeAmount.Text = String.Empty;

			ddlBankName.SelectedIndex = 0;
			cbSupplier.SelectedIndex = 0;

			txtComments.Text = String.Empty;			
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			ResetControls();
		}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }	
	}
}
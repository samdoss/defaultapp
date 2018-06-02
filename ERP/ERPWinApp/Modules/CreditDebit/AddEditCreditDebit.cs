using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ERP.CommonLayer;
using ERP.DataLayer;

namespace ERPWinApp
{
    public partial class AddEditCreditDebit : Form
    {
        ScreenMode userMode;
        Variables _variables = new Variables();
        ApplicationConnection _appConnection = new ApplicationConnection();

        internal string helpFile = "\\Help\\HelpFile.chm";
        public int CreditDebitID = 0;
        public eFormsState formsState;

        public AddEditCreditDebit()
        {
            InitializeComponent();
        }

        private void AddEditCreditDebit_Load(object sender, EventArgs e)
        {
            try
            {

                string sSelected = "--Select--";
                BankDetailDL bankObj = new BankDetailDL();
                // Fill Country
                ddlBankName.DataSource = bankObj.GetBankDetailsList().Tables[0];
                ddlBankName.DisplayMember = "BankAccountHolderName";
                ddlBankName.ValueMember = "BankDetailID";

                Common.SetDialogCoordinate(this);

                if (CreditDebitID != 0)
                {
                    ShowSelectedCreditDebitData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void ShowSelectedCreditDebitData()
        {
            BankCreditDebitDL cpRecord = new BankCreditDebitDL(CreditDebitID, MDIForm.CompanyID, true);
            dtpEntryDate.Value = cpRecord.DateProcessed;

            if (cpRecord.IsDebit)
                txtCreditDebitAmount.Text = cpRecord.DebitAmount.ToString();

            if (cpRecord.IsCredit)
                txtCreditDebitAmount.Text = cpRecord.CreditAmount.ToString();

            txtComments.Text = cpRecord.Description;

            if (cpRecord.BankDetailID != null)
                ddlBankName.SelectedValue = cpRecord.BankDetailID;

            rbDebit.Checked = cpRecord.IsDebit;
            rbCredit.Checked = cpRecord.IsCredit;

            btnReset.Visible = false;

            if (formsState == eFormsState.View)
            {
                DisableControls();
            }
        }

        private void DisableControls()
        {
            dtpEntryDate.Enabled = false;

            txtCreditDebitAmount.Enabled = false;
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
            BankCreditDebitDL CreditDebit = new BankCreditDebitDL();

            CreditDebit.CompanyID = MDIForm.CompanyID;
            if (ddlBankName.SelectedValue != null)
                CreditDebit.BankDetailID = Convert.ToInt32(ddlBankName.SelectedValue.ToString());

            CreditDebit.DateProcessed = dtpEntryDate.Value.Date;

            if (rbCredit.Checked)
                CreditDebit.CreditAmount = Convert.ToDecimal(txtCreditDebitAmount.Text);
            else
                CreditDebit.CreditAmount = 0;

            if (rbDebit.Checked)
                CreditDebit.DebitAmount = Convert.ToDecimal(txtCreditDebitAmount.Text);
            else
                CreditDebit.DebitAmount = 0;

            CreditDebit.IsCredit = Convert.ToBoolean(rbCredit.Checked);
            CreditDebit.IsDebit = Convert.ToBoolean(rbDebit.Checked);

            CreditDebit.Description = txtComments.Text.Trim();


            CreditDebit.AuditUserID = MDIForm.UserID;
            if (CreditDebitID == 0)
            {
                CreditDebit.AddEditOption = 0;
                TransactionResult result = null;
                CreditDebit.ScreenMode = ScreenMode.Add;
                result = CreditDebit.Commit(ScreenMode.Add);
                //MessageBox.Show(_Result.Message, "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                CustomMessageBox.Show(string.Format(Constants.SUCCESSFULL_ADD_MESSAGE, Constants.CONSTANT_CreditDebit, txtCreditDebitAmount.Text),
                                              Constants.CONSTANT_INFORMATION,
                                              CustomMessageBox.eDialogButtons.OK,
                                              CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Success));
                ResetControls();
            }
            else
            {
                CreditDebit.AddEditOption = 1;
                CreditDebit.BankCreditDebitID = CreditDebitID;
                TransactionResult result = null;
                CreditDebit.ScreenMode = ScreenMode.Edit;
                result = CreditDebit.Commit(ScreenMode.Edit);
                CustomMessageBox.Show(string.Format(Constants.SUCCESSFULL_SAVE_MESSAGE, txtCreditDebitAmount.Text),
                                                              Constants.CONSTANT_CreditDebit,
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
                MessageBox.Show("Please Select Bank.", Constants.CONSTANT_CreditDebit, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                valid = false;
            }
            else if (string.IsNullOrEmpty(txtCreditDebitAmount.Text))
            {
                txtCreditDebitAmount.Focus();
                MessageBox.Show("Please Enter Amount.", Constants.CONSTANT_CreditDebit, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                valid = false;
            }
            
            return valid;
        }
        private void ResetControls()
        {
            txtCreditDebitAmount.Text = String.Empty;
            ddlBankName.SelectedIndex = 0;
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

        private void txtCreditDebitAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            //{
            //    if (!char.IsDigit(e.KeyChar)) 
            //        e.Handled = true;         //Just Digits
            //    if (e.KeyChar == (char)8) 
            //        e.Handled = false;            //Allow Backspace
            //    if (e.KeyChar == (char)13)
            //    { 
            //    }
            //        //Allow Enter            
            //}
        }
    }
}
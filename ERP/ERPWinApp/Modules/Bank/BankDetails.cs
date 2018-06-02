using ERP.CommonLayer;
using ERP.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPWinApp
{
    public partial class BankDetails : Form
    {
        public BankDetails()
        {
            InitializeComponent();
        }
        ScreenMode userMode;
        BankDetailDL _bankObj = new BankDetailDL();
        public int SearchID { get; set; }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!FormValidation()) { return; }

            _bankObj.BankDetailID = Convert.ToInt32(lblBankDetailID.Text);
            _bankObj.BankAccountHolderName = txtAccountHolderName.Text;
            _bankObj.BankAccountNumber = txtAccountNumber.Text;
            _bankObj.BankName = txtBankName.Text;
            _bankObj.BranchName = txtBranchName.Text;
            _bankObj.IFSCCode = txtIfscCode.Text;

            TransactionResult result;
            if ((lblBankDetailID.Text != null) && (lblBankDetailID.Text == "0"))
                userMode = ScreenMode.Add;
            else
                userMode = ScreenMode.Edit;
            result = _bankObj.Commit(userMode);
            MessageBox.Show(result.Message.ToString(), "Check Process", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool FormValidation()
        {
            bool valid = true;
            if (txtAccountHolderName.Text.Trim() == "" || txtAccountHolderName.Text.Length < 2)
            {
                MessageBox.Show("Please Enter Valid Account Holder Name.", "Check Process", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                valid = false;
                txtAccountHolderName.Focus();
            }           
            
            return valid;
        }

        private void BankDetails_Load(object sender, EventArgs e)
        {
            lblBankDetailID.Text = SearchID.ToString();

            if (SearchID != 0)
                ViewBankDetailsData();
            else
                ClearForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                frmFindBankDetails frmFinder = new frmFindBankDetails();
                frmFinder.SearchText = txtAccountHolderName.Text;
                frmFinder.ShowDialog();
                userMode = ScreenMode.View;
                SearchID = frmFinder.fSearchID;
                lblBankDetailID.Text = Convert.ToString(frmFinder.fSearchID);
                if (lblBankDetailID.Text != "0")
                {
                    txtAccountHolderName.Text = frmFinder.SearchText;
                    txtAccountHolderName_Leave(sender, e);
                    txtAccountHolderName.Focus();
                }
                else
                {
                    ClearForm();
                }
            }
            catch { }
        }

        private void txtAccountHolderName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (userMode == ScreenMode.View)
                {
                    if (lblBankDetailID.Text.ToString() != "" && lblBankDetailID.Text.ToString() != "0")
                    {
                        bool dataExist = ViewBankDetailsData();
                        userMode = ScreenMode.Edit;
                        lblBankDetailID.Visible = true;
                        
                    }
                }
                if (userMode == ScreenMode.Add)
                {
                    lblBankDetailID.Visible = true;
                }
            }
            catch { }
        }

        private bool ViewBankDetailsData()
        {
            bool dataExist = false;
            try
            {
                userMode = ScreenMode.View;
                //ClearForm();
                BankDetailDL _bankDetail = new BankDetailDL(SearchID, true);
                txtAccountHolderName.Text = _bankDetail.BankAccountHolderName;
                txtAccountNumber.Text = _bankDetail.BankAccountNumber;
                txtBankName.Text = _bankDetail.BankName;
                txtIfscCode.Text = _bankDetail.IFSCCode;
                txtBranchName.Text = _bankDetail.BranchName;
                lblBankDetailID.Text = _bankDetail.BankDetailID.ToString();         
                dataExist = true;
                return dataExist;
            }
            catch { }
            return dataExist;
        }

        private void ClearForm()
        {
            txtAccountHolderName.Text = "";
            txtAccountNumber.Text = "";
            txtBankName.Text = "";
            txtBranchName.Text = "";
            txtIfscCode.Text = "";
            lblBankDetailID.Text = "0";
            txtAccountHolderName.Focus();
            userMode = ScreenMode.Add;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}

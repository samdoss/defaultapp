using ERP.CommonLayer;
using ERP.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERPWinApp
{
    public partial class CreditDebitReport : Form
    {
		private BankCreditDebitDL CreditDebitService = new BankCreditDebitDL();
        int rowIndex = 0;
        int currentPage = 1;
        int TotalPage = 0;

        public CreditDebitReport()
        {
            InitializeComponent();
        }

        private void CreditDebitReport_Load(object sender, EventArgs e)
        {
            Common.SetFormCoordinate(this);
            BindCreditDebitReportsDataGrid();
            BindSupplierDropDownName();
        }

        private void BindSupplierDropDownName()
        {
            string sSelected = "--Select--";
            BankDetailDL bankService = new BankDetailDL();
            cmbBankDetails.DataSource = bankService.GetBankDetailsList().Tables[0];
            cmbBankDetails.DisplayMember = "BankAccountHolderName";
            cmbBankDetails.ValueMember = "BankDetailID";
            //cmbCreditDebitName.Items.Add(sSelected);
            //cmbCreditDebitName.SelectedIndex = 0;
        }

        private void BindCreditDebitReportsDataGrid()
        {
            int resultsPerPage = Convert.ToInt32(txtResultsPerPage.Text);
            List<BankCreditDebitDL> creditDebitList = CreditDebitService.GetAllBankCreditDebitList(MDIForm.CompanyID);
            int CreditDebitId = Convert.ToInt32(cmbBankDetails.SelectedValue);

            if (CreditDebitId != 0)
                creditDebitList = (from CreditDebit in creditDebitList
                                 .Where(v => v.BankCreditDebitID == CreditDebitId)
                                   select CreditDebit).ToList<BankCreditDebitDL>();

            //if (!String.IsNullOrEmpty(txtChequeNo.Text))
            //    CreditDebitList = (from CreditDebit in CreditDebitList
            //                     .Where(v => v.IsCredit.StartsWith(txtChequeNo.Text, StringComparison.OrdinalIgnoreCase))
            //                       select CreditDebit).ToList<BankCreditDebitDL>();

            if (!String.IsNullOrEmpty(txDepositDate.Text))
                creditDebitList = (from CreditDebit in creditDebitList
                                 .Where(v => v.DateProcessed.ToString().StartsWith(txDepositDate.Text, StringComparison.OrdinalIgnoreCase))
                                   select CreditDebit).ToList<BankCreditDebitDL>();

            decimal creditSum = (from CreditDebit in creditDebitList
                                      select CreditDebit.CreditAmount).Sum();

            lblTotalCreditAmount.Text = creditSum.ToString();

            decimal debitSum = (from CreditDebit in creditDebitList
                                      select CreditDebit.DebitAmount).Sum();

            lblTotalDebitAmount.Text = debitSum.ToString();

            int totalRecords = creditDebitList.Count;
            CalculateTotalPages(totalRecords);

            if (creditDebitList.Count != 0)
            {

                int srNo = 0;
                var columns = from CreditDebit in creditDebitList
                              select new
                              {
                                  No = ++srNo,
                                  BankCreditDebitID = CreditDebit.BankCreditDebitID,
                                  Description = CreditDebit.Description,
                                  DateProcessed = CreditDebit.DateProcessed,
                                  CreditAmount = CreditDebit.CreditAmount,
                                  DebitAmount = CreditDebit.DebitAmount                                  
                              };                
                if (currentPage == 1)
                {
                    this.dgvCreditDebitResult.DataSource = columns.Take(resultsPerPage).ToList();
                }
                else
                {
                    int skipRecordsNo = resultsPerPage * (currentPage - 1);
                    this.dgvCreditDebitResult.DataSource = columns.Skip(skipRecordsNo).Take(resultsPerPage).ToList();
                }
            }
            if (currentPage <= TotalPage)
            {
                txtPageEnd.Visible = true;
                txtPageStart.Visible = true;
                btnLeft.Visible = true;
                btnRight.Visible = true;
                lblSeperator.Visible = true;
                txtPageStart.Text = Convert.ToString(currentPage);
                txtPageEnd.Text = Convert.ToString(TotalPage);
                txtPageEnd.Enabled = false;

                if (currentPage == 1)
                {
                    btnLeft.Enabled = false;
                    btnRight.Enabled = true;
                }
                else if (currentPage == TotalPage)
                {
                    btnRight.Enabled = false;
                    btnLeft.Enabled = true;
                }
                else
                {
                    btnLeft.Enabled = true;
                    btnRight.Enabled = true;
                }

                if (TotalPage == 1)
                {
                    txtPageEnd.Visible = false; ;
                    txtPageStart.Visible = false;
                    btnLeft.Visible = false;
                    btnRight.Visible = false;
                    lblSeperator.Visible = false;
                }
            }
        }

        private void btnNewCreditDebit_Click(object sender, EventArgs e)
        {
            AddEditCreditDebit objCreditDebit = new AddEditCreditDebit();
            objCreditDebit.StartPosition = FormStartPosition.CenterScreen;
            objCreditDebit.ShowDialog(this);
            BindCreditDebitReportsDataGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvCreditDebitResult.SelectedRows[rowIndex];
            int CreditDebitID = Convert.ToInt32(row.Cells["BankCreditDebitID"].Value);
            AddEditCreditDebit objCreditDebit = new AddEditCreditDebit();
            objCreditDebit.CreditDebitID = CreditDebitID;
            objCreditDebit.formsState = eFormsState.Edit;
            objCreditDebit.ShowDialog(this);
            BindCreditDebitReportsDataGrid();
        }

        private void dgvCreditDebitResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvCreditDebitResult.SelectedRows[rowIndex];
            int CreditDebitID = Convert.ToInt32(row.Cells["BankCreditDebitID"].Value);
            AddEditCreditDebit objCreditDebit = new AddEditCreditDebit();
            objCreditDebit.CreditDebitID = CreditDebitID;
            objCreditDebit.formsState = eFormsState.View;
            objCreditDebit.ShowDialog(this);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvCreditDebitResult.SelectedRows[rowIndex];
            int CreditDebitID = Convert.ToInt32(row.Cells["BankCreditDebitID"].Value);
            DialogResult dialogRes = CustomMessageBox.Show(Constants.DELETE_WARNING,
                                  Constants.CONSTANT_INFORMATION,
                                  CustomMessageBox.eDialogButtons.YesNo,
                                  CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Information));

            if (dialogRes == System.Windows.Forms.DialogResult.Yes)
            {
                CreditDebitService.BankCreditDebitID = CreditDebitID;
                TransactionResult result = null;
                CreditDebitService.ScreenMode = ScreenMode.Delete;
                result = CreditDebitService.Commit(ScreenMode.Delete);
                CustomMessageBox.Show(string.Format(Constants.DELETE_WARNING, Constants.CONSTANT_CreditDebit, CreditDebitID),
                                              Constants.CONSTANT_INFORMATION,
                                              CustomMessageBox.eDialogButtons.OK,
                                              CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Success));

            }

            BindCreditDebitReportsDataGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindCreditDebitReportsDataGrid();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbBankDetails.SelectedIndex = 0;
            txtChequeNo.Text = String.Empty;
            txDepositDate.Text = String.Empty;            
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            BindCreditDebitReportsDataGrid();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (currentPage < TotalPage)
                currentPage++;

            BindCreditDebitReportsDataGrid();
        }

        private void CalculateTotalPages(int rowCount)
        {
            int pageSize = Convert.ToInt32(txtResultsPerPage.Text);
            TotalPage = rowCount / pageSize;

            if (rowCount % pageSize > 0)
                TotalPage += 1;
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
                currentPage--;

            BindCreditDebitReportsDataGrid();
        }    
    }
}

using ERP.CommonLayer;
using ERP.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERPWinApp
{
    public partial class ChequeProcessReport : Form
    {
		private ChequeProcessDL chequeProcessService = new ChequeProcessDL();
        int rowIndex = 0;
        int currentPage = 1;
        int TotalPage = 0;

        public ChequeProcessReport()
        {
            InitializeComponent();
        }

        private void ChequeProcessReport_Load(object sender, EventArgs e)
        {
            Common.SetFormCoordinate(this);
            BindChequeProcessReportsDataGrid();
            BindSupplierDropDownName();
        }

        private void BindSupplierDropDownName()
        {
            string sSelected = "--Select--";
            SupplierDL supplierService = new SupplierDL();
            cmbSupplierName.DataSource = supplierService.GetSupplierDropDownList(MDIForm.CompanyID).Tables[0]; 
            cmbSupplierName.DisplayMember = "SupplierName";
            cmbSupplierName.ValueMember = "SupplierId";
            //cmbChequeProcessName.Items.Add(sSelected);
            //cmbChequeProcessName.SelectedIndex = 0;
        }

        private void BindChequeProcessReportsDataGrid()
        {
            int resultsPerPage = Convert.ToInt32(txtResultsPerPage.Text);
            List<ChequeProcessDL> ChequeProcessList = chequeProcessService.GetAllChequeDepositList(MDIForm.CompanyID);
            int ChequeProcessId = Convert.ToInt32(cmbSupplierName.SelectedValue);

            if (ChequeProcessId != 0)
                ChequeProcessList = (from ChequeProcess in ChequeProcessList
                                 .Where(v => v.ChequeDepositID == ChequeProcessId)
                              select ChequeProcess).ToList<ChequeProcessDL>();

            if (!String.IsNullOrEmpty(txtChequeNo.Text))
                ChequeProcessList = (from ChequeProcess in ChequeProcessList
                                 .Where(v => v.ChequeNo.StartsWith(txtChequeNo.Text, StringComparison.OrdinalIgnoreCase))
                              select ChequeProcess).ToList<ChequeProcessDL>();

            if (!String.IsNullOrEmpty(txEntryDate.Text))
                ChequeProcessList = (from ChequeProcess in ChequeProcessList
                                 .Where(v => v.EntryDate.ToString().StartsWith(txEntryDate.Text, StringComparison.OrdinalIgnoreCase))
                              select ChequeProcess).ToList<ChequeProcessDL>();

            
            int totalRecords = ChequeProcessList.Count;
            CalculateTotalPages(totalRecords);
            int srNo = 0;
            var columns = from ChequeProcess in ChequeProcessList
                          select new
                          {
                              No = ++srNo,
                              ChequeDepositID = ChequeProcess.ChequeDepositID,
                              SupplierName = ChequeProcess.SupplierCompanyName,
                              EntryDate = ChequeProcess.EntryDate,
                              ChequeDepositeDate = ChequeProcess.ChequeDepositDate,
                              ChequeNo = ChequeProcess.ChequeNo,
                              ChequeAmount = ChequeProcess.ChequeAmount,
                              ChequeProcessDate = ChequeProcess.ChequeProcessDate,
                              IsChequeProcessed = ChequeProcess.IsChequeProcessed,
                              IsChequeFails = ChequeProcess.IsChequeFails,
                              BankAccountName = ChequeProcess.BankAccountName
                          };
            if (currentPage == 1)
            {
                this.dgvChequeProcessResult.DataSource = columns.Take(resultsPerPage).ToList();
            }
            else
            {
                int skipRecordsNo = resultsPerPage * (currentPage - 1);
                this.dgvChequeProcessResult.DataSource = columns.Skip(skipRecordsNo).Take(resultsPerPage).ToList();
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

        private void btnNewChequeProcess_Click(object sender, EventArgs e)
        {
            AddNewChequeProcess addNewChequeProcess = new AddNewChequeProcess();
            addNewChequeProcess.StartPosition = FormStartPosition.CenterParent;
            addNewChequeProcess.ShowDialog(this);
            BindChequeProcessReportsDataGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvChequeProcessResult.SelectedRows[rowIndex];
            int ChequeDepositID = Convert.ToInt32(row.Cells["ChequeDepositID"].Value);
            AddNewChequeProcess addNewChequeProcess = new AddNewChequeProcess();
            addNewChequeProcess.ChequeDepositID = ChequeDepositID;
            addNewChequeProcess.formsState = eFormsState.Edit;
            addNewChequeProcess.ShowDialog(this);
            BindChequeProcessReportsDataGrid();
        }

        private void dgvChequeProcessResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvChequeProcessResult.SelectedRows[rowIndex];
            int ChequeDepositID = Convert.ToInt32(row.Cells["ChequeDepositID"].Value);
            AddNewChequeProcess addNewChequeProcess = new AddNewChequeProcess();
            addNewChequeProcess.ChequeDepositID = ChequeDepositID;
            addNewChequeProcess.formsState = eFormsState.View;
            addNewChequeProcess.ShowDialog(this);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvChequeProcessResult.SelectedRows[rowIndex];
            int ChequeDepositID = Convert.ToInt32(row.Cells["ChequeDepositID"].Value);
            DialogResult dialogRes = CustomMessageBox.Show(Constants.DELETE_WARNING,
                                  Constants.CONSTANT_INFORMATION,
                                  CustomMessageBox.eDialogButtons.YesNo,
                                  CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Information));

            if (dialogRes == System.Windows.Forms.DialogResult.Yes)
            {
                chequeProcessService.ChequeDepositID = ChequeDepositID;
                TransactionResult result = null;
                chequeProcessService.ScreenMode = ScreenMode.Delete;
                result = chequeProcessService.Commit(ScreenMode.Delete);
                CustomMessageBox.Show(string.Format(Constants.DELETE_WARNING, Constants.CONSTANT_ChequeProcess, ChequeDepositID),
                                              Constants.CONSTANT_INFORMATION,
                                              CustomMessageBox.eDialogButtons.OK,
                                              CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Success));

            }

            BindChequeProcessReportsDataGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindChequeProcessReportsDataGrid();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbSupplierName.SelectedIndex = 0;
            txtChequeNo.Text = String.Empty;
            txEntryDate.Text = String.Empty;            
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            BindChequeProcessReportsDataGrid();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (currentPage < TotalPage)
                currentPage++;

            BindChequeProcessReportsDataGrid();
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

            BindChequeProcessReportsDataGrid();
        }

        private void btnViewVisual_Click(object sender, EventArgs e)
        {
        
        }
    }
}

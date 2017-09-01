using ERP.CommonLayer;
using ERP.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERPWinApp
{
    public partial class SuppliersReport : Form
    {
		private SupplierDL SupplierService = new SupplierDL();
        int rowIndex = 0;
        int currentPage = 1;
        int TotalPage = 0;

        public SuppliersReport()
        {
            InitializeComponent();
        }

        private void SuppliersReport_Load(object sender, EventArgs e)
        {
            Common.SetFormCoordinate(this);
            BindSupplierReportsDataGrid();
            BindSupplierName();
        }

        private void BindSupplierName()
        {
            string sSelected = "--Select--";
			SupplierService = new SupplierDL();
			cmbSupplierName.DataSource = SupplierService.GetSupplierDropDownList(MDIForm.CompanyID).Tables[0]; 
            cmbSupplierName.DisplayMember = "SupplierName";
            cmbSupplierName.ValueMember = "SupplierId";
            //cmbSupplierName.Items.Add(sSelected);
            //cmbSupplierName.SelectedIndex = 0;
        }

        private void BindSupplierReportsDataGrid()
        {
            int resultsPerPage = Convert.ToInt32(txtResultsPerPage.Text);
            List<SupplierDL> SupplierList = SupplierService.GetAllSupplierList(MDIForm.CompanyID);
            int SupplierId = Convert.ToInt32(cmbSupplierName.SelectedValue);

            if (SupplierId != 0)
                SupplierList = (from Supplier in SupplierList
                                 .Where(v => v.SupplierID == SupplierId)
                              select Supplier).ToList<SupplierDL>();

            if (!String.IsNullOrEmpty(txtContactName.Text))
                SupplierList = (from Supplier in SupplierList
                                 .Where(v => v.SupplierCompanyName.StartsWith(txtContactName.Text, StringComparison.OrdinalIgnoreCase))
                              select Supplier).ToList<SupplierDL>();

            if (!String.IsNullOrEmpty(txtEmail.Text))
                SupplierList = (from Supplier in SupplierList
                                 .Where(v => v.WorkEmail.StartsWith(txtEmail.Text, StringComparison.OrdinalIgnoreCase))
                              select Supplier).ToList<SupplierDL>();

            if (!String.IsNullOrEmpty(txtPhone.Text))
                SupplierList = (from Supplier in SupplierList
                                 .Where(v => v.WorkPhone.StartsWith(txtPhone.Text, StringComparison.OrdinalIgnoreCase))
                              select Supplier).ToList<SupplierDL>();

            int totalRecords = SupplierList.Count;
            CalculateTotalPages(totalRecords);
            int srNo = 0;
            var columns = from Supplier in SupplierList
                          select new
                          {
                              No = ++srNo,
                              SupplierId = Supplier.SupplierID,
                              SupplierName = Supplier.SupplierCompanyName,
                              ContactName = Supplier.SupplierName,
                              BillingAddress = Supplier.Address1,
                              Email = Supplier.WorkEmail,
                              Phone = Supplier.WorkPhone,
                              PrivateSupplierDetails = Supplier.SalesPersonName
                          };
            if (currentPage == 1)
            {
                this.dgvSupplierResult.DataSource = columns.Take(resultsPerPage).ToList();
            }
            else
            {
                int skipRecordsNo = resultsPerPage * (currentPage - 1);
                this.dgvSupplierResult.DataSource = columns.Skip(skipRecordsNo).Take(resultsPerPage).ToList();
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

        private void btnNewSupplier_Click(object sender, EventArgs e)
        {
            AddNewSupplier addNewSupplier = new AddNewSupplier();
            addNewSupplier.StartPosition = FormStartPosition.CenterParent;
            addNewSupplier.ShowDialog(this);
            BindSupplierReportsDataGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvSupplierResult.Rows[rowIndex];
            int SupplierId = Convert.ToInt32(row.Cells["SupplierId"].Value);
            AddNewSupplier addNewSupplier = new AddNewSupplier();
            addNewSupplier.SupplierID = SupplierId;
            addNewSupplier.formsState = eFormsState.Edit;
            addNewSupplier.ShowDialog(this);
            BindSupplierReportsDataGrid();
        }

        private void dgvSupplierResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvSupplierResult.Rows[rowIndex];
            int SupplierId = Convert.ToInt32(row.Cells["SupplierId"].Value);
            AddNewSupplier addNewSupplier = new AddNewSupplier();
            addNewSupplier.SupplierID = SupplierId;
            addNewSupplier.formsState = eFormsState.View;
            addNewSupplier.ShowDialog(this);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvSupplierResult.Rows[rowIndex];
            int SupplierId = Convert.ToInt32(row.Cells["SupplierId"].Value);
            DialogResult dialogRes = CustomMessageBox.Show(Constants.DELETE_WARNING,
                                  Constants.CONSTANT_INFORMATION,
                                  CustomMessageBox.eDialogButtons.YesNo,
                                  CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Information));

            if (dialogRes == System.Windows.Forms.DialogResult.Yes)
            {
                SupplierService.SupplierID = SupplierId;
                TransactionResult result = null;
                SupplierService.ScreenMode = ScreenMode.Delete;
                result = SupplierService.Commit();
                CustomMessageBox.Show(string.Format(Constants.DELETE_WARNING, Constants.CONSTANT_SUPPLIER, SupplierId),
                                              Constants.CONSTANT_INFORMATION,
                                              CustomMessageBox.eDialogButtons.OK,
                                              CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Success));

            }

            BindSupplierReportsDataGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindSupplierReportsDataGrid();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbSupplierName.SelectedIndex = 0;
            txtContactName.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtPhone.Text = String.Empty;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            BindSupplierReportsDataGrid();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (currentPage < TotalPage)
                currentPage++;

            BindSupplierReportsDataGrid();
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

            BindSupplierReportsDataGrid();
        }
    }
}

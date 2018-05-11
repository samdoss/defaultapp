using ERP.CommonLayer;
using ERP.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ERPWinApp
{
    public partial class EmployeesReport : Form
    {
		private EmployeeDL EmployeeService = new EmployeeDL();
        int rowIndex = 0;
        int currentPage = 1;
        int TotalPage = 0;

        public EmployeesReport()
        {
            InitializeComponent();
        }

        private void EmployeesReport_Load(object sender, EventArgs e)
        {
            Common.SetFormCoordinate(this);
            BindEmployeeReportsDataGrid();
            BindEmployeeName();
        }

        private void BindEmployeeName()
        {
            string sSelected = "--Select--";
			EmployeeService = new EmployeeDL();
			cmbEmployeeName.DataSource = EmployeeService.GetEmployeeDropDownList(MDIForm.CompanyID).Tables[0]; 
            cmbEmployeeName.DisplayMember = "EmployeeName";
            cmbEmployeeName.ValueMember = "EmployeeId";
            //cmbEmployeeName.Items.Add(sSelected);
            //cmbEmployeeName.SelectedIndex = 0;
        }

        private void BindEmployeeReportsDataGrid()
        {
            int resultsPerPage = Convert.ToInt32(txtResultsPerPage.Text);
            List<EmployeeDL> EmployeeList = EmployeeService.GetAllEmployeeList(MDIForm.CompanyID);
            int EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue);

            if (EmployeeId != 0)
                EmployeeList = (from Employee in EmployeeList
                                 .Where(v => v.EmployeeID == EmployeeId)
                              select Employee).ToList<EmployeeDL>();

            if (!String.IsNullOrEmpty(txtContactName.Text))
                EmployeeList = (from Employee in EmployeeList
                                 .Where(v => v.EmployeeCompanyName.StartsWith(txtContactName.Text, StringComparison.OrdinalIgnoreCase))
                              select Employee).ToList<EmployeeDL>();

            if (!String.IsNullOrEmpty(txtEmail.Text))
                EmployeeList = (from Employee in EmployeeList
                                 .Where(v => v.WorkEmail.StartsWith(txtEmail.Text, StringComparison.OrdinalIgnoreCase))
                              select Employee).ToList<EmployeeDL>();

            if (!String.IsNullOrEmpty(txtPhone.Text))
                EmployeeList = (from Employee in EmployeeList
                                 .Where(v => v.WorkPhone.StartsWith(txtPhone.Text, StringComparison.OrdinalIgnoreCase))
                              select Employee).ToList<EmployeeDL>();

            int totalRecords = EmployeeList.Count;
            CalculateTotalPages(totalRecords);
            int srNo = 0;
            var columns = from Employee in EmployeeList
                          select new
                          {
                              No = ++srNo,
                              EmployeeId = Employee.EmployeeID,
                              EmployeeName = Employee.EmployeeCompanyName,
                              ContactName = Employee.EmployeeName,
                              BillingAddress = Employee.Address1,
                              Email = Employee.WorkEmail,
                              Phone = Employee.WorkPhone,
                              PrivateEmployeeDetails = Employee.SalesPersonName
                          };
            if (currentPage == 1)
            {
                this.dgvEmployeeResult.DataSource = columns.Take(resultsPerPage).ToList();
            }
            else
            {
                int skipRecordsNo = resultsPerPage * (currentPage - 1);
                this.dgvEmployeeResult.DataSource = columns.Skip(skipRecordsNo).Take(resultsPerPage).ToList();
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

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            AddNewEmployee addNewEmployee = new AddNewEmployee();
            addNewEmployee.StartPosition = FormStartPosition.CenterParent;
            addNewEmployee.ShowDialog(this);
            BindEmployeeReportsDataGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvEmployeeResult.Rows[rowIndex];
            int EmployeeId = Convert.ToInt32(row.Cells["EmployeeId"].Value);
            AddNewEmployee addNewEmployee = new AddNewEmployee();
            addNewEmployee.EmployeeID = EmployeeId;
            addNewEmployee.formsState = eFormsState.Edit;
            addNewEmployee.ShowDialog(this);
            BindEmployeeReportsDataGrid();
        }

        private void dgvEmployeeResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvEmployeeResult.Rows[rowIndex];
            int EmployeeId = Convert.ToInt32(row.Cells["EmployeeId"].Value);
            AddNewEmployee addNewEmployee = new AddNewEmployee();
            addNewEmployee.EmployeeID = EmployeeId;
            addNewEmployee.formsState = eFormsState.View;
            addNewEmployee.ShowDialog(this);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvEmployeeResult.Rows[rowIndex];
            int EmployeeId = Convert.ToInt32(row.Cells["EmployeeId"].Value);
            DialogResult dialogRes = CustomMessageBox.Show(Constants.DELETE_WARNING,
                                  Constants.CONSTANT_INFORMATION,
                                  CustomMessageBox.eDialogButtons.YesNo,
                                  CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Information));

            if (dialogRes == System.Windows.Forms.DialogResult.Yes)
            {
                EmployeeService.EmployeeID = EmployeeId;
                TransactionResult result = null;
                EmployeeService.ScreenMode = ScreenMode.Delete;
                result = EmployeeService.Commit();
                CustomMessageBox.Show(string.Format(Constants.DELETE_WARNING, Constants.CONSTANT_Employee, EmployeeId),
                                              Constants.CONSTANT_INFORMATION,
                                              CustomMessageBox.eDialogButtons.OK,
                                              CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Success));

            }

            BindEmployeeReportsDataGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindEmployeeReportsDataGrid();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbEmployeeName.SelectedIndex = 0;
            txtContactName.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtPhone.Text = String.Empty;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            BindEmployeeReportsDataGrid();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (currentPage < TotalPage)
                currentPage++;

            BindEmployeeReportsDataGrid();
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

            BindEmployeeReportsDataGrid();
        }
    }
}

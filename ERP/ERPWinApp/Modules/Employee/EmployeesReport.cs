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
            cmbEmployeeName.ValueMember = "EmployeeID";
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

            if (!String.IsNullOrEmpty(txtEmployeeCode.Text))
                EmployeeList = (from Employee in EmployeeList
                                 .Where(v => v.EmployeeCode.StartsWith(txtEmployeeCode.Text, StringComparison.OrdinalIgnoreCase))
                              select Employee).ToList<EmployeeDL>();

            if (!String.IsNullOrEmpty(txtBankAccountNumber.Text))
                EmployeeList = (from Employee in EmployeeList
                                 .Where(v => v.BankAccountNumber.StartsWith(txtBankAccountNumber.Text, StringComparison.OrdinalIgnoreCase))
                              select Employee).ToList<EmployeeDL>();

            if (!String.IsNullOrEmpty(txtPhone.Text))
                EmployeeList = (from Employee in EmployeeList
                                 .Where(v => v.MobilePhone.StartsWith(txtPhone.Text, StringComparison.OrdinalIgnoreCase))
                              select Employee).ToList<EmployeeDL>();

            int totalRecords = EmployeeList.Count;
            CalculateTotalPages(totalRecords);
            int srNo = 0;
            var columns = from Employee in EmployeeList
                          select new
                          {
                              No = ++srNo,
                              EmployeeId = Employee.EmployeeID,
                              EmployeeName = Employee.EmployeeName,
                              EmployeeCode = Employee.EmployeeCode,
                              MobileNumber = Employee.MobilePhone,
                              DateOfBirth = Employee.DateOfBirth,
                              Address = Employee.Address1,
                              BankAccountNo = Employee.BankAccountNumber
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
            DataGridViewRow row = dgvEmployeeResult.SelectedRows[rowIndex];
            int EmployeeId = Convert.ToInt32(row.Cells["EmployeeID"].Value);
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
            DataGridViewRow row = dgvEmployeeResult.SelectedRows[rowIndex];
            int EmployeeId = Convert.ToInt32(row.Cells["EmployeeID"].Value);
            AddNewEmployee addNewEmployee = new AddNewEmployee();
            addNewEmployee.EmployeeID = EmployeeId;
            addNewEmployee.formsState = eFormsState.View;
            addNewEmployee.ShowDialog(this);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvEmployeeResult.SelectedRows[rowIndex];
            int EmployeeId = Convert.ToInt32(row.Cells["EmployeeID"].Value);
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
            txtEmployeeCode.Text = String.Empty;
            txtBankAccountNumber.Text = String.Empty;
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

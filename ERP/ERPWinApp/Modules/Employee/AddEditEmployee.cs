using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ERP.CommonLayer;
using ERP.DataLayer;

namespace ERPWinApp
{
	public partial class AddNewEmployee : Form
	{
		ScreenMode userMode;
		Variables _variables = new Variables();
		ApplicationConnection _appConnection = new ApplicationConnection();

		internal string helpFile = "\\Help\\HelpFile.chm";
		public int EmployeeID = 0;
		public eFormsState formsState;

		public AddNewEmployee()
		{
			InitializeComponent();
		}

		private void AddNewEmployee_Load(object sender, EventArgs e)
		{
			try
			{

				string sSelected = "--Select--";

				// Fill Country
				ddlCountry.DataSource = CommonDL.GetCountry(_appConnection).Tables[0];
				ddlCountry.DisplayMember = "Country";
				ddlCountry.ValueMember = "CountryID";

				ddlState.Items.Add(sSelected);
				ddlState.SelectedIndex = 0;
				ddlCity.Items.Add(sSelected);
				ddlCity.SelectedIndex = 0;

				// Fill Country
				ddlBankName.DataSource = CommonDL.GetBank(_appConnection).Tables[0];
				ddlBankName.DisplayMember = "BankName";
				ddlBankName.ValueMember = "BankID";


				Common.SetDialogCoordinate(this);


				if (EmployeeID != 0)
				{
					ShowSelectedEmployeeData();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error :" + ex.Message);
			}
		}


		private void FillCity(ComboBox state, ComboBox city)
		{
			try
			{
				//Fill City
				int stateID = int.Parse(state.SelectedValue.ToString());
				city.DataSource = CommonDL.GetCity(_appConnection, stateID).Tables[0];
				city.DisplayMember = "City";
				city.ValueMember = "CityID";
			}
			catch { }
		}

		private void FillState(ComboBox country, ComboBox state)
		{
			try
			{
				// Fill State
				int countryID = int.Parse(country.SelectedValue.ToString());
				state.DataSource = CommonDL.GetState(_appConnection, countryID).Tables[0];
				state.DisplayMember = "State";
				state.ValueMember = "StateID";
			}
			catch { }
		}

		private void ShowSelectedEmployeeData()
		{
			EmployeeDL employeeRecord = new EmployeeDL(EmployeeID, MDIForm.CompanyID, true);

            lblEmployeeCode.Text = employeeRecord.EmployeeCode;

			txtEmployeeName.Text = employeeRecord.EmployeeName;
			txtFatherName.Text = employeeRecord.EmployeeFatherName;
            txtMotherName.Text = employeeRecord.EmployeeMotherName;

            txtDateOfBirth.Text = employeeRecord.DateOfBirth;

            txtHomePhone.Text = employeeRecord.HomePhone;
			txtWorkPhone.Text = employeeRecord.WorkPhone;
			txtMobilePhone.Text = employeeRecord.MobilePhone;
			txtEmail1.Text = employeeRecord.WorkEmail;
			
			txtBillingAddress.Text = employeeRecord.Address1;

			ddlCountry.SelectedValue = employeeRecord.CountryID;
			FillState(ddlCountry, ddlState);
			if (employeeRecord.StateID != null)
				ddlState.SelectedValue = employeeRecord.StateID;
			FillCity(ddlState, ddlCity);
			if (employeeRecord.CityID != null)
				ddlCity.SelectedValue = employeeRecord.CityID;

			
			txtZip.Text = employeeRecord.PostalCode;
			txtEmail2.Text = employeeRecord.HomeEmail;
			txtComments.Text = employeeRecord.Comments;

            txtAadharPanNumber.Text = employeeRecord.AadharNo;
			txtPFNumber.Text = employeeRecord.PFNumber;

			if (employeeRecord.BankId != null)
				ddlBankName.SelectedValue = employeeRecord.BankId;

			txtBankRegion.Text = employeeRecord.BankRegion;
			txtBankAccountNo.Text = employeeRecord.BankAccountNumber;
			txtBranchName.Text = employeeRecord.BankBranch;
			txtBranchIfscCode.Text = employeeRecord.BankIFSC;
			txtBranchCode.Text = employeeRecord.BankBranchCode;
            

			btnReset.Visible = false;

			if (formsState == eFormsState.View)
			{
				DisableControls();
			}
		}

		private void DisableControls()
		{
			txtEmployeeName.Enabled = false;
			txtFatherName.Enabled = false;
            txtDateOfBirth.Enabled = false;
			txtHomePhone.Enabled = false;
			txtEmail1.Enabled = false;
			txtEmail2.Enabled = false;
			txtMotherName.Enabled = false;
			txtBillingAddress.Enabled = false;
			ddlCity.Enabled = false;
			txtZip.Enabled = false;
			ddlState.Enabled = false;
			ddlCountry.Enabled = false;
			txtBankRegion.Enabled = false;
			txtDateOfBirth.Enabled = false;
			btnSave.Enabled = false;
			ddlBankName.Enabled = false;
			txtPFNumber.Enabled = false;
            txtAadharPanNumber.Enabled = false;
			txtComments.Enabled = false;
			txtBranchCode.Enabled = false;
			txtBankAccountNo.Enabled = false;
			txtBranchIfscCode.Enabled = false;
			txtBranchName.Enabled = false;
			
		}

		private void bnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			EmployeeDL employee = new EmployeeDL();

			employee.CompanyID = MDIForm.CompanyID;
                       

			employee.EmployeeName = txtEmployeeName.Text.Trim();
            employee.EmployeeFatherName = txtFatherName.Text.Trim();
            employee.EmployeeMotherName = txtMotherName.Text.Trim();

			employee.HomePhone = txtHomePhone.Text.Trim();
			employee.WorkPhone = txtWorkPhone.Text.Trim();
			employee.MobilePhone = txtMobilePhone.Text.Trim();
			
            
			employee.Address1 = txtBillingAddress.Text.Trim();
			if (ddlCity.SelectedValue != null)
				employee.CityID = Convert.ToInt32(ddlCity.SelectedValue.ToString());
			if (ddlState.SelectedValue != null)
				employee.StateID = Convert.ToInt32(ddlState.SelectedValue.ToString());
			employee.CountryID = Convert.ToInt32(ddlCountry.SelectedValue.ToString());
			employee.PostalCode = txtZip.Text.Trim();
			
			employee.Comments = txtComments.Text.Trim();
            employee.PFNumber = txtPFNumber.Text.Trim();
            employee.AadharNo = txtAadharPanNumber.Text.Trim();

			employee.DateOfBirth = txtDateOfBirth.Text;

			if (ddlBankName.SelectedValue != null)
				employee.BankId = Convert.ToInt32(ddlBankName.SelectedValue.ToString());

			employee.BankRegion = txtBankRegion.Text.Trim();
			employee.BankAccountNumber = txtBankAccountNo.Text.Trim();
			employee.BankBranch = txtBranchName.Text;
			employee.BankIFSC = txtBranchIfscCode.Text;
			employee.BankBranchCode = txtBranchCode.Text;

            employee.WorkEmail = txtEmail1.Text.Trim();
            employee.HomeEmail = txtEmail2.Text;

			employee.AuditUserID = MDIForm.UserID;
			if (EmployeeID == 0)
			{
				employee.AddEditOption = 0;
				TransactionResult result = null;
				employee.ScreenMode = ScreenMode.Add;
				result = employee.Commit();
				//MessageBox.Show(_Result.Message, "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
				CustomMessageBox.Show(string.Format(Constants.SUCCESSFULL_ADD_MESSAGE, Constants.CONSTANT_Employee, txtEmployeeName.Text),
											  Constants.CONSTANT_INFORMATION,
											  CustomMessageBox.eDialogButtons.OK,
											  CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Success));
				ResetControls();
			}
			else
			{
				employee.AddEditOption = 1;
				employee.EmployeeID = EmployeeID;
                
				TransactionResult result = null;
				employee.ScreenMode = ScreenMode.Edit;
				result = employee.Commit();
				CustomMessageBox.Show(string.Format(Constants.SUCCESSFULL_SAVE_MESSAGE, txtEmployeeName.Text),
															  Constants.CONSTANT_INFORMATION,
															  CustomMessageBox.eDialogButtons.OK,
															  CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Success));
			}

			this.Close();
		}

		private void ResetControls()
		{
            lblEmployeeCode.Text = String.Empty;

			txtEmployeeName.Text = String.Empty;
			txtFatherName.Text = String.Empty;
            txtMotherName.Text = String.Empty;

            txtDateOfBirth.Text = String.Empty;

            txtHomePhone.Text = String.Empty;
			txtEmail1.Text = String.Empty;
			txtEmail2.Text = "";
			
			txtBankRegion.Text = String.Empty;
			
			txtBillingAddress.Text = String.Empty;

			txtBranchCode.Text = "";
			txtBankAccountNo.Text = "";
			txtBranchIfscCode.Text = "";
			txtBranchName.Text = "";
			
			ddlCity.SelectedIndex = 0;
			ddlState.SelectedIndex = 0;
			ddlCountry.SelectedIndex = 0;
			txtZip.Text = String.Empty;

			txtComments.Text = String.Empty;

			ddlBankName.SelectedIndex = 0;
			txtPFNumber.Text = String.Empty;
            txtAadharPanNumber.Text = string.Empty;
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			ResetControls();
		}

		private void chkDifferentAddress_CheckedChanged(object sender, EventArgs e)
		{
			ShowShippingAddressControls();
		}

		private void ShowShippingAddressControls()
		{

		}

		private void ddlCountry_Validated(object sender, EventArgs e)
		{
			try
			{
				FillState(ddlCountry, ddlState);
			}
			catch { }
		}

		private void ddlState_Validated(object sender, EventArgs e)
		{
			try
			{
				FillCity(ddlState, ddlCity);
			}
			catch { }
		}
	}
}
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
			EmployeeDL EmployeeRecord = new EmployeeDL(EmployeeID, MDIForm.CompanyID, true);

			txtEmployeeName.Text = EmployeeRecord.EmployeeName;
			txtEmployeeCompanyName.Text = EmployeeRecord.EmployeeCompanyName;
			txtHomePhone.Text = EmployeeRecord.HomePhone;
			txtWorkPhone.Text = EmployeeRecord.WorkPhone;
			txtMobilePhone.Text = EmployeeRecord.MobilePhone;
			txtEmail1.Text = EmployeeRecord.WorkEmail;
			txtTIN.Text = EmployeeRecord.TinNo;
			txtBillingAddress.Text = EmployeeRecord.Address1;

			ddlCountry.SelectedValue = EmployeeRecord.CountryID;
			FillState(ddlCountry, ddlState);
			if (EmployeeRecord.StateID != null)
				ddlState.SelectedValue = EmployeeRecord.StateID;
			FillCity(ddlState, ddlCity);
			if (EmployeeRecord.CityID != null)
				ddlCity.SelectedValue = EmployeeRecord.CityID;

			txtSalesPersonName.Text = EmployeeRecord.SalesPersonName;
			txtZip.Text = EmployeeRecord.PostalCode;
			txtEmail2.Text = EmployeeRecord.HomeEmail;
			txtComments.Text = EmployeeRecord.Comments;
			txtGSTNumber.Text = EmployeeRecord.CcrNo;

			if (EmployeeRecord.BankId != null)
				ddlBankName.SelectedValue = EmployeeRecord.BankId;

			txtBankRegion.Text = EmployeeRecord.BankRegion;
			txtBankAccountNo.Text = EmployeeRecord.BankAccountNumber;
			txtBranchName.Text = EmployeeRecord.BankBranch;
			txtBranchIfscCode.Text = EmployeeRecord.BankIFSC;
			txtBranchCode.Text = EmployeeRecord.BankBranchCode;

			btnReset.Visible = false;

			if (formsState == eFormsState.View)
			{
				DisableControls();
			}
		}

		private void DisableControls()
		{
			txtEmployeeName.Enabled = false;
			txtEmployeeCompanyName.Enabled = false;
			txtEmployeeCompanyName.Enabled = false;
			txtHomePhone.Enabled = false;
			txtEmail1.Enabled = false;
			txtEmail2.Enabled = false;
			txtTIN.Enabled = false;
			txtBillingAddress.Enabled = false;
			ddlCity.Enabled = false;
			txtZip.Enabled = false;
			ddlState.Enabled = false;
			ddlCountry.Enabled = false;
			txtBankRegion.Enabled = false;
			txtSalesPersonName.Enabled = false;
			btnSave.Enabled = false;
			ddlBankName.Enabled = false;
			txtGSTNumber.Enabled = false;
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
			EmployeeDL Employee = new EmployeeDL();

			Employee.CompanyID = MDIForm.CompanyID;

			Employee.EmployeeName = txtEmployeeName.Text.Trim();
			Employee.EmployeeCompanyName = txtEmployeeCompanyName.Text.Trim();
			Employee.HomePhone = txtHomePhone.Text.Trim();
			Employee.WorkPhone = txtWorkPhone.Text.Trim();
			Employee.MobilePhone = txtMobilePhone.Text.Trim();
			Employee.WorkEmail = txtEmail1.Text.Trim();
			Employee.TinNo = txtTIN.Text.Trim();
			Employee.Address1 = txtBillingAddress.Text.Trim();
			if (ddlCity.SelectedValue != null)
				Employee.CityID = Convert.ToInt32(ddlCity.SelectedValue.ToString());
			if (ddlState.SelectedValue != null)
				Employee.StateID = Convert.ToInt32(ddlState.SelectedValue.ToString());
			Employee.CountryID = Convert.ToInt32(ddlCountry.SelectedValue.ToString());
			Employee.PostalCode = txtZip.Text.Trim();
			Employee.HomeEmail = txtEmail2.Text;
			Employee.Comments = txtComments.Text.Trim();
			Employee.CcrNo = txtGSTNumber.Text.Trim();
			Employee.SalesPersonName = txtSalesPersonName.Text;
			if (ddlBankName.SelectedValue != null)
				Employee.BankId = Convert.ToInt32(ddlBankName.SelectedValue.ToString());

			Employee.BankRegion = txtBankRegion.Text.Trim();
			Employee.BankAccountNumber = txtBankAccountNo.Text.Trim();
			Employee.BankBranch = txtBranchName.Text;
			Employee.BankIFSC = txtBranchIfscCode.Text;
			Employee.BankBranchCode = txtBranchCode.Text;
			Employee.AuditUserID = MDIForm.UserID;
			if (EmployeeID == 0)
			{
				Employee.AddEditOption = 0;
				TransactionResult result = null;
				Employee.ScreenMode = ScreenMode.Add;
				result = Employee.Commit();
				//MessageBox.Show(_Result.Message, "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
				CustomMessageBox.Show(string.Format(Constants.SUCCESSFULL_ADD_MESSAGE, Constants.CONSTANT_Employee, txtEmployeeName.Text),
											  Constants.CONSTANT_INFORMATION,
											  CustomMessageBox.eDialogButtons.OK,
											  CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Success));
				ResetControls();
			}
			else
			{
				Employee.AddEditOption = 1;
				Employee.EmployeeID = EmployeeID;
				TransactionResult result = null;
				Employee.ScreenMode = ScreenMode.Edit;
				result = Employee.Commit();
				CustomMessageBox.Show(string.Format(Constants.SUCCESSFULL_SAVE_MESSAGE, txtEmployeeName.Text),
															  Constants.CONSTANT_INFORMATION,
															  CustomMessageBox.eDialogButtons.OK,
															  CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Success));
			}

			this.Close();
		}

		private void ResetControls()
		{
			txtEmployeeName.Text = String.Empty;
			txtEmployeeCompanyName.Text = String.Empty;
			txtHomePhone.Text = String.Empty;
			txtEmail1.Text = String.Empty;
			txtEmail2.Text = "";
			txtTIN.Text = String.Empty;
			txtBankRegion.Text = String.Empty;
			txtSalesPersonName.Text = String.Empty;
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
			txtGSTNumber.Text = String.Empty;
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
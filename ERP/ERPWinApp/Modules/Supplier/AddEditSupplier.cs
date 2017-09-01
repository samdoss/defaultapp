using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ERP.CommonLayer;
using ERP.DataLayer;

namespace ERPWinApp
{
	public partial class AddNewSupplier : Form
	{
		ScreenMode userMode;
		Variables _variables = new Variables();
		ApplicationConnection _appConnection = new ApplicationConnection();

		internal string helpFile = "\\Help\\HelpFile.chm";
		public int SupplierID = 0;
		public eFormsState formsState;

		public AddNewSupplier()
		{
			InitializeComponent();
		}

		private void AddNewSupplier_Load(object sender, EventArgs e)
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


				if (SupplierID != 0)
				{
					ShowSelectedSupplierData();
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

		private void ShowSelectedSupplierData()
		{
			SupplierDL SupplierRecord = new SupplierDL(SupplierID, MDIForm.CompanyID, true);

			txtSupplierName.Text = SupplierRecord.SupplierName;
			txtSupplierCompanyName.Text = SupplierRecord.SupplierCompanyName;
			txtHomePhone.Text = SupplierRecord.HomePhone;
			txtWorkPhone.Text = SupplierRecord.WorkPhone;
			txtMobilePhone.Text = SupplierRecord.MobilePhone;
			txtEmail1.Text = SupplierRecord.WorkEmail;
			txtTIN.Text = SupplierRecord.TinNo;
			txtBillingAddress.Text = SupplierRecord.Address1;

			ddlCountry.SelectedValue = SupplierRecord.CountryID;
			FillState(ddlCountry, ddlState);
			if (SupplierRecord.StateID != null)
				ddlState.SelectedValue = SupplierRecord.StateID;
			FillCity(ddlState, ddlCity);
			if (SupplierRecord.CityID != null)
				ddlCity.SelectedValue = SupplierRecord.CityID;

			txtSalesPersonName.Text = SupplierRecord.SalesPersonName;
			txtZip.Text = SupplierRecord.PostalCode;
			txtEmail2.Text = SupplierRecord.HomeEmail;
			txtComments.Text = SupplierRecord.Comments;
			txtGSTNumber.Text = SupplierRecord.CcrNo;

			if (SupplierRecord.BankId != null)
				ddlBankName.SelectedValue = SupplierRecord.BankId;

			txtBankRegion.Text = SupplierRecord.BankRegion;
			txtBankAccountNo.Text = SupplierRecord.BankAccountNumber;
			txtBranchName.Text = SupplierRecord.BankBranch;
			txtBranchIfscCode.Text = SupplierRecord.BankIFSC;
			txtBranchCode.Text = SupplierRecord.BankBranchCode;

			btnReset.Visible = false;

			if (formsState == eFormsState.View)
			{
				DisableControls();
			}
		}

		private void DisableControls()
		{
			txtSupplierName.Enabled = false;
			txtSupplierCompanyName.Enabled = false;
			txtSupplierCompanyName.Enabled = false;
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
			SupplierDL Supplier = new SupplierDL();

			Supplier.CompanyID = MDIForm.CompanyID;

			Supplier.SupplierName = txtSupplierName.Text.Trim();
			Supplier.SupplierCompanyName = txtSupplierCompanyName.Text.Trim();
			Supplier.HomePhone = txtHomePhone.Text.Trim();
			Supplier.WorkPhone = txtWorkPhone.Text.Trim();
			Supplier.MobilePhone = txtMobilePhone.Text.Trim();
			Supplier.WorkEmail = txtEmail1.Text.Trim();
			Supplier.TinNo = txtTIN.Text.Trim();
			Supplier.Address1 = txtBillingAddress.Text.Trim();
			if (ddlCity.SelectedValue != null)
				Supplier.CityID = Convert.ToInt32(ddlCity.SelectedValue.ToString());
			if (ddlState.SelectedValue != null)
				Supplier.StateID = Convert.ToInt32(ddlState.SelectedValue.ToString());
			Supplier.CountryID = Convert.ToInt32(ddlCountry.SelectedValue.ToString());
			Supplier.PostalCode = txtZip.Text.Trim();
			Supplier.HomeEmail = txtEmail2.Text;
			Supplier.Comments = txtComments.Text.Trim();
			Supplier.CcrNo = txtGSTNumber.Text.Trim();
			Supplier.SalesPersonName = txtSalesPersonName.Text;
			if (ddlBankName.SelectedValue != null)
				Supplier.BankId = Convert.ToInt32(ddlBankName.SelectedValue.ToString());

			Supplier.BankRegion = txtBankRegion.Text.Trim();
			Supplier.BankAccountNumber = txtBankAccountNo.Text.Trim();
			Supplier.BankBranch = txtBranchName.Text;
			Supplier.BankIFSC = txtBranchIfscCode.Text;
			Supplier.BankBranchCode = txtBranchCode.Text;
			Supplier.AuditUserID = MDIForm.UserID;
			if (SupplierID == 0)
			{
				Supplier.AddEditOption = 0;
				TransactionResult result = null;
				Supplier.ScreenMode = ScreenMode.Add;
				result = Supplier.Commit();
				//MessageBox.Show(_Result.Message, "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
				CustomMessageBox.Show(string.Format(Constants.SUCCESSFULL_ADD_MESSAGE, Constants.CONSTANT_SUPPLIER, txtSupplierName.Text),
											  Constants.CONSTANT_INFORMATION,
											  CustomMessageBox.eDialogButtons.OK,
											  CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Success));
				ResetControls();
			}
			else
			{
				Supplier.AddEditOption = 1;
				Supplier.SupplierID = SupplierID;
				TransactionResult result = null;
				Supplier.ScreenMode = ScreenMode.Edit;
				result = Supplier.Commit();
				CustomMessageBox.Show(string.Format(Constants.SUCCESSFULL_SAVE_MESSAGE, txtSupplierName.Text),
															  Constants.CONSTANT_INFORMATION,
															  CustomMessageBox.eDialogButtons.OK,
															  CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Success));
			}

			this.Close();
		}

		private void ResetControls()
		{
			txtSupplierName.Text = String.Empty;
			txtSupplierCompanyName.Text = String.Empty;
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
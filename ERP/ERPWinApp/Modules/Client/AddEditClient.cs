using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ERP.CommonLayer;
using ERP.DataLayer;

namespace ERPWinApp
{
    public partial class AddNewClient : Form
    {
        ScreenMode userMode;
        Variables _variables = new Variables();
        ApplicationConnection _appConnection = new ApplicationConnection();

        internal string helpFile = "\\Help\\HelpFile.chm";
        public int clientID = 0;
        public eFormsState formsState;

        public AddNewClient()
        {
            InitializeComponent();
        }

        private void AddNewClient_Load(object sender, EventArgs e)
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
                ddlCountryShipping.DataSource = CommonDL.GetCountry(_appConnection).Tables[0];
                ddlCountryShipping.DisplayMember = "Country";
                ddlCountryShipping.ValueMember = "CountryID";

                ddlStateShipping.Items.Add(sSelected);
                ddlStateShipping.SelectedIndex = 0;
                ddlCityShipping.Items.Add(sSelected);
                ddlCityShipping.SelectedIndex = 0;

	            ShowShippingAddressControls();
                Common.SetDialogCoordinate(this);
                

                if (clientID != 0)
                {
                    ShowSelectedClientData();
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

        private void ShowSelectedClientData()
        {
            Client clientRecord = new Client(clientID);
            
            txtClientName.Text = clientRecord.ClientName;
            txtContactName.Text = clientRecord.ContactName;
            txtPhone.Text = clientRecord.Phone;
            txtEmail.Text = clientRecord.Email;
            txtTIN.Text = clientRecord.TIN;
            txtPrivateClientDetails.Text = clientRecord.PrivateClientDetails;
            txtOtherClientDetails.Text = clientRecord.OtherClientDetails;
            txtBillingAddress.Text = clientRecord.BillingAddress;
            ddlCountry.SelectedValue = clientRecord.CountryID;

            FillState(ddlCountry, ddlState);
            ddlState.SelectedValue = clientRecord.StateID;
            FillCity(ddlState, ddlCity);

            ddlCity.SelectedValue = clientRecord.CityID;

            txtZip.Text = clientRecord.Zip;

            
            chkDifferentAddress.Checked = clientRecord.ShipToDifferentAddress;
            ShowShippingAddressControls();
            txtShippingAddress.Text = clientRecord.ShippingAddress;
            
            txtShippingZip.Text = clientRecord.ShippingZip;
            
            ddlCountryShipping.SelectedValue = clientRecord.ShippingCountryID;
            FillState(ddlCountryShipping, ddlStateShipping);
            ddlStateShipping.SelectedValue = clientRecord.ShippingStateID;
            FillCity(ddlStateShipping, ddlCityShipping);
            ddlCityShipping.SelectedValue = clientRecord.ShippingCityID;

            btnReset.Visible = false;

            if (formsState == eFormsState.View)
            {
                DisableControls();
            }
        }

        private void DisableControls()
        {
            txtClientName.Enabled = false;
            txtContactName.Enabled = false;
            txtContactName.Enabled = false;
            txtPhone.Enabled = false;
            txtEmail.Enabled = false;
            txtTIN.Enabled = false;
            txtBillingAddress.Enabled = false;
            ddlCity.Enabled = false;
            txtZip.Enabled = false;
            ddlState.Enabled = false;
            ddlCountry.Enabled = false;
            chkDifferentAddress.Enabled = false;
            txtPrivateClientDetails.Enabled = false;
            txtOtherClientDetails.Enabled = false;
            btnSave.Enabled = false;
            ddlCountryShipping.Enabled = false;
            ddlStateShipping.Enabled = false;
            ddlCityShipping.Enabled = false;
            txtShippingZip.Enabled = false;
            txtShippingAddress.Enabled = false;
        }
       
        private void bnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Client client = new Client();
	        client.CompanyID = MDIForm.CompanyID;
            client.ClientName = txtClientName.Text.Trim();
            client.ContactName = txtContactName.Text.Trim();
            client.Phone = txtPhone.Text.Trim();
            client.Email = txtEmail.Text.Trim();
            client.TIN = txtTIN.Text.Trim();
            client.BillingAddress = txtBillingAddress.Text.Trim();
            client.CityID = Convert.ToInt32(ddlCity.SelectedValue.ToString());
            client.CountryID = Convert.ToInt32(ddlCountry.SelectedValue.ToString());
            client.Zip = txtZip.Text.Trim();
            client.StateID = Convert.ToInt32(ddlState.SelectedValue.ToString());
            client.ShipToDifferentAddress = chkDifferentAddress.Checked;
            client.ShippingAddress = txtShippingAddress.Text.Trim();
            if (ddlCityShipping.SelectedValue != null)
                client.ShippingCityID = Convert.ToInt32(ddlCityShipping.SelectedValue.ToString());

            if (ddlStateShipping.SelectedValue != null)
                client.ShippingStateID = Convert.ToInt32(ddlStateShipping.SelectedValue.ToString());

            
            client.ShippingZip = txtShippingZip.Text.Trim();

            if (ddlCountryShipping.SelectedValue != null)
                client.ShippingCountryID = Convert.ToInt32(ddlCountryShipping.SelectedValue.ToString());

            client.PrivateClientDetails = txtPrivateClientDetails.Text.Trim();
            client.OtherClientDetails = txtOtherClientDetails.Text.Trim();
            client.Status = true;
            client.CreatedDate = DateTime.Now;
			client.AuditUserID = MDIForm.UserID;
            if (clientID == 0)
            {

                TransactionResult result = null;
                result = client.Commit(ScreenMode.Add);
                //MessageBox.Show(_Result.Message, "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                CustomMessageBox.Show(string.Format(Constants.SUCCESSFULL_ADD_MESSAGE, Constants.CONSTANT_CLIENT, txtClientName.Text),
                                              Constants.CONSTANT_INFORMATION,
                                              CustomMessageBox.eDialogButtons.OK,
                                              CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Success));
                ResetControls();
                smssend();
            }
            else
            {
                client.ModifiedDate = DateTime.Now;
                client.ClientId = clientID;
                TransactionResult result = null;
                result = client.Commit(ScreenMode.Edit);
                CustomMessageBox.Show(string.Format(Constants.SUCCESSFULL_SAVE_MESSAGE, txtClientName.Text),
                                                              Constants.CONSTANT_INFORMATION,
                                                              CustomMessageBox.eDialogButtons.OK,
                                                              CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Success));
            }

            this.Close();
        }

        private void smssend()
        {
            Client cl = new Client(Convert.ToInt32(clientID));


            using (var web = new System.Net.WebClient())
            {
                try
                {
                    string userName = "9789017256";
                    string userPassword = "SAMDOSS147";
                    string msgRecepient = "";
					string msgText = "Greatings, Welcome to WoodWorld, Your customerid is " + clientID + ", Thank you";
                    string url = "http://bhashsms.com/api/sendmsg.php?" +
                        "user=" + System.Web.HttpUtility.UrlEncode(userName) +
                        "&pass=" + userPassword +
                        "&sender=" + "CSICHU" +
                        "&phone=" + txtPhone.Text +
                        "&text=" + msgText + //System.Web.HttpUtility.UrlEncode(msgText, System.Text.Encoding.GetEncoding("ISO-8859-1")) +
                        "&priority=" + "ndnd" +
                        "&stype=" + "normal";
                    string smsResult = web.DownloadString(url);
                    if (smsResult.Contains("S."))
                    {
                        MessageBox.Show("Sms sent successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Some issue delivering", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    //Catch and show the exception if needed. Donot supress. :)  

                }
            }
        }


        private void ResetControls()
        {
            txtClientName.Text = String.Empty;
            txtContactName.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtTIN.Text = String.Empty;
            txtPrivateClientDetails.Text = String.Empty;
            txtOtherClientDetails.Text = String.Empty;
            txtBillingAddress.Text = String.Empty;
            ddlCity.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;
            ddlCountry.SelectedIndex = 0;
            txtZip.Text = String.Empty;
            
            chkDifferentAddress.Checked = false;
            txtShippingAddress.Text = String.Empty;
            ddlCityShipping.SelectedIndex = 0;            
            ddlStateShipping.SelectedIndex = 0;
            ddlCountryShipping.SelectedIndex = 0;
            txtShippingZip.Text = String.Empty;
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
            if (chkDifferentAddress.Checked)
            {
                lblShippingAddress.Visible = true;
                lblShippingCity.Visible = true;
                lblShippingCountry.Visible = true;
                lblShippingState.Visible = true;
                lblShippingZip.Visible = true;
                txtShippingAddress.Visible = true;
                ddlCityShipping.Visible = true;
                ddlStateShipping.Visible = true;
                txtShippingZip.Visible = true;
                ddlCountryShipping.Visible = true;
            }
            else
            {
                lblShippingAddress.Visible = false;
                lblShippingCity.Visible = false;
                lblShippingCountry.Visible = false;
                lblShippingState.Visible = false;
                lblShippingZip.Visible = false;
                txtShippingAddress.Visible = false;
                ddlCityShipping.Visible = false;
                ddlStateShipping.Visible = false;
                txtShippingZip.Visible = false;
                ddlCountryShipping.Visible = false;
            }
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

        private void ddlCountryShipping_Validated(object sender, EventArgs e)
        {
            try
            {
                FillState(ddlCountryShipping, ddlStateShipping);
            }
            catch { }
        }

        private void ddlStateShipping_Validated(object sender, EventArgs e)
        {
            try
            {
                FillCity(ddlStateShipping, ddlCityShipping);
            }
            catch { }
        }
    }
}
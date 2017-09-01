using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using ERP.DataLayer;
using ERP.CommonLayer;

namespace ERPWinApp
{
    public partial class EditCompanyDetails : Form
    {
        ScreenMode userMode;
        Variables _variables = new Variables();
        ApplicationConnection _appConnection = new ApplicationConnection();
        private Country countryService = new Country();
        private State stateService = new State();
        private City cityService = new City();
        private Company companyService = new Company();
        public string ImageName { get; set; }
        public int CompanyID { get; set; }

        public EditCompanyDetails()
        {
            InitializeComponent();
        }

        private void ShowActiveCompanyDetails()
        {
           Company activeCompany = (from company in companyService.GetAllCompanyList()
                                                        .Where(v => v.Status == true)
                                                         select company).SingleOrDefault();
            SetControlsWithData(activeCompany);
        }

        private void SetControlsWithData(Company activeCompany)
        {
            if (activeCompany == null)
                return;

            CompanyID = activeCompany.CompanyId;
            txtCompanyName.Text = activeCompany.CompanyName;
            txtAddress.Text = activeCompany.Address;

            ddlCountry.SelectedValue = activeCompany.CountryID;
            FillState(ddlCountry, ddlState);
            ddlState.SelectedValue = activeCompany.StateID;
            FillCity(ddlState, ddlCity);
            ddlCity.SelectedValue = activeCompany.CityID;
			txtPincode.Text = activeCompany.Zip;
            txtCompanyPhone.Text = activeCompany.CompanyPhone;
            txtEmail.Text = activeCompany.Email;
            txtWebsite.Text = activeCompany.Website;
            txtTIN.Text = activeCompany.TIN;
            txtServiceTaxNo.Text = activeCompany.ServiceTaxNo;
            txtAdditionalDetails.Text = activeCompany.AdditionalDetails;
            txtPAN.Text = activeCompany.PAN;
            cmbCurrency.SelectedItem = activeCompany.Currency;

            string absolutePath = Path.GetDirectoryName(Application.ExecutablePath);

            if (absolutePath.EndsWith("\\bin\\Debug"))
            {
                absolutePath = absolutePath.Replace("\\bin\\Debug", "");
            }

            string imagePath = Path.Combine(absolutePath, Constants.CONSTANT_IMAGES, Constants.CONSTANT_CompanyLogo);
            ImageName = activeCompany.Logo;
            Image image = Image.FromFile(Path.Combine(imagePath, activeCompany.Logo), true);
            pnlLogo.Controls.Clear();
            PictureBox pbLogo = new PictureBox();
            pbLogo.Image = image;
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.Size = pnlLogo.Size;
            pnlLogo.Controls.Add(pbLogo);
            btnRemove.Visible = true;            
        }

        private void EditCompanyDetails_Load(object sender, EventArgs e)
        {
            Common.SetFormCoordinate(this);
            string sSelected = "--Select--";

            // Fill Country
            ddlCountry.DataSource = CommonDL.GetCountry(_appConnection).Tables[0];
            ddlCountry.DisplayMember = "Country";
            ddlCountry.ValueMember = "CountryID";

            ddlState.Items.Add(sSelected);
            ddlState.SelectedIndex = 0;
            ddlCity.Items.Add(sSelected);
            ddlCity.SelectedIndex = 0;

            ddlBankName.DataSource = CommonDL.GetBank(_appConnection).Tables[0];
            ddlBankName.DisplayMember = "BankName";
            ddlBankName.ValueMember = "BankID";


            ShowActiveCompanyDetails();
        }

        //private void LoadStates()
        //{
        //    List<State> lstState = masterService.GetAllStates();
        //    lstState.Insert(0, new State("DF", "-- Select State --"));
        //    cmbState.DataSource = lstState;
        //    cmbState.DisplayMember = "StateName";
        //    cmbState.ValueMember = "StateCode";
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Company company = new Company();
                company.CompanyId = CompanyID;
                company.CompanyName = txtCompanyName.Text.Trim();
                
                company.Address = txtAddress.Text.Trim();
                company.CityID = Convert.ToInt32(ddlCity.SelectedValue);
                company.StateID = Convert.ToInt32(ddlState.SelectedValue);
	            company.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
	            company.Zip = txtPincode.Text;
				company.CompanyPhone = txtCompanyPhone.Text.Trim();
                company.Email = txtEmail.Text.Trim();
                company.Website = txtWebsite.Text.Trim();
                company.TIN = txtTIN.Text.Trim();
                company.ServiceTaxNo = txtServiceTaxNo.Text.Trim();
                company.AdditionalDetails = txtAdditionalDetails.Text.Trim();
                company.PAN = txtPAN.Text.Trim();
                company.Currency = cmbCurrency.Text;

                if (ddlBankName.SelectedValue.ToString() != "0")
                    company.BankID = Convert.ToInt32(ddlBankName.SelectedValue.ToString());

                company.BankAccountNumber = txtBankAccountNo.Text;
                company.BankIFSC = txtBranchIfscCode.Text;
                

                company.Logo = ImageName;
                company.Status = true;

                TransactionResult result = null;
				result = company.Commit(ScreenMode.Edit);

                CustomMessageBox.Show(string.Format(Constants.SUCCESSFULL_SAVE_MESSAGE, txtCompanyName.Text),
                                                                  Constants.CONSTANT_INFORMATION,
                                                                  CustomMessageBox.eDialogButtons.OK,
                                                                  CustomImages.GetDialogImage(CustomImages.eCustomDialogImages.Success));
            }
            catch(Exception ex){
                MessageBox.Show("Error : "+ex.Message);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "d:\\";
            openFileDialog1.Filter = "image files|*.jpg;*.png;*.gif;*.icon;.*;";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pnlLogo.Controls.Clear();
                    PictureBox pbLogo = new PictureBox();
                    string imageName = openFileDialog1.SafeFileName;
                    Image image = Image.FromFile(openFileDialog1.FileName);
                    string absolutePath = Path.GetDirectoryName(Application.ExecutablePath);

                    if (absolutePath.EndsWith("\\bin\\Debug"))
                    {
                        absolutePath = absolutePath.Replace("\\bin\\Debug", "");
                    }

                    string imagePath = Path.Combine(absolutePath, Constants.CONSTANT_IMAGES, Constants.CONSTANT_CompanyLogo);

                    if (!Directory.Exists(imagePath))
                    {
                        Directory.CreateDirectory(imagePath);
                    }

                    imagePath = Path.Combine(imagePath, imageName);
                    ImageName = imageName;
                    image.Save(imagePath);
                    pbLogo.Image = image;
                    pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbLogo.Size = pnlLogo.Size;
                    pnlLogo.Controls.Add(pbLogo);
                    btnRemove.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image" + ex.Message);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                pnlLogo.Controls.Clear();
                btnRemove.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing image" + ex.Message);
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
    }
}

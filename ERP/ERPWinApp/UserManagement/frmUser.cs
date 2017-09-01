using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using ERP.CommonLayer;
using ERP.DataLayer;

namespace ERPWinApp
{
    public partial class frmUser : Form
    {
        #region Constructor(s)

        public frmUser()
        {
            InitializeComponent();
            
        }

        #endregion

        #region Private Variables

        private int _UserID = 0;
        private int _AddressID = 0;
        ScreenMode userMode;
        Variables _variables = new Variables();
        ApplicationConnection _appConnection = new ApplicationConnection();
        
        internal string helpFile = "\\Help\\HelpFile.chm";
        private string _dPassword;
        private string EPassword;
        private string GetKey = "SamsTechnologies";

        #endregion

        #region Public Variables

        /// <summary>
        /// Decrypted Password: Get - Returns (Encrypted Property) Decrypted
        /// Decrypted Password: Set - Pass in Clear 
        /// </summary>
        public string DPassword // Decrypted Password
        {
            get
            {
                SymCryptography cryptic = new SymCryptography("tripledes");

                cryptic.Key = GetKey;

                _dPassword = cryptic.Decrypt(EPassword);

                return _dPassword;
            }
            set
            {

                _dPassword = value;

                SymCryptography cryptic = new SymCryptography("tripledes");
                cryptic.Key = GetKey;

                EPassword = cryptic.Encrypt(value);
            }
        }

        #endregion

        #region Private Event(s)

        private void frmUser_Load(object sender, EventArgs e)
        {
            try
            {
                string sSelected = "--Select--";

                // Fill Title Without Baby, Master
                ddlTitle.DataSource = CommonDL.GetTitle(_appConnection, 1).Tables[0];
                ddlTitle.DisplayMember = "Title";
                ddlTitle.ValueMember = "TitleID";

                //Fill Gender
                ddlGender.DataSource = CommonDL.GetGender(_appConnection).Tables[0];
                ddlGender.DisplayMember = "Gender";
                ddlGender.ValueMember = "GenderID";

             
                // Fill Country
                ddlCountry.DataSource = CommonDL.GetCountry(_appConnection).Tables[0];
                ddlCountry.DisplayMember = "Country";
                ddlCountry.ValueMember = "CountryID";

                ddlState.Items.Add(sSelected);
                ddlState.SelectedIndex = 0;
                ddlCity.Items.Add(sSelected);
                ddlCity.SelectedIndex = 0;

                //Fill Role
                ddlRole.DataSource = Role.GetRoleList(_appConnection).Tables[0];
                ddlRole.DisplayMember = "RoleName";
                ddlRole.ValueMember = "RoleID";

               
                //Fill Date of Birth
                dtpDOB.MaxDate = DateTime.Now;
                dtpDOB.MaxDate = DateTime.Now.AddDays(-6570);

                txtUserName.Focus();

                ClearForm();

                ApplicationHelpProvider.HelpNamespace = (Application.StartupPath + helpFile);
                ApplicationHelpProvider.SetHelpKeyword(this, "frmuser.htm");
                ApplicationHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
                _variables.FnSetDisabledButton(btnSave);
                _variables.FnSetEnabledButton(btnCancel);
                //Font Settings
                LoadDefaultColorandFonts();
            }
            catch { }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            _variables.FnSetEnabledButton(btnSave);
            _variables.FnSetEnabledButton(btnCancel);
            
        }

        private void ddlTitle_TextChanged(object sender, EventArgs e)
        {
            _variables.FnSetEnabledButton(btnSave);
            _variables.FnSetEnabledButton(btnCancel);
            
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            _variables.FnSetEnabledButton(btnSave);
            _variables.FnSetEnabledButton(btnCancel);
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                frmFindUser _frmFindUser = new frmFindUser();
                _frmFindUser.UserName = txtUserName.Text;
                _frmFindUser.ShowDialog();

                _UserID = _frmFindUser.UserID;
                txtUserID.Text = Convert.ToString(_frmFindUser.UserID);
                if (txtUserID.Text != "0")
                {
                    txtUserName.Text = _frmFindUser.UserName;
                    txtUserName_Leave(sender, e);
                    txtUserName.Focus();
                    _variables.FnSetEnabledButton(btnSave);
                    _variables.FnSetEnabledButton(btnCancel);
                    
                }
                else
                {
                    txtUserName.Text = "";
                    txtDOB.Text = "";
                    lblAge.Text = "(Age)";
                    txtUserID.Text = "";
                    txtUserName.Focus();
                    _variables.FnSetDisabledButton(btnSave);
                    _variables.FnSetEnabledButton(btnCancel);
                    
                }
            }
            catch { }
        }

        private void ddlCountry_Validated(object sender, EventArgs e)
        {
            try
            {
                FillState();
            }
            catch { }
        }

        private void ddlState_Validated(object sender, EventArgs e)
        {
            try
            {
                FillCity();
            }
            catch { }
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            string strFilePath;
            System.Drawing.Image thumbnail, fullimage;

            OpenFileDialog opnFileBoxImage = new OpenFileDialog();
            opnFileBoxImage.Filter = "Image files (*.bmp; *.gif; *.jpg; *.png)|*.bmp;*.gif;*.jpg;*.png|" + "All files (*.*)|*.*";

            if (opnFileBoxImage.ShowDialog() == DialogResult.OK)
            {
                strFilePath = opnFileBoxImage.FileName;
                try
                {
                    fullimage = System.Drawing.Image.FromFile(strFilePath);
                    thumbnail = fullimage.GetThumbnailImage(125, 150, null, IntPtr.Zero);
                    picPhoto.Image = thumbnail;
                    fullimage.Dispose();
                }
                catch
                {
                    MessageBox.Show("Please Select Valid Image Format.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            picPhoto.Image = null;
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtPincode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtPhone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtPhone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtSTD1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtConsultFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtSTD2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Validation 
                if (!FormValidation()) { return; }
                Users _Users = new Users();

                if (_UserID == 0)
                {
                    userMode = ScreenMode.Add;
                    lblUserName.Visible = true;
                    txtUserName.Visible = true;
                }
                else
                {
                    userMode = ScreenMode.Edit;
                    lblUserName.Visible = false;
                    txtUserName.Visible = false;
                }
                _Users.UserID = _UserID;
                _Users.UserName = txtUserName.Text;
                DPassword = "123456";
                _Users.Password = EPassword;

                _Users.TitleID = Int16.Parse(ddlTitle.SelectedValue.ToString());
                _Users.Name = txtName.Text;
                _Users.DateOfBirth = dtpDOB.Value;
                _Users.GenderID = Int16.Parse(ddlGender.SelectedValue.ToString());
                _Users.RoleID = Int16.Parse(ddlRole.SelectedValue.ToString());
                _Users.RegistrationNumber = txtAadharNo.Text.ToString();
                if (txtDesignation.Text.ToString() != "")
                    _Users.Designation = txtDesignation.Text;

                if (txtQualification.Text.ToString() != "")
                    _Users.Qualification = txtQualification.Text;
                                
                _Users.AuditUserID = MDIForm.UserID;

                if (picPhoto.Image != null)
                {
                    MemoryStream ms = new MemoryStream();
                    picPhoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] bytes = ms.GetBuffer();
                    _Users.Photo = bytes;
                }

                Address uAdd = new Address();
                uAdd.AddressID = _AddressID;
                uAdd.Address1 = txtAddress1.Text;
                if (txtAddress2.Text.ToString() != "")
                    uAdd.Address2 = txtAddress2.Text;
                if (txtAddress3.Text.ToString() != "")
                    uAdd.Address3 = txtAddress3.Text;
                if (txtArea.Text.ToString() != "")
                    uAdd.Area = txtArea.Text;
                uAdd.CountryID = int.Parse(ddlCountry.SelectedValue.ToString());
                if(ddlState.SelectedValue != null)
                uAdd.StateID = int.Parse(ddlState.SelectedValue.ToString());
                if (ddlCity.SelectedValue != null)
                uAdd.CityID = int.Parse(ddlCity.SelectedValue.ToString());
                if (txtPincode.Text.ToString() != "")
                    uAdd.ZipCode = txtPincode.Text;
                if (txtEmail.Text.ToString() != "")
                    uAdd.Email = txtEmail.Text;
                _Users.AddressList = uAdd;

                List<ContactInformation> listUCI = new List<ContactInformation>();

                ContactInformation UCI1 = new ContactInformation();
                if (txtPhone1.Text.ToString() != "")
                {
                    UCI1.ContactTypeID = Convert.ToInt16(ContactType.Telephone);
                    UCI1.ContactNumber = txtPhone1.Text;
                    if (txtSTD1.Text.ToString() != "")
                        UCI1.ContactSTD = txtSTD1.Text;
                    UCI1.AuditUserID = MDIForm.UserID;
                    listUCI.Add(UCI1);
                }

                ContactInformation UCI2 = new ContactInformation();
                if (txtPhone2.Text.ToString() != "")
                {
                    UCI2.ContactTypeID = Convert.ToInt16(ContactType.Telephone);
                    UCI2.ContactNumber = txtPhone2.Text;
                    if (txtSTD2.Text.ToString() != "")
                        UCI2.ContactSTD = txtSTD2.Text;
                    UCI2.AuditUserID = MDIForm.UserID;
                    listUCI.Add(UCI2);
                }

                ContactInformation UCI3 = new ContactInformation();
                if (txtMobile.Text.ToString() != "")
                {
                    UCI3.ContactTypeID = Convert.ToInt16(ContactType.Mobile);
                    UCI3.ContactNumber = txtMobile.Text;
                    UCI3.ContactSTD = string.Empty;
                    UCI3.AuditUserID = MDIForm.UserID;
                    listUCI.Add(UCI3);
                }

                if (listUCI.Count > 0)
                    _Users.ContactInformation = listUCI;

                TransactionResult result;
                result = _Users.Commit(userMode);
                MessageBox.Show(result.Message.ToString(), "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                ClearForm();
            }
            catch
            {
                MessageBox.Show("UserName Already Exists.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            txtUserName.Focus();
            userMode = ScreenMode.View;
            lblUserName.Visible = true;
            txtUserName.Visible = true;
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime dtDate = new DateTime();


                if (dtpDOB.Value >= DateTime.Today)
                    dtpDOB.Value = DateTime.Today;

                dtDate = dtpDOB.Value;

                txtDOB.Text = dtDate.ToString("dd/MM/yyyy");
                lblAge.Text = Utility.CalculateAge(dtpDOB.Value);
            }
            catch { }
        }

        private void ddlRole_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                pnlDoctorInfo.Visible = false;
                lblDoctorInfo.Visible = false;

                if (ddlRole.Text.ToString() == "Doctor")
                {
                    pnlDoctorInfo.Visible = true;
                    lblDoctorInfo.Visible = true;
                }
            }
            catch { }
        }

        private void frmUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (userMode == ScreenMode.View)
                {
                    if (txtUserID.Text.ToString() != "" && txtUserID.Text.ToString() != "0")
                    {
                        bool dataExist = ViewUserData();
                        userMode = ScreenMode.Edit;
                        lblUserName.Visible = false;
                        txtUserName.Visible = false;
                    }
                }
                if (userMode == ScreenMode.Add)
                {
                        txtUserName.Visible = true;
                        lblUserName.Visible = true;
                }
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                _UserID = 0;
                txtUserName.Text = string.Empty;
                ClearForm();
                userMode = ScreenMode.Add;
                lblUserName.Visible = true;
                txtUserName.Visible = true;
                _variables.FnSetEnabledButton(btnCancel);
                _variables.FnSetDisabledButton(btnSave);
                
            }
            catch { }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text.Trim() != "")
                {
                    string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                       @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                       @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                    Regex re = new Regex(strRegex);
                    if (!re.IsMatch(txtEmail.Text.ToString()))
                    {
                        MessageBox.Show("Please Enter Valid Email-ID.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        txtEmail.Focus();
                    }
                }
            }
            catch { }
        }

        #endregion

        #region Private Methods

        private void LoadDefaultColorandFonts()
        {
            _variables.FnTitleTheme(lblCaption);
            _variables.FnSubTitleTheme(lblBasicInfo);
            _variables.FnSubTitleTheme(lblContactInfo);
            _variables.FnSubTitleTheme(lblPhoto);
            _variables.FnSubTitleTheme(lblDoctorInfo);
            _variables.FnButtonTheme(btnCancel);
            _variables.FnButtonTheme(btnSave);
            _variables.FnButtonTheme(btnClose);
            _variables.FnButtonTheme(btnPhoto);
            _variables.FnButtonTheme(btnClear);
            _variables.FnButtonTheme(btnView);
            _variables.FnButtonTheme(btnSearch);
            _variables.FnSetToolTip(btnClear, "Alt+E Clear");
            _variables.FnSetToolTip(btnView, "Alt+V View");
            _variables.FnSetToolTip(btnSave, "Alt+S Save");
            _variables.FnSetToolTip(btnCancel, "Alt+R Reset");
            _variables.FnSetToolTip(btnClose, "Alt+C Close");
            _variables.FnSetToolTip(btnPhoto, "Alt+L Photo");
            _variables.FnSetToolTip(btnSearch, "Alt+H Search");

        }

        private bool ViewUserData()
        {
            bool dataExist = false;
            try
            {
                ClearForm();
                Users _Users = new Users(_UserID, true);
                txtUserName.Text = _Users.UserName;
                txtAadharNo.Text = _Users.RegistrationNumber;
                ddlTitle.SelectedValue = _Users.TitleID;
                txtName.Text = _Users.Name;
                DateTime dt = new DateTime();
                dt = _Users.DateOfBirth;
                txtDOB.Text = dt.ToString("dd/MM/yyyy");

                if (txtDOB.Text.ToString() == "01/01/0001")
                {
                    dtpDOB.MaxDate = DateTime.Now.AddDays(-6570);
                }
                else
                {
                    dtpDOB.MaxDate = DateTime.Now.AddDays(-6570);
                    dtpDOB.Value = _Users.DateOfBirth;
                    txtDOB.Text = _Users.DateOfBirth.ToString();
                }
                lblAge.Text = Utility.CalculateAge(dtpDOB.Value);
                ddlGender.SelectedValue = _Users.GenderID;
                ddlRole.SelectedValue = _Users.RoleID;
                txtDesignation.Text = _Users.Designation;
                txtQualification.Text = _Users.Qualification;
                
                _AddressID = _Users.AddressList.AddressID;
                txtAddress1.Text = _Users.AddressList.Address1;
                txtAddress2.Text = _Users.AddressList.Address2;
                txtAddress3.Text = _Users.AddressList.Address3;
                txtArea.Text = _Users.AddressList.Area;
                ddlCountry.SelectedValue = _Users.AddressList.CountryID;
                FillState();
                ddlState.SelectedValue = _Users.AddressList.StateID;
                FillCity();
                ddlCity.SelectedValue = _Users.AddressList.CityID;
                txtPincode.Text = _Users.AddressList.ZipCode;
                txtEmail.Text = _Users.AddressList.Email;
                if (_Users.Photo != null)
                {
                    MemoryStream ms = new MemoryStream(_Users.Photo);
                    if (ms.Length != 0)
                    {
                        picPhoto.Image = Image.FromStream(ms);
                        picPhoto.Refresh();
                    }
                }

                List<ContactInformation> listUCI = _Users.ContactInformation;

                int iTelephoneCount = 0;
                if (listUCI != null)
                {
                    foreach (ContactInformation sCI in listUCI)
                    {
                        switch ((ContactType)Enum.Parse(typeof(ContactType), sCI.ContactTypeID.ToString()))
                        {
                            case ContactType.Telephone:
                                if (iTelephoneCount == 0)
                                {
                                    txtSTD1.Text = sCI.ContactSTD;
                                    txtPhone1.Text = sCI.ContactNumber;
                                }
                                if (iTelephoneCount == 1)
                                {
                                    txtSTD2.Text = sCI.ContactSTD;
                                    txtPhone2.Text = sCI.ContactNumber;
                                }
                                iTelephoneCount = 1;
                                break;
                            case ContactType.Mobile:
                                txtMobile.Text = sCI.ContactNumber;
                                break;
                        }
                    }
                }
               
                dataExist = true;
                return dataExist;
            }
            catch { }
            return dataExist;
        }

        private bool FormValidation()
        {
            bool valid = true;

            if (txtUserName.Text.Trim() == "" || txtUserName.Text.Length < 6)
            {
                MessageBox.Show("Please Enter Valid Username. Length must be 6 characters", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                valid = false;
                txtUserName.Focus();
            }
            else if (int.Parse(ddlTitle.SelectedValue.ToString()) == 0)
            {
                MessageBox.Show("Please Select Title.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                valid = false;
                ddlTitle.Focus();
            }

            else if (txtName.Text.Trim() == "" || txtName.Text.Length < 3)
            {
                MessageBox.Show("Please Enter Valid Name.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                valid = false;
                txtName.Focus();
            }
            else if (ddlGender.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Gender.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                valid = false;
                ddlGender.Focus();
            }
            else if (ddlRole.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Role.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                valid = false;
                ddlRole.Focus();
            }
            else if (txtAddress1.Text.ToString() == "")
            {
                MessageBox.Show("Please Enter Address.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                valid = false;
                txtAddress1.Focus();
            }
            else if (txtArea.Text.ToString() == "")
            {
                MessageBox.Show("Please Enter Area / Place.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                valid = false;
                txtArea.Focus();
            }
            else if (ddlCountry.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Country.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                valid = false;
                ddlCountry.Focus();
            }
            else if (ddlState.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select State.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                valid = false;
                ddlState.Focus();
            }
            else if (ddlCity.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select City.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                valid = false;
                ddlCity.Focus();
            }
            else if (txtPincode.Text.Trim() == "" || txtPincode.Text.Length < 6)
            {
                MessageBox.Show("Please Enter Valid Pincode.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                valid = false;
                txtPincode.Focus();
            }
            else if (txtMobile.Text.Trim() == "" || txtMobile.Text.Length < 10)
            {
                MessageBox.Show("Please Enter Valid Mobile Number.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                valid = false;
                txtMobile.Focus();
            }
            else if (txtEmail.Text.Trim() != "")
            {
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                   @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                   @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(strRegex);
                if (!re.IsMatch(txtEmail.Text.ToString()))
                {
                    MessageBox.Show("Please Enter Valid Email-ID.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    valid = false;
                    txtEmail.Focus();
                }
            }
            else if ((txtAadharNo.Text.Trim() == "") || (Convert.ToInt32(txtAadharNo.Text.Length) < 3))
            {
                    MessageBox.Show("Please Enter Aadhar Number.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    valid = false;
                    txtAadharNo.Focus();               
            }
            
           
            return valid;
        }

        public void ClearForm()
        {
            txtUserName.Text = "";
            ddlTitle.SelectedValue = 0;
            txtName.Text = string.Empty;
            txtAadharNo.Text = "";
            txtDOB.Text = "";
            ddlGender.SelectedIndex = 0;
            ddlRole.SelectedIndex = 0;
            
            txtDesignation.Text = string.Empty;
            txtQualification.Text = string.Empty;
            
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtAddress3.Text = string.Empty;
            txtArea.Text = string.Empty;
            ddlCity.SelectedValue = 0;
            ddlState.SelectedValue = 0;
            ddlCountry.SelectedValue = 0;

            txtPincode.Text = string.Empty;
            txtSTD1.Text = string.Empty;
            txtPhone1.Text = string.Empty;
            txtSTD2.Text = string.Empty;
            txtPhone2.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMobile.Text = "";
            picPhoto.Image = null;
            
            ddlTitle.SelectedIndex = 0;
            ddlGender.SelectedIndex = 0;
            ddlRole.SelectedIndex = 0;
            ddlCountry.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;
            ddlCity.SelectedIndex = 0;
            dtpDOB.Value = Convert.ToDateTime("01/01/1970");
            btnSearch.Visible = false;
            txtUserName.Focus();
            lblAge.Text = "(Age)";
        }

        private void FillCity()
        {
            //Fill City
            int stateID = int.Parse(ddlState.SelectedValue.ToString());
            ddlCity.DataSource = CommonDL.GetCity(_appConnection, stateID).Tables[0];
            ddlCity.DisplayMember = "City";
            ddlCity.ValueMember = "CityID";
        }

        private void FillState()
        {
            // Fill State
            int countryID = int.Parse(ddlCountry.SelectedValue.ToString());
            ddlState.DataSource = CommonDL.GetState(_appConnection, countryID).Tables[0];
            ddlState.DisplayMember = "State";
            ddlState.ValueMember = "StateID";
        }

        private void txtDOB_Validated(object sender, EventArgs e)
        {
            if (txtDOB.Text.Trim() != "")
            {
                try
                {
                    String[] date = txtDOB.Text.Split('/');
                    string ddmmyy = date[1].ToString().Trim() + "/" + date[0].ToString().Trim() + "/" + date[2].ToString().Trim();
                    dtpDOB.Value = DateTime.Parse(ddmmyy.ToString());
                }
                catch
                {
                    txtDOB.Text = "";
                    //MessageBox.Show("Please Enter Valid Date.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    lblAge.Text = "Age";
                }
            }
        }

        #endregion

    }
}
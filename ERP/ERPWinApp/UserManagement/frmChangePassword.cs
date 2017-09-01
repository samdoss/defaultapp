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
    public partial class frmChangePassword : Form
    {
        #region Constructor(s)

        public frmChangePassword()
        {
            InitializeComponent();
            
        }

        #endregion

        #region Private Variables

        private int _UserID = 0;
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

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            try
            {
                ApplicationHelpProvider.HelpNamespace = (Application.StartupPath + helpFile);
                ApplicationHelpProvider.SetHelpKeyword(this, "frmChangePassword.htm");
                ApplicationHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
                lblUserName.Text = Convert.ToString(MDIForm.UserNames.ToString());
                _UserID = Convert.ToInt32(MDIForm.UserID.ToString());
                _variables.FnSetDisabledButton(btnOk);
                LoadDefaultColorandFonts();
            }
            catch { }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                ddlOldPassword.DataSource = ChangePassword.GetUserPassword(_appConnection, Convert.ToInt32(_UserID)).Tables[0];
                ddlOldPassword.DisplayMember = "Password";
                ddlOldPassword.ValueMember = "Password";
                DPassword = txtPassword.Text;
                if (!FormValidation()) { return; }
                ChangePassword _changePassword = new ChangePassword();
                _changePassword.UserID = _UserID;
                DPassword = txtNewPassword.Text;
                _changePassword.Password = EPassword;
                userMode = ScreenMode.Edit;
                TransactionResult result;
                result = _changePassword.Commit(userMode);
                MessageBox.Show(result.Message.ToString(), "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
            catch { }
        }

        private void ddlOldPassword_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlOldPassword.SelectedIndex != 0)
                {
                    _variables.FnSetEnabledButton(btnOk);
                    
                }
                else
                {
                    _variables.FnSetDisabledButton(btnOk);
                    
                }
            }
            catch { }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text != "")
                {
                    _variables.FnSetEnabledButton(btnOk);
                    
                }
            }
            catch { }
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNewPassword.Text != "")
                {
                    _variables.FnSetEnabledButton(btnOk);
                    
                }
            }
            catch { }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtConfirmPassword.Text != "")
                {
                    _variables.FnSetEnabledButton(btnOk);
                    
                }
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }

        #endregion

        #region Private Method

        private bool FormValidation()
        {
            bool valid = true;
            if ((Convert.ToString(txtPassword.Text) == null) || (Convert.ToString(txtPassword.Text) == ""))
            {
                txtPassword.Focus();
                MessageBox.Show("Please Enter Old Password.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                valid = false;
            }
            else if ((Convert.ToString(txtNewPassword.Text) == null) || (Convert.ToString(txtNewPassword.Text) == ""))
            {
                txtNewPassword.Focus();
                MessageBox.Show("Please Enter New Password.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                valid = false;
            }
            else if ((Convert.ToString(txtConfirmPassword.Text) == null) || (Convert.ToString(txtConfirmPassword.Text) == ""))
            {
                txtConfirmPassword.Focus();
                MessageBox.Show("Please Enter Confirm Password.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                valid = false;
            }
            else if (Convert.ToString(txtNewPassword.Text) != Convert.ToString(txtConfirmPassword.Text))
            {
                MessageBox.Show("New password Does Not Match with Confirm Password, Please Check.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtNewPassword.Text = "";
                txtConfirmPassword.Text = "";
                txtNewPassword.Focus();
                valid = false;
            }
            else if (Convert.ToString(txtPassword.Text) == Convert.ToString(txtNewPassword.Text))
            {
                MessageBox.Show("Old Password and New Password are Same, Please Enter Other Value for New Password.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtNewPassword.Text = "";
                txtConfirmPassword.Text = "";
                txtNewPassword.Focus();
                valid = false;
            }
            else if (Convert.ToInt32(txtNewPassword.Text.Length.ToString()) < 5)
            {
                MessageBox.Show("New Password Should be Minimum 5 Characters, Please Enter 5 or More Characters.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtNewPassword.Text = "";
                txtConfirmPassword.Text = "";
                txtNewPassword.Focus();
                valid = false;
            }
            else if (Convert.ToString(ddlOldPassword.SelectedValue.ToString().Trim()) != EPassword)
            {
                MessageBox.Show("Please Enter Old Password Correctly.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtPassword.Focus();
                valid = false;
            }
            return valid;
        }

        private void LoadDefaultColorandFonts()
        {
            _variables.FnTitleTheme(lblCaption);
            _variables.FnButtonTheme(btnOk);
            _variables.FnButtonTheme(btnCancel);
            _variables.FnSetToolTip(btnCancel, "Alt+C Cancel");
            _variables.FnSetToolTip(btnOk, "Alt+O Change the Password");
        }
        
        #endregion

    }
}
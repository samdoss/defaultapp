using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; 
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration; 
using System.IO;
using System.Security.Cryptography;
using ERP.DataLayer;
using ERP.CommonLayer;
                    
namespace ERPWinApp
{
    public partial class frmLogin : Form
    {
        #region Constructor(s)

        public frmLogin()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Variables

        Variables objVariables = new Variables();
        ApplicationConnection _appConnection = new ApplicationConnection();
        internal string helpFile = "\\Help\\HelpFile.chm";
        private string _dPassword;
        private string EPassword;
        /*GetKey is the Login Key of the Application.
         * *** If you Change the GetKey the password doesn't match *** */
        private string GetKey = "SamsTechnologies";
        Microsoft.Win32.RegistryKey key;
        private string _IsPeriodValid;
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

        public string IsPeriodValid
        {
            get { return _IsPeriodValid; }
            set { _IsPeriodValid = value; }
        }
        #endregion

        #region Private Event(s)

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = _appConnection.ConnectConnectionString();
                Login login = new Login();
                ActiveUsers _activeUsers = new ActiveUsers();
                if (!FormValidation()) { return; }
                DPassword = txtPassword.Text;
                string appSettingDirectory = Common.GetAllUserPath();
                TransactionResult result = login.ValidateUser(appSettingDirectory, txtUserName.Text.ToString(), EPassword, chkRemember.Checked);
                if (result.Status == TransactionStatus.Success)
                {
                    key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(txtUserName.Text, true);
                    //key.GetValue
                    if (key != null)
                    {
                        TransactionResult removeUserResult = _activeUsers.RemoveActiveUser(login.UserID);
                    }

                    TransactionResult addUserResult = _activeUsers.AddActiveUser(login.UserID);

                    if (addUserResult.Status == TransactionStatus.Failure)
                    {
                        MessageBox.Show(addUserResult.Message, "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        Application.Restart();
                        return;
                    }

                    if (_activeUsers.GetActiveUsersCount() != "")
                    {
                        MessageBox.Show(_activeUsers.GetActiveUsersCount(), "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        TransactionResult removeUserResult = _activeUsers.RemoveActiveUser(login.UserID);
                        Application.Restart();
                        return;
                    }

                    this.DialogResult = DialogResult.OK;
                    MDIForm.UserID = int.Parse(login.UserID.ToString());

                    key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(txtUserName.Text);
                    key.SetValue(txtUserName.Text, MDIForm.UserID);
                    key.Close();
                    btnCancel_Click(sender, e);
                    

                }
                else
                {
                    txtUserName.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    MessageBox.Show("Invalid User Name or Password.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtUserName.Focus();
                }
            }
            catch
            {
                //MessageBox.Show("Database Not Associated With this Application, Please Update the Database Settings Correctly.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //frmSettings objDBSettings = new frmSettings();
                //objDBSettings.ShowDialog();
                //Application.Restart();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                int _period = 0;
                PCSHelp.HelpNamespace = (Application.StartupPath + helpFile);
                PCSHelp.SetHelpKeyword(this, "frmLogin.htm");
                PCSHelp.SetHelpNavigator(this, HelpNavigator.Topic);
                _period = Convert.ToInt32(IsPeriodValid);

                if (_period >= 365)
                {
                    txtUserName.Enabled = false;
                    txtUserName.Text = "";
                    txtPassword.Enabled = false;
                    btnLogin.Enabled = false;
                    chkRemember.Checked = false;
                    chkRemember.Enabled = false;
                    lblTrialVersion.Text = "This Copy of ERP  Valid For 365 Days .";
                    lblCP.Visible = true;
                }
                else if (_period < 0)
                {
                    txtUserName.Enabled = false;
                    txtUserName.Text = "";
                    txtPassword.Enabled = false;
                    btnLogin.Enabled = false;
                    chkRemember.Checked = false;
                    chkRemember.Enabled = false;
                    lblTrialVersion.Text = "This Copy of ERP  Valid For 365 Days.";
                    lblCP.Visible = true;
                }
                else
                {
                    _period = 365 - _period;
                    lblTrialVersion.Text = "This License Will Expire in " + _period + " Days";
                    lblCP.Visible = false;
                }

                Login login = new Login();
                string appSettingDirectory = Common.GetAllUserPath();
                txtUserName.Text = login.ReadDefaultUser(appSettingDirectory);
                if (txtUserName.Text.Trim() != "")
                {
                    chkRemember.Checked = true;
                }
            }
            catch { }
        }

        #endregion

        #region Private Method(s)

        private bool FormValidation()
        {
            bool valid = true;

            if (txtUserName.Text == "")
            {
                MessageBox.Show("Please Enter The User Name.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtUserName.Focus();
                valid = false;
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Please Enter The Password.", "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtPassword.Focus();
                valid = false;
            }
            return valid;
        }

        #endregion
    }
}
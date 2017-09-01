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
    public partial class frmResetPassword : Form
    {
        #region Constructor(s)

        public frmResetPassword()
        {
            InitializeComponent();
           
        }

        #endregion

        #region Private Variables

        private int _UserID = 0;
        internal string helpFile = "\\Help\\HelpFile.chm";
        ScreenMode userMode;
        Variables _variables = new Variables();
        ApplicationConnection _appConnection = new ApplicationConnection();
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

        private void frmResetPassword_Load(object sender, EventArgs e)
        {
            try
            {
                ddlUser.DataSource = Users.GetUsersList(_appConnection).Tables[0];
                ddlUser.DisplayMember = "UserName";
                ddlUser.ValueMember = "UserID";
                ApplicationHelpProvider.HelpNamespace = (Application.StartupPath + helpFile);
                ApplicationHelpProvider.SetHelpKeyword(this, "frmResetPassword.htm");
                ApplicationHelpProvider.SetHelpNavigator(this, HelpNavigator.Topic);
                _variables.FnSetDisabledButton(btnOk);
                LoadDefaultColorandFonts();
            }
            catch { }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlUser.SelectedIndex != 0)
                {
                    ResetPassword _resetPassword = new ResetPassword();
                    _resetPassword.UserID = Convert.ToInt32(ddlUser.SelectedValue.ToString());
                    _resetPassword.UserName = ddlUser.Text;
                    DPassword = "123456";
                    _resetPassword.Password = EPassword;
                    userMode = ScreenMode.Edit;
                    TransactionResult result;
                    result = _resetPassword.Commit(userMode);
                    MessageBox.Show(result.Message.ToString(), "SoftwareName", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ddlUser.SelectedIndex = 0;
                }
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlUser.SelectedIndex != 0)
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

        private void frmResetPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }

        #endregion

        #region Private Method

        private void LoadDefaultColorandFonts()
        {
            _variables.FnTitleTheme(lblCaption);
            _variables.FnButtonTheme(btnOk);
            _variables.FnButtonTheme(btnCancel);
            _variables.FnSetToolTip(btnCancel, "Alt+C Close");
            _variables.FnSetToolTip(btnOk, "Alt+O Reset Password");
        }

        #endregion

    }
}
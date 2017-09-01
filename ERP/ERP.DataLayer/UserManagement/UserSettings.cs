using ERP.CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.DataLayer
{
    public class UserSettings
    {
        #region Constructor(s)

        public UserSettings(){}
        
        #endregion

        #region Private Variables

        ApplicationConnection _appConnection = new ApplicationConnection();

        private int _UserID;
        private string _Password;
        private string _NewPassword;
        private string _ConfirmPassword;

        #endregion

        #region Public Properties

        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string NewPassword
        {
            get { return _NewPassword; }
            set { _NewPassword = value; }
        }

        public string ConfirmPassword
        {
            get { return _ConfirmPassword; }
            set { _ConfirmPassword = value; }
        }

        #endregion

     }
}

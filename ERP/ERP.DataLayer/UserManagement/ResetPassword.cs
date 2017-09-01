using System.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using ERP.CommonLayer;

namespace ERP.DataLayer
{
    public class ResetPassword
    {
        #region Constructor(s)

        public ResetPassword() { }

        #endregion

        #region Private Variables

        ApplicationConnection _appConnection = new ApplicationConnection();
        //Users Table
        private int _UserID;
        private string _UserName;
        private string _Password;
        
        #endregion

        #region Public Properties

        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        #endregion

        #region Public Methods

        public TransactionResult Commit(ScreenMode screenMode)
        {
            TransactionResult _result = null;
            switch (screenMode)
            {
                case ScreenMode.Edit:
                    _result = UpdateUserPassword();
                    break;
            }
            return _result;
        }

        #endregion

        #region Private Methods

        private TransactionResult UpdateUserPassword()
        {
            int _returnValue = 0;
            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
            string sqlCommand = "spUpdateUserPassword";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "UserID", DbType.Int32, _UserID);
            db.AddInParameter(dbCommand, "Password", DbType.String, _Password);
            db.AddParameter(dbCommand, "Return Value", DbType.String, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);
            db.ExecuteNonQuery(dbCommand);
            _returnValue = Convert.ToInt32(db.GetParameterValue(dbCommand, "Return Value"));

            if (_returnValue == -1)
            {
                return new TransactionResult(TransactionStatus.Failure, "Failure Resetting User Password");
            }
            else
            {
                return new TransactionResult(TransactionStatus.Success, "User Password Successfully Reset");
            }
        }

        #endregion
    }
}

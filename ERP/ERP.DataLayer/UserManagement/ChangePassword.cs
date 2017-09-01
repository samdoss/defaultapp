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
    public class ChangePassword
    {
        #region Constructor(s)

        public ChangePassword() { }

        #endregion

        #region Private Variables

        private int _UserID;
        private string _UserName;
        private string _Password;
        ApplicationConnection _appConnection = new ApplicationConnection();
        
        
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
            try
            {
                TransactionResult _result = null;
                switch (screenMode)
                {
                    case ScreenMode.Edit:
                        _result = UpdateChangePassword();
                        break;
                }
                return _result;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("ChangePassword.cs", "Commit");
            }
            return null;
        }
                
        #region Get Old Password

        /// <summary>
        /// Get Old Password
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="UserID">UserID</param>
        /// <returns>Return the data as Dataset</returns>
        
        public static DataSet GetUserPassword(ApplicationConnection _appConnection, int UserID)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetUserPassword";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("ChangePassword.cs", "GetUserPassword");
            }
            return null;
        }

        #endregion


        #region Get Current Password

        /// <summary>
        /// Get Current Password
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="UserName">UserName</param>
        /// <returns>Return the data as Dataset</returns>

        public static String GetUserNamePassword(ApplicationConnection _appConnection, string UserName)
        {
            string _checkPassword="";
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetUserNamePassword";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "UserName", DbType.String, UserName);
                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        _checkPassword = dataReader.GetString(dataReader.GetOrdinal("Password"));
                    }
                }
                return _checkPassword;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("ChangePassword.cs", "GetUserNamePassword");
            }
            return null;
        }

        #endregion

        #endregion

        #region Private Methods

        private TransactionResult UpdateChangePassword()
        {
            int _returnValue = 0;
            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
            string sqlCommand = "spUpdatePassword";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "UserID", DbType.Int32, _UserID);
            db.AddInParameter(dbCommand, "Password", DbType.String, _Password);
            db.AddParameter(dbCommand, "Return Value", DbType.String, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);
            db.ExecuteNonQuery(dbCommand);
            _returnValue = Convert.ToInt32(db.GetParameterValue(dbCommand, "Return Value"));

            if (_returnValue == -1)
            {
                return new TransactionResult(TransactionStatus.Failure, "Failure Updating User Password.");
            }
            else
            {
                return new TransactionResult(TransactionStatus.Success, "User Password Successfully Updated.");
            }
        }

        #endregion
    }
}

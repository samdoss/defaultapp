using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;  
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.CommonLayer;

namespace ERP.DataLayer
{
    public class ActiveUsers
    {
        #region Private Variables

        private int _conCurrentUsers = 4;
        ApplicationConnection _appConnection = new ApplicationConnection();

        #endregion

        #region Public Methods

        /// <summary>
        /// Get Active Users Count
        /// </summary>
        /// <returns>Return bool</returns>
        public string GetActiveUsersCount()
        {
            string _retVal = "";
            int _usersCount = 0;
            _appConnection = new ApplicationConnection();
            try
            {
                string sqlCommand = "spGetActiveUsersCount";
                Database db = null;
                db =CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader) // (SqlDataReader)db.ExecuteReader(dbCommand))
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        _usersCount = dataReader.GetInt32(dataReader.GetOrdinal("ActiveUserCount"));
                        if (_usersCount > _conCurrentUsers)
                        {
                            _retVal = _conCurrentUsers.ToString() + " has Already Logged in. Only " + _conCurrentUsers.ToString() + " are Allowed to Use the Application Simultaneously";
                        }
                    }
                }
                return _retVal;
            }
            catch { }
            return "Error";
        }

        public TransactionResult AddActiveUser(int UserID)
        {
            int _returnValue = 0;
            string sqlCommand = "spAddActiveUser";
            try
            {
                Database db =CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);

                db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                                DataRowVersion.Default, _returnValue);

                db.ExecuteNonQuery(dbCommand);
                _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

                if (_returnValue == -1)
                    return new TransactionResult(TransactionStatus.Failure);
                else
                    return new TransactionResult(TransactionStatus.Success);
            }
            catch
            {
                return new TransactionResult(TransactionStatus.Failure, "You are Already Logged in");
            }
        }

        public TransactionResult RemoveActiveUser(int UserID)
        {
            int _returnValue = 0;
            string sqlCommand = "spRemoveActiveUser";
            try
            {
                Database db =CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);

                db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                                DataRowVersion.Default, _returnValue);

                db.ExecuteNonQuery(dbCommand);
                _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

                if (_returnValue == -1)
                    return new TransactionResult(TransactionStatus.Failure);
                else
                    return new TransactionResult(TransactionStatus.Success);
            }
            catch
            {
                return new TransactionResult(TransactionStatus.Failure);
            }
        }
        #endregion
    }
}

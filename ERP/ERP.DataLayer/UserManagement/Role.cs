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
    public static class Role
    {

        #region Get Role List

        /// <summary>
        /// Get all User Roles from Role Table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <returns>Return the data as Dataset</returns>

        public static DataSet GetRoleList(ApplicationConnection _appConnection)
        {
            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
            string sqlCommand = "spGetRoleList";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            return db.ExecuteDataSet(dbCommand);
        }

        #endregion

        #region Get Role for Form Level

        /// <summary>
        /// Get Roles for form Level
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="RoleID">Role ID</param>
        /// <returns>Return the data as Dataset</returns>

        public static SqlDataReader GetRoleXFormLevel(ApplicationConnection _appConnection, int RoleID)
        {
            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
            string sqlCommand = "spGetRoleXFormLevel";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "RoleID", DbType.Int32, RoleID);
            return ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader; // (SqlDataReader)db.ExecuteReader(dbCommand))
        }

        #endregion

        #region Get Users Role for Form Level

        /// <summary>
        /// Get Users Roles for form Level
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="RoleID">Role ID</param>
        /// <returns>Return the data as Dataset</returns>

        public static SqlDataReader GetUserRoleXFormLevel(ApplicationConnection _appConnection, int UserID)
        {
            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
            string sqlCommand = "spGetUserRoleXFormLevel";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);
            return ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader; // (SqlDataReader)db.ExecuteReader(dbCommand))
        }

        #endregion

        #region Add Rights for Role

        /// <summary>
        /// Add Rights for Roles To form Level
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="RoleID">Role ID</param>
        /// <param name="FormIDs">User Forms ID</param>
        /// <param name="Rights">Rights for the User</param>
        /// <returns>Return the data as TransactionResult</returns>

        public static TransactionResult AddRoleXRights(ApplicationConnection _appConnection, int RoleID, string FormIDs, string Rights)
        {
            int _returnValue = 0;
            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
            string sqlCommand = "spAddRoleXRights";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "RoleID", DbType.Int32, RoleID);
            db.AddInParameter(dbCommand, "FormLevelIDList", DbType.String, FormIDs);
            db.AddInParameter(dbCommand, "RightsList", DbType.String, Rights);
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);
            db.ExecuteNonQuery(dbCommand);
            _returnValue = Convert.ToInt32(db.GetParameterValue(dbCommand, "Return Value"));

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding User Role");
            else
                return new TransactionResult(TransactionStatus.Success, "User Role Successfully Added.");
        }

        #endregion

        #region Add Rights for Users

        /// <summary>
        /// Add Rights for Users To form Level
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="UserID">User ID</param>
        /// <param name="FormIDs">User Forms ID</param>
        /// <param name="Rights">Rights for the User</param>
        /// <returns>Return the data as TransactionResult</returns>

        public static TransactionResult AddUserXRights(ApplicationConnection _appConnection, int UserID, string FormIDs, string Rights)
        {
            int _returnValue = 0;
            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
            string sqlCommand = "spAddUserXRights";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);
            db.AddInParameter(dbCommand, "FormLevelIDList", DbType.String, FormIDs);
            db.AddInParameter(dbCommand, "RightsList", DbType.String, Rights);
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);
            db.ExecuteNonQuery(dbCommand);
            _returnValue = Convert.ToInt32(db.GetParameterValue(dbCommand, "Return Value"));

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding User Role");
            else
                return new TransactionResult(TransactionStatus.Success, "User Role Successfully Added.");
        }

        #endregion

    }
}

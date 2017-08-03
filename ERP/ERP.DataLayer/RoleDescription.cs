using System.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using ERP.CommonLayer;

namespace ERP.DataLayer
{
    public class RoleDescription
    {
        #region Constructor(s)

        public RoleDescription(){}

        public RoleDescription(int RoleID, bool getAllProperties)
        {
            _RoleID = RoleID;
            if (getAllProperties)
            {
                GetRole();
            }
        }

        #endregion

        #region Private Variables

		ApplicationConnection _appConnection = new ApplicationConnection();
        private int _RoleID;
        private string _Role;
        private bool _IsEnabled;
        private int _AuditUserID;
        private List<RoleDL> _RoleList;

        #endregion

        #region Public Properties

        public int RoleID
        {
            get { return _RoleID; }
            set { _RoleID = value; }
        }

        public string Role
        {
            get { return _Role; }
            set { _Role = value; }
        }

        public int AuditUserID
        {
            get { return _AuditUserID; }
            set { _AuditUserID = value; }
        }

        public bool IsEnabled
        {
            get { return _IsEnabled; }
            set { _IsEnabled = value; }
        }

		public List<RoleDL> RoleList
        {
            get { return _RoleList; }
            set { _RoleList = value; }
        }

        #endregion

        #region Public Methods

        public static DataSet GetRoleList(ApplicationConnection _appConnection)
        {
            try
            {
	            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                //Database db = DatabaseFactory.CreateDatabase(_appConnection.DatabaseName);
                string sqlCommand = "spGetRolesList";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
				//ErrorLog _errorLog = new ErrorLog();
				//_errorLog.ErrorMessage = ex.Message;
				//_errorLog.LogErrorMessageToDB("RoleDescription", "GetRoleList");
            }
            return null;
        }

		public static List<RoleDL> GetEnableDisableRole(ApplicationConnection _appConnection, bool EnableDisable)
        {
			List<RoleDL> _listRole = new List<RoleDL>();
            try
            {
                //Database db = DatabaseFactory.CreateDatabase(_appConnection.DatabaseName);
	            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetEnabledDisabledRoles";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "EnableDisable", DbType.Boolean, EnableDisable);
				using (SqlDataReader DataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)// (SqlDataReader)db.ExecuteReader(dbCommand))
                {
                    if (DataReader.HasRows)
                    {
                        while (DataReader.Read())
                        {
							RoleDL _sRole = new RoleDL();
                            _sRole.RoleID = Convert.ToInt32(DataReader["RoleID"].ToString());
                            _sRole.Roles = DataReader.GetString(DataReader.GetOrdinal("Role"));
                            _sRole.IsEnabled = DataReader.GetBoolean(DataReader.GetOrdinal("IsEnabled"));
                            _listRole.Add(_sRole);
                        }
                    }
                }
                return _listRole;
            }
            catch (Exception ex)
            {
				//ErrorLog _errorLog = new ErrorLog();
				//_errorLog.ErrorMessage = ex.Message;
				//_errorLog.LogErrorMessageToDB("RoleDescription", "GetEnableDisableRoles");
            }
            return _listRole;
        }

        public static TransactionResult EnableDisableRole(ApplicationConnection _appConnection, int RoleID, bool EnableDisable)
        {
            int _returnValue = 0;
            //Database db = DatabaseFactory.CreateDatabase(_appConnection.DatabaseName);
	        Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
            string sqlCommand = "spEnableDisableRoles";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "RoleID", DbType.Int32, RoleID);
            db.AddInParameter(dbCommand, "EnableDisable", DbType.Boolean, EnableDisable);

            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);

            db.ExecuteNonQuery(dbCommand);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure);
            else
                return new TransactionResult(TransactionStatus.Success);
        }

        public TransactionResult Commit(ScreenMode screenMode)
        {
            TransactionResult _result = null;

			//DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory());
            //Database db = DatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
			Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    switch (screenMode)
                    {
                        case ScreenMode.Add:
                            if (_RoleList != null)
                            {
								foreach (RoleDL _StructsRole in _RoleList)
                                {
                                    _result = AddRole(_StructsRole, db, transaction);
                                    if (_result.Status == TransactionStatus.Failure)
                                    {
                                        transaction.Rollback();
                                        return _result;
                                    }
                                }
                            }
                            break;
                        case ScreenMode.Edit:
							foreach (RoleDL _StructsRole in _RoleList)
                            {
                                _result = UpdateRole(_StructsRole, db, transaction);
                                if (_result.Status == TransactionStatus.Failure)
                                {
                                    transaction.Rollback();
                                    return _result;
                                }
                            }
                            break;
                        case ScreenMode.Delete:
							foreach (RoleDL _StructsRole in _RoleList)
                            {
                                _result = DeleteRole(_StructsRole, db, transaction);
                                if (_result.Status == TransactionStatus.Failure)
                                {
                                    transaction.Rollback();
                                    return _result;
                                }
                            }
                            break;
                    }
                    transaction.Commit();
                    return _result;
                }
                catch
                {
                    transaction.Rollback();
                    if (screenMode == ScreenMode.Add)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Adding Role Description.");
                    if (screenMode == ScreenMode.Edit)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Updating Role Description.");
                    if (screenMode == ScreenMode.Delete)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Role Description.");
                }
            }
            return null;
        }

        #endregion

        #region Private Methods

		private TransactionResult AddRole(RoleDL _StructsRole, Database db, DbTransaction transaction)
        {
            int _returnValue = 0;
            string sqlCommand = "spAddRoles";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "Role", DbType.String, _StructsRole.Roles);
            db.AddInParameter(dbCommand, "AuditUserID", DbType.Int32, _StructsRole.AuditUserID);
            db.AddInParameter(dbCommand, "IsEnabled", DbType.Boolean, _StructsRole.IsEnabled);
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding Role Description.");
            else
                return new TransactionResult(TransactionStatus.Success, "Role Description Successfully Added.");
        }

        private TransactionResult UpdateRole(RoleDL _StructsRole, Database db, DbTransaction transaction)
        {
            int _returnValue = 0;
            string sqlCommand = "spUpdateRoles";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "RoleID", DbType.Int32, _StructsRole.RoleID);
            db.AddInParameter(dbCommand, "Role", DbType.String, _StructsRole.Roles);
            db.AddInParameter(dbCommand, "AuditUserID", DbType.Int32, _StructsRole.AuditUserID);

            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Updating Role Description.");
            else
                return new TransactionResult(TransactionStatus.Success, "Role Description Successfully Updated.");
        }

		private TransactionResult DeleteRole(RoleDL _StructsRole, Database db, DbTransaction transaction)
        {
            int _returnValue = 0;
            string sqlCommand = "spDeleteRoles";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "RoleID", DbType.Int32, _StructsRole.RoleID);
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Role Description.");
            else
                return new TransactionResult(TransactionStatus.Success, "Role Description Successfully Deleted.");
        }

        private void GetRole()
        {
            try
            {
	            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                //Database db = DatabaseFactory.CreateDatabase(_appConnection.DatabaseName);
                string sqlCommand = "spGetRoles";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "RoleID", DbType.Int32, _RoleID);
				using (SqlDataReader DataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)// (SqlDataReader)db.ExecuteReader(dbCommand))
                {
                    if (DataReader.HasRows)
                    {
                        while (DataReader.Read())
                        {
                            RoleID = DataReader.GetInt32(DataReader.GetOrdinal("RoleID"));
                            Role = DataReader.GetString(DataReader.GetOrdinal("Role"));
                            IsEnabled = DataReader.GetBoolean(DataReader.GetOrdinal("IsEnabled"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
				//ErrorLog _errorLog = new ErrorLog();
				//_errorLog.ErrorMessage = ex.Message;
				//_errorLog.LogErrorMessageToDB("RoleDescription", "GetEnableDisableRoles");
            }
        }

        #endregion

    }
}

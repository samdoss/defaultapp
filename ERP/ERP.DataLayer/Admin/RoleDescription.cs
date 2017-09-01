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
        private List<RoleDescription> _RoleList;

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

        public List<RoleDescription> RoleList
        {
            get { return _RoleList; }
            set { _RoleList = value; }
        }

        #endregion

        #region Public Methods



        public SqlDataReader FindUsers(string searchText)
        {
            Database db =CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
            string sqlCommand = "spFindUsers";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "UserName", DbType.String, searchText);
            return ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader; // (SqlDataReader)db.ExecuteReader(dbCommand))
           
        }

	    public SqlDataReader FindSupplier(string searchText)
	    {
		    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
		    string sqlCommand = "spFindSupplier";
		    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			db.AddInParameter(dbCommand, "SearchKeyword", DbType.String, searchText);
		    return ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader; // (SqlDataReader)db.ExecuteReader(dbCommand))

	    }

        public static DataSet GetRoleList(ApplicationConnection _appConnection)
        {
            try
            {
	            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                //Database db =CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetRolesList";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
				//
				//
				//ErrorLog.LogErrorMessageToDB("RoleDescription", "GetRoleList");
            }
            return null;
        }

        public static List<RoleDescription> GetEnableDisableRole(ApplicationConnection _appConnection, bool EnableDisable)
        {
            List<RoleDescription> _listRole = new List<RoleDescription>();
            try
            {
                //Database db =CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
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
                            RoleDescription _sRole = new RoleDescription();
                            _sRole.RoleID = Convert.ToInt32(DataReader["RoleID"].ToString());
                            _sRole.Role = DataReader.GetString(DataReader.GetOrdinal("Role"));
                            _sRole.IsEnabled = DataReader.GetBoolean(DataReader.GetOrdinal("IsEnabled"));
                            _listRole.Add(_sRole);
                        }
                    }
                }
                return _listRole;
            }
            catch (Exception ex)
            {
				//
				//
				//ErrorLog.LogErrorMessageToDB("RoleDescription", "GetEnableDisableRoles");
            }
            return _listRole;
        }

        public static TransactionResult EnableDisableRole(ApplicationConnection _appConnection, int RoleID, bool EnableDisable)
        {
            int _returnValue = 0;
            //Database db =CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
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
                                foreach (RoleDescription _StructsRole in _RoleList)
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
                            foreach (RoleDescription _StructsRole in _RoleList)
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
                            foreach (RoleDescription _StructsRole in _RoleList)
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

        private TransactionResult AddRole(RoleDescription _StructsRole, Database db, DbTransaction transaction)
        {
            int _returnValue = 0;
            string sqlCommand = "spAddRoles";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "Role", DbType.String, _StructsRole.Role);
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

        private TransactionResult UpdateRole(RoleDescription _StructsRole, Database db, DbTransaction transaction)
        {
            int _returnValue = 0;
            string sqlCommand = "spUpdateRoles";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "RoleID", DbType.Int32, _StructsRole.RoleID);
            db.AddInParameter(dbCommand, "Role", DbType.String, _StructsRole.Role);
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

        private TransactionResult DeleteRole(RoleDescription _StructsRole, Database db, DbTransaction transaction)
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
                //Database db =CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
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
                ErrorLog.LogErrorMessageToDB("RoleDescription", "GetEnableDisableRoles", "", ex.Message);
            }
        }

        #endregion

    }
}

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
    public class UnitDescription
    {
        #region Constructor(s)

        public UnitDescription(){}

        public UnitDescription(int UnitID, bool getAllProperties)
        {
            _UnitID = UnitID;
            if (getAllProperties)
            {
                GetUnit();
            }
        }

        #endregion

        #region Private Variables

        ApplicationConnection _appConnection = new ApplicationConnection();
        private int _UnitID;
        private string _Unit;
        private bool _IsEnabled;
        private int _AuditUserID;
        private List<UnitDescription> _UnitList;

        #endregion

        #region Public Properties

        public int UnitID
        {
            get { return _UnitID; }
            set { _UnitID = value; }
        }

        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
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

        public List<UnitDescription> UnitList
        {
            get { return _UnitList; }
            set { _UnitList = value; }
        }

        #endregion

        #region Public Methods

        public static DataSet GetUnitList(ApplicationConnection _appConnection)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetUnitsList";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("UnitDescription", "GetUnitList");
            }
            return null;
        }

        public static List<UnitDescription> GetEnableDisableUnit(ApplicationConnection _appConnection, bool EnableDisable)
        {
            List<UnitDescription> _listUnit = new List<UnitDescription>();
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetEnabledDisabledUnits";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "EnableDisable", DbType.Boolean, EnableDisable);
                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            UnitDescription _sUnit = new UnitDescription();
                            _sUnit.UnitID = Convert.ToInt32(dataReader["UnitID"].ToString());
                            _sUnit.Unit = dataReader.GetString(dataReader.GetOrdinal("Unit"));
                            _sUnit.IsEnabled = dataReader.GetBoolean(dataReader.GetOrdinal("IsEnabled"));
                            _listUnit.Add(_sUnit);
                        }
                    }
                }
                return _listUnit;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("UnitDescription", "GetEnableDisableUnits");
            }
            return _listUnit;
        }

        public static TransactionResult EnableDisableUnit(ApplicationConnection _appConnection, int UnitID, bool EnableDisable)
        {
            int _returnValue = 0;
            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
            string sqlCommand = "spEnableDisableUnits";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "UnitID", DbType.Int32, UnitID);
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
                            if (_UnitList != null)
                            {
                                foreach (UnitDescription _StructsUnit in _UnitList)
                                {
                                    _result = AddUnit(_StructsUnit, db, transaction);
                                    if (_result.Status == TransactionStatus.Failure)
                                    {
                                        transaction.Rollback();
                                        return _result;
                                    }
                                }
                            }
                            break;
                        case ScreenMode.Edit:
                            foreach (UnitDescription _StructsUnit in _UnitList)
                            {
                                _result = UpdateUnit(_StructsUnit, db, transaction);
                                if (_result.Status == TransactionStatus.Failure)
                                {
                                    transaction.Rollback();
                                    return _result;
                                }
                            }
                            break;
                        case ScreenMode.Delete:
                            foreach (UnitDescription _StructsUnit in _UnitList)
                            {
                                _result = DeleteUnit(_StructsUnit, db, transaction);
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
                        return new TransactionResult(TransactionStatus.Failure, "Failure Adding Unit Description.");
                    if (screenMode == ScreenMode.Edit)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Updating Unit Description.");
                    if (screenMode == ScreenMode.Delete)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Unit Description.");
                }
            }
            return null;
        }

        #endregion

        #region Private Methods

        private TransactionResult AddUnit(UnitDescription _StructsUnit, Database db, DbTransaction transaction)
        {
            int _returnValue = 0;
            string sqlCommand = "spAddUnits";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "Unit", DbType.String, _StructsUnit.Unit);
            db.AddInParameter(dbCommand, "AuditUserID", DbType.Int32, _StructsUnit.AuditUserID);
            db.AddInParameter(dbCommand, "IsEnabled", DbType.Boolean, _StructsUnit.IsEnabled);
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding Unit Description.");
            else
                return new TransactionResult(TransactionStatus.Success, "Unit Description Successfully Added.");
        }

        private TransactionResult UpdateUnit(UnitDescription _StructsUnit, Database db, DbTransaction transaction)
        {
            int _returnValue = 0;
            string sqlCommand = "spUpdateUnits";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "UnitID", DbType.Int32, _StructsUnit.UnitID);
            db.AddInParameter(dbCommand, "Unit", DbType.String, _StructsUnit.Unit);
            db.AddInParameter(dbCommand, "AuditUserID", DbType.Int32, _StructsUnit.AuditUserID);

            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Updating Unit Description.");
            else
                return new TransactionResult(TransactionStatus.Success, "Unit Description Successfully Updated.");
        }

        private TransactionResult DeleteUnit(UnitDescription _StructsUnit, Database db, DbTransaction transaction)
        {
            int _returnValue = 0;
            string sqlCommand = "spDeleteUnits";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "UnitID", DbType.Int32, _StructsUnit.UnitID);
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Unit Description.");
            else
                return new TransactionResult(TransactionStatus.Success, "Unit Description Successfully Deleted.");
        }

        private void GetUnit()
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetUnits";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "UnitID", DbType.Int32, _UnitID);
                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            UnitID = dataReader.GetInt32(dataReader.GetOrdinal("UnitID"));
                            Unit = dataReader.GetString(dataReader.GetOrdinal("Unit"));
                            IsEnabled = dataReader.GetBoolean(dataReader.GetOrdinal("IsEnabled"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("UnitDescription", "GetEnableDisableUnits");
            }
        }

        #endregion
    }
}
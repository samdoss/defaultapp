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
    public class BillDescription
    {
        #region Constructor(s)

        public BillDescription(){}

        public BillDescription(string BillCode,bool getAllProperties) 
        {
            _BillCode = BillCode;
            if (getAllProperties)
            {
                GetBillDescription();
            }
        }

        #endregion

        #region Private Variables

        ApplicationConnection _appConnection = new ApplicationConnection();
        private int _BillDescriptionID;
        private string _BillCode;
        private string _Description;
        private decimal _Price;
        private decimal _Total;        
        private decimal _ServiceTax;
        private bool _IsEnabled;
        private int _AuditUserID;
        private List<BillDescription> _BillMaster;

        #endregion

        #region Public Properties

        public int BillDescriptionID
        {
            get { return _BillDescriptionID; }
            set { _BillDescriptionID = value; }
        }

        public string BillCode
        {
            get { return _BillCode; }
            set { _BillCode = value; }

        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        

        public decimal ServiceTax
        {
            get { return _ServiceTax; }
            set { _ServiceTax = value; }
        }

        public bool IsEnabled
        {
            get { return _IsEnabled; }
            set { _IsEnabled = value; }
        }

        public int AuditUserID
        {
            get { return _AuditUserID; }
            set { _AuditUserID = value; }
        }

        public List<BillDescription> BillMaster
        {
            get { return _BillMaster; }
            set { _BillMaster = value; }
        }

        #endregion

        #region Public Methods

        public static List<BillDescription> GetEnableDisableBills(ApplicationConnection _appConnection, bool EnableDisable)
        {
            List<BillDescription> _listBillMaster = new List<BillDescription>();
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetEnabledDisabledBills";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "EnableDisable", DbType.Boolean, EnableDisable);
                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            BillDescription _sBillMaster = new BillDescription();
                            _sBillMaster.BillDescriptionID = dataReader.GetInt32(dataReader.GetOrdinal("BillDescriptionID"));
                            _sBillMaster.BillCode = dataReader.GetString(dataReader.GetOrdinal("BillCode"));
                            _sBillMaster.Description = dataReader.GetString(dataReader.GetOrdinal("BillDescription"));
                            _sBillMaster.Price = Convert.ToDecimal(dataReader["Price"].ToString());
                            _sBillMaster.ServiceTax = Convert.ToDecimal(dataReader["ServiceTax"].ToString());
                            _sBillMaster.IsEnabled = dataReader.GetBoolean(dataReader.GetOrdinal("IsEnabled"));
                            _listBillMaster.Add(_sBillMaster);
                        }
                    }
                }
            }
            catch (Exception ex)
            {   
                ErrorLog.LogErrorMessageToDB("BillDescription", "GetEnableDisableBills");
            }
            return _listBillMaster;
        }

        public static TransactionResult EnableDisableBill(ApplicationConnection _appConnection, int BillDescriptionID, bool EnableDisable)
        {
            int _returnValue = 0;
            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
            string sqlCommand = "spEnableDisableBill";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "BillDescriptionID", DbType.Int32, BillDescriptionID);
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

        public SqlDataReader GetFindBill(string SearchText)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spFindBill";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "Bill", DbType.String, SearchText);
                return ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader; // (SqlDataReader)db.ExecuteReader(dbCommand))
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("FindBill", "GetFindBill");
            }
            return null;
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
                            if (_BillMaster != null)
                            {
                                foreach (BillDescription _StructsBillMaster in _BillMaster)
                                {
                                    _result = AddBill(_StructsBillMaster,db, transaction);
                                    if (_result.Status == TransactionStatus.Failure)
                                    {
                                        transaction.Rollback();
                                        return _result;
                                    }
                                }
                            }
                            break;
                        case ScreenMode.Edit:
                            foreach (BillDescription _StructsBillMaster in _BillMaster)
                            {
                                _result = UpdateBill(_StructsBillMaster, db, transaction);
                                if (_result.Status == TransactionStatus.Failure)
                                {
                                    transaction.Rollback();
                                    return _result;
                                }
                            }
                            break;
                        case ScreenMode.Delete:
                            foreach (BillDescription _StructsBillMaster in _BillMaster)
                            {
                                _result = DeleteBill(_StructsBillMaster, db, transaction);
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
                        return new TransactionResult(TransactionStatus.Failure, "Failure Adding Bill Description.");
                    if (screenMode == ScreenMode.Edit)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Updating Bill Description.");
                    if (screenMode == ScreenMode.Delete)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Bill Description.");
                }
            }
            return _result;
        }

        #endregion

        #region Private Methods

        private TransactionResult AddBill(BillDescription _StructsBillMaster, Database db, DbTransaction transaction)
        {
            int _returnValue = 0;
            string sqlCommand = "spAddBillMaster";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "BillCode", DbType.String, _StructsBillMaster.BillCode);
            db.AddInParameter(dbCommand, "BillDescription", DbType.String, _StructsBillMaster.Description);
            db.AddInParameter(dbCommand, "Price", DbType.Decimal, _StructsBillMaster.Price);
            db.AddInParameter(dbCommand, "ServiceTax", DbType.Decimal, _StructsBillMaster.ServiceTax);
            db.AddInParameter(dbCommand, "AuditUserID", DbType.Int32, _StructsBillMaster.AuditUserID);
            db.AddInParameter(dbCommand, "IsEnabled", DbType.Boolean, _StructsBillMaster.IsEnabled);
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding Bill Description.");
            else
                return new TransactionResult(TransactionStatus.Success, "Bill Description Successfully Added.");
        }

        private TransactionResult UpdateBill(BillDescription _StructsBillMaster, Database db, DbTransaction transaction)
        {
            int _returnValue = 0;
            string sqlCommand = "spUpdateBillMaster";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "BillDescriptionID", DbType.Int32, _StructsBillMaster.BillDescriptionID);
            db.AddInParameter(dbCommand, "BillCode", DbType.String, _StructsBillMaster.BillCode);
            db.AddInParameter(dbCommand, "BillDescription", DbType.String, _StructsBillMaster.Description);
            db.AddInParameter(dbCommand, "Price", DbType.Decimal, _StructsBillMaster.Price);
            db.AddInParameter(dbCommand, "ServiceTax", DbType.Decimal, _StructsBillMaster.ServiceTax);
            db.AddInParameter(dbCommand, "AuditUserID", DbType.Int32, _StructsBillMaster.AuditUserID);

            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Updating Bill Description.");
            else
                return new TransactionResult(TransactionStatus.Success, "Bill Description Successfully Updated.");
        }

        private TransactionResult DeleteBill(BillDescription _StructsBillMaster, Database db, DbTransaction transaction)
        {
            int _returnValue = 0;
            string sqlCommand = "spDeleteBillMaster";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "BillDescriptionID", DbType.Int32, _StructsBillMaster.BillDescriptionID);
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Bill Description.");
            else
                return new TransactionResult(TransactionStatus.Success, "Bill Description Successfully Deleted.");
        }

        private void GetBillDescription()
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetBillMaster";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "BillCode", DbType.String, _BillCode);
                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            BillDescriptionID = dataReader.GetInt32(dataReader.GetOrdinal("BillDescriptionID"));
                            BillCode = dataReader.GetString(dataReader.GetOrdinal("BillCode"));
                            Description = dataReader.GetString(dataReader.GetOrdinal("BillDescription"));
                            Price = Convert.ToDecimal(dataReader["Price"].ToString());
                            ServiceTax = Convert.ToDecimal(dataReader["ServiceTax"].ToString());
                            IsEnabled = dataReader.GetBoolean(dataReader.GetOrdinal("IsEnabled"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("BillDescription", "GetBillDescription.");
            }
        }
        #endregion
    }
}

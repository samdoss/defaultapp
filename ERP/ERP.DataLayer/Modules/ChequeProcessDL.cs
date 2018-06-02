using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.CommonLayer;
using System.Data;

namespace ERP.DataLayer
{
    public class ChequeProcessDL
    {
        private ApplicationConnection _myConnection;

        public int ChequeDepositID { get; set; }
        public int SupplierID { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ChequeDepositDate { get; set; }
        public int BankAccountID { get; set; }
        public string BankAccountName { get; set; }
        public string ChequeNo { get; set; }
        public decimal ChequeAmount { get; set; }
        public DateTime ChequeProcessDate { get; set; }
        public bool IsChequeProcessed { get; set; }
        public bool IsChequeFails { get; set; }
        public string Comments { get; set; }
        public int AuditUserID { get; set; }
        public DateTime AuditDate { get; set; }
        public int AddEditOption { get; set; }
        public int CompanyID { get; set; }
        public string SupplierName { get; set; }
        public string SupplierCompanyName { get; set; }
        public ScreenMode ScreenMode { get; set; }
        public string CompanyName { get; set; }

        public bool IsDelete { get; set; }

        public ChequeProcessDL()
            : base()
        {
            _myConnection = new ApplicationConnection();
            SupplierName = "";
            SupplierCompanyName = "";

            AddEditOption = 0;
        }

        public ChequeProcessDL(int chequeDepositID, int supplierID, int companyID, bool allProperties)
            : base()
        {
            _myConnection = new ApplicationConnection();
            SupplierName = "";
            SupplierCompanyName = "";

            AddEditOption = 0;
            ChequeDepositID = chequeDepositID;
            SupplierID = supplierID;
            CompanyID = companyID;
            if (allProperties)
            {
                GetChequeDepositInformation(ChequeDepositID);
            }
        }

        public ChequeProcessDL(int chequeDepositID, int companyID, bool allProperties)
            : base()
        {
            _myConnection = new ApplicationConnection();
            SupplierName = "";
            SupplierCompanyName = "";
            AddEditOption = 0;
            ChequeDepositID = chequeDepositID;          
            CompanyID = companyID;
            if (allProperties)
            {
                GetChequeDepositInformation(ChequeDepositID);
            }
        }

        private TransactionResult AddChequeDeposit(Database db, DbTransaction transaction)
        {
            string sqlCommand = "usp_ChequeDeposit_Insert";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            
            db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, CompanyID);
            db.AddInParameter(dbCommand, "SupplierID", DbType.Int32, SupplierID);
            db.AddInParameter(dbCommand, "EntryDate", DbType.DateTime, EntryDate);
            db.AddInParameter(dbCommand, "ChequeDepositDate", DbType.DateTime, ChequeDepositDate);            
            db.AddInParameter(dbCommand, "BankAccountID", DbType.Int32, BankAccountID);            
            db.AddInParameter(dbCommand, "ChequeNo", DbType.String, ChequeNo);
            db.AddInParameter(dbCommand, "ChequeAmount", DbType.Decimal, ChequeAmount);
            db.AddInParameter(dbCommand, "ChequeProcessDate", DbType.DateTime, ChequeProcessDate);
            db.AddInParameter(dbCommand, "IsChequeProcessed", DbType.Boolean, IsChequeProcessed);
            db.AddInParameter(dbCommand, "IsChequeFails", DbType.Boolean, IsChequeFails);
            db.AddInParameter(dbCommand, "IsDelete", DbType.Boolean, false);
            db.AddInParameter(dbCommand, "Comments", DbType.String, Comments);
            db.AddInParameter(dbCommand, "AuditUserID", DbType.Int32, Convert.ToInt32(AuditUserID));

            int returnValue = 0;
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                DataRowVersion.Default, returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding Cheque Deposit.");
            else
            {
                ChequeDepositID = returnValue;
                return new TransactionResult(TransactionStatus.Success, "Cheque Deposit Successfully Added.");
            }
        }

        private TransactionResult UpdateChequeDeposit(Database db, DbTransaction transaction)
        {

            string sqlCommand = "usp_ChequeDeposit_Update";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "ChequeDepositID", DbType.Int32, ChequeDepositID);
            db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, CompanyID);
            db.AddInParameter(dbCommand, "SupplierID", DbType.Int32, SupplierID);
            db.AddInParameter(dbCommand, "EntryDate", DbType.DateTime, EntryDate);
            db.AddInParameter(dbCommand, "ChequeDepositDate", DbType.DateTime, ChequeDepositDate);
            db.AddInParameter(dbCommand, "BankAccountID", DbType.Int32, BankAccountID);
            db.AddInParameter(dbCommand, "ChequeNo", DbType.String, ChequeNo);
            db.AddInParameter(dbCommand, "ChequeAmount", DbType.Decimal, ChequeAmount);
            db.AddInParameter(dbCommand, "ChequeProcessDate", DbType.DateTime, ChequeProcessDate);
            db.AddInParameter(dbCommand, "IsChequeProcessed", DbType.Boolean, IsChequeProcessed);
            db.AddInParameter(dbCommand, "IsChequeFails", DbType.Boolean, IsChequeFails);
            db.AddInParameter(dbCommand, "Comments", DbType.String, Comments);
            db.AddInParameter(dbCommand, "AuditUserID", DbType.Int32, Convert.ToInt32(AuditUserID));

            int returnValue = -1;
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                DataRowVersion.Default, returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Updating Cheque Deposit Information.");
            else
            {
                ChequeDepositID = returnValue;
                return new TransactionResult(TransactionStatus.Success, "Cheque Deposit Information Successfully Updated.");
            }
        }

        private TransactionResult DeactivateChequeDeposit(Database db, DbTransaction transaction)
        {

            string sqlCommand = "usp_ChequeDeposit_Deactivate";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "ChequeDepositID", DbType.Int32, ChequeDepositID);
            int returnValue = -1;
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                DataRowVersion.Default, returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Cheque Deposit Information.");
            else
                return new TransactionResult(TransactionStatus.Success, "Cheque Deposit Information Successfully Deleted.");
        }

        #region Public Methods

        public TransactionResult Commit(ScreenMode screenMode)
        {
            TransactionResult _result = null;
            Database db = CustomDatabaseFactory.CreateDatabase(_myConnection.ConnectionString);
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    switch (screenMode)
                    {
                        case ScreenMode.Add:
                            _result = AddChequeDeposit(db, transaction);
                            if (_result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return _result;
                            }
                            break;
                        case ScreenMode.Edit:

                            _result = UpdateChequeDeposit(db, transaction);
                            if (_result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return _result;
                            }

                            break;
                        case ScreenMode.Delete:

                            _result = DeactivateChequeDeposit(db, transaction);
                            if (_result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return _result;
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
                        return new TransactionResult(TransactionStatus.Failure, "Failure Adding Cheque Deposit.");
                    if (screenMode == ScreenMode.Edit)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Updating Cheque Deposit.");
                    if (screenMode == ScreenMode.Delete)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Cheque Deposit.");
                }
            }
            return null;
        }

        #endregion


        public DataSet GetChequeDepositDetails(int supplierID, int companyID, string searchText)
        {
            DataSet dataSet = new DataSet();
            try
            {
                Database database = CustomDatabaseFactory.CreateDatabase(_myConnection.ConnectionString);
                DbCommand dbCommand = database.GetStoredProcCommand("usp_ChequeDeposit_GetChequeDeposit");
                dbCommand.Parameters.Clear();
                dbCommand.CommandTimeout = 300;
                database.AddInParameter(dbCommand, "SupplierID", System.Data.DbType.Int32, supplierID);
                database.AddInParameter(dbCommand, "CompanyID", System.Data.DbType.Int32, companyID);
                database.AddInParameter(dbCommand, "SearchText", System.Data.DbType.String, searchText);
                dataSet = database.ExecuteDataSet(dbCommand);
            }
            catch (Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "ChequeDepositDL.cs", "GetChequeDepositDetails", exception1.Message.ToString());
                throw;
            }
            return dataSet;
        }

        public DataSet GetAllChequeDeposit()
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_myConnection.ConnectionString);
                string sqlCommand = "usp_ChequeDeposit_GetAllChequeDeposit";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("ChequeDepositDL", "GetAllChequeDeposit", "", ex.Message);
            }
            return null;
        }

        public List<ChequeProcessDL> GetAllChequeDepositList(int companyID)
        {
            try
            {
                List<ChequeProcessDL> chequeDepositList = new List<ChequeProcessDL>();
                Database db = CustomDatabaseFactory.CreateDatabase(_myConnection.ConnectionString);
                string sqlCommand = "usp_ChequeDeposit_GetAllChequeDepositByCompany";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "CompanyID", System.Data.DbType.Int32, companyID);
                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    ChequeProcessDL obj = new ChequeProcessDL();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            obj = new ChequeProcessDL();

                            obj.ChequeDepositID = dataReader.GetInt32(dataReader.GetOrdinal("ChequeDepositID"));
                            obj.CompanyID = dataReader.GetInt32(dataReader.GetOrdinal("CompanyID"));
                            obj.SupplierID = dataReader.GetInt32(dataReader.GetOrdinal("SupplierID"));
                            obj.SupplierCompanyName = dataReader.GetString(dataReader.GetOrdinal("SupplierCompanyName"));
                            obj.EntryDate = dataReader.GetDateTime(dataReader.GetOrdinal("EntryDate"));
                            obj.ChequeDepositDate = dataReader.GetDateTime(dataReader.GetOrdinal("ChequeDepositDate"));
                            obj.BankAccountID = dataReader.GetInt32(dataReader.GetOrdinal("BankAccountID"));
                            obj.BankAccountName = dataReader.GetString(dataReader.GetOrdinal("BankAccountHolderName"));
                            obj.ChequeNo = dataReader.GetString(dataReader.GetOrdinal("ChequeNo"));
                            obj.ChequeAmount = dataReader.GetDecimal(dataReader.GetOrdinal("ChequeAmount"));
                            obj.ChequeProcessDate = dataReader.GetDateTime(dataReader.GetOrdinal("ChequeProcessDate"));
                            obj.IsChequeProcessed = dataReader.GetBoolean(dataReader.GetOrdinal("IsChequeProcessed"));
                            obj.IsChequeFails = dataReader.GetBoolean(dataReader.GetOrdinal("IsChequeFails"));
                            obj.Comments = dataReader.GetString(dataReader.GetOrdinal("Comments"));
                            obj.IsDelete = dataReader.GetBoolean(dataReader.GetOrdinal("IsDelete"));

                            chequeDepositList.Add(obj);
                        }
                    }

                }
                return chequeDepositList;
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("ChequeDepositDL", "GetAllChequeDepositList", "", ex.Message);
                return null;
            }
        }


        private void GetChequeDepositInformation(int chequeDepositID)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_myConnection.ConnectionString);
                string sqlCommand = "usp_ChequeDeposit_GetChequeDepositDetails";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ChequeDepositID", DbType.Int32, chequeDepositID);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();

                        ChequeDepositID = dataReader.GetInt32(dataReader.GetOrdinal("ChequeDepositID"));
                        CompanyID = dataReader.GetInt32(dataReader.GetOrdinal("CompanyID"));
                        SupplierID = dataReader.GetInt32(dataReader.GetOrdinal("SupplierID"));
                        SupplierCompanyName = dataReader.GetString(dataReader.GetOrdinal("SupplierCompanyName"));
                        EntryDate = dataReader.GetDateTime(dataReader.GetOrdinal("EntryDate"));
                        ChequeDepositDate = dataReader.GetDateTime(dataReader.GetOrdinal("ChequeDepositDate"));
                        BankAccountID = dataReader.GetInt32(dataReader.GetOrdinal("BankAccountID"));
                        BankAccountName = dataReader.GetString(dataReader.GetOrdinal("BankAccountHolderName"));
                        ChequeNo = dataReader.GetString(dataReader.GetOrdinal("ChequeNo"));
                        ChequeAmount = dataReader.GetDecimal(dataReader.GetOrdinal("ChequeAmount"));
                        ChequeProcessDate = dataReader.GetDateTime(dataReader.GetOrdinal("ChequeProcessDate"));                        
                        IsChequeProcessed = dataReader.GetBoolean(dataReader.GetOrdinal("IsChequeProcessed"));
                        IsChequeFails = dataReader.GetBoolean(dataReader.GetOrdinal("IsChequeFails"));                        
                        Comments = dataReader.GetString(dataReader.GetOrdinal("Comments"));
                        IsDelete = dataReader.GetBoolean(dataReader.GetOrdinal("IsDelete"));                        
                        
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("ChequeDepositDL", "GetChequeDepositInformation");
            }
        }
    }
}

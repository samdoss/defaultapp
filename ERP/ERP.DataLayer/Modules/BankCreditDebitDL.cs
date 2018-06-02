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
    public class BankCreditDebitDL
    {
        private ApplicationConnection _myConnection;

        public int BankCreditDebitID { get; set; }
        public int CompanyID { get; set; }
        public ScreenMode ScreenMode { get; set; }
        public string CompanyName { get; set; }
        public DateTime DateProcessed { get; set; }
        public int BankDetailID { get; set; }
        public string BankAccountName { get; set; }
        public string Description { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal DebitAmount { get; set; }
        public bool IsCredit { get; set; }
        public bool IsDebit { get; set; }
        public bool IsDelete { get; set; }
        public int AuditUserID { get; set; }
        public DateTime AuditDate { get; set; }
        public int AddEditOption { get; set; }



        public BankCreditDebitDL()
            : base()
        {
            _myConnection = new ApplicationConnection();

            AddEditOption = 0;
        }
        public BankCreditDebitDL(int bankCreditDebitID, int companyID, bool allProperties)
            : base()
        {
            _myConnection = new ApplicationConnection();
            AddEditOption = 0;
            BankCreditDebitID = bankCreditDebitID;
            CompanyID = companyID;
            if (allProperties)
            {
                GetBankCreditDebitInformation(BankCreditDebitID);
            }
        }

        private TransactionResult AddBankCreditDebit(Database db, DbTransaction transaction)
        {
            string sqlCommand = "usp_BankCreditDebit_Insert";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);


            db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, CompanyID);
            db.AddInParameter(dbCommand, "BankDetailID", DbType.Int32, BankDetailID);
            db.AddInParameter(dbCommand, "DateProcessed", DbType.DateTime, DateProcessed);
            db.AddInParameter(dbCommand, "CreditAmount", DbType.Decimal, CreditAmount);
            db.AddInParameter(dbCommand, "DebitAmount", DbType.Decimal, DebitAmount);
            db.AddInParameter(dbCommand, "Description", DbType.String, Description);
            db.AddInParameter(dbCommand, "IsCredit", DbType.Boolean, IsCredit);
            db.AddInParameter(dbCommand, "IsDebit", DbType.Boolean, IsDebit);
            db.AddInParameter(dbCommand, "IsDelete", DbType.Boolean, false);
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
                BankCreditDebitID = returnValue;
                return new TransactionResult(TransactionStatus.Success, "Cheque Deposit Successfully Added.");
            }
        }

        private TransactionResult UpdateBankCreditDebit(Database db, DbTransaction transaction)
        {

            string sqlCommand = "usp_BankCreditDebit_Update";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "BankCreditDebitID", DbType.Int32, BankCreditDebitID);
            db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, CompanyID);
            db.AddInParameter(dbCommand, "BankDetailID", DbType.Int32, BankDetailID);
            db.AddInParameter(dbCommand, "DateProcessed", DbType.DateTime, DateProcessed);
            db.AddInParameter(dbCommand, "CreditAmount", DbType.Decimal, CreditAmount);
            db.AddInParameter(dbCommand, "DebitAmount", DbType.Decimal, DebitAmount);
            db.AddInParameter(dbCommand, "Description", DbType.String, Description);
            db.AddInParameter(dbCommand, "IsCredit", DbType.Boolean, IsCredit);
            db.AddInParameter(dbCommand, "IsDebit", DbType.Boolean, IsDebit);
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
                BankCreditDebitID = returnValue;
                return new TransactionResult(TransactionStatus.Success, "Cheque Deposit Information Successfully Updated.");
            }
        }

        private TransactionResult DeactivateBankCreditDebit(Database db, DbTransaction transaction)
        {

            string sqlCommand = "usp_BankCreditDebit_Deactivate";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "BankCreditDebitID", DbType.Int32, BankCreditDebitID);
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
                            _result = AddBankCreditDebit(db, transaction);
                            if (_result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return _result;
                            }
                            break;
                        case ScreenMode.Edit:

                            _result = UpdateBankCreditDebit(db, transaction);
                            if (_result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return _result;
                            }

                            break;
                        case ScreenMode.Delete:

                            _result = DeactivateBankCreditDebit(db, transaction);
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
                        return new TransactionResult(TransactionStatus.Failure, "Failure Adding Credit or Debit.");
                    if (screenMode == ScreenMode.Edit)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Updating Credit or Debit.");
                    if (screenMode == ScreenMode.Delete)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Credit or Debit.");
                }
            }
            return null;
        }

        #endregion


        public DataSet GetBankCreditDebitDetails(int bankDetailID, int companyID, string searchText)
        {
            DataSet dataSet = new DataSet();
            try
            {
                Database database = CustomDatabaseFactory.CreateDatabase(_myConnection.ConnectionString);
                DbCommand dbCommand = database.GetStoredProcCommand("usp_BankCreditDebit_GetBankCreditDebit");
                dbCommand.Parameters.Clear();
                dbCommand.CommandTimeout = 300;
                database.AddInParameter(dbCommand, "BankDetailID", System.Data.DbType.Int32, bankDetailID);
                database.AddInParameter(dbCommand, "CompanyID", System.Data.DbType.Int32, companyID);
                database.AddInParameter(dbCommand, "SearchText", System.Data.DbType.String, searchText);
                dataSet = database.ExecuteDataSet(dbCommand);
            }
            catch (Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "BankCreditDebitDL.cs", "GetBankCreditDebitDetails", exception1.Message.ToString());
                throw;
            }
            return dataSet;
        }

        public DataSet GetAllBankCreditDebit()
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_myConnection.ConnectionString);
                string sqlCommand = "usp_BankCreditDebit_GetAllBankCreditDebit";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("BankCreditDebitDL", "GetAllBankCreditDebit", "", ex.Message);
            }
            return null;
        }

        public List<BankCreditDebitDL> GetAllBankCreditDebitList(int companyID)
        {
            try
            {
                List<BankCreditDebitDL> BankCreditDebitList = new List<BankCreditDebitDL>();
                Database db = CustomDatabaseFactory.CreateDatabase(_myConnection.ConnectionString);
                string sqlCommand = "usp_BankCreditDebit_GetAllBankCreditDebitByCompany";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "CompanyID", System.Data.DbType.Int32, companyID);
                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    BankCreditDebitDL obj = new BankCreditDebitDL();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            obj = new BankCreditDebitDL();

                            obj.BankCreditDebitID = dataReader.GetInt32(dataReader.GetOrdinal("BankCreditDebitID"));
                            obj.CompanyID = dataReader.GetInt32(dataReader.GetOrdinal("CompanyID"));
                            obj.BankDetailID = dataReader.GetInt32(dataReader.GetOrdinal("BankDetailID"));
                            obj.DateProcessed = dataReader.GetDateTime(dataReader.GetOrdinal("DateProcessed"));
                            obj.CreditAmount = dataReader.GetDecimal(dataReader.GetOrdinal("CreditAmount"));
                            obj.DebitAmount = dataReader.GetDecimal(dataReader.GetOrdinal("DebitAmount"));

                            obj.IsCredit = dataReader.GetBoolean(dataReader.GetOrdinal("IsCredit"));
                            obj.IsDebit = dataReader.GetBoolean(dataReader.GetOrdinal("IsDebit"));
                            obj.Description = dataReader.GetString(dataReader.GetOrdinal("Description"));
                            obj.IsDelete = dataReader.GetBoolean(dataReader.GetOrdinal("IsDelete"));

                            BankCreditDebitList.Add(obj);
                        }
                    }

                }
                return BankCreditDebitList;
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("BankCreditDebitDL", "GetAllBankCreditDebitList", "", ex.Message);
                return null;
            }
        }


        private void GetBankCreditDebitInformation(int BankCreditDebitID)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_myConnection.ConnectionString);
                string sqlCommand = "usp_BankCreditDebit_GetBankCreditDebitDetails";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "BankCreditDebitID", DbType.Int32, BankCreditDebitID);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();

                        BankCreditDebitID = dataReader.GetInt32(dataReader.GetOrdinal("BankCreditDebitID"));
                        CompanyID = dataReader.GetInt32(dataReader.GetOrdinal("CompanyID"));
                        BankDetailID = dataReader.GetInt32(dataReader.GetOrdinal("BankDetailID"));
                        DateProcessed = dataReader.GetDateTime(dataReader.GetOrdinal("DateProcessed"));
                        CreditAmount = dataReader.GetDecimal(dataReader.GetOrdinal("CreditAmount"));
                        DebitAmount = dataReader.GetDecimal(dataReader.GetOrdinal("DebitAmount"));

                        IsCredit = dataReader.GetBoolean(dataReader.GetOrdinal("IsCredit"));
                        IsDebit = dataReader.GetBoolean(dataReader.GetOrdinal("IsDebit"));
                        Description = dataReader.GetString(dataReader.GetOrdinal("Description"));
                        IsDelete = dataReader.GetBoolean(dataReader.GetOrdinal("IsDelete"));
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("BankCreditDebitDL", "GetBankCreditDebitInformation");
            }
        }
    }
}

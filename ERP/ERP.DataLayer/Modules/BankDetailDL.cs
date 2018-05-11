using ERP.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.DataLayer
{
    public class BankDetailDL
    {
        ApplicationConnection _dbAppConnection = new ApplicationConnection();
        private int _bankDetailID;
        private string _bankAccountHolderName;
        private string _bankAccountNumber;
        private string _bankName;
        private string _iFSCCode;
        private string _branchName;

        public int BankDetailID
        {
            get { return _bankDetailID; }
            set { _bankDetailID = value; }
        }
        public string BankAccountNumber
        {
            get { return _bankAccountNumber; }
            set { _bankAccountNumber = value; }
        }       

        public string IFSCCode
        {
            get { return _iFSCCode; }
            set { _iFSCCode = value; }
        }
       
        public string BankAccountHolderName
        {
            get { return _bankAccountHolderName; }
            set { _bankAccountHolderName = value; }
        }
        public string BranchName
        {
            get { return _branchName; }
            set { _branchName = value; }
        }

        public string BankName
        {
            get { return _bankName; }
            set { _bankName = value; }
        }

        #region Constructor(s)

        public BankDetailDL(){}

        public BankDetailDL(int BankDetailID, bool getallproperties)
        {
            if (getallproperties)
            {
                //Calling private method to get all values from the database
                //Assign the values to local variables
                GetBankDetailInformation(BankDetailID);
            }
        }

        #endregion


        #region Public Methods

        public TransactionResult Commit(ScreenMode screenMode)
        {
            TransactionResult _result = null;
            try
            {
                switch (screenMode)
                {
                    case ScreenMode.Add:
                        _result = AddBankDetails();
                        break;
                    case ScreenMode.Edit:
                        _result = UpdateBankDetails();
                        break;
                }
                return _result;
            }
            catch (Exception ex)
            {                
                ErrorLog.LogErrorMessageToDB("BankDetailDL", "BankDetailDL", "Commit", ex.Message);
            }
            return null;
        }

        #endregion

        public SqlDataReader FindUsers(string searchText)
        {
            Database db = DatabaseFactory.CreateDatabase(_dbAppConnection.DatabaseName);
            string sqlCommand = "spFindBankDetails";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "UserName", DbType.String, searchText);
            //return ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader; 
            return (SqlDataReader)db.ExecuteReader(dbCommand);

        }

        #region Private Methods

        private TransactionResult AddBankDetails()
        {
            Database db = DatabaseFactory.CreateDatabase(_dbAppConnection.DatabaseName);
            string sqlCommand = "spAddBankDetail";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "BankDetailID", DbType.Int32, _bankDetailID);
            db.AddInParameter(dbCommand, "BankAccountHolderName", DbType.String, _bankAccountHolderName);
            db.AddInParameter(dbCommand, "BankAccountNumber", DbType.String, _bankAccountNumber);
            db.AddInParameter(dbCommand, "BankName", DbType.String, _bankName);
            db.AddInParameter(dbCommand, "IFSCCode", DbType.String, _iFSCCode);
            db.AddInParameter(dbCommand, "BranchName", DbType.String, _branchName);


            int returnValue = -1;
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, returnValue);

            db.ExecuteNonQuery(dbCommand);
            returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding Bank Information.");
            else
                return new TransactionResult(TransactionStatus.Success, "Bank Information Successfully Added.");
        }

        private TransactionResult UpdateBankDetails()
        {
            Database db = DatabaseFactory.CreateDatabase(_dbAppConnection.DatabaseName);
            string sqlCommand = "spUpdateBankDetail";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "BankDetailID", DbType.Int32, _bankDetailID);
            db.AddInParameter(dbCommand, "BankAccountHolderName", DbType.String, _bankAccountHolderName);
            db.AddInParameter(dbCommand, "BankAccountNumber", DbType.String, _bankAccountNumber);
            db.AddInParameter(dbCommand, "BankName", DbType.String, _bankName);
            db.AddInParameter(dbCommand, "IFSCCode", DbType.String, _iFSCCode);
            db.AddInParameter(dbCommand, "BranchName", DbType.String, _branchName);


            int returnValue = -1;
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, returnValue);

            db.ExecuteNonQuery(dbCommand);
            returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Updating Bank Details Information.");
            else
                return new TransactionResult(TransactionStatus.Success, "Bank Details Information Successfully Updated.");
        }


        #endregion


        private void GetBankDetailInformation(int bankDetailID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(_dbAppConnection.DatabaseName);
                string sqlCommand = "spGetBankDetailsByID";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "BankDetailID", DbType.Int32, bankDetailID);

                using (SqlDataReader dataReader = (SqlDataReader)db.ExecuteReader(dbCommand))
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        BankDetailID = dataReader.GetInt32(dataReader.GetOrdinal("BankDetailID"));
                        BankAccountHolderName = dataReader.GetString(dataReader.GetOrdinal("BankAccountHolderName"));
                        BankAccountNumber = dataReader.GetString(dataReader.GetOrdinal("BankAccountNumber"));
                        BankName = dataReader.GetString(dataReader.GetOrdinal("BankName"));
                        IFSCCode = dataReader.GetString(dataReader.GetOrdinal("IFSCCode"));
                        BranchName = dataReader.GetString(dataReader.GetOrdinal("BranchName"));                   
			
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("BankDetailDL", "GetBankDetailInformation", "GetBankDetailInformation", ex.Message);
            }
        }
    }
}
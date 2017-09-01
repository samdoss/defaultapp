using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.CommonLayer;     

namespace ERP.DataLayer
{
    public class PatientBilling
    {
        #region Constructor(s)

        public PatientBilling() { }

        public PatientBilling(int PatientBillID, bool getAllProperties)
        {
            _PatientBillID = PatientBillID;
            if (getAllProperties)
            {
                GetPatientBill(_PatientBillID);
            }
        }

        #endregion

        #region Private Variables

        ApplicationConnection _appConnection = new ApplicationConnection();
        private int _PatientID;
        private int _PatientBillID;
        private DateTime _BillDate;
        private int _PaymentModes;
        private string _BillDescriptionCode;
        private string _BillDescription;
        private decimal _GrossAmount;
        private decimal _DiscountAmount;
        private decimal _NetAmount;
        private decimal _PaidAmount;
        private decimal _BalanceDue;
        private int _AuditUserID;
        private DateTime _AuditDate;
        private bool _IsEnabled;
        private List<PaymentMode> _ModeOfPayment;
        private List<PatientBillDetails> _PatientBillDetails;
        private PatientChequePayment _PatientChequePayment;
        private PatientDDPayment _PatientDDPayment;
        private PatientCardPayment _PatientCardPayment;

        #endregion

        #region Public Properties

        public int PatientID
        {
            get { return _PatientID; }
            set { _PatientID = value; } 
        }

        public int PatientBillID
        {
            get { return _PatientBillID; }
            set { _PatientBillID = value; } 
        }

        public int PaymentModes
        {
            get { return _PaymentModes; }
            set { _PaymentModes = value; }
        }

        public string BillDescriptionCode
        {
            get { return _BillDescriptionCode; }
            set { _BillDescriptionCode = value; }
        }

        public string BillDescription
        {
            get { return _BillDescription; }
            set { _BillDescription = value; }
        }

        public DateTime BillDate
        {
            get { return _BillDate; }
            set { _BillDate = value; }
        }

        public decimal GrossAmount
        {
            get { return _GrossAmount; }
            set { _GrossAmount = value; }
        }

        public decimal DiscountAmount
        {
            get { return _DiscountAmount; }
            set { _DiscountAmount = value; }
        }

        public decimal PaidAmount
        {
            get { return _PaidAmount; }
            set { _PaidAmount = value; }
        }

        public decimal BalanceDue
        {
            get { return _BalanceDue; }
            set { _BalanceDue = value; }
        }

        public decimal NetAmount
        {
            get { return _NetAmount; }
            set { _NetAmount = value; }
        }

        public int AuditUserID
        {
            get { return _AuditUserID; }
            set { _AuditUserID = value; }
        }

        public DateTime AuditDate
        {
            get { return _AuditDate; }
            set { _AuditDate = value; }
        }

        public bool IsEnabled
        {
            get { return _IsEnabled; }
            set { _IsEnabled = value; }
        }

        public List<PaymentMode> ModeOfPayment
        {
            get { return _ModeOfPayment; }
            set { _ModeOfPayment = value; }
        }

        public List<PatientBillDetails> PatientBillDetails
        {
            get { return _PatientBillDetails; }
            set { _PatientBillDetails = value; }
        }

        public PatientChequePayment PatientChequePayment
        {
            get { return _PatientChequePayment; }
            set { _PatientChequePayment = value; }
        }

        public PatientDDPayment PatientDDPayment
        {
            get { return _PatientDDPayment; }
            set { _PatientDDPayment = value; }
        }

        public PatientCardPayment PatientCardPayment
        {
            get { return _PatientCardPayment; }
            set { _PatientCardPayment = value; }
        }

        #endregion

        #region Public Methods

        #region Get Previous Bill Dates

        /// <summary>
        /// Get All Previous Bill Dates for the selected patient
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="PatientID">Patient ID</param>
        /// <returns>Return the data as Dataset</returns>

        public static DataSet GetPatientBillDates(ApplicationConnection _appConnection, string PatientID)
        {
            try
                {
                    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                    string sqlCommand = "spGetPatientPreviousBillDetails";
                    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                    db.AddInParameter(dbCommand, "PatientID", DbType.String, PatientID);
                    return db.ExecuteDataSet(dbCommand);
                }
        catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("PatientBilling", "GetPatientBillDates");
            }
        return null;
        }

        #endregion

        #region Get Billing Details

        /// <summary>
        /// Get Billing Detail
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <returns>Return the data as Dataset</returns>

        public static DataSet GetBillingDetails(ApplicationConnection _appConnection, string BillingID)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetPatientBillingDetails";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "BillingID", DbType.String, BillingID);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("PatientBilling", "GetBillingDetails");
            }
            return null;
        }

        #endregion

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
                            _result = AddPatientBill(db, transaction);
                            if (_result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return _result;
                            }
                            if (_PatientBillDetails != null)
                            {
                                foreach (PatientBillDetails _StructsPatientBillDetails in _PatientBillDetails)
                                {
                                    _result = AddPatientBillDetails(_StructsPatientBillDetails, db, transaction);
                                    if (_result.Status == TransactionStatus.Failure)
                                    {
                                        transaction.Rollback();
                                        return _result;
                                    }
                                }
                            }
                            if (_ModeOfPayment != null)
                            {
                                foreach (PaymentMode _PaymentMode in _ModeOfPayment)
                                {
                                    switch (_PaymentMode)
                                    {
                                        case PaymentMode.Cheque:
                                            _result = AddPatientBillChequeDetails(db, transaction);
                                            if (_result.Status == TransactionStatus.Failure)
                                            {
                                                transaction.Rollback();
                                                return _result;
                                            }
                                            break;
                                        case PaymentMode.DemandDraft:
                                            _result = AddPatientBillDDDetails(db, transaction);
                                            if (_result.Status == TransactionStatus.Failure)
                                            {
                                                transaction.Rollback();
                                                return _result;
                                            }
                                            break;
                                        case PaymentMode.CreditOrDebitCard:
                                            _result = AddPatientBillCardDetails(db, transaction);
                                            if (_result.Status == TransactionStatus.Failure)
                                            {
                                                transaction.Rollback();
                                                return _result;
                                            }
                                            break;
                                    }
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
                    return new TransactionResult(TransactionStatus.Failure, "Failure Adding Bill Transaction");
                }
            }
        }

        #endregion

        #region Private Methods

        private TransactionResult AddPatientBill(Database db, DbTransaction transaction)
        {
            string sqlCommand = "spAddPatientBill";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "GrossAmount", DbType.Decimal, _GrossAmount);
            db.AddInParameter(dbCommand, "DiscountAmount", DbType.Decimal, _DiscountAmount);
            db.AddInParameter(dbCommand, "NetAmount", DbType.Decimal, _NetAmount);
            db.AddInParameter(dbCommand, "PaymentMode", DbType.Int32, _PaymentModes);
            db.AddInParameter(dbCommand, "PaidAmount", DbType.Decimal, _PaidAmount);
            db.AddInParameter(dbCommand, "BalanceDue", DbType.Decimal, _BalanceDue);
            db.AddInParameter(dbCommand, "AuditUserID", DbType.Int32, _AuditUserID);
            db.AddInParameter(dbCommand, "PatientID", DbType.Int32, _PatientID);
            

	        db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _PatientBillID);
            db.ExecuteNonQuery(dbCommand, transaction);
            _PatientBillID = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_PatientBillID == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding Bill Transaction");
            else
                return new TransactionResult(TransactionStatus.Success, "Bill Transaction Successfully Added.");
        }

        private TransactionResult AddPatientBillDetails(PatientBillDetails _sPatientBillDetails, Database db, DbTransaction transaction)
        {
            int _returnValue = 0;
            string sqlCommand = "spAddPatientBillDetails";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "PatientBillingID", DbType.Int32, _PatientBillID);
            db.AddInParameter(dbCommand, "BillDescriptionID", DbType.Int32, _sPatientBillDetails.BillDescriptionID);
            db.AddInParameter(dbCommand, "BillCode", DbType.String, _sPatientBillDetails.BillCode);
            db.AddInParameter(dbCommand, "ServiceTax", DbType.Decimal, _sPatientBillDetails.ServiceTax);
            db.AddInParameter(dbCommand, "Price", DbType.Decimal, _sPatientBillDetails.Price);
            db.AddInParameter(dbCommand, "Total", DbType.Decimal, _sPatientBillDetails.Total);

            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);
            db.ExecuteNonQuery(dbCommand, transaction);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding Bill Transaction");
            else
                return new TransactionResult(TransactionStatus.Success, "Bill Transaction Successfully Added.");
        }

        private TransactionResult AddPatientBillChequeDetails(Database db, DbTransaction transaction)
        {
            int _returnValue = 0;
            string sqlCommand = "spAddPatientBillChequeDetails";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "PatientBillingID", DbType.Int32, _PatientBillID);
            db.AddInParameter(dbCommand, "ChequeNumber", DbType.Int32, _PatientChequePayment.ChequeNumber);
            db.AddInParameter(dbCommand, "ChequeDate", DbType.DateTime, _PatientChequePayment.ChequeDate);
            db.AddInParameter(dbCommand, "BankName", DbType.String, _PatientChequePayment.BankName);
            db.AddInParameter(dbCommand, "Place", DbType.String, _PatientChequePayment.Place);
            db.AddInParameter(dbCommand, "Amount", DbType.Decimal, _PatientChequePayment.Amount);

            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);
            db.ExecuteNonQuery(dbCommand, transaction);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding Bill Transaction");
            else
                return new TransactionResult(TransactionStatus.Success, "Bill Transaction Successfully Added.");
        }

        private TransactionResult AddPatientBillDDDetails(Database db, DbTransaction transaction)
        {
            int _returnValue = 0;
            string sqlCommand = "spAddPatientBillDDDetails";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "PatientBillingID", DbType.Int32, _PatientBillID);
            db.AddInParameter(dbCommand, "DDNumber", DbType.Int32, _PatientDDPayment.DDNumber);
            db.AddInParameter(dbCommand, "DDDate", DbType.DateTime, _PatientDDPayment.DDDate);
            db.AddInParameter(dbCommand, "BankName", DbType.String, _PatientDDPayment.BankName);
            db.AddInParameter(dbCommand, "Place", DbType.String, _PatientDDPayment.Place);
            db.AddInParameter(dbCommand, "Amount", DbType.Decimal, _PatientDDPayment.Amount);

            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);
            db.ExecuteNonQuery(dbCommand, transaction);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding Bill Transaction");
            else
                return new TransactionResult(TransactionStatus.Success, "Bill Transaction Successfully Added.");
        }

        private TransactionResult AddPatientBillCardDetails(Database db, DbTransaction transaction)
        {
            int _returnValue = 0;
            string sqlCommand = "spAddPatientBillCardDetails";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "PatientBillingID", DbType.Int32, _PatientBillID);
            db.AddInParameter(dbCommand, "CardType", DbType.Int32, _PatientCardPayment.CardType);
            db.AddInParameter(dbCommand, "CardNumber", DbType.String, _PatientCardPayment.CardNumber);
            db.AddInParameter(dbCommand, "HolderName", DbType.String, _PatientCardPayment.HolderName);
            db.AddInParameter(dbCommand, "Amount", DbType.Decimal, _PatientCardPayment.Amount);

            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);
            db.ExecuteNonQuery(dbCommand, transaction);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding Bill Transaction");
            else
                return new TransactionResult(TransactionStatus.Success, "Bill Transaction Successfully Added.");
        }

        #region Get Patient Billing Details

        /// <summary>
        /// Get Patient Billing Details
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="PatientEncounterID">PatientBillingID</param>
        /// <returns>Return the data as List</returns>

        private void GetPatientBill(int PatientBillingID)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetPatientBill";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "PatientBillingID", DbType.Int32, PatientBillingID);
                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            _BillDate = Convert.ToDateTime(dataReader["BillDate"].ToString());
                            _PaymentModes = dataReader.GetInt32(dataReader.GetOrdinal("PaymentModes"));
                            _DiscountAmount = Convert.ToDecimal(dataReader["DiscountAmount"].ToString());
                            _NetAmount = Convert.ToDecimal(dataReader["NetAmount"].ToString());
                            _GrossAmount = Convert.ToDecimal(dataReader["GrossAmount"].ToString());
                            _PaidAmount = Convert.ToDecimal(dataReader["PaidAmount"].ToString());
                            _BalanceDue = Convert.ToDecimal(dataReader["BalanceDue"].ToString());
                            _IsEnabled = dataReader.GetBoolean(dataReader.GetOrdinal("IsEnabled"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("BillDescription", "GetPatientBill");
            }

        }

        #endregion

        #region Get Patient Billing Details

        /// <summary>
        /// Get Patient Billing Details
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="PatientEncounterID">PatientBillingID</param>
        /// <returns>Return the data as List</returns>

        public static List<PatientBillDetails> GetPatientBillingDetails(ApplicationConnection _appConnection, int PatientBillingID)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetPatientBillDetail";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "PatientBillingID", DbType.Int32, PatientBillingID);
                List<PatientBillDetails> _listBillDetails = new List<PatientBillDetails>();
                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            PatientBillDetails _sBillDetails = new PatientBillDetails();
                            _sBillDetails.BillDescriptionID = Convert.ToInt32(dataReader["BillDescriptionID"].ToString());
                            _sBillDetails.BillCode = dataReader.GetString(dataReader.GetOrdinal("BillCode"));
                            _sBillDetails.BillDescription = dataReader.GetString(dataReader.GetOrdinal("BillDescription"));
                            _sBillDetails.ServiceTax = dataReader.GetDecimal(dataReader.GetOrdinal("ServiceTax"));
                            _sBillDetails.Price = dataReader.GetDecimal(dataReader.GetOrdinal("Price"));
                            _sBillDetails.Total = dataReader.GetDecimal(dataReader.GetOrdinal("Total"));
                            
                            _listBillDetails.Add(_sBillDetails);
                        }
                    }
                }
                return _listBillDetails;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("PatientBilling.cs", "GetPatientBillingDetails");
            }
            return null;
        }

        #endregion

        #region Get Patient Cheque Details

        /// <summary>
        /// Get Patient Cheque Details
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="PatientEncounterID">PatientBillingID</param>
        /// <returns>Return the data as List</returns>

        public static List<PatientChequePayment> GetPatientBillChequeDetails(ApplicationConnection _appConnection, int PatientBillingID)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetPatientBillCheque";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "PatientBillingID", DbType.Int32, PatientBillingID);
                List<PatientChequePayment> _listBillChequeDetails = new List<PatientChequePayment>();
                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {

                            PatientChequePayment _sBillDetails = new PatientChequePayment();
                            _sBillDetails.ChequeNumber = Convert.ToInt32(dataReader["ChequeNumber"].ToString());
                            _sBillDetails.ChequeDate = Convert.ToDateTime(dataReader["ChequeDate"].ToString());
                            _sBillDetails.BankName = dataReader.GetString(dataReader.GetOrdinal("BankName"));
                            _sBillDetails.Place = dataReader.GetString(dataReader.GetOrdinal("Place"));
                            _sBillDetails.Amount = dataReader.GetDecimal(dataReader.GetOrdinal("Amount"));



                            _listBillChequeDetails.Add(_sBillDetails);
                        }
                    }
                }
                return _listBillChequeDetails;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("PatientBilling.cs", "GetPatientBillingChequeDetails");
            }
            return null;
        }

        #endregion

        #region Get Patient DD Details

        /// <summary>
        /// Get Patient DD Details
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="PatientEncounterID">PatientBillingID</param>
        /// <returns>Return the data as List</returns>

        public static List<PatientDDPayment> GetPatientBillDDDetails(ApplicationConnection _appConnection, int PatientBillingID)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetPatientBillDD";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "PatientBillingID", DbType.Int32, PatientBillingID);
                List<PatientDDPayment> _listBillDDDetails = new List<PatientDDPayment>();
                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            PatientDDPayment _sBillDetails = new PatientDDPayment();
                            _sBillDetails.DDNumber = Convert.ToInt32(dataReader["DDNumber"].ToString());
                            _sBillDetails.DDDate = Convert.ToDateTime(dataReader["DDDate"].ToString());
                            _sBillDetails.BankName = dataReader.GetString(dataReader.GetOrdinal("BankName"));
                            _sBillDetails.Place = dataReader.GetString(dataReader.GetOrdinal("Place"));
                            _sBillDetails.Amount = dataReader.GetDecimal(dataReader.GetOrdinal("Amount"));
                            _listBillDDDetails.Add(_sBillDetails);
                        }
                    }
                }
                return _listBillDDDetails;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("PatientBilling.cs", "GetPatientBillingDDDetails");
            }
            return null;
        }

        #endregion

        #region Get Patient Card Details

        /// <summary>
        /// Get Patient Card Details
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="PatientEncounterID">PatientBillingID</param>
        /// <returns>Return the data as List</returns>

        public static List<PatientCardPayment> GetPatientBillCardDetails(ApplicationConnection _appConnection, int PatientBillingID)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetPatientBillCard";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "PatientBillingID", DbType.Int32, PatientBillingID);
                List<PatientCardPayment> _listBillCardDetails = new List<PatientCardPayment>();
                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            PatientCardPayment _sBillDetails = new PatientCardPayment();
                            _sBillDetails.CardType = Convert.ToInt32(dataReader["CardType"].ToString());
                            _sBillDetails.CardNumber = dataReader.GetString(dataReader.GetOrdinal("CardNumber"));
                            _sBillDetails.HolderName = dataReader.GetString(dataReader.GetOrdinal("HolderName"));
                            _sBillDetails.Amount = dataReader.GetDecimal(dataReader.GetOrdinal("Amount"));
                            _listBillCardDetails.Add(_sBillDetails);
                        }
                    }
                }
                return _listBillCardDetails;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("PatientBilling.cs", "GetPatientBillingDDDetails");
            }
            return null;
        }

        #endregion

        #endregion
    }
}

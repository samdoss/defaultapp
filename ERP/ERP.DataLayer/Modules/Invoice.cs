using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using ERP.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERP.DataLayer
{
    public class Invoice
    {
	    ApplicationConnection _appConnection = new ApplicationConnection();

	    public Invoice()
	    {

	    }
		public Invoice(int InvoiceId)
	    {
			GetInvoiceInformation(InvoiceId);
	    }

        public int InvoiceId { get; set; }
        public int CompanyId { get; set; }
        public int ClientId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public string PurchaseOrderNo { get; set; }
        public int PaymentTermId { get; set; }
        public List<InvoiceProduct> InvoiceProductList { get; set; }
        public decimal Discount { get; set; }
        public bool RoundOffTotal { get; set; }
        public bool MarkInvoicePaid { get; set; }
        public int PaymentTypeId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Notes { get; set; }
        public string NotesForClient { get; set; }
        public string PrivateNotes { get; set; }
        public string PaymentStatus { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

	    #region Public Methods

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
							_result = AddInvoice(db, transaction);
						    if (_result.Status == TransactionStatus.Failure)
						    {
							    transaction.Rollback();
							    return _result;
						    }
						    break;
					    case ScreenMode.Edit:

							_result = UpdateInvoice(db, transaction);
						    if (_result.Status == TransactionStatus.Failure)
						    {
							    transaction.Rollback();
							    return _result;
						    }

						    break;
					    case ScreenMode.Delete:

						    _result = DeactivateInvoice(db, transaction);
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
						return new TransactionResult(TransactionStatus.Failure, "Failure Adding Invoice.");
				    if (screenMode == ScreenMode.Edit)
						return new TransactionResult(TransactionStatus.Failure, "Failure Updating Invoice.");
				    if (screenMode == ScreenMode.Delete)
						return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Invoice.");
			    }
		    }
		    return null;
	    }

	    #endregion


	    private TransactionResult AddInvoice(Database db, DbTransaction transaction)
	    {
			string sqlCommand = "usp_Invoice_InsertInvoiceDetails";
		    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			
		    db.AddInParameter(dbCommand, "CompanyId", DbType.Int32, CompanyId);
			db.AddInParameter(dbCommand, "ClientId", DbType.Int32, ClientId);
			db.AddInParameter(dbCommand, "IssueDate", DbType.DateTime, IssueDate);
		    db.AddInParameter(dbCommand, "PurchaseOrderNo", DbType.String, PurchaseOrderNo);
		    db.AddInParameter(dbCommand, "PaymentTermId", DbType.Int32, PaymentTermId);
			db.AddInParameter(dbCommand, "DueDate", DbType.DateTime, DueDate);
			db.AddInParameter(dbCommand, "Discount", DbType.Decimal, Discount);
			db.AddInParameter(dbCommand, "RoundOffTotal", DbType.Boolean, RoundOffTotal);
			db.AddInParameter(dbCommand, "MarkInvoicePaid", DbType.Boolean, MarkInvoicePaid);
		    db.AddInParameter(dbCommand, "PaymentTypeId", DbType.Int32, PaymentTypeId);
		    db.AddInParameter(dbCommand, "AmountPaid", DbType.Decimal, AmountPaid);
		    db.AddInParameter(dbCommand, "PaymentDate", DbType.DateTime, PaymentDate);
		    db.AddInParameter(dbCommand, "PaymentStatus", DbType.String, PaymentStatus);
			db.AddInParameter(dbCommand, "Notes", DbType.String, Notes);
		    db.AddInParameter(dbCommand, "TotalAmount", DbType.Decimal, TotalAmount);
			db.AddInParameter(dbCommand, "NotesForClient", DbType.String, NotesForClient);
			db.AddInParameter(dbCommand, "PrivateNotes", DbType.String, PrivateNotes);
		    db.AddInParameter(dbCommand, "Status", DbType.Boolean, Status);

		    int returnValue = 0;
		    db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
			    DataRowVersion.Default, returnValue);

		    db.ExecuteNonQuery(dbCommand, transaction);
		    returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

		    if (returnValue == -1)
				return new TransactionResult(TransactionStatus.Failure, "Failure Adding Invoice.");
		    else
		    {
			    InvoiceId = returnValue;
				return new TransactionResult(TransactionStatus.Success, "Invoice Successfully Added.");
		    }
	    }

		private TransactionResult UpdateInvoice(Database db, DbTransaction transaction)
	    {

			string sqlCommand = "usp_Invoice_UpdateInvoice";
		    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

		    db.AddInParameter(dbCommand, "InvoiceId", DbType.Int32, InvoiceId);
			db.AddInParameter(dbCommand, "CompanyId", DbType.Int32, CompanyId);
		    db.AddInParameter(dbCommand, "ClientId", DbType.Int32, ClientId);
		    db.AddInParameter(dbCommand, "IssueDate", DbType.DateTime, IssueDate);
		    db.AddInParameter(dbCommand, "PurchaseOrderNo", DbType.String, PurchaseOrderNo);
		    db.AddInParameter(dbCommand, "PaymentTermId", DbType.Int32, PaymentTermId);
		    db.AddInParameter(dbCommand, "DueDate", DbType.DateTime, DueDate);
		    db.AddInParameter(dbCommand, "Discount", DbType.Decimal, Discount);
		    db.AddInParameter(dbCommand, "RoundOffTotal", DbType.Boolean, RoundOffTotal);
		    db.AddInParameter(dbCommand, "MarkInvoicePaid", DbType.Boolean, MarkInvoicePaid);
		    db.AddInParameter(dbCommand, "PaymentTypeId", DbType.Int32, PaymentTypeId);
		    db.AddInParameter(dbCommand, "AmountPaid", DbType.Decimal, AmountPaid);
		    db.AddInParameter(dbCommand, "PaymentDate", DbType.DateTime, PaymentDate);
		    db.AddInParameter(dbCommand, "PaymentStatus", DbType.String, PaymentStatus);
		    db.AddInParameter(dbCommand, "Notes", DbType.String, Notes);
		    db.AddInParameter(dbCommand, "TotalAmount", DbType.Decimal, TotalAmount);
		    db.AddInParameter(dbCommand, "NotesForClient", DbType.String, NotesForClient);
		    db.AddInParameter(dbCommand, "PrivateNotes", DbType.String, PrivateNotes);
		    db.AddInParameter(dbCommand, "Status", DbType.Boolean, Status);

		    int returnValue = -1;
		    db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
			    DataRowVersion.Default, returnValue);

		    db.ExecuteNonQuery(dbCommand, transaction);
		    returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

		    if (returnValue == -1)
				return new TransactionResult(TransactionStatus.Failure, "Failure Updating Invoice Information.");
		    else
		    {
			    InvoiceId = returnValue;
				return new TransactionResult(TransactionStatus.Success, "Invoice Information Successfully Updated.");
		    }
	    }

	    private TransactionResult DeactivateInvoice(Database db, DbTransaction transaction)
	    {

			string sqlCommand = "usp_Invoice_DeactivateInvoice";
		    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

			db.AddInParameter(dbCommand, "InvoiceId", DbType.Int32, InvoiceId);
		    int returnValue = -1;
		    db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
			    DataRowVersion.Default, returnValue);

		    db.ExecuteNonQuery(dbCommand, transaction);
		    returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

		    if (returnValue == -1)
				return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Invoice Information.");
		    else
				return new TransactionResult(TransactionStatus.Success, "Invoice Information Successfully Deleted.");
	    }


	    public DataSet GetAllInvoice()
	    {
		    try
		    {
			    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
			    string sqlCommand = "usp_Invoice_GetAllInvoice";
			    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			    return db.ExecuteDataSet(dbCommand);
		    }
		    catch (Exception ex)
		    {
				ErrorLog.LogErrorMessageToDB("InvoiceDL", "GetAllInvoice", "", ex.Message);
		    }
		    return null;
	    }

		public List<Invoice> GetAllInvoiceList()
	    {
		    try
		    {
				List<Invoice> InvoiceList = new List<Invoice>();
			    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
				string sqlCommand = "usp_Invoice_GetAllInvoices";
			    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

			    using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
			    {
					Invoice obj = new Invoice();
				    if (dataReader.HasRows)
				    {
					    while (dataReader.Read())
					    {
							obj = new Invoice();

							obj.InvoiceId = dataReader.GetInt32(dataReader.GetOrdinal("InvoiceId"));
						    obj.CompanyId = dataReader.GetInt32(dataReader.GetOrdinal("CompanyId"));
						    obj.ClientId = dataReader.GetInt32(dataReader.GetOrdinal("ClientId"));
						    obj.IssueDate = dataReader.GetDateTime(dataReader.GetOrdinal("IssueDate"));
						    obj.DueDate = dataReader.GetDateTime(dataReader.GetOrdinal("DueDate"));
						    obj.PurchaseOrderNo = dataReader.GetString(dataReader.GetOrdinal("PurchaseOrderNo"));
						    obj.PaymentTermId = dataReader.GetInt32(dataReader.GetOrdinal("PaymentTermId"));
						    obj.Discount = dataReader.GetDecimal(dataReader.GetOrdinal("Discount"));
						    obj.RoundOffTotal = dataReader.GetBoolean(dataReader.GetOrdinal("RoundOffTotal"));
						    obj.MarkInvoicePaid = dataReader.GetBoolean(dataReader.GetOrdinal("MarkInvoicePaid"));
						    obj.PaymentTypeId = dataReader.GetInt32(dataReader.GetOrdinal("PaymentTypeId"));
						    obj.AmountPaid = dataReader.GetDecimal(dataReader.GetOrdinal("AmountPaid"));
						    obj.PaymentDate = dataReader.GetDateTime(dataReader.GetOrdinal("PaymentDate"));
						    obj.TotalAmount = dataReader.GetDecimal(dataReader.GetOrdinal("TotalAmount"));
						    obj.Notes = dataReader.GetString(dataReader.GetOrdinal("Notes"));
						    obj.NotesForClient = dataReader.GetString(dataReader.GetOrdinal("NotesForClient"));
						    obj.PrivateNotes = dataReader.GetString(dataReader.GetOrdinal("PrivateNotes"));
						    obj.PaymentStatus = dataReader.GetString(dataReader.GetOrdinal("PaymentStatus"));
						    obj.Status = dataReader.GetBoolean(dataReader.GetOrdinal("Status"));


						    InvoiceList.Add(obj);
					    }
				    }

			    }
				return InvoiceList;
		    }
		    catch (Exception ex)
		    {
				ErrorLog.LogErrorMessageToDB("InvoiceDL", "GetAllInvoiceList", "",ex.Message);
			    return null;
		    }
	    }


		private void GetInvoiceInformation(int invoiceID)
	    {
		    try
		    {
			    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
				string sqlCommand = "usp_Invoice_GetInvoiceDetails";
			    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
				db.AddInParameter(dbCommand, "InvoiceID", DbType.Int32, invoiceID);

			    using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
			    {
				    if (dataReader.HasRows)
				    {
					    dataReader.Read();
						InvoiceId = dataReader.GetInt32(dataReader.GetOrdinal("InvoiceId"));
					    CompanyId = dataReader.GetInt32(dataReader.GetOrdinal("CompanyId"));
					    ClientId = dataReader.GetInt32(dataReader.GetOrdinal("ClientId"));
					    IssueDate = dataReader.GetDateTime(dataReader.GetOrdinal("IssueDate"));
					    DueDate = dataReader.GetDateTime(dataReader.GetOrdinal("DueDate"));
					    PurchaseOrderNo = dataReader.GetString(dataReader.GetOrdinal("PurchaseOrderNo"));
					    PaymentTermId = dataReader.GetInt32(dataReader.GetOrdinal("PaymentTermId"));
					    Discount = dataReader.GetDecimal(dataReader.GetOrdinal("Discount"));
					    RoundOffTotal = dataReader.GetBoolean(dataReader.GetOrdinal("RoundOffTotal"));
					    MarkInvoicePaid = dataReader.GetBoolean(dataReader.GetOrdinal("MarkInvoicePaid"));
					    PaymentTypeId = dataReader.GetInt32(dataReader.GetOrdinal("PaymentTypeId"));
					    AmountPaid = dataReader.GetDecimal(dataReader.GetOrdinal("AmountPaid"));
					    PaymentDate = dataReader.GetDateTime(dataReader.GetOrdinal("PaymentDate"));
					    TotalAmount = dataReader.GetDecimal(dataReader.GetOrdinal("TotalAmount"));
					    Notes = dataReader.GetString(dataReader.GetOrdinal("Notes"));
					    NotesForClient = dataReader.GetString(dataReader.GetOrdinal("NotesForClient"));
					    PrivateNotes = dataReader.GetString(dataReader.GetOrdinal("PrivateNotes"));
					    PaymentStatus = dataReader.GetString(dataReader.GetOrdinal("PaymentStatus"));
					    Status = dataReader.GetBoolean(dataReader.GetOrdinal("Status"));
				    }
			    }
		    }
		    catch (Exception ex)
		    {
				ErrorLog.LogErrorMessageToDB("InvoiceDL", "GetInvoiceInformation");
		    }
	    }
    }
}

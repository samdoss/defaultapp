using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using ERP.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERP.DataLayer
{
    public class Estimate
    {
	    ApplicationConnection _appConnection = new ApplicationConnection();

	    public Estimate()
	    {

	    }
		public Estimate(int EstimateId)
	    {
			GetEstimateInformation(EstimateId);
	    }

        public int EstimateId { get; set; }
        public int CompanyId { get; set; }
        public int ClientId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public string EstimateNo { get; set; }
        public int PaymentTermId { get; set; }
        public List<EstimateProduct> EstimateProductList { get; set; }
        public decimal Discount { get; set; }
        public bool RoundOffTotal { get; set; }
        public bool MarkEstimatePaid { get; set; }
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
							_result = AddEstimate(db, transaction);
						    if (_result.Status == TransactionStatus.Failure)
						    {
							    transaction.Rollback();
							    return _result;
						    }
						    break;
					    case ScreenMode.Edit:

							_result = UpdateEstimate(db, transaction);
						    if (_result.Status == TransactionStatus.Failure)
						    {
							    transaction.Rollback();
							    return _result;
						    }

						    break;
					    case ScreenMode.Delete:

						    _result = DeactivateEstimate(db, transaction);
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
						return new TransactionResult(TransactionStatus.Failure, "Failure Adding Estimate.");
				    if (screenMode == ScreenMode.Edit)
						return new TransactionResult(TransactionStatus.Failure, "Failure Updating Estimate.");
				    if (screenMode == ScreenMode.Delete)
						return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Estimate.");
			    }
		    }
		    return null;
	    }

	    #endregion


	    private TransactionResult AddEstimate(Database db, DbTransaction transaction)
	    {
			string sqlCommand = "usp_Estimate_InsertEstimateDetails";
		    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			
		    db.AddInParameter(dbCommand, "CompanyId", DbType.Int32, CompanyId);
			db.AddInParameter(dbCommand, "ClientId", DbType.Int32, ClientId);
			db.AddInParameter(dbCommand, "IssueDate", DbType.DateTime, IssueDate);
		    db.AddInParameter(dbCommand, "EstimateNo", DbType.String, EstimateNo);
		    db.AddInParameter(dbCommand, "PaymentTermId", DbType.Int32, PaymentTermId);
			db.AddInParameter(dbCommand, "DueDate", DbType.DateTime, DueDate);
			db.AddInParameter(dbCommand, "Discount", DbType.Decimal, Discount);
			db.AddInParameter(dbCommand, "RoundOffTotal", DbType.Boolean, RoundOffTotal);
			db.AddInParameter(dbCommand, "MarkEstimatePaid", DbType.Boolean, MarkEstimatePaid);
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
				return new TransactionResult(TransactionStatus.Failure, "Failure Adding Estimate.");
		    else
		    {
			    EstimateId = returnValue;
				return new TransactionResult(TransactionStatus.Success, "Estimate Successfully Added.");
		    }
	    }

		private TransactionResult UpdateEstimate(Database db, DbTransaction transaction)
	    {

			string sqlCommand = "usp_Estimate_UpdateEstimate";
		    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

		    db.AddInParameter(dbCommand, "EstimateId", DbType.Int32, EstimateId);
			db.AddInParameter(dbCommand, "CompanyId", DbType.Int32, CompanyId);
		    db.AddInParameter(dbCommand, "ClientId", DbType.Int32, ClientId);
		    db.AddInParameter(dbCommand, "IssueDate", DbType.DateTime, IssueDate);
		    db.AddInParameter(dbCommand, "EstimateNo", DbType.String, EstimateNo);
		    db.AddInParameter(dbCommand, "PaymentTermId", DbType.Int32, PaymentTermId);
		    db.AddInParameter(dbCommand, "DueDate", DbType.DateTime, DueDate);
		    db.AddInParameter(dbCommand, "Discount", DbType.Decimal, Discount);
		    db.AddInParameter(dbCommand, "RoundOffTotal", DbType.Boolean, RoundOffTotal);
		    db.AddInParameter(dbCommand, "MarkEstimatePaid", DbType.Boolean, MarkEstimatePaid);
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
				return new TransactionResult(TransactionStatus.Failure, "Failure Updating Estimate Information.");
		    else
		    {
			    EstimateId = returnValue;
				return new TransactionResult(TransactionStatus.Success, "Estimate Information Successfully Updated.");
		    }
	    }

	    private TransactionResult DeactivateEstimate(Database db, DbTransaction transaction)
	    {

			string sqlCommand = "usp_Estimate_DeactivateEstimate";
		    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

			db.AddInParameter(dbCommand, "EstimateId", DbType.Int32, EstimateId);
		    int returnValue = -1;
		    db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
			    DataRowVersion.Default, returnValue);

		    db.ExecuteNonQuery(dbCommand, transaction);
		    returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

		    if (returnValue == -1)
				return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Estimate Information.");
		    else
				return new TransactionResult(TransactionStatus.Success, "Estimate Information Successfully Deleted.");
	    }


	    public DataSet GetAllEstimate()
	    {
		    try
		    {
			    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
			    string sqlCommand = "usp_Estimate_GetAllEstimate";
			    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			    return db.ExecuteDataSet(dbCommand);
		    }
		    catch (Exception ex)
		    {
				ErrorLog.LogErrorMessageToDB("EstimateDL", "GetAllEstimate", "", ex.Message);
		    }
		    return null;
	    }

		public List<Estimate> GetAllEstimateList()
	    {
		    try
		    {
				List<Estimate> EstimateList = new List<Estimate>();
			    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
				string sqlCommand = "usp_Estimate_GetAllEstimates";
			    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

			    using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
			    {
					Estimate obj = new Estimate();
				    if (dataReader.HasRows)
				    {
					    while (dataReader.Read())
					    {
							obj = new Estimate();

							obj.EstimateId = dataReader.GetInt32(dataReader.GetOrdinal("EstimateId"));
						    obj.CompanyId = dataReader.GetInt32(dataReader.GetOrdinal("CompanyId"));
						    obj.ClientId = dataReader.GetInt32(dataReader.GetOrdinal("ClientId"));
						    obj.IssueDate = dataReader.GetDateTime(dataReader.GetOrdinal("IssueDate"));
						    obj.DueDate = dataReader.GetDateTime(dataReader.GetOrdinal("DueDate"));
						    obj.EstimateNo = dataReader.GetString(dataReader.GetOrdinal("EstimateNo"));
						    obj.PaymentTermId = dataReader.GetInt32(dataReader.GetOrdinal("PaymentTermId"));
						    obj.Discount = dataReader.GetDecimal(dataReader.GetOrdinal("Discount"));
						    obj.RoundOffTotal = dataReader.GetBoolean(dataReader.GetOrdinal("RoundOffTotal"));
						    obj.MarkEstimatePaid = dataReader.GetBoolean(dataReader.GetOrdinal("MarkEstimatePaid"));
						    obj.PaymentTypeId = dataReader.GetInt32(dataReader.GetOrdinal("PaymentTypeId"));
						    obj.AmountPaid = dataReader.GetDecimal(dataReader.GetOrdinal("AmountPaid"));
						    obj.PaymentDate = dataReader.GetDateTime(dataReader.GetOrdinal("PaymentDate"));
						    obj.TotalAmount = dataReader.GetDecimal(dataReader.GetOrdinal("TotalAmount"));
						    obj.Notes = dataReader.GetString(dataReader.GetOrdinal("Notes"));
						    obj.NotesForClient = dataReader.GetString(dataReader.GetOrdinal("NotesForClient"));
						    obj.PrivateNotes = dataReader.GetString(dataReader.GetOrdinal("PrivateNotes"));
						    obj.PaymentStatus = dataReader.GetString(dataReader.GetOrdinal("PaymentStatus"));
						    obj.Status = dataReader.GetBoolean(dataReader.GetOrdinal("Status"));


						    EstimateList.Add(obj);
					    }
				    }

			    }
				return EstimateList;
		    }
		    catch (Exception ex)
		    {
				ErrorLog.LogErrorMessageToDB("EstimateDL", "GetAllEstimateList", "",ex.Message);
			    return null;
		    }
	    }


		private void GetEstimateInformation(int EstimateID)
	    {
		    try
		    {
			    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
				string sqlCommand = "usp_Estimate_GetEstimateDetails";
			    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
				db.AddInParameter(dbCommand, "EstimateID", DbType.Int32, EstimateID);

			    using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
			    {
				    if (dataReader.HasRows)
				    {
					    dataReader.Read();
						EstimateId = dataReader.GetInt32(dataReader.GetOrdinal("EstimateId"));
					    CompanyId = dataReader.GetInt32(dataReader.GetOrdinal("CompanyId"));
					    ClientId = dataReader.GetInt32(dataReader.GetOrdinal("ClientId"));
					    IssueDate = dataReader.GetDateTime(dataReader.GetOrdinal("IssueDate"));
					    DueDate = dataReader.GetDateTime(dataReader.GetOrdinal("DueDate"));
					    EstimateNo = dataReader.GetString(dataReader.GetOrdinal("EstimateNo"));
					    PaymentTermId = dataReader.GetInt32(dataReader.GetOrdinal("PaymentTermId"));
					    Discount = dataReader.GetDecimal(dataReader.GetOrdinal("Discount"));
					    RoundOffTotal = dataReader.GetBoolean(dataReader.GetOrdinal("RoundOffTotal"));
					    MarkEstimatePaid = dataReader.GetBoolean(dataReader.GetOrdinal("MarkEstimatePaid"));
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
				ErrorLog.LogErrorMessageToDB("EstimateDL", "GetEstimateInformation");
		    }
	    }
    }
}

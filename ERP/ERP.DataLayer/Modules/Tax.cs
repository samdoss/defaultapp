
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using ERP.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERP.DataLayer
{
    public class Tax
    {
	    ApplicationConnection _appConnection = new ApplicationConnection();

		public Tax(int TaxId)
	    {
			GetTaxInformation(TaxId);
	    }

        public Tax()
        {

        }

        public Tax(int taxId, string taxName)
        {
            this.TaxId = taxId;
            this.TaxName = taxName;
        }
        public int TaxId { get; set; }
        public string TaxName { get; set; }
        public decimal TaxPercentage { get; set; }
        public bool IsDefault { get; set; }
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
						    _result = AddTax(db, transaction);
						    if (_result.Status == TransactionStatus.Failure)
						    {
							    transaction.Rollback();
							    return _result;
						    }
						    break;
					    case ScreenMode.Edit:

						    _result = UpdateTax(db, transaction);
						    if (_result.Status == TransactionStatus.Failure)
						    {
							    transaction.Rollback();
							    return _result;
						    }

						    break;
					    case ScreenMode.Delete:

						    _result = DeactivateTax(db, transaction);
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
					    return new TransactionResult(TransactionStatus.Failure, "Failure Adding Tax.");
				    if (screenMode == ScreenMode.Edit)
					    return new TransactionResult(TransactionStatus.Failure, "Failure Updating Tax.");
				    if (screenMode == ScreenMode.Delete)
					    return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Tax.");
			    }
		    }
		    return null;
	    }

	    #endregion


	    private TransactionResult AddTax(Database db, DbTransaction transaction)
	    {
		    string sqlCommand = "usp_Tax_InsertTaxDetails";
		    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			
			db.AddInParameter(dbCommand, "TaxName", DbType.String, TaxName);
			db.AddInParameter(dbCommand, "TaxPercentage", DbType.Decimal, TaxPercentage);
			db.AddInParameter(dbCommand, "IsDefault", DbType.Boolean, IsDefault);
			db.AddInParameter(dbCommand, "Status", DbType.Boolean, Status);
		    

		    int returnValue = 0;
		    db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
			    DataRowVersion.Default, returnValue);

		    db.ExecuteNonQuery(dbCommand, transaction);
		    returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

		    if (returnValue == -1)
			    return new TransactionResult(TransactionStatus.Failure, "Failure Adding Tax.");
		    else
		    {
			    TaxId = returnValue;
			    return new TransactionResult(TransactionStatus.Success, "Tax Successfully Added.");
		    }
	    }

	    private TransactionResult UpdateTax(Database db, DbTransaction transaction)
	    {

		    string sqlCommand = "usp_Tax_UpdateTax";
		    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

		    db.AddInParameter(dbCommand, "TaxId", DbType.Int32, TaxId);
		    db.AddInParameter(dbCommand, "TaxName", DbType.String, TaxName);
		    db.AddInParameter(dbCommand, "TaxPercentage", DbType.Decimal, TaxPercentage);
		    db.AddInParameter(dbCommand, "IsDefault", DbType.Boolean, IsDefault);
		    db.AddInParameter(dbCommand, "Status", DbType.Boolean, Status);

		    int returnValue = -1;
		    db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
			    DataRowVersion.Default, returnValue);

		    db.ExecuteNonQuery(dbCommand, transaction);
		    returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

		    if (returnValue == -1)
			    return new TransactionResult(TransactionStatus.Failure, "Failure Updating Tax Information.");
		    else
		    {
			    TaxId = returnValue;
			    return new TransactionResult(TransactionStatus.Success, "Tax Information Successfully Updated.");
		    }
	    }

	    private TransactionResult DeactivateTax(Database db, DbTransaction transaction)
	    {

		    string sqlCommand = "usp_Tax_DeactivateTax";
		    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

			db.AddInParameter(dbCommand, "TaxId", DbType.Int32, TaxId);
		    int returnValue = -1;
		    db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
			    DataRowVersion.Default, returnValue);

		    db.ExecuteNonQuery(dbCommand, transaction);
		    returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

		    if (returnValue == -1)
			    return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Tax Information.");
		    else
			    return new TransactionResult(TransactionStatus.Success, "Tax Information Successfully Deleted.");
	    }


	    public DataSet GetAllTax()
	    {
		    try
		    {
			    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
			    string sqlCommand = "usp_Tax_GetAllTaxs";
			    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			    return db.ExecuteDataSet(dbCommand);
		    }
		    catch (Exception ex)
		    {
			    ErrorLog.LogErrorMessageToDB("TaxDL", "GetAllTax", "", ex.Message);
		    }
		    return null;
	    }

	    public List<Tax> GetAllTaxList()
	    {
		    try
		    {
			    List<Tax> TaxList = new List<Tax>();
			    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
			    string sqlCommand = "usp_Tax_GetAllTaxs";
			    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

			    using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
			    {
				    Tax obj = new Tax();
				    if (dataReader.HasRows)
				    {
					    while (dataReader.Read())
					    {
						    obj = new Tax();

							obj.TaxId = dataReader.GetInt32(dataReader.GetOrdinal("TaxId"));
						    obj.TaxName = dataReader.GetString(dataReader.GetOrdinal("TaxName"));
						    obj.TaxPercentage = dataReader.GetDecimal(dataReader.GetOrdinal("TaxPercentage"));
						    obj.IsDefault = dataReader.GetBoolean(dataReader.GetOrdinal("IsDefault"));
						    obj.Status = dataReader.GetBoolean(dataReader.GetOrdinal("Status"));

						    TaxList.Add(obj);
					    }
				    }

			    }
			    return TaxList;
		    }
		    catch (Exception ex)
		    {
			    ErrorLog.LogErrorMessageToDB("TaxDL", "GetAllTaxList", "", ex.Message);
			    return null;
		    }
	    }


	    private void GetTaxInformation(int TaxID)
	    {
		    try
		    {
			    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
			    string sqlCommand = "usp_Tax_GetTaxDetails";
			    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			    db.AddInParameter(dbCommand, "TaxID", DbType.Int32, TaxID);

			    using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
			    {
				    if (dataReader.HasRows)
				    {
					    dataReader.Read();
						TaxId = dataReader.GetInt32(dataReader.GetOrdinal("TaxId"));
					    TaxName = dataReader.GetString(dataReader.GetOrdinal("TaxName"));
					    TaxPercentage = dataReader.GetDecimal(dataReader.GetOrdinal("TaxPercentage"));
					    IsDefault = dataReader.GetBoolean(dataReader.GetOrdinal("IsDefault"));
					    Status = dataReader.GetBoolean(dataReader.GetOrdinal("Status"));
				    }
			    }
		    }
		    catch (Exception ex)
		    {
			    ErrorLog.LogErrorMessageToDB("TaxDL", "GetTaxInformation");
		    }
	    }
    }
}

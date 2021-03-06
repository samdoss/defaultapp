﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms.VisualStyles;
using ERP.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERP.DataLayer
{
    public class EstimateProduct
    {
	    ApplicationConnection _appConnection = new ApplicationConnection();

	    public EstimateProduct()
	    {

	    }
		public EstimateProduct(int EstimateProductId)
	    {
			GetEstimateProductInformation(EstimateProductId);
	    }

        public int EstimateProductId { get; set; }
        public int EstimateId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

		public int MaterialID { get; set; }
	    public string MaterialName	{ get; set; }
	    public string MaterialCode	{ get; set; }

	    public int UnitID { get; set; }
		public string UnitCode { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int TaxId { get; set; }
        public decimal TaxValue { get; set; }

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
						    _result = AddEstimateProduct(db, transaction);
						    if (_result.Status == TransactionStatus.Failure)
						    {
							    transaction.Rollback();
							    return _result;
						    }
						    break;
					    case ScreenMode.Edit:

						    _result = UpdateEstimateProduct(db, transaction);
						    if (_result.Status == TransactionStatus.Failure)
						    {
							    transaction.Rollback();
							    return _result;
						    }

						    break;
					    case ScreenMode.Delete:

                            //_result = DeactivateEstimateProduct(db, transaction);
                            //if (_result.Status == TransactionStatus.Failure)
                            //{
                            //    transaction.Rollback();
                            //    return _result;
                            //}

						    break;
				    }
				    transaction.Commit();
				    return _result;
			    }
			    catch
			    {
				    transaction.Rollback();
				    if (screenMode == ScreenMode.Add)
					    return new TransactionResult(TransactionStatus.Failure, "Failure Adding EstimateProduct.");
				    if (screenMode == ScreenMode.Edit)
					    return new TransactionResult(TransactionStatus.Failure, "Failure Updating EstimateProduct.");
				    if (screenMode == ScreenMode.Delete)
					    return new TransactionResult(TransactionStatus.Failure, "Failure Deleting EstimateProduct.");
			    }
		    }
		    return null;
	    }

	    #endregion


	    private TransactionResult AddEstimateProduct(Database db, DbTransaction transaction)
	    {
		    string sqlCommand = "usp_EstimateProduct_InsertEstimateProductDetails";
		    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

			db.AddInParameter(dbCommand, "EstimateId", DbType.Int32, EstimateId);
			db.AddInParameter(dbCommand, "ProductId", DbType.Int32, ProductId);
			db.AddInParameter(dbCommand, "ProductName", DbType.String, ProductName);
			db.AddInParameter(dbCommand, "Description", DbType.String, Description);

		    db.AddInParameter(dbCommand, "MaterialID", DbType.Int32, MaterialID);
		    db.AddInParameter(dbCommand, "MaterialName", DbType.String, MaterialName);
		    db.AddInParameter(dbCommand, "MaterialCode", DbType.String, MaterialCode);

		    db.AddInParameter(dbCommand, "UnitID", DbType.Int32, UnitID);
		    db.AddInParameter(dbCommand, "UnitCode", DbType.String, UnitCode);
		   
			db.AddInParameter(dbCommand, "Quantity", DbType.Int32, Quantity);
			db.AddInParameter(dbCommand, "UnitPrice", DbType.Decimal, UnitPrice);
			db.AddInParameter(dbCommand, "TotalPrice", DbType.Decimal, TotalPrice);
			db.AddInParameter(dbCommand, "TaxId", DbType.Int32, TaxId);
			db.AddInParameter(dbCommand, "TaxValue", DbType.Decimal, TaxValue);


		    int returnValue = 0;
		    db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
			    DataRowVersion.Default, returnValue);

		    db.ExecuteNonQuery(dbCommand, transaction);
		    returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

		    if (returnValue == -1)
			    return new TransactionResult(TransactionStatus.Failure, "Failure Adding EstimateProduct.");
		    else
		    {
			    EstimateProductId = returnValue;
			    return new TransactionResult(TransactionStatus.Success, "EstimateProduct Successfully Added.");
		    }
	    }

	    private TransactionResult UpdateEstimateProduct(Database db, DbTransaction transaction)
	    {

		    string sqlCommand = "usp_EstimateProduct_UpdateEstimateProduct";
		    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

		    db.AddInParameter(dbCommand, "EstimateProductId", DbType.Int32, EstimateProductId);
		    db.AddInParameter(dbCommand, "EstimateId", DbType.Int32, EstimateId);
		    db.AddInParameter(dbCommand, "ProductId", DbType.Int32, ProductId);
		    db.AddInParameter(dbCommand, "ProductName", DbType.String, ProductName);
		    db.AddInParameter(dbCommand, "Description", DbType.String, Description);


			db.AddInParameter(dbCommand, "MaterialID", DbType.Int32, MaterialID);
		    db.AddInParameter(dbCommand, "MaterialName", DbType.String, MaterialName);
		    db.AddInParameter(dbCommand, "MaterialCode", DbType.String, MaterialCode);

		    db.AddInParameter(dbCommand, "UnitID", DbType.Int32, UnitID);
		    db.AddInParameter(dbCommand, "UnitCode", DbType.String, UnitCode);

		    db.AddInParameter(dbCommand, "Quantity", DbType.Int32, Quantity);
		    db.AddInParameter(dbCommand, "UnitPrice", DbType.Decimal, UnitPrice);
		    db.AddInParameter(dbCommand, "TotalPrice", DbType.Decimal, TotalPrice);
		    db.AddInParameter(dbCommand, "TaxId", DbType.Int32, TaxId);
		    db.AddInParameter(dbCommand, "TaxValue", DbType.Decimal, TaxValue);

		    int returnValue = -1;
		    db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
			    DataRowVersion.Default, returnValue);

		    db.ExecuteNonQuery(dbCommand, transaction);
		    returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

		    if (returnValue == -1)
			    return new TransactionResult(TransactionStatus.Failure, "Failure Updating EstimateProduct Information.");
		    else
		    {
			    EstimateProductId = returnValue;
			    return new TransactionResult(TransactionStatus.Success, "EstimateProduct Information Successfully Updated.");
		    }
	    }


	    public DataSet GetAllEstimateProduct()
	    {
		    try
		    {
			    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
			    string sqlCommand = "usp_EstimateProduct_GetAllEstimateProduct";
			    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			    return db.ExecuteDataSet(dbCommand);
		    }
		    catch (Exception ex)
		    {
			    ErrorLog.LogErrorMessageToDB("EstimateProductDL", "GetAllEstimateProduct", "", ex.Message);
		    }
		    return null;
	    }

	    public List<EstimateProduct> GetAllEstimateProductList()
	    {
		    try
		    {
			    List<EstimateProduct> EstimateProductList = new List<EstimateProduct>();
			    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
			    string sqlCommand = "usp_EstimateProduct_GetAllEstimateProduct";
			    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

			    using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
			    {
				    EstimateProduct obj = new EstimateProduct();
				    if (dataReader.HasRows)
				    {
					    while (dataReader.Read())
					    {
						    obj = new EstimateProduct();

							obj.EstimateProductId = dataReader.GetInt32(dataReader.GetOrdinal("EstimateProductId"));
						    obj.EstimateId = dataReader.GetInt32(dataReader.GetOrdinal("EstimateId"));
						    obj.ProductId = dataReader.GetInt32(dataReader.GetOrdinal("ProductId"));
						    obj.ProductName = dataReader.GetString(dataReader.GetOrdinal("ProductName"));
						    obj.Description = dataReader.GetString(dataReader.GetOrdinal("Description"));

						    obj.MaterialID = dataReader.GetInt32(dataReader.GetOrdinal("MaterialID"));
							obj.MaterialName = dataReader.GetString(dataReader.GetOrdinal("MaterialName"));
							obj.MaterialCode = dataReader.GetString(dataReader.GetOrdinal("MaterialCode"));

							obj.UnitID = dataReader.GetInt32(dataReader.GetOrdinal("UnitID"));
							obj.UnitCode = dataReader.GetString(dataReader.GetOrdinal("UnitCode"));

						    obj.Quantity = dataReader.GetInt32(dataReader.GetOrdinal("Quantity"));
						    obj.UnitPrice = dataReader.GetDecimal(dataReader.GetOrdinal("UnitPrice"));
						    obj.TotalPrice = dataReader.GetDecimal(dataReader.GetOrdinal("TotalPrice"));
						    obj.TaxId = dataReader.GetInt32(dataReader.GetOrdinal("TaxId"));
						    obj.TaxValue = dataReader.GetDecimal(dataReader.GetOrdinal("TaxValue"));

						    EstimateProductList.Add(obj);
					    }
				    }

			    }
			    return EstimateProductList;
		    }
		    catch (Exception ex)
		    {
			    ErrorLog.LogErrorMessageToDB("EstimateProductDL", "GetAllEstimateProductList", "", ex.Message);
			    return null;
		    }
	    }

	    private void GetEstimateProductInformation(int EstimateProductID)
	    {
		    try
		    {
			    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
			    string sqlCommand = "usp_EstimateProduct_GetEstimateProductDetails";
			    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			    db.AddInParameter(dbCommand, "EstimateProductID", DbType.Int32, EstimateProductID);

			    using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
			    {
				    if (dataReader.HasRows)
				    {
					    dataReader.Read();
						EstimateProductId = dataReader.GetInt32(dataReader.GetOrdinal("EstimateProductId"));
					    EstimateId = dataReader.GetInt32(dataReader.GetOrdinal("EstimateId"));
					    ProductId = dataReader.GetInt32(dataReader.GetOrdinal("ProductId"));
					    ProductName = dataReader.GetString(dataReader.GetOrdinal("ProductName"));
					    Description = dataReader.GetString(dataReader.GetOrdinal("Description"));

						MaterialID = dataReader.GetInt32(dataReader.GetOrdinal("MaterialID"));
					    MaterialName = dataReader.GetString(dataReader.GetOrdinal("MaterialName"));
					    MaterialCode = dataReader.GetString(dataReader.GetOrdinal("MaterialCode"));

					    UnitID = dataReader.GetInt32(dataReader.GetOrdinal("UnitID"));
					    UnitCode = dataReader.GetString(dataReader.GetOrdinal("UnitCode"));

					    Quantity = dataReader.GetInt32(dataReader.GetOrdinal("Quantity"));
					    UnitPrice = dataReader.GetDecimal(dataReader.GetOrdinal("UnitPrice"));
					    TotalPrice = dataReader.GetDecimal(dataReader.GetOrdinal("TotalPrice"));
					    TaxId = dataReader.GetInt32(dataReader.GetOrdinal("TaxId"));
					    TaxValue = dataReader.GetDecimal(dataReader.GetOrdinal("TaxValue"));
				    }
			    }
		    }
		    catch (Exception ex)
		    {
			    ErrorLog.LogErrorMessageToDB("EstimateProductDL", "GetEstimateProductInformation");
		    }
	    }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using ERP.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERP.DataLayer
{
    public class Product
    {
	    ApplicationConnection _appConnection = new ApplicationConnection();

		public Product(int ProductId)
	    {
			GetProductInformation(ProductId);
	    }

        public Product()
        {

        }

        public Product(int productId, string productName)
        {
            this.ProductId = productId;
            this.ProductName = productName;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

		//public decimal UnitPrice { get; set; }
		//public int UnitID { get; set; }

	    public int MaterialID { get; set; }
	    

        public int Quantity { get; set; }
        public int TaxId { get; set; }
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
						    _result = AddProduct(db, transaction);
						    if (_result.Status == TransactionStatus.Failure)
						    {
							    transaction.Rollback();
							    return _result;
						    }
						    break;
					    case ScreenMode.Edit:

						    _result = UpdateProduct(db, transaction);
						    if (_result.Status == TransactionStatus.Failure)
						    {
							    transaction.Rollback();
							    return _result;
						    }

						    break;
					    case ScreenMode.Delete:

						    _result = DeactivateProduct(db, transaction);
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
					    return new TransactionResult(TransactionStatus.Failure, "Failure Adding Product.");
				    if (screenMode == ScreenMode.Edit)
					    return new TransactionResult(TransactionStatus.Failure, "Failure Updating Product.");
				    if (screenMode == ScreenMode.Delete)
					    return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Product.");
			    }
		    }
		    return null;
	    }

	    #endregion


	    private TransactionResult AddProduct(Database db, DbTransaction transaction)
	    {
		    string sqlCommand = "usp_Product_InsertProductDetails";
		    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

		    db.AddInParameter(dbCommand, "ProductId", DbType.Int32,ProductId);
		    db.AddInParameter(dbCommand, "ProductName", DbType.String,ProductName);
		    db.AddInParameter(dbCommand, "Description", DbType.String,Description);
		    
		    db.AddInParameter(dbCommand, "Quantity", DbType.Int32,Quantity);

			db.AddInParameter(dbCommand, "MaterialID", DbType.Int32, MaterialID);

			//db.AddInParameter(dbCommand, "UnitID", DbType.Int32, UnitID);
			//db.AddInParameter(dbCommand, "UnitPrice", DbType.Decimal, UnitPrice);

		    db.AddInParameter(dbCommand, "TaxId", DbType.Int32,TaxId);
		    db.AddInParameter(dbCommand, "Status", DbType.Boolean,Status);


		    int returnValue = 0;
		    db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
			    DataRowVersion.Default, returnValue);

		    db.ExecuteNonQuery(dbCommand, transaction);
		    returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

		    if (returnValue == -1)
			    return new TransactionResult(TransactionStatus.Failure, "Failure Adding Product.");
		    else
		    {
			    ProductId = returnValue;
			    return new TransactionResult(TransactionStatus.Success, "Product Successfully Added.");
		    }
	    }

	    private TransactionResult UpdateProduct(Database db, DbTransaction transaction)
	    {

		    string sqlCommand = "usp_Product_UpdateProduct";
		    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

			db.AddInParameter(dbCommand, "ProductId", DbType.Int32, ProductId);
		    db.AddInParameter(dbCommand, "ProductName", DbType.String, ProductName);
		    db.AddInParameter(dbCommand, "Description", DbType.String, Description);

		    db.AddInParameter(dbCommand, "Quantity", DbType.Int32, Quantity);

			db.AddInParameter(dbCommand, "MaterialID", DbType.Int32, MaterialID);
			//db.AddInParameter(dbCommand, "UnitID", DbType.Int32, UnitID);
			//db.AddInParameter(dbCommand, "UnitPrice", DbType.Decimal, UnitPrice);

		    db.AddInParameter(dbCommand, "TaxId", DbType.Int32, TaxId);
		    db.AddInParameter(dbCommand, "Status", DbType.Boolean, Status);

		    int returnValue = -1;
		    db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
			    DataRowVersion.Default, returnValue);

		    db.ExecuteNonQuery(dbCommand, transaction);
		    returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

		    if (returnValue == -1)
			    return new TransactionResult(TransactionStatus.Failure, "Failure Updating Product Information.");
		    else
		    {
			    ProductId = returnValue;
			    return new TransactionResult(TransactionStatus.Success, "Product Information Successfully Updated.");
		    }
	    }

	    private TransactionResult DeactivateProduct(Database db, DbTransaction transaction)
	    {

		    string sqlCommand = "usp_Product_DeactivateProduct";
		    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

		    db.AddInParameter(dbCommand, "ProductId", DbType.Int32, ProductId);
		    int returnValue = -1;
		    db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
			    DataRowVersion.Default, returnValue);

		    db.ExecuteNonQuery(dbCommand, transaction);
		    returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

		    if (returnValue == -1)
			    return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Product Information.");
		    else
			    return new TransactionResult(TransactionStatus.Success, "Product Information Successfully Deleted.");
	    }


	    public DataSet GetAllProduct()
	    {
		    try
		    {
			    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
			    string sqlCommand = "usp_Product_GetAllProducts";
			    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			    return db.ExecuteDataSet(dbCommand);
		    }
		    catch (Exception ex)
		    {
			    ErrorLog.LogErrorMessageToDB("ProductDL", "GetAllProduct", "", ex.Message);
		    }
		    return null;
	    }

	    public List<Product> GetAllProductList()
	    {
		    try
		    {
			    List<Product> ProductList = new List<Product>();
			    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
				string sqlCommand = "usp_Product_GetAllProductsList";
			    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

			    using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
			    {
				    Product obj = new Product();
				    if (dataReader.HasRows)
				    {
					    while (dataReader.Read())
					    {
						    obj = new Product();

							obj.ProductId = dataReader.GetInt32(dataReader.GetOrdinal("ProductId"));
						    obj.ProductName = dataReader.GetString(dataReader.GetOrdinal("ProductName"));
						    obj.Description = dataReader.GetString(dataReader.GetOrdinal("Description"));
						    //obj.MaterialID = dataReader.GetInt32(dataReader.GetOrdinal("MaterialID"));
							//obj.UnitID = dataReader.GetInt32(dataReader.GetOrdinal("UnitID"));
							//obj.UnitPrice = dataReader.GetDecimal(dataReader.GetOrdinal("UnitPrice"));
						    //obj.Quantity = dataReader.GetInt32(dataReader.GetOrdinal("Quantity"));
						    //obj.TaxId = dataReader.GetInt32(dataReader.GetOrdinal("TaxId"));
						    obj.Status = dataReader.GetBoolean(dataReader.GetOrdinal("Status"));

						    ProductList.Add(obj);
					    }
				    }

			    }
			    return ProductList;
		    }
		    catch (Exception ex)
		    {
			    ErrorLog.LogErrorMessageToDB("ProductDL", "GetAllProductList", "", ex.Message);
			    return null;
		    }
	    }


		private void GetProductInformation(int ProductID)
	    {
		    try
		    {
			    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
			    string sqlCommand = "usp_Product_GetProductDetails";
			    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			    db.AddInParameter(dbCommand, "ProductID", DbType.Int32, ProductID);

			    using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
			    {
				    if (dataReader.HasRows)
				    {
					    dataReader.Read();
						ProductId = dataReader.GetInt32(dataReader.GetOrdinal("ProductId"));
					    ProductName = dataReader.GetString(dataReader.GetOrdinal("ProductName"));
					    Description = dataReader.GetString(dataReader.GetOrdinal("Description"));
					    MaterialID = dataReader.GetInt32(dataReader.GetOrdinal("MaterialID"));
						//UnitID = dataReader.GetInt32(dataReader.GetOrdinal("UnitID"));
						//UnitPrice = dataReader.GetDecimal(dataReader.GetOrdinal("UnitPrice"));
					    Quantity = dataReader.GetInt32(dataReader.GetOrdinal("Quantity"));
					    TaxId = dataReader.GetInt32(dataReader.GetOrdinal("TaxId"));
					    Status = dataReader.GetBoolean(dataReader.GetOrdinal("Status"));
				    }
			    }
		    }
		    catch (Exception ex)
		    {
			    ErrorLog.LogErrorMessageToDB("ProductDL", "GetProductInformation");
		    }
	    }
    }
}

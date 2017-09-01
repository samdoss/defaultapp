using System;
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
    public class PurchaseOrderProduct
    {
	    ApplicationConnection _appConnection = new ApplicationConnection();

	    public PurchaseOrderProduct()
	    {

	    }
		public PurchaseOrderProduct(int PurchaseOrderProductId)
	    {
			GetPurchaseOrderProductInformation(PurchaseOrderProductId);
	    }

        public int PurchaseOrderProductId { get; set; }
        public int PurchaseOrderId { get; set; }
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
						    _result = AddPurchaseOrderProduct(db, transaction);
						    if (_result.Status == TransactionStatus.Failure)
						    {
							    transaction.Rollback();
							    return _result;
						    }
						    break;
					    case ScreenMode.Edit:

						    _result = UpdatePurchaseOrderProduct(db, transaction);
						    if (_result.Status == TransactionStatus.Failure)
						    {
							    transaction.Rollback();
							    return _result;
						    }

						    break;
					    case ScreenMode.Delete:

                            //_result = DeactivatePurchaseOrderProduct(db, transaction);
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
					    return new TransactionResult(TransactionStatus.Failure, "Failure Adding PurchaseOrderProduct.");
				    if (screenMode == ScreenMode.Edit)
					    return new TransactionResult(TransactionStatus.Failure, "Failure Updating PurchaseOrderProduct.");
				    if (screenMode == ScreenMode.Delete)
					    return new TransactionResult(TransactionStatus.Failure, "Failure Deleting PurchaseOrderProduct.");
			    }
		    }
		    return null;
	    }

	    #endregion


	    private TransactionResult AddPurchaseOrderProduct(Database db, DbTransaction transaction)
	    {
		    string sqlCommand = "usp_PurchaseOrderProduct_InsertPurchaseOrderProductDetails";
		    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

			db.AddInParameter(dbCommand, "PurchaseOrderId", DbType.Int32, PurchaseOrderId);
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
			    return new TransactionResult(TransactionStatus.Failure, "Failure Adding PurchaseOrderProduct.");
		    else
		    {
			    PurchaseOrderProductId = returnValue;
			    return new TransactionResult(TransactionStatus.Success, "PurchaseOrderProduct Successfully Added.");
		    }
	    }

	    private TransactionResult UpdatePurchaseOrderProduct(Database db, DbTransaction transaction)
	    {

		    string sqlCommand = "usp_PurchaseOrderProduct_UpdatePurchaseOrderProduct";
		    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

		    db.AddInParameter(dbCommand, "PurchaseOrderProductId", DbType.Int32, PurchaseOrderProductId);
		    db.AddInParameter(dbCommand, "PurchaseOrderId", DbType.Int32, PurchaseOrderId);
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
			    return new TransactionResult(TransactionStatus.Failure, "Failure Updating PurchaseOrderProduct Information.");
		    else
		    {
			    PurchaseOrderProductId = returnValue;
			    return new TransactionResult(TransactionStatus.Success, "PurchaseOrderProduct Information Successfully Updated.");
		    }
	    }


	    public DataSet GetAllPurchaseOrderProduct()
	    {
		    try
		    {
			    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
			    string sqlCommand = "usp_PurchaseOrderProduct_GetAllPurchaseOrderProduct";
			    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			    return db.ExecuteDataSet(dbCommand);
		    }
		    catch (Exception ex)
		    {
			    ErrorLog.LogErrorMessageToDB("PurchaseOrderProductDL", "GetAllPurchaseOrderProduct", "", ex.Message);
		    }
		    return null;
	    }

	    public List<PurchaseOrderProduct> GetAllPurchaseOrderProductList()
	    {
		    try
		    {
			    List<PurchaseOrderProduct> PurchaseOrderProductList = new List<PurchaseOrderProduct>();
			    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
			    string sqlCommand = "usp_PurchaseOrderProduct_GetAllPurchaseOrderProduct";
			    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

			    using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
			    {
				    PurchaseOrderProduct obj = new PurchaseOrderProduct();
				    if (dataReader.HasRows)
				    {
					    while (dataReader.Read())
					    {
						    obj = new PurchaseOrderProduct();

							obj.PurchaseOrderProductId = dataReader.GetInt32(dataReader.GetOrdinal("PurchaseOrderProductId"));
						    obj.PurchaseOrderId = dataReader.GetInt32(dataReader.GetOrdinal("PurchaseOrderId"));
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

						    PurchaseOrderProductList.Add(obj);
					    }
				    }

			    }
			    return PurchaseOrderProductList;
		    }
		    catch (Exception ex)
		    {
			    ErrorLog.LogErrorMessageToDB("PurchaseOrderProductDL", "GetAllPurchaseOrderProductList", "", ex.Message);
			    return null;
		    }
	    }

	    private void GetPurchaseOrderProductInformation(int PurchaseOrderProductID)
	    {
		    try
		    {
			    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
			    string sqlCommand = "usp_PurchaseOrderProduct_GetPurchaseOrderProductDetails";
			    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			    db.AddInParameter(dbCommand, "PurchaseOrderProductID", DbType.Int32, PurchaseOrderProductID);

			    using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
			    {
				    if (dataReader.HasRows)
				    {
					    dataReader.Read();
						PurchaseOrderProductId = dataReader.GetInt32(dataReader.GetOrdinal("PurchaseOrderProductId"));
					    PurchaseOrderId = dataReader.GetInt32(dataReader.GetOrdinal("PurchaseOrderId"));
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
			    ErrorLog.LogErrorMessageToDB("PurchaseOrderProductDL", "GetPurchaseOrderProductInformation");
		    }
	    }
    }
}

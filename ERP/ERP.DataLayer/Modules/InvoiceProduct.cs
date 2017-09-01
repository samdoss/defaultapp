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
    public class InvoiceProduct
    {
        ApplicationConnection _appConnection = new ApplicationConnection();

        public InvoiceProduct()
        {

        }
        public InvoiceProduct(int InvoiceProductId)
        {
            GetInvoiceProductInformation(InvoiceProductId);
        }

        public int InvoiceProductId { get; set; }
        public int InvoiceId { get; set; }
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
        public int InvoiceDeliveryStatusID { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryNote { get; set; }
        public string DeliveryDestination { get; set; }
        public bool IsDelivered { get; set; }
        public string DespatchedThrough { get; set; }


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
                            _result = AddInvoiceProduct(db, transaction);
                            if (_result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return _result;
                            }
                            _result = AddInvoiceDeliveryStatus(db, transaction);
                            if (_result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return _result;
                            }
                            break;
                        case ScreenMode.Edit:

                            _result = UpdateInvoiceProduct(db, transaction);
                            if (_result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return _result;
                            }



                            break;
                        case ScreenMode.Delete:
                            _result = InvoiceDelivered(db, transaction);
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
                        return new TransactionResult(TransactionStatus.Failure, "Failure Adding InvoiceProduct.");
                    if (screenMode == ScreenMode.Edit)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Updating InvoiceProduct.");
                    if (screenMode == ScreenMode.Delete)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Deleting InvoiceProduct.");
                }
            }
            return null;
        }

        #endregion


        private TransactionResult AddInvoiceProduct(Database db, DbTransaction transaction)
        {
            string sqlCommand = "usp_InvoiceProduct_InsertInvoiceProductDetails";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "InvoiceId", DbType.Int32, InvoiceId);
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
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding InvoiceProduct.");
            else
            {
                InvoiceProductId = returnValue;
                return new TransactionResult(TransactionStatus.Success, "InvoiceProduct Successfully Added.");
            }
        }



        private TransactionResult AddInvoiceDeliveryStatus(Database db, DbTransaction transaction)
        {
            string sqlCommand = "usp_InvoiceProduct_InsertInvoiceDeliveryStatus";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);


            db.AddInParameter(dbCommand, "InvoiceID", DbType.Int32, InvoiceId);
            db.AddInParameter(dbCommand, "DeliveryDate", DbType.DateTime, DeliveryDate);
            db.AddInParameter(dbCommand, "DeliveryNote", DbType.String, DeliveryNote);
            db.AddInParameter(dbCommand, "DeliveryDestination", DbType.String, DeliveryDestination);
            db.AddInParameter(dbCommand, "DespatchedThrough", DbType.String, DespatchedThrough);
            db.AddInParameter(dbCommand, "IsDelivered", DbType.Boolean, IsDelivered);
        
            int returnValue = 0;
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                DataRowVersion.Default, returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding InvoiceDeliveryStatus.");
            else
            {
                InvoiceProductId = returnValue;
                return new TransactionResult(TransactionStatus.Success, "InvoiceDeliveryStatus Successfully Added.");
            }
        }

        private TransactionResult UpdateInvoiceProduct(Database db, DbTransaction transaction)
        {

            string sqlCommand = "usp_InvoiceProduct_UpdateInvoiceProduct";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "InvoiceProductId", DbType.Int32, InvoiceProductId);
            db.AddInParameter(dbCommand, "InvoiceId", DbType.Int32, InvoiceId);
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
                return new TransactionResult(TransactionStatus.Failure, "Failure Updating InvoiceProduct Information.");
            else
            {
                InvoiceProductId = returnValue;
                return new TransactionResult(TransactionStatus.Success, "InvoiceProduct Information Successfully Updated.");
            }
        }

        private TransactionResult InvoiceDelivered(Database db, DbTransaction transaction)
        {

            string sqlCommand = "usp_Update_InvoiceProductDelivered";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "InvoiceId", DbType.Int32, InvoiceId);
            db.AddInParameter(dbCommand, "IsDelivered", DbType.Boolean, IsDelivered);

            int returnValue = -1;
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                DataRowVersion.Default, returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Updating InvoiceProduct Information.");
            else
            {
                InvoiceProductId = returnValue;
                return new TransactionResult(TransactionStatus.Success, "InvoiceProduct Information Successfully Updated.");
            }
        }


        public DataSet GetAllInvoiceProduct()
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "usp_InvoiceProduct_GetAllInvoiceProduct";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("InvoiceProductDL", "GetAllInvoiceProduct", "", ex.Message);
            }
            return null;
        }

        public List<InvoiceProduct> GetAllInvoiceProductList()
        {
            try
            {
                List<InvoiceProduct> InvoiceProductList = new List<InvoiceProduct>();
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "usp_InvoiceProduct_GetAllInvoiceProduct";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    InvoiceProduct obj = new InvoiceProduct();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            obj = new InvoiceProduct();

                            obj.InvoiceProductId = dataReader.GetInt32(dataReader.GetOrdinal("InvoiceProductId"));
                            obj.InvoiceId = dataReader.GetInt32(dataReader.GetOrdinal("InvoiceId"));
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

                            InvoiceProductList.Add(obj);
                        }
                    }

                }
                return InvoiceProductList;
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("InvoiceProductDL", "GetAllInvoiceProductList", "", ex.Message);
                return null;
            }
        }

        private void GetInvoiceProductInformation(int InvoiceProductID)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "usp_InvoiceProduct_GetInvoiceProductDetails";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "InvoiceProductID", DbType.Int32, InvoiceProductID);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        InvoiceProductId = dataReader.GetInt32(dataReader.GetOrdinal("InvoiceProductId"));
                        InvoiceId = dataReader.GetInt32(dataReader.GetOrdinal("InvoiceId"));
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
                ErrorLog.LogErrorMessageToDB("InvoiceProductDL", "GetInvoiceProductInformation");
            }
        }
    }
}

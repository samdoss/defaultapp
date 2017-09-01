
using ERP.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlSupplier;
namespace ERP.DataLayer
{
    public class Supplier
    {
        public Supplier()
        {

        }
        
        public Supplier(int SupplierId)
        {
            GetSupplierInformation(SupplierId);
            
        }
        
        public Supplier(int SupplierId, string SupplierName)
        {
            this.SupplierId = SupplierId;
            this.SupplierName = SupplierName;
        }

        #region Private Variables

        ApplicationConnection _appConnection = new ApplicationConnection();
        
        public int CompanyID { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string TIN { get; set; }
        public string PrivateSupplierDetails { get; set; }
        public string OtherSupplierDetails { get; set; }
        public string BillingAddress { get; set; }
        public int CityID { get; set; }
        public int StateID { get; set; }        
        public int CountryID { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public string Zip { get; set; }
        public bool ShipToDifferentAddress { get; set; }
        public string ShippingAddress { get; set; }
        public int ShippingCityID { get; set; }
        public int ShippingStateID { get; set; }
        public string ShippingZip { get; set; }
        public int ShippingCountryID { get; set; }

        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingCountry { get; set; }


        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public int AuditUserID { get; set; }

        #endregion

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
                            _result = AddSupplier(db, transaction);
                                    if (_result.Status == TransactionStatus.Failure)
                                    {
                                        transaction.Rollback();
                                        return _result;
                                    }                                
                            break;
                        case ScreenMode.Edit:
                            
                                _result = UpdateSupplier( db, transaction);
                                if (_result.Status == TransactionStatus.Failure)
                                {
                                    transaction.Rollback();
                                    return _result;
                                }
                            
                            break;
                        case ScreenMode.Delete:

                            _result = DeactivateSupplier(db, transaction);
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
                        return new TransactionResult(TransactionStatus.Failure, "Failure Adding Supplier.");
                    if (screenMode == ScreenMode.Edit)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Updating Supplier.");
                    if (screenMode == ScreenMode.Delete)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Supplier.");
                }
            }
            return null;
        }

        #endregion

        private TransactionResult AddSupplier(Database db, DbTransaction transaction)
        {            
            string sqlCommand = "usp_Supplier_InsertSupplierDetails";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, CompanyID);
            db.AddInParameter(dbCommand, "SupplierId", DbType.Int32, SupplierId);
            db.AddInParameter(dbCommand, "SupplierName", DbType.String, SupplierName);
            db.AddInParameter(dbCommand, "ContactName", DbType.String, ContactName);
            db.AddInParameter(dbCommand, "Phone", DbType.String, Phone);
            db.AddInParameter(dbCommand, "Email", DbType.String, Email);
            db.AddInParameter(dbCommand, "TIN", DbType.String, TIN);
            db.AddInParameter(dbCommand, "PrivateSupplierDetails", DbType.String, PrivateSupplierDetails);
            db.AddInParameter(dbCommand, "OtherSupplierDetails", DbType.String, OtherSupplierDetails);
            db.AddInParameter(dbCommand, "BillingAddress", DbType.String, BillingAddress);
            db.AddInParameter(dbCommand, "CityID", DbType.Int32, CityID);
            db.AddInParameter(dbCommand, "StateID", DbType.Int32, StateID);
            db.AddInParameter(dbCommand, "Zip", DbType.String, Zip);
            db.AddInParameter(dbCommand, "CountryID", DbType.Int32, CountryID);
            db.AddInParameter(dbCommand, "ShipToDifferentAddress", DbType.String, ShipToDifferentAddress);
            db.AddInParameter(dbCommand, "ShippingAddress", DbType.String, ShippingAddress);
            db.AddInParameter(dbCommand, "ShippingCityID", DbType.Int32, ShippingCityID);
            db.AddInParameter(dbCommand, "ShippingStateID", DbType.Int32, ShippingStateID);
            db.AddInParameter(dbCommand, "ShippingZip",  DbType.String,ShippingZip);
            db.AddInParameter(dbCommand, "ShippingCountryID", DbType.Int32, ShippingCountryID);
            db.AddInParameter(dbCommand, "Status", DbType.Boolean, Status);

            db.AddInParameter(dbCommand, "AuditUserID", DbType.Int32, AuditUserID);

            int returnValue = 0;
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding Supplier.");
            else
            {
                SupplierId = returnValue;
                return new TransactionResult(TransactionStatus.Success, "Supplier Successfully Added.");
            }            
        }

        private TransactionResult UpdateSupplier(Database db, DbTransaction transaction)
        {
            
            string sqlCommand = "usp_Supplier_UpdateSupplier";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, CompanyID);
            db.AddInParameter(dbCommand, "SupplierId", DbType.Int32, SupplierId);
            db.AddInParameter(dbCommand, "SupplierName", DbType.String, SupplierName);
            db.AddInParameter(dbCommand, "ContactName", DbType.String, ContactName);
            db.AddInParameter(dbCommand, "Phone", DbType.String, Phone);
            db.AddInParameter(dbCommand, "Email", DbType.String, Email);
            db.AddInParameter(dbCommand, "TIN", DbType.String, TIN);
            db.AddInParameter(dbCommand, "PrivateSupplierDetails", DbType.String, PrivateSupplierDetails);
            db.AddInParameter(dbCommand, "OtherSupplierDetails", DbType.String, OtherSupplierDetails);
            db.AddInParameter(dbCommand, "BillingAddress", DbType.String, BillingAddress);
            db.AddInParameter(dbCommand, "CityID", DbType.Int32, CityID);
            db.AddInParameter(dbCommand, "StateID", DbType.Int32, StateID);
            db.AddInParameter(dbCommand, "Zip", DbType.String, Zip);
            db.AddInParameter(dbCommand, "CountryID", DbType.Int32, CountryID);
            db.AddInParameter(dbCommand, "ShipToDifferentAddress", DbType.String, ShipToDifferentAddress);
            db.AddInParameter(dbCommand, "ShippingAddress", DbType.String, ShippingAddress);
            db.AddInParameter(dbCommand, "ShippingCityID", DbType.Int32, ShippingCityID);
            db.AddInParameter(dbCommand, "ShippingStateID", DbType.Int32, ShippingStateID);
            db.AddInParameter(dbCommand, "ShippingZip", DbType.String, ShippingZip);
            db.AddInParameter(dbCommand, "ShippingCountryID", DbType.Int32, ShippingCountryID);
            db.AddInParameter(dbCommand, "Status", DbType.Boolean, Status);

            db.AddInParameter(dbCommand, "AuditUserID", DbType.Int32, AuditUserID);

            int returnValue = -1;
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");
           
            if (returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Updating Company Information.");
            else
            {
                SupplierId = returnValue;
                return new TransactionResult(TransactionStatus.Success, "Company Information Successfully Updated.");
            }
        }

        private TransactionResult DeactivateSupplier(Database db, DbTransaction transaction)
        {
            
            string sqlCommand = "usp_Supplier_DeactivateSupplier";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "SupplierId", DbType.Int32, SupplierId);
            int returnValue = -1;
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Supplier Information.");
            else
                return new TransactionResult(TransactionStatus.Success, "Supplier Information Successfully Deleted.");
        }

        private void GetSupplierInformation(int SupplierID)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "usp_Supplier_GetSupplierDetails";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "SupplierId", DbType.Int32, SupplierID);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        SupplierId = dataReader.GetInt32(dataReader.GetOrdinal("SupplierId"));
                        CompanyID = dataReader.GetInt32(dataReader.GetOrdinal("CompanyID"));
                        SupplierName = dataReader.GetString(dataReader.GetOrdinal("SupplierName"));
                        ContactName = dataReader.GetString(dataReader.GetOrdinal("ContactName"));
                        Phone = dataReader.GetString(dataReader.GetOrdinal("Phone"));
                        Email = dataReader.GetString(dataReader.GetOrdinal("Email"));
                        TIN = dataReader.GetString(dataReader.GetOrdinal("Tin"));
                        PrivateSupplierDetails = dataReader.GetString(dataReader.GetOrdinal("PrivateSupplierDetails"));
                        OtherSupplierDetails = dataReader.GetString(dataReader.GetOrdinal("OtherSupplierDetails"));
                        BillingAddress = dataReader.GetString(dataReader.GetOrdinal("BillingAddress"));
                        CityID = dataReader.GetInt32(dataReader.GetOrdinal("CityID"));
                        StateID = dataReader.GetInt32(dataReader.GetOrdinal("StateID"));
                        CountryID = dataReader.GetInt32(dataReader.GetOrdinal("CountryID"));

                      

                        Zip = dataReader.GetString(dataReader.GetOrdinal("Zip"));
                        ShipToDifferentAddress = dataReader.GetBoolean(dataReader.GetOrdinal("ShipToDifferentAddress"));
                        ShippingAddress = dataReader.GetString(dataReader.GetOrdinal("ShippingAddress"));
                        ShippingCityID = dataReader.GetInt32(dataReader.GetOrdinal("ShippingCityID"));
                        ShippingStateID = dataReader.GetInt32(dataReader.GetOrdinal("ShippingStateID"));
                        ShippingCountryID = dataReader.GetInt32(dataReader.GetOrdinal("ShippingCountryID"));

                        City = dataReader.GetString(dataReader.GetOrdinal("City"));
                        State = dataReader.GetString(dataReader.GetOrdinal("State"));
                        Country = dataReader.GetString(dataReader.GetOrdinal("Country"));

                        ShippingCity = dataReader.GetString(dataReader.GetOrdinal("ShippingCity"));
                        ShippingState = dataReader.GetString(dataReader.GetOrdinal("ShippingState"));
                        ShippingCountry = dataReader.GetString(dataReader.GetOrdinal("ShippingCountry"));


                        ShippingZip = dataReader.GetString(dataReader.GetOrdinal("ShippingZip"));
                        Status = dataReader.GetBoolean(dataReader.GetOrdinal("Status"));
                        AuditUserID = dataReader.GetInt32(dataReader.GetOrdinal("AuditUserID"));
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("SupplierDL", "GetSupplierInformation");
            }
        }

        public DataSet GetAllSuppliers()
        {
            try
            {
	            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "usp_Supplier_GetAllSuppliers";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("SupplierDL", "GetAllSuppliers", "", ex.Message);
            }
            return null;
        }

        public List<Supplier> GetAllSuppliersList()
        {            
            try
            {
                List<Supplier> SupplierLIst = new List<Supplier>();
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "usp_Supplier_GetAllSuppliers";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                
                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    Supplier obj = new Supplier();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            obj = new Supplier();

                            obj.SupplierId = dataReader.GetInt32(dataReader.GetOrdinal("SupplierId"));
                            obj.CompanyID = dataReader.GetInt32(dataReader.GetOrdinal("CompanyID"));
                            obj.SupplierName = dataReader.GetString(dataReader.GetOrdinal("SupplierName"));
                            obj.ContactName = dataReader.GetString(dataReader.GetOrdinal("ContactName"));
                            obj.Phone = dataReader.GetString(dataReader.GetOrdinal("Phone"));
                            obj.Email = dataReader.GetString(dataReader.GetOrdinal("Email"));
                            obj.TIN = dataReader.GetString(dataReader.GetOrdinal("TIN"));
                            obj.PrivateSupplierDetails = dataReader.GetString(dataReader.GetOrdinal("PrivateSupplierDetails"));
                            obj.OtherSupplierDetails = dataReader.GetString(dataReader.GetOrdinal("OtherSupplierDetails"));
                            obj.BillingAddress = dataReader.GetString(dataReader.GetOrdinal("BillingAddress"));
                            obj.CityID = dataReader.GetInt32(dataReader.GetOrdinal("CityID"));
                            obj.StateID = dataReader.GetInt32(dataReader.GetOrdinal("StateID"));
                            obj.CountryID = dataReader.GetInt32(dataReader.GetOrdinal("CountryID"));
                            obj.Zip = dataReader.GetString(dataReader.GetOrdinal("Zip"));
                            obj.ShipToDifferentAddress = dataReader.GetBoolean(dataReader.GetOrdinal("ShipToDifferentAddress"));
                            obj.ShippingAddress = dataReader.GetString(dataReader.GetOrdinal("ShippingAddress"));
                            obj.ShippingCityID = dataReader.GetInt32(dataReader.GetOrdinal("ShippingCityID"));
                            obj.ShippingStateID = dataReader.GetInt32(dataReader.GetOrdinal("ShippingStateID"));
                            obj.ShippingCountryID = dataReader.GetInt32(dataReader.GetOrdinal("ShippingCountryID"));

                            obj.City = dataReader.GetString(dataReader.GetOrdinal("City"));
                            obj.State = dataReader.GetString(dataReader.GetOrdinal("State"));
                            obj.Country = dataReader.GetString(dataReader.GetOrdinal("Country"));

                            obj.ShippingCity = dataReader.GetString(dataReader.GetOrdinal("ShippingCity"));
                            obj.ShippingState = dataReader.GetString(dataReader.GetOrdinal("ShippingState"));
                            obj.ShippingCountry = dataReader.GetString(dataReader.GetOrdinal("ShippingCountry"));

                            
                            obj.ShippingZip = dataReader.GetString(dataReader.GetOrdinal("ShippingZip"));
                            obj.Status = dataReader.GetBoolean(dataReader.GetOrdinal("Status"));
                            obj.AuditUserID = dataReader.GetInt32(dataReader.GetOrdinal("AuditUserID"));

                            SupplierLIst.Add(obj);
                        }
                    }
                    
                }
                return SupplierLIst;
            }
            catch (Exception ex)
            {
                return null;
                ErrorLog.LogErrorMessageToDB("SupplierDL", "GetSupplierInformation");
            }
        }

    }
}

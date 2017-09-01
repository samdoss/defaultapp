
using ERP.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
namespace ERP.DataLayer
{
    public class Client
    {
        public Client()
        {

        }
        
        public Client(int clientId)
        {
            GetClientInformation(clientId);
            
        }
        
        public Client(int clientId, string clientName)
        {
            this.ClientId = clientId;
            this.ClientName = clientName;
        }

        #region Private Variables

        ApplicationConnection _appConnection = new ApplicationConnection();
        
        public int CompanyID { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string TIN { get; set; }
        public string PrivateClientDetails { get; set; }
        public string OtherClientDetails { get; set; }
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
                            _result = AddClient(db, transaction);
                                    if (_result.Status == TransactionStatus.Failure)
                                    {
                                        transaction.Rollback();
                                        return _result;
                                    }                                
                            break;
                        case ScreenMode.Edit:
                            
                                _result = UpdateClient( db, transaction);
                                if (_result.Status == TransactionStatus.Failure)
                                {
                                    transaction.Rollback();
                                    return _result;
                                }
                            
                            break;
                        case ScreenMode.Delete:

                            _result = DeactivateClient(db, transaction);
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
                        return new TransactionResult(TransactionStatus.Failure, "Failure Adding Client.");
                    if (screenMode == ScreenMode.Edit)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Updating Client.");
                    if (screenMode == ScreenMode.Delete)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Client.");
                }
            }
            return null;
        }

        #endregion

        private TransactionResult AddClient(Database db, DbTransaction transaction)
        {            
            string sqlCommand = "usp_Client_InsertClientDetails";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, CompanyID);
            db.AddInParameter(dbCommand, "ClientId", DbType.Int32, ClientId);
            db.AddInParameter(dbCommand, "ClientName", DbType.String, ClientName);
            db.AddInParameter(dbCommand, "ContactName", DbType.String, ContactName);
            db.AddInParameter(dbCommand, "Phone", DbType.String, Phone);
            db.AddInParameter(dbCommand, "Email", DbType.String, Email);
            db.AddInParameter(dbCommand, "TIN", DbType.String, TIN);
            db.AddInParameter(dbCommand, "PrivateClientDetails", DbType.String, PrivateClientDetails);
            db.AddInParameter(dbCommand, "OtherClientDetails", DbType.String, OtherClientDetails);
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
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding Client.");
            else
            {
                ClientId = returnValue;
                return new TransactionResult(TransactionStatus.Success, "Client Successfully Added.");
            }            
        }

        private TransactionResult UpdateClient(Database db, DbTransaction transaction)
        {
            
            string sqlCommand = "usp_Client_UpdateClient";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, CompanyID);
            db.AddInParameter(dbCommand, "ClientId", DbType.Int32, ClientId);
            db.AddInParameter(dbCommand, "ClientName", DbType.String, ClientName);
            db.AddInParameter(dbCommand, "ContactName", DbType.String, ContactName);
            db.AddInParameter(dbCommand, "Phone", DbType.String, Phone);
            db.AddInParameter(dbCommand, "Email", DbType.String, Email);
            db.AddInParameter(dbCommand, "TIN", DbType.String, TIN);
            db.AddInParameter(dbCommand, "PrivateClientDetails", DbType.String, PrivateClientDetails);
            db.AddInParameter(dbCommand, "OtherClientDetails", DbType.String, OtherClientDetails);
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
                ClientId = returnValue;
                return new TransactionResult(TransactionStatus.Success, "Company Information Successfully Updated.");
            }
        }

        private TransactionResult DeactivateClient(Database db, DbTransaction transaction)
        {
            
            string sqlCommand = "usp_Client_DeactivateClient";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "ClientId", DbType.Int32, ClientId);
            int returnValue = -1;
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Client Information.");
            else
                return new TransactionResult(TransactionStatus.Success, "Client Information Successfully Deleted.");
        }

        private void GetClientInformation(int clientID)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "usp_Client_GetClientDetails";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ClientId", DbType.Int32, clientID);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        ClientId = dataReader.GetInt32(dataReader.GetOrdinal("ClientId"));
                        CompanyID = dataReader.GetInt32(dataReader.GetOrdinal("CompanyID"));
                        ClientName = dataReader.GetString(dataReader.GetOrdinal("ClientName"));
                        ContactName = dataReader.GetString(dataReader.GetOrdinal("ContactName"));
                        Phone = dataReader.GetString(dataReader.GetOrdinal("Phone"));
                        Email = dataReader.GetString(dataReader.GetOrdinal("Email"));
                        TIN = dataReader.GetString(dataReader.GetOrdinal("Tin"));
                        PrivateClientDetails = dataReader.GetString(dataReader.GetOrdinal("PrivateClientDetails"));
                        OtherClientDetails = dataReader.GetString(dataReader.GetOrdinal("OtherClientDetails"));
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
                ErrorLog.LogErrorMessageToDB("ClientDL", "GetClientInformation");
            }
        }

        public DataSet GetAllClients()
        {
            try
            {
	            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "usp_Client_GetAllClients";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("ClientDL", "GetAllClients", "", ex.Message);
            }
            return null;
        }

	    public DataSet GetAllClientsDropDownList()
	    {
		    try
		    {
			    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
				string sqlCommand = "usp_Client_GetAllClientsDropDownList";
			    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			    return db.ExecuteDataSet(dbCommand);
		    }
		    catch (Exception ex)
		    {
			    ErrorLog.LogErrorMessageToDB("ClientDL", "GetAllClients", "", ex.Message);
		    }
		    return null;
	    }

        public List<Client> GetAllClientsList()
        {            
            try
            {
                List<Client> clientLIst = new List<Client>();
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "usp_Client_GetAllClients";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                
                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    Client obj = new Client();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            obj = new Client();

                            obj.ClientId = dataReader.GetInt32(dataReader.GetOrdinal("ClientId"));
                            obj.CompanyID = dataReader.GetInt32(dataReader.GetOrdinal("CompanyID"));
                            obj.ClientName = dataReader.GetString(dataReader.GetOrdinal("ClientName"));
                            obj.ContactName = dataReader.GetString(dataReader.GetOrdinal("ContactName"));
                            obj.Phone = dataReader.GetString(dataReader.GetOrdinal("Phone"));
                            obj.Email = dataReader.GetString(dataReader.GetOrdinal("Email"));
                            obj.TIN = dataReader.GetString(dataReader.GetOrdinal("TIN"));
                            obj.PrivateClientDetails = dataReader.GetString(dataReader.GetOrdinal("PrivateClientDetails"));
                            obj.OtherClientDetails = dataReader.GetString(dataReader.GetOrdinal("OtherClientDetails"));
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

                            clientLIst.Add(obj);
                        }
                    }
                    
                }
                return clientLIst;
            }
            catch (Exception ex)
            {
                return null;
                ErrorLog.LogErrorMessageToDB("ClientDL", "GetClientInformation");
            }
        }

    }
}

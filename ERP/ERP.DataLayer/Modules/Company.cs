using ERP.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
namespace ERP.DataLayer
{
    public class Company
    {
	    ApplicationConnection _appConnection = new ApplicationConnection();

        public Company()
        {

        }
        public Company(int companyId)
        {
            GetCompanyInformation(companyId);
        }
        public int BankID { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankIFSC { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string TIN { get; set; }
        public int CountryID { get; set; }
        public string ServiceTaxNo { get; set; }
        public string Address { get; set; }
        public string PAN { get; set; }
        public string AdditionalDetails { get; set; }
        public int CityID { get; set; }
        public int StateID { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public string Zip { get; set; }
        public string Currency { get; set; }
        public string CompanyPhone { get; set; }
        public string Logo { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
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
                            _result = AddCompany(db, transaction);
                            if (_result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return _result;
                            }
                            break;
                        case ScreenMode.Edit:

                            _result = UpdateCompany(db, transaction);
                            if (_result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return _result;
                            }

                            break;
                        case ScreenMode.Delete:

                            //_result = DeactivateCompany(db, transaction);
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
                        return new TransactionResult(TransactionStatus.Failure, "Failure Adding Company.");
                    if (screenMode == ScreenMode.Edit)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Updating Company.");
                    if (screenMode == ScreenMode.Delete)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Company.");
                }
            }
            return null;
        }

        #endregion
        
        private TransactionResult AddCompany(Database db, DbTransaction transaction)
        {
            string sqlCommand = "usp_Company_InsertCompanyDetails";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "CompanyName", DbType.String, CompanyName);
            db.AddInParameter(dbCommand, "CountryID", DbType.Int32, CountryID);
            db.AddInParameter(dbCommand, "Address", DbType.String, Address);
            db.AddInParameter(dbCommand, "CityID", DbType.Int32, CityID);
            db.AddInParameter(dbCommand, "StateID", DbType.Int32, StateID);
            db.AddInParameter(dbCommand, "CompanyPhone", DbType.String, CompanyPhone);
            db.AddInParameter(dbCommand, "Email", DbType.String, Email);
            db.AddInParameter(dbCommand, "Website", DbType.String, Website);
            db.AddInParameter(dbCommand, "TIN", DbType.String, TIN);
	        db.AddInParameter(dbCommand, "Zip", DbType.String, Zip);
            db.AddInParameter(dbCommand, "BankID", System.Data.DbType.Int32, Convert.ToInt32(BankID));
            db.AddInParameter(dbCommand, "BankAccountNo", System.Data.DbType.String, BankAccountNumber);
            db.AddInParameter(dbCommand, "BankIFSC", System.Data.DbType.String, BankIFSC);
            
            db.AddInParameter(dbCommand, "ServiceTaxNo", DbType.String, ServiceTaxNo);
            db.AddInParameter(dbCommand, "AdditionalDetails", DbType.String, AdditionalDetails);
            db.AddInParameter(dbCommand, "PAN", DbType.String, PAN);
            db.AddInParameter(dbCommand, "Currency", DbType.String, Currency);
            db.AddInParameter(dbCommand, "Logo", DbType.String, Logo);
            db.AddInParameter(dbCommand, "Status", DbType.Boolean, Status);


            int returnValue = 0;
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding Company.");
            else
            {
                CompanyId = returnValue;
                return new TransactionResult(TransactionStatus.Success, "Company Successfully Added.");
            }
        }

		private TransactionResult UpdateCompany(Database db, DbTransaction transaction)
        {

            string sqlCommand = "usp_Company_UpdateCompany";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "CompanyId", DbType.Int32, CompanyId);
            db.AddInParameter(dbCommand, "CompanyName", DbType.String, CompanyName);
            db.AddInParameter(dbCommand, "CountryID", DbType.Int32, CountryID);
            db.AddInParameter(dbCommand, "Address", DbType.String, Address);
            db.AddInParameter(dbCommand, "CityID", DbType.Int32, CityID);
            db.AddInParameter(dbCommand, "StateID", DbType.Int32, StateID);
            db.AddInParameter(dbCommand, "CompanyPhone", DbType.String, CompanyPhone);
            db.AddInParameter(dbCommand, "Email", DbType.String, Email);
            db.AddInParameter(dbCommand, "Website", DbType.String, Website);
            db.AddInParameter(dbCommand, "TIN", DbType.String, TIN);
	        db.AddInParameter(dbCommand, "Zip", DbType.String, Zip);
            db.AddInParameter(dbCommand, "BankID", System.Data.DbType.Int32, Convert.ToInt32(BankID));
            db.AddInParameter(dbCommand, "BankAccountNo", System.Data.DbType.String, BankAccountNumber);
            db.AddInParameter(dbCommand, "BankIFSC", System.Data.DbType.String, BankIFSC);
            db.AddInParameter(dbCommand, "ServiceTaxNo", DbType.String, ServiceTaxNo);
            db.AddInParameter(dbCommand, "AdditionalDetails", DbType.String, AdditionalDetails);
            db.AddInParameter(dbCommand, "PAN", DbType.String, PAN);
            db.AddInParameter(dbCommand, "Currency", DbType.String, Currency);
            db.AddInParameter(dbCommand, "Logo", DbType.String, Logo);
            db.AddInParameter(dbCommand, "Status", DbType.Boolean, Status);

            int returnValue = -1;
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Updating Company Information.");
            else
            {
                CompanyId = returnValue;
                return new TransactionResult(TransactionStatus.Success, "Company Information Successfully Updated.");
            }
        }

        public DataSet GetAllCompany()
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "usp_Company_GetAllCompany";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
				ErrorLog.LogErrorMessageToDB("CompanyDL", "GetAllCompany", "", ex.Message);
            }
            return null;
        }

        public List<Company> GetAllCompanyList()
        {
            try
            {
                List<Company> companyList = new List<Company>();
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "usp_Company_GetAllCompany";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
					Company obj = new Company();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
							obj = new Company();

							obj.CompanyId = dataReader.GetInt32(dataReader.GetOrdinal("CompanyId"));
	                        obj.CompanyName = dataReader.GetString(dataReader.GetOrdinal("CompanyName"));
	                        obj.TIN = dataReader.GetString(dataReader.GetOrdinal("TIN"));
	                        obj.ServiceTaxNo = dataReader.GetString(dataReader.GetOrdinal("ServiceTaxNo"));
	                        obj.Address = dataReader.GetString(dataReader.GetOrdinal("Address"));
	                        obj.PAN = dataReader.GetString(dataReader.GetOrdinal("Pan"));
	                        obj.AdditionalDetails = dataReader.GetString(dataReader.GetOrdinal("AdditionalDetails"));
	                        obj.Zip = dataReader.GetString(dataReader.GetOrdinal("Zip"));
	                        obj.CountryID = dataReader.GetInt32(dataReader.GetOrdinal("CountryID"));
	                        obj.StateID = dataReader.GetInt32(dataReader.GetOrdinal("StateID"));
	                        obj.CityID = dataReader.GetInt32(dataReader.GetOrdinal("CityID"));

                            obj.City = dataReader.GetString(dataReader.GetOrdinal("City"));
                            obj.State = dataReader.GetString(dataReader.GetOrdinal("State"));
                            obj.Country = dataReader.GetString(dataReader.GetOrdinal("Country"));
                            obj.BankID = dataReader.GetInt32(dataReader.GetOrdinal("BankID"));
                            obj.BankName = dataReader.GetString(dataReader.GetOrdinal("BankName"));
                            obj.BankAccountNumber = dataReader.GetString(dataReader.GetOrdinal("BankAccountNumber"));
                            obj.BankIFSC = dataReader.GetString(dataReader.GetOrdinal("BankIFSC"));

	                        obj.Currency = dataReader.GetString(dataReader.GetOrdinal("Currency"));
	                        obj.CompanyPhone = dataReader.GetString(dataReader.GetOrdinal("CompanyPhone"));
	                        obj.Logo = dataReader.GetString(dataReader.GetOrdinal("Logo"));
	                        obj.Email = dataReader.GetString(dataReader.GetOrdinal("Email"));
	                        obj.Website = dataReader.GetString(dataReader.GetOrdinal("Website"));
	                        obj.Status = dataReader.GetBoolean(dataReader.GetOrdinal("Status"));

                            companyList.Add(obj);
                        }
                    }

                }
                return companyList;
            }
            catch (Exception ex)
            {
                return null;
				ErrorLog.LogErrorMessageToDB("CompanyDL", "GetAllCompanyList");
            }
        }


	    private void GetCompanyInformation(int companyID)
	    {
		    try
		    {
			    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
				string sqlCommand = "usp_Company_GetCompanyDetails";
			    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
				db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, companyID);

			    using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
			    {
				    if (dataReader.HasRows)
				    {
					    dataReader.Read();
						CompanyId = dataReader.GetInt32(dataReader.GetOrdinal("CompanyId"));
					    CompanyName = dataReader.GetString(dataReader.GetOrdinal("CompanyName"));
					    TIN = dataReader.GetString(dataReader.GetOrdinal("TIN"));
					    ServiceTaxNo = dataReader.GetString(dataReader.GetOrdinal("ServiceTaxNo"));
					    Address = dataReader.GetString(dataReader.GetOrdinal("Address"));
					    PAN = dataReader.GetString(dataReader.GetOrdinal("Pan"));
					    AdditionalDetails = dataReader.GetString(dataReader.GetOrdinal("AdditionalDetails"));
					    Zip = dataReader.GetString(dataReader.GetOrdinal("Zip"));
					    CountryID = dataReader.GetInt32(dataReader.GetOrdinal("CountryID"));
					    StateID = dataReader.GetInt32(dataReader.GetOrdinal("StateID"));
					    CityID = dataReader.GetInt32(dataReader.GetOrdinal("CityID"));

                        City = dataReader.GetString(dataReader.GetOrdinal("City"));
                        State = dataReader.GetString(dataReader.GetOrdinal("State"));
                        Country = dataReader.GetString(dataReader.GetOrdinal("Country"));

                        BankID = dataReader.GetInt32(dataReader.GetOrdinal("BankID"));
                        BankName = dataReader.GetString(dataReader.GetOrdinal("BankName"));
                        BankAccountNumber = dataReader.GetString(dataReader.GetOrdinal("BankAccountNumber"));
                        BankIFSC = dataReader.GetString(dataReader.GetOrdinal("BankIFSC"));

					    Currency = dataReader.GetString(dataReader.GetOrdinal("Currency"));
					    CompanyPhone = dataReader.GetString(dataReader.GetOrdinal("CompanyPhone"));
					    Logo = dataReader.GetString(dataReader.GetOrdinal("Logo"));
					    Email = dataReader.GetString(dataReader.GetOrdinal("Email"));
					    Website = dataReader.GetString(dataReader.GetOrdinal("Website"));
					    Status = dataReader.GetBoolean(dataReader.GetOrdinal("Status"));
				    }
			    }
		    }
		    catch (Exception ex)
		    {
				ErrorLog.LogErrorMessageToDB("CompanyDL", "GetCompanyInformation");
		    }
	    }
    }
}

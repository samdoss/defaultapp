using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.CommonLayer;

namespace ERP.DataLayer
{
    public class CompanyInformation
    {

        #region Constructor(s)

        public CompanyInformation(){}

        public CompanyInformation(string HospitalID, bool getallproperties)
        {
            if (getallproperties)
            {
                //Calling private method to get all values from the database
                //Assign the values to local variables
                GetCompanyInformation(HospitalID);
            }
        }

        #endregion

        #region Private Variables

        ApplicationConnection _appConnection = new ApplicationConnection();
        private int _CompanyInformationID;
        private string _companyName;
        private string _RegistrationNumber;
        private string _Address1;
        private string _Address2;
        private string _Address3;
        private string _Area;
        private int _CityID;
        private int _StateID;
        private int _CountryID;
        private string _Pincode;
        private string _Std1;
        private string _Std2;
        private string _Std3;
        private string _Phone1;
        private string _Phone2;
        private string _Phone3;
        private string _FaxNo;
        private string _EmailID;
        private string _Website;
        private int _AuditUserID;
        private DateTime _AuditDate;
        private bool _IsEnabled;        

        #endregion

        #region public properties

        public int CompanyInformationID
        {
            get { return _CompanyInformationID; }
            set { _CompanyInformationID = value; }
        }

        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }
        
        public string RegistrationNumber
        {
            get { return _RegistrationNumber; }
            set { _RegistrationNumber = value; }
        }
        
        public string Address1
        {
            get { return _Address1; }
            set { _Address1 = value; }
        }
        
        public string Address2
        {
            get { return _Address2; }
            set { _Address2 = value; }
        }
        
        public string Address3
        {
            get { return _Address3; }
            set { _Address3 = value; }
        }
        
        public string Area
        {
            get { return _Area; }
            set { _Area = value; }
        }
        
        public int CityID
        {
            get { return _CityID; }
            set { _CityID = value; }
        }
        
        public int StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }
        
        public int CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }
        
        public string Pincode
        {
            get { return _Pincode; }
            set { _Pincode = value; }
        }
        
        public string Std1
        {
            get { return _Std1; }
            set { _Std1 = value; }
        }
        
        public string Std2
        {
            get { return _Std2; }
            set { _Std2 = value; }
        }
        
        public string Std3
        {
            get { return _Std3; }
            set { _Std3 = value; }
        }

        public string Phone1
        {
            get { return _Phone1; }
            set { _Phone1 = value; }
        }
        
        public string Phone2
        {
            get { return _Phone2; }
            set { _Phone2 = value; }
        }
        
        public string Phone3
        {
            get { return _Phone3; }
            set { _Phone3 = value; }
        }

        public string FaxNo
        {
            get { return _FaxNo; }
            set { _FaxNo = value; }
        }

        public string EmailID
        {
            get { return _EmailID; }
            set { _EmailID = value; }
        }

        public string Website
        {
            get { return _Website; }
            set { _Website = value; }
        }
        
        public int AuditUserID
        {
            get { return _AuditUserID; }
            set { _AuditUserID = value; }
        }

        public DateTime AuditDate
        {
            get { return _AuditDate; }
            set { _AuditDate = value; }
        }

        public bool IsEnabled
        {
            get { return _IsEnabled; }
            set { _IsEnabled = value; }
        }

        #endregion

        #region Public Methods

        public TransactionResult Commit(ScreenMode screenMode)
        {
            TransactionResult _result = null;
            try
            {
                switch (screenMode)
                {
                    case ScreenMode.Add:
                        _result = AddCompanyInformation();
                        break;
                    case ScreenMode.Edit:
                        _result = UpdateCompanyInformation();
                        break;
                }
                return _result;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("CompanyInformation", "Commit");
            }
            return null;
        }

        #endregion

        #region Private Methods

        private TransactionResult AddCompanyInformation()
        {
            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
            string sqlCommand = "spAddCompanyInformation";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "CompanyInformationID", DbType.Int32, _CompanyInformationID);
            db.AddInParameter(dbCommand, "CompanyName", DbType.String, _companyName);
            db.AddInParameter(dbCommand, "RegistrationNo", DbType.String, _RegistrationNumber);
            db.AddInParameter(dbCommand, "Address1", DbType.String, _Address1);
            db.AddInParameter(dbCommand, "Address2", DbType.String, _Address2);
            db.AddInParameter(dbCommand, "Address3", DbType.String, _Address3);
            db.AddInParameter(dbCommand, "Area", DbType.String, _Area);
            db.AddInParameter(dbCommand, "CountryID", DbType.Int32, _CountryID);
            db.AddInParameter(dbCommand, "StateID", DbType.Int32, _StateID);
            db.AddInParameter(dbCommand, "CityID", DbType.Int32, _CityID);
            db.AddInParameter(dbCommand, "PinCode", DbType.String, _Pincode);

            db.AddInParameter(dbCommand, "STD1", DbType.String, _Std1);
            db.AddInParameter(dbCommand, "Phone1", DbType.String, _Phone1);

            db.AddInParameter(dbCommand, "STD2", DbType.String, _Std2);
            db.AddInParameter(dbCommand, "Phone2", DbType.String, _Phone2);

            db.AddInParameter(dbCommand, "STD3", DbType.String, _Std3);
            db.AddInParameter(dbCommand, "Phone3", DbType.String, _Phone3);

            db.AddInParameter(dbCommand, "FaxNo", DbType.String, _FaxNo);

            db.AddInParameter(dbCommand, "EmailID", DbType.String, _EmailID);
            db.AddInParameter(dbCommand, "Website", DbType.String, _Website);

            db.AddInParameter(dbCommand, "AuditUserID", DbType.Int32, _AuditUserID);
            
            int returnValue = -1;
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, returnValue);

            db.ExecuteNonQuery(dbCommand);
            returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (returnValue == -1)
               return new TransactionResult(TransactionStatus.Failure, "Failure Adding Hospital Information.");
            else
                return new TransactionResult(TransactionStatus.Success, "Hospital Information Successfully Added.");
        }

        private TransactionResult UpdateCompanyInformation()
        {
            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spUpdateCompanyInformation";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "CompanyID", DbType.String, _CompanyInformationID);
                db.AddInParameter(dbCommand, "CompanyName", DbType.String, _companyName);
                db.AddInParameter(dbCommand, "RegistrationNo", DbType.String, _RegistrationNumber);
                db.AddInParameter(dbCommand, "Address1", DbType.String, _Address1);
                db.AddInParameter(dbCommand, "Address2", DbType.String, _Address2);
                db.AddInParameter(dbCommand, "Address3", DbType.String, _Address3);
                db.AddInParameter(dbCommand, "Area", DbType.String, _Area);
                db.AddInParameter(dbCommand, "CountryID", DbType.Int32, _CountryID);
                db.AddInParameter(dbCommand, "StateID", DbType.Int32, _StateID);
                db.AddInParameter(dbCommand, "CityID", DbType.Int32, _CityID);
                db.AddInParameter(dbCommand, "PinCode", DbType.String, _Pincode);

                db.AddInParameter(dbCommand, "STD1", DbType.String, _Std1);
                db.AddInParameter(dbCommand, "Phone1", DbType.String, _Phone1);

                db.AddInParameter(dbCommand, "STD2", DbType.String, _Std2);
                db.AddInParameter(dbCommand, "Phone2", DbType.String, _Phone2);

                db.AddInParameter(dbCommand, "STD3", DbType.String, _Std3);
                db.AddInParameter(dbCommand, "Phone3", DbType.String, _Phone3);

                db.AddInParameter(dbCommand, "FaxNo", DbType.String, _FaxNo);

                db.AddInParameter(dbCommand, "EmailID", DbType.String, _EmailID);
                db.AddInParameter(dbCommand, "Website", DbType.String, _Website);

                db.AddInParameter(dbCommand, "AuditUserID", DbType.Int32, _AuditUserID);
            
                int returnValue = -1;
                db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                                DataRowVersion.Default, returnValue);

                db.ExecuteNonQuery(dbCommand);
                returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

                if (returnValue == -1)
                    return new TransactionResult(TransactionStatus.Failure, "Failure Updating Company Information.");
                else
                    return new TransactionResult(TransactionStatus.Success, "Company Information Successfully Updated.");
        }

        private void GetCompanyInformation(string HospitalID)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetCompanyInformationDetail";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "CompanyInformationID", DbType.String, HospitalID);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        CompanyInformationID = dataReader.GetInt32(dataReader.GetOrdinal("CompanyID"));
                        CompanyName = dataReader.GetString(dataReader.GetOrdinal("CompanyName"));
                        RegistrationNumber = dataReader.GetString(dataReader.GetOrdinal("RegistrationNo"));
                        Address1 = dataReader.GetString(dataReader.GetOrdinal("AddressLine1"));
                        Address2 = dataReader.GetString(dataReader.GetOrdinal("AddressLine2"));
                        Address3 = dataReader.GetString(dataReader.GetOrdinal("AddressLine3"));
                        Area = dataReader.GetString(dataReader.GetOrdinal("Area"));
                        CountryID = dataReader.GetInt32(dataReader.GetOrdinal("CountryID"));
                        StateID = dataReader.GetInt32(dataReader.GetOrdinal("StateID"));
                        CityID = dataReader.GetInt32(dataReader.GetOrdinal("CityID"));
                        Pincode = dataReader.GetString(dataReader.GetOrdinal("PostalCode"));
                        Std1 = dataReader.GetString(dataReader.GetOrdinal("STD1"));
                        Std2 = dataReader.GetString(dataReader.GetOrdinal("STD2"));
                        Std3 = dataReader.GetString(dataReader.GetOrdinal("STD3"));

                        Phone1 = dataReader.GetString(dataReader.GetOrdinal("Telephone1"));
                        Phone2 = dataReader.GetString(dataReader.GetOrdinal("Telephone2"));
                        Phone3 = dataReader.GetString(dataReader.GetOrdinal("Telephone3"));

                        FaxNo = dataReader.GetString(dataReader.GetOrdinal("FaxNo"));
                        EmailID = dataReader.GetString(dataReader.GetOrdinal("EmailID"));
                        Website = dataReader.GetString(dataReader.GetOrdinal("Website"));
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("CompanyInformation", "GetCompanyInformation");
            }
        }

        #endregion
    }
}

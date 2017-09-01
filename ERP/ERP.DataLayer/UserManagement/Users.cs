using System.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using ERP.CommonLayer;

namespace ERP.DataLayer
{
    public class Users
    {
        #region Constructor(s)
        
        public Users(){ }

        public Users(int UserID, bool getallproperties) 
        {
            _UserID = UserID;
            if (getallproperties)
            {
                //Calling private method to get all values from the database
                //Assign the values to local variables
                GetUser(_UserID); 
            }
        }

        #endregion

        #region Private Variables

        ApplicationConnection _appConnection = new ApplicationConnection();
        
        
        //Users Table
        private int _UserID;
        private string _UserName;
        private string _Password;
        private int _TitleID;
        private string _Title;
        private string _Name;
        private string _RegistrationNumber;
        private DateTime _DateOfBirth;
        private Int16 _GenderID;
        private Int16 _RoleID;
        private string _RoleName;
        private string _Designation;
        private string _Qualification;
        private int _AuditUserID;
        private DateTime _AuditDate;
        private bool _IsEnabled;
        private byte[] _Photo;

        //Address Table
        private Address _addressList;
        //ContactInformation Table
        private List<ContactInformation> _ContactInformation;
        
        #endregion

        #region Public Properties

        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public int TitleID
        {
            get { return _TitleID; }
            set { _TitleID = value; }
        }

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string RegistrationNumber
        {
            get { return _RegistrationNumber; }
            set { _RegistrationNumber = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; }
        }

        public Int16 GenderID
        {
            get { return _GenderID; }
            set { _GenderID = value; }
        }

        public Int16 RoleID
        {
            get { return _RoleID; }
            set { _RoleID = value; }
        }

        public string RoleName
        {
            get { return _RoleName; }
            set { _RoleName = value; }
        }

        public string Designation
        {
            get { return _Designation; }
            set { _Designation = value; }
        }

        public string Qualification
        {
            get { return _Qualification; }
            set { _Qualification = value; }
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

        public Address AddressList
        {
            get{return _addressList;}
            set { _addressList = value; }
        }

        public List<ContactInformation> ContactInformation
        {
            get { return _ContactInformation; }
            set { _ContactInformation = value; }
        }

        public byte[] Photo
        {
            get { return _Photo; }
            set { _Photo = value; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get all Users List for fill the User data to List Box
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        
        public static DataSet GetUsersList(ApplicationConnection _appConnection)
        {
            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
            string sqlCommand = "spGetUserList";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            return db.ExecuteDataSet(dbCommand);
        }

        public string GetUserDetail(int userID)
        {
            try
            {
                string userRegNo = "";
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetUserDetail";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userID);
                SqlDataReader dr = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader; // (SqlDataReader)db.ExecuteReader(dbCommand))
                if (dr.Read())
                {
                    if (dr[0] != null)
                    {
                        userRegNo = dr[1].ToString().Trim();
                    }
                }
                dr.Close();
                return userRegNo;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Users", "GetUserDetail");
            }
            return null;
        }

        public string GetUserContactDetail(int userID)
        {
            try
            {
                string userPhoneNo = "";
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetUserContactDetail";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userID);
                SqlDataReader dr = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader; // (SqlDataReader)db.ExecuteReader(dbCommand))
                if (dr.Read())
                {
                    if (dr[0] != null)
                    {
                        userPhoneNo = dr[2].ToString().Trim();
                    }
                }
                dr.Close();
                return userPhoneNo;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Users", "GetUserContactDetail");
            }
            return null;
        }

        public string GetUserQualificationDetail(int userID)
        {
            try
            {
                string userQualification = "";
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetUserQualificationDetail";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userID);
                SqlDataReader dr = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader; // (SqlDataReader)db.ExecuteReader(dbCommand))
                if (dr.Read())
                {
                    if (dr[0] != null)
                    {
                        userQualification = dr[1].ToString().Trim();
                    }
                }
                dr.Close();
                return userQualification;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Users", "GetUserQualificationDetail");
            }
            return null;
        }

        /// <summary>
        /// Enable or Disable the User
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="UserID">User ID</param>
        
        public static TransactionResult EnableOrDisableUser(ApplicationConnection _appConnection, int UserID, bool EnableOrDisable)
        {
            int _returnValue = 0;
            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
            string sqlCommand = "spEnableOrDisableUser";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "UserID", DbType.Int32, UserID);
            db.AddInParameter(dbCommand, "EnableOrDisable", DbType.Boolean, EnableOrDisable);
            db.AddParameter(dbCommand, "Return Value", DbType.String, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);
            db.ExecuteNonQuery(dbCommand);
            _returnValue = Convert.ToInt32(db.GetParameterValue(dbCommand, "Return Value"));

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure);
            else
                return new TransactionResult(TransactionStatus.Success);
        }

        public TransactionResult Commit(ScreenMode screenMode)
        {
            TransactionResult _result = null;
            switch (screenMode)
            {
                case ScreenMode.Add:
                    _result = AddUser();
                    break;
                case ScreenMode.Edit:
                    _result = UpdateUser(); 
                    break;
            }
            return _result; 
        }

        #endregion

        #region Private Methods

        private TransactionResult AddUser()
        {
            int _returnValue = 0;
            string sContactInfo = "";
            
            if (_ContactInformation != null)
            {
                foreach (ContactInformation contact in _ContactInformation)
                {
                    sContactInfo = sContactInfo + contact.ContactTypeID.ToString() + ",'" + contact.ContactSTD.ToString() + "','" + contact.ContactNumber.ToString() + "'," + _AuditUserID.ToString() + "^";
                }
            }

            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
            string sqlCommand = "spAddUser";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "UserName", DbType.String, _UserName);
            db.AddInParameter(dbCommand, "Password", DbType.String, _Password);
            db.AddInParameter(dbCommand, "TitleID", DbType.Int16, _TitleID);
            db.AddInParameter(dbCommand, "Name", DbType.String, _Name);
            db.AddInParameter(dbCommand, "RegistrationNumber", DbType.String, _RegistrationNumber);
            db.AddInParameter(dbCommand, "DateOfBirth", DbType.DateTime, _DateOfBirth);
            db.AddInParameter(dbCommand, "GenderID", DbType.Int16, _GenderID);
            db.AddInParameter(dbCommand, "RoleID", DbType.Int16, _RoleID);
            db.AddInParameter(dbCommand, "Designation", DbType.String, _Designation);
            db.AddInParameter(dbCommand, "Qualification", DbType.String, _Qualification);
            db.AddInParameter(dbCommand, "AuditUserID", DbType.Int32, _AuditUserID);
            
            db.AddInParameter(dbCommand, "Address1", DbType.String, _addressList.Address1);
            db.AddInParameter(dbCommand, "Address2", DbType.String, _addressList.Address2);
            db.AddInParameter(dbCommand, "Address3", DbType.String, _addressList.Address3);
            db.AddInParameter(dbCommand, "Area", DbType.String, _addressList.Area);
            db.AddInParameter(dbCommand, "StateID", DbType.String, _addressList.StateID);
            db.AddInParameter(dbCommand, "CityID", DbType.String, _addressList.CityID);
            db.AddInParameter(dbCommand, "CountryID", DbType.String, _addressList.CountryID);
            db.AddInParameter(dbCommand, "ZipCode", DbType.String, _addressList.ZipCode);
            db.AddInParameter(dbCommand, "EmailID", DbType.String, _addressList.Email);
            db.AddInParameter(dbCommand, "ContactInformation", DbType.String, sContactInfo);
            db.AddInParameter(dbCommand, "Photo", DbType.Binary, _Photo);

            db.AddParameter(dbCommand, "Return Value", DbType.String, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);
            db.ExecuteNonQuery(dbCommand);
            _returnValue = Convert.ToInt32(db.GetParameterValue(dbCommand, "Return Value"));

            if (_returnValue == -1)
            {
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding User Information");
            }
            else
            {
                return new TransactionResult(TransactionStatus.Success, "User Information Successfully Added.");
            }
        }

        private TransactionResult UpdateUser()
        {
            int _returnValue = 0;
            string sContactInfo = "";
           if (_ContactInformation != null)
            {
                foreach (ContactInformation contact in _ContactInformation)
                {
                    sContactInfo = sContactInfo + contact.ContactTypeID.ToString() + ",'" + contact.ContactSTD.ToString() + "','" + contact.ContactNumber.ToString() + "'," + _AuditUserID.ToString() + "^";
                }
            }

            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
            string sqlCommand = "spUpdateUser";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "UserID", DbType.Int32, _UserID);
            db.AddInParameter(dbCommand, "TitleID", DbType.Int16, _TitleID);
            db.AddInParameter(dbCommand, "Name", DbType.String, _Name);
            db.AddInParameter(dbCommand, "RegistrationNumber", DbType.String, _RegistrationNumber);
            db.AddInParameter(dbCommand, "DateOfBirth", DbType.DateTime, _DateOfBirth);
            db.AddInParameter(dbCommand, "GenderID", DbType.Int16, _GenderID);
            db.AddInParameter(dbCommand, "RoleID", DbType.Int16, _RoleID);
            db.AddInParameter(dbCommand, "Designation", DbType.String, _Designation);
            db.AddInParameter(dbCommand, "Qualification", DbType.String, _Qualification);
            db.AddInParameter(dbCommand, "AuditUserID", DbType.Int32, _AuditUserID);
            
            db.AddInParameter(dbCommand, "AddressID", DbType.Int32, _addressList.AddressID);
            db.AddInParameter(dbCommand, "Address1", DbType.String, _addressList.Address1);
            db.AddInParameter(dbCommand, "Address2", DbType.String, _addressList.Address2);
            db.AddInParameter(dbCommand, "Address3", DbType.String, _addressList.Address3);
            db.AddInParameter(dbCommand, "Area", DbType.String, _addressList.Area);
            db.AddInParameter(dbCommand, "StateID", DbType.String, _addressList.StateID);
            db.AddInParameter(dbCommand, "CityID", DbType.String, _addressList.CityID);
            db.AddInParameter(dbCommand, "CountryID", DbType.String, _addressList.CountryID);
            db.AddInParameter(dbCommand, "ZipCode", DbType.String, _addressList.ZipCode);
            db.AddInParameter(dbCommand, "EmailID", DbType.String, _addressList.Email);
            db.AddInParameter(dbCommand, "ContactInformation", DbType.String, sContactInfo);
            db.AddInParameter(dbCommand, "Photo", DbType.Binary, _Photo);

            db.AddParameter(dbCommand, "Return Value", DbType.String, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);
            db.ExecuteNonQuery(dbCommand);
            _returnValue = Convert.ToInt32(db.GetParameterValue(dbCommand, "Return Value"));

            if (_returnValue == -1)
            {
                return new TransactionResult(TransactionStatus.Failure, "Failure Updating User Information");
            }
            else
            {
                return new TransactionResult(TransactionStatus.Success, "User Information Successfully Updated.");
            }
        }

        private void GetUser(int UserID)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetUser";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "UserID", DbType.Int32, _UserID);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        UserID = dataReader.GetInt32(dataReader.GetOrdinal("UserID"));
                        UserName = dataReader.GetString(dataReader.GetOrdinal("UserName"));
                        TitleID = dataReader.GetInt16(dataReader.GetOrdinal("TitleID"));
                        Title = dataReader.GetString(dataReader.GetOrdinal("Title"));
                        Name = dataReader.GetString(dataReader.GetOrdinal("Name"));
                        RegistrationNumber = dataReader.GetString(dataReader.GetOrdinal("RegistrationNumber"));
                        DateOfBirth = dataReader.GetDateTime(dataReader.GetOrdinal("DateOfBirth"));
                        GenderID = dataReader.GetInt16(dataReader.GetOrdinal("GenderID"));
                        RoleID = dataReader.GetInt16(dataReader.GetOrdinal("RoleID"));
                        RoleName = dataReader.GetString(dataReader.GetOrdinal("RoleName"));
                        Designation = dataReader.GetString(dataReader.GetOrdinal("Designation"));
                        Qualification = dataReader.GetString(dataReader.GetOrdinal("Qualification"));
                        AuditUserID = dataReader.GetInt32(dataReader.GetOrdinal("AuditUserID"));
                        AuditDate = dataReader.GetDateTime(dataReader.GetOrdinal("AuditDate"));
                        IsEnabled = dataReader.GetBoolean(dataReader.GetOrdinal("IsEnabled"));
                        if (dataReader["Photo"] != DBNull.Value)
                            Photo = (byte[])dataReader["Photo"];
                    }
                }
                int Category = 0;
                sqlCommand = "spGetAddress";
                dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "PHUDID", DbType.Int32, UserID);
                Category = Convert.ToInt32(AddressCategory.User);
                db.AddInParameter(dbCommand, "AddressCategoryID", DbType.String, Category);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    Address address = new Address();
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        address.AddressID = dataReader.GetInt32(dataReader.GetOrdinal("AddressID"));
                        address.PHUDID = dataReader.GetInt32(dataReader.GetOrdinal("PHUDID"));
                        address.AddressCategoryID = dataReader.GetInt16(dataReader.GetOrdinal("AddressCategoryID"));
                        address.Address1 = dataReader.GetString(dataReader.GetOrdinal("Address1"));
                        address.Address2 = dataReader.GetString(dataReader.GetOrdinal("Address2"));
                        address.Address3 = dataReader.GetString(dataReader.GetOrdinal("Address3"));
                        address.Area = dataReader.GetString(dataReader.GetOrdinal("Area"));
                        address.CityID = dataReader.GetInt32(dataReader.GetOrdinal("CityID"));
                        address.StateID = dataReader.GetInt32(dataReader.GetOrdinal("StateID"));
                        address.CountryID = dataReader.GetInt32(dataReader.GetOrdinal("CountryID"));
                        address.ZipCode = dataReader.GetString(dataReader.GetOrdinal("ZipCode"));
                        address.Email = dataReader.GetString(dataReader.GetOrdinal("Email"));
                        address.AuditUserID = dataReader.GetInt32(dataReader.GetOrdinal("AuditUserID"));
                        address.AuditDate = dataReader.GetDateTime(dataReader.GetOrdinal("AuditDate"));
                        AddressList = address;
                    }

                    if (address.AddressID != 0)
                    {
                        sqlCommand = "spGetContactInformation";
                        dbCommand = db.GetStoredProcCommand(sqlCommand);
                        db.AddInParameter(dbCommand, "AddressID", DbType.Int32, _addressList.AddressID);

                        List<ContactInformation> listUCI = new List<ContactInformation>();

                        using (SqlDataReader dataReaderS = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    ContactInformation structsCI;
                                    structsCI.ContactTypeID = dataReaderS.GetInt16(dataReaderS.GetOrdinal("ContactTypeID"));
                                    structsCI.AddressID = dataReaderS.GetInt32(dataReaderS.GetOrdinal("AddressID"));
                                    structsCI.ContactSTD = dataReaderS.GetString(dataReaderS.GetOrdinal("ContactSTD"));
                                    structsCI.ContactNumber = dataReaderS.GetString(dataReaderS.GetOrdinal("ContactNumber"));
                                    structsCI.AuditUserID = dataReaderS.GetInt32(dataReaderS.GetOrdinal("AuditUserID"));
                                    structsCI.AuditDate = dataReaderS.GetDateTime(dataReaderS.GetOrdinal("AuditDate"));
                                    listUCI.Add(structsCI);
                                }
                                ContactInformation = listUCI;
                            }
                        }
                    }
                }
          
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Users.cs", "GetUser");
            }
        }

        #endregion
    }
}


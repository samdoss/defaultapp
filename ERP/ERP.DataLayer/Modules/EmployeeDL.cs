using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.CommonLayer;
using System.Data;

namespace ERP.DataLayer
{
    public class EmployeeDL
    {
        private ApplicationConnection _myConnection;
        private ScreenMode _screenMode;

        private int _addEditOption;

        private int _employeeID;
        private string _employeeCode;

        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }
        private string _employeeName;
        private int _companyID;
        private string _companyName;
        private string _employeeFatherName;
        private string _employeeMotherName;
        private string _aadharNo;
        private string _dateOfBirth;

        public string DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public string AadharNo
        {
            get { return _aadharNo; }
            set { _aadharNo = value; }
        }

        public string EmployeeMotherName
        {
            get { return _employeeMotherName; }
            set { _employeeMotherName = value; }
        }

        private string _bankBranchCode;
        public string BankBranchCode
        {
            get { return _bankBranchCode; }
            set { _bankBranchCode = value; }
        }

        private string _homeEmail;
        private string _workEmail;

        private string _homePhone;
        private string _workPhone;

        private string _mobilePhone;

        private string _preferredEmployeeID;

        private string _comments;

        private int _bankID;

        private string _bankRegion;

        private int _auditUserID;

        private byte[] _photo;
        public byte[] Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }
        public int AuditUserID
        {
            get { return _auditUserID; }
            set { _auditUserID = value; }
        }

        public string BankRegion
        {
            get { return _bankRegion; }
            set { _bankRegion = value; }
        }
        private string _bankCompanyName;
        private string _bankAccountNumber;
        private string _bankBranch;

        public string BankBranch
        {
            get { return _bankBranch; }
            set { _bankBranch = value; }
        }
        private string _bankIFSC;

        public string BankIFSC
        {
            get { return _bankIFSC; }
            set { _bankIFSC = value; }
        }
        private string _bankBranchAddress;

        public string BankBranchAddress
        {
            get { return _bankBranchAddress; }
            set { _bankBranchAddress = value; }
        }

        private int _agentID;
        private string _pfNumber;
        public int AddEditOption
        {
            get
            {
                return _addEditOption;
            }
            set
            {
                _addEditOption = value;
            }
        }

        public string Comments
        {
            get
            {
                return _comments;
            }
            set
            {
                _comments = value;
            }
        }

        public int CompanyID
        {
            get
            {
                return _companyID;
            }
            set
            {
                _companyID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return _employeeID;
            }
            set
            {
                _employeeID = value;
            }
        }

      

        public string EmployeeName
        {
            get
            {
                return _employeeName;
            }
            set
            {
                _employeeName = value;
            }
        }

        public string HomeEmail
        {
            get
            {
                return _homeEmail;
            }
            set
            {
                _homeEmail = value;
            }
        }

        public string HomePhone
        {
            get
            {
                return _homePhone;
            }
            set
            {
                _homePhone = value;
            }
        }

        public string EmployeeFatherName
        {
            get
            {
                return _employeeFatherName;
            }
            set
            {
                _employeeFatherName = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return _mobilePhone;
            }
            set
            {
                _mobilePhone = value;
            }
        }

        public string WorkEmail
        {
            get
            {
                return _workEmail;
            }
            set
            {
                _workEmail = value;
            }
        }

        public string WorkPhone
        {
            get
            {
                return _workPhone;
            }
            set
            {
                _workPhone = value;
            }
        }

        public ScreenMode ScreenMode
        {
            get
            {
                return _screenMode;
            }
            set
            {
                _screenMode = value;
            }
        }

        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        public string PreferredEmployeeId
        {
            get { return _preferredEmployeeID; }
            set { _preferredEmployeeID = value; }
        }

        public int BankId
        {
            get { return _bankID; }
            set { _bankID = value; }
        }

        public string BankIfsc
        {
            get { return _bankIFSC; }
            set { _bankIFSC = value; }
        }

        public int AgentId
        {
            get { return _agentID; }
            set { _agentID = value; }
        }
       

        public string PFNumber
        {
            get { return _pfNumber; }
            set { _pfNumber = value; }
        }

        public string BankCompanyName
        {
            get { return _bankCompanyName; }
            set { _bankCompanyName = value; }
        }

        public string BankAccountNumber
        {
            get { return _bankAccountNumber; }
            set { _bankAccountNumber = value; }
        }

        private string _address1;
        public string Address1 { get { return _address1; } set { _address1 = value; } }

        private string _address2;
        public string Address2 { get { return _address2; } set { _address2 = value; } }

        private string _address3;
        public string Address3 { get { return _address3; } set { _address3 = value; } }

        private string _cityDescription;
        public string CityDescription { get {return _cityDescription; } set { _cityDescription = value; } }
          
        private int _cityID;
        public int CityID { get { return _cityID; } set { _cityID = value; } }

        private string _cityName;
        public string CityName { get { return _cityName; } set { _cityName = value; } }

        private int _districtID;
        public int DistrictID  { get {return _districtID; } set { _districtID  = value; } }

        private string _districtName;
        public string DistrictName  {get { return _districtName; } set { _districtName  = value; } }

        private int _stateID;
        public int StateID  {get { return _stateID; } set { _stateID = value; } }

        private string _stateName;
        public string StateName {get { return _stateName; } set { _stateName = value; } }

        private int _countryID;
        public int CountryID { get {return _countryID; } set { _countryID = value; } }

        private string _countryName;
        public string CountryName  {get { return _countryName; } set { _countryName = value; } }

        private string _postalCode;
        public string PostalCode  { get {return _postalCode; } set { _postalCode = value; } }

        public EmployeeDL()
            : base()
        {
            _myConnection = new ApplicationConnection();
            _employeeName = "";
            _employeeFatherName = "";
            _homeEmail = "";
            _workEmail = "";
            _homePhone = "";
            _workPhone = "";
            _mobilePhone = "";
            _comments = "";
            _addEditOption = 0;
        }

        public EmployeeDL(int EmployeeID, int companyID, bool allProperties)
            : base()
        {
            _myConnection = new ApplicationConnection();
            _employeeName = "";
            _employeeFatherName = "";
            _homeEmail = "";
            _workEmail = "";
            _homePhone = "";
            _workPhone = "";
            _mobilePhone = "";
            _comments = "";
            _addEditOption = 0;
            _employeeID = EmployeeID;
            _companyID = companyID;
            if (allProperties)
            {
                GetEmployee();
            }
        }

        private TransactionResult AddEditEmployee(Database db, System.Data.Common.DbTransaction transaction)
        {
            System.Data.Common.DbCommand dbCommand;
            TransactionResult transactionResult;
            bool bl;
            int i = 0;
            dbCommand = db.GetStoredProcCommand("spAddEditEmployee");
            db.AddInParameter(dbCommand, "EmployeeID", System.Data.DbType.Int32, _employeeID);
            db.AddInParameter(dbCommand, "CompanyID", System.Data.DbType.Int32, _companyID);
            db.AddInParameter(dbCommand, "EmployeeName", System.Data.DbType.String, _employeeName);
            //db.AddInParameter(dbCommand, "EmployeeCode", System.Data.DbType.String, _employeeCode);
            db.AddInParameter(dbCommand, "EmployeeFatherName", System.Data.DbType.String, _employeeFatherName);
            db.AddInParameter(dbCommand, "EmployeeMotherName", System.Data.DbType.String, _employeeMotherName);
            db.AddInParameter(dbCommand, "DateOfBirth", System.Data.DbType.String, _dateOfBirth);

            db.AddInParameter(dbCommand, "AadharNo", System.Data.DbType.String, _aadharNo);
            db.AddInParameter(dbCommand, "PFNo", System.Data.DbType.String, _pfNumber);


            db.AddInParameter(dbCommand, "Address1", System.Data.DbType.String, _address1);
            db.AddInParameter(dbCommand, "Address2", System.Data.DbType.String, _address2);
            db.AddInParameter(dbCommand, "Address3", System.Data.DbType.String, _address3);
            bl = CountryID == 0;
            if (!bl)
            {
                db.AddInParameter(dbCommand, "CountryID", System.Data.DbType.Int32, _countryID);
            }
            bl = StateID == 0;
            if (!bl)
            {
                db.AddInParameter(dbCommand, "StateID", System.Data.DbType.Int32, _stateID);
            }
            bl = CityID == 0;
            if (!bl)
            {
                db.AddInParameter(dbCommand, "CityID", System.Data.DbType.Int32, _cityID);
            }
            db.AddInParameter(dbCommand, "ZipCode", System.Data.DbType.String, _postalCode);
            db.AddInParameter(dbCommand, "HomeEmail", System.Data.DbType.String, _homeEmail);
            db.AddInParameter(dbCommand, "WorkEmail", System.Data.DbType.String, _workEmail);
            db.AddInParameter(dbCommand, "HomePhone", System.Data.DbType.String, _homePhone);
            db.AddInParameter(dbCommand, "WorkPhone", System.Data.DbType.String, _workPhone);
            db.AddInParameter(dbCommand, "MobilePhone", System.Data.DbType.String, _mobilePhone);

            db.AddInParameter(dbCommand, "BankID", System.Data.DbType.Int32, Convert.ToInt32(_bankID));
            db.AddInParameter(dbCommand, "BankRegion", System.Data.DbType.String, _bankRegion);
            db.AddInParameter(dbCommand, "BankAccountNo", System.Data.DbType.String, _bankAccountNumber);
            db.AddInParameter(dbCommand, "BankBranch", System.Data.DbType.String, _bankBranch);
            db.AddInParameter(dbCommand, "BankBranchCode", System.Data.DbType.String, _bankBranchCode);
            db.AddInParameter(dbCommand, "BankIFSC", System.Data.DbType.String, _bankIFSC);
            db.AddInParameter(dbCommand, "BankBranchAddress", System.Data.DbType.String, _bankBranchAddress);
            db.AddInParameter(dbCommand, "AgentID", System.Data.DbType.Int32, Convert.ToInt32(_agentID));

            db.AddInParameter(dbCommand, "Photo", DbType.Binary, _photo);

            db.AddInParameter(dbCommand, "Comments", System.Data.DbType.String, _comments);
            db.AddInParameter(dbCommand, "PreferredEmployeeID", System.Data.DbType.Int32, Convert.ToInt32(_preferredEmployeeID));
            db.AddInParameter(dbCommand, "AuditUserID", System.Data.DbType.Int32, Convert.ToInt32( _auditUserID));
            db.AddInParameter(dbCommand, "AddEditOption", System.Data.DbType.Int16, _addEditOption);
            db.AddParameter(dbCommand, "Return Value", System.Data.DbType.Int32, System.Data.ParameterDirection.ReturnValue, "Return Value", System.Data.DataRowVersion.Default, i);
            db.ExecuteNonQuery(dbCommand, transaction);
            _employeeID = (int)db.GetParameterValue(dbCommand, "Return Value");
            if (_employeeID == -1)
            {
                if (_addEditOption == 1)
                    return new TransactionResult(TransactionStatus.Failure, "Failure Updating");
                else
                    return new TransactionResult(TransactionStatus.Failure, "Failure Adding");
            }
            else if (_employeeID == -99)
            {
                if (_addEditOption == 1)
                {
                    return new TransactionResult(TransactionStatus.Success, "Record already exists");
                }
                else
                {
                    return new TransactionResult(TransactionStatus.Success, "Record already exists");
                }
            }
            else
            {
                if (_addEditOption == 1)
                {
                    return new TransactionResult(TransactionStatus.Success, "Successfully Updated");
                }
                else
                {
                    return new TransactionResult(TransactionStatus.Success, "Successfully Added");
                }
            }
        }


        #region Commit Add/Update/Delete Transactions

        /// <summary>
        /// Decides whether to Call Add/Edit/Delete method
        /// And Calls the appropriate method
        /// </summary>
        /// <returns>TransactionResult - Success / Failure</returns>
        public TransactionResult Commit()
        {
            TransactionResult result = null;
            Database db = CustomDatabaseFactory.CreateDatabase(_myConnection.ConnectionString);
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    switch (_screenMode)
                    {
                        case ScreenMode.Add:
                            result = AddEditEmployee(db, transaction);
                            if (result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return result;
                            }

                            break;
                        case ScreenMode.Edit:
                            result = AddEditEmployee(db, transaction);
                            if (result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return result;
                            }
                            break;
                        case ScreenMode.Delete:
                            result = DeleteEmployee(db, transaction);
                            if (result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return result;
                            }
                            break;
                        case ScreenMode.View:
                            break;
                    }
                    transaction.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    if (_screenMode == ScreenMode.Add)
                    {

                        return new TransactionResult(TransactionStatus.Failure, "Failure Adding");
                    }
                    if (_screenMode == ScreenMode.Edit)
                    {

                        return new TransactionResult(TransactionStatus.Failure, "Failure Updating");
                    }
                    if (_screenMode == ScreenMode.Delete)
                    {

                        return new TransactionResult(TransactionStatus.Failure, "Failure Deleting");
                    }
                }
            }
            return null;
        }
        #endregion

        private TransactionResult DeleteEmployee(Database db, System.Data.Common.DbTransaction transaction)
        {
            TransactionResult transactionResult;
            int i = 0;
            System.Data.Common.DbCommand dbCommand = db.GetStoredProcCommand("spDeleteEmployee");
            db.AddInParameter(dbCommand, "EmployeeID", System.Data.DbType.Int32, _employeeID);
            db.AddParameter(dbCommand, "Return Value", System.Data.DbType.Int32, System.Data.ParameterDirection.ReturnValue, "Return Value", System.Data.DataRowVersion.Default, i);
            db.ExecuteNonQuery(dbCommand, transaction);
            i = (int)db.GetParameterValue(dbCommand, "Return Value");
            transactionResult = i == -1 ? new TransactionResult(TransactionStatus.Failure, "Failure Deleted") : new TransactionResult(TransactionStatus.Success, "Successfully Deleted");
            return transactionResult;
        }

        private void GetEmployee()
        {
            System.Data.DataSet dataSet;
            try
            {
                Database database = CustomDatabaseFactory.CreateDatabase(_myConnection.ConnectionString);
                System.Data.Common.DbCommand dbCommand = database.GetStoredProcCommand("spGetEmployee");
                database.AddInParameter(dbCommand, "EmployeeID", System.Data.DbType.Int32, EmployeeID);
                database.AddInParameter(dbCommand, "CompanyID", System.Data.DbType.Int32, CompanyID);
                dataSet = database.ExecuteDataSet(dbCommand);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    System.Data.DataRow dataRow = dataSet.Tables[0].Rows[0];
                    _employeeCode = Common.CheckNull(dataRow["EmployeeCode"]);
                    _employeeName = Common.CheckNull(dataRow["EmployeeName"]);
                    _employeeFatherName = Common.CheckNull(dataRow["EmployeeFatherName"]);
                    _employeeMotherName = Common.CheckNull(dataRow["EmployeeMotherName"]);

                    _companyID = Common.CheckIntNull(dataRow["CompanyID"]);

                    _dateOfBirth = Common.CheckNull(dataRow["DateOfBirth"]);
                    _aadharNo = Common.CheckNull(dataRow["AadharNo"]);
                    _pfNumber = Common.CheckNull(dataRow["PFNo"]);

                    Address1 = Common.CheckNull(dataRow["Address1"]);
                    Address2 = Common.CheckNull(dataRow["Address2"]);
                    Address3 = Common.CheckNull(dataRow["Address3"]);
                    CityID = Common.CheckIntNull(dataRow["CityID"]);
                    CityName = Common.CheckNull(dataRow["CityName"]);
                    StateID = Common.CheckIntNull(dataRow["StateID"]);
                    StateName = Common.CheckNull(dataRow["StateName"]);
                    CountryID = Common.CheckIntNull(dataRow["CountryID"]);
                    CountryName = Common.CheckNull(dataRow["CountryName"]);
                    PostalCode = Common.CheckNull(dataRow["ZipCode"]);
                    _homeEmail = Common.CheckNull(dataRow["HomeEmail"]);
                    _workEmail = Common.CheckNull(dataRow["WorkEmail"]);
                    _homePhone = Common.CheckNull(dataRow["HomePhone"]);
                    _workPhone = Common.CheckNull(dataRow["WorkPhone"]);
                    _mobilePhone = Common.CheckNull(dataRow["MobilePhone"]);
                    _comments = Common.CheckNull(dataRow["Comments"]);
                    _preferredEmployeeID = Common.CheckNull(dataRow["PreferredEmployeeID"]);
                    _bankID = Common.CheckIntNull(dataRow["BankID"]);
                    _bankRegion = Common.CheckNull(dataRow["BankRegion"]);
                    _bankAccountNumber = Common.CheckNull(dataRow["BankAccountNo"]);
                    _bankBranch = Common.CheckNull(dataRow["BankBranch"]);
                    _bankBranchCode = Common.CheckNull(dataRow["BankBranchcode"]);
                    _bankIFSC = Common.CheckNull(dataRow["BankIFSC"]);
                    _bankBranchAddress = Common.CheckNull(dataRow["BankBranchAddress"]);
                    _agentID = Common.CheckIntNull(dataRow["AgentID"]);

                    if (dataRow["Photo"] != DBNull.Value)
                     _photo = (byte[])dataRow["Photo"];

                    
                }
            }
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "Employee.cs", "GetEmployee", exception1.Message.ToString());
                throw;
            }
        }


        public List<EmployeeDL> GetAllEmployeeList(int companyID)
        {
            try
            {
                List<EmployeeDL> EmployeeList = new List<EmployeeDL>();
                Database db = CustomDatabaseFactory.CreateDatabase(_myConnection.ConnectionString);
                string sqlCommand = "spGetEmployeeList";

                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "CompanyID", System.Data.DbType.Int32, companyID);
                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    EmployeeDL obj = new EmployeeDL();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            obj = new EmployeeDL();

                            obj.EmployeeID = Common.CheckIntNull(dataReader["EmployeeID"]);

                            obj.EmployeeCode = Common.CheckNull(dataReader["EmployeeCode"]);

                            obj.EmployeeName = Common.CheckNull(dataReader["EmployeeName"]);
                            obj.EmployeeFatherName = Common.CheckNull(dataReader["EmployeeFatherName"]);
                            obj.EmployeeMotherName = Common.CheckNull(dataReader["EmployeeMotherName"]);

                            obj.DateOfBirth = Common.CheckNull(dataReader["DateOfBirth"]);

                            CompanyID = Common.CheckIntNull(dataReader["CompanyID"]);


                            obj.Address1 = Common.CheckNull(dataReader["Address1"]);
                            obj.Address2 = Common.CheckNull(dataReader["Address2"]);
                            obj.Address3 = Common.CheckNull(dataReader["Address3"]);
                            obj.CityID = Common.CheckIntNull(dataReader["CityID"]);
                            obj.CityName = Common.CheckNull(dataReader["CityName"]);
                            obj.StateID = Common.CheckIntNull(dataReader["StateID"]);
                            obj.StateName = Common.CheckNull(dataReader["StateName"]);
                            obj.CountryID = Common.CheckIntNull(dataReader["CountryID"]);
                            obj.CountryName = Common.CheckNull(dataReader["CountryName"]);
                            obj.PostalCode = Common.CheckNull(dataReader["ZipCode"]);
                            obj.HomeEmail = Common.CheckNull(dataReader["HomeEmail"]);
                            obj.WorkEmail = Common.CheckNull(dataReader["WorkEmail"]);
                            obj.HomePhone = Common.CheckNull(dataReader["HomePhone"]);
                            obj.WorkPhone = Common.CheckNull(dataReader["WorkPhone"]);
                            obj.MobilePhone = Common.CheckNull(dataReader["MobilePhone"]);
                            obj.Comments = Common.CheckNull(dataReader["Comments"]);
                            obj.PreferredEmployeeId = Common.CheckNull(dataReader["PreferredEmployeeID"]);
                            obj.BankId = Common.CheckIntNull(dataReader["BankID"]);
                            obj.BankRegion = Common.CheckNull(dataReader["BankRegion"]);
                            obj.BankAccountNumber = Common.CheckNull(dataReader["BankAccountNo"]);
                            obj.BankBranch = Common.CheckNull(dataReader["BankBranch"]);
                            obj.BankBranchCode = Common.CheckNull(dataReader["BankBranchcode"]);
                            obj.BankIFSC = Common.CheckNull(dataReader["BankIFSC"]);
                            obj.BankBranchAddress = Common.CheckNull(dataReader["BankBranchAddress"]);
                            obj.AgentId = Common.CheckIntNull(dataReader["AgentID"]);

                            obj.AadharNo = Common.CheckNull(dataReader["AadharNo"]);
                            obj.PFNumber = Common.CheckNull(dataReader["PFNo"]);

                            if (dataReader["Photo"] != DBNull.Value)
                                obj.Photo = (byte[])dataReader["Photo"];

                            EmployeeList.Add(obj);
                        }
                    }

                }
                return EmployeeList;
            }
            catch (Exception ex)
            {                
                ErrorLog.LogErrorMessageToDB("EmployeeDL", "GetAllEmployeeList");
                return null;
            }
        }

        public System.Data.DataSet GetEmployeeDetails(int EmployeeID, int companyID, string searchText)
        {
            System.Data.DataSet dataSet;
            dataSet = new System.Data.DataSet();
            try
            {
                Database database = CustomDatabaseFactory.CreateDatabase(_myConnection.ConnectionString);
                System.Data.Common.DbCommand dbCommand = database.GetStoredProcCommand("spGetEmployee");
                dbCommand.Parameters.Clear();
                dbCommand.CommandTimeout = 300;
                database.AddInParameter(dbCommand, "EmployeeID", System.Data.DbType.Int32, EmployeeID);
                database.AddInParameter(dbCommand, "CompanyID", System.Data.DbType.Int32, companyID);
                database.AddInParameter(dbCommand, "SearchText", System.Data.DbType.String, searchText);
                dataSet = database.ExecuteDataSet(dbCommand);
            }
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "Employee.cs", "GetEmployeeDetails", exception1.Message.ToString());
                throw;
            }
            return dataSet;
        }

        public System.Data.DataSet GetEmployeeList(int companyID)
        {
            System.Data.DataSet dataSet;
            dataSet = new System.Data.DataSet();
            try
            {
                Database database = CustomDatabaseFactory.CreateDatabase(_myConnection.ConnectionString);
                System.Data.Common.DbCommand dbCommand = database.GetStoredProcCommand("spGetEmployeeList");
                dbCommand.Parameters.Clear();
                dbCommand.CommandTimeout = 300;
                database.AddInParameter(dbCommand, "CompanyID", System.Data.DbType.Int32, companyID);
                dataSet = database.ExecuteDataSet(dbCommand);
            }
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "Employee.cs", "GetEmployeeList", exception1.Message.ToString());
                throw;
            }
            return dataSet;
        }

        public System.Data.DataSet GetEmployeeDropDownList(int companyID)
        {
            System.Data.DataSet dataSet;
            dataSet = new System.Data.DataSet();
            try
            {
                Database database = CustomDatabaseFactory.CreateDatabase(_myConnection.ConnectionString);
                System.Data.Common.DbCommand dbCommand = database.GetStoredProcCommand("spGetEmployeeDropDownList");
                dbCommand.Parameters.Clear();
                dbCommand.CommandTimeout = 300;
                database.AddInParameter(dbCommand, "CompanyID", System.Data.DbType.Int32, companyID);
                dataSet = database.ExecuteDataSet(dbCommand);
            }
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "Employee.cs", "GetEmployeeDropDownList", exception1.Message.ToString());
                throw;
            }
            return dataSet;
        }

        public System.Data.DataSet GetEmployeeListByCompanyID(int companyID)
        {
            System.Data.DataSet dataSet;
            dataSet = new System.Data.DataSet();
            try
            {
                Database database = CustomDatabaseFactory.CreateDatabase(_myConnection.ConnectionString);
                System.Data.Common.DbCommand dbCommand = database.GetStoredProcCommand("spGetEmployeeListByCompanyID");
                dbCommand.Parameters.Clear();
                dbCommand.CommandTimeout = 300;
                database.AddInParameter(dbCommand, "CompanyID", System.Data.DbType.Int32, companyID);
                dataSet = database.ExecuteDataSet(dbCommand);
            }
            catch (System.Exception exception1)
            {
                ErrorLog.LogErrorMessageToDB("", "Employee.cs", "spGetEmployeeListByCompanyID", exception1.Message.ToString());
                throw;
            }
            return dataSet;
        }

        

    }
}

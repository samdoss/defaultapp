using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using ERP.CommonLayer;

namespace ERP.DataLayer
{
    public class Country
    {
        #region Constructor(s)

        public Country(){}

        public Country(int CountryID, bool getAllProperties)
        {
            _CountryID = CountryID;
            if (getAllProperties)
            {
                //GetCountry();
            }
        }

        #endregion

        #region Private Variables

        ApplicationConnection _appConnection = new ApplicationConnection();
        private int _CountryID;
        private string _CountryName;
        private List<Country> _CountryList;

        #endregion

        #region Public Properties

        public int CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }

        public string CountryName
        {
            get { return _CountryName; }
            set { _CountryName = value; }
        }

        public List<Country> CountryList
        {
            get { return _CountryList; }
            set { _CountryList = value; }
        }

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
                            if (_CountryList != null)
                            {
                                foreach (Country _StructsCountry in _CountryList)
                                {
                                    _result = AddCountry(_StructsCountry, db, transaction);
                                    if (_result.Status == TransactionStatus.Failure)
                                    {
                                        transaction.Rollback();
                                        return _result;
                                    }
                                }
                            }
                            break;
                        case ScreenMode.Edit:
                            return UpdateCountry();
                            break;
                        case ScreenMode.View:
                            return new TransactionResult(TransactionStatus.Success);
                            break;
                        case ScreenMode.Delete:
                            foreach (Country _StructsCountry in _CountryList)
                            {
                                _result = DeleteCountry(_StructsCountry, db, transaction);
                                if (_result.Status == TransactionStatus.Failure)
                                {
                                    transaction.Rollback();
                                    return _result;
                                }
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
                        return new TransactionResult(TransactionStatus.Failure, "Failure Adding Country Description.");
                    if (screenMode == ScreenMode.Edit)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Updating Country Description.");
                    if (screenMode == ScreenMode.Delete)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Country Description.");
                }
                return _result;
            }
        }

        public static List<Country> GetCountryList(ApplicationConnection _appConnection)
        {
            List<Country> _listCountry = new List<Country>();
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetCountryListing";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Country _sCountry = new Country();
                            _sCountry.CountryID = Convert.ToInt32(dataReader["CountryID"].ToString());
                            _sCountry.CountryName = dataReader.GetString(dataReader.GetOrdinal("Country"));
                            _listCountry.Add(_sCountry);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Country", "GetCountryList");
            }
            return _listCountry;
        }


        #endregion

        #region Private Methods
       
        private TransactionResult AddCountry(Country _StructsCountry, Database db, DbTransaction transaction)
        {
            int _returnValue = 0;
            string sqlCommand = "spAddCountry";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "Country", DbType.String, _StructsCountry.CountryName);
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);

            db.ExecuteNonQuery(dbCommand);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding Country Description.");
            else
                return new TransactionResult(TransactionStatus.Success, "Country Description Successfully Added.");
        }

        private TransactionResult UpdateCountry()
        {
            int _returnValue = 0;
            string sqlCommand = "spUpdateCountry";
            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "CountryID", DbType.Int32, _CountryID);
            db.AddInParameter(dbCommand, "Country", DbType.String, _CountryName);
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);

            db.ExecuteNonQuery(dbCommand);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Updating Country Description.");
            else
                return new TransactionResult(TransactionStatus.Success, "Country Description Successfully Updated.");
        }

        private TransactionResult DeleteCountry(Country _StructsCountry, Database db, DbTransaction transaction)
        {
            int _returnValue = 0;
            string sqlCommand = "spDeleteCountry";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "CountryID", DbType.Int32, _StructsCountry.CountryID);
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Country.");
            else
                return new TransactionResult(TransactionStatus.Success, "Country Successfully Deleted.");
        }

        #endregion
    }
}

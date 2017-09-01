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
    public class City
    {
        #region Constructor(s)

        public City() { }

        public City(int CityID, bool getAllProperties)
        {
            _CityID = CityID;
            if (getAllProperties)
            {
                //GetCity();
            }
        }

        #endregion

        #region Private Variables

        ApplicationConnection _appConnection = new ApplicationConnection();
        private int _CityID;
        private int _StateID;
        private string _CityName;
        private List<City> _CityList;

        #endregion

        #region Public Properties

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

        public string CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }

        public List<City> CityList
        {
            get { return _CityList; }
            set { _CityList = value; }
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
                            if (_CityList != null)
                            {
                                foreach (City _StructsCity in _CityList)
                                {
                                    _result = AddCity(_StructsCity, db, transaction);
                                    if (_result.Status == TransactionStatus.Failure)
                                    {
                                        transaction.Rollback();
                                        return _result;
                                    }
                                }
                            }
                            break;
                        case ScreenMode.Edit:
                            return UpdateCity();
                            break;
                        case ScreenMode.View:
                            return new TransactionResult(TransactionStatus.Success);
                            break;
                        case ScreenMode.Delete:
                            foreach (City _StructsCity in _CityList)
                            {
                                _result = DeleteCity(_StructsCity, db, transaction);
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
                        return new TransactionResult(TransactionStatus.Failure, "Failure Adding City Description.");
                    if (screenMode == ScreenMode.Edit)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Updating City Description.");
                    if (screenMode == ScreenMode.Delete)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Deleting City Description.");
                }
                return _result;
            }
        }

        public static List<City> GetCityList(ApplicationConnection _appConnection,int StateID)
        {
            List<City> _listCity = new List<City>();
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetCityListing";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "StateID", DbType.Int32, StateID);
                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            City _sCity = new City();
                            _sCity.CityID = Convert.ToInt32(dataReader["CityID"].ToString());
                            _sCity.CityName = dataReader.GetString(dataReader.GetOrdinal("City"));
                            _listCity.Add(_sCity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("City", "GetCityList");
            }
            return _listCity;
        }

        #endregion

        #region Private Methods

        private TransactionResult AddCity(City _StructsCity, Database db, DbTransaction transaction)
        {
            int _returnValue = 0;
            string sqlCommand = "spAddCity";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "StateID", DbType.String,_StructsCity.StateID);
            db.AddInParameter(dbCommand, "City", DbType.String, _StructsCity.CityName);
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);

            db.ExecuteNonQuery(dbCommand);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding City Description.");
            else
                return new TransactionResult(TransactionStatus.Success, "City Description Successfully Added.");
        }

        private TransactionResult UpdateCity()
        {
            int _returnValue = 0;
            string sqlCommand = "spUpdateCity";
            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "CityID", DbType.Int32, _CityID);
            db.AddInParameter(dbCommand, "City", DbType.String, _CityName);
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);

            db.ExecuteNonQuery(dbCommand);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Updating City Description.");
            else
                return new TransactionResult(TransactionStatus.Success, "City Description Successfully Updated.");
        }

        private TransactionResult DeleteCity(City _StructsCity, Database db, DbTransaction transaction)
        {
            int _returnValue = 0;
            string sqlCommand = "spDeleteCity";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "CityID", DbType.Int32, _StructsCity.CityID);
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Deleting City.");
            else
                return new TransactionResult(TransactionStatus.Success, "City Successfully Deleted.");
        }
        #endregion
    }
}

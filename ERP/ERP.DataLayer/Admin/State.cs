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
    public class State
    {
        #region Constructor(s)

        public State() { }

        public State(int StateID, bool getAllProperties)
        {
            _StateID = StateID;
            if (getAllProperties)
            {
                //GetState();
            }
        }

        #endregion

        #region Private Variables

        ApplicationConnection _appConnection = new ApplicationConnection();
        private int _StateID;
        private string _StateName;
        private int _CountryID;
        private List<State> _StateList;

        #endregion

        #region Public Properties

        public int StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }

        public string StateName
        {
            get { return _StateName; }
            set { _StateName = value; }
        }

        public int CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }
        public List<State> StateList
        {
            get { return _StateList; }
            set { _StateList = value; }
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
                            if (_StateList != null)
                            {
                                foreach (State _StructsState in _StateList)
                                {
                                    _result = AddState(_StructsState, db, transaction);
                                    if (_result.Status == TransactionStatus.Failure)
                                    {
                                        transaction.Rollback();
                                        return _result;
                                    }
                                }
                            }
                            break;
                        case ScreenMode.Edit:
                            return UpdateState();
                            break;
                        case ScreenMode.View:
                            return new TransactionResult(TransactionStatus.Success);
                            break;
                        case ScreenMode.Delete:
                            foreach (State _StructsState in _StateList)
                            {
                                _result = DeleteState(_StructsState, db, transaction);
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
                        return new TransactionResult(TransactionStatus.Failure, "Failure Adding State Description.");
                    if (screenMode == ScreenMode.Edit)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Updating State Description.");
                    if (screenMode == ScreenMode.Delete)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Deleting State Description.");
                }
                return _result;
            }
        }        

        public static List<State> GetStateList(ApplicationConnection _appConnection, int CountryID)
        {
            List<State> _listState = new List<State>();
                
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetStateListing";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "CountryID", DbType.Int32, CountryID);
                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            State _sState = new State();
                            _sState.StateID = Convert.ToInt32(dataReader["StateID"].ToString());
                            _sState.StateName = dataReader.GetString(dataReader.GetOrdinal("State"));
                            _listState.Add(_sState);
                        }
                    }
                }
                return _listState;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("State", "GetStateList");
            }
            return _listState;
        }

        #region Get Country

        /// <summary>
        /// Get all Countries from Country table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <returns>Return the data as Dataset</returns>

        public static DataSet GetCountry(ApplicationConnection _appConnection)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetCountry";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("Common", "GetCountry");
            }
            return null;
        }

        /// <summary>
        /// Get Countries from Country table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="CountryID">Country ID</param>
        /// <returns>Return the data as string</returns>

        public static string GetCountry(ApplicationConnection _appConnection, int CountryID)
        {
            string sCountry = "";
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetCountry";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "CountryID", DbType.Int32, CountryID);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        sCountry = dataReader.GetString(dataReader.GetOrdinal("Country"));
                    }
                }
                return sCountry;
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("Common", "GetCountry");
            }
            return sCountry;
        }

        #endregion

        #region Get States

        /// <summary>
        /// Get all States from State table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="CountryID">Country ID</param>
        /// <returns>Return the data as Dataset</returns>

        public static DataSet GetState(ApplicationConnection _appConnection, int CountryID)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetState";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "CountryID", DbType.Int32, CountryID);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("Common", "GetState");
            }
            return null;
        }

        /// <summary>
        /// Get specific State from State table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="StateID">State ID</param>
        /// <param name="CountryID">Country ID(give dummy country ID)</param>
        /// <returns>Return the data as string</returns>

        public static string GetState(ApplicationConnection _appConnection, int StateID, int CountryID)
        {
            string sState = "";
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetState";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "StateID", DbType.Int32, StateID);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        sState = dataReader.GetString(dataReader.GetOrdinal("State"));
                    }
                }
                return sState;
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("Common", "GetState");
            }
            return sState;
        }

        #endregion

        #region Get City

        /// <summary>
        /// Get all City from City table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="StateID">State ID</param>
        /// <returns>Return the data as Dataset</returns>

        public static DataSet GetCity(ApplicationConnection _appConnection, int StateID)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetCity";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "StateID", DbType.Int32, StateID);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("Common", "GetCity");
            }
            return null;
        }

        /// <summary>
        /// Get specific City from City table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="CityID">City ID</param>
        /// <param name="StateID">State ID</param>
        /// <returns>Return the data as string</returns>

        public static string GetCity(ApplicationConnection _appConnection, int CityID, int StateID)
        {
            string sCity = "";
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetCity";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "CityID", DbType.Int32, CityID);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        sCity = dataReader.GetString(dataReader.GetOrdinal("City"));
                    }
                }
                return sCity;
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("Common", "GetCity");
            }
            return sCity;
        }

        #endregion

        #endregion

        #region Private Methods

        private TransactionResult AddState(State _StructsState, Database db, DbTransaction transaction)
        {
            int _returnValue = 0;
            string sqlCommand = "spAddState";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "CountryID", DbType.Int32, _StructsState.CountryID);
            db.AddInParameter(dbCommand, "State", DbType.String, _StructsState.StateName);
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);

            db.ExecuteNonQuery(dbCommand);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding State Description.");
            else
                return new TransactionResult(TransactionStatus.Success, "State Description Successfully Added.");
        }

        private TransactionResult UpdateState()
        {
            int _returnValue = 0;
            string sqlCommand = "spUpdateState";
            Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "StateID", DbType.Int32, _StateID);
            db.AddInParameter(dbCommand, "State", DbType.String, _StateName);
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);

            db.ExecuteNonQuery(dbCommand);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Updating State Description.");
            else
                return new TransactionResult(TransactionStatus.Success, "State Description Successfully Updated.");
        }

        private TransactionResult DeleteState(State _StructsState, Database db, DbTransaction transaction)
        {
            int _returnValue = 0;
            string sqlCommand = "spDeleteState";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "StateID", DbType.Int32, _StructsState.StateID);
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                            DataRowVersion.Default, _returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Deleting State.");
            else
                return new TransactionResult(TransactionStatus.Success, "State Successfully Deleted.");
        }

        #endregion
    }
}

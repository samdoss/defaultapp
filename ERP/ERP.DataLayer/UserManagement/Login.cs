using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.CommonLayer;

namespace ERP.DataLayer
{
    public class Login
    {
        #region Constructor(s)

        public Login() { }

        public Login(int UserID, bool readAllProperties)
        {
            _UserID = UserID;
            if (readAllProperties)
            {
                PopulateAllProperties();
            }
        }

        #endregion

        #region Private Variables

        private ApplicationConnection _ApplicationConnection = new ApplicationConnection(); 
        private int _UserID;
        private string _UserName;
        private string _Password;
        

        #endregion

        #region public properties

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

        #endregion

        #region Private Methods

        private void PopulateAllProperties()
        { 
        }

        private void WriteDefaultUser(string logFileLocation, string userName, bool Remember)
        {
             FileInfo objFile = new FileInfo(Path.Combine(logFileLocation, "user.log"));
            StreamWriter objSW = objFile.CreateText();
            if (!Remember) { userName = ""; }
            objSW.WriteLine(userName);
            objSW.Close();
        }

        #endregion

        #region Public Methods

        public string ReadDefaultUser(string logFileLocation)
        {
            string read = null;
            string username = string.Empty;
            try
            {
                StreamReader st = File.OpenText( Path.Combine(logFileLocation, "user.log"));
                if ((read = st.ReadLine()) != null)
                {
                    username = read;
                }
                st.Close();
            }
            catch { }
            return username;
        }

        public TransactionResult ValidateUser(string logfileLocation,string userName, string password, bool Remember)
        {
            bool validUser = false;
            Database db = CustomDatabaseFactory.CreateDatabase(_ApplicationConnection.ConnectionString);
            string sqlCommand = "spGetLogin";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommand, "UserName", DbType.String, userName);
            db.AddInParameter(dbCommand, "Password", DbType.String, password);
            
            using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
            {
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    UserName = dataReader.GetString(dataReader.GetOrdinal("UserName"));
                    password = dataReader.GetString(dataReader.GetOrdinal("Password"));
                    UserID = dataReader.GetInt32(dataReader.GetOrdinal("UserID"));
                    WriteDefaultUser(logfileLocation, UserName, Remember);
                    validUser = true;
                }
            }
            if (validUser)
                return new TransactionResult(TransactionStatus.Success);
            else
                return new TransactionResult(TransactionStatus.Failure);
        }

        #endregion
    }
}

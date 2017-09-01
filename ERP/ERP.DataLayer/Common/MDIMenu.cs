using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ERP.CommonLayer;

namespace ERP.DataLayer
{
    public class MDIMenu
    {
        #region Constructor(s)
        
        public MDIMenu(){ }

        #endregion

        #region Private Variables

        private ApplicationConnection _appConnection = new ApplicationConnection();
         

        #endregion

        #region Public Methods
        
        public int GetCountOfMenuItems()
        {
            try
            {
                //Dataset
                SqlDataReader dr = null;
                int tCount = 0;

                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetCountOfMenuItems";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                dr = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader; // (SqlDataReader)db.ExecuteReader(dbCommand))
                if (dr.Read())
                {
                    if (dr[0] != null)
                    {
                        tCount = Convert.ToInt32(dr[0]);
                    }
                }
                dr.Close();
                return tCount;
            }
            catch(Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("MDIMenu", "GetCountOfMenuItems","", ex.Message);
            }
            return 0;
       }

        public DataSet GetTopMenuItems(int userID)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetTopMenuItems";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userID);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("MDIMenu", "GetTopMenuItems", "", ex.Message);
            }
            return null;
        }

        public DataSet GetMiddleMenuItems(int userID)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetMiddleMenuItems";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userID);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("MDIMenu", "GetMiddleMenuItems", "", ex.Message);
            }
            return null;
        }

        public DataSet GetSubMenuItems(int userID)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetSubMenuItems";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userID);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("MDIMenu", "GetSubMenuItems", "", ex.Message);
            }
            return null;
        }

        public string GetCompanyName()
        {
            try
            {
                string companyName = "";
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetCompanyDetails";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                SqlDataReader dr = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader; // (SqlDataReader)db.ExecuteReader(dbCommand))
                if (dr.Read())
                {
                    if (dr[0] != null)
                    {
                        companyName = dr[0].ToString().Trim();
                    }
                }
                dr.Close();
                return companyName;
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("MDIMenu", "GetCompanyName", "", ex.Message);
            }
            return null;
        }

        public string GetUserName(int userID)
        {
            try
            {
                string userName = "";
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetUserName";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userID);
                SqlDataReader dr = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader; // (SqlDataReader)db.ExecuteReader(dbCommand))
                if (dr.Read())
                {
                    if (dr[0] != null)
                    {
                        userName = dr[0].ToString().Trim();
                    }
                }
                dr.Close();
                return userName;
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("MDIMenu", "GetUserName", "", ex.Message);
            }
            return null;
        }

        public DataSet GetFormUserRights(int userID, string formName)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetFormUserRights";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userID);
                db.AddInParameter(dbCommand, "FormName", DbType.Int32, formName);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("MDIMenu", "GetFormUserRights", "", ex.Message);
            }
            return null;
        }

        public bool IsUserADoctor(int userID)
        {
            bool isDoctor = false;

            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetUserRoleName";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userID);
                SqlDataReader dr = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader; // (SqlDataReader)db.ExecuteReader(dbCommand))
                if (dr.Read())
                {
                    if (dr[0] != null)
                    {
                        if (dr[0].ToString().Trim() == "DOCTOR")
                        {
                            isDoctor = true;
                        }
                    }
                }
                dr.Close();
                return isDoctor;
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("MDIMenu", "IsUserADoctor", "", ex.Message);
            }
            return isDoctor;
        }

        #endregion
    }
}

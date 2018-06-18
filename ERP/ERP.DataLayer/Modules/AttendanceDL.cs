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
    public class AttendanceDL
    {
        public AttendanceDL()
            : base()
        {
            _myConnection = new ApplicationConnection();
        }

        private ApplicationConnection _myConnection;
        public int CompanyID { get; set; }
        public ScreenMode ScreenMode { get; set; }
        public DateTime AttendanceDate{ get; set; }
        public int EmployeeID { get; set; }
        public bool Forenoon { get; set; }
        public bool Afternoon { get; set; }
        public bool FullDay { get; set; }

        #region Public Methods

        public TransactionResult Commit(ScreenMode screenMode)
        {
            TransactionResult _result = null;
            Database db = CustomDatabaseFactory.CreateDatabase(_myConnection.ConnectionString);
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    switch (screenMode)
                    {
                        case ScreenMode.Add:
                            _result = AddAttendance(db, transaction);
                            if (_result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return _result;
                            }
                            break;
                        case ScreenMode.Edit:                            
                            _result = AddAttendance(db, transaction);
                            if (_result.Status == TransactionStatus.Failure)
                            {
                                transaction.Rollback();
                                return _result;
                            }

                            break;
                        case ScreenMode.Delete:

                            _result = DeleteAttendance(db, transaction);
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
                        return new TransactionResult(TransactionStatus.Failure, "Failure Adding Attendance.");
                    if (screenMode == ScreenMode.Edit)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Updating Attendance.");
                    if (screenMode == ScreenMode.Delete)
                        return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Attendance.");
                }
            }
            return null;
        }

        #endregion

        //public DataTable getAttendanceByDate(DateTime dtValue, int employeeID)
        //{
        //    string dt1 = string.Empty;
        //    dt1 = dtValue.ToShortDateString();
        //    OleDbConnection cnGet = new OleDbConnection(DBUtil.GetConnectionString());
        //    String query = "select AttendanceDate, EmployeeID, Forenoon, Afternoon, FullDay from Attendance where (AttendanceDate = #" + dt1 + "#) and (EmployeeID = "+ employeeID + ")";
        //    OleDbDataAdapter DataAdapter = new OleDbDataAdapter(query, cnGet);

        //    DataTable dt = new DataTable();

        //    try
        //    {
        //        DataAdapter.Fill(dt);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Unable to get Employees" + ex.Message);
        //    }

        //    return dt;
        //}

        public DataTable getAttendanceByDate(DateTime dtValue, int employeeID, int companyID)
        {
            DataTable dt = new DataTable();
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_myConnection.ConnectionString);
                string sqlCommand = "usp_Attendance_GetAttendanceDetails";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "AttendanceDate", DbType.DateTime, dtValue);
                db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, employeeID);
                db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, companyID);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        
                        dt.Load(dataReader);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("AttendanceDL", "getAttendanceByDate");
            }
            return dt;
        }      

        private TransactionResult AddAttendance(Database db, DbTransaction transaction)
        {
            string sqlCommand = "usp_Attendance_Insert";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, CompanyID);
            db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, EmployeeID);
            db.AddInParameter(dbCommand, "AttendanceDate", DbType.DateTime, AttendanceDate);
            db.AddInParameter(dbCommand, "Forenoon", DbType.Boolean, Forenoon);
            db.AddInParameter(dbCommand, "Afternoon", DbType.Boolean, Afternoon);
            db.AddInParameter(dbCommand, "FullDay", DbType.Boolean, FullDay);
            
            int returnValue = 0;
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                DataRowVersion.Default, returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding Attendance.");
            else
            {
                EmployeeID = returnValue;
                return new TransactionResult(TransactionStatus.Success, "Attendance Successfully Added.");
            }
        }

        private TransactionResult DeleteAttendance(Database db, DbTransaction transaction)
        {

            string sqlCommand = "usp_Attendance_Delete";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "CompanyID", DbType.Int32, CompanyID);
            db.AddInParameter(dbCommand, "EmployeeID", DbType.Int32, EmployeeID);
            db.AddInParameter(dbCommand, "AttendanceDate", DbType.DateTime, AttendanceDate);
            int returnValue = -1;
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                DataRowVersion.Default, returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Attendance Information.");
            else
                return new TransactionResult(TransactionStatus.Success, "Attendance Information Successfully Deleted.");
        }

       
    }
}

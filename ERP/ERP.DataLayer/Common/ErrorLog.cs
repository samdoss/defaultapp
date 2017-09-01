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
    public static class ErrorLog
    {        
        public static void LogErrorMessageToDB(string pageName, string className, string eventName, string errorMessage)
        {
            try
            {
                ApplicationConnection _appConnection = new ApplicationConnection();
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spAddLogErrorMessageToDB";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "PageName", DbType.String, pageName);
                db.AddInParameter(dbCommand, "ClassName", DbType.String, className);
                db.AddInParameter(dbCommand, "EventName", DbType.String, eventName);
                db.AddInParameter(dbCommand, "ErrorMessage", DbType.String,errorMessage);
                db.ExecuteNonQuery(dbCommand);
            }
            catch { }
        }

        public static void LogErrorMessageToDB(string pageName, string className)
        {
            try
            {
                LogErrorMessageToDB(pageName, className);
            }
            catch { }
        }

    }
}

//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Data;
//using System.Data.SqlClient;
//using System.Data.Common;
//using System.Windows.Forms;
//using Microsoft.Practices.EnterpriseLibrary.Data;   

//namespace ERP.DataLayer
//{
//    public class ErrorLog
//    {
//        #region Constructor(s)

//        public ErrorLog(){}

//        public ErrorLog(int ErrorLogID, bool getAllProperties)
//        {
//        }

//        #endregion

//        #region Private Variables

//        ApplicationConnection _appConnection = new ApplicationConnection();
//        private string _ErrorMessage;
//        private string _DummyErrorMessage;

//        #endregion

//        #region Public Properties

//        public string ErrorMessage
//        {
//            get { return _ErrorMessage; }
//            set { _ErrorMessage = value; } 
//        }

//        #endregion

//        #region Public Methods

//        public void ShowError(string caption,string pageName,string eventName)
//        {
//            DialogResult isYes;
//            _DummyErrorMessage = _ErrorMessage;
//            LogErrorMessageToDB(pageName, eventName);
//            //MessageBox.Show(_DummyErrorMessage, caption, MessageBoxButtons.OK,MessageBoxIcon.Error);
//            isYes = MessageBox.Show("Error Occured : Click 'Yes' to Send The Error Report to Us", "ERP ", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
//            if (isYes == DialogResult.Yes)
//            {
//                SendMail(_ErrorMessage,pageName,eventName);
//            }
//        }

//        public void LogErrorMessageToDB(string pageName, string eventName)
//        {
//            try
//            {
//                Database db =CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
//                string sqlCommand = "spAddLogErrorMessageToDB";
//                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
//                db.AddInParameter(dbCommand, "PageName", DbType.String, pageName);
//                db.AddInParameter(dbCommand, "EventName", DbType.String, eventName);
//                db.AddInParameter(dbCommand, "ErrorMessage", DbType.String, _ErrorMessage);
//                db.ExecuteNonQuery(dbCommand);
//            }
//            catch {}
//        }

//        private void SendMail(string errorMessage, string PageName, string EventName)
//        {
//            System.Diagnostics.Process.Start(string.Format("mailto:{0}?Subject={1}&Body={2}", "samdoss@live.com", "Error Report ", "Error Message : " + errorMessage + " Form Name " + PageName + " Method Name " + EventName));
//        }

//        #endregion
//    }
//}

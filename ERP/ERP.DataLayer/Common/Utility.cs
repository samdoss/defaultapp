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
    public static class Utility
    {
        #region Public Methods

        #region Get Date

        /// <summary>
        /// Get System Date
        /// </summary>

        public static string GetDate()
        {
            try
            {
                DateTime dt = DateTime.Now;
                return dt.Month.ToString() + "/" + dt.Day.ToString() + "/" + dt.Year.ToString();
            }
            catch (Exception ex)
            {
               ErrorLog.LogErrorMessageToDB("Utility", "GetDate","",ex.Message);
            }
            return null;
        }

        #endregion

        #region Get SQL Server Date

        /// <summary>
        /// Get SQL Server Date
        /// </summary>

        public static DateTime GetServerDate(ApplicationConnection _appConnection)
        {
            DateTime ServerDate = new DateTime();
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "SELECT GetDate() AS TodayDate";
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader) // (SqlDataReader)db.ExecuteReader(dbCommand))
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        ServerDate = dataReader.GetDateTime(dataReader.GetOrdinal("TodayDate"));
                    }
                }
                return ServerDate;
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("Utility", "GetServerDate","",ex.Message);
            }
            return ServerDate;
        }

        #endregion

        #region Number Validation

        /// <summary>
        /// Validate Number
        /// </summary>

        public static int ValidateNumber(string number)
        {
            int numberType = 0;
            try
            {
                // -1 Empty
                // 0 Non Numeric and blanks
                // 1 Numeric
                if (number.Trim().Length == 0)
                {
                    numberType = -1;
                    return numberType;
                }
                else
                {
                    numberType = 1;
                    for (int index = 0; index < number.Length; index++)
                    {
                        if (!Char.IsNumber(number[index]))
                        {
                            numberType = 0;
                            break;
                        }
                    }
                }
                return numberType;
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("Utility", "ValidateNumber","",ex.Message);
            }
            return numberType;
        }

        #endregion

        #region Number Validation

        /// <summary>
        /// Validate Number
        /// </summary>

        public static int ValidateDecimalNumber(string number)
        {
            int numberType = 0;
            try
            {
                // -1 Empty
                // 0 Non Numeric and blanks
                // 1 Numeric
                if (number.Trim().Length == 0)
                {
                    numberType = -1;
                    return numberType;
                }
                else
                {
                    numberType = 1;
                    for (int index = 0; index < number.Length; index++)
                    {
                        if (!Char.IsNumber(number[index]))
                        {
                            if (number[index].ToString() == ".")
                            {

                            }
                            else
                            {
                                numberType = 0;
                                break;
                            }
                        }
                    }
                }
                return numberType;
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("Utility", "ValidateNumber", "", ex.Message);
            }
            return numberType;
        }

        #endregion

        #region Age Calculation

        /// <summary>
        /// Calculate the age based on the Date of Birth
        /// </summary>

        public static string CalculateAge(DateTime DateOfBirth)
        {
            try
            {
                string txtDOB = "";
                DateTime dtDate = new DateTime();
                dtDate = DateOfBirth;
                txtDOB = dtDate.ToString("MM/dd/yyyy");

                ApplicationConnection _appConnection = new ApplicationConnection();
                TimeSpan ts = GetServerDate(_appConnection) - dtDate;

                int year = (int)(ts.TotalDays / 365);
                int month = (int)(ts.TotalDays / 30);
                int day = (int)(ts.TotalDays);
                string old;

                if (year > 0)
                {
                    old = " Years";
                    if (year == 1)
                    {
                        old = " Year";
                    }
                    return year.ToString() + old;
                }
                else if (month > 0)
                {
                    if (month == 12) month = 11;
                    old = " Months";
                    if (month == 1)
                    {
                        old = " Month";
                    }
                    return month.ToString() + old;
                }
                else
                {
                    old = " Days";
                    if (day == 1)
                    {
                        old = " Day";
                    }
                    return day.ToString() + old;
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("Utility", "CalculateAge", "", ex.Message);
            }
            return string.Empty;
        }

        #endregion

        #region Date Validation

        /// <summary>
        /// Validate the Given Date
        /// </summary>

        public static bool ValidateDate(string sDate)
        {
            bool _returnValue = true;
            sDate = sDate.Replace("/", "");
            sDate = sDate.Replace(" ", "");

            if (ValidateNumber(sDate) <= 0)
            {
                _returnValue = false;
            }
            else
            {
                try
                {
                    int _Day = Convert.ToInt32(sDate.Substring(0, 2));
                    int _Month = Convert.ToInt32(sDate.Substring(2, 2));
                    int _Year = Convert.ToInt32(sDate.Substring(4, 4));
                    DateTime _DateTime = new DateTime(_Year, _Month, _Day);
                }
                catch (Exception ex)
                {
                    _returnValue = false;
                    ErrorLog.LogErrorMessageToDB("Utility", "ValidateDate", "", ex.Message);
                }
            }
            return _returnValue;
        }
        #endregion

        #region Day Calculation

        /// <summary>
        /// Calculate the Date based on the Date
        /// </summary>

        public static int CalculateDay(DateTime DateOfBirth)
        {
            try
            {
                string txtDOB = "";
                DateTime dtDate = new DateTime();
                dtDate = DateOfBirth;
                txtDOB = dtDate.ToString("dd/MM/yyyy");

                ApplicationConnection _appConnection = new ApplicationConnection();
                TimeSpan ts = GetServerDate(_appConnection) - dtDate;

                int year = (int)(ts.TotalDays / 365);
                int month = (int)(ts.TotalDays / 30);
                int day = (int)(ts.TotalDays);

                if (year > 0)
                {
                    return year;
                }
                else if (month > 0)
                {
                    return month;
                }
                else
                {
                    return day;
                }
                return 0;
            }
                
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("Utility", "CalculateDay","", ex.Message);
            }
            return 0;
        }

        #endregion

        #endregion
    }
}

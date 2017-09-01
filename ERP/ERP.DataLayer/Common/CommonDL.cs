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
    public static class CommonDL
    {
        #region Get Hospital Details

        /// <summary>
        /// Get Hospital Detail
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <returns>Return the data as Dataset</returns>

        public static DataSet GetHospitalDetails(ApplicationConnection _appConnection)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetHospitalDetails";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                ErrorLog.LogErrorMessageToDB("Common", "GetHospitalDetails");
            }
            return null;
        }

        #endregion

        #region Get Patient Details

        /// <summary>
        /// Get Patient Detail
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <returns>Return the data as Dataset</returns>

        public static DataSet GetPatientDetails(ApplicationConnection _appConnection,int PatientID)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetPatientAddressDetails";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "PatientID", DbType.Int32, PatientID);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetPatientDetails");
            }
            return null;
        }

        #endregion

        #region Get Blood Group

        /// <summary>
        /// Get all Blood Groups from BloodGroups table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <returns>Return the data as Dataset</returns>
        
        public static DataSet GetBloodGroup(ApplicationConnection _appConnection)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetBloodGroups";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetBloodGroup");
            }
            return null;
        }

        /// <summary>
        /// Get Blood Group from BloodGroups table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="BloodGroupID">Blood Group ID</param>
        /// <returns>Return the data as string</returns>
        
        public static string GetBloodGroup(ApplicationConnection _appConnection,Int16 BloodGrouupID)
        {
            string sBloodGroup = "";
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetBloodGroups";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "BloodGrouupID", DbType.Int16, BloodGrouupID);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();

                        sBloodGroup = dataReader.GetString(dataReader.GetOrdinal("BloodGroup"));
                    }
                }
                return sBloodGroup;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetBloodGroup");
            }
            return sBloodGroup;
        }

        #endregion

        #region Get Patient Type

        /// <summary>
        /// Get all Patient Types from PatientTypes table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <returns>Return the data as Dataset</returns>
        
        public static DataSet GetPatientType(ApplicationConnection _appConnection)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetPatientTypes";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetPatientType");
            }
            return null;
        }

        /// <summary>
        /// Get Patient Types from PatientTypes table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="PatientTypeID">Patient Type ID</param>
        /// <returns>Return the data as String</returns>
        
        public static string GetPatientType(ApplicationConnection _appConnection,Int16 PatientTypeID)
        {
            string sPatientType = "";
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetPatientTypes";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "PatientTypeID", DbType.Int16, PatientTypeID);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        sPatientType = dataReader.GetString(dataReader.GetOrdinal("PatientType"));
                    }
                }
                return sPatientType;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetPatientType");
            }
            return sPatientType;
        }

        #endregion

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

        public static DataSet GetBank(ApplicationConnection _appConnection)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetBank";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {


                ErrorLog.LogErrorMessageToDB("CommonDL", "GetBank");
            }
            return null;
        }

        public static string GetBank(ApplicationConnection _appConnection, int BankID)
        {
            string sBank = "";
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetBank";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "BankID", DbType.Int32, BankID);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        sBank = dataReader.GetString(dataReader.GetOrdinal("BankName"));
                    }
                }
                return sBank;
            }
            catch (Exception ex)
            {


                ErrorLog.LogErrorMessageToDB("Common", "GetBank");
            }
            return sBank;
        }

        /// <summary>
        /// Get Countries from Country table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="CountryID">Country ID</param>
        /// <returns>Return the data as string</returns>
        
        public static string GetCountry(ApplicationConnection _appConnection,int CountryID)
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
        
        public static DataSet GetState(ApplicationConnection _appConnection,int CountryID)
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
        
        public static string GetState(ApplicationConnection _appConnection,int StateID, int CountryID)
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
        
        public static DataSet GetCity(ApplicationConnection _appConnection,int StateID)
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
        
        public static string GetCity(ApplicationConnection _appConnection,int CityID, int StateID)
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

        #region Get Religions

        /// <summary>
        /// Get all Religion from Religion table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <returns>Return the data as Dataset</returns>
        
        public static DataSet GetReligion(ApplicationConnection _appConnection)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetReligion";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetReligion");
            }
            return null;
        }

        /// <summary>
        /// Get specific Religion from Religion table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="ReligionID">Religion ID</param>
        /// <returns>Return the data as string</returns>
        
        public static string GetReligion(ApplicationConnection _appConnection,Int16 ReligionID)
        {
            string sReligion = "";
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetReligion";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ReligionID", DbType.Int16, ReligionID);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        sReligion = dataReader.GetString(dataReader.GetOrdinal("Religion"));
                    }
                }
                return sReligion;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetReligion");
            }
            return sReligion;
        }

        #endregion

        #region Get Title

        /// <summary>
        /// Get all Title from Title table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <returns>Return the data as Dataset</returns>
        
        public static DataSet GetTitle(ApplicationConnection _appConnection,Int16 WithOutBaby)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetTitle";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "WithoutBaby", DbType.Int16, WithOutBaby);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetTitle");
            }
            return null;
        }

        /// <summary>
        /// Get specific Title from Title table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="TitleID">Title ID</param>
        /// <returns>Return the data as string</returns>
        
        public static string GetTitle(ApplicationConnection _appConnection,Int16 TitleID, Int16 WithOutBaby)
        {
            string sTitle = "";
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetTitle";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "TitleID", DbType.Int16, TitleID);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        sTitle = dataReader.GetString(dataReader.GetOrdinal("Title"));
                    }
                }
                return sTitle;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetTitle");
            }
            return sTitle;
        }

        #endregion

        #region Get Occupation

        /// <summary>
        /// Get all Occupation from Patient table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <returns>Return the data as Dataset</returns>
        
        public static DataSet GetOccupation(ApplicationConnection _appConnection)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetOccupation";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetOccupation");
            }
            return null;
        }

        /// <summary>
        /// Get specific Occupation from Patient table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="OccupationID">Occupation ID</param>
        /// <returns>Return the data as string</returns>
        
        public static string GetOccupation(ApplicationConnection _appConnection,Int16 OccupationID)
        {
            string sOccupation = "";
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetOccupation";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "OccupationID", DbType.Int16, OccupationID);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        sOccupation = dataReader.GetString(dataReader.GetOrdinal("Occupation"));
                    }
                }
                return sOccupation;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetOccupation");
            }
            return sOccupation;
        }

        #endregion

        #region Get Gender

        /// <summary>
        /// Get all Gender from Gender table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <returns>Return the data as Dataset</returns>
        
        public static DataSet GetGender(ApplicationConnection _appConnection)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetGender";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetGender");
            }
            return null;
        }

        /// <summary>
        /// Get specific Gender from Gender table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="GenderID">Gender ID</param>
        /// <returns>Return the data as string</returns>
        
        public static string GetGender(ApplicationConnection _appConnection,Int16 GenderID)
        {
            string sGender = "";
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetGender";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "GenderID", DbType.Int16, GenderID);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        sGender = dataReader.GetString(dataReader.GetOrdinal("Gender"));
                    }
                }
                return sGender;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetGender");
            }
            return sGender;
        }

        #endregion
        
        #region Get Provider List

        /// <summary>
        /// Get all Provider from Users table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <returns>Return the data as Dataset</returns>
        
        public static DataSet GetProviderList(ApplicationConnection _appConnection)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetProviderList";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetProviderList");
            }
            return null;
        }
        /// <summary>
        /// Get all Provider for Specified Speciality
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="SpecialityID">Speciality ID</param>
        /// <returns>Return the data as Dataset</returns>
        
        public static DataSet GetProviderList(ApplicationConnection _appConnection, int SpecialityID)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetProviderList";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "SpecialityID", DbType.Int32, SpecialityID);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetProviderList");
            }
            return null;
        }

        #endregion
                
        #region Get DrugFormType

        /// <summary>
        /// Get all Countries from Country table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <returns>Return the data as Dataset</returns>
        
        public static DataSet GetDrugFormType(ApplicationConnection _appConnection)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetDrugFormTypes";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetDrugFormType");
            }
            return null;
        }

        /// <summary>
        /// Get DrugFormType from DrugFormType table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="DrugFormTypeID">DrugFormType ID</param>
        /// <returns>Return the data as string</returns>
        
        public static string GetDrugFormType(ApplicationConnection _appConnection, int DrugFormTypeID)
        {
            string sDrugFormType = "";
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetDrugFormTypes";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "DrugFormTypeID", DbType.Int32, DrugFormTypeID);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        sDrugFormType = dataReader.GetString(dataReader.GetOrdinal("DrugFormType"));
                    }
                }
                return sDrugFormType;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetDrugFormType");
            }
            return sDrugFormType;
        }

        #endregion

        #region Get DrugStrengthUnit

        /// <summary>
        /// Get all Countries from Country table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <returns>Return the data as Dataset</returns>
        
        public static DataSet GetDrugStrengthUnit(ApplicationConnection _appConnection)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetDrugStrengthUnits";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetDrugStrengthUnit");
            }
            return null;
        }

        /// <summary>
        /// Get DrugFormType from DrugFormType table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="DrugStrengthUnitID">DrugStrengthUnit ID</param>
        /// <returns>Return the data as string</returns>
        
        public static string GetDrugStrengthUnit(ApplicationConnection _appConnection, int DrugStrengthUnitID)
        {
            string sDrugStrengthUnit = "";
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetDrugStrengthUnits";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "DrugStrengthUnitID", DbType.Int32, DrugStrengthUnitID);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        sDrugStrengthUnit = dataReader.GetString(dataReader.GetOrdinal("DrugStrengthUnit"));
                    }
                }
                return sDrugStrengthUnit;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetDrugStrengthUnit");
            }
            return sDrugStrengthUnit;
        }

        #endregion

        #region Get DrugCompany

        /// <summary>
        /// Get all Countries from Country table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <returns>Return the data as Dataset</returns>
        
        public static DataSet GetDrugCompany(ApplicationConnection _appConnection)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetDrugCompany";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetDrugCompany");
            }
            return null;
        }

        /// <summary>
        /// Get DrugFormType from DrugFormType table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="DrugCompanyID">DrugCompany ID</param>
        /// <returns>Return the data as string</returns>
        
        public static string GetDrugCompany(ApplicationConnection _appConnection, int DrugCompanyID)
        {
            string sDrugCompany = "";
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetDrugCompany";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "DrugCompanyID", DbType.Int32, DrugCompanyID);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        sDrugCompany = dataReader.GetString(dataReader.GetOrdinal("CompanyName"));
                    }
                }
                return sDrugCompany;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetDrugCompany");
            }
            return sDrugCompany;
        }

        #endregion

        #region Get GenericDrug

        /// <summary>
        /// Get all Countries from Country table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <returns>Return the data as Dataset</returns>
        
        public static DataSet GetGenericDrug(ApplicationConnection _appConnection)
        {
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetGenericDrugs";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetGenericDrug");
            }
            return null;
        }

        /// <summary>
        /// Get DrugFormType from DrugFormType table
        /// </summary>
        /// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
        /// <param name="DrugCompanyID">DrugCompany ID</param>
        /// <returns>Return the data as string</returns>
        
        public static string GetGenericDrug(ApplicationConnection _appConnection, int GenericDrugID)
        {
            string sGenericDrug = "";
            try
            {
                Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
                string sqlCommand = "spGetGenericDrugs";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "GenericDrugID", DbType.Int32, GenericDrugID);

                using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        sGenericDrug = dataReader.GetString(dataReader.GetOrdinal("GenericDrug"));
                    }
                }
                return sGenericDrug;
            }
            catch (Exception ex)
            {
                
                
                ErrorLog.LogErrorMessageToDB("Common", "GetGenericDrug");
            }
            return sGenericDrug;
        }

        #endregion
    }
}

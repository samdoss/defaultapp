using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ERP.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERP.DataLayer
{
    public class PaymentTerms
    {
	    ApplicationConnection _appConnection = new ApplicationConnection();

        public int PaymentTermId { get; set; }
        public string PaymentTermName { get; set; }
        public int PaymentTerm { get; set; }
        public bool Status { get; set; }

	    public DataSet GetAllPaymentTerms()
	    {
		    try
		    {
			    Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
				string sqlCommand = "usp_PaymentTerms_GetAllPaymentTerms";
			    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			    return db.ExecuteDataSet(dbCommand);
		    }
		    catch (Exception ex)
		    {
				ErrorLog.LogErrorMessageToDB("PaymentTermsDL", "GetAllPaymentTerms", "", ex.Message);
		    }
		    return null;
	    }

	    public List<PaymentTerms> GetAllPaymentTermsList()
	    {
			try
			{
				List<PaymentTerms> PaymentTermsList = new List<PaymentTerms>();
				Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
				string sqlCommand = "usp_PaymentTerms_GetAllPaymentTerms";
				DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

				using (SqlDataReader dataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
				{
					PaymentTerms obj = new PaymentTerms();
					if (dataReader.HasRows)
					{
						while (dataReader.Read())
						{
							obj = new PaymentTerms();

							obj.PaymentTermId = dataReader.GetInt32(dataReader.GetOrdinal("PaymentTermId"));
							obj.PaymentTermName = dataReader.GetString(dataReader.GetOrdinal("PaymentTermName"));
							obj.PaymentTerm = dataReader.GetInt32(dataReader.GetOrdinal("PaymentTerm"));
							obj.Status = dataReader.GetBoolean(dataReader.GetOrdinal("Status"));

							PaymentTermsList.Add(obj);
						}
					}
				}
				return PaymentTermsList;
			}
			catch (Exception ex)
			{
				ErrorLog.LogErrorMessageToDB("PaymentTermsDL", "GetAllPaymentTermsList", "", ex.Message);
				return null;
			}
	    }
    }

}

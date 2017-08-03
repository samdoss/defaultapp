using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERP.DataLayer
{
	public class DatabaseFactoryDL
	{
	}

	public static class CustomDatabaseFactory
	{
		static readonly DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");

		public static Database CreateDatabase(string connectionString)
		{
			return new GenericDatabase(connectionString, dbProviderFactory);
		}
	}

//	public class CustomDatabaseFactory
//	{
//		private string serverName;
//		private string connectionString;
//		private string databaseName;

//		public CustomDatabaseFactory(string ServerName, string DatabaseName)
//		{

//			this.serverName = ServerName;

//			this.databaseName = DatabaseName;

//		}


//		static readonly DbProviderFactory dbProviderFactory =
//			DbProviderFactories.GetFactory("System.Data.SqlClient");
//		public Database CreateDatabase(string connectionString)
//		{
//			Database db = null;

//			//database mydb = new EnterpriseLibrary.Data.Sql.SqlDatabase("connection string here");

//			db = new GenericDatabase(connectionString, dbProviderFactory);
//			return db;
//		}

//		public Database GetDatabase(string connectionString)
//		{

//			DbConnectionStringBuilder builder = new DbConnectionStringBuilder();

//			Database db = null;

//			db = new GenericDatabase(connectionString, dbProviderFactory);

//			return db;

//		}

//		public DataTable PMHistory(int Id, string connectionString)
//		{
//			string spName = "stp_pm_History";

//			DataTable dt = new DataTable();
//			Database db = DatabaseFactory.CreateDatabase(connectionString);

//			object[] parameters = { Id };

//			DbCommand command = db.GetStoredProcCommand(spName, parameters);

//			return dt;

//		}



//	}

//	public partial class _Default : System.Web.UI.Page
//	{
//		protected ExportFile createFile;
    
//		protected void Page_Load(object sender, EventArgs e)
//		{
//			try
//			{
//				string    connectionString = "Data Source=SQLDEV01;Initial Catalog=test;Persist Security Info=True;User ID=rrrrr;Password=xxxxx";
//				CustomDatabaseFactory getData = new CustomDatabaseFactory("", "");
//				getData.PMHistory(1, connectionString); //FALLS HERE         }

//					catch (Exception ex)
//				{
//					Response.Write(ex.ToString());
//				}
//			}
//		}
}
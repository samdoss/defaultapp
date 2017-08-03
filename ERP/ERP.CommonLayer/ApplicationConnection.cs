using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace ERP.CommonLayer
{
    [Serializable]
    public class ApplicationConnection
    {
        #region Constructor(s)

        public ApplicationConnection()
        {
	        Dictionary<string, string> dataCollection = new Dictionary<string, string>();
	        dataCollection = Settings.ReadSettingFiles();
	        foreach (var read in dataCollection)
	        {
		        switch (read.Key)
		        {
			        case "ServerName":
				        ServerName = read.Value;
				        break;
			        case "DatabaseName":
				        DatabaseName = read.Value;
				        break;
			        case "AuthenticationType":
				        Authentication = read.Value;
				        break;
			        case "DBUserName":
				        Dbusername = read.Value;
				        break;
			        case "DBPassword":
				        Dbpassword = read.Value;
				        break;
		        }
	        }

	        if (Authentication.ToLower() == "windows")
	        {
				ConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + DatabaseName + ";Integrated Security=SSPI;";
	        }
	        else
	        {
				ConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + DatabaseName + ";User ID=" +
								   Dbusername + ";Password=" + Dbpassword + ";";
	        }
        }


        #endregion

        #region Private Variables

        private string _connectionString;
        private string _databaseName;
	    private string _serverName = string.Empty;
	    private string _authentication = string.Empty;
	    private string _dbusername = string.Empty;
	    private string _dbpassword = string.Empty;

        #endregion

        #region Public Properties

        public string DatabaseName
        {
            get { return _databaseName; }
            set { _databaseName = value; }
        }

        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

	    public string ServerName
	    {
		    get { return _serverName; }
		    set { _serverName = value; }
	    }

	    public string Authentication
	    {
		    get { return _authentication; }
		    set { _authentication = value; }
	    }

	    public string Dbusername
	    {
		    get { return _dbusername; }
		    set { _dbusername = value; }
	    }

	    public string Dbpassword
	    {
		    get { return _dbpassword; }
		    set { _dbpassword = value; }
	    }

	    #endregion
    }
}

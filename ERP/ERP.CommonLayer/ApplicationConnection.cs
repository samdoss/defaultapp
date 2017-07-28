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
			        case "DatabaseName":
				        DatabaseName = read.Value;
				        break;
		        }
	        }
        }

        #endregion

        #region Private Variables

        private string _connectionString;
        private string _databaseName;

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
        #endregion
    }
}

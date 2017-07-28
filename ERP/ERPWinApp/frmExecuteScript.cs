using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using ERP.CommonLayer;

namespace ERPWinApp
{
	public partial class frmExecuteScript : Form
	{
		Dictionary<string, string> dataCollection = new Dictionary<string, string>();
		private string serverName = string.Empty;
		private string databasename = string.Empty;
		private string authentication = string.Empty;
		private string dbusername = string.Empty;
		private string dbpassword = string.Empty;

		public frmExecuteScript()
		{
			InitializeComponent();
		}

		private void btnExecute_Click(object sender, EventArgs e)
		{
			String sqlServerLogin = dbusername;
			String password = dbpassword;
			String dbName = databasename;
			String remoteSvrName = serverName;
			string connectionString = string.Empty;
			//// Connecting to an instance of SQL Server using SQL Server Authentication  
			//Server srv1 = new Server();   // connects to default instance 
			//srv1.ConnectionContext.LoginSecure = false;   // set to true for Windows Authentication  
			//srv1.ConnectionContext.Login = sqlServerLogin;
			//srv1.ConnectionContext.Password = password;
			////Console.WriteLine(srv1.Information.Version);   // connection is established  

			//// Connecting to a named instance of SQL Server with SQL Server Authentication using ServerConnection  
			//ServerConnection srvConn = new ServerConnection();
			//srvConn.ServerInstance = @".\" + instanceName;   // connects to named instance  
			//srvConn.LoginSecure = false;   // set to true for Windows Authentication  
			//srvConn.Login = sqlServerLogin;
			//srvConn.Password = password;
			//Server srv2 = new Server(srvConn);
			//Console.WriteLine(srv2.Information.Version);   // connection is established  

			//// For remote connection, remote server name / ServerInstance needs to be specified  
			//ServerConnection srvConn2 = new ServerConnection(remoteSvrName);
			//srvConn2.LoginSecure = false;
			//srvConn2.Login = sqlServerLogin;
			//srvConn2.Password = password;
			//Server srv3 = new Server(srvConn2);
			//Console.WriteLine(srv3.Information.Version);

			if (authentication.ToLower() == "windows")
			{
				connectionString = "Data Source=" + remoteSvrName + ";Initial Catalog=" + dbName + ";Integrated Security=SSPI;";
			}
			else
			{
				connectionString = "Data Source=" + remoteSvrName + ";Initial Catalog=" + dbName + ";User ID=" +
				                   dbusername + ";Password=" + dbpassword + ";";
			}

			SqlConnection conn = new SqlConnection(connectionString);
			ServerConnection connectServer = new ServerConnection(conn);
			Server server = new Server(connectServer);
			conn.Open();
			server.ConnectionContext.ExecuteNonQuery(txtScripts.Text);
			conn.Close();
			MessageBox.Show("Script Executed Successfully!");
		}

		private void frmExecuteScript_Load(object sender, EventArgs e)
		{
			ReadSettingFile();
		}

		private void ReadSettingFile()
		{
			dataCollection = ERP.CommonLayer.Settings.ReadSettingFiles();
			foreach (var read in dataCollection)
			{
				switch (read.Key)
				{
					case "ServerName":
						serverName = read.Value;
						break;
					case "DatabaseName":
						databasename = read.Value;
						break;
					case "AuthenticationType":
						authentication = read.Value;
						break;
					case "DBUserName":
						dbusername = read.Value;
						break;
					case "DBPassword":
						dbpassword = read.Value;
						break;
				}
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnBrowseScriptFile_Click(object sender, EventArgs e)
		{
			var FD = new System.Windows.Forms.OpenFileDialog();
			if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				txtBrowseFile.Text = FD.FileName;
				string fileToOpen = FD.FileName;
				//System.IO.FileInfo File = new System.IO.FileInfo(FD.FileName);
				////OR
				System.IO.StreamReader reader = new System.IO.StreamReader(fileToOpen);
				//etc
				txtScripts.Text = reader.ReadToEnd();
			}
		}
	}
}

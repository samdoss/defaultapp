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
		

		public frmExecuteScript()
		{
			InitializeComponent();
		}

		private void btnExecute_Click(object sender, EventArgs e)
		{
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

			ApplicationConnection appConnection = new ApplicationConnection();

			SqlConnection conn = new SqlConnection(appConnection.ConnectionString);
			ServerConnection connectServer = new ServerConnection(conn);
			Server server = new Server(connectServer);
			conn.Open();
			server.ConnectionContext.ExecuteNonQuery(txtScripts.Text);
			conn.Close();
			MessageBox.Show("Script Executed Successfully!");
		}

		private void frmExecuteScript_Load(object sender, EventArgs e)
		{
			
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

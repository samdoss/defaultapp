using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERP.CommonLayer;

namespace ERPWinApp
{
	public partial class frmSettings : Form
	{
		Dictionary<string, string> dataCollection = new Dictionary<string, string>();
		private string connectionString = string.Empty;
		public frmSettings()
		{
			InitializeComponent();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			Dictionary<string, string> saveDataCollection = new Dictionary<string, string>();
			foreach (var read in dataCollection)
			{
				switch (read.Key)
				{
					case "ServerName":
						saveDataCollection.Add(read.Key, txtServerName.Text);
						break;
					case "DatabaseName":
						saveDataCollection.Add(read.Key, txtDatabaseName.Text);
						break;
					case "AuthenticationType":
						if(rbtnServer.Checked)
							saveDataCollection.Add(read.Key, "Server");
						else
							saveDataCollection.Add(read.Key, "Windows");
						break;
					case "DBUserName":
						saveDataCollection.Add(read.Key, txtUserID.Text);
						break;
					case "DBPassword":
						saveDataCollection.Add(read.Key, txtPassword.Text);
						break;
					case "CurrentDate":
						saveDataCollection.Add(read.Key, DateTime.Now.ToString());
						break;
				}
			}
			Settings.SaveSettingFile(saveDataCollection);
			MessageBox.Show("Saved Successfully!");
		}

		private void frmSettings_Load(object sender, EventArgs e)
		{
			Settings.CreateSettingFile();
			dataCollection = Settings.ReadSettingFiles();

			foreach (var read in dataCollection)
			{
				switch (read.Key)
				{
					case "ServerName":
						txtServerName.Text = read.Value;
						break;
					case "DatabaseName":
						txtDatabaseName.Text = read.Value;
						break;
					case "AuthenticationType":
						if (read.Value == "Windows")
						{
							rbtnWindows.Checked = true;
							rbtnServer.Checked = false;
							txtUserID.Enabled = false;
							txtPassword.Enabled = false;
						}
						else
						{
							rbtnServer.Checked = true;
							rbtnWindows.Checked = false;
							txtUserID.Enabled = true;
							txtPassword.Enabled = true;
						}
						break;
					case "DBUserName":
						txtUserID.Text = read.Value;
						break;
					case "DBPassword":
						txtPassword.Text = read.Value;
						break;
					case "ProductExpiredDays":
						lblExpireinDays.Text = read.Value;
						break;
					case "InstalledDate":
						lblInstalledDateValue.Text = read.Value;
						break;
					case "CurrentDate":
						//txtServerName.Text = read.Value;
						break;
				}
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnTestConnection_Click(object sender, EventArgs e)
		{
			if (rbtnServer.Checked)
			{
				connectionString = "Data Source=" + txtServerName.Text + ";Initial Catalog=" + txtDatabaseName.Text + ";User ID=" +
				                   txtUserID.Text + ";Password=" + txtPassword.Text + ";";
			}
			else
			{
				connectionString = "Data Source=" + txtServerName.Text + ";Initial Catalog=" + txtDatabaseName.Text + ";Integrated Security=SSPI;";
			}

			using (SqlConnection conn = new SqlConnection())
			{
				// Create the connectionString
				// Trusted_Connection is used to denote the connection uses Windows Authentication
				conn.ConnectionString = connectionString;
				try
				{
					conn.Open();
					conn.Close();
					MessageBox.Show("Sqlserver Connected ! ");
				}
				catch (Exception ex)
				{
					MessageBox.Show("Sqlserver Connection Failed ! " + ex.Message.ToString());
				}
			}
		}

		private void rbtnServer_CheckedChanged(object sender, EventArgs e)
		{
			if (rbtnServer.Checked)
			{
				rbtnWindows.Checked = false;
				txtUserID.Enabled = true;
				txtPassword.Enabled = true;
			}
		}

		private void rbtnWindows_CheckedChanged(object sender, EventArgs e)
		{
			if (rbtnWindows.Checked)
			{
				rbtnServer.Checked = false;
				txtUserID.Enabled = false;
				txtPassword.Enabled = false;
			}
		}
	}
}

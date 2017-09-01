using ERP.CommonLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPWinApp
{
	static class Program
	{
		#region Private Variable

		static Mutex mutex;

		#endregion

		#region Private Method(s)
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			try
			{
				string Period = "";
				if (!IsAlreadyRunning())
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					DateTime dt = Directory.GetCreationTime(Environment.CurrentDirectory);

					string appSettingDirectory = Common.GetAllUserPath();

					if (!Directory.Exists(appSettingDirectory))
						Directory.CreateDirectory(appSettingDirectory);

					if (!File.Exists(Path.Combine(appSettingDirectory, "Settings.xml")))
					{
						frmSettings dbSettings = new frmSettings();
						dbSettings.ShowDialog();
					}


					//frmRoleMaster fm = new frmRoleMaster();
					//fm.ShowDialog();

					frmLogin frm = new frmLogin();

					// Give feedback to the user.
					if (DateTime.Now.Subtract(dt).TotalDays > 364)
					{
						Period = Convert.ToInt32(DateTime.Now.Subtract(dt).TotalDays).ToString();
					}
					else if (DateTime.Now.Subtract(dt).TotalDays > 90)
					{
						Period = Convert.ToInt32(DateTime.Now.Subtract(dt).TotalDays).ToString();
					}
					else if (DateTime.Now.Subtract(dt).TotalDays <= 1)
					{
						Period = Convert.ToInt32(DateTime.Now.Subtract(dt).TotalDays).ToString();
					}
					else
					{
						//MessageBox.Show("This directory was created on {0}." + dt + Convert.ToString(DateTime.Now.Subtract(dt).TotalDays));
						Period = Convert.ToInt32(DateTime.Now.Subtract(dt).TotalDays).ToString();
					}
					frm.IsPeriodValid = Period.ToString();
					DialogResult result = frm.ShowDialog();
					if (result == DialogResult.OK)
						Application.Run(new MDIForm());
				}
				else
				{
					MessageBox.Show("A Copy of The Software is Already Open. Please Check Your System Tray (Notification Area)", "ERP ", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Environment.Exit(0);
					Application.Exit();
				}
			}
			catch { }
		}

		#endregion

		#region Private Method(s)

		private static bool IsAlreadyRunning()
		{
			string strLoc = System.Reflection.Assembly.GetExecutingAssembly().Location;
			FileSystemInfo fileInfo = new FileInfo(strLoc);
			string sExeName = fileInfo.Name;
			bool bCreatedNew;

			mutex = new Mutex(true, "Global\\" + sExeName, out bCreatedNew);
			if (bCreatedNew)
				mutex.ReleaseMutex();

			return !bCreatedNew;
		}

		#endregion
	}
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace ERPWinApp
{
	public partial class frmBackup : Form
	{
		public frmBackup()
		{
			InitializeComponent();
		}

		private void btnBackupLocation_Click(object sender, EventArgs e)
		{

		}

		private void frmBackup_Load(object sender, EventArgs e)
		{
			Server myServer = new Server(@"ARSHADALI-LAP\ARSHADALI");
			try
			{
				//Using windows authentication 
				myServer.ConnectionContext.LoginSecure = true;
				myServer.ConnectionContext.Connect();
				Database myDatabase = myServer.Databases["AdventureWorks"];
				BackupDatabaseFull(myServer, myDatabase);
				//BackupDatabaseDifferential(myServer, myDatabase); 
				//BackupDatabaseLog(myServer, myDatabase); 
				//BackupDatabaseFullWithCompression(myServer, myDatabase);
				RestoreDatabase(myServer, myDatabase);
				//RestoreDatabaseLog(myServer, myDatabase); 
				//RestoreDatabaseWithDifferentNameAndLocation(myServer, myDatabase); 
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.InnerException.Message);
			}
			finally
			{
				if (myServer.ConnectionContext.IsOpen)
					myServer.ConnectionContext.Disconnect();
				Console.WriteLine("Press any key to terminate...");
				Console.ReadKey();
			}
		}

		private void btnProcess_Click(object sender, EventArgs e)
		{

		}

		private static void BackupDatabaseFull(Server myServer, Database myDatabase)
		{
			Backup bkpDBFull = new Backup();
			/* Specify whether you want to back up database or files or log */
			bkpDBFull.Action = BackupActionType.Database;
			/* Specify the name of the database to back up */
			bkpDBFull.Database = myDatabase.Name;
			/* You can take backup on several media type (disk or tape), here I am using * File type and storing backup on the file system */
			bkpDBFull.Devices.AddDevice(@"D:\AdventureWorksFull.bak", DeviceType.File);
			bkpDBFull.BackupSetName = "Adventureworks database Backup";
			bkpDBFull.BackupSetDescription = "Adventureworks database - Full Backup";
			/* You can specify the expiration date for your backup data * after that date backup data would not be relevant */
			bkpDBFull.ExpirationDate = DateTime.Today.AddDays(10);
			/* You can specify Initialize = false (default) to create a new * backup set which will be appended as last backup set on the media. You can * specify Initialize = true to make the backup as first set on the mediuam and * to overwrite any other existing backup sets if the all the backup sets have * expired and specified backup set name matches with the name on the medium */
			bkpDBFull.Initialize = false; /* Wiring up events for progress monitoring */
			bkpDBFull.PercentComplete += CompletionStatusInPercent;
			bkpDBFull.Complete += Backup_Completed; /* SqlBackup method starts to take back up * You cab also use SqlBackupAsync method to perform backup * operation asynchronously */
			bkpDBFull.SqlBackup(myServer);
		}
		private static void BackupDatabaseDifferential(Server myServer, Database myDatabase)
		{
			Backup bkpDBDifferential = new Backup();
			/* Specify whether you want to back up database or files or log */
			bkpDBDifferential.Action = BackupActionType.Database;
			/* Specify the name of the database to back up */
			bkpDBDifferential.Database = myDatabase.Name;
			/* You can take backup on several media type (disk or tape), here I am using * File type and storing backup on the file system */
			bkpDBDifferential.Devices.AddDevice(@"D:\AdventureWorksDifferential.bak", DeviceType.File);
			bkpDBDifferential.BackupSetName = "Adventureworks database Backup";
			bkpDBDifferential.BackupSetDescription = "Adventureworks database - Differential Backup";
			/* You can specify the expiration date for your backup data * after that date backup data would not be relevant */
			bkpDBDifferential.ExpirationDate = DateTime.Today.AddDays(10);
			/* You can specify Initialize = false (default) to create a new * backup set which will be appended as last backup set on the media. You can * specify Initialize = true to make the backup as first set on the mediuam and * to overwrite any other existing backup sets if the all the backup sets have * expired and specified backup set name matches with the name on the medium */
			bkpDBDifferential.Initialize = false;
			/* You can specify Incremental = false (default) to perform full backup * or Incremental = true to perform differential backup since most recent * full backup */
			bkpDBDifferential.Incremental = true;
			/* Wiring up events for progress monitoring */
			bkpDBDifferential.PercentComplete += CompletionStatusInPercent;
			bkpDBDifferential.Complete += Backup_Completed;
			/* SqlBackup method starts to take back up * You cab also use SqlBackupAsync method to perform backup * operation asynchronously */
			bkpDBDifferential.SqlBackup(myServer);
		}
		private static void BackupDatabaseLog(Server myServer, Database myDatabase)
		{
			Backup bkpDBLog = new Backup(); /* Specify whether you want to back up database or files or log */
			bkpDBLog.Action = BackupActionType.Log;
			/* Specify the name of the database to back up */
			bkpDBLog.Database = myDatabase.Name;
			/* You can take backup on several media type (disk or tape), here I am using * File type and storing backup on the file system */
			bkpDBLog.Devices.AddDevice(@"D:\AdventureWorksLog.bak", DeviceType.File);
			bkpDBLog.BackupSetName = "Adventureworks database Backup";
			bkpDBLog.BackupSetDescription = "Adventureworks database - Log Backup";
			/* You can specify the expiration date for your backup data * after that date backup data would not be relevant */
			bkpDBLog.ExpirationDate = DateTime.Today.AddDays(10);
			/* You can specify Initialize = false (default) to create a new * backup set which will be appended as last backup set on the
			 * media. You can * specify Initialize = true to make the backup as first set on the mediuam and * to overwrite any 
			 * other existing backup sets if the all the backup sets have * expired and specified backup set name matches with the name on the medium */
			bkpDBLog.Initialize = false;
			/* Wiring up events for progress monitoring */
			bkpDBLog.PercentComplete += CompletionStatusInPercent;
			bkpDBLog.Complete += Backup_Completed;
			/* SqlBackup method starts to take back up * You cab also use SqlBackupAsync method to perform backup * operation asynchronously */
			bkpDBLog.SqlBackup(myServer);
		}

		private static void BackupDatabaseFullWithCompression(Server myServer, Database myDatabase)
		{
			Backup bkpDBFullWithCompression = new Backup();
			/* Specify whether you want to back up database or files or log */
			bkpDBFullWithCompression.Action = BackupActionType.Database;
			/* Specify the name of the database to back up */
			bkpDBFullWithCompression.Database = myDatabase.Name;
			/* You can use back up compression technique of SQL Server 2008, * specify CompressionOption property to On for compressed backup */
			bkpDBFullWithCompression.CompressionOption = BackupCompressionOptions.On;
			bkpDBFullWithCompression.Devices.AddDevice(@"D:\AdventureWorksFullWithCompression.bak", DeviceType.File);
			bkpDBFullWithCompression.BackupSetName = "Adventureworks database Backup - Compressed";
			bkpDBFullWithCompression.BackupSetDescription = "Adventureworks database - Full Backup with Compressin - only in SQL Server 2008";
			bkpDBFullWithCompression.SqlBackup(myServer);
		}

		private static void CompletionStatusInPercent(object sender, PercentCompleteEventArgs args)
		{
			Console.Clear();
			Console.WriteLine("Percent completed: {0}%.", args.Percent);
		}
		private static void Backup_Completed(object sender, ServerMessageEventArgs args)
		{
			Console.WriteLine("Hurray...Backup completed.");
			Console.WriteLine(args.Error.Message);
		}

		private static void Restore_Completed(object sender, ServerMessageEventArgs args)
		{
			Console.WriteLine("Hurray...Restore completed."); Console.WriteLine(args.Error.Message);

		}
		private static void RestoreDatabase(Server myServer, Database myDatabase)
		{
			Restore restoreDB = new Restore();
			restoreDB.Database = myDatabase.Name;
			/* Specify whether you want to restore database or files or log etc */
			restoreDB.Action = RestoreActionType.Database;
			restoreDB.Devices.AddDevice(@"D:\AdventureWorksFull.bak", DeviceType.File);
			/* You can specify ReplaceDatabase = false (default) to not create a new image * of the database, 
			 * the specified database must exist on SQL Server instance. * If you can specify ReplaceDatabase = true to create new database image 
			 * * regardless of the existence of specified database with same name */
			restoreDB.ReplaceDatabase = true;
			/* If you have differential or log restore to be followed, you would need * to specify NoRecovery = true, this will ensure no 
			 * recovery is done after the * restore and subsequent restores are allowed. It means it will database * in the Restoring state. */
			restoreDB.NoRecovery = true;
			/* Wiring up events for progress monitoring */
			restoreDB.PercentComplete += CompletionStatusInPercent; restoreDB.Complete += Restore_Completed;
			/* SqlRestore method starts to restore database * You cab also use SqlRestoreAsync method to perform restore * operation asynchronously */
			restoreDB.SqlRestore(myServer);
		}
		private static void RestoreDatabaseLog(Server myServer, Database myDatabase)
		{
			Restore restoreDBLog = new Restore();
			restoreDBLog.Database = myDatabase.Name;
			restoreDBLog.Action = RestoreActionType.Log;
			restoreDBLog.Devices.AddDevice(@"D:\AdventureWorksLog.bak", DeviceType.File);
			/* You can specify NoRecovery = false (default) so that transactions are * rolled forward and recovered. */
			restoreDBLog.NoRecovery = false;
			/* Wiring up events for progress monitoring */
			restoreDBLog.PercentComplete += CompletionStatusInPercent;
			restoreDBLog.Complete += Restore_Completed;
			/* SqlRestore method starts to restore database * You cab also use SqlRestoreAsync method to perform restore * operation asynchronously */
			restoreDBLog.SqlRestore(myServer);
		}
		private static void RestoreDatabaseWithDifferentNameAndLocation(Server myServer, Database myDatabase)
		{
			Restore restoreDB = new Restore();
			restoreDB.Database = myDatabase.Name + "New";
			/* Specify whether you want to restore database or files or log etc */
			restoreDB.Action = RestoreActionType.Database; restoreDB.Devices.AddDevice(@"D:\AdventureWorksFull.bak", DeviceType.File);
			/* You can specify ReplaceDatabase = false (default) to not create a new image * of the database, the specified database must 
			 * exist on SQL Server instance. * You can specify ReplaceDatabase = true to create new database image * regardless of the existence of 
			 * specified database with same name */
			restoreDB.ReplaceDatabase = true;
			/* If you have differential or log restore to be followed, you would need to specify NoRecovery = true, this will
			 * ensure no recovery is done after the restore and subsequent restores are allowed. It means it will database 
			 * in the Restoring state. */
			restoreDB.NoRecovery = false;
			/* RelocateFiles collection allows you to specify the logical file names and * physical file names (new locations)
			 * if you want to restore to a different location.*/
			restoreDB.RelocateFiles.Add(new RelocateFile("AdventureWorks_Data", @"D:\AdventureWorksNew_Data.mdf"));
			restoreDB.RelocateFiles.Add(new RelocateFile("AdventureWorks_Log", @"D:\AdventureWorksNew_Log.ldf"));
			/* Wiring up events for progress monitoring */
			restoreDB.PercentComplete += CompletionStatusInPercent;
			restoreDB.Complete += Restore_Completed;
			/* SqlRestore method starts to restore database * You cab also use SqlRestoreAsync method to perform restore * operation asynchronously */
			restoreDB.SqlRestore(myServer);
		}

	}
}
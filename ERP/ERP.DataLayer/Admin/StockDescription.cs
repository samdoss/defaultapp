using System.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using ERP.CommonLayer;

namespace ERP.DataLayer
{
	public class StockDescription
	{
		#region Constructor(s)

		public StockDescription()
		{
		}

		public StockDescription(int stockID, bool getAllProperties)
		{
			StockID = stockID;
			if (getAllProperties)
			{
				GetStock();
			}
		}

		#endregion

		#region Private Variables

		ApplicationConnection _appConnection = new ApplicationConnection();

		public int StockID { get; set; }
		public int 	MaterialID	{ get; set; }
		public int 	AvailableCount	{ get; set; }
		public decimal SupplierMaterialPrice	{ get; set; }
		public int AuditID { get; set; }
		public bool IsEnabled { get; set; }

		private List<StockDescription> _stockList;

		#endregion

		#region Public Properties

		public int AddEditOption { get; set; }
		
		public List<StockDescription> StockList
		{
			get { return _stockList; }
			set { _stockList = value; }
		}

		#endregion

		#region Public Methods

		public static DataSet GetStockList(ApplicationConnection _appConnection)
		{
			try
			{
				Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
				//Database db =CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
				string sqlCommand = "spGetStockList";
				DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
				return db.ExecuteDataSet(dbCommand);
			}
			catch (Exception ex)
			{
				//
				//
				//ErrorLog.LogErrorMessageToDB("StockDescription", "GetStockList");
			}
			return null;
		}

		public static List<StockDescription> GetEnableDisableStock(ApplicationConnection _appConnection, int MaterialID, bool EnableDisable)
		{
			List<StockDescription> _listStock = new List<StockDescription>();
			try
			{
				//Database db =CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
				Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
				string sqlCommand = "spGetEnabledDisabledStock";
				DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
                db.AddInParameter(dbCommand, "MaterialID", DbType.Int32, MaterialID);
				db.AddInParameter(dbCommand, "EnableDisable", DbType.Boolean, EnableDisable);
				using (SqlDataReader DataReader =
					((RefCountingDataReader) db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader
				) // (SqlDataReader)db.ExecuteReader(dbCommand))
				{
					if (DataReader.HasRows)
					{
						while (DataReader.Read())
						{
							StockDescription _sStock = new StockDescription();
							_sStock.StockID = Convert.ToInt32(DataReader["StockID"].ToString());
							_sStock.MaterialID = Convert.ToInt32(DataReader["MaterialID"].ToString());
							_sStock.AvailableCount = Convert.ToInt32(DataReader["AvailableCount"].ToString());
							_sStock.SupplierMaterialPrice = DataReader.GetDecimal(DataReader.GetOrdinal("SupplierMaterialPrice"));
							_listStock.Add(_sStock);
						}
					}
				}
				return _listStock;
			}
			catch (Exception ex)
			{
				//
				//
				//ErrorLog.LogErrorMessageToDB("StockDescription", "GetEnableDisableStocks");
			}
			return _listStock;
		}

		public static TransactionResult EnableDisableStock(ApplicationConnection _appConnection, int StockID,
			bool EnableDisable)
		{
			int _returnValue = 0;
			//Database db =CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
			Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
			string sqlCommand = "spEnableDisableStock";
			DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			db.AddInParameter(dbCommand, "StockID", DbType.Int32, StockID);
			db.AddInParameter(dbCommand, "EnableDisable", DbType.Boolean, EnableDisable);

			db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
				DataRowVersion.Default, _returnValue);

			db.ExecuteNonQuery(dbCommand);
			_returnValue = (Int32) db.GetParameterValue(dbCommand, "Return Value");

			if (_returnValue == -1)
				return new TransactionResult(TransactionStatus.Failure);
			else
				return new TransactionResult(TransactionStatus.Success);
		}

		public TransactionResult Commit(ScreenMode screenMode)
		{
			TransactionResult _result = null;
			//DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory());
			Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					switch (screenMode)
					{
						case ScreenMode.Add:
							if (_stockList != null)
							{
								foreach (StockDescription _StructsStock in _stockList)
								{
									_result = AddStock(_StructsStock, db, transaction);
									if (_result.Status == TransactionStatus.Failure)
									{
										transaction.Rollback();
										return _result;
									}
								}
							}
                            else
                            {
                                _result = AddStock(db, transaction);
                                if (_result.Status == TransactionStatus.Failure)
                                {
                                    transaction.Rollback();
                                    return _result;
                                }
                            }
							break;
						
						case ScreenMode.Delete:
							foreach (StockDescription _StructsStock in _stockList)
							{
								_result = DeleteStock(_StructsStock, db, transaction);
								if (_result.Status == TransactionStatus.Failure)
								{
									transaction.Rollback();
									return _result;
								}
							}
							break;
					}
					transaction.Commit();
					return _result;
				}
				catch
				{
					transaction.Rollback();
					if (screenMode == ScreenMode.Add)
						return new TransactionResult(TransactionStatus.Failure, "Failure Adding Stock Description.");
					if (screenMode == ScreenMode.Edit)
						return new TransactionResult(TransactionStatus.Failure, "Failure Updating Stock Description.");
					if (screenMode == ScreenMode.Delete)
						return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Stock Description.");
				}
			}
			return null;
		}

		#endregion

		#region Private Methods

		private TransactionResult AddStock(StockDescription _structsStock, Database db, DbTransaction transaction)
		{
			int _returnValue = 0;
			string sqlCommand = "spAddEditStock";
			DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

			db.AddInParameter(dbCommand, "StockID", DbType.Int32, _structsStock.StockID);
			db.AddInParameter(dbCommand, "MaterialID", DbType.Int32, _structsStock.MaterialID);
			db.AddInParameter(dbCommand, "AvailableCount", DbType.Int32, _structsStock.AvailableCount);
			db.AddInParameter(dbCommand, "SupplierMaterialPrice", DbType.Decimal, _structsStock.SupplierMaterialPrice);
			db.AddInParameter(dbCommand, "AuditID", DbType.Int32, _structsStock.AuditID);
			db.AddInParameter(dbCommand, "IsEnabled", DbType.Boolean, _structsStock.IsEnabled);
			db.AddInParameter(dbCommand, "AddEditOption", DbType.Int32, _structsStock.AddEditOption);
			db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
				DataRowVersion.Default, _returnValue);

			db.ExecuteNonQuery(dbCommand, transaction);
			_returnValue = (Int32) db.GetParameterValue(dbCommand, "Return Value");

			if (_returnValue == -1)
				return new TransactionResult(TransactionStatus.Failure, "Failure Adding Stock Description.");
			else
				return new TransactionResult(TransactionStatus.Success, "Stock Description Successfully Added.");
		}

        private TransactionResult AddStock(Database db, DbTransaction transaction)
        {
            int _returnValue = 0;
            string sqlCommand = "spAddEditStock";
            DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

            db.AddInParameter(dbCommand, "StockID", DbType.Int32, StockID);
            db.AddInParameter(dbCommand, "MaterialID", DbType.Int32, MaterialID);
            db.AddInParameter(dbCommand, "AvailableCount", DbType.Int32, AvailableCount);
            db.AddInParameter(dbCommand, "SupplierMaterialPrice", DbType.Decimal, SupplierMaterialPrice);
            db.AddInParameter(dbCommand, "AuditID", DbType.Int32, AuditID);
            db.AddInParameter(dbCommand, "IsEnabled", DbType.Boolean, IsEnabled);
            db.AddInParameter(dbCommand, "AddEditOption", DbType.Int32, AddEditOption);
            db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
                DataRowVersion.Default, _returnValue);

            db.ExecuteNonQuery(dbCommand, transaction);
            _returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

            if (_returnValue == -1)
                return new TransactionResult(TransactionStatus.Failure, "Failure Adding Stock Description.");
            else
                return new TransactionResult(TransactionStatus.Success, "Stock Description Successfully Added.");
        }

		private TransactionResult DeleteStock(StockDescription _StructsStock, Database db, DbTransaction transaction)
		{
			int _returnValue = 0;
			string sqlCommand = "spDeleteStock";
			DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			db.AddInParameter(dbCommand, "StockID", DbType.Int32, _StructsStock.StockID);
			db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
				DataRowVersion.Default, _returnValue);

			db.ExecuteNonQuery(dbCommand, transaction);
			_returnValue = (Int32) db.GetParameterValue(dbCommand, "Return Value");

			if (_returnValue == -1)
				return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Stock Description.");
			else
				return new TransactionResult(TransactionStatus.Success, "Stock Description Successfully Deleted.");
		}

		private void GetStock()
		{
			try
			{
				Database db = CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
				//Database db =CustomDatabaseFactory.CreateDatabase(_appConnection.ConnectionString);
				string sqlCommand = "spGetStock";
				DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
				db.AddInParameter(dbCommand, "StockID", DbType.Int32, StockID);
				using (SqlDataReader DataReader =
					((RefCountingDataReader) db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader
				) // (SqlDataReader)db.ExecuteReader(dbCommand))
				{
					if (DataReader.HasRows)
					{
						while (DataReader.Read())
						{
							StockID = Convert.ToInt32(DataReader["StockID"].ToString());
							MaterialID = Convert.ToInt32(DataReader["MaterialID"].ToString());
							AvailableCount = Convert.ToInt32(DataReader["AvailableCount"].ToString());
							SupplierMaterialPrice = DataReader.GetDecimal(DataReader.GetOrdinal("SupplierMaterialPrice"));
							IsEnabled = DataReader.GetBoolean(DataReader.GetOrdinal("IsEnabled"));
						}
					}
				}
			}
			catch (Exception ex)
			{
				ErrorLog.LogErrorMessageToDB("StockDescription", "GetEnableDisableStocks", "", ex.Message);
			}
		}

		#endregion



	}
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.CommonLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERP.DataLayer
{
	public class Material
	{
		#region Constructor(s)

		public Material()
		{

		}

		public Material(int materialID, bool getAllProperties)
		{
			MaterialID = materialID;
			if (getAllProperties)
			{
				GetMaterial();
			}
		}

        public Material(int materialID, string materialDescription)
        {
            this.MaterialID = materialID;
            this.MaterialDescription = materialDescription;
        }

		#endregion

		#region Private Variables

		ApplicationConnection applicationConnection = new ApplicationConnection();
        
		#endregion

		#region Public Properties

		public int ProductID { get; set; }

        public int SupplierID { get; set; }
		public int MaterialID { get; set; }

		public string MaterialDescription { get; set; }

		public string MaterialCode { get; set; }

		public string MaterialQuality { get; set; }

		public bool TaxInclusive { get; set; }

		public int TaxID { get; set; }

		public string TaxName { get; set; }

		public int UnitID { get; set; }

		public string Unit { get; set; }

		public decimal MaterialRate { get; set; }

		public string SpecialInstruction { get; set; }

		public int AuditUserID { get; set; }

		public bool IsEnabled { get; set; }

		public List<Material> MaterialList { get; set; }
        
		#endregion

		#region Public Methods

		#region Get Material List

		/// <summary>
		/// Get Material List
		/// </summary>
		/// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
		/// <returns>Return the data as Dataset</returns>
        
		public static DataSet GetMaterialList(ApplicationConnection applicationConnection, int productID)
		{
			try
			{
                Database db = CustomDatabaseFactory.CreateDatabase(applicationConnection.ConnectionString);
				string sqlCommand = "spGetMaterialList";
				DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
				db.AddInParameter(dbCommand, "ProductID", DbType.Int32, productID);
				return db.ExecuteDataSet(dbCommand);
			}
			catch (Exception ex)
			{
				ErrorLog.LogErrorMessageToDB("Material", "GetMaterialList", "", ex.Message);
			}
			return null;
		}
		#endregion

		#region Get Material Requisition

		/// <summary>
		/// Get Material Requisition
		/// </summary>
		/// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
		/// <returns>List</returns>

		public static List<Material> GetMaterialRequisition(ApplicationConnection applicationConnection, int productID)
		{
			List<Material> _listMaterial = new List<Material>();
			try
			{
                Database db = CustomDatabaseFactory.CreateDatabase(applicationConnection.ConnectionString);
				string sqlCommand = "spGetMaterials";
				DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
				db.AddInParameter(dbCommand, "ProductID", DbType.Int32, productID);
				using (SqlDataReader DataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
				{
					if (DataReader.HasRows)
					{
						while (DataReader.Read())
						{
							Material _sMaterial = new Material();
							_sMaterial.MaterialID = Convert.ToInt32(DataReader["MaterialID"].ToString());
							_sMaterial.MaterialDescription = DataReader.GetString(DataReader.GetOrdinal("MaterialDescription"));
							_sMaterial.ProductID = Convert.ToInt32(DataReader["ProductID"].ToString());
							_sMaterial.MaterialCode = DataReader.GetString(DataReader.GetOrdinal("MaterialCode"));
							_sMaterial.UnitID = Convert.ToInt32(DataReader["UnitID"].ToString());
							_sMaterial.Unit = DataReader.GetString(DataReader.GetOrdinal("Unit"));
							_sMaterial.MaterialQuality = DataReader.GetString(DataReader.GetOrdinal("MaterialQuality"));
							_sMaterial.TaxInclusive = Convert.ToBoolean(DataReader["TaxInclusive"].ToString());
							_sMaterial.TaxID = Convert.ToInt32(DataReader["TaxID"].ToString());
							_sMaterial.TaxName = DataReader.GetString(DataReader.GetOrdinal("TaxName"));
							_sMaterial.MaterialRate = Convert.ToDecimal(DataReader["MaterialRate"].ToString());
							_sMaterial.SpecialInstruction = DataReader.GetString(DataReader.GetOrdinal("SpecialInstruction"));
							_listMaterial.Add(_sMaterial);
						}
					}
				}
				return _listMaterial;
			}
			catch (Exception ex)
			{
				ErrorLog.LogErrorMessageToDB("Material", "GetMaterialRequisition", "",ex.Message);
			}
			return _listMaterial;
		}
		#endregion

		#region Get Enabled Or Disabled Material Parameter

		/// <summary>
		/// Get Enabled Or Disabled Material Parameter
		/// </summary>
		/// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
		/// <param name="ProductID">ProductID</param>
		/// <param name="EnabledOrDisabled">EnableDisable</param>
		/// <returns>List</returns>
        
		public static List<Material> GetEnableDisableMaterial(ApplicationConnection applicationConnection, int ProductID, int SupplierID, bool EnableDisable)
		{
			List<Material> _listMaterial = new List<Material>();
			try
			{
                Database db = CustomDatabaseFactory.CreateDatabase(applicationConnection.ConnectionString);
				string sqlCommand = "spGetEnabledDisabledMaterial";
				DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
				db.AddInParameter(dbCommand, "ProductID", DbType.Int32, ProductID);
                db.AddInParameter(dbCommand, "SupplierID", DbType.Int32, SupplierID);
				db.AddInParameter(dbCommand, "EnableDisable", DbType.Boolean, EnableDisable);
				using (SqlDataReader DataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
				{
					if (DataReader.HasRows)
					{
						while (DataReader.Read())
						{
							Material _sMaterial = new Material();

							_sMaterial.MaterialID = Convert.ToInt32(DataReader["MaterialID"].ToString());
							_sMaterial.MaterialDescription = DataReader.GetString(DataReader.GetOrdinal("MaterialDescription"));
							_sMaterial.ProductID = Convert.ToInt32(DataReader["ProductID"].ToString());
							_sMaterial.MaterialCode = DataReader.GetString(DataReader.GetOrdinal("MaterialCode"));
							_sMaterial.UnitID = Convert.ToInt32(DataReader["UnitID"].ToString());
							_sMaterial.Unit = DataReader.GetString(DataReader.GetOrdinal("Unit"));
							_sMaterial.MaterialQuality = DataReader.GetString(DataReader.GetOrdinal("MaterialQuality"));
							_sMaterial.TaxInclusive = Convert.ToBoolean(DataReader["TaxInclusive"].ToString());
							_sMaterial.TaxID = Convert.ToInt32(DataReader["TaxID"].ToString());
							_sMaterial.TaxName = DataReader.GetString(DataReader.GetOrdinal("TaxName"));
							_sMaterial.MaterialRate = Convert.ToDecimal(DataReader["MaterialRate"].ToString());
							_sMaterial.SpecialInstruction = DataReader.GetString(DataReader.GetOrdinal("SpecialInstruction"));
							_sMaterial.IsEnabled = DataReader.GetBoolean(DataReader.GetOrdinal("IsEnabled"));
							_listMaterial.Add(_sMaterial);
						}
					}
				}
				return _listMaterial;
			}
			catch (Exception ex)
			{
				ErrorLog.LogErrorMessageToDB("Material", "GetEnableDisableMaterial", "", ex.Message);
			}
			return _listMaterial;
		}

		#endregion

		#region Set Enable Or Disable the Material Parameter

		/// <summary>
		/// Set Enabled Or Disabled Material Parameter
		/// </summary>
		/// <param name="ApplicationConnection">Instance of the ApplicationConnection Class</param>
		/// <param name="MaterialID">MaterialID</param>
		/// <param name="EnabledOrDisabled">EnableDisable</param>
		/// <returns>TransactionResult</returns>
        
		public static TransactionResult EnableDisableMaterial(ApplicationConnection applicationConnection, int MaterialID, bool EnableDisable)
		{
			int _returnValue = 0;
            Database db = CustomDatabaseFactory.CreateDatabase(applicationConnection.ConnectionString);
			string sqlCommand = "spEnableDisableMaterials";
			DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			db.AddInParameter(dbCommand, "MaterialID", DbType.Int32, MaterialID);
			db.AddInParameter(dbCommand, "EnableDisable", DbType.Boolean, EnableDisable);

			db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
				DataRowVersion.Default, _returnValue);

			db.ExecuteNonQuery(dbCommand);
			_returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

			if (_returnValue == -1)
				return new TransactionResult(TransactionStatus.Failure);
			else
				return new TransactionResult(TransactionStatus.Success);
		}

		#endregion

		#region Commit Add/Update/Delete Transactions

		/// <summary>
		/// Commit Add/Update/Delete Transactions
		/// </summary>
		/// <param name="ScreenMode">ScreenMode</param>
		/// <returns>TransactionResult</returns>
        
		public TransactionResult Commit(ScreenMode screenMode)
		{
			TransactionResult _result = null;
            Database db = CustomDatabaseFactory.CreateDatabase(applicationConnection.ConnectionString);
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					switch (screenMode)
					{
						case ScreenMode.Add:
							if (MaterialList != null)
							{
								foreach (Material _structsMaterial in MaterialList)
								{
									_result = AddMaterial(_structsMaterial, db, transaction);
									if (_result.Status == TransactionStatus.Failure)
									{
										transaction.Rollback();
										return _result;
									}
								}
							}
							break;
						case ScreenMode.Edit:
							foreach (Material _structsMaterial in MaterialList)
							{
								_result = UpdateMaterial(_structsMaterial, db, transaction);
								if (_result.Status == TransactionStatus.Failure)
								{
									transaction.Rollback();
									return _result;
								}
							}
							break;
						case ScreenMode.Delete:
							foreach (Material _structsMaterial in MaterialList)
							{
								_result = DeleteMaterial(_structsMaterial, db, transaction);
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
						return new TransactionResult(TransactionStatus.Failure, "Failure Adding Material Description.");
					if (screenMode == ScreenMode.Edit)
						return new TransactionResult(TransactionStatus.Failure, "Failure Updating Material Description.");
					if (screenMode == ScreenMode.Delete)
						return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Material Description.");
				}
			}
			return null;
		}
		#endregion

		#endregion

		#region Private Methods

		private TransactionResult AddMaterial(Material _structsMaterial, Database db, DbTransaction transaction)
		{
			int _returnValue = 0;
			string sqlCommand = "spAddMaterial";
			DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

			db.AddInParameter(dbCommand, "ProductID", DbType.Int32, _structsMaterial.ProductID);
            db.AddInParameter(dbCommand, "SupplierID", DbType.Int32, _structsMaterial.SupplierID);
			db.AddInParameter(dbCommand, "MaterialDescription", DbType.String, _structsMaterial.MaterialDescription);
			db.AddInParameter(dbCommand, "MaterialCode", DbType.String, _structsMaterial.MaterialCode);
			db.AddInParameter(dbCommand, "MaterialQuality", DbType.String, _structsMaterial.MaterialQuality);
			db.AddInParameter(dbCommand, "TaxInclusive", DbType.Boolean, _structsMaterial.TaxInclusive);
			db.AddInParameter(dbCommand, "TaxID", DbType.Int32, _structsMaterial.TaxID);
			db.AddInParameter(dbCommand, "MaterialRate", DbType.Decimal, _structsMaterial.MaterialRate);
			db.AddInParameter(dbCommand, "UnitID", DbType.Int32, _structsMaterial.UnitID);
			db.AddInParameter(dbCommand, "SpecialInstruction", DbType.String, _structsMaterial.SpecialInstruction);

			db.AddInParameter(dbCommand, "AuditUserID", DbType.Int32, _structsMaterial.AuditUserID);
			db.AddInParameter(dbCommand, "IsEnabled", DbType.Boolean, _structsMaterial.IsEnabled);
			db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
				DataRowVersion.Default, _returnValue);

			db.ExecuteNonQuery(dbCommand, transaction);
			_returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

			if (_returnValue == -1)
				return new TransactionResult(TransactionStatus.Failure, "Failure Adding Material Description.");
			else
			{
				MaterialID = _returnValue;
				return new TransactionResult(TransactionStatus.Success, "Material Description Successfully Added.");
			}
		}

		private TransactionResult UpdateMaterial(Material _structsMaterial, Database db, DbTransaction transaction)
		{
			int _returnValue = 0;
			string sqlCommand = "spUpdateMaterial";
			DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			db.AddInParameter(dbCommand, "MaterialID", DbType.Int32, _structsMaterial.MaterialID);
			db.AddInParameter(dbCommand, "ProductID", DbType.Int32, _structsMaterial.ProductID);
			db.AddInParameter(dbCommand, "MaterialDescription", DbType.String, _structsMaterial.MaterialDescription);
			db.AddInParameter(dbCommand, "MaterialCode", DbType.String, _structsMaterial.MaterialCode);
			db.AddInParameter(dbCommand, "MaterialQuality", DbType.String, _structsMaterial.MaterialQuality);
			db.AddInParameter(dbCommand, "TaxInclusive", DbType.Boolean, _structsMaterial.TaxInclusive);
			db.AddInParameter(dbCommand, "TaxID", DbType.Int32, _structsMaterial.TaxID);
			db.AddInParameter(dbCommand, "MaterialRate", DbType.Decimal, _structsMaterial.MaterialRate);
			db.AddInParameter(dbCommand, "UnitID", DbType.Int32, _structsMaterial.UnitID);
			db.AddInParameter(dbCommand, "SpecialInstruction", DbType.String, _structsMaterial.SpecialInstruction);
			db.AddInParameter(dbCommand, "AuditUserID", DbType.Int32, _structsMaterial.AuditUserID);

			
			db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
				DataRowVersion.Default, _returnValue);

			db.ExecuteNonQuery(dbCommand, transaction);
			_returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

			if (_returnValue == -1)
				return new TransactionResult(TransactionStatus.Failure, "Failure Updating Material Description.");
			else
				return new TransactionResult(TransactionStatus.Success, "Material Description Successfully Updated.");
		}

		private TransactionResult DeleteMaterial(Material _StructsMaterial, Database db, DbTransaction transaction)
		{
			int _returnValue = 0;
			string sqlCommand = "spDeleteMaterial";
			DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
			db.AddInParameter(dbCommand, "MaterialID", DbType.Int32, _StructsMaterial.MaterialID);
			db.AddParameter(dbCommand, "Return Value", DbType.Int32, ParameterDirection.ReturnValue, "Return Value",
				DataRowVersion.Default, _returnValue);

			db.ExecuteNonQuery(dbCommand, transaction);
			_returnValue = (Int32)db.GetParameterValue(dbCommand, "Return Value");

			if (_returnValue == -1)
				return new TransactionResult(TransactionStatus.Failure, "Failure Deleting Material Description.");
			else
				return new TransactionResult(TransactionStatus.Success, "Material Description Successfully Deleted.");
		}

		private void GetMaterial()
		{
			try
			{
                Database db = CustomDatabaseFactory.CreateDatabase(applicationConnection.ConnectionString);
				string sqlCommand = "spGetMaterial";
				DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
				db.AddInParameter(dbCommand, "MaterialID", DbType.Int32, MaterialID);
				using (SqlDataReader DataReader = ((RefCountingDataReader)db.ExecuteReader(dbCommand)).InnerReader as SqlDataReader)
				{
					if (DataReader.HasRows)
					{
						while (DataReader.Read())
						{
							MaterialID = DataReader.GetInt32(DataReader.GetOrdinal("MaterialID"));
							MaterialDescription = DataReader.GetString(DataReader.GetOrdinal("MaterialDescription"));
							MaterialCode = DataReader.GetString(DataReader.GetOrdinal("MaterialCode"));
							MaterialQuality = DataReader.GetString(DataReader.GetOrdinal("MaterialQuality"));
							TaxInclusive = DataReader.GetBoolean(DataReader.GetOrdinal("TaxInclusive"));
							TaxID = DataReader.GetInt32(DataReader.GetOrdinal("TaxID"));
							MaterialRate = Convert.ToDecimal(DataReader["MaterialRate"].ToString());
							UnitID = DataReader.GetInt32(DataReader.GetOrdinal("UnitID"));
							Unit = DataReader.GetString(DataReader.GetOrdinal("Unit"));
							SpecialInstruction = DataReader.GetString(DataReader.GetOrdinal("SpecialInstruction"));
							IsEnabled = DataReader.GetBoolean(DataReader.GetOrdinal("IsEnabled"));
						}
					}
				}
			}
			catch (Exception ex)
			{
				ErrorLog.LogErrorMessageToDB("Material", "GetMaterial","", ex.Message);
			}
		}
		#endregion
	}
}

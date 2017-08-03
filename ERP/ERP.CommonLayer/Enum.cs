using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.CommonLayer
{

	/// <summary>
	/// Enums for User's Screen Mode
	/// </summary>
	public enum ScreenMode
	{
		Add = 1,
		Edit = 2,
		View = 3,
		Delete = 4
	}

	/// <summary>
	/// TransactionStatus defines whether the transaction was successful or failed.
	/// </summary>
	public enum TransactionStatus
	{
		/// <summary>
		/// Transaction was successful
		/// </summary>
		Success,
		/// <summary>
		/// Transaction failed
		/// </summary>
		Failure
	}

	/// <summary>
	/// Enums for Address's Category
	/// </summary>
	public enum AddressCategory
	{
		User = 1
	}

	/// <summary>
	/// Enums for Contacts
	/// </summary>
	public enum ContactType
	{
		Telephone = 1,
		Fax = 2,
		Mobile = 3,
		Pager = 4
	}

	/// <summary>
	/// Enums for ShowStatus
	/// </summary>
	public enum ShowStatus
	{
		Enabled = 1,
		Disabled = 2
	}

	/// <summary>
	/// Enums for Pyment Mode
	/// </summary>
	public enum PaymentMode
	{
		Cash = 1,
		Cheque = 2,
		DemandDraft = 3,
		CreditOrDebitCard = 4
	}
    
}
